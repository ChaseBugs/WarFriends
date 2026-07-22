using WarFriends.Legacy;

public class LastLoginSaver : InGameSerializedObjectGeneric<LastLoginSaver.SaveData>
{
	public class SaveData
	{
		public string lastLogin;
	}

	private static LastLoginSaver mInstance;

	public static LastLoginSaver instance
	{
		get
		{
			mInstance = mInstance ?? ((LastLoginSaver)SingletonSupport.FindOrCreate(typeof(LastLoginSaver)));
			return mInstance;
		}
	}

	public string lastLoginName
	{
		get
		{
			return (!string.IsNullOrEmpty(data.lastLogin)) ? data.lastLogin : string.Empty;
		}
		set
		{
			if (!value.Contains("Warfriend"))
			{
				data.lastLogin = value;
				Save();
			}
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}
}
