using Newtonsoft.Json.Linq;
using UnityEngine;

public class OneOffer
{
	public string id;

	public string title;

	public string description;

	public string buttonTitle;

	public int deadline;

	public int discount;

	public string urlBig;

	public string urlSmall;

	public OffersDestination type;

	public string additionalInfo;

	public bool wasShowed;

	public bool isApplicable
	{
		get
		{
			switch (type)
			{
			case OffersDestination.ArmyScreenUnitOneBuy:
			{
				LevelBehaviour levelBehaviour2 = LevelManager.instance.Unit(additionalInfo);
				return levelBehaviour2 != null && levelBehaviour2.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
			}
			case OffersDestination.ArmyScreenUnitOneUpgrade:
			{
				LevelBehaviour levelBehaviour3 = LevelManager.instance.Unit(additionalInfo);
				return levelBehaviour3 != null && levelBehaviour3.upgradeSlots.bought && levelBehaviour3.upgradeSlots.canBeUpgraded;
			}
			case OffersDestination.ArmyScreenUnitOneUpgradeBuy:
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.Unit(additionalInfo);
				if (levelBehaviour == null)
				{
					return false;
				}
				return levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed || (levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded);
			}
			case OffersDestination.ArmyScreenFlatBuy:
			case OffersDestination.ArmyScreenTypeFlatBuy:
			case OffersDestination.ArmyScreenFlatUpgrade:
			case OffersDestination.ArmyScreenTypeFlatUpgrade:
			case OffersDestination.ArmyScreenFlatUpgradeBuy:
			case OffersDestination.ArmyScreenTypeFlatUpgradeBuy:
				return IsAnyApplicableUnit();
			case OffersDestination.WeaponScreenWeaponOneBuy:
			{
				WeaponLevelsSetup weaponLevelsSetup3 = LevelManager.instance.Weapon(additionalInfo);
				return weaponLevelsSetup3 != null && weaponLevelsSetup3.weaponState == WeaponLevelsSetup.State.NotBuyed;
			}
			case OffersDestination.WeaponScreenWeaponOneUpgrade:
			{
				WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.Weapon(additionalInfo);
				return weaponLevelsSetup2 != null && weaponLevelsSetup2.bought && weaponLevelsSetup2.canBeUpgraded;
			}
			case OffersDestination.WeaponScreenWeaponOneUpgradeBuy:
			{
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(additionalInfo);
				if (weaponLevelsSetup == null)
				{
					return false;
				}
				return weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded);
			}
			case OffersDestination.WeaponScreenFlatBuy:
			case OffersDestination.WeaponScreenSlotFlatBuy:
			case OffersDestination.WeaponScreenTypeFlatBuy:
			case OffersDestination.WeaponScreenFlatUpgrade:
			case OffersDestination.WeaponScreenSlotFlatUpgrade:
			case OffersDestination.WeaponScreenTypeFlatUpgrade:
			case OffersDestination.WeaponScreenFlatUpgradeBuy:
			case OffersDestination.WeaponScreenSlotFlatUpgradeBuy:
			case OffersDestination.WeaponScreenTypeFlatUpgradeBuy:
				return IsAnyApplicableWeapon();
			case OffersDestination.BuyInApp:
				return !PlayerAnalytics.instance.IsPackBought(additionalInfo);
			default:
				return true;
			}
		}
	}

	private int category
	{
		get
		{
			int result = 0;
			int.TryParse(additionalInfo, out result);
			return result;
		}
	}

	public static OneOffer LoadFromJson(JToken data, string key)
	{
		OneOffer oneOffer = new OneOffer();
		if (data["end"] != null && data["sale"] != null && data["offerType"] != null && data["bigURL"] != null && data["smallURL"] != null)
		{
			if (data["title"] == null)
			{
				Debug.LogError("null title for offer!");
				return null;
			}
			oneOffer.id = key;
			oneOffer.deadline = StringParser.ParseIntToken(data["end"]);
			oneOffer.discount = StringParser.ParseIntToken(data["sale"]);
			oneOffer.wasShowed = data["showed"] != null && StringParser.ParseIntToken(data["showed"]) == 1;
			oneOffer.type = (OffersDestination)StringParser.ParseIntToken(data["offerType"]);
			oneOffer.title = StringParser.ParseString(data["title"], string.Empty);
			if (data["button"] != null)
			{
				oneOffer.buttonTitle = StringParser.ParseString(data["button"], string.Empty);
			}
			else
			{
				oneOffer.buttonTitle = string.Empty;
			}
			if (data["description"] != null)
			{
				oneOffer.description = StringParser.ParseString(data["description"], string.Empty);
			}
			else
			{
				oneOffer.description = string.Empty;
			}
			if (data["otherInfo"] != null)
			{
				oneOffer.additionalInfo = StringParser.ParseString(data["otherInfo"], string.Empty);
			}
			else
			{
				oneOffer.additionalInfo = string.Empty;
			}
			oneOffer.urlBig = StringParser.ParseString(data["bigURL"], string.Empty);
			oneOffer.urlSmall = StringParser.ParseString(data["smallURL"], string.Empty);
			return oneOffer;
		}
		return null;
	}

	public static OneOffer CreateTestOffer(int i = 0)
	{
		OneOffer oneOffer = new OneOffer();
		oneOffer.id = i.ToString("'ID'0");
		oneOffer.title = i.ToString("'Offer '0");
		oneOffer.description = ((i != 0) ? "Description!!!!!!! Motherfuckers :-)" : string.Empty);
		oneOffer.buttonTitle = ((i != 1) ? "BYATCH" : "GO TO OFFER");
		oneOffer.deadline = ((i != 3) ? (Singleton<BeanstalkServerManager>.instance.currentTimestamp + 3600) : 0);
		oneOffer.discount = 60 - i;
		switch (i)
		{
		case 0:
			oneOffer.urlBig = "http://www.about-fun.com/img/game-war-third-bg.jpg";
			break;
		case 1:
			oneOffer.urlBig = "http://www.imgawards.com/wp-content/uploads/2015/12/Cover-Winter_WarFriends.png";
			break;
		default:
			oneOffer.urlBig = "http://a4.mzstatic.com/eu/r30/Purple111/v4/30/72/db/3072db24-2849-d8a8-cdf4-739c12e46a00/screen520x924.jpeg";
			break;
		}
		oneOffer.urlSmall = oneOffer.urlBig;
		oneOffer.type = (OffersDestination)(i + 12);
		if (oneOffer.type == OffersDestination.ArmyScreenUnitOneUpgradeBuy)
		{
			oneOffer.additionalInfo = "Google2u.DBUpgradeSlotsCar";
		}
		if (oneOffer.type == OffersDestination.WeaponScreenSlotFlatBuy)
		{
			oneOffer.additionalInfo = "Primary";
		}
		oneOffer.wasShowed = true;
		return oneOffer;
	}

	public static OneOffer CreateTestLootboxOffer()
	{
		OneOffer oneOffer = new OneOffer();
		oneOffer.id = "LOOTBOXDISCOUNT";
		oneOffer.title = "LOOTBOXES DISCOUNTED";
		oneOffer.description = "Buy as many as you can";
		oneOffer.buttonTitle = "GO TO WARSHOP";
		oneOffer.deadline = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 3600;
		oneOffer.discount = 20;
		oneOffer.urlBig = "https://i.ytimg.com/vi/U6Da9jKbXu0/hqdefault.jpg";
		oneOffer.urlSmall = oneOffer.urlBig;
		oneOffer.type = OffersDestination.WarshopLootboxesFlat;
		oneOffer.wasShowed = false;
		return oneOffer;
	}

	private bool IsAnyApplicableUnit()
	{
		int num = category;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			int num2 = 1 << (int)behaviour.unitType;
			if (type == OffersDestination.ArmyScreenTypeFlatBuy && (num2 & num) > 0 && behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed)
			{
				return true;
			}
			if (type == OffersDestination.ArmyScreenTypeFlatUpgrade && (num2 & num) > 0 && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return true;
			}
			if (type == OffersDestination.ArmyScreenTypeFlatUpgradeBuy && (num2 & num) > 0 && (behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return true;
			}
			if (type == OffersDestination.ArmyScreenFlatBuy && behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed)
			{
				return true;
			}
			if (type == OffersDestination.ArmyScreenFlatUpgrade && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return true;
			}
			if (type == OffersDestination.ArmyScreenFlatUpgradeBuy && (behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsAnyApplicableWeapon()
	{
		int num = category;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			int weaponCategory = (int)weaponLevelsSetup.weaponCategory;
			if ((type == OffersDestination.WeaponScreenSlotFlatBuy || type == OffersDestination.WeaponScreenTypeFlatBuy) && (weaponCategory & num) > 0 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed)
			{
				return true;
			}
			if ((type == OffersDestination.WeaponScreenSlotFlatUpgrade || type == OffersDestination.WeaponScreenTypeFlatUpgrade) && (weaponCategory & num) > 0 && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if ((type == OffersDestination.WeaponScreenSlotFlatUpgradeBuy || type == OffersDestination.WeaponScreenTypeFlatUpgradeBuy) && (weaponCategory & num) > 0 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
			if (type == OffersDestination.WeaponScreenFlatBuy && weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed)
			{
				return true;
			}
			if (type == OffersDestination.WeaponScreenFlatUpgrade && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if (type == OffersDestination.WeaponScreenFlatUpgradeBuy && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}
}
