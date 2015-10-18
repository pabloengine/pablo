/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Xml.Serialization;

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
        [XmlIgnore]
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                ThrowOnReadOnly();
                _isReadOnly = value;
            }
        }

        /// <summary>
        /// This function should be used inside every mutator to ensure 
        /// the mutable invariant.
        /// </summary>
        protected void ThrowOnReadOnly()
        {
            if (_isReadOnly)
                throw new InvalidOperationException("Read only objects cannot be mutated.");
        }


        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <remarks>
        /// All children
        /// </remarks>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public sealed override int GetHashCode()
        {
            // Make sure no object is used inside a hashset 
            // unless it's immutable.
            if(!IsReadOnly)
                throw new InvalidOperationException($"{nameof(GetHashCode)} must be invoked on mutable objects.");

            return GetHashCodeOverride();
        }

        /// <summary>
        /// This function must be overriden instead of <see cref="GetHashCode"/>. 
        /// </summary>
        /// <remarks>
        /// <see cref="GetHashCode"/> must not be invoked on mutable objects.
        /// </remarks>
        protected virtual int GetHashCodeOverride() => base.GetHashCode();

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public sealed override bool Equals(object obj) => ReferenceEquals(this, obj) || EqualsOverride(obj);

        /// <summary>
        /// This function must be overriden instead of <see cref="Equals"/>. 
        /// </summary>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        protected virtual bool EqualsOverride(object obj) => ReferenceEquals(this, obj);

        /// <summary>
        /// Returns a deep, mutable clone of this object.
        /// </summary>
        /// <remarks>
        /// <para>This function will return a clone even if it is read only.</para>
        /// <para>This function will call CreateInstanceOverride to get a new instance.</para>
        /// <para>This function will call CloneOverride to update properties.</para>
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject MutableClone() => CloneImpl();

        /// <summary>
        /// Returns a deep, immutable clone of this object.
        /// </summary>
        /// <remarks>
        /// <para>This function will return itself as the clone if it is read only.</para>
        /// <para>This function will call CreateInstanceOverride to get a new instance.</para>
        /// <para>This function will call CloneOverride to update properties.</para>
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject ImmutableClone()
        {
            // Return itself if it's already read only.
            if (IsReadOnly)
                return this;

            // Otherwise make a clone...
            var clone = CloneImpl();
            
            // Make it immutable...
            clone.IsReadOnly = true;

            // And return the clone.
            return clone;
        }
        
        /// <summary>
        /// Returns a deep clone of this object.
        /// </summary>
        /// <remarks>
        /// <para>This function will return this instance if it is read only.</para>
        /// <para>This function will call CreateInstanceOverride to get a new instance if not read only.</para>
        /// <para>This function will call CloneOverride to update properties if not read only.</para>
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject Clone()
        {
            // Immutable objects may be shared safely.
            return _isReadOnly ? this : CloneImpl();
        }

        /// <summary>
        /// General cloning implementation method.
        /// </summary>
        /// <exception cref="CloneException">Cloning failed</exception>
        private CloneableObject CloneImpl()
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
            => (CloneableObject)Activator.CreateInstance(GetType());

        /// <summary>
        /// Implement semantics that cannot be specified while creating an instance of the object.
        /// </summary>
        /// <remarks>
        /// This function is not called when cloning read only objects.
        /// </remarks>
        protected virtual void CloneOverride(CloneableObject clone)
        { }

        #region Implementation of ICloneable

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <remarks>
        /// Explicit implmenetation of ICloneable to make the API play nice with others.
        /// </remarks>
        object ICloneable.Clone() => Clone();

        #endregion

    }
}
