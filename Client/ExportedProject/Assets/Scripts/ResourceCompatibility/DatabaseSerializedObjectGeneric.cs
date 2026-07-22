using System;
using Newtonsoft.Json.Linq;

public class DatabaseSerializedObjectGeneric<T> : DatabaseSerializedObject where T : class
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

	protected virtual void InitData()
	{
	}

	public void LoadFromJsonString(string jsonData)
	{
	}

	protected override void Load(JToken dictionary)
	{
	}

	protected override void TryLoad(JToken dictionary)
	{
	}
}
