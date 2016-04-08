/// Copyright (C) 2016 The Authors.
module Vector

[<Sealed>]
type Vector =
  /// <summary>
  /// Negate a vector.
  /// </summary>
  /// <param name=v>The vector to negate.</param>
  /// <returns>The negated vector.</returns>
  static member (~-) : v:Vector -> Vector

  /// <summary>
  /// Compute the sum of two vector.
  /// </summary>
  /// <param name=u>The first vector.</param>
  /// <param name=v>The second vector.</param>
  /// <returns>The sum of the two vectors.</returns>
  static member (+) : u:Vector * v:Vector -> Vector

  /// <summary>
  /// Compute the difference of two vectors.
  /// </summary>
  /// <param name=u>The first vector.</param>
  /// <param name=v>The second vector.</param>
  /// <returns>The difference of the two vectors.</returns>
  static member (-) : u:Vector * v:Vector -> Vector

  /// <summary>
  /// Multiply a vector by a scalar.
  /// </summary>
  /// <param name=s>The scalar to multiply the vector by.</param>
  /// <param name=v>The vector to multiply.</param>
  /// <returns>The multiplied vector.</returns>
  static member (*) : s:float * v:Vector -> Vector

  /// <summary>
  /// Compute the dot product of two vectors.
  /// </summary>
  /// <param name=u>The first vector.</param>
  /// <param name=v>The second vector.</param>
  /// <returns>The dot product of the two vectors.</returns>
  static member (*) : u:Vector * v:Vector -> float

/// <summary>
/// Raised in case of attempting to normalize a zero-length vector.
/// </summary>
exception NormaliseZeroLengthException

/// <summary>
/// Raised in case of attempting to round a vector to a negative number of decimals.
/// </summary>
exception RoundNegativeDeicmalsException

/// <summary>
/// Create a vector with three components.
/// </summary>
/// <param name=x>The x component of the vector.</param>
/// <param name=y>The y component of the vector.</param>
/// <param name=z>The z component of the vector.</param>
/// <returns>The created vector.</returns>
val make : x:float -> y:float -> z:float -> Vector

/// <summary>
/// Get the x component of a vector.
/// </summary>
/// <param name=v>The vector whose x component to get.</param>
/// <returns>The x component of the vector.</returns>
val getX : v:Vector -> float

/// <summary>
/// Get the y component of a vector.
/// </summary>
/// <param name=v>The vector whose y component to get.</param>
/// <returns>The y component of the vector.</returns>
val getY : v:Vector -> float

/// <summary>
/// Get the z component of a vector.
/// </summary>
/// <param name=v>The vector whose z component to get.</param>
/// <returns>The z component of the vector.</returns>
val getZ : v:Vector -> float

/// <summary>
/// Get all components of a vector.
/// </summary>
/// <param name=v>The vector whose components to get.</param>
/// <returns>The components of the vector.</returns>
val getCoord: v:Vector -> float * float * float

/// <summary>
/// Multiply a vector by a scalar.
/// </summary>
/// <param name=v>The vector to multiply.</param>
/// <param name=s>The scalar to multiply the vector by.</param>
/// <returns>The multiplied vector.</returns>
val multScalar : v:Vector -> s:float -> Vector

/// <summary>
/// Compute the magnitude of a vector.
/// </summary>
/// <param name=v>The vector whose magnitude to compute.</param>
/// <returns>The magnitude of the vector.</returns>
val magnitude : v:Vector -> float

/// <summary>
/// Compute the dot product of two vectors.
/// </summary>
/// <param name=u>The first vector.</param>
/// <param name=v>The second vector.</param>
/// <returns>The dot product of the two vectors.</returns>
val dotProduct : u:Vector -> v:Vector -> float

/// <summary>
/// Compute the cross product of two vectors.
/// </summary>
/// <param name=u>The first vector.</param>
/// <param name=v>The second vector.</param>
/// <returns>The cross product of the two vectors.</returns>
val crossProduct : u:Vector -> v:Vector -> Vector

/// <summary>
/// Normalise a vector.
/// </summary>
/// <exception cref="NormaliseZeroLengthException">Raised in case of attempting to normalize a zero-length vector.</exception>
/// <param name=v>The vector to normalise.</param>
/// <returns>The normalised vector.</returns>
val normalise : v:Vector -> Vector

/// <summary>
/// Round a vector to a specific number of decimals.
/// </summary>
/// <param name=v>The vector to round.</param>
/// <param name=d>The number of decimals to round to.</param>
/// <returns>The rounded vector.</returns>
val round : v:Vector -> d:int -> Vector
