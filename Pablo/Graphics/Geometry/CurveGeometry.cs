/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static Pablo.Graphics.Vector;

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents the <see cref="Geometry"/> of a curve.
    /// </summary>
    public sealed class CurveGeometry : Geometry, IEquatable<CurveGeometry>, IXmlSerializable
    {
        /// <summary>
        /// The start <see cref="Point"/> of the <see cref="CurveGeometry"/>.
        /// </summary>
        private Point _start;

        /// <summary>
        /// The end <see cref="Point"/> of the <see cref="CurveGeometry"/>.
        /// </summary>
        private Point _end;

        /// <summary>
        /// The bulge of the <see cref="CurveGeometry"/>.
        /// </summary>
        private double _bulge;

        /// <summary>
        /// Gets or sets the start <see cref="Point"/> of the <see cref="CurveGeometry"/>.
        /// </summary>
        public Point Start
        {
            get { return _start; }
            set
            {
                ThrowOnReadOnly();
                _start = value;
            }
        }

        /// <summary>
        /// Gets or sets the end <see cref="Point"/> of the <see cref="CurveGeometry"/>.
        /// </summary>
        public Point End
        {
            get { return _end; }
            set
            {
                ThrowOnReadOnly();
                _end = value;
            }
        }

        /// <summary>
        /// Gets or sets the bulge of the <see cref="CurveGeometry"/>.
        /// </summary>
        /// <remarks>
        /// A positive bulge goes from <see cref="Start"/> to <see cref="End"/> counterclockwise.
        /// Whereas, a negative bulge goes clockwise.
        /// </remarks>
        public double Bulge
        {
            get { return _bulge; }
            set
            {
                ThrowOnReadOnly();
                _bulge = value;
            }
        }

        /// <summary>
        /// Gets the peak <see cref="Point"/> of the <see cref="CurveGeometry"/>.
        /// </summary>
        public Point Peak
        {
            get
            {
                // Get the midpoint between start and end.
                var midVector = Lerp(Start, End, 0.5);

                // The start to end vector.
                Vector startEnd = End - Start;

                // The unit perpendicular vector to the startEnd vector.
                var norm = Cross(startEnd, K).Unit;

                // Calculate the peak point.
                return (Point)(midVector + norm * Bulge * startEnd.Length / 2.0);
            }
        }

        /// <summary>
        /// Determines whether the <see cref="CurveGeometry"/> is closed.
        /// </summary>
        public override bool IsClosed { get; } = false;

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox => Box.Encompass(Start, End, Peak);

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // Should only translate the start and end points.
            Start += to;
            End += to;
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        /// <remarks>
        /// Since this object is sealed it is safe to override this here.
        /// </remarks>
        protected override CloneableObject CreateInstanceOverride()
            => new CurveGeometry { Bulge = Bulge, Start = Start, End = End };

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
        {
            var hash = 17;
            hash = hash * 31 + Start.GetHashCode();
            hash = hash * 31 + End.GetHashCode();
            hash = hash * 31 + Bulge.GetHashCode();
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is CurveGeometry && Equals((CurveGeometry)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is CurveGeometry && Equals((CurveGeometry)other);

        #region Implementation of IEquatable<CurveGeometry>

        /// <summary>
        /// Determines whether the specified <see cref="CurveGeometry"/> is equal to the current <see cref="CurveGeometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="CurveGeometry"/> is equal to the current <see cref="CurveGeometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="CurveGeometry"/> to compare with the current <see cref="CurveGeometry"/>. </param>
        public bool Equals(CurveGeometry other)
        {
            return other != null
                && Start == other.Start
                && End == other.End
                && Bulge.Equals(other.Bulge);
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var start = reader.GetAttribute(nameof(Start));
            if (start != null)
                Start = Point.Parse(start);

            var end = reader.GetAttribute(nameof(End));
            if (end != null)
                End = Point.Parse(end);

            var bulge = reader.GetAttribute(nameof(Bulge));
            if (bulge != null)
                Bulge = double.Parse(bulge);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Start), Start.ToString());
            writer.WriteAttributeString(nameof(End), End.ToString());
            writer.WriteAttributeString(nameof(Bulge), Bulge.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
