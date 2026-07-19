using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;

public abstract class InGameSerializedObject : Core_BaseScript
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

	protected virtual string GetSavedName()
	{
		return GetType().Name;
	}

	public virtual void Save()
	{
		string savedName = GetSavedName();
		string value = JsonConvert.SerializeObject(SerializedObject);
		ObscuredPrefs.SetString(savedName, value);
		ObscuredPrefs.Save();
	}

	public void SaveEmpty()
	{
		string savedName = GetSavedName();
		ObscuredPrefs.SetString(savedName, string.Empty);
		ObscuredPrefs.Save();
	}

	public virtual void Load()
	{
		string savedName = GetSavedName();
		if (ObscuredPrefs.HasKey(savedName) && ObscuredPrefs.GetString(savedName) != string.Empty)
		{
			SerializedObject = JsonConvert.DeserializeObject(ObscuredPrefs.GetString(savedName), SerializeType);
		}
		else
		{
			SerializedObject = Activator.CreateInstance(SerializeType);
		}
	}
}
