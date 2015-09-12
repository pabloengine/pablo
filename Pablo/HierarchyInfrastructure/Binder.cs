using System;
using DynamicExpresso;

namespace Pablo
{
    /// <summary>
    /// Represents a value that is bound.
    /// </summary>
    internal class Binder
    {
        /// <summary>
        /// Determines whether faulty expressions should
        /// throw exception or ignore.
        /// </summary>
        private readonly bool _ignoreOnError;
        /// <summary>
        /// The target object of binding.
        /// </summary>
        private readonly HierarchicalObject _target;

        /// <summary>
        /// The evaluator function.
        /// </summary>
        private readonly Interpreter _interpreter = new Interpreter(InterpreterOptions.DefaultCaseInsensitive);

        /// <summary>
        /// The expression used for the binding.
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Binder"/>
        /// </summary>
        /// <param name="target"> The target object</param>
        /// <param name="expression"> 
        /// The expression string.
        /// The format of the expression must be one of the following:
        /// <list type="number">
        ///     <item>
        ///         <term>"."</term> 
        ///         <description>
        ///             The value will be the DataContext itself.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Foo"</term> 
        ///         <description>
        ///             The value will be from <code>DataContext.Foo</code>. 
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Foo[5].Bar"</term> 
        ///         <description>
        ///             The value will be from <code>DataContext.Foo[5].Bar</code>. 
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"Foo.Bar["baz"].ToBaz()"</term> 
        ///         <description>
        ///             The value will be from <code>DataContext.Foo.Bar["baz"].ToBaz()</code>. 
        ///         </description>
        ///     </item>
        /// </list>
        /// </param>
        /// <param name="ignoreOnError">
        /// Determines whether missing properties on the context should
        /// throw exception or ignore.
        /// </param>
        /// <exception cref="ArgumentException"> The expression is empty</exception>
        /// <exception cref="ArgumentNullException"> expression is null</exception>
        public Binder(HierarchicalObject target, string expression, bool ignoreOnError)
        {
            _target = target;
            _ignoreOnError = ignoreOnError;

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException($"the provided {nameof(expression)} is empty.", nameof(expression));

            // Trim the expression
            Expression = expression.Trim();

            // Single dot case
            if (Expression == ".")
            {
                Expression = "__";
            }
            else
            {
                Expression = "__." + Expression;
            }
        }

        /// <summary>
        /// Gets the value from the evaluated binding expression.
        /// </summary>
        public object Value
        {
            get
            {
                var context = _target?.DataContext;
                // null if the context is missing.
                if (context == null)
                    return null;
                try
                {
                    // evaluate the binding expression and return the result.
                    return _interpreter.Eval(Expression, new Parameter("__", context));
                }
                catch (Exception e)
                {
                    if (_ignoreOnError)
                        return null;
                    throw new BindingExceprtion("Evaluation of the bound property failed, see innerException for details.",
                        e, _target, Expression);
                }
            }
        }
    }
}
