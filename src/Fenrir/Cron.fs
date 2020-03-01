module Cron

open System

type Schedule = {
  id : Guid
  period : TimeSpan
  action : unit->unit
  deadline : DateTime
  // state : 'a
}

let schedule period action initialState = 
  { id = Guid.NewGuid()
    period = period
    action = action
    deadline = DateTime.MinValue 
    state = initialState }

let rec run (schedule:Schedule<'a> list) =
  // printfn "%A" schedule
  schedule
  |> List.sortBy (fun s -> s.deadline)
  |> List.tryHead
  |> function
  | None -> ()
  | Some head -> 
    Threading.Thread.Sleep (max (head.deadline - DateTime.Now) (TimeSpan.Zero))
    let state' = head.action head.state
    run (
      { head with state = state'; deadline = DateTime.Now + head.period } :: 
      (List.filter (fun i -> head.id <> i.id) schedule))

type Count = {
  counter : int
}
run [
  schedule (TimeSpan.FromSeconds 5.) (fun t -> printfn "count = %i" t.counter; { t with counter = t.counter + 1}) ({ counter = 0 })
]

