using UnityEngine;

namespace Cu1usTools.Obscure
{
    public struct Vector1
    {
        /// <summary>
        /// X component of the vector.
        /// </summary>
        public float x;

        /// <summary>
        /// Shorthand for writing Vector1(0).
        /// </summary>
        public static readonly Vector1 zero = new(0);
        /// <summary>
        /// Shorthand for writing Vector1(1).
        /// </summary>
        public static readonly Vector1 one = new(1);
        /// <summary>
        /// Shorthand for writing Vector1(1).
        /// </summary>
        public static readonly Vector1 forward = new(1);
        /// <summary>
        /// Shorthand for writing Vector1(-1).
        /// </summary>
        public static readonly Vector1 back = new(1);


        /// <summary>
        /// Creates a vector with the specified X component.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        public Vector1(float x = 0)
        {
            this.x = x;
        }

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public readonly float magnitude { get { return x < 0 ? 0 - x : x; } }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public readonly float sqrMagnitude { get { return x * x; } }

        /// <summary>
        /// Returns a normalized vector based on the current vector. The normalized vector
        /// has a magnitude of 1 and is in the same direction as the current vector. Returns
        /// a zero vector If the current vector is too small to be normalized.
        /// </summary>
        public readonly Vector1 normalized { get { return x == 0 ? zero : one; } }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        public void Normalize()
        {
            this = normalized;
        }

        /// <summary>
        /// Sets the component of an existing Vector1.
        /// </summary>
        /// <param name="newX">The new value.</param>
        public void Set(float newX)
        {
            x = newX;
        }

        /// <summary>Calculates the angle between two vectors.</summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <returns>The angle in degrees between the two vectors.</returns>
        public static float Angle(Vector1 from, Vector1 to)
        {
            if ((from.x > 0 && to.x < 0) || (from.x < 0 && to.x > 0)) return 180;
            return 0;
        }

        /// <summary>
        /// Returns a copy of vector with its magnitude clamped to maxLength.
        /// </summary>
        /// <param name="vector">The vector to clamp.</param>
        /// <param name="maxLength">The maximum length of the vector.</param>
        public static Vector1 ClampMagnitude(Vector1 vector, float maxLength)
        {
            if (maxLength < 0) maxLength = 0 - maxLength;
            if (vector.magnitude > maxLength)
            {
                if (vector.x < 0) return new Vector1(maxLength);
                else return new Vector1(-maxLength);
            }
            return vector;
        }

        /// <summary>
        /// Returns the largest of two vectors.
        /// </summary>
        public static Vector1 Max(Vector1 lhs, Vector1 rhs)
        {
            if (lhs.x > rhs.x) return lhs;
            else return rhs;
        }
        /// <summary>
        /// Returns the smallest of two vectors.
        /// </summary>
        public static Vector1 Min(Vector1 lhs, Vector1 rhs)
        {
            if (lhs.x < rhs.x) return lhs;
            else return rhs;
        }

        public static Vector1 operator +(Vector1 a, Vector1 b)
        {
            return new Vector1(a.x + b.x);
        }
        public static Vector1 operator -(Vector1 a, Vector1 b)
        {
            return new Vector1(a.x - b.x);
        }
        public static Vector1 operator -(Vector1 a)
        {
            return new Vector1(0f - a.x);
        }
        public static Vector1 operator *(Vector1 a, Vector1 b)
        {
            return new Vector1(a.x * b.x);
        }
        public static Vector1 operator /(Vector1 a, Vector1 b)
        {
            if (b.x == 0) throw new System.DivideByZeroException();
            return new Vector1(a.x / b.x);
        }
        // public static bool operator ==(Vector1 a, Vector1 b)
        // {
        //     return a.x == b.x;
        // }
        // public static Vector1 operator !=(Vector1 a, Vector1 b)
        // {
        //     return a.x != b.x;
        // }

        public static implicit operator float(Vector1 vector) => vector.x;
        public static implicit operator Vector1(float num) => new(num);

        public static implicit operator double(Vector1 vector) => vector.x;
        public static implicit operator Vector1(double num) => new((float)num);

        public static implicit operator int(Vector1 vector) => (int)vector.x;
        public static implicit operator Vector1(int num) => new(num);

        public static implicit operator Vector2(Vector1 v) => new(v, 0);
        public static implicit operator Vector1(Vector2 v) => new(v.x);

        public static implicit operator Vector3(Vector1 v) => new(v, 0, 0);
        public static implicit operator Vector1(Vector3 v) => new(v.x);

        public static implicit operator Vector4(Vector1 v) => new(v, 0, 0, 0);
        public static implicit operator Vector1(Vector4 v) => new(v.x);

        public readonly override string ToString()
        {
            return $"({x})";
        }
    }
}