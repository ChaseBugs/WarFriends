using System;
using System.Runtime.CompilerServices;
using Google2u;

public class ACLIJDOONEB : HHFHFANGCEJ
{
	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public override bool JLCLGAKDIMG
	{
		get
		{
			return true;
		}
	}

	internal virtual Action HDCNLELCFIA(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCrateLowLevelGoldMax).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DCFGPFJOAFI;
	}

	public virtual void KHCIMEFCJFC()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool LDMDMHBAIBG()
	{
		return false;
	}

	[SpecialName]
	public virtual bool JLKEKLKKAFI()
	{
		return false;
	}

	[SpecialName]
	public virtual bool OOJCJCJEEGP()
	{
		return false;
	}

	public virtual void FLMALOGGOBN()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool ILKJHIPHHKL()
	{
		return false;
	}

	public virtual void ODFFMMOFCFF()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public override void KPANLOMNEIG()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	internal virtual Action MAGGBLIILMK(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLoginReminder2After).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return NCJJEBGJLEF;
	}

	[SpecialName]
	public virtual bool GMJGCMNKMOJ()
	{
		return true;
	}

	internal virtual Action LNHELEJOMGD(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotificationAllowHoursBetween).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DBMAINGNHMJ;
	}

	private static void HHBFOPPPAOO()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MaxEnergy).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	internal override Action ENNLMIGMBKJ(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-29)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FHBMAGJHNEK;
	}

	public override void LEJEDFACEGP()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public virtual void JBMCFEMBPKE()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool GJAFEHILAKB()
	{
		return false;
	}

	internal virtual Action IFKOEFBFBHI(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LapsedPlayerInterval3).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return LJAGGANKNLE;
	}

	private static void DBMAINGNHMJ()
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.RateAppReward).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	internal virtual Action IHAPMLGGJEA(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-44)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return delegate
		{
			Singleton<Tweetmanager>.instance.likeUsOnFacebook();
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
			Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		};
	}

	internal virtual Action GBFDOFLHHNA(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FHDADONGADC;
	}

	[SpecialName]
	public virtual bool KHENIHFHBHN()
	{
		return true;
	}

	private static void EDDBKHKJICI()
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastWeaponUpgrade).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	private static void KAHGGAACJIB()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-82)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	[SpecialName]
	public virtual bool FKLAGJJHEGK()
	{
		return true;
	}

	public virtual void DLCFAJEFLHO()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private static void OHHDCFEFCNP()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.TwitterFollow).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	private static void ODDGPIBDLOA()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_PowerbandRewardDuration).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	[SpecialName]
	public virtual bool NJBGFDDLBFD()
	{
		return false;
	}

	public virtual void JLJMIOLJPNL()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	internal virtual Action IKJNAPGLGKO(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return LJAGGANKNLE;
	}

	public virtual void DMLDBKFCACB()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	internal virtual Action MBMLDFPGLIP(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.RateAppMaxShow).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return KNKMMACEBBA;
	}

	private static void NCJJEBGJLEF()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.StartingGold).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	internal virtual Action MCOBONFBIBF(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-101)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DCFGPFJOAFI;
	}

	internal virtual Action PKGCMKFOOOA(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SquadMedalWeight3).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return EDDBKHKJICI;
	}

	private static void DCFGPFJOAFI()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-86)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return delegate
		{
			Singleton<Tweetmanager>.instance.likeUsOnFacebook();
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
			Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		};
	}

	internal virtual Action MDCHALEHFEH(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-76)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return OHHDCFEFCNP;
	}

	internal virtual Action PHCOJLAACDB(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.NotificationAllowMaxShow).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return EDDBKHKJICI;
	}

	[SpecialName]
	public virtual bool NEKCMEGLOAC()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NLLNBDCBPFC()
	{
		return true;
	}

	[SpecialName]
	public override bool KILOAOCGEGC()
	{
		return false;
	}

	internal virtual Action DKHFKILKBNM(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-60)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return HNOOBDCMFHE;
	}

	[SpecialName]
	public virtual bool MFDGCHCJLLI()
	{
		return true;
	}

	public virtual void CALBGDIEDGA()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool DIJLBGOCPBP()
	{
		return false;
	}

	private static void ICHLCKMDDED()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-87)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	private static void FHDADONGADC()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	[SpecialName]
	public virtual bool PJOAAJMBKFJ()
	{
		return false;
	}

	internal virtual Action PLPNGBDLCFJ(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalMaxLockedForWeapon).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return HNOOBDCMFHE;
	}

	internal virtual Action DJOHJFOHPAF(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastUnitUpgrade).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return HHBFOPPPAOO;
	}

	internal virtual Action BLKKNMBFDBL(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-77)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FHBMAGJHNEK;
	}

	internal virtual Action NENKCAJJIFL(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-31)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return LJAGGANKNLE;
	}

	public virtual void AMFEDOOPGCL()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool IECFJMJPBII()
	{
		return true;
	}

	internal virtual Action EOGIDAEFGNI(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastWeaponUpgrade).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DCFGPFJOAFI;
	}

	private static void BHBFCOKBKLO()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMax).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	private static void KNKMMACEBBA()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MaxPingToConnectRegion).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	public virtual void NFEADFKKCOG()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	private static void HNOOBDCMFHE()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipGoldMultiplier).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	internal virtual Action NMCDBKLHFOB(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipExperienceMultiplier).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return EDDBKHKJICI;
	}

	public virtual void FPOIGOFDIPF()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private static void JHKDMDCJHJJ()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-123)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	private static void FHBMAGJHNEK()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-4)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	public virtual void DFJBBKKIPAD()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public virtual bool JNDKJFKEENA()
	{
		return false;
	}

	internal virtual Action IHHPOBJLEGE(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-84)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DBMAINGNHMJ;
	}

	public virtual void DLNGGGOEDLL()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	internal virtual Action IGGIOPAGILL(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-93)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FHDADONGADC;
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	internal virtual Action ILLFKEIJILN(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipRunningOutSeconds).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return NCJJEBGJLEF;
	}

	public ACLIJDOONEB()
		: base("LikeUsOnFacebook", NKHJBLBAAEB.LikeUsOnFacebook)
	{
	}

	public virtual void FPLCMPHNNHK()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	internal virtual Action BOFFALKMDGB(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-112)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return OHHDCFEFCNP;
	}

	internal virtual Action EAJDDIMBBOL(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-110)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return HNOOBDCMFHE;
	}

	public virtual void DPDNJFAKNCM()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	internal virtual Action ILLNDNCGJBO(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReminder1After).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return DBMAINGNHMJ;
	}

	[SpecialName]
	public virtual bool MFKOLEKIKGK()
	{
		return false;
	}

	[SpecialName]
	public virtual bool HKPFPJMPAHN()
	{
		return true;
	}

	internal virtual Action BFDIJGGPNCO(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.PlayerExplosiveCoef).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FHBMAGJHNEK;
	}

	internal virtual Action OGPPKOPMIOJ(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-85)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return delegate
		{
			Singleton<Tweetmanager>.instance.likeUsOnFacebook();
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
			Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		};
	}

	public virtual void NNPILDOKNJO()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private static void LJAGGANKNLE()
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-84)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}

	public virtual void LOAHPGAPGNN()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private static void CCPPBMANOGC()
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-20)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
	}
}
