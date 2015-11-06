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
    /// Represents a shape.
    /// </summary>
    public interface IShape : IVisualElement
    {

        /// <summary>
        /// Gets the <see cref="Graphics.Geometry"/> of the <see cref="IShape"/>.
        /// </summary>
        Geometry Geometry { get; }

        /// <summary>
        /// Gets the bounding <see cref="Box"/> of the <see cref="IShape"/>.
        /// </summary>
        Box BoundingBox { get; }

        /// <summary>
        /// Gets the width of the <see cref="IShape"/>.
        /// </summary>
        double Width { get; }

        /// <summary>
        /// Gets the height of the <see cref="IShape"/>.
        /// </summary>
        double Height { get; }

        /// <summary>
        /// Determines whether the <see cref="IShape"/> is closed.
        /// </summary>
        bool IsClosed { get; }

    }
}
