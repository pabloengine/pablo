/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;

namespace Pablo.Graphics
{
    /// <summary>
    /// A factory that creates <see cref="Text"/> objects.
    /// </summary>
    public sealed class TextBuilder
    {
        /// <summary>
        /// The <see cref="TextGeometry"/> that the <see cref="Text"/> will be built from.
        /// </summary>
        private readonly TextGeometry _geometry;

        /// <summary>
        /// Gets or sets the font family of the <see cref="TextBuilder"/>.
        /// </summary>
        public string FontFamily
        {
            get { return _geometry.FontFamily; }
            set { _geometry.FontFamily = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontStyle"/> of the <see cref="TextBuilder"/>.
        /// </summary>
        public FontStyle FontStyle
        {
            get { return _geometry.FontStyle; }
            set { _geometry.FontStyle = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontWeight"/> of the <see cref="TextBuilder"/>.
        /// </summary>
        public FontWeight FontWeight
        {
            get { return _geometry.FontWeight; }
            set { _geometry.FontWeight = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontDecoration"/> of the <see cref="TextBuilder"/>.
        /// </summary>
        public FontDecoration FontDecoration
        {
            get { return _geometry.FontDecoration; }
            set { _geometry.FontDecoration = value; }
        }


        /// <summary>
        /// Gets or sets font height of the <see cref="TextBuilder"/>.
        /// </summary>
        /// <remarks>
        /// Setting the font height does not stretch the <see cref="TextBuilder"/>
        /// but scale it. As does <see cref="TextWidth"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">value must not be less than zero</exception>
        public double FontHeight
        {
            get { return _geometry.FontHeight; }
            set { _geometry.FontHeight = value; }
        }

        /// <summary>
        /// Gets or sets the content of the <see cref="TextBuilder"/>.
        /// </summary>
        public string Content
        {
            get { return _geometry.Content; }
            set { _geometry.Content = value; }
        }

        /// <summary>
        /// Gets or sets the baseline's left <see cref="Point"/> of the <see cref="TextBuilder"/>.
        /// </summary>
        public Point BaseLineLeft
        {
            get { return _geometry.BaseLineLeft; }
            set { _geometry.BaseLineLeft = value; }
        }

        /// <summary>
        /// Gets or sets the rotation angle of the <see cref="TextBuilder"/> in degrees.
        /// </summary>
        /// <remarks>
        /// The rotation is centered around the <see cref="BaseLineLeft"/>.
        /// </remarks>
        public double Rotation
        {
            get { return _geometry.Rotation; }
            set { _geometry.Rotation = value; }
        }

        /// <summary>
        /// Gets or sets the width of the <see cref="TextBuilder"/>.
        /// </summary>
        /// <remarks>
        /// Setting the text width does not stretch the <see cref="TextBuilder"/>
        /// but scale it. As does <see cref="FontHeight"/>
        /// </remarks>
        public double TextWidth
        {
            get { return _geometry.TextWidth; }
            set { _geometry.TextWidth = value; }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextBuilder"/>.
        /// </summary>
        public TextBuilder()
        {
            _geometry = new TextGeometry();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextBuilder"/> with the provided <see cref="ITextLayoutMeasure"/>.
        /// </summary>
        public TextBuilder(ITextLayoutMeasure textLayoutMeasure)
        {
            _geometry = new TextGeometry(textLayoutMeasure);
        }

        /// <summary>
        /// Sets the width of the <see cref="TextBuilder"/> limited by the provided font height.
        /// </summary>
        /// <remarks>
        /// Useful for fitting the <see cref="TextBuilder"/> in a tight spot.
        /// </remarks>
        public void SetWidthWithHeightLimit(double width, double heightLimit)
        {
            _geometry.SetWidthWithHeightLimit(width, heightLimit);
        }

        /// <summary>
        /// Create a new instance of <see cref="Text"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">Must be renderable, see <see cref="TextGeometry"/> for more info.</exception>
        /// <returns>The newly created instance</returns>
        public Text Build()
        {
            // Make sure the resulting shape is valid
            if (!_geometry.Renderable)
                throw new InvalidOperationException($"The resulting {nameof(Text)} must be renderable.");

            // Make an immutable clone from the current geometry object. 
            var targetGeometry = (TextGeometry)_geometry.ImmutableClone();

            // Return a new shape.
            return new Text { Geometry = targetGeometry };
        }

    }
}
