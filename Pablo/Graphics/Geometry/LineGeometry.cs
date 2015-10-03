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

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents the <see cref="Geometry"/> of a line.
    /// </summary>
    public sealed class LineGeometry : Geometry, IEquatable<LineGeometry>, IXmlSerializable
    {
        /// <summary>
        /// The start <see cref="Point"/> of the <see cref="LineGeometry"/>.
        /// </summary>
        private Point _start;

        /// <summary>
        /// The end <see cref="Point"/> of the <see cref="LineGeometry"/>.
        /// </summary>
        private Point _end;

        /// <summary>
        /// Gets or sets the start <see cref="Point"/> of the <see cref="LineGeometry"/>.
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
        /// Gets or sets the end <see cref="Point"/> of the <see cref="LineGeometry"/>.
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
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public override bool IsClosed { get; } = false;

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox
            => Box.Encompass(Start, End);

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // Both start and end points must be translated.
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
            => new LineGeometry { Start = Start, End = End };

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
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is LineGeometry && Equals((LineGeometry)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is LineGeometry && Equals((LineGeometry)other);

        #region Implementation of IEquatable<LineGeometry>

        /// <summary>
        /// Determines whether the specified <see cref="LineGeometry"/> is equal to the current <see cref="LineGeometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="LineGeometry"/> is equal to the current <see cref="LineGeometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="LineGeometry"/> to compare with the current <see cref="LineGeometry"/>. </param>
        public bool Equals(LineGeometry other)
        {
            return other != null
                && Start == other.Start
                && End == other.End;
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
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Start), Start.ToString());
            writer.WriteAttributeString(nameof(End), End.ToString());
        }

        #endregion

    }
}
