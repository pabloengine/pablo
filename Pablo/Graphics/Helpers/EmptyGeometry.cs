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
    /// Represents an empty <see cref="Geometry"/> object.
    /// </summary>
    internal static class EmptyGeometry<TGeometry> where TGeometry : Geometry, new()
    {
        /// <summary>
        /// The empty <see cref="Geometry"/> value.
        /// </summary>
        /// <remarks>
        /// This is a singleton, readonly object. 
        /// </remarks>
        public static readonly TGeometry Value = new TGeometry { IsReadOnly = true };
    }
}
