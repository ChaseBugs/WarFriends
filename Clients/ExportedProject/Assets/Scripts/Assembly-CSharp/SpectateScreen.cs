using System;
using UnityEngine;

public class SpectateScreen : GuiScreenSingle<SpectateScreen>
{
	[Header("Button")]
	public UIButton forfeitButton;

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(forfeitButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ForfeitClick));
	}

	private void ForfeitClick(GameObject go)
	{
		if (!isShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_LEAVE_SPECTATE"), Localization.Localize("ID_CONFIRM_LEAVE_SPECTATE_TEXT"), delegate(ConfirmDialog dialog, bool b)
		{
			if (b)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 0f);
	}

	protected override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}

	public override void OnBack()
	{
		ForfeitClick(forfeitButton.gameObject);
	}
}
