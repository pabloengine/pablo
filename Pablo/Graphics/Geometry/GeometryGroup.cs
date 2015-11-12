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
    /// Represents a group of geometries.
    /// </summary>
    public sealed class GeometryGroup : Geometry, IEquatable<GeometryGroup>, IXmlSerializable
    {
        /// <summary>
        /// The <see cref="Geometry"/> array of the <see cref="GeometryGroup"/>.
        /// </summary>
        private Geometry[] _geometries = Array.Empty<Geometry>();

        /// <summary>
        /// Gets or sets the <see cref="Geometry"/> array of the <see cref="GeometryGroup"/>.
        /// </summary>
        public IEnumerable<Geometry> Geometries
        {
            get
            {
                // Wrap the array to keep if from being
                // mutated by the client code.
                return Array.AsReadOnly(_geometries);
            }
            set
            {
                ThrowOnReadOnly();
                
                // Make an array from locked clones of provided geometries to prevent future immutibility violation.
                _geometries = value?.Select(g => (Geometry)g.ImmutableClone()).ToArray() ?? Array.Empty<Geometry>();
            }
        }

        /// <summary>
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public override bool IsClosed
        {
            get
            {
                if (_geometries.Length == 0)
                    return false;

                // IsClosed is mostly used for filling the shape.
                // Makes a cleaner API if it is known whether a geometry
                // has any parts that can be filled.
                return _geometries.Any(g => g.IsClosed);
            }
        }

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public override Box BoundingBox
        {
            get
            {
                if (_geometries.Length == 0)
                    return new Box();

                // Cache bounding box calculation results
                var boundingBoxes = _geometries.Select(g => g.BoundingBox).ToArray();

                return new Box(
                    boundingBoxes.Select(b => b.Left).Min(),
                    boundingBoxes.Select(b => b.Top).Max(),
                    boundingBoxes.Select(b => b.Right).Max(),
                    boundingBoxes.Select(b => b.Bottom).Min());
            }
        }

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected override void TranslateCore(Point to)
        {
            // Must translate every geometry in the array.
            foreach (var geometry in _geometries)
                geometry.Translate(to);
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        protected override CloneableObject CreateInstanceOverride()
        {
            // Defensively copy the geometries.
            return new GeometryGroup { _geometries = _geometries.Select(g => (Geometry)g.ImmutableClone()).ToArray() };
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
            => Geometries.Aggregate(17, (current, geometry) => current * 31 + geometry.GetHashCode());


        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is GeometryGroup && Equals((GeometryGroup)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public override bool Equals(Geometry other) => other is GeometryGroup && Equals((GeometryGroup)other);

        #region Implementation of IEquatable<GeometryGroup>

        /// <summary>
        /// Determines whether the specified <see cref="GeometryGroup"/> is equal to the current <see cref="GeometryGroup"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="GeometryGroup"/> is equal to the current <see cref="GeometryGroup"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="GeometryGroup"/> to compare with the current <see cref="GeometryGroup"/>. </param>
        public bool Equals(GeometryGroup other)
        {
            return other != null
                && _geometries.SequenceEqual(other._geometries);
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var list = new List<Geometry>();

            // Get to first element.
            reader.Read();
            
            // Read while there are geometry elements.
            while (reader.NodeType == XmlNodeType.Element)
            {
                // Qualify the name to match this namespace and type.
                var type = Type.GetType($"{GetType().Namespace}.{reader.Name}");

                // Make sure the type exists!
                if(type == null)
                    throw new XmlException($"{reader.Name} is not a recognized {nameof(Geometry)} object.");

                // Activate the type.
                var geometry = (Geometry)Activator.CreateInstance(type);
                
                // Populate the instance with properties from the xml.
                ((IXmlSerializable)geometry).ReadXml(reader);
                
                // Add the result to the list.
                list.Add(geometry);

                // Move to the next element.
                reader.Read();
            }

            _geometries = list.ToArray();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (var geometry in _geometries)
            {
                // Write start element with the name of the geometry type.
                writer.WriteStartElement(geometry.GetType().Name);
                
                // Copy the properties.
                ((IXmlSerializable)geometry).WriteXml(writer);

                // Write the end element.
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
