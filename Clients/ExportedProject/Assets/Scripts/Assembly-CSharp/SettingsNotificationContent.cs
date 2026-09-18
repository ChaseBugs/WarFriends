using System;
using UnityEngine;

public class SettingsNotificationContent : Core_BaseScript
{
	[Header("Core")]
	public SettingsNotificationButton notification1Button;

	public SettingsNotificationButton notification2Button;

	public SettingsNotificationButton notification3Button;

	public SettingsNotificationButton notification4Button;

	public SettingsNotificationButton notification5Button;

	public SettingsNotificationButton notification6Button;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(notification1Button.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.playerLeague = !SettingsManager.instance.playerLeague;
				notification1Button.SetHighlight(SettingsManager.instance.playerLeague);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(notification2Button.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
				notification2Button.SetHighlight(SettingsManager.instance.challenge);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(notification3Button.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
				notification3Button.SetHighlight(SettingsManager.instance.squadStatus);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(notification4Button.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
				notification4Button.SetHighlight(SettingsManager.instance.dailyRewardNotification);
			}
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(notification5Button.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
				notification5Button.SetHighlight(SettingsManager.instance.maintenance);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(notification6Button.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DoNotChangeNotificationSetting())
			{
				SettingsManager.instance.squadEvents = !SettingsManager.instance.squadEvents;
				notification6Button.SetHighlight(SettingsManager.instance.squadEvents);
			}
		});
	}

	private bool DoNotChangeNotificationSetting()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return false;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.fadeOutTime))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.fadeOutTime);
		}
		return true;
	}

	public void InitGUIValues()
	{
		notification1Button.SetHighlight(SettingsManager.instance.playerLeague);
		notification2Button.SetHighlight(SettingsManager.instance.challenge);
		notification3Button.SetHighlight(SettingsManager.instance.squadStatus);
		notification4Button.SetHighlight(SettingsManager.instance.dailyRewardNotification);
		notification5Button.SetHighlight(SettingsManager.instance.maintenance);
		if (notification6Button.gameObject.activeSelf)
		{
			notification6Button.SetHighlight(SettingsManager.instance.squadEvents);
		}
	}
}
