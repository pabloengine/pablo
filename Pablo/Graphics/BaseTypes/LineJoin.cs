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
    /// Determines how lines should meet.
    /// </summary>
    public enum LineJoin
    {
        /// <summary>
        /// This produces a sharp corner.
        /// </summary>
        Miter,

        /// <summary>
        /// This produces a diagonal corner.
        /// </summary>
        Bevel,

        /// <summary>
        /// This produces a smooth, circular arc between the lines.
        /// </summary>
        Round
    }
}
