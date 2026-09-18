using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadEventEnteredMessage : DatabaseMessage
{
	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public SquadEventEnteredMessage()
		: base("testingidevententered", Type.UnitReadyForPromotion)
	{
	}

	public SquadEventEnteredMessage(JToken dict)
		: base(dict)
	{
		Debug.Log("Squad Entered Event");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(squadName, checkCache: false);
		}
		Confirm();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadEventEntered(messageType, messageTime);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadEvent();
		};
	}

	public override void Confirm()
	{
		Ignore();
	}
}
