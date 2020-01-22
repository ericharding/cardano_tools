// A wolf to watch the snake

open Jormangandr
open Argu

type Arguments =
  | Url of string
  with
    interface IArgParserTemplate with
      member this.Usage = 
              match this with 
              | Url _ -> "Url to connect to"


printfn "hello world"

