/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

namespace Pablo
{
    /// <summary>
    /// Specifies the position relative to the geometry space where the render position will reside.
    /// </summary>
    public enum OriginPointBehavior
    {
        /// <summary>
        /// This will place the render position at the origin of the geometry space.
        /// </summary>
        Zero,

        /// <summary>
        /// This will place the render position at the TopLeft of the geometry's bounding box.
        /// </summary>
        BoundingBoxTopLeft,

        /// <summary>
        /// This will place the render position at the TopCenter of the geometry's bounding box.
        /// </summary>
        BoundingBoxTopCenter,

        /// <summary>
        /// This will place the render position at the TopRight of the geometry's bounding box.
        /// </summary>
        BoundingBoxTopRight,

        /// <summary>
        /// This will place the render position at the BottomLeft of the geometry's bounding box.
        /// </summary>
        BoundingBoxBottomLeft,

        /// <summary>
        /// This will place the render position at the BottomCenter of the geometry's bounding box.
        /// </summary>
        BoundingBoxBottomCenter,

        /// <summary>
        /// This will place the render position at the BottomRight of the geometry's bounding box.
        /// </summary>
        BoundingBoxBottomRight,

        /// <summary>
        /// This will place the render position at the CenterLeft of the geometry's bounding box.
        /// </summary>
        BoundingBoxCenterLeft,

        /// <summary>
        /// This will place the render position at the CenterRight of the geometry's bounding box.
        /// </summary>
        BoundingBoxCenterRight,

        /// <summary>
        /// This will place the render position at the Center of the geometry's bounding box.
        /// </summary>
        BoundingBoxCenter,

        /// <summary>
        /// This will place the render position at the specified point within the geometry space.
        /// </summary>
        Absolute
    }
}
