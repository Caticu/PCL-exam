type expr = | Const of int 
            | BinOpr of expr * string * expr

//q5a
let expr1 = Const 5
let expr2 = BinOpr (Const 3, "+", Const 7)
let expr3 = BinOpr (BinOpr (Const 1, "+", Const 2), "*", Const 3)

//q5b

let rec toString (e: expr) : string =
    match e with
    | Const n -> string n
    | BinOpr (left, op, right) -> 
        "(" + toString left + op + toString right + ")"

printf "%s \n%s \n%s \n" (toString expr1) (toString expr2) (toString expr3)
//output:
//5 
//(3+7) 
//((1+2)*3) 

let expr4 = BinOpr (Const 1, "+",BinOpr( Const 2, "*", Const 3))
printf "%s \n" (toString expr4)
//output:
//(1+(2*3)) 