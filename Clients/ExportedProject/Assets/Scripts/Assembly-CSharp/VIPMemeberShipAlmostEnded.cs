using System;

public class VIPMemeberShipAlmostEnded : DatabaseMessage
{
	public int secondsLeft;

	public VIPMemeberShipAlmostEnded()
		: base("VIPMemeberShipAlmostEnded", Type.VIPMemeberShipAlmostEnded)
	{
		secondsLeft = Singleton<VipManager>.instance.vipExpiration - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public VIPMemeberShipAlmostEnded(int seconds)
		: base("VIPMemeberShipAlmostEnded", Type.VIPMemeberShipAlmostEnded)
	{
		secondsLeft = seconds;
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ReminderDialog>.instance.ShowDialog(ReminderDialog.ReminderTypes.VIPAlmostExpired, delegate
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		});
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_VIPAlmostEnded(messageType, messageTime, secondsLeft);
		return delegate
		{
			GuiElementSingle<ReminderDialog>.instance.ShowDialog(ReminderDialog.ReminderTypes.VIPAlmostExpired, delegate
			{
				GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
			});
		};
	}
}
