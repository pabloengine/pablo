/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pablo.Graphics
{
    /// <summary>
    /// Paints a shape with a striped pattern.
    /// </summary>
    public sealed class StripePatternBrush : Brush, IEquatable<StripePatternBrush>, IXmlSerializable
    {
        /// <summary>
        /// The <see cref="Stripe"/>s of the <see cref="StripePatternBrush"/>.
        /// </summary>
        private Stripe[] _stripes = Array.Empty<Stripe>();

        /// <summary>
        /// The background <see cref="Color"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        private Color _backgroundColor;

        /// <summary>
        /// The stripe <see cref="Color"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        private Color _stripeColor;

        /// <summary>
        /// The origin <see cref="Point"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        private Point _origin;

        /// <summary>
        /// The scale of the <see cref="StripePatternBrush"/>.
        /// </summary>
        private double _scale = 1;

        /// <summary>
        /// Gets or sets the <see cref="Stripe"/>s of the <see cref="StripePatternBrush"/>.
        /// </summary>
        public IEnumerable<Stripe> Stripes
        {
            get { return Array.AsReadOnly(_stripes); }
            set
            {
                ThrowOnReadOnly();

                // Make a new array from the provided stripes to prevent future immutibility violation.
                _stripes = value?.ToArray() ?? Array.Empty<Stripe>();
            }
        }

        /// <summary>
        /// Gets or sets the background <see cref="Color"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                ThrowOnReadOnly();
                _backgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the stripe <see cref="Color"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        public Color StripeColor
        {
            get { return _stripeColor; }
            set
            {

                ThrowOnReadOnly();
                _stripeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the origin <see cref="Point"/> of the <see cref="StripePatternBrush"/>.
        /// </summary>
        public Point Origin
        {
            get { return _origin; }
            set
            {
                ThrowOnReadOnly();
                _origin = value;
            }
        }

        /// <summary>
        /// Gets or sets the scale of the <see cref="StripePatternBrush"/>.
        /// </summary>
        public double Scale
        {
            get { return _scale; }
            set
            {
                ThrowOnReadOnly();
                _scale = value;
            }
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        /// <remarks>
        /// Since this object is sealed it is safe to override this here.
        /// </remarks>
        protected override CloneableObject CreateInstanceOverride()
            => new StripePatternBrush
            {
                Stripes = _stripes,
                BackgroundColor = _backgroundColor,
                StripeColor = _stripeColor,
                Origin = _origin,
                Scale = _scale,
            };

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="CloneableObject.GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected override int GetHashCodeOverride()
        {
            var hash = _stripes.Aggregate(17, (current, stripe) => current * 31 + stripe.GetHashCode());
            hash = hash * 31 + BackgroundColor.GetHashCode();
            hash = hash * 31 + StripeColor.GetHashCode();
            hash = hash * 31 + Origin.GetHashCode();
            hash = hash * 31 + Scale.GetHashCode();
            return hash;
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="CloneableObject.Equals(object)"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected override bool EqualsOverride(object obj) => obj is StripePatternBrush && Equals((StripePatternBrush)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Brush"/> to compare with the current <see cref="Brush"/>. </param>
        public override bool Equals(Brush other) => other is StripePatternBrush && Equals((StripePatternBrush)other);

        #region Implementation of IEquatable<SolidColorBrush>

        /// <summary>
        /// Determines whether the specified <see cref="StripePatternBrush"/> is equal to the current <see cref="StripePatternBrush"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="StripePatternBrush"/> is equal to the current <see cref="StripePatternBrush"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="StripePatternBrush"/> to compare with the current <see cref="StripePatternBrush"/>. </param>
        public bool Equals(StripePatternBrush other)
        {
            return other != null
                && BackgroundColor == other.BackgroundColor
                && StripeColor == other.StripeColor
                && Origin == other.Origin
                && Scale.Equals(other.Scale)
                && _stripes.SequenceEqual(other._stripes);
        }

        #endregion

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var backgroundColor = reader.GetAttribute(nameof(BackgroundColor));
            if (backgroundColor != null)
                BackgroundColor = Color.Parse(backgroundColor);

            var stripeColor = reader.GetAttribute(nameof(StripeColor));
            if (stripeColor != null)
                StripeColor = Color.Parse(stripeColor);

            var origin = reader.GetAttribute(nameof(Origin));
            if (origin != null)
                Origin = Point.Parse(origin);

            var scale = reader.GetAttribute(nameof(Scale));
            if (scale != null)
                Scale = double.Parse(scale);


            var list = new List<Stripe>();

            // Read initial.
            reader.ReadToFollowing(nameof(Stripe));

            // Read while there are stripe elements.
            while (reader.Name == nameof(Stripe))
                list.Add(Stripe.Parse(reader.ReadElementContentAsString()));

            _stripes = list.ToArray();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(BackgroundColor), BackgroundColor.ToString());
            writer.WriteAttributeString(nameof(StripeColor), StripeColor.ToString());
            writer.WriteAttributeString(nameof(Origin), Origin.ToString());
            writer.WriteAttributeString(nameof(Scale), Scale.ToString(CultureInfo.InvariantCulture));

            foreach (var stripe in _stripes)
                writer.WriteElementString(nameof(Stripe), stripe.ToString());
        }

        #endregion
    }
}
