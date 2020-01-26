module Failover

// Taking inspiration from
// https://raw.githubusercontent.com/rdlrt/Alternate-Jormungandr-Testnet/master/scripts/jormungandr-leaders-failover.sh

type Node = Node of string

let run (alpha:Node) (beta:Node) =
  // todo: convert to Node list
  let ca = let (Node a) = alpha in Jormangandr.connect a
  let cb = let (Node b) = beta in Jormangandr.connect b
  let s = Jormangandr.getSettings ca
  ()
