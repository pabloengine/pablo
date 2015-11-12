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
    /// Displays a closed polyline described by a <see cref="PolylineGeometry"/>.
    /// </summary>
    public sealed class Polyline : Shape<PolylineGeometry>
    {
        /// <summary>
        /// Gets the <see cref="Point"/>s that describe this <see cref="Polyline"/>.
        /// </summary>
        public IEnumerable<Point> Points => Geometry.Points;

        /// <summary>
        /// Initializes a new instance of <see cref="Polyline"/>.
        /// </summary>
        public Polyline() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Polyline"/> with the provided <see cref="Point"/>s.
        /// </summary>
        /// <exception cref="ArgumentNullException">points is null</exception>
        public Polyline(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            Geometry = new PolylineGeometry
            {
                Points = points,
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Polyline"/> with the provided <see cref="Point"/>s.
        /// </summary>
        /// <exception cref="ArgumentNullException">points is null</exception>
        public Polyline(params Point[] points)
            : this(points.AsEnumerable())
        { }

    }
}
