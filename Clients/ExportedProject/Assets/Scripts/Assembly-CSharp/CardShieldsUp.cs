using System.Collections.Generic;
using Google2u;

public class CardShieldsUp : Card
{
	private const string ingameIcoName = "game-card-ico-shieldsup";

	public float multiplierShieldHealth => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShieldsUpCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(multiplierShieldHealth));

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
		float maxHealth = list[0].shield.maxHealth * (1f + multiplierShieldHealth);
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.maxHealth = maxHealth;
			item2.shield.Sync();
			item2.shield.cardIconIndicator.Show("game-card-ico-shieldsup", 3f, 3f, animated: false);
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
