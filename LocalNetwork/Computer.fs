namespace LocalNetwork

type Computer(os: IOperatingSystem, infected: bool) =
    let mutable isInfected = infected

    new(os: IOperatingSystem) = Computer(os, false)

    member _.OS = os

    member _.IsInfected = isInfected

    member _.Infect() =
        isInfected <- true

    member _.TryInfect(random: unit -> float) =
        if not isInfected && random() < os.InfectionProbability then
            isInfected <- true