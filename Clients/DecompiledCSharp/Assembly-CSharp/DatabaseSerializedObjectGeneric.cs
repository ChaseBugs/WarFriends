using System;
using Beebyte.Obfuscator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
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

	protected override void Load(JToken dictionary)
	{
		if (dictionary[SerializeType.Name] != null)
		{
			JToken jToken = dictionary[SerializeType.Name];
			try
			{
				SerializedObject = JsonConvert.DeserializeObject((string)jToken["S"], typeof(T));
				return;
			}
			catch (Exception exception)
			{
				Debug.LogError("Error Deserializing JSON for " + SerializeType.Name + ". Loading default...");
				LoadEmpty();
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, DatabaseAction.GetPlayerData, jToken.ToString(), Singleton<BeanstalkServerManager>.instance.postParameters);
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
