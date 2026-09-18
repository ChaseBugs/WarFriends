using System;
using UnityEngine;

public class InvitationFailedDialog : GuiElementSingle<InvitationFailedDialog>, IGuiDialog
{
	[Header("Top")]
	public UILabel header;

	[Header("Middle")]
	public UILabel description;

	[Header("Bottom")]
	public UIButton continueButton;

	private InvitationState mState;

	public void ShowDialog(InvitationState invitationState)
	{
		mState = invitationState;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(continueButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ContinueClick));
	}

	private void ContinueClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public override void InitGUIValues()
	{
		if (mState == InvitationState.Denied)
		{
			header.text = Localization.Localize("ID_INVITATIONDENIED");
			description.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_YOUROPPONENTHASDENIED") : Localization.Localize("ID_YOURFRIENDHASDENIED"));
		}
		else
		{
			header.text = Localization.Localize("ID_INVITATIONNOTACCEPTED");
			description.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_YOUROPPONENTHASNOTACCEPTED") : Localization.Localize("ID_YOURFRIENDHASNOTACCEPTED"));
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		ContinueClick(continueButton.gameObject);
	}
}
