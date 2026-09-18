using System;
using Google2u;

public class LikeUsOnFacebook : DatabaseMessage
{
	public override bool processNextMessage => true;

	public LikeUsOnFacebook()
		: base("LikeUsOnFacebook", Type.LikeUsOnFacebook)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		int goldNumber = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).FLOATVALUE;
		record.SetAppearance_GenericGetFreeGoldWithSocial(messageType, messageTime, goldNumber);
		return delegate
		{
			Singleton<Tweetmanager>.instance.likeUsOnFacebook();
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
			Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		};
	}
}
