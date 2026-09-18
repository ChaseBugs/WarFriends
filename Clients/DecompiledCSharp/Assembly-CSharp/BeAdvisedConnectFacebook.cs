using System;

public class BeAdvisedConnectFacebook : DatabaseMessage
{
	public BeAdvisedConnectFacebook()
		: base("BeAdvisedConnectFacebook", Type.BeAdvisedConnectFacebook)
	{
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LoginToFacebookDialog>.instance, 0f);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_BeAdvisedFacebook(messageType, messageTime);
		return delegate
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LoginToFacebookDialog>.instance, 0f);
		};
	}
}
