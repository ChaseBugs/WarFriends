using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyAssignmentsContent : Core_BaseScript
{
	[SerializeField]
	[Header("Core")]
	private AssignmentRecord[] mRecords;

	[SerializeField]
	private MegaRewardPart mMegaRewardPart;

	[SerializeField]
	private GameObject mOkButton;

	private bool BELEDBMKJGB = true;

	private void JEDPOENGGCE()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: true);
		}
	}

	private void LDABOMNGDOL()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			BLMKFKCCFBF();
		}
	}

	private void EKKCBDCBPFM()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			OLDPLDMADJD();
		}
	}

	public void PNLGFNBEOLG()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LCJHOGHEDMC(currentAssignments[i], DLGHFHEKMJN: false);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void JLIKFJGLBPF(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-10))
		{
			InitGUIValues();
		}
	}

	public void PGNEBFCEFNM()
	{
		mMegaRewardPart.Initialize();
	}

	public void EBHPAIIHCCK()
	{
		mMegaRewardPart.Initialize();
	}

	public void BCEKMKLNDLB(int BDHNPJEELIE)
	{
		for (int i = 1; i < 4; i++)
		{
			mRecords[i].KPJMCHMGGMO(BDHNPJEELIE);
		}
	}

	private void LEIABHKOGCA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.ChatShownFirstTime)
		{
			HHLOGFGGHHD();
		}
	}

	private void NEICBFCJPDM(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.EGOHMNMEMLM();
		}
	}

	private void BAOPKDEDGMB()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			AIFEFBBPEHG();
		}
	}

	private void FIEFEMEMKPA()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			EANAEBPDAAO();
		}
	}

	private void AIFEFBBPEHG()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: false);
		}
	}

	private void FDNKHOCPKHJ()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.JJLMJBCJBIK(DLGHFHEKMJN: false);
		}
	}

	private void KNCCIFNOHGH()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			FOFCPAACCJG();
		}
	}

	public void COBDHBOCGAP()
	{
		mRecords[1].LBHEIOEPJLJ();
		mRecords[0].GMJCEEHFAJG();
		mRecords[1].InitControls();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += KNCCIFNOHGH;
		AssignmentsManager.instance.AssignmentClaimed += EPBCEONHDBP;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(OENPBPAELJL);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.LMINDENMDEH));
	}

	private void GGDINFFHMGJ(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.IPNKGKNJOLO();
			mMegaRewardPart.EGOHMNMEMLM();
		}
	}

	public void AHMGFBBKAIH(int BDHNPJEELIE)
	{
		for (int i = 0; i < 4; i += 0)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	private void OFDKMLBCBIN()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			FHCGINEENFP();
		}
	}

	private void ODNPMFKHMML()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			BDLILCKHAPL();
		}
	}

	private void JAKOCNMIGHK(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.RemoveGooglePlay)
		{
			InitGUIValues();
		}
	}

	private void OMNCJNHOHNI()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.MMODJNPLLOO(DLGHFHEKMJN: false);
		}
	}

	private void OOCCIAHEDKJ()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			HOFGDECDKOC();
		}
	}

	private void IKMLNFPGNDP()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i++)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: true);
		}
	}

	public void KPBDJELONKH()
	{
		mRecords[0].AAJLGPIGDED();
		mRecords[0].LBHEIOEPJLJ();
		mRecords[3].AAJLGPIGDED();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += LDABOMNGDOL;
		AssignmentsManager.instance.AssignmentClaimed += MJBJAKOABIB;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BGPBOCDCGHC);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.KEAAAMPGPGD));
	}

	private void PDICNCKIOOC()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			AGFGKBGNMFG();
		}
	}

	public void ReinitializeMegaReward()
	{
		mMegaRewardPart.Initialize();
	}

	private void NBFJKPDMJCL()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.EKCIBBGBKLD(DLGHFHEKMJN: true);
		}
	}

	private void IEKFJGAPBMJ()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.DMBBNBHICHA(DLGHFHEKMJN: false);
		}
	}

	public void OGPKLKIEBHM()
	{
		mRecords[0].MMFBOMDHGPL();
		mRecords[1].AMBDHDEBPJJ();
		mRecords[5].PEIILMKDGBK();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += LMFICMCMKAI;
		AssignmentsManager.instance.AssignmentClaimed += EPBCEONHDBP;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += KOPKADMBIKO;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
	}

	private void NODBJJJNPIF()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.JJLMJBCJBIK(DLGHFHEKMJN: true);
		}
	}

	private void EGNKNIHIHGK()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			NDDKNOKGNLH();
		}
	}

	private void EANAEBPDAAO()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.HJKLIKLGMCK(DLGHFHEKMJN: false);
		}
	}

	public void APHKKCJDHAG(int BDHNPJEELIE)
	{
		for (int i = 0; i < 3; i++)
		{
			mRecords[i].KPJMCHMGGMO(BDHNPJEELIE);
		}
	}

	public void JPHDDAJBDOE()
	{
		mMegaRewardPart.Initialize();
	}

	private void LFKEAKAHNLH()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			BDLILCKHAPL();
		}
	}

	private void KENIMKGFCJH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.SendPlayerReport)
		{
			OBNCKIBJOGJ();
		}
	}

	private void ECKDFNKKAAF(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.GameStartedCoopMaster)
		{
			ODCHCNCMJGC();
		}
	}

	private void GKEAPAGJJMH()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i++)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: true);
		}
	}

	private void BLMKFKCCFBF()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: true);
		}
	}

	public void APFGAHIINCM(int BDHNPJEELIE)
	{
		for (int i = 0; i < 1; i++)
		{
			mRecords[i].DENINLHNEAM(BDHNPJEELIE);
		}
	}

	public void GIJHHJHIDKO()
	{
		mMegaRewardPart.Initialize();
	}

	public void LLHGHHABLDC()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LCJHOGHEDMC(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void PLLBOELHOFA(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	private void LMFICMCMKAI()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			FHCGINEENFP();
		}
	}

	private void LDJHDFCJBIA()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			HOFGDECDKOC();
		}
	}

	public void LAKPCHLKCJK(int BDHNPJEELIE)
	{
		for (int i = 1; i < 6; i++)
		{
			mRecords[i].UpdateTime(BDHNPJEELIE);
		}
	}

	public void BCHDADIHJIP()
	{
		mMegaRewardPart.Initialize();
	}

	public void DOLBCFNPIBA()
	{
		mMegaRewardPart.Initialize();
	}

	private void FHCGINEENFP()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i++)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.MMODJNPLLOO(DLGHFHEKMJN: false);
		}
	}

	private void LPCIGGJBMLH()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			HOFGDECDKOC();
		}
	}

	private void ALNDFBGDKPC(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.ClaimAssignment)
		{
			MAEFFJLPNDK();
		}
	}

	private void NKHGNNBAFOO(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	public void OBNCKIBJOGJ()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i += 0)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].InitializeAndUpdate(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void KFLKHEKJDAL()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			FOFCPAACCJG();
		}
	}

	public void BKKHGPEMIAO(int BDHNPJEELIE)
	{
		for (int i = 1; i < 4; i += 0)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	public void BPPNPHGOBEA()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i += 0)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LNNCHMIIIPB(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void NBONIEADKFH()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: false);
		}
	}

	public void JKGLFGICHJG(int BDHNPJEELIE)
	{
		for (int i = 0; i < 3; i += 0)
		{
			mRecords[i].DENINLHNEAM(BDHNPJEELIE);
		}
	}

	public void OCFOEGJBNCH()
	{
		mRecords[0].LBHEIOEPJLJ();
		mRecords[1].LBHEIOEPJLJ();
		mRecords[8].KLPJPLHNFON();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += ODNPMFKHMML;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OENPBPAELJL;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
	}

	public void CBLEHJBBPGF()
	{
		mMegaRewardPart.Initialize();
	}

	public void MAEFFJLPNDK()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].InitializeAndUpdate(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void OLDPLDMADJD()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i++)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: false);
		}
	}

	private void BHKGKEDJNOB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-187))
		{
			DBFHCLPIOKH();
		}
	}

	private void HOFGDECDKOC()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: false);
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.ClaimAssignmentMegaReward)
		{
			InitGUIValues();
		}
	}

	private void MNAMKJCJNBB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.BuyWeaponUpgrade)
		{
			DEJPNPOAKIJ();
		}
	}

	public void GIHMAEGDGHA()
	{
		mRecords[1].PEIILMKDGBK();
		mRecords[1].PEIILMKDGBK();
		mRecords[3].InitControls();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += CMMJIMADFEJ;
		AssignmentsManager.instance.AssignmentClaimed += MACFCBBIMAE;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(KENIMKGFCJH);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.DJOCGHINNJA));
	}

	private void LFDMAKAADAL()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i++)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.DMBBNBHICHA(DLGHFHEKMJN: true);
		}
	}

	public void LPFPAKGNNIO()
	{
		mRecords[0].KLPJPLHNFON();
		mRecords[0].AAJLGPIGDED();
		mRecords[3].AAJLGPIGDED();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += KFLKHEKJDAL;
		AssignmentsManager.instance.AssignmentClaimed += EPBCEONHDBP;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BHKGKEDJNOB);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
	}

	public void GGOGACBJDGH(int BDHNPJEELIE)
	{
		for (int i = 0; i < 2; i += 0)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	public void JCEMKGHAHNE()
	{
		mRecords[0].KLPJPLHNFON();
		mRecords[1].AAJLGPIGDED();
		mRecords[7].MMFBOMDHGPL();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += JHBGABICKAD;
		AssignmentsManager.instance.AssignmentClaimed += NKHGNNBAFOO;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MHGOGNMIJPC;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.KEAAAMPGPGD));
	}

	private void ABJFLHOCKBA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-139))
		{
			HMNOPHFJJHK();
		}
	}

	public void BNPDALDLFFM()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LCJHOGHEDMC(currentAssignments[i], DLGHFHEKMJN: false);
			}
		}
		mMegaRewardPart.Initialize();
	}

	public void FOKFDABALJD()
	{
		mMegaRewardPart.Initialize();
	}

	private void FBHKMJHJCKN(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.EGOHMNMEMLM();
		}
	}

	private void GPNIPCCDIJI()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			FDNKHOCPKHJ();
		}
	}

	public void CDHLMEPGPNJ()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i += 0)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LNNCHMIIIPB(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void NIEPDKCANFH()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.EKCIBBGBKLD(DLGHFHEKMJN: false);
		}
	}

	public void HHLOGFGGHHD()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LNNCHMIIIPB(currentAssignments[i], DLGHFHEKMJN: false);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void GAGHOCJBFDD()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			NBONIEADKFH();
		}
	}

	public void CAKEPACMPBN(int BDHNPJEELIE)
	{
		for (int i = 1; i < 6; i += 0)
		{
			mRecords[i].UpdateTime(BDHNPJEELIE);
		}
	}

	public void HMNOPHFJJHK()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i += 0)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].MCLMCIDKDCG(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	public void EKDGDAHOGMA(int BDHNPJEELIE)
	{
		for (int i = 0; i < 4; i += 0)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	private void FJBGLCFEEDP()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			FDNKHOCPKHJ();
		}
	}

	public void UpdateTime(int BDHNPJEELIE)
	{
		for (int i = 0; i < 3; i++)
		{
			mRecords[i].UpdateTime(BDHNPJEELIE);
		}
	}

	public void InitGUIValues()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].InitializeAndUpdate(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void MACFCBBIMAE(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	public void KCFKCFHGIPE(int BDHNPJEELIE)
	{
		for (int i = 1; i < 5; i++)
		{
			mRecords[i].UpdateTime(BDHNPJEELIE);
		}
	}

	private void MJBJAKOABIB(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	public void CMCKCKKLKDG(int BDHNPJEELIE)
	{
		for (int i = 1; i < 3; i++)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	public void MDHJIPDGDAK()
	{
		mRecords[1].AAJLGPIGDED();
		mRecords[0].GMJCEEHFAJG();
		mRecords[6].KLPJPLHNFON();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += BAOPKDEDGMB;
		AssignmentsManager.instance.AssignmentClaimed += NEICBFCJPDM;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(ABJFLHOCKBA);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.KEAAAMPGPGD));
	}

	private void HGMDCEGIMIE()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			NBONIEADKFH();
		}
	}

	private void KLPACNJJDIA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.AcceptRentalOffer)
		{
			MAEFFJLPNDK();
		}
	}

	public void ICKIHECNLII()
	{
		mMegaRewardPart.Initialize();
	}

	public void HAGLDJPBIKC()
	{
		mMegaRewardPart.Initialize();
	}

	private void OENPBPAELJL(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)100)
		{
			PNLGFNBEOLG();
		}
	}

	private void BGPBOCDCGHC(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.GetFriendsInfo)
		{
			HHLOGFGGHHD();
		}
	}

	private void CMMJIMADFEJ()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			FHCGINEENFP();
		}
	}

	private void LAGFAGNJEEG(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-117))
		{
			BNPDALDLFFM();
		}
	}

	private void AGFGKBGNMFG()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: true);
		}
	}

	public void FBDMBKKDEDC()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].InitializeAndUpdate(currentAssignments[i], DLGHFHEKMJN: false);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void BKAGFAENAAN()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			KLHELIPBHFM();
		}
	}

	private void KOPKADMBIKO(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-114))
		{
			HMNOPHFJJHK();
		}
	}

	private void DEMIPDGHPOE(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.ActivateUnitUpgrade)
		{
			DEJPNPOAKIJ();
		}
	}

	public void DLPEBGPLCJA()
	{
		mMegaRewardPart.Initialize();
	}

	private void KLHELIPBHFM()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.EOJMAKBNJOE(DLGHFHEKMJN: false);
		}
	}

	private void GPCDPBLIGEE(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	public void LEMNDNDGIOE()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LNNCHMIIIPB(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	public void DEJPNPOAKIJ()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments != null && currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LNNCHMIIIPB(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	public void JGDMLKMKHCJ()
	{
		mRecords[1].AMBDHDEBPJJ();
		mRecords[1].LBHEIOEPJLJ();
		mRecords[2].LBHEIOEPJLJ();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += JHBGABICKAD;
		AssignmentsManager.instance.AssignmentClaimed += MJBJAKOABIB;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(ALNDFBGDKPC);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.DJOCGHINNJA));
	}

	public void EFKFHFNAOHA()
	{
		mRecords[1].LBHEIOEPJLJ();
		mRecords[1].KLPJPLHNFON();
		mRecords[7].MMFBOMDHGPL();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += MJPKIOGJJKJ;
		AssignmentsManager.instance.AssignmentClaimed += FBHKMJHJCKN;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JAKOCNMIGHK;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
	}

	public void InitControls()
	{
		mRecords[0].InitControls();
		mRecords[1].InitControls();
		mRecords[2].InitControls();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += LDJHDFCJBIA;
		AssignmentsManager.instance.AssignmentClaimed += PLLBOELHOFA;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
	}

	private void IKAPDADLBOE()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: false);
		}
	}

	public void IGPBIBLOMFD()
	{
		mMegaRewardPart.Initialize();
	}

	public void EOAABNAEDIP()
	{
		mMegaRewardPart.Initialize();
	}

	private void EPBCEONHDBP(int DFHAAIFFLOE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			mMegaRewardPart.Animate();
			mMegaRewardPart.UpdateRewardButton();
		}
	}

	private void FOFCPAACCJG()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: false);
		}
	}

	public void DBFHCLPIOKH()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 1; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].InitializeAndUpdate(currentAssignments[i], DLGHFHEKMJN: false);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void BDLILCKHAPL()
	{
		BELEDBMKJGB = true;
		AssignmentRecord[] array = mRecords;
		for (int i = 0; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.UpdateAssignmentLook(DLGHFHEKMJN: false);
		}
	}

	public void FHMNJJFPENM(int BDHNPJEELIE)
	{
		for (int i = 1; i < 5; i += 0)
		{
			mRecords[i].KPJMCHMGGMO(BDHNPJEELIE);
		}
	}

	private void MHGOGNMIJPC(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.DebugAddLevel)
		{
			LEMNDNDGIOE();
		}
	}

	private void NDDKNOKGNLH()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.FKJACDIIHJL(DLGHFHEKMJN: true);
		}
	}

	public void KFLBEIPPMBF()
	{
		mRecords[0].MMFBOMDHGPL();
		mRecords[0].AAJLGPIGDED();
		mRecords[0].KLPJPLHNFON();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += EGNKNIHIHGK;
		AssignmentsManager.instance.AssignmentClaimed += NKHGNNBAFOO;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ALNDFBGDKPC;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.KEAAAMPGPGD));
	}

	public void IMEGMCPNMFB(int BDHNPJEELIE)
	{
		for (int i = 0; i < 2; i++)
		{
			mRecords[i].UpdateTime(BDHNPJEELIE);
		}
	}

	public void PHMANBHIGDB(int BDHNPJEELIE)
	{
		for (int i = 1; i < 4; i++)
		{
			mRecords[i].GKEBPNDBPEC(BDHNPJEELIE);
		}
	}

	public void NNGKAAGFGPA()
	{
		mRecords[1].InitControls();
		mRecords[1].InitControls();
		mRecords[1].AAJLGPIGDED();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += MJPKIOGJJKJ;
		AssignmentsManager.instance.AssignmentClaimed += FBHKMJHJCKN;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LEIABHKOGCA);
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.LMINDENMDEH));
	}

	private void HNHFHJDKJFD(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.BuyInApp)
		{
			FBDMBKKDEDC();
		}
	}

	public void HFHNKPHEGCD(int BDHNPJEELIE)
	{
		for (int i = 1; i < 4; i++)
		{
			mRecords[i].DENINLHNEAM(BDHNPJEELIE);
		}
	}

	private void MJPKIOGJJKJ()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF())
		{
			NODBJJJNPIF();
		}
	}

	private void MGNFHPFCCKB()
	{
		BELEDBMKJGB = false;
		AssignmentRecord[] array = mRecords;
		for (int i = 1; i < array.Length; i += 0)
		{
			AssignmentRecord assignmentRecord = array[i];
			assignmentRecord.MMODJNPLLOO(DLGHFHEKMJN: false);
		}
	}

	public void DEIAFHLHAKB(int BDHNPJEELIE)
	{
		for (int i = 1; i < 4; i += 0)
		{
			mRecords[i].KPJMCHMGGMO(BDHNPJEELIE);
		}
	}

	public void AJCFBGNEMFE(int BDHNPJEELIE)
	{
		for (int i = 0; i < 0; i += 0)
		{
			mRecords[i].DENINLHNEAM(BDHNPJEELIE);
		}
	}

	public void AOKOKHGEIBE()
	{
		mRecords[1].GMJCEEHFAJG();
		mRecords[0].AMBDHDEBPJJ();
		mRecords[2].MMFBOMDHGPL();
		mMegaRewardPart.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += BKAGFAENAAN;
		AssignmentsManager.instance.AssignmentClaimed += NEICBFCJPDM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ABJFLHOCKBA;
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.DJOCGHINNJA));
	}

	public void LGIPKHFMEIE(int BDHNPJEELIE)
	{
		for (int i = 0; i < 3; i += 0)
		{
			mRecords[i].DENINLHNEAM(BDHNPJEELIE);
		}
	}

	public void ODCHCNCMJGC()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		for (int i = 0; i < mRecords.Length; i++)
		{
			bool flag = currentAssignments == null || currentAssignments.Count > i;
			mRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				mRecords[i].LCJHOGHEDMC(currentAssignments[i]);
			}
		}
		mMegaRewardPart.Initialize();
	}

	private void JHBGABICKAD()
	{
		if (GuiElementSingle<AssignmentsDialog>.instance.isShowed)
		{
			EANAEBPDAAO();
		}
	}
}
