module PointFree

let funcOriginal x l =
    List.map (fun y -> y * x) l

let flip f a b =
    f b a

let func x =
    List.map (flip (*) x)