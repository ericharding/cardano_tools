module Log

type Level =
  | Diag
  | Info
  | Warn
  | Err

let log (level:Level) format =
  let now = System.DateTime.Now.ToString("yyyy-MM-dd H:mm:ss.fff")
  Printf.kprintf (printfn "[%s] %s> %s" (string level) now) format


