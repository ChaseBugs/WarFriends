using System;

public abstract class InGameSerializedObjectGeneric<T> : InGameSerializedObject
{
	public T data;

	protected override Type SerializeType => null;

	protected override object SerializedObject
	{
		get
		{
			return null;
		}
		set
		{
		}
	}
}
