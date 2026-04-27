namespace LocalNetwork

type IOperatingSystem =
    abstract Name: string
    abstract InfectionProbability: float

type Windows() =
    interface IOperatingSystem with
        member _.Name = "Windows"
        member _.InfectionProbability = 0.7

type Linux() =
    interface IOperatingSystem with
        member _.Name = "Linux"
        member _.InfectionProbability = 0.3

type MacOS() =
    interface IOperatingSystem with
        member _.Name = "MacOS"
        member _.InfectionProbability = 0.5