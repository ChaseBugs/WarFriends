using System;
using UnityEngine;

public class LiveBroadcast : GuiElement
{
	[Header("Core")]
	public UIPanel videoReplayWarning;

	public UIButton videoReplayWarningClose;

	public SettingsButton broadcast;

	public GameObject androidBroadcast;

	public GameObject youtubeButton;

	public GameObject mobcrushButton;

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(youtubeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			AndroidOpenBroadcastApp.launchApp();
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(mobcrushButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			AndroidOpenBroadcastApp.launchApp("com.mobcrush.mobcrush");
		});
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		broadcast.gameObject.transform.parent.gameObject.SetActive(value: false);
		androidBroadcast.gameObject.SetActive(Recording.canBroadcast);
		ShowHideVideoWarning(open: false);
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
