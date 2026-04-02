module Task2

/// Prints a square of '*' characters of size n.
/// Uses functional constructs without imperative loops.
let printSquare n =
    let topBottom = String.replicate n "*"
    let middle =
        if n > 2 then
            String.replicate (n - 2) " " |> fun spaces -> "*" + spaces + "*"
        else
            ""

    [
        yield topBottom
        if n > 2 then
            yield! List.replicate (n - 2) middle
        if n > 1 then
            yield topBottom
    ]
    |> String.concat "\n"
