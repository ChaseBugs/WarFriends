using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DepositWarcards : DatabaseMessage
{
	public DatabasePlayer player;

	public bool alreadyIgnored;

	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public DepositWarcards(DatabasePlayer playerData)
		: base($"DepositWarcards-{playerData.name}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.DepositWarcards)
	{
		alreadyIgnored = false;
		player = playerData;
	}

	public DepositWarcards(JToken dict)
		: base(dict)
	{
		alreadyIgnored = false;
		player = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			player.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			player.level = StringParser.ParseIntToken(dict["Level"]["N"]);
		}
		if (dict["SquadId"] != null)
		{
			player.squadName = StringParser.ParseString("SquadId", "S", dict, string.Empty);
		}
		if (dict["SquadRank"] != null)
		{
			player.squadRank = (SquadRank)StringParser.ParseIntToken(dict["SquadRank"]["N"]);
		}
		if (dict["AdminPlayerId"] != null)
		{
			player.id = StringParser.ParseString("AdminPlayerId", "S", dict, string.Empty);
		}
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("DEPOSIT WARCARDS MESSAGE!!!");
		}
	}

	public override void OnAdd()
	{
		if (Singleton<MessageManager>.instance.lastDepositWarcardsMessage != null)
		{
			Singleton<MessageManager>.instance.lastDepositWarcardsMessage.Confirm();
		}
		Singleton<MessageManager>.instance.lastDepositWarcardsMessage = this;
	}

	public override void Confirm()
	{
		Ignore();
		alreadyIgnored = true;
	}

	public override void Show()
	{
		base.Show();
		if (!alreadyIgnored)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_DepositWarcards(messageType, messageTime, player);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			Confirm();
		};
	}
}
