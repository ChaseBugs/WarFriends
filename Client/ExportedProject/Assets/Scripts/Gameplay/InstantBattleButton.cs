using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class InstantBattleButton : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("KBLIJMBEDGJ")]
	public BoxCollider BCFMHBDMJGM;

	[FormerlySerializedAs("CDPBBIOOOAC")]
	public UISprite LDNCPPBFILM;

	[Header("Locked")]
	[FormerlySerializedAs("BALNNIIDCHF")]
	public GameObject MDAFFKPPCBG;

	[FormerlySerializedAs("CCFGLJELPEG")]
	public UILabel JFJJDKIJEIL;

	[Header("Normal Part")]
	[FormerlySerializedAs("MFNBLJIBPKN")]
	public GameObject BGLGDMKPDKD;

	[FormerlySerializedAs("GIEGCJBMHNA")]
	public UISprite OHGAMIOBMFD;

	[FormerlySerializedAs("BJHHELOCGMH")]
	public UILabel DGJPCANLFIN;

	[FormerlySerializedAs("GNFKDAGFDDE")]
	public UISprite[] DICPNFDFJKP;

	[FormerlySerializedAs("ADNNMCCHAND")]
	public UILabel CDNHKEFKIGF;

	[Header("-Buy 5 Battles")]
	[FormerlySerializedAs("OJBJKPPGOHI")]
	public GameObject PHAIDPNIKIK;

	[FormerlySerializedAs("ADCMDNHOLCL")]
	public UILabel HDPIMDLPFKB;

	[FormerlySerializedAs("DNFHNALNBNJ")]
	public UITable KOAKLMDELFM;

	[FormerlySerializedAs("CBLFOFEGFKH")]
	public UILabel JKABLBAGDLF;

	private int ELPGENFAMIH;

	private float JDPOMFBEFOI;

	private int FACFDHPLFCI;

	private int NKFGNDFKGHC;

	public void PGHAMCBHBOD()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += NEAKJJFODKG;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNDOFCNEGFH));
	}

	private void OAKHBDDOGAO(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1248f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.UpdateArmyPower, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-81)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void IFPHMPIHPHA(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.SendPlayerReport)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void JMPDHKPOHEA()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1556f)
		{
			JDPOMFBEFOI = 1296f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_SQUADEVENT", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				GCFAPIEMIKG();
			}
		}
	}

	private void NHHHBLDDLAE(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.UserAddedToSquadSuccess)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void IBNHJGLOHAE()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += IFPHMPIHPHA;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNHCDEMLPJL));
	}

	private void CDAKKFIHKOF(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)35)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void LKENOAMNLCK()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 279f)
		{
			JDPOMFBEFOI = 80f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "_TintColor", string.Empty);
			}
			else
			{
				EPFKCOHPCAK();
			}
		}
	}

	public void KBKILDENNLM()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1089f)
		{
			JDPOMFBEFOI = 422f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "DogTags", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				LHGNJNBJCMH();
			}
		}
	}

	private void EBHBCHBAJGL(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 707f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-55), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-86)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void FAGLINADKMD(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1651f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.ChangeLanguage, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void GFPPJNOENLE()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1188f)
		{
			JDPOMFBEFOI = 1183f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), ", signature: ", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				KOIODAGEAKE();
			}
		}
	}

	private void BNKHNIFGLGO(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1437f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.InstantBattle, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.CreateSquadUnlockLevel).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void JFMOGGFMHHA()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += MLGKEPFJMHJ;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMGIKCAFKDF));
	}

	private void IMGIKCAFKDF(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1003f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-111), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SecondRenameGoldCost).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void DGIENHPKJNI()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 885f : 256f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("ID_LOADING", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 275f, 770f, 147);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldPackGuaranteedCardsType).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 334f : 457f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1366f : 1027f);
		DGJPCANLFIN.text = string.Format("PlayerProgressRate", Localization.Localize(", p = "), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1750f, 419f, -103);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1232f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1811f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("ExceptionStacktrace");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("BattleId", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 483f, 367f, -98);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	private void PONLDOAKING(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1095f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.UpdateRegionPings, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-106)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void BOPGJFGMNJM()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 247f)
		{
			JDPOMFBEFOI = 799f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "NEW FLAWLESS = ", string.Empty);
			}
			else
			{
				MHAMKMMDBHA();
			}
		}
	}

	private void DPCCAJABKBC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-46))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void ENLJPODGGKE()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1672f : 1630f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat(" ", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 17f, 981f, 65);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 600f : 1094f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 296f : 173f);
		DGJPCANLFIN.text = string.Format("ID_ERROR_SQUADSKILLNOTANUMBER", Localization.Localize("Amount"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1147f, 623f, -80);
		for (int i = 1; i < DICPNFDFJKP.Length; i += 0)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1770f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 573f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("PlayerGold");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array2 = new object[1];
			array2[1] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("com.chillingo.warfriends.android.gplay.localpersistencemanager.LocalPersistenceManager", array2);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1261f, 1993f, -38);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	private void NHIHNGJAGAK(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-86))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void LHGNJNBJCMH()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1003f : 988f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("Count", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 706f, 368f, 52);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppShowSecondTimeAfterLevel).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 769f : 514f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 9f : 249f);
		DGJPCANLFIN.text = string.Format("ChangeWeapon", Localization.Localize("Deposited Warcards: "), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 772f, 498f, -27);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(397f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 133f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("ID_GUI_EQUIPPED");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array2 = new object[0];
			array2[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat(",", array2);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1125f, 1644f, -35);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	public void JAFBNNAACCL()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 716f)
		{
			JDPOMFBEFOI = 1676f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "Product", string.Empty);
			}
			else
			{
				JFKIJCDGJLF();
			}
		}
	}

	private void LJJHNBDDMDB(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1401f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-195), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-25)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.InstantBattle)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void DNMDAAFJEDN(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1997f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)35, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-96)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void JOCHCGHAIGH()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 753f)
		{
			JDPOMFBEFOI = 133f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "ID_TUTORIAL_GRENADERS_DOWN", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				DFKJNOKALCH();
			}
		}
	}

	private void JHIPAEJOHEB(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 360f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)6, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleUnlockLevel).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void LENBEGMGNMG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-136))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void OBEEPOFOMMP(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1124f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-135), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-181)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void EKPBOMOMMFB()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1794f)
		{
			JDPOMFBEFOI = 1795f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "ID_OVERALL", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				FOJGMIGABFI();
			}
		}
	}

	public void HAHKNAIIIPC()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EHEKLENCLMC;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKHBDDOGAO));
	}

	public void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJBGDGLOEDK));
	}

	public void FJJHFMBOFDO()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNDOFCNEGFH));
	}

	private void FEEMLJFHCLC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-85))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void PAMAPPOIONJ(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 463f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-73), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-65)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void FOJGMIGABFI()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 448f : 60f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("N", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1497f, 1564f, -98);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-56)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 409f : 83f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1195f : 264f);
		DGJPCANLFIN.text = string.Format("ID_NA", Localization.Localize("otherInfo"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1053f, 1047f, -132);
		for (int i = 1; i < DICPNFDFJKP.Length; i += 0)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1084f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1855f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("\n");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array2 = new object[0];
			array2[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("WarArenaRuleConcreteMap", array2);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1838f, 1090f, 63);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	public void KOIODAGEAKE()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1414f : 1997f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("'ID_MONTH_'0", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1380f, 813f, 153);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SquadMedalWeight3).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 608f : 1724f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 906f : 1471f);
		DGJPCANLFIN.text = string.Format("N", Localization.Localize("menu-weapon-benelli-starterpack"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1289f, 1576f, -81);
		for (int i = 1; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(792f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1830f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("shotReal");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array2 = new object[0];
			array2[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("ArmyPower", array2);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1550f, 898f, 22);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	private void BBIOLFHDLFF(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)1)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void HNHCDEMLPJL(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1394f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-189), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-99)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void INBJGJOFJMK()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += JEFCFCIKFGC;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNHCDEMLPJL));
	}

	private void MKNMNBCMAEH(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 440f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-143), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void EPFKCOHPCAK()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 665f : 924f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			JFJJDKIJEIL.text = Localization.LocalizeFormat("()Lcom/google/android/gms/games/stats/PlayerStats;", LevelManager.instance.instantBattleUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 38f, 1140f, 116);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-132)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 694f : 862f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1002f : 1307f);
		DGJPCANLFIN.text = string.Format("isAdAvailableForZoneID", Localization.Localize("Card_1_Played"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1623f, 1019f, -54);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1575f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 428f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("{0}\u00a0{1}");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array = new object[0];
			array[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("tickets", array);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1445f, 1108f, 96);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	public void JFKIJCDGJLF()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1505f : 519f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("Beanstalk: On Add GameCenter", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1148f, 951f, 194);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DogTagCap).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 48f : 303f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1492f : 713f);
		DGJPCANLFIN.text = string.Format("RETRY", Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 588f, 883f, 88);
		for (int i = 0; i < DICPNFDFJKP.Length; i += 0)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1317f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 744f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("AccountType");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("Weapon", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1742f, 1719f, 84);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	public void MHAMKMMDBHA()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1639f : 438f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("StoreEntryRoute", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 750f, 1015f, -145);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-133)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 1456f : 1699f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1780f : 782f);
		DGJPCANLFIN.text = string.Format("N", Localization.Localize("Shotgunner"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 466f, 1187f, 97);
		for (int i = 1; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1431f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 647f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("ID_WARNING_OPPONENTDISCONNECTED");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("RESOLUTION_REQUIRED", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 577f, 1578f, -127);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	private void FCAFGIMJHMF(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1874f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-60), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward10).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void EKGKKIDEEMB(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1790f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetAllPlayers, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TutorialUpgradeUnitAfterGames).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void HBIEADMBDHC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-37))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void ELJHCOHCAJI()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1878f)
		{
			JDPOMFBEFOI = 1229f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "ID_GUI_DELIVERING", string.Empty);
			}
			else
			{
				EPFKCOHPCAK();
			}
		}
	}

	private void NJKFMPIBMPE(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-153))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void MLGKEPFJMHJ(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-120))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void Update()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty);
			}
			else
			{
				InitGuiValues();
			}
		}
	}

	public void JMDOFLJIGKO()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += IFPHMPIHPHA;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDFALDANMPD));
	}

	public void DFFACMCAHMO()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1597f : 51f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("BufferId", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1388f, 908f, 119);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-191)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 1985f : 1451f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1848f : 1916f);
		DGJPCANLFIN.text = string.Format("HeroicMissionsCompletionRewardArmyUnitId", Localization.Localize("Note:"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 860f, 1274f, 2);
		for (int i = 1; i < DICPNFDFJKP.Length; i += 0)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(784f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1975f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("menu-squadpoint-ico-bw");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("Directory \"{0}\" does not exists", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 383f, 551f, -42);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	public void HBMEBODGOHH()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1981f : 1627f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			JFJJDKIJEIL.text = Localization.LocalizeFormat("BattleCount", LevelManager.instance.instantBattleUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1454f, 719f, 146);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-19)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 1040f : 364f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1888f : 962f);
		DGJPCANLFIN.text = string.Format("ID_READYTIME", Localization.Localize("menu-camos-alien"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 810f, 664f, -76);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(402f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1756f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("id");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("ID_ZEROSECONDS", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 196f, 1573f, -71);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	private void KONEODGKCEA(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.EquipWeapon)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void JOCALAINFHG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)25)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void OKGDPGPNOPN(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 616f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-105), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-56)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void FMOPBINFAPD(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1638f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-127), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-75)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void EFINNDNBJDN()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EHEKLENCLMC;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNHCDEMLPJL));
	}

	public void ILCKGHGDDJA()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += DPCCAJABKBC;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FAGLINADKMD));
	}

	private void DGHOFIADNLL(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GetSquadWarsDivision)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void INHEEMEAIDJ()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1965f)
		{
			JDPOMFBEFOI = 1368f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", string.Empty);
			}
			else
			{
				KDEIAPCGBLK();
			}
		}
	}

	public void GCFAPIEMIKG()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 742f : 1880f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("Beginners League:{0}  LeagueMedals: {1}  GLobalMedals: {2}", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 311f, 1769f, 73);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-196)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 18f : 678f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1411f : 697f);
		DGJPCANLFIN.text = string.Format("\n", Localization.Localize("DailyMissionsCompletionRewardCards"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1224f, 540f, -72);
		for (int i = 1; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(164f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1673f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("Match start time {0} photon time: {1}");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array2 = new object[0];
			array2[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("withContentType", array2);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1348f, 813f, 103);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	public void AAABJNBFLEG()
	{
		if (ELPGENFAMIH <= 0)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 138f)
		{
			JDPOMFBEFOI = 1286f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "InstantBattleEnded: REWARD WARBUCKS: ", string.Empty);
			}
			else
			{
				KDEIAPCGBLK();
			}
		}
	}

	private void BNDOFCNEGFH(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1531f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-7), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void MJOFGGFFAFL(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 995f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-22), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-192)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void KHAJHGBKIBB(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)27)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void PGJHCMEBADJ(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1853f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-67), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-17)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void IIFBKHDMIAD()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1495f)
		{
			JDPOMFBEFOI = 719f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "HeroicPoints", string.Empty);
			}
			else
			{
				ENLJPODGGKE();
			}
		}
	}

	public void DFKJNOKALCH()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 673f : 1219f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[1];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("S", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1948f, 431f, 10);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-88)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 1239f : 127f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 246f : 279f);
		DGJPCANLFIN.text = string.Format("nextGenerate", Localization.Localize(" (#"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 161f, 1941f, 99);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1136f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1653f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("AchievementCompleted");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("InstantBattleTime", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1194f, 1913f, 7);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	public void KDEIAPCGBLK()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1519f : 1476f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[0];
			array[0] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("GLM: RegisterOrLogin -  playerAccount == NULL", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1044f, 568f, 130);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.NotificationAllowHoursBetween).FLOATVALUE;
		bool flag = FACFDHPLFCI == 1;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 369f : 299f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 506f : 1955f);
		DGJPCANLFIN.text = string.Format("ID_GUI_ACCEPT_PLAYER_CANTJOIN", Localization.Localize("menu-button-promote-ico"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1451f, 1637f, 49);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(1467f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 205f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("CardWasUsedOnline");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("Twitter_Like", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 1740f, 244f, 1);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	public void KHCEMKGDNGH()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1027f : 1464f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			UILabel jFJJDKIJEIL = JFJJDKIJEIL;
			object[] array = new object[1];
			array[1] = LevelManager.instance.instantBattleUnlockLevel;
			jFJJDKIJEIL.text = Localization.LocalizeFormat("Total_Assignment_Completed", array);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1117f, 222f, 155);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-71)).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 884f : 20f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1390f : 171f);
		DGJPCANLFIN.text = string.Format("CONFIRM", Localization.Localize("WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden."), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1457f, 1611f, 29);
		for (int i = 1; i < DICPNFDFJKP.Length; i += 0)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(491f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 1299f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("DOWNLOAD");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("IsOffline", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 11f, 1792f, -34);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	public void AGPINBAMJHF()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += FEEMLJFHCLC;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PGJHCMEBADJ));
	}

	private void IBCMOCGPOEB(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1625f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.AcceptChallenge, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void IKAPFIIHBBA(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1711f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-123), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-117)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void PLAKLPJEAHM()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += FGOEBHNMMIL;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMGIKCAFKDF));
	}

	private void EHEKLENCLMC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-135))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void BHIABNNGKFO()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 660f)
		{
			JDPOMFBEFOI = 768f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "LeagueId", string.Empty, IEJMLKBCDJB: false);
			}
			else
			{
				KHCEMKGDNGH();
			}
		}
	}

	public void HKPIHGBKAHO()
	{
		if (ELPGENFAMIH <= 1)
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1713f)
		{
			JDPOMFBEFOI = 95f;
			if (ELPGENFAMIH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				CDNHKEFKIGF.text = MEJMLNDFDBP.CJCFPDLDMEK(ELPGENFAMIH - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "Turret: Can not find shot target", string.Empty);
			}
			else
			{
				MHAMKMMDBHA();
			}
		}
	}

	private void FGOEBHNMMIL(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-160))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void GFKMDLNPNHP(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-64))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void MGIDNGCKLCF()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ACIGJJCHDKM;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLLJOBLLPLM));
	}

	public void InitGuiValues()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1f : 0.5f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: false);
			JFJJDKIJEIL.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", LevelManager.instance.instantBattleUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 30f, 20f, 280);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 0f : 34f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 33f : 16f);
		DGJPCANLFIN.text = string.Format("{0} {1}({2})[-]", Localization.Localize("ID_INSTANTBATTLE"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 52f, 20f, 380);
		for (int i = 0; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(0.33f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 0f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("ID_MAX");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			HDPIMDLPFKB.text = Localization.LocalizeFormat("ID_5SKIRMISHES", num);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 35f, 20f, 270);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = true;
		}
	}

	public void AIJEMOLBNEC()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += LENBEGMGNMG;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OBEEPOFOMMP));
	}

	private void NEAKJJFODKG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GetSquads)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void ACIGJJCHDKM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-67))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void OLFINDGNMJN(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-79))
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void IODCFNOOAKM()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += MLGKEPFJMHJ;
		UIEventListener uIEventListener = UIEventListener.Get(BCFMHBDMJGM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLLJOBLLPLM));
	}

	private void JEFCFCIKFGC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.DemotePlayer)
		{
			FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	public void GKDKIEJMCFI()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		BCFMHBDMJGM.enabled = !isInstantBattleLocked;
		LDNCPPBFILM.alpha = ((!isInstantBattleLocked) ? 1189f : 1164f);
		MDAFFKPPCBG.SetActive(isInstantBattleLocked);
		BGLGDMKPDKD.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			PHAIDPNIKIK.SetActive(value: true);
			JFJJDKIJEIL.text = Localization.LocalizeFormat("Buy_Weapon_Upgrade", LevelManager.instance.instantBattleUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, 1721f, 1154f, -56);
			return;
		}
		FACFDHPLFCI = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE;
		bool flag = FACFDHPLFCI == 0;
		bool flag2 = FACFDHPLFCI == num;
		OHGAMIOBMFD.gameObject.SetActive(!flag);
		BGLGDMKPDKD.transform.localPosition = BGLGDMKPDKD.transform.localPosition.ReplaceY((!flag) ? 273f : 1381f);
		DGJPCANLFIN.transform.localPosition = DGJPCANLFIN.transform.localPosition.ReplaceY((!flag) ? 1245f : 1796f);
		DGJPCANLFIN.text = string.Format("myapp://myval1/myval2", Localization.Localize("Managers"), Colours.stringBlue, FACFDHPLFCI);
		MEJMLNDFDBP.COCBCFKJOJE(DGJPCANLFIN, 1653f, 1860f, 5);
		for (int i = 1; i < DICPNFDFJKP.Length; i++)
		{
			DICPNFDFJKP[i].color = ((FACFDHPLFCI <= i) ? Colours.grayTime.ReplaceA(727f) : Colours.blue);
		}
		ELPGENFAMIH = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		JDPOMFBEFOI = 96f;
		CDNHKEFKIGF.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			CDNHKEFKIGF.text = Localization.Localize("GoldDeducted");
		}
		PHAIDPNIKIK.SetActive(flag);
		if (flag)
		{
			NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
			UILabel hDPIMDLPFKB = HDPIMDLPFKB;
			object[] array = new object[0];
			array[0] = num;
			hDPIMDLPFKB.text = Localization.LocalizeFormat("setListener", array);
			MEJMLNDFDBP.COCBCFKJOJE(HDPIMDLPFKB, 99f, 698f, -200);
			JKABLBAGDLF.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
			KOAKLMDELFM.repositionNow = false;
		}
	}

	private void MDFALDANMPD(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 900f);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-42), aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-46)).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void KJBGDGLOEDK(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI == 0) ? NKFGNDFKGHC : 0);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance);
			return;
		}
		BCFMHBDMJGM.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.InstantBattle, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	private void JLLJOBLLPLM(GameObject KHAHPAKDIKE)
	{
		int num = ((FACFDHPLFCI != 0) ? 1 : NKFGNDFKGHC);
		List<Tuple<string, string>> aBMLHILNNDM = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1513f);
			return;
		}
		BCFMHBDMJGM.enabled = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetAllMessages, aBMLHILNNDM);
		if (FACFDHPLFCI == 0)
		{
			FACFDHPLFCI = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SquadWarsReminder).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = FACFDHPLFCI;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}
}
