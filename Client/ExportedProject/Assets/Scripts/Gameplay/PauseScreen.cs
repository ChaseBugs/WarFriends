using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseScreen : GuiElementSingle<PauseScreen>, PAIIOKBBHBC
{
	[FormerlySerializedAs("KFEGNKJLMEL")]
	[Header("Header")]
	public UILabel OKMNFHNBMFA;

	[FormerlySerializedAs("LBBMNBALPPB")]
	public GameObject LHHOCEIJPFI;

	[Header("Content Top")]
	[FormerlySerializedAs("DBKGCCMBHOF")]
	public GameObject ADPFECKEMME;

	[FormerlySerializedAs("JPMMILMPNIG")]
	public UILabel HLPHCDNMJLG;

	[FormerlySerializedAs("IGECJIOGFAG")]
	public UILabel NHDCKJNOPOH;

	[FormerlySerializedAs("GAJAIAGNAKL")]
	[Header("Daily Assignment Part")]
	public GameObject JJFOLFDFMCB;

	[FormerlySerializedAs("DNHHBAFLNCE")]
	public List<AssignmentPauseRecord> DHNNCMHLOEM;

	[FormerlySerializedAs("OKNAEMIFADO")]
	[Header("Tutorial Part")]
	public GameObject CGELLNFMCIB;

	[FormerlySerializedAs("ICHBCBHLKHP")]
	public GameObject NOHDFMODCEG;

	[FormerlySerializedAs("JCOEBALIFIC")]
	public GameObject CCHDMDPGMJK;

	[FormerlySerializedAs("GKJPDPFCKPD")]
	public GameObject JMMAHFEOLGG;

	[FormerlySerializedAs("CKIMLOFIAAH")]
	public GameObject GCPPNCHGHMH;

	[Header("Buttons")]
	[FormerlySerializedAs("LAMMNCMNBFP")]
	public GameObject MOLJCJLCHEL;

	[FormerlySerializedAs("LMELJEEBIJF")]
	public UILabel FPOCPBLILGB;

	[FormerlySerializedAs("BCKGFLKBFAH")]
	public BoxCollider AJPHIGNGEHJ;

	[FormerlySerializedAs("FPDIIBBPEBN")]
	public UILabel FPGLDFLJKMP;

	[Header("Debug")]
	[FormerlySerializedAs("MAHCGJAGFFF")]
	public GameObject GFLFLPKBLBN;

	private bool PEMGLFGJEDK;

	private float ADDICBANAAB;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> CCNLMGEJBIB;

	public virtual void MNJJHEBFIJG()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void OOAOJGNKOOD(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(BGEBJDBGEGD);
		Singleton<GooglePlayGameService>.instance.IPKHNKGMDML(AELFFBEMEKB);
		GameLoginManager.instance.LoginToGoogle();
	}

	public override void HideDialog()
	{
		Debug.Log("#VAVRO# PauseScreen Hide");
		base.HideDialog();
	}

	protected virtual void KBKILDENNLM()
	{
		base.Update();
		if (!PEMGLFGJEDK)
		{
			ADDICBANAAB += Time.unscaledDeltaTime;
			if (ADDICBANAAB >= 1783f)
			{
				ADDICBANAAB = 1368f;
				KJMPBFMHNCO();
			}
		}
	}

	public override void InitGUIValues()
	{
		PEMGLFGJEDK = false;
		bool flag = TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocalyFocusLost || Singleton<GameController>.instance.isTutorial;
		DailyMission currentMission = DailyMissionsManager.instance.currentMission;
		bool active = Singleton<GameController>.instance.isMission && currentMission != null && currentMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "ID_GAMEPAUSED" : ((!Singleton<GameController>.instance.isMission) ? "ID_OPPONENTPAUSED" : "ID_FRIENDPAUSED"));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.isMission);
		if (Singleton<GameController>.instance.isMission)
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(currentMission.number);
			NHDCKJNOPOH.text = currentMission.objective;
		}
		else if (Singleton<GameController>.instance.isTutorial || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("ID_TUTORIAL_OBJECTIVE");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("ID_NORMAL_OBJECTIVE");
		}
		JJFOLFDFMCB.SetActive(!Singleton<GameController>.instance.isTutorial && !StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 0; i < DHNNCMHLOEM.Count; i++)
			{
				bool flag2 = currentAssignments != null && currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].Initialize(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.isTutorial);
		bool flag3 = false;
		bool flag4 = !GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = false;
		bool flag6 = !flag4;
		flag3 = !Singleton<GooglePlayGameService>.instance.isLoggedIn;
		flag5 = !flag3;
		bool flag7 = (flag3 || flag5) && (flag4 || flag6);
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 0f : (-304f));
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 0f : 304f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize("ID_CONTINUE");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_FORFEIT" : "ID_RESTART");
		GFLFLPKBLBN.gameObject.SetActive(Singleton<GameController>.instance.isTutorial && DebugSettings.isOurDevice);
	}

	private void HBCDFABNPCG(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(AELFFBEMEKB);
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(FCGIEKEBCPH);
		GameLoginManager.instance.LoginToGoogle();
	}

	public virtual void ALNHBEFMCNF()
	{
		Debug.Log("GameLauncher Async done");
		base.HideDialog();
	}

	public virtual void AIIJHNNODDM()
	{
		if (AJPHIGNGEHJ.enabled)
		{
			BMIKFLAPCOK(AJPHIGNGEHJ.gameObject);
		}
	}

	public override void OnBack()
	{
		if (AJPHIGNGEHJ.enabled)
		{
			CCHDCEDFNNB(AJPHIGNGEHJ.gameObject);
		}
	}

	private void JOPGNBKJCND(GameObject KHAHPAKDIKE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("ID_STATE_WAITINGFOROPPONENT"), Localization.Localize("C0"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
			{
				if (NCMHGPNPEJM)
				{
					Singleton<GameController>.instance.mainController.Forfeit();
					GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
					GuiScreenSingle<MainScreen>.instance.previousScreen = null;
				}
			}, 1447f);
		}
		else
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "squadCreationsCnt" : "Overtime_Was_Already_Explained"), Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "grenadeExplosion" : "vipStart"), MEFCKIPNFID, 571f);
		}
	}

	private static void MEFCKIPNFID(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
	}

	private void ONAKIMHMKHD()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 1; i < 2; i += 0)
			{
				DHNNCMHLOEM[i].NMOEMGAMDBH(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == (TimeManager.HICMJEBLEDA)6)
			{
				FPGLDFLJKMP.text = string.Format("Pack_Id", Localization.Localize("ID_INPROGRESS"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("0", Localization.Localize("DogTags"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.FAIHDODHHBJ() != TimeManager.HICMJEBLEDA.Resumed && TimeManager.instance.FAIHDODHHBJ() != (TimeManager.HICMJEBLEDA)6 && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	private void INBHDBDMIHN(bool EJBBDIBLDKI)
	{
		Debug.LogFormat("D", EJBBDIBLDKI);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= INPECAECIPC;
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.isTutorial || !Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	public virtual void EDFDIJCOMOI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LODJHPLNDHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BBJDKCKCDHG));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ELDLDJBJKEA));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ANDPGGEINKL));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IEPMOAOOFHJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IHOGKPNDCOM));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PDMPDHFBPGA));
		Singleton<GameController>.instance.GameEnded += HKENFAALDLA;
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	private void KNNNIOLHMJM(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: true);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
		NOHDFMODCEG.SetActive(value: true);
	}

	private static void MIEIJEMMECE(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	private static void FCJCKHGNNGE(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
	}

	private void GBEHDCJHDAO(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= BGEBJDBGEGD;
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(INBHDBDMIHN);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void EKLADPACBIM(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private static void MEGIBHIKFCO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
	}

	private void KHLKFIOJBOK(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= CNHMMDOIKPM;
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(PEAPKCHJAPK);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	protected virtual void MJNBAFDLMPN()
	{
		base.BOEMHLPLOGA();
		if (!PEMGLFGJEDK)
		{
			ADDICBANAAB += Time.unscaledDeltaTime;
			if (ADDICBANAAB >= 510f)
			{
				ADDICBANAAB = 255f;
				KGFGFACALHK();
			}
		}
	}

	public virtual void IMPJPMIDCBB()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void BCNLLHLCDEN(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: true);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.BAKCODKBCPJ() || Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	protected override void Update()
	{
		base.Update();
		if (!PEMGLFGJEDK)
		{
			ADDICBANAAB += Time.unscaledDeltaTime;
			if (ADDICBANAAB >= 0.333f)
			{
				ADDICBANAAB = 0f;
				OJDKJDJOGGP();
			}
		}
	}

	private void BMIKFLAPCOK(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void PCCECEDDOIB(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: false);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	private void ODDDKDANPOL(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: true);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
		NOHDFMODCEG.SetActive(value: true);
	}

	private static void DOAFIJAKDGD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	private void PBDBOODHBND(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: false);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.BAKCODKBCPJ() || !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	private void KGFGFACALHK()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 0; i < 4; i += 0)
			{
				DHNNCMHLOEM[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemote)
			{
				FPGLDFLJKMP.text = string.Format("Special pack content: type: {0} id: {1}{2}", Localization.Localize("1"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("SquadWarsFinishedMessage: Claiming gold: {0}", Localization.Localize("Visual"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.FAIHDODHHBJ() == (TimeManager.HICMJEBLEDA)7 || Singleton<GameController>.instance.BAKCODKBCPJ();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	private void KJMPBFMHNCO()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 0; i < 0; i++)
			{
				DHNNCMHLOEM[i].DDECKJACMEH(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.FAIHDODHHBJ() == (TimeManager.HICMJEBLEDA)8)
			{
				FPGLDFLJKMP.text = string.Format("menu-button-oneside-white", Localization.Localize("SquadIcons/"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("{0} Emblem {1} LVL {2}", Localization.Localize("veteranpack2"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.pauseStatus != (TimeManager.HICMJEBLEDA)6 && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	private void CEHMFBLGKPB(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void KAFPKFAELBP(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[0] = EJBBDIBLDKI;
		Debug.LogFormat("StartingWarbucks", array);
		NOHDFMODCEG.gameObject.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() && !GameLoginManager.instance.IsLoggedToFacebook);
	}

	public virtual void EENCDGMLNMP()
	{
		Debug.Log("ID_GOLDFORFREERIGHTAWAY");
		base.HideDialog();
	}

	public virtual void OPKPLEGMOPI()
	{
		PEMGLFGJEDK = false;
		bool flag = TimeManager.instance.FAIHDODHHBJ() != TimeManager.HICMJEBLEDA.Resumed && TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.Resumed && Singleton<GameController>.instance.DAIEAMEFGIE();
		DailyMission currentMission = DailyMissionsManager.instance.currentMission;
		bool active = !Singleton<GameController>.instance.ECHCLJJJPML() || currentMission == null || currentMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "squadPoints" : ((!Singleton<GameController>.instance.isMission) ? "{0} doesn't contain data for card unit" : "menu-assignments-type-score"));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.ECHCLJJJPML());
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(currentMission.number);
			NHDCKJNOPOH.text = currentMission.objective;
		}
		else if (Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("ID_COMEBACKTOMORROW");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("N0");
		}
		JJFOLFDFMCB.SetActive(Singleton<GameController>.instance.isTutorial || StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 1; i < DHNNCMHLOEM.Count; i += 0)
			{
				bool flag2 = currentAssignments == null || currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].LIMIFKFNNLA(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		bool flag3 = false;
		bool flag4 = !GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = true;
		bool flag6 = !flag4;
		flag3 = !Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH();
		flag5 = !flag3;
		bool flag7 = (!flag3 && !flag5) || (!flag4 && flag6);
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 1039f : 80f);
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 353f : 643f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize(", val = ");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "Seats" : "Main_Menu_Offers_Bar");
		GFLFLPKBLBN.gameObject.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() && DebugSettings.isOurDevice);
	}

	private void PIOPBIMGHPI(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(AELFFBEMEKB);
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(EJGBOHPGOAF);
		GameLoginManager.instance.LoginToGoogle();
	}

	public virtual void KLPJPLHNFON()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DIBOJLJPPDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OMNOLNECBEN));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NJLABBAKMAJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LKKOLNJODID));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OBFLEPDMEDA));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ELIKCJEEEGN));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PCCECEDDOIB));
		Singleton<GameController>.instance.CNPGMMPAGIE(PMPHPLMHJJE);
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	private void CNAEHNOHINA(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(HIEIFAMFCLC);
	}

	private void BIJEPBHFAOB(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void LODJHPLNDHK(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (Singleton<GameController>.instance.isWarArena)
			{
				ConfirmDialog.NMLMDFGOHDC(Localization.Localize("ID_RENTAL_GRENADELAUNCHER"), Localization.Localize("small_icon"), MEGIBHIKFCO, 658f);
			}
			else
			{
				ConfirmDialog.HMBAPGGLPLC(Localization.Localize((!Singleton<GameController>.instance.DAIEAMEFGIE()) ? "ID_BRONZEPACK" : "S"), Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}" : "Win"), MEFCKIPNFID, 394f);
			}
		}
	}

	private void HIEIFAMFCLC(bool EJBBDIBLDKI)
	{
		Debug.LogFormat("#account# logged to facebook result {0}", EJBBDIBLDKI);
		NOHDFMODCEG.gameObject.SetActive(Singleton<GameController>.instance.isTutorial && !GameLoginManager.instance.IsLoggedToFacebook);
	}

	private void MLGLMAODLCD(bool EJBBDIBLDKI)
	{
		object[] array = new object[1];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("Icon", array);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(AGGLIOHBFNA);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	public virtual void EILDFECJGLM()
	{
		Debug.Log("\nCPAPI:{\"cmd\":\"Filter\" \"name\":\"");
		base.HideDialog();
	}

	public virtual void DNCNKAAMMOP()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void NKGEEFPHAKB(GameObject KHAHPAKDIKE)
	{
		if (!isShowed)
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_FORFEITARENA"), Localization.Localize("ID_CONFIRM_FORFEITARENA_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
			{
				if (NCMHGPNPEJM)
				{
					Singleton<GameController>.instance.mainController.Forfeit();
					GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
					GuiScreenSingle<MainScreen>.instance.previousScreen = null;
				}
			});
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_FORFEIT" : "ID_RESTART"), Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_CONFIRM_FORFEIT_TEXT" : "ID_CONFIRM_RESTART_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		});
	}

	private void ODGMCBBDDAL(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(BGEBJDBGEGD);
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(CNHMMDOIKPM);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void LFDLJCLFHHM(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(EOJFBDFCOAF);
	}

	public virtual void DMBLJNMGLAH()
	{
		PEMGLFGJEDK = true;
		bool flag = TimeManager.instance.FAIHDODHHBJ() != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.pauseStatus != (TimeManager.HICMJEBLEDA)8 && Singleton<GameController>.instance.BAKCODKBCPJ();
		DailyMission dailyMission = DailyMissionsManager.instance.DPLEEBIFDKL();
		bool active = !Singleton<GameController>.instance.isMission || dailyMission == null || dailyMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "StarterPackDays" : ((!Singleton<GameController>.instance.isMission) ? "bronze1" : "ID_CONFIRM_SQUADFULL"));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.ECHCLJJJPML());
		if (Singleton<GameController>.instance.isMission)
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(dailyMission.number);
			NHDCKJNOPOH.text = dailyMission.objective;
		}
		else if (Singleton<GameController>.instance.isTutorial || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("ID_CONFIRM_ERROR");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("reloadTime");
		}
		JJFOLFDFMCB.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() || StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 1; i < DHNNCMHLOEM.Count; i++)
			{
				bool flag2 = currentAssignments != null && currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].JPBOGGKMAON(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		bool flag3 = false;
		bool flag4 = GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = false;
		bool flag6 = flag4;
		flag3 = !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC();
		flag5 = flag3;
		bool flag7 = (!flag3 && !flag5) || flag4 || flag6;
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 162f : 194f);
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 707f : 744f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize("{0}-{1}");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "T" : " ");
		GFLFLPKBLBN.gameObject.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && DebugSettings.isOurDevice);
	}

	private void ELIKCJEEEGN(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: false);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
		NOHDFMODCEG.SetActive(value: true);
	}

	private void PEAPKCHJAPK(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[0] = EJBBDIBLDKI;
		Debug.LogFormat("First_Time_Check_Leagues", array);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(MLGLMAODLCD);
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.isTutorial || !Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	private void AANHCJIDNAM(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: false);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
		NOHDFMODCEG.SetActive(value: true);
	}

	public virtual void PGBBMFDKGJC()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	public virtual void FAGMMFKPKHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LODJHPLNDHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ELDLDJBJKEA));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GIHJEGACDAE));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OOAOJGNKOOD));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ELIKCJEEEGN));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PBDBOODHBND));
		Singleton<GameController>.instance.CNPGMMPAGIE(HKENFAALDLA);
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	private void LMMMKGMBEKI(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: false);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.isTutorial && !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	private void HDLNLOJBGDH(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[0] = EJBBDIBLDKI;
		Debug.LogFormat("mapId", array);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= INBHDBDMIHN;
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.BAKCODKBCPJ() || !Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	public virtual void LEFACCFHPDF()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void MCBNIJJJLLF(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: true);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE() || !Singleton<GooglePlayGameService>.instance.isLoggedIn);
	}

	private void OOMHGDJPPGF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void DIBOJLJPPDB(GameObject KHAHPAKDIKE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("121 MENU WEAPON SCREEN SHOWN"), Localization.Localize("WarBucksSkipPrice"), DOAFIJAKDGD, 207f);
			return;
		}
		ConfirmDialog.HMBAPGGLPLC(Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "Player chose to stay on his account" : "N"), Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "Squad" : "mortarBuildTime"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 616f);
	}

	private void LKKOLNJODID(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(EOJFBDFCOAF);
	}

	public virtual void HEOMHIGCMOC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOPGNBKJCND));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BIJEPBHFAOB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NJLABBAKMAJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LFDLJCLFHHM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GBEHDCJHDAO));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ELIKCJEEEGN));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(BEANJGLIGBF));
		Singleton<GameController>.instance.CNPGMMPAGIE(HKENFAALDLA);
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	private void OFPNFKJJDEJ(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void KODADNBOIAD(bool EJBBDIBLDKI)
	{
		object[] array = new object[1];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("Time_Since_Delivery_Finished", array);
		NOHDFMODCEG.gameObject.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && GameLoginManager.instance.IsLoggedToFacebook);
	}

	public virtual void FJCDJJGBJPP()
	{
		if (AJPHIGNGEHJ.enabled)
		{
			OMNOLNECBEN(AJPHIGNGEHJ.gameObject);
		}
	}

	private void AELFFBEMEKB(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("100+.", array);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= MLGLMAODLCD;
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE() || Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	private void PHPHCNIOHOG()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 1; i < 1; i++)
			{
				DHNNCMHLOEM[i].EKDGDAHOGMA(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocalyFocusLost)
			{
				FPGLDFLJKMP.text = string.Format("ID_RENTEDUNIT", Localization.Localize("ID_EARLYUNLOCK2"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("menu-camos-alien", Localization.Localize("0.0.0"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.pauseStatus == (TimeManager.HICMJEBLEDA)7 || Singleton<GameController>.instance.isTutorial;
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	private void EOJFBDFCOAF(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[0] = EJBBDIBLDKI;
		Debug.LogFormat("Assignment: Kill Specific Enemy Units", array);
		NOHDFMODCEG.gameObject.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE() || !GameLoginManager.instance.IsLoggedToFacebook);
	}

	public virtual void KHGEHFNELDI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LODJHPLNDHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NJLABBAKMAJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LFDLJCLFHHM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PIOPBIMGHPI));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MDGKHJPKLPF));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PDMPDHFBPGA));
		Singleton<GameController>.instance.CNPGMMPAGIE(HKENFAALDLA);
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	public GuiElement EICPBDMFHFE()
	{
		return this;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.isShowed)
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void BDHGMGIDNFB(GameObject KHAHPAKDIKE)
	{
		if (!isShowed)
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.LGANINAGPLB(Localization.Localize("bazooka_uncover_left"), Localization.Localize("squadMembers"), ABFOFDAIHIO, 1683f);
			return;
		}
		ConfirmDialog.HMBAPGGLPLC(Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_ARENARULES_MORECRATES" : "{0} {1}{2}[-]"), Localization.Localize((!Singleton<GameController>.instance.DAIEAMEFGIE()) ? "ID_CONFIRM_NOTLEADEROFSQUAD" : "Rental"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 205f);
	}

	[CompilerGenerated]
	private static void LDMKAPNAJOG(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	private void OMNOLNECBEN(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void AEAIFCJDOON(GameObject KHAHPAKDIKE)
	{
		if (!isShowed)
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_INSTANTBATTLEHINT1"), Localization.Localize("game-elite-buff"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
			{
				if (NCMHGPNPEJM)
				{
					Singleton<GameController>.instance.mainController.Forfeit();
					GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
					GuiScreenSingle<MainScreen>.instance.previousScreen = null;
				}
			}, 1705f);
		}
		else
		{
			ConfirmDialog.ShowConfirm(Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "Action " : "ID_CLAIM"), Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "gameCenterPassword" : "\n"), MEFCKIPNFID, 880f);
		}
	}

	private void ELDLDJBJKEA(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CBAPHFGNLLH.IOPPHJNCABF();
	}

	private void MDGKHJPKLPF(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: true);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
		NOHDFMODCEG.SetActive(value: true);
	}

	private void AGGLIOHBFNA(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("offers", array);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(PEAPKCHJAPK);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && !Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH());
	}

	private void FPOBABDCIGM()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 1; i < 1; i++)
			{
				DHNNCMHLOEM[i].DEIAFHLHAKB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.Resumed)
			{
				FPGLDFLJKMP.text = string.Format("ID_GC_LOGIN_TUTORIAL_TEXT", Localization.Localize("ID_ALIEN"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("Send FinishChoosingCardsRPC: ", Localization.Localize("Sessions"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.Resumed && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	private void MFHFJDMAKHG(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (Singleton<GameController>.instance.isWarArena)
			{
				ConfirmDialog.NMLMDFGOHDC(Localization.Localize("https://i.ytimg.com/vi/U6Da9jKbXu0/hqdefault.jpg"), Localization.Localize("{0} {1}"), MEGIBHIKFCO, 1306f);
			}
			else
			{
				ConfirmDialog.BMBPFNKJHMF(Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_LEAGUE10" : "after update GC still GC account, but no added or missing gcID or gcPassword"), Localization.Localize((!Singleton<GameController>.instance.DAIEAMEFGIE()) ? "0$" : "ID_DEPLOYEDSOLDIERS"), FCJCKHGNNGE, 967f);
			}
		}
	}

	public virtual void AHCIKCJPBCN()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.isShowed)
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void OBFLEPDMEDA(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= FCGIEKEBCPH;
		Singleton<GooglePlayGameService>.instance.LoggedIn += FCGIEKEBCPH;
		GameLoginManager.instance.LoginToGoogle();
	}

	private void GIHJEGACDAE(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(FJGHOCJKKBB);
	}

	private void IEPMOAOOFHJ(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(HIKBOPLEBOO);
		Singleton<GooglePlayGameService>.instance.KGGJNIGKKPL(AGGLIOHBFNA);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void BEANJGLIGBF(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: false);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.isTutorial && !Singleton<GooglePlayGameService>.instance.isLoggedIn);
	}

	private void INPECAECIPC(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[0] = EJBBDIBLDKI;
		Debug.LogFormat("getExtrasPayload", array);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= CNHMMDOIKPM;
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.BAKCODKBCPJ() || !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void DOAEFBGCLJB()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 0; i < 1; i += 0)
			{
				DHNNCMHLOEM[i].DDECKJACMEH(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.PausedRemoteFocusLost)
			{
				FPGLDFLJKMP.text = string.Format("country-south-africa", Localization.Localize("ID_MAXSTAT"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("menu-assignments-bg", Localization.Localize("Server send power band reward id {0} which is null setting random {1}"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.FAIHDODHHBJ() != (TimeManager.HICMJEBLEDA)7 && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKGEEFPHAKB));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NJLABBAKMAJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ANDPGGEINKL));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OBFLEPDMEDA));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IHOGKPNDCOM));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(BEANJGLIGBF));
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	private void IBCALEICIIO(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void JHBMBCMBJMF(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: false);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.isTutorial || !Singleton<GooglePlayGameService>.instance.isLoggedIn);
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void LCBNPHDCLJO(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(INPECAECIPC);
		Singleton<GooglePlayGameService>.instance.KLLEOBDKNDJ(FCGIEKEBCPH);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void EJGBOHPGOAF(bool EJBBDIBLDKI)
	{
		object[] array = new object[1];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("Cards_Owned_Silver", array);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= AELFFBEMEKB;
		CCHDMDPGMJK.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE() || Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	private void OJDKJDJOGGP()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 0; i < 3; i++)
			{
				DHNNCMHLOEM[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocalyFocusLost)
			{
				FPGLDFLJKMP.text = string.Format("{0} ({1})", Localization.Localize("ID_CONTINUE"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("{0} ({1})", Localization.Localize("ID_WAIT"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.pauseTimeLeft));
			}
			bool flag = TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocalyFocusLost || Singleton<GameController>.instance.isTutorial;
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	protected virtual void OPMNIHDAHAA()
	{
		base.Update();
		if (!PEMGLFGJEDK)
		{
			ADDICBANAAB += Time.unscaledDeltaTime;
			if (ADDICBANAAB >= 1876f)
			{
				ADDICBANAAB = 1637f;
				DOAEFBGCLJB();
			}
		}
	}

	public virtual void LBLEJMFCBIC()
	{
		PEMGLFGJEDK = false;
		bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedRemoteFocusLost && Singleton<GameController>.instance.BAKCODKBCPJ();
		DailyMission dailyMission = DailyMissionsManager.instance.MEBFNJBNNEK();
		bool active = Singleton<GameController>.instance.ECHCLJJJPML() && dailyMission != null && dailyMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "MachineGunner" : ((!Singleton<GameController>.instance.isMission) ? "menu-cards-goldpack" : "Beanstalk check: Application not reachable!"));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.isMission);
		if (Singleton<GameController>.instance.isMission)
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(dailyMission.number);
			NHDCKJNOPOH.text = dailyMission.objective;
		}
		else if (Singleton<GameController>.instance.isTutorial || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("soldier behaviour is null !!!!");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("FuseSDK instance not initialized. Awake may not have been called.");
		}
		JJFOLFDFMCB.SetActive(Singleton<GameController>.instance.isTutorial || StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 0; i < DHNNCMHLOEM.Count; i += 0)
			{
				bool flag2 = currentAssignments != null && currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].KOEBOGHPHIA(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE());
		bool flag3 = true;
		bool flag4 = !GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = false;
		bool flag6 = !flag4;
		flag3 = !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC();
		flag5 = !flag3;
		bool flag7 = (!flag3 && !flag5) || (!flag4 && flag6);
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 274f : 372f);
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 791f : 503f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize("Cards_Owned_Gold");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.DAIEAMEFGIE()) ? "WarArenaConfig" : "Buy_Dogtags_With_Gold");
		GFLFLPKBLBN.gameObject.SetActive(Singleton<GameController>.instance.isTutorial && DebugSettings.isOurDevice);
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	public virtual void EHCPCODBOGJ()
	{
		Debug.Log("Dont have excel row for skillshot: ");
		base.HideDialog();
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DIBOJLJPPDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(AJPHIGNGEHJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LEOMHCCBGBF));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFLFLPKBLBN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ELDLDJBJKEA));
		UIEventListener uIEventListener4 = UIEventListener.Get(NOHDFMODCEG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LFDLJCLFHHM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCHDMDPGMJK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OBFLEPDMEDA));
		UIEventListener uIEventListener6 = UIEventListener.Get(JMMAHFEOLGG);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ODDDKDANPOL));
		UIEventListener uIEventListener7 = UIEventListener.Get(GCPPNCHGHMH);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PDMPDHFBPGA));
		Singleton<GameController>.instance.CNPGMMPAGIE(PMPHPLMHJJE);
		GameLoginManager.instance.LoginDataChanged += InitGUIValues;
	}

	private void HIKBOPLEBOO(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("+0", array);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= FCGIEKEBCPH;
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && !Singleton<GooglePlayGameService>.instance.ILCAOINJDAM());
	}

	private void JCKGLOHNLFO(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(CNHMMDOIKPM);
		Singleton<GooglePlayGameService>.instance.GNAHNELLDIG(AGGLIOHBFNA);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void BGEBJDBGEGD(bool EJBBDIBLDKI)
	{
		object[] array = new object[1];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat(" (#", array);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(HIKBOPLEBOO);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && !Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH());
	}

	private static void DIBNFOLLNEG(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
	}

	private void NJLABBAKMAJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CBAPHFGNLLH.SkipTutorial();
	}

	private static void ABFOFDAIHIO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	private void ANGFPNFCONA(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: true);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(MLGLMAODLCD);
		Singleton<GooglePlayGameService>.instance.CFNFOKADFFP(AELFFBEMEKB);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void LEOMHCCBGBF(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void MKIKFNLCBCD(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(EOJFBDFCOAF);
	}

	public GuiElement AEFPOOGLEEE()
	{
		return this;
	}

	private void BBJDKCKCDHG(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			PEMGLFGJEDK = false;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void KLMLPPGHJGI(GameObject KHAHPAKDIKE)
	{
		CCHDMDPGMJK.gameObject.SetActive(value: false);
		Singleton<GooglePlayGameService>.instance.AEBAHMIHJIM(HIKBOPLEBOO);
		Singleton<GooglePlayGameService>.instance.KGGJNIGKKPL(PEAPKCHJAPK);
		GameLoginManager.instance.LoginToGoogle();
	}

	private void FPLIPMEMPOA(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("Measure Event With Event Items", array);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(FCGIEKEBCPH);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && Singleton<GooglePlayGameService>.instance.JFBEEDPMNBO());
	}

	public virtual void IHLGGCNHCDG()
	{
		PEMGLFGJEDK = false;
		bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.Resumed && TimeManager.instance.FAIHDODHHBJ() != TimeManager.HICMJEBLEDA.PausedRemoteFocusLost && Singleton<GameController>.instance.DAIEAMEFGIE();
		DailyMission dailyMission = DailyMissionsManager.instance.DPLEEBIFDKL();
		bool active = Singleton<GameController>.instance.isMission && dailyMission != null && dailyMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "resultMessage" : ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "Items" : "BoughtIndex"));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.ECHCLJJJPML());
		if (Singleton<GameController>.instance.isMission)
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(dailyMission.number);
			NHDCKJNOPOH.text = dailyMission.objective;
		}
		else if (Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("startSession");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("ID_FREEPERCENTLINE");
		}
		JJFOLFDFMCB.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() || !StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 1; i < DHNNCMHLOEM.Count; i += 0)
			{
				bool flag2 = currentAssignments != null && currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].KOEBOGHPHIA(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		bool flag3 = false;
		bool flag4 = !GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = false;
		bool flag6 = flag4;
		flag3 = Singleton<GooglePlayGameService>.instance.isLoggedIn;
		flag5 = flag3;
		bool flag7 = (!flag3 && !flag5) || (!flag4 && flag6);
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 916f : 796f);
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 358f : 1682f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize("bronzecardpack");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.BAKCODKBCPJ()) ? "Total_Battles" : "SetTrapRPC");
		GFLFLPKBLBN.gameObject.SetActive(!Singleton<GameController>.instance.BAKCODKBCPJ() || DebugSettings.isOurDevice);
	}

	private void NKGCAIFLFLK()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 1; i < 8; i += 0)
			{
				DHNNCMHLOEM[i].BCEKMKLNDLB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedLocalyFocusLost)
			{
				FPGLDFLJKMP.text = string.Format("FacebookId", Localization.Localize("WarFriends requires permission to access your media storage in order to download critical game data.Without this permission the game cannot function and will be closed. Please retry or quit WarFriends."), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("DecalManagerData", Localization.Localize("menu-sidetab-challenge-start"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocaly && TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.PausedLocalyFocusLost && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	public virtual void OAFEJICKOEH()
	{
		PEMGLFGJEDK = true;
		bool flag = TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.Resumed || TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemoteFocusLost || Singleton<GameController>.instance.DAIEAMEFGIE();
		DailyMission dailyMission = DailyMissionsManager.instance.DPLEEBIFDKL();
		bool active = !Singleton<GameController>.instance.isMission || dailyMission == null || dailyMission.isHeroic;
		OKMNFHNBMFA.text = Localization.Localize(flag ? "Assignment: Error, task definition not found for id = " : ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "-" : " "));
		LHHOCEIJPFI.SetActive(active);
		ADPFECKEMME.SetActive(Singleton<GameController>.instance.isMission);
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			HLPHCDNMJLG.text = MEJMLNDFDBP.GMIPFLIEOHD(dailyMission.number);
			NHDCKJNOPOH.text = dailyMission.objective;
		}
		else if (Singleton<GameController>.instance.isTutorial || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			NHDCKJNOPOH.text = Localization.Localize("VisualType");
		}
		else
		{
			NHDCKJNOPOH.text = Localization.Localize("id");
		}
		JJFOLFDFMCB.SetActive(Singleton<GameController>.instance.isTutorial || StarterAssignmentsManager.instance.isActiveAndNotCompleted);
		if (JJFOLFDFMCB.activeSelf)
		{
			AssignmentsManager.instance.GetAssignmentsUpdate();
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int i = 1; i < DHNNCMHLOEM.Count; i += 0)
			{
				bool flag2 = currentAssignments != null && currentAssignments.Count > i;
				DHNNCMHLOEM[i].gameObject.SetActive(flag2);
				if (flag2)
				{
					DHNNCMHLOEM[i].MFMJPBCIHEH(currentAssignments[i]);
				}
			}
		}
		CGELLNFMCIB.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE());
		bool flag3 = true;
		bool flag4 = !GameLoginManager.instance.IsLoggedToFacebook;
		bool flag5 = true;
		bool flag6 = flag4;
		flag3 = !Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH();
		flag5 = flag3;
		bool flag7 = (flag3 || flag5) && (flag4 || flag6);
		NOHDFMODCEG.SetActive(flag4);
		CCHDMDPGMJK.SetActive(flag3);
		JMMAHFEOLGG.SetActive(flag6);
		GCPPNCHGHMH.SetActive(flag5);
		NOHDFMODCEG.transform.localPosition = NOHDFMODCEG.transform.localPosition.ReplaceX((!flag7) ? 610f : 1908f);
		CCHDMDPGMJK.transform.localPosition = CCHDMDPGMJK.transform.localPosition.ReplaceX((!flag7) ? 79f : 957f);
		JMMAHFEOLGG.transform.localPosition = NOHDFMODCEG.transform.localPosition;
		GCPPNCHGHMH.transform.localPosition = CCHDMDPGMJK.transform.localPosition;
		AJPHIGNGEHJ.enabled = flag;
		FPGLDFLJKMP.text = Localization.Localize("OK");
		FPOCPBLILGB.text = Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "friendsPushNotification" : "ID_ROQUETRANSMISION");
		GFLFLPKBLBN.gameObject.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE() || DebugSettings.isOurDevice);
	}

	[CompilerGenerated]
	private static void NFCIKMFJJHC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	private void ANDPGGEINKL(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: false);
		GameLoginManager.instance.LoginToFacebook(HIEIFAMFCLC);
	}

	public virtual void PKFIKGOPLBH()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.isShowed)
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void HKENFAALDLA(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void ILHMLNDIPIL(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			PEMGLFGJEDK = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void DCKCPHHMMED(GameObject KHAHPAKDIKE)
	{
		NOHDFMODCEG.SetActive(value: true);
		GameLoginManager.instance.LoginToFacebook(KAFPKFAELBP);
	}

	private void CNHMMDOIKPM(bool EJBBDIBLDKI)
	{
		object[] array = new object[1];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("playerVisuals", array);
		Singleton<GooglePlayGameService>.instance.HIMBMCCDHCL(PEAPKCHJAPK);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() && Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH());
	}

	private void FJGHOCJKKBB(bool EJBBDIBLDKI)
	{
		object[] array = new object[0];
		array[1] = EJBBDIBLDKI;
		Debug.LogFormat("weapon doesnt have ammo setup", array);
		NOHDFMODCEG.gameObject.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE() && GameLoginManager.instance.IsLoggedToFacebook);
	}

	private void PDMPDHFBPGA(GameObject KHAHPAKDIKE)
	{
		GCPPNCHGHMH.SetActive(value: true);
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ() && !Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC());
	}

	private void EJEDABNCGMJ()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int i = 0; i < 1; i += 0)
			{
				DHNNCMHLOEM[i].BCEKMKLNDLB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.FAIHDODHHBJ() == TimeManager.HICMJEBLEDA.PausedLocaly || TimeManager.instance.pauseStatus == (TimeManager.HICMJEBLEDA)5)
			{
				FPGLDFLJKMP.text = string.Format("CannonDamage", Localization.Localize("ID_UPGRADENOW"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			else
			{
				FPGLDFLJKMP.text = string.Format("Time: ", Localization.Localize("[0-9.,]*"), MEJMLNDFDBP.ABKAOAODKGC(TimeManager.KPGJAIBFMCC()));
			}
			bool flag = TimeManager.instance.pauseStatus != TimeManager.HICMJEBLEDA.Resumed && TimeManager.instance.pauseStatus != (TimeManager.HICMJEBLEDA)6 && Singleton<GameController>.instance.DAIEAMEFGIE();
			AJPHIGNGEHJ.enabled = flag;
		}
	}

	public virtual void IJKLNEDKOOI()
	{
		if (AJPHIGNGEHJ.enabled)
		{
			CEHMFBLGKPB(AJPHIGNGEHJ.gameObject);
		}
	}

	private void FAIFPPHEHFP(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: false);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
		NOHDFMODCEG.SetActive(value: false);
	}

	private void FCGIEKEBCPH(bool EJBBDIBLDKI)
	{
		Debug.LogFormat("#account# logged to gpgs result {0}", EJBBDIBLDKI);
		Singleton<GooglePlayGameService>.instance.LoggedIn -= FCGIEKEBCPH;
		CCHDMDPGMJK.SetActive(Singleton<GameController>.instance.isTutorial && !Singleton<GooglePlayGameService>.instance.isLoggedIn);
	}

	private void IHOGKPNDCOM(GameObject KHAHPAKDIKE)
	{
		JMMAHFEOLGG.SetActive(value: false);
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
		NOHDFMODCEG.SetActive(value: true);
	}

	private void PMPHPLMHJJE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}
}
