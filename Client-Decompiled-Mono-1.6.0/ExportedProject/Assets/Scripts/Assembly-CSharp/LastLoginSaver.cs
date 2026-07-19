using UnityEngine;

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
			mInstance = mInstance ?? ((LastLoginSaver)Object.FindObjectsOfType(typeof(LastLoginSaver))[0]);
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
