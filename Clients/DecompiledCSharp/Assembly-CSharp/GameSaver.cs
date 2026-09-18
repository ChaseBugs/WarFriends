using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;
using UnityEngine;

public static class GameSaver
{
	public static void SaveObject(string name, Type objectType, object toSaveObject)
	{
		try
		{
			ObscuredPrefs.SetString(name, SerializeObject(toSaveObject, objectType));
		}
		catch (Exception ex)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(ex.ToString());
			}
		}
	}

	public static void SaveEmptyObject(string name)
	{
		ObscuredPrefs.DeleteAll();
	}

	private static string SerializeObject(object pObject, Type type)
	{
		return JsonConvert.SerializeObject(pObject);
	}
}
