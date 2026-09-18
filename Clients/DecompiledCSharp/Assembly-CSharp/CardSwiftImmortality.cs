using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardSwiftImmortality : Card
{
	private const string ingameIcoName = "game-card-ico-swiftimmortality";

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SwiftImmortalityTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.PrintableTimeDescription(buffTime));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mPlayer.isImmortal = true;
		mRemainingTime = buffTime;
		mUsed = true;
		mPlayer.cardIconIndicator.Show("game-card-ico-swiftimmortality", show: true);
		cardManager.CardWasUsed(this, fraction);
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-swiftimmortality", mRemainingTime / buffTime);
				return;
			}
			mPlayer.isImmortal = false;
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-swiftimmortality", show: false);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (botHealthRatio >= 0.2f)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
