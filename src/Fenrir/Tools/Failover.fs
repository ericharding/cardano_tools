module Failover

// Taking inspiration from
// https://raw.githubusercontent.com/rdlrt/Alternate-Jormungandr-Testnet/master/scripts/jormungandr-leaders-failover.sh

open Jormangandr

type Node = Node of string

let run (alpha:Node) (beta:Node) =
  ()
