using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class JoinOrCreateSquadDialog : GuiElementSingle<JoinOrCreateSquadDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[FormerlySerializedAs("JEDIIODMIBF")]
	[Header("Middle")]
	public UITable DEHDBIEONIE;

	[FormerlySerializedAs("DNMKFMELGPG")]
	public UILabel JMINNKBHOLP;

	[FormerlySerializedAs("ELCKDFIGOGP")]
	public UILabel JKJOBGEEOOK;

	[FormerlySerializedAs("KGENBOFKCOK")]
	[Header("Bottom")]
	public UIButton DEMFFGLNDJP;

	[FormerlySerializedAs("NBLEKCIMHFI")]
	public UIButton KHFOHBMDEBJ;

	private void MMGLPPKHCCM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNIJPDFMGML));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EJAKCPOLEJC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KEPANOAFGDH));
		JMINNKBHOLP.text = Localization.Localize("DOGTAG REWARD DIALOG - not showing because player already played one match and spent gained dogtag");
		JKJOBGEEOOK.rescaleWidth = 48 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 124);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = ECDKLKABMAL;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HPMCJAPKFPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ELAOKJDGAKB));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNPLONAGNFG));
		JMINNKBHOLP.text = Localization.Localize("ReSyncRPC");
		JKJOBGEEOOK.rescaleWidth = 173 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 99);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = LCEAIEBGBBA;
	}

	public GuiElement MBGEOLKGLGM()
	{
		return this;
	}

	private void OHJDPBGGELA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public virtual void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BIJAIMFLKMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMPEDKPFDOO));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GNOHHBDBJMC));
		JMINNKBHOLP.text = Localization.Localize("ID_GUI_BEADVISED_JORCSQUAD");
		JKJOBGEEOOK.rescaleWidth = -179 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 35);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = CJDAFNEFNFI;
	}

	public void ELODCMCIEDP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1187f);
	}

	public void GLLHPDLKAFI()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 882f);
	}

	public override void GENKPBNDOCB()
	{
		KCMKFOHCOKK(LJNPCHFCGCN.gameObject);
	}

	public virtual void IHLGGCNHCDG()
	{
	}

	private void JHGAAEAEMML(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void EJAKCPOLEJC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void CMFFEECPAED()
	{
		KCMKFOHCOKK(LJNPCHFCGCN.gameObject);
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HIPFHJDIMJA));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ILLGPNAKACP));
		JMINNKBHOLP.text = Localization.Localize("Directory \"{0}\" does not exists");
		JKJOBGEEOOK.rescaleWidth = -58 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -78);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = delegate
		{
			if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
			{
				JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
				DEHDBIEONIE.repositionNow = true;
			}
		};
	}

	private void AFBIBMPEAAE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public void LNCDCBNNKHN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1463f);
	}

	public virtual void FBDMBKKDEDC()
	{
	}

	public virtual void JMNHKBNACBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LNBOCKDINKM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OHJDPBGGELA));
		JMINNKBHOLP.text = Localization.Localize("ID_TRAINSMALL");
		JKJOBGEEOOK.rescaleWidth = -123 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 10);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = CJDAFNEFNFI;
	}

	public void OHJEIGCJCLL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 5f);
	}

	private void NIAINIMBICA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void NODOIBLJBKD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MCEPGNFHBCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LNBOCKDINKM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BHPHFADPDDO));
		JMINNKBHOLP.text = Localization.Localize("Rule Record For Height");
		JKJOBGEEOOK.rescaleWidth = 185 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -49);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = PNBEIOFCKDA;
	}

	public virtual void EJGCLLIGBCB()
	{
		DNIJPDFMGML(LJNPCHFCGCN.gameObject);
	}

	private void DNIJPDFMGML(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void LIEGBJHHFIG()
	{
	}

	private void PNBEIOFCKDA()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = false;
		}
	}

	public virtual void EEFCNPGAODO()
	{
		FBNPDPDJOBP(LJNPCHFCGCN.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IKHGOODELBC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BHPHFADPDDO));
		JMINNKBHOLP.text = Localization.Localize("ID_GETSP");
		JKJOBGEEOOK.rescaleWidth = 870 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 88);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = delegate
		{
			if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
			{
				JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
				DEHDBIEONIE.repositionNow = true;
			}
		};
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EJAKCPOLEJC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GNOHHBDBJMC));
		JMINNKBHOLP.text = Localization.Localize("Days_Since_Install");
		JKJOBGEEOOK.rescaleWidth = -155 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -44);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = CJDAFNEFNFI;
	}

	public virtual void GEDIFKPBIML()
	{
		LKKELGHLEPN(LJNPCHFCGCN.gameObject);
	}

	private void AEDGBDJPKMD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public virtual void DNFPEBEDLIG()
	{
	}

	public virtual void KPMLFMMINEP()
	{
	}

	public virtual void KMCKIIFEKCA()
	{
	}

	private void ECDKLKABMAL()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = true;
		}
	}

	public virtual void DMBLJNMGLAH()
	{
	}

	private void LCEAIEBGBBA()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = false;
		}
	}

	public virtual void GKPGHCLMCDK()
	{
		MMGLPPKHCCM(LJNPCHFCGCN.gameObject);
	}

	private void LNBOCKDINKM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
	}

	private void HIPFHJDIMJA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBNPDPDJOBP));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HFFMFFEMCGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNPLONAGNFG));
		JMINNKBHOLP.text = Localization.Localize("ID_PLAYXRANKEDBATTLESTOENTERLEAGUE");
		JKJOBGEEOOK.rescaleWidth = -132 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -17);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = LCEAIEBGBBA;
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	private void PMPEDKPFDOO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	private void IKHGOODELBC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void GAGKEJAFBOH()
	{
		MMGLPPKHCCM(LJNPCHFCGCN.gameObject);
	}

	public GuiElement DIHCAJGCPEI()
	{
		return this;
	}

	public virtual void BNPDALDLFFM()
	{
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	public virtual void DILDDAGFIEO()
	{
		BIJAIMFLKMB(LJNPCHFCGCN.gameObject);
	}

	private void NHJHBMBKDEM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public GuiElement NKAJOPFDFEI()
	{
		return this;
	}

	public virtual void CJMOCAFCDPE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GNHIHEPCJOK));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FGAGIDNNPIB));
		JMINNKBHOLP.text = Localization.Localize("Google2u.DBUpgradeSlotsAssaulter");
		JKJOBGEEOOK.rescaleWidth = 48 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 4);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = LCEAIEBGBBA;
	}

	private void GNOHHBDBJMC(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void FBNPDPDJOBP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}

	public virtual void EFINNDNBJDN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LNBOCKDINKM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MEIHBNOJJEC));
		JMINNKBHOLP.text = Localization.Localize("com.google.android.gms.common.api.GoogleApiClient");
		JKJOBGEEOOK.rescaleWidth = 122 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -48);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = ADGJFAALCFB;
	}

	private void BHADJPEPODO()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = true;
		}
	}

	private void KCMKFOHCOKK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void OKMMGFMKJGG()
	{
	}

	public GuiElement HBNMNKIHCLC()
	{
		return this;
	}

	public void GFBDMPINFFP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 482f);
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCMKFOHCOKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HIPFHJDIMJA));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FGAGIDNNPIB));
		JMINNKBHOLP.text = Localization.Localize("ID_UNITCOMBINATIONSAVED");
		JKJOBGEEOOK.rescaleWidth = 191 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -2);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = BHADJPEPODO;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNIJPDFMGML));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ELAOKJDGAKB));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OBLEKDODJGO));
		JMINNKBHOLP.text = Localization.Localize("CAD");
		JKJOBGEEOOK.rescaleWidth = 197 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 52);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = ECDKLKABMAL;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = true;
		}
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	public void PCBDDAMEPCJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1714f);
	}

	public virtual void IJHNPCPFEKF()
	{
	}

	private void KAPPBMIDNNC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void OJKCMCPJPGO()
	{
	}

	private void KEPANOAFGDH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public void OAAABGFLAFG()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 592f);
	}

	public GuiElement KFNLDDJDPDP()
	{
		return this;
	}

	private void CJDAFNEFNFI()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = true;
		}
	}

	public void AFBEKJCMHFO()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 556f);
	}

	public virtual void JCJECJKBKGD()
	{
	}

	private void GNHIHEPCJOK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void JDFDJPAAIAA()
	{
	}

	public void FPKBPNDDOHP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1601f);
	}

	private void MCEPGNFHBCI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void AGPINBAMJHF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NHJHBMBKDEM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KEPANOAFGDH));
		JMINNKBHOLP.text = Localization.Localize("{0}{1}");
		JKJOBGEEOOK.rescaleWidth = -189 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 92);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = delegate
		{
			if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
			{
				JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
				DEHDBIEONIE.repositionNow = true;
			}
		};
	}

	private void BIJAIMFLKMB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void IKOHKEBHBFF()
	{
	}

	public virtual void PJHCHEHKHEN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBNPDPDJOBP));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EJAKCPOLEJC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ILLGPNAKACP));
		JMINNKBHOLP.text = Localization.Localize("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!");
		JKJOBGEEOOK.rescaleWidth = -2 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + -118);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = ECDKLKABMAL;
	}

	private void LKKELGHLEPN(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void ELAOKJDGAKB(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public virtual void JIHMFJANIHI()
	{
	}

	public virtual void LCMFDLLFBDC()
	{
	}

	private void MEIHBNOJJEC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void HPMCJAPKFPF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public void KBBGALKNDDK()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1258f);
	}

	private void FGAGIDNNPIB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public virtual void KDKEPFMCOEF()
	{
		MCEPGNFHBCI(LJNPCHFCGCN.gameObject);
	}

	public virtual void DFMCKHMFNHO()
	{
	}

	private void ILLGPNAKACP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public void CPGNJFJHBEB()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 543f);
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCMKFOHCOKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMPEDKPFDOO));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ILLGPNAKACP));
		JMINNKBHOLP.text = Localization.Localize("Walk");
		JKJOBGEEOOK.rescaleWidth = 5 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 72);
		DEHDBIEONIE.repositionNow = false;
		DEHDBIEONIE.onReposition = delegate
		{
			if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
			{
				JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
				DEHDBIEONIE.repositionNow = true;
			}
		};
	}

	private void BHPHFADPDDO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void BALHPHBGFPF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public virtual void EIPCLGCNKGO()
	{
		DNIJPDFMGML(LJNPCHFCGCN.gameObject);
	}

	private void ADGJFAALCFB()
	{
		if (JMINNKBHOLP.transform.localScale.x != JKJOBGEEOOK.transform.localScale.x)
		{
			JMINNKBHOLP.transform.localScale = JKJOBGEEOOK.transform.localScale;
			DEHDBIEONIE.repositionNow = true;
		}
	}

	public virtual void LPHPIMMGNPI()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public GuiElement LGCLDIDHJHB()
	{
		return this;
	}

	public virtual void ECOFKMAPFLN()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public virtual void NNGKAAGFGPA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BIJAIMFLKMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(DEMFFGLNDJP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ELAOKJDGAKB));
		UIEventListener uIEventListener3 = UIEventListener.Get(KHFOHBMDEBJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OHJDPBGGELA));
		JMINNKBHOLP.text = Localization.Localize("antialiasing");
		JKJOBGEEOOK.rescaleWidth = 15 - ((int)(JMINNKBHOLP.relativeSize.x * JMINNKBHOLP.transform.localScale.x) + 27);
		DEHDBIEONIE.repositionNow = true;
		DEHDBIEONIE.onReposition = LCEAIEBGBBA;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void OBNCKIBJOGJ()
	{
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void OBLEKDODJGO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public void CHMIPBJLKIJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1999f);
	}

	public GuiElement NJJPMGGLEHB()
	{
		return this;
	}

	public void CMOEFABLABI()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1896f);
	}

	private void MNPLONAGNFG(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	private void HFFMFFEMCGC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}
}
