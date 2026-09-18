using System;
using UnityEngine;

public class ArenaUnlockedDialog : GuiElementSingle<ArenaUnlockedDialog>, IGuiDialog
{
	[Header("Core")]
	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	[Header("Top")]
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

	[SerializeField]
	[Header("Bottom")]
	private GameObject mBottomPart;

	[SerializeField]
	private GameObject mBottomButton;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		mUnlockTable.onReposition = delegate
		{
			float val = 0f - mUnlockTable.padding.x - (mUnlockLabel.transform.parent.localPosition.x - mUnlockTable.padding.x) / 2f;
			mUnlockTable.transform.localPosition = mUnlockTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
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

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mBottomButton);
	}
}
