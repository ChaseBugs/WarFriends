using System;
using UnityEngine;

public class NewVersionDialog : GuiElementSingle<NewVersionDialog>, PAIIOKBBHBC
{
	[Header("Button")]
	public UIButton NMHOCIJOIIM;

	public UIButton DENCNPBFNPD;

	public virtual void APMBOAFCMHI()
	{
		base.DoBeforeShowUp();
		DialogBackground.GAFFKDOELMI().ShowBackground(DCIKANJJFIJ);
	}

	private void KEKAELKLOOA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.JNMJGFMEGHF());
			IGGCOBAPAMM();
		}
	}

	public GuiElement BMKBFOPGFDA()
	{
		return this;
	}

	private void ONDFNJOLDPF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			MHGFKPPDHEA();
		}
	}

	private void ENOPIECCFEA()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	public virtual void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DBCOJOGGLAI));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEDBINLHGOL));
	}

	public override void OIEPFDKMCNC()
	{
	}

	public virtual void LPHGNGHAGNE()
	{
		base.DoBeforeShowUp();
		DialogBackground.JAEGFKLEEIM().JIJIKPCMEBD(DCIKANJJFIJ);
	}

	public virtual void MKPCIDNPCME()
	{
		base.NEEAKMELPBJ();
		DialogBackground.IBKPDGILFDH().HELLIJPLION(HECFOEMLJCD);
	}

	private void CEGDBBHIOMO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Application.OpenURL(GameVariables.MLANOJFJPNL());
			CGNDJLICOEI();
		}
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HDLHMOHFJKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCMFMADKPIC));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPOGNGHHGFL));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEDBINLHGOL));
	}

	private void JCFFCJHIABG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Application.OpenURL(GameVariables.JNMJGFMEGHF());
			CGNDJLICOEI();
		}
	}

	public virtual void PGEODBJFHFC()
	{
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DBCOJOGGLAI));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCMFMADKPIC));
	}

	private void CGNDJLICOEI()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	private void JHCHBILHLFE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.MLANOJFJPNL());
			ELOEINJOHEH();
		}
	}

	public virtual void MDHOJINHADJ()
	{
		base.DoBeforeShowUp();
		DialogBackground.PJDMNGIAPBE().JAPDCHEOFPH(DCIKANJJFIJ);
	}

	private void AIGEEMKOKLH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			BIPOMBDOKPK();
		}
	}

	private void CMPFNOCEBBA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			IGGCOBAPAMM();
		}
	}

	public virtual void FJLJDLBCAAA()
	{
		base.JNBMCODJHBJ();
		DialogBackground.JAEGFKLEEIM().MAPJAMBHFAM(HECFOEMLJCD);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		DialogBackground.instance.ShowBackground(DCIKANJJFIJ);
	}

	public virtual void NEECLAOCOKD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPOGNGHHGFL));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEDBINLHGOL));
	}

	private void FEDBINLHGOL(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Application.OpenURL(GameVariables.JFEILIFIODM());
			BIPOMBDOKPK();
		}
	}

	private void MHGFKPPDHEA()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	public virtual void BGOHFEBKENN()
	{
		base.FKCKIFKLBAP();
		DialogBackground.GAFFKDOELMI().FHLCKAGMMFE(HECFOEMLJCD);
	}

	private void HKFNHNHBEFD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Application.OpenURL(GameVariables.MLANOJFJPNL());
			HACJOEEPCFP();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		DialogBackground.instance.HideBackground(HECFOEMLJCD);
	}

	public virtual void GNJDDFLJMAK()
	{
		base.MOOACPIOELI();
		DialogBackground.AMLFDHLNOFL().BLIHLKLBNCM(HECFOEMLJCD);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCHDKPCKEAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KAHIEJGIOCA));
	}

	private void FFEFFPEICPM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			MHGFKPPDHEA();
		}
	}

	public virtual void KKIOMAIPFLI()
	{
		base.DoBeforeShowUp();
		DialogBackground.AMLFDHLNOFL().ELECGBPEKNG(DCIKANJJFIJ);
	}

	private void PLLPHPNMCKA()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	private void IGGCOBAPAMM()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	private void IDHJNGHGMMA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			COGIPFGOLCI();
		}
	}

	public virtual void BGELLEOANEI()
	{
	}

	private void DBCOJOGGLAI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			CGNDJLICOEI();
		}
	}

	private void KCHDKPCKEAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.JNMJGFMEGHF());
			IGGCOBAPAMM();
		}
	}

	public virtual void PJENKEKOCAE()
	{
	}

	public virtual void OGIMMHFONPP()
	{
		base.DoBeforeShowUp();
		DialogBackground.KJNIJCBJJDE().ELECGBPEKNG(DCIKANJJFIJ);
	}

	private void BLMNOJBJALD(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.HHPOMIKJKAA());
			ENOPIECCFEA();
		}
	}

	private void BIPOMBDOKPK()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	public virtual void KPMLFMMINEP()
	{
	}

	public virtual void PAKCFABJKAG()
	{
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HDLHMOHFJKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIGEEMKOKLH));
	}

	private void BHEMDICDMPH(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Application.OpenURL(GameVariables.JNMJGFMEGHF());
			HACJOEEPCFP();
		}
	}

	private void AFPEHLGPHGD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			HACJOEEPCFP();
		}
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public override void InitGUIValues()
	{
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CEGDBBHIOMO));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EIPIAEHNJDE));
	}

	public virtual void DOANAOOEAKD()
	{
	}

	public virtual void GEGDLJIKIFE()
	{
		base.DoBeforeShowUp();
		DialogBackground.CFKGEENJOAM().JAPDCHEOFPH(DCIKANJJFIJ);
	}

	private void AADKIOIDNDP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.JNMJGFMEGHF());
			ELOEINJOHEH();
		}
	}

	private void BNHBHFBMLLG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			ENOPIECCFEA();
		}
	}

	private void MJCJMCJGALP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			MHGFKPPDHEA();
		}
	}

	public virtual void NFNMLPPDPAP()
	{
	}

	private void CPOGNGHHGFL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			IGGCOBAPAMM();
		}
	}

	private void ELOEINJOHEH()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	public GuiElement CPONDDGFBIH()
	{
		return this;
	}

	public virtual void ACLOLICAKGL()
	{
	}

	public virtual void HAFLJGIHBAP()
	{
		base.DoBeforeHide();
		DialogBackground.KJNIJCBJJDE().KONGBHICOGN(HECFOEMLJCD);
	}

	public virtual void NBMAFELJLCI()
	{
		base.MOOACPIOELI();
		DialogBackground.instance.DMPHJEKKCBH(HECFOEMLJCD);
	}

	public virtual void NHOEHNJICBO()
	{
	}

	public override void OnBack()
	{
	}

	private void JFLDBCHODKI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			IGGCOBAPAMM();
		}
	}

	public virtual void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AADKIOIDNDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEDBINLHGOL));
	}

	private void EIPIAEHNJDE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			MHGFKPPDHEA();
		}
	}

	public GuiElement KKBDMDCLDEN()
	{
		return this;
	}

	public virtual void EGNPMLEJLMJ()
	{
	}

	private void JCFFNPHBNIF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			ENOPIECCFEA();
		}
	}

	private void HJIJPIFKPHD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			PLLPHPNMCKA();
		}
	}

	private void EMOLNOOCLCJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			MHGFKPPDHEA();
		}
	}

	private void COGIPFGOLCI()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	public virtual void KFLBEIPPMBF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CMPFNOCEBBA));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MJCJMCJGALP));
	}

	public virtual void BPPNPHGOBEA()
	{
	}

	private void HBLPMHABHEC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			PLLPHPNMCKA();
		}
	}

	public virtual void DOPDLKMCFMA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCHDKPCKEAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EMOLNOOCLCJ));
	}

	public virtual void AELLCNJBOFL()
	{
		base.FKCKIFKLBAP();
		DialogBackground.CFKGEENJOAM().FHLCKAGMMFE(HECFOEMLJCD);
	}

	private void MNDEFOOPMLH(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			IGGCOBAPAMM();
		}
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	public virtual void HAHKNAIIIPC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NMHOCIJOIIM.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HKFNHNHBEFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(DENCNPBFNPD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JFLDBCHODKI));
	}

	private void HDLHMOHFJKI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			BIPOMBDOKPK();
		}
	}

	private void HACJOEEPCFP()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}

	private void FPPCHADGILJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			ELOEINJOHEH();
		}
	}

	public virtual void BFFHGHMJOGP()
	{
	}

	public virtual void CGIFPCLNPBO()
	{
		base.FKCKIFKLBAP();
		DialogBackground.ONEAEHMCMOI().AAHOCODLJBJ(HECFOEMLJCD);
	}

	public virtual void PLMOAGCCJEB()
	{
	}

	private void KAHIEJGIOCA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			COGIPFGOLCI();
		}
	}

	private void GCMFMADKPIC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			ENOPIECCFEA();
		}
	}

	public virtual void KHMCAPGAEOB()
	{
		base.DoBeforeShowUp();
		DialogBackground.MCJOOEEIIHI().PBHGMNNHNHD(DCIKANJJFIJ);
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}
}
