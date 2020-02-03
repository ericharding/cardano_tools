module NodeRunner
open System
open Log
//A. Stuck Notifier:
//Threshold time=300s
//1. Poll jormungandr node for latest block tip every 5 sec. (+ read logs for errors i.e. "stuck notifier")
//2. If there the tip does not progress after 300s:
     // check external sources for the tip (i) pooltool.io (ii) shelleyexplorer for the tip:
              // if the tips match--continue checking the tip (goto 1), if not:
              // send and email/text to operator with chain progress  error + time. 
              // restart the node. goto 1 [loop] 
              
//B. Strategic Node Restart:
//Get leader schedule at 2.14PM every day.
//Create a restart schedule for the node: 20 min before each block creation time
//When the nodes hits the designated time: (i) restart the node, monitor chain for 4 min for new blocks. 
//if no blocks for 4 min--notify node operator(email/text) every minute 6x times
    //if node receives blocks: check progress + check with external data sources 
         //if node catches up, send a success! alert to node operator
    //else restart the node--send an alert to operator   

//C. Keep Node Alive:
//1. Check if node is running (every 30 seconds or every 10 seconds if block creation < 20 min):
      //if not running-->restart
           //if running-->check stats--> (set timer)
                //if checking block0 or bootstrapping > 5 min.--> send alert to operator --> restart
                //else goto 1
                
//D. Block Performance
//Call leader logs --> count the number of blocks to be created from schedule
  //if block creation error--> notify operator 
//After each block creation event-->check if block hash has decendants (this confirms someone built upon our tip) 
   //keep track of blocks built on forks 
//Calculate the stats: 
//--wake up time vs. scheduled time
//--block completion time vs. wakeup vs. schedule
//--network propagation time (how long it took the network to send the block info back to us as a new tip)
//--blocks built on forks vs healthy blocks.

type SNConfig = {
  threshHold : TimeSpan
  pollInterval : TimeSpan
  externalTipInterval : TimeSpan
  maxTrailing : int
}
type Config = {
  snc : SNConfig
}
type SNState = {
  lastChecked : DateTime
  externalTip : Tip
  externalTipTime : DateTime
}
type SNResult =
  | Good of SNState
  | Bad

let checkExternalSourcesForGoodTip() =
  let pt = PoolTool.getHeights()
  // Todo: Check list of explorer nodes
  match pt with
  | Ok p -> 
    if p.stats.syncd > 10 then
      Some p.stats.majoritymax
    else
      None
  | Error _ -> None

let stuckNotifier (con:Jormungandr.Connection) (now:DateTime) (config:SNConfig) (state:SNState)  =
  let state' = { state with lastChecked = now }
  if now - state.lastChecked < config.pollInterval then
    Good state'
  else
   // todo: read logs 
   match Jormungandr.getNodeStats con |> Async.RunSynchronously with
   | Ok stats -> 
      match stats.state with
      | Jormungandr.Running -> 
        let tipAge = now - stats.lastBlockTime
        if tipAge > config.threshHold then
          let externalTip = checkExternalSourcesForGoodTip()
          match externalTip with
          | Some t when t <= stats.lastBlockHeight -> 
            log Warn "Tip has not advanced in %A but matches external tip" tipAge
            Good { 
              state with 
                externalTip = t
                externalTipTime = now
                lastChecked = now }
          | Some t ->
            log Err "Our block has not advanced since %A. External tip ahead by %i" (stats.lastBlockTime) (t - stats.lastBlockHeight)
            Bad
          | None -> 
            log Err "Our block has not advanced since %A. External tip is unavailable." (stats.lastBlockTime)
            Bad
        else
          if now - state.externalTipTime > config.externalTipInterval then
            match checkExternalSourcesForGoodTip() with
            | Some t when t <= stats.lastBlockHeight + config.maxTrailing -> 
              log Info "External tip ahead by %i" (t - stats.lastBlockHeight)
              Good { 
                state with 
                  externalTip = t
                  externalTipTime = now
                  lastChecked = now }
            | Some t -> 
              // Our tip is behind external tip by more than 2
              log Err "External tip ahead by %i" (t - stats.lastBlockHeight)
              Bad
            | None -> Good state'
          else
            Good state'
      | other -> 
        log Info "Node state %A" other
        Good state'
   | Error e ->
      log Err "Cannot get node stats: %s" e
      Bad

  //1. Poll jormungandr node for latest block tip every 5 sec. (+ read logs for errors i.e. "stuck notifier")
  //2. If there the tip does not progress after 300s:
  // 3. Every 30s check external sources for tip
    // - if the tips match, we're good
    // - otherwise signal error
       // check external sources for the tip (i) pooltool.io (ii) shelleyexplorer for the tip:
                // if the tips match--continue checking the tip (goto 1), if not:
                // send and email/text to operator with chain progress  error + time. 
                // restart the node. goto 1 [loop] 

let rec run elapsed =
  ()

let defaultConfig = { 
  snc = { 
    threshHold = TimeSpan.FromMinutes 5.
    pollInterval = TimeSpan.FromSeconds 5.
    externalTipInterval = TimeSpan.FromSeconds 30.
    maxTrailing = 1
  }
}

let start (cmd:string list) =
  ()


