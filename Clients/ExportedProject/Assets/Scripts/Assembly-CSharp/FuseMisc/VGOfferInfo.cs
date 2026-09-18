using System;
using System.Text;
using UnityEngine;

namespace FuseMisc
{
public struct VGOfferInfo
{
	public int CurrencyID;

	public string PurchaseCurrency;

	public float PurchasePrice;

	public int VirtualGoodID;

	public string ItemName;

	public int ItemAmount;

	public DateTime StartTime;

	public DateTime EndTime;

	public string Metadata;

	public VGOfferInfo(string infoString) : this()
	{
		if (string.IsNullOrEmpty(infoString))
		{
			return;
		}
		try
		{
			string[] array = infoString.Split(',');
			PurchaseCurrency = Encoding.UTF8.GetString(Convert.FromBase64String(array[0]));
			PurchasePrice = ((!float.TryParse(array[1], out var result)) ? 0f : result);
			ItemName = Encoding.UTF8.GetString(Convert.FromBase64String(array[2]));
			ItemAmount = (int.TryParse(array[3], out var result2) ? result2 : 0);
			StartTime = ((!long.TryParse(array[4], out var result3)) ? 0 : result3).ToDateTime();
			EndTime = ((!long.TryParse(array[5], out var result4)) ? 0 : result4).ToDateTime();
			CurrencyID = (int.TryParse(array[6], out var result5) ? result5 : 0);
			VirtualGoodID = (int.TryParse(array[7], out var result6) ? result6 : 0);
			Metadata = Encoding.UTF8.GetString(Convert.FromBase64String(array[8]));
		}
		catch (Exception exception)
		{
			Debug.LogError("FuseSDK: Error parsing VGOfferInfo. Returning default value.");
			Debug.LogException(exception);
		}
	}

	public override string ToString()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject jSONObject2 = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject2.AddField("CurrencyID", CurrencyID);
		jSONObject2.AddField("PurchaseCurrency", PurchaseCurrency);
		jSONObject2.AddField("PurchasePrice", PurchasePrice);
		jSONObject2.AddField("VirtualGoodID", VirtualGoodID);
		jSONObject2.AddField("ItemName", ItemName);
		jSONObject2.AddField("ItemAmount", ItemAmount);
		jSONObject2.AddField("StartTime", StartTime.ToUnixTimestamp());
		jSONObject2.AddField("EndTime", EndTime.ToUnixTimestamp());
		jSONObject2.AddField("Metadata", Convert.ToBase64String(Encoding.UTF8.GetBytes(Metadata)));
		jSONObject.AddField("VGOfferInfo", jSONObject2);
		return jSONObject.ToString();
	}
}
}
