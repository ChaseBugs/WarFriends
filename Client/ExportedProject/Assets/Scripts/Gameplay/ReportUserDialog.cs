using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ReportUserDialog : GuiElementSingle<ReportUserDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("KINFCHEICEC")]
	[Header("Core")]
	public GameObject COBFKLAHJBC;

	[FormerlySerializedAs("MMEGODHLFKO")]
	public ChatAbusePopUpList GJHAIDKBCEA;

	[FormerlySerializedAs("NJPBAJCIHHE")]
	public GameObject APCMHDINKEI;

	[Header("-Submit Button")]
	[FormerlySerializedAs("NHODOOHCPIB")]
	public GameObject GHBDJCJDEIK;

	[FormerlySerializedAs("OMNCAJKAGLK")]
	public BoxCollider AOOMNFPKFKK;

	[FormerlySerializedAs("OCFPIIHDIAA")]
	public UISprite BCEICONFFFP;

	public const string FKPPPBHNOJC = "ID_REPORTUSER_ITEM0";

	public const string HGHCGBDNHKK = "ID_REPORTUSER_ITEM1";

	public const string PKHMFNFPIDD = "ID_REPORTUSER_ITEM2";

	private string GCNLDDCMBEO;

	private HIJBBEBAJCO OLOLINICHII;

	private Dictionary<string, HIJBBEBAJCO> EOPOCHJMJDH;

	private void CICOILEBDDM(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(1410f) : Color.white);
	}

	private void BCFFLIJPEBC(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(112f) : Color.white);
	}

	public static void ShowBotReportDialog(int NIAENIMGFEA)
	{
		ReportUserDialog reportUserDialog = GuiElementSingle<ReportUserDialog>.instance;
		reportUserDialog.GCNLDDCMBEO = NIAENIMGFEA.ToString("'bot-'0");
		Singleton<GuiManager>.instance.ShowDialog(reportUserDialog);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	public virtual void BNEPKGCDIFH()
	{
		GJHAIDKBCEA.LJFFDAHEOFM();
		BCFFLIJPEBC(GJNGLPOBFJI: true);
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void PICCJCKNCCF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void HNINPEMJHIM(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(1507f) : Color.white);
	}

	public virtual void DKCOOAKKFKD()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.ANCFPKKIAPF.onePanelDisabled = false;
	}

	private void DNAOBOAJJHN(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (base.isFullyShowed)
		{
			JKOIDJICNFE(GJNGLPOBFJI: true);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OEKMDCHLDHD();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = (HIJBBEBAJCO)55;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	private void FJLMMINDMDF(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (base.isFullyShowed)
		{
			JKOIDJICNFE(GJNGLPOBFJI: true);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				LLEBDFOLOPF();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = HIJBBEBAJCO.Other;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public virtual void MHIFDHGPDCK()
	{
		GJHAIDKBCEA.PDKLGKEPAOB();
		HNINPEMJHIM(GJNGLPOBFJI: false);
	}

	public override void AIKPJGLHLLO()
	{
		HCOMBPLJLNL(APCMHDINKEI.gameObject);
	}

	private void EIGCNEHJPBN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int num = LevelManager.instance.currentLevel.NPOEMAMPNEP();
			int num2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BACGCIBHBOO();
			int num3 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO();
			float num4 = Singleton<MatchManager>.instance.DKFPOEPNFLJ();
			GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.JDNAAJAPHMD();
			object[] array = new object[2];
			array[0] = OLOLINICHII;
			array[1] = GCNLDDCMBEO;
			array[5] = num3;
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			array[5] = num;
			array[8] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
			array[4] = MEJMLNDFDBP.GGDHFCCNAND(num4);
			Debug.Log(string.Format("menu-arena-ticket", array));
			Singleton<BeanstalkServerManager>.instance.BOHDKCDECMN(GCNLDDCMBEO, (int)OLOLINICHII, armyPowerX, num, num3, num2, num4);
			HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JJIDIKGPDAP));
		GJHAIDKBCEA.GJHAIDKBCEA.SetDefaultValue();
		GJHAIDKBCEA.OnSelect += FJLMMINDMDF;
		LLEBDFOLOPF();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.ANCFPKKIAPF.onePanelDisabled = false;
	}

	public override void InitGUIValues()
	{
		GJHAIDKBCEA.ResetToDefault();
		JKOIDJICNFE(GJNGLPOBFJI: false);
	}

	private void ECKJDKMDJPP(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (base.isFullyShowed)
		{
			CICOILEBDDM(GJNGLPOBFJI: false);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				CGMDIHOMIBC();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = (HIJBBEBAJCO)34;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public static void NAIEJNGBEAF(string EJBEDLHIKDG)
	{
		ReportUserDialog reportUserDialog = GuiElementSingle<ReportUserDialog>.instance;
		reportUserDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		Singleton<GuiManager>.instance.ShowDialog(reportUserDialog, 1387f);
	}

	private void HCOMBPLJLNL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void CGMDIHOMIBC()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, HIJBBEBAJCO>();
		}
		if (EOPOCHJMJDH.Count > 0)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("()Z", HIJBBEBAJCO.SuspiciousBehaviourDuringMatch);
		EOPOCHJMJDH.Add("ID_ARENASHORTCUTPHASESTART", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("ID_TURRETBUILDTIME", (HIJBBEBAJCO)(-7));
	}

	private void JJIDIKGPDAP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int displayNumber = LevelManager.instance.currentLevel.displayNumber;
			int num = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IMOJCFKJKMN;
			int num2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL;
			float matchTime = Singleton<MatchManager>.instance.matchTime;
			GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.DisableReportButton();
			Debug.Log($"Submited: \"{OLOLINICHII}\" for player: \"{GCNLDDCMBEO}\" rank:{num2} AP:{MEJMLNDFDBP.GMIPFLIEOHD(num)} and my rank:{displayNumber} AP:{MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX)}. Match duration: {MEJMLNDFDBP.GGDHFCCNAND(matchTime)}");
			Singleton<BeanstalkServerManager>.instance.BOHDKCDECMN(GCNLDDCMBEO, (int)OLOLINICHII, armyPowerX, displayNumber, num2, num, matchTime);
			HideDialog();
		}
	}

	public virtual void FCPGJBMGBLJ()
	{
		HCOMBPLJLNL(APCMHDINKEI.gameObject);
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EIGCNEHJPBN));
		GJHAIDKBCEA.GJHAIDKBCEA.HGJOJDPJEAB();
		GJHAIDKBCEA.OMJABMDGBPB(ECKJDKMDJPP);
		FOAJNFBAFPL();
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EIGCNEHJPBN));
		GJHAIDKBCEA.GJHAIDKBCEA.MFEDHFAHDAN();
		GJHAIDKBCEA.OMJABMDGBPB(FJLMMINDMDF);
		CGMDIHOMIBC();
	}

	private void JKOIDJICNFE(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(0.5f) : Color.white);
	}

	public static void ShowReportDialog(string EJBEDLHIKDG)
	{
		ReportUserDialog reportUserDialog = GuiElementSingle<ReportUserDialog>.instance;
		reportUserDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		Singleton<GuiManager>.instance.ShowDialog(reportUserDialog);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EIGCNEHJPBN));
		GJHAIDKBCEA.GJHAIDKBCEA.GHPJIGNGDFN();
		GJHAIDKBCEA.KCDOLGGNNCM(ECKJDKMDJPP);
		OEKMDCHLDHD();
	}

	private void LLEBDFOLOPF()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, HIJBBEBAJCO>();
		}
		if (EOPOCHJMJDH.Count > 0)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("ID_REPORTUSER_ITEM0", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("ID_REPORTUSER_ITEM1", HIJBBEBAJCO.SuspiciousBehaviourDuringMatch);
		EOPOCHJMJDH.Add("ID_REPORTUSER_ITEM2", HIJBBEBAJCO.Other);
	}

	private void OEKMDCHLDHD()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, HIJBBEBAJCO>();
		}
		if (EOPOCHJMJDH.Count > 1)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("ID_XTICKETS", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("Cards_Owned", (HIJBBEBAJCO)7);
	}

	private void FOAJNFBAFPL()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, HIJBBEBAJCO>();
		}
		if (EOPOCHJMJDH.Count > 0)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("[-]", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("country-south-korea", HIJBBEBAJCO.InstantKill);
		EOPOCHJMJDH.Add("OK", (HIJBBEBAJCO)6);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.ANCFPKKIAPF.onePanelDisabled = true;
	}

	public virtual void BLFLDJNPDFH()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<EndScreen>.instance.KGGJOOAFDIF.ANCFPKKIAPF.onePanelDisabled = true;
	}
}
