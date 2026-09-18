using Google2u;
using UnityEngine;

public class CardBrokenLegs : Card
{
	private const string ingameIcoName = "game-card-ico-paralyzethese";

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private float mBuffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.PrintableTimeDescription(mBuffTime));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetEnemyOf(fraction);
		mPlayer.movingFreeze = true;
		mRemainingTime = mBuffTime;
		mUsed = true;
		mPlayer.cardIconIndicator.Show("game-card-ico-paralyzethese", show: true);
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-paralyzethese", mRemainingTime / mBuffTime);
				return;
			}
			mPlayer.movingFreeze = false;
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-paralyzethese", show: false);
		}
	}
}
