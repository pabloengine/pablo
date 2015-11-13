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
    /// Represents box thickness.
    /// </summary>
    public struct Thickness : IEquatable<Thickness>
    {
        /// <summary>
        /// Gets the Left side of the <see cref="Thickness"/>.
        /// </summary>
        public double Left { get; }

        /// <summary>
        /// Gets the Top side of the <see cref="Thickness"/>.
        /// </summary>
        public double Top { get; }

        /// <summary>
        /// Gets the Right side of the <see cref="Thickness"/>.
        /// </summary>
        public double Right { get; }

        /// <summary>
        /// Gets the Bottom side of the <see cref="Thickness"/>.
        /// </summary>
        public double Bottom { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/> with uniform sides.
        /// </summary>
        public Thickness(double size)
        {
            if (size < 0)
                throw new ArgumentException("Thickness cannot be less than zero.");

            Left = size;
            Top = size;
            Right = size;
            Bottom = size;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/> with different vertical and horizontal sides.
        /// </summary>
        public Thickness(double leftRight, double topBottom)
        {
            if (leftRight < 0 || topBottom < 0)
                throw new ArgumentException("Thickness cannot be less than zero.");

            Left = leftRight;
            Top = topBottom;
            Right = leftRight;
            Bottom = topBottom;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Thickness"/> with different sides.
        /// </summary>
        public Thickness(double left, double top, double right, double bottom)
        {
            if (left < 0 || top < 0 || right < 0 || bottom < 0)
                throw new ArgumentException("Thickness cannot be less than zero.");

            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Compares two <see cref="Thickness"/>es for equality.
        /// </summary>
        public static bool operator ==(Thickness a, Thickness b)
        {
            return a.Left.Equals(b.Left)
                && a.Top.Equals(b.Top)
                && a.Right.Equals(b.Right)
                && a.Bottom.Equals(b.Bottom);
        }

        /// <summary>
        /// Compares two <see cref="Thickness"/>es for inequality.
        /// </summary>
        public static bool operator !=(Thickness a, Thickness b) => !(a == b);

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 31 + Left.GetHashCode();
            hash = hash * 31 + Top.GetHashCode();
            hash = hash * 31 + Right.GetHashCode();
            hash = hash * 31 + Bottom.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj) => obj is Thickness && this == (Thickness)obj;

        #region Implementation of IEquatable<Thickness>

        /// <summary>
        /// Determines whether the specified <see cref="Thickness"/> is equal to the current <see cref="Thickness"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Thickness"/> is equal to the current <see cref="Thickness"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Thickness"/> to compare with the current <see cref="Thickness"/>. </param>
        public bool Equals(Thickness other) => this == other;

        #endregion

        /// <summary>
        /// Converts the string representation of <see cref="Thickness"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be one of the following:
        /// <list type="number">
        ///     <item>
        ///         <term>"1.4"</term> 
        ///         <description>
        ///             All sides will have the thickness of 1.4.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"1.4,1.5"</term> 
        ///         <description>
        ///             Left and right sides will have the value 1.4 and the
        ///             top and bottom sides will have the value 1.5.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"1.4,1.5,1.6,2.7"</term> 
        ///         <description>
        ///             Left, top, right and bottom will have the values
        ///             1.4, 1.5, 1.6 and 2.7 respectively.
        ///         </description>
        ///     </item>
        /// </list>
        /// All numbers are parsed with <code>double.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        public static Thickness Parse(string s)
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
        private static Thickness ParseImpl(string s)
        {
            var strings = s.Split(',');

            switch (strings.Length)
            {
                case 1:
                    return new Thickness(double.Parse(strings[0]));
                case 2:
                    return new Thickness(double.Parse(strings[0]), double.Parse(strings[1]));
                case 4:
                    var left = double.Parse(strings[0]);
                    var top = double.Parse(strings[1]);
                    var right = double.Parse(strings[2]);
                    var bottom = double.Parse(strings[3]);
                    return new Thickness(left, top, right, bottom);
                default:
                    throw new ArgumentException("Invalid number of comma separated values.");
            }
        }

        /// <summary>
        /// Represents the <see cref="Thickness"/> as a <see cref="string"/>. This function is 
        /// guarateed to stay consistent and it is safe to use for serialization.
        /// </summary>
        /// <remarks>
        /// The opposite behavior of Parse with the same output format as the input format.
        /// "Left,Top,Right,Bottom" The numbers are serialized using 
        /// <code>double.ToString(CultureInfo.InvariantCulture)</code>
        /// </remarks>
        public override string ToString()
        {
            return Left.ToString(CultureInfo.InvariantCulture) + "," +
                   Top.ToString(CultureInfo.InvariantCulture) + "," +
                   Right.ToString(CultureInfo.InvariantCulture) + "," +
                   Bottom.ToString(CultureInfo.InvariantCulture);
        }
    }
}
