module NumberOfDegree

let powersOfTwo (n: int) (m: int) : bigint list =
    if m < 0 then
        invalidArg "m" "m must be non-negative"
    else
        let start = pown 2I n

        let rec loop count current acc =
            if count > m then
                List.rev acc
            else
                loop (count + 1) (current * 2I) (current :: acc)

        loop 0 start [] 