/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System.Collections.Generic;
using System.Linq;

namespace Pablo.Graphics
{
    /// <summary>
    /// Displays a rectangle described by a <see cref="PolygonGeometry"/>.
    /// </summary>
    public class Rectangle : Shape<PolygonGeometry>
    {

        /// <summary>
        /// Gets the <see cref="Point"/>s that describe this <see cref="Rectangle"/>.
        /// </summary>
        public IEnumerable<Point> Points => Geometry.Points;

        /// <summary>
        /// Initialized a new instance of <see cref="Rectangle"/>.
        /// </summary>
        public Rectangle()
        {
            Geometry = new PolygonGeometry
            {
                Points = Enumerable.Repeat(new Point(), 4),
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initialized a new instance of <see cref="Rectangle"/> from the provided <see cref="Box"/>.
        /// </summary>
        public Rectangle(Box box)
        {
            Geometry = new PolygonGeometry
            {
                Points = box.Points,
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initialized a new instance of <see cref="Rectangle"/> from the provided sides.
        /// </summary>
        public Rectangle(double left, double top, double right, double bottom)
            : this(new Box(left, top, right, bottom))
        { }

    }
}
