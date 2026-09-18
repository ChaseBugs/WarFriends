using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadPromoteMessage : DatabaseMessage
{
	public int newRank;

	public DatabasePlayer promotedPlayer;

	public DatabasePlayer adminPlayer;

	public bool playerClicked;

	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public SquadPromoteMessage(DatabasePlayer player, DatabasePlayer byPlayer)
		: base($"SquadPromoteMessage {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.SquadPromotion)
	{
		playerClicked = true;
		promotedPlayer = player;
		adminPlayer = byPlayer;
		if (player != null)
		{
			newRank = Mathf.Clamp((int)player.squadRank, 0, 2);
		}
	}

	public SquadPromoteMessage(JToken dict)
		: base(dict)
	{
		playerClicked = false;
		promotedPlayer = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			promotedPlayer.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			promotedPlayer.level = StringParser.ParseIntToken(dict["Level"]["N"]);
		}
		if (dict["SquadId"] != null)
		{
			promotedPlayer.squadName = StringParser.ParseString("SquadId", "S", dict, string.Empty);
		}
		if (dict["SquadRank"] != null)
		{
			promotedPlayer.squadRank = (SquadRank)StringParser.ParseIntToken(dict["SquadRank"]["N"]);
			newRank = (int)promotedPlayer.squadRank;
		}
		if (dict["PromotedPlayerId"] != null)
		{
			promotedPlayer.id = StringParser.ParseString("PromotedPlayerId", "S", dict, string.Empty);
		}
		adminPlayer = new DatabasePlayer();
		if (dict["AdminName"] != null)
		{
			adminPlayer.accountName = StringParser.ParseString("AdminName", "S", dict, string.Empty);
		}
		if (dict["AdminId"] != null)
		{
			adminPlayer.id = StringParser.ParseString("AdminId", "S", dict, string.Empty);
		}
		if (dict["AdminLevel"] != null)
		{
			adminPlayer.level = StringParser.ParseIntToken(dict["AdminLevel"]["N"]);
		}
	}

	public override void Show()
	{
		base.Show();
		bool flag = adminPlayer.id == GameLoginManager.currentPlayer.id;
		Debug.Log(string.Format("Player promoted - database informations:\nName:{0} Level:{1} SquadId:{2} SquadRank:{3}", (promotedPlayer.accountName != null) ? promotedPlayer.accountName : "null", promotedPlayer.level, (promotedPlayer.squadName != null) ? promotedPlayer.squadName : "null", promotedPlayer.squadRank));
		if (promotedPlayer.squadRank == SquadRank.Member)
		{
			Debug.LogError("Promoting to MEMBER!!!! should be JOINED MESSAGE");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.chatContent.AddDatabaseMessageToSquadChat(this, !flag);
		}
		else if (!playerClicked && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
		if (!playerClicked)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
			}
			Confirm();
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadPromotion(messageType, messageTime, newRank, promotedPlayer);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (promotedPlayer.id == player.id)
		{
			promotedPlayer.level = player.level;
		}
	}

	public override void Confirm()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = messageTime + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogError(string.Format("Removing squad promote message - message time:{0}, server time:{1}, isInSquad:{2}", MiscTools.PrintableTime(messageTime, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag));
			Ignore();
		}
	}
}
