module Fibonacci

    let fib (n: int) : bigint =
        if n < 0 then
            invalidArg "n" "n must be non-negative"
        else
            let rec loop i prev curr =
                if i = n then prev
                else loop (i + 1) curr (prev + curr)

            loop 0 0I 1I