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
    /// Paints a shape with a solid color.
    /// </summary>
    public sealed class SolidColorBrush : Brush, IEquatable<SolidColorBrush>, IXmlSerializable
    {
        /// <summary>
        /// The <see cref="Graphics.Color"/> of <see cref="SolidColorBrush"/>.
        /// </summary>
        private Color _color;

        /// <summary>
        /// Gets the <see cref="Graphics.Color"/> of <see cref="SolidColorBrush"/>.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                ThrowOnReadOnly();
                _color = value;
            }
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        /// <remarks>
        /// Since this object is sealed it is safe to override this here.
        /// </remarks>
        protected override CloneableObject CreateInstanceOverride()
            => new SolidColorBrush { Color = Color };

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
        {
            var hash = 17;
            hash = hash * 31 + Color.GetHashCode();
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is SolidColorBrush && Equals((SolidColorBrush)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Brush"/> to compare with the current <see cref="Brush"/>. </param>
        public override bool Equals(Brush other) => other is SolidColorBrush && Equals((SolidColorBrush)other);

        #region Implementation of IEquatable<SolidColorBrush>

        /// <summary>
        /// Determines whether the specified <see cref="SolidColorBrush"/> is equal to the current <see cref="SolidColorBrush"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="SolidColorBrush"/> is equal to the current <see cref="SolidColorBrush"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="SolidColorBrush"/> to compare with the current <see cref="SolidColorBrush"/>. </param>
        public bool Equals(SolidColorBrush other)
        {
            return other != null
                && Color == other.Color;
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var color = reader.GetAttribute(nameof(Color));
            if (color != null)
                Color = Color.Parse(color);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Color), Color.ToString());
        }

        #endregion
    }
}
