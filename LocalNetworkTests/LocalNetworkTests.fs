module LocalNetworkTests

open NUnit.Framework
open FsUnit
open LocalNetwork

type TestOS(probability: float) =
    interface IOperatingSystem with
        member _.Name = "TestOS"
        member _.InfectionProbability = probability

type AlwaysSuccessfulRandom() =
    interface IRandom with
        member _.Next() = 0.0

[<Test>]
let ``infection with probability one works like BFS`` () =
    let os = TestOS(1.0) :> IOperatingSystem

    let computers =
        [ Computer(os, true)
          Computer(os)
          Computer(os) ]

    let adjacency =
        array2D
            [ [ false; true; false ]
              [ true; false; true ]
              [ false; true; false ] ]

    let network = Network(computers, adjacency)
    let random = AlwaysSuccessfulRandom() :> IRandom

    network.Step random.Next

    computers[0].IsInfected |> should equal true
    computers[1].IsInfected |> should equal true
    computers[2].IsInfected |> should equal false

    network.Step random.Next

    computers[0].IsInfected |> should equal true
    computers[1].IsInfected |> should equal true
    computers[2].IsInfected |> should equal true

[<Test>]
let ``infection with probability zero does not spread`` () =
    let os = TestOS(0.0) :> IOperatingSystem

    let computers =
        [ Computer(os, true)
          Computer(os) ]

    let adjacency =
        array2D
            [ [ false; true ]
              [ true; false ] ]

    let network = Network(computers, adjacency)
    let random = AlwaysSuccessfulRandom() :> IRandom

    network.Step random.Next

    computers[0].IsInfected |> should equal true
    computers[1].IsInfected |> should equal false

[<Test>]
let ``can change is false when there are no healthy neighbours`` () =
    let os = TestOS(1.0) :> IOperatingSystem

    let computers =
        [ Computer(os, true)
          Computer(os, true) ]

    let adjacency =
        array2D
            [ [ false; true ]
              [ true; false ] ]

    let network = Network(computers, adjacency)

    network.CanChange |> should equal false

[<Test>]
let ``can change is false when neighbour has zero infection probability`` () =
    let infectedOS = TestOS(1.0) :> IOperatingSystem
    let safeOS = TestOS(0.0) :> IOperatingSystem

    let computers =
        [ Computer(infectedOS, true)
          Computer(safeOS) ]

    let adjacency =
        array2D
            [ [ false; true ]
              [ true; false ] ]

    let network = Network(computers, adjacency)

    network.CanChange |> should equal false