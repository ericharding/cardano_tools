module Jormangandr

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

let connect baseUri =
  { baseUri = Uri(baseUri, UriKind.Absolute) 
    client = new HttpClient() }

let private get<'a> (c:Connection) method decoder : Async<Result<'a,string>> =
  use request = new HttpRequestMessage()
  request.Method <- HttpMethod("GET")
  request.Headers.Accept.Add(Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"))
  request.RequestUri <- new Uri(c.baseUri, Uri(method, UriKind.Relative))
  async {
    let! response = 
      c.client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
      |> Async.AwaitTask
    match int response.StatusCode with
    | 200 -> 
      let! data = response.Content.ReadAsStringAsync() |> Async.AwaitTask
      printfn "%s" data
      return decoder data
    | _ -> 
      return Error (sprintf "Http error %A" response.StatusCode)
  }

// let private extraCoders = Extra.empty |> Extra.withInt64
// let private diagDecoder = Decode.Auto.generateDecoderCached<Diagnostics>(extra = extraCoders)

type Diagnostics = {
  open_file_limit : uint32
  cpu_usage_limit : uint64
}
let getDiagnostic (c:Connection) =
  get<Diagnostics> c "/api/v0/diagnostic" (JsonConvert.DeserializeObject<_> >> Ok)

type NodeStats = {
  blockRecvCnt : int
  lastblockContentSize : int
  lastBlockDate : string
  lastBlockFees : int
  lastBlockHash : string
  lastBlockHeight : int
  lastBlockSum : int
  lastBlockTime : DateTime
  lastReceivedBlockTime: DateTime
  uptime: int
  state: string
  txRecvCnt: string
  version: string
}
let getNodeStats c =
  get<NodeStats> c "/api/v0/node/stats" (JsonConvert.DeserializeObject<_> >> Ok)

type PerCertificateFee = {
  certificate_pool_registration: uint64
  certificate_stake_delegation: uint64
  certificate_owner_stake_delegation: uint64
}
type LinearFee = {
    constant: uint64
    coefficient: uint64
    certificate: uint64
    per_certificate_fees: PerCertificateFee
}
type Ratio = {
  numerator : uint64
  denominator : uint64
}
type RewardParams = {
  // todo: Can we use thoth toth to parse this as a proper DU?
  // see reward_parameters.rs
  compoundingType : string // Linear / Halvening
  constant : uint64
  ratio : Ratio
  epochStart : uint64
  epochRate : uint64
}
type TaxType = {
  ``fixed`` : uint64
  ratio : Ratio
  max : uint64
}
// settings.rs
type Settings = {
  block0Hash : string
  block0Time : string
  currSlotStartTime: DateTime
  consensusVersion: string
  fees : LinearFee
  blockContentMaxSize : uint32
  epochStabilityDepth: uint32
  slotDuration : uint64
  slotsPerEpoch : uint32

  treasuryTax : TaxType
  rewardParams : RewardParams
}

let getSettings c =
  get<Settings> c "/api/v0/settings" (JsonConvert.DeserializeObject<_> >> Ok)

