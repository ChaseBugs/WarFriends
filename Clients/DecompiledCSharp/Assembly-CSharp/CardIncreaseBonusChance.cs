using System.Collections.Generic;

public class CardIncreaseBonusChance : Card
{
	public KillStreakBonus forBonus;

	public float minimalBotHealth = 0.7f;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		int num = 0;
		List<KillStreakBonus> bonusesPrefabs = Singleton<KillStreakManager>.instance.bonusesPrefabs;
		num = bonusesPrefabs.IndexOf(forBonus);
		Singleton<KillStreakManager>.instance.EnqueueNewBonus(num, fraction);
		cardManager.CardWasUsed(this, fraction);
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (botHealthRatio >= minimalBotHealth)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
