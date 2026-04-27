namespace LocalNetwork

open System

type IRandom =
    abstract Next: unit -> float

type RealRandom() =
    let random = Random(DateTime.Now.Millisecond)

    interface IRandom with
        member _.Next() = random.NextDouble()