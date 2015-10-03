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
    /// Represents the <see cref="Geometry"/> of an ellipse.
    /// </summary>
    public sealed class EllipseGeometry : Geometry, IEquatable<EllipseGeometry>, IXmlSerializable
    {
        /// <summary>
        /// The center <see cref="Point"/> of the <see cref="EllipseGeometry"/>.
        /// </summary>
        private Point _center;

        /// <summary>
        /// The x radius of the <see cref="EllipseGeometry"/>.
        /// </summary>
        private double _radiusX;

        /// <summary>
        /// The y radius of the <see cref="EllipseGeometry"/>.
        /// </summary>
        private double _radiusY;

        /// <summary>
        /// Gets or sets the center <see cref="Point"/> of the <see cref="EllipseGeometry"/>.
        /// </summary>
        public Point Center
        {
            get { return _center; }
            set
            {
                ThrowOnReadOnly();
                _center = value;
            }
        }

        /// <summary>
        /// Gets or sets the x radius of the <see cref="EllipseGeometry"/>.
        /// </summary>
        public double RadiusX
        {
            get { return _radiusX; }
            set
            {
                ThrowOnReadOnly();
                _radiusX = value;
            }
        }

        /// <summary>
        /// Gets or sets the y radius of the <see cref="EllipseGeometry"/>.
        /// </summary>
        public double RadiusY
        {
            get { return _radiusY; }
            set
            {
                ThrowOnReadOnly();
                _radiusY = value;
            }
        }

        /// <summary>
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public override bool IsClosed { get; } = true;

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox
            => new Box(
                    Center.X - RadiusX,
                    Center.Y + RadiusY,
                    Center.X + RadiusX,
                    Center.Y - RadiusY
                );

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // Should only translate the center point.
            Center += to;
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        /// <remarks>
        /// Since this object is sealed it is safe to override this here.
        /// </remarks>
        protected override CloneableObject CreateInstanceOverride()
            => new EllipseGeometry { Center = Center, RadiusX = RadiusX, RadiusY = RadiusY };

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
        {
            var hash = 17;
            hash = hash * 31 + Center.GetHashCode();
            hash = hash * 31 + RadiusX.GetHashCode();
            hash = hash * 31 + RadiusY.GetHashCode();
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is EllipseGeometry && Equals((EllipseGeometry)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is EllipseGeometry && Equals((EllipseGeometry)other);

        #region Implementation of IEquatable<EllipseGeometry>

        /// <summary>
        /// Determines whether the specified <see cref="EllipseGeometry"/> is equal to the current <see cref="EllipseGeometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="EllipseGeometry"/> is equal to the current <see cref="EllipseGeometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="EllipseGeometry"/> to compare with the current <see cref="EllipseGeometry"/>. </param>
        public bool Equals(EllipseGeometry other)
        {
            return other != null
                && Center == other.Center
                && RadiusX.Equals(other.RadiusX)
                && RadiusY.Equals(other.RadiusY);
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var center = reader.GetAttribute(nameof(Center));
            if (center != null)
                Center = Point.Parse(center);

            var radiusX = reader.GetAttribute(nameof(RadiusX));
            if (radiusX != null)
                RadiusX = double.Parse(radiusX);

            var radiusY = reader.GetAttribute(nameof(RadiusY));
            if (radiusY != null)
                RadiusY = double.Parse(radiusY);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Center), Center.ToString());
            writer.WriteAttributeString(nameof(RadiusX), RadiusX.ToString(InvariantCulture));
            writer.WriteAttributeString(nameof(RadiusY), RadiusY.ToString(InvariantCulture));
        }

        #endregion

    }
}
