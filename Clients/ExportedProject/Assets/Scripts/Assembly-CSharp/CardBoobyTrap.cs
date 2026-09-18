public class CardBoobyTrap : Card
{
	public const string ingameIconName = "game-card-ico-boobytrap";

	public override bool showInGame => false;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		Singleton<KillStreakManager>.instance.BoobyTrapSet(allowed: true, fraction);
		cardManager.CardWasUsed(this, fraction);
	}
}
