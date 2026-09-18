using System;
using Beebyte.Obfuscator;

[Skip]
public abstract class InGameSerializedObjectGeneric<T> : InGameSerializedObject
{
	public T data;

	protected override Type SerializeType => typeof(T);

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
