using Newtonsoft.Json.Linq;
using UnityEngine;

internal class SquadMemberGameEnded : DatabaseMessage
{
	public override bool processNextMessage => true;

	public SquadMemberGameEnded(JToken dict)
		: base(dict)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Message: squad player ended game -> get squad details to sync exp and stats");
		}
	}

	public override void Show()
	{
		base.Show();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(squadName, checkCache: false);
		}
		Ignore();
	}
}
