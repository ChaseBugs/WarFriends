using Newtonsoft.Json.Linq;

internal class NewSquadJoinRequest : DatabaseMessage
{
	public override bool processNextMessage => true;

	public NewSquadJoinRequest(JToken dict)
		: base(dict)
	{
	}

	public override void Show()
	{
		base.Show();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
		}
		Ignore();
	}
}
