/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pablo.Graphics
{
    /// <summary>
    /// Represents the <see cref="Geometry"/> of a polygon.
    /// </summary>
    public sealed class PolygonGeometry : Geometry, IEquatable<PolygonGeometry>, IXmlSerializable
    {
        /// <summary>
        /// The array of <see cref="Point"/>s in the <see cref="PolygonGeometry"/>.
        /// </summary>
        private Point[] _points = Array.Empty<Point>();

        /// <summary>
        /// Gets or sets the <see cref="Point"/>s in the <see cref="PolygonGeometry"/>.
        /// </summary>
        [XmlElement("Point")]
        public IEnumerable<Point> Points
        {
            get
            {
                // Wrap the array to keep if from being
                // mutated by the client code.
                return Array.AsReadOnly(_points);
            }
            set
            {
                ThrowOnReadOnly();
                _points = value?.ToArray() ?? Array.Empty<Point>();
            }
        }

        /// <summary>
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public override bool IsClosed { get; } = true;

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox => Box.Encompass(Points);

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // Translate every point in the array.
            for (var i = 0; i < _points.Length; i++)
                _points[i] += to;
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        /// <remarks>
        /// Since this object is sealed it is safe to override this here.
        /// </remarks>
        protected override CloneableObject CreateInstanceOverride()
            => new PolygonGeometry { _points = _points.ToArray() };


        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
            => Points.Aggregate(17, (current, point) => current * 31 + point.GetHashCode());

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is PolygonGeometry && Equals((PolygonGeometry)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is PolygonGeometry && Equals((PolygonGeometry)other);

        #region Implementation of IEquatable<PolygonGeometry>

        /// <summary>
        /// Determines whether the specified <see cref="PolygonGeometry"/> is equal to the current <see cref="PolygonGeometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="PolygonGeometry"/> is equal to the current <see cref="PolygonGeometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="PolygonGeometry"/> to compare with the current <see cref="PolygonGeometry"/>. </param>
        public bool Equals(PolygonGeometry other)
        {
            return other != null
                && _points.SequenceEqual(other._points);
        }

        #endregion

        #region Implementation of IXmlSerializable

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            var list = new List<Point>();

            // Read initial.
            reader.ReadToFollowing(nameof(Point));

            // Read while there are point elements.
            while (reader.Name == nameof(Point))
                list.Add(Point.Parse(reader.ReadElementContentAsString()));

            _points = list.ToArray();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var point in _points)
                writer.WriteElementString(nameof(Point), point.ToString());
        }

        #endregion
    }
}
