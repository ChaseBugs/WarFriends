using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SpecialPackContent
{
	public enum ContentType
	{
		Warbucks,
		Gold,
		Warcard,
		Cardpack,
		VIP,
		PowerBand,
		Customization,
		Unit,
		Weapon
	}

	[Serializable]
	public class Content
	{
		public ContentType type;

		public int amount;

		public CardManager.CardType warcardType;

		public CardPack cardpackType;

		public LevelBehaviour unit;

		public WeaponLevelsSetup weapon;

		private PlayerVisual mVisual;

		public PlayerVisual visual
		{
			get
			{
				if (mVisual != null)
				{
					return mVisual;
				}
				if (type == ContentType.PowerBand)
				{
					return CamosManager.instance.RandomPlayerVisual(3);
				}
				return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 3));
			}
		}

		public string debugString
		{
			get
			{
				if (type == ContentType.PowerBand)
				{
					return $"Special pack content: type: {type} id: {visual.id} seconds: {amount}";
				}
				if (type == ContentType.Customization)
				{
					return $"Special pack content: type: {type} id: {visual.id}";
				}
				if (type == ContentType.Unit)
				{
					return $"Special pack content: type: {type} id: {unit.unitName}";
				}
				if (type == ContentType.Weapon)
				{
					return string.Format("Special pack content: type: {0} id: {1}", type, (!(weapon == null)) ? weapon.weaponName : "null");
				}
				if (type == ContentType.Cardpack)
				{
					return $"Special pack content: type: {type} rarity: {cardpackType} amount: {amount}";
				}
				if (type == ContentType.Warcard)
				{
					return $"Special pack content: type: {type} rarity: {warcardType} amount: {amount}";
				}
				return $"Special pack content: type: {type} amount: {amount}";
			}
		}

		public static Content CreateWarbucks(int money)
		{
			Content content = new Content();
			content.type = ContentType.Warbucks;
			content.amount = money;
			return content;
		}

		public static Content CreateGold(int money)
		{
			Content content = new Content();
			content.type = ContentType.Gold;
			content.amount = money;
			return content;
		}

		public static Content CreateWarcard(CardManager.CardType rarity, int count)
		{
			Content content = new Content();
			content.type = ContentType.Warcard;
			content.amount = count;
			content.warcardType = rarity;
			return content;
		}

		public static Content CreateCardPack(CardPack cardpackType, int count)
		{
			Content content = new Content();
			content.type = ContentType.Cardpack;
			content.amount = count;
			content.cardpackType = cardpackType;
			return content;
		}

		public static Content CreateVIP(int seconds)
		{
			Content content = new Content();
			content.type = ContentType.VIP;
			content.amount = seconds;
			return content;
		}

		public static Content CreatePowerBand(int seconds, PlayerVisual powerBand)
		{
			Content content = new Content();
			content.type = ContentType.PowerBand;
			content.amount = seconds;
			content.mVisual = powerBand;
			return content;
		}

		public static Content CreateCustomization(PlayerVisual customization)
		{
			Content content = new Content();
			content.type = ContentType.Customization;
			content.mVisual = customization;
			return content;
		}

		public static Content CreateUnit(LevelBehaviour armyUnit)
		{
			Content content = new Content();
			content.type = ContentType.Unit;
			content.unit = armyUnit;
			return content;
		}

		public static Content CreateWeapon(WeaponLevelsSetup weaponSetup)
		{
			Content content = new Content();
			content.type = ContentType.Weapon;
			content.weapon = weaponSetup;
			return content;
		}
	}

	public string translationId;

	public string packId;

	public float sale;

	public Content[] contentOfPack;

	public int finishAt = -1;

	private string mSpecialPackRowName;

	public Tuple<float, string> storePrize => Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(mSpecialPackRowName);

	public string countryCode => Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemCountryCode(mSpecialPackRowName);

	public string currentPrize => (storePrize != null) ? storePrize.Value2 : string.Empty;

	public string name => (!string.IsNullOrEmpty(translationId)) ? Localization.Localize(translationId) : packId;

	public string realPrize => Singleton<GameVariables>.instance.RegularPriceOfPack(sale, packId).Value2;

	public string debugString
	{
		get
		{
			if (contentOfPack == null || contentOfPack.Length == 0)
			{
				return "Empty pack " + packId;
			}
			string text = $"Debugging pack id: {packId} with sale: {sale} store price: {storePrize.Value2} store country: {countryCode} and content:\n";
			Content[] array = contentOfPack;
			foreach (Content content in array)
			{
				text = text + content.debugString + "\n";
			}
			return text;
		}
	}

	public static SpecialPackContent CreatePackFromId(string packId)
	{
		Debug.Log("creating special pack: " + packId);
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(packId) < 0)
		{
			return null;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(packId);
		if (row == null)
		{
			return null;
		}
		SpecialPackContent specialPackContent = new SpecialPackContent();
		specialPackContent.packId = packId;
		specialPackContent.mSpecialPackRowName = row.NAME;
		if (packId.ToLower().StartsWith("elitepack"))
		{
			specialPackContent.translationId = "ID_ELITEPACK";
			specialPackContent.finishAt = PlayerAnalytics.instance.data.PackDeadline(packId);
		}
		else if (packId.ToLower().StartsWith("veteranpack"))
		{
			specialPackContent.translationId = "ID_VETERANPACK";
			specialPackContent.finishAt = PlayerAnalytics.instance.data.PackDeadline(packId);
		}
		else if (packId == Singleton<GameVariables>.instance.PackId(CardPack.Value))
		{
			specialPackContent.translationId = "ID_VALUEPACK";
			specialPackContent.finishAt = 0;
		}
		else if (packId == Singleton<GameVariables>.instance.PackId(CardPack.Starter))
		{
			specialPackContent.translationId = "ID_STARTERPACK";
			specialPackContent.finishAt = PlayerAnalytics.instance.data.starterPackDeadline;
		}
		else if (packId == Singleton<GameVariables>.instance.PackId(CardPack.Money))
		{
			specialPackContent.translationId = "ID_MONEYPACK";
			specialPackContent.finishAt = PlayerAnalytics.instance.data.moneyPackDeadline;
		}
		else
		{
			specialPackContent.translationId = Singleton<OfferManager>.instance.GetOfferTitle(packId);
			specialPackContent.finishAt = Singleton<OfferManager>.instance.GetOfferDeadline(packId);
		}
		specialPackContent.sale = row.SALE;
		int num = 0;
		int wARBUCKS = row.WARBUCKS;
		if (wARBUCKS > 0)
		{
			num++;
		}
		int gOLD = row.GOLD;
		if (gOLD > 0)
		{
			num++;
		}
		int gOLDCARDS = row.GOLDCARDS;
		if (gOLDCARDS > 0)
		{
			num++;
		}
		int sILVERCARDS = row.SILVERCARDS;
		if (sILVERCARDS > 0)
		{
			num++;
		}
		int count = 0;
		int count2 = 0;
		int count3 = 0;
		int count4 = 0;
		int vIPSECONDS = row.VIPSECONDS;
		if (vIPSECONDS > 0)
		{
			num++;
		}
		string pLAYERVISUALS = row.PLAYERVISUALS;
		PlayerVisual powerBand = null;
		int seconds = 0;
		Singleton<GameVariables>.instance.PowerBandInPack(pLAYERVISUALS, ref powerBand, ref seconds);
		if (seconds > 0)
		{
			num++;
		}
		PlayerVisual[] array = Singleton<GameVariables>.instance.PlayerVisualsInPack(pLAYERVISUALS);
		num += array.Length;
		string aRMYUNITS = row.ARMYUNITS;
		LevelBehaviour levelBehaviour = Singleton<GameVariables>.instance.UnitInPack(aRMYUNITS);
		if (levelBehaviour != null)
		{
			num++;
		}
		string wEAPONS = row.WEAPONS;
		WeaponLevelsSetup weaponLevelsSetup = Singleton<GameVariables>.instance.WeaponInPack(wEAPONS);
		if (weaponLevelsSetup != null)
		{
			num++;
		}
		string gUIORDER = row.GUIORDER;
		string[] array2 = gUIORDER.Split(new char[4] { '{', '}', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array2.Length != num)
		{
			Debug.LogFormat("Different number of guiOrder {0} and items in pack {1}", array2.Length, num);
		}
		specialPackContent.contentOfPack = new Content[array2.Length];
		int num2 = 0;
		string[] array3 = Singleton<GameVariables>.instance.CustomizationIdsFromPack(pLAYERVISUALS);
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i].ToLower() == "warbucks")
			{
				specialPackContent.contentOfPack[i] = Content.CreateWarbucks(wARBUCKS);
			}
			else if (array2[i].ToLower() == "gold")
			{
				specialPackContent.contentOfPack[i] = Content.CreateGold(gOLD);
			}
			else if (array2[i].ToLower() == "bronzewarcard")
			{
				specialPackContent.contentOfPack[i] = Content.CreateWarcard(CardManager.CardType.Bronze, count);
			}
			else if (array2[i].ToLower() == "silverwarcard")
			{
				specialPackContent.contentOfPack[i] = Content.CreateWarcard(CardManager.CardType.Silver, sILVERCARDS);
			}
			else if (array2[i].ToLower() == "goldwarcard")
			{
				specialPackContent.contentOfPack[i] = Content.CreateWarcard(CardManager.CardType.Gold, gOLDCARDS);
			}
			else if (array2[i].ToLower() == "bronzecardpack")
			{
				specialPackContent.contentOfPack[i] = Content.CreateCardPack(CardPack.Bronze, count4);
			}
			else if (array2[i].ToLower() == "silverwarcard")
			{
				specialPackContent.contentOfPack[i] = Content.CreateCardPack(CardPack.Silver, count3);
			}
			else if (array2[i].ToLower() == "goldcardpack")
			{
				specialPackContent.contentOfPack[i] = Content.CreateCardPack(CardPack.Gold, count2);
			}
			else if (array2[i].ToLower() == "vip")
			{
				specialPackContent.contentOfPack[i] = Content.CreateVIP(vIPSECONDS);
			}
			else if (array2[i].ToLower() == "visual")
			{
				if (powerBand != null && array3[num2] == powerBand.id)
				{
					specialPackContent.contentOfPack[i] = Content.CreatePowerBand(seconds, powerBand);
				}
				else
				{
					int num3 = -1;
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j].id == array3[num2])
						{
							num3 = j;
						}
					}
					if (num3 >= 0)
					{
						specialPackContent.contentOfPack[i] = Content.CreateCustomization(array[num3]);
					}
				}
				num2++;
			}
			else if (array2[i].ToLower() == "unit")
			{
				specialPackContent.contentOfPack[i] = Content.CreateUnit(levelBehaviour);
			}
			else if (array2[i].ToLower() == "weapon")
			{
				specialPackContent.contentOfPack[i] = Content.CreateWeapon(weaponLevelsSetup);
			}
		}
		return specialPackContent;
	}

	private List<Card[]> GetCardsFromCardpacks()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] array = contentOfPack;
		foreach (Content content in array)
		{
			if (content.type == ContentType.Cardpack)
			{
				if (content.cardpackType == CardPack.Bronze)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Bronze));
				}
				if (content.cardpackType == CardPack.Silver)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Silver));
				}
				if (content.cardpackType == CardPack.Gold)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Gold));
				}
			}
		}
		return list;
	}

	public IEnumerator ClaimCardpacks(CardMenuOwerlay owerlay)
	{
		List<Card[]> cardpacksToClaim = GetCardsFromCardpacks();
		if (owerlay == null)
		{
			Debug.LogError("No overlay to display cards!");
			yield break;
		}
		for (int i = 0; i < cardpacksToClaim.Count; i++)
		{
			Debug.Log("Animating claiming cardpack: " + (i + 1));
			owerlay.StartShowAnimation(cardpacksToClaim[i], 0.5f);
			yield return new WaitForRealSeconds(1f);
			while (owerlay.gameObject.activeSelf)
			{
				yield return null;
			}
		}
		Debug.Log("Animating claiming cardpack end");
	}
}
