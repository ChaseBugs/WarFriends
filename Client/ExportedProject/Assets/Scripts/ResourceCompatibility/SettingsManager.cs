using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

public class SettingsManager : DatabaseSerializedObjectGeneric<SettingsManager.Settings>
{
	[Preserve]
	public class Settings
	{
		public bool challenge;

		public bool squadStatus;

		public bool squadEvents;

		public bool maintenance;

		public bool playerLeague;

		public bool dailyRewardNotification;

		public NotificationSettingType Setting;
	}

	[Flags]
	public enum NotificationSettingType
	{
		None = 0,
		DailyReward = 1,
		Upgrades = 2,
		Dogtags = 4,
		Events = 8,
		PlayerLeague = 0x10,
		Challenge = 0x20,
		Skirmish = 0x40,
		Warcards = 0x80,
		Missions = 0x100,
		SquadActions = 0x200,
		SquadCardpool = 0x400,
		Boosters = 0x800,
		All = 0xFFF,
		Always = 0x1000
	}

	private static readonly Dictionary<NotificationSettingType, string> mNotifSettingsTitles;

	private static readonly Dictionary<NotificationSettingType, string> mNotifSettingsDescriptions;

	private static SettingsManager mInstance;

	private bool mShouldUpdateServer;

	public static SettingsManager instance => null;

	public bool challenge
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool squadStatus
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool squadEvents
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool maintenance
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool dailyRewardNotification
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool playerLeague
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public NotificationSettingType NotificationSettings
	{
		get
		{
			return default(NotificationSettingType);
		}
		set
		{
		}
	}

	public void OnDestroy()
	{
	}

	public bool IsNotificationEnabled(NotificationSettingType type)
	{
		return false;
	}

	public static string GetTitleIdForSetting(NotificationSettingType setting)
	{
		return null;
	}

	public static string GetDescriptionIdForSetting(NotificationSettingType setting)
	{
		return null;
	}

	protected override void Load(JToken dictionary)
	{
	}

	protected override void LoadEmpty()
	{
	}

	protected override void Awake()
	{
	}

	private void OnDataLoaded(DatabaseAction action)
	{
	}

	internal void SendChangesToServer()
	{
	}
}
