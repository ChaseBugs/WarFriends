using System;
using UnityEngine;

public class UserExistsDialog : GuiElementSingle<UserExistsDialog>, IGuiDialog
{
	[Header("Content")]
	public UILabel mainText;

	[Header("Left Current User")]
	public UIButton leftButton;

	public UISprite currentLevelIcon;

	public UILabel currentLevelNumber;

	public UILabel currentName;

	public UILabel currentMedals;

	[Header("Right Other User")]
	public UIButton rightButton;

	public UILabel rightButtonLabel;

	public UISprite otherLevelIcon;

	public UILabel otherLevelNumber;

	public UILabel otherName;

	public UILabel otherMedals;

	public Action<bool> actionResult;

	private AccountType mAccountType;

	private string mUserName;

	private int mUserLevel;

	private int mUserMedals;

	private string mCustomText;

	public void ShowDialog(AccountType accountType, Action<bool> result, string userName, int userLevel = 2, int userMedals = 500, string customText = "")
	{
		mAccountType = accountType;
		actionResult = result;
		mUserName = userName;
		mUserLevel = userLevel;
		mUserMedals = userMedals;
		mCustomText = customText;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(leftButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CurrentChosenClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(rightButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OtherChosenClick));
	}

	private void CurrentChosenClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_AREYOUSURE"), Localization.LocalizeFormat("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", currentName.text, currentLevelNumber.text, otherName.text, otherLevelNumber.text), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				if (actionResult != null)
				{
					actionResult(obj: true);
				}
				HideDialog();
			}
		}, 0f);
	}

	private void OtherChosenClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_AREYOUSURE"), Localization.LocalizeFormat("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", otherName.text, otherLevelNumber.text, currentName.text, currentLevelNumber.text), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				if (actionResult != null)
				{
					actionResult(obj: false);
				}
				HideDialog();
			}
		}, 0f);
	}

	public override void InitGUIValues()
	{
		if (mAccountType == AccountType.GooglePlay)
		{
			mainText.text = Localization.Localize("ID_USEREXISTSGOOGLEPLAYTEXT");
			rightButtonLabel.text = Localization.Localize("ID_GOOGLEPLAYUSER");
		}
		else if (mAccountType == AccountType.GameCenter)
		{
			mainText.text = Localization.Localize("ID_USEREXISTSGAMECENTERTEXT");
			rightButtonLabel.text = Localization.Localize("ID_GAMECENTERUSER");
		}
		else
		{
			mainText.text = ((!string.IsNullOrEmpty(mCustomText)) ? mCustomText : Localization.Localize("ID_USEREXISTSFACEBOOKTEXT"));
			rightButtonLabel.text = Localization.Localize("ID_FACEBOOKUSER");
		}
		FillCurrentUser();
		FillOtherUser();
	}

	private void FillOtherUser()
	{
		otherName.text = mUserName;
		MiscTools.SetUILabelRescale(otherName, 30f, 22f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(mUserLevel);
		otherLevelNumber.text = levelDefinition.displayString;
		otherLevelIcon.spriteName = levelDefinition.iconName;
		otherMedals.text = MiscTools.FormatBigNumber(mUserMedals);
	}

	private void FillCurrentUser()
	{
		currentName.text = GameLoginManager.currentPlayer.name;
		MiscTools.SetUILabelRescale(otherName, 30f, 22f);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		currentLevelNumber.text = currentLevel.displayString;
		currentLevelIcon.spriteName = currentLevel.iconName;
		currentMedals.text = MiscTools.FormatBigNumber(GameLoginManager.currentPlayer.skill);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		actionResult = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
	}
}
