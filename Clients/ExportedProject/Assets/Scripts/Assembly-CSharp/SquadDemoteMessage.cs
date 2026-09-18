using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadDemoteMessage : DatabaseMessage
{
	public int newRank;

	public DatabasePlayer demotedPlayer;

	public DatabasePlayer adminPlayer;

	public bool playerClicked;

	public string squadNameKickedFrom;

	public List<string> cardList;

	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public override bool canSquadTypeMessageBeRemovedWhenLeftSquad
	{
		get
		{
			bool flag = demotedPlayer.id == GameLoginManager.currentPlayer.id && newRank == -1;
			return !flag;
		}
	}

	public SquadDemoteMessage(DatabasePlayer player, int newRankForPlayer, DatabasePlayer byPlayer)
		: base($"DemoteOrKickPlayer {newRankForPlayer} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.SquadDemotion)
	{
		Debug.Log($"Fake DatabaseMessage - SquadDemoteMessage - Player:{player.debugBasicInformation}\t\tNewRank:{newRankForPlayer}");
		playerClicked = true;
		demotedPlayer = player;
		newRank = newRankForPlayer;
		adminPlayer = byPlayer;
		squadNameKickedFrom = adminPlayer.squadName;
	}

	public SquadDemoteMessage(DatabasePlayer player, DatabasePlayer byPlayer)
		: base($"DemoteOrKickPlayer {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.SquadDemotion)
	{
		Debug.Log(string.Format("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}", (player != null) ? player.debugBasicInformation : "null"));
		playerClicked = true;
		demotedPlayer = player;
		adminPlayer = byPlayer;
		squadNameKickedFrom = adminPlayer.squadName;
		if (player != null)
		{
			newRank = (int)player.squadRank;
		}
	}

	public SquadDemoteMessage(JToken dict)
		: base(dict)
	{
		playerClicked = false;
		demotedPlayer = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			demotedPlayer.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			demotedPlayer.level = StringParser.ParseIntToken(dict["Level"]["N"]);
		}
		if (dict["SquadId"] != null)
		{
			demotedPlayer.squadName = StringParser.ParseString("SquadId", "S", dict, string.Empty);
		}
		if (dict["KickedPlayerId"] != null)
		{
			demotedPlayer.id = StringParser.ParseString("KickedPlayerId", "S", dict, string.Empty);
		}
		if (dict["DemotedPlayerId"] != null)
		{
			demotedPlayer.id = StringParser.ParseString("DemotedPlayerId", "S", dict, string.Empty);
		}
		if (dict["SquadKickedFrom"] != null)
		{
			squadNameKickedFrom = StringParser.ParseString("SquadKickedFrom", "S", dict, string.Empty);
		}
		if (dict["SquadRank"] != null)
		{
			demotedPlayer.squadRank = (SquadRank)StringParser.ParseIntToken(dict["SquadRank"]["N"]);
			newRank = (int)demotedPlayer.squadRank;
		}
		else
		{
			newRank = -1;
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
		if (dict["KickedPlayerDepositedCards"] != null && demotedPlayer.id == GameLoginManager.currentPlayer.id && newRank == -1)
		{
			Debug.Log("Got kicked player deposited WarCards => pasing them to GameLoginManager");
			cardList = JsonConvert.DeserializeObject<List<string>>(StringParser.ParseString("KickedPlayerDepositedCards", "S", dict, string.Empty));
		}
	}

	public override void Show()
	{
		base.Show();
		Debug.Log($"DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {demotedPlayer.debugBasicInformation}\nNewRank: {newRank}\nBy Player: {adminPlayer.debugBasicInformation}");
		bool flag = adminPlayer.id == GameLoginManager.currentPlayer.id;
		bool flag2 = demotedPlayer.id == GameLoginManager.currentPlayer.id && newRank == -1;
		bool flag3 = messageTime + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > messageTime;
		bool flag5 = GameLoginManager.currentPlayer.squadName == squadNameKickedFrom;
		if (newRank == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.chatContent.AddDatabaseMessageToSquadChat(this, !flag);
				}
			}
			else if (!playerClicked && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.chatContent.AddDatabaseMessageToSquadChat(this, !flag);
		}
		else if (!playerClicked && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
		if (!playerClicked)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(cardList);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
			}
			if (!flag2)
			{
				Confirm();
			}
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadDemotion(messageType, messageTime, newRank, demotedPlayer, adminPlayer);
		return delegate
		{
			if (demotedPlayer.id == GameLoginManager.currentPlayer.id && newRank == -1)
			{
				OverrideConfirm();
			}
			else
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
			}
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (demotedPlayer.id == player.id)
		{
			demotedPlayer.level = player.level;
			demotedPlayer.squadName = player.squadName;
		}
	}

	public override void Confirm()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = messageTime + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogError(string.Format("Removing squad demote/kick message - message time:{0}, server time:{1}, isInSquad:{2}", MiscTools.PrintableTime(messageTime, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag));
			OverrideConfirm();
		}
	}

	private void OverrideConfirm()
	{
		Ignore();
	}
}
