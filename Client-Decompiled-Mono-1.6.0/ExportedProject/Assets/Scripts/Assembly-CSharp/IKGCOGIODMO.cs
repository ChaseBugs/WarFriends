using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class IKGCOGIODMO
{
	private string OPOHIPCELHI;

	private int OPOLOCGAPBF;

	private int BEBCNKHDJDC;

	private int PGOFCHMMCDL;

	private int JOBBHEFODFM;

	private int PFMMAAFOBKL;

	public LevelBehaviour IOIKKIIFOCB
	{
		get
		{
			return LevelManager.instance.Unit(OPOHIPCELHI);
		}
	}

	public int KCAAMHIMKMM
	{
		get
		{
			return OPOLOCGAPBF;
		}
	}

	public int FPMJEDOCJKE
	{
		get
		{
			return BEBCNKHDJDC;
		}
	}

	public int HAFMGCFMCPC
	{
		get
		{
			return PGOFCHMMCDL;
		}
	}

	public int FMCANDNKEKC
	{
		get
		{
			return JOBBHEFODFM;
		}
	}

	public int MDOHMDGAHDD
	{
		get
		{
			return PFMMAAFOBKL;
		}
	}

	public string IJLLICNFGEA
	{
		get
		{
			return OPOHIPCELHI;
		}
	}

	[SpecialName]
	public string EMHBGDMNFAH()
	{
		return OPOHIPCELHI;
	}

	[SpecialName]
	public int MBKFEAGBJJO()
	{
		return JOBBHEFODFM;
	}

	public virtual string HAAAFGHDCHN()
	{
		string text = "VipReward1";
		text += string.Format("PlayerName", OPOHIPCELHI, OPOLOCGAPBF);
		text += string.Format("GameType", BEBCNKHDJDC);
		text += string.Format("ID_NOTIFICATION_LAPSED_MORE", PGOFCHMMCDL);
		text += string.Format("add", JOBBHEFODFM);
		return text + string.Format("isConnecting", PFMMAAFOBKL);
	}

	public void GIFDCHDEBGM()
	{
		IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.currentParts += OPOLOCGAPBF;
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PNHDGLHLNIE();
		}
		Singleton<Wallet>.instance.NFLMMKJBKEJ(BEBCNKHDJDC);
		Singleton<Wallet>.instance.COLJGNLBEII(PGOFCHMMCDL);
		Singleton<Wallet>.instance.AddTickets(JOBBHEFODFM);
		Singleton<Wallet>.instance.AddScraps(PFMMAAFOBKL);
	}

	public void MMOKNNCBNOK()
	{
		UpgradeSlotElite upgradeSlotElite = PGKDAPCACAL().upgradeSlots.upgradeSlotElite;
		upgradeSlotElite.JMNFJMPIODK(upgradeSlotElite.currentParts + OPOLOCGAPBF);
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.KKFKODJHMNK();
		}
		Singleton<Wallet>.instance.EBFKEHKBAFJ(BEBCNKHDJDC);
		Singleton<Wallet>.instance.COLJGNLBEII(PGOFCHMMCDL, false);
		Singleton<Wallet>.instance.OLAOFCJHNEM(JOBBHEFODFM);
		Singleton<Wallet>.instance.AddScraps(PFMMAAFOBKL);
	}

	public virtual string MAJKLAFDDON()
	{
		string text = "S";
		text += string.Format("D3", OPOHIPCELHI, OPOLOCGAPBF);
		text += string.Format(" a: ", BEBCNKHDJDC);
		text += string.Format("registerCustomProfileDate", PGOFCHMMCDL);
		text += string.Format("Squad Buddy Warcard {0}", JOBBHEFODFM);
		return text + string.Format("is-IS", PFMMAAFOBKL);
	}

	[SpecialName]
	public int PPHNAFJKGNK()
	{
		return BEBCNKHDJDC;
	}

	public override string ToString()
	{
		string text = "Arena Lootbox:\n";
		text += string.Format("Unit \"{0}\" elite parts: {1}\n", OPOHIPCELHI, OPOLOCGAPBF);
		text += string.Format("Warbucks: {0}\n", BEBCNKHDJDC);
		text += string.Format("Gold:     {0}\n", PGOFCHMMCDL);
		text += string.Format("Tickets:  {0}\n", JOBBHEFODFM);
		return text + string.Format("Scraps:   {0}\n", PFMMAAFOBKL);
	}

	[SpecialName]
	public LevelBehaviour NNBGMMGBIFJ()
	{
		return LevelManager.instance.Unit(OPOHIPCELHI);
	}

	public IKGCOGIODMO()
	{
		OPOHIPCELHI = "Google2u.DBUpgradeSlotsGrennader";
		OPOLOCGAPBF = 1;
		BEBCNKHDJDC = 1000;
		PGOFCHMMCDL = 0;
		JOBBHEFODFM = 10;
		PFMMAAFOBKL = 100;
		Debug.Log(ToString());
	}

	public void AAIKNHJLNJP()
	{
		UpgradeSlotElite upgradeSlotElite = GNHCMNPHAEI().upgradeSlots.upgradeSlotElite;
		upgradeSlotElite.currentParts = upgradeSlotElite.HMPNFKJHKGG() + OPOLOCGAPBF;
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.NDHFECMKILC();
		}
		Singleton<Wallet>.instance.EBFKEHKBAFJ(BEBCNKHDJDC, false);
		Singleton<Wallet>.instance.BKFOPCDLPCJ(PGOFCHMMCDL, false);
		Singleton<Wallet>.instance.OLAOFCJHNEM(JOBBHEFODFM);
		Singleton<Wallet>.instance.DHIBMBCMBFM(PFMMAAFOBKL);
	}

	[SpecialName]
	public int GJPLMCPMNJG()
	{
		return PFMMAAFOBKL;
	}

	[SpecialName]
	public int NNIAJCDCFPD()
	{
		return BEBCNKHDJDC;
	}

	[SpecialName]
	public int DMEEIAIFMMN()
	{
		return PFMMAAFOBKL;
	}

	[SpecialName]
	public int KAKPEIFFKGN()
	{
		return OPOLOCGAPBF;
	}

	[SpecialName]
	public LevelBehaviour KNNBGNFCPCE()
	{
		return LevelManager.instance.Unit(OPOHIPCELHI);
	}

	[SpecialName]
	public int APIGJHLEKAH()
	{
		return OPOLOCGAPBF;
	}

	[SpecialName]
	public int CJJFGBPHPMJ()
	{
		return JOBBHEFODFM;
	}

	[SpecialName]
	public int NPNANNBHPFK()
	{
		return BEBCNKHDJDC;
	}

	[SpecialName]
	public int CLFKOKOMJLL()
	{
		return JOBBHEFODFM;
	}

	[SpecialName]
	public LevelBehaviour GNHCMNPHAEI()
	{
		return LevelManager.instance.Unit(OPOHIPCELHI);
	}

	public IKGCOGIODMO(JToken FIEPMDJDIEE)
	{
		OPOHIPCELHI = KHJJFPPACBP.BKFCLMMJNHK(FIEPMDJDIEE["ArmyUnitId"], string.Empty);
		OPOLOCGAPBF = KHJJFPPACBP.HNMDPGKPLNK(FIEPMDJDIEE["ArmyUnitParts"]);
		BEBCNKHDJDC = KHJJFPPACBP.HNMDPGKPLNK(FIEPMDJDIEE["WarBucks"]);
		PGOFCHMMCDL = KHJJFPPACBP.HNMDPGKPLNK(FIEPMDJDIEE["Gold"]);
		JOBBHEFODFM = KHJJFPPACBP.HNMDPGKPLNK(FIEPMDJDIEE["Tickets"]);
		PFMMAAFOBKL = KHJJFPPACBP.HNMDPGKPLNK(FIEPMDJDIEE["Scraps"]);
		Debug.Log(ToString());
	}

	public virtual string BICEOOCDGBD()
	{
		string text = "Started delivering |";
		text += string.Format("ONLY EDITOR FEATURE", OPOHIPCELHI, OPOLOCGAPBF);
		text += string.Format("game-kill-overtime", BEBCNKHDJDC);
		text += string.Format("ID_CONFIRM_ERROR", PGOFCHMMCDL);
		text += string.Format("IAPOfferAccepted(", JOBBHEFODFM);
		return text + string.Format("Action ", PFMMAAFOBKL);
	}

	[SpecialName]
	public string AHKAPNDDPGG()
	{
		return OPOHIPCELHI;
	}

	public virtual string OFEOHDIAIJA()
	{
		string text = "throw_grenade_right";
		text += string.Format("173432c2", OPOHIPCELHI, OPOLOCGAPBF);
		text += string.Format("WRONG NUMBER OF ORDER ", BEBCNKHDJDC);
		text += string.Format("ID_GUI_EQUIP", PGOFCHMMCDL);
		text += string.Format("Level", JOBBHEFODFM);
		return text + string.Format(".", PFMMAAFOBKL);
	}

	[SpecialName]
	public int JLHNPLHKFGK()
	{
		return PFMMAAFOBKL;
	}

	[SpecialName]
	public LevelBehaviour PGKDAPCACAL()
	{
		return LevelManager.instance.Unit(OPOHIPCELHI);
	}

	[SpecialName]
	public int PJIHDFPGOEP()
	{
		return JOBBHEFODFM;
	}

	public void ELHDHJKPKFO()
	{
		UpgradeSlotElite upgradeSlotElite = HENOIEKPMOD().upgradeSlots.upgradeSlotElite;
		upgradeSlotElite.currentParts = upgradeSlotElite.HMPNFKJHKGG() + OPOLOCGAPBF;
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.FNDHFKKOCJE();
		}
		Singleton<Wallet>.instance.NFLMMKJBKEJ(BEBCNKHDJDC, false);
		Singleton<Wallet>.instance.COLJGNLBEII(PGOFCHMMCDL, false);
		Singleton<Wallet>.instance.AddTickets(JOBBHEFODFM);
		Singleton<Wallet>.instance.DHIBMBCMBFM(PFMMAAFOBKL);
	}

	[SpecialName]
	public int OOBLBMHIPFB()
	{
		return BEBCNKHDJDC;
	}

	[SpecialName]
	public LevelBehaviour HENOIEKPMOD()
	{
		return LevelManager.instance.Unit(OPOHIPCELHI);
	}

	[SpecialName]
	public int GBOHGDCIEKP()
	{
		return BEBCNKHDJDC;
	}

	[SpecialName]
	public int MEODOGJFBKF()
	{
		return PGOFCHMMCDL;
	}

	[SpecialName]
	public int ONMIIMOFEPJ()
	{
		return PGOFCHMMCDL;
	}

	public void DJDPHLELPEA()
	{
		IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.currentParts += OPOLOCGAPBF;
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP(), true);
			JFNGDDOMPAE.ICCFCMFAKMO();
		}
		Singleton<Wallet>.instance.NFLMMKJBKEJ(BEBCNKHDJDC);
		Singleton<Wallet>.instance.COLJGNLBEII(PGOFCHMMCDL);
		Singleton<Wallet>.instance.OLAOFCJHNEM(JOBBHEFODFM);
		Singleton<Wallet>.instance.AddScraps(PFMMAAFOBKL);
	}
}
