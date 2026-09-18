using System;
using UnityEngine;

public class BroadcastSettingsDialog : GuiElementSingle<BroadcastSettingsDialog>, IGuiDialog
{
	[Header("-Buttons")]
	public GameObject closeButton;

	public GameObject continueButton;

	[Header("-Switches")]
	public SettingsButton microphoneSettings;

	public SettingsButton cameraSettings;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(continueButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(StartBroadcasting));
		UIEventListener uIEventListener3 = UIEventListener.Get(microphoneSettings.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MicrophoneSettingsClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(cameraSettings.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CameraSettingsClick));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void StartBroadcasting(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			WaitingDialog.ShowDialog("ID_WAITINGFORREPLAYKIT");
			Recording.StartBroadcast();
		}
	}

	private void MicrophoneSettingsClick(GameObject go)
	{
		DebugSettings.microphoneInBroadcast = !DebugSettings.microphoneInBroadcast;
		microphoneSettings.ButtonSetTo(DebugSettings.microphoneInBroadcast);
	}

	private void CameraSettingsClick(GameObject go)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		cameraSettings.ButtonSetTo(DebugSettings.cameraInBroadcast);
	}

	public override void InitGUIValues()
	{
		microphoneSettings.ButtonSetTo(DebugSettings.microphoneInBroadcast, updateOnlyActiveObject: false);
		cameraSettings.ButtonSetTo(DebugSettings.cameraInBroadcast, updateOnlyActiveObject: false);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}
}
