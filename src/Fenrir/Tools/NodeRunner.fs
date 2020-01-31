module NodeRunner
//Stuck Notifier
//Threshold time=300s
//1.  Poll jormungandr node for latest block tip every 5 sec. (+ read logs for key words "stuck notifier")
//2.  If there the tip does not progress after 300s:
      // check external sources for the tip (i) pooltool.io (ii) shelleyexplorer for the tip:
              // if the tips match--continue checking the tip(goto 1), if not:
              // send and email/text to operator with chain progress  error + time. 
              // restart the node. goto 1 [loop] 
              
//Strategic Node Restart:
//Get leader schedule at 2.14PM every day.
//Create a restart schedule for the node: 20 min before each block creation time
//When the nodes hits the designated time: (i) restart the node, monitor chain for 4 min for new blocks. 
//if no blocks for 4 min--notify node operator(email/text) every minute 6x times
    //if node receives blocks: check progress + check with external data sources 
         //if node catches up, send a success! alert to node operator
    //else restart the node--send an alert to operator   


let run (cmd:string list) =
  ()


