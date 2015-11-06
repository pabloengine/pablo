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

namespace Pablo.Graphics
{
    /// <summary>
    /// Displays a block described by a <see cref="GeometryGroup"/>.
    /// </summary>
    public sealed class Block : Shape<GeometryGroup>
    {
        /// <summary>
        /// Gets the geometries describing this <see cref="Block"/>.
        /// </summary>
        public IEnumerable<Geometry> Geometries => Geometry.Geometries;

        /// <summary>
        /// Initializes a new instance of <see cref="Block"/>.
        /// </summary>
        public Block() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Block"/> with the provided geometries.
        /// </summary>
        /// <exception cref="ArgumentNullException">geometries is null</exception>
        public Block(IEnumerable<Geometry> geometries)
        {
            if (geometries == null)
                throw new ArgumentNullException(nameof(geometries));

            Geometry = new GeometryGroup
            {
                Geometries = geometries,
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Block"/> with the provided geometries.
        /// </summary>
        /// <exception cref="ArgumentNullException">geometries is null</exception>
        public Block(params Geometry[] geometries)
            : this(geometries.AsEnumerable())
        { }

    }
}
