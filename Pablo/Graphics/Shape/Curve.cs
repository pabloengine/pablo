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
    /// Displays a curve described by a <see cref="CurveGeometry"/>.
    /// </summary>
    public sealed class Curve : Shape<CurveGeometry>
    {
        /// <summary>
        /// Gets the start point of the <see cref="Curve"/>.
        /// </summary>
        public Point Start => Geometry.Start;

        /// <summary>
        /// Gets the end point of the <see cref="Curve"/>.
        /// </summary>
        public Point End => Geometry.End;

        /// <summary>
        /// Gets the bulge of the <see cref="Curve"/>.
        /// </summary>
        public double Bulge => Geometry.Bulge;

        /// <summary>
        /// Initializes a new instance of <see cref="Curve"/>.
        /// </summary>
        public Curve() { }

        /// <summary>
        /// Initializes a new instance of <see cref="Curve"/> with the provided start, end and bulge.
        /// </summary>
        public Curve(Point start, Point end, double bulge)
        {
            Geometry = new CurveGeometry
            {
                Start = start,
                End = end,
                Bulge = bulge,
                IsReadOnly = true,
            };
        }

    }
}

