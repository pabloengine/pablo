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
    /// Displays a line described by a <see cref="LineGeometry"/>.
    /// </summary>
    public sealed class Line : Shape<LineGeometry>
    {
        /// <summary>
        /// Gets the start point of the <see cref="Line"/>.
        /// </summary>
        public Point Start => Geometry.Start;

        /// <summary>
        /// Gets the end point of the <see cref="Line"/>.
        /// </summary>
        public Point End => Geometry.End;

        /// <summary>
        /// Initializes a new instance of <see cref="Line"/>.
        /// </summary>
        public Line() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Line"/> with the provided start and end points.
        /// </summary>
        public Line(Point start, Point end)
        {
            Geometry = new LineGeometry
            {
                Start = start,
                End = end,
                IsReadOnly = true,
            };
        }

    }
}
