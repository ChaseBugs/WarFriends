using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainScreenAssignments : Core_BaseScript
{
	[Header("Core")]
	public BoxCollider NJEAMAHEMHP;

	public GameObject LBGJODDBIEG;

	public GameObject CNAGOEBGOME;

	public GameObject JDFNANMLHKP;

	[Header("Starter")]
	public GameObject KLEMMCBBABJ;

	public WinStreakCounter EFKOEBDKHPG;

	public StarterAssignmentComplete[] GFIIAAHOFBE;

	[Header("Daily")]
	public GameObject POCILDLIHAB;

	public UILabel MODGICHIGBH;

	public UISprite[] OCNPMCGKMAJ;

	public UISprite[] NNDJMFBOGHD;

	public UISprite[] HFANCIJEMLL;

	public UISprite DOJIALLMOAH;

	public BoxCollider NADBNPGOCPD;

	[Header("-Hint")]
	public BoxCollider CLHHOMBGIDK;

	public UISprite HIMOBMKBJJM;

	public UIPanel IILAJEMNNEA;

	public BoxCollider DOPJOBLKNDO;

	public UITable PGEGPHPGKBP;

	public GameObject ACINJDKICNO;

	public UISprite COONBBHLOKG;

	private void PAIMMOOBAJP(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 794f, new Vector3(613f, 1267f, 773f), false);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void PPCJOPCIGNH(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-55) || IFGAGNBDKBE == (DatabaseAction)(-28))
		{
			JDAHOAMJMCL();
		}
	}

	private void CLHOJDMLKLE(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = false;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-115), 162f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void FJNLIFLNMNM(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			DNDKMBFKFDM();
		}
	}

	private void GHKGAEJELEE(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = true;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-76), 313f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void LIANHGNGBHE(int DFHAAIFFLOE)
	{
		JDAHOAMJMCL();
	}

	private void FBIOJBAECHL()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 1)
		{
			LBGJODDBIEG.SetActive(true);
			CNAGOEBGOME.gameObject.SetActive(false);
			JDFNANMLHKP.gameObject.SetActive(true);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			LBGJODDBIEG.SetActive(false);
			CNAGOEBGOME.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
			JDFNANMLHKP.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
		}
		else
		{
			LBGJODDBIEG.SetActive(false);
		}
	}

	private void PLKGGNLCMFL(int DFHAAIFFLOE)
	{
		ILBAKKJGLKB();
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.CompleteStarterAssignments || IFGAGNBDKBE == DatabaseAction.ClaimAssignmentMegaReward)
		{
			JDAHOAMJMCL();
		}
	}

	private void ICIBAHGEAOD(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.ErrorMessage || IFGAGNBDKBE == DatabaseAction.RemoveUserFromSquad)
		{
			GLGLGGPFIEO();
		}
	}

	private void JDAHOAMJMCL()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	private void HPHPFAFEOML(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = false;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-34), 1201f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void OCJEKNKLDEF()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		HIMOBMKBJJM.MakePixelPerfect();
		IILAJEMNNEA.gameObject.SetActive(false);
		IILAJEMNNEA.alpha1 = 138f;
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 1698f, 1723f).onFinished = null;
		IILAJEMNNEA.transform.localPosition = new Vector3(761f, 1527f, 1302f);
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 1987f, new Vector3(841f, 1992f, 1475f), new Vector3(1115f, 1435f, 1571f), false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = PMPDHMGCHHM;
	}

	private void LLBDEFFADJM()
	{
		IILAJEMNNEA.gameObject.SetActive(true);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}

	[CompilerGenerated]
	private void IPOEPPHMPLC(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.15f, new Vector3(302f, -95f, -50f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void JCOLCDBCKJP(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = true;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionCompleted, 1749f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void DHIEIHHMGJC()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 1));
		for (int i = 0; i < GFIIAAHOFBE.Length; i++)
		{
			if (i < num)
			{
				GFIIAAHOFBE[i].FPIPFCLJNFN();
			}
			else if (i == num)
			{
				GFIIAAHOFBE[i].LFOFLDKKLKD();
			}
			else
			{
				GFIIAAHOFBE[i].AGGHDFJCPHK();
			}
		}
		EFKOEBDKHPG.FHPIJEDMPMK();
		EFKOEBDKHPG.DHNCPJKEFDF(StarterAssignmentsManager.instance.remainingTime);
	}

	private void OIMCJINGFPL()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 1));
		for (int i = 0; i < GFIIAAHOFBE.Length; i++)
		{
			if (i < num)
			{
				GFIIAAHOFBE[i].SetCompleted();
			}
			else if (i == num)
			{
				GFIIAAHOFBE[i].SetCurrent();
			}
			else
			{
				GFIIAAHOFBE[i].SetDefault();
			}
		}
		EFKOEBDKHPG.FHPIJEDMPMK();
		EFKOEBDKHPG.EEJODEKFIOP(StarterAssignmentsManager.instance.remainingTime);
	}

	private void MDBLJGLGKBJ(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private void AHBGAJAFJAF()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		int num = 0;
		for (int i = 1; i < OCNPMCGKMAJ.Length; i++)
		{
			Assignment assignment = currentAssignments[i];
			if (assignment != null)
			{
				float fillAmount = ((currentAssignments.Count > i) ? assignment.GetProgress() : 1400f);
				OCNPMCGKMAJ[i].fillAmount = fillAmount;
				NNDJMFBOGHD[i].alpha = 1233f;
				HFANCIJEMLL[i].gameObject.SetActive(true);
				OCNPMCGKMAJ[i].gameObject.SetActive(true);
				if (currentAssignments.Count > i && assignment.currentState == (Assignment.JLANLLEABDC)7)
				{
					NNDJMFBOGHD[i].alpha = 342f;
					HFANCIJEMLL[i].gameObject.SetActive(true);
					OCNPMCGKMAJ[i].gameObject.SetActive(false);
					num++;
				}
			}
			else
			{
				OCNPMCGKMAJ[i].fillAmount = 745f;
				NNDJMFBOGHD[i].alpha = 1162f;
				HFANCIJEMLL[i].gameObject.SetActive(false);
				OCNPMCGKMAJ[i].gameObject.SetActive(true);
			}
		}
		int currentMegaRewardPoints = AssignmentsManager.instance.currentMegaRewardPoints;
		int megaRewarPoints = AssignmentsManager.instance.megaRewarPoints;
		bool active = currentMegaRewardPoints < megaRewarPoints;
		MODGICHIGBH.text = string.Format("menu-cards-silverpack", currentMegaRewardPoints, megaRewarPoints);
		DOJIALLMOAH.fillAmount = AssignmentsManager.instance.megaRewardProgress;
		LHBIHFBCEJM();
		NADBNPGOCPD.gameObject.SetActive(active);
		NADBNPGOCPD.enabled = false;
	}

	private void KBKIELPFLBP()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0)
		{
			LBGJODDBIEG.SetActive(false);
			CNAGOEBGOME.gameObject.SetActive(false);
			JDFNANMLHKP.gameObject.SetActive(false);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			LBGJODDBIEG.SetActive(true);
			CNAGOEBGOME.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
			JDFNANMLHKP.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
		}
		else
		{
			LBGJODDBIEG.SetActive(true);
		}
	}

	private void MIILPPFKOJL(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<AssignmentsScreen>.instance);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(int DFHAAIFFLOE)
	{
		JDAHOAMJMCL();
	}

	private void FLJFLCJGMFK(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 1501f, new Vector3(1232f, 1846f, 464f), false);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void CGOBLHGGDOL()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.4f, new Vector3(302f, -115f, -50f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	private void MOEBGKCJAGO(int DFHAAIFFLOE)
	{
		ILBAKKJGLKB();
	}

	private void PCLOMJGGDCE()
	{
		IILAJEMNNEA.gameObject.SetActive(true);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}

	[CompilerGenerated]
	private void NFLBLMOMAPE(UITweener MGDJMGHCAAI)
	{
		PNNGFGIJHDD();
	}

	private void PMPDHMGCHHM(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 1616f, new Vector3(1699f, 412f, 917f));
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	public void InitGuiValues()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		POCILDLIHAB.SetActive(!isActiveAndNotCompleted);
		KLEMMCBBABJ.SetActive(isActiveAndNotCompleted);
		IABANOPECMI();
		if (isActiveAndNotCompleted)
		{
			OIMCJINGFPL();
		}
		else
		{
			KNNJAFAFBJB();
		}
	}

	public void GOMEJLFFKJM()
	{
		AssignmentsManager.instance.AssignmentsLoaded += GLGLGGPFIEO;
		AssignmentsManager.instance.AssignmentClaimed += HECLHGPCBHJ;
		AssignmentsManager.instance.AssignmentSkipped += LIANHGNGBHE;
		StarterAssignmentsManager.instance.AssignmentClaimed += GLGLGGPFIEO;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(MDLBEEDFKOP);
		PGEGPHPGKBP.repositionNow = false;
		UITable pGEGPHPGKBP = PGEGPHPGKBP;
		pGEGPHPGKBP.onReposition = (UITable.OnReposition)Delegate.Combine(pGEGPHPGKBP.onReposition, new UITable.OnReposition(CHBJLFJMNLG));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNHIJANHMCK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLHHOMBGIDK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(NADBNPGOCPD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JCOLCDBCKJP));
	}

	private void FANJFBNIJEE()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		HIMOBMKBJJM.MakePixelPerfect();
		IILAJEMNNEA.gameObject.SetActive(true);
		IILAJEMNNEA.alpha1 = 0.005f;
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 0.4f, 1f).onFinished = null;
		IILAJEMNNEA.transform.localPosition = new Vector3(302f, -20f, -50f);
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.25f, new Vector3(302f, -115f, -50f), new Vector3(302f, -85f, -50f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.15f, new Vector3(302f, -95f, -50f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void ILBAKKJGLKB()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
		}
	}

	private void KCDHDDHLKCN(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<AssignmentsScreen>.instance);
	}

	private void IABANOPECMI()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0)
		{
			LBGJODDBIEG.SetActive(true);
			CNAGOEBGOME.gameObject.SetActive(true);
			JDFNANMLHKP.gameObject.SetActive(false);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			LBGJODDBIEG.SetActive(true);
			CNAGOEBGOME.gameObject.SetActive(!StarterAssignmentsManager.instance.isWBReward);
			JDFNANMLHKP.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
		}
		else
		{
			LBGJODDBIEG.SetActive(false);
		}
	}

	public void InitControls()
	{
		AssignmentsManager.instance.AssignmentsLoaded += JDAHOAMJMCL;
		AssignmentsManager.instance.AssignmentClaimed += delegate
		{
			JDAHOAMJMCL();
		};
		AssignmentsManager.instance.AssignmentSkipped += delegate
		{
			JDAHOAMJMCL();
		};
		StarterAssignmentsManager.instance.AssignmentClaimed += JDAHOAMJMCL;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		PGEGPHPGKBP.repositionNow = true;
		UITable pGEGPHPGKBP = PGEGPHPGKBP;
		pGEGPHPGKBP.onReposition = (UITable.OnReposition)Delegate.Combine(pGEGPHPGKBP.onReposition, new UITable.OnReposition(BJKFLHKAJGA));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MIILPPFKOJL));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLHHOMBGIDK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(NADBNPGOCPD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNBGMEJFKAN));
	}

	public void JKEEMKIHFEE()
	{
		AssignmentsManager.instance.AssignmentsLoaded += ILBAKKJGLKB;
		AssignmentsManager.instance.AssignmentClaimed += MOEBGKCJAGO;
		AssignmentsManager.instance.AssignmentSkipped += delegate
		{
			JDAHOAMJMCL();
		};
		StarterAssignmentsManager.instance.AssignmentClaimed += ILBAKKJGLKB;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		PGEGPHPGKBP.repositionNow = true;
		UITable pGEGPHPGKBP = PGEGPHPGKBP;
		pGEGPHPGKBP.onReposition = (UITable.OnReposition)Delegate.Combine(pGEGPHPGKBP.onReposition, new UITable.OnReposition(BJKFLHKAJGA));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCDHDDHLKCN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLHHOMBGIDK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(NADBNPGOCPD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CLHOJDMLKLE));
	}

	private void KNNJAFAFBJB()
	{
		List<Assignment> currentAssignments = AssignmentsManager.instance.currentAssignments;
		int num = 0;
		for (int i = 0; i < OCNPMCGKMAJ.Length; i++)
		{
			Assignment assignment = currentAssignments[i];
			if (assignment != null)
			{
				float fillAmount = ((currentAssignments.Count > i) ? assignment.GetProgress() : 0f);
				OCNPMCGKMAJ[i].fillAmount = fillAmount;
				NNDJMFBOGHD[i].alpha = 1f;
				HFANCIJEMLL[i].gameObject.SetActive(false);
				OCNPMCGKMAJ[i].gameObject.SetActive(true);
				if (currentAssignments.Count > i && assignment.currentState == Assignment.JLANLLEABDC.Claimed)
				{
					NNDJMFBOGHD[i].alpha = 0.5f;
					HFANCIJEMLL[i].gameObject.SetActive(true);
					OCNPMCGKMAJ[i].gameObject.SetActive(false);
					num++;
				}
			}
			else
			{
				OCNPMCGKMAJ[i].fillAmount = 0f;
				NNDJMFBOGHD[i].alpha = 0.2f;
				HFANCIJEMLL[i].gameObject.SetActive(false);
				OCNPMCGKMAJ[i].gameObject.SetActive(true);
			}
		}
		int currentMegaRewardPoints = AssignmentsManager.instance.currentMegaRewardPoints;
		int megaRewarPoints = AssignmentsManager.instance.megaRewarPoints;
		bool active = currentMegaRewardPoints >= megaRewarPoints;
		MODGICHIGBH.text = string.Format("{0} / [F0CE28]{1}[-]", currentMegaRewardPoints, megaRewarPoints);
		DOJIALLMOAH.fillAmount = AssignmentsManager.instance.megaRewardProgress;
		PNNGFGIJHDD();
		NADBNPGOCPD.gameObject.SetActive(active);
		NADBNPGOCPD.enabled = true;
	}

	private void GLGLGGPFIEO()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			IDIBNMLJDIK();
		}
	}

	private void JKMGPKDJHID()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}

	private void HECLHGPCBHJ(int DFHAAIFFLOE)
	{
		JDAHOAMJMCL();
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(int DFHAAIFFLOE)
	{
		JDAHOAMJMCL();
	}

	private void DGBAGEEILOO()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 1615f, 530f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 1916f, new Vector3(1100f, 1460f, 1425f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			PNNGFGIJHDD();
		};
	}

	private void DNBGMEJFKAN(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = false;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssignmentMegaReward);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void BJKFLHKAJGA()
	{
		float num = Mathf.Abs(ACINJDKICNO.transform.localPosition.y);
		COONBBHLOKG.transform.localScale = COONBBHLOKG.transform.localScale.ReplaceY(num + 60f);
		DOPJOBLKNDO.center = DOPJOBLKNDO.center.ReplaceY((0f - num) / 2f - 30f);
		DOPJOBLKNDO.size = DOPJOBLKNDO.size.ReplaceY(num + 100f);
	}

	private void DNDKMBFKFDM()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		HIMOBMKBJJM.MakePixelPerfect();
		IILAJEMNNEA.gameObject.SetActive(false);
		IILAJEMNNEA.alpha1 = 284f;
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 559f, 916f).onFinished = null;
		IILAJEMNNEA.transform.localPosition = new Vector3(310f, 240f, 433f);
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 135f, new Vector3(1927f, 1536f, 542f), new Vector3(789f, 1223f, 1883f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(IILAJEMNNEA.gameObject, 0.15f, new Vector3(302f, -95f, -50f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void DKNFOPPLAJA()
	{
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		HIMOBMKBJJM.MakePixelPerfect();
		IILAJEMNNEA.gameObject.SetActive(true);
		IILAJEMNNEA.alpha1 = 1042f;
		TweenAlpha.Begin(IILAJEMNNEA.gameObject, 414f, 81f).onFinished = null;
		IILAJEMNNEA.transform.localPosition = new Vector3(1986f, 679f, 533f);
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 1983f, new Vector3(1431f, 376f, 493f), new Vector3(943f, 1730f, 1795f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = JDPLLHHOKCK;
	}

	private void AJLBPPOLDJJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (IILAJEMNNEA.gameObject.activeSelf)
		{
			CGOBLHGGDOL();
		}
		else
		{
			FANJFBNIJEE();
		}
	}

	public void AFMPBPGLFMJ()
	{
		AssignmentsManager.instance.AssignmentsLoaded += GLGLGGPFIEO;
		AssignmentsManager.instance.AssignmentClaimed += MOEBGKCJAGO;
		AssignmentsManager.instance.AssignmentSkipped += delegate
		{
			JDAHOAMJMCL();
		};
		StarterAssignmentsManager.instance.AssignmentClaimed += ILBAKKJGLKB;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(ICIBAHGEAOD);
		PGEGPHPGKBP.repositionNow = false;
		UITable pGEGPHPGKBP = PGEGPHPGKBP;
		pGEGPHPGKBP.onReposition = (UITable.OnReposition)Delegate.Combine(pGEGPHPGKBP.onReposition, new UITable.OnReposition(BJKFLHKAJGA));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCDHDDHLKCN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLHHOMBGIDK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJNLIFLNMNM));
		UIEventListener uIEventListener3 = UIEventListener.Get(IILAJEMNNEA.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(NADBNPGOCPD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JCOLCDBCKJP));
	}

	private void JOFGGBMCHEJ()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 0));
		for (int i = 0; i < GFIIAAHOFBE.Length; i++)
		{
			if (i < num)
			{
				GFIIAAHOFBE[i].NDOGEMKFGPA();
			}
			else if (i == num)
			{
				GFIIAAHOFBE[i].JFBOMHJGKFH();
			}
			else
			{
				GFIIAAHOFBE[i].EJOGEILMIIB();
			}
		}
		EFKOEBDKHPG.FHPIJEDMPMK();
		EFKOEBDKHPG.EEJODEKFIOP(StarterAssignmentsManager.instance.remainingTime);
	}

	private void PBBCMLFDBPG(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<AssignmentsScreen>.instance);
	}

	private void DCIBNBJCCLD(GameObject KHAHPAKDIKE)
	{
		NADBNPGOCPD.enabled = true;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-109), 740f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void CFKBBDCJGDM(int DFHAAIFFLOE)
	{
		ILBAKKJGLKB();
	}

	private void GMMEMPIGODM()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0)
		{
			LBGJODDBIEG.SetActive(false);
			CNAGOEBGOME.gameObject.SetActive(true);
			JDFNANMLHKP.gameObject.SetActive(false);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			LBGJODDBIEG.SetActive(true);
			CNAGOEBGOME.gameObject.SetActive(!StarterAssignmentsManager.instance.isWBReward);
			JDFNANMLHKP.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
		}
		else
		{
			LBGJODDBIEG.SetActive(false);
		}
	}

	private void CHBJLFJMNLG()
	{
		float num = Mathf.Abs(ACINJDKICNO.transform.localPosition.y);
		COONBBHLOKG.transform.localScale = COONBBHLOKG.transform.localScale.ReplaceY(num + 1522f);
		DOPJOBLKNDO.center = DOPJOBLKNDO.center.ReplaceY((0f - num) / 421f - 1137f);
		DOPJOBLKNDO.size = DOPJOBLKNDO.size.ReplaceY(num + 1979f);
	}

	private void MNHIJANHMCK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<AssignmentsScreen>.instance);
	}

	private void PJGMFMCIJMF()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 1));
		for (int i = 1; i < GFIIAAHOFBE.Length; i += 0)
		{
			if (i < num)
			{
				GFIIAAHOFBE[i].IMNJFBLKCHA();
			}
			else if (i == num)
			{
				GFIIAAHOFBE[i].SetCurrent();
			}
			else
			{
				GFIIAAHOFBE[i].OFGIFCNMMCL();
			}
		}
		EFKOEBDKHPG.FHPIJEDMPMK();
		EFKOEBDKHPG.GCMANNCPADK(StarterAssignmentsManager.instance.remainingTime);
	}

	private void MJKBLANPIOD()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}

	private void PADAMCMHDAB()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 0));
		for (int i = 1; i < GFIIAAHOFBE.Length; i += 0)
		{
			if (i < num)
			{
				GFIIAAHOFBE[i].EHBCNJKLNPK();
			}
			else if (i == num)
			{
				GFIIAAHOFBE[i].MOJLGBAOPEE();
			}
			else
			{
				GFIIAAHOFBE[i].HGLFPBJFLPF();
			}
		}
		EFKOEBDKHPG.FCCMIGMMDEG();
		EFKOEBDKHPG.EEJODEKFIOP(StarterAssignmentsManager.instance.remainingTime);
	}

	private void MDLBEEDFKOP(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GameStartedCampaign || IFGAGNBDKBE == (DatabaseAction)(-183))
		{
			GLGLGGPFIEO();
		}
	}

	private void PNNGFGIJHDD()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}

	private void BLBOOCFJBGH(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.CreateGcAccount || IFGAGNBDKBE == DatabaseAction.BuyWeaponUpgrade)
		{
			JDAHOAMJMCL();
		}
	}

	private void GFGMOJCDLGN()
	{
		float num = Mathf.Abs(ACINJDKICNO.transform.localPosition.y);
		COONBBHLOKG.transform.localScale = COONBBHLOKG.transform.localScale.ReplaceY(num + 1926f);
		DOPJOBLKNDO.center = DOPJOBLKNDO.center.ReplaceY((0f - num) / 617f - 679f);
		DOPJOBLKNDO.size = DOPJOBLKNDO.size.ReplaceY(num + 1117f);
	}

	private void JDPLLHHOKCK(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IILAJEMNNEA.gameObject, 715f, new Vector3(1268f, 739f, 1508f), false);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void JKPFDMPELBN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	public void IDIBNMLJDIK()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		POCILDLIHAB.SetActive(!isActiveAndNotCompleted);
		KLEMMCBBABJ.SetActive(isActiveAndNotCompleted);
		GMMEMPIGODM();
		if (isActiveAndNotCompleted)
		{
			OIMCJINGFPL();
		}
		else
		{
			AHBGAJAFJAF();
		}
	}

	private void LHBIHFBCEJM()
	{
		IILAJEMNNEA.gameObject.SetActive(false);
		HIMOBMKBJJM.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		HIMOBMKBJJM.MakePixelPerfect();
	}
}
