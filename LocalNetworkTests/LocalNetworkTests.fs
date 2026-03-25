module LocalNetwork.Tests

open NUnit.Framework
open FsUnit
open LocalNetwork

type AlwaysInfectRandom() =
    interface IRandom with
        member _.Next() = 0.0

type NeverInfectRandom() =
    interface IRandom with
        member _.Next() = 1.0

[<Test>]
let ``Infection spreads step by step`` () =
    let computers =
        [ Computer(OS.Windows)
          Computer(OS.Windows)
          Computer(OS.Windows) ]

    let adjacency = array2D [ [ false; true; false ]
                              [ true; false; true ]
                              [ false; true; false ] ]

    let network = Network(computers, adjacency)

    computers[0].Infect()

    let rnd = AlwaysInfectRandom() :> IRandom

    network.Step(rnd.Next)
    computers[1].IsInfected |> should equal true
    computers[2].IsInfected |> should equal false

    network.Step(rnd.Next)
    computers[2].IsInfected |> should equal true

[<Test>]
let ``No infection when probability is zero`` () =
    let computers =
        [ Computer(OS.Linux)
          Computer(OS.Linux) ]

    let adjacency = array2D [ [ false; true ]
                              [ true; false ] ]

    let network = Network(computers, adjacency)

    computers[0].Infect()

    let rnd = NeverInfectRandom() :> IRandom

    network.Step(rnd.Next)

    computers[1].IsInfected |> should equal false

[<Test>]
let ``Already infected computer stays infected`` () =
    let comp = Computer(OS.Windows)
    comp.Infect()

    let rnd = NeverInfectRandom() :> IRandom

    comp.TryInfect(rnd.Next)

    comp.IsInfected |> should equal true