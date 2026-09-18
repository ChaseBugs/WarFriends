using System;
using UnityEngine;

public class EnableNotificationsInSystemDialog : GuiElementSingle<EnableNotificationsInSystemDialog>, IGuiDialog
{
	[Header("Buttons")]
	public UIButton buttonCancel;

	public UIButton buttonEnable;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonCancel.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CancelClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonEnable.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EnableClick));
	}

	public override void InitGUIValues()
	{
	}

	private void CancelClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void EnableClick(GameObject go)
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
		CancelClick(buttonCancel.gameObject);
	}
}
