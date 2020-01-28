module Time
open System

let private unixEpoch = DateTime(1970,01,01)
let toUnix dt =
  (dt - unixEpoch).TotalSeconds |> int64

let unixNow() = toUnix DateTime.UtcNow

let currSlot chainStart slotsPerEpoch slotDuration =
  let chainAgeSeconds = uint64 (chainStart - DateTime.UtcNow).TotalSeconds
  (chainAgeSeconds % (slotsPerEpoch*slotDuration)) / slotDuration