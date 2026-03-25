namespace LocalNetwork

open System.Collections.Generic

type Network(computers: Computer list, adjacency: bool[,]) =

    member _.Computers = computers

    member _.Size = computers.Length

    member _.GetNeighbors(index: int) =
        [ for j in 0 .. computers.Length - 1 do
            if adjacency[index, j] then yield j ]

    member this.Step(random: unit -> float) =
        let toInfect = HashSet<int>()

        for i in 0 .. computers.Length - 1 do
            if computers[i].IsInfected then
                for j in this.GetNeighbors(i) do
                    if not computers[j].IsInfected then
                        toInfect.Add(j) |> ignore

        for i in toInfect do
            computers[i].TryInfect(random)