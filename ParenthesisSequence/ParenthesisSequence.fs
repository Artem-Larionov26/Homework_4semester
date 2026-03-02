module ParenthesisSequence

let isCorrect (input: string) =
    let pairs =
        dict [
            ')', '('
            ']', '['
            '}', '{'
        ]

    let opening =
        Set.ofList ['('; '['; '{']

    let rec loop chars stack =
        match chars with
        | [] ->
            stack = []

        | c :: rest when Set.contains c opening ->
            loop rest (c :: stack)

        | c :: rest when pairs.ContainsKey c ->
            match stack with
            | top :: tail when top = pairs[c] ->
                loop rest tail
            | _ ->
                false

        | _ :: rest ->
            loop rest stack

    loop (List.ofSeq input) []