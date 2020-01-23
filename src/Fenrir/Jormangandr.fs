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
}
let getNodeStats c =
  get<NodeStats> c "/api/v0/node/stats" (JsonConvert.DeserializeObject<_> >> Ok)
