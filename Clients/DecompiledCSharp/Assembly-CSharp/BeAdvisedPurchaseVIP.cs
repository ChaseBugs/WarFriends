using System;

public class BeAdvisedPurchaseVIP : DatabaseMessage
{
	public BeAdvisedPurchaseVIP()
		: base("BeAdvisedPurchaseVIP", Type.BeAdvisedPurchaseVIP)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_BeAdvisedVIP(messageType, messageTime);
		return delegate
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		};
	}
}
