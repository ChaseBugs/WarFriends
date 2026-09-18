using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;

[Skip]
public abstract class InGameSerializedObject : Core_BaseGlobalScript
{
	public static List<InGameSerializedObject> objectsToSerialize = new List<InGameSerializedObject>();

	protected abstract Type SerializeType { get; }

	protected abstract object SerializedObject { get; set; }

	protected override void Awake()
	{
		base.Awake();
		objectsToSerialize.Add(this);
		Load();
	}

	public static void SaveObjects()
	{
		foreach (InGameSerializedObject item in objectsToSerialize)
		{
			item.Save();
		}
	}

	public static void SaveEmtyObjectsAndReload()
	{
		foreach (InGameSerializedObject item in objectsToSerialize)
		{
			item.SaveEmpty();
			item.Load();
		}
	}

	public static void Reset()
	{
		objectsToSerialize = new List<InGameSerializedObject>();
	}

	public virtual void Save()
	{
		string key = GetType().Name;
		string value = JsonConvert.SerializeObject(SerializedObject);
		ObscuredPrefs.SetString(key, value);
		ObscuredPrefs.Save();
	}

	public void SaveEmpty()
	{
		string key = GetType().Name;
		ObscuredPrefs.SetString(key, string.Empty);
		ObscuredPrefs.Save();
	}

	public virtual void Load()
	{
		string key = GetType().Name;
		if (ObscuredPrefs.HasKey(key) && ObscuredPrefs.GetString(key) != string.Empty)
		{
			SerializedObject = JsonConvert.DeserializeObject(ObscuredPrefs.GetString(key), SerializeType);
		}
		else
		{
			SerializedObject = Activator.CreateInstance(SerializeType);
		}
	}
}
