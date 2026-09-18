using System;
using UnityEngine;

public class ElitePerkTutorialDialog : GuiElementSingle<ElitePerkTutorialDialog>, IGuiDialog
{
	[Header("Core")]
	public GameObject bottomButton;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
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
		CloseClick(bottomButton);
	}
}
