using System;
using UnityEngine;

public class ReconnectDialog : GuiElementSingle<ReconnectDialog>, IGuiDialog
{
	[Header("Core")]
	public UISprite background;

	public UILabel title;

	public UILabel waitText;

	public UILabel hintText;

	public GameObject forfeitButton;

	public void SetCause(ReconnectState reconnectState, bool allPlayersFinishetStartAnimation)
	{
		switch (reconnectState)
		{
		case ReconnectState.Me:
			title.text = Localization.Localize("ID_YOUWEREDISCONNECTED");
			forfeitButton.SetActive(value: true);
			break;
		case ReconnectState.Other:
			title.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_OPPONENTWASDISCONNECTED" : "ID_FRIENDWASDISCONNECTED");
			forfeitButton.SetActive(value: false);
			break;
		default:
			if (!allPlayersFinishetStartAnimation)
			{
				title.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_STATE_WAITINGFOROPPONENT" : "ID_WAITINGFORFRIEND");
				forfeitButton.SetActive(value: false);
			}
			break;
		}
		hintText.gameObject.SetActive(!forfeitButton.activeSelf);
		if (hintText.gameObject.activeSelf)
		{
			hintText.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_RECONNECTHINT" : "ID_RECONNECTFRIENDHINT");
			MiscTools.SetUILabelRescale(hintText, 40f, 20f, 1340);
		}
		background.transform.localScale = background.transform.localScale.ReplaceY((!forfeitButton.activeSelf) ? 836f : 872f);
		MiscTools.SetUILabelRescale(title, 87f, 44f, 1420);
	}

	public void SetWaitTime(float time)
	{
		if (time > 0f)
		{
			waitText.text = Localization.LocalizeFormat("ID_WAITINGTIME", MiscTools.PrintableTimeTwoDigits(time));
		}
		else
		{
			waitText.text = string.Empty;
		}
	}

	public override void HideDialog()
	{
		Debug.Log("ReconnectDialog Hide");
		base.HideDialog();
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(forfeitButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnForfeitClick));
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
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
				HideDialog();
			}
		}, 0f);
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		HideDialog();
	}

	public override void InitGUIValues()
	{
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		Debug.Log("ReconnectDialog Show");
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Debug.Log("ReconnectDialog: DoBeforeHide");
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
	}
}
