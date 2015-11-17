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
    /// Defines the behavior of <see cref="Dimension"/>.
    /// </summary>
    public enum DimensionBehavior
    {
        /// <summary>
        /// Shrink to minimum possible value.
        /// </summary>
        Shrink,

        /// <summary>
        /// Stretch to maximum possible value.
        /// </summary>
        Stretch,

        /// <summary>
        /// Measure relative to siblings.
        /// </summary>
        Relative,

        /// <summary>
        /// Measure proportional to maximum possible value, 
        /// </summary>
        Proportional,

        /// <summary>
        /// Statically measure the dimension.
        /// </summary>
        Static,
    }
}
