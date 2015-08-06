using System;

namespace Pablo
{
    /// <summary>
    /// Represents an object that can be cloned.
    /// </summary>
    public abstract class CloneableObject : ICloneable
    {
        /// <summary>
        /// Makes a deep clone from this object.
        /// </summary>
        /// <remarks>
        /// Mostly meant for the <see cref="HierarchicalObject"/> to automate property cloning.
        /// Use this within your code with caution.
        /// </remarks>
        /// <exception cref="CloneException">Cloning failed</exception>
        public CloneableObject Clone()
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

        #region Implementation: ICloneable

        /// <summary>
        /// Clone this instance.
        /// </summary>
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

    }
}
