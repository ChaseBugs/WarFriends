public class CardpoolTutorialMessage : DatabaseMessage
{
	public CardpoolTutorialMessage()
		: base("CardpoolTutorialMessage", Type.CardpoolTutorialMessage)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<CardpoolTutorialDialog>.instance.ShowDialog();
	}
}
