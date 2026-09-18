using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardShiedlsRefection : Card
{
	private const string ingameIcoName = "game-card-ico-shieldsup";

	private float mRemainingTime;

	private bool mUsed;

	private Fractions mFraction;

	private List<Shield> mShields;

	public float timeInSeconds => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShiedlsRefectionTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.PrintableTimeDescription(timeInSeconds));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (mShields == null)
		{
			mShields = new List<Shield>();
		}
		else
		{
			mShields.Clear();
		}
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == fraction)
			{
				Shield shield = item.point.shield;
				mShields.Add(shield);
				shield.isImmortal = true;
				shield.cardIconIndicator.Show("game-card-ico-shieldsup", show: true);
			}
		}
		mFraction = fraction;
		mRemainingTime = timeInSeconds;
		mUsed = true;
		cardManager.CardWasUsed(this, fraction);
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
				mShields[i].cardIconIndicator.UpdateIndicator("game-card-ico-shieldsup", fract);
			}
			return;
		}
		mRemainingTime = 0f;
		mUsed = false;
		for (int j = 0; j < mShields.Count; j++)
		{
			mShields[j].isImmortal = false;
			mShields[j].cardIconIndicator.Show("game-card-ico-shieldsup", show: false);
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
