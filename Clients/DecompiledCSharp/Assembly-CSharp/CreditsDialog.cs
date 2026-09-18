using System;
using UnityEngine;

public class CreditsDialog : GuiElementSingle<CreditsDialog>, IGuiDialog
{
	[Header("Credits")]
	public UIButton closeButton;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public override void InitGUIValues()
	{
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
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
