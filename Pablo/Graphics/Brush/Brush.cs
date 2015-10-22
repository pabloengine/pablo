/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;

namespace Pablo.Graphics
{
    /// <summary>
    /// Provides the base class for all the brushes.
    /// </summary>
    public abstract class Brush : CloneableObject, IEquatable<Brush>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Brush"/>.
        /// </summary>
        internal Brush() { }

        #region Implementation of IEquatable<Brush>

        /// <summary>
        /// Determines whether the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="Brush"/> is equal to the current <see cref="Brush"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="Brush"/> to compare with the current <see cref="Brush"/>. </param>
        public abstract bool Equals(Brush other);

        #endregion
    }
}
