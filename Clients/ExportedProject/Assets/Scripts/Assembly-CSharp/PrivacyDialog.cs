using System;
using UnityEngine;

public class PrivacyDialog : GuiElementSingle<PrivacyDialog>, IGuiDialog
{
	[Header("Buttons")]
	public GameObject closeButton;

	public GameObject userAgreementButton;

	public GameObject privacyCookiesButton;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(userAgreementButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(UserAgreementClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(privacyCookiesButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PrivacyCookiesClick));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void UserAgreementClick(GameObject go)
	{
		Application.OpenURL("http://tos.ea.com/legalapp/WEBTERMS/US/" + GetCode() + "/PC/");
	}

	private void PrivacyCookiesClick(GameObject go)
	{
		Application.OpenURL("http://tos.ea.com/legalapp/WEBPRIVACY/US/" + GetCode() + "/PC/");
	}

	public override void InitGUIValues()
	{
	}

	private string GetCode()
	{
		string currentLanguage = Localization.instance.currentLanguage;
		switch (currentLanguage)
		{
			case "cn":
				return "sc";
			case "jp":
				return "ja";
			case "kr":
				return "ko";
			default:
				return currentLanguage;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton);
	}
}
