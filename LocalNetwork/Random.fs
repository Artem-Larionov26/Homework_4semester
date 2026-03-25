namespace LocalNetwork

type IRandom =
    abstract Next: unit -> float

type RealRandom() =
    let rnd = System.Random()

    interface IRandom with
        member _.Next() = rnd.NextDouble()