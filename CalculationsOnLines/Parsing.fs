namespace CalculationsOnLines

module Parsing =

    let tryParseInt (s: string) =
        match System.Int32.TryParse(s) with
        | true, value -> Some value
        | false, _ -> None