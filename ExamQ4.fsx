let f1 i j k =  
    seq { 
                    for x in [0 .. i] do 
                        for y in [0 .. j] do 
                            if x+y < k then yield (x,y)  
    } 

let f2 f p sq =  
    seq { 
                    for x in sq do 
                        if p x then yield f x   
    }       

let f3 g sq =  
    seq { 
                    for s in sq do 
                        yield! g s   
    } 

let result1 = List.ofSeq (f1 2 2 3)
printfn "%A" result1
//output: [(0, 0); (0, 1); (0, 2); (1, 0); (1, 1); (2, 0)] where [] is List.ofSeq and (0, 0); (0, 1); (0, 2); (1, 0); (1, 1); (2, 0) are the yield elements

let f2Alternative f p sq =
    Seq.collect (fun x -> if p x then Seq.singleton (f x) else Seq.empty) sq


// Call f2Alternative with appropriate arguments
let list2 = [(0, 1); (1, 2); (2, 3); (3, 4); (4, 5)]

let result2 = f2Alternative id (fun (x,_) -> x > 1) list2

result2 |> Seq.iter (printfn "%A")