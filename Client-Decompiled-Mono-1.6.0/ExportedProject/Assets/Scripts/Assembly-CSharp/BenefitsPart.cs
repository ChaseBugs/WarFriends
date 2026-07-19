using Google2u;
using UnityEngine;

public class BenefitsPart : Core_BaseScript
{
	[Header("1 Warcards Slot")]
	public UILabel MILKCHCPMPL;

	public UISprite FLKNHCAEBMM;

	public UISprite DABFBHIDOMM;

	public UILabel BHBJJHLEJEO;

	[Header("2 More Lootboxes")]
	public UILabel AIHJMMMGGDP;

	[Header("4 More XP")]
	public UILabel DFEACGKACCK;

	public UILabel ELAIEILHGFG;

	[Header("5 Daily Warcards")]
	public UILabel ANBOFCEKKMB;

	public UISprite PJJPHFALNKO;

	public UISprite LPPNDCMLBEH;

	public UILabel ENCLEFMHEPB;

	public void FIDIINBHKDG()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-69)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("equips", Localization.Localize("dogTagTimerLock"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("GameReward", Localization.Localize("ID_WARNING_ACCOUNTALREADYCREATED"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("GameController.LoadAndStartNewMap - 1sec delay");
		ELAIEILHGFG.text = Localization.Localize("ID_GOLDC");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1789f, 1448f, -24);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 68f, 148f, 17);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("\"", array);
	}

	public void ENCCFDDDJFF()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-194)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("{0} 1 / 3", Localization.Localize("ID_DEBUG_EVENTASSIGNMENTUPDATE"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("Row: Rank", Localization.Localize("ID_STAT_SQUADBEST"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("\t\"FALSE\"");
		ELAIEILHGFG.text = Localization.Localize("ID_GUI_SQUADRANKUP");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 850f, 1372f, 137);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 231f, 1685f, -50);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("Days_Since_Install", array);
	}

	public void AFHMOPJGNBM()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-193)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_ACTIVATEXMOREINSTANTBATTLES", Localization.Localize("ID_GETAREWARD1"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("LevelRewards", Localization.Localize("ID_READYTIME"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ticketsSpent");
		ELAIEILHGFG.text = Localization.Localize("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 695f, 1316f, -118);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1395f, 1476f, -37);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("ActivateBonusResultRPC", array);
	}

	public void IGPOLIPPGBP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_LootboxRewardChance).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_ARENARULES_UNLIMITEDAMMO", Localization.Localize("ID_NA"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("EventDefinition", Localization.Localize("GameController.Awake START"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Current unit is not delivering at the moment!!!");
		ELAIEILHGFG.text = Localization.Localize("Card_1_Played");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 487f, 1389f, -187);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 115f, 323f, -8);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("WarCard {0}", array);
	}

	public void KOABMGAPCKP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-125)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_GUI_FOLLOWTWITTER_DESC", Localization.Localize("GameControllerCampaign.StartGame START"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("registerCustomProfileNumber", Localization.Localize("{0} {1}"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Record Monetization Event");
		ELAIEILHGFG.text = Localization.Localize("smallThumbnailBig");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 962f, 1957f, 144);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 788f, 695f, -81);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("RefillRPC", array);
	}

	public void AOAMOJHIAMN()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SecondRenameGoldCost).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Items", Localization.Localize("105 STAGE 1 COVER 2"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ShowAdForZoneID", Localization.Localize("ID_SKILLSHOTHINT_COVERED"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("N");
		ELAIEILHGFG.text = Localization.Localize("Custom date = ");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1373f, 924f, 175);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 664f, 1892f, 74);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("Submited: \"{0}\" for player: \"{1}\" rank:{2} AP:{3} and my rank:{4} AP:{5}. Match duration: {6}", array);
	}

	public void CFIAHPMMJOE()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-23)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("BatchSizeMax", Localization.Localize("Buy_Rental_Army_Unit"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("VipReward2", Localization.Localize("ID_CONFIRM_SQUADALREADYEXISTS"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize(", ");
		ELAIEILHGFG.text = Localization.Localize("Amount");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 312f, 237f, 38);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 693f, 788f, 80);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("reloadTime", array);
	}

	public void FANFNOPNGBL()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Going generate units", Localization.Localize("0.#"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ID_ARENARARITY", Localization.Localize("damage"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("()Landroid/content/Context;");
		ELAIEILHGFG.text = Localization.Localize("rateAppShownCounter");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1705f, 1311f, -15);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1797f, 1133f, -52);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("DailyMissionsCompletionRewardScraps", array);
	}

	public void ANMJHOFBIAI()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackMaxRarityCardsType).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_SALEPERCENTLINE", Localization.Localize("ID_NEWLOOTBOXINBATTLES"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ID_TUTORIAL_UPGRADEWEAPON_3", Localization.Localize("DailyMissionsCompletionRewardCards"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("1.0");
		ELAIEILHGFG.text = Localization.Localize("Sessions");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1598f, 489f, -69);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 2f, 678f, -98);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("Mission_Type", array);
	}

	public void FJLJLDNCBBD()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("WarArenaData", Localization.Localize("gcID"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("Landroid/os/Parcelable$Creator;", Localization.Localize(", [data],"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ID_GUI_EQUIP");
		ELAIEILHGFG.text = Localization.Localize(" TOTAL ALLOCATED: ");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1720f, 1384f, -132);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1646f, 1756f, -88);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("SetFractionRPC", array);
	}

	public void JMLMMFOCKCN()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-198)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("CA", Localization.Localize("ID_ARENARULES_NOOVERTIME"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("tickets", Localization.Localize("menu-sidetab-bg-box-button-gold"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("예");
		ELAIEILHGFG.text = Localization.Localize("veteranpack");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 809f, 112f, 177);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 306f, 904f, 29);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("getExperimentName", array);
	}

	public void IACEOEJFEEM()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward4).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("DeliveryTime", Localization.Localize(" was BuyAndActivated."), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("\n\nDEBUG STATE: ", Localization.Localize("INVALID_ACCOUNT"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Wave Out of range. #DAN#");
		ELAIEILHGFG.text = Localization.Localize("Amount");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 610f, 144f, -154);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 426f, 1305f, 116);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("LogId", array);
	}

	public void BGFKBPMPJIL()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("[-]", Localization.Localize("Total_Battles"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ID_CONFIRM_ERROR", Localization.Localize("Load assetBundle which is not cached !!!: "), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Memory_warnings");
		ELAIEILHGFG.text = Localization.Localize("Experience");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1115f, 578f, 58);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1934f, 1628f, -46);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("WFX_MF", array);
	}

	public void PPLIBOAJOCA()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ShieldRepairTime).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Different squads \"{0}\" and \"{1}\"\n", Localization.Localize("is-IS"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ID_SQUADEVENT", Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_7"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("SoldierHP");
		ELAIEILHGFG.text = Localization.Localize("RweardModifierXP");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 568f, 715f, 133);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 733f, 40f);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("addFriend", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}

	public void FPPLMOLHGFD()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRepairTime).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("StepId", Localization.Localize("customDouble"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("N", Localization.Localize("ID_ARENAREWARD_WARBUCKS"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ID_UPGRADE");
		ELAIEILHGFG.text = Localization.Localize("HeroicPoints");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1006f, 748f, -183);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 228f, 1742f, -69);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("StarterPackDays", array);
	}

	public void MFMJPBCIHEH()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseScrapsMax).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("isInLeague", Localization.Localize("Player was removed from db!"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("MessageId", Localization.Localize("java.util.HashMap"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("throw_grenade_left");
		ELAIEILHGFG.text = Localization.Localize("warfriends-staging.eu-west-1.elasticbeanstalk.com/");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 940f, 1505f, 197);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 99f, 1930f, 3);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("ID_GUI_BRONZE", array);
	}

	public void Initialize()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ID_MOREXP");
		ELAIEILHGFG.text = Localization.Localize("ID_XP");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 50f, 15f, 137);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 84f, 15f, 124);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("ID_VIP_BENEFITS2", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}

	public void MFFEFILOKMG()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseScrapsMax).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("gold7daily1", Localization.Localize("menu-gold"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("something is wrong - time == 0", Localization.Localize("\t\"FALSE\""), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Fuseboxx: Show offer for zone ");
		ELAIEILHGFG.text = Localization.Localize("Parts");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 827f, 576f, -138);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 482f, 145f, -86);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("SquadIcon", array);
	}

	public void ACJCGDPGNAN()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.LapsedPlayerInterval1).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_TUTORIAL_UPGRADEWEAPON_6", Localization.Localize("Pings: ConnectToNameServer"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("realShotProbability", Localization.Localize("ID_STARTERPACKINFORMATIONS"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("weapons");
		ELAIEILHGFG.text = Localization.Localize(" OK!");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 940f, 1980f, 56);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1350f, 1620f, 126);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("can't find price for: ", array);
	}

	public void PONFOKHPMMO()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-1)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("BeAdvisedPurchaseVIP", Localization.Localize("{0}{1}/{2}{3}"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("-1", Localization.Localize("CheckResources () for "), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("LLCCAALEHGN");
		ELAIEILHGFG.text = Localization.Localize("ID_FEATURE_RATE-FANCY");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 228f, 350f, -120);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1450f, 326f, 25);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("Stats", array);
	}

	public void MBOFPLGHGLP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-84)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Error message sent to server, database action: ", Localization.Localize("Start"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("testingideventtierreward", Localization.Localize("S"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("WarCards_Screen");
		ELAIEILHGFG.text = Localization.Localize("DisableData()");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1805f, 1634f, 71);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1771f, 620f, 92);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("ServerResponseHandler.GetConfigurations START", array);
	}

	public void HOAMHAAHEHP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-149)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("roomName", Localization.Localize("ID_LEVEL"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("lapsed_player_2", Localization.Localize("Grenade_Throwing_Tutorial_Duration"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Arena Lives: ");
		ELAIEILHGFG.text = Localization.Localize("blink");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1817f, 586f, -114);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1633f, 493f, -16);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("mortarBuildTime", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}

	public void LMPNFLGMNBG()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMin).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("ID_", Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_3"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("Id", Localization.Localize("ID_GC_LOGOUT_TITLE"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Average_Player_Level");
		ELAIEILHGFG.text = Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 28f, 375f, -87);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1071f, 893f, -106);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("Map was set to: ", array);
	}

	public void KBCFOADCMKF()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GooglePlayLoginReward).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Shots_Fired", Localization.Localize("country-india"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("trial", Localization.Localize("engineer_repair"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Amount");
		ELAIEILHGFG.text = Localization.Localize("maxMapId");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 341f, 675f, 46);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1212f, 1206f, 70);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("LevelName", array);
	}

	public void ONGAIEOAHMA()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_WBRewardChance).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("GetAllSquadMembers - squad {0} - force {1}", Localization.Localize("ID_NOTIFICATION_PLAYERLEAGUEEND"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format(" & ", Localization.Localize("{0}/{1}"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("OtherPlayer");
		ELAIEILHGFG.text = Localization.Localize("SquadLeft");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 577f, 1129f, -37);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1853f, 583f, -46);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("'Day'0", array);
	}

	public void HEGPFIGACED()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-119)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format(")", Localization.Localize("bazooka_uncover_left"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("ID_CONFIRM_NOSQUADACTIONS_TEXT", Localization.Localize("elite"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Yes_Clicked");
		ELAIEILHGFG.text = Localization.Localize(")");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 552f, 1138f, 133);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1506f, 797f, 96);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("try add null pack", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}

	public void NAKAFGAFEPH()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-86)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Android", Localization.Localize("ID_ARENAWILLOPENSOON"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("CZ", Localization.Localize("special"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ID_DEMOTETODIVISION");
		ELAIEILHGFG.text = Localization.Localize("ID_CATEGORY_LOW_SG_MINIGUN");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1890f, 1353f, -65);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1279f, 1037f, 72);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("ID_COOPCANCELED", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}

	public void CKOIIPAGCNO()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SecondRenameGoldCost).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("OnDisconnectedFromPhoton", Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("S", Localization.Localize("ID_MIN"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("AccountType");
		ELAIEILHGFG.text = Localization.Localize("set acces token: ");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 669f, 1000f, -64);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1247f, 1415f, 96);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("MineCards", array);
	}

	public void MPFPHNBAIKD()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastUnitUpgrade).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("LostGameInRow", Localization.Localize("ID_NOREWARD"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("check.php", Localization.Localize("LICENSE_CHECK_FAILED"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("RowIDs");
		ELAIEILHGFG.text = Localization.Localize("0");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 805f, 860f, -159);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1764f, 838f, 56);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("before: critical: ", array);
	}

	public void PPKOJCFEPCB()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.StarterPackRunningOutSeconds).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("game-elite-buff1", Localization.Localize("\n"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("billingNotSupportedEvent: ", Localization.Localize("100+."), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null");
		ELAIEILHGFG.text = Localization.Localize("pt");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 671f, 756f, 82);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1306f, 214f, 44);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("ID_STAT_MISSIONSSOLO", array);
	}

	public void OMGCKCFKDJM()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalUnitProbability).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("registerCustomProfileNumber", Localization.Localize("SquadId"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("GameCenterId", Localization.Localize("#VAVRO# Accept Challenge Message {0}"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ExplodeDamageMax");
		ELAIEILHGFG.text = Localization.Localize("LootboxType");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 482f, 780f, 43);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 368f, 448f, -83);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("sniper_reload", array);
	}

	public void OAMBDKHLJKI()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-189)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("Card withdrawn", Localization.Localize("test_contentType"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("no pack name", Localization.Localize("ダウンロード"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("Internet off: {0} {1}");
		ELAIEILHGFG.text = Localization.Localize("Terms: OnApplicationPause InitTerms");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 398f, 594f, -83);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 707f, 21f, 88);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("CAMOS_DEFAULT", array);
	}

	public void BDMNPDBOCGN()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseTicketsMin).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("?", Localization.Localize("gold"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("PlayTrailRPC", Localization.Localize(", password = "), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("\n");
		ELAIEILHGFG.text = Localization.Localize("ID_SKILLSHOTHINT_ONTHEMOVE");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1494f, 1953f, -164);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1470f, 1680f, -126);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("RETRY", array);
	}

	public void MCONFEEMOLE()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VideoFeedIOSInAppVideo).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("master1", Localization.Localize("{0} {1}"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("313 MENU ENABLE PUSH", Localization.Localize("SquadRank"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("ID_WARNING_BADVERSIONERROR");
		ELAIEILHGFG.text = Localization.Localize("CardManagerData");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 1539f, 907f, -157);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1218f, 1546f, -56);
		UILabel aIHJMMMGGDP = AIHJMMMGGDP;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper();
		aIHJMMMGGDP.text = Localization.LocalizeFormat("colt_shooting_stop", array);
	}

	public void MMKEEBKDKLG()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-59)).FLOATVALUE;
		MILKCHCPMPL.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		ANBOFCEKKMB.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		FLKNHCAEBMM.gameObject.SetActive(isWarcardsLocked);
		DABFBHIDOMM.gameObject.SetActive(isWarcardsLocked);
		BHBJJHLEJEO.gameObject.SetActive(isWarcardsLocked);
		PJJPHFALNKO.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		ENCLEFMHEPB.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			BHBJJHLEJEO.text = string.Format("()I", Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED_TEXT"), LevelManager.instance.warcardsUnlockLevel);
			ENCLEFMHEPB.text = string.Format("0", Localization.Localize("#AccoutCheck# GamecenterChangeDuringTutorial - wrong situation -> do nothing"), LevelManager.instance.warcardsUnlockLevel);
		}
		DFEACGKACCK.text = Localization.Localize("S");
		ELAIEILHGFG.text = Localization.Localize("Player inventory got no slot for ");
		MEJMLNDFDBP.COCBCFKJOJE(DFEACGKACCK, 700f, 1411f, -130);
		MEJMLNDFDBP.COCBCFKJOJE(ELAIEILHGFG, 1706f, 1407f, 71);
		AIHJMMMGGDP.text = Localization.LocalizeFormat("Player promoted - database informations:\nName:{0} Level:{1} SquadId:{2} SquadRank:{3}", MEJMLNDFDBP.PDDBDAMHIAA(fFHHEHHFOKJ).ToUpper());
	}
}
