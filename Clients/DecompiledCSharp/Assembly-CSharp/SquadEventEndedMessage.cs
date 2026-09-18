using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadEventEndedMessage : DatabaseMessage
{
	public int currentTier;

	public int maxTiers;

	public override bool processNextMessage => true;

	public SquadEventEndedMessage(int tierNumber, int tierMax)
		: base("testingideventended", Type.WelcomBackSoldierMessage)
	{
		messageId += tierNumber;
		currentTier = tierNumber;
		maxTiers = tierMax;
	}

	public SquadEventEndedMessage(JToken dict)
		: base(dict)
	{
		currentTier = dict["CurrentTier"]["N"].ToObject<int>();
		maxTiers = dict["MaxTiers"]["N"].ToObject<int>();
		Debug.Log("Squad Event Ended. Squad completed " + currentTier + " / " + maxTiers);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		Confirm();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadEventEnded(messageType, messageTime, currentTier, maxTiers);
		return null;
	}

	public override void Confirm()
	{
		Ignore();
	}
}
