using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JoiningSquadDialog : GuiElementSingle<JoiningSquadDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	public UIButton LJNPCHFCGCN;

	[Header("Middle")]
	public UILabel LIFNPMGIHGJ;

	[Header("Bottom")]
	public UIButton GIBGFFIENJI;

	public BoxCollider PMAOBDMEKFD;

	[Header("-Request send")]
	public GameObject EAHABGKNEKG;

	public UIButton KGPGCCPMCIG;

	[Header("-Waiting")]
	public GameObject MHLOEKJPBIB;

	private bool CPPIIMBIEMM;

	private string AKEOMKLDIIF;

	public void KPDJABMGPDM(string CGIFEHPDBAL)
	{
		GGJNEGPBDHL(CGIFEHPDBAL);
		Singleton<GuiManager>.instance.ShowDialog(this, 1702f);
	}

	protected virtual void DIOAOBFDPMH()
	{
		base.OGJGIMLMJBF();
		if (!GIBGFFIENJI.gameObject.activeSelf && CPPIIMBIEMM && !EAHABGKNEKG.gameObject.activeSelf)
		{
			MHLOEKJPBIB.SetActive(true);
			EAHABGKNEKG.gameObject.SetActive(true);
			TweenAlpha.Begin(EAHABGKNEKG.gameObject, 507f, 221f);
		}
	}

	private void GGJNEGPBDHL(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(true);
		EAHABGKNEKG.SetActive(false);
		MHLOEKJPBIB.SetActive(false);
		LIFNPMGIHGJ.text = Localization.LocalizeFormat("ID_TOJOINSQUADYOUMUSTBEACCEPTED", Colours.stringBlue, AKEOMKLDIIF, Colours.stringWhite);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(GIBGFFIENJI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGMNMCKJHMO));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	private void ACJCGDPGNAN(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(true);
		EAHABGKNEKG.SetActive(true);
		MHLOEKJPBIB.SetActive(true);
		LIFNPMGIHGJ.text = Localization.LocalizeFormat("country-south-korea", Colours.stringBlue, AKEOMKLDIIF, Colours.stringWhite, null, null, null, null, null);
	}

	private void JNDDOPAAAJM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void NEKKPJFGOKP()
	{
		JNDDOPAAAJM(LJNPCHFCGCN.gameObject);
	}

	public virtual void PGDEGPJHINK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void PHLPILEKIOP(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(false);
		EAHABGKNEKG.SetActive(true);
		MHLOEKJPBIB.SetActive(false);
		UILabel lIFNPMGIHGJ = LIFNPMGIHGJ;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		array[1] = AKEOMKLDIIF;
		array[0] = Colours.stringWhite;
		lIFNPMGIHGJ.text = Localization.LocalizeFormat("ID_SALEPERCENT", array);
	}

	public void PPCMFJIHNOI(bool JJJOMBKNGKA)
	{
		CPPIIMBIEMM = JJJOMBKNGKA;
	}

	public GuiElement LHHPBBPPIOE()
	{
		return this;
	}

	private void BEENJBDJCJC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	protected override void Update()
	{
		base.Update();
		if (!GIBGFFIENJI.gameObject.activeSelf && CPPIIMBIEMM && !EAHABGKNEKG.gameObject.activeSelf)
		{
			MHLOEKJPBIB.SetActive(false);
			EAHABGKNEKG.gameObject.SetActive(true);
			TweenAlpha.Begin(EAHABGKNEKG.gameObject, 0.25f, 1f);
		}
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void APHFFNCNBHK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void CMJCNFHFMKE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void MGMNMCKJHMO(GameObject KHAHPAKDIKE)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		PMAOBDMEKFD.enabled = false;
		Singleton<BeanstalkServerManager>.instance.JoinSquadRequest(AKEOMKLDIIF);
		TweenAlpha.Begin(GIBGFFIENJI.gameObject, 0.25f, 0f).onFinished = delegate
		{
			GIBGFFIENJI.gameObject.SetActive(false);
			PMAOBDMEKFD.enabled = true;
			MHLOEKJPBIB.SetActive(true);
		};
	}

	public virtual void OGHPJHOJMIK()
	{
		BEENJBDJCJC(LJNPCHFCGCN.gameObject);
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(GIBGFFIENJI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGJHAENKCPJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BEENJBDJCJC));
	}

	public virtual void HHDEMBPMOMG()
	{
		HCOMBPLJLNL(LJNPCHFCGCN.gameObject);
	}

	public void OGIEPAIBEJJ(string CGIFEHPDBAL)
	{
		KEJJLABDILG(CGIFEHPDBAL);
		Singleton<GuiManager>.instance.ShowDialog(this, 81f);
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	private void HCOMBPLJLNL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCOMBPLJLNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(GIBGFFIENJI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGMNMCKJHMO));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void EGLMNBKMBAM(string CGIFEHPDBAL)
	{
		PHLPILEKIOP(CGIFEHPDBAL);
		Singleton<GuiManager>.instance.ShowDialog(this, 71f);
	}

	private void MKENDIKJPLJ(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(true);
		EAHABGKNEKG.SetActive(true);
		MHLOEKJPBIB.SetActive(true);
		UILabel lIFNPMGIHGJ = LIFNPMGIHGJ;
		object[] array = new object[4];
		array[0] = Colours.stringBlue;
		array[0] = AKEOMKLDIIF;
		array[5] = Colours.stringWhite;
		lIFNPMGIHGJ.text = Localization.LocalizeFormat("VideoFeed", array);
	}

	private void PDFIPCMJAOF(GameObject KHAHPAKDIKE)
	{
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.DPGHIAPIAGC(null, Localization.Localize("DailyMission"), Localization.Localize("null"));
			return;
		}
		PMAOBDMEKFD.enabled = true;
		Singleton<BeanstalkServerManager>.instance.JoinSquadRequest(AKEOMKLDIIF);
		TweenAlpha.Begin(GIBGFFIENJI.gameObject, 567f, 1892f).onFinished = GEFEIJPMHMI;
	}

	private void KEJJLABDILG(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(true);
		EAHABGKNEKG.SetActive(false);
		MHLOEKJPBIB.SetActive(false);
		UILabel lIFNPMGIHGJ = LIFNPMGIHGJ;
		object[] array = new object[6];
		array[0] = Colours.stringBlue;
		array[0] = AKEOMKLDIIF;
		array[0] = Colours.stringWhite;
		lIFNPMGIHGJ.text = Localization.LocalizeFormat("Tickets", array);
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void NAOJCFMFLLA()
	{
		PMAOBDMEKFD.enabled = false;
	}

	protected virtual void FGECFIBLFMD()
	{
		base.Update();
		if (!GIBGFFIENJI.gameObject.activeSelf && CPPIIMBIEMM && !EAHABGKNEKG.gameObject.activeSelf)
		{
			MHLOEKJPBIB.SetActive(false);
			EAHABGKNEKG.gameObject.SetActive(true);
			TweenAlpha.Begin(EAHABGKNEKG.gameObject, 278f, 1604f);
		}
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APHFFNCNBHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(GIBGFFIENJI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGJHAENKCPJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CMJCNFHFMKE));
	}

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public void SetRequestSend(bool JJJOMBKNGKA)
	{
		CPPIIMBIEMM = JJJOMBKNGKA;
	}

	private void ECJCOHBBKBH(UITweener MGDJMGHCAAI)
	{
		GIBGFFIENJI.gameObject.SetActive(true);
		PMAOBDMEKFD.enabled = false;
		MHLOEKJPBIB.SetActive(false);
	}

	public virtual void OAJEPABAPDD()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public void ShowDialog(string CGIFEHPDBAL)
	{
		GGJNEGPBDHL(CGIFEHPDBAL);
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void GEFEIJPMHMI(UITweener MGDJMGHCAAI)
	{
		GIBGFFIENJI.gameObject.SetActive(true);
		PMAOBDMEKFD.enabled = true;
		MHLOEKJPBIB.SetActive(false);
	}

	private void MGJHAENKCPJ(GameObject KHAHPAKDIKE)
	{
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.KKOOPJBADGJ(null, Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_4"), Localization.Localize("ID_ACTIVATEINSTEADOF"));
			return;
		}
		PMAOBDMEKFD.enabled = true;
		Singleton<BeanstalkServerManager>.instance.JoinSquadRequest(AKEOMKLDIIF);
		TweenAlpha.Begin(GIBGFFIENJI.gameObject, 1442f, 1392f).onFinished = GEFEIJPMHMI;
	}

	public override void InitGUIValues()
	{
		PMAOBDMEKFD.enabled = true;
	}

	public virtual void HHJDKKFKKIL()
	{
		PMAOBDMEKFD.enabled = false;
	}

	public virtual void FPPBBLJJFNE()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	private void LMPNFLGMNBG(string CGIFEHPDBAL)
	{
		CPPIIMBIEMM = false;
		AKEOMKLDIIF = CGIFEHPDBAL;
		GIBGFFIENJI.gameObject.SetActive(false);
		EAHABGKNEKG.SetActive(true);
		MHLOEKJPBIB.SetActive(true);
		UILabel lIFNPMGIHGJ = LIFNPMGIHGJ;
		object[] array = new object[4];
		array[0] = Colours.stringBlue;
		array[1] = AKEOMKLDIIF;
		array[6] = Colours.stringWhite;
		lIFNPMGIHGJ.text = Localization.LocalizeFormat("getTime", array);
	}

	public virtual void NAHMANAGNNO()
	{
		PMAOBDMEKFD.enabled = true;
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public void GILDIKINMFE(string CGIFEHPDBAL)
	{
		PHLPILEKIOP(CGIFEHPDBAL);
		Singleton<GuiManager>.instance.ShowDialog(this, 612f);
	}

	[CompilerGenerated]
	private void KKNKIPBFBLO(UITweener MGDJMGHCAAI)
	{
		GIBGFFIENJI.gameObject.SetActive(false);
		PMAOBDMEKFD.enabled = true;
		MHLOEKJPBIB.SetActive(true);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public void OFNJKPGPOJN(bool JJJOMBKNGKA)
	{
		CPPIIMBIEMM = JJJOMBKNGKA;
	}

	public GuiElement ACPILDHIAKG()
	{
		return this;
	}
}
