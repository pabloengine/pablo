/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents a stride.
    /// </summary>
    public sealed class Stripe
    {
        /// <summary>
        /// The dash array of the <see cref="Stripe"/>.
        /// </summary>
        private readonly double[] _dashes;

        /// <summary>
        /// Gets the angle of the <see cref="Stripe"/>.
        /// </summary>
        public double Angle { get; }

        /// <summary>
        /// Gets the origin <see cref="Point"/> of the <see cref="Stripe"/>.
        /// </summary>
        public Point Origin { get; }

        /// <summary>
        /// Gets the offset <see cref="Point"/> of the <see cref="Stripe"/>.
        /// </summary>
        public Point Offset { get; }

        /// <summary>
        /// Gets the dash array of the <see cref="Stripe"/>.
        /// </summary>
        public IEnumerable<double> DashArray => Array.AsReadOnly(_dashes);

        /// <summary>
        /// Initializes a new instance of <see cref="Stripe"/> with the specified values.
        /// </summary>
        public Stripe(double angle, Point origin, Point offset, params double[] dashArray)
        {
            Angle = angle;
            Origin = origin;
            Offset = offset;
            _dashes = dashArray?.ToArray() ?? Array.Empty<double>();
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            var hash = _dashes.Aggregate(17, (current, dash) => current + dash.GetHashCode());
            hash = hash * 31 + Angle.GetHashCode();
            hash = hash * 31 + Origin.GetHashCode();
            hash = hash * 31 + Offset.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            var other = obj as Stripe;
            return other != null
                && Angle.Equals(other.Angle)
                && Origin == other.Origin
                && Offset == other.Offset;
        }

        /// <summary>
        /// Represents the <see cref="Stripe"/> as a <see cref="string"/>. This function is 
        /// guarateed to stay consistent and it is safe to use for serialization.
        /// </summary>
        /// <remarks>
        /// The opposite behavior of Parse with the same output format as the input format.
        /// "Angle,Origin.X,Origin.Y,Offset.X,Offset.Y,Dash1,Dash2,..." 
        /// </remarks>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
              // First angle
              .Append(Angle)
              .Append(',')

              // Then the origin point
              .Append(Origin.X)
              .Append(',')

              .Append(Origin.Y)
              .Append(',')

              // Then the offset point
              .Append(Offset.X)
              .Append(',')

              .Append(Offset.Y);

            // The rest are the dashes
            foreach (var dash in _dashes)
                sb
                    .Append(',')
                    .Append(dash);

            return sb.ToString();
        }

        /// <summary>
        /// Converts the string representation of <see cref="Stripe"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be: "Angle,Origin.X,Origin.Y,Offset.X,Offset.Y,Dash1,Dash2,..." 
        /// where all items are double precision 
        /// floating point numbers parsable with <code>double.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        public static Stripe Parse(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            try
            {
                // Split the strings.
                var strings = s.Split(',');

                // First one is angle.
                var angle = double.Parse(strings[0].Trim());

                // Second and third are the origin.
                var origin = new Point(double.Parse(strings[1].Trim()), double.Parse(strings[2].Trim()));

                // Forth and fifth are the offset.
                var offset = new Point(double.Parse(strings[3].Trim()), double.Parse(strings[4].Trim()));

                // the rest (if any) are the dashes
                var rest = strings.Length - 5;
                var dashes = new double[rest];

                for (var i = 0; i < rest; i++)
                    dashes[i] = double.Parse(strings[i + 5].Trim());

                return new Stripe(angle, origin, offset, dashes);
            }
            catch (Exception e)
            {
                throw new FormatException("The input string (" + s + ") was not in a valid format.", e);
            }
        }

    }
}
