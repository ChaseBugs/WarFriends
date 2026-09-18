using System.Collections.Generic;
using UnityEngine;

public class CardShieldGenerator : Card
{
	private const string ingameIcoName = "game-card-ico-shieldgenerator";

	public float timeInSeconds = 3f;

	private List<Shield> mShields = new List<Shield>();

	private float mRemainingTime;

	private bool mUsed;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mShields.Clear();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == fraction)
			{
				item.point.shield.canRegenerate = true;
				item.point.shield.cardIconIndicator.Show("game-card-ico-shieldgenerator", show: true);
				mShields.Add(item.point.shield);
			}
		}
		cardManager.CardWasUsed(this, fraction);
		mRemainingTime = timeInSeconds;
		mUsed = true;
	}

	public override void ReleaseCard(bool isOpponent)
	{
		base.ReleaseCard(isOpponent);
		mUsed = false;
		mShields.Clear();
	}

	protected void Update()
	{
		if (!mUsed)
		{
			return;
		}
		if (mRemainingTime > 0f)
		{
			mRemainingTime -= Time.deltaTime;
			float fract = mRemainingTime / timeInSeconds;
			for (int i = 0; i < mShields.Count; i++)
			{
				mShields[i].cardIconIndicator.UpdateIndicator("game-card-ico-shieldgenerator", fract);
			}
			return;
		}
		mRemainingTime = 0f;
		mUsed = false;
		for (int j = 0; j < mShields.Count; j++)
		{
			mShields[j].canRegenerate = false;
			mShields[j].cardIconIndicator.Show("game-card-ico-shieldgenerator", show: false);
		}
		mShields.Clear();
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
