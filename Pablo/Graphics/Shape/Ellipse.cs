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
    /// Displays a ellipse described by an <see cref="EllipseGeometry"/>.
    /// </summary>
    public sealed class Ellipse : Shape<EllipseGeometry>
    {
        /// <summary>
        /// Gets the center point of the <see cref="Ellipse"/>.
        /// </summary>
        public Point Center => Geometry.Center;

        /// <summary>
        /// Gets the radius along the x axis of the <see cref="Ellipse"/>.
        /// </summary>
        public double RadiusX => Geometry.RadiusX;

        /// <summary>
        /// Gets the radius along the y axis of the <see cref="Ellipse"/>.
        /// </summary>
        public double RadiusY => Geometry.RadiusY;

        /// <summary>
        /// Initializes a new instance of <see cref="Ellipse"/>.
        /// </summary>
        public Ellipse() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Ellipse"/> with the provided center <see cref="Point"/> and radiuses.
        /// </summary>
        public Ellipse(Point center, double radiusX, double radiusY)
        {
            Geometry = new EllipseGeometry
            {
                RadiusX = radiusX,
                RadiusY = radiusY,
                Center = center,
                IsReadOnly = true,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Ellipse"/> with the provided center <see cref="Point"/> and
        /// one radius to form a circle.
        /// </summary>
        public Ellipse(Point center, double radius)
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
