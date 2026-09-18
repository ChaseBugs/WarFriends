using System;
using System.Collections.Generic;
using System.IO;
using FuseMisc;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class OfferManager : Singleton<OfferManager>
{
	public long minDiscountDuration = 300L;

	private int lastCheckTime;

	private bool canCheckOffer;

	private Dictionary<string, SpecialPackContent> mSpecialPacks = new Dictionary<string, SpecialPackContent>();

	private Dictionary<string, string> packNameChanges = new Dictionary<string, string>();

	private Dictionary<string, string> packNameTranslator = new Dictionary<string, string>();

	private int mEndTime;

	private JToken downloadedCache;

	public string suffixForABtesting = string.Empty;

	public int DiscountChangeForABTesting;

	private List<OneOffer> mAllOffersData = new List<OneOffer>();

	private OneOffer[] mDebugData;

	public int numberOfSpecialPacks => mSpecialPacks.Count;

	public Dictionary<string, SpecialPackContent>.ValueCollection specialPacks => mSpecialPacks.Values;

	public OneOffer[] currentOffers
	{
		get
		{
			if (DebugSettings.debugEnabled && mDebugData != null && mDebugData.Length > 0)
			{
				return mDebugData;
			}
			return mAllOffersData.ToArray();
		}
	}

	public event Action SalesChanged;

	public void AddSpecialPack(SpecialPackContent newPack)
	{
		if (newPack == null)
		{
			Debug.LogError("try add null pack");
		}
		else if (mSpecialPacks.ContainsKey(newPack.packId))
		{
			Debug.Log($"Special pack \"{newPack.packId}\" already in offer manager cache.");
		}
		else
		{
			mSpecialPacks.Add(newPack.packId, newPack);
		}
	}

	public void CheckOffer()
	{
		if (canCheckOffer)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > mEndTime && currentTimestamp - lastCheckTime > 300)
			{
				Debug.Log("check offer");
				FuseboxxService fuseboxxService = Singleton<EventTrackingManager>.instance.fuseboxxService;
				fuseboxxService.CheckOffer(show: false);
				lastCheckTime = currentTimestamp;
			}
		}
	}

	private void CreateFolders()
	{
		string path = $"{Application.persistentDataPath}/offerImages/small/";
		Directory.CreateDirectory(path);
		path = $"{Application.persistentDataPath}/offerImages/big/";
		Directory.CreateDirectory(path);
	}

	private void CheckFolder(List<string> offerIds, string path)
	{
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				string fileName = Path.GetFileName(files[i]);
				bool flag = true;
				for (int j = 0; j < offerIds.Count; j++)
				{
					if (!flag)
					{
						break;
					}
					flag = fileName.StartsWith(offerIds[j]);
				}
				if (flag)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	private void CheckFolders(List<string> offerIds)
	{
		CheckFolder(offerIds, $"{Application.persistentDataPath}/offerImages/small/");
		CheckFolder(offerIds, $"{Application.persistentDataPath}/offerImages/big/");
	}

	public static void SaveImage(bool small, string offerId, string langCode, Texture2D texture)
	{
		if (texture == null)
		{
			return;
		}
		try
		{
			string path = string.Format("{0}/offerImages/{1}/{2}-{3}.png", Application.persistentDataPath, (!small) ? "big" : "small", offerId, langCode);
			File.WriteAllBytes(path, texture.EncodeToPNG());
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static Texture2D LoadImage(bool small, string offerId, string langCode)
	{
		string path = string.Format("{0}/offerImages/{1}/{2}-{3}.png", Application.persistentDataPath, (!small) ? "big" : "small", offerId, langCode);
		if (File.Exists(path))
		{
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.LoadImage(data);
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			return texture2D;
		}
		return null;
	}

	public void DebugThreeOffers()
	{
		mDebugData = new OneOffer[3];
		mDebugData[0] = OneOffer.CreateTestOffer();
		mDebugData[1] = OneOffer.CreateTestOffer(1);
		mDebugData[2] = OneOffer.CreateTestOffer(2);
		if (this.SalesChanged != null)
		{
			this.SalesChanged();
		}
	}

	public void HaveOfferFormFusebox(VGOfferInfo offerInfo)
	{
		long num = offerInfo.EndTime.ToUnixTimestamp();
		if (num > Singleton<BeanstalkServerManager>.instance.currentTimestamp + minDiscountDuration)
		{
			float purchasePrice = offerInfo.PurchasePrice;
			int num2 = MiscTools.RoundToInt(100f - purchasePrice) + DiscountChangeForABTesting;
			if (num2 >= 1 && num2 <= 99)
			{
				string itemName = offerInfo.ItemName;
				string dbKey = offerInfo.Metadata + suffixForABtesting;
				Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(num, num2, dbKey, itemName);
			}
		}
	}

	public void ShowedSavedOnServer()
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			mAllOffersData[i].wasShowed = true;
		}
	}

	public void UpdateFromServer(JToken importData, bool init = false)
	{
		List<string> list = new List<string>();
		if (importData == null)
		{
			mAllOffersData.Clear();
		}
		else
		{
			mAllOffersData.Clear();
			foreach (JToken item in importData.AsJEnumerable())
			{
				if (item is JProperty)
				{
					JProperty jProperty = item as JProperty;
					OneOffer oneOffer = OneOffer.LoadFromJson(jProperty.Value, jProperty.Name);
					if (oneOffer != null)
					{
						mAllOffersData.Add(oneOffer);
						list.Add(oneOffer.id);
					}
				}
			}
		}
		if (!init)
		{
			CheckFolders(list);
		}
		if (mAllOffersData.Count > 0)
		{
			int num = int.MaxValue;
			List<OneOffer> list2 = new List<OneOffer>();
			for (int i = 0; i < mAllOffersData.Count; i++)
			{
				if (!mAllOffersData[i].wasShowed)
				{
					list2.Add(mAllOffersData[i]);
				}
				if (mAllOffersData[i].deadline < num)
				{
					num = mAllOffersData[i].deadline;
				}
			}
			if (list2.Count > 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new SpecialOfferMessage(list2.ToArray()));
			}
			mEndTime = num;
		}
		else
		{
			mEndTime = 0;
		}
		if (this.SalesChanged != null)
		{
			this.SalesChanged();
		}
		canCheckOffer = true;
	}

	public List<SpecialPackContent> GetSpecialPackOffer()
	{
		List<SpecialPackContent> list = new List<SpecialPackContent>();
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.BuyInApp && Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(mAllOffersData[i].additionalInfo))
			{
				list.Add(SpecialPackContent.CreatePackFromId(mAllOffersData[i].additionalInfo));
			}
		}
		return list;
	}

	public string GetOfferTitle(string offerId)
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.BuyInApp && mAllOffersData[i].additionalInfo == offerId)
			{
				return mAllOffersData[i].title;
			}
		}
		return offerId;
	}

	public int GetOfferDeadline(string offerId)
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.BuyInApp && mAllOffersData[i].additionalInfo == offerId)
			{
				return mAllOffersData[i].deadline;
			}
		}
		return 0;
	}

	public string getPackName(string packID)
	{
		if (packNameChanges.ContainsKey(packID))
		{
			return packNameChanges[packID];
		}
		Debug.LogError("no pack name");
		return packID;
	}

	public void SetPacknames(JToken data)
	{
		packNameChanges.Clear();
		foreach (JProperty item in (IEnumerable<JToken>)data)
		{
			string key = item.Name;
			string text = StringParser.ParseString(item.Value, string.Empty);
			if (text != string.Empty)
			{
				packNameChanges.Add(key, text);
			}
		}
	}

	public void UpdateSpecialPackFromServer(JToken data, bool now)
	{
		if (now)
		{
			UpdatePackData(data);
			downloadedCache = null;
		}
		else
		{
			downloadedCache = data;
		}
	}

	private void UpdatePackData(JToken data)
	{
		if (data is JArray)
		{
			foreach (JToken item in (IEnumerable<JToken>)data)
			{
				if (item["id"] != null && item["end"] != null)
				{
					string text = StringParser.ParseString(item["id"], string.Empty);
					int finishAt = StringParser.ParseIntToken(item["end"], -1);
					if (mSpecialPacks.ContainsKey(text))
					{
						mSpecialPacks[text].finishAt = finishAt;
					}
					else
					{
						SpecialPackContent specialPackContent = SpecialPackContent.CreatePackFromId(text);
						if (specialPackContent != null)
						{
							specialPackContent.finishAt = finishAt;
							AddSpecialPack(specialPackContent);
						}
					}
				}
			}
			return;
		}
		Debug.LogWarning("OffersManager: Wrong data: " + data.ToString());
	}

	protected override void Awake()
	{
		base.Awake();
		CreateFolders();
		UpdateFromServer(null, init: true);
		canCheckOffer = false;
		lastCheckTime = 0;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.updateCounterBySecond = (Action)Delegate.Combine(counterManager.updateCounterBySecond, new Action(EverySecondUpdate));
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	public void RegisterPacksNameChange(string oldPackId, string newPackID)
	{
		Packs packsDefinition = Singleton<GameVariables>.instance.packsDefinition;
		if (oldPackId == Singleton<GameVariables>.instance.packsDefinition.rowNames[0])
		{
			Singleton<GameVariables>.instance.starterpackABtestingName = newPackID;
		}
		else if (oldPackId == Singleton<GameVariables>.instance.packsDefinition.rowNames[1])
		{
			Singleton<GameVariables>.instance.valuePackABtestingName = newPackID;
		}
		else if (oldPackId == Singleton<GameVariables>.instance.packsDefinition.rowNames[2])
		{
			Singleton<GameVariables>.instance.moneyPackABtestingName = newPackID;
		}
		else if (Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(oldPackId))
		{
			if (packNameChanges.ContainsKey(oldPackId))
			{
				packNameChanges[oldPackId] = newPackID;
			}
			else
			{
				packNameChanges.Add(oldPackId, newPackID);
			}
		}
		else if (Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(newPackID))
		{
			AddSpecialPack(SpecialPackContent.CreatePackFromId(newPackID));
		}
	}

	private void OnPlayerDataLoaded()
	{
		if (downloadedCache != null)
		{
			UpdatePackData(downloadedCache);
		}
		downloadedCache = null;
	}

	public int DiscountedWeaponCategory(WeaponCategory category, OfferBuyType type, WeaponLevelsSetup weapon = null)
	{
		int num = 0;
		bool flag = (type & OfferBuyType.Buy) > (OfferBuyType)0;
		bool flag2 = (type & OfferBuyType.Upgrade) > (OfferBuyType)0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
				}
			}
			else if (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
				}
			}
			else if ((flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy)))
			{
				int result = 0;
				if (int.TryParse(mAllOffersData[i].additionalInfo, out result) && (int)((uint)result & (uint)category) > 0 && mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
				}
			}
			else if (weapon != null && ((flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy))) && mAllOffersData[i].additionalInfo == weapon.GetSheetName() && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedWeapon(WeaponLevelsSetup weapon, OfferBuyType type)
	{
		return DiscountedWeaponCategory(weapon.weaponCategory, type, weapon);
	}

	public int DiscountedWeaponEndtime(WeaponLevelsSetup weapon, OfferBuyType type)
	{
		int num = 0;
		int result = 0;
		bool flag = (type & OfferBuyType.Buy) > (OfferBuyType)0;
		bool flag2 = (type & OfferBuyType.Upgrade) > (OfferBuyType)0;
		WeaponCategory weaponCategory = weapon.weaponCategory;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if ((flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy)))
			{
				int result2 = 0;
				if (int.TryParse(mAllOffersData[i].additionalInfo, out result2) && (int)((uint)result2 & (uint)weaponCategory) > 0 && mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if (((flag && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy))) && mAllOffersData[i].additionalInfo == weapon.GetSheetName() && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedWeaponOfferBuy()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedWeaponOfferUpgrade()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public WeaponLevelsSetup DiscountedWeaponOffer()
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy) && mAllOffersData[i].discount > 0)
			{
				return LevelManager.instance.Weapon(mAllOffersData[i].additionalInfo);
			}
		}
		return null;
	}

	public int DiscountedWeaponOfferEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenWeaponOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedWeaponFlatEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.WeaponScreenFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedUnitCategory(LevelBehaviour.UnitType unitType, OfferBuyType type, LevelBehaviour unit = null)
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			bool flag = (type & OfferBuyType.Buy) > (OfferBuyType)0;
			bool flag2 = (type & OfferBuyType.Upgrade) > (OfferBuyType)0;
			if (flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
				}
				continue;
			}
			if (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
				}
				continue;
			}
			if ((flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy)))
			{
				int num2 = 1 << (int)unitType;
				int result = 0;
				if (int.TryParse(mAllOffersData[i].additionalInfo, out result) && (result & num2) > 0)
				{
					if (mAllOffersData[i].discount > num)
					{
						num = mAllOffersData[i].discount;
					}
					continue;
				}
			}
			if (unit != null && ((flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy))) && mAllOffersData[i].additionalInfo == unit.upgradeSlots.GetSheetName() && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedUnit(LevelBehaviour unit, OfferBuyType type)
	{
		return DiscountedUnitCategory(unit.unitType, type, unit);
	}

	public int DiscountedUnitEndtime(LevelBehaviour unit, OfferBuyType type)
	{
		int unitType = (int)unit.unitType;
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			bool flag = (type & OfferBuyType.Buy) > (OfferBuyType)0;
			bool flag2 = (type & OfferBuyType.Upgrade) > (OfferBuyType)0;
			if (flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgradeBuy))
			{
				if (mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if ((flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy)))
			{
				int num2 = 1 << unitType;
				int result2 = 0;
				if (int.TryParse(mAllOffersData[i].additionalInfo, out result2) && (result2 & num2) > 0 && mAllOffersData[i].discount > num)
				{
					num = mAllOffersData[i].discount;
					result = mAllOffersData[i].deadline;
				}
			}
			else if (unit != null && ((flag && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy)) || (flag2 && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy))) && mAllOffersData[i].additionalInfo == unit.upgradeSlots.GetSheetName() && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return result;
	}

	public int DiscountedUnitOfferBuy()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedUnitOfferUpgrade()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public LevelBehaviour DiscountedUnitOffer()
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy) && mAllOffersData[i].discount > 0)
			{
				return LevelManager.instance.Unit(mAllOffersData[i].additionalInfo);
			}
		}
		return null;
	}

	public int DiscountedUnitOfferEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenUnitOneUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedUnitFlatEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (mAllOffersData[i].type == OffersDestination.ArmyScreenFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenFlatUpgradeBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatBuy || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgrade || mAllOffersData[i].type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedVIP()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.VIPFlat && mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedVIPEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.VIPFlat && mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedLootbox()
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.WarshopLootboxesFlat && mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedLootboxEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].type == OffersDestination.WarshopLootboxesFlat && mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].discount > num)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public int DiscountedCardpack(CardPack cardTypePack)
	{
		int num = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (((cardTypePack == CardPack.Gold || cardTypePack == CardPack.Silver || cardTypePack == CardPack.Bronze) && mAllOffersData[i].type == OffersDestination.WarshopCardpacksFlat) || (mAllOffersData[i].type == OffersDestination.WarshopCardpacksOne && mAllOffersData[i].additionalInfo == Singleton<GameVariables>.instance.GetCardPackRow(cardTypePack).NAME)) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
			}
		}
		return num;
	}

	public int DiscountedCardpackEndtime(CardPack cardTypePack)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (((cardTypePack == CardPack.Gold || cardTypePack == CardPack.Silver || cardTypePack == CardPack.Bronze) && mAllOffersData[i].type == OffersDestination.WarshopCardpacksFlat) || (mAllOffersData[i].type == OffersDestination.WarshopCardpacksOne && mAllOffersData[i].additionalInfo == Singleton<GameVariables>.instance.GetCardPackRow(cardTypePack).NAME)) && num < mAllOffersData[i].discount)
			{
				num = mAllOffersData[i].discount;
				result = mAllOffersData[i].deadline;
			}
		}
		return result;
	}

	public bool DiscountedCardpackOffer(CardPack cardTypePack)
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].type == OffersDestination.WarshopCardpacksOne && mAllOffersData[i].additionalInfo == Singleton<GameVariables>.instance.GetCardPackRow(cardTypePack).NAME)
			{
				return true;
			}
		}
		return false;
	}

	public bool DiscountedCardpackFlat()
	{
		for (int i = 0; i < mAllOffersData.Count; i++)
		{
			if (mAllOffersData[i].deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp && mAllOffersData[i].type == OffersDestination.WarshopCardpacksFlat)
			{
				return true;
			}
		}
		return false;
	}

	private void EverySecondUpdate()
	{
		if (mEndTime == 0)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (mEndTime > currentTimestamp)
		{
			return;
		}
		int num = int.MaxValue;
		for (int num2 = mAllOffersData.Count - 1; num2 >= 0; num2--)
		{
			if (mAllOffersData[num2].deadline <= currentTimestamp)
			{
				mAllOffersData.RemoveAt(num2);
			}
		}
		mEndTime = ((mAllOffersData.Count > 0) ? num : 0);
		if (this.SalesChanged != null)
		{
			this.SalesChanged();
		}
	}
}
