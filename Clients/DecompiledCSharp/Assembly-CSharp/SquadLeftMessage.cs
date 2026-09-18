using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadLeftMessage : DatabaseMessage
{
	public DatabasePlayer playerThatLeft;

	public override bool processNextMessage => true;

	public SquadLeftMessage()
		: base("SquadLeft", Type.SquadLeft)
	{
		playerThatLeft = GameLoginManager.currentPlayer;
	}

	public SquadLeftMessage(JToken dict)
		: base(dict)
	{
		playerThatLeft = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			playerThatLeft.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			playerThatLeft.level = StringParser.ParseInt("Level", "N", dict);
		}
		if (dict["playerId"] != null)
		{
			playerThatLeft.id = StringParser.ParseString("playerId", "S", dict, string.Empty);
		}
	}

	public override void Show()
	{
		base.Show();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.chatContent.AddDatabaseMessageToSquadChat(this);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
			}
		}
		Confirm();
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (playerThatLeft.id == player.id)
		{
			playerThatLeft.level = player.level;
		}
	}

	public override void Confirm()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = messageTime + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogError(string.Format("Removing squad left message - message time:{0}, server time:{1}, isInSquad:{2}", MiscTools.PrintableTime(messageTime, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag));
			Ignore();
		}
	}
}
