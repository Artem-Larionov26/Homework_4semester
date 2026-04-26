module NumberOfDegree

let powersOfTwo n m =
    if m < 0 then
        Error "m must be non-negative"
    else
        let start = 2.0 ** float n

        let rec loop count acc =
            if count = 0 then
                List.rev acc
            else
                loop (count - 1) ((List.head acc * 2.0) :: acc)

        Ok (loop m [start])