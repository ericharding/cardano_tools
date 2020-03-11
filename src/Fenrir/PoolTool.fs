module PoolTool
open FSharp.Data
open System.Net.Http
open System
open Thoth.Json.Net
open FSharp.Data.HttpRequestHeaders

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

// https://github.com/papacarp/pooltool.io/blob/master/sendmytip.sh
let submit poolId userId (data:Jormungandr.NodeStats)  =
  let platformName = "Fenrir"
  ()

module SendLogs =
  open FSharp.Data
  type SendLogsConfig = {
    // apiPort : uint32
    poolId : string
    userId : string
    genesis : string
    // keyLocation : string
    statsFile : string
    leaderFile : string
  }

  let sendlogsUri = "https://api.pooltool.io/v0/sendlogs"
  let badValue = "error"

  let getConfig() =
    let getenv i def =
      match System.Environment.GetEnvironmentVariable i with
      | null -> def
      | str -> str
    { poolId = getenv "MY_POOL_ID" badValue
      userId = getenv "MY_USER_ID" badValue
      genesis = getenv "THIS_GENESIS" "8e4d2a343f3dcf93" 
      statsFile = "stats.log"
      leaderFile = "leader.log"
    }

  let submitData (config:SendLogsConfig) (epoch:string) (leader:Jormungandr.LeaderLog[]) =
    let assignedSlots =
      leader 
      |> Array.filter (fun l -> l.scheduled_at_date.StartsWith(epoch))
      |> Array.length
    printfn "Epoch: %s" epoch
    printfn "assigned slots: %i" assignedSlots
    let payload = 
      sprintf """{ "currentepoch": "%s", "poolid": "%s", "genesispref": "%s", "userid": "%s", "assigned_slots": "%s" }""" 
        epoch 
        config.poolId
        config.genesis
        config.userId
        (string assignedSlots)
    printfn "%s" payload
    // let r = 
    //   Http.RequestString(
    //     sendlogsUri, 
    //     headers = [ContentType HttpContentTypes.Json], 
    //     body = TextRequest payload)
    // printfn "Response: %s" r

  let sendLogs () =
    let config = getConfig()
    if config.poolId = badValue || config.userId = badValue then
      printfn "Hey Umed, One or more variables is not set."
    else
      let nodeStats = Jormungandr.getNodeStatsFromFile config.statsFile
      let leaderStats = Jormungandr.getLeaderLogFromFile config.leaderFile
      match nodeStats, leaderStats with
      | Ok node, Ok leader -> 
        match node.lastBlockDate.Split('.') |> Array.tryHead with
        | Some epoch -> submitData config epoch leader
        | None -> printfn "Invalid last block date: %s" node.lastBlockDate
      | Error e, _ -> 
        printfn "Failed to read node stats: %s" e
      | _, Error e -> 
        printfn "Failed to read leader stats: %s" e


