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
    /// Represents a managed property.
    /// </summary>
    public sealed class HierarchicalProperty
    {
        readonly Func<string, object> _parser;
        readonly Func<object> _defaultFactory;
        readonly Func<object, object> _cloner;

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type of the property.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Indicates whether this property can be inherited.
        /// </summary>
        public bool IsInheritable { get; }

        /// <summary>
        /// The type that registered this property.
        /// </summary>
        public Type Owner { get; }

        /// <summary>
        /// Get the default value of this property.
        /// </summary>
        /// <exception cref="PropertyException">Default generation failed</exception>
        public object Default
        {
            get
            {
                // Automatically instantiate the default value if the property is value type
                // and no generator is specified.
                if (_defaultFactory == null)
                    return Type.IsValueType ? Activator.CreateInstance(Type) : null;

                object defaultObject;

                try
                {
                    defaultObject = _defaultFactory();
                }
                catch (Exception e)
                {
                    // The factory method threw an exception.
                    throw new PropertyException("The default generator function threw an exception.", e, this);
                }
                // Makes sure the factory generated an object of the correct type.
                if (!Type.IsInstanceOfType(defaultObject))
                    throw new PropertyException("The default generator function return type does not match the property type", null, this);
                return defaultObject;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is parsable.
        /// </summary>
        /// <value><c>true</c> if this instance is parsable; otherwise, <c>false</c>.</value>
        public bool IsParsable
        {
            get
            {
                // The underlying type in case it's nullable
                var underlyingType = Nullable.GetUnderlyingType(Type);
                // Has parser method
                return _parser != null
                    // Is String
                || Type == typeof(string)
                    // Is primitive 
                || Type.IsPrimitive
                    // Or Convert understands it
                || Type == typeof(DateTime)
                || Type == typeof(DateTimeOffset)
                    // Is Enum
                || Type.IsEnum
                    // Is Nullable with...
                || (underlyingType != null
                    // Primitive underlying type
                && (underlyingType.IsPrimitive
                    // Or underlying type understood by convert
                || underlyingType == typeof(DateTime)
                || underlyingType == typeof(DateTimeOffset)));
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is cloneable.
        /// </summary>
        /// <value><c>true</c> if this instance is cloneable; otherwise, <c>false</c>.</value>
        public bool IsCloneable => _cloner != null
            // Is String
                                   || Type == typeof (string)
            // Is value type 
                                   || Type.IsValueType
            // Is Enum
                                   || Type.IsEnum
            // Implements ICloneable
                                   || typeof (ICloneable).IsAssignableFrom(Type);

        /// <summary>
        /// Initializes a new instance of the <see cref="Pablo.HierarchicalProperty"/> class.
        /// </summary>
        internal HierarchicalProperty(Type owner,
                                      string name,
                                      Type type,
                                      bool inheritable,
                                      Func<string, object> parser,
                                      Func<object> defaultFactory,
                                      Func<object, object> cloner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name must have value. null or whitespace is not acceptable.", nameof(name));

            Name = name;
            Type = type;
            IsInheritable = inheritable;
            Owner = owner;
            _parser = parser;
            _defaultFactory = defaultFactory;
            _cloner = cloner;
        }

        /// <summary>
        /// Parses an instance of this property from the provided string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="PropertyException">Parsing failed</exception>
        public object Parse(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            // Automate parsing (or throw exception) in case a method is not provided.
            if (_parser == null)
            {
                // Return the s itself if the property is string too.
                if (Type == typeof(string))
                    return s;

                try
                {
                    // Parse as enum if the property is enum.
                    if (Type.IsEnum)
                        return Enum.Parse(Type, s, true);

                    // In case the property is nullable...
                    var nullableType = Nullable.GetUnderlyingType(Type);
                    if (nullableType != null) // Make sure it's nullable.
                        if (nullableType.IsPrimitive || // Make sure its a type that Convert understands.
                            nullableType == typeof(DateTime) ||
                            nullableType == typeof(DateTimeOffset))
                            return Convert.ChangeType(s, nullableType);

                    // In case the property is primitive, make sure Convert understands it.
                    if (Type.IsPrimitive || Type == typeof(DateTime) || Type == typeof(DateTimeOffset))
                        return Convert.ChangeType(s, Type);
                }
                catch (Exception e)
                {
                    throw new PropertyException("Automatic parsing for failed. Provided value: " + s, e, this);
                }

                // The Property is either a user-defiend struct or a class.
                throw new PropertyException("A parsing function was not provided.", null, this);
            }

            object parsedObject;

            try
            {
                parsedObject = _parser(s);
            }
            catch (Exception e)
            {
                // The parser method threw an exception.
                throw new PropertyException("The parser function threw an exception.", e, this);
            }

            // Makes sure the parser returned an object of the correct type.
            if (!Type.IsInstanceOfType(parsedObject))
                throw new PropertyException("The parser function return type does not match the property type", null, this);
            return parsedObject;
        }

        /// <summary>
        /// Makes a deep clone of this property.
        /// </summary>
        /// <exception cref="PropertyException">Cloning failed</exception>
        public object Clone(object o)
        {
            // Clone of null is null.
            if (o == null)
                return null;

            // Check for type mismatch.
            if (Type != o.GetType())
                throw new ArgumentException("The provided parameter's type does not match the property's type.");

            // Automate cloning (or throw exception) in case a method is not provided.
            if (_cloner == null)
            {
                // If the property is primitive, string or enum return itself.
                if (Type.IsValueType || Type == typeof(string) || Type.IsEnum)
                    return o;

                // Call the Clone method if the object is Cloneable.
                if (typeof(ICloneable).IsAssignableFrom(Type))
                {
                    try
                    {
                        return ((ICloneable)o).Clone();

                    }
                    catch (Exception e)
                    {
                        // Clone method threw an exception.
                        throw new PropertyException("The clone method threw an exception.", e, this);
                    }
                }

                // No method of automatic cloning found.
                throw new PropertyException("A cloning function was not provided.", null, this);
            }

            object clone;

            try
            {
                clone = _cloner(o);
            }
            catch (Exception e)
            {
                // The cloner threw an exception.
                throw new PropertyException("The cloning function threw an exception.", e, this);
            }

            // Makes sure the cloner returned an object of the correct type.
            if (clone.GetType() != Type)
                throw new PropertyException("The cloning function return type does not match the property type", null, this);

            return clone;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Name + "Property of " + Type;
        }
    }
}
