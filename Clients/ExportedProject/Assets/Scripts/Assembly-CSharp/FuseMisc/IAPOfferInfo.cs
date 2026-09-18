using System;
using System.Text;
using UnityEngine;

namespace FuseMisc
{
public struct IAPOfferInfo
{
	public string ProductId;

	public float ProductPrice;

	public string ItemName;

	public int ItemAmount;

	public DateTime StartTime;

	public DateTime EndTime;

	public string Metadata;

	public IAPOfferInfo(string infoString) : this()
	{
		if (string.IsNullOrEmpty(infoString))
		{
			return;
		}
		try
		{
			string[] array = infoString.Split(',');
			ProductId = Encoding.UTF8.GetString(Convert.FromBase64String(array[0]));
			ProductPrice = ((!float.TryParse(array[1], out var result)) ? 0f : result);
			ItemName = Encoding.UTF8.GetString(Convert.FromBase64String(array[2]));
			ItemAmount = (int.TryParse(array[3], out var result2) ? result2 : 0);
			StartTime = ((!long.TryParse(array[4], out var result3)) ? 0 : result3).ToDateTime();
			EndTime = ((!long.TryParse(array[5], out var result4)) ? 0 : result4).ToDateTime();
			Metadata = Encoding.UTF8.GetString(Convert.FromBase64String(array[6]));
		}
		catch (Exception exception)
		{
			Debug.LogError("FuseSDK: Error parsing IAPOfferInfo. Returning default value.");
			Debug.LogException(exception);
		}
	}

	public override string ToString()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject jSONObject2 = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject2.AddField("ProductId", ProductId);
		jSONObject2.AddField("ProductPrice", ProductPrice);
		jSONObject2.AddField("ItemName", ItemName);
		jSONObject2.AddField("ItemAmount", ItemAmount);
		jSONObject2.AddField("StartTime", StartTime.ToUnixTimestamp());
		jSONObject2.AddField("EndTime", EndTime.ToUnixTimestamp());
		jSONObject2.AddField("Metadata", Convert.ToBase64String(Encoding.UTF8.GetBytes(Metadata)));
		jSONObject.AddField("IAPOfferInfo", jSONObject2);
		return jSONObject.ToString();
	}
}
}
