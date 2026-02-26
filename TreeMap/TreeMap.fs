module TreeMap

type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

let rec map (f: 'a -> 'b) (tree: Tree<'a>) : Tree<'b> =
    match tree with
    | Empty -> Empty
    | Node(value, left, right) ->
        Node(
            f value,
            map f left,
            map f right
        )