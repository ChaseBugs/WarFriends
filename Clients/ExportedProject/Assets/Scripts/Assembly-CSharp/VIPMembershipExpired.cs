using System;
using UnityEngine;

public class VIPMembershipExpired : DatabaseMessage
{
	public override bool processNextMessage => true;

	public VIPMembershipExpired()
		: base("VIPMembershipExpired", Type.VIPMembershipExpired)
	{
		messageTime = Singleton<VipManager>.instance.vipExpiration;
		Debug.Log("Show VIP Expired at " + messageTime);
	}

	public override void Show()
	{
		base.Show();
		if (messageTime > 0)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_VIPExpired(messageType, messageTime);
		return delegate
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowExpired();
		};
	}
}
