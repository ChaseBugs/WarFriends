using System;

public abstract class InGameSerializedObjectGeneric<T> : InGameSerializedObject
{
	public T data;

	protected override Type SerializeType
	{
		get
		{
			return typeof(T);
		}
	}

	protected override object SerializedObject
	{
		get
		{
			return data;
		}
		set
		{
			data = (T)value;
		}
	}
}
