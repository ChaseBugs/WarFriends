using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadLevelUpMessage : DatabaseMessage
{
	public int level;

	public string squadId;

	public override bool processNextMessage => true;

	public SquadLevelUpMessage(int newLevel)
		: base("testingidsquadrankup", Type.SquadLevelUp)
	{
		messageId += newLevel;
		level = newLevel;
		squadId = GameLoginManager.currentPlayer.squadName;
	}

	public SquadLevelUpMessage(JToken dict)
		: base(dict)
	{
		level = dict["Level"]["N"].ToObject<int>();
		squadId = dict["SquadId"]["S"].ToObject<string>();
	}

	public override void Show()
	{
		base.Show();
		Debug.Log("Show squad " + squadId + " leveled up to " + level);
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(squadId))
		{
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(squadId, checkCache: false);
		}
		Confirm();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadLevelUp(messageType, messageTime, level + 1);
		return null;
	}

	public override void Confirm()
	{
		Ignore();
	}
}
