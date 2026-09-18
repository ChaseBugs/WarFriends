using Google2u;
using UnityEngine;

public class CardBelovedEnemy : Card
{
	private const string ingameIcoName = "game-card-ico-belovedenemy";

	private float mRemainingTime;

	private bool mUsed;

	private float mSavedSpeed = 1f;

	private PlayerController mPlayer;

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemyTime).FLOATVALUE;

	private float mSlowedSpeed => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemySpeed).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(mSlowedSpeed), MiscTools.PrintableTimeDescription(buffTime));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetEnemyOf(fraction);
		mPlayer.cardIconIndicator.Show("game-card-ico-belovedenemy", show: true);
		mSavedSpeed = mPlayer.speed;
		mPlayer.speed = mSlowedSpeed;
		mRemainingTime = buffTime;
		mUsed = true;
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-belovedenemy", mRemainingTime / buffTime);
				return;
			}
			mPlayer.speed = mSavedSpeed;
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-belovedenemy", show: false);
		}
	}
}
