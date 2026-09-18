using System;
using UnityEngine;

public class VideoReplay : GuiElement
{
	[Header("Core")]
	public SettingsButton videoReplay;

	public UIPanel videoReplayWarning;

	public UIButton videoReplayWarningClose;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += RecordingOnChanged;
		UIEventListener uIEventListener = UIEventListener.Get(videoReplay);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnVideoReplayClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(videoReplayWarningClose);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseWarning));
	}

	private void RecordingOnChanged()
	{
		if (base.gameObject.activeInHierarchy)
		{
			videoReplay.ButtonSetTo(Recording.recordingEnabled);
			ShowHideVideoWarning(Recording.recordingEnabled);
		}
	}

	private void OnVideoReplayClick(GameObject go)
	{
		if (!Recording.tryToSetRecording)
		{
			Recording.recordingEnabled = !Recording.recordingEnabled;
			if (videoReplay.on)
			{
				videoReplay.ButtonSetTo(Recording.recordingEnabled);
			}
			else
			{
				videoReplay.ButtonSetTo(onSetting: true);
			}
			ShowHideVideoWarning(Recording.recordingEnabled);
		}
	}

	private void CloseWarning(GameObject go)
	{
		ShowHideVideoWarning(open: false);
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		Recording.recordingEnabled = false;
		videoReplay.gameObject.transform.parent.gameObject.SetActive(Recording.canRecord && !Recording.isBroadcasting);
		videoReplay.ButtonSetTo(Recording.recordingEnabled);
		ShowHideVideoWarning(Recording.recordingEnabled);
	}

	private void ShowHideVideoWarning(bool open)
	{
		if (open)
		{
			videoReplayWarning.gameObject.SetActive(value: true);
			TweenAlpha.Begin(videoReplayWarning.gameObject, 0.5f, 0f, 1f);
		}
		else
		{
			videoReplayWarning.gameObject.SetActive(value: false);
		}
	}
}
