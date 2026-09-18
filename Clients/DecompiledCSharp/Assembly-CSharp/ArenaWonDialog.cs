using System;
using UnityEngine;

public class ArenaWonDialog : GuiElementSingle<ArenaWonDialog>, IGuiDialog
{
	[Header("Core")]
	[SerializeField]
	private UILabel mMiddleText;

	[SerializeField]
	private GameObject mBottomButton;

	private bool mIsFlawless;

	private int mWonBattles;

	public void ShowDialog(bool isFlawless, int wonBattles)
	{
		mIsFlawless = isFlawless;
		mWonBattles = wonBattles;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.EnterArena;
				GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mMiddleText.text = Localization.LocalizeFormat((!mIsFlawless) ? "ID_ARENAWONXWINSTEXT" : "ID_ARENAWONFLAWLESSLYTEXT", mWonBattles);
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
