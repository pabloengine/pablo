/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Globalization;

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents a vector in three dimensional space.
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// Gets the X value of the <see cref="Vector"/>.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the Y value of the <see cref="Vector"/>.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Gets the Z value of the <see cref="Vector"/>.
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Gets the Length of the <see cref="Vector"/>.
        /// </summary>
        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        /// <summary>
        /// Gets the Unit <see cref="Vector"/> from this <see cref="Vector"/>.
        /// </summary>
        public Vector Unit
        {
            get
            {
                // Cache the calculation to prevent re-evaluation.
                var length = Length;
                return new Vector(X / length, Y / length, Z / length);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Vector"/> on the XY plane.
        /// </summary>
        public Vector(double x, double y)
            : this()
        {
            X = x;
            Y = y;
            Z = 0;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Vector"/> in the space.
        /// </summary>
        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Produces a new <see cref="Vector"/> from the linear interpolation 
        /// between start and end <see cref="Vector"/>.
        /// </summary>
        public static Vector Lerp(Vector start, Vector end, double alpha)
            => start + alpha * (end - start);

        /// <summary>
        /// Returns the dot product of two <see cref="Vector"/>s.
        /// </summary>
        public static double Dot(Vector a, Vector b)
            => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// <summary>
        /// Returns the cross product of two <see cref="Vector"/>s.
        /// </summary>
        public static Vector Cross(Vector a, Vector b)
            => new Vector(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

        /// <summary>
        /// Compares two <see cref="Vector"/>s for equality.
        /// </summary>
        public static bool operator ==(Vector a, Vector b)
        {
            return a.X.Equals(b.X)
                && a.Y.Equals(b.Y)
                && a.Z.Equals(b.Z);
        }

        /// <summary>
        /// Compares two <see cref="Vector"/>s for inequality.
        /// </summary>
        public static bool operator !=(Vector a, Vector b) => !(a == b);

        /// <summary>
        /// Adds two <see cref="Vector"/>s to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator +(Vector a, Vector b)
            => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        /// <summary>
        /// Subtracts two <see cref="Vector"/>s to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator -(Vector a, Vector b)
            => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        /// <summary>
        /// Scales a <see cref="Vector"/> to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator *(Vector a, double b)
            => new Vector(a.X * b, a.Y * b, a.Z * b);

        /// <summary>
        /// Scales a <see cref="Vector"/> to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator *(double b, Vector a)
            => new Vector(a.X * b, a.Y * b, a.Z * b);

        /// <summary>
        /// Scales a <see cref="Vector"/> to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator /(Vector a, double b)
            => new Vector(a.X / b, a.Y / b, a.Z / b);

        /// <summary>
        /// Scales a <see cref="Vector"/> to make a new <see cref="Vector"/>.
        /// </summary>
        public static Vector operator /(double b, Vector a)
            => new Vector(a.X / b, a.Y / b, a.Z / b);

        /// <summary>
        /// Casts <see cref="Point"/> to <see cref="Vector"/>.
        /// </summary>
        public static implicit operator Vector(Point p) => new Vector(p.X, p.Y);

        /// <summary>
        /// Maps the <see cref="Vector"/> to XY plane to make a <see cref="Point"/>.
        /// </summary>
        public static explicit operator Point(Vector v) => new Point(v.X, v.Y);

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Z.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj) => obj is Vector && this == (Vector)obj;

        /// <summary>
        /// Determines whether the specified <see cref="Vector"/> is equal to the current <see cref="Vector"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Vector"/> is equal to the current <see cref="Vector"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Vector"/> to compare with the current <see cref="Vector"/>. </param>
        public bool Equals(Vector other) => this == other;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return X.ToString(CultureInfo.InvariantCulture) + "," +
                   Y.ToString(CultureInfo.InvariantCulture) + "," +
                   Z.ToString(CultureInfo.InvariantCulture);
        }
    }
}
