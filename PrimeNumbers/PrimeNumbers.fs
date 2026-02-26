module PrimeNumbers

let isPrime n =
    if n < 2 then false
    else
        let bound = int (sqrt (float n))
        seq { 2 .. bound }
        |> Seq.forall (fun d -> n % d <> 0)

let primes : seq<int> =
    Seq.initInfinite (fun i -> i + 2)
    |> Seq.filter isPrime