module NumberOfDegree

let powersOfTwo (n: int) (m: int) : Result<float list, string> =
    match m with
    | m when m < 0 ->
        Error "m must be non-negative"
    | _ ->
        let start = 2.0 ** float n

        let rec loop count current acc =
            if count > m then
                List.rev acc
            else
                loop (count + 1) (current * 2.0) (current :: acc)

        Ok (loop 0 start [])