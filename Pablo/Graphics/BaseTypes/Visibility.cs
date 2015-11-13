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
    /// Defines the visibility state of an element.
    /// </summary>
    public enum Visibility
    {
        /// <summary>
        /// The element is fully visible.
        /// </summary>
        Visible,

        /// <summary>
        /// The element is not visible and does not affect the layout.
        /// </summary>
        Collapsed,

        /// <summary>
        /// The element is not visible but reserves it's space in the layout.
        /// </summary>
        Hidden,
    }
}
