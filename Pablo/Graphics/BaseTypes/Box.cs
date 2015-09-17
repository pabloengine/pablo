/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pablo
{
    /// <summary>
    /// Represents a box in a 2 dimensional space.
    /// </summary>
    public struct Box
    {
        /// <summary>
        /// Gets the Left side of the <see cref="Box"/>.
        /// </summary>
        public double Left { get; }

        /// <summary>
        /// Gets the Top side of the <see cref="Box"/>.
        /// </summary>
        public double Top { get; }

        /// <summary>
        /// Gets the Right side of the <see cref="Box"/>.
        /// </summary>
        public double Right { get; }

        /// <summary>
        /// Gets the Bottom side of the <see cref="Box"/>.
        /// </summary>
        public double Bottom { get; }

        /// <summary>
        /// Gets the TopLeft <see cref="Point"/> of the <see cref="Box"/>.
        /// </summary>
        public Point TopLeft => new Point(Left, Top);

        /// <summary>
        /// Gets the TopRight <see cref="Point"/> of the <see cref="Box"/>.
        /// </summary>
        public Point TopRight => new Point(Right, Top);

        /// <summary>
        /// Gets the BottomLeft <see cref="Point"/> of the <see cref="Box"/>.
        /// </summary>
        public Point BottomLeft => new Point(Left, Bottom);

        /// <summary>
        /// Gets the BottomRight <see cref="Point"/> of the <see cref="Box"/>.
        /// </summary>
        public Point BottomRight => new Point(Right, Bottom);

        /// <summary>
        /// Gets the Center <see cref="Point"/> of the <see cref="Box"/>.
        /// </summary>
        public Point Center => new Point((Right + Left) / 2.0, (Top + Bottom) / 2.0);

        /// <summary>
        /// Gets all four <see cref="Point"/>s of the <see cref="Box"/> 
        /// in a clockwise order starting from <see cref="TopLeft"/>.
        /// </summary>
        public IEnumerable<Point> Points
        {
            get
            {
                yield return TopLeft;
                yield return TopRight;
                yield return BottomRight;
                yield return BottomLeft;
            }
        }

        /// <summary>
        /// Gets the Width of the <see cref="Box"/>.
        /// </summary>
        public double Width => Right - Left;

        /// <summary>
        /// Gets the Height of the <see cref="Box"/>.
        /// </summary>
        public double Height => Top - Bottom;

        /// <summary>
        /// Initializes a new instance of <see cref="Box"/> from the four sides.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public Box(double left, double top, double right, double bottom)
            : this()
        {

            if (left > right || top < bottom)
                throw new ArgumentException("The invariant left <= right and top >= bottom must hold.");

            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Box"/> from the 
        /// bottomLeft <see cref="Point"/> and the topRight <see cref="Point"/>.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public Box(Point bottomLeft, Point topRight)
            : this(bottomLeft.X, topRight.Y, topRight.X, bottomLeft.Y)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Box"/> from 
        /// the bottomLeft <see cref="Point"/> and its dimensions.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public Box(Point bottomLeft, double width, double height)
            : this(bottomLeft.X, bottomLeft.Y + height, bottomLeft.X + width, bottomLeft.Y)
        { }

        /// <summary>
        /// Compares two <see cref="Box"/>es for equality.
        /// </summary>
        public static bool operator ==(Box a, Box b)
        {
            return a.Left.Equals(b.Left)
                && a.Top.Equals(b.Top)
                && a.Right.Equals(b.Right)
                && a.Bottom.Equals(b.Bottom);
        }

        /// <summary>
        /// Compares two <see cref="Box"/>es for inequality.
        /// </summary>
        public static bool operator !=(Box a, Box b) => !(a == b);

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
        public override bool Equals(object obj) => obj is Box && this == (Box)obj;

        /// <summary>
        /// Determines whether the specified <see cref="Box"/> is equal to the current <see cref="Box"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Box"/> is equal to the current <see cref="Box"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Box"/> to compare with the current <see cref="Box"/>. </param>
        public bool Equals(Box other) => this == other;

        /// <summary>
        /// Creates a square <see cref="Box"/> at the origin.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public static Box Square(double width) => new Box(new Point(0, 0), width, width);

        /// <summary>
        /// Creates a square <see cref="Box"/> at the bottomLeft <see cref="Point"/>.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public static Box Square(Point bottomLeft, double width) => new Box(bottomLeft, width, width);

        /// <summary>
        /// Converts the string representation of <see cref="Box"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be: "left,top,right,bottom" where left, top, right
        /// and bottom are floating point numbers parsable with <code>double.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        public static Box Parse(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            try
            {
                return ParseImpl(s);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FormatException($"The input string ( {s} ) was not in a valid format.", e);
            }
        }

        /// <summary>
        /// Implementation of the <see cref="Parse"/> method.
        /// </summary>
        /// <exception cref="ArgumentException">left &gt; right or top &lt; bottom</exception>
        private static Box ParseImpl(string s)
        {
            // Split the string
            var strings = s.Split(',');
            // Extract the items
            var left = double.Parse(strings[0]);
            var top = double.Parse(strings[1]);
            var right = double.Parse(strings[2]);
            var bottom = double.Parse(strings[3]);
            return new Box(left, top, right, bottom);
        }

        /// <summary>
        /// Represents the <see cref="Box"/> as a <see cref="string"/>. This function is 
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
