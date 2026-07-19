using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StarterAssignmentPart : Core_BaseScript
{
	[Header("Core")]
	public UIPanel CFFKHHJKBMJ;

	public UIPanel[] LEELKOOOHOH;

	[Header("Completition")]
	public GameObject FEDEOJHHKBJ;

	public UILabel BIHDHODOJJA;

	public StarterAssignmentComplete[] HCEKAMFLPLK;

	[Header("Current Assignment")]
	public StarterAssignmentRecord ALLPMIFFDMA;

	[Header("Rewards")]
	public GameObject LGBIALCPJJO;

	public UILabel HMILHDMPEHE;

	public UIGrid HHAAKINPOPB;

	public UITexture NGHCDIMLGMO;

	private bool IHEPLEBDJCB;

	private bool JFKIPIKKGNO;

	public void PLAKLPJEAHM()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (153f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 815f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 1064f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(1870f + num / 895f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 86f, 254f + num);
		float num2 = 218f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 1099f - 1034f * num2) / 1183f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 609f) / 961f + num2 / 337f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += JJBEBLMPLIH;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void EAEDCJDPIOG(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == DatabaseAction.ClaimCraftedCard)
		{
			PMBPAOLBLFA();
		}
	}

	private void PMBPAOLBLFA()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LHAINBLLMKB));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < HCEKAMFLPLK.Length; i++)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].SetCompleted();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].SetCurrent();
			}
			else
			{
				HCEKAMFLPLK[i].SetDefault();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		NKACHLHLHLH();
	}

	private void KLAJOICAIHD()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].OFEDCPAAGBL();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].GGLIGOEINNH();
		}
	}

	private void BBIBCELPGEF()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].EIFPLGFGIFI();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].CEGBPBCEGNF();
		}
	}

	public void AOKOKHGEIBE()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (377f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 1266f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 1032f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(1772f + num / 709f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 762f, 1728f + num);
		float num2 = 279f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 1050f - 853f * num2) / 353f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 971f) / 1022f + num2 / 1481f);
		ALLPMIFFDMA.KNOKOJKOCEB(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += KLAJOICAIHD;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MHGOGNMIJPC;
	}

	public void CGNAGNAOEJA(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			NAMPECFNCLJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 44f) : 990f, (!IHEPLEBDJCB) ? 1203f : 1983f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 922f) : 1232f, (!IHEPLEBDJCB) ? 1691f : 771f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			OBHCKFBKNOD();
		}
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

	private void BGFDEKOPOEI(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	private void GKDPPGMNNEM()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].AnimateFinish();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].AnimateProgress();
		}
	}

	public void DGLFBGIFAND(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			ACLOLICAKGL();
		}
		if (base.gameObject.activeSelf)
		{
			BIOEEBECOEM((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 25f) : 904f, (!IHEPLEBDJCB) ? 840f : 1174f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1679f) : 601f, (!IHEPLEBDJCB) ? 211f : 467f).onFinished = HLNOEADEHBA;
		}
		else if (!IHEPLEBDJCB)
		{
			KDLOHIBMEBO();
		}
	}

	private void NAMPECFNCLJ(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i += 0)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void EBHBOCDLLKA(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	private void AFNPNEHACIN()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			resourceLoaderTexture2D.FreeAsset("banana");
			JFKIPIKKGNO = false;
		}
	}

	private void JCGDALOBGHO()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(ANCCELHKPJP));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < HCEKAMFLPLK.Length; i += 0)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].NDOGEMKFGPA();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].JFBOMHJGKFH();
			}
			else
			{
				HCEKAMFLPLK[i].OFGIFCNMMCL();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		DFLJNAHHMAI();
	}

	private void KADANDIFHLF()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("player_level");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1254f * Singleton<GuiTexureAssets>.instance.NFJLFPEOFKD());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void KMGPEHGOEHB()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("id: ");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(38f * Singleton<GuiTexureAssets>.instance.MNDPPODHJHA());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(true);
			}
		}
	}

	private void EEELLLONGJE(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			BGDPJGNKPKB();
		}
	}

	private void FOHNBAGCDGB(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == DatabaseAction.UpdateSquad)
		{
			FACKIKMABGK();
		}
	}

	private void JPPNHHDKNEP()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("customDate");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1023f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(true);
			}
		}
	}

	private void IMCLOGOONPP()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].NGEJCCPFCGC();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].GGLIGOEINNH();
		}
	}

	public void FMEJLMMLBPD()
	{
		base.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
		NMIADNEAAFB();
	}

	private void PACHKLGLHLA(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == DatabaseAction.SearchPlayers)
		{
			DOLLFDPMGOD();
		}
	}

	private void EFPJLANPNOK()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset("ID_CONFIRM_ERROR");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1731f * Singleton<GuiTexureAssets>.instance.NDEPMHDDMFL());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void DFLJNAHHMAI()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("LootboxType");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1949f * Singleton<GuiTexureAssets>.instance.PNEJKIKMMJL());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void OBHCKFBKNOD()
	{
		DoAfterHide();
	}

	private void LHAINBLLMKB()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
			HMILHDMPEHE.text = Localization.Localize("ID_YOURREWARDS");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("ID_EXPIRED");
			HMILHDMPEHE.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
		}
		else
		{
			BIHDHODOJJA.text = string.Format("{0} {1}{2}", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
			HMILHDMPEHE.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "ID_READYTIME", string.Empty));
		}
	}

	private void NPLOPHFGDKK()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("UnitsDeployed");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(637f * Singleton<GuiTexureAssets>.instance.MMPHJJIMJPI());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void ALJEEHNFPFC()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			resourceLoaderTexture2D.FreeAsset(", ");
			JFKIPIKKGNO = true;
		}
	}

	public void MPNFAPKFNHL()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (1347f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 652f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 789f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(1359f + num / 662f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 708f, 1086f + num);
		float num2 = 789f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 890f - 1781f * num2) / 1848f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 236f) / 841f + num2 / 99f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += GKDPPGMNNEM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MHGOGNMIJPC;
	}

	private void FACKIKMABGK()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LHAINBLLMKB));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < HCEKAMFLPLK.Length; i++)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].FMNCHNGNIKH();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].LFOFLDKKLKD();
			}
			else
			{
				HCEKAMFLPLK[i].KILICFGAKGA();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		KADANDIFHLF();
	}

	public void DKOBOPADMMI()
	{
		base.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IDJOMCPNFAF));
		NMIADNEAAFB();
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
				NGHCDIMLGMO.gameObject.SetActive(true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.617f * Singleton<GuiTexureAssets>.instance.scale);
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	public void BCLDACBBJPO(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			GCPDEEPCBOF();
		}
		if (base.gameObject.activeSelf)
		{
			GMPLEKKOGMF((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1762f) : 1047f, (!IHEPLEBDJCB) ? 1275f : 1486f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 158f) : 49f, (!IHEPLEBDJCB) ? 759f : 508f).onFinished = JIDGJEKLAMN;
		}
		else if (!IHEPLEBDJCB)
		{
			JJBIDFEPIAN();
		}
	}

	private void JILOAENNJKF()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_DEBUG_STACKTRACEINCONSOLE");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1948f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void MHIFDHGPDCK()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(ANCCELHKPJP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < HCEKAMFLPLK.Length; i++)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].NDOGEMKFGPA();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].MOJLGBAOPEE();
			}
			else
			{
				HCEKAMFLPLK[i].DMIKGONFFLP();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		DFLJNAHHMAI();
	}

	public void PEPFALDMHLH(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			GCPDEEPCBOF();
		}
		if (base.gameObject.activeSelf)
		{
			NAMPECFNCLJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 708f) : 1151f, (!IHEPLEBDJCB) ? 1082f : 1358f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 857f) : 1370f, (!IHEPLEBDJCB) ? 1531f : 411f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			JJBIDFEPIAN();
		}
	}

	private void KCPMBAIILCG(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == (DatabaseAction)(-92))
		{
			ACLOLICAKGL();
		}
	}

	private void CNPDJMHJPGM(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			FMEJLMMLBPD();
		}
	}

	public void GOMEJLFFKJM()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (1581f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 1292f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 1915f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(246f + num / 944f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 1298f, 1610f + num);
		float num2 = 1751f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 1059f - 297f * num2) / 1456f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 834f) / 1124f + num2 / 859f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += BBIBCELPGEF;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
	}

	public void PPLPLCAEHLF(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			MHIFDHGPDCK();
		}
		if (base.gameObject.activeSelf)
		{
			BIEHAAKCJPA((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1985f) : 1244f, (!IHEPLEBDJCB) ? 1557f : 1176f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 124f) : 1275f, (!IHEPLEBDJCB) ? 970f : 888f).onFinished = EDFCJKBPGNA;
		}
		else if (!IHEPLEBDJCB)
		{
			OBHCKFBKNOD();
		}
	}

	private void GMPLEKKOGMF(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 0; i < LEELKOOOHOH.Length; i++)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void LCAGFCAKPEC()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("ID_GOLDENSHIELDS");
			HMILHDMPEHE.text = Localization.Localize("unsubscribed.");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("ManualRegisterForPushNotifications(");
			HMILHDMPEHE.text = Localization.Localize("silver");
			return;
		}
		BIHDHODOJJA.text = string.Format("Null cannot be saved as last weapon.", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "\t\"TRUE\"", string.Empty, false), Colours.stringWhite, Localization.Localize("getNumberOfSessions"));
		UILabel hMILHDMPEHE = HMILHDMPEHE;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "ID_GUI_CHAT_SQUAD_JOINED", string.Empty);
		hMILHDMPEHE.text = Localization.LocalizeFormat("ID_UNIT2UPGRADEABILITY_UNIT1BUY", array);
	}

	private void HDPBFLANMGB()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("changing moneypack to B variant withoud data from fuseboxx");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(344f * Singleton<GuiTexureAssets>.instance.NFJLFPEOFKD());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(true);
			}
		}
	}

	private void AMDJKDCJGHK()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_WARNING_NOTENOUGHTGOLDFORWARBUCKS");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1690f * Singleton<GuiTexureAssets>.instance.scale);
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(true);
			}
		}
	}

	private void BNPDALDLFFM()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IJCLAHMPBEM));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < HCEKAMFLPLK.Length; i++)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].DPILIMGLILA();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].MOJLGBAOPEE();
			}
			else
			{
				HCEKAMFLPLK[i].EJOGEILMIIB();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		JPPNHHDKNEP();
	}

	private void NKDPGJKFLGC()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GAIGOIIFIIP();
			resourceLoaderTexture2D.FreeAsset("Player_Avoided_Grenade_On_First_Try");
			JFKIPIKKGNO = false;
		}
	}

	private void ACLOLICAKGL()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(ANCCELHKPJP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(IDJOMCPNFAF));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < HCEKAMFLPLK.Length; i += 0)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].EHBCNJKLNPK();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].PAHAGJBMPAG();
			}
			else
			{
				HCEKAMFLPLK[i].OFGIFCNMMCL();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		AMDJKDCJGHK();
	}

	private void NMIADNEAAFB()
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

	private void DOLLFDPMGOD()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LHAINBLLMKB));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < HCEKAMFLPLK.Length; i++)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].DPILIMGLILA();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].JFBOMHJGKFH();
			}
			else
			{
				HCEKAMFLPLK[i].DMIKGONFFLP();
			}
		}
		ALLPMIFFDMA.HBDEPMJNLEK(currentAssignment);
		KMGPEHGOEHB();
	}

	[CompilerGenerated]
	private void AMLFLGIACFL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	public void DoAfterHide()
	{
		base.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LHAINBLLMKB));
		NMIADNEAAFB();
	}

	public void DBGBPLFENBG(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			NAMPECFNCLJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1278f) : 132f, (!IHEPLEBDJCB) ? 913f : 1654f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 753f) : 1555f, (!IHEPLEBDJCB) ? 1957f : 1279f).onFinished = JIDGJEKLAMN;
		}
		else if (!IHEPLEBDJCB)
		{
			OBHCKFBKNOD();
		}
	}

	private void KDLOHIBMEBO()
	{
		DoAfterHide();
	}

	public void JIPNELFJIDA(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			HEBFPFJEKPJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1184f) : 1129f, (!IHEPLEBDJCB) ? 198f : 82f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 929f) : 730f, (!IHEPLEBDJCB) ? 808f : 1810f).onFinished = HLNOEADEHBA;
		}
		else if (!IHEPLEBDJCB)
		{
			FGHKCPDKIKM();
		}
	}

	private void JGANNEFCIOB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset("ID_BRONZE");
			JFKIPIKKGNO = true;
		}
	}

	private void ANCCELHKPJP()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("ID_SLOTUPGRADE_DAMAGE");
			HMILHDMPEHE.text = Localization.Localize("throw_grenade_right");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("CONFIRM");
			HMILHDMPEHE.text = Localization.Localize("x");
			return;
		}
		BIHDHODOJJA.text = string.Format(" null FacebookMeResult", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "Level", string.Empty), Colours.stringWhite, Localization.Localize("ID_TONORMALLEAGUEHINT2"));
		UILabel hMILHDMPEHE = HMILHDMPEHE;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, " ", string.Empty);
		hMILHDMPEHE.text = Localization.LocalizeFormat("unit", array);
	}

	private void IDJOMCPNFAF()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("nextSquadWars");
			HMILHDMPEHE.text = Localization.Localize("DogTagRefillTime");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("Gold");
			HMILHDMPEHE.text = Localization.Localize("{0} {1}");
			return;
		}
		BIHDHODOJJA.text = string.Format("Silver", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "Player Entered League:{0}  tier:{1}  division:{2}", string.Empty), Colours.stringWhite, Localization.Localize("x"));
		UILabel hMILHDMPEHE = HMILHDMPEHE;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "1", string.Empty, false);
		hMILHDMPEHE.text = Localization.LocalizeFormat("damage", array);
	}

	public void CKPCFIPPDLC()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (1264f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 964f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 946f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(1758f + num / 621f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 930f, 519f + num);
		float num2 = 1495f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 127f - 590f * num2) / 505f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 1596f) / 352f + num2 / 174f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += BFCIMDIIHOK;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += EAEDCJDPIOG;
	}

	private void ADLGKBKMGLO()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("com/google/android/gms/common/ConnectionResult");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(false);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1571f * Singleton<GuiTexureAssets>.instance.IPLEADDEGEI());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(true);
			}
		}
	}

	private void JIDGJEKLAMN(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DKOBOPADMMI();
		}
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			HEBFPFJEKPJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			OBHCKFBKNOD();
		}
	}

	public void NFABHLHCNGJ()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (689f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 779f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 1315f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(688f + num / 921f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 1735f, 1680f + num);
		float num2 = 240f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 939f - 1163f * num2) / 344f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 1472f) / 1589f + num2 / 369f);
		ALLPMIFFDMA.KNOKOJKOCEB(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += IMCLOGOONPP;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(ECKDFNKKAAF);
	}

	public void NEINEPJDKCL()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (650f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 513f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 498f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(826f + num / 555f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 1156f, 1600f + num);
		float num2 = 202f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 1191f - 148f * num2) / 1137f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 786f) / 888f + num2 / 704f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += IMCLOGOONPP;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += KCPMBAIILCG;
	}

	private void JJBEBLMPLIH()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 0].MGMPFCPIJJN();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].NOCAKGBIBLH();
		}
	}

	public void GBJHCKCPOBB()
	{
		base.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IDJOMCPNFAF));
		NMIADNEAAFB();
	}

	private void LPLBGPDAPOF(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == (DatabaseAction)(-32))
		{
			JCGDALOBGHO();
		}
	}

	private void CCPCHEFNAJB()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("S");
			if (texture2D != null)
			{
				NGHCDIMLGMO.gameObject.SetActive(true);
				NGHCDIMLGMO.mainTexture = texture2D;
				NGHCDIMLGMO.MakePixelPerfect();
				NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1724f * Singleton<GuiTexureAssets>.instance.NNOEPDDIFBA());
			}
			else
			{
				NGHCDIMLGMO.transform.localScale = Vector3.one;
				NGHCDIMLGMO.gameObject.SetActive(false);
			}
		}
	}

	private void GCPDEEPCBOF()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(ALNHIJKOBEK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < HCEKAMFLPLK.Length; i += 0)
		{
			if (i < num)
			{
				HCEKAMFLPLK[i].FPIPFCLJNFN();
			}
			else if (i == num)
			{
				HCEKAMFLPLK[i].JFBOMHJGKFH();
			}
			else
			{
				HCEKAMFLPLK[i].EJOGEILMIIB();
			}
		}
		ALLPMIFFDMA.Initialize(currentAssignment);
		JPPNHHDKNEP();
	}

	private void AEIKDIGDBGG(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == (DatabaseAction)(-86))
		{
			JCGDALOBGHO();
		}
	}

	private void MHGOGNMIJPC(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == DatabaseAction.UpdateSettings)
		{
			FACKIKMABGK();
		}
	}

	private void HIBBEDGNFMN()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].OFEDCPAAGBL();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].JIFIFBJANHO();
		}
	}

	private void ALNHIJKOBEK()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize(" OK!");
			HMILHDMPEHE.text = Localization.Localize("ID_WARNING_BADVERSIONERROR_TEXT");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("ID_ONETIMESPECIALOFFER");
			HMILHDMPEHE.text = Localization.Localize("Different league \"{0}\" and \"{1}\"\n");
		}
		else
		{
			BIHDHODOJJA.text = string.Format("Wrong_Weapon", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "fuseData", string.Empty, false), Colours.stringWhite, Localization.Localize("PlayerName"));
			HMILHDMPEHE.text = Localization.LocalizeFormat("JoinRoomFailedAfterReconnect: {0} GameIsRunning: {1}", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "Missing references in Special Pack Record: ", string.Empty));
		}
	}

	private void FGHKCPDKIKM()
	{
		FMEJLMMLBPD();
	}

	private void NBDNHDEKABM()
	{
		GBJHCKCPOBB();
	}

	private void JOCJHIHNEJH()
	{
		BGDPJGNKPKB();
	}

	private void BIEHAAKCJPA(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		for (int i = 1; i < LEELKOOOHOH.Length; i += 0)
		{
			if (LEELKOOOHOH[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(LEELKOOOHOH[i].gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void FDBJBPCJOOO(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DoAfterHide();
		}
	}

	private void JJBIDFEPIAN()
	{
		NMMEDNEGDNI();
	}

	public void NMMEDNEGDNI()
	{
		base.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(LCAGFCAKPEC));
		NKDPGJKFLGC();
	}

	private void ECKDFNKKAAF(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == (DatabaseAction)137)
		{
			FACKIKMABGK();
		}
	}

	private void EDFCJKBPGNA(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			GBJHCKCPOBB();
		}
	}

	private void IJCLAHMPBEM()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("FuseSDK: Parsing error in _AdDidShow");
			HMILHDMPEHE.text = Localization.Localize(" {0}{1}");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("Play_Card_Tutorial_Duration");
			HMILHDMPEHE.text = Localization.Localize("Mobile/Diffuse");
			return;
		}
		BIHDHODOJJA.text = string.Format("CannonDamage", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "Shots_Hits", string.Empty, false), Colours.stringWhite, Localization.Localize("Cancel - Disconnect, clicked in dialog !!!"));
		UILabel hMILHDMPEHE = HMILHDMPEHE;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, " (", string.Empty, false);
		hMILHDMPEHE.text = Localization.LocalizeFormat("{0}-firstTime-{1}", array);
	}

	public void PIFPDLGICNP(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			JCGDALOBGHO();
		}
		if (base.gameObject.activeSelf)
		{
			BIEHAAKCJPA((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1356f) : 603f, (!IHEPLEBDJCB) ? 10f : 1395f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 215f) : 1593f, (!IHEPLEBDJCB) ? 1805f : 1680f).onFinished = HLNOEADEHBA;
		}
		else if (!IHEPLEBDJCB)
		{
			NBDNHDEKABM();
		}
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

	public void FHJDLCDAMGI()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (1261f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 369f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 957f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(438f + num / 1053f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 1234f, 1087f + num);
		float num2 = 541f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 1763f - 1353f * num2) / 577f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 749f) / 1373f + num2 / 1706f);
		ALLPMIFFDMA.KNOKOJKOCEB(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += BFCIMDIIHOK;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += EAEDCJDPIOG;
	}

	public void BGDPJGNKPKB()
	{
		base.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IDJOMCPNFAF));
		NMIADNEAAFB();
	}

	public void MEMHLENAOMB(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			DOLLFDPMGOD();
		}
		if (base.gameObject.activeSelf)
		{
			HEBFPFJEKPJ((!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 1472f) : 1006f, (!IHEPLEBDJCB) ? 1607f : 451f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<AssignmentsScreen>.instance.HAMKIKMJHDP * 633f) : 1434f, (!IHEPLEBDJCB) ? 1731f : 1647f).onFinished = FDBJBPCJOOO;
		}
		else if (!IHEPLEBDJCB)
		{
			NBDNHDEKABM();
		}
	}

	private void BFCIMDIIHOK()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		HCEKAMFLPLK[num - 1].IOBGBKMCJNC();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			HCEKAMFLPLK[num].DGONDPIDHKN();
		}
	}

	private void HLNOEADEHBA(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			DKOBOPADMMI();
		}
	}

	private void DMLBMBKPELI()
	{
		FMEJLMMLBPD();
	}

	private void OMLILLGCIDA()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JFKIPIKKGNO)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			resourceLoaderTexture2D.FreeAsset("Attempt");
			JFKIPIKKGNO = true;
		}
	}

	public void InitControls()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = (1f - Singleton<GameVariables>.instance.multiplierYfromRatio) * 100f;
		FEDEOJHHKBJ.transform.localPosition = FEDEOJHHKBJ.transform.localPosition.ReplaceX(activeWidthSafe / 2f);
		ALLPMIFFDMA.transform.localPosition = ALLPMIFFDMA.transform.localPosition.ReplaceY(-340f + num / 2f);
		LGBIALCPJJO.transform.localPosition = LGBIALCPJJO.transform.localPosition.ReplaceXY(activeWidthSafe / 2f, -600f + num);
		float num2 = 326f;
		HHAAKINPOPB.cellWidth = num2 + (activeWidthSafe - 120f - 5f * num2) / 4f;
		HHAAKINPOPB.transform.localPosition = HHAAKINPOPB.transform.localPosition.ReplaceX(0f - (activeWidthSafe - 120f) / 2f + num2 / 2f);
		ALLPMIFFDMA.InitControls(activeWidthSafe);
		StarterAssignmentsManager.instance.AssignmentClaimed += GKDPPGMNNEM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void HLBCBOAALOB()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			BIHDHODOJJA.text = Colours.stringWhite + Localization.Localize("Skip_Wait_Weapon_Upgrades");
			HMILHDMPEHE.text = Localization.Localize("ReportedPlayerId");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			BIHDHODOJJA.text = Localization.Localize("Gold");
			HMILHDMPEHE.text = Localization.Localize("ID_RANK");
		}
		else
		{
			BIHDHODOJJA.text = string.Format("DOWNLOAD", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "startSession", string.Empty), Colours.stringWhite, Localization.Localize("menu-squad-10"));
			HMILHDMPEHE.text = Localization.LocalizeFormat("Clicked buy on ", MEJMLNDFDBP.CJCFPDLDMEK(remainingTime, "ID_AVAILABLE", string.Empty));
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && IFGAGNBDKBE == DatabaseAction.CompleteStarterAssignments)
		{
			PMBPAOLBLFA();
		}
	}
}
