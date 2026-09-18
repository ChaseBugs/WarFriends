using System;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDialog : GuiElementSingle<LanguageDialog>, IGuiDialog
{
	[Header("Close")]
	public UIButton closeButton;

	[Header("List")]
	public List<SettingsMainButton> buttons;

	public UIGrid buttonGrid;

	private string mCurrentLanguage;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		CreateAndHookLanguageButtons();
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void CreateAndHookLanguageButtons()
	{
		int count = LanguageProperties.languages.Count;
		for (int i = 0; i < buttons.Count && i < count; i++)
		{
			string text = LanguageProperties.languages[i];
			buttons[i].nameLabel.text = LanguageProperties.GetTranslation(text.ToLower());
			UIEventListener.Get(buttons[i].gameObject).onClick = LanguageButtonClick;
		}
		buttonGrid.repositionNow = true;
	}

	private void LanguageButtonClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		int num = buttons.FindIndex((SettingsMainButton but) => but.gameObject.name == go.name);
		if (num == -1)
		{
			HideDialog();
			return;
		}
		string text = buttons[num].nameLabel.text;
		if (text == mCurrentLanguage.ToUpper())
		{
			return;
		}
		string newLanguage = GetLanguageFromButtonName(text);
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LANGUAGECHANGE"), Localization.LocalizeFormat("ID_CONFIRM_LANGUAGECHANGE_TEXT", LanguageProperties.GetTranslation(mCurrentLanguage.ToLower()), text), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				Localization.instance.nextLanguage = newLanguage;
				Singleton<BeanstalkServerManager>.instance.ChangeLanguage(newLanguage);
			}
		}, 0f);
		HideDialog();
	}

	private string GetLanguageFromButtonName(string buttonName)
	{
		foreach (KeyValuePair<string, string> languageName in LanguageProperties.languageNames)
		{
			if (Localization.Localize(languageName.Value) == buttonName)
			{
				return languageName.Key;
			}
		}
		return buttonName.ToLower();
	}

	public override void InitGUIValues()
	{
		int count = LanguageProperties.languages.Count;
		mCurrentLanguage = Localization.instance.nextLanguage;
		for (int i = 0; i < buttons.Count && i < count; i++)
		{
			string text = LanguageProperties.languages[i];
			buttons[i].SetHighlight(mCurrentLanguage == text);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
