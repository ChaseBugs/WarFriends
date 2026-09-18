using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using FuseMisc;
using Prime31;
using UnityEngine;

public class FuseSDK_Prime31_IAB : MonoBehaviour
{
	public bool logging;

	public static bool debugOutput;

	private GooglePurchase savedPurchase;

	private int retryQueryAmount = 5;

	private void Start()
	{
		if (logging)
		{
			debugOutput = true;
		}
		RegisterActions();
	}

	private void RegisterActions()
	{
		GoogleIABManager.purchaseSucceededEvent += PurchaseSucceeded;
		GoogleIABManager.purchaseFailedEvent += PurchaseFailed;
	}

	private void OnDestroy()
	{
		UnregisterActions();
	}

	private void UnregisterActions()
	{
		GoogleIABManager.purchaseSucceededEvent -= PurchaseSucceeded;
		GoogleIABManager.purchaseFailedEvent -= PurchaseFailed;
	}

	private void PurchaseSucceeded(GooglePurchase purchase)
	{
		savedPurchase = purchase;
		GoogleIABManager.queryInventorySucceededEvent += GetSkuInfo;
		GoogleIABManager.queryInventoryFailedEvent += GetSkuFailed;
		StartCoroutine(GetProductInfo(0.5f));
	}

	private void PurchaseFailed(string error, int response)
	{
	}

	private IEnumerator GetProductInfo(float delay)
	{
		yield return new WaitForSeconds(delay);
		GoogleIAB.queryInventory(new string[1] { savedPurchase.productId });
	}

	private void GetSkuInfo(List<GooglePurchase> purchaseInfo, List<GoogleSkuInfo> skuInfo)
	{
		int i;
		for (i = 0; i < purchaseInfo.Count && savedPurchase != purchaseInfo[i]; i++)
		{
		}
		if (savedPurchase == null || i >= purchaseInfo.Count || i >= skuInfo.Count)
		{
			GetSkuFailed("GetSkuInfo succeeded but productId " + savedPurchase.productId + " was not in the list of products.");
			return;
		}
		GoogleIABManager.queryInventorySucceededEvent -= GetSkuInfo;
		GoogleIABManager.queryInventoryFailedEvent -= GetSkuFailed;
		string price = skuInfo[i].price;
		double num = 0.0;
		try
		{
			num = double.Parse(price, NumberStyles.Currency);
		}
		catch
		{
			Regex regex = new Regex("\\D*(?<num>[\\d\\s\\.,]+?)(?<dec>([\\.,]\\s*\\d?\\d?)?)\\D*$");
			Match match = regex.Match(price);
			if (match.Success)
			{
				string text = string.Empty;
				try
				{
					string text2 = Regex.Replace(match.Groups["dec"].Value, "\\s", string.Empty);
					text = Regex.Replace(match.Groups["num"].Value, "[^\\d]", string.Empty) + text2;
					num = double.Parse(text, NumberStyles.Currency);
					if (num % 1.0 == 0.0 && text2.Length > 1)
					{
						num /= 100.0;
					}
				}
				catch
				{
					Debug.LogError("FuseSDK_Prime31_IAB::GetSkuInfo: Error parsing " + price + " >> Unable to parse " + text);
				}
			}
			else
			{
				Debug.LogError("FuseSDK_Prime31_IAB::GetSkuInfo: Error parsing " + price + " >> String did not match regex");
			}
		}
		GooglePurchase googlePurchase = savedPurchase;
		FuseSDK.RegisterAndroidInAppPurchase(purchaseTime: new DateTime(googlePurchase.purchaseTime * 10000, DateTimeKind.Utc), purchaseState: (IAPState)googlePurchase.purchaseState, purchaseToken: googlePurchase.purchaseToken, productId: googlePurchase.productId, orderId: googlePurchase.orderId, developerPayload: googlePurchase.developerPayload, price: num, currency: null);
		savedPurchase = null;
	}

	private void GetSkuFailed(string error)
	{
		retryQueryAmount--;
		if (retryQueryAmount > 0)
		{
			StartCoroutine(GetProductInfo(0.5f));
			return;
		}
		GoogleIABManager.queryInventorySucceededEvent -= GetSkuInfo;
		GoogleIABManager.queryInventoryFailedEvent -= GetSkuFailed;
		Debug.LogError("FuseSDK_Prime31_IAB: GoogleIAB.queryInventory failed with message: " + error);
	}

	public static void FuseLog(string str)
	{
		if (debugOutput)
		{
			Debug.Log("FuseSDK: " + str);
		}
	}
}
