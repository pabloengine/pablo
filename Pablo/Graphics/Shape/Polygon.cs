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
    /// Displays a closed polygon described by a <see cref="PolygonGeometry"/>.
    /// </summary>
    public sealed class Polygon : Shape<PolygonGeometry>
    {
        /// <summary>
        /// Gets the <see cref="Point"/>s that describe this <see cref="Polygon"/>.
        /// </summary>
        public IEnumerable<Point> Points => Geometry.Points;

        /// <summary>
        /// Initializes a new instance of <see cref="Polygon"/>.
        /// </summary>
        public Polygon() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Polygon"/> with the provided <see cref="Point"/>s.
        /// </summary>
        /// <exception cref="ArgumentNullException">points is null</exception>
        public Polygon(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            Geometry = new PolygonGeometry
            {
                Points = points,
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Polygon"/> with the provided <see cref="Point"/>s.
        /// </summary>
        /// <exception cref="ArgumentNullException">points is null</exception>
        public Polygon(params Point[] points)
            : this(points.AsEnumerable())
        { }

    }
}
