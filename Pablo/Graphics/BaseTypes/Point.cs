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
    /// Represents a point in two dimensional space.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Gets or sets the X value of the <see cref="Point"/>.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets or sets the Y value of the <see cref="Point"/>.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Point"/> with the specified values.
        /// </summary>
        public Point(double x, double y)
            : this()
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Compares two <see cref="Point"/>s for equality.
        /// </summary>
        public static bool operator ==(Point a, Point b)
        {
            return a.X.Equals(b.X)
                && a.Y.Equals(b.Y);
        }

        /// <summary>
        /// Compares two <see cref="Point"/>s for inequality.
        /// </summary>
        public static bool operator !=(Point a, Point b) => !(a == b);

        /// <summary>
        /// Adds two <see cref="Point"/>s to make a new <see cref="Point"/>.
        /// </summary>
        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);

        /// <summary>
        /// Subtracts two <see cref="Point"/>s to make a new <see cref="Point"/>.
        /// </summary>
        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

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
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj) => obj is Point && this == (Point)obj;

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Point"/> is equal to the current <see cref="Point"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Point"/> to compare with the current <see cref="Point"/>. </param>
        public bool Equals(Point other) => this == other;

        /// <summary>
        /// Converts the string representation of <see cref="Box"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be: "x,y" where x and y are 
        /// floating point numbers parsable with <code>double.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        public static Point Parse(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            try
            {
                return ParseImpl(s);
            }
            catch (Exception e)
            {
                throw new FormatException($"The input string ( {s} ) was not in a valid format.", e);
            }
        }

        /// <summary>
        /// Implementation of the <see cref="Parse"/> method.
        /// </summary>
        public static Point ParseImpl(string s)
        {
            var strings = s.Split(',');
            var x = double.Parse(strings[0]);
            var y = double.Parse(strings[1]);
            return new Point(x, y);
        }

        /// <summary>
        /// Represents the <see cref="Point"/> as a <see cref="string"/>. This function is 
        /// guarateed to stay consistent and it is safe to use for serialization.
        /// </summary>
        /// <remarks>
        /// The opposite behavior of Parse with the same output format as the input format.
        /// "X,Y" The numbers are serialized using 
        /// <code>double.ToString(CultureInfo.InvariantCulture)</code>
        /// </remarks>
        public override string ToString()
        {
            return X.ToString(CultureInfo.InvariantCulture) + "," +
                   Y.ToString(CultureInfo.InvariantCulture);
        }

    }

}
