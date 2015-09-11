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
    /// Represents an error that occutred during a cloning session.
    /// </summary>
    public sealed class CloneException : Exception
    {
        readonly CloneableObject _targetObject;

        /// <summary>
        /// The type of the target cloneable object.
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// The target clonable object that failed to be deeply cloned.
        /// </summary>
        public object TargetObject => _targetObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pablo.CloneException"/> class.
        /// </summary>
        internal CloneException(string message, Exception innerException, Type targetType, CloneableObject targetObject)
            : base(message, innerException)
        {
            TargetType = targetType;
            _targetObject = targetObject;
        }

    }
}
