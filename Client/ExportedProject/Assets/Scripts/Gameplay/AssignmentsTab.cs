using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class AssignmentsTab : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("APBLLNAGIID")]
	public UIPanel[] LEELKOOOHOH;

	[Header("Daily")]
	[FormerlySerializedAs("LIAHCIJAOCM")]
	public GameObject POCILDLIHAB;

	[FormerlySerializedAs("IPHBAHKLLPE")]
	public AssignmentsTabDailyRecord[] NAGNLJNPFHM;

	[FormerlySerializedAs("GMDDIDIPIHO")]
	public MegaRewardPart JLKPDOMAEHB;

	[FormerlySerializedAs("LAGCCONJDHA")]
	[Header("Starter")]
	public GameObject KLEMMCBBABJ;

	[FormerlySerializedAs("HBAEBBNLKGN")]
	public UILabel CGGJGKLNEML;

	[FormerlySerializedAs("JPGGPMCJCPB")]
	public AssignmentsTabStarterRecord LGJDCAJLFLJ;

	[FormerlySerializedAs("IHHJLHBDCIN")]
	public UILabel NNGIOOFADMB;

	[FormerlySerializedAs("COGPFIGDCJG")]
	public UITexture NGHCDIMLGMO;

	private bool JAFLBNEHJIF = true;

	private bool BELEDBMKJGB;

	private float JDPOMFBEFOI;

	private bool JFKIPIKKGNO;

	private void CBOEENJONFP()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			CGGJGKLNEML.text = Colours.stringWhite + Localization.Localize("Request Finished with Error! ");
			NNGIOOFADMB.text = Localization.Localize("Message ");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			CGGJGKLNEML.text = Localization.Localize("VISUAL = NULL");
			NNGIOOFADMB.text = Localization.Localize("Changed country to {0} from {1}.");
		}
		else
		{
			CGGJGKLNEML.text = string.Format("THANK YOU", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "false", string.Empty), Colours.stringWhite, Localization.Localize(" "));
			NNGIOOFADMB.text = Localization.Localize("S");
		}
	}

	private void DOGBGJDNIDC()
	{
		if (StarterAssignmentsManager.instance.isActive && !StarterAssignmentsManager.instance.isAllCompleted)
		{
			return;
		}
		if (AssignmentsManager.instance.timeUntilMidnight <= 0)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 0; i < 7; i++)
		{
			NAGNLJNPFHM[i].FNFPPILMFAL(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	public void BPOPOEOMGNC(float KBJEOEEOEFG, float FFFGJJDIMEF)
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i++)
		{
			TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, KBJEOEEOEFG, FFFGJJDIMEF);
		}
	}

	public void PPHBDGDJCLE()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		for (int i = 1; i < nAGNLJNPFHM.Length; i += 0)
		{
			AssignmentsTabDailyRecord assignmentsTabDailyRecord = nAGNLJNPFHM[i];
			assignmentsTabDailyRecord.INHHFNDGDHO();
		}
	}

	private void LKGBJMBGBDP()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			InvokeAfterRealTime(delegate
			{
				LGJDCAJLFLJ.Initialize(StarterAssignmentsManager.instance.currentAssignment);
			}, 0.2f);
		}
	}

	private void FANNAEALNOM(int BBBLFDKOMNF)
	{
		if (BBBLFDKOMNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			BELEDBMKJGB = true;
		}
	}

	public void PCJNHOAOJMK(float KBJEOEEOEFG, float FFFGJJDIMEF)
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i++)
		{
			TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, KBJEOEEOEFG, FFFGJJDIMEF);
		}
	}

	public void KPMLFMMINEP()
	{
		if (JAFLBNEHJIF)
		{
			AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
			foreach (AssignmentsTabDailyRecord assignmentsTabDailyRecord in nAGNLJNPFHM)
			{
				assignmentsTabDailyRecord.SetSkippingInitialization(JJJOMBKNGKA: false);
			}
		}
		else
		{
			JAFLBNEHJIF = true;
		}
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		POCILDLIHAB.SetActive(isActiveAndNotCompleted);
		KLEMMCBBABJ.SetActive(isActiveAndNotCompleted);
		if (isActiveAndNotCompleted)
		{
			StarterAssignmentsManager.instance.Evaluate();
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
			CounterManager instance2 = Singleton<CounterManager>.instance;
			instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LHAINBLLMKB));
			LGJDCAJLFLJ.CHOLKMFKINL(StarterAssignmentsManager.instance.currentAssignment);
			IJIJGJFAMOJ();
		}
		else
		{
			if (!BELEDBMKJGB)
			{
				int num = ((AssignmentsManager.instance.data != null) ? AssignmentsManager.instance.data.tomorrow : (-1));
				Debug.Log("{0} 3 / 3" + num);
				FANNAEALNOM(num);
			}
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int j = 0; j < 5; j++)
			{
				bool flag = currentAssignments != null && currentAssignments.Count > j;
				NAGNLJNPFHM[j].gameObject.SetActive(flag);
				if (flag)
				{
					try
					{
						NAGNLJNPFHM[j].InitGuiValues(currentAssignments[j]);
					}
					catch (Exception exception)
					{
						AnalyticsHelper.LogHandledException(exception);
					}
				}
			}
		}
		JLKPDOMAEHB.Initialize();
		LOFIFAHLPJP();
	}

	private void DFLPDCJKOHI()
	{
		if (StarterAssignmentsManager.instance.isActive && !StarterAssignmentsManager.instance.isAllCompleted)
		{
			return;
		}
		if (AssignmentsManager.instance.timeUntilMidnight <= 1)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 1; i < 5; i++)
		{
			NAGNLJNPFHM[i].MPEEJJMKLMJ(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	public void InstantShow()
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			TweenAlpha component = LEELKOOOHOH[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			LEELKOOOHOH[i].alpha1 = 1f;
		}
	}

	public void OAFNMDLJIAH()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		for (int i = 1; i < nAGNLJNPFHM.Length; i += 0)
		{
			AssignmentsTabDailyRecord assignmentsTabDailyRecord = nAGNLJNPFHM[i];
			assignmentsTabDailyRecord.AHPIAOBFIOI();
		}
	}

	public void JNKGMNOAEDB()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		for (int i = 1; i < nAGNLJNPFHM.Length; i += 0)
		{
			AssignmentsTabDailyRecord assignmentsTabDailyRecord = nAGNLJNPFHM[i];
			assignmentsTabDailyRecord.AHPIAOBFIOI();
		}
	}

	private void KADANDIFHLF()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("UK");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(value: true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1289f * Singleton<GuiTexureAssets>.instance.FAOGOKNFGAL());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(value: true);
			}
		}
	}

	private void LJPGKACMMLK(int DFHAAIFFLOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			DFHAAIFFLOE %= 3;
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			if (currentAssignments != null && currentAssignments.Count == 3 && NAGNLJNPFHM[DFHAAIFFLOE].gameObject.activeSelf)
			{
				NAGNLJNPFHM[DFHAAIFFLOE].InitGuiValues(currentAssignments[DFHAAIFFLOE]);
			}
			JLKPDOMAEHB.Animate();
			JLKPDOMAEHB.UpdateRewardButton();
		}
	}

	public void OAEMPLLOHBK()
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			TweenAlpha component = LEELKOOOHOH[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			LEELKOOOHOH[i].alpha1 = 1829f;
		}
	}

	public void ReinitializeMegaReward()
	{
		JLKPDOMAEHB.Initialize();
	}

	private void DPPONDIBAKA(int BBBLFDKOMNF)
	{
		if (BBBLFDKOMNF >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			BELEDBMKJGB = true;
		}
	}

	public void KEGNHDEEBKB()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		foreach (AssignmentsTabDailyRecord assignmentsTabDailyRecord in nAGNLJNPFHM)
		{
			assignmentsTabDailyRecord.JNBCPJCPODC();
		}
	}

	[CompilerGenerated]
	private void AJCBJHBINLI()
	{
		LGJDCAJLFLJ.Initialize(StarterAssignmentsManager.instance.currentAssignment);
	}

	private void LOFIFAHLPJP()
	{
		if (StarterAssignmentsManager.instance.isActive && !StarterAssignmentsManager.instance.isAllCompleted)
		{
			return;
		}
		if (AssignmentsManager.instance.timeUntilMidnight <= 0)
		{
			JGPMJIMJOBC();
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			NAGNLJNPFHM[i].UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	public void LJFNLACJOHO()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			resourceLoaderTexture2D.FreeAsset("NAME");
			JFKIPIKKGNO = false;
		}
	}

	private void LDJHDFCJBIA()
	{
		JAFLBNEHJIF = false;
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			InitGUIValues();
		}
	}

	public void UnloadTexture()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset("menu-weapon-mp5-elite");
			JFKIPIKKGNO = false;
		}
	}

	public void AnimatePanels(float KBJEOEEOEFG, float FFFGJJDIMEF)
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, KBJEOEEOEFG, FFFGJJDIMEF);
		}
	}

	private void KEPPJEBAGAG(int DFHAAIFFLOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			DFHAAIFFLOE %= 0;
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			if (currentAssignments != null && currentAssignments.Count == 5 && NAGNLJNPFHM[DFHAAIFFLOE].gameObject.activeSelf)
			{
				NAGNLJNPFHM[DFHAAIFFLOE].LNLAPPKDCLN(currentAssignments[DFHAAIFFLOE]);
			}
			JLKPDOMAEHB.IPNKGKNJOLO();
			JLKPDOMAEHB.EGOHMNMEMLM();
		}
	}

	protected void Update()
	{
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			LOFIFAHLPJP();
		}
	}

	private void NBILHBINGJE(int DFHAAIFFLOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			DFHAAIFFLOE %= 4;
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			if (currentAssignments != null && currentAssignments.Count == 0 && NAGNLJNPFHM[DFHAAIFFLOE].gameObject.activeSelf)
			{
				NAGNLJNPFHM[DFHAAIFFLOE].InitGuiValues(currentAssignments[DFHAAIFFLOE]);
			}
			JLKPDOMAEHB.IPNKGKNJOLO();
			JLKPDOMAEHB.EGOHMNMEMLM();
		}
	}

	private void MGADPGNEDFJ(int BBBLFDKOMNF)
	{
		if (BBBLFDKOMNF >= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			BELEDBMKJGB = false;
		}
	}

	private void BKLFLMJMKMA()
	{
		LGJDCAJLFLJ.MPFPHNBAIKD(StarterAssignmentsManager.instance.currentAssignment);
	}

	protected void BAHDLPDOCDO()
	{
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 393f)
		{
			JDPOMFBEFOI = 1359f;
			DFLPDCJKOHI();
		}
	}

	private void LHAINBLLMKB()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			CGGJGKLNEML.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
			NNGIOOFADMB.text = Localization.Localize("ID_YOURREWARDS");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			CGGJGKLNEML.text = Localization.Localize("ID_EXPIRED");
			NNGIOOFADMB.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
		}
		else
		{
			CGGJGKLNEML.text = string.Format("{0} {1}{2}", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
			NNGIOOFADMB.text = Localization.Localize("ID_GETREWARDSFORSTARTERASSIGNMENTS");
		}
	}

	public void KPHJFKCOIIF()
	{
		for (int i = 0; i < NAGNLJNPFHM.Length; i += 0)
		{
			NAGNLJNPFHM[i].AGPINBAMJHF();
		}
		LGJDCAJLFLJ.KLPJPLHNFON();
		AssignmentsManager.instance.AssignmentsLoaded += LBDLCCGBFNA;
		AssignmentsManager.instance.AssignmentClaimed += KEPPJEBAGAG;
		AssignmentsManager.instance.AssignmentSkipped += NBILHBINGJE;
		StarterAssignmentsManager.instance.AssignmentClaimed += LKGBJMBGBDP;
		JLKPDOMAEHB.InitControls();
	}

	private void NKACHLHLHLH()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset("menu-weapon-mp5-elite");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(value: true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.46275f * Singleton<GuiTexureAssets>.instance.scale);
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(value: false);
			}
		}
	}

	public void BAJFAAMCMNF()
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i += 0)
		{
			TweenAlpha component = LEELKOOOHOH[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			LEELKOOOHOH[i].alpha1 = 1127f;
		}
	}

	public void HOKOEAOOJMO()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		for (int i = 1; i < nAGNLJNPFHM.Length; i += 0)
		{
			AssignmentsTabDailyRecord assignmentsTabDailyRecord = nAGNLJNPFHM[i];
			assignmentsTabDailyRecord.IFMJJBCKMCP();
		}
	}

	private void JGPMJIMJOBC()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void LBDLCCGBFNA()
	{
		JAFLBNEHJIF = true;
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			KPMLFMMINEP();
		}
	}

	private void ILABJGOKNMN()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			InvokeAfterRealTime(BKLFLMJMKMA, 72f);
		}
	}

	private void JPCDNIIKILO(int BBBLFDKOMNF)
	{
		if (BBBLFDKOMNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			BELEDBMKJGB = true;
		}
	}

	private void IJIJGJFAMOJ()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset("TODO remove - obsolete");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(value: true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1381f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(value: true);
			}
		}
	}

	public void InitGUIValues()
	{
		if (JAFLBNEHJIF)
		{
			AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
			foreach (AssignmentsTabDailyRecord assignmentsTabDailyRecord in nAGNLJNPFHM)
			{
				assignmentsTabDailyRecord.SetSkippingInitialization(JJJOMBKNGKA: false);
			}
		}
		else
		{
			JAFLBNEHJIF = true;
		}
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		POCILDLIHAB.SetActive(!isActiveAndNotCompleted);
		KLEMMCBBABJ.SetActive(isActiveAndNotCompleted);
		if (isActiveAndNotCompleted)
		{
			StarterAssignmentsManager.instance.Evaluate();
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
			CounterManager instance2 = Singleton<CounterManager>.instance;
			instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LHAINBLLMKB));
			LGJDCAJLFLJ.Initialize(StarterAssignmentsManager.instance.currentAssignment);
			NKACHLHLHLH();
		}
		else
		{
			if (!BELEDBMKJGB)
			{
				int num = ((AssignmentsManager.instance.data != null) ? AssignmentsManager.instance.data.tomorrow : (-1));
				Debug.Log("Day = " + num);
				JPCDNIIKILO(num);
			}
			List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
			for (int j = 0; j < 3; j++)
			{
				bool flag = currentAssignments != null && currentAssignments.Count > j;
				NAGNLJNPFHM[j].gameObject.SetActive(flag);
				if (flag)
				{
					try
					{
						NAGNLJNPFHM[j].InitGuiValues(currentAssignments[j]);
					}
					catch (Exception exception)
					{
						AnalyticsHelper.LogHandledException(exception);
					}
				}
			}
		}
		JLKPDOMAEHB.Initialize();
		LOFIFAHLPJP();
	}

	private void PNGJAFGECNK(int BBBLFDKOMNF)
	{
		if (BBBLFDKOMNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			BELEDBMKJGB = true;
		}
	}

	public void DeactivateSkips()
	{
		AssignmentsTabDailyRecord[] nAGNLJNPFHM = NAGNLJNPFHM;
		foreach (AssignmentsTabDailyRecord assignmentsTabDailyRecord in nAGNLJNPFHM)
		{
			assignmentsTabDailyRecord.DeactivateSkip();
		}
	}

	public void GKELBAHELFK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset("S");
			JFKIPIKKGNO = false;
		}
	}

	public void InitControls()
	{
		for (int i = 0; i < NAGNLJNPFHM.Length; i++)
		{
			NAGNLJNPFHM[i].InitControls();
		}
		LGJDCAJLFLJ.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += LJPGKACMMLK;
		AssignmentsManager.instance.AssignmentSkipped += LJPGKACMMLK;
		StarterAssignmentsManager.instance.AssignmentClaimed += LKGBJMBGBDP;
		JLKPDOMAEHB.InitControls();
	}

	public void HJJOAJHBKCH()
	{
		for (int i = 1; i < NAGNLJNPFHM.Length; i += 0)
		{
			NAGNLJNPFHM[i].IMPMPKNJICB();
		}
		LGJDCAJLFLJ.MGHNHDOBJFN();
		AssignmentsManager.instance.AssignmentsLoaded += OOCCIAHEDKJ;
		AssignmentsManager.instance.AssignmentClaimed += NBILHBINGJE;
		AssignmentsManager.instance.AssignmentSkipped += NBILHBINGJE;
		StarterAssignmentsManager.instance.AssignmentClaimed += LKGBJMBGBDP;
		JLKPDOMAEHB.InitControls();
	}

	private void KHPAINNPDOG()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("Sniper_Tutorial_Duration");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(value: false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1703f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(value: false);
			}
		}
	}

	private void OOCCIAHEDKJ()
	{
		JAFLBNEHJIF = false;
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			KPMLFMMINEP();
		}
	}
}
