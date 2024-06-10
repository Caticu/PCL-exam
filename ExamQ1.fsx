//Q1:
//miaw a
//me
let sqrOnlyFirst ls = 
    match ls with  
    | hd :: _ -> hd * hd 

let sqrOnlyFirstFix ls = 
    match ls with  
    | hd :: _ -> hd * hd
    | _ -> 0 

// i.
printf "%d \n" (sqrOnlyFirst [2;4;6]) // 4
// ii.
//printf "%d \n" (sqrOnlyFirst []) // The match cases were incomplete
// iii.
printf "%d \n" (sqrOnlyFirstFix []) // handle empty list


// q:1b
let rec stringToList (str:string) : char list =
    if str.Length = 0 then []
    else str.[0] :: stringToList (str.Substring(1))

let lst = stringToList "Hello"
printfn "%A" lst // ['H'; 'e'; 'l'; 'l'; 'o']
