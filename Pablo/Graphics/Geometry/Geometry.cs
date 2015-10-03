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
    /// The base type of all geometries.
    /// </summary>
    public abstract class Geometry : CloneableObject, IEquatable<Geometry>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Geometry"/>.
        /// </summary>
        internal Geometry() { }

        /// <summary>
        /// Determines whether the <see cref="Geometry"/> is closed.
        /// </summary>
        public abstract bool IsClosed { get; }

        /// <summary>
        /// Gets the bounding <see cref="Box"/> in space.
        /// </summary>
        public abstract Box BoundingBox { get; }

        /// <summary>
        /// Translate the <see cref="Geometry"/> to the specified <see cref="Point"/>.
        /// </summary>
        public void Translate(Point to)
        {
            ThrowOnReadOnly();
            TranslateCore(to);
        }

        /// <summary>
        /// Must be implemented by all <see cref="Geometry"/> 
        /// subclasses to provide a mean of translation.
        /// </summary>
        /// <param name="to">The <see cref="Point"/> to translate to</param>
        protected abstract void TranslateCore(Point to);

        #region Implementation of IEquatable<Geometry>

        /// <summary>
        /// Determines whether the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Geometry"/> is equal to the current <see cref="Geometry"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Geometry"/> to compare with the current <see cref="Geometry"/>. </param>
        public abstract bool Equals(Geometry other);

        #endregion
    }
}
