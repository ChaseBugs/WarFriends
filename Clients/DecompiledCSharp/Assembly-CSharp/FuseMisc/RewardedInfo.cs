using System;
using System.Text;
using UnityEngine;

namespace FuseMisc;

public struct RewardedInfo
{
	public string PreRollMessage;

	public string RewardMessage;

	public string RewardItem;

	public int RewardItemId;

	public int RewardAmount;

	public RewardedInfo(string infoString)
	{
		if (string.IsNullOrEmpty(infoString))
		{
			return;
		}
		try
		{
			string[] array = infoString.Split(',');
			PreRollMessage = Encoding.UTF8.GetString(Convert.FromBase64String(array[0]));
			RewardMessage = Encoding.UTF8.GetString(Convert.FromBase64String(array[1]));
			RewardItem = Encoding.UTF8.GetString(Convert.FromBase64String(array[2]));
			RewardAmount = (int.TryParse(array[3], out var result) ? result : 0);
			RewardItemId = (int.TryParse(array[4], out var result2) ? result2 : 0);
		}
		catch (Exception exception)
		{
			Debug.LogError("FuseSDK: Error parsing RewardInfo. Returning default value.");
			Debug.LogException(exception);
		}
	}

	public override string ToString()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject jSONObject2 = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject2.AddField("PreRollMessage", PreRollMessage);
		jSONObject2.AddField("RewardMessage", RewardMessage);
		jSONObject2.AddField("RewardItem", RewardItem);
		jSONObject2.AddField("RewardItemId", RewardItemId);
		jSONObject2.AddField("RewardAmount", RewardAmount);
		jSONObject.AddField("RewardedInfo", jSONObject2);
		return jSONObject.ToString();
	}
}
