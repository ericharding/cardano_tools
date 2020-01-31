module NodeRunner
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


let run (cmd:string list) =
  ()


