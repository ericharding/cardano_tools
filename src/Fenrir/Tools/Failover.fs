module Failover
open System
open Log

// Taking inspiration from
// https://raw.githubusercontent.com/rdlrt/Alternate-Jormungandr-Testnet/master/scripts/jormungandr-leaders-failover.sh

type Node = {
  address : Uri
  connection : Jormungandr.Connection
}

type Settings = {
  slotDuration : uint64
  slotsPerEpoch : uint64
  chainStart : DateTime
  timeout : TimeSpan
}

module Option =
  let ofResult = function
  | Ok o -> Some o
  | Error _ -> None

let getScheduleInfo (n:Node) =
  Jormungandr.getSettings n.connection
  |> Async.RunSynchronously
  |> Option.ofResult

let toNode (s:string) =
  match Uri.TryCreate(s, System.UriKind.Absolute) with
  | true, uri -> 
    Some { address = uri; connection = Jormungandr.connect uri }
  | false, _ -> 
    log Err "Invalid Uri '%s'" s
    None


let rec main (nodes:Node list) (settings:Settings) =
  let curSlot = Time.currSlot settings.chainStart settings.slotsPerEpoch settings.slotDuration
  let diffEpochEnd = settings.slotsPerEpoch - curSlot
  // Check node stats, see which node is ahead
  // If a node has been ahead for N checks promote it to leader

  // If a node is N blocks behind tip
  // kill it and restart?

  // get schedule, if we're 5 minutes from scheduled block restart the leader
  // if we're 1 minute from schedule block and leader isn't healthy promote next
  printfn "%d " diffEpochEnd
  ()


let run (addr : string list) =
  // parse address to uri and remove any invalid
  let nodes = List.choose toNode addr
  if List.length nodes = 0 then
    log Err "Empty node list"
  else
    let settings = List.tryPick getScheduleInfo nodes
    match settings with
    | None ->
      log Err "Failed to read settings. Are all nodes down?"
    | Some s -> 
      log Info "Starting failover daemon monitoring %i nodes" (List.length nodes)
      main 
        nodes
        { slotsPerEpoch = uint64 s.slotsPerEpoch
          slotDuration = s.slotDuration
          chainStart = s.block0Time
          timeout = TimeSpan.FromSeconds(30.) } 
