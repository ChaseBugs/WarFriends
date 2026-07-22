using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonsContent : Core_BaseScript
{
	[Header("Single Player Buttons")]
	[FormerlySerializedAs("BFBPFIMFAFE")]
	public GameObject CDAKNFAOGFC;

	[FormerlySerializedAs("DOOEDABDCGL")]
	[Header("-Play Again")]
	public UIButton KKIIENBCDPC;

	[FormerlySerializedAs("JKFMOMCFGDO")]
	public BoxCollider LOKJLHFHGOL;

	[FormerlySerializedAs("JDNGOEAPGKN")]
	[Header("-Continue")]
	public UIButton PLLPDGDIOFL;

	[FormerlySerializedAs("IACEFHIJMJP")]
	public BoxCollider LEJKOAMDPDM;

	[FormerlySerializedAs("LGCIFBKIBBL")]
	public GameObject IBCFNHLOANO;

	[FormerlySerializedAs("BBEAIFIHKNA")]
	public UILabel CJHMCNAJMND;

	[FormerlySerializedAs("EHOHDKPBCBD")]
	public List<UISprite> DNCLMBNGCPN;

	[FormerlySerializedAs("LKOJGGDKFHB")]
	[Header("-Text")]
	public UILabel FDDILBBJNMM;

	[Header("Multi Player Buttons")]
	[FormerlySerializedAs("BAJAADHHKHJ")]
	public GameObject MBBDPKMMNDO;

	[Header("-Play Again")]
	[FormerlySerializedAs("MKLJADOJNMJ")]
	public GameObject EPGKGHLCBGA;

	[FormerlySerializedAs("ECLOLKENFAC")]
	public BoxCollider HKNODJGHCMI;

	[FormerlySerializedAs("KAJOHGEIAFJ")]
	public GameObject CFJGLIMNDNN;

	[FormerlySerializedAs("IMMKIPLMEDI")]
	public List<UISprite> OIAIPHHOBJO;

	[FormerlySerializedAs("KDPIHLJINBB")]
	public UILabel IPKNANOMFDP;

	[FormerlySerializedAs("JAGKFMIIEHK")]
	public UILabel NGICJAPOOGN;

	[Header("--Lootbox Part")]
	[FormerlySerializedAs("KPFPJNCOMAD")]
	public GameObject ALJEPHCHIIJ;

	[FormerlySerializedAs("ODGGNNHGGIM")]
	public UILabel PNPDLNOFBGB;

	[Header("--Winstreak Part")]
	[FormerlySerializedAs("LLIFPIKDAHE")]
	public GameObject DFDFBOAKFID;

	[FormerlySerializedAs("KIHBCLMNLHL")]
	public UITable HHOIKNLFGAO;

	[FormerlySerializedAs("KJOMINEOPIH")]
	public UILabel CEJHJPFCIOO;

	[FormerlySerializedAs("EKBLBFOHMCJ")]
	public WinStreakCounter JMFOJLNHAAK;

	[Header("-Continue")]
	[FormerlySerializedAs("CPHDOHJPKCK")]
	public UIButton JGNKPNNEFIN;

	[FormerlySerializedAs("FIEJINFCLGB")]
	public BoxCollider BOAJOLAOMAP;

	[FormerlySerializedAs("GNJLKHBMPGL")]
	public GameObject KPBBPKBPEMA;

	[FormerlySerializedAs("EAOIOKCOJMP")]
	public UILabel FJOPFDFKLPG;

	[FormerlySerializedAs("FJJFNOBEOCD")]
	[Header("-Text")]
	public UILabel MNEFEENCGOP;

	[Header("Setting")]
	public List<EndScreen.MPJAFCCIOEO> JCGDIGCGHNO;

	private bool IGBKDNOKNKI;

	private float JCAFFELIFAO = 0.2f;

	private float ADDICBANAAB;

	private void OJDKJDJOGGP()
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			string matchTimeStatus = MatchManager.matchTimeStatus;
			MNEFEENCGOP.text = ((!string.IsNullOrEmpty(matchTimeStatus)) ? $"{MatchManager.matchStatusAfterMatch} ({matchTimeStatus})" : MatchManager.matchStatusAfterMatch);
			NDOLNKCJCKM(MatchManager.canRematch);
		}
		else
		{
			NDOLNKCJCKM(GJNGLPOBFJI: true);
			MNEFEENCGOP.text = string.Empty;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			if (KKIIENBCDPC.gameObject.activeInHierarchy)
			{
				string matchTimeStatus2 = MatchManager.matchTimeStatus;
				FDDILBBJNMM.text = ((!string.IsNullOrEmpty(matchTimeStatus2)) ? $"{MatchManager.matchStatusAfterMatch} ({matchTimeStatus2})" : MatchManager.matchStatusAfterMatch);
				IDAGBBPEGJG(MatchManager.canRematch);
			}
			else
			{
				FDDILBBJNMM.text = string.Empty;
			}
		}
		else
		{
			IDAGBBPEGJG(GJNGLPOBFJI: true);
			FDDILBBJNMM.text = string.Empty;
		}
	}

	private void FAOIFNFDEGO(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	private void AKLKMMLHBKP(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.NextButtonClick(EndScreen.MPJAFCCIOEO.WarCards);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			KDGBFENEJEP();
		}
	}

	private void IDAGBBPEGJG(bool GJNGLPOBFJI)
	{
		LOKJLHFHGOL.enabled = GJNGLPOBFJI;
		foreach (UISprite item in DNCLMBNGCPN)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void MAFPGDJMAPD()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1001f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1558f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 103f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, useLocal: false);
		component.onFinished = KAFFDBAFIIF;
	}

	public void NNGKAAGFGPA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KKIIENBCDPC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MIPACGEIHGG));
		UIEventListener uIEventListener2 = UIEventListener.Get(PLLPDGDIOFL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AGJHBDGEHLH));
		UIEventListener uIEventListener3 = UIEventListener.Get(EPGKGHLCBGA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BJCHGKOPDBI));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGNKPNNEFIN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BNMJLHGLHFD));
		MatchManager.MatchStateChanged += FGHFIJGGPAO;
		Singleton<NotificationManager>.instance.UnitDelivered += PPOFIBLBLBM;
		Singleton<NotificationManager>.instance.WeaponDelivered += delegate
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				KDGBFENEJEP();
			}
		};
		Singleton<NotificationManager>.instance.VisualWasShown += delegate
		{
			Debug.Log("End Screen - button content - visual notification changed. End Screen active " + GuiScreenSingle<EndScreen>.instance.isShowed + " BUTTONS CONTENT " + base.gameObject.activeSelf);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				KDGBFENEJEP();
			}
		};
	}

	[CompilerGenerated]
	private void KMKGBGLHOGO(UITweener PHNEAHCCJOL)
	{
		FCMLDGPJHOG();
	}

	private void DKBPOEIFGCA()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(0f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(-42f));
		tweenPosition.onFinished = delegate
		{
			KAONEFDFMMD();
		};
	}

	private void POHJBFLFAMB(UITweener PHNEAHCCJOL)
	{
		FCMLDGPJHOG();
	}

	protected void CJBJGDCNLOG()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 433f)
		{
			ADDICBANAAB -= 845f;
			NNBDNFNKHLC();
		}
		if (IGBKDNOKNKI != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			AOPDKJLCCOJ(IGBKDNOKNKI);
		}
	}

	[CompilerGenerated]
	private void EEEMOKHOHJH(UITweener PHNEAHCCJOL)
	{
		KAONEFDFMMD();
	}

	private void AIBCLDMNEHJ(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	private void MNMIJMLJMKB()
	{
		object[] array = new object[0];
		array[1] = "CannonDamage";
		array[1] = GuiScreenSingle<EndScreen>.instance.isShowed;
		array[2] = "()Z";
		array[1] = base.gameObject.activeSelf;
		Debug.Log(string.Concat(array));
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			KDGBFENEJEP();
		}
	}

	public void SetActiveAccordingToTab(EndScreen.MPJAFCCIOEO JKBOBJKCENJ)
	{
		base.gameObject.SetActive(JCGDIGCGHNO.Contains(JKBOBJKCENJ));
	}

	private void ECBBGHHAFHG()
	{
		bool flag = Singleton<GameController>.instance.FJOGEJNMNHI();
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag2 = !Singleton<GameController>.instance.isRandomMatchMaking || winStreak == null || winStreak.isActive;
		NGICJAPOOGN.gameObject.SetActive(!flag && !flag2);
		ALJEPHCHIIJ.SetActive(flag);
		if (flag)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 1)
			{
				text = Localization.Localize("ID_MYWARCARDS");
			}
			else
			{
				object[] array = new object[0];
				array[0] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("_MIN_", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 971f, 1670f, 9);
		}
		DFDFBOAKFID.SetActive(flag2);
		if (flag2)
		{
			CEJHJPFCIOO.text = string.Format("Grenade_Throwing_Tutorial_Duration", Localization.Localize("#VOJTA# ERROR ACHIEVEMENT ALREADY CLAIMED!!"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = false;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.BGHNMCPLIPE();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MHLJHMOPDAO(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = CKBKNEGIDBM;
			}
		}
		else
		{
			JMFOJLNHAAK.PEHBGMEHFEM();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (flag && flag2)
		{
			LGLPGGDEDDM();
		}
		else
		{
			IMDIFONPLMC();
		}
	}

	private void EEGLBHHGIGE()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(154f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1678f);
	}

	protected void OOCJOBIIKAH()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 581f)
		{
			ADDICBANAAB -= 1905f;
			COPBIADLDME();
		}
		if (IGBKDNOKNKI != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			AOPDKJLCCOJ(IGBKDNOKNKI);
		}
	}

	private void JMIDHMAJNBK()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(0f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(18f);
	}

	private void MAPFOPJJBOK(bool GJNGLPOBFJI)
	{
		LOKJLHFHGOL.enabled = GJNGLPOBFJI;
		foreach (UISprite item in DNCLMBNGCPN)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void CBMKOGDMFOH(UITweener PHNEAHCCJOL)
	{
		NMLAGLCDDLN();
	}

	private void JODAOEMJJIG()
	{
		object[] array = new object[4];
		array[1] = "Sniper_Tutorial_Played";
		array[1] = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
		array[8] = "()I";
		array[0] = base.gameObject.activeSelf;
		Debug.Log(string.Concat(array));
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			KDGBFENEJEP();
		}
	}

	private void AAGHLEPCFHE()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1996f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(847f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 617f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			FCMLDGPJHOG();
		};
	}

	internal void NGOMHEHCDMG()
	{
		IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		AOPDKJLCCOJ(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		FDDILBBJNMM.text = string.Empty;
		bool isSinglePlayer = GuiScreenSingle<EndScreen>.instance.isSinglePlayer;
		CDAKNFAOGFC.SetActive(isSinglePlayer);
		MBBDPKMMNDO.SetActive(isSinglePlayer);
		if (isSinglePlayer)
		{
			MNEFEENCGOP.text = string.Empty;
			bool isTutorial = Singleton<GameController>.instance.isTutorial;
			bool active = Singleton<GameController>.instance.MNMLNIMFMJP != (GameController.HKGHCIEPGEL)49 && !isTutorial;
			KKIIENBCDPC.gameObject.SetActive(active);
			if (KKIIENBCDPC.gameObject.activeSelf)
			{
				ODMOAGLMILJ(GJNGLPOBFJI: true);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
				FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool flag = Singleton<GameController>.instance.FJOGEJNMNHI();
			IPKNANOMFDP.text = Localization.Localize((!flag) ? "ID_YOUWEREDISCONNECTED" : "startActivity");
			NGICJAPOOGN.text = Localization.Localize((!flag) ? "NextUpgradePrice" : "#Mission Rewards# New missions data (midnight or heroic completed)");
			CFJGLIMNDNN.SetActive(flag);
			MEJMLNDFDBP.COCBCFKJOJE(IPKNANOMFDP, 1948f, 1043f, -23);
			JBFFNINEEFL();
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		KDGBFENEJEP();
	}

	private void KAFFDBAFIIF(UITweener PHNEAHCCJOL)
	{
		FCMLDGPJHOG();
	}

	private void KPGDOMIOFDJ()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			KLKALGKNLKL();
		}
	}

	private void FGHFIJGGPAO(GLFPILGCAPM ENCEFOOPBMK)
	{
		if (!GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD() && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
			FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	private void BJCHGKOPDBI(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.PlayAgainButtonClick(EndScreen.MPJAFCCIOEO.WarCards);
	}

	internal void IEOAGCPNBBI()
	{
		IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		MFCJOPPBLBG(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		FDDILBBJNMM.text = string.Empty;
		bool flag = GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD();
		CDAKNFAOGFC.SetActive(flag);
		MBBDPKMMNDO.SetActive(flag);
		if (flag)
		{
			MNEFEENCGOP.text = string.Empty;
			bool flag2 = Singleton<GameController>.instance.DAIEAMEFGIE();
			bool active = Singleton<GameController>.instance.MNMLNIMFMJP != (GameController.HKGHCIEPGEL)(-97) && flag2;
			KKIIENBCDPC.gameObject.SetActive(active);
			if (KKIIENBCDPC.gameObject.activeSelf)
			{
				IDAGBBPEGJG(GJNGLPOBFJI: true);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
				FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
			IPKNANOMFDP.text = Localization.Localize((!isRandomMatchMaking) ? "1" : "Ignore_Text_{0}{1}_Dont_Ask_Again");
			NGICJAPOOGN.text = Localization.Localize((!isRandomMatchMaking) ? "{0} {1}{2}" : "Weapon");
			CFJGLIMNDNN.SetActive(isRandomMatchMaking);
			MEJMLNDFDBP.COCBCFKJOJE(IPKNANOMFDP, 1966f, 1740f, 56);
			JBFFNINEEFL();
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		KDGBFENEJEP();
	}

	private void AOPDKJLCCOJ(bool GKAKLBKHBMP)
	{
		Debug.Log("Before CreateFromDatabase" + GKAKLBKHBMP);
		BOAJOLAOMAP.enabled = GKAKLBKHBMP;
		LEJKOAMDPDM.enabled = GKAKLBKHBMP;
		LOKJLHFHGOL.enabled = GKAKLBKHBMP;
		HKNODJGHCMI.enabled = GKAKLBKHBMP;
	}

	private void MLHEPKKBHEH(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.AEGGGBJBLAF(EndScreen.MPJAFCCIOEO.Ribbons);
	}

	private void GHMINFINIPM()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			GKEHIMFKMOJ();
		}
	}

	private void KNCACAJBLBP()
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag = Singleton<GameController>.instance.isRandomMatchMaking && winStreak != null && winStreak.isActive;
		NGICJAPOOGN.gameObject.SetActive(!isRandomMatchMaking && !flag);
		ALJEPHCHIIJ.SetActive(isRandomMatchMaking);
		if (isRandomMatchMaking)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			PNPDLNOFBGB.text = ((remainingMatchesToNextLootbox != 1) ? Localization.LocalizeFormat("ID_NEWLOOTBOXINBATTLES", remainingMatchesToNextLootbox) : Localization.Localize("ID_NEWLOOTBOXINBATTLE"));
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 30f, 20f, 520);
		}
		DFDFBOAKFID.SetActive(flag);
		if (flag)
		{
			CEJHJPFCIOO.text = string.Format("{0} {1}", Localization.Localize("ID_WINSTREAK"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = true;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.JCMHGOGNMFO();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MHLJHMOPDAO(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = delegate
				{
					KNCACAJBLBP();
				};
			}
		}
		else
		{
			JMFOJLNHAAK.JCMHGOGNMFO();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (isRandomMatchMaking && flag)
		{
			GMAGDEDJNEA();
		}
		else
		{
			JMIDHMAJNBK();
		}
	}

	private void EHCGMDOCAGF()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			LAGBCMICDGN();
		}
	}

	private void NDOLNKCJCKM(bool GJNGLPOBFJI)
	{
		HKNODJGHCMI.enabled = GJNGLPOBFJI;
		foreach (UISprite item in OIAIPHHOBJO)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void LFCPEKIPGLJ()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			GANHJPDLJIE();
		}
	}

	public void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KKIIENBCDPC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPEFKODOPKO));
		UIEventListener uIEventListener2 = UIEventListener.Get(PLLPDGDIOFL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AGJHBDGEHLH));
		UIEventListener uIEventListener3 = UIEventListener.Get(EPGKGHLCBGA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KPNBGJIFING));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGNKPNNEFIN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NNJFFOOJBOA));
		MatchManager.MatchStateChanged += FGHFIJGGPAO;
		Singleton<NotificationManager>.instance.UnitDelivered += MNNDDFOKIKA;
		Singleton<NotificationManager>.instance.WeaponDelivered += EHCGMDOCAGF;
		Singleton<NotificationManager>.instance.VisualWasShown += MNMIJMLJMKB;
	}

	private void OCHNNIPEKHD(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ReplayButtonClick(EndScreen.MPJAFCCIOEO.None);
	}

	private void GIFICGKMGAP(bool GKAKLBKHBMP)
	{
		Debug.Log("ID_READYTIME" + GKAKLBKHBMP);
		BOAJOLAOMAP.enabled = GKAKLBKHBMP;
		LEJKOAMDPDM.enabled = GKAKLBKHBMP;
		LOKJLHFHGOL.enabled = GKAKLBKHBMP;
		HKNODJGHCMI.enabled = GKAKLBKHBMP;
	}

	private void NMLAGLCDDLN()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1972f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1785f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 239f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = CPAKCFCGDLM;
	}

	private void ACBANEKCLKD()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1046f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1616f);
	}

	[CompilerGenerated]
	private void CNGALIHCOJG(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		Debug.Log("End Screen - button content - visual notification changed. End Screen active " + GuiScreenSingle<EndScreen>.instance.isShowed + " BUTTONS CONTENT " + base.gameObject.activeSelf);
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			KDGBFENEJEP();
		}
	}

	private void KPNBGJIFING(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.KJINDMFGFAI(EndScreen.MPJAFCCIOEO.None);
	}

	private void KDGBFENEJEP()
	{
		int numberOfEndScreenNotifications = Singleton<NotificationManager>.instance.GetNumberOfEndScreenNotifications();
		CJHMCNAJMND.text = numberOfEndScreenNotifications.ToString();
		FJOPFDFKLPG.text = numberOfEndScreenNotifications.ToString();
		IBCFNHLOANO.SetActive(value: false);
		KPBBPKBPEMA.SetActive(numberOfEndScreenNotifications > 0);
	}

	private void KFFHOOEOLEI()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(938f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(776f));
		tweenPosition.onFinished = LLHNOONMOHA;
	}

	private void NLPKLNFOGAE(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.AEGGGBJBLAF(EndScreen.MPJAFCCIOEO.WarCards);
	}

	private void KAONEFDFMMD()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(0f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(78f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 10f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			FCMLDGPJHOG();
		};
	}

	private void FCMLDGPJHOG()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(-60f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(18f));
		tweenPosition.onFinished = delegate
		{
			GMAGDEDJNEA();
		};
	}

	private void PPOFIBLBLBM()
	{
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			KDGBFENEJEP();
		}
	}

	private void JPMBAAOHMJD(bool GJNGLPOBFJI)
	{
		HKNODJGHCMI.enabled = GJNGLPOBFJI;
		foreach (UISprite item in OIAIPHHOBJO)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void KLKALGKNLKL()
	{
		int num = Singleton<NotificationManager>.instance.OGEPEFMHMJC();
		CJHMCNAJMND.text = num.ToString();
		FJOPFDFKLPG.text = num.ToString();
		IBCFNHLOANO.SetActive(value: false);
		KPBBPKBPEMA.SetActive(num > 0);
	}

	public void GOBANJDMLBI(EndScreen.MPJAFCCIOEO JKBOBJKCENJ)
	{
		base.gameObject.SetActive(JCGDIGCGHNO.Contains(JKBOBJKCENJ));
	}

	private void MLKJCHMOKMO()
	{
		ECBBGHHAFHG();
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			KDGBFENEJEP();
		}
	}

	private void ODJMGOCKFHH(bool GJNGLPOBFJI)
	{
		HKNODJGHCMI.enabled = GJNGLPOBFJI;
		foreach (UISprite item in OIAIPHHOBJO)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void LLKEOOCFKOO()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(5f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1694f);
	}

	private void MIPACGEIHGG(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.AOOIMBPEKME((EndScreen.MPJAFCCIOEO)8);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KKIIENBCDPC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJPABAIINKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(PLLPDGDIOFL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKLKMMLHBKP));
		UIEventListener uIEventListener3 = UIEventListener.Get(EPGKGHLCBGA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BJCHGKOPDBI));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGNKPNNEFIN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BNMJLHGLHFD));
		MatchManager.MatchStateChanged += KMKIKLKOALI;
		Singleton<NotificationManager>.instance.UnitDelivered += delegate
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				KDGBFENEJEP();
			}
		};
		Singleton<NotificationManager>.instance.WeaponDelivered += delegate
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				KDGBFENEJEP();
			}
		};
		Singleton<NotificationManager>.instance.VisualWasShown += delegate
		{
			Debug.Log("End Screen - button content - visual notification changed. End Screen active " + GuiScreenSingle<EndScreen>.instance.isShowed + " BUTTONS CONTENT " + base.gameObject.activeSelf);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				KDGBFENEJEP();
			}
		};
	}

	private void IJKOBCIPJAO(UITweener PHNEAHCCJOL)
	{
		LGLPGGDEDDM();
	}

	private void GMAGDEDJNEA()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(60f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(18f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 10f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			DKBPOEIFGCA();
		};
	}

	protected void CHHKMBGOMJJ()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 623f)
		{
			ADDICBANAAB -= 1935f;
			COPBIADLDME();
		}
		if (IGBKDNOKNKI != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			MFCJOPPBLBG(IGBKDNOKNKI);
		}
	}

	public void POJPIIDOEKC(EndScreen.MPJAFCCIOEO JKBOBJKCENJ)
	{
		base.gameObject.SetActive(JCGDIGCGHNO.Contains(JKBOBJKCENJ));
	}

	private void GOLCAIGOKGI(bool GJNGLPOBFJI)
	{
		HKNODJGHCMI.enabled = GJNGLPOBFJI;
		foreach (UISprite item in OIAIPHHOBJO)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void LLHNOONMOHA(UITweener PHNEAHCCJOL)
	{
		MFCPMPLCOIO();
	}

	private void BNMJLHGLHFD(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ContinueButtonClick(EndScreen.MPJAFCCIOEO.WarCards);
	}

	private void JKLINBICFMF(GLFPILGCAPM ENCEFOOPBMK)
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
			FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	private void BAADBPMFEHE()
	{
		EDNPMLJILFK();
	}

	private void KMKIKLKOALI(GLFPILGCAPM ENCEFOOPBMK)
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
			FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	private void AKILFLIPGKG()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1243f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1587f);
	}

	private void CPAKCFCGDLM(UITweener PHNEAHCCJOL)
	{
		KIBKOFBBMDJ();
	}

	private void GANHJPDLJIE()
	{
		int numberOfEndScreenNotifications = Singleton<NotificationManager>.instance.GetNumberOfEndScreenNotifications();
		CJHMCNAJMND.text = numberOfEndScreenNotifications.ToString();
		FJOPFDFKLPG.text = numberOfEndScreenNotifications.ToString();
		IBCFNHLOANO.SetActive(value: true);
		KPBBPKBPEMA.SetActive(numberOfEndScreenNotifications > 0);
	}

	private void OJPABAIINKE(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ReplayButtonClick(EndScreen.MPJAFCCIOEO.WarCards);
	}

	private void AGHAAHBJAGF(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.AEGGGBJBLAF(EndScreen.MPJAFCCIOEO.Ribbons);
	}

	private void JPOPOCJFCKP()
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			string text = MatchManager.NEOPOLEEEGE();
			MNEFEENCGOP.text = ((!string.IsNullOrEmpty(text)) ? string.Format("ID_JOINSQUADDESCRIPTION3", MatchManager.matchStatusAfterMatch, text) : MatchManager.matchStatusAfterMatch);
			ODJMGOCKFHH(MatchManager.OILNKFOADMO());
		}
		else
		{
			JPMBAAOHMJD(GJNGLPOBFJI: true);
			MNEFEENCGOP.text = string.Empty;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			if (KKIIENBCDPC.gameObject.activeInHierarchy)
			{
				string text2 = MatchManager.NEOPOLEEEGE();
				FDDILBBJNMM.text = ((!string.IsNullOrEmpty(text2)) ? string.Format("ID_UNIT2UPGRADE_UNIT1BUY", MatchManager.matchStatusAfterMatch, text2) : MatchManager.matchStatusAfterMatch);
				MAPFOPJJBOK(MatchManager.GFGPGJCGAPO());
			}
			else
			{
				FDDILBBJNMM.text = string.Empty;
			}
		}
		else
		{
			MAPFOPJJBOK(GJNGLPOBFJI: false);
			FDDILBBJNMM.text = string.Empty;
		}
	}

	private void EOOCMJEABIL()
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag = !Singleton<GameController>.instance.FJOGEJNMNHI() || winStreak == null || winStreak.isActive;
		NGICJAPOOGN.gameObject.SetActive(!isRandomMatchMaking && flag);
		ALJEPHCHIIJ.SetActive(isRandomMatchMaking);
		if (isRandomMatchMaking)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 0)
			{
				text = Localization.Localize("ID_SQUADLEVEL");
			}
			else
			{
				object[] array = new object[0];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("Notifications", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 160f, 851f, 181);
		}
		DFDFBOAKFID.SetActive(flag);
		if (flag)
		{
			CEJHJPFCIOO.text = string.Format("ID_CONFIRM_LEAVESQUADLEADER_TEXT", Localization.Localize("Omitting object: "), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = true;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.JCMHGOGNMFO();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.FPNEIICLJFG(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = delegate
				{
					KNCACAJBLBP();
				};
			}
		}
		else
		{
			JMFOJLNHAAK.PEHBGMEHFEM();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (isRandomMatchMaking && flag)
		{
			LGLPGGDEDDM();
		}
		else
		{
			JMIDHMAJNBK();
		}
	}

	private void NOIEGPCNLBG(GLFPILGCAPM ENCEFOOPBMK)
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
			FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	internal void PILDGJHBBIJ()
	{
		IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		GGDHNJMEBJG(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		FDDILBBJNMM.text = string.Empty;
		bool isSinglePlayer = GuiScreenSingle<EndScreen>.instance.isSinglePlayer;
		CDAKNFAOGFC.SetActive(isSinglePlayer);
		MBBDPKMMNDO.SetActive(!isSinglePlayer);
		if (isSinglePlayer)
		{
			MNEFEENCGOP.text = string.Empty;
			bool isTutorial = Singleton<GameController>.instance.isTutorial;
			bool active = Singleton<GameController>.instance.MNMLNIMFMJP != GameController.HKGHCIEPGEL.MissionSuccess && !isTutorial;
			KKIIENBCDPC.gameObject.SetActive(active);
			if (KKIIENBCDPC.gameObject.activeSelf)
			{
				IDAGBBPEGJG(GJNGLPOBFJI: true);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
				FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
			IPKNANOMFDP.text = Localization.Localize((!isRandomMatchMaking) ? "ID_PLAYAGAIN" : "ID_RANKEDBATTLE");
			NGICJAPOOGN.text = Localization.Localize((!isRandomMatchMaking) ? "ID_AGAINSTTHESAMEOPPONENT" : "ID_ENEMYWILLBESELECTEDRANDOMLY");
			CFJGLIMNDNN.SetActive(isRandomMatchMaking);
			MEJMLNDFDBP.COCBCFKJOJE(IPKNANOMFDP, 58f, 29f, 580);
			KNCACAJBLBP();
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		KDGBFENEJEP();
	}

	private void OGKNBALNJJK(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ReplayButtonClick(EndScreen.MPJAFCCIOEO.Ribbons);
	}

	private void NNBDNFNKHLC()
	{
		if (!GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD() && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			string text = MatchManager.NEOPOLEEEGE();
			MNEFEENCGOP.text = ((!string.IsNullOrEmpty(text)) ? string.Format("Black_market_triggered", MatchManager.matchStatusAfterMatch, text) : MatchManager.matchStatusAfterMatch);
			NDOLNKCJCKM(MatchManager.EEGOFPNKOCO());
		}
		else
		{
			GOLCAIGOKGI(GJNGLPOBFJI: false);
			MNEFEENCGOP.text = string.Empty;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			if (KKIIENBCDPC.gameObject.activeInHierarchy)
			{
				string matchTimeStatus = MatchManager.matchTimeStatus;
				FDDILBBJNMM.text = ((!string.IsNullOrEmpty(matchTimeStatus)) ? string.Format("{0}th", MatchManager.matchStatusAfterMatch, matchTimeStatus) : MatchManager.matchStatusAfterMatch);
				IDAGBBPEGJG(MatchManager.GFGPGJCGAPO());
			}
			else
			{
				FDDILBBJNMM.text = string.Empty;
			}
		}
		else
		{
			ODMOAGLMILJ(GJNGLPOBFJI: true);
			FDDILBBJNMM.text = string.Empty;
		}
	}

	protected void BOPGJFGMNJM()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 394f)
		{
			ADDICBANAAB -= 256f;
			NNBDNFNKHLC();
		}
		if (IGBKDNOKNKI != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			GGDHNJMEBJG(IGBKDNOKNKI);
		}
	}

	private void LGLPGGDEDDM()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1184f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1783f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 417f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = FAOIFNFDEGO;
	}

	private void LAGBCMICDGN()
	{
		int numberOfEndScreenNotifications = Singleton<NotificationManager>.instance.GetNumberOfEndScreenNotifications();
		CJHMCNAJMND.text = numberOfEndScreenNotifications.ToString();
		FJOPFDFKLPG.text = numberOfEndScreenNotifications.ToString();
		IBCFNHLOANO.SetActive(value: false);
		KPBBPKBPEMA.SetActive(numberOfEndScreenNotifications > 1);
	}

	private void JCBOFAEIJGH()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			LAGBCMICDGN();
		}
	}

	private void CAPLKFEEILP()
	{
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			GANHJPDLJIE();
		}
	}

	public void GNFOGFDNKCJ(EndScreen.MPJAFCCIOEO JKBOBJKCENJ)
	{
		base.gameObject.SetActive(JCGDIGCGHNO.Contains(JKBOBJKCENJ));
	}

	internal void KHCEMKGDNGH()
	{
		IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		GIFICGKMGAP(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		FDDILBBJNMM.text = string.Empty;
		bool isSinglePlayer = GuiScreenSingle<EndScreen>.instance.isSinglePlayer;
		CDAKNFAOGFC.SetActive(isSinglePlayer);
		MBBDPKMMNDO.SetActive(!isSinglePlayer);
		if (isSinglePlayer)
		{
			MNEFEENCGOP.text = string.Empty;
			bool isTutorial = Singleton<GameController>.instance.isTutorial;
			bool active = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-24) || !isTutorial;
			KKIIENBCDPC.gameObject.SetActive(active);
			if (KKIIENBCDPC.gameObject.activeSelf)
			{
				ODMOAGLMILJ(GJNGLPOBFJI: true);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
				FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
			IPKNANOMFDP.text = Localization.Localize((!isRandomMatchMaking) ? "Gold" : "mode");
			NGICJAPOOGN.text = Localization.Localize((!isRandomMatchMaking) ? "ID_GUI_PLAYER" : "EventAssignmentConfig");
			CFJGLIMNDNN.SetActive(isRandomMatchMaking);
			MEJMLNDFDBP.COCBCFKJOJE(IPKNANOMFDP, 1629f, 916f, -115);
			JBFFNINEEFL();
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		GANHJPDLJIE();
	}

	internal void OADKOIBGLMM()
	{
		IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		AOPDKJLCCOJ(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		FDDILBBJNMM.text = string.Empty;
		bool flag = GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD();
		CDAKNFAOGFC.SetActive(flag);
		MBBDPKMMNDO.SetActive(!flag);
		if (flag)
		{
			MNEFEENCGOP.text = string.Empty;
			bool flag2 = Singleton<GameController>.instance.BAKCODKBCPJ();
			bool active = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)62 || flag2;
			KKIIENBCDPC.gameObject.SetActive(active);
			if (KKIIENBCDPC.gameObject.activeSelf)
			{
				ODMOAGLMILJ(GJNGLPOBFJI: true);
			}
			if (Singleton<GameController>.instance.MNPNHJKBNCJ())
			{
				bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
				FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool flag3 = Singleton<GameController>.instance.FJOGEJNMNHI();
			IPKNANOMFDP.text = Localization.Localize((!flag3) ? "ID_WAITINGFORFRIEND" : "fake-division");
			NGICJAPOOGN.text = Localization.Localize((!flag3) ? "Special pack content: type: {0} id: {1}{2}" : "ID_FREEPERCENT");
			CFJGLIMNDNN.SetActive(flag3);
			MEJMLNDFDBP.COCBCFKJOJE(IPKNANOMFDP, 1992f, 74f, -37);
			KNCACAJBLBP();
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		KDGBFENEJEP();
	}

	private void DHDPMJOBMNI(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.AOOIMBPEKME(EndScreen.MPJAFCCIOEO.Results);
	}

	[CompilerGenerated]
	private void LODFKEIMNOD()
	{
		KNCACAJBLBP();
	}

	private void MDHENDAHCLM()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1233f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(716f);
	}

	private void OBCCAIJKHIF(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.PFFMIGFNNCC((EndScreen.MPJAFCCIOEO)7);
	}

	private void BBHMNAOCMAL(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.KJINDMFGFAI(EndScreen.MPJAFCCIOEO.None);
	}

	[CompilerGenerated]
	private void APLOJNCONFO(UITweener PHNEAHCCJOL)
	{
		GMAGDEDJNEA();
	}

	private void ODMOAGLMILJ(bool GJNGLPOBFJI)
	{
		LOKJLHFHGOL.enabled = GJNGLPOBFJI;
		foreach (UISprite item in DNCLMBNGCPN)
		{
			item.color = ((!GJNGLPOBFJI) ? Colours.grayLight : Color.white);
		}
	}

	private void FMHNFPEHKKJ()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			GKEHIMFKMOJ();
		}
	}

	private void IDIMBCBFNIA(GLFPILGCAPM ENCEFOOPBMK)
	{
		if (!GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD() && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			MNEFEENCGOP.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			bool activeInHierarchy = KKIIENBCDPC.gameObject.activeInHierarchy;
			FDDILBBJNMM.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	private void KIBKOFBBMDJ()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(1529f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(503f), useLocal: false);
		tweenPosition.onFinished = ANCBKBEJFDP;
	}

	private void MFCPMPLCOIO()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(327f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(691f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 183f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = KAFFDBAFIIF;
	}

	private void IMDIFONPLMC()
	{
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = DFDFBOAKFID.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1930f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(98f);
	}

	private void CKBKNEGIDBM()
	{
		EDNPMLJILFK();
	}

	private void GKEHIMFKMOJ()
	{
		int num = Singleton<NotificationManager>.instance.OGEPEFMHMJC();
		CJHMCNAJMND.text = num.ToString();
		FJOPFDFKLPG.text = num.ToString();
		IBCFNHLOANO.SetActive(value: false);
		KPBBPKBPEMA.SetActive(num > 0);
	}

	private void FMECFCIAMEN(UITweener PHNEAHCCJOL)
	{
		MAFPGDJMAPD();
	}

	private void GPEFKODOPKO(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ReplayButtonClick(EndScreen.MPJAFCCIOEO.Assignments);
	}

	private void GGDHNJMEBJG(bool GKAKLBKHBMP)
	{
		Debug.Log("END SCREEN - BUTTONS - enabled " + GKAKLBKHBMP);
		BOAJOLAOMAP.enabled = GKAKLBKHBMP;
		LEJKOAMDPDM.enabled = GKAKLBKHBMP;
		LOKJLHFHGOL.enabled = GKAKLBKHBMP;
		HKNODJGHCMI.enabled = GKAKLBKHBMP;
	}

	private void JHPKKCONEDG(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.KJINDMFGFAI((EndScreen.MPJAFCCIOEO)6);
	}

	protected void Update()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			OJDKJDJOGGP();
		}
		if (IGBKDNOKNKI != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			IGBKDNOKNKI = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			GGDHNJMEBJG(IGBKDNOKNKI);
		}
	}

	private void FLIOGBEEMGL()
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			string text = MatchManager.EEOMPCLGLAH();
			MNEFEENCGOP.text = ((!string.IsNullOrEmpty(text)) ? string.Format("out of range", MatchManager.matchStatusAfterMatch, text) : MatchManager.matchStatusAfterMatch);
			GOLCAIGOKGI(MatchManager.OILNKFOADMO());
		}
		else
		{
			ODJMGOCKFHH(GJNGLPOBFJI: true);
			MNEFEENCGOP.text = string.Empty;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			if (KKIIENBCDPC.gameObject.activeInHierarchy)
			{
				string text2 = MatchManager.EEOMPCLGLAH();
				FDDILBBJNMM.text = ((!string.IsNullOrEmpty(text2)) ? string.Format(" does not have small variant look!!!!!", MatchManager.matchStatusAfterMatch, text2) : MatchManager.matchStatusAfterMatch);
				ODMOAGLMILJ(MatchManager.canRematch);
			}
			else
			{
				FDDILBBJNMM.text = string.Empty;
			}
		}
		else
		{
			ODMOAGLMILJ(GJNGLPOBFJI: false);
			FDDILBBJNMM.text = string.Empty;
		}
	}

	private void IPDHLCMBKMN()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1929f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1648f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 437f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			FCMLDGPJHOG();
		};
	}

	private void MNNDDFOKIKA()
	{
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			GANHJPDLJIE();
		}
	}

	private void JBFFNINEEFL()
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag = !Singleton<GameController>.instance.FJOGEJNMNHI() || winStreak == null || winStreak.isActive;
		NGICJAPOOGN.gameObject.SetActive(!isRandomMatchMaking && !flag);
		ALJEPHCHIIJ.SetActive(isRandomMatchMaking);
		if (isRandomMatchMaking)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 0)
			{
				text = Localization.Localize("\n");
			}
			else
			{
				object[] array = new object[0];
				array[0] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("ID_CONFIRM_NOSKIRMISHAVAILABLE", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 714f, 659f, 12);
		}
		DFDFBOAKFID.SetActive(flag);
		if (flag)
		{
			CEJHJPFCIOO.text = string.Format("0", Localization.Localize("OOOOPS"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = false;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.BGHNMCPLIPE();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.FPNEIICLJFG(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = BAADBPMFEHE;
			}
		}
		else
		{
			JMFOJLNHAAK.PEHBGMEHFEM();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (isRandomMatchMaking && flag)
		{
			GMAGDEDJNEA();
		}
		else
		{
			LLKEOOCFKOO();
		}
	}

	private void COPBIADLDME()
	{
		if (!GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD() && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			string text = MatchManager.NEOPOLEEEGE();
			MNEFEENCGOP.text = ((!string.IsNullOrEmpty(text)) ? string.Format(",", MatchManager.matchStatusAfterMatch, text) : MatchManager.matchStatusAfterMatch);
			GOLCAIGOKGI(MatchManager.GFGPGJCGAPO());
		}
		else
		{
			ODJMGOCKFHH(GJNGLPOBFJI: false);
			MNEFEENCGOP.text = string.Empty;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			if (KKIIENBCDPC.gameObject.activeInHierarchy)
			{
				string text2 = MatchManager.NEOPOLEEEGE();
				FDDILBBJNMM.text = ((!string.IsNullOrEmpty(text2)) ? string.Format("Button \"{0}\" has no assigned box collider.", MatchManager.matchStatusAfterMatch, text2) : MatchManager.matchStatusAfterMatch);
				MAPFOPJJBOK(MatchManager.canRematch);
			}
			else
			{
				FDDILBBJNMM.text = string.Empty;
			}
		}
		else
		{
			ODMOAGLMILJ(GJNGLPOBFJI: true);
			FDDILBBJNMM.text = string.Empty;
		}
	}

	private void ANCBKBEJFDP(UITweener PHNEAHCCJOL)
	{
		GMAGDEDJNEA();
	}

	private void NNJFFOOJBOA(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.ContinueButtonClick((EndScreen.MPJAFCCIOEO)8);
	}

	private void AGJHBDGEHLH(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<EndScreen>.instance.PFFMIGFNNCC(EndScreen.MPJAFCCIOEO.Assignments);
	}

	private void EDNPMLJILFK()
	{
		bool flag = Singleton<GameController>.instance.FJOGEJNMNHI();
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag2 = !Singleton<GameController>.instance.isRandomMatchMaking || winStreak == null || winStreak.isActive;
		NGICJAPOOGN.gameObject.SetActive(!flag && !flag2);
		ALJEPHCHIIJ.SetActive(flag);
		if (flag)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 1)
			{
				text = Localization.Localize("DebugEnabled");
			}
			else
			{
				object[] array = new object[0];
				array[0] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("OtherPlayer", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 1639f, 532f, -125);
		}
		DFDFBOAKFID.SetActive(flag2);
		if (flag2)
		{
			CEJHJPFCIOO.text = string.Format("goldenSuitcase", Localization.Localize("Total_Battles"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = false;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.PEHBGMEHFEM();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.OANDDHKJDOB(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = MLKJCHMOKMO;
			}
		}
		else
		{
			JMFOJLNHAAK.LOINIDOGNCO();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (flag && flag2)
		{
			GMAGDEDJNEA();
		}
		else
		{
			AKILFLIPGKG();
		}
	}

	private void MFCJOPPBLBG(bool GKAKLBKHBMP)
	{
		Debug.Log("ID_STAT_SHOTGUNKILLS" + GKAKLBKHBMP);
		BOAJOLAOMAP.enabled = GKAKLBKHBMP;
		LEJKOAMDPDM.enabled = GKAKLBKHBMP;
		LOKJLHFHGOL.enabled = GKAKLBKHBMP;
		HKNODJGHCMI.enabled = GKAKLBKHBMP;
	}
}
