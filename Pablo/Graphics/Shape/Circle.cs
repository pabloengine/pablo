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
    /// Displays a circle described by an <see cref="EllipseGeometry"/>.
    /// </summary>
    public sealed class Circle : Shape<EllipseGeometry>
    {
        /// <summary>
        /// Gets the center point of the <see cref="Circle"/>.
        /// </summary>
        public Point Center => Geometry.Center;

        /// <summary>
        /// Gets the radius of the <see cref="Circle"/>.
        /// </summary>
        public double RadiusX => Geometry.RadiusX;

        /// <summary>
        /// Initializes a new instance of <see cref="Circle"/>.
        /// </summary>
        public Circle() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Circle"/> with the provided center <see cref="Point"/> and radius.
        /// </summary>
        public Circle(Point center, double radius)
        {
            Geometry = new EllipseGeometry
            {
                RadiusX = radius,
                RadiusY = radius,
                Center = center,
                IsReadOnly = true,
            };
        }

    }
}
