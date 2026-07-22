using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomizationsTutorial : GuiElementSingle<CustomizationsTutorial>, PAIIOKBBHBC
{
	[Header("Core")]
	[FormerlySerializedAs("MOLMKDOBAOI")]
	public UILabel GJJCOAGIMHJ;

	[FormerlySerializedAs("BIOFHPALEMO")]
	public GameObject CCFFNAKFPPE;

	private bool NGGHECBDGMH;

	private float ONJHNBMMPMI;

	private void BMIKFLAPCOK(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
	}

	public GuiElement AHDGOCGHIHJ()
	{
		return this;
	}

	private void JLNHAILBDKI(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	private void HCABJKFHJAJ(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = false;
	}

	public virtual void EEFCNPGAODO()
	{
		JLNHAILBDKI(CCFFNAKFPPE.gameObject);
	}

	public virtual void KJBGADNDLGI()
	{
		JLNHAILBDKI(CCFFNAKFPPE.gameObject);
	}

	protected virtual void JNDLGOABMKC()
	{
		base.IIFBKHDMIAD();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 1815f)
		{
			NGGHECBDGMH = false;
			ONJHNBMMPMI = 294f;
			HideDialog();
		}
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	public virtual void GDEDNFKNNFH(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		switch (Localization.instance.currentLanguage)
		{
		case "specialOffers":
		case "damage":
		case "#AccoutCheck# gpgs account found during account loading!!! - TODO!":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1720f, 1158f, 1286f);
			break;
		}
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	public virtual void EEFEFOHKIBF()
	{
		base.OIMKKAHOEKO();
		Singleton<AtlasPreparer>.instance.BLCCADCEEED();
	}

	public virtual void AEADDDNBLEE()
	{
		PKFNOHPOLCN(CCFFNAKFPPE.gameObject);
	}

	public GuiElement NEDDABHBCLE()
	{
		return this;
	}

	public virtual void PNLGFNBEOLG()
	{
		NGGHECBDGMH = false;
		ONJHNBMMPMI = 245f;
		Singleton<BeanstalkServerManager>.instance.EOKBKABOIMI();
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPJEEJIIHOJ));
		switch (Localization.instance.currentLanguage)
		{
		case "ID_CONFIRM_SERVERERROR":
		case "Os":
		case "S":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1530f, 1604f, 1725f);
			break;
		}
	}

	private void PKFNOHPOLCN(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	public virtual void IEHJMLIMNEP()
	{
		NGGHECBDGMH = false;
		ONJHNBMMPMI = 508f;
		Singleton<BeanstalkServerManager>.instance.EIOAPGKFBBP();
	}

	public virtual void HGKNCKIKBDC()
	{
		NGGHECBDGMH = true;
		ONJHNBMMPMI = 292f;
		Singleton<BeanstalkServerManager>.instance.EIOAPGKFBBP();
	}

	public virtual void CHAGJLIDGAH()
	{
		base.DoAfterHide();
		Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
	}

	public virtual void DNFPEBEDLIG()
	{
		NGGHECBDGMH = false;
		ONJHNBMMPMI = 370f;
		Singleton<BeanstalkServerManager>.instance.EIOAPGKFBBP();
	}

	public virtual void FANFGPFNGCC()
	{
		base.OIMKKAHOEKO();
		Singleton<AtlasPreparer>.instance.PFFNDANCGCB();
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		switch (Localization.instance.currentLanguage)
		{
		case "fr":
		case "de":
		case "pt":
			GJJCOAGIMHJ.transform.localScale = new Vector3(40f, 40f, 1f);
			break;
		}
	}

	public virtual void NBJKGKHHGCJ(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
	}

	public virtual void KILEBJAGCND(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
	}

	public virtual void KMJBAAPCEBD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCABJKFHJAJ));
		switch (Localization.instance.currentLanguage)
		{
		case "cardPack":
		case "LapsedPlayerRewardId":
		case "shield_shot":
			GJJCOAGIMHJ.transform.localScale = new Vector3(674f, 301f, 1294f);
			break;
		}
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public virtual void POFPIJKJFBP()
	{
		base.OIMKKAHOEKO();
		Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCABJKFHJAJ));
		switch (Localization.instance.currentLanguage)
		{
		case "Message":
		case "RegisterCurrency()":
		case "testingideventtierreward":
			GJJCOAGIMHJ.transform.localScale = new Vector3(519f, 494f, 462f);
			break;
		}
	}

	public override void InitGUIValues()
	{
		NGGHECBDGMH = false;
		ONJHNBMMPMI = 0f;
		Singleton<BeanstalkServerManager>.instance.EOKBKABOIMI();
	}

	private void LPJEEJIIHOJ(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	public virtual void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKFNOHPOLCN));
		switch (Localization.instance.currentLanguage)
		{
		case "#Mission# Waves finished":
		case "Country":
		case "squad":
			GJJCOAGIMHJ.transform.localScale = new Vector3(861f, 240f, 1551f);
			break;
		}
	}

	public virtual void PFCKKOBABEL()
	{
		LKIKKIEMMJI(CCFFNAKFPPE.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void PAKCFABJKAG()
	{
		NGGHECBDGMH = false;
		ONJHNBMMPMI = 1828f;
		Singleton<BeanstalkServerManager>.instance.EIOAPGKFBBP();
	}

	public virtual void DCNGEGFNAGG()
	{
		LPJEEJIIHOJ(CCFFNAKFPPE.gameObject);
	}

	public virtual void ICNGBKKANLB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPJEEJIIHOJ));
		switch (Localization.instance.currentLanguage)
		{
		case "Main_Menu_Offers_Bar":
		case "Message":
		case "ID_CONTINUE":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1915f, 1316f, 1352f);
			break;
		}
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMIKFLAPCOK));
		switch (Localization.instance.currentLanguage)
		{
		case "ID_GUI_LEAGUE":
		case "menu-cards-goldpack":
		case "game-elite-buff1":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1013f, 1854f, 253f);
			break;
		}
	}

	public virtual void IAKDHKOGFCM(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	public virtual void PANHEDPIJHD()
	{
		HCABJKFHJAJ(CCFFNAKFPPE.gameObject);
	}

	private void NLBFNMJPLDH(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = false;
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	public virtual void BBIHNICEDGE()
	{
		base.OIMKKAHOEKO();
		Singleton<AtlasPreparer>.instance.ACOLPEPNNMA();
	}

	public override void OnBack()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCABJKFHJAJ));
		switch (Localization.instance.currentLanguage)
		{
		case "Player_Avoided_Grenade_On_First_Try":
		case "Awake called: ":
		case " AND ":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1344f, 1909f, 301f);
			break;
		}
	}

	public virtual void OOBJHJLMEED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMIKFLAPCOK));
		switch (Localization.instance.currentLanguage)
		{
		case "QUIT":
		case "{0} Rookie {1}":
		case "ID_UPGRADE":
			GJJCOAGIMHJ.transform.localScale = new Vector3(112f, 255f, 30f);
			break;
		}
	}

	private void LKIKKIEMMJI(GameObject KHAHPAKDIKE)
	{
		NGGHECBDGMH = true;
	}

	protected virtual void JAFBNNAACCL()
	{
		base.OGJGIMLMJBF();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 1475f)
		{
			NGGHECBDGMH = false;
			ONJHNBMMPMI = 136f;
			HideDialog();
		}
	}

	public virtual void NEOLLOMIKPK()
	{
		NGGHECBDGMH = true;
		ONJHNBMMPMI = 381f;
		Singleton<BeanstalkServerManager>.instance.EIOAPGKFBBP();
	}

	public virtual void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		switch (Localization.instance.currentLanguage)
		{
		case "'Day'0":
		case "com/google/android/gms/games/Games":
		case "FuseRewardedOptionKey_PreRollYesButtonText":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1581f, 1892f, 1600f);
			break;
		}
	}

	protected virtual void IAPBHPLNNNO()
	{
		base.Update();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 1567f)
		{
			NGGHECBDGMH = true;
			ONJHNBMMPMI = 33f;
			HideDialog();
		}
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.IIFBKHDMIAD();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 1128f)
		{
			NGGHECBDGMH = false;
			ONJHNBMMPMI = 835f;
			HideDialog();
		}
	}

	public virtual void FKMBLEKFCGM(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
	}

	public virtual void OINEJNKJNEH(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.FEKCJMKEIPM());
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		switch (Localization.instance.currentLanguage)
		{
		case "StepId":
		case "left":
		case "AtlasPreparer - CLEARING ATLAS ":
			GJJCOAGIMHJ.transform.localScale = new Vector3(1245f, 142f, 416f);
			break;
		}
	}

	public virtual void GLOINJNJBCP()
	{
		base.DoAfterHide();
		Singleton<AtlasPreparer>.instance.PFFNDANCGCB();
	}

	public virtual void MPGNNJMDFKB(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
	}

	protected virtual void KNIAAECLFFK()
	{
		base.Update();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 418f)
		{
			NGGHECBDGMH = false;
			ONJHNBMMPMI = 1256f;
			HideDialog();
		}
	}

	public virtual void ACLOLICAKGL()
	{
		NGGHECBDGMH = true;
		ONJHNBMMPMI = 208f;
		Singleton<BeanstalkServerManager>.instance.EOKBKABOIMI();
	}

	public virtual void CKPAAPIFKGK(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKFNOHPOLCN));
		switch (Localization.instance.currentLanguage)
		{
		case "ID_SKILLSHOTHINT_VEHICLEDESTROYED":
		case "ID_READYTIME":
		case "Gold":
			GJJCOAGIMHJ.transform.localScale = new Vector3(373f, 603f, 551f);
			break;
		}
	}

	protected virtual void CMELHMEBEFI()
	{
		base.Update();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 591f)
		{
			NGGHECBDGMH = true;
			ONJHNBMMPMI = 633f;
			HideDialog();
		}
	}

	protected override void Update()
	{
		base.Update();
		ONJHNBMMPMI += Time.unscaledDeltaTime;
		if (NGGHECBDGMH && ONJHNBMMPMI > 1.5f)
		{
			NGGHECBDGMH = false;
			ONJHNBMMPMI = 0f;
			HideDialog();
		}
	}

	public virtual void NIHENNDPJFB()
	{
		PKFNOHPOLCN(CCFFNAKFPPE.gameObject);
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	public virtual void BCMCGJGLFPL()
	{
		base.DoAfterHide();
		Singleton<AtlasPreparer>.instance.AHMHELBEJND();
	}

	public GuiElement PDOCMLPCMMO()
	{
		return this;
	}
}
