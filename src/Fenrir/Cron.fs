module Cron

open System

type Schedule = {
  id : Guid
  period : TimeSpan
  action : unit->unit
  deadline : DateTime
}

let schedule period action initialState = 
  { id = Guid.NewGuid()
    period = period
    action = action
    deadline = DateTime.MinValue }

let rec run (schedule:Schedule list) =
  schedule
  |> List.sortBy (fun s -> s.deadline)
  |> List.tryHead
  |> function
  | None -> ()
  | Some head -> 
    Threading.Thread.Sleep (max (head.deadline - DateTime.Now) (TimeSpan.Zero))
    run (
      { head with deadline = DateTime.Now + head.period } :: 
      (List.filter (fun i -> head.id <> i.id) schedule))

type Count = {
  counter : int
}

// run [
//   schedule (TimeSpan.FromSeconds 5.) (fun () -> printfn "count = %i" t.counter; { t with counter = t.counter + 1}) ({ counter = 0 })
// ]

