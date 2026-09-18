using System;
using System.Collections.Generic;
using UnityEngine;

public class CardShieldDestroyer : Card
{
	private const string ingameIcoName = "game-card-ico-shielddestroyer";

	private List<PlayerPoint> mPlayerPoints;

	private void DestroyRandomShield(Fractions callerFraction)
	{
		mPlayerPoints = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != callerFraction)
			{
				mPlayerPoints.Add(item.point);
			}
		}
		if (mPlayerPoints.Count != 0)
		{
			float num = UnityEngine.Random.Range(0f, mPlayerPoints.Count - 1);
			int index = (int)Math.Round(num, 0);
			mPlayerPoints[index].shield.DestroyShield();
			mPlayerPoints[index].shield.cardIconIndicator.Show("game-card-ico-shielddestroyer", 3f, 3f, animated: false);
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DestroyRandomShield(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			DestroyRandomShield(fraction);
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
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
