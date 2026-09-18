using System;

public class BeAdvisedJoinOrCreateSquad : DatabaseMessage
{
	public override bool canBeClickedInLobby => false;

	public BeAdvisedJoinOrCreateSquad()
		: base("BeAdvisedJoinOrCreateSquad", Type.BeAdvisedJoinOrCreateSquad)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<JoinOrCreateSquadDialog>.instance.ShowDialog();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_BeAdvisedJoinOrCreateSquad(messageType, messageTime);
		return delegate
		{
			GuiElementSingle<JoinOrCreateSquadDialog>.instance.ShowDialog();
		};
	}
}
