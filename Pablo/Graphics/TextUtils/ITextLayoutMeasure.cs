/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

namespace Pablo.Graphics
{
    /// <summary>
    /// Defines a method to measure the layout of a rendered text.
    /// </summary>
    public interface ITextLayoutMeasure
    {
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
        double MeasureWidthToHeightRatio(string text, double fontHeight, string fontFamily, FontWeight fontWeight);
    }
}
