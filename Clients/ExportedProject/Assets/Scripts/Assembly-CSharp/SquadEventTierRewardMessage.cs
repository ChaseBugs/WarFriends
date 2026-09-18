using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadEventTierRewardMessage : DatabaseMessage
{
	public int tier;

	public int reward;

	public string squadId;

	public override bool processNextMessage => true;

	public SquadEventTierRewardMessage(int tierNumber, int goldReward)
		: base("testingideventtierreward", Type.SquadEventTierReward)
	{
		messageId += tierNumber;
		tier = tierNumber;
		reward = goldReward;
	}

	public SquadEventTierRewardMessage(JToken dict)
		: base(dict)
	{
		tier = dict["Tier"]["N"].ToObject<int>();
		squadId = dict["SquadId"]["S"].ToObject<string>();
		reward = dict["Reward"]["N"].ToObject<int>();
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadEventTierReward(messageType, messageTime, tier + 1, reward);
		return delegate
		{
			Debug.Log("Claiming reward " + reward + " Golds for squad event - completed tier " + tier);
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", reward);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Claim_Reward");
			Confirm();
		};
	}

	public override void Confirm()
	{
		Singleton<BeanstalkServerManager>.instance.ClaimReward(this);
	}
}
