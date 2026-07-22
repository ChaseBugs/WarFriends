using System;
using System.Collections.Generic;

public abstract class InGameSerializedObject : Core_BaseScript
{
	public static List<InGameSerializedObject> objectsToSerialize;

	protected abstract Type SerializeType { get; }

	protected abstract object SerializedObject { get; set; }

	protected override void Awake()
	{
	}

	public static void SaveObjects()
	{
	}

	public static void SaveEmtyObjectsAndReload()
	{
	}

	public static void Reset()
	{
	}

	protected virtual string GetSavedName()
	{
		return null;
	}

	public virtual void Save()
	{
	}

	public void SaveEmpty()
	{
	}

	public virtual void Load()
	{
	}

	private string GetSavePath()
	{
		return null;
	}

	private void Save(string name, string content)
	{
	}

	private string Load(string name)
	{
		return null;
	}
}
