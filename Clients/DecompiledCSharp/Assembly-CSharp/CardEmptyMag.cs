public class CardEmptyMag : Card
{
	private const string ingameIcoName = "game-card-ico-emptymag";

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		enemyOf.cardIconIndicator.Show("game-card-ico-emptymag", 3f, 3f, animated: false);
		enemyOf.weaponInventory.usedWeapons[0].weapon.ammoLeftInClip = 0;
		enemyOf.weaponInventory.usedWeapons[0].weapon.Reload();
	}
}
