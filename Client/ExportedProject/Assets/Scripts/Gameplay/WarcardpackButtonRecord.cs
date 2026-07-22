using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class WarcardpackButtonRecord : Core_BaseScript
{
	[FormerlySerializedAs("NMHMLEPEFJN")]
	[Header("Core")]
	public UILabel BIJMEDAOIJK;

	[FormerlySerializedAs("EMNKKIOFLIG")]
	public UILabel JHGBKKBOLDN;

	[FormerlySerializedAs("GIGPNEHMDMP")]
	public UILabel ONEGKCKBKHF;

	[FormerlySerializedAs("CJKPFJDIEDA")]
	public UILabel DAELPBJDPHM;

	[FormerlySerializedAs("COLDMHKKFPB")]
	public UILabel FGOCGMLGOAF;

	[FormerlySerializedAs("DPDENKMKDGN")]
	[Header("-Table")]
	public UITable DELPMOEPIKC;

	[FormerlySerializedAs("PLGFIHIGABB")]
	public UISprite BGPBNIJPOKM;

	[FormerlySerializedAs("HIPMEHHAOAL")]
	public UISprite CODFFPODNEP;

	[FormerlySerializedAs("ILBALNHGGDC")]
	public UILabel DFJKHFGDOBA;

	[FormerlySerializedAs("HGCNKEEBLDO")]
	[Header("-Sale")]
	public GameObject GPLAPCHBAGF;

	[FormerlySerializedAs("LNCMBNNJCND")]
	public UILabel KBBHLLOBFOA;

	[FormerlySerializedAs("MGBHBJEFPAJ")]
	public WinStreakCounter PMADDGEKPPG;

	private NGNPIOOAHEH FOLGHNBEAEL = NGNPIOOAHEH.Bronze;

	public NGNPIOOAHEH warcardPack => FOLGHNBEAEL;

	private void CEMNEMBDHLA()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("metalExplosion");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Experience", array);
			ONEGKCKBKHF.text = string.Format("PlayerWeapons", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Show buy hearth dialog"));
			DAELPBJDPHM.text = string.Format("End Screen - button content - visual notification changed. End Screen active ", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("InAppHandlerIos: purchase was cancellled, "));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[7];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_INTIME", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_SILVERPACK");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[1];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("SquadWarsId", array3);
			ONEGKCKBKHF.text = string.Format("ID_RENTAL_ASSAULTRIFLE", CardManager.instance.silverPackSilverCards, Localization.Localize("await"));
			DAELPBJDPHM.text = string.Format("D2", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("AttributionData"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[0];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ID_IFNUMBEROFPLAYERS", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Gold)
		{
			BIJMEDAOIJK.text = Localization.Localize("pt");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[0];
			array5[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("ID_ARENARULES_PLAYERSMOVEFASTER", array5);
			ONEGKCKBKHF.text = string.Format("ArmyPower", CardManager.instance.goldPackGoldCards, Localization.Localize("StartTime"));
			DAELPBJDPHM.text = string.Format("country-taiwan", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("medals"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[3];
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("Scripts search finished.\n", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 282f, 936f, -192);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1381f, 1066f, -123);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 241f, 496f, 93);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 303f, 416f, 3);
	}

	private void OOGBHKLNEHN()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("On Debug add Goodies");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_RANDOMWARCARDCRAFTINGINPROGRESS", array);
			ONEGKCKBKHF.text = string.Format("Manual_Unit_Spawn", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Buy_VIP_Pack_With_Gold"));
			DAELPBJDPHM.text = string.Format("ID_INSILVER1", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("YES"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[1];
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("seconds", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Starter)
		{
			BIJMEDAOIJK.text = Localization.Localize("FakePlayer");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[1];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("ID_NOTIFICATION_GOLDCRAFT", array3);
			ONEGKCKBKHF.text = string.Format("CheckDisable", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_FACEBOOKLOGOUTLEGALTEXT"));
			DAELPBJDPHM.text = string.Format(".jpg", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Button \"{0}\" has no assigned box collider."));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("1", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower(), null, null, null, null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize(",");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("Name", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("attack", CardManager.instance.goldPackGoldCards, Localization.Localize("generate"));
			DAELPBJDPHM.text = string.Format("RecieveRandomUnitsForHost", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("tuneId     = "));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[2];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("Sessions", array4);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 9f, 479f, -133);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 496f, 1309f, -88);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 147f, 1552f, 37);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 735f, 1453f, 98);
	}

	[SpecialName]
	public NGNPIOOAHEH KLJNAOJLGHM()
	{
		return FOLGHNBEAEL;
	}

	private void FMIDCPENJPG()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1144f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void MMLOAKGDDGF()
	{
		PMADDGEKPPG.GGKCMHOGFPF();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void OCDHLOOGCAF()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	private void LJNAACMGCED()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 501f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void MCFIFGJHFMN()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("League");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_ARENARULES_FASTERRELOADING", array);
			ONEGKCKBKHF.text = string.Format("SyncShield", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Action "));
			DAELPBJDPHM.text = string.Format("ShotFrequencyMax", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_COMPLETED"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[0];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("{0} Empty", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_WARNING_BUDDYCARDNOTREADY");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("ID_GUI_TIMEXPBONUS", array3);
			ONEGKCKBKHF.text = string.Format("com.upsight.mediation.unity.FuseUnitySDK", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_BUDDYCARDHERE"));
			DAELPBJDPHM.text = string.Format("Tickets", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("D2"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[0];
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("getResolution", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("Play_Card_Tutorial_Duration");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[0];
			array5[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("ExtraRewards", array5);
			ONEGKCKBKHF.text = string.Format("nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v", CardManager.instance.goldPackGoldCards, Localization.Localize("WarFriends"));
			DAELPBJDPHM.text = string.Format("GetLockRPC", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize(" succesfully joined squad "));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[7];
			array6[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("flamethrower_idle", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 247f, 933f, -135);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1f, 402f, -90);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1683f, 1158f, 137);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1581f, 1474f, 37);
	}

	public void OJLONNEIBLE(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		LADHAGHBHDK();
		DELPMOEPIKC.onReposition = POECDPJIIEO;
	}

	private void ACMJDMAPEFL()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Google2u.DBUpgradeSlotsAssaulter");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ERROR - BAD FORMAT", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("Xp", CardManager.instance.bronzePackBronzeCards, Localization.Localize("withAdvertiserSubCampaign"));
			DAELPBJDPHM.text = string.Format(" ", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("VipRewardForDay"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[2];
			array[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("Bad War Arena Data", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_REQUIREDMINBIG");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array2 = new object[0];
			array2[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Player_Avoided_Grenade_On_First_Try", array2);
			ONEGKCKBKHF.text = string.Format("right", CardManager.instance.silverPackSilverCards, Localization.Localize("monthLenght"));
			DAELPBJDPHM.text = string.Format(", ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("FinishChoosingCardsRPC"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[5];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ID_TUTORIAL_MACHINEGUNNERS_UP", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("AssignmentsIds");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array4 = new object[1];
			array4[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("HH:mm", array4);
			ONEGKCKBKHF.text = string.Format("NextBuddyDeposit", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_TUTORIAL_GRENADETHROW_DOWN"));
			DAELPBJDPHM.text = string.Format("ID_STAT_GRENADELAUNCHERKILLS", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("bronze"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array5 = new object[1];
			array5[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("ID_EMPTYSEARCHPLAYER", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1420f, 1375f, 143);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1314f, 716f, 120);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1717f, 1203f, -113);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1449f, 363f, 96);
	}

	public void FJONDAPGOGE()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-65 - num) / -55));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("ID_INVITATIONDENIED", array);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LOFELBODFFN;
		}
		else
		{
			PMADDGEKPPG.GGKCMHOGFPF();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH NDCHJNHONDL()
	{
		return FOLGHNBEAEL;
	}

	public void SetSaleAndPrize()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (100 - num) / 100));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			PMADDGEKPPG.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = delegate
			{
				GPLAPCHBAGF.SetActive(value: false);
				DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
				DELPMOEPIKC.repositionNow = true;
			};
		}
		else
		{
			PMADDGEKPPG.JCMHGOGNMFO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void JGCMMECGCOE()
	{
		PMADDGEKPPG.JCMHGOGNMFO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void AGIIDABBIAF()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (117 - num) / 33));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("ID_MORTARBUILDTIME", array);
			PMADDGEKPPG.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = PNCDJFEBEML;
		}
		else
		{
			PMADDGEKPPG.BGHNMCPLIPE();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void JKMPCMCAIBP()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	public void EKECENANOBE()
	{
		PMADDGEKPPG.PEHBGMEHFEM();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void LEIFCFAPGCJ()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-22 - num) / -121));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[0] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("\n{0}\n", array);
			PMADDGEKPPG.MIOOAOFMLIE(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = EJKOKAFCHMF;
		}
		else
		{
			PMADDGEKPPG.LOINIDOGNCO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void CLMDBKKAHNP()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1630f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void AAKHNEMCLEE()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void OGOJOKOIBFL()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void EJKOKAFCHMF()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	public void JMNHKBNACBE(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		CFPANHMLPKF();
		DELPMOEPIKC.onReposition = NKDHGKAOFKF;
	}

	public void EIAEMEBHMIN()
	{
		PMADDGEKPPG.GGKCMHOGFPF();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void CCDGDEANNKA()
	{
		PMADDGEKPPG.LOINIDOGNCO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	[SpecialName]
	public NGNPIOOAHEH JIKGHCPBOCG()
	{
		return FOLGHNBEAEL;
	}

	public void JGDMLKMKHCJ(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		LBKLGOPDFGP();
		DELPMOEPIKC.onReposition = MJEMAKPOKOG;
	}

	public void NNKLLLBKPGK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (26 - num) / -4));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("stand_up_crawl", num);
			PMADDGEKPPG.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = JKMPCMCAIBP;
		}
		else
		{
			PMADDGEKPPG.LOINIDOGNCO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void IOKGJJIJCBO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-126 - num) / -121));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("Alias", array);
			PMADDGEKPPG.APFDDFPMACA(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LIECCIHPNNC;
		}
		else
		{
			PMADDGEKPPG.PEHBGMEHFEM();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH BLCLGJFCLHD()
	{
		return FOLGHNBEAEL;
	}

	public void OINLPBNOMPJ()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-125 - num) / 24));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("No Squads Found", num);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = delegate
			{
				GPLAPCHBAGF.SetActive(value: false);
				DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
				DELPMOEPIKC.repositionNow = true;
			};
		}
		else
		{
			PMADDGEKPPG.FCGPLOBEHDL();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void EFACHONJLPL(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		GAEDNOHEEOD();
		DELPMOEPIKC.onReposition = FMIDCPENJPG;
	}

	public void InitControls(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		GEPPOLFAMJK();
		DELPMOEPIKC.onReposition = delegate
		{
			float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 2f;
			DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
		};
	}

	[SpecialName]
	public NGNPIOOAHEH OPDJCGDDGLI()
	{
		return FOLGHNBEAEL;
	}

	private void MJEMAKPOKOG()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 529f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void OPAOAGLCKGC()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-110 - num) / -104));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[0] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("Starter_Assignment_Completed", array);
			PMADDGEKPPG.MIOOAOFMLIE(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = CPFDKKKGJOF;
		}
		else
		{
			PMADDGEKPPG.LOINIDOGNCO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void IAPAJIHNKJO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-101 - num) / 108));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[0] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("ID_CONFIRM_GAMEDOESNOTEXIST", array);
			PMADDGEKPPG.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = HDMCLCCDHCN;
		}
		else
		{
			PMADDGEKPPG.LOINIDOGNCO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH PIJJANCGJIO()
	{
		return FOLGHNBEAEL;
	}

	public void PIBGCFEHANG()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (75 - num) / -77));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("ID_CONFIRM_NOSUCHPACK", array);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LIECCIHPNNC;
		}
		else
		{
			PMADDGEKPPG.PEHBGMEHFEM();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void BGJIFBAANKL()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (46 - num) / -108));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("Clicked buy on ", num);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = IKOGKCBMLFI;
		}
		else
		{
			PMADDGEKPPG.LOINIDOGNCO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH OIBMCPJMNDK()
	{
		return FOLGHNBEAEL;
	}

	private void LMDCGLAIAMC()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("PrepareBotForDeathMatch 0");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Beanstalk: On Send Settings", array);
			ONEGKCKBKHF.text = string.Format("PARCELABLE_WRITE_RETURN_VALUE", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_LOGININDAYS"));
			DAELPBJDPHM.text = string.Format("#Game Rewards# - Squad Points: {0} (after offer mult x{1} on server)", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("MessageType"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("game-elite-buff1", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower(), null, null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("Completed");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array2 = new object[0];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("N1", array2);
			ONEGKCKBKHF.text = string.Format("D2", CardManager.instance.silverPackSilverCards, Localization.Localize("Id"));
			DAELPBJDPHM.text = string.Format("creating special pack: ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_READYTIME"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array3 = new object[7];
			array3[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("6", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("Time-limited Offers");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("退出", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("-", CardManager.instance.goldPackGoldCards, Localization.Localize("eventStart"));
			DAELPBJDPHM.text = string.Format("New FB friend, name = ", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_LOADING"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("com.tune.unityutils.TuneUnityDeeplinkListener", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1238f, 778f, 7);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1179f, 940f, -44);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 592f, 362f, -140);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 425f, 937f, -195);
	}

	public void DHJECBGBIGO()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (95 - num) / -52));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("GetVGOfferInfoForZone", array);
			PMADDGEKPPG.MIOOAOFMLIE(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = AAKHNEMCLEE;
		}
		else
		{
			PMADDGEKPPG.PEHBGMEHFEM();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void JNOELIDIGNA()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1091f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void OBCGMBBGKNK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (114 - num) / 61));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("Getting null texture materialTetxureRed", array);
			PMADDGEKPPG.APFDDFPMACA(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = OCDHLOOGCAF;
		}
		else
		{
			PMADDGEKPPG.PEHBGMEHFEM();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void EEFEFOHKIBF()
	{
		PMADDGEKPPG.JCMHGOGNMFO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void PHKPCKAKACK()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1923f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void OCFOEGJBNCH(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		ACMJDMAPEFL();
		DELPMOEPIKC.onReposition = PHKPCKAKACK;
	}

	private void ADGJFAALCFB()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1284f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void PFEOBECCMHB()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1658f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void PEDLMCEDDJM()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	private void CPFDKKKGJOF()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	private void AOFKPEOFONL()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Action ");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("[.,]*", array);
			ONEGKCKBKHF.text = string.Format("SpecialFeature", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_INVITATIONDENIED"));
			DAELPBJDPHM.text = string.Format("discount", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("\""));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[0];
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("getCurrentVariantId", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_ZEROSECONDS");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[1];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("init", array3);
			ONEGKCKBKHF.text = string.Format("-", CardManager.instance.silverPackSilverCards, Localization.Localize("-"));
			DAELPBJDPHM.text = string.Format("Excel {0} dont have row Tier!!!", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("GetSkuInfo succeeded but productId "));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[3];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ID_CHANGENAMENOTENOUGHT", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Android");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[0];
			array5[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("206 STAGE 6 GRENADE THROWING", array5);
			ONEGKCKBKHF.text = string.Format("InstantBattleEnded: 3RD REWARD GOLD: ", CardManager.instance.goldPackGoldCards, Localization.Localize("GameLoginManager: Logout from facebook"));
			DAELPBJDPHM.text = string.Format("Found labels with dynamic font in children:\n", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("after update GC still GC account, but no added or missing gcID or gcPassword"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[8];
			array6[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("1", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 318f, 1022f, 55);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1596f, 709f, 149);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 253f, 1442f, 162);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 570f, 1360f, 107);
	}

	public void OAMMJCEIFHA(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		IIAOKCJEKFF();
		DELPMOEPIKC.onReposition = ADGJFAALCFB;
	}

	private void LIDLIBBPIJJ()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	public void JCEMKGHAHNE(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		EBLBEAEHJNI();
		DELPMOEPIKC.onReposition = NGBBHMKFGJB;
	}

	[SpecialName]
	public NGNPIOOAHEH OEPPNJOHDMM()
	{
		return FOLGHNBEAEL;
	}

	public void DoAfterHide()
	{
		PMADDGEKPPG.JCMHGOGNMFO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void AFMPBPGLFMJ(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		GEPPOLFAMJK();
		DELPMOEPIKC.onReposition = EOIKMFLNNEP;
	}

	[SpecialName]
	public NGNPIOOAHEH IGLAJLEHNPK()
	{
		return FOLGHNBEAEL;
	}

	private void FKBBMEAFOBN()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	public void EOCHFFNODIM()
	{
		PMADDGEKPPG.BGHNMCPLIPE();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void EAFCKJDPMDF()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("Result");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[1];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Title", array);
			ONEGKCKBKHF.text = string.Format("ID_INTIME", CardManager.instance.bronzePackBronzeCards, Localization.Localize("-[^-]*$"));
			DAELPBJDPHM.text = string.Format("ID_CONFIRM_ERROR", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_READYTIME"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[8];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("WarFriends", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Starter)
		{
			BIJMEDAOIJK.text = Localization.Localize("EventId");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat(", squadId = ", array3);
			ONEGKCKBKHF.text = string.Format("ID_LEAGUEREWARDHINT2", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_ARENARULES_SLOWERRELOADING"));
			DAELPBJDPHM.text = string.Format("Delete QuickPlay Data", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("BattleId"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ArmyPower", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower(), null, null);
		}
		else if (FOLGHNBEAEL == (NGNPIOOAHEH)8)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_POSITIONXY");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("-veteran", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("minigun_idle", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_EARNMORE"));
			DAELPBJDPHM.text = string.Format("LootboxType", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_CONFIRM_STARTOVER"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("Lcom/google/android/gms/games/event/Events;", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 929f, 956f, 194);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1807f, 1249f, -168);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 779f, 1710f, -64);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 188f, 403f, 175);
	}

	public void DFAMJIFGKHL()
	{
		PMADDGEKPPG.BGHNMCPLIPE();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void EKHPHMMMLDL()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	private void BLDKFHAEIJD()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_CONTAINSXWARCARDS");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[1];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("\t\"FALSE\"", array);
			ONEGKCKBKHF.text = string.Format("Lootbox id /{0}/ bought for /{1}/ gold", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_READYTIME"));
			DAELPBJDPHM.text = string.Format("IosReceipt", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("DK"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("Stats for lobby {0}, matches {1} time {2}", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower(), null, null, null, null, null, null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array2 = new object[1];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("GoldBase", array2);
			ONEGKCKBKHF.text = string.Format("gold", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_XOFPLAYERSGETSPROMOTED"));
			DAELPBJDPHM.text = string.Format("Buy_Army_Unit_At_Rank_Gold", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("108 STAGE 2 KILLED 2. SOLDIER"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array3 = new object[0];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("menu-assignments-type-deploy", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_WARNING_ALREADYCRAFTING");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array4 = new object[0];
			array4[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("{0} {1}/{2} {3}", array4);
			ONEGKCKBKHF.text = string.Format("menu-info-close-ico", CardManager.instance.goldPackGoldCards, Localization.Localize("RemovedCards"));
			DAELPBJDPHM.text = string.Format("ID_NOTCOMPATIBLEWITH", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("Player visual Error: id not find: "));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array5 = new object[0];
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("#Google play# gpgs logout during tutorial - ignore", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1f, 1732f, 131);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1268f, 822f, -90);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1916f, 1312f, 15);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1960f, 1773f, 111);
	}

	public void LIJFFGBNJPG()
	{
		PMADDGEKPPG.KEIIENDMKLN();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void IIAOKCJEKFF()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("Icon");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("OK", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("id: ", CardManager.instance.bronzePackBronzeCards, Localization.Localize("mortarBuildTime"));
			DAELPBJDPHM.text = string.Format("#PETER# removing warcards from slots", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("goldPrefix"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[6];
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_GUI_BRONZE", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("discount");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array2 = new object[0];
			array2[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Current unit is not delivered at the moment!!!", array2);
			ONEGKCKBKHF.text = string.Format("Rule {0:D2}", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_STAT_UNITSPURCHASED"));
			DAELPBJDPHM.text = string.Format("\"", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("AdWillClose()"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[0];
			array3[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("tc", array3);
		}
		else if (FOLGHNBEAEL == (NGNPIOOAHEH)8)
		{
			BIJMEDAOIJK.text = Localization.Localize("TimeStamp");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array4 = new object[0];
			array4[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat(",", array4);
			ONEGKCKBKHF.text = string.Format("Level", CardManager.instance.goldPackGoldCards, Localization.Localize(","));
			DAELPBJDPHM.text = string.Format("PlaySparks", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_WARSHOP_GOLD"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array5 = new object[2];
			array5[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("ID_NOTIFICATION_LAPSED_VIP", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 297f, 1410f, 18);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1687f, 1565f, -3);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1297f, 448f, -200);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1911f, 1369f, 91);
	}

	private void LCMFJBDBDAA()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void NKDHGKAOFKF()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1265f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void BHADJPEPODO()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 809f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void LIECCIHPNNC()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	[SpecialName]
	public NGNPIOOAHEH DLCNKPEPBKH()
	{
		return FOLGHNBEAEL;
	}

	private void MCNMFDKAPBD()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Kills");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("ID_TUTORIAL_DELIVERED_WEAPON", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_MAXSTAT"));
			DAELPBJDPHM.text = string.Format("menu-sidetab-player-kick", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("LEADERBOARDS - showing "));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[0];
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_LOADING", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Gold)
		{
			BIJMEDAOIJK.text = Localization.Localize("HP");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array2 = new object[0];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT", array2);
			ONEGKCKBKHF.text = string.Format("metalExplosion", CardManager.instance.silverPackSilverCards, Localization.Localize("N0"));
			DAELPBJDPHM.text = string.Format("SquadRank", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("SoldierHP"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[8];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("weaponDelivery", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("menu-assignments-type-kill");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("right", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("com/google/android/gms/games/Games", CardManager.instance.goldPackGoldCards, Localization.Localize("You are already our follower, thank you! That's great, isn’t it?"));
			DAELPBJDPHM.text = string.Format("ID_YOUNEEDMONEYTODELIVERSPECIAL", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_COMPLETED"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("100+.", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null, null, null, null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 222f, 1085f, 187);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 190f, 880f, 28);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1212f, 219f, -70);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1567f, 1814f, -118);
	}

	private void BKPAPKIOAKL()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_WARNING_ACCOUNTALREADYCREATED");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("bazooka_idle", array);
			ONEGKCKBKHF.text = string.Format("ID_WARNING_CONNECTIONERROR_TEXT", CardManager.instance.bronzePackBronzeCards, Localization.Localize("{0} {1}{2}"));
			DAELPBJDPHM.text = string.Format("universal", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ArmyPower"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[6];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("312 MENU CONNECT FB", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("^\\D*");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("dailyRewardData", array3);
			ONEGKCKBKHF.text = string.Format("Total_Warbucks_Earned", CardManager.instance.silverPackSilverCards, Localization.Localize("menu-button-oneside"));
			DAELPBJDPHM.text = string.Format("com.tune.TuneLocation", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_SELECTTWOUNITS"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("0", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower(), null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("Ignore_Text_{0}{1}_Dont_Ask_Again");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array4 = new object[0];
			array4[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("ID_CONFIRM_JOININGSAMESQUAD", array4);
			ONEGKCKBKHF.text = string.Format("S", CardManager.instance.goldPackGoldCards, Localization.Localize("Reported"));
			DAELPBJDPHM.text = string.Format("ID_ARENARULES_NORELOADING", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_READYTIME"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array5 = new object[8];
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ID_INMASTER2", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 283f, 208f, -34);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 639f, 742f, 81);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1851f, 59f, 2);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 406f, 1817f, 96);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 2f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void LOFELBODFFN()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	public void FIALPJINCAI()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-67 - num) / -6));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("game-card-ico-swiftimmortality", num);
			PMADDGEKPPG.FPNEIICLJFG(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LOFELBODFFN;
		}
		else
		{
			PMADDGEKPPG.GGKCMHOGFPF();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH ONFFAGHCGGD()
	{
		return FOLGHNBEAEL;
	}

	[CompilerGenerated]
	private void NNAMCANEBJB()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	public void NFJEGBLCFLM()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (39 - num) / -6));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("Exception while processing received sheets: ", array);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LIDLIBBPIJJ;
		}
		else
		{
			PMADDGEKPPG.GGKCMHOGFPF();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void GOIMFAPNEGB()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("RequiredMedals");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("FinishGameMultiplayerRPC", array);
			ONEGKCKBKHF.text = string.Format("+0", CardManager.instance.bronzePackBronzeCards, Localization.Localize("experiment type is "));
			DAELPBJDPHM.text = string.Format("finish", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("AssignmentData"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[5];
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_COMPLETED", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_GOLDPACK");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("discount", array3);
			ONEGKCKBKHF.text = string.Format("AdminName", CardManager.instance.silverPackSilverCards, Localization.Localize("GetActualIndex()\nCurPosX: {0}"));
			DAELPBJDPHM.text = string.Format("\"", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Card_1_Played"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower(), null, null, null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("Error while parsing response from GetConfigurations, will try again next run");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array4 = new object[0];
			array4[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("-{0}-{1}", array4);
			ONEGKCKBKHF.text = string.Format("S", CardManager.instance.goldPackGoldCards, Localization.Localize("ABOUT TO SHOW DAILY REWARD "));
			DAELPBJDPHM.text = string.Format("response= ", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("For {0} - {1} are objects in different Z\n{2} in {3} and {4} in {5}"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("Chat: Channels ", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null, null, null, null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 701f, 1515f, -50);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1277f, 783f, 28);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 975f, 1860f, -1);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1597f, 1672f, -35);
	}

	public void HEBANLOKBFG()
	{
		PMADDGEKPPG.LOINIDOGNCO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void APKGKCPOLKN()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-5 - num) / -101));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("Card_1_Played", array);
			PMADDGEKPPG.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = AAKHNEMCLEE;
		}
		else
		{
			PMADDGEKPPG.BGHNMCPLIPE();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void OJLHHHDIADB()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Overtime_Was_Already_Explained");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("globalSquadLeaderboard", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("Battle", CardManager.instance.bronzePackBronzeCards, Localization.Localize("LootBoxOpen"));
			DAELPBJDPHM.text = string.Format("ID_PHASEX", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("N"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower(), null);
		}
		else if (FOLGHNBEAEL == (NGNPIOOAHEH)8)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-COOP");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("#AccoutCheck# possibly change GC during tutorial", array);
			ONEGKCKBKHF.text = string.Format("menu-warbucks", CardManager.instance.silverPackSilverCards, Localization.Localize("bronze"));
			DAELPBJDPHM.text = string.Format("InAppHandlerIos: Validating inapp on server... inappId = ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_ARENARULES_RANDOMWARCARDS"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("0", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower(), null);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array2 = new object[1];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat(" ", array2);
			ONEGKCKBKHF.text = string.Format("Saved_data.csv", CardManager.instance.goldPackGoldCards, Localization.Localize("ALL: \n"));
			DAELPBJDPHM.text = string.Format("ID_UNITTYPE4", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("VipRewardForDay"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array3 = new object[5];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_GETFORREWARD2", array3);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 961f, 1772f, 49);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1604f, 303f, 196);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 638f, 1994f, -42);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1619f, 388f, 141);
	}

	private void BFFNJIIEFHK()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_CONFIRM_NOTFORQUESTACCOUNTS");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("    ", array);
			ONEGKCKBKHF.text = string.Format("ArmyUnitId", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Deploys_Count"));
			DAELPBJDPHM.text = string.Format("#DANIEL# Everyplay IsRecordingSupported: ", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("Card_1_Played"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[7];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_INBRONZE2", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_GUI_SQUADLEVELEDUP_NOINCR");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("subscription", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("Beanstalk: ", CardManager.instance.silverPackSilverCards, Localization.Localize("Beanstalk: Invalid Token - "));
			DAELPBJDPHM.text = string.Format(")", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Found labels with original font in children:\n"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[2];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("Hide poison", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("はい");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array4 = new object[1];
			array4[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("Logs sent to server\nWaiting for response", array4);
			ONEGKCKBKHF.text = string.Format("RecentVideos", CardManager.instance.goldPackGoldCards, Localization.Localize("-"));
			DAELPBJDPHM.text = string.Format("ID_ARENARULES_BUDDYWARCARDS", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("MissionData"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array5 = new object[1];
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("Medals", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1814f, 1906f, -101);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 53f, 1435f, -76);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 223f, 1772f, 69);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 209f, 1583f, 165);
	}

	private void LABHCHBNELJ()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	public void HECOPILOEJG()
	{
		PMADDGEKPPG.GGKCMHOGFPF();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void LKBEDFIIGIK()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("\n\nDEBUG STATE: ");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_ARENARULES_NORELOADING", array);
			ONEGKCKBKHF.text = string.Format("loadPlayerStats", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_AWESOME"));
			DAELPBJDPHM.text = string.Format("ID_GUI_SQUADKICK", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_IFNUMBEROSQUADSINASQUADWAR"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[7];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("WarFriends requires permission to access your media storage in order to download critical game data.Please accept the permission dialog which follows, we will never use this permission for any other purpose.", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Starter)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_GUI_SQUADDEMOTION");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_LEAGUE7", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("damage", CardManager.instance.silverPackSilverCards, Localization.Localize("On server"));
			DAELPBJDPHM.text = string.Format("ID_CONFIRM_UNKNOWNREASON", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Tutorial_Step_Complete"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[4];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("CANCELED", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("Warbucks");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("GameGold", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("{0} {1}", CardManager.instance.goldPackGoldCards, Localization.Localize("PrepareBotForDeathMatch 9"));
			DAELPBJDPHM.text = string.Format("6519f781-1ea7-421f-85d0-c9bb516e923d", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_SKILLSHOTHINT_SLOWMOTIONKILL"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("Awake called: ", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 954f, 1712f, -104);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1060f, 1708f, -120);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1775f, 630f, -85);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1500f, 955f, 11);
	}

	public void MOPAOJFCOGP()
	{
		PMADDGEKPPG.FCGPLOBEHDL();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void NGBBHMKFGJB()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 204f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void JCOILGHDPHA()
	{
		PMADDGEKPPG.FCGPLOBEHDL();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void MHIGAEFCIAF()
	{
		PMADDGEKPPG.FCGPLOBEHDL();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void LIFLEEGJFFN()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 280f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void ABLGHAECEHD(NGNPIOOAHEH IHFNCPHJHCK)
	{
		FOLGHNBEAEL = IHFNCPHJHCK;
		OJLHHHDIADB();
		DELPMOEPIKC.onReposition = ADGJFAALCFB;
	}

	public void BKNJHLKMFKE()
	{
		PMADDGEKPPG.LOINIDOGNCO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void GJICELCFFCF()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void EOIKMFLNNEP()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 329f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void EBLBEAEHJNI()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("WBTransactionAmount");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_GUI_REPORTABUSE_LISTITEM0", array);
			ONEGKCKBKHF.text = string.Format("Automatic_Equip", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_WARNING_BADVERSIONERROR"));
			DAELPBJDPHM.text = string.Format("S", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_CATEGORY_LOW_PL_SPECIAL"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[7];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("Cards_Owned_Bronze", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("\n");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("clipSize", array3);
			ONEGKCKBKHF.text = string.Format("Local", CardManager.instance.silverPackSilverCards, Localization.Localize("withAttribute2"));
			DAELPBJDPHM.text = string.Format("com/google/android/gms/common/api/Status", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("setGoogleUserId"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[5];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ru", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("com/google/android/gms/common/ConnectionResult");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[0];
			array5[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("http://a4.mzstatic.com/eu/r30/Purple111/v4/30/72/db/3072db24-2849-d8a8-cdf4-739c12e46a00/screen520x924.jpeg", array5);
			ONEGKCKBKHF.text = string.Format("HEAVYTURRET", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_GC_LOGOUT_TITLE"));
			DAELPBJDPHM.text = string.Format("ID_UNITCOMBINATIONSAVED", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("colt_shooting_start"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[6];
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("ID_CONFIRM_LOGGEDOUT_TEXT", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1212f, 1175f, -126);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1175f, 1227f, 41);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1366f, 209f, 61);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1807f, 322f, -109);
	}

	public void GHCIGJCIPAA()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-21 - num) / 64));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("menu-assignments-type-win", array);
			PMADDGEKPPG.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = LABHCHBNELJ;
		}
		else
		{
			PMADDGEKPPG.FCGPLOBEHDL();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void MJMCCNFLKFP()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1801f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void GMFAMOINIPH()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1015f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void KCMPMBNMBLI()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("D2");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("game-card-gold", array);
			ONEGKCKBKHF.text = string.Format("ID_BATTLEWINBONUSFALLSTO", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_NA"));
			DAELPBJDPHM.text = string.Format("variant letter is ", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("LocalPersistenceHandle"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[5];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("D2", array2);
		}
		else if (FOLGHNBEAEL == (NGNPIOOAHEH)8)
		{
			BIJMEDAOIJK.text = Localization.Localize("DOWNLOADBTN");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("Localization", array3);
			ONEGKCKBKHF.text = string.Format("MissionType", CardManager.instance.silverPackSilverCards, Localization.Localize("getCustomProfileGeolocation"));
			DAELPBJDPHM.text = string.Format("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Chat: Connected - Subscribe to: "));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[8];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("temp_facebook_user_id", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Starter)
		{
			BIJMEDAOIJK.text = Localization.Localize("-.*$");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[0];
			array5[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat("ID_DAILYWINTERASSIGNMENT", array5);
			ONEGKCKBKHF.text = string.Format("subitem1", CardManager.instance.goldPackGoldCards, Localization.Localize("Already loading player data, wait"));
			DAELPBJDPHM.text = string.Format("ID_READYTIME", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ArmyPower"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[8];
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("{0} {1}{2}", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 632f, 894f, 80);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1158f, 1464f, -174);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1193f, 1374f, -148);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1131f, 1863f, 67);
	}

	public void KICJHALCOOM()
	{
		PMADDGEKPPG.LOINIDOGNCO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void CAJPNCELIJA()
	{
		PMADDGEKPPG.FCGPLOBEHDL();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	public void HCEKIGAIGOL()
	{
		PMADDGEKPPG.GGKCMHOGFPF();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void FHFICKKJHPL()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("ExplodeDamageMin");
			JHGBKKBOLDN.text = Localization.LocalizeFormat(", dictionary= ", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("was:{0} is:{1} removed:{2}", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Manual_Unit_Spawn"));
			DAELPBJDPHM.text = string.Format("ID_GOLDC", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("menu-assignments-type-cards"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[4];
			array[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("veteranpack4", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.ThreeCards)
		{
			BIJMEDAOIJK.text = Localization.Localize("JP");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array2 = new object[1];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT", array2);
			ONEGKCKBKHF.text = string.Format("Daily", CardManager.instance.silverPackSilverCards, Localization.Localize("Name"));
			DAELPBJDPHM.text = string.Format("On Test = ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_JOINSQUADDESCRIPTION2"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[3];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ID_NO", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("1");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array4 = new object[0];
			array4[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("_Color", array4);
			ONEGKCKBKHF.text = string.Format("$10-$20", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_VIDEOREADY1"));
			DAELPBJDPHM.text = string.Format("myLobby", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_SLOTUPGRADE_HEAT"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array5 = new object[5];
			array5[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array5[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("212 MENU LEVEL UP SHOWN", array5);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1520f, 637f, -97);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 232f, 873f, -110);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1099f, 1542f, -10);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1366f, 1316f, 27);
	}

	private void CIOBFNMGHFJ()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("country-belarus");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[1];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("Checker", array);
			ONEGKCKBKHF.text = string.Format("ID_CONFIRM_ERROR", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Play_Card_Tutorial_Duration"));
			DAELPBJDPHM.text = string.Format("Winstreak", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("Squad: {0}  SquadPoints: {1}  Reputations: {2}  SquadRank: {3}"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[0];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("Still waiting for server\nBe patient :-)", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("shop");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[1];
			array3[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("PushNotificationDialog {0}", array3);
			ONEGKCKBKHF.text = string.Format("Predefined_Assignment_Completed", CardManager.instance.silverPackSilverCards, Localization.Localize("_Existing_User"));
			DAELPBJDPHM.text = string.Format(" TOTAL ALLOCATED: ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("Value2"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[1];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("GameReward", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.None)
		{
			BIJMEDAOIJK.text = Localization.Localize("Sessions");
			UILabel jHGBKKBOLDN3 = JHGBKKBOLDN;
			object[] array5 = new object[1];
			array5[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN3.text = Localization.LocalizeFormat(")", array5);
			ONEGKCKBKHF.text = string.Format("IsLocal", CardManager.instance.goldPackGoldCards, Localization.Localize("FuseBox Event Level Up for level {0}"));
			DAELPBJDPHM.text = string.Format("game-card-ico-bg-gold", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_GC_LOGOUT_TEXT"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array6 = new object[6];
			array6[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array6[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("shotPoison", array6);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1317f, 1075f, 104);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 487f, 1519f, 171);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 240f, 1877f, -149);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 334f, 82f, -28);
	}

	public void EKEPDPHMDGA()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (62 - num) / 117));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 1);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			KBBHLLOBFOA.text = Localization.LocalizeFormat("queryInventoryFailedEvent: ", num);
			PMADDGEKPPG.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = EKHPHMMMLDL;
		}
		else
		{
			PMADDGEKPPG.JCMHGOGNMFO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void DFJLADAADAC()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void LNIHHJAIENK()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void GAEDNOHEEOD()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("GooglePlayName");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CATEGORY_SHOTGUN", array);
			ONEGKCKBKHF.text = string.Format("_FrustumCornersWS", CardManager.instance.bronzePackBronzeCards, Localization.Localize("This unit cannot be showned, because it has not implemented elite buff."));
			DAELPBJDPHM.text = string.Format("{0}S", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("game-card-ico-disarmed"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[1];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("ID_GOOGLEPLAYUSER", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("SHOWING WARS EVALUATION ");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_DEPLOYEDSOLDIERS", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("VIP-SALE-ALL;WEAPON-EXPLOSIVE-SALE", CardManager.instance.silverPackSilverCards, Localization.Localize(", databaseType= "));
			DAELPBJDPHM.text = string.Format("Error Deserializing JSON for ", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("下載"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[0];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("WarBucks", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Money)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_CONFIRM_ERROR");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("GameLaunch", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format(" mSpriteName:", CardManager.instance.goldPackGoldCards, Localization.Localize("USPECH POKUSU O LOGIN NA FB!!!"));
			DAELPBJDPHM.text = string.Format("OnConnectionFailed: ", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("Returning {0} isGoodPing: {1}"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array4 = new object[2];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("idle", array4);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 73f, 102f, -21);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1338f, 726f, -162);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1085f, 1497f, 72);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 247f, 109f, 4);
	}

	private void CFPANHMLPKF()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_7");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_HOU", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("SessionStartReceived()", CardManager.instance.bronzePackBronzeCards, Localization.Localize("{0} Summary"));
			DAELPBJDPHM.text = string.Format("ID_GETITCHEAPERNOW", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_READYTIME"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[1];
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("SuggestedSquad", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("specialOffers");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("Gold Spent ", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("Manual_Unit_Spawn", CardManager.instance.silverPackSilverCards, Localization.Localize("Unit_Upgrade"));
			DAELPBJDPHM.text = string.Format("videoAdRewardTimes", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("StatisticsData"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array2 = new object[2];
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("On Get Arena Leaderboards: CNT =  ", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ItemsOwned_Rarity_0");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("3", array3);
			ONEGKCKBKHF.text = string.Format("Total_Warbucks_Earned", CardManager.instance.goldPackGoldCards, Localization.Localize("\""));
			DAELPBJDPHM.text = string.Format("ID_SLOTUPGRADE_ROF", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("Skill"));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array4 = new object[5];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("HH:mm", array4);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 93f, 740f, -148);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1708f, 867f, -157);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1231f, 288f, 53);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1651f, 1972f, 86);
	}

	public void LDBLJDJNJJN()
	{
		PMADDGEKPPG.PEHBGMEHFEM();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	[SpecialName]
	public NGNPIOOAHEH PEPNCFACPGG()
	{
		return FOLGHNBEAEL;
	}

	public void EGDEKEFCPPC()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (77 - num) / -106));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 0);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[0] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("$5-$10", array);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = CPFDKKKGJOF;
		}
		else
		{
			PMADDGEKPPG.JCMHGOGNMFO();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void LMPJHNIMENH()
	{
		PMADDGEKPPG.JCMHGOGNMFO();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void LADHAGHBHDK()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("Take arena life!");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array = new object[0];
			array[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("groundBoxHit", array);
			ONEGKCKBKHF.text = string.Format("ID_CONFIRM_FBLOGINCANCELLED", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_NOTINLEAGUETEXT"));
			DAELPBJDPHM.text = string.Format(",", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("Time_Since_Delivery_Finished"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array2 = new object[0];
			array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array2[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("Tutorial_Step_Complete", array2);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Starter)
		{
			BIJMEDAOIJK.text = Localization.Localize("game-elite-buff3");
			UILabel jHGBKKBOLDN2 = JHGBKKBOLDN;
			object[] array3 = new object[0];
			array3[0] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN2.text = Localization.LocalizeFormat("THANK YOU", array3);
			ONEGKCKBKHF.text = string.Format("ID_FINISHED", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_NOHEROESINPREVIOUSARENA"));
			DAELPBJDPHM.text = string.Format("{0} [616577]/[-] {1}", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_WARNING_SERVERTIMEDOUT"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array4 = new object[4];
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("nextGenerate", array4);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Value)
		{
			BIJMEDAOIJK.text = Localization.Localize("null");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_MYWARCARDS", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("warbucks", CardManager.instance.goldPackGoldCards, Localization.Localize("Null cannot be saved as last customization."));
			DAELPBJDPHM.text = string.Format("game-card-ico-disarmed", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("VipRewardForDay"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("Player disconected 0002", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower(), null, null, null, null, null);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1927f, 56f, -62);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 302f, 808f, 116);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 831f, 964f, -165);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 882f, 1529f, -121);
	}

	public void AGOCMIMIAPE()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (30 - num) / -108));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[0];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("#AccoutCheck# GoogleLoggedIn tutorial - wrong situation -> do nothing", array);
			PMADDGEKPPG.OANDDHKJDOB(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = AAKHNEMCLEE;
		}
		else
		{
			PMADDGEKPPG.BGHNMCPLIPE();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	private void IKOGKCBMLFI()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}

	private void LBKLGOPDFGP()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize(" was BuyAndActivated.");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("VipReward2", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("Vip status changed!", CardManager.instance.bronzePackBronzeCards, Localization.Localize("Play_Card_Tutorial_Duration"));
			DAELPBJDPHM.text = string.Format("ID_CONFIRM_INFO", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("default"));
			UILabel fGOCGMLGOAF = FGOCGMLGOAF;
			object[] array = new object[7];
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower();
			array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower();
			fGOCGMLGOAF.text = Localization.LocalizeFormat("{0}{1}{2} {3}{4}", array);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Value)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_CONFIGURATIONSVERSION");
			UILabel jHGBKKBOLDN = JHGBKKBOLDN;
			object[] array2 = new object[0];
			array2[1] = CardManager.instance.cardsInPack;
			jHGBKKBOLDN.text = Localization.LocalizeFormat("WarFriends", array2);
			ONEGKCKBKHF.text = string.Format("Token", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_RETRY"));
			DAELPBJDPHM.text = string.Format("ID_CONFIRM_LOGGEDOUT", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("BattleRewards"));
			UILabel fGOCGMLGOAF2 = FGOCGMLGOAF;
			object[] array3 = new object[0];
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower();
			array3[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower();
			fGOCGMLGOAF2.text = Localization.LocalizeFormat("ObjectPool", array3);
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("grenade_run");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_FEATURE_AMMO-DESCRIPTION", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("ID_SELECTTWOUNITS", CardManager.instance.goldPackGoldCards, Localization.Localize("country-czech-republic"));
			DAELPBJDPHM.text = string.Format("확인", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("InstantBattleEnded: 3RD REWARD WARBUCKS: "));
			UILabel fGOCGMLGOAF3 = FGOCGMLGOAF;
			object[] array4 = new object[6];
			array4[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower();
			array4[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower();
			fGOCGMLGOAF3.text = Localization.LocalizeFormat("Shots_Fired", array4);
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 1658f, 1698f, 71);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 1384f, 1462f, -127);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 1821f, 1474f, -128);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 1078f, 1961f, 22);
	}

	private void PNCDJFEBEML()
	{
		GPLAPCHBAGF.SetActive(value: true);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	public void JPHEKEILEKK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(FOLGHNBEAEL);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (41 - num) / -66));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = false;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("ID_CONFIRM_SERVERDIDNTRESPONDAFTER", array);
			PMADDGEKPPG.APFDDFPMACA(Singleton<OfferManager>.instance.EIPMGKEGLBK(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = delegate
			{
				GPLAPCHBAGF.SetActive(value: false);
				DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
				DELPMOEPIKC.repositionNow = true;
			};
		}
		else
		{
			PMADDGEKPPG.PEHBGMEHFEM();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	public void MFBOBBCJLOD()
	{
		PMADDGEKPPG.KEIIENDMKLN();
		PMADDGEKPPG.JEMKCLKCOMI = null;
	}

	private void KHKOKOJLDPJ()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = false;
	}

	private void POECDPJIIEO()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DFJKHFGDOBA.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1793f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public NGNPIOOAHEH PNKJKMKCNEB()
	{
		return FOLGHNBEAEL;
	}

	private void GEPPOLFAMJK()
	{
		if (FOLGHNBEAEL == NGNPIOOAHEH.Bronze)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_BRONZEPACK");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("{0} {1}", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_BRONZEWARCARDS"));
			DAELPBJDPHM.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_RANDOMWARCARDS"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.bronzePackMax]).ToLower());
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Silver)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_SILVERPACK");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("{0} {1}", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_SILVERWARCARDS"));
			DAELPBJDPHM.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_RANDOMWARCARDS"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.silverPackMax]).ToLower());
		}
		else if (FOLGHNBEAEL == NGNPIOOAHEH.Gold)
		{
			BIJMEDAOIJK.text = Localization.Localize("ID_GOLDPACK");
			JHGBKKBOLDN.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			ONEGKCKBKHF.text = string.Format("{0} {1}", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_GOLDWARCARDS"));
			DAELPBJDPHM.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_RANDOMWARCARDS"));
			FGOCGMLGOAF.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.HPMPBIEHOGH[CardManager.instance.goldPackMax]).ToLower());
		}
		MEJMLNDFDBP.COCBCFKJOJE(BIJMEDAOIJK, 57f, 28f, 700);
		MEJMLNDFDBP.COCBCFKJOJE(JHGBKKBOLDN, 40f, 30f, 400);
		MEJMLNDFDBP.COCBCFKJOJE(ONEGKCKBKHF, 40f, 30f, 370);
		MEJMLNDFDBP.COCBCFKJOJE(DAELPBJDPHM, 38f, 30f, 370);
	}

	public void CDGBHBMFOAK()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(FOLGHNBEAEL);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(FOLGHNBEAEL);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-10 - num) / 60));
		BGPBNIJPOKM.gameObject.SetActive(num2 > 0);
		CODFFPODNEP.gameObject.SetActive(num3 > 1);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		DELPMOEPIKC.repositionNow = true;
		GPLAPCHBAGF.SetActive(flag);
		if (flag)
		{
			UILabel kBBHLLOBFOA = KBBHLLOBFOA;
			object[] array = new object[1];
			array[1] = num;
			kBBHLLOBFOA.text = Localization.LocalizeFormat("game-card-bronze-big", array);
			PMADDGEKPPG.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(FOLGHNBEAEL));
			PMADDGEKPPG.JEMKCLKCOMI = JKMPCMCAIBP;
		}
		else
		{
			PMADDGEKPPG.FCGPLOBEHDL();
			PMADDGEKPPG.JEMKCLKCOMI = null;
		}
	}

	[SpecialName]
	public NGNPIOOAHEH MIFPKEIKOLC()
	{
		return FOLGHNBEAEL;
	}

	private void HDMCLCCDHCN()
	{
		GPLAPCHBAGF.SetActive(value: false);
		DFJKHFGDOBA.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.CardPackWarbucks(FOLGHNBEAEL) + Singleton<GameVariables>.instance.CardPackGold(FOLGHNBEAEL));
		DELPMOEPIKC.repositionNow = true;
	}
}
