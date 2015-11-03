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
    /// Base type for all the shapes with geometry.
    /// </summary>
    /// <typeparam name="TGeometry">The geometry type that describes this shape.</typeparam>
    public abstract class Shape<TGeometry> : Shape where TGeometry : Geometry, new()
    {

        /// <summary>
        /// Identifies the <see cref="Geometry"/> of the <see cref="Shape{TGeometry}"/>.
        /// </summary>
        public static readonly HierarchicalProperty GeometryProperty
            = RegisterProperty(typeof(Shape<TGeometry>), nameof(BackgroundBrush), typeof(TGeometry), 
                defaultFactory: () => EmptyGeometry<TGeometry>.Value);

        /// <summary>
        /// Gets or sets the <see cref="TGeometry"/> that describes the <see cref="Shape{TGeometry}"/>.
        /// </summary>
        public TGeometry Geometry
        {
            get { return (TGeometry)GetValue(GeometryProperty); }
            set { SetValue(GeometryProperty, value?.ImmutableClone()); }
        }

        /// <summary>
        /// Gets the bounding box of the <see cref="Shape"/>.
        /// </summary>
        public override Box BoundingBox => Geometry.BoundingBox;

        /// <summary>
        /// Gets the width of the <see cref="Shape"/>.
        /// </summary>
        public override double Width => BoundingBox.Width;

        /// <summary>
        /// Gets the height of the <see cref="Shape"/>.
        /// </summary>
        public override double Height => BoundingBox.Height;

        /// <summary>
        /// Determines whether the <see cref="Shape"/> is closed.
        /// </summary>
        public override bool IsClosed => Geometry.IsClosed;
        
    }
}
