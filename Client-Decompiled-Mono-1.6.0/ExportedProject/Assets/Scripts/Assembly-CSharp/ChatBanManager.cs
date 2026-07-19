using UnityEngine;

public class ChatBanManager : DatabaseSerializedObjectGeneric<ChatBanManager.ChatBanData>
{
	public class ChatBanData
	{
		public int timestamp;

		public bool forever;

		public bool IsChatBanned(int currentTimestamp)
		{
			if (forever)
			{
				return true;
			}
			if (currentTimestamp < timestamp)
			{
				return true;
			}
			return false;
		}
	}

	private static ChatBanManager mInstance;

	public static ChatBanManager instance
	{
		get
		{
			mInstance = mInstance ?? ((ChatBanManager)Object.FindObjectsOfType(typeof(ChatBanManager))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	public bool IsChatBanned(int currentTimestamp)
	{
		return data != null && data.IsChatBanned(currentTimestamp);
	}

	internal void BanPlayerFromChat(int timestamp)
	{
		data.timestamp = timestamp;
	}

	public int RemainingBanTime()
	{
		int num = data.timestamp - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		return (num >= 0) ? num : 0;
	}

	public bool IsBannedForever()
	{
		return data.forever;
	}

	internal void BanPlayerFromChat()
	{
		data.forever = true;
	}
}
