/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Globalization.CultureInfo;

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents the <see cref="Geometry"/> of a text.
    /// </summary>
    public sealed class TextGeometry : Geometry, IEquatable<TextGeometry>, IXmlSerializable
    {
        /// <summary>
        /// The default <see cref="ITextLayoutMeasure"/> instance to use 
        /// when creating new instances of the <see cref="TextGeometry"/>.
        /// </summary>
        public static ITextLayoutMeasure DefaultTextLayoutMeasure = Graphics.DefaultTextLayoutMeasure.Instance;

        /// <summary>
        /// The font family of the <see cref="TextGeometry"/>.
        /// </summary>
        private string _fontFamily;

        /// <summary>
        /// The <see cref="Graphics.FontStyle"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        private FontStyle _fontStyle;

        /// <summary>
        /// The <see cref="Graphics.FontWeight"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        private FontWeight _fontWeight;

        /// <summary>
        /// The <see cref="Graphics.FontDecoration"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        private FontDecoration _fontDecoration;

        /// <summary>
        /// The font height of the <see cref="TextGeometry"/>.
        /// </summary>
        private double _fontHeight;

        /// <summary>
        /// The content of the <see cref="TextGeometry"/>.
        /// </summary>
        private string _content;

        /// <summary>
        /// The baseline's left <see cref="Point"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        private Point _baseLineLeft;

        /// <summary>
        /// The rotation angle of the <see cref="TextGeometry"/> in degrees.
        /// </summary>
        private double _rotation;

        /// <summary>
        /// the layout measurer instance used in width calculations of the <see cref="TextGeometry"/>.
        /// </summary>
        private readonly ITextLayoutMeasure _layoutMeasure;

        /// <summary>
        /// Gets or sets the font family of the <see cref="TextGeometry"/>.
        /// </summary>
        public string FontFamily
        {
            get { return _fontFamily; }
            set
            {
                ThrowOnReadOnly();
                _fontFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontStyle"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set
            {
                ThrowOnReadOnly();
                _fontStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontWeight"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set
            {
                ThrowOnReadOnly();
                _fontWeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.FontDecoration"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        public FontDecoration FontDecoration
        {
            get { return _fontDecoration; }
            set
            {
                ThrowOnReadOnly();
                _fontDecoration = value;
            }
        }


        /// <summary>
        /// Gets or sets font height of the <see cref="TextGeometry"/>.
        /// </summary>
        /// <remarks>
        /// Setting the font height does not stretch the <see cref="TextGeometry"/>
        /// but scale it. As does <see cref="TextWidth"/>.
        /// </remarks>
        public double FontHeight
        {
            get { return _fontHeight; }
            set
            {
                ThrowOnReadOnly();
                if (value < 0)
                    throw new InvalidOperationException($"{nameof(FontHeight)} cannot be less than zero");
                _fontHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the content of the <see cref="TextGeometry"/>.
        /// </summary>
        public string Content
        {
            get { return _content; }
            set
            {
                ThrowOnReadOnly();
                _content = value;
            }
        }

        /// <summary>
        /// Gets or sets the baseline's left <see cref="Point"/> of the <see cref="TextGeometry"/>.
        /// </summary>
        public Point BaseLineLeft
        {
            get { return _baseLineLeft; }
            set
            {
                ThrowOnReadOnly();
                _baseLineLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the rotation angle of the <see cref="TextGeometry"/> in degrees.
        /// </summary>
        /// <remarks>
        /// The rotation is centered around the <see cref="BaseLineLeft"/>.
        /// </remarks>
        public double Rotation
        {
            get { return _rotation; }
            set
            {
                ThrowOnReadOnly();
                _rotation = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the <see cref="TextGeometry"/>.
        /// </summary>
        /// <remarks>
        /// Setting the text width does not stretch the <see cref="TextGeometry"/>
        /// but scale it. As does <see cref="FontHeight"/>
        /// </remarks>
        public double TextWidth
        {
            get
            {
                var ratio = _layoutMeasure.MeasureWidthToHeightRatio(_content, _fontHeight, _fontFamily, _fontWeight);
                if (double.IsNaN(ratio))
                    return 0;

                // Convert the height to width using their conversion ratio.
                return _fontHeight * ratio;
            }
            set
            {
                ThrowOnReadOnly();

                var ratio = _layoutMeasure.MeasureWidthToHeightRatio(_content, _fontHeight, _fontFamily, _fontWeight);
                // Without the ratio the height is not calculatable.
                if (double.IsNaN(ratio))
                    _fontHeight = 0;

                // Convert the width to the height using the layout measure.
                _fontHeight = value / _layoutMeasure.MeasureWidthToHeightRatio(_content, _fontHeight, _fontFamily, _fontWeight);
            }
        }

        /// <summary>
        /// Determines whether the <see cref="TextGeometry"/> is renderable and affects layout.
        /// </summary>
        public bool Renderable => Content != null && FontFamily != null && FontHeight > 0;

        /// <summary>
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public override bool IsClosed { get; } = true;

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox
        {
            get
            {
                // If not renderable return a single dot as the bounding box.
                if (!Renderable)
                    return Box.Encompass(BaseLineLeft);

                // Cache the width query.
                var width = TextWidth;
                // If there are no rotations, skip the heavy calculations.
                if (Rotation.Equals(0))
                    return new Box(BaseLineLeft.X,
                        BaseLineLeft.Y + _fontHeight,
                        BaseLineLeft.X + width,
                        BaseLineLeft.Y);

                // Rotate and translate the points.
                var baselineLeft = BaseLineLeft;
                var baselineRight = BaseLineLeft + (Point)Vector.RotateZDegree(new Vector(width, 0), Rotation);
                var toplineLeft = BaseLineLeft + (Point)Vector.RotateZDegree(new Vector(0, _fontHeight), Rotation);
                var toplineRight = BaseLineLeft + (Point)Vector.RotateZDegree(new Vector(width, _fontHeight), Rotation);

                return Box.Encompass(baselineLeft, baselineRight, toplineLeft, toplineRight);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextGeometry"/>.
        /// </summary>
        public TextGeometry()
        {
            _layoutMeasure = DefaultTextLayoutMeasure ?? Graphics.DefaultTextLayoutMeasure.Instance;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextGeometry"/>
        /// with the specified <see cref="ITextLayoutMeasure"/>.
        /// </summary>
        public TextGeometry(ITextLayoutMeasure layoutMeasure)
        {
            _layoutMeasure = layoutMeasure;
        }

        /// <summary>
        /// Sets the width of the <see cref="TextGeometry"/> limited by the provided font height.
        /// </summary>
        /// <remarks>
        /// Useful for fitting the <see cref="TextGeometry"/> in a tight spot.
        /// </remarks>
        public void SetWidthWithHeightLimit(double width, double heightLimit)
        {
            // Set the width first.
            TextWidth = width;
            // If the height exceeds the limit ...
            if (FontHeight > heightLimit)
                // Set the height to the limit.
                FontHeight = heightLimit;
        }

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // All that is needed in the baseline to be translated.
            BaseLineLeft += to;
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        protected override CloneableObject CreateInstanceOverride()
        {
            return new TextGeometry(_layoutMeasure)
            {
                _fontFamily = _fontFamily,
                _fontStyle = _fontStyle,
                _fontWeight = _fontWeight,
                _fontDecoration = _fontDecoration,
                _fontHeight = _fontHeight,
                _content = _content,
                _baseLineLeft = _baseLineLeft,
                _rotation = _rotation,

            };
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
        {
            var hash = 17;
            hash = hash * 31 + FontFamily.GetHashCode();
            hash = hash * 31 + FontStyle.GetHashCode();
            hash = hash * 31 + FontWeight.GetHashCode();
            hash = hash * 31 + FontDecoration.GetHashCode();
            hash = hash * 31 + FontHeight.GetHashCode();
            hash = hash * 31 + Content.GetHashCode();
            hash = hash * 31 + BaseLineLeft.GetHashCode();
            hash = hash * 31 + Rotation.GetHashCode();
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is TextGeometry && Equals((TextGeometry)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is TextGeometry && Equals((TextGeometry)other);

        #region Implementation of IEquatable<TextGeometry>

        /// <summary>
        /// Determines whether the specified <see cref="TextGeometry"/> is equal to the current <see cref="TextGeometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="TextGeometry"/> is equal to the current <see cref="TextGeometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="TextGeometry"/> to compare with the current <see cref="TextGeometry"/>. </param>
        public bool Equals(TextGeometry other)
        {
            return other != null
                && FontFamily == other.FontFamily
                && FontStyle == other.FontStyle
                && FontWeight == other.FontWeight
                && FontDecoration == other.FontDecoration
                && FontHeight.Equals(other.FontHeight)
                && Content == other.Content
                && BaseLineLeft == other.BaseLineLeft
                && Rotation.Equals(other.Rotation);
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {

            var fontFamily = reader.GetAttribute(nameof(FontFamily));
            if (fontFamily != null)
                FontFamily = fontFamily;

            FontStyle fontStyle;
            if (Enum.TryParse(reader.GetAttribute(nameof(FontStyle)), out fontStyle))
                FontStyle = fontStyle;

            FontWeight fontWeight;
            if (Enum.TryParse(reader.GetAttribute(nameof(FontWeight)), out fontWeight))
                FontWeight = fontWeight;

            FontDecoration fontDecoration;
            if (Enum.TryParse(reader.GetAttribute(nameof(FontDecoration)), out fontDecoration))
                FontDecoration = fontDecoration;

            var fontHeight = reader.GetAttribute(nameof(FontHeight));
            if (fontHeight != null)
                FontHeight = double.Parse(fontHeight);

            var baseLineLeft = reader.GetAttribute(nameof(BaseLineLeft));
            if (baseLineLeft != null)
                BaseLineLeft = Point.Parse(baseLineLeft);

            var rotation = reader.GetAttribute(nameof(Rotation));
            if (rotation != null)
                Rotation = double.Parse(rotation);

            var content = reader.ReadElementContentAsString();
            if (content != null)
                Content = content;
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(FontFamily), FontFamily);
            writer.WriteAttributeString(nameof(FontStyle), FontStyle.ToString());
            writer.WriteAttributeString(nameof(FontWeight), FontWeight.ToString());
            writer.WriteAttributeString(nameof(FontDecoration), FontDecoration.ToString());
            writer.WriteAttributeString(nameof(FontHeight), FontHeight.ToString(InvariantCulture));
            writer.WriteAttributeString(nameof(BaseLineLeft), BaseLineLeft.ToString());
            writer.WriteAttributeString(nameof(Rotation), Rotation.ToString(InvariantCulture));

            writer.WriteValue(Content);
        }

        #endregion

    }
}
