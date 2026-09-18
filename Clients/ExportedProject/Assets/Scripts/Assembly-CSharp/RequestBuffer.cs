using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class RequestBuffer
{
	public bool alreadySent;

	public string id;

	public int requestCount;

	public Dictionary<int, Request> requests;

	private float mTimeOut;

	private RadicalRoutine mWaitingRoutine;

	public void AddRequest(DatabaseAction databaseAction, string objData, int warbucks = 0, int gold = 0, string parameter = "", bool additionalParameter = false)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Add request to buffer");
		}
		Request request = new Request();
		request.data = objData;
		request.action = databaseAction;
		Request value = request;
		switch (databaseAction)
		{
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.BuyUnit:
		case DatabaseAction.BuyCardPack:
		case DatabaseAction.BuyDecal:
		case DatabaseAction.InstantBuyUnit:
		case DatabaseAction.InstantBuyWeapon:
			PlayerAnalytics.instance.AddTransaction((int)databaseAction, parameter, gold, warbucks, 0f);
			break;
		}
		switch (databaseAction)
		{
		case DatabaseAction.BuyWeapon:
			if (gold > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Gold", "Weapon_ID", parameter, gold);
				Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchasePremiumWeapon);
				Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_Weapon", gold);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon", "Weapon_ID", parameter, warbucks);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
				Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseSoftWeapon);
			}
			break;
		case DatabaseAction.BuyWeaponUpgrade:
		{
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text = "0";
			if (dictionary.ContainsKey("BoughtIndex"))
			{
				text = dictionary["BoughtIndex"].ToString();
			}
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Upgrade", "Weapon_ID", parameter + " " + text, warbucks);
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Upgrade_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseWeaponUpgrade);
			break;
		}
		case DatabaseAction.BuyUnit:
			if (gold > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit_Gold", "Army_Unit_ID", parameter, gold);
				Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchasePremiumUnit);
				Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_Unit", gold);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit", "Army_Unit_ID", parameter, warbucks);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
				Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseSoftUnit);
			}
			break;
		case DatabaseAction.BuyUnitUpgrade:
		{
			Dictionary<string, object> dictionary4 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text4 = "0";
			bool flag = false;
			if (dictionary4.ContainsKey("BoughtIndex"))
			{
				text4 = dictionary4["BoughtIndex"].ToString();
			}
			if (dictionary4.ContainsKey("IsSpecial"))
			{
				flag = dictionary4["IsSpecial"].ToString().Equals("1");
			}
			string parameterValue = ((!flag) ? (parameter + " " + text4) : (parameter + " Special " + text4));
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Upgrade_For_Army_Unit", "Army_Unit_ID", parameterValue, warbucks);
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent((!flag) ? "Buy_Upgrade_For_Army_Unit_At_Rank" : "Buy_Upgrade_For_Army_Unit_At_Rank_Special", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseUnitUpgrade);
			break;
		}
		case DatabaseAction.UpgradeEliteSlot:
		{
			Dictionary<string, object> dictionary3 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text2 = dictionary3["BoughtIndex"].ToString();
			string text3 = dictionary3["LevelName"].ToString();
			string s3 = dictionary3["SpentParts"].ToString();
			string s4 = dictionary3["SpentWarbucks"].ToString();
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtElite(text3 + " " + text2, int.Parse(s3), int.Parse(s4));
			break;
		}
		case DatabaseAction.ConvertPartsToScraps:
		{
			Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string unit = dictionary2["LevelName"].ToString();
			string s = dictionary2["PartsToConvert"].ToString();
			string s2 = dictionary2["Scraps"].ToString();
			Singleton<EventTrackingManager>.instance.RegisterScrappingParts(unit, int.Parse(s), int.Parse(s2));
			break;
		}
		case DatabaseAction.BuyDecal:
			if (warbucks > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Player_Customizations_Warbucks", "Item_ID", parameter, warbucks);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Player_Customizations_Gold", "Item_ID", parameter, gold);
			}
			break;
		}
		string text5 = string.Empty;
		string text6 = string.Empty;
		string text7 = string.Empty;
		int num = 0;
		if (databaseAction == DatabaseAction.BuyWeapon || databaseAction == DatabaseAction.BuyWeaponUpgrade)
		{
			if (warbucks > 0)
			{
				text5 = "Spend_Warbucks_On_Weapons";
				text7 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Weapon_Upgrade" : "Buy_Weapon");
				num = warbucks;
			}
			else
			{
				text5 = "Spend_Gold_On_Weapons";
				text6 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Weapon_Upgrade" : "Buy_Weapon");
				num = gold;
			}
		}
		if (databaseAction == DatabaseAction.BuyUnit || databaseAction == DatabaseAction.BuyUnitUpgrade)
		{
			if (warbucks > 0)
			{
				text5 = "Spend_Warbucks_On_Army";
				num = warbucks;
				text7 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Unit_Upgrade" : "Buy_Unit");
			}
			else
			{
				text5 = "Spend_Gold_On_Army";
				num = gold;
				text6 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Unit_Upgrade" : "Buy_Unit");
			}
		}
		if (databaseAction == DatabaseAction.BuyDecal)
		{
			if (warbucks > 0)
			{
				if (!additionalParameter)
				{
					text5 = "Spend_Warbucks_On_Player_Customizations";
					num = warbucks;
				}
			}
			else if (additionalParameter)
			{
				text5 = "Spend_Gold_On_Power_Bands";
				num = gold;
				Singleton<EventTrackingManager>.instance.RegisterPowerBandEvent(objData, gold, isGold: true);
			}
			else
			{
				text5 = "Spend_Gold_On_Player_Customizations";
				num = gold;
				Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.PurchaseCosmeticItem);
			}
		}
		if (databaseAction == DatabaseAction.InstantWeaponUpgrade)
		{
			text5 = "Skip_Wait_Weapon_Upgrades";
			num = gold;
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.DeliverWeaponUpgrade);
			text6 = "Buy_Instant_Weapon_Upgrade";
		}
		if (databaseAction == DatabaseAction.InstantUnitUpgrade)
		{
			text5 = "Skip_Wait_Unit_Upgrades";
			num = gold;
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.DeliverUnitUpgrade);
			text6 = "Buy_Instant_Unit_Upgrade";
		}
		if (databaseAction == DatabaseAction.BuyCardPack)
		{
			if (gold > 0)
			{
				text5 = "Spend_Gold_On_Card_Packs";
				num = gold;
				text6 = "Buy_Card_Pack";
			}
			Singleton<EventTrackingManager>.instance.RegisterBuyCardPackEvent(parameter, num, gold > 0);
		}
		if (!string.IsNullOrEmpty(text6))
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldOut(text6, gold);
		}
		if (!string.IsNullOrEmpty(text7))
		{
			Singleton<EventTrackingManager>.instance.RegisterWBOut(text7, warbucks);
		}
		if (num != 0 && !string.IsNullOrEmpty(text5))
		{
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent(text5, num);
		}
		requests.Add(requestCount++, value);
		if (mWaitingRoutine != null)
		{
			mWaitingRoutine.Cancel();
			mWaitingRoutine = RadicalRoutine.Create(WaitAndSend(mTimeOut));
			RequestBufferManager.instance.StartCoroutine(RadicalRoutine.Run(mWaitingRoutine.enumerator));
		}
		RequestBufferManager.instance.Save();
		PushNotificationManager.instance.ScheduleLocalNotifications(databaseAction);
	}

	public void Send()
	{
		Debug.Log("RequestBuffer " + id + ": sending via Beanstalk(request count =" + requestCount + ")");
		if (alreadySent)
		{
			Debug.LogError("Buffer already sent!");
			RequestBufferManager.instance.RemoveRequestBuffer(id);
		}
		else
		{
			alreadySent = true;
			Singleton<BeanstalkServerManager>.instance.SendRequestBuffer(id, requests, requestCount);
		}
	}

	internal void Init(string bufferId, float timeOut)
	{
		requestCount = 0;
		id = bufferId;
		mTimeOut = timeOut;
		mWaitingRoutine = RadicalRoutine.Create(WaitAndSend(mTimeOut));
		RequestBufferManager.instance.StartCoroutine(RadicalRoutine.Run(mWaitingRoutine.enumerator));
		requests = new Dictionary<int, Request>();
		alreadySent = false;
	}

	internal void Init(string bufferId)
	{
		requestCount = 0;
		id = bufferId;
		requests = new Dictionary<int, Request>();
		alreadySent = false;
	}

	private IEnumerator WaitAndSend(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		while (Singleton<BeanstalkServerManager>.instance.isSending)
		{
			yield return new WaitForSeconds(0.2f);
			yield return null;
		}
		yield return null;
		Send();
	}
}
