//q2a
type Vector =
    | Vec2 of float*float
    | Vec3 of float*float*float
    | Vec4 of float*float*float*float
    | Vec5 of float*float*float*float*float

//q2b
let vecLen vector =
    match vector with
    | Vec2 (x, y) -> sqrt (x * x + y * y)
    | Vec3 (x, y, z) -> sqrt (x * x + y * y + z * z)
    | Vec4 (x, y, z, w) -> sqrt (x * x + y * y + z * z + w * w)
    | Vec5 (x, y, z, w, v) -> sqrt (x * x + y * y + z * z + w * w + v * v)

// q2c
let vecAdd vector1 vector2 =
    match vector1, vector2 with
    | Vec2 (x1, y1), Vec2 (x2, y2) -> Vec2 (x1 + x2, y1 + y2)
    | Vec3 (x1, y1, z1), Vec3 (x2, y2, z2) -> Vec3 (x1 + x2, y1 + y2, z1 + z2)
    | Vec4 (x1, y1, z1, w1), Vec4 (x2, y2, z2, w2) -> Vec4 (x1 + x2, y1 + y2, z1 + z2, w1 + w2)
    | Vec5 (x1, y1, z1, w1, v1), Vec5 (x2, y2, z2, w2, v2) -> Vec5 (x1 + x2, y1 + y2, z1 + z2, w1 + w2, v1 + v2)



//TESt
// Test the functions with sample vectors
let vector2D = Vec2 (3.0, 4.0)
let vector3D = Vec3 (1.0, 2.0, 3.0)
let vector4D = Vec4 (1.0, 2.0, 3.0, 4.0)
let vector5D = Vec5 (1.0, 2.0, 3.0, 4.0, 5.0)

printfn "Length of 2D vector: %f" (vecLen vector2D)
printfn "Length of 3D vector: %f" (vecLen vector3D)
printfn "Length of 4D vector: %f" (vecLen vector4D)
printfn "Length of 5D vector: %f" (vecLen vector5D)

let addedVector2D = vecAdd vector2D vector2D
let addedVector3D = vecAdd vector3D vector3D
let addedVector4D = vecAdd vector4D vector4D
let addedVector5D = vecAdd vector5D vector5D

match addedVector2D with
| Vec2 (x, y) -> printfn "Addition of 2D vectors: (%f, %f)" x y
| _ -> ()

match addedVector3D with
| Vec3 (x, y, z) -> printfn "Addition of 3D vectors: (%f, %f, %f)" x y z
| _ -> ()

match addedVector4D with
| Vec4 (x, y, z, w) -> printfn "Addition of 4D vectors: (%f, %f, %f, %f)" x y z w
| _ -> ()

match addedVector5D with
| Vec5 (x, y, z, w, v) -> printfn "Addition of 5D vectors: (%f, %f, %f, %f, %f)" x y z w v
| _ -> ()

//Outputs
//Length of 2D vector: 5.000000
//Length of 3D vector: 3.741657
//Length of 4D vector: 5.477226
//Length of 5D vector: 7.416198
//Addition of 2D vectors: (6.000000, 8.000000)
//Addition of 3D vectors: (2.000000, 4.000000, 6.000000)
//Addition of 4D vectors: (2.000000, 4.000000, 6.000000, 8.000000)
//Addition of 5D vectors: (2.000000, 4.000000, 6.000000, 8.000000, 10.000000)