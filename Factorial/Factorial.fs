module Factorial

let factorial (n: int) : bigint =
    if n < 0 then
        invalidArg "n" "n must be non-negative"
    else
        let rec loop acc i =
            if i > n then
                acc
            else
                loop (acc * bigint i) (i + 1)

        loop 1I 1