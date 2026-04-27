namespace LocalNetwork

type Network(computers: Computer list, adjacency: bool[,]) =

    member _.Computers = computers

    member _.Size = computers.Length

    member _.GetNeighbors(index: int) =
        [ for j in 0 .. computers.Length - 1 do
              if adjacency[index, j] then
                  yield j ]

    member this.InfectionFront =
        computers
        |> List.indexed
        |> List.filter (fun (_, computer) -> computer.IsInfected)
        |> List.collect (fun (index, _) -> this.GetNeighbors index)
        |> List.distinct
        |> List.filter (fun index -> not computers[index].IsInfected)

    member this.CanChange =
        this.InfectionFront
        |> List.exists (fun index -> computers[index].OS.InfectionProbability > 0.0)

    member this.Step(random: unit -> float) =
        this.InfectionFront
        |> List.iter (fun index -> computers[index].TryInfect random)