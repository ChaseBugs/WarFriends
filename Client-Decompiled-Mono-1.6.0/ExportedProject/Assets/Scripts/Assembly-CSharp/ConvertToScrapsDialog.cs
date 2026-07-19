using System;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class ConvertToScrapsDialog : GuiElementSingle<ConvertToScrapsDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Top")]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mTopText;

	[SerializeField]
	[Header("Middle")]
	private UISprite mUnitIcon;

	[SerializeField]
	private UILabel mUnitEliteParts;

	[SerializeField]
	private UITable mScrapsTable;

	[SerializeField]
	private UILabel mScrapsLabel;

	[SerializeField]
	[Header("Bottom")]
	private GameObject mBottomButton;

	private LevelBehaviour IFFDIHCPKFE;

	private Action<bool> PMFAEKAALAK;

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	public void OAAABGFLAFG(LevelBehaviour IOIKKIIFOCB, Action<bool> BLHPGCIDEBE)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(this, 903f);
	}

	private void DCLELDLLJKD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void HLBIJGPEPIO()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public virtual void FACKIKMABGK()
	{
		int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier5Percentage).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)currentParts * (float)fLOATVALUE);
		UILabel uILabel = mTopText;
		object[] array = new object[6];
		array[0] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		array[1] = IFFDIHCPKFE.unitElitePartsName;
		array[4] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		uILabel.text = Localization.LocalizeFormat("ID_CLOSESIN", array);
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 502f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(150f / mUnitIcon.transform.localScale.x, 362f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsSell).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)currentParts * (float)fLOATVALUE);
		mTopText.text = Localization.LocalizeFormat("ID_AREYOUSUREYOUWANTTOCONVERTPARTS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(currentParts), IFFDIHCPKFE.unitElitePartsName, MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 126f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(180f / mUnitIcon.transform.localScale.x, 116f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = true;
	}

	private void OAEGLMGPFOI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	public virtual void CICEFDONBML()
	{
		PMEMHPANFMC(mBottomButton);
	}

	public void ShowDialog(LevelBehaviour IOIKKIIFOCB, Action<bool> BLHPGCIDEBE)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	private void HJDABGKKGMP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	private void NKDHGKAOFKF()
	{
		float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 747f;
		mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void DBMCMLINOPD()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void NIHDCNNMBIK()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	public virtual void HGKNCKIKBDC()
	{
		int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)currentParts * (float)fLOATVALUE);
		UILabel uILabel = mTopText;
		object[] array = new object[7];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		array[4] = IFFDIHCPKFE.unitElitePartsName;
		array[7] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		uILabel.text = Localization.LocalizeFormat(".e", array);
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 1790f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(465f / mUnitIcon.transform.localScale.x, 1488f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = false;
	}

	public virtual void CDHLMEPGPNJ()
	{
		int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-109)).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)num * (float)fLOATVALUE);
		UILabel uILabel = mTopText;
		object[] array = new object[5];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
		array[6] = IFFDIHCPKFE.unitElitePartsName;
		array[3] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		uILabel.text = Localization.LocalizeFormat("RETRY", array);
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 940f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(1070f / mUnitIcon.transform.localScale.x, 1571f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = true;
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(APGBGLPBCEB));
		mScrapsTable.onReposition = delegate
		{
			float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 2f;
			mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	private void NGAOACPFBPC()
	{
		float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 1756f;
		mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
	}

	private void PCDMCGJGBDP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public GuiElement EMJNNILLFIM()
	{
		return this;
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FCEDMOAEKOB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(APGBGLPBCEB));
		mScrapsTable.onReposition = NGAOACPFBPC;
	}

	public virtual void EMGHCAHOJNC()
	{
		int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)currentParts * (float)fLOATVALUE);
		UILabel uILabel = mTopText;
		object[] array = new object[6];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		array[0] = IFFDIHCPKFE.unitElitePartsName;
		array[5] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		uILabel.text = Localization.LocalizeFormat("ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT", array);
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 985f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(1073f / mUnitIcon.transform.localScale.x, 578f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = true;
	}

	public void EMCKDMFGEIB(LevelBehaviour IOIKKIIFOCB, Action<bool> BLHPGCIDEBE)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(this, 977f);
	}

	private void PMEMHPANFMC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	private void LJJPMNECIGF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	private void APGBGLPBCEB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void FNNHJPMKDOM()
	{
		MBNJPBNNJPM(mBottomButton);
	}

	public override void GENKPBNDOCB()
	{
		PMEMHPANFMC(mBottomButton);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 2f;
		mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
	}

	private void MBNJPBNNJPM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void BNPDALDLFFM()
	{
		int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-56)).FLOATVALUE;
		int fFHHEHHFOKJ = (int)((float)num * (float)fLOATVALUE);
		UILabel uILabel = mTopText;
		object[] array = new object[1];
		array[1] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(num);
		array[0] = IFFDIHCPKFE.unitElitePartsName;
		array[3] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		uILabel.text = Localization.LocalizeFormat("menu-hub-multiplayer-vipico", array);
		mUnitIcon.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			float multiplier = 1164f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(962f / mUnitIcon.transform.localScale.x, 1007f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		mScrapsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		mScrapsTable.repositionNow = true;
	}

	public void KLMGKBDODBJ(LevelBehaviour IOIKKIIFOCB, Action<bool> BLHPGCIDEBE)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(this, 228f);
	}

	private void GPOOJEDAMEG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	private void OPEIOMJOMDI()
	{
		float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 183f;
		mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
	}

	private void IIKAFDLCMEC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	private void PMEJKEBHMJN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCLELDLLJKD));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMEJKEBHMJN));
		mScrapsTable.onReposition = OPEIOMJOMDI;
	}

	private void MMGIJGLLMAE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCLELDLLJKD));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJJPMNECIGF));
		mScrapsTable.onReposition = delegate
		{
			float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 2f;
			mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void OEEEAMKAAJE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	private void FCEDMOAEKOB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public void JDNEBEKOHPG(LevelBehaviour IOIKKIIFOCB, Action<bool> BLHPGCIDEBE)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1764f);
	}
}
