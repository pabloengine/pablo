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
    /// Represents a dimension of an element.
    /// </summary>
    public struct Dimension : IEquatable<Dimension>
    {
        /// <summary>
        /// Gets the value of this <see cref="Dimension"/>.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Get the <see cref="DimensionBehavior"/> of this <see cref="Dimension"/>.
        /// </summary>
        public DimensionBehavior Behavior { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Dimension"/> with the specified value and behavior.
        /// </summary>
        /// <exception cref="ArgumentException">value is less than zero</exception>
        public Dimension(double value, DimensionBehavior behavior)
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(value)} cannot be less than zero.", nameof(value));

            Value = value;
            Behavior = behavior;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Dimension"/> with static value.
        /// </summary>
        /// <exception cref="ArgumentException">value is less than zero</exception>
        public Dimension(double value)
            : this(value, DimensionBehavior.Static)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="Dimension"/> with the specified behavior.
        /// </summary>
        /// <exception cref="ArgumentException">value is less than zero</exception>
        public Dimension(DimensionBehavior behavior)
            : this(0, behavior)
        { }

        /// <summary>
        /// Compares two <see cref="Dimension"/>es for equality.
        /// </summary>
        public static bool operator ==(Dimension a, Dimension b)
        {
            return a.Behavior == b.Behavior
                && a.Value.Equals(b.Value);
        }

        /// <summary>
        /// Compares two <see cref="Dimension"/>es for inequality.
        /// </summary>
        public static bool operator !=(Dimension a, Dimension b) => !(a == b);

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 31 + Value.GetHashCode();
            hash = hash * 31 + Behavior.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj) => obj is Dimension && this == (Dimension)obj;

        #region Implementation of IEquatable<Dimension>

        /// <summary>
        /// Determines whether the specified <see cref="Dimension"/> is equal to the current <see cref="Dimension"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Dimension"/> is equal to the current <see cref="Dimension"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Dimension"/> to compare with the current <see cref="Dimension"/>. </param>
        public bool Equals(Dimension other) => this == other;

        #endregion

        /// <summary>
        /// Converts the string representation of <see cref="Dimension"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be one of the following:
        /// <list type="number">
        ///     <item>
        ///         <term>"14.7"</term> 
        ///         <description>
        ///             The value will be 14.7 and behavior <see cref="DimensionBehavior.Static"/>.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Shrink"</term> 
        ///         <description>
        ///             The behavior will be <see cref="DimensionBehavior.Shrink"/>.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Stretch"</term> 
        ///         <description>
        ///             The behavior will be <see cref="DimensionBehavior.Stretch"/>.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"20*"</term> 
        ///         <description>
        ///             The value will be 20 (relative to siblings) and behavior <see cref="DimensionBehavior.Relative"/>.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"54.2%"</term> 
        ///         <description>
        ///             The value will be 54.2 (percentage of maximum possible value) 
        ///             and behavior <see cref="DimensionBehavior.Proportional"/>.
        ///         </description>
        ///     </item>
        /// </list>
        /// All numbers are parsed with <code>double.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        public static Dimension Parse(string s)
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
        private static Dimension ParseImpl(string s)
        {
            if (s == nameof(DimensionBehavior.Shrink))
                return new Dimension(DimensionBehavior.Shrink);

            if (s == nameof(DimensionBehavior.Stretch))
                return new Dimension(DimensionBehavior.Stretch);

            if (s.Trim().EndsWith("*"))
                return new Dimension(double.Parse(s.Trim().Replace("*", "")), DimensionBehavior.Relative);

            if (s.Trim().EndsWith("%"))
                return new Dimension(double.Parse(s.Trim().Replace("%", "")), DimensionBehavior.Proportional);

            return new Dimension(double.Parse(s.Trim()));
        }

        /// <summary>
        /// Represents the <see cref="Dimension"/> as a <see cref="string"/>. This function is 
        /// guarateed to stay consistent and it is safe to use for serialization.
        /// </summary>
        /// <remarks>
        /// The opposite behavior of Parse with the same output format as the input format.
        /// "Value" for <see cref="DimensionBehavior.Static"/>, "Shrink" for <see cref="DimensionBehavior.Shrink"/>, 
        /// "Stretch" for <see cref="DimensionBehavior.Stretch"/>, "Value*" for <see cref="DimensionBehavior.Relative"/>
        /// and "Value%" for <see cref="DimensionBehavior.Proportional"/>.
        /// <code>double.ToString(CultureInfo.InvariantCulture)</code>
        /// </remarks>
        public override string ToString()
        {
            switch (Behavior)
            {
                case DimensionBehavior.Shrink:
                    return nameof(DimensionBehavior.Shrink);
                case DimensionBehavior.Stretch:
                    return nameof(DimensionBehavior.Stretch);
                case DimensionBehavior.Relative:
                    return $"{Value}*";
                case DimensionBehavior.Proportional:
                    return $"{Value}%";
                case DimensionBehavior.Static:
                    return Value.ToString(CultureInfo.InvariantCulture);
                default:
                    throw new InvalidOperationException("Unknown behavior.");
            }

        }
    }
}
