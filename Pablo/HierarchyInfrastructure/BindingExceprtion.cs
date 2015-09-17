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
    public class BindingExceprtion : Exception
    {
        /// <summary>
        /// Gets the target object that failed at binding.
        /// </summary>
        public HierarchicalObject Target { get; }

        /// <summary>
        /// The faulty expression that failed to compile.
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BindingExceprtion"/>.
        /// </summary>
        internal BindingExceprtion(string message,
            Exception innerException,
            HierarchicalObject target,
            string expression)
            : base(message, innerException)
        {
            Target = target;
            Expression = expression;
        }
    }
}
