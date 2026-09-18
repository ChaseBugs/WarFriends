using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class InformSquadLeaderAboutEvent : DatabaseMessage
{
	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public InformSquadLeaderAboutEvent()
		: base("InformSquadLeader", Type.InformSquadLeaderAboutEvent)
	{
	}

	public InformSquadLeaderAboutEvent(JToken dict)
		: base(dict)
	{
		Debug.Log("Message Inform Squad Leader About Event came");
	}

	public override void Show()
	{
		base.Show();
		Debug.Log("Showing Inform Squad Leader About Event in Notification center");
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		Confirm();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_InformSquadLeader(messageType, messageTime);
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
