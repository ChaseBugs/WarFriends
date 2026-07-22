using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabaseSerializedObjectGeneric<T> : DatabaseSerializedObject where T : class
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

	protected virtual void InitData()
	{
	}

	public void LoadFromJsonString(string jsonData)
	{
		try
		{
			SerializedObject = JsonConvert.DeserializeObject<T>(jsonData);
			InitData();
		}
		catch (Exception ex)
		{
			Debug.LogError("Error Deserializing JSON for " + SerializeType.Name + ". Loading default...");
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
			LoadEmpty();
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(ex, DatabaseAction.GetPlayerData, jsonData, Singleton<BeanstalkServerManager>.instance.postParameters);
		}
	}

	protected override void Load(JToken dictionary)
	{
		if (dictionary[SerializeType.Name] != null)
		{
			JToken jToken = dictionary[SerializeType.Name];
			try
			{
				string value = (string)jToken["S"];
				SerializedObject = JsonConvert.DeserializeObject(value, typeof(T));
				return;
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("Error Deserializing JSON for " + SerializeType.Name + ". Loading default...");
				LoadEmpty();
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, DatabaseAction.GetPlayerData, jToken.ToString(), Singleton<BeanstalkServerManager>.instance.postParameters);
				return;
			}
		}
		LoadEmpty();
	}

	protected override void TryLoad(JToken dictionary)
	{
		if (dictionary[SerializeType.Name] != null)
		{
			JToken jToken = dictionary[SerializeType.Name];
			try
			{
				SerializedObject = JsonConvert.DeserializeObject((string)jToken["S"], typeof(T));
				return;
			}
			catch (Exception)
			{
				Debug.LogError("Error Deserializing JSON for " + SerializeType.Name + ". Loading default...");
				LoadEmpty();
				return;
			}
		}
		LoadEmpty();
	}
}
