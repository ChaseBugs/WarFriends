public class ElitePackTimeLimitedOffer : DatabaseMessage
{
	public string packId;

	public ElitePackTimeLimitedOffer(string elitePackId)
		: base("TimeLimitedOffer", Type.TimeLimitedOffer)
	{
		packId = elitePackId;
		messageId += $"-{packId}";
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(SpecialPackContent.CreatePackFromId(packId));
	}
}
