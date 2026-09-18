using System;
using UnityEngine;

public class FacebookDialog : GuiElementSingle<FacebookDialog>, IGuiDialog
{
	[Header("Texts")]
	public UILabel titleText;

	public UILabel legalText;

	[Header("Buttons")]
	public UIButton signIn;

	public UILabel signInLabel;

	public UIButton cancel;

	private Action<bool> mDialogResult;

	public void ShowLoginDialog(Action<bool> resultHandler)
	{
		mDialogResult = resultHandler;
		titleText.text = Localization.Localize("ID_FACEBOOKCONNECT");
		legalText.text = Localization.Localize("ID_FACEBOOKLOGINLEGALTEXT");
		signInLabel.text = Localization.Localize("ID_SIGNIN");
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowLogoutDialog(bool newAccount, Action<bool> resultHandler)
	{
		mDialogResult = resultHandler;
		string text = "ID_FACEBOOKLOGOUTLEGALTEXT";
		text = "ID_FACEBOOKLOGOUTLEGALTEXTA";
		titleText.text = Localization.Localize("ID_FACEBOOKLOGOUT");
		legalText.text = Localization.Localize((!newAccount) ? text : "ID_FACEBOOKLOGOUTLEGALTEXT2");
		signInLabel.text = Localization.Localize("ID_SIGNOUT");
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowGooglePlayLogoutDialog(Action<bool> resultHandler)
	{
		mDialogResult = resultHandler;
		titleText.text = Localization.Localize("ID_GOOGLEPLAYLOGOUT");
		legalText.text = Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT");
		signInLabel.text = Localization.Localize("ID_SIGNOUT");
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(signIn.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(SignInClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(cancel.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CancelClick));
	}

	private void SignInClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mDialogResult != null)
			{
				mDialogResult(obj: true);
				mDialogResult = null;
			}
		}
	}

	private void CancelClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mDialogResult != null)
			{
				mDialogResult(obj: false);
				mDialogResult = null;
			}
		}
	}

	public override void InitGUIValues()
	{
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CancelClick(cancel.gameObject);
	}
}
