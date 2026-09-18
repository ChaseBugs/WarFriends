using System;
using UnityEngine;

public class UserGeneratedContent : GuiElementSingle<UserGeneratedContent>, IGuiDialog
{
	[Header("Buttons")]
	public UIButton continueButton;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(continueButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		Singleton<BeanstalkServerManager>.instance.ChatShown();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(continueButton.gameObject);
	}
}
