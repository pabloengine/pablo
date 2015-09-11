using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
