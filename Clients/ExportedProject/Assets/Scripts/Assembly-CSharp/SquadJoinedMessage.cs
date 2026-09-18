using System;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class SquadJoinedMessage : DatabaseMessage
{
	public string squadId;

	public DatabasePlayer newMember;

	public bool isSquadPrivate;

	public bool wasAcceptedFromRequest;

	public long goldReward;

	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public SquadJoinedMessage(bool isMe)
		: base("testingidsquadjoined", Type.SquadJoined)
	{
		if (isMe)
		{
			newMember = GameLoginManager.currentPlayer;
			wasAcceptedFromRequest = true;
			isSquadPrivate = true;
			messageId += newMember.id;
		}
		else
		{
			newMember = new DatabasePlayer();
			newMember.accountName = "Testing Player";
			newMember.level = 6;
			newMember.squadName = "Squad";
			newMember.id = "newMember";
			messageId += newMember.id;
		}
	}

	public SquadJoinedMessage(JToken dict)
		: base(dict)
	{
		newMember = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			newMember.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			newMember.level = StringParser.ParseIntToken(dict["Level"]["N"]);
		}
		if (dict["SquadId"] != null)
		{
			newMember.squadName = StringParser.ParseString("SquadId", "S", dict, string.Empty);
		}
		squadId = newMember.squadName;
		if (dict["NewPlayerMemberId"] != null)
		{
			newMember.id = StringParser.ParseString("NewPlayerMemberId", "S", dict, string.Empty);
		}
		if (dict["SquadRank"] != null)
		{
			newMember.squadRank = (SquadRank)StringParser.ParseIntToken(dict["SquadRank"]["N"]);
		}
		if (dict["Gold"] != null)
		{
			goldReward = StringParser.ParseLongToken(dict["Gold"]["N"], 0L);
		}
		if (dict["SquadIsPrivate"] != null)
		{
			isSquadPrivate = true;
		}
		if (dict["AcceptedFromRequest"] != null)
		{
			wasAcceptedFromRequest = true;
		}
	}

	public override void Show()
	{
		base.Show();
		Debug.Log("Player " + newMember.name + " succesfully joined squad " + squadId);
		if (wasAcceptedFromRequest)
		{
			Debug.Log("Player was accepted to squad via Squad Join Request!");
		}
		bool flag = newMember.id == GameLoginManager.currentPlayer.id;
		bool flag2 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag3 = flag && isSquadPrivate && wasAcceptedFromRequest;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > messageTime;
		if (flag && !string.IsNullOrEmpty(squadId) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(squadId, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).DBKEY;
			if (goldReward > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.AddGoldReward(goldReward);
				Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, goldReward));
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.chatContent.AddDatabaseMessageToSquadChat(this, !flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !base.messageShown)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
		Confirm();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadJoined(messageType, messageTime, newMember);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (newMember.id == player.id)
		{
			newMember.level = player.level;
		}
	}

	public override void Confirm()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = messageTime + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogError(string.Format("Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}", MiscTools.PrintableTime(messageTime, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag));
			Ignore();
		}
	}
}
