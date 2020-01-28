// A wolf to watch the snake

open Argu

let oculent_pool = "b628a5f5e987b03151c232b80d59a17e214e7105258c5bf8fc734a55ceb3e8d5"

type Arguments =
  | Url of string
  with
    interface IArgParserTemplate with
      member this.Usage = 
              match this with 
              | Url _ -> "Url to connect to"

let usage() =
  printfn "fenrir <command> [args]"

let uri s = new System.Uri(s, System.UriKind.Absolute)
let test() =
  let uri = uri "http://cerberus:57701"
  let c = Jormungandr.connect(uri)

  let stuff = 
    Jormungandr.getNodeStats c
    |> Async.RunSynchronously
  match stuff with
  | Ok s -> printfn "%A" s
  | Error e -> printfn "%A" e

let args = 
  System.Environment.GetCommandLineArgs() 
  |> List.ofArray 
  |> List.tail

match args with
| "test"::_ -> test()
| "failover"::xs -> 
  Failover.run xs
| "help"::_
| [] -> usage()
| h::_ -> 
  printfn "Unknown or invalid argument: '%s'" h
  
