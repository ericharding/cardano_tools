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

let private get (c:Connection) method : Async<Result<string,string>> =
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
  Async.map (decode<'a,_> (JsonConvert.DeserializeObject<_> >> Ok)) r
let inline private defaultDecode<'a> r : Async<Result<'a,string>> = newtonSoftDecode<'a> r

// let private extraCoders = Extra.empty |> Extra.withInt64
// let private diagDecoder = Decode.Auto.generateDecoderCached<Diagnostics>(extra = extraCoders)

type Diagnostics = {
  open_file_limit : uint32
  cpu_usage_limit : uint64
}
let getDiagnostic (c:Connection) =
  get c "/api/v0/diagnostic" |> defaultDecode<Diagnostics>

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
  get c "/api/v0/node/stats" |> defaultDecode<NodeStats>

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
  currSlotStartTime: DateTime // option
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
  get c "/api/v0/settings" |> defaultDecode<Settings>

