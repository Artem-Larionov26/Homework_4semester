namespace LocalNetwork

type Computer(os: OS) =
    let mutable infected = false

    member _.OS = os

    member _.IsInfected
        with get() = infected

    member _.Infect() =
        infected <- true

    member _.TryInfect(random: unit -> float) =
        if not infected then
            let chance = random()
            if chance < os.InfectionProbability then
                infected <- true