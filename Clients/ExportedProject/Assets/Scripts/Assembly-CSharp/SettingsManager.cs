using Beebyte.Obfuscator;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class SettingsManager : DatabaseSerializedObjectGeneric<SettingsManager.Settings>
{
	[Skip]
	public class Settings
	{
		public bool challenge;

		public bool squadStatus;

		public bool squadEvents;

		public bool maintenance;

		public bool playerLeague;

		public bool dailyRewardNotification;
	}

	private static SettingsManager mInstance;

	private bool mShouldUpdateServer;

	public static SettingsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((SettingsManager)Object.FindObjectsOfType(typeof(SettingsManager))[0]);
			return mInstance;
		}
	}

	public bool challenge
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.challenge;
		}
		set
		{
			mShouldUpdateServer = true;
			data.challenge = value;
		}
	}

	public bool squadStatus
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.squadStatus;
		}
		set
		{
			mShouldUpdateServer = true;
			data.squadStatus = value;
		}
	}

	public bool squadEvents
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.squadEvents;
		}
		set
		{
			mShouldUpdateServer = true;
			data.squadEvents = value;
		}
	}

	public bool maintenance
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.maintenance;
		}
		set
		{
			mShouldUpdateServer = true;
			data.maintenance = value;
		}
	}

	public bool dailyRewardNotification
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.dailyRewardNotification;
		}
		set
		{
			mShouldUpdateServer = true;
			data.dailyRewardNotification = value;
		}
	}

	public bool playerLeague
	{
		get
		{
			return BundleVersionBindings.pushNotificationEnabled && data.playerLeague;
		}
		set
		{
			mShouldUpdateServer = true;
			data.playerLeague = value;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void LoadEmpty()
	{
		base.LoadEmpty();
		data.playerLeague = true;
		data.challenge = true;
		data.squadStatus = true;
		data.dailyRewardNotification = true;
		data.squadEvents = true;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.UpdateSettings)
		{
			mShouldUpdateServer = false;
		}
	}

	internal void OnDialogClose()
	{
		if (mShouldUpdateServer)
		{
			Singleton<BeanstalkServerManager>.instance.UpdateSettings(JsonConvert.SerializeObject(data));
		}
	}
}
