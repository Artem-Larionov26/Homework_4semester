namespace CalculationsOnLines

open Parsing

type CalculateBuilder() =

    member _.Bind(value: string, f: int -> 'a option) =
        match tryParseInt value with
        | Some v -> f v
        | None -> None

    member _.Return(x: 'a) =
        Some x

    member _.ReturnFrom(x: 'a option) =
        x