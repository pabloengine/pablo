/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

namespace Pablo.Graphics
{
    /// <summary>
    /// Base type for all the shapes.
    /// </summary>
    public abstract class Shape : VisualElement
    {
        /// <summary>
        /// Gets the bounding box of the <see cref="Shape"/>.
        /// </summary>
        public abstract Box BoundingBox { get; }

        /// <summary>
        /// Gets the width of the <see cref="Shape"/>.
        /// </summary>
        public abstract double Width { get; }

        /// <summary>
        /// Gets the height of the <see cref="Shape"/>.
        /// </summary>
        public abstract double Height { get; }

        /// <summary>
        /// Determines whether the <see cref="Shape"/> is closed.
        /// </summary>
        public abstract bool IsClosed { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Shape"/>.
        /// </summary>
        internal Shape() { }

    }
}
