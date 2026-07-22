using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuHeader : GuiElementSingle<MenuHeader>
{
	[FormerlySerializedAs("IMNNPCMJHMP")]
	[Header("Status")]
	public UISprite GFKNLLCKJOG;

	[FormerlySerializedAs("KBJPGNFNAAA")]
	public UILabel BCMCMKDCLGP;

	[FormerlySerializedAs("MDKDHDFAFPH")]
	public UILabel CNCAGHAEIEL;

	[FormerlySerializedAs("CJECLHLNJFA")]
	public UILabel HEAGCIPCKHF;

	[FormerlySerializedAs("AACEBDJDPJC")]
	public UISprite CMIBPCAHILH;

	[FormerlySerializedAs("KCJOIIBNAMA")]
	public UISprite FFHCPJALBCC;

	[FormerlySerializedAs("HEGGIEABPCF")]
	public UIButton FPCFLFGMMEF;

	[FormerlySerializedAs("KAFIPMNBLOA")]
	public GameObject EDBMBNCLHFC;

	public UILabel LMCMDIGDGCJ;

	[Header("VIP")]
	[FormerlySerializedAs("BHAKDPBCEMO")]
	public GameObject AIFGOKIDMMO;

	[FormerlySerializedAs("EEDBHPKILHN")]
	public UISprite GDBGLCLOKPA;

	[FormerlySerializedAs("JFKEHLKCMGD")]
	public GameObject BDDIAPDJOEF;

	[FormerlySerializedAs("NLMMMNNENEJ")]
	public GameObject ABDGBEMGCPG;

	[FormerlySerializedAs("PDDMHDLFDKO")]
	public UILabel DDNOEAJIGNN;

	[FormerlySerializedAs("IGECNBKEAFF")]
	public WinStreakCounter JBGPDECEOOB;

	[Header("Subscription")]
	[FormerlySerializedAs("GBOMCHGBLPA")]
	public GameObject LKEPONMFFNK;

	[FormerlySerializedAs("PLGFIHIGABB")]
	[Header("Warbucks and Gold")]
	public UISprite BGPBNIJPOKM;

	[FormerlySerializedAs("AGEBDBJHAKE")]
	public UILabel MCMHCOLPLBD;

	[FormerlySerializedAs("HIPMEHHAOAL")]
	public UISprite CODFFPODNEP;

	[FormerlySerializedAs("IJOFKEPMEKF")]
	public UILabel AGEEJIHGKID;

	[FormerlySerializedAs("HKFECPKBNGL")]
	public UIButton FLJDOPCHLMM;

	[Header("Settings")]
	[FormerlySerializedAs("GNGHGJECDGH")]
	public UIButton FGOEDANMKED;

	[FormerlySerializedAs("HPINBAABKKI")]
	public UISprite MCNGLCFFPED;

	[FormerlySerializedAs("LEEBPNGMFFM")]
	[Header("Anchors")]
	public Transform JNKHCEGFPGE;

	[FormerlySerializedAs("INGKAICNAME")]
	public Transform ENOOMPLKMKJ;

	private bool BOPCKJNBALK;

	public float subscriptionPixels => (!SubscriptionManager.instance.isSubscribed) ? 0f : 46f;

	private void NJEICHELDFP(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GuiElementSingle<InappScreen>.instance.GIKMFEKAOAH();
			return;
		}
		DialogManager.instance.HideAllDialogs();
		GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "ID_SLOTUPGRADE_DAMAGE";
		GuiElementSingle<InappScreen>.instance.GIKMFEKAOAH();
	}

	private void OLKCBDPJAGL()
	{
		GDBGLCLOKPA.spriteName = ((!Singleton<VipManager>.instance.NOIHCEPINJJ()) ? "Chat Record For Height" : "ID_COMPLETEALLTENSTARTERASSIGNMENTS");
	}

	private void EPDKEJEFKBL()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(350f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: false);
		FLJDOPCHLMM.gameObject.SetActive(value: true);
		FLJDOPCHLMM.isEnabled = false;
		FGOEDANMKED.gameObject.SetActive(value: true);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.WarbucksChanged += CENFGDKGECH;
		Singleton<Wallet>.instance.GoldChanged += HFHICNCMHOG;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<VipManager>.instance.VipStatusChanged += BLGDIIICCBM;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		Singleton<OfferManager>.instance.SalesChanged += CJFIOPEIJKD;
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
		Singleton<AchievementsManager>.instance.AchievementsEvaluated += FBGKNGOHLOL;
		Singleton<AchievementsManager>.instance.AchievementClaimed += GHAIDEGBPKO;
		GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(CHHHDDIJJMB));
		GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(OGCILPJBKLP));
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NOOJKMEHJPD));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AANOCIGNMKK));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IBPGKJPLMJC));
	}

	private void APIKMJMJPDA()
	{
		ABDGBEMGCPG.SetActive(value: true);
	}

	public virtual void BAAOGDMJCLK()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			FANABKNHEEI(GameLoginManager.currentPlayer.name);
			if (!BOPCKJNBALK)
			{
				GIKKPPPIOIB();
			}
			if (!BOPCKJNBALK)
			{
				KNOAMONLNHH();
			}
			CIAFIJLFEFE();
			MNFPHKCMCCB();
			CDGJKDHHILN();
			if (!BOPCKJNBALK)
			{
				CENFGDKGECH(Singleton<Wallet>.instance.GCEAEGBNLMM(), 0L);
			}
			if (!BOPCKJNBALK)
			{
				HJEMKJCKKNP(Singleton<Wallet>.instance.EFNHFKGEDHC(), 0L);
			}
			TweenRotationSpecial component = MCNGLCFFPED.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			MCNGLCFFPED.transform.localRotation = Quaternion.Euler(482f, 884f, 695f);
			if (Singleton<GameController>.instance.DAIEAMEFGIE())
			{
				KNCMFCHACOO();
			}
			else
			{
				NKBGKKOLHDF();
			}
			BOPCKJNBALK = false;
		}
	}

	private void FLCGJPCGODC(GuiElement JAGBOPMGIAA)
	{
		if (isShowed && ABDGBEMGCPG.activeSelf && DialogManager.instance.GetShownDialog() == null)
		{
			TweenAlpha.Begin(ABDGBEMGCPG, 703f, 829f);
		}
	}

	public void SetUpWarbucksGoldWithoutAnimation(long FPMJEDOCJKE, long HAFMGCFMCPC)
	{
		MCMHCOLPLBD.text = MEJMLNDFDBP.PGJPABFJDGG(FPMJEDOCJKE);
		AGEEJIHGKID.text = MEJMLNDFDBP.PGJPABFJDGG(HAFMGCFMCPC);
	}

	private void EGOMFANNIKL()
	{
		LKEPONMFFNK.SetActive(SubscriptionManager.instance.isSubscribed);
	}

	private void LMAGFLMDGNB()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public virtual void AGPINBAMJHF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NOOJKMEHJPD));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FAKPCCJBJDF));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LNJAMABHBDD));
	}

	private void MNFPHKCMCCB()
	{
		LKEPONMFFNK.SetActive(SubscriptionManager.instance.isSubscribed);
	}

	public void JPPOMCGJPDL()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.KAKFPJPKHHB();
		GFKNLLCKJOG.spriteName = gameLevel.NOHAFIDFPCM();
		if (gameLevel.PFMGLDJDNBF() == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("\t\"TRUE\"");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(603f, 243f, 882f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.GIIHOHGFHBO();
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(675f, 1511f, 1f);
		}
	}

	public virtual void PLDAPLOGJPA()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.ANAHBKMOENA(CENFGDKGECH);
		Singleton<Wallet>.instance.GoldChanged += HJEMKJCKKNP;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<VipManager>.instance.VipStatusChanged += NAJKGMFCCGA;
		Singleton<GameController>.instance.CNPGMMPAGIE(MNCCFKBBKLE);
		Singleton<OfferManager>.instance.SalesChanged += CJFIOPEIJKD;
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
		Singleton<AchievementsManager>.instance.ALKDIMDNNEI(EDIGDBDIMCE);
		Singleton<AchievementsManager>.instance.CODAFOOMAHC(GHAIDEGBPKO);
		GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(CHHHDDIJJMB));
		GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(FLCGJPCGODC));
	}

	private void BLGDIIICCBM(bool HMGOHGOLMJB)
	{
		if (isShowed)
		{
			PAFJCIMACOM();
		}
	}

	private void CJFIOPEIJKD()
	{
		if (!isShowed)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.DiscountedVIP(null);
		bool flag = num > 0;
		ABDGBEMGCPG.SetActive(flag);
		if (flag)
		{
			DDNOEAJIGNN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedVIPEndtime(null));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				ABDGBEMGCPG.SetActive(value: false);
			};
		}
		else
		{
			JBGPDECEOOB.JCMHGOGNMFO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
	}

	private void DKHCIEOELCM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GuiElementSingle<InappScreen>.instance.GIKMFEKAOAH();
			return;
		}
		DialogManager.instance.HideAllDialogs();
		GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("currentAchievementProgress");
		GuiElementSingle<InappScreen>.instance.FFHMEJCIEPJ();
	}

	public virtual void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NJEICHELDFP));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AANOCIGNMKK));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IDNMKBDIHGP));
	}

	private void NOOJKMEHJPD(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GuiElementSingle<InappScreen>.instance.FFHMEJCIEPJ();
			return;
		}
		DialogManager.instance.HideAllDialogs();
		GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "1.0";
		GuiElementSingle<InappScreen>.instance.AHKAIALCMEI();
	}

	private void NHJHCKAKGCF(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1838f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1382f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	private void MIJBJFGKLGK()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(367f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: false);
		FLJDOPCHLMM.gameObject.SetActive(value: false);
		FLJDOPCHLMM.isEnabled = true;
		FGOEDANMKED.gameObject.SetActive(value: false);
	}

	private void NKBGKKOLHDF()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(-61f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: true);
		FLJDOPCHLMM.gameObject.SetActive(value: true);
		FLJDOPCHLMM.isEnabled = true;
		FGOEDANMKED.gameObject.SetActive(value: true);
	}

	private void HBIMHBPCNPB(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 583f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1388f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	public virtual void CMMFMJKAGKE()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.ANAHBKMOENA(CENFGDKGECH);
		Singleton<Wallet>.instance.GoldChanged += HFHICNCMHOG;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CBJNHDHPLIN;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(OFFLAPAMMKB);
		Singleton<VipManager>.instance.JEPFBKHJPMA(NAJKGMFCCGA);
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		Singleton<OfferManager>.instance.SalesChanged += LOLLPCBCNBJ;
		SubscriptionManager.instance.SubscriptionStateChanged += KNMGDOFODPC;
		Singleton<AchievementsManager>.instance.ALKDIMDNNEI(ELCABCOPKKE);
		Singleton<AchievementsManager>.instance.CODAFOOMAHC(GHAIDEGBPKO);
		GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(CHHHDDIJJMB));
		GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(OGCILPJBKLP));
	}

	private void KLPABPJJPIA()
	{
		int achievementsNotifications = Singleton<NotificationManager>.instance.GetAchievementsNotifications();
		bool flag = achievementsNotifications > 1;
		EDBMBNCLHFC.SetActive(flag);
		if (flag)
		{
			LMCMDIGDGCJ.text = MEJMLNDFDBP.GMIPFLIEOHD(achievementsNotifications);
		}
	}

	private void IFLHAOHDEDH(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<InappScreen>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Direct";
			GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
		}
	}

	private void EDCFGNFKDMA()
	{
		ABDGBEMGCPG.SetActive(value: true);
	}

	public void JFODBIOHGJP(long FPMJEDOCJKE, long HAFMGCFMCPC)
	{
		MCMHCOLPLBD.text = MEJMLNDFDBP.PGJPABFJDGG(FPMJEDOCJKE);
		AGEEJIHGKID.text = MEJMLNDFDBP.PGJPABFJDGG(HAFMGCFMCPC);
	}

	private void NLENMGHHCDG(string BCJFMFMDAEM)
	{
		BCMCMKDCLGP.text = BCJFMFMDAEM;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 945f, 615f);
		BCMCMKDCLGP.color = Color.white;
		TweenColor component = BCMCMKDCLGP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DKHCIEOELCM));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AANOCIGNMKK));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LPAHCCPFAGG));
	}

	private void PAFJCIMACOM()
	{
		GDBGLCLOKPA.spriteName = ((!Singleton<VipManager>.instance.NOGEIPHFNPK()) ? "menu-top-vip-not" : "menu-top-vip");
	}

	public void AnimateToCurrentValues()
	{
		long warBucks = Singleton<Wallet>.instance.warBucks;
		long gold = Singleton<Wallet>.instance.gold;
		long num = Convert.ToInt64(Regex.Replace(MCMHCOLPLBD.text, "[.,']*", string.Empty));
		long num2 = Convert.ToInt64(Regex.Replace(AGEEJIHGKID.text, "[.,']*", string.Empty));
		HFHICNCMHOG(gold, gold - num2);
		CENFGDKGECH(warBucks, warBucks - num);
	}

	public virtual void OJKCMCPJPGO()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			DJCJJNKFIKA(GameLoginManager.currentPlayer.name);
			if (!BOPCKJNBALK)
			{
				JPPOMCGJPDL();
			}
			if (!BOPCKJNBALK)
			{
				DDNNGBFMCEK();
			}
			LCEBJCBMKND();
			MNFPHKCMCCB();
			CDGJKDHHILN();
			if (!BOPCKJNBALK)
			{
				CENFGDKGECH(Singleton<Wallet>.instance.ODKBFHAFHMA(), 1L);
			}
			if (!BOPCKJNBALK)
			{
				IDGDFNCBKLD(Singleton<Wallet>.instance.gold, 0L);
			}
			TweenRotationSpecial component = MCNGLCFFPED.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			MCNGLCFFPED.transform.localRotation = Quaternion.Euler(207f, 738f, 1517f);
			if (Singleton<GameController>.instance.DAIEAMEFGIE())
			{
				KNCMFCHACOO();
			}
			else
			{
				NKBGKKOLHDF();
			}
			BOPCKJNBALK = false;
		}
	}

	private void FAKPCCJBJDF(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("goldenSuitcase");
			GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
		}
	}

	private void HMGJBMLEIIO()
	{
		if (NPFFMLLLDAF())
		{
			CDGJKDHHILN();
		}
	}

	private void IDGDFNCBKLD(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1028f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1555f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	private void KCPMBAIILCG(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-41):
			case (DatabaseAction)(-32):
			case (DatabaseAction)(-7):
			case DatabaseAction.AcceptSquadJoinRequest:
			case DatabaseAction.NotifyPlayerToDeposit:
			case DatabaseAction.CardpoolShown:
				OLNIFPBEFKB(GameLoginManager.currentPlayer.name);
				break;
			case (DatabaseAction)46:
				InitGUIValues();
				break;
			case DatabaseAction.ActivateUnitUpgrade:
				PAFJCIMACOM();
				break;
			}
		}
	}

	private void CHHHDDIJJMB()
	{
		if (isShowed && ABDGBEMGCPG.activeSelf)
		{
			TweenAlpha.Begin(ABDGBEMGCPG, 0.2f, 0f);
		}
	}

	private void HFHICNCMHOG(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 0f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 2f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	public void AnimateToActualStateOfWBAndGold()
	{
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks));
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.gold));
	}

	private void HJEMKJCKKNP(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1021f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(AGEEJIHGKID.gameObject, 1217f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	private void CDGJKDHHILN()
	{
		int achievementsNotifications = Singleton<NotificationManager>.instance.GetAchievementsNotifications();
		bool flag = achievementsNotifications > 0;
		EDBMBNCLHFC.SetActive(flag);
		if (flag)
		{
			LMCMDIGDGCJ.text = MEJMLNDFDBP.GMIPFLIEOHD(achievementsNotifications);
		}
	}

	private void GLOCMLLMBLB(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GuiElementSingle<InappScreen>.instance.ShowWarshopSubscription();
			return;
		}
		DialogManager.instance.HideAllDialogs();
		GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Direct";
		GuiElementSingle<InappScreen>.instance.ShowWarshopSubscription();
	}

	private void LHHDLIAOMMD()
	{
		if (isShowed)
		{
			int num = Singleton<OfferManager>.instance.DiscountedVIP(null);
			bool flag = num > 0;
			ABDGBEMGCPG.SetActive(flag);
			if (flag)
			{
				UILabel dDNOEAJIGNN = DDNOEAJIGNN;
				object[] array = new object[1];
				array[1] = num;
				dDNOEAJIGNN.text = Localization.LocalizeFormat("ReconnectDialog Hide", array);
				JBGPDECEOOB.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedVIPEndtime(null));
				JBGPDECEOOB.JEMKCLKCOMI = APIKMJMJPDA;
			}
			else
			{
				JBGPDECEOOB.KEIIENDMKLN();
				JBGPDECEOOB.JEMKCLKCOMI = null;
			}
		}
	}

	public void UpdateLevel()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.displayString;
		GFKNLLCKJOG.spriteName = gameLevel.iconName;
		if (gameLevel.displayNumber == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("ID_MAX");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(20f, 20f, 1f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.displayString;
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(25f, 25f, 1f);
		}
	}

	private void FBGKNGOHLOL()
	{
		if (isShowed)
		{
			CDGJKDHHILN();
		}
	}

	public void ADJJGJHMJJM()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.DLCFFHEKBAA();
		GFKNLLCKJOG.spriteName = gameLevel.CDLBEKECJNK();
		if (gameLevel.displayNumber == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("{0} {1}");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(636f, 1639f, 393f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.displayString;
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(1897f, 757f, 646f);
		}
	}

	private void OGCILPJBKLP(GuiElement JAGBOPMGIAA)
	{
		if (isShowed && ABDGBEMGCPG.activeSelf && DialogManager.instance.GetShownDialog() == null)
		{
			TweenAlpha.Begin(ABDGBEMGCPG, 0.2f, 1f);
		}
	}

	public virtual void LANJLCBMFHJ()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.WarbucksChanged += CENFGDKGECH;
		Singleton<Wallet>.instance.HIAFLHLJKGB(IDGDFNCBKLD);
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<VipManager>.instance.VipStatusChanged += BLGDIIICCBM;
		Singleton<GameController>.instance.CNPGMMPAGIE(KPPNCJBMDPE);
		Singleton<OfferManager>.instance.SalesChanged += CJFIOPEIJKD;
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
		Singleton<AchievementsManager>.instance.ALKDIMDNNEI(KFLAOKLLCFM);
		Singleton<AchievementsManager>.instance.MKGPMALCDPO(GHAIDEGBPKO);
		GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(CHHHDDIJJMB));
		GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(OGCILPJBKLP));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	public void UpdateProgress()
	{
		float progress = LevelManager.instance.GetProgress();
		CMIBPCAHILH.fillAmount = progress;
		FFHCPJALBCC.fillAmount = progress;
	}

	private void LNJAMABHBDD(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			TweenRotationSpecial.Begin(MCNGLCFFPED.gameObject, 1f, Vector3.forward, 0f, 360f);
			GuiElementSingle<SettingsDialog>.instance.ShowGeneral();
		}
	}

	private void DJCJJNKFIKA(string BCJFMFMDAEM)
	{
		BCMCMKDCLGP.text = BCJFMFMDAEM;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1228f, 1458f);
		BCMCMKDCLGP.color = Color.white;
		TweenColor component = BCMCMKDCLGP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void KNMGDOFODPC()
	{
		if (NPFFMLLLDAF())
		{
			EGOMFANNIKL();
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.SwitchToFacebook:
			case DatabaseAction.ChangePlayerName:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				OLNIFPBEFKB(GameLoginManager.currentPlayer.name);
				break;
			case DatabaseAction.RemoveFacebook:
				InitGUIValues();
				break;
			case DatabaseAction.BuyVip:
				PAFJCIMACOM();
				break;
			}
		}
	}

	private void AANOCIGNMKK(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<InappScreen>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC("Shots_Hits");
			GuiElementSingle<InappScreen>.instance.GNNKBAAGCCL();
		}
	}

	private void BJPCHHACKCE()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(0f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: true);
		FLJDOPCHLMM.gameObject.SetActive(value: true);
		FLJDOPCHLMM.isEnabled = true;
		FGOEDANMKED.gameObject.SetActive(value: false);
	}

	private void MNCCFKBBKLE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		BOPCKJNBALK = false;
	}

	private void AMNFEHPNDCH(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	public virtual void AHMBANMKGEJ()
	{
		base.OIMKKAHOEKO();
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	[CompilerGenerated]
	private void PCBGLNNFPGP()
	{
		ABDGBEMGCPG.SetActive(value: false);
	}

	private void NAJKGMFCCGA(bool HMGOHGOLMJB)
	{
		if (NPFFMLLLDAF())
		{
			PAFJCIMACOM();
		}
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NOOJKMEHJPD));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AANOCIGNMKK));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IDNMKBDIHGP));
	}

	public void NKKIINELKAI()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.displayString;
		GFKNLLCKJOG.spriteName = gameLevel.GIEIIPBAIBK();
		if (gameLevel.ELFCEEOLNFJ() == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("CardManager: Added card ");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(67f, 69f, 191f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.JNODDKLJOAG();
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(1096f, 440f, 1782f);
		}
	}

	private void ELCABCOPKKE()
	{
		if (isShowed)
		{
			KLPABPJJPIA();
		}
	}

	private void PHGFBJFFFPH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OFFLAPAMMKB(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-148):
			case (DatabaseAction)(-127):
			case (DatabaseAction)(-33):
			case (DatabaseAction)43:
			case DatabaseAction.FacebookLoginOk:
			case DatabaseAction.WeaponWasShown:
				OLNIFPBEFKB(GameLoginManager.currentPlayer.name);
				break;
			case (DatabaseAction)(-200):
				InitGUIValues();
				break;
			case (DatabaseAction)93:
				OLKCBDPJAGL();
				break;
			}
		}
	}

	public void DDNNGBFMCEK()
	{
		float progress = LevelManager.instance.GetProgress();
		CMIBPCAHILH.fillAmount = progress;
		FFHCPJALBCC.fillAmount = progress;
	}

	private void BFNPHAPIHAM()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private void CBJNHDHPLIN()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public void BCNJPFHIKIO()
	{
		long warBucks = Singleton<Wallet>.instance.warBucks;
		long num = Singleton<Wallet>.instance.EFNHFKGEDHC();
		long num2 = Convert.ToInt64(Regex.Replace(MCMHCOLPLBD.text, "matchMadeGames", string.Empty));
		long num3 = Convert.ToInt64(Regex.Replace(AGEEJIHGKID.text, "\"{0}\":", string.Empty));
		HJEMKJCKKNP(num, num - num3);
		CENFGDKGECH(warBucks, warBucks - num2);
	}

	private void LPAHCCPFAGG(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			TweenRotationSpecial.IAGLEIPAIOB(MCNGLCFFPED.gameObject, 579f, Vector3.forward, 1096f, 519f);
			GuiElementSingle<SettingsDialog>.instance.JGPCJJILAHG();
		}
	}

	private void KFLAOKLLCFM()
	{
		if (isShowed)
		{
			BDLODIHNIFN();
		}
	}

	private void CIAFIJLFEFE()
	{
		PAFJCIMACOM();
		CJFIOPEIJKD();
	}

	private void PALBLCFMFHJ()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(155f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: false);
		FLJDOPCHLMM.gameObject.SetActive(value: false);
		FLJDOPCHLMM.isEnabled = true;
		FGOEDANMKED.gameObject.SetActive(value: true);
	}

	public virtual void OPEIFLGEBFI()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			DJCJJNKFIKA(GameLoginManager.currentPlayer.name);
			if (!BOPCKJNBALK)
			{
				UpdateLevel();
			}
			if (!BOPCKJNBALK)
			{
				FECABMLBDDO();
			}
			LCEBJCBMKND();
			MNFPHKCMCCB();
			CDGJKDHHILN();
			if (!BOPCKJNBALK)
			{
				CENFGDKGECH(Singleton<Wallet>.instance.ODKBFHAFHMA(), 1L);
			}
			if (!BOPCKJNBALK)
			{
				HJEMKJCKKNP(Singleton<Wallet>.instance.FHLGDIIPHFN(), 0L);
			}
			TweenRotationSpecial component = MCNGLCFFPED.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			MCNGLCFFPED.transform.localRotation = Quaternion.Euler(1765f, 1251f, 75f);
			if (Singleton<GameController>.instance.isTutorial)
			{
				PALBLCFMFHJ();
			}
			else
			{
				NKBGKKOLHDF();
			}
			BOPCKJNBALK = true;
		}
	}

	public void LGPFHLENCML()
	{
		BOPCKJNBALK = true;
	}

	private void NCNEDHKIJEI(GuiElement JAGBOPMGIAA)
	{
		if (isShowed && ABDGBEMGCPG.activeSelf && DialogManager.instance.GetShownDialog() == null)
		{
			TweenAlpha.Begin(ABDGBEMGCPG, 418f, 464f);
		}
	}

	private void BDLODIHNIFN()
	{
		int achievementsNotifications = Singleton<NotificationManager>.instance.GetAchievementsNotifications();
		bool flag = achievementsNotifications > 1;
		EDBMBNCLHFC.SetActive(flag);
		if (flag)
		{
			LMCMDIGDGCJ.text = MEJMLNDFDBP.GMIPFLIEOHD(achievementsNotifications);
		}
	}

	[SpecialName]
	public float PPIIBKCHEEH()
	{
		return (!SubscriptionManager.instance.isSubscribed) ? 610f : 947f;
	}

	private void DEIICLHJKBH(bool HMGOHGOLMJB)
	{
		if (NPFFMLLLDAF())
		{
			OLKCBDPJAGL();
		}
	}

	private void LOLLPCBCNBJ()
	{
		if (NPFFMLLLDAF())
		{
			int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(null);
			bool flag = num > 1;
			ABDGBEMGCPG.SetActive(flag);
			if (flag)
			{
				UILabel dDNOEAJIGNN = DDNOEAJIGNN;
				object[] array = new object[0];
				array[0] = num;
				dDNOEAJIGNN.text = Localization.LocalizeFormat("queryInventoryFailedEvent: ", array);
				JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedVIPEndtime(null));
				JBGPDECEOOB.JEMKCLKCOMI = CPOLLDCMOCP;
			}
			else
			{
				JBGPDECEOOB.LOINIDOGNCO();
				JBGPDECEOOB.JEMKCLKCOMI = null;
			}
		}
	}

	private void OLNIFPBEFKB(string BCJFMFMDAEM)
	{
		BCMCMKDCLGP.text = BCJFMFMDAEM;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 30f, 20f);
		BCMCMKDCLGP.color = Color.white;
		TweenColor component = BCMCMKDCLGP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void EIBNHKPJBNP(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-136):
			case (DatabaseAction)(-112):
			case (DatabaseAction)(-74):
			case (DatabaseAction)(-72):
			case (DatabaseAction)10:
			case (DatabaseAction)152:
				FANABKNHEEI(GameLoginManager.currentPlayer.name);
				break;
			case (DatabaseAction)(-24):
				InitGUIValues();
				break;
			case (DatabaseAction)9:
				PAFJCIMACOM();
				break;
			}
		}
	}

	public void NDIFLCMCBIP()
	{
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1400f, new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM()));
		TweenTextCounterLong.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1040f, new OLDCFKEJDPA(Singleton<Wallet>.instance.EFNHFKGEDHC()));
	}

	private void NHGNCOHKMLH(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-126):
			case (DatabaseAction)16:
			case DatabaseAction.AddFacebook:
			case (DatabaseAction)93:
			case DatabaseAction.GetSquadsByExperience:
			case DatabaseAction.CustomizationShown:
				NLENMGHHCDG(GameLoginManager.currentPlayer.name);
				break;
			case (DatabaseAction)(-64):
				InitGUIValues();
				break;
			case (DatabaseAction)(-120):
				OLKCBDPJAGL();
				break;
			}
		}
	}

	private void CENFGDKGECH(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(MCMHCOLPLBD.gameObject, 0f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
			}
			else
			{
				TweenTextCounterLong.Begin(MCMHCOLPLBD.gameObject, 2f, new OLDCFKEJDPA(IEALLELGOBM - ODNAADFONLC), new OLDCFKEJDPA(IEALLELGOBM));
			}
		}
	}

	private void IDNCGGBGBOP()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void GHAIDEGBPKO()
	{
		if (isShowed)
		{
			CDGJKDHHILN();
		}
	}

	private void CPOLLDCMOCP()
	{
		ABDGBEMGCPG.SetActive(value: true);
	}

	private void EKAEAFMGNEJ(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-134):
			case (DatabaseAction)(-93):
			case (DatabaseAction)(-92):
			case (DatabaseAction)(-53):
			case (DatabaseAction)(-49):
			case (DatabaseAction)(-48):
				OLNIFPBEFKB(GameLoginManager.currentPlayer.name);
				break;
			case DatabaseAction.UpdateAnalytics:
				InitGUIValues();
				break;
			case (DatabaseAction)9:
				OLKCBDPJAGL();
				break;
			}
		}
	}

	private void FANABKNHEEI(string BCJFMFMDAEM)
	{
		BCMCMKDCLGP.text = BCJFMFMDAEM;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1393f, 394f, 1);
		BCMCMKDCLGP.color = Color.white;
		TweenColor component = BCMCMKDCLGP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public virtual void DJIJBPFLOMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GLOCMLLMBLB));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FAKPCCJBJDF));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IBPGKJPLMJC));
	}

	public void InTutorialAccountChange()
	{
		BOPCKJNBALK = false;
	}

	public void PFPGEMJALMK()
	{
		long num = Singleton<Wallet>.instance.GCEAEGBNLMM();
		long num2 = Singleton<Wallet>.instance.EFNHFKGEDHC();
		long num3 = Convert.ToInt64(Regex.Replace(MCMHCOLPLBD.text, "https://itunes.apple.com/app/warfriends/id", string.Empty));
		long num4 = Convert.ToInt64(Regex.Replace(AGEEJIHGKID.text, "Server send power band reward id {0} which is null setting random {1}", string.Empty));
		IDGDFNCBKLD(num2, num2 - num4);
		CENFGDKGECH(num, num - num3);
	}

	public void FHEDABDGJEJ()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.IEFOIJAFOJC();
		GFKNLLCKJOG.spriteName = gameLevel.CDLBEKECJNK();
		if (gameLevel.KADNNBCOGGL() == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("Testing Player");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(218f, 1606f, 74f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.DLCFFHEKBAA();
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(444f, 1266f, 134f);
		}
	}

	private void IDNMKBDIHGP(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			TweenRotationSpecial.HDHIEDDCJIC(MCNGLCFFPED.gameObject, 1061f, Vector3.forward, 770f, 1006f);
			GuiElementSingle<SettingsDialog>.instance.JGPCJJILAHG();
		}
	}

	private void LCEBJCBMKND()
	{
		OLKCBDPJAGL();
		LOLLPCBCNBJ();
	}

	public void JDOIJDNHJDF()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.IEFOIJAFOJC();
		GFKNLLCKJOG.spriteName = gameLevel.iconName;
		if (gameLevel.displayNumber == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("SquadMembers");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(110f, 1152f, 1415f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.IEFOIJAFOJC();
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(919f, 247f, 1274f);
		}
	}

	public virtual void NAHMANAGNNO()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			DJCJJNKFIKA(GameLoginManager.currentPlayer.name);
			if (!BOPCKJNBALK)
			{
				NKKIINELKAI();
			}
			if (!BOPCKJNBALK)
			{
				UpdateProgress();
			}
			LCEBJCBMKND();
			MNFPHKCMCCB();
			KLPABPJJPIA();
			if (!BOPCKJNBALK)
			{
				CENFGDKGECH(Singleton<Wallet>.instance.GCEAEGBNLMM(), 0L);
			}
			if (!BOPCKJNBALK)
			{
				HFHICNCMHOG(Singleton<Wallet>.instance.gold, 0L);
			}
			TweenRotationSpecial component = MCNGLCFFPED.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			MCNGLCFFPED.transform.localRotation = Quaternion.Euler(846f, 1539f, 679f);
			if (Singleton<GameController>.instance.BAKCODKBCPJ())
			{
				KNCMFCHACOO();
			}
			else
			{
				EPDKEJEFKBL();
			}
			BOPCKJNBALK = false;
		}
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			OLNIFPBEFKB(GameLoginManager.currentPlayer.name);
			if (!BOPCKJNBALK)
			{
				UpdateLevel();
			}
			if (!BOPCKJNBALK)
			{
				UpdateProgress();
			}
			CIAFIJLFEFE();
			EGOMFANNIKL();
			CDGJKDHHILN();
			if (!BOPCKJNBALK)
			{
				CENFGDKGECH(Singleton<Wallet>.instance.warBucks, 0L);
			}
			if (!BOPCKJNBALK)
			{
				HFHICNCMHOG(Singleton<Wallet>.instance.gold, 0L);
			}
			TweenRotationSpecial component = MCNGLCFFPED.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			MCNGLCFFPED.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			if (Singleton<GameController>.instance.isTutorial)
			{
				KNCMFCHACOO();
			}
			else
			{
				NKBGKKOLHDF();
			}
			BOPCKJNBALK = false;
		}
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		BOPCKJNBALK = true;
	}

	public void GIKKPPPIOIB()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		CNCAGHAEIEL.text = gameLevel.IEFOIJAFOJC();
		GFKNLLCKJOG.spriteName = gameLevel.NOHAFIDFPCM();
		if (gameLevel.ELFCEEOLNFJ() == LevelManager.instance.maxDisplayLevel)
		{
			HEAGCIPCKHF.text = Localization.Localize("WRONG NUMBER OF ALL BOXES ");
			HEAGCIPCKHF.color = Colours.blue;
			HEAGCIPCKHF.transform.localScale = new Vector3(812f, 1657f, 304f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			HEAGCIPCKHF.text = gameLevel2.DLCFFHEKBAA();
			HEAGCIPCKHF.color = Colours.grayMax;
			HEAGCIPCKHF.transform.localScale = new Vector3(1355f, 1319f, 1141f);
		}
	}

	private void KNCMFCHACOO()
	{
		AIFGOKIDMMO.transform.localPosition = AIFGOKIDMMO.transform.localPosition.ReplaceY(100f);
		GDBGLCLOKPA.transform.parent.gameObject.SetActive(value: false);
		FLJDOPCHLMM.gameObject.SetActive(value: true);
		FLJDOPCHLMM.isEnabled = false;
		FGOEDANMKED.gameObject.SetActive(value: false);
	}

	private void EDIGDBDIMCE()
	{
		if (NPFFMLLLDAF())
		{
			AEMLFHDNIEB();
		}
	}

	public void KNOAMONLNHH()
	{
		float progress = LevelManager.instance.GetProgress();
		CMIBPCAHILH.fillAmount = progress;
		FFHCPJALBCC.fillAmount = progress;
	}

	private void AEMLFHDNIEB()
	{
		int achievementsNotifications = Singleton<NotificationManager>.instance.GetAchievementsNotifications();
		bool flag = achievementsNotifications > 0;
		EDBMBNCLHFC.SetActive(flag);
		if (flag)
		{
			LMCMDIGDGCJ.text = MEJMLNDFDBP.GMIPFLIEOHD(achievementsNotifications);
		}
	}

	private void PKKEIHEJJFL()
	{
		if (isShowed)
		{
			EGOMFANNIKL();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FPCFLFGMMEF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NADHBIGBANF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BDDIAPDJOEF);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AMNFEHPNDCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LKEPONMFFNK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GLOCMLLMBLB));
		UIEventListener uIEventListener4 = UIEventListener.Get(FLJDOPCHLMM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IFLHAOHDEDH));
		UIEventListener uIEventListener5 = UIEventListener.Get(FGOEDANMKED);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LNJAMABHBDD));
	}

	public void FECABMLBDDO()
	{
		float progress = LevelManager.instance.GetProgress();
		CMIBPCAHILH.fillAmount = progress;
		FFHCPJALBCC.fillAmount = progress;
	}

	private void NADHBIGBANF(GameObject KHAHPAKDIKE)
	{
		if (!GuiScreenSingle<PlayerStatsScreen>.instance.isShowed && !GuiScreenSingle<CardSelectionScreen>.instance.isShowed && !Singleton<GameController>.instance.isTutorial)
		{
			DialogManager.instance.HideAllDialogs();
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, 0.2f, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.isShowed;
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<PlayerStatsScreen>.instance);
			if (flag)
			{
				GuiScreenSingle<PlayerStatsScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
		}
	}

	private void IBPGKJPLMJC(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			TweenRotationSpecial.GHMBHKEBADL(MCNGLCFFPED.gameObject, 289f, Vector3.forward, 903f, 1131f);
			GuiElementSingle<SettingsDialog>.instance.KCOAHMHDFHP();
		}
	}

	private void NILLGBNMFPK(GameObject KHAHPAKDIKE)
	{
		if (!GuiScreenSingle<PlayerStatsScreen>.instance.NPFFMLLLDAF() && !GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.isTutorial)
		{
			DialogManager.instance.HideAllDialogs();
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, 1262f, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.isShowed;
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<PlayerStatsScreen>.instance);
			if (flag)
			{
				GuiScreenSingle<PlayerStatsScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}
}
