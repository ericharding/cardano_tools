module PoolTool
open FSharp.Data
open System.Net.Http
open System
open Thoth.Json.Net

let heightsUri = Uri "https://pooltool.s3-us-west-2.amazonaws.com/stats/heights.json"

type HeightStats = {
  majoritymax : Tip
  syncd : int
  samples : int
}
type HeightData = {
  tips : Map<string,Tip>
  stats : HeightStats
}

let private get (client:HttpClient) : Async<Result<string,string>> =
  use request = new HttpRequestMessage()
  request.Method <- HttpMethod("GET")
  request.Headers.Accept.Add(Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"))
  request.RequestUri <- heightsUri
  async {
    let! response = 
      client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
      |> Async.AwaitTask
    match int response.StatusCode with
    | 200 -> 
      let! data = response.Content.ReadAsStringAsync() |> Async.AwaitTask
      return Ok data
    | _ -> 
      return Error (sprintf "Http error %A" response.StatusCode)
  }

let getHeights() =
  use client = new HttpClient()
  let decoder = Decode.Auto.generateDecoderCached<HeightData>()
  let fromString = Decode.fromString decoder |> Result.bind
  get client 
  |> Async.map fromString
  |> Async.RunSynchronously
