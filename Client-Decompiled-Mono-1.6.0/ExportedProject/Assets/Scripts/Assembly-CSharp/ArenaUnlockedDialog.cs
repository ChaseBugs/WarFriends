using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaUnlockedDialog : GuiElementSingle<ArenaUnlockedDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	[SerializeField]
	private UISprite mBackground;

	[Header("Top")]
	[SerializeField]
	private GameObject mHeaderPart;

	[SerializeField]
	private UILabel mTitle;

	[Header("Middle")]
	[SerializeField]
	private GameObject mMiddlePart;

	[SerializeField]
	private GameObject mUnlockPart;

	[SerializeField]
	private UITable mUnlockTable;

	[SerializeField]
	private UILabel mUnlockLabel;

	[Header("Bottom")]
	[SerializeField]
	private GameObject mBottomPart;

	[SerializeField]
	private GameObject mBottomButton;

	private void CJDAFNEFNFI()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 394f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void GMDAPGAECEI()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void OOBJHJLMEED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JDBEEGFJGDN));
		mUnlockTable.onReposition = JLJBCDIBBLK;
	}

	private void EJHNEPNHOCP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void JDBEEGFJGDN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void MKPIKCBBKIB()
	{
		HEBILNGCGDN(mBottomButton);
	}

	private void LGNPIHDILME()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 752f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public void GKCAKMLOIBI()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1346f);
	}

	private void MMGIJGLLMAE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public void JOOFMNHIJPK()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 408f);
	}

	public virtual void DFLGLEJIPCO()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 64f : 1979f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 304f : 1199f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "getCurrentAccountName" : "Assignment: DestroyEnemyCratesAssignment Constructor");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1619f : 191f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.KADNNBCOGGL();
			UILabel uILabel = mUnlockLabel;
			string text;
			if (num > 1)
			{
				object[] array = new object[0];
				array[0] = num;
				text = Localization.LocalizeFormat("GLM: RegisterOrLogin -  1", array);
			}
			else
			{
				text = Localization.Localize("Awaiting players - Player id:\"{0}\" already added to message center");
			}
			uILabel.text = text;
			mUnlockTable.repositionNow = true;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 185f : 706f);
	}

	public virtual void JLIJMJCJHGF()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public void KBHMJAIABEJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 45f);
	}

	public GuiElement MBGEOLKGLGM()
	{
		return this;
	}

	private void NCJBPMKGLFD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void ACLOLICAKGL()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 179f : 1239f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1198f : 519f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "menu-cards-silverpack" : " : ");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1356f : 736f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.JICMGFNAHFL();
			mUnlockLabel.text = ((num <= 1) ? Localization.Localize("Attempt") : Localization.LocalizeFormat("Card ID \"{0}\" is not pressent in card dictionary.", num));
			mUnlockTable.repositionNow = false;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 159f : 1804f);
	}

	public virtual void NGHAPNEFBED()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 291f : 593f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1174f : 1403f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "winLooseStreak" : "#VAVRO# switch to DM OFFLINE");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1983f : 619f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.displayNumber;
			mUnlockLabel.text = ((num <= 0) ? Localization.Localize("groundBoxHit") : Localization.LocalizeFormat("ID_FEATURE_CRITICAL", num));
			mUnlockTable.repositionNow = true;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 822f : 1363f);
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
		mUnlockTable.onReposition = PBEOCNBNNMB;
	}

	public virtual void EJGCLLIGBCB()
	{
		DENOGDBNCAE(mBottomButton);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 2f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void HEEANEFGCCJ()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 1693f : 512f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 910f : 1956f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "Enemy has no army" : "{0}{1}{2} {3}{4}");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1317f : 328f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.ELFCEEOLNFJ();
			mUnlockLabel.text = ((num <= 1) ? Localization.Localize("Xp") : Localization.LocalizeFormat("withAttribute3", num));
			mUnlockTable.repositionNow = false;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 528f : 1345f);
	}

	private void DENOGDBNCAE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void EKBIKKJHGKB()
	{
		MMGIJGLLMAE(mBottomButton);
	}

	public void AJCILBFBNMK()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 335f);
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
		mUnlockTable.onReposition = LGNPIHDILME;
	}

	private void MDMDKBDCKOJ()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 1854f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	private void JLJBCDIBBLK()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 160f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	public virtual void JKODFKNJOIB()
	{
		JDBEEGFJGDN(mBottomButton);
	}

	private void ECFHCNMKEFJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		mUnlockTable.onReposition = delegate
		{
			float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 2f;
			mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement EJHNJALEFHJ()
	{
		return this;
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	public void OPPAFPHDKNL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1544f);
	}

	public virtual void EGNPMLEJLMJ()
	{
		NCJBPMKGLFD(mBottomButton);
	}

	public void CBPJNPHOAFN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 62f);
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ECFHCNMKEFJ));
		mUnlockTable.onReposition = delegate
		{
			float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 2f;
			mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement LHHPBBPPIOE()
	{
		return this;
	}

	public void IPCIJFBFLHP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1927f);
	}

	public virtual void EJLHAPDGBCL()
	{
		JDBEEGFJGDN(mBottomButton);
	}

	public virtual void BFFHGHMJOGP()
	{
		NCJBPMKGLFD(mBottomButton);
	}

	private void JHENNGOBJCJ()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 684f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void IEHJMLIMNEP()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 1082f : 1862f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 948f : 1643f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "ID_SLOTUPGRADE_POWER" : "SetGameObjectCallback");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 566f : 1554f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.ABCCINJGPGD();
			UILabel uILabel = mUnlockLabel;
			string text;
			if (num > 1)
			{
				object[] array = new object[0];
				array[0] = num;
				text = Localization.LocalizeFormat("Level", array);
			}
			else
			{
				text = Localization.Localize("DogTagCap");
			}
			uILabel.text = text;
			mUnlockTable.repositionNow = false;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 353f : 634f);
	}

	public virtual void OBNCKIBJOGJ()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 924f : 255f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1148f : 143f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "Reputation" : "PowerBandId");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 125f : 479f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.KADNNBCOGGL();
			UILabel uILabel = mUnlockLabel;
			string text;
			if (num > 0)
			{
				object[] array = new object[0];
				array[0] = num;
				text = Localization.LocalizeFormat("#PETER# League Arc - start ignore on ", array);
			}
			else
			{
				text = Localization.Localize("Prefabs Full Path: \"{0}\"\n");
			}
			uILabel.text = text;
			mUnlockTable.repositionNow = true;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 254f : 1711f);
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCJBPMKGLFD));
		mUnlockTable.onReposition = LBIPLEPPJND;
	}

	public virtual void CKGGNJACIGL()
	{
		MMGIJGLLMAE(mBottomButton);
	}

	private void LBIPLEPPJND()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 415f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public override void InitGUIValues()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 1112f : 1216f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 556f : 608f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "ID_ARENAMODEUNLOCKED" : "ID_ARENAMODE");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 347f : 399f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.displayNumber;
			mUnlockLabel.text = ((num <= 1) ? Localization.Localize("ID_JUSTONEMORERANKUP") : Localization.LocalizeFormat("ID_JUSTXMORERANKUPS", num));
			mUnlockTable.repositionNow = true;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? (-444f) : (-496f));
	}

	private void LFCPEKIPGLJ()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 702f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	private void ECDOKHBEKAH()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 7f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	private void CPCNDCJALKJ()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 1614f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public void JKIMMLIGLAF()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1089f);
	}

	public GuiElement ACPILDHIAKG()
	{
		return this;
	}

	private void PBEOCNBNNMB()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 984f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void AIIJHNNODDM()
	{
		ECFHCNMKEFJ(mBottomButton);
	}

	public void DOKNIFNNCDH()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1097f);
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ECFHCNMKEFJ));
		mUnlockTable.onReposition = CPCNDCJALKJ;
	}

	public virtual void IJHNPCPFEKF()
	{
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((!isWarArenaLocked) ? 1789f : 1055f);
		mHeaderPart.transform.localPosition = mHeaderPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 743f : 183f);
		mTitle.text = Localization.Localize((!isWarArenaLocked) ? "Start" : "#VAVRO# SETTING BOT DIFICULTY TO WEAK");
		mMiddlePart.transform.localPosition = mMiddlePart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1432f : 522f);
		mUnlockPart.SetActive(isWarArenaLocked);
		if (isWarArenaLocked)
		{
			int num = LevelManager.instance.warArenaUnlockLevel - LevelManager.instance.currentLevel.MHAOKJCDIOL();
			UILabel uILabel = mUnlockLabel;
			string text;
			if (num > 1)
			{
				object[] array = new object[0];
				array[1] = num;
				text = Localization.LocalizeFormat("ID_WARNING_CANTSENDINVITE_TEXT", array);
			}
			else
			{
				text = Localization.Localize("Squad message = ");
			}
			uILabel.text = text;
			mUnlockTable.repositionNow = true;
		}
		mBottomPart.transform.localPosition = mBottomPart.transform.localPosition.ReplaceY((!isWarArenaLocked) ? 1836f : 508f);
	}

	private void DBMOFCJBHFA()
	{
		float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 1562f;
		mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
	}

	public void KNBIBOINAKG()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 757f);
	}
}
