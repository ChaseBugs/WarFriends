using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class DatabaseSerializedObject : Core_BaseScript
{
	private static readonly List<DatabaseSerializedObject> SerializedObjects;

	protected abstract Type SerializeType { get; }

	protected abstract object SerializedObject { get; set; }

	static DatabaseSerializedObject()
	{
		SerializedObjects = new List<DatabaseSerializedObject>();
		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			Converters = new List<JsonConverter>
			{
				new NPILMLBGNID()
			}
		};
	}

	protected override void Awake()
	{
		base.Awake();
		SerializedObjects.Add(this);
	}

	protected virtual void LoadEmpty()
	{
		SerializedObject = Activator.CreateInstance(SerializeType);
	}

	internal static void LoadObjects(JToken dictionary)
	{
		foreach (DatabaseSerializedObject serializedObject in SerializedObjects)
		{
			serializedObject.Load(dictionary);
		}
	}

	internal static void TryLoadObjects(JToken dictionary)
	{
		foreach (DatabaseSerializedObject serializedObject in SerializedObjects)
		{
			serializedObject.TryLoad(dictionary);
		}
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
