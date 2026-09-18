using System;
using UnityEngine;

public class CantPauseDialog : GuiElementSingle<CantPauseDialog>, IGuiDialog
{
	[Header("Buttons")]
	public UIButton resume;

	public UIButton forfeit;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(resume);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(forfeit);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OnForfeitClick));
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	public override void InitGUIValues()
	{
	}

	private void OnForfeitClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_FORFEIT"), Localization.Localize("ID_CONFIRM_FORFEIT_TEXT"), delegate(ConfirmDialog dialog, bool b)
		{
			if (b)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
			HideDialog();
		}, 0f);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		HideDialog();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(resume.gameObject);
	}
}
