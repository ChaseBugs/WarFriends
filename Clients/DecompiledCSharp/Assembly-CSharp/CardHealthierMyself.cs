public class CardHealthierMyself : Card
{
	private const string ingameIcoName = "game-card-ico-supersoldiers";

	public float multiplierMaxHealth = 1.15f;

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(multiplierMaxHealth - 1f);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		float healAmount = playerOld.destroyableParts.maxHealth * (multiplierMaxHealth - 1f);
		playerOld.destroyableParts.maxHealth *= multiplierMaxHealth;
		playerOld.destroyableParts.Heal(healAmount, isNetworkCopy: false);
		playerOld.destroyableParts.Sync();
		cardManager.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.Show("game-card-ico-supersoldiers", 3f, 3f, animated: false);
	}
}
