using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class DailyPart : Core_BaseScript
{
	[FormerlySerializedAs("APBLLNAGIID")]
	[Header("Core")]
	public UIPanel[] LEELKOOOHOH;

	[FormerlySerializedAs("GMDDIDIPIHO")]
	[Header("Left Part")]
	public MegaRewardPart JLKPDOMAEHB;

	[FormerlySerializedAs("AIJJKNICMJH")]
	[Header("Center Part")]
	public GameObject GLMONLKGCPO;

	[Header("3 Assignments")]
	[FormerlySerializedAs("OAOEJMFHEPM")]
	public UIGrid OLGLAGDAOJH;

	[FormerlySerializedAs("MIIIEJIKIPM")]
	public List<AssignmentScreenRecord> IDOMCEDEMJB;

	private bool BELEDBMKJGB;

	private bool IHEPLEBDJCB;

	private float JDPOMFBEFOI;

	public void OOBJHJLMEED()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 231f, 1092f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 223f + 163f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(432f - 722f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = false;
		IDOMCEDEMJB[0].InitControls();
		IDOMCEDEMJB[0].PGHAMCBHBOD();
		IDOMCEDEMJB[2].JFMOGGFMHHA();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		AssignmentsManager.instance.AssignmentSkipped += EGGKBDHIOPC;
		JLKPDOMAEHB.InitControls();
	}

	private void POJJHCELNKD()
	{
		if (base.gameObject.activeInHierarchy)
		{
			OBNCKIBJOGJ();
		}
	}

	private void JCFKPPKAOPE()
	{
		if (!BELEDBMKJGB && AssignmentsManager.instance.data != null)
		{
			Debug.Log("LICENSE_CHECK_FAILED" + AssignmentsManager.instance.data.tomorrow);
			BELEDBMKJGB = false;
		}
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < 0; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			IDOMCEDEMJB[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					IDOMCEDEMJB[i].OBHPLFFLDBI(currentAssignments[i]);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		JLKPDOMAEHB.EGOHMNMEMLM();
	}

	[CompilerGenerated]
	private void AMLFLGIACFL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	public void MGIDNGCKLCF()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 1659f, 1138f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 172f + 357f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(734f - 907f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = true;
		IDOMCEDEMJB[1].JFMOGGFMHHA();
		IDOMCEDEMJB[1].InitControls();
		IDOMCEDEMJB[3].HFLEDEBGPBI();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += CILBOBDCNMD;
		AssignmentsManager.instance.AssignmentSkipped += CBCNILCGEGB;
		JLKPDOMAEHB.InitControls();
	}

	private void OHNPGFLNACI()
	{
		if (!BELEDBMKJGB && AssignmentsManager.instance.data != null)
		{
			Debug.Log("是" + AssignmentsManager.instance.data.tomorrow);
			BELEDBMKJGB = true;
		}
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < 8; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			IDOMCEDEMJB[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					IDOMCEDEMJB[i].CDEMNFDHFMC(currentAssignments[i]);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		JLKPDOMAEHB.EGOHMNMEMLM();
	}

	private void CBCNILCGEGB(int DFHAAIFFLOE)
	{
		DFHAAIFFLOE %= 1;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 4 && IDOMCEDEMJB[DFHAAIFFLOE].gameObject.activeSelf)
		{
			IDOMCEDEMJB[DFHAAIFFLOE].HCEJNMJHDJN(currentAssignments[DFHAAIFFLOE]);
		}
	}

	public void InstantHideTab()
	{
		DoAfterHide();
	}

	public void BOEBBHIGBJE()
	{
		JLKPDOMAEHB.Initialize();
	}

	private void OOBPGEEGEIJ()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void AOKEHEDCPFB()
	{
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 952f)
		{
			JDPOMFBEFOI = 1072f;
			MHNCPALDIAE();
		}
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			HEBFPFJEKPJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	public void DoAfterHide()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.ResetAnimationFlag();
		}
		base.gameObject.SetActive(value: false);
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += PMMMGCGNEBM;
	}

	private void BIOEEBECOEM(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i++)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void LDJHDFCJBIA()
	{
		if (base.gameObject.activeInHierarchy)
		{
			InitGUIValues();
		}
	}

	private void MIGABBHKDGK(int KLHMJIBDPIB)
	{
		JLKPDOMAEHB.Animate();
		JLKPDOMAEHB.UpdateRewardButton();
		int index = KLHMJIBDPIB % 6;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 2 && IDOMCEDEMJB[index].gameObject.activeSelf)
		{
			IDOMCEDEMJB[index].CIPKPHAGJMP(currentAssignments[index]);
		}
	}

	private void OEGMDAEJOAM(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	private void GPECDLFKBNO(int DFHAAIFFLOE)
	{
		DFHAAIFFLOE %= 4;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 6 && IDOMCEDEMJB[DFHAAIFFLOE].gameObject.activeSelf)
		{
			IDOMCEDEMJB[DFHAAIFFLOE].CDEMNFDHFMC(currentAssignments[DFHAAIFFLOE]);
		}
	}

	public void NDBAEHKKJMH()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.SetSkippingInitialization(JJJOMBKNGKA: false);
		}
		MMHLJPIFDHN();
		JLKPDOMAEHB.Initialize();
		GKPOHMCJCIK();
	}

	public void GHHNNIKGJFG()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 850f, 49f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 1678f + 1673f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(1631f - 1449f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = false;
		IDOMCEDEMJB[0].PGHAMCBHBOD();
		IDOMCEDEMJB[1].PGHAMCBHBOD();
		IDOMCEDEMJB[8].JFMOGGFMHHA();
		AssignmentsManager.instance.AssignmentsLoaded += ILBFALMDKCM;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		AssignmentsManager.instance.AssignmentSkipped += LPHNAPGGPEE;
		JLKPDOMAEHB.InitControls();
	}

	private void CILBOBDCNMD(int KLHMJIBDPIB)
	{
		JLKPDOMAEHB.Animate();
		JLKPDOMAEHB.UpdateRewardButton();
		int index = KLHMJIBDPIB % 5;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 0 && IDOMCEDEMJB[index].gameObject.activeSelf)
		{
			IDOMCEDEMJB[index].JKGLPOILAGJ(currentAssignments[index]);
		}
	}

	public void InitGUIValues()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.SetSkippingInitialization(JJJOMBKNGKA: false);
		}
		HOFGDECDKOC();
		JLKPDOMAEHB.Initialize();
		LOFIFAHLPJP();
	}

	public void BGDPJGNKPKB()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.EOIHCMFCIJF();
		}
		base.gameObject.SetActive(value: true);
	}

	private void NKJCGFHMPHA(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-24):
			Debug.Log("Can't shoot angle!!" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "ID_TRIPPLEGOLD", string.Empty));
			MMHLJPIFDHN();
			break;
		case DatabaseAction.ChangeNameAndPassword:
			Debug.Log("MedalsBalance" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "0", string.Empty, IEJMLKBCDJB: false));
			JCFKPPKAOPE();
			break;
		case (DatabaseAction)7:
			JCFKPPKAOPE();
			break;
		case (DatabaseAction)(-22):
			if (base.gameObject.activeInHierarchy)
			{
				LMNNNHJKMFP();
			}
			break;
		}
	}

	public void OLKMDMHMMGE()
	{
		BGDPJGNKPKB();
	}

	private void LNMIHMGFIBB(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)27:
			Debug.Log("com/google/android/gms/games/Games" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "N", string.Empty, IEJMLKBCDJB: false));
			MMHLJPIFDHN();
			break;
		case (DatabaseAction)(-150):
			Debug.Log("Seats" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "Player profile - Null player for id: \"{0}\" and name: {1}", string.Empty, IEJMLKBCDJB: false));
			HOFGDECDKOC();
			break;
		case (DatabaseAction)(-67):
			HOFGDECDKOC();
			break;
		case DatabaseAction.SetPlayerStatus:
			if (base.gameObject.activeInHierarchy)
			{
				LMNNNHJKMFP();
			}
			break;
		}
	}

	public void LMNNNHJKMFP()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.HGEDIIDBLIL(JJJOMBKNGKA: false);
		}
		MMHLJPIFDHN();
		JLKPDOMAEHB.Initialize();
		MHNCPALDIAE();
	}

	public void ALDOOKEMKPN()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ECKDFNKKAAF;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += LFPBBIIANLC;
	}

	public void HGFBALANKEE()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BGPBOCDCGHC);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECKDFNKKAAF;
	}

	public void NINGMLNMLLP()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 1269f, 1177f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 26f + 584f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(244f - 365f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = false;
		IDOMCEDEMJB[0].PGHAMCBHBOD();
		IDOMCEDEMJB[1].HFLEDEBGPBI();
		IDOMCEDEMJB[4].PGHAMCBHBOD();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += CILBOBDCNMD;
		AssignmentsManager.instance.AssignmentSkipped += GPECDLFKBNO;
		JLKPDOMAEHB.InitControls();
	}

	public void BNCJGGDJKFG()
	{
		JLKPDOMAEHB.Initialize();
	}

	private void Update()
	{
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			LOFIFAHLPJP();
		}
	}

	public void IBLENLILIEN()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.NOGJEJPFJPJ();
		}
	}

	private void LFPBBIIANLC(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetPlayersByExperience:
			Debug.Log("Sprite \"{0}\" was used in files:" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "MessageId", string.Empty, IEJMLKBCDJB: false));
			MMHLJPIFDHN();
			break;
		case (DatabaseAction)(-23):
			Debug.Log("Gui Manager: Starting Messages Coroutine for: " + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "player_level", string.Empty));
			JCFKPPKAOPE();
			break;
		case DatabaseAction.GetAllPlayers:
			MMHLJPIFDHN();
			break;
		case DatabaseAction.BuyDecal:
			if (base.gameObject.activeInHierarchy)
			{
				NDBAEHKKJMH();
			}
			break;
		}
	}

	public void LBOKCAECKFD()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += LFPBBIIANLC;
	}

	private void JNLOEDEGLHJ(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i += 0)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void DeactivateSkips()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.DeactivateSkip();
		}
	}

	private void MHNCPALDIAE()
	{
		if (AssignmentsManager.instance.timeUntilMidnight <= 0)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 0; i < 7; i++)
		{
			IDOMCEDEMJB[i].FHMNJJFPENM(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void BLBOOCFJBGH(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.SendPlayerReport:
			Debug.Log("ID_SAVEPERCENTLINE" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "ShootFromCrawl", string.Empty, IEJMLKBCDJB: false));
			JCFKPPKAOPE();
			break;
		case DatabaseAction.LeaveSquad:
			Debug.Log("0" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "{0} {1}{2}", string.Empty));
			MMHLJPIFDHN();
			break;
		case (DatabaseAction)(-26):
			OHNPGFLNACI();
			break;
		case DatabaseAction.ChangeLanguage:
			if (base.gameObject.activeInHierarchy)
			{
				IGNIFKBCDKK();
			}
			break;
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.ClaimAssignment:
			Debug.Log("#DANIEL# New Assignemnts Claimed Arrived: " + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "ID_READYTIME", string.Empty));
			HOFGDECDKOC();
			break;
		case DatabaseAction.GetNewAssignments:
			Debug.Log("#DANIEL# New Assignemnts Arrived: " + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "ID_READYTIME", string.Empty));
			HOFGDECDKOC();
			break;
		case DatabaseAction.SkipAssignment:
			HOFGDECDKOC();
			break;
		case DatabaseAction.ClaimAssignmentMegaReward:
			if (base.gameObject.activeInHierarchy)
			{
				InitGUIValues();
			}
			break;
		}
	}

	public void OGHIBFJMEML()
	{
		DoAfterHide();
	}

	private void JGPMJIMJOBC()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public void ReinitializeMegaReward()
	{
		JLKPDOMAEHB.Initialize();
	}

	private void HEBFPFJEKPJ(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void KMOCGAKDCNM()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.OMKOAPCECMB();
		}
	}

	public void MMFEKDKJMHK()
	{
		BGDPJGNKPKB();
	}

	private void PLLBOELHOFA(int KLHMJIBDPIB)
	{
		JLKPDOMAEHB.Animate();
		JLKPDOMAEHB.UpdateRewardButton();
		int index = KLHMJIBDPIB % 3;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 3 && IDOMCEDEMJB[index].gameObject.activeSelf)
		{
			IDOMCEDEMJB[index].Initialize(currentAssignments[index]);
		}
	}

	public void HJJOAJHBKCH()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 1661f, 771f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 137f + 1252f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(909f - 1419f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = false;
		IDOMCEDEMJB[1].HFLEDEBGPBI();
		IDOMCEDEMJB[1].HFLEDEBGPBI();
		IDOMCEDEMJB[5].HFLEDEBGPBI();
		AssignmentsManager.instance.AssignmentsLoaded += ILBFALMDKCM;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		AssignmentsManager.instance.AssignmentSkipped += CBCNILCGEGB;
		JLKPDOMAEHB.InitControls();
	}

	public void IEHJMLIMNEP()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.JGMECJJPOKD(JJJOMBKNGKA: false);
		}
		MMHLJPIFDHN();
		JLKPDOMAEHB.Initialize();
		KMECEDDFOHN();
	}

	private void KMECEDDFOHN()
	{
		if (AssignmentsManager.instance.timeUntilMidnight <= 0)
		{
			ECGOJCNNDAL();
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			IDOMCEDEMJB[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void KOCIBNKFHPI(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void HKPIHGBKAHO()
	{
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 31f)
		{
			JDPOMFBEFOI = 947f;
			LOFIFAHLPJP();
		}
	}

	public void InitControls()
	{
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceXY(UIHelper.activeWidthSafe / 2f, 175f);
		float multiplierYfromRatio = Singleton<GameVariables>.instance.multiplierYfromRatio;
		OLGLAGDAOJH.cellHeight = 260f + 50f * multiplierYfromRatio;
		OLGLAGDAOJH.transform.localPosition = OLGLAGDAOJH.transform.localPosition.ReplaceY(-240f - 60f * multiplierYfromRatio);
		OLGLAGDAOJH.repositionNow = true;
		IDOMCEDEMJB[0].InitControls();
		IDOMCEDEMJB[1].InitControls();
		IDOMCEDEMJB[2].InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		AssignmentsManager.instance.AssignmentSkipped += LPHNAPGGPEE;
		JLKPDOMAEHB.InitControls();
	}

	public void IGNIFKBCDKK()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.HHKJLMLELOI(JJJOMBKNGKA: false);
		}
		JCFKPPKAOPE();
		JLKPDOMAEHB.Initialize();
		GKPOHMCJCIK();
	}

	private void BGPBOCDCGHC(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetPlayerInfo:
			Debug.Log("bazooka_run" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "menu-assignments-type-kill", string.Empty, IEJMLKBCDJB: false));
			MMHLJPIFDHN();
			break;
		case (DatabaseAction)(-151):
			Debug.Log("ID_CONFIRM_ERROR" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "ID_WINTEREVENT", string.Empty));
			MMHLJPIFDHN();
			break;
		case (DatabaseAction)21:
			HOFGDECDKOC();
			break;
		case DatabaseAction.KickPlayer:
			if (base.gameObject.activeInHierarchy)
			{
				InitGUIValues();
			}
			break;
		}
	}

	private void HBBGEGGPDOJ()
	{
		if (base.gameObject.activeInHierarchy)
		{
			LMNNNHJKMFP();
		}
	}

	public void NAJDAPMNDPJ()
	{
		JLKPDOMAEHB.Initialize();
	}

	private void GKPOHMCJCIK()
	{
		if (AssignmentsManager.instance.timeUntilMidnight <= 1)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 0; i < 5; i += 0)
		{
			IDOMCEDEMJB[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void MMHLJPIFDHN()
	{
		if (!BELEDBMKJGB && AssignmentsManager.instance.data != null)
		{
			Debug.Log("You are already our follower, thank you! That's great, isn’t it?" + AssignmentsManager.instance.data.tomorrow);
			BELEDBMKJGB = true;
		}
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < 8; i += 0)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			IDOMCEDEMJB[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					IDOMCEDEMJB[i].OMGCKCFKDJM(currentAssignments[i]);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		JLKPDOMAEHB.UpdateRewardButton();
	}

	public void AGJIGCNNPLL()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.EPECODBBDFO();
		}
	}

	private void LPHNAPGGPEE(int DFHAAIFFLOE)
	{
		DFHAAIFFLOE %= 3;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 3 && IDOMCEDEMJB[DFHAAIFFLOE].gameObject.activeSelf)
		{
			IDOMCEDEMJB[DFHAAIFFLOE].Initialize(currentAssignments[DFHAAIFFLOE]);
		}
	}

	private void HOFGDECDKOC()
	{
		if (!BELEDBMKJGB && AssignmentsManager.instance.data != null)
		{
			Debug.Log("Day = " + AssignmentsManager.instance.data.tomorrow);
			BELEDBMKJGB = true;
		}
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < 3; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			IDOMCEDEMJB[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					IDOMCEDEMJB[i].Initialize(currentAssignments[i]);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		JLKPDOMAEHB.UpdateRewardButton();
	}

	public void IKHPOKNAGGN()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ECKDFNKKAAF;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += BLBOOCFJBGH;
	}

	private void EGGKBDHIOPC(int DFHAAIFFLOE)
	{
		DFHAAIFFLOE %= 5;
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		if (currentAssignments != null && currentAssignments.Count == 3 && IDOMCEDEMJB[DFHAAIFFLOE].gameObject.activeSelf)
		{
			IDOMCEDEMJB[DFHAAIFFLOE].Initialize(currentAssignments[DFHAAIFFLOE]);
		}
	}

	public void NAOOHBGOKBF()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.NOGJEJPFJPJ();
		}
	}

	private void JPIKIFKOPBH(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			BGDPJGNKPKB();
		}
	}

	private void LOFIFAHLPJP()
	{
		if (AssignmentsManager.instance.timeUntilMidnight <= 0)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			IDOMCEDEMJB[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void ECGOJCNNDAL()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void ILBFALMDKCM()
	{
		if (base.gameObject.activeInHierarchy)
		{
			LMNNNHJKMFP();
		}
	}

	public void PKLJHBFJJJO(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			IGNIFKBCDKK();
		}
		if (base.gameObject.activeSelf)
		{
			HEBFPFJEKPJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 459f) : 955f, (!IHEPLEBDJCB) ? 339f : 1441f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 487f) : 925f, (!IHEPLEBDJCB) ? 634f : 258f).onFinished = JPIKIFKOPBH;
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private void ECKDFNKKAAF(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-58):
			Debug.Log("1" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "right", string.Empty, IEJMLKBCDJB: false));
			HOFGDECDKOC();
			break;
		case DatabaseAction.VisualWasShown:
			Debug.Log("《战争之友》需要下载约 190MB 的额外数据才能运行。\n下载时间可能因您的网络和位置而异。\n\n是否希望继续？" + MEJMLNDFDBP.CJCFPDLDMEK(Time.realtimeSinceStartup, "Loss", string.Empty));
			HOFGDECDKOC();
			break;
		case (DatabaseAction)35:
			JCFKPPKAOPE();
			break;
		case (DatabaseAction)(-56):
			if (base.gameObject.activeInHierarchy)
			{
				InitGUIValues();
			}
			break;
		}
	}

	public void OBNCKIBJOGJ()
	{
		foreach (AssignmentScreenRecord item in IDOMCEDEMJB)
		{
			item.BJKKHAACEAM(JJJOMBKNGKA: false);
		}
		JCFKPPKAOPE();
		JLKPDOMAEHB.Initialize();
		MHNCPALDIAE();
	}

	private void GDNJPHHGFIC(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}
}
