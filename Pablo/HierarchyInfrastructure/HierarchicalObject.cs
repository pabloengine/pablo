/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;

namespace Pablo
{
    /// <summary>
    /// Represents an object with managed properties.
    /// </summary>
    public abstract class HierarchicalObject : CloneableObject
    {
        /// <summary>
        /// A mapping from types to their registered properties.
        /// </summary>
        static readonly Dictionary<Type, Dictionary<string, HierarchicalProperty>> RegisteredProperties;

        /// <summary>
        /// A mapping from properties of of this object to it's own values.
        /// </summary>
        readonly Dictionary<HierarchicalProperty, object> _ownValues;

        /// <summary>
        /// The hierarchy parent.
        /// </summary>
        HierarchicalObject _hierarchyParent;

        /// <summary>
        /// Gets or sets the hierarchy parent.
        /// </summary>
        /// <value>The hierarchy parent.</value>
        /// <exception cref="T:System.InvalidOperationException">object is read only</exception>
        public HierarchicalObject HierarchyParent
        {
            get
            {
                return _hierarchyParent;
            }
            set
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("Read only objects cannot be mutated.");
                
                _hierarchyParent = value;
            }
        }

        /// <summary>
        /// Gets the root of the tree.
        /// </summary>
        /// <remarks>
        /// If queried from a root object the object itself is returned.
        /// </remarks>
        public HierarchicalObject HierarchyRoot
        {
            get
            {
                // Crawl up the tree to reach the root.
                var current = this;
                while (current.HierarchyParent != null)
                    current = current.HierarchyParent;
                return current;
            }
        }

        /// <summary>
        /// Initializes the <see cref="Pablo.HierarchicalObject"/> class.
        /// </summary>
        static HierarchicalObject()
        {
            RegisteredProperties = new Dictionary<Type, Dictionary<string, HierarchicalProperty>>();
        }

        /// <summary>
        /// initialize a new instance of HierarchicalObject.
        /// </summary>
        protected HierarchicalObject()
        {
            _ownValues = new Dictionary<HierarchicalProperty, object>();
        }

        /// <summary>
        /// Register a new managed property.
        /// </summary>
        /// <returns>The representative for the property.</returns>
        /// <param name="owner">The type that owns this property</param>
        /// <param name="name">Name of the property (preferably same as it's CLR wrapper)</param>
        /// <param name="type">The type of this property</param>
        /// <param name="isInheritable">Whether the property can be inherited from the parent</param>
        /// <param name="parser">
        /// The function used to parse the string representation of this peoperty
        /// (not needed for primitives, enums, string, <see cref="DateTime"/>, 
        /// <see cref="DateTimeOffset"/> and their nullable forms)
        /// </param>
        /// <param name="defaultFactory">
        /// The function used to produce the default value of this property (optional)
        /// </param>
        /// <param name="cloner">
        /// The function used to clone the peoperty with
        /// (not needed for <see cref="ICloneable"/>s, strings, enums, all value types and their nullable forms)
        /// </param>
        /// <exception cref="ArgumentNullException">either owner, name or type is null</exception>
        /// <exception cref="T:System.ArgumentException">name is whitespace or already registered</exception>
        protected static HierarchicalProperty RegisterProperty(
            Type owner,
            string name,
            Type type,
            bool isInheritable = false,
            Func<string, object> parser = null,
            Func<object> defaultFactory = null,
            Func<object, object> cloner = null)
        {
            // Check for nulls.
            if (owner == null)
                throw new ArgumentNullException("owner");
            if (name == null)
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");

            // Make sure the name is valid.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name must have value. null or whitespace is not acceptable.", "name");

            // Add a mapping for the owner if it does not already exist.
            if (!RegisteredProperties.ContainsKey(owner))
                RegisteredProperties.Add(owner, new Dictionary<string, HierarchicalProperty>());

            // Make sure the name is not already registered.
            if (RegisteredProperties[owner].ContainsKey(name))
                throw new ArgumentException("A property with the same name as the name provided is already registered.", "name");

            // Create a new instance of HierarchicalProperty for this property.
            var hierarchicalProperty = new HierarchicalProperty(owner, name, type, isInheritable, parser, defaultFactory, cloner);
            // Add the property to its owner's list of properties.
            RegisteredProperties[owner].Add(name, hierarchicalProperty);
            // Expose the instance to client code.
            return hierarchicalProperty;
        }

        /// <summary>
        /// Returns a registered property for the owner type or its base type by name.
        /// </summary>
        /// <returns>
        /// the property or null if the name is not registered in the class hierarchy
        /// </returns>
        /// <exception cref="ArgumentNullException">owner is null</exception>
        public static HierarchicalProperty GetProperty(Type owner, string propertyName)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            // Crawl up the class heirarchy to find a base class owning the property.
            var currentType = owner;
            while (true)
            {
                // The current type has the property
                if (RegisteredProperties.ContainsKey(currentType) && RegisteredProperties[currentType].ContainsKey(propertyName))
                    return RegisteredProperties[currentType][propertyName];
                // If no base type exists or there can be no property owner types in the class hierarchy break and return null.
                if (currentType.BaseType == null || !currentType.BaseType.IsSubclassOf(typeof(HierarchicalObject)))
                    break;
                // Target the base type of current type.
                currentType = currentType.BaseType;
            }
            return null;
        }


        /// <summary>
        /// Indicates whether this object has its own value of the provided property.
        /// </summary>
        /// <exception cref="ArgumentNullException">property is null</exception>
        public bool HasOwnValue(HierarchicalProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            return _ownValues.ContainsKey(property);
        }

        /// <summary>
        /// Indicates whether this object or any ancestors has a value of the provided property.
        /// </summary>
        /// <exception cref="ArgumentNullException">property is null</exception>
        public bool HasValue(HierarchicalProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            // This object itself has the value.
            return HasOwnValue(property)
            // Otherwise, crawl up the tree if the property is inheritable...          
            || (property.IsInheritable
            // And has a parent.
            && HierarchyParent != null
            // Recursively check the parent to determine whether
            // a value can be found in the hierarchy.
            && HierarchyParent.HasValue(property));
        }

        /// <summary>
        /// Get the value for the provided property.
        /// Returns the property's default if none exist.
        /// </summary>
        /// <exception cref="ArgumentNullException">property is null</exception>
        public object GetValue(HierarchicalProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            // This object itself has the value.
            if (HasOwnValue(property))
                return _ownValues[property];
            // Return the property's default value if inheritance 
            // is not allowed or there are no parents.
            if (!property.IsInheritable || HierarchyParent == null)
                return property.Default;
            // Recursively query the parent for the value.
            return HierarchyParent.GetValue(property);
        }

        /// <summary>
        /// Set the property to this object as its own.
        /// </summary>
        /// <exception cref="ArgumentNullException">property is null</exception>
        /// <exception cref="T:System.InvalidOperationException">object is read only</exception>
        public void SetValue(HierarchicalProperty property, object value)
        {
            if (IsReadOnly)
                throw new InvalidOperationException("Read only objects cannot be mutated.");

            if (property == null)
                throw new ArgumentNullException("property");

            // Make sure non-nullable value-types are not assigned null.
            if (value == null
                // Make sure the property is value type...
                && property.Type.IsValueType
                // And not nullable.
                && Nullable.GetUnderlyingType(property.Type) == null)
                throw new ArgumentException("null is not assignable to " + property.Type, "value");

            // It is now okay to assign null to the property. But not value of the wrong type.
            if (value != null && !property.Type.IsInstanceOfType(value))
                throw new ArgumentException("value is not an instance of " + property.Type, "value");

            // Add or update the value for the property.
            _ownValues[property] = value;
        }

        /// <summary>
        /// Implement semantics that cannot be specified while creating an instance of the object.
        /// </summary>
        /// <remarks>
        /// This function cannot be overriden from this point on or the contract of this
        /// class will be broken. To support cloning all properties must be properly registered.
        /// </remarks>
        /// <param name="clonableObject">Clonable object.</param>
        protected sealed override void CloneOverride(CloneableObject clonableObject)
        {
            var clone = (HierarchicalObject)clonableObject;
            foreach (var propertyMapping in _ownValues)
            {
                // The property representative.
                var property = propertyMapping.Key;
                // The value owned by this object.
                var value = propertyMapping.Value;
                // Set value for this property on the clone.
                clone.SetValue(property, property.Clone(value));
            }
        }
    }
}
