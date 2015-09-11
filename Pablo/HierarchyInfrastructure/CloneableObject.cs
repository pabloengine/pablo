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
    /// Represents an object that can be cloned.
    /// </summary>
    public abstract class CloneableObject : ICloneable
    {
        bool _isReadOnly;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <remarks>
        /// Once set it cannot be undone.
        /// Setting this property causes the clone method to return a shallow
        /// copy instead.
        /// </remarks>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (_isReadOnly)
                    throw new InvalidOperationException("Read only objects cannot be mutated.");
                _isReadOnly = value;
            }
        }

        /// <summary>
        /// Returns a deep, mutable clone of this object.
        /// </summary>
        /// <remarks>
        /// This function will return a clone even if it is read only.
        /// This function will call CreateInstanceOverride to get a new instance.
        /// This function will call CloneOverride to update properties.
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject MutableClone()
        {
            return CloneImp();
        }

        /// <summary>
        /// Returns a deep clone of this object.
        /// </summary>
        /// <remarks>
        /// This function will return this instance if it is read only.
        /// This function will call CreateInstanceOverride to get a new instance.
        /// This function will call CloneOverride to update properties.
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject Clone()
        {
            // Immutable objects may be shared safely.
            return _isReadOnly ? this : CloneImp();
        }

        /// <summary>
        /// Implementation of <see cref="Clone"/> method.
        /// </summary>
        /// <exception cref="CloneException">Cloning failed</exception>
        CloneableObject CloneImp()
        {
            CloneableObject instance;

            try
            {
                // Try to create a new instance of the current type.
                instance = CreateInstanceOverride();
            }
            catch (Exception e)
            {
                // An unexpected Exception happend while trying to activate.
                throw new CloneException("Could not create a clone instance from target object.", e, GetType(), this);
            }

            // Check to make sure the instantiated object is of the correct type. 
            if (GetType() != instance.GetType())
                throw new CloneException("The cloned instance's type does not match the target object's type", null, GetType(), this);
            try
            {
                // Run the CloneOverride on the instance.
                CloneOverride(instance);
            }
            catch (Exception e)
            {
                // CloneOverride threw an Exception.
                throw new CloneException("Clone override function throw an exception.", e, GetType(), this);
            }

            return instance;
        }

        /// <summary>
        /// Create instance of the current type. Override when a default constructor is not present.
        /// </summary>
        protected virtual CloneableObject CreateInstanceOverride()
        {
            return (CloneableObject)Activator.CreateInstance(GetType());
        }

        /// <summary>
        /// Implement semantics that cannot be specified while creating an instance of the object.
        /// </summary>
        protected virtual void CloneOverride(CloneableObject clonableObject)
        {
        }

        #region Implementation of ICloneable

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <remarks>
        /// Explicit implmenetation of ICloneable to make the API play nice with others.
        /// </remarks>
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

    }
}
