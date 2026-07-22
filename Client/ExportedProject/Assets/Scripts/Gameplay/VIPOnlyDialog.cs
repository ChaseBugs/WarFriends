using System;
using UnityEngine;

public class VIPOnlyDialog : GuiElementSingle<VIPOnlyDialog>, PAIIOKBBHBC
{
	[Header("Center")]
	public UILabel HOLNKOFHDNK;

	public UISprite LNOALPEJMPI;

	public UISprite EMIKKLKIPNJ;

	[Header("Bottom")]
	public UIButton APCMHDINKEI;

	public UIButton ELOEEKANPJN;

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	public override void InitGUIValues()
	{
	}

	private void GGJNEGPBDHL(string FNEEBKOLLIC, string KCHMDALPMBN, bool FCCPCGEBNEK)
	{
		LNOALPEJMPI.gameObject.SetActive(!FCCPCGEBNEK);
		EMIKKLKIPNJ.gameObject.SetActive(FCCPCGEBNEK);
		if (FCCPCGEBNEK)
		{
			EMIKKLKIPNJ.spriteName = KCHMDALPMBN;
			EMIKKLKIPNJ.MakePixelPerfect();
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(1.7f);
		}
		else
		{
			LNOALPEJMPI.spriteName = KCHMDALPMBN;
			LNOALPEJMPI.MakePixelPerfect();
			LNOALPEJMPI.transform.localScale = LNOALPEJMPI.transform.localScale.MultiplyXY(1.7f);
		}
		HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_ACCESSORYISACCESSIBLEONLYTOVIP", FNEEBKOLLIC, Colours.stringWhite);
	}

	public virtual void KFPOJBHHLGJ()
	{
		KEFAOGGMJKG(APCMHDINKEI.gameObject);
	}

	public void ShowDialog(PlayerVisual DJOAHABGGNA)
	{
		GGJNEGPBDHL(DJOAHABGGNA.name, DJOAHABGGNA.icon, DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void BCGIKEKOPLL()
	{
		BKJPHNPHGMI(APCMHDINKEI.gameObject);
	}

	public virtual void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void NOOGCJJIAIJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	public void GONOICLIMKO(PlayerVisual DJOAHABGGNA)
	{
		GGJNEGPBDHL(DJOAHABGGNA.name, DJOAHABGGNA.icon, DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this, 850f);
	}

	public void JKIMMLIGLAF(PlayerVisual DJOAHABGGNA)
	{
		GGJNEGPBDHL(DJOAHABGGNA.name, DJOAHABGGNA.icon, DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this, 1460f);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}

	private void LFJIEIJBJCB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void DOLLFDPMGOD()
	{
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NOOGCJJIAIJ));
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void EMCKDMFGEIB(PlayerVisual DJOAHABGGNA)
	{
		GGJNEGPBDHL(DJOAHABGGNA.name, DJOAHABGGNA.icon, DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this, 1740f);
	}

	public virtual void DLCJLHFFLPJ()
	{
		GAJOEPACHHB(APCMHDINKEI.gameObject);
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	private void BKJPHNPHGMI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void JCIBDJMFOLI()
	{
	}

	public void CHMIPBJLKIJ(PlayerVisual DJOAHABGGNA)
	{
		GGJNEGPBDHL(DJOAHABGGNA.name, DJOAHABGGNA.icon, DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this, 1553f);
	}

	public virtual void CBPNEALKOMM()
	{
		GAJOEPACHHB(APCMHDINKEI.gameObject);
	}

	public virtual void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAJOEPACHHB));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NOOGCJJIAIJ));
	}

	private void NPJGJBCEFCA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void GAJOEPACHHB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void BFLHENDLPLK()
	{
	}

	public virtual void EJGCLLIGBCB()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}
}
