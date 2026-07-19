using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnitReadyForPromotionDialog : GuiElementSingle<UnitReadyForPromotionDialog>, PAIIOKBBHBC
{
	[Header("Header")]
	public UIButton LJNPCHFCGCN;

	[Header("Content")]
	public UISprite NACGOGCPIAH;

	public UILabel PAPFDDCBACC;

	[Header("Buttons")]
	public UIButton CLGPEFJOGLE;

	private LevelBehaviour IFFDIHCPKFE;

	public virtual void AKPHBJHGBKF()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				if (!(IFFDIHCPKFE == null))
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(IFFDIHCPKFE);
					if (GuiScreenSingle<ArmyScreen>.instance.isShowed)
					{
						GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
					}
					else
					{
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
					}
				}
			}
		});
	}

	private void NGBBHMKFGJB(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(IFFDIHCPKFE == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(IFFDIHCPKFE);
			if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
			}
		}
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FMHNFPEHKKJ));
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void DKOBOPADMMI()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public virtual void BGDPJGNKPKB()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void NDEOHELNJLN()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
	}

	public virtual void JCJECJKBKGD()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(136f / NACGOGCPIAH.transform.localScale.x, 806f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			UILabel pAPFDDCBACC = PAPFDDCBACC;
			object[] array = new object[3];
			array[0] = IFFDIHCPKFE.unitName.ToUpper();
			array[0] = Colours.stringWhite;
			array[1] = Colours.stringGoldTier;
			array[2] = IFFDIHCPKFE.upgradeSlots.actualTier + 0;
			pAPFDDCBACC.text = Localization.LocalizeFormat("ID_STARTERASSIGNMENTSEXPIRED", array);
		}
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	public virtual void DCNGEGFNAGG()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	private void NPJGJBCEFCA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void LGNPIHDILME(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(IFFDIHCPKFE == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(IFFDIHCPKFE);
			if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			}
		}
	}

	public virtual void MKPCIDNPCME()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void CBPNEALKOMM()
	{
		FJHIPNPNGAG(LJNPCHFCGCN.gameObject);
	}

	public virtual void NDBAEHKKJMH()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(436f / NACGOGCPIAH.transform.localScale.x, 1691f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			UILabel pAPFDDCBACC = PAPFDDCBACC;
			object[] array = new object[8];
			array[0] = IFFDIHCPKFE.unitName.ToUpper();
			array[0] = Colours.stringWhite;
			array[1] = Colours.stringGoldTier;
			array[2] = IFFDIHCPKFE.upgradeSlots.actualTier + 1;
			pAPFDDCBACC.text = Localization.LocalizeFormat(" mSpriteName:", array);
		}
	}

	public override void InitGUIValues()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(350f / NACGOGCPIAH.transform.localScale.x, 340f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			PAPFDDCBACC.text = Localization.LocalizeFormat("ID_UNITCANBEPROMOTEDTOTIER", IFFDIHCPKFE.unitName.ToUpper(), Colours.stringWhite, Colours.stringGoldTier, IFFDIHCPKFE.upgradeSlots.actualTier + 1);
		}
	}

	public virtual void PGHAMCBHBOD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NGBBHMKFGJB));
	}

	public virtual void LFDIOJJLKCG()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	public virtual void PGBBAHLJMLA()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	private void FMHNFPEHKKJ(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		HideDialog();
		if (!(IFFDIHCPKFE == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(IFFDIHCPKFE);
			if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			}
		}
	}

	private void MNIMAGPBMKE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void GFIFLFAKKEC()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public virtual void LKHINDDJBOD()
	{
		base.MOJBHFPBAPP();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EKFJOFAOPMA));
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EKFJOFAOPMA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LGNPIHDILME));
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void OAAABGFLAFG(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this, 951f);
	}

	public void ShowDialog(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void MJDMMNCCFKB()
	{
		base.PDBDILLHKID();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
	}

	public virtual void CFLBPMFEFAB()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public void IOAICJBKOIP(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this, 581f);
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}

	private void EKFJOFAOPMA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void NHJIGGFEEPP()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EKFJOFAOPMA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NGBBHMKFGJB));
	}

	private void FJHIPNPNGAG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CLGPEFJOGLE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				if (!(IFFDIHCPKFE == null))
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(IFFDIHCPKFE);
					if (GuiScreenSingle<ArmyScreen>.instance.isShowed)
					{
						GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
					}
					else
					{
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
					}
				}
			}
		});
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(IFFDIHCPKFE == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(IFFDIHCPKFE);
			if (GuiScreenSingle<ArmyScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			}
		}
	}

	public virtual void HLBIJGPEPIO()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	private void NKDHGKAOFKF(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		HideDialog();
		if (!(IFFDIHCPKFE == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(IFFDIHCPKFE);
			if (GuiScreenSingle<ArmyScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
			}
		}
	}

	public virtual void CLIEKFOJNPO()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EKFJOFAOPMA));
	}

	public virtual void JIODMKHANMM()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void BCMCGJGLFPL()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	public virtual void AIIJHNNODDM()
	{
		MNIMAGPBMKE(LJNPCHFCGCN.gameObject);
	}

	public virtual void ONHFMLDPOKG()
	{
		base.BJIPCOPNEAM();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EKFJOFAOPMA));
	}

	public virtual void EJNKFOFOJFL()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
	}
}
