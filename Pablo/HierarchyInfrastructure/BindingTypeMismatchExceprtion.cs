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
    /// Represents an error that occured while applying data binding.
    /// </summary>
    public sealed class BindingTypeMismatchExceprtion : BindingExceprtion
    {
        /// <summary>
        /// The type of the evaluated expression.
        /// </summary>
        public Type EvaluationType { get; }

        /// <summary>
        /// The type of property that was expected.
        /// </summary>
        public Type PropertyType { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BindingExceprtion"/>.
        /// </summary>
        internal BindingTypeMismatchExceprtion(string message,
            Exception innerException,
            HierarchicalObject target,
            string expression, Type evaluationType, Type propertyType)
            : base(message, innerException, target, expression)
        {
            EvaluationType = evaluationType;
            PropertyType = propertyType;
        }
    }
}
