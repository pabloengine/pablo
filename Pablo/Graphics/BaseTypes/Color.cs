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
    /// Represents a color in rgba space.
    /// </summary>
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Gets the red value of the <see cref="Color"/>.
        /// </summary>
        public byte R { get; }

        /// <summary>
        /// Gets the green value of the <see cref="Color"/>.
        /// </summary>
        public byte G { get; }

        /// <summary>
        /// Gets the blue value of the <see cref="Color"/>.
        /// </summary>
        public byte B { get; }

        /// <summary>
        /// Gets the alpha value of the <see cref="Color"/> which simulates transparency.
        /// </summary>
        public byte A { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Color"/> from red, green and blue.
        /// Defaults the alpha to 255.
        /// </summary>
        public Color(byte r, byte g, byte b)
            : this()
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Color"/> from red, green, blue and alpha.
        /// </summary>
        public Color(byte r, byte g, byte b, byte a)
            : this()
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Compares two <see cref="Color"/>s for equality.
        /// </summary>
        public static bool operator ==(Color a, Color b)
        {
            return a.R == b.R
                && a.G == b.G
                && a.B == b.B
                && a.A == b.A;
        }

        /// <summary>
        /// Compares two <see cref="Color"/>s for inequality.
        /// </summary>
        public static bool operator !=(Color a, Color b) => !(a == b);

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 31 + R.GetHashCode();
            hash = hash * 31 + G.GetHashCode();
            hash = hash * 31 + B.GetHashCode();
            hash = hash * 31 + A.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj) => obj is Color && this == (Color)obj;

        #region Implementation of IEquatable<Color>

        /// <summary>
        /// Determines whether the specified <see cref="Color"/> is equal to the current <see cref="Color"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Color"/> is equal to the current <see cref="Color"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Color"/> to compare with the current <see cref="Color"/>. </param>
        public bool Equals(Color other) => this == other;

        #endregion

        /// <summary>
        /// Converts the string representation of <see cref="Color"/> into its logical representation.
        /// </summary>
        /// <param name="s">
        /// The format of the input string must be one of the following:
        /// <list type="number">
        ///     <item>
        ///         <term>"#ffffff"</term> 
        ///         <description>
        ///             The hax code of the color. First 2 nibbles are the red byte,
        ///             the next 2 are the green byte and the last 2 nibbles are the blue byte.
        ///             The hex digits are case-insensitive. The alpha is defaulted to 255. 
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"#fff"</term> 
        ///         <description>
        ///             Shorter form of #ffffff. each hexadecimal digit represents 2 nibles.
        ///             That is, the string #1a5 is equivalent to #11aa55.
        ///             The hex digits are case-insensitive. The alpha is defaulted to 255. 
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"128,255,128"</term> 
        ///         <description>
        ///             The argumnets are respectively red, green and the blue byte.
        ///             The range is from 0 to 255 inclusively.
        ///             The alpha is defaulted to 255.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"128,255,128,128"</term> 
        ///         <description>
        ///             The argumnets are respectively red, green, blue and the alpha byte.
        ///             The range is from 0 to 255 inclusively.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Red"</term> 
        ///         <description>
        ///             The color is queried from <see cref="Colors"/>.
        ///             The alpha is defaulted to 255.
        ///         </description>
        ///     </item>
        /// </list>
        /// All numbers are parsed with <code>byte.Parse(s)</code>
        /// </param>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">input string is in not in the correct format</exception>
        public static Color Parse(string s)
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
        private static Color ParseImpl(string s)
        {
            // Formats: #ffffff and #fff
            if (s[0] == '#')
            {
                var hexCode = s.Substring(1, s.Length - 1);

                // Format: #ffffff
                if (hexCode.Length == 6)
                {
                    var r = byte.Parse(hexCode.Substring(0, 2), NumberStyles.HexNumber);
                    var g = byte.Parse(hexCode.Substring(2, 2), NumberStyles.HexNumber);
                    var b = byte.Parse(hexCode.Substring(4, 2), NumberStyles.HexNumber);
                    return new Color(r, g, b);
                }
                // Format: #fff
                else
                {
                    var r = byte.Parse(hexCode[0].ToString(CultureInfo.InvariantCulture), NumberStyles.HexNumber);
                    var g = byte.Parse(hexCode[1].ToString(CultureInfo.InvariantCulture), NumberStyles.HexNumber);
                    var b = byte.Parse(hexCode[2].ToString(CultureInfo.InvariantCulture), NumberStyles.HexNumber);
                    // Implements the formula: #fff => #ffffff, #abc => #aabbcc
                    return new Color((byte)(r + r * 16), (byte)(g + g * 16), (byte)(b + b * 16));
                }
            }

            // Format: Blue, red, GREEN, etc.
            if (Colors.NameExists(s))
                return Colors.GetColor(s);

            // Formats: 255,255,255 and 255,255,255,255
            var strings = s.Split(',');
            var r2 = byte.Parse(strings[0]);
            var g2 = byte.Parse(strings[1]);
            var b2 = byte.Parse(strings[2]);
            // Check for the optional alpha parameter
            var a2 = (strings.Length == 4) ? byte.Parse(strings[3]) : byte.MaxValue;
            return new Color(r2, g2, b2, a2);
        }

        /// <summary>
        /// Returns a new <see cref="Color"/> from the inverted input <see cref="Color"/>.
        /// </summary>
        public static Color Invert(Color color)
        {
            return new Color((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B), color.A);
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Color"/>.This function is 
        /// guarateed to stay consistent and it is safe to use for serialization.
        /// </summary>
        /// <remarks>
        /// The opposite behavior of Parse with the output format of:
        /// "R,G,B,A" i.e. "128,255,128,255"
        /// </remarks>
        public override string ToString() => $"{R},{G},{B},{A}";
    }

}
