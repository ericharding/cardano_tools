module Option

let ofResult = function
| Ok o -> Some o
| Error _ -> None
