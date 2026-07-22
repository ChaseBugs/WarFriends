using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public abstract class DatabaseSerializedObject : Core_BaseScript
{
	private static readonly List<DatabaseSerializedObject> SerializedObjects;

	protected abstract Type SerializeType { get; }

	protected abstract object SerializedObject { get; set; }

	static DatabaseSerializedObject()
	{
	}

	protected override void Awake()
	{
	}

	protected virtual void LoadEmpty()
	{
	}

	internal static void LoadObjects(JToken dictionary)
	{
	}

	internal static void TryLoadObjects(JToken dictionary)
	{
	}

	protected virtual void Load(JToken dictionary)
	{
	}

	protected virtual void TryLoad(JToken dictionary)
	{
	}

	protected virtual void Load(Dictionary<string, object> dictionary)
	{
	}
}
