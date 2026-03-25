namespace LocalNetwork

type OS =
    | Windows
    | Linux
    | Mac

    member this.InfectionProbability =
        match this with
        | Windows -> 0.7
        | Linux -> 0.3
        | Mac -> 0.5