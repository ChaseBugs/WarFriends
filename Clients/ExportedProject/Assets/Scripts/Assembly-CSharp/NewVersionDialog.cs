using System;
using UnityEngine;

public class NewVersionDialog : GuiElementSingle<NewVersionDialog>, IGuiDialog
{
	[Header("Button")]
	public UIButton openAppstore;

	public UIButton openPlayStore;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(openAppstore.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenAppstore));
		UIEventListener uIEventListener2 = UIEventListener.Get(openPlayStore.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OpenPlayStore));
	}

	public override void InitGUIValues()
	{
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		DialogBackground.instance.ShowBackground(fadeInTime);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		DialogBackground.instance.HideBackground(fadeOutTime);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
	}

	private void OpenAppstore(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.iOSAppStoreURL);
			CloseDialogOrQuitApplication();
		}
	}

	private void OpenPlayStore(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			CloseDialogOrQuitApplication();
		}
	}

	private void CloseDialogOrQuitApplication()
	{
		if (DebugSettings.debugEnabled)
		{
			HideDialog();
		}
		else
		{
			Application.Quit();
		}
	}
}
