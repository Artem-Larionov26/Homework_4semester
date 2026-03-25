namespace LocalNetwork

module Simulation =

    let printState (network: Network) =
        network.Computers
        |> List.iteri (fun i c ->
            printfn "Computer %d: %b" i c.IsInfected)

    let getState (network: Network) =
        network.Computers |> List.map (fun c -> c.IsInfected)

    let rec simulate network random =
        printState network
        printfn "----"

        let before = getState network

        network.Step(random)

        let after = getState network

        if before <> after then
            simulate network random