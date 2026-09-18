using System;
using UnityEngine;

public class NameChangeReminderDialog : GuiElementSingle<NameChangeReminderDialog>, IGuiDialog
{
	[Header("Dialog Content")]
	public UIButton notNow;

	public UIButton changeName;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(notNow.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(changeName.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, fadeOutTime);
			}
		});
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
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(notNow.gameObject);
	}
}
