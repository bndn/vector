/// Copyright (C) 2016 The Authors.
module Vector

[<Sealed>]
type Vector =
  /// Negate a vector.
  static member (~-) : Vector -> Vector

  /// Add two vectors.
  static member (+) : Vector * Vector -> Vector

  /// Subtract two vectors.
  static member (-) : Vector * Vector -> Vector

  /// Multiply a vector by a scalar.
  static member (*) : float * Vector -> Vector

  /// Compute the dot product of two vectors.
  static member (*) : Vector * Vector -> float

/// Raised in case of attempting to normalize a zero-length vector.
exception NormaliseZeroLengthException

/// Raised in case of attempting to round a vector to a negative number of decimals.
exception RoundNegativeDeicmalsException

/// Create a vector with three components.
val mkVector : float -> float -> float -> Vector

/// Get the x component of a vector.
val getX : Vector -> float

/// Get the y component of a vector.
val getY : Vector -> float

/// Get the z component of a vector.
val getZ : Vector -> float

/// Get all components of a vector.
val getCoord: Vector -> float * float * float

/// Multiply a vector by a scalar.
val multScalar : Vector -> float -> Vector

/// Compute the magnitude of a vector.
val magnitude : Vector -> float

/// Compute the dot product of two vectors.
val dotProduct : Vector -> Vector -> float

/// Compute the cross product of two vectors.
val crossProduct : Vector -> Vector -> Vector

/// Normalise a vector.
val normalise : Vector -> Vector

/// Round a vector to a specific number of decimals.
val round : Vector -> int -> Vector
