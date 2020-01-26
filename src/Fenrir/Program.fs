﻿// A wolf to watch the snake

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

let test() =
  let uri = "http://cerberus:57701"
  let c = Jormangandr.connect(uri)

  let stats = 
    Jormangandr.getDiagnostic c
    |> Async.RunSynchronously

  match stats with
  | Ok s -> printfn "%A" s
  | Error e -> printfn "%A" e

let args = 
  System.Environment.GetCommandLineArgs() 
  |> List.ofArray 
  |> List.tail

match args with
| "test"::_ -> test()
| "failover"::a::b::_ -> 
  Failover.run (Failover.Node a) (Failover.Node b)
| "help"::_
| [] -> usage()
| h::_ -> 
  printfn "Unknown or invalid argument: '%s'" h
  
