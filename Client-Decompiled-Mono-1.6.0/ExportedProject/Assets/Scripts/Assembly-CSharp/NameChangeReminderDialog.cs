using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NameChangeReminderDialog : GuiElementSingle<NameChangeReminderDialog>, PAIIOKBBHBC
{
	[Header("Dialog Content")]
	public UIButton PHNIFMONKGA;

	public UIButton IPDKNHJKCIA;

	public virtual void EEFCNPGAODO()
	{
		JJNLDFHEHJL(PHNIFMONKGA.gameObject);
	}

	private void DBMOFCJBHFA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHOCBIKIKOE));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NFOGNDOICKP));
	}

	public GuiElement HDGJKEDKNDL()
	{
		return this;
	}

	public virtual void DEJFPFPJKJI()
	{
		EONGHPAPNFI(PHNIFMONKGA.gameObject);
	}

	public GuiElement DDMIEFJMHJN()
	{
		return this;
	}

	public virtual void EOFNCJHPHDM()
	{
		JJNLDFHEHJL(PHNIFMONKGA.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
			}
		});
	}

	private void PHEJINPOFKO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(PHNIFMONKGA.gameObject);
	}

	public virtual void JCGDALOBGHO()
	{
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKPDHCKFJPK));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
			}
		});
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPCNDCJALKJ));
	}

	public virtual void JJDJKPGLHGD()
	{
	}

	public virtual void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KPGDOMIOFDJ));
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	public virtual void LBFHGMHJKJC()
	{
		NHOCBIKIKOE(PHNIFMONKGA.gameObject);
	}

	private void MDMDKBDCKOJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKPDHCKFJPK));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFCPEKIPGLJ));
	}

	public virtual void NHOEHNJICBO()
	{
		EONGHPAPNFI(PHNIFMONKGA.gameObject);
	}

	public GuiElement NIFFGPKMBKE()
	{
		return this;
	}

	public GuiElement EICPBDMFHFE()
	{
		return this;
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DBMOFCJBHFA));
	}

	private void LFCPEKIPGLJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void LKKBJAMACMD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void OEDLHCLCKEO()
	{
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void ODCHCNCMJGC()
	{
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void BHADJPEPODO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void HIOBLMOKLGF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void GKEJLOGIJDP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void OBNCKIBJOGJ()
	{
	}

	private void NFOGNDOICKP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	public virtual void EIPIEOCIGKL()
	{
	}

	private void CPCNDCJALKJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void KPGDOMIOFDJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void HPMCJAPKFPF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void JNPMCOCIICG()
	{
		HPMCJAPKFPF(PHNIFMONKGA.gameObject);
	}

	public override void InitGUIValues()
	{
	}

	public virtual void DJMCADMNEDH()
	{
	}

	public virtual void KLABPENJAHJ()
	{
	}

	private void EONGHPAPNFI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void DLCJLHFFLPJ()
	{
		NKPDHCKFJPK(PHNIFMONKGA.gameObject);
	}

	private void CLMDBKKAHNP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void FMAGLNJIMKF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	public virtual void HFLEDEBGPBI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JJNLDFHEHJL));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNNDDFOKIKA));
	}

	private void NKPDHCKFJPK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EONGHPAPNFI));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNNDDFOKIKA));
	}

	public virtual void PDHNLAMPOBN()
	{
	}

	public virtual void LLJMGDDLIEG()
	{
		KEFAOGGMJKG(PHNIFMONKGA.gameObject);
	}

	private void MNNDDFOKIKA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void FBJPGHLEBPO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement BEOCBHEIKKO()
	{
		return this;
	}

	public virtual void GBLCNFADKHF()
	{
		PHEJINPOFKO(PHNIFMONKGA.gameObject);
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	private void KKHOGBIKIOD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	private void HECLHGPCBHJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, HECFOEMLJCD);
		}
	}

	public GuiElement NBMJAMLOCAJ()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void NEOLLOMIKPK()
	{
	}

	private void PFEFFOOHKHI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFEFFOOHKHI));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HECLHGPCBHJ));
	}

	private void JJNLDFHEHJL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void ELLOMLNAFJK()
	{
		EONGHPAPNFI(PHNIFMONKGA.gameObject);
	}

	public virtual void DLCPOAJMBJP()
	{
		GKOHJGFKPAH(PHNIFMONKGA.gameObject);
	}

	public virtual void PJENKEKOCAE()
	{
	}

	public virtual void LKDFHKIAKAB()
	{
		NHOCBIKIKOE(PHNIFMONKGA.gameObject);
	}

	private void KBOAHNAEGED(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKEJLOGIJDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CLMDBKKAHNP));
	}

	public virtual void CEOBPADJPIA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKEJLOGIJDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FMAGLNJIMKF));
	}

	public GuiElement FBCEIODHNLC()
	{
		return this;
	}

	public virtual void PFCKKOBABEL()
	{
		HPMCJAPKFPF(PHNIFMONKGA.gameObject);
	}

	public virtual void CICEFDONBML()
	{
		FBJPGHLEBPO(PHNIFMONKGA.gameObject);
	}

	public GuiElement ACKFLCFBFLN()
	{
		return this;
	}

	public virtual void OFCCACPEBHD()
	{
	}

	private void NHOCBIKIKOE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public GuiElement DPPOMEPDHEK()
	{
		return this;
	}

	public virtual void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EONGHPAPNFI));
		UIEventListener uIEventListener2 = UIEventListener.Get(IPDKNHJKCIA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CLMDBKKAHNP));
	}
}
