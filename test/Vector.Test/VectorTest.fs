/// Copyright (C) 2016 The Authors.
module Vector.Test

open Xunit;
open FsUnit.Xunit;

[<Fact>]
let ``make constructs a vector given three components`` () =
    let v = Vector.make 1.0 2.0 3.0

    // Check that a vector was constructed.
    v |> should be instanceOfType<Vector>

[<Fact>]
let ``getX, getY, and getZ gets the x-, y-, and z-components of a vector`` () =
    let v = Vector.make -8.4 5.34 9.1

    // Check that the components can be retrieved.
    Vector.getX v |> should equal -8.4
    Vector.getY v |> should equal 5.34
    Vector.getZ v |> should equal 9.1

[<Fact>]
let ``getCoord gets the components of a vector as a triple`` () =
    let v = Vector.make 5.4 7.1 -2.78

    // Check that the components can be retrieved.
    Vector.getCoord v |> should equal (5.4, 7.1, -2.78)

[<Fact>]
let ``multScalar multiplies a vector by a scalar`` () =
    let v = Vector.make 3.0 6.0 1.0
    let v' = Vector.multScalar v 2.0
    let v'' = Vector.multScalar v' 3.0
    let v''' = Vector.multScalar v'' -4.0

    // Check that the resulting vectors are correct.
    Vector.getCoord v' |> should equal (6.0, 12.0, 2.0)
    Vector.getCoord v'' |> should equal (18.0, 36.0, 6.0)
    Vector.getCoord v''' |> should equal (-72.0, -144.0, -24.0)

[<Fact>]
let ``magnitude computes the length of a vector`` () =
    let v = Vector.make 3.0 4.0 2.0
    let m = Vector.magnitude v

    // Check that the computed magnitude is correct within +-0.01.
    abs (m - 5.39) |> should be (lessThan 0.01)

[<Fact>]
let ``dotProduct computes the dot product of two vectors`` () =
    let v1 = Vector.make 5.4 -9.3 3.6
    let v2 = Vector.make -2.0 4.9 1.2
    let d = Vector.dotProduct v1 v2

    // Check that the computed dot product is correct within +-0.01.
    abs (d - -52.05) |> should be (lessThan 0.01)

[<Fact>]
let ``crossProduct computes the cross product of two vectors`` () =
    let v1 = Vector.make 3.9 -1.6 8.3
    let v2 = Vector.make 1.0 14.2 7.5
    let c = Vector.crossProduct v1 v2

    // Check that the computed cross product is correct within +-0.01.
    abs (Vector.getX c - -129.86) |> should be (lessThan 0.01)
    abs (Vector.getY c - -20.95) |> should be (lessThan 0.01)
    abs (Vector.getZ c - 56.98) |> should be (lessThan 0.01)

[<Fact>]
let ``normalise normalises a vector to a length of 1`` () =
    let v = Vector.make 3.0 4.2 7.8
    let n = Vector.normalise v

    // Ensure that the magnitude of the original vector isn't 1.
    Vector.magnitude v |> should not' (equal 1.0)

    // Check that the magnitude of the normalised vector is 1.
    Vector.magnitude n |> should equal 1.0

[<Fact>]
let ``normalise fails if normalising the null vector`` () =
    let v = Vector.make 0.0 0.0 0.0

    // Check the normlisation fails for the null vector.
    (fun () -> Vector.normalise v |> ignore) |> shouldFail

[<Fact>]
let ``round rounds a vector to a specific number of decimals`` () =
    let v = Vector.make 1.126 2.2436 4.2
    let v' = Vector.round v 2
    let v'' = Vector.round v' 1
    let v''' = Vector.round v'' 0

    // Check the the vectors were rounded correctly.
    Vector.getCoord v' |> should equal (1.13, 2.24, 4.2)
    Vector.getCoord v'' |> should equal (1.1, 2.2, 4.2)
    Vector.getCoord v''' |> should equal (1.0, 2.0, 4.0)

[<Fact>]
let ``round fails if rounding to negative number of decimals`` () =
    let v = Vector.make 1.3 2.2 3.5

    // Check that rounding fails if given a negative d.
    (fun () -> Vector.round v -1 |> ignore) |> shouldFail
    (fun () -> Vector.round v -2 |> ignore) |> shouldFail

[<Fact>]
let ``a vector can be negated using the unary "-" operator`` () =
    let v = Vector.make 7.3 9.2 -1.4
    let v' = -v

    // Check that the vector was correctly negated.
    Vector.getCoord v' |> should equal (-7.3, -9.2, 1.4)

[<Fact>]
let ``two vectors can be summed using the "+" infix operator`` () =
    let v1 = Vector.make 2.0 4.0 1.0
    let v2 = Vector.make 8.0 7.0 1.0
    let s = v1 + v2;

    // Check that the vector were summed correctly.
    Vector.getCoord s |> should equal (10.0, 11.0, 2.0)

[<Fact>]
let ``two vectors can be diffed using the "-" infix operator`` () =
    let v1 = Vector.make 2.0 7.0 1.0
    let v2 = Vector.make 8.0 4.0 1.0
    let d = v1 - v2;

    // Check that the vector were summed correctly.
    Vector.getCoord d |> should equal (-6.0, 3.0, 0.0)

[<Fact>]
let ``a vector can be multiplied by a scalar using the "*" infix operator`` () =
    let v = Vector.make 3.0 6.0 1.0
    let m = multScalar v 2.0

    // Check that the infix operator does the same as multScalar.
    2.0 * v |> should equal m

[<Fact>]
let ``the dot product of two vectors can be computed using the "*" infix operator`` () =
    let v1 = Vector.make 5.4 -9.3 3.6
    let v2 = Vector.make -2.0 4.9 1.2
    let d = Vector.dotProduct v1 v2

    // Check that the infix operator does the same as dotProduct.
    v1 * v2 |> should equal d
