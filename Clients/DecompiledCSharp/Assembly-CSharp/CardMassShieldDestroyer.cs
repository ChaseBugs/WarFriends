using System.Collections.Generic;
using UnityEngine;

public class CardMassShieldDestroyer : Card
{
	private const string ingameIcoName = "game-card-ico-shielddestroyer";

	public int shieldCount;

	private List<PlayerPoint> mPlayerPoints;

	private void DestroyEnemyShields(Fractions callerFraction)
	{
		mPlayerPoints = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != callerFraction && item.point.shield.health > 0f)
			{
				mPlayerPoints.Add(item.point);
			}
		}
		int num = shieldCount;
		while (mPlayerPoints.Count > 0 && num > 0)
		{
			int index = Random.Range(0, mPlayerPoints.Count);
			Shield shield = mPlayerPoints[index].shield;
			mPlayerPoints.RemoveAt(index);
			shield.DestroyShield();
			shield.cardIconIndicator.Show("game-card-ico-shielddestroyer", 3f, 3f, animated: false);
			num--;
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DestroyEnemyShields(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			DestroyEnemyShields(fraction);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition availablePoint in Singleton<MapManager>.instance.currentMapDef.availablePoints)
		{
			if (availablePoint.fraction != botFraction && availablePoint.point.shield.healthRatio > 0f)
			{
				num++;
			}
		}
		if (num <= 2)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
