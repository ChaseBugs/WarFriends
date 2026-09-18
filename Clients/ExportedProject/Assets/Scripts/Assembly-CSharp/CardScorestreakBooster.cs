using UnityEngine;

public class CardScorestreakBooster : Card
{
	private const string ingameIcoName = "game-card-ico-streakboost-full";

	public float scoreBoosterMultiplier = 1.25f;

	public float buffTime = 60f;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private bool mCanChange;

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(scoreBoosterMultiplier - 1f);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mPlayer.cardIconIndicator.Show("game-card-ico-streakboost-full", show: true);
		UseCardInternal();
		mCanChange = true;
		cardManager.CardWasUsed(this, fraction);
	}

	private void UseCardInternal()
	{
		if (mPlayer.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = scoreBoosterMultiplier;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = scoreBoosterMultiplier;
		}
		mRemainingTime = buffTime;
		mUsed = true;
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		UseCardInternal();
		mCanChange = false;
	}

	public override void DisconnectEvents()
	{
		if (mUsed)
		{
			mRemainingTime = 0f;
		}
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
			if (mCanChange)
			{
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-streakboost-full", mRemainingTime / buffTime);
			}
			return;
		}
		if (mPlayer.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 1f;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = 1f;
		}
		mRemainingTime = 0f;
		mUsed = false;
		if (mCanChange)
		{
			mPlayer.cardIconIndicator.Show("game-card-ico-streakboost-full", show: false);
		}
	}
}
