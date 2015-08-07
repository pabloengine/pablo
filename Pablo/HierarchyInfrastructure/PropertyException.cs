/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;

namespace Pablo
{
    /// <summary>
    /// Represents an error that occured during the execution of 
    /// HierarchicalProperty extended functionalities.
    /// </summary>
    public sealed class PropertyException : Exception
    {
        readonly HierarchicalProperty _targetProperty;

        /// <summary>
        /// The faulted property.
        /// </summary>
        public HierarchicalProperty TargetProperty
        {
            get { return _targetProperty; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pablo.PropertyException"/> class.
        /// </summary>
        internal PropertyException(string message, Exception innerException, HierarchicalProperty targetProperty)
            : base(message, innerException)
        {
            _targetProperty = targetProperty;
        }

    }
}
