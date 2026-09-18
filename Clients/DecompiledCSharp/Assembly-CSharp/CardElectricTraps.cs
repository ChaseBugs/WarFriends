using System.Collections.Generic;

public class CardElectricTraps : Card
{
	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == fraction)
			{
				item.point.electricTrap.SetTrap(visible: true);
			}
		}
		cardManager.CardWasUsed(this, fraction);
	}
}
