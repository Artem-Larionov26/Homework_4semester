namespace RoundingWorkflow

type RoundingBuilder(precision: int) =

    let roundValue (x: float) =
        System.Math.Round(x, precision)

    member _.Bind(value: float, f: float -> float) =
        value |> roundValue |> f

    member _.Return(x: float) =
        roundValue x

    member _.ReturnFrom(x: float) =
        roundValue x

    member _.Zero() =
        0.0