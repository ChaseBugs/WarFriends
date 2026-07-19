using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVsPlayerButton : Core_BaseScript
{
	public enum NKHJBLBAAEB
	{
		Tutorial = 0,
		Normal = 1,
		Winstreak = 2,
		Lootbox = 3,
		WinstreakAndLootbox = 4
	}

	[Header("Core")]
	public UIButtonSetter CJBEJLIFALJ;

	public GameObject ECJHCGPGGDC;

	public GameObject KIPFNEOKJBB;

	public UITable EMKNGHNLNIM;

	public UILabel MIALHLAHHJL;

	public UILabel KPBGMIPOICO;

	[Header("-Lootbox Part")]
	public GameObject ALJEPHCHIIJ;

	public UILabel PNPDLNOFBGB;

	[Header("-Winstreak Part")]
	public GameObject DFDFBOAKFID;

	public UITable HHOIKNLFGAO;

	public UILabel CEJHJPFCIOO;

	public WinStreakCounter JMFOJLNHAAK;

	[Header("-Tutorial")]
	public GameObject IJPJDKALPDP;

	public GameObject OMDKNOFNFBB;

	public UILabel BNPEMLKENPB;

	private float JCAFFELIFAO = 0.2f;

	private NKHJBLBAAEB GPABKIOEGKM
	{
		get
		{
			if (Singleton<GameController>.instance.isTutorial)
			{
				return NKHJBLBAAEB.Tutorial;
			}
			if (TutorialManagerStage6.instance.isTutorialRunning)
			{
				return NKHJBLBAAEB.Normal;
			}
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			if (winStreak != null && winStreak.isActive)
			{
				return NKHJBLBAAEB.WinstreakAndLootbox;
			}
			return NKHJBLBAAEB.Lootbox;
		}
	}

	private void LLHPKIJMOOK()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1810f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(234f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1758f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = CJKILCNFFMD;
	}

	public void OEIOHNGDAHO(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(false);
		}
		else if (Singleton<GameController>.instance.OJHIKLMNHNE() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				Singleton<GameController>.instance.SwitchToDeathMatch();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1764f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 942f);
			}
		}
	}

	public void PLMOAGCCJEB()
	{
		HMGKFKMCCBB();
	}

	private void AKJDFMBPAEG()
	{
		HMGKFKMCCBB();
	}

	private void NCHEPMBLKGE()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(535f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(1951f), false);
		tweenPosition.onFinished = GMHCAIFCGDP;
	}

	private void PGAKFNDBLOG()
	{
		CGMKEDLODOD();
	}

	private void OLKBIDOIIEJ(UITweener PHNEAHCCJOL)
	{
		NPMHANDOCLA();
	}

	public void JPIEGHAOIPL()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(false);
		ALJEPHCHIIJ.SetActive(true);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(874f);
		JMFOJLNHAAK.KEIIENDMKLN();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void DFLGLEJIPCO()
	{
		NLLGLDLIKFE();
	}

	[SpecialName]
	private NKHJBLBAAEB BAIEEDDFGFF()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return NKHJBLBAAEB.Tutorial;
		}
		if (TutorialManagerStage6.instance.isTutorialRunning)
		{
			return NKHJBLBAAEB.Normal;
		}
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		if (winStreak != null && winStreak.isActive)
		{
			return NKHJBLBAAEB.WinstreakAndLootbox;
		}
		return NKHJBLBAAEB.Lootbox;
	}

	public void JOJGEIBOLNJ()
	{
		GameLoginManager.instance.PlayerLogOut += BAFHJFKFDPC;
	}

	public void OKMMGFMKJGG()
	{
		CGMKEDLODOD();
	}

	public void EOFOMCBDBJN()
	{
		HMGKFKMCCBB();
	}

	private void IAKKJKAKEHO()
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
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1845f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1562f);
	}

	private void MDOIDGLPAPI()
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
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1293f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(409f);
	}

	[CompilerGenerated]
	private void PKMBHLJMONO(UITweener PHNEAHCCJOL)
	{
		KAONEFDFMMD();
	}

	public void DHLDBDIFGFG()
	{
		GameLoginManager.instance.PlayerLogOut += EGBPOAIPKCF;
	}

	private void PIMAIBAKFLL()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(3f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(876f), false);
		tweenPosition.onFinished = MOGEDCGMOPD;
	}

	public void EGBPOAIPKCF()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(true);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(811f);
		JMFOJLNHAAK.JCMHGOGNMFO();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	private void GMHCAIFCGDP(UITweener PHNEAHCCJOL)
	{
		DKIHDLFHGJC();
	}

	public void EFHOGCDFAMI()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(false);
		ALJEPHCHIIJ.SetActive(true);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(1782f);
		JMFOJLNHAAK.LOINIDOGNCO();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void KAIEFIKDLDC(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(false);
		}
		else if (Singleton<GameController>.instance.ICINKELJCAH() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(1))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1842f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1444f);
			}
		}
	}

	private void DGGKMAIGIPL(UITweener PHNEAHCCJOL)
	{
		PIMAIBAKFLL();
	}

	private void MOMPAKJOCDG(UITweener PHNEAHCCJOL)
	{
		JPKJMGJCAOL();
	}

	public void JCGDALOBGHO()
	{
		CGMKEDLODOD();
	}

	public void LEMNDNDGIOE()
	{
		HBHGKHAHCAG();
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

	private void GCFGPJLGHED()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1238f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1667f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1457f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = MOMPAKJOCDG;
	}

	public void CGEKMDIENJL()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(849f);
		JMFOJLNHAAK.PEHBGMEHFEM();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void NODHJEDOGDI()
	{
		GameLoginManager.instance.PlayerLogOut += LIINGAIDMAM;
	}

	private void HOFOBCGKGGL()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(238f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(403f));
		tweenPosition.onFinished = DLJOHHEHFKM;
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

	private void ABPEJFIAMKN()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1425f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(144f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 438f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = PCLHOCBGCFP;
	}

	private void PCLHOCBGCFP(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	private void KHEECJHDAKF()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(973f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1866f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1865f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, false);
		component.onFinished = LMEBFMPALPK;
	}

	private void JPKJMGJCAOL()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(722f));
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(1699f));
		tweenPosition.onFinished = NPKGOBBNCIO;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECJHCGPGGDC);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PvPClick));
		MIALHLAHHJL.text = Localization.Localize("ID_PVP_RANKED");
		KPBGMIPOICO.text = Localization.Localize("ID_PVP_BATTLE");
		float num = MIALHLAHHJL.relativeSize.x + KPBGMIPOICO.relativeSize.x;
		float a = 450f / num;
		float gLIDDLHPAKL = Mathf.Max(a, 57f);
		MEJMLNDFDBP.COCBCFKJOJE(MIALHLAHHJL, gLIDDLHPAKL, 20f, 450);
		MEJMLNDFDBP.COCBCFKJOJE(KPBGMIPOICO, gLIDDLHPAKL, 20f, 450);
		EMKNGHNLNIM.repositionNow = true;
		HHOIKNLFGAO.repositionNow = true;
	}

	private void DLJOHHEHFKM(UITweener PHNEAHCCJOL)
	{
		ABPEJFIAMKN();
	}

	public void JOPGGHDLJJL()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(95f);
		JMFOJLNHAAK.BGHNMCPLIPE();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	private void GOBFHGPGCHK()
	{
		NKHJBLBAAEB nKHJBLBAAEB = GPABKIOEGKM;
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.isTutorialStage1) ? "ID_CONTINUETOBOOTCAMP3" : "ID_CONTINUETOBOOTCAMP2");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = 500;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.Tutorial);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Normal) ? 30f : 8f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Lootbox || nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			PNPDLNOFBGB.text = ((remainingMatchesToNextLootbox != 1) ? Localization.LocalizeFormat("ID_NEWLOOTBOXINBATTLES", remainingMatchesToNextLootbox) : Localization.Localize("ID_NEWLOOTBOXINBATTLE"));
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 30f, 20f, Mathf.Max(400, CJBEJLIFALJ.width - 386));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Winstreak || nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
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
					GOBFHGPGCHK();
				};
			}
		}
		else
		{
			JMFOJLNHAAK.JCMHGOGNMFO();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox)
		{
			GMAGDEDJNEA();
		}
		else
		{
			JMIDHMAJNBK();
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

	public void LBKKAHOOCAA(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(true);
		}
		else if (Singleton<GameController>.instance.ICINKELJCAH() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(1))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1766f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1091f);
			}
		}
	}

	public void DJNIAJCODPI(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(true);
		}
		else if (Singleton<GameController>.instance.isTutorialStage1 || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(0))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.StartRandomMatchMaking(1609f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1738f);
			}
		}
	}

	[SpecialName]
	private NKHJBLBAAEB DHELCJDJIPI()
	{
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			return NKHJBLBAAEB.Tutorial;
		}
		if (TutorialManagerStage6.instance.isTutorialRunning)
		{
			return NKHJBLBAAEB.Tutorial;
		}
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		if (winStreak != null && winStreak.isActive)
		{
			return (NKHJBLBAAEB)6;
		}
		return (NKHJBLBAAEB)5;
	}

	private void CGHAEBAKKKO(UITweener PHNEAHCCJOL)
	{
		NPMHANDOCLA();
	}

	public void EOKIICNOHKC()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(798f);
		JMFOJLNHAAK.KEIIENDMKLN();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void PHNKOMPPPLD()
	{
		KJAEGFLONHC();
	}

	public void LIINGAIDMAM()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(799f);
		JMFOJLNHAAK.JCMHGOGNMFO();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	private void GGCMHNGMKCB()
	{
		HMGKFKMCCBB();
	}

	private void MOGEDCGMOPD(UITweener PHNEAHCCJOL)
	{
		MKJKALIBLJI();
	}

	public void InitBlank()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(false);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(8f);
		JMFOJLNHAAK.JCMHGOGNMFO();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	[SpecialName]
	private NKHJBLBAAEB CPFMNHFFPLM()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			return NKHJBLBAAEB.Normal;
		}
		if (TutorialManagerStage6.instance.isTutorialRunning)
		{
			return NKHJBLBAAEB.Normal;
		}
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		if (winStreak != null && winStreak.isActive)
		{
			return NKHJBLBAAEB.Tutorial;
		}
		return NKHJBLBAAEB.Winstreak;
	}

	public void InitEvents()
	{
		GameLoginManager.instance.PlayerLogOut += InitBlank;
	}

	public void FCOMFPHBOGH(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(true);
		}
		else if (Singleton<GameController>.instance.OJHIKLMNHNE() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.OAGOEBANLHN(0))
			{
				Singleton<GameController>.instance.SwitchToDeathMatch();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1168f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1362f);
			}
		}
	}

	private void ENPJBAIDEEL(UITweener PHNEAHCCJOL)
	{
		MKJKALIBLJI();
	}

	public void BAFHJFKFDPC()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(850f);
		JMFOJLNHAAK.BGHNMCPLIPE();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	private void HMGKFKMCCBB()
	{
		NKHJBLBAAEB nKHJBLBAAEB = DOGBKGHFODD();
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.OJHIKLMNHNE()) ? "registerCustomProfileGeolocation" : "ID_MISSION_KILL_HUD");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = 36;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Tutorial) ? 278f : 713f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox || nKHJBLBAAEB == NKHJBLBAAEB.Winstreak);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 0)
			{
				text = Localization.Localize("ID_");
			}
			else
			{
				object[] array = new object[0];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("BattleId", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 537f, 1975f, Mathf.Max(-167, CJBEJLIFALJ.DMBHNBLAPFM() - -31));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Winstreak || nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("T", Localization.Localize("One man in squad and not a leader!!!"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = true;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.GGKCMHOGFPF();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MIOOAOFMLIE(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = delegate
				{
					GOBFHGPGCHK();
				};
			}
		}
		else
		{
			JMFOJLNHAAK.GGKCMHOGFPF();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox)
		{
			GMAGDEDJNEA();
		}
		else
		{
			MHMAEACIAJI();
		}
	}

	public void EDOJAEGICFE(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(false);
		}
		else if (Singleton<GameController>.instance.OJHIKLMNHNE() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.OAGOEBANLHN(1))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1666f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 189f);
			}
		}
	}

	private void IBMKJFNOBCN()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(33f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(625f));
		tweenPosition.onFinished = DLJOHHEHFKM;
	}

	private void DGKFMBGAECI()
	{
		KGFNPIOPLMD();
	}

	private void KJAEGFLONHC()
	{
		NKHJBLBAAEB nKHJBLBAAEB = BAIEEDDFGFF();
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.ICINKELJCAH()) ? "#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER" : "Login: id = ");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = 119;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.Normal);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Normal) ? 1407f : 121f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)7 || nKHJBLBAAEB == NKHJBLBAAEB.Winstreak);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 0)
			{
				text = Localization.Localize("DOWNLOAD");
			}
			else
			{
				object[] array = new object[1];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("pt", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 1752f, 1090f, Mathf.Max(-99, CJBEJLIFALJ.BNIFKDJJGNB() - 160));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)7 || nKHJBLBAAEB == (NKHJBLBAAEB)8);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("mortar_up", Localization.Localize("vveteranpack"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = false;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.PEHBGMEHFEM();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MIOOAOFMLIE(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = GGCMHNGMKCB;
			}
		}
		else
		{
			JMFOJLNHAAK.BGHNMCPLIPE();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox)
		{
			PBOFEIIOKBO();
		}
		else
		{
			IAKKJKAKEHO();
		}
	}

	private void PBOFEIIOKBO()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1988f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1868f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 339f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = DGGKMAIGIPL;
	}

	private void MCKBIFLIFHD()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(271f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(413f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1503f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, false);
		component.onFinished = LMEBFMPALPK;
	}

	private void JNDMKNGPFLN()
	{
		KJAEGFLONHC();
	}

	public void NKBMEDEHOHL()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(true);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(1055f);
		JMFOJLNHAAK.GGKCMHOGFPF();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void NMIFLJICPJJ()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(true);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(718f);
		JMFOJLNHAAK.GGKCMHOGFPF();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void EECJOMDMPEP(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(true);
		}
		else if (Singleton<GameController>.instance.isTutorialStage1 || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(1))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.StartRandomMatchMaking(1678f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1977f);
			}
		}
	}

	private void GKDJAKCOIEL(UITweener PHNEAHCCJOL)
	{
		IBMKJFNOBCN();
	}

	private void HOAJFAGLBGF()
	{
		TweenPosition.Begin(ALJEPHCHIIJ, JCAFFELIFAO, ALJEPHCHIIJ.transform.localPosition, ALJEPHCHIIJ.transform.localPosition.ReplaceY(516f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(DFDFBOAKFID, JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition.ReplaceY(1649f), false);
		tweenPosition.onFinished = OLKBIDOIIEJ;
	}

	public void AMDCIHLNIHD()
	{
		GameLoginManager.instance.PlayerLogOut += EFHOGCDFAMI;
	}

	private void KANLELHCGMF(UITweener PHNEAHCCJOL)
	{
		JOJLPGPLLOI();
	}

	private void DKIHDLFHGJC()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(322f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(364f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1064f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			DKBPOEIFGCA();
		};
	}

	public void FLJMFAPGEJI()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(false);
		ALJEPHCHIIJ.SetActive(true);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(589f);
		JMFOJLNHAAK.PEHBGMEHFEM();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void GMHAEONJIHD()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(false);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(1484f);
		JMFOJLNHAAK.BGHNMCPLIPE();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	private void NPMHANDOCLA()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1338f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1799f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1020f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, false);
		component.onFinished = delegate
		{
			FCMLDGPJHOG();
		};
	}

	private void NPKGOBBNCIO(UITweener PHNEAHCCJOL)
	{
		ABPEJFIAMKN();
	}

	private void CJKILCNFFMD(UITweener PHNEAHCCJOL)
	{
		NCHEPMBLKGE();
	}

	private void IGLCCBKNMBK()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(730f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1819f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 290f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = LMEBFMPALPK;
	}

	private void OIAJNJMKDPJ(UITweener PHNEAHCCJOL)
	{
		FCMLDGPJHOG();
	}

	[CompilerGenerated]
	private void ONDGJCENMLE(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	private void JOJLPGPLLOI()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1346f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(747f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1519f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = MOMPAKJOCDG;
	}

	private void MHMAEACIAJI()
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
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1233f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(150f);
	}

	public void PvPClick(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(false);
		}
		else if (Singleton<GameController>.instance.isTutorialStage1 || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				Singleton<GameController>.instance.SwitchToDeathMatch();
				Singleton<GameController>.instance.GMNKFFNFEHG.StartRandomMatchMaking();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance);
			}
		}
	}

	public void InitGUIValues()
	{
		GOBFHGPGCHK();
	}

	private void KFLIKDCDPAF()
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
			component.enabled = true;
		}
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1843f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1202f);
	}

	private void CGMKEDLODOD()
	{
		NKHJBLBAAEB nKHJBLBAAEB = DHELCJDJIPI();
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.ICINKELJCAH()) ? "vipExpire" : ")");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = -47;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Tutorial) ? 127f : 526f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Winstreak || nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 1)
			{
				text = Localization.Localize("startActivity");
			}
			else
			{
				object[] array = new object[1];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("true", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 1728f, 981f, Mathf.Max(-159, CJBEJLIFALJ.MPKJFIBGCLH() - 94));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB != (NKHJBLBAAEB)6 && nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("LevelManagerData", Localization.Localize("SMG_run"), winStreak.winstreakNumber);
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
				JMFOJLNHAAK.JEMKCLKCOMI = JNDMKNGPFLN;
			}
		}
		else
		{
			JMFOJLNHAAK.PEHBGMEHFEM();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			DKIHDLFHGJC();
		}
		else
		{
			CAFPIOFENJK();
		}
	}

	private void HBHGKHAHCAG()
	{
		NKHJBLBAAEB nKHJBLBAAEB = GPABKIOEGKM;
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.OJHIKLMNHNE()) ? "setReferralSources" : "ID_WARNING_WARCARDNOTFOUNDINCOLLECTION");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = 88;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.Tutorial);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Normal) ? 112f : 1970f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)6 || nKHJBLBAAEB == (NKHJBLBAAEB)8);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 0)
			{
				text = Localization.Localize("{0} {1}{2}");
			}
			else
			{
				object[] array = new object[0];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("AFLODScrpt", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 1727f, 1138f, Mathf.Max(-19, CJBEJLIFALJ.BNIFKDJJGNB() - 74));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Winstreak || nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("{0} [616577]/[-] {1}", Localization.Localize("Max"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = true;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.FCGPLOBEHDL();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MHLJHMOPDAO(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = NJBBELPNMDC;
			}
		}
		else
		{
			JMFOJLNHAAK.PEHBGMEHFEM();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Lootbox)
		{
			GMAGDEDJNEA();
		}
		else
		{
			KFLIKDCDPAF();
		}
	}

	private void LMEBFMPALPK(UITweener PHNEAHCCJOL)
	{
		DKBPOEIFGCA();
	}

	private void GAHALIDDJDJ()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(716f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1735f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1239f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = GKDJAKCOIEL;
	}

	private void FDLKGHIDAHH(UITweener PHNEAHCCJOL)
	{
		HOFOBCGKGGL();
	}

	private void HBJPABBHPGL()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(57f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1883f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 747f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = LMEBFMPALPK;
	}

	private void CAFPIOFENJK()
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
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(860f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1321f);
	}

	private void NJBBELPNMDC()
	{
		KJAEGFLONHC();
	}

	private void KGFNPIOPLMD()
	{
		NKHJBLBAAEB nKHJBLBAAEB = DOGBKGHFODD();
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.ICINKELJCAH()) ? "{0} / {1}" : "{0}{1}");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = -109;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Tutorial) ? 871f : 4f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox || nKHJBLBAAEB == (NKHJBLBAAEB)6);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 1)
			{
				text = Localization.Localize("Please add object to pool, before instanciing it ::: prefab name = ");
			}
			else
			{
				object[] array = new object[1];
				array[1] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("NOT IN LEAGUE", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 147f, 950f, Mathf.Max(-189, CJBEJLIFALJ.BNIFKDJJGNB() - 136));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.Normal && nKHJBLBAAEB == (NKHJBLBAAEB)6);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("SpecialPackFromServer", Localization.Localize("PlayerLeagueFinished - Player joined {0}, leave {1}, finish on position {2}, with medals {3}"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = true;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.FCGPLOBEHDL();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.MIOOAOFMLIE(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = PGAKFNDBLOG;
			}
		}
		else
		{
			JMFOJLNHAAK.JCMHGOGNMFO();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Winstreak)
		{
			FIKEHJONALC();
		}
		else
		{
			IAKKJKAKEHO();
		}
	}

	public void OBCHCAEMAAJ()
	{
		GameLoginManager.instance.PlayerLogOut += LIINGAIDMAM;
	}

	public void IHPDLNODNDO()
	{
		BNPEMLKENPB.gameObject.SetActive(false);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(436f);
		JMFOJLNHAAK.FCGPLOBEHDL();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	public void AFICHGGNMJB()
	{
		GameLoginManager.instance.PlayerLogOut += EFHOGCDFAMI;
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

	[SpecialName]
	private NKHJBLBAAEB ADAENKNLBGH()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			return NKHJBLBAAEB.Tutorial;
		}
		if (TutorialManagerStage6.instance.isTutorialRunning)
		{
			return NKHJBLBAAEB.Tutorial;
		}
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		if (winStreak != null && winStreak.isActive)
		{
			return (NKHJBLBAAEB)8;
		}
		return (NKHJBLBAAEB)7;
	}

	private void OEHOLDCCBIE()
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
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(46f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1364f);
	}

	[SpecialName]
	private NKHJBLBAAEB DOGBKGHFODD()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			return NKHJBLBAAEB.Tutorial;
		}
		if (TutorialManagerStage6.instance.isTutorialRunning)
		{
			return NKHJBLBAAEB.Tutorial;
		}
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		if (winStreak != null && winStreak.isActive)
		{
			return NKHJBLBAAEB.Lootbox;
		}
		return NKHJBLBAAEB.Normal;
	}

	[CompilerGenerated]
	private void MFODPEGGPBB(UITweener PHNEAHCCJOL)
	{
		FCMLDGPJHOG();
	}

	private void BOKNNNOGFNL(UITweener PHNEAHCCJOL)
	{
		NCHEPMBLKGE();
	}

	private void FIKEHJONALC()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1667f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(1305f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1435f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = delegate
		{
			DKBPOEIFGCA();
		};
	}

	public void CPELEJBFNMC(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(true);
		}
		else if (Singleton<GameController>.instance.ICINKELJCAH() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(0))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.NCILIMJOJEC(1833f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 644f);
			}
		}
	}

	private void GKNGNCFOMCO(UITweener PHNEAHCCJOL)
	{
		NPMHANDOCLA();
	}

	public void PEIILMKDGBK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECJHCGPGGDC);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPELEJBFNMC));
		MIALHLAHHJL.text = Localization.Localize("ID_WARNING_CONNECTIONERROR");
		KPBGMIPOICO.text = Localization.Localize("menu-warbucks");
		float num = MIALHLAHHJL.relativeSize.x + KPBGMIPOICO.relativeSize.x;
		float a = 1564f / num;
		float gLIDDLHPAKL = Mathf.Max(a, 270f);
		MEJMLNDFDBP.COCBCFKJOJE(MIALHLAHHJL, gLIDDLHPAKL, 1736f, 101);
		MEJMLNDFDBP.COCBCFKJOJE(KPBGMIPOICO, gLIDDLHPAKL, 1869f, -110);
		EMKNGHNLNIM.repositionNow = false;
		HHOIKNLFGAO.repositionNow = false;
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

	private void BOHINJAKEIO()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1488f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(926f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1828f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, false);
		component.onFinished = FDLKGHIDAHH;
	}

	public void DBOPDJLMLAC(GameObject KHAHPAKDIKE)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(false);
		}
		else if (Singleton<GameController>.instance.ICINKELJCAH() || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.HKLLODKPINP(1))
			{
				Singleton<GameController>.instance.OFOIBAENJFA();
				Singleton<GameController>.instance.GMNKFFNFEHG.StartRandomMatchMaking(1080f);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1094f);
			}
		}
	}

	private void PEEKPMAOFFH()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(627f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(755f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 1930f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition, false);
		component.onFinished = OIAJNJMKDPJ;
	}

	public void DOPDLKMCFMA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECJHCGPGGDC);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KAIEFIKDLDC));
		MIALHLAHHJL.text = Localization.Localize("PlayerToInviteId");
		KPBGMIPOICO.text = Localization.Localize("getHighSpenderProbability");
		float num = MIALHLAHHJL.relativeSize.x + KPBGMIPOICO.relativeSize.x;
		float a = 1119f / num;
		float gLIDDLHPAKL = Mathf.Max(a, 395f);
		MEJMLNDFDBP.COCBCFKJOJE(MIALHLAHHJL, gLIDDLHPAKL, 1775f, -160);
		MEJMLNDFDBP.COCBCFKJOJE(KPBGMIPOICO, gLIDDLHPAKL, 1088f, -141);
		EMKNGHNLNIM.repositionNow = false;
		HHOIKNLFGAO.repositionNow = true;
	}

	[CompilerGenerated]
	private void NGJPKHKLJDC()
	{
		GOBFHGPGCHK();
	}

	private void FPOFKKDFALE()
	{
		KJAEGFLONHC();
	}

	private void NLLGLDLIKFE()
	{
		NKHJBLBAAEB nKHJBLBAAEB = DOGBKGHFODD();
		BNPEMLKENPB.gameObject.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Tutorial);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Tutorial)
		{
			BNPEMLKENPB.text = Localization.Localize((!Singleton<GameController>.instance.isTutorialStage1) ? "ID_EMPTYFOUNDSQUADSGLOBAL" : "#AccoutCheck# FB login during tutorial");
			if (Localization.isEnglish)
			{
				CJBEJLIFALJ.NCBAMBKGNLO.Clear();
				BNPEMLKENPB.lineWidth = 99;
			}
		}
		KIPFNEOKJBB.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.Normal);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY((nKHJBLBAAEB != NKHJBLBAAEB.Normal) ? 1839f : 1028f);
		ALJEPHCHIIJ.SetActive(nKHJBLBAAEB != NKHJBLBAAEB.WinstreakAndLootbox && nKHJBLBAAEB == NKHJBLBAAEB.WinstreakAndLootbox);
		if (ALJEPHCHIIJ.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel pNPDLNOFBGB = PNPDLNOFBGB;
			string text;
			if (remainingMatchesToNextLootbox == 1)
			{
				text = Localization.Localize("ID_MAXSTAT");
			}
			else
			{
				object[] array = new object[0];
				array[0] = remainingMatchesToNextLootbox;
				text = Localization.LocalizeFormat("HR", array);
			}
			pNPDLNOFBGB.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(PNPDLNOFBGB, 249f, 388f, Mathf.Max(66, CJBEJLIFALJ.DMBHNBLAPFM() - -44));
		}
		DFDFBOAKFID.SetActive(nKHJBLBAAEB != (NKHJBLBAAEB)7 && nKHJBLBAAEB == NKHJBLBAAEB.Normal);
		if (DFDFBOAKFID.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			CEJHJPFCIOO.text = string.Format("ACD: Speedhack detected!", Localization.Localize("about"), winStreak.winstreakNumber);
			HHOIKNLFGAO.repositionNow = false;
			if (winStreak.isInfinite)
			{
				JMFOJLNHAAK.LOINIDOGNCO();
				JMFOJLNHAAK.JEMKCLKCOMI = null;
				JMFOJLNHAAK.KGNGFHMBHMJ.text = string.Empty;
			}
			else
			{
				JMFOJLNHAAK.APFDDFPMACA(winStreak.deadline);
				JMFOJLNHAAK.JEMKCLKCOMI = GGCMHNGMKCB;
			}
		}
		else
		{
			JMFOJLNHAAK.LOINIDOGNCO();
			JMFOJLNHAAK.JEMKCLKCOMI = null;
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Lootbox)
		{
			PBOFEIIOKBO();
		}
		else
		{
			MHMAEACIAJI();
		}
	}

	public void MJHMIDJHNDN()
	{
		BNPEMLKENPB.gameObject.SetActive(true);
		KIPFNEOKJBB.SetActive(false);
		DFDFBOAKFID.SetActive(true);
		ALJEPHCHIIJ.SetActive(false);
		KIPFNEOKJBB.transform.localPosition = KIPFNEOKJBB.transform.localPosition.ReplaceY(1564f);
		JMFOJLNHAAK.FCGPLOBEHDL();
		JMFOJLNHAAK.JEMKCLKCOMI = null;
	}

	[CompilerGenerated]
	private void BAJEHBPBNDH(UITweener PHNEAHCCJOL)
	{
		GMAGDEDJNEA();
	}

	private void MKJKALIBLJI()
	{
		ALJEPHCHIIJ.transform.localPosition = ALJEPHCHIIJ.transform.localPosition.ReplaceY(1834f);
		DFDFBOAKFID.transform.localPosition = DFDFBOAKFID.transform.localPosition.ReplaceY(451f);
		TweenPosition component = ALJEPHCHIIJ.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(DFDFBOAKFID, 189f * JCAFFELIFAO, DFDFBOAKFID.transform.localPosition, DFDFBOAKFID.transform.localPosition);
		component.onFinished = GKDJAKCOIEL;
	}

	public void CHFHCBLGINB()
	{
		KGFNPIOPLMD();
	}
}
