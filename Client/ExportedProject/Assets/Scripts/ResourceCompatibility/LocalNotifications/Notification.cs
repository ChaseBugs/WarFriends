using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace LocalNotifications
{
	[Serializable]
	[Preserve]
	public class Notification
	{
		[JsonProperty]
		public readonly string key;

		[JsonProperty]
		public readonly string templateKey;

		[JsonProperty]
		public int platformSpecificId;

		[JsonProperty]
		public readonly string message;

		[JsonProperty]
		public readonly string extraData;

		[JsonProperty]
		public int displayTime;

		[JsonProperty]
		public readonly int requestedDisplayTime;

		private Notification()
		{
		}

		public Notification(string PLCGDEHGHIO, string MALPKDOCIEL, int HAFNMEAJDKC, string NNCFCHPCADD, string OBMEMHJNKCB)
		{
		}
	}
}
