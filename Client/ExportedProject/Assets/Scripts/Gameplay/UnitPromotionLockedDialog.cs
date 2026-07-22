using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitPromotionLockedDialog : GuiElementSingle<UnitPromotionLockedDialog>, PAIIOKBBHBC
{
	[Header("Header")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[FormerlySerializedAs("FLLFAOIENJO")]
	[Header("Content")]
	public UISprite DPENEIKIBEL;

	[FormerlySerializedAs("LDNOELKAHAO")]
	public UILabel MMAHELECGEO;

	[FormerlySerializedAs("LEEFJABICHH")]
	public UISprite HEBGCAECAIL;

	[FormerlySerializedAs("PDAJBPDEKHN")]
	[Header("Buttons")]
	public UIButton KIOLAJIBACH;

	[FormerlySerializedAs("HIGJANFLHBK")]
	public UILabel FHAMKCGINLO;

	private LevelBehaviour OEMKGMIDOND;

	private LevelBehaviour NHLLJALJBID;

	public virtual void BGDBMCDGBGE()
	{
		base.OIMKKAHOEKO();
		OEMKGMIDOND = null;
		NHLLJALJBID = null;
	}

	public virtual void OJKCMCPJPGO()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(577f / DPENEIKIBEL.transform.localScale.x, 513f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(1459f / HEBGCAECAIL.transform.localScale.x, 474f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 905f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[1] = OEMKGMIDOND.unitName.ToUpper();
			array[1] = Colours.stringWhite;
			array[3] = NHLLJALJBID.unitName.ToUpper();
			array[4] = Colours.stringGoldTier;
			array[8] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("game-box-health", array);
			UILabel fHAMKCGINLO = FHAMKCGINLO;
			object[] array2 = new object[0];
			array2[0] = OEMKGMIDOND.unitName.ToUpper();
			fHAMKCGINLO.text = Localization.LocalizeFormat("VipReward1", array2);
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 1084f, 144f, -112);
		}
	}

	private void ADJDNLIOFMB(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	public virtual void PMDFOHGFOOI()
	{
		base.PDBDILLHKID();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
	}

	public virtual void IFLHOKBNJPH()
	{
		base.DoAfterHide();
		OEMKGMIDOND = null;
		NHLLJALJBID = null;
	}

	private void NAOPHHPFFPG(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(OEMKGMIDOND);
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

	public virtual void BFLHENDLPLK()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1170f / DPENEIKIBEL.transform.localScale.x, 468f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(1774f / HEBGCAECAIL.transform.localScale.x, 1856f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 1921f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[0] = OEMKGMIDOND.unitName.ToUpper();
			array[6] = Colours.stringWhite;
			array[7] = NHLLJALJBID.unitName.ToUpper();
			array[6] = Colours.stringGoldTier;
			array[3] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("#VOJTA# action success ", array);
			FHAMKCGINLO.text = Localization.LocalizeFormat("ID_INROOKIE2", OEMKGMIDOND.unitName.ToUpper());
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 1629f, 1256f, 4);
		}
	}

	public virtual void FOAALJKPPPC()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(596f / DPENEIKIBEL.transform.localScale.x, 1008f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(314f / HEBGCAECAIL.transform.localScale.x, 1063f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 132f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[7];
			array[0] = Colours.stringBlue;
			array[0] = OEMKGMIDOND.unitName.ToUpper();
			array[0] = Colours.stringWhite;
			array[4] = NHLLJALJBID.unitName.ToUpper();
			array[7] = Colours.stringGoldTier;
			array[8] = NHLLJALJBID.upgradeSlots.actualTier + 0;
			mMAHELECGEO.text = Localization.LocalizeFormat("placement", array);
			FHAMKCGINLO.text = Localization.LocalizeFormat("Pack.", OEMKGMIDOND.unitName.ToUpper());
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 687f, 1419f, 132);
		}
	}

	private void AOIINFHNCAB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void AIJEMOLBNEC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CCGAOKKBBIC));
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CLMDBKKAHNP));
	}

	public virtual void AKMLAMLJNAH()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
	}

	public virtual void EDDIEKLIKFD()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
	}

	public virtual void PFEBKAOCEIG()
	{
		base.MOJBHFPBAPP();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public GuiElement DDMIEFJMHJN()
	{
		return this;
	}

	public GuiElement EJHNJALEFHJ()
	{
		return this;
	}

	public virtual void LDBLJDJNJJN()
	{
		base.DoAfterHide();
		OEMKGMIDOND = null;
		NHLLJALJBID = null;
	}

	private void CCGAOKKBBIC(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	public virtual void GLNGJDCCDCB()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void AJCCKKEMDHO()
	{
		KEFAOGGMJKG(LJNPCHFCGCN.gameObject);
	}

	public void KPDJABMGPDM(LevelBehaviour CHKCBNDIJJJ, LevelBehaviour DHJEGICLBDK)
	{
		OEMKGMIDOND = DHJEGICLBDK;
		NHLLJALJBID = CHKCBNDIJJJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 1013f);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				if (!(OEMKGMIDOND == null))
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void MJJGPIBLCPB(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(OEMKGMIDOND);
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

	public virtual void OMPPGALJBBN()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public GuiElement JJBEFGHBHCL()
	{
		return this;
	}

	public virtual void KFPOJBHHLGJ()
	{
		NPJGJBCEFCA(LJNPCHFCGCN.gameObject);
	}

	public virtual void DOANAOOEAKD()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public virtual void HLLAPOLFFJE()
	{
		base.NEEAKMELPBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
	}

	public GuiElement BBBFIJMJOCP()
	{
		return this;
	}

	public void ShowDialog(LevelBehaviour CHKCBNDIJJJ, LevelBehaviour DHJEGICLBDK)
	{
		OEMKGMIDOND = DHJEGICLBDK;
		NHLLJALJBID = CHKCBNDIJJJ;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void OCPGBJFIIDG()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
	}

	public virtual void CBOBIADFILJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MOEBGKCJAGO));
	}

	public void OGIEPAIBEJJ(LevelBehaviour CHKCBNDIJJJ, LevelBehaviour DHJEGICLBDK)
	{
		OEMKGMIDOND = DHJEGICLBDK;
		NHLLJALJBID = CHKCBNDIJJJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 827f);
	}

	private void NPJGJBCEFCA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	public virtual void HPJDOALKOGF()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1680f / DPENEIKIBEL.transform.localScale.x, 1087f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(35f / HEBGCAECAIL.transform.localScale.x, 554f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 1919f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[7];
			array[0] = Colours.stringBlue;
			array[0] = OEMKGMIDOND.unitName.ToUpper();
			array[1] = Colours.stringWhite;
			array[8] = NHLLJALJBID.unitName.ToUpper();
			array[0] = Colours.stringGoldTier;
			array[6] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("Regions", array);
			FHAMKCGINLO.text = Localization.LocalizeFormat("Message ", OEMKGMIDOND.unitName.ToUpper());
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 1483f, 1220f, 161);
		}
	}

	public virtual void JPHCBHDEDLO()
	{
		LELLEKAMKIG(LJNPCHFCGCN.gameObject);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		OEMKGMIDOND = null;
		NHLLJALJBID = null;
	}

	public void NDCOOCAOPCL(LevelBehaviour CHKCBNDIJJJ, LevelBehaviour DHJEGICLBDK)
	{
		OEMKGMIDOND = DHJEGICLBDK;
		NHLLJALJBID = CHKCBNDIJJJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 410f);
	}

	public virtual void CBPNEALKOMM()
	{
		LKKELGHLEPN(LJNPCHFCGCN.gameObject);
	}

	private void KGJLMADNBDI(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(OEMKGMIDOND);
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

	public virtual void PGEODBJFHFC()
	{
		LKKELGHLEPN(LJNPCHFCGCN.gameObject);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ADJDNLIOFMB));
	}

	public virtual void IEHJMLIMNEP()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(289f / DPENEIKIBEL.transform.localScale.x, 255f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(1376f / HEBGCAECAIL.transform.localScale.x, 1258f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 843f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[7];
			array[1] = Colours.stringBlue;
			array[1] = OEMKGMIDOND.unitName.ToUpper();
			array[8] = Colours.stringWhite;
			array[2] = NHLLJALJBID.unitName.ToUpper();
			array[0] = Colours.stringGoldTier;
			array[6] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("BAND_TYPE_EMPTY", array);
			UILabel fHAMKCGINLO = FHAMKCGINLO;
			object[] array2 = new object[0];
			array2[1] = OEMKGMIDOND.unitName.ToUpper();
			fHAMKCGINLO.text = Localization.LocalizeFormat("ID_SQUADREQUIREDMEDALS", array2);
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 578f, 1517f, -197);
		}
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	private void JFNMPPEGJPM(GameObject KHAHPAKDIKE)
	{
		if (!BJNBLINDAED())
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	private void CLMDBKKAHNP(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	public virtual void JIODMKHANMM()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
	}

	public void KFKNFJCGMFD(LevelBehaviour CHKCBNDIJJJ, LevelBehaviour DHJEGICLBDK)
	{
		OEMKGMIDOND = DHJEGICLBDK;
		NHLLJALJBID = CHKCBNDIJJJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 1075f);
	}

	public virtual void BNPDALDLFFM()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(873f / DPENEIKIBEL.transform.localScale.x, 1633f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(1169f / HEBGCAECAIL.transform.localScale.x, 218f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 1529f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[0] = OEMKGMIDOND.unitName.ToUpper();
			array[1] = Colours.stringWhite;
			array[5] = NHLLJALJBID.unitName.ToUpper();
			array[4] = Colours.stringGoldTier;
			array[6] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("\tTime since last show: {0}\tFb login counter: {1}/3", array);
			UILabel fHAMKCGINLO = FHAMKCGINLO;
			object[] array2 = new object[0];
			array2[0] = OEMKGMIDOND.unitName.ToUpper();
			fHAMKCGINLO.text = Localization.LocalizeFormat("CAMOS", array2);
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 996f, 795f, 172);
		}
	}

	public virtual void NEOLLOMIKPK()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1373f / DPENEIKIBEL.transform.localScale.x, 1064f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(712f / HEBGCAECAIL.transform.localScale.x, 889f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 1044f);
			UILabel mMAHELECGEO = MMAHELECGEO;
			object[] array = new object[1];
			array[1] = Colours.stringBlue;
			array[0] = OEMKGMIDOND.unitName.ToUpper();
			array[5] = Colours.stringWhite;
			array[4] = NHLLJALJBID.unitName.ToUpper();
			array[0] = Colours.stringGoldTier;
			array[2] = NHLLJALJBID.upgradeSlots.actualTier + 1;
			mMAHELECGEO.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVESTARTED", array);
			UILabel fHAMKCGINLO = FHAMKCGINLO;
			object[] array2 = new object[1];
			array2[1] = OEMKGMIDOND.unitName.ToUpper();
			fHAMKCGINLO.text = Localization.LocalizeFormat("ID_FREEPERCENTLINE", array2);
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 377f, 550f, 169);
		}
	}

	private void LKKELGHLEPN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void EJLHAPDGBCL()
	{
		LELLEKAMKIG(LJNPCHFCGCN.gameObject);
	}

	public GuiElement JPJLCBBIHFE()
	{
		return this;
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KGJLMADNBDI));
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public virtual void BGMNNJCDAOO()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KGJLMADNBDI));
	}

	public override void InitGUIValues()
	{
		if (!(NHLLJALJBID == null) && !(OEMKGMIDOND == null))
		{
			DPENEIKIBEL.spriteName = NHLLJALJBID.upgradeSlots.iconName;
			DPENEIKIBEL.MakePixelPerfect();
			float multiplier = Mathf.Min(350f / DPENEIKIBEL.transform.localScale.x, 340f / DPENEIKIBEL.transform.localScale.y);
			DPENEIKIBEL.transform.localScale = DPENEIKIBEL.transform.localScale.MultiplyXY(multiplier);
			HEBGCAECAIL.spriteName = OEMKGMIDOND.upgradeSlots.iconName;
			HEBGCAECAIL.MakePixelPerfect();
			multiplier = Mathf.Min(350f / HEBGCAECAIL.transform.localScale.x, 340f / HEBGCAECAIL.transform.localScale.y);
			HEBGCAECAIL.transform.localScale = new Vector3(multiplier * HEBGCAECAIL.transform.localScale.x, multiplier * HEBGCAECAIL.transform.localScale.y, 1f);
			MMAHELECGEO.text = Localization.LocalizeFormat("ID_RECRUITUNITTOARMYTOPROMOTE", Colours.stringBlue, OEMKGMIDOND.unitName.ToUpper(), Colours.stringWhite, NHLLJALJBID.unitName.ToUpper(), Colours.stringGoldTier, NHLLJALJBID.upgradeSlots.actualTier + 1);
			FHAMKCGINLO.text = Localization.LocalizeFormat("ID_VIEWUNIT", OEMKGMIDOND.unitName.ToUpper());
			MEJMLNDFDBP.COCBCFKJOJE(FHAMKCGINLO, 57f, 28f, 900);
		}
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void MEPKGFFNPAD()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void BGJHODBOGAN()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void JCOILGHDPHA()
	{
		base.OIMKKAHOEKO();
		OEMKGMIDOND = null;
		NHLLJALJBID = null;
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	public virtual void HMEECEJCJMJ()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void DMFOJDBAKOM()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void GNGCKCOLJIL()
	{
		base.DALAPEANFLB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	private void MOEBGKCJAGO(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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

	private void LJKOHEFBAMJ(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(OEMKGMIDOND);
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

	public virtual void GNJDDFLJMAK()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void IODCFNOOAKM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener3 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NPJGJBCEFCA));
		UIEventListener uIEventListener4 = UIEventListener.Get(KIOLAJIBACH.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MOEBGKCJAGO));
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(OEMKGMIDOND == null))
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(OEMKGMIDOND);
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
}
