using System;

public class TweetAboutWarfriends : DatabaseMessage
{
	public override bool processNextMessage => true;

	public TweetAboutWarfriends()
		: base("TweetAboutWarfriends", Type.TweetAboutWarfriends)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_GenericGetFreeGoldWithSocial(messageType, messageTime, 0);
		return null;
	}
}
