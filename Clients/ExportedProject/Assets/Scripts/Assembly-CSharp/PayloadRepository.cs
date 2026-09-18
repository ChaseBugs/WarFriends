using System;
using UnityEngine;

public class PayloadRepository
{
	private const string payloadsKey = "payloadKeys";

	private const int maxPayloadsStringLength = 2048;

	private string payloads;

	public void Init()
	{
		payloads = PlayerPrefs.GetString("payloadKeys", string.Empty);
	}

	private string GetRandomString()
	{
		return Guid.NewGuid().ToString();
	}

	public string GetNewPayload()
	{
		if (payloads.Length > 2048)
		{
			int num = payloads.IndexOf(',', payloads.Length - 2048);
			if (num > 0)
			{
				payloads = payloads.Substring(0, num + 1);
			}
		}
		string text = GetRandomString() + ",";
		payloads += text;
		PlayerPrefs.SetString("payloadKeys", payloads);
		return text;
	}

	public bool IsValid(string payload)
	{
		return !string.IsNullOrEmpty(payload) && payloads.Contains(payload);
	}

	public void RemovePayload(string payload)
	{
		if (payload != null)
		{
			payloads = payloads.Replace(payload, string.Empty);
			PlayerPrefs.SetString("payloadKeys", payloads);
		}
	}
}
