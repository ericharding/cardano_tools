module Jormungandr

open System
open System.Net.Http
open Thoth.Json.Net
open Newtonsoft.Json

type Connection = private {
  baseUri: Uri
  client : HttpClient
}
 with 
 interface IDisposable with
   member this.Dispose() = this.client.Dispose()

let connect (uri : Uri) =
  { baseUri = uri
    client = new HttpClient() }

let private get (c:Connection) method : Async<Result<string,string>> =
  use request = new HttpRequestMessage()
  request.Method <- HttpMethod("GET")
  request.Headers.Accept.Add(Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"))
  request.RequestUri <- Uri(c.baseUri, Uri(method, UriKind.Relative))
  async {
    let! response = 
      c.client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
      |> Async.AwaitTask
    match int response.StatusCode with
    | 200 -> 
      let! data = response.Content.ReadAsStringAsync() |> Async.AwaitTask
      printfn "%s" data
      return Ok data
    | _ -> 
      return Error (sprintf "Http error %A" response.StatusCode)
  }

let private decode<'a,'e> decode (r:Result<string,'e>) : Result<'a,'e> =
  match r with
  | Ok r' ->
    decode r'
  | Error e -> Error e

let inline private newtonSoftDecode<'a> r =
  Async.map (Result.bind (JsonConvert.DeserializeObject<'a> >> Ok)) r

let private extraCoders = Extra.empty |> Extra.withInt64 |> Extra.withUInt64

let inline private thothDecodeString<'a> s =
  let decoder = Decode.Auto.generateDecoderCached<'a>(extra = extraCoders)
  Decode.fromString decoder s

let inline private thothDecode<'a> r =
  let fromString = thothDecodeString<'a> |> Result.bind
  Async.map fromString r

let inline private defaultDecode<'a> r : Async<Result<'a,string>> = 
  // Thoth handles union types out of the box
  // newtonSoftDecode<'a> r
  thothDecode<'a> r


type Diagnostics = {
  open_file_limit : uint32
  cpu_usage_limit : uint64
}
let getDiagnostic (c:Connection) =
  get c "/api/v0/diagnostic" |> defaultDecode<Diagnostics>

type NodeState =
  | StartingRestServer
  | PreparingStorage
  | PreparingBlock0
  | Bootstrapping
  | StartingWorkers
  | Running

type LeaderLog = {
  created_at_time : DateTime
  scheduled_at_time: DateTime
  scheduled_at_date: string
  wake_at_time: DateTime option
  finished_at_time: DateTime option
  // status : string
  enclave_leader_id : int
}

type NodeStats = {
  version: string
  blockRecvCnt : int
  lastblockContentSize : int option
  lastBlockDate : string
  lastBlockFees : int
  lastBlockHash : string
  lastBlockHeight : Tip
  lastBlockSum : int
  lastBlockTime : DateTime
  lastReceivedBlockTime: DateTime
  uptime: int
  state: NodeState
  txRecvCnt: uint32
}

let getLeaderLog c =
  get c "/api/v0/leaders/logs" |> defaultDecode<LeaderLog[]>

let getLeaderLogFromFile file =
  let lines = System.IO.File.ReadAllText file
  thothDecodeString<LeaderLog[]> lines

let getNodeStats c =
  get c "/api/v0/node/stats" |> defaultDecode<NodeStats>

let getNodeStatsFromFile file =
  System.IO.File.ReadAllText file
  |> thothDecodeString<NodeStats>

type PerCertificateFee = {
  certificate_pool_registration: uint64 option
  certificate_stake_delegation: uint64 option
  certificate_owner_stake_delegation: uint64 option
}
type LinearFee = {
    constant: uint64
    coefficient: uint64
    certificate: uint64
    per_certificate_fees: PerCertificateFee option
}
type Ratio = {
  numerator : uint64
  denominator : uint64
}
type CompoundingType = Linear | Halvening
type RewardParams = {
  // todo: Can we use thoth toth to parse this as a proper DU?
  // see reward_parameters.rs
  compoundingRatio : Ratio
  compoundingType : CompoundingType
  epochRate : uint32
  epochStart : uint64
  initialValue : uint64
}
type TaxType = {
  ``fixed`` : uint64
  ratio : Ratio
  max : uint64 option
}

// settings.rs
type Settings = {
  block0Hash : string
  block0Time : DateTime
  currSlotStartTime: DateTime option
  consensusVersion: string // bft or genesis
  fees : LinearFee
  blockContentMaxSize : uint32
  epochStabilityDepth: uint32
  slotDuration : uint64
  slotsPerEpoch : uint32

  treasuryTax : TaxType
  rewardParams : RewardParams
}

let getSettings c =
  get c "/api/v0/settings" |> defaultDecode<Settings>



