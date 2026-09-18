using System;
using Google2u;

public class FollowUsOnTwitter : DatabaseMessage
{
	public FollowUsOnTwitter()
		: base("FollowUsOnTwitter", Type.FollowUsOnTwitter)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		int goldNumber = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE;
		record.SetAppearance_GenericGetFreeGoldWithSocial(messageType, messageTime, goldNumber);
		return delegate
		{
			Singleton<Tweetmanager>.instance.FollowAs();
		};
	}
}
