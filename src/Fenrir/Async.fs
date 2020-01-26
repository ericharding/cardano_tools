module Async

let map f op = async {
  let! x = op
  return f x
}