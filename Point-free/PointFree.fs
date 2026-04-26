module PointFree

let flip f x y = f y x

let originalFunction x l =
    List.map (fun y -> y * x) l

let withoutListArgument x =
    List.map (fun y -> y * x)

let withOperator x =
    List.map (fun y -> (*) y x)

let withFlip x =
    List.map (flip (*) x)

let pointFree =
    List.map << flip (*)