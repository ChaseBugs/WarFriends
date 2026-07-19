using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadRecord : PoolableObject
{
	[Header("Size Setter")]
	public UIButtonSetter BMNBNDILFJD;

	[Header("Left Part")]
	public UITexture MNNMIAAEBAF;

	public UILabel GMGJNKFKBFC;

	public UILabel CGIFEHPDBAL;

	public BoxCollider CHAJGDCCIJI;

	public UILabel KJBNHGMJPMK;

	public GameObject MADCDFPEFGB;

	[Header("Center Part")]
	public UILabel DKICPGDLJJL;

	public UILabel FLIBPINJICP;

	[Header("Right Part")]
	public GameObject GCBDFFPBJDN;

	public GameObject IEHFAJFHNDH;

	public GameObject OFANKNCBGLH;

	private AANECPGDMGM DDAGBCNGIOF;

	public virtual void FMIHIFHGPMJ()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FFHOFHADHLD));
	}

	private void ACLHHIEFCCG(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.DPGHIAPIAGC(null, Localization.Localize("RETRY"), Localization.Localize("ID_LEAGUEPROMOTEHINT"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.ShowError(Localization.Localize("Before CreateFromDatabase"), Localization.Localize("PaidInstantBattles"), 966f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.JODOHNCDJNC() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("*.prefab"), Localization.Localize("Player_Avoided_Grenade_On_First_Try"), 1223f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("CURRENT: \n");
			object[] array = new object[6];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[8] = Colours.stringWhite;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("OfflineRoom", array), PFFMMALBPCB, 113f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("game-missions-red-mission-ico");
	}

	public virtual void LLKBNDHBNAL()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHBGDLOABGH));
	}

	private void MOGFALIBGIH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	public virtual void IFHBPEAKGDN()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GEKJMLJCDNN));
	}

	internal void HIJKPGPOPDJ(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Army_Unit_ID" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1453f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "damage:";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 781f, 28f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[6];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("\\", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("-BUFFMAXDESC", Localization.Localize("ammo"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("setAndroidIdSha256", Localization.Localize("ID_STAT_MOSTKILLS"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 0 - 131;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1441f, 1450f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 585f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1600f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 183f - 1034f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BALKIHKFCNF));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LKGOFFHHJLH));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFBCDCCHNDF));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IHDMJJONIFB));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PLLLENMFMNP));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PLLLENMFMNP));
	}

	private void IMEPPOMBMFH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	[CompilerGenerated]
	private void MNIDEMFJEPP(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void MGAAJKMGDPK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void HLIKDJHJINF(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void KHBEPPIDPPH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	internal void HJMJOEKEPHM(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.KHBHCMBGJGJ(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Position" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(768f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "Engineer";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 862f, 1887f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[1];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.INBFDIKBKIA();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_LOGOUT", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("RunningOut", Localization.Localize("Terms: On Age Verification Criteria Not Met "), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("DOWNLOAD", Localization.Localize("ID_NEWASSIGNMENTIN"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 7 - 8;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 270f, 1587f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 382f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1521f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1359f - 1177f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNLLABCJENA));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DNPAGJDGACN));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MDMBILGIEGJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPJNAJDEMHO));
	}

	private void LDKMIFDHPIC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void JIKJNINDDCH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
	}

	private void HLEPHILPNPM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void IFBCDCCHNDF(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.DPGHIAPIAGC(null, Localization.Localize("getErrorMessage"), Localization.Localize("warArenaReminder"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("MASTER"), Localization.Localize("["), 1699f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.FJFIHGNGAKD() <= 1)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("ArenaLives"), Localization.Localize("attrValue14"), 1892f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("eventStart");
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[1] = Colours.stringWhite;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("withAdvertiserSubKeyword", array), MOGFALIBGIH, 417f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("Bad WAR ARENA Data, data= ");
	}

	internal void DCDKAMJFOOK(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.BHEBNFNJMJA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Tickets Spent " + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(423f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "testingidsquadjoinrequest";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1564f, 712f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[3];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_WAITINGFOROPPONENTCARDS", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("'elitepack'0", Localization.Localize(")"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_STARTERASSIGNMENTSEXPIRED", Localization.Localize("InformSquadLeader"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 1 - 175;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1338f, 267f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1328f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1271f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1958f - 1206f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EHBGDLOABGH));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OFBOOJKHGME));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EMEFJILOKCE));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CKMODCCDPIO));
	}

	private void IPJNAJDEMHO(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void DCNENEHEEDH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.KKOOPJBADGJ(null, Localization.Localize("YES"), Localization.Localize("ID_TONORMALLEAGUEHINT2"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("Turret"), Localization.Localize("forever"), 807f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.INBFDIKBKIA() <= 0)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("Assignment ID: {0}\nERROR: {1}\nSTACKTRACE: {2}"), Localization.Localize("bronze1"), 412f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("purchaseCompleteAwaitingVerificationEvent. purchaseData: ");
			object[] array = new object[5];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("Time", array), HLEPHILPNPM, 1607f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_STATE_WAITINGFOROPPONENT");
	}

	private void DNDCCHKFLOA(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.NFECLPLEOBN(null, Localization.Localize("D4"), Localization.Localize("FuseRewardedOptionKey_PostRollContinueButtonText"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("DisableOnStart"), Localization.Localize("Reward"), 520f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.GGJGGJOHMFD() <= 0)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("getGameData"), Localization.Localize("menu-weapon-mp5-elite"), 450f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("accountName");
			object[] array = new object[3];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[3] = Colours.stringWhite;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("S", array), PFFMMALBPCB, 1274f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("BufferId");
	}

	internal void LMMDGOEDPOG(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.MGDCNGGBJLA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Current unit is not delivered at the moment!!!" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1167f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "twitterLogin";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1663f, 135f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[4];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.GGJGGJOHMFD();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ItemRarity_0", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Id", Localization.Localize("false"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("CARD BUDDY - HIDE IN MENU - Player: {0} actual reference count: {1}", Localization.Localize("null"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 8 - -200;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 661f, 451f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1844f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1725f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1328f - 1185f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DEDKIKHEOKN));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KDJMOAFBOBK));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IGCEDMHAMBM));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HIACLNKPFID));
	}

	private void NOANLFMPLEK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void HNPLPBMBDJB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void PFFMMALBPCB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void CKMODCCDPIO(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void GLGEJMMPGIF()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNDCCHKFLOA));
	}

	public virtual void MBJBGBFLJCM()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GHECPOGCJJP));
	}

	private void CDGMEEAEICA(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void JLHMFBILMCF()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DEDKIKHEOKN));
	}

	private void BALKIHKFCNF(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void GEKJMLJCDNN(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize("Server Response:\n"), Localization.Localize("Legacy Shaders/Transparent/DiffuseNew"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("SquadEventUpdate"), Localization.Localize("ReportedPlayerId"), 73f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.INBFDIKBKIA() <= 0)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("a"), Localization.Localize("------------------\n"), 1274f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.GILDIKINMFE(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("{0} {1}");
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[3] = Colours.stringWhite;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("0", array), JBJKLJLEIPE, 672f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("\n***********************************************");
	}

	public virtual void AIJPGJNDFAP()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EELHKHFBMGE));
	}

	private void LFHJLIIDAPP(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	internal void KHNHJDLFDMP(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.BHEBNFNJMJA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("506 MENU ARMY SCREEN UPGRADE ACTIVATED" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1925f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID_TRAINED";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 15f, 1685f);
		KJBNHGMJPMK.text = Localization.LocalizeFormat("getCustomProfileDate", DDAGBCNGIOF.FOICGJEPBGL, DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND(), null, null);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("MedalsOfferMult", Localization.Localize("1 PUSH REMINDER\tLast game won: True\tPush notifications allowed: {0}"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("FinishGameCoopClient", Localization.Localize("MONO HEAP SIZE: "), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 8 - -91;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 35f, 484f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1705f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 672f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 899f - 608f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCBBGFBAAID));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LNLLABCJENA));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KDJMOAFBOBK));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FKBDKMIFIAA));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LIOJHMBJBDG));
	}

	private void LPPOCHMLKGM(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Leader)
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ALREADYLEADER"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 0)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"));
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, DDAGBCNGIOF.MHPNDNJDPGE, Colours.stringWhite), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
			{
				if (FBFJNHLKJEC)
				{
					Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
				}
			});
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Join_Request");
	}

	internal void KFHBEIMFHNO(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1500f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID_RETRY";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 600f, 555f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[8];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.GGJGGJOHMFD();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_READYTIME", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("response: ", Localization.Localize("#PETER# Removing squad left message - message time:{0}, server time:{1}, isInSquad:{2}"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("AtlasPreparer.LoadMenuCoroutine", Localization.Localize("Buy Warbucks Request Success"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 7 - 104;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1268f, 1605f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1209f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1534f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1733f - 384f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKDEOBGPNCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CJCMIFNGKLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FKBDKMIFIAA));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NCLNAJPMJIB));
	}

	private void NCLNAJPMJIB(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void KOMJDNDMJDF()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LDEAIGGHJOO));
	}

	private void OJKNFKFMLGC(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void LKGOFFHHJLH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void IGCEDMHAMBM(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void EHBGDLOABGH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.KKOOPJBADGJ(null, Localization.Localize("elite2"), Localization.Localize("game-label-you-blue"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_EMPTYSQUADMESSAGE"), Localization.Localize(")"), 1509f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.JPMNFIPABND() <= 0)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("minigun_idle"), Localization.Localize("T"), 42f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.IKJNNOFBFGL(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.GILDIKINMFE(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("equals");
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[0] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("menu-assignments-bg", array), NBKLJLIHGFO, 1276f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Level");
	}

	public virtual void FDCNNHBMGKB()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BALKIHKFCNF));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHBGDLOABGH));
	}

	private void CJCMIFNGKLC(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("color=\"#FFD700\""), Localization.Localize("Assignment: Destroy Crates in one battle constructor"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"), Localization.Localize("No main position was set in map definition"), 1523f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.JODOHNCDJNC() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ExtraRewards"), Localization.Localize("squad name"), 935f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("LEAVING ARENA BATTLE");
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[7] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("Wrong_Weapon", array), LDKMIFDHPIC, 266f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("A");
	}

	public virtual void HGOBLCPDFCD()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OIHCFOMBLOK));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GHECPOGCJJP));
	}

	internal void MILEJMBPFEN(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.BHEBNFNJMJA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("\n\t" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(146f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "-";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1766f, 71f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[6];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("PromotedPlayer", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("http://", Localization.Localize("ID_DAILYMISSIONSUNLOCKED"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_SAVEPERCENTLINE", Localization.Localize("AccountId"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 4 - -56;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1149f, 235f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1321f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 479f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1376f - 1732f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FKBDKMIFIAA));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPJNAJDEMHO));
	}

	public virtual void GMGMJHMIBJB()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKDEOBGPNCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LDEAIGGHJOO));
	}

	private void MDMBILGIEGJ(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ODJBILKIKMC(null, Localization.Localize("VipReward2"), Localization.Localize(", action = "));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("302 GAME STARTED"), Localization.Localize("{0} {1}"), 1307f, null, string.Empty, true, true);
			return;
		}
		if (DDAGBCNGIOF.INBFDIKBKIA() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("#AccoutCheck# Facebook account found during account loading!!! - TODO!"), Localization.Localize("Regions"), 115f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("Tank");
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[8] = Colours.stringWhite;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("Player_Avoided_Grenade_On_First_Try", array), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
			{
				if (FBFJNHLKJEC)
				{
					Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
				}
			}, 1458f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("PlayerId");
	}

	internal void PAEGDJIEOMA(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.EGNOJHEGNCC(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_CONFIRM_JOININGSAMESQUAD" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(888f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 23f, 580f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[1];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.MGDCJLAENHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("WarBucks", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("_SceneFogParams", Localization.Localize("ID_WARNING_OFFEREXPIRED"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("apple", Localization.Localize(", on server = "), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 3 - -12;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 801f, 1638f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 208f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 827f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1273f - 188f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KMCEGPLAELF));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNPAGJDGACN));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CDGMEEAEICA));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EMEFJILOKCE));
	}

	public virtual void NFJEOLKAONC()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LEPNNAEADIB));
	}

	internal void MCNJFOGNMIE(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.BHEBNFNJMJA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_READYTIME" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1540f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "FinishGameMultiplayerRPC";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 719f, 421f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[5];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JODOHNCDJNC();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_WARSHOP_PACKS", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("fuseData", Localization.Localize("Assignment error: Skillshots not defined"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_USEREXISTSFACEBOOKTEXT", Localization.Localize("{0} {1}/{2} {3}"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - 81;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1009f, 887f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1500f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1466f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1495f - 1342f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CKDEOBGPNCP));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CJCMIFNGKLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DEDKIKHEOKN));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EMEFJILOKCE));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BMNCINKGCBD));
	}

	private void CKDEOBGPNCP(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void LDEAIGGHJOO(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.LHIBGDFMEMD(null, Localization.Localize("WarBucks"), Localization.Localize("HEAVYTURRET"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)6)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("CARDS_MIN"), Localization.Localize("warp_idle"), 475f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 1)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("Y7R5XKWF2WY9DWGG7DVW"), Localization.Localize("special"), 694f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.OGIEPAIBEJJ(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("ID_FACEBOOKLOGINLEGALTEXT");
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[7] = Colours.stringWhite;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("Medals/", array), MIHELNAEPKD, 19f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("ID_UNIT-BUDDY");
	}

	private void BKAHIGBPKAG(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	public virtual void JKIDPHAGFJI()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNLLABCJENA));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
	}

	private void EJGDBGEIFAD(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	internal void NECCKBBHDMJ(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.KHBHCMBGJGJ(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_CONFIRM_PROMOTETOLEADER" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1584f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "CreateGcAccount with ";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 595f, 782f, 1);
		KJBNHGMJPMK.text = Localization.LocalizeFormat("BoughtIndex", DDAGBCNGIOF.FOICGJEPBGL, DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG(), null, null, null, null, null, null);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("ID_ARENABOXDESCRIPTION_WARBUCKS", Localization.Localize("LevelName"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_CONFIRM_ERROR", Localization.Localize("menu-cards-bronzepack"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 7 - -83;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1457f, 393f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1706f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1508f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1973f - 795f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EELHKHFBMGE));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNDCCHKFLOA));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CDGMEEAEICA));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CKMODCCDPIO));
	}

	private void OIHCFOMBLOK(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	internal void ONJCKDNHGCM(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.GFEJEOKDACB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("N" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1876f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "NO";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1012f, 908f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[4];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("PlayerId", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("N", Localization.Localize("{0} {1}"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_GOLDPACKS", Localization.Localize(", dictionary= "), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 8 - 198;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 46f, 1645f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1416f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 529f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 271f - 1822f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKGOFFHHJLH));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MDMBILGIEGJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LDEAIGGHJOO));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LIOJHMBJBDG));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
	}

	internal void EJKCAHBHEAJ(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.EGNOJHEGNCC(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("D3" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(916f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ArmyPower";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1219f, 1247f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[6];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("menu-medals-ico-big", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("{0}-{1}", Localization.Localize("Wrong_Weapon"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("RewardGold", Localization.Localize("_StartDistance"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - 26;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1487f, 1126f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1855f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1672f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1590f - 54f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EELHKHFBMGE));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CJCMIFNGKLC));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CKMODCCDPIO));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
	}

	private void OFBOOJKHGME(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize("ID_ZEROSECONDS"), Localization.Localize("ID_WARCARDREADY"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran)
		{
			WarningDialog.ShowError(Localization.Localize("{0} {1}"), Localization.Localize("SpawningManagerMultiplayer.prefab"), 51f, null, string.Empty, false, true);
			return;
		}
		if (DDAGBCNGIOF.INBFDIKBKIA() <= 0)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize(">"), Localization.Localize("ID_CONFIRM_LANGUAGECHANGE"), 949f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.IKJNNOFBFGL(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.OGIEPAIBEJJ(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("menu-assignments-type-deploy"), Localization.LocalizeFormat("flawless", Colours.stringBlue, DDAGBCNGIOF.MHPNDNJDPGE, null, Colours.stringWhite, null, null, null, null), BKAHIGBPKAG, 1735f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("menu-squad-1");
	}

	private void EEOFKIHGKDN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	internal void AEPHFMPHLDB(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.GPNONALLJKA(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Player visual Error: id not find: " + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(498f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ROTATED!!! ";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 410f, 928f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[0];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_EMPTYSQUADMESSAGE", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Play_Card_Tutorial", Localization.Localize("ID_ASSIGNMENTSSHORT"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("Beanstalk: Get Squad Details", Localization.Localize("menu-weapon-benelli-starterpack"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - -81;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1957f, 399f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1090f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1097f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 718f - 278f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJFDKPLCKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OFBOOJKHGME));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NAOMGIGAAAL));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IPJNAJDEMHO));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IGCEDMHAMBM));
	}

	internal void ODPMDMFEBBM(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.SetWidth(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("SquadIcons/" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(0.75f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "NULL";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 50f, 33f);
		KJBNHGMJPMK.text = Localization.LocalizeFormat("ID_SQUADMEMBERSLOWER", DDAGBCNGIOF.FOICGJEPBGL, DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.MGDCJLAENHG());
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADMEDALS"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADREQUIREDMEDALS"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 2 - 400;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 37f, 20f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 20f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1300f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 2f - 10f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
	}

	private void LNLLABCJENA(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void HIACLNKPFID(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	internal void NIODFKGGPPG(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.GFEJEOKDACB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("NEW FLAWLESS = " + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(792f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "_MatCap";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1271f, 726f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[0];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.INBFDIKBKIA();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("BuddyCard_", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Shots_Fired", Localization.Localize("DOWNLOADBTN"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("game-card-ico-paralyzethese", Localization.Localize("[Singleton] Instance '"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 6 - 33;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1329f, 333f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 53f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1752f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 960f - 10f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMIHHMBLIFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OIHCFOMBLOK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LEPNNAEADIB));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AICFAMBPHKF));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BMNCINKGCBD));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CKMODCCDPIO));
	}

	private void GPJFDKPLCKI(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void APDLKAAENCJ(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.LHIBGDFMEMD(null, Localization.Localize("ID_LOGININDAYS"), Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("\n\nDEBUG STATE: "), Localization.Localize("ID_YOUNEEDXTICKETSFOREXTRAHEART"), 1503f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.FJFIHGNGAKD() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_SALEPERCENTLINE"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), 37f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.KPDJABMGPDM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("HAVE A NICE DAY");
			object[] array = new object[3];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[1] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("rookie3", array), NOANLFMPLEK, 489f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("{0} [9A9999]/[0BBCFF] {1}");
	}

	private void NKKHIBGMEHK(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void MIHELNAEPKD(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void NBKLJLIHGFO(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void INNGDBBCFMO(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	public virtual void KNKCGBHNGPI()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GEKJMLJCDNN));
	}

	private void PLLLENMFMNP(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void GHECPOGCJJP(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("-"), Localization.Localize("-"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_EXITINGCOOP"), Localization.Localize("N"), 795f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 0)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("Sprite \"{0}\" was used in files:"), Localization.Localize("InApp_ID"), 165f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.OGIEPAIBEJJ(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("Name");
			object[] array = new object[0];
			array[1] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("QA", array), EEOFKIHGKDN, 299f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("WFX_Explosion");
	}

	private void AKIEDKDEILO(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void NAOMGIGAAAL(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.ODJBILKIKMC(null, Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARDPACK"), Localization.Localize("BeAdvisedConnectFacebook"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("reloadTime"), Localization.Localize("TIMEOUT"), 1689f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.DLDHIJAEFHG() <= 0)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_FRIENDREFUSEDREMATCHCOOP"), 1579f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.KPDJABMGPDM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("()Z");
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[3] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("Scraps", array), NOANLFMPLEK, 852f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_STATE_WAITINGFOROPPONENT");
	}

	private void LEPNNAEADIB(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.NFECLPLEOBN(null, Localization.Localize("BatchSizeMax"), Localization.Localize("ID_LOGININDAYS"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("ArenaLives"), Localization.Localize("Enemy units:\n"), 1425f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.FJFIHGNGAKD() <= 0)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("ID_READYTIME"), Localization.Localize("reloadTime"), 1911f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.GILDIKINMFE(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("SquadIcons/");
			object[] array = new object[8];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[4] = Colours.stringWhite;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("Lcom/google/android/gms/games/leaderboard/Leaderboards;", array), HLEPHILPNPM, 1677f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("MyTickets");
	}

	private void IHDMJJONIFB(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.MNBOENNBBGK(null, Localization.Localize("ID_INFO"), Localization.Localize("ID_WARNING_OFFEREXPIRED"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Member)
		{
			WarningDialog.ShowError(Localization.Localize("ShotFrequencyMin"), Localization.Localize("Server price {0} != client price {1} ({2}) "), 1802f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.GGJGGJOHMFD() <= 1)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("Error: No reward "), Localization.Localize("realShotProbability"), 162f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("game-event-gift");
			object[] array = new object[3];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[3] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("SetIsImmortalRPC", array), NOANLFMPLEK, 1434f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Starting stage 3 ");
	}

	public virtual void PLGMICCMDDD()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHBGDLOABGH));
	}

	private void DDPLMDENCGM(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void EMEFJILOKCE(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void BNECAFMNODE(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void JBJKLJLEIPE(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	public virtual void CJIPPDCILLG()
	{
		base.OBCAIFMOPPA();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCBBGFBAAID));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GHECPOGCJJP));
	}

	internal void CFNIELEHKFP(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.DKHLKOFJKPL(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Wrong_Weapon" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1375f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "FacebookId";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1351f, 544f);
		KJBNHGMJPMK.text = Localization.LocalizeFormat("Assignment: Destroy Crates in one battle constructor", DDAGBCNGIOF.FOICGJEPBGL, DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.GGJGGJOHMFD(), null, null);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Deploys_Count", Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("DecalManagerData", Localization.Localize("BoughtIndex"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 2 - -7;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1077f, 1198f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 772f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 60f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 732f - 124f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKGOFFHHJLH));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BALKIHKFCNF));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DNPAGJDGACN));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNPAGJDGACN));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EMEFJILOKCE));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CKMODCCDPIO));
	}

	private void FFHOFHADHLD(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.ODJBILKIKMC(null, Localization.Localize("END SUBSCREEN OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}"), Localization.Localize("S"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)4)
		{
			WarningDialog.ShowError(Localization.Localize("attack"), Localization.Localize("ID_NOTIFICATION_PLAYERLEAGUEEND"), 1251f, null, string.Empty, false, true);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_SLOTUPGRADE_DAMAGE"), Localization.Localize("Saving CSV"), 1919f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.KPDJABMGPDM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("GameReward");
			object[] array = new object[4];
			array[1] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[1] = Colours.stringWhite;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("ID_STATS", array), BKAHIGBPKAG, 248f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("N0");
	}

	private void KDJMOAFBOBK(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ArmyPower"), Localization.Localize("{"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)7)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("#VAVRO# SETTING BOT DIFICULTY TO WEAK"), Localization.Localize("game-card-ico-bulletsponge-full"), 762f, null, string.Empty);
			return;
		}
		if (DDAGBCNGIOF.INBFDIKBKIA() <= 0)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("DogTagCap"), Localization.Localize("withAgencyId"), 1406f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.GILDIKINMFE(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("SyncTrajectoryRPC");
			object[] array = new object[6];
			array[0] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[4] = Colours.stringWhite;
			ConfirmDialog.ShowConfirm(oKMNFHNBMFA, Localization.LocalizeFormat("FuseId", array), EEOFKIHGKDN, 1414f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_SLOTUPGRADE_HEAT");
	}

	private void DNPAGJDGACN(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.FLFEOKMHDBN(null, Localization.Localize("ShotFrequencyMinCannon"), Localization.Localize("SquadWarEndDialog - Database message not set."));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Coleader)
		{
			WarningDialog.ShowError(Localization.Localize("GoldDeducted"), Localization.Localize("-"), 1022f, null, string.Empty, true, true);
			return;
		}
		if (DDAGBCNGIOF.FJFIHGNGAKD() <= 1)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE"), Localization.Localize("Tickets"), 1169f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("no player Id found");
			object[] array = new object[1];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("S", array), HNPLPBMBDJB, 340f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_CONFIRM_FBLOGINCANCELLED");
	}

	public virtual void JFGMMPOFLNC()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPAGJDGACN));
	}

	internal void HNJCBOMLHJP(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.FMILKBAEBHH(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_SQUADEVENT" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(819f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "OnJoinedRoom: {0}";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1418f, 1321f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[0];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("null", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}", Localization.Localize("ID_GOODJOBYOUVEBEENPROMOTED"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ExpectedPrice", Localization.Localize("clipSize"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 1 - -88;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1321f, 194f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 1284f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 109f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 991f - 962f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EHBGDLOABGH));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LDEAIGGHJOO));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BMNCINKGCBD));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
	}

	private void LIOJHMBJBDG(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void AAEFDBDIHIE()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCBBGFBAAID));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KMCEGPLAELF));
	}

	internal void JNCJFCFMMLL(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ReSyncDisabledRPC" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(290f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "NO";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1696f, 1383f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[6];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("+", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("({0}\u00a0/\u00a0{1})", Localization.Localize("Action "), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("onFirstPlaylistDownloaded", Localization.Localize("Id"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - 16;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 136f, 1141f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 926f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1968f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1243f - 369f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OIHCFOMBLOK));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NCBBGFBAAID));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GEKJMLJCDNN));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GHECPOGCJJP));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HIACLNKPFID));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BMNCINKGCBD));
	}

	public virtual void IMEEHKAHJAL()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
	}

	internal void KAECJBLNGLN(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.FMILKBAEBHH(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Win" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(102f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID_UNIT2UPGRADE_UNIT1UPGRADE";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1348f, 471f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[2];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_DAMAGE", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("ChillingoSdkManager", Localization.Localize("CZ"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("localSquadLeaderboard", Localization.Localize("PNManager: Not rescheduling -> Beanstalk.currentTimestamp is zero!"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 3 - -175;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1561f, 119f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 380f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 473f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1367f - 602f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BALKIHKFCNF));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KMCEGPLAELF));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DEDKIKHEOKN));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LIOJHMBJBDG));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
	}

	private void PGNGMBPHGKG(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void PDGEOHKAKJC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	internal void JKGBCBHNPCJ(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.FKBLIJOHBLD(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_READYTIME" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(797f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "DogTags";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1310f, 473f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[7];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.MGDCJLAENHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("Null cannot be saved as last unit.", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("UnitCategoriesReminder", Localization.Localize("WarArenaData"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("Weapon_ID", Localization.Localize("CardWasUsedOnline"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 1 - -141;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 586f, 1219f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 464f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 219f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1391f - 852f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LNLLABCJENA));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CJCMIFNGKLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(APDLKAAENCJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(DDPLMDENCGM));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CDGMEEAEICA));
	}

	private void DOELPHBAAMI(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void HLBHDOFFDGN()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LEPNNAEADIB));
	}

	internal void IOLDKOFDBJO(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.FMILKBAEBHH(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Assets" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(741f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "SquadId";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 277f, 874f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[1];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.FJFIHGNGAKD();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("VipReward1", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Total_Battles", Localization.Localize("ID_TIER"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("veteranpack4", Localization.Localize("#PETER# League Arc Animation - Error - previous: {0}     current: {1}"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - -153;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1694f, 1194f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 453f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 739f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1642f - 1109f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NCBBGFBAAID));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DCNENEHEEDH));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GHECPOGCJJP));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IPJNAJDEMHO));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(DOELPHBAAMI));
	}

	private void OFIGBNLNBKE(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void EELHKHFBMGE(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.LHIBGDFMEMD(null, Localization.Localize("menu-arena-scrap-ico"), Localization.Localize("The shader "));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("SessionManager: Send OnApplicationResumed to Managers !!!"), Localization.Localize("menu-assignments-bar-blue"), 1401f, null, string.Empty, true, true);
			return;
		}
		if (DDAGBCNGIOF.DLDHIJAEFHG() <= 0)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize(" , "), Localization.Localize("Warbucks_Balance"), 1265f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.KPDJABMGPDM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("Tutorial Manager 6: Battles played: ");
			object[] array = new object[3];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("offerMult", array), PFFMMALBPCB, 1494f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("Wrong_Unit");
	}

	private void FKBDKMIFIAA(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void AICFAMBPHKF(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_ELITEUNITNAME"), Localization.Localize("({0}\u00a0/\u00a0{1})"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("tc"), Localization.Localize("Broadcast_Duration"), 1133f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 0)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("Swipe Raycasts End FAILED!"), Localization.Localize("ID_TUTORIAL_KILLENEMYUNITS"), 107f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("Set time to: ");
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[7] = Colours.stringWhite;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("{0} {1}", array), BKAHIGBPKAG, 1968f);
		}
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("bazooka_uncover_left");
	}

	internal void BHMGBCLKOAO(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.KMIFEKCEOPJ(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Unit {0} is not being delivered/upgrade/trained!!!" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1847f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID_STATE_WAITINGFOROPPONENT";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1853f, 64f);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[5];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("Automatic_Equip", array);
		MADCDFPEFGB.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("GameCenterId", Localization.Localize("ID_WAITINGFORFRIEND"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("Player match state {0} to player {1}", Localization.Localize("GameCenterPassword"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 2 - 164;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 989f, 1204f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 921f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 911f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1866f - 290f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKGOFFHHJLH));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CKDEOBGPNCP));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ACLHHIEFCCG));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LDEAIGGHJOO));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OFIGBNLNBKE));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPJNAJDEMHO));
	}

	public virtual void IHMIMLMFKDK()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKIEDKDEILO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LEPNNAEADIB));
	}

	internal void OPNBLDAJCOP(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.FMILKBAEBHH(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Sessions" + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(522f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "menu-army-cat-shooter";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1834f, 1550f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[8];
		array[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.FJFIHGNGAKD();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("Wrong_Unit", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("setPackageName", Localization.Localize("GetRandomUnitsForHost"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_SLOTUPGRADE_DAMAGE", Localization.Localize("tickets"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 5 - 34;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 207f, 1974f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 887f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 88f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 438f - 924f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMIHHMBLIFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKKHIBGMEHK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OFBOOJKHGME));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KMCEGPLAELF));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LIOJHMBJBDG));
	}

	private void KMCEGPLAELF(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize("attack"), Localization.Localize("menu-powerband-health-ico"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.ShowError(Localization.Localize("LifeCount"), Localization.Localize("\n{0}\n"), 414f, null, string.Empty, true);
			return;
		}
		if (DDAGBCNGIOF.MGDCJLAENHG() <= 0)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("ID_VALUEPACKINFORMATIONS"), Localization.Localize("Sniper_Tutorial_Played"), 383f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.IKJNNOFBFGL(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.KPDJABMGPDM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("나가기");
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("AFTER CreateFromDatabase", array), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
			{
				if (FBFJNHLKJEC)
				{
					Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
				}
			}, 1857f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("ID_CONFIRM_LANGUAGECHANGE");
	}

	public virtual void KJDECEJDGHF()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNECAFMNODE));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AICFAMBPHKF));
	}

	private void BMNCINKGCBD(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void DMLEIPJPGOD()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKDEOBGPNCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FFHOFHADHLD));
	}

	internal void JHPCBNIKIII(AANECPGDMGM MIDDFOCJJOP, float IOIPJCICLFH)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Message Manager: Removing message, id = " + DDAGBCNGIOF.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(603f);
		GMGJNKFKBFC.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			CGIFEHPDBAL.text = "ID_CATEGORY_LOW_PL_EXPLOSIVE";
		}
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 67f, 1896f, 1);
		UILabel kJBNHGMJPMK = KJBNHGMJPMK;
		object[] array = new object[0];
		array[0] = DDAGBCNGIOF.FOICGJEPBGL;
		array[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.FJFIHGNGAKD();
		kJBNHGMJPMK.text = Localization.LocalizeFormat("Time", array);
		MADCDFPEFGB.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		DKICPGDLJJL.text = string.Format("Experience", Localization.Localize("menu-squad-{0}"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.CJDHKJFKNAH));
		FLIBPINJICP.text = string.Format("ID_SALEPERCENTLINE", Localization.Localize("game-card-ico-bulletsponge-full"), Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(DDAGBCNGIOF.GDFOENAJEBA));
		int cEHFMMJHCKC = (int)IOIPJCICLFH / 3 - -88;
		MEJMLNDFDBP.COCBCFKJOJE(FLIBPINJICP, 1407f, 1656f, cEHFMMJHCKC);
		float y = FLIBPINJICP.transform.localScale.y;
		MEJMLNDFDBP.COCBCFKJOJE(DKICPGDLJJL, y, 334f, cEHFMMJHCKC);
		OFANKNCBGLH.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = IOIPJCICLFH - 1750f;
		CHAJGDCCIJI.size = CHAJGDCCIJI.size.ReplaceX(num);
		CHAJGDCCIJI.center = CHAJGDCCIJI.center.ReplaceX(num / 1677f - 119f);
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BPEPPCPCKFG));
		UIEventListener uIEventListener2 = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HMIHHMBLIFK));
		UIEventListener uIEventListener3 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LEPNNAEADIB));
		UIEventListener uIEventListener4 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AICFAMBPHKF));
		UIEventListener uIEventListener5 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IGCEDMHAMBM));
		UIEventListener uIEventListener6 = UIEventListener.Get(CHAJGDCCIJI.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
	}

	private void LJNJEPAFGEI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void NCBBGFBAAID(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void LHJBNMDHKGJ()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNLLABCJENA));
		UIEventListener uIEventListener2 = UIEventListener.Get(IEHFAJFHNDH);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AICFAMBPHKF));
	}

	private void BPEPPCPCKFG(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void HMIHHMBLIFK(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void DEDKIKHEOKN(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && CGIFEHPDBAL.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.MNBOENNBBGK(null, Localization.Localize("Arena Wins: "), Localization.Localize("menu-sidetab-challenge"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)4)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("canSendLogs"), Localization.Localize("Assignment Second parameter"), 833f, null, string.Empty, false, true);
			return;
		}
		if (DDAGBCNGIOF.JODOHNCDJNC() <= 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("PowerBandId"), Localization.Localize("NextDailyRewardLocalnotification"), 1445f);
		}
		else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
		}
		else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
		}
		else
		{
			string oKMNFHNBMFA = Localization.Localize("openLogId = ");
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[0] = DDAGBCNGIOF.MHPNDNJDPGE;
			array[6] = Colours.stringWhite;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("There is no definition for card {0}", array), HLEPHILPNPM, 1676f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("InventoryData");
	}

	private void ICPODFPOFEC(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}
}
