/// Copyright (C) 2016 The Authors.
module Vector

type Vector =
    | V of float * float * float
    override v.ToString() =
        match v with
        | V(x, y, z) -> "[" + x.ToString() + "," + y.ToString() + "," + z.ToString() + "]"

/// <summary>
/// Raised in case of attempting to normalize a zero-length vector.
/// </summary>
exception NormaliseZeroLengthException

/// <summary>
/// Raised in case of attempting to round a vector to a negative number of decimals.
/// </summary>
exception RoundNegativeDecimalsException

/// <summary>
/// Create a vector with three components.
/// </summary>
/// <param name=x>The x component of the vector.</param>
/// <param name=y>The y component of the vector.</param>
/// <param name=z>The z component of the vector.</param>
/// <returns>The created vector.</returns>
let make x y z = V(x, y, z)

/// <summary>
/// Get the x component of a vector.
/// </summary>
/// <param name=v>The vector whose x component to get.</param>
/// <returns>The x component of the vector.</returns>
let getX (V(x, _, _)) = x

/// <summary>
/// Get the y component of a vector.
/// </summary>
/// <param name=v>The vector whose y component to get.</param>
/// <returns>The y component of the vector.</returns>
let getY (V(_, y, _)) = y

/// <summary>
/// Get the z component of a vector.
/// </summary>
/// <param name=v>The vector whose z component to get.</param>
/// <returns>The z component of the vector.</returns>
let getZ (V(_, _, z)) = z

/// <summary>
/// Get all components of a vector.
/// </summary>
/// <param name=v>The vector whose components to get.</param>
/// <returns>The components of the vector.</returns>
let getCoord (V(x, y, z)) = (x, y, z)

/// <summary>
/// Multiply a vector by a scalar.
/// </summary>
/// <param name=v>The vector to multiply.</param>
/// <param name=s>The scalar to multiply the vector by.</param>
/// <returns>The multiplied vector.</returns>
let multScalar (V(x, y, z)) s = V(x * s, y * s, z * s)

/// <summary>
/// Compute the magnitude of a vector.
/// </summary>
/// <param name=v>The vector whose magnitude to compute.</param>
/// <returns>The magnitude of the vector.</returns>
let magnitude (V(x, y, z)) = sqrt(x * x + y * y + z * z)

/// <summary>
/// Compute the dot product of two vectors.
/// </summary>
/// <param name=u>The first vector.</param>
/// <param name=v>The second vector.</param>
/// <returns>The dot product of the two vectors.</returns>
let dotProduct (V(ux, uy, uz)) (V(vx, vy, vz)) = ux * vx + uy * vy + uz * vz

/// <summary>
/// Compute the cross product of two vectors.
/// </summary>
/// <param name=u>The first vector.</param>
/// <param name=v>The second vector.</param>
/// <returns>The cross product of the two vectors.</returns>
let crossProduct (V(ux, uy, uz)) (V(vx, vy, vz)) = V(uy * vz - uz * vy, uz * vx - ux * vz, ux * vy - uy * vx)

/// <summary>
/// Normalise a vector.
/// </summary>
/// <exception cref="NormaliseZeroLengthException">Raised in case of attempting to normalize a zero-length vector.</exception>
/// <param name=v>The vector to normalise.</param>
/// <returns>The normalised vector.</returns>
let normalise (V(x, y, z) as v) =
    let m = magnitude v
    if m = 0.0 then raise NormaliseZeroLengthException
    V(x / m, y / m, z / m)

/// <summary>
/// Round a vector to a specific number of decimals.
/// </summary>
/// <param name=v>The vector to round.</param>
/// <param name=d>The number of decimals to round to.</param>
/// <returns>The rounded vector.</returns>
let round (V(x, y, z)) (d:int) =
    if d < 0 then raise RoundNegativeDecimalsException
    let f = 10.0 ** float d
    V(round (x * f) / f, round (y * f) / f, round (z * f) / f)

type Vector with
    /// <summary>
    /// Negate a vector.
    /// </summary>
    /// <param name=v>The vector to negate.</param>
    /// <returns>The negated vector.</returns>
    static member (~-) (V(x, y, z)) = V(-x, -y, -z)

    /// <summary>
    /// Compute the sum of two vector.
    /// </summary>
    /// <param name=u>The first vector.</param>
    /// <param name=v>The second vector.</param>
    /// <returns>The sum of the two vectors.</returns>
    static member (+) (V(ux, uy, uz), V(vx, vy, vz)) = V(ux + vx, uy + vy, uz + vz)

    /// <summary>
    /// Compute the difference of two vectors.
    /// </summary>
    /// <param name=u>The first vector.</param>
    /// <param name=v>The second vector.</param>
    /// <returns>The difference of the two vectors.</returns>
    static member (-) (V(ux, uy, uz), V(vx, vy, vz)) = V(ux - vx, uy - vy, uz - vz)

    /// <summary>
    /// Multiply a vector by a scalar.
    /// </summary>
    /// <param name=s>The scalar to multiply the vector by.</param>
    /// <param name=v>The vector to multiply.</param>
    /// <returns>The multiplied vector.</returns>
    static member (*) (s, v) = multScalar v s

    /// <summary>
    /// Compute the dot product of two vectors.
    /// </summary>
    /// <param name=u>The first vector.</param>
    /// <param name=v>The second vector.</param>
    /// <returns>The dot product of the two vectors.</returns>
    static member (*) (u, v) = dotProduct u v
