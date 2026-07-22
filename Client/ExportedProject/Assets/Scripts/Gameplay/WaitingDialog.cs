using UnityEngine;
using UnityEngine.Serialization;

public class WaitingDialog : GuiElementSingle<WaitingDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("HKAELKNPPGD")]
	[Header("Content")]
	public UILabel NFNLBEGFLHC;

	private bool FNHMJEBIOJB;

	public virtual void COBDHBOCGAP()
	{
	}

	public virtual void NHKGKDBAKLH()
	{
	}

	public virtual void LLJMGDDLIEG()
	{
	}

	public virtual void GJBBEAMNJEG()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	protected virtual void OFNEGNKMKKG()
	{
		base.BOEMHLPLOGA();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public GuiElement BEOCBHEIKKO()
	{
		return this;
	}

	public virtual void BKLJJBPHOEK()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void HEMIDJPBKKL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public static void CIJLKGLNIPO()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("elite" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public static void PMGDBGECOEM()
	{
		if (GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			if (GuiElementSingle<WaitingDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("S" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void IDKBKFNPAPD()
	{
	}

	public virtual void HHEEDIHHCEA()
	{
	}

	public virtual void CMEMLNEOAFA()
	{
	}

	protected virtual void PNEKCEHBGPD()
	{
		base.BOEMHLPLOGA();
		if (LHDGJFHPJNM() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void INMFKHJDBIP()
	{
	}

	public virtual void JNGFIPHAINA()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	protected virtual void FMKLDIJPHIH()
	{
		base.IIFBKHDMIAD();
		if (BKIGLABDGCP() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = true;
		}
	}

	public virtual void DDHFFMIJMJG()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = true;
	}

	public static void DNNLAHACDCK()
	{
		if (GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			if (GuiElementSingle<WaitingDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log("DatabaseMessage - No long existing database message came from server!" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public static void KDLLKOJBGGO()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("HELMETS_CROWNSILVER" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void AGFDJGJALKD()
	{
	}

	public virtual void HJJOAJHBKCH()
	{
	}

	public virtual void OLIOADHMKKA()
	{
	}

	public static void HLAPENBALCJ()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("Buy_Army_Unit_Gold" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public static void FCCJJKBPNCH(string NDBAGOOMIDJ = "ID_JOININGSQUAD")
	{
		Debug.Log("MIN_FPS" + NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.NFNLBEGFLHC.text = Localization.Localize(NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
		if (!GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance, 1988f);
		}
	}

	public virtual void NGHAPNEFBED()
	{
	}

	public virtual void DFNABAFOPLE()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public static void PNEPDNHKIKD()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log("{0} {1}" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void LPEKMKPCIKK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void HEOMHIGCMOC()
	{
	}

	public virtual void OAMMJCEIFHA()
	{
	}

	protected virtual void EKPBOMOMMFB()
	{
		base.OGJGIMLMJBF();
		if (BJNBLINDAED() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void ADHKCLPIPGL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void PAKCFABJKAG()
	{
	}

	public virtual void JCGDALOBGHO()
	{
	}

	public GuiElement DPPOMEPDHEK()
	{
		return this;
	}

	protected virtual void OCBLKIFKJEG()
	{
		base.Update();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = true;
		}
	}

	public virtual void CJNNMMDIHDI()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void PGBBMFDKGJC()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	protected virtual void BLOBBBLIJPI()
	{
		base.BOEMHLPLOGA();
		if (AFOFDNJOJHG() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = true;
		}
	}

	public static void NDJPJBDKANE()
	{
		if (GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public GuiElement HDAEPEKEFCE()
	{
		return this;
	}

	public virtual void EFINNDNBJDN()
	{
	}

	public virtual void HAFLJGIHBAP()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = false;
	}

	public static void AJCILBFBNMK(string NDBAGOOMIDJ = "ID_JOININGSQUAD")
	{
		Debug.Log("ID_UPGRADED" + NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.NFNLBEGFLHC.text = Localization.Localize(NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
		if (!GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance, 464f);
		}
	}

	public virtual void DFMCKHMFNHO()
	{
	}

	protected virtual void HGGABJBEKDC()
	{
		base.IIFBKHDMIAD();
		if (LHDGJFHPJNM() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void OMKGJLKNCJG()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void GDAOBIKGIBH()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	protected virtual void IJHGOEMOMFK()
	{
		base.IIFBKHDMIAD();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void GCGPANMGOPN()
	{
	}

	public static void PEIFGGPNHMK()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log("clipSize" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public override void InitGUIValues()
	{
	}

	public static void FOKMAICBJAB()
	{
		if (GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			if (GuiElementSingle<WaitingDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("ShotFrequencyMin" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void OBIBHNFJKHD()
	{
	}

	protected override void Update()
	{
		base.Update();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void GFIFLFAKKEC()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void NECAFEIDDKK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void KNOKOJKOCEB()
	{
	}

	protected virtual void PMPDBJCPDHJ()
	{
		base.JMPDHKPOHEA();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	protected virtual void MGKCNLDGNEM()
	{
		base.BOEMHLPLOGA();
		if (BKIGLABDGCP() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void CEAHALCLDNE()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	protected virtual void CBOIHLDFKPI()
	{
		base.BOEMHLPLOGA();
		if (base.isFullyShowed && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = true;
		}
	}

	public virtual void LBHEIOEPJLJ()
	{
	}

	public static void ShowDialog(string NDBAGOOMIDJ = "ID_JOININGSQUAD")
	{
		Debug.Log("Show Waiting Dialog " + NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.NFNLBEGFLHC.text = Localization.Localize(NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
		if (!GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance);
		}
	}

	public virtual void KPHJFKCOIIF()
	{
	}

	public static void GFGNLDJNNAI()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.MHAIBHBGBOO())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log("#AccoutCheck# check gpgs but offline" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void IOLNONPHCMM()
	{
	}

	public static void CDLODKKNAEF()
	{
		if (GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			if (GuiElementSingle<WaitingDialog>.instance.AFOFDNJOJHG())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log("Count" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void GHHLNPHJJGM()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void MNMIMONMPCG()
	{
	}

	public static void PCBDDAMEPCJ(string NDBAGOOMIDJ = "ID_JOININGSQUAD")
	{
		Debug.Log("ID_NOTIFICATION_SILVERCRAFT" + NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.NFNLBEGFLHC.text = Localization.Localize(NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
		if (!GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance, 1464f);
		}
	}

	public virtual void PHIGFMNOHLM()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void CBPNEALKOMM()
	{
	}

	public virtual void LBIJJNEOELO()
	{
	}

	public static void Hide()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("Hide Waiting Dialog - will hide in a moment: " + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	protected virtual void CFLALBENGJN()
	{
		base.JMPDHKPOHEA();
		if (LHDGJFHPJNM() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void GBDAHEGKBDG()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void KNCNLMJPACC()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void OILPJONILBG()
	{
	}

	public virtual void GEABCFONNJF()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void MIIMAJBHBLL()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void JKPBJPFBAFJ()
	{
	}

	public GuiElement MBGEOLKGLGM()
	{
		return this;
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	public override void OnBack()
	{
	}

	public virtual void NHOEHNJICBO()
	{
	}

	protected virtual void ELJHCOHCAJI()
	{
		base.Update();
		if (AFOFDNJOJHG() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void GAGKEJAFBOH()
	{
	}

	public static void JCHCOHNECJD()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.BKIGLABDGCP())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
			}
			Debug.Log("ID_DETAILS" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void CMFFEECPAED()
	{
	}

	public virtual void NINGMLNMLLP()
	{
	}

	public virtual void MINEFKEBIHK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public static void NFFOFBDCHMF(string NDBAGOOMIDJ = "ID_JOININGSQUAD")
	{
		Debug.Log("MaintenanceMessage" + NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.NFNLBEGFLHC.text = Localization.Localize(NDBAGOOMIDJ);
		GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = true;
		if (!GuiElementSingle<WaitingDialog>.instance.NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance, 1708f);
		}
	}

	public virtual void KHDFKEINFCJ()
	{
	}

	public virtual void JMKDHCIKJMG()
	{
	}

	public override void InitControls()
	{
	}

	public virtual void CCIIBAIKMFK()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void ECOFKMAPFLN()
	{
	}

	public virtual void KPMLFMMINEP()
	{
	}

	public virtual void MMFBOMDHGPL()
	{
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	public static void JDPJKEJBLHN()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.LHDGJFHPJNM())
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB = false;
			}
			Debug.Log(" {0}\u00a0{1}" + GuiElementSingle<WaitingDialog>.instance.FNHMJEBIOJB);
		}
	}

	public virtual void PANHEDPIJHD()
	{
	}

	public GuiElement FDDDPGMAFHD()
	{
		return this;
	}

	public virtual void OIGFBFFNNHH()
	{
	}

	public virtual void CPAKIBKODJC()
	{
	}

	public virtual void MFJBACDAOLD()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	protected virtual void CJBJGDCNLOG()
	{
		base.JMPDHKPOHEA();
		if (AFOFDNJOJHG() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	protected virtual void BHIABNNGKFO()
	{
		base.OGJGIMLMJBF();
		if (MHAIBHBGBOO() && FNHMJEBIOJB)
		{
			HideDialog();
			FNHMJEBIOJB = false;
		}
	}

	public virtual void PEIILMKDGBK()
	{
	}
}
