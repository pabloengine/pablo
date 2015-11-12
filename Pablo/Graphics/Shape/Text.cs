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
    /// Displays a text described by a <see cref="TextGeometry"/>.
    /// </summary>
    public class Text : Shape<TextGeometry>
    {

        /// <summary>
        /// Gets the font family of the <see cref="Text"/>.
        /// </summary>
        public string FontFamily => Geometry.FontFamily;

        /// <summary>
        /// Gets the <see cref="Graphics.FontStyle"/> of the <see cref="Text"/>.
        /// </summary>
        public FontStyle FontStyle => Geometry.FontStyle;

        /// <summary>
        /// Gets the <see cref="Graphics.FontWeight"/> of the <see cref="Text"/>.
        /// </summary>
        public FontWeight FontWeight => Geometry.FontWeight;

        /// <summary>
        /// Gets the <see cref="Graphics.FontDecoration"/> of the <see cref="Text"/>.
        /// </summary>
        public FontDecoration FontDecoration => Geometry.FontDecoration;

        /// <summary>
        /// Gets the font height of the <see cref="Text"/>.
        /// </summary>
        public double FontHeight => Geometry.FontHeight;

        /// <summary>
        /// Gets the content of the <see cref="Text"/>.
        /// </summary>
        public string Content => Geometry.Content;

        /// <summary>
        /// Gets the baseline's left <see cref="Point"/> of the <see cref="Text"/>.
        /// </summary>
        public Point BaseLineLeft => Geometry.BaseLineLeft;

        /// <summary>
        /// Gets the rotation angle of the <see cref="Text"/> in degrees.
        /// </summary>
        /// <remarks>
        /// The rotation is centered around the <see cref="BaseLineLeft"/>.
        /// </remarks>
        public double Rotation => Geometry.Rotation;

        /// <summary>
        /// Gets the width of the <see cref="Text"/>.
        /// </summary>
        public double TextWidth => Geometry.TextWidth;

        /// <summary>
        /// Determines whether the <see cref="Text"/> is renderable and affects layout.
        /// </summary>
        public bool Renderable => Geometry.Renderable;

    }
}
