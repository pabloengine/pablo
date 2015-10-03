/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Drawing;

namespace Pablo.Graphics
{
    /// <summary>
    /// Calculates the size of a text layout.
    /// </summary>
    /// <remarks>
    /// This class is stateless and singleton.
    /// </remarks>
    public class DefaultTextLayoutMeasure : ITextLayoutMeasure
    {
        /// <summary>
        /// The instance of <see cref="DefaultTextLayoutMeasure"/>.
        /// </summary>
        public static DefaultTextLayoutMeasure Instance { get; } = new DefaultTextLayoutMeasure();

        /// <summary>
        /// Initializes a new instance of <see cref="DefaultTextLayoutMeasure"/>.
        /// </summary>
        private DefaultTextLayoutMeasure() { }

        #region Implementation of ITextLayoutMeasure

        /// <summary>
        /// Measure the ratio between the width and the height of the text layout.
        /// Returns <see cref="double.NaN"/> if the input does not result in a renderable text.
        /// </summary>
        /// <param name="text">The contents of the layout</param>
        /// <param name="fontHeight">The height of the layout</param>
        /// <param name="fontFamily">The font family of the layout</param>
        /// <param name="fontWeight">The weight of the font used in the layout</param>
        /// <returns>
        /// The ratio between the width and the height of the text layout, i.e. Width/Height. 
        /// <see cref="double.NaN"/> if the input does not result in a renderable text.
        /// </returns>
        public double MeasureWidthToHeightRatio(string text, double fontHeight, string fontFamily, FontWeight fontWeight)
        {
            // Make sure the text is renderable.
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(fontFamily) || fontHeight <= 0)
                return double.NaN;

            // Initialize the context to run the calculations.
            using (var font = new Font(new FontFamily(fontFamily), (float)fontHeight, ToFontStyle(fontWeight), GraphicsUnit.Millimeter))
            using (var image = new Bitmap(1, 1))
            using (var graphics = System.Drawing.Graphics.FromImage(image))
            {
                var size = graphics.MeasureString(text, font);
                return size.Width / size.Height;
            }
        }

        #endregion

        /// <summary>
        /// Converts the <see cref="FontWeight"/> to <see cref="System.Drawing.FontStyle"/>.
        /// </summary>
        private static System.Drawing.FontStyle ToFontStyle(FontWeight fontWeight)
        {
            switch (fontWeight)
            {
                case FontWeight.Normal:
                    return System.Drawing.FontStyle.Regular;
                case FontWeight.Thin:
                    return System.Drawing.FontStyle.Regular;
                case FontWeight.Light:
                    return System.Drawing.FontStyle.Regular;
                case FontWeight.Medium:
                    return System.Drawing.FontStyle.Bold;
                case FontWeight.Bold:
                    return System.Drawing.FontStyle.Bold;
                case FontWeight.Black:
                    return System.Drawing.FontStyle.Bold;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fontWeight), fontWeight, null);
            }
        }

    }
}
