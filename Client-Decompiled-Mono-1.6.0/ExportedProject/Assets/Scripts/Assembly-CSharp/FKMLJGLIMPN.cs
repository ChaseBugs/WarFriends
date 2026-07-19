using System.Runtime.CompilerServices;

public class FKMLJGLIMPN : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RELOAD");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RELOAD-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-army-reload-ico";
		}
	}

	public override bool menuMainAtlas
	{
		get
		{
			return false;
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RELOAD-DESCRIPTION");
		}
	}

	public override string statisticIncrease
	{
		get
		{
			return MEJMLNDFDBP.DPAFFLMAFJG(0f - (float)base.value);
		}
	}

	public override string weaponPrefix
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RELOAD-WEAPONPREFIX");
		}
	}

	public override float reloadCoef
	{
		get
		{
			return 1f - (float)base.value;
		}
	}

	[SpecialName]
	public virtual float INGFENCDNMI()
	{
		return 1207f - (float)base.value;
	}

	[SpecialName]
	public virtual bool BEGOJMGPNFG()
	{
		return true;
	}

	[SpecialName]
	public virtual string PKCAJCNLEMO()
	{
		return Localization.Localize("Key = ");
	}

	[SpecialName]
	public virtual string IMIBCBLGEBC()
	{
		return Localization.Localize("BoughtIndex");
	}

	public virtual int CFHOOHKLCIP(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.reloadGUI != ILHEPJCFKIK.reloadGUI)
		{
			return (!(DDJKMDPGFPB.reloadGUI > ILHEPJCFKIK.reloadGUI)) ? 1 : (-1);
		}
		return 1;
	}

	public virtual string FNGMNFBFAFJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DLDMHFBIEEO(JMMJHCOKCGG.reloadGUI);
	}

	[SpecialName]
	public virtual string NKDGJNGLIOG()
	{
		return Localization.Localize("ID_SEC");
	}

	[SpecialName]
	public virtual string POGGGLDGFIN()
	{
		return Localization.Localize("Time");
	}

	[SpecialName]
	public virtual string DHHHJAKDDHN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(0f - (float)base.value);
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.reloadGUI != ILHEPJCFKIK.reloadGUI)
		{
			return (!(DDJKMDPGFPB.reloadGUI > ILHEPJCFKIK.reloadGUI)) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string IDMLAPMCBBP()
	{
		return Localization.Localize("Player_Had_To_Select_Grenade");
	}

	[SpecialName]
	public virtual string ODBIPIIIFGD()
	{
		return Localization.Localize("batchSizeMin");
	}

	[SpecialName]
	public virtual string HLBAJGPAHMI()
	{
		return Localization.Localize("OrderId");
	}

	[SpecialName]
	public virtual string BOGMMFKKIOE()
	{
		return Localization.Localize("ID_SQUADEMPTYTEXT-COOP");
	}

	[SpecialName]
	public virtual bool KAMGFPFOLBB()
	{
		return false;
	}

	[SpecialName]
	public virtual string BJLFFCECMAN()
	{
		return Localization.Localize("#PETER# League Arc - start ignore on ");
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		return Localization.Localize("ID_CONFIRM_SELECTEDWARCARDWASALREADY");
	}

	[SpecialName]
	public virtual float GNHKFIDFAEK()
	{
		return 1753f - (float)base.value;
	}

	[SpecialName]
	public virtual string LIMNOLDMOCP()
	{
		return Localization.Localize("]");
	}

	public virtual int HNBAFJOGEHO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.reloadGUI != ILHEPJCFKIK.reloadGUI)
		{
			return (!(DDJKMDPGFPB.reloadGUI > ILHEPJCFKIK.reloadGUI)) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual bool OCDAHHOEFGP()
	{
		return false;
	}

	[SpecialName]
	public virtual string EABDPJALKPO()
	{
		return Localization.Localize("dbKey");
	}

	[SpecialName]
	public virtual string PJNLIHAALHM()
	{
		return Localization.Localize("War_Battle_End_Performance");
	}

	[SpecialName]
	public virtual string EGHMNGLKGIB()
	{
		return Localization.Localize("vveteranpack");
	}

	[SpecialName]
	public virtual string EAGLFFBBGGC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(0f - (float)base.value);
	}

	[SpecialName]
	public virtual string MGNJCDMLAJH()
	{
		return Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;");
	}

	[SpecialName]
	public virtual bool OFKPEHHODPC()
	{
		return true;
	}

	[SpecialName]
	public virtual string DDOBDADADJO()
	{
		return "PlayerInfoId";
	}

	[SpecialName]
	public virtual float BKDHEMPFCDL()
	{
		return 188f - (float)base.value;
	}

	[SpecialName]
	public virtual string HLMFODOONOD()
	{
		return "#AccoutCheck# gpgs account found during account loading!!! - TODO!";
	}

	[SpecialName]
	public virtual string HHKJLMAAOBC()
	{
		return Localization.Localize("InAppHandlerIos: Validating inapp on server... inappId = ");
	}

	[SpecialName]
	public virtual float COIGPLAACHJ()
	{
		return 1209f - (float)base.value;
	}

	[SpecialName]
	public virtual float AIMJKAKONCN()
	{
		return 623f - (float)base.value;
	}

	[SpecialName]
	public virtual bool GDAHCKMMAPL()
	{
		return true;
	}

	[SpecialName]
	public virtual float LOIIHEJONJM()
	{
		return 221f - (float)base.value;
	}

	[SpecialName]
	public virtual string MIANMFIEBBH()
	{
		return Localization.Localize("S");
	}

	[SpecialName]
	public virtual string FJMGKDLILDH()
	{
		return Localization.Localize("doesnt exist");
	}

	[SpecialName]
	public virtual bool ADHGHNDFJBB()
	{
		return true;
	}

	[SpecialName]
	public virtual float ICIOFCPIFMP()
	{
		return 289f - (float)base.value;
	}

	[SpecialName]
	public virtual string IOLLOCGDADC()
	{
		return Localization.Localize("CardId");
	}

	public virtual int DDIEKAJJPJO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.reloadGUI != ILHEPJCFKIK.reloadGUI)
		{
			return (DDJKMDPGFPB.reloadGUI > ILHEPJCFKIK.reloadGUI) ? (-1) : 0;
		}
		return 1;
	}

	public virtual int GOAIOOIPLLK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.reloadGUI != ILHEPJCFKIK.reloadGUI)
		{
			return (DDJKMDPGFPB.reloadGUI > ILHEPJCFKIK.reloadGUI) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string BJOMEKMNJPG()
	{
		return "default";
	}

	[SpecialName]
	public virtual bool EFKECFOJIPO()
	{
		return false;
	}

	[SpecialName]
	public virtual string HPGIFOKKNPD()
	{
		return "getOriginalAccountType";
	}

	[SpecialName]
	public virtual string IANDLJLLIFJ()
	{
		return Localization.Localize("ID_GUI_SYSTEMMAINTENANCE_DESC");
	}

	public virtual string MEJJPMNMLFF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DLDMHFBIEEO(JMMJHCOKCGG.reloadGUI);
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DLDMHFBIEEO(JMMJHCOKCGG.reloadGUI);
	}

	[SpecialName]
	public virtual string AKDEGDMJIPO()
	{
		return Localization.Localize("DeadRadius");
	}

	public virtual string BAIBMLCIPFC(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DLDMHFBIEEO(JMMJHCOKCGG.reloadGUI);
	}

	[SpecialName]
	public virtual string JPLENCEGLKD()
	{
		return Localization.Localize("DOWNLOADBTN");
	}

	[SpecialName]
	public virtual string PANCCHFGCAJ()
	{
		return Localization.Localize("ID_CONFIRM_TUTORIALMATCH_TEXT");
	}

	public virtual string MIPNOJFEGNO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DLDMHFBIEEO(JMMJHCOKCGG.reloadGUI);
	}

	[SpecialName]
	public virtual string KPKHIIMMLDD()
	{
		return "ID_TUTORIAL_GO_TO_ARMORY_8";
	}

	[SpecialName]
	public virtual string DDIMLOOCJCN()
	{
		return "player_level";
	}

	[SpecialName]
	public virtual bool NHEFBDCIMNK()
	{
		return false;
	}

	[SpecialName]
	public virtual string PDPICPEFOEF()
	{
		return Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE");
	}

	[SpecialName]
	public virtual string DDDIEIDBMJI()
	{
		return Localization.Localize("bazooka_reload");
	}

	[SpecialName]
	public virtual string DMIBLIJMELC()
	{
		return Localization.Localize(" ID_");
	}

	[SpecialName]
	public virtual string HKBDGJPPMLP()
	{
		return "player name";
	}

	[SpecialName]
	public virtual float EFJLKHIMICJ()
	{
		return 832f - (float)base.value;
	}

	[SpecialName]
	public virtual string JMOLPCNANHO()
	{
		return Localization.Localize("key= ");
	}

	[SpecialName]
	public virtual float JLALIBJJEGC()
	{
		return 606f - (float)base.value;
	}

	[SpecialName]
	public virtual string PPDJEJBIGMK()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(0f - (float)base.value);
	}

	[SpecialName]
	public virtual string KGBHICKFEBE()
	{
		return Localization.Localize("setGender");
	}
}
