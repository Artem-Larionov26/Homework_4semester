namespace LocalNetwork

module Simulation =

    let printState (network: Network) =
        network.Computers
        |> List.iteri (fun index computer ->
            printfn
                "Computer %d: OS = %s, infected = %b"
                index
                computer.OS.Name
                computer.IsInfected)

    let rec simulate (network: Network) (random: unit -> float) =
        printState network
        printfn "----"

        if network.CanChange then
            network.Step random
            simulate network random