using System;

namespace Pablo
{
	/// <summary>
	/// Represents an error that occutred during a cloning session.
	/// </summary>
	public sealed class CloneException : Exception
	{
		readonly Type _targetType;
		readonly CloneableObject _targetObject;

		/// <summary>
		/// The type of the target cloneable object.
		/// </summary>
		public Type TargetType {
			get { return _targetType; }
		}

		/// <summary>
		/// The target clonable object that failed to be deeply cloned.
		/// </summary>
		public object TargetObject {
			get { return _targetObject; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Pablo.CloneException"/> class.
		/// </summary>
		internal CloneException(string message, Exception innerException, Type targetType, CloneableObject targetObject)
			: base(message, innerException)
		{
			_targetType = targetType;
			_targetObject = targetObject;
		}

	}
}
