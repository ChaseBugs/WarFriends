using System.Collections.Generic;

public class CardShieldsSpawner : Card
{
	private const string ingameIcoName = "game-card-ico-shieldgenerator";

	public float multiplierRespawnRate = 0.7f;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == fraction)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			cardManager.CardWasUsed(this, fraction);
			return;
		}
		float refreshTime = list[0].shield.refreshTime * multiplierRespawnRate;
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.refreshTime = refreshTime;
			item2.shield.cardIconIndicator.Show("game-card-ico-shieldgenerator", 3f, 3f, animated: false);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
