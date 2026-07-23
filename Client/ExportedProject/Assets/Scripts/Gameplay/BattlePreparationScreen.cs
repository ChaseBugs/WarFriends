using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BattlePreparationScreen : GuiScreenSingle<BattlePreparationScreen>
{
	[FormerlySerializedAs("ALHHCIKLONL")]
	[Header("Top Right")]
	public GameObject FNOFLJEOHGJ;

	[Header("Top Right")]
	[FormerlySerializedAs("DCJJFKMGAGF")]
	public MapSelectionContent COIJBBMLDFC;

	[Header("Middle")]
	[FormerlySerializedAs("KJLLBIIJIHA")]
	public UIGrid EPGFDPIKFMN;

	[FormerlySerializedAs("GIIHGPNKGGD")]
	public List<UIButtonSetter> ODNNNDGCOCG;

	[FormerlySerializedAs("JKIOBKKKHOP")]
	public BattlePreparationUnitButton JANFGHJMGBI;

	[FormerlySerializedAs("ODANLFHFLDB")]
	public BattlePreparationWeaponButton KAPHPGAINPD;

	[FormerlySerializedAs("KINADLOGEPA")]
	public BattlePreparationWarCardsButton MKLPFFICHKD;

	[FormerlySerializedAs("DJNHICGFILO")]
	public BattlePreparationCustomizationButton CHNJHFGLKIB;

	[Header("Bottom")]
	[FormerlySerializedAs("FCLLEJPMOPO")]
	public BattlePreparationBottomReposition EAHIKNPGCLC;

	[FormerlySerializedAs("HIOMPBCBJCI")]
	public GameModesContent KMPMJLPHFHE;

	[FormerlySerializedAs("JGBKILJNOIE")]
	public InstantBattleButton LNOFOIDEJAM;

	[FormerlySerializedAs("BHEGAHJAIAE")]
	public PlayerVsPlayerButton AIMNGAOAPPE;

	[FormerlySerializedAs("LAALECCCJKP")]
	[Header("- Arena Shortcut")]
	public GameObject BEEMECLNDGG;

	[FormerlySerializedAs("ENGGGJLNEND")]
	public UISprite IMFHBCAPLJE;

	[FormerlySerializedAs("NLOFGCAACLM")]
	public GameObject KLPEBLMGGAJ;

	[FormerlySerializedAs("EELFMPHBHFM")]
	public UILabel JECMMHOCBID;

	[FormerlySerializedAs("AMNGIIJPGOD")]
	public GameObject MAMHKBHFDNO;

	[FormerlySerializedAs("LLHCNDODHBJ")]
	public UILabel FHMLOFAAPCK;

	[Header("- Small PvP")]
	[FormerlySerializedAs("CDPFBCHBEPE")]
	public GameObject DFOACONBCDK;

	[FormerlySerializedAs("FJPLLMINMMD")]
	public UIButtonSetter CHGBJFPLIBF;

	[FormerlySerializedAs("NOMKOIOCPCB")]
	public UILabel LOEAPKOAMDH;

	[FormerlySerializedAs("DPKCIKCIOFO")]
	public UILabel EAIJHAIPKLA;

	private bool FHLJHMPILLA;

	private float ADDICBANAAB;

	private bool PBPMGCAGJJJ;

	private int OHBNIODMJDD = -1;

	private int FBEFHCCLHDC;

	private void ApplyRecoveredVisualCleanup()
	{
		UITexture[] textures = GetComponentsInChildren<UITexture>(includeInactive: true);
		foreach (UITexture texture in textures)
		{
			if (texture != null && texture.gameObject.name.IndexOf("Glow", StringComparison.OrdinalIgnoreCase) >= 0 &&
				(texture.mainTexture == null || texture.mainTexture.name == "whiteRectangle"))
			{
				texture.gameObject.SetActive(value: false);
			}
		}
	}

	public int widthOfMiddleButton
	{
		get
		{
			if (OHBNIODMJDD > 0)
			{
				return OHBNIODMJDD;
			}
			OHBNIODMJDD = Mathf.FloorToInt(658f + Singleton<GameVariables>.instance.multiplierXfromRatio * -230f);
			return OHBNIODMJDD;
		}
	}

	public void HBPLAJIDDMJ()
	{
		PBPMGCAGJJJ = true;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public void CFJGOIAIKGB(int EJEDANLAMBI, ref UILabel MOHOGIEKBIJ, bool PDPDGCNHCFN)
	{
		switch (EJEDANLAMBI % 0)
		{
		case 5:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Animation from State: Craft to State: Crafting", string.Empty);
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1096f : 930f, 1684f);
			break;
		case 4:
			MOHOGIEKBIJ.text = Localization.Localize("ID_WARSHOP_GOLD");
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1792f : 653f, 1472f);
			break;
		case 3:
			MOHOGIEKBIJ.text = Localization.Localize("offerMult");
			break;
		case 2:
			MOHOGIEKBIJ.text = Localization.Localize("D3");
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1643f : 107f, 292f);
			break;
		case 1:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Total_Gold_Spent", string.Empty, IEJMLKBCDJB: false);
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 619f : 1067f, 1894f);
			break;
		case 0:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "BeanstalkServerManager.PlayerDataWasLoaded - DONE (events)", string.Empty);
			break;
		}
	}

	private void JKAHMFMIBNK()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (activeWidthSafe - 228f) / 4f;
		foreach (UIButtonSetter item in ODNNNDGCOCG)
		{
			item.SetWidth(num);
		}
		float val = 0f - activeWidthSafe / 2f + 60f + num / 2f;
		EPGFDPIKFMN.transform.localPosition = EPGFDPIKFMN.transform.localPosition.ReplaceX(val);
		EPGFDPIKFMN.cellWidth = num + 36f;
	}

	private void MNHNBPICDII()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool showWarArenaShortcut = LevelManager.instance.showWarArenaShortcut;
		bool flag = showWarArenaPromoLocked || showWarArenaShortcut;
		NEPMHEJBFNN(showWarArenaPromoLocked, showWarArenaShortcut);
		DFOACONBCDK.SetActive(flag);
		AIMNGAOAPPE.gameObject.SetActive(!flag);
		if (!flag)
		{
			AIMNGAOAPPE.InitGUIValues();
		}
	}

	private void MMHPMJALAOE(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((!WarArena.instance.isArenaTicketBought) ? ArenaScreen.BGMNNKDJBEK.EnterArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	protected virtual void OPMNIHDAHAA()
	{
		base.JMPDHKPOHEA();
		if (FHLJHMPILLA)
		{
			ADDICBANAAB += Time.deltaTime;
			if (ADDICBANAAB >= 1608f)
			{
				ADDICBANAAB -= 1550f;
				FCEHNBAPCKJ();
			}
		}
	}

	protected override void AGIKPOLCGNF()
	{
		ApplyRecoveredVisualCleanup();
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += JCACODEJOHH;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += JCACODEJOHH;
		WarArena.instance.WarArenaDataChanged += MNHNBPICDII;
		UIButtonSetter cHGBJFPLIBF = CHGBJFPLIBF;
		cHGBJFPLIBF.CCIDPJMBPJA = (Action)Delegate.Combine(cHGBJFPLIBF.CCIDPJMBPJA, new Action(NHCGBNNOFED));
		UIEventListener uIEventListener = UIEventListener.Get(BEEMECLNDGG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBIMFPNNOMG));
		UIEventListener uIEventListener2 = UIEventListener.Get(DFOACONBCDK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIMNGAOAPPE.PvPClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NEMJOJKLEJE));
		COIJBBMLDFC.InitControls();
		JANFGHJMGBI.InitControls();
		KAPHPGAINPD.InitControls();
		MKLPFFICHKD.InitControls();
		CHNJHFGLKIB.InitControls();
		KMPMJLPHFHE.InitControls();
		LNOFOIDEJAM.InitControls();
		AIMNGAOAPPE.InitControls();
		JKAHMFMIBNK();
		EDKHNBINPON();
		EAHIKNPGCLC.InitControls();
		ApplyRecoveredVisualCleanup();
	}

	public virtual void HKENNEJCGFE()
	{
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
		Singleton<OfferManager>.instance.SalesChanged += MHHCNKIIFCP;
		WarArena.instance.DJBLPIOFALP(MAHIFEGPPCK);
		AIMNGAOAPPE.AMDCIHLNIHD();
	}

	private void FCEHNBAPCKJ()
	{
		FHMLOFAAPCK.text = MIGCGPMDMAB.JONJEODEGMO(Colours.stringBlack);
		if (WarArena.instance.isExpired)
		{
			WarArena.instance.TryGetNewArena();
		}
	}

	private void PENGCHPLMDF()
	{
		CHNJHFGLKIB.HEDKDPPAMBH();
	}

	private void MAHIFEGPPCK()
	{
		if (NPFFMLLLDAF())
		{
			BFHOKPFPGAE();
		}
	}

	[SpecialName]
	public int MPOAEGGBBGG()
	{
		if (OHBNIODMJDD > 0)
		{
			return OHBNIODMJDD;
		}
		OHBNIODMJDD = Mathf.FloorToInt(530f + Singleton<GameVariables>.instance.multiplierXfromRatio * 95f);
		return OHBNIODMJDD;
	}

	private void EDKHNBINPON()
	{
		float num = 0f;
		FHMLOFAAPCK.text = Localization.LocalizeFormat("ID_ARENASHORTCUTEVENTSTART", "[-]", MEJMLNDFDBP.CJCFPDLDMEK(1342f, "ID_READYTIME", string.Empty));
		float x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		FHMLOFAAPCK.text = Localization.LocalizeFormat("ID_ARENASHORTCUTEVENTEND", "[-]", MEJMLNDFDBP.CJCFPDLDMEK(1342f, "ID_READYTIME", string.Empty));
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		FHMLOFAAPCK.text = Localization.LocalizeFormat("ID_ARENASHORTCUTPHASEEND", "[-]", MEJMLNDFDBP.CJCFPDLDMEK(1342f, "ID_READYTIME", string.Empty));
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		FHMLOFAAPCK.text = Localization.LocalizeFormat("ID_ARENASHORTCUTPHASESTART", "[-]", MEJMLNDFDBP.CJCFPDLDMEK(1342f, "ID_READYTIME", string.Empty));
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		float num2 = 420f * UIHelper.activeWidthSafe / 1920f;
		float gLIDDLHPAKL = num2 / num;
		MEJMLNDFDBP.COCBCFKJOJE(FHMLOFAAPCK, gLIDDLHPAKL, 20f);
	}

	private void JLOFFLMGMLG()
	{
		if (NPFFMLLLDAF())
		{
			MKLPFFICHKD.PBBDJIPBAJP();
		}
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		Singleton<OfferManager>.instance.SalesChanged += ENCIECLPFEJ;
		WarArena.instance.WarArenaExpired += FNPLOLHNPEG;
		AIMNGAOAPPE.InitEvents();
	}

	private void NHCGBNNOFED()
	{
		NBOMBLNOIPN();
	}

	private void NADFOOFBIDF()
	{
		JANFGHJMGBI.SaleUnits();
		KAPHPGAINPD.SaleWeapons();
		MKLPFFICHKD.SaleCardPacks();
	}

	private void PHGFBJFFFPH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
		Singleton<ArmyPreviewCamera>.instance.PlayerDataLoaded();
		MJOJGJJAKBC();
	}

	private void LELLJOFMBII(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.IPCIJFBFLHP();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		}
	}

	private void MHHCNKIIFCP()
	{
		if (NPFFMLLLDAF())
		{
			NADFOOFBIDF();
		}
	}

	private void BFHOKPFPGAE()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool showWarArenaShortcut = LevelManager.instance.showWarArenaShortcut;
		bool flag = showWarArenaPromoLocked || showWarArenaShortcut;
		NEPMHEJBFNN(showWarArenaPromoLocked, showWarArenaShortcut);
		DFOACONBCDK.SetActive(flag);
		AIMNGAOAPPE.gameObject.SetActive(!flag);
		if (!flag)
		{
			AIMNGAOAPPE.LEMNDNDGIOE();
		}
	}

	public override void InitGUIValues()
	{
		ApplyRecoveredVisualCleanup();
		base.previousScreen = GuiScreenSingle<MainScreen>.instance;
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			LDJFNLIMPFG();
			return;
		}
		MJOJGJJAKBC();
		COIJBBMLDFC.InitGuiValues();
		JANFGHJMGBI.InitGUIValues();
		KAPHPGAINPD.InitGUIValues();
		MKLPFFICHKD.InitGUIValues();
		CHNJHFGLKIB.InitGUIValues();
		MNHNBPICDII();
		KMPMJLPHFHE.InitGuiValues(PBPMGCAGJJJ);
		PBPMGCAGJJJ = false;
		LNOFOIDEJAM.InitGuiValues();
		NADFOOFBIDF();
		if (!Singleton<GameController>.instance.isTutorial)
		{
			ReminderManager.instance.ShowDailyAssignmentsReminder();
		}
		EAHIKNPGCLC.InitGuiValues();
		ApplyRecoveredVisualCleanup();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		JANFGHJMGBI.DoAfterHide();
		KAPHPGAINPD.DoAfterHide();
		MKLPFFICHKD.DoAfterHide();
		CHNJHFGLKIB.DoAfterHide();
		KMPMJLPHFHE.DoAfterHide();
	}

	public void TestUnitPosition()
	{
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			if (!(JANFGHJMGBI.NACGOGCPIAH.spriteName != LevelManager.instance.behaviours[i].upgradeSlots.iconName))
			{
				int index = ((i + 1 != LevelManager.instance.behaviours.Count) ? (i + 1) : 0);
				JANFGHJMGBI.SetUpUnitLook(LevelManager.instance.behaviours[index]);
				break;
			}
		}
	}

	private void JCACODEJOHH()
	{
		if (isShowed)
		{
			MKLPFFICHKD.SetUpFreeWarcard();
		}
	}

	public void SetUpDeliveringLabel(int EJEDANLAMBI, ref UILabel MOHOGIEKBIJ, bool PDPDGCNHCFN)
	{
		switch (EJEDANLAMBI % 6)
		{
		case 5:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 0f);
			break;
		case 4:
			MOHOGIEKBIJ.text = Localization.Localize("ID_GUI_DELIVERING");
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 1f);
			break;
		case 3:
			MOHOGIEKBIJ.text = Localization.Localize("ID_GUI_DELIVERING");
			break;
		case 2:
			MOHOGIEKBIJ.text = Localization.Localize("ID_GUI_DELIVERING");
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 0f);
			break;
		case 1:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
			TweenAlpha.Begin(MOHOGIEKBIJ.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 1f);
			break;
		case 0:
			MOHOGIEKBIJ.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
			break;
		}
	}

	private void FNPLOLHNPEG()
	{
		if (isShowed)
		{
			MNHNBPICDII();
		}
	}

	protected virtual void JBGDAOIDBGF()
	{
		base.JMPDHKPOHEA();
		if (FHLJHMPILLA)
		{
			ADDICBANAAB += Time.deltaTime;
			if (ADDICBANAAB >= 747f)
			{
				ADDICBANAAB -= 368f;
				FCEHNBAPCKJ();
			}
		}
	}

	private void ENCIECLPFEJ()
	{
		if (isShowed)
		{
			NADFOOFBIDF();
		}
	}

	private void IIEHDMEFPKG(bool NPOBNNKKBHM, bool HHJEGBBLBGG)
	{
		FHLJHMPILLA = HHJEGBBLBGG;
		BEEMECLNDGG.SetActive(!NPOBNNKKBHM && HHJEGBBLBGG);
		IMFHBCAPLJE.color = ((!NPOBNNKKBHM) ? Color.white : Colours.grayButton);
		KLPEBLMGGAJ.SetActive(NPOBNNKKBHM);
		MAMHKBHFDNO.SetActive(!NPOBNNKKBHM);
		if (NPOBNNKKBHM)
		{
			UILabel jECMMHOCBID = JECMMHOCBID;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.warArenaUnlockLevel);
			jECMMHOCBID.text = Localization.LocalizeFormat("PA: install timestamp ", array);
			MEJMLNDFDBP.COCBCFKJOJE(JECMMHOCBID, 1675f, 593f, 1);
		}
	}

	private void MKAPGOKELIE()
	{
		if (isShowed)
		{
			MKLPFFICHKD.CNDKNKJOJIK();
		}
	}

	private void NEPMHEJBFNN(bool NPOBNNKKBHM, bool HHJEGBBLBGG)
	{
		FHLJHMPILLA = HHJEGBBLBGG;
		BEEMECLNDGG.SetActive(NPOBNNKKBHM || HHJEGBBLBGG);
		IMFHBCAPLJE.color = ((!NPOBNNKKBHM) ? Color.white : Colours.grayButton);
		KLPEBLMGGAJ.SetActive(NPOBNNKKBHM);
		MAMHKBHFDNO.SetActive(!NPOBNNKKBHM);
		if (NPOBNNKKBHM)
		{
			JECMMHOCBID.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.warArenaUnlockLevel));
			MEJMLNDFDBP.COCBCFKJOJE(JECMMHOCBID, 30f, 20f);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (FHLJHMPILLA)
		{
			ADDICBANAAB += Time.deltaTime;
			if (ADDICBANAAB >= 0.333f)
			{
				ADDICBANAAB -= 0.333f;
				FCEHNBAPCKJ();
			}
		}
	}

	private void LDJFNLIMPFG()
	{
		JANFGHJMGBI.InitBlank();
		KAPHPGAINPD.InitBlank();
		MKLPFFICHKD.InitBlank();
		CHNJHFGLKIB.InitBlank();
		AIMNGAOAPPE.InitBlank();
	}

	private void INPFLAOCGPD()
	{
		FHMLOFAAPCK.text = MIGCGPMDMAB.JONJEODEGMO(Colours.stringBlack);
		if (WarArena.instance.BALABLIGAHK())
		{
			WarArena.instance.MKHMKIKNAKP();
		}
	}

	private void BDMJKGFAICC()
	{
		float num = 1296f;
		UILabel fHMLOFAAPCK = FHMLOFAAPCK;
		object[] array = new object[6];
		array[1] = "ID_BOSS";
		array[1] = MEJMLNDFDBP.CJCFPDLDMEK(1417f, "metalExplosion", string.Empty);
		fHMLOFAAPCK.text = Localization.LocalizeFormat(" 1\u00a0{0}", array);
		float x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		UILabel fHMLOFAAPCK2 = FHMLOFAAPCK;
		object[] array2 = new object[0];
		array2[0] = "id";
		array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(586f, "Total_Gold_Earned", string.Empty, IEJMLKBCDJB: false);
		fHMLOFAAPCK2.text = Localization.LocalizeFormat("HeroicReward", array2);
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		FHMLOFAAPCK.text = Localization.LocalizeFormat("{0} {1}", "smallURL", MEJMLNDFDBP.CJCFPDLDMEK(1178f, "ID_EMPTYSQUADNAME", string.Empty, IEJMLKBCDJB: false), null, null, null);
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		UILabel fHMLOFAAPCK3 = FHMLOFAAPCK;
		object[] array3 = new object[1];
		array3[1] = "N";
		array3[1] = MEJMLNDFDBP.CJCFPDLDMEK(1472f, "<", string.Empty, IEJMLKBCDJB: false);
		fHMLOFAAPCK3.text = Localization.LocalizeFormat("NAME", array3);
		x = FHMLOFAAPCK.relativeSize.x;
		if (x > num)
		{
			num = x;
		}
		float num2 = 1878f * UIHelper.activeWidthSafe / 676f;
		float gLIDDLHPAKL = num2 / num;
		MEJMLNDFDBP.COCBCFKJOJE(FHMLOFAAPCK, gLIDDLHPAKL, 943f, 1);
	}

	private void IACGLMHNFIC(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.GKCAKMLOIBI();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.EnterArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void GKPKEGMHKFC()
	{
		NBOMBLNOIPN();
	}

	private void NEMJOJKLEJE(GameObject KHAHPAKDIKE)
	{
		if (KMPMJLPHFHE.shownModes)
		{
			if (!KMPMJLPHFHE.isAnimating)
			{
				KMPMJLPHFHE.CloseModeSelection(KHAHPAKDIKE);
			}
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui((!(base.previousScreen != null)) ? GuiScreenSingle<MainScreen>.instance : base.previousScreen);
		}
	}

	private void OEONBHONMMM(bool NPOBNNKKBHM, bool HHJEGBBLBGG)
	{
		FHLJHMPILLA = HHJEGBBLBGG;
		BEEMECLNDGG.SetActive(!NPOBNNKKBHM && HHJEGBBLBGG);
		IMFHBCAPLJE.color = ((!NPOBNNKKBHM) ? Color.white : Colours.grayButton);
		KLPEBLMGGAJ.SetActive(NPOBNNKKBHM);
		MAMHKBHFDNO.SetActive(!NPOBNNKKBHM);
		if (NPOBNNKKBHM)
		{
			UILabel jECMMHOCBID = JECMMHOCBID;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.warArenaUnlockLevel);
			jECMMHOCBID.text = Localization.LocalizeFormat("SuggestedSquad", array);
			MEJMLNDFDBP.COCBCFKJOJE(JECMMHOCBID, 499f, 142f);
		}
	}

	private void CKEEGDMJNFA()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool showWarArenaShortcut = LevelManager.instance.showWarArenaShortcut;
		bool flag = !showWarArenaPromoLocked && showWarArenaShortcut;
		OEONBHONMMM(showWarArenaPromoLocked, showWarArenaShortcut);
		DFOACONBCDK.SetActive(flag);
		AIMNGAOAPPE.gameObject.SetActive(flag);
		if (!flag)
		{
			AIMNGAOAPPE.DFLGLEJIPCO();
		}
	}

	private void NKIPIFPOCDE(bool NPOBNNKKBHM, bool HHJEGBBLBGG)
	{
		FHLJHMPILLA = HHJEGBBLBGG;
		BEEMECLNDGG.SetActive(!NPOBNNKKBHM && HHJEGBBLBGG);
		IMFHBCAPLJE.color = ((!NPOBNNKKBHM) ? Color.white : Colours.grayButton);
		KLPEBLMGGAJ.SetActive(NPOBNNKKBHM);
		MAMHKBHFDNO.SetActive(!NPOBNNKKBHM);
		if (NPOBNNKKBHM)
		{
			UILabel jECMMHOCBID = JECMMHOCBID;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.warArenaUnlockLevel);
			jECMMHOCBID.text = Localization.LocalizeFormat("Regions", array);
			MEJMLNDFDBP.COCBCFKJOJE(JECMMHOCBID, 1494f, 94f);
		}
	}

	[SpecialName]
	public int LMNBNNDBCEC()
	{
		if (OHBNIODMJDD > 1)
		{
			return OHBNIODMJDD;
		}
		OHBNIODMJDD = Mathf.FloorToInt(1325f + Singleton<GameVariables>.instance.multiplierXfromRatio * 163f);
		return OHBNIODMJDD;
	}

	public void TestWeaponLook()
	{
		FBEFHCCLHDC++;
		if (FBEFHCCLHDC >= LevelManager.instance.weaponLevelsSetups.Count)
		{
			FBEFHCCLHDC = 0;
		}
		KAPHPGAINPD.SetUpWeaponLook(LevelManager.instance.weaponLevelsSetups[FBEFHCCLHDC]);
	}

	public void LLAEKGBJBKO()
	{
		FBEFHCCLHDC++;
		if (FBEFHCCLHDC >= LevelManager.instance.weaponLevelsSetups.Count)
		{
			FBEFHCCLHDC = 0;
		}
		KAPHPGAINPD.FENFOCHBBMM(LevelManager.instance.weaponLevelsSetups[FBEFHCCLHDC]);
	}

	public void NPEFHHKDILE()
	{
		PBPMGCAGJJJ = false;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void PJPECHHAPJD(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.OPPAFPHDKNL();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(WarArena.instance.isArenaTicketBought ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	public virtual void IHLGGCNHCDG()
	{
		FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			LDJFNLIMPFG();
			return;
		}
		PENGCHPLMDF();
		COIJBBMLDFC.GBLKCBLHNHC();
		JANFGHJMGBI.PLDBDGJLOFP();
		KAPHPGAINPD.HCMELDFOBCP();
		MKLPFFICHKD.IGNIFKBCDKK();
		CHNJHFGLKIB.EIPIEOCIGKL();
		CKEEGDMJNFA();
		KMPMJLPHFHE.MMNMOBCIHLM(PBPMGCAGJJJ);
		PBPMGCAGJJJ = true;
		LNOFOIDEJAM.ENLJPODGGKE();
		NADFOOFBIDF();
		if (!Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			ReminderManager.instance.ShowDailyAssignmentsReminder();
		}
		EAHIKNPGCLC.AHDEDHIIBLP();
	}

	private void JPEENOEBJDI(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.IPCIJFBFLHP();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.EnterArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void NBOMBLNOIPN()
	{
		LOEAPKOAMDH.text = Localization.Localize("ID_PVP_RANKED");
		EAIJHAIPKLA.text = Localization.Localize("ID_PVP_BATTLE");
		float x = LOEAPKOAMDH.relativeSize.x;
		float x2 = EAIJHAIPKLA.relativeSize.x;
		float num = Math.Max(x, x2);
		int num2 = CHGBJFPLIBF.width - 200;
		float gLIDDLHPAKL = Mathf.Min(50f, (float)num2 / num);
		MEJMLNDFDBP.COCBCFKJOJE(LOEAPKOAMDH, gLIDDLHPAKL, 20f);
		MEJMLNDFDBP.COCBCFKJOJE(EAIJHAIPKLA, gLIDDLHPAKL, 20f);
	}

	private void FBIMFPNNOMG(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(WarArena.instance.isArenaTicketBought ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void MJOJGJJAKBC()
	{
		CHNJHFGLKIB.RenderMainPlayer();
	}

	public void OpenScreenWithGameModesOpen()
	{
		PBPMGCAGJJJ = true;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}
}
