public class CardCopycat : Card
{
	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}
}
