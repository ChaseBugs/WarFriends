using UnityEngine;

public class CardScoreStreakKiller : Card
{
	private const string ingameIcoName = "game-card-ico-crateblocker";

	public float scoreBoosterMultiplier = 0.8f;

	public float buffTime = 60f;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private bool mCanChange;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetEnemyOf(fraction);
		mPlayer.cardIconIndicator.Show("game-card-ico-crateblocker", show: true);
		UseCardInternal();
		mCanChange = true;
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetEnemyOf(fraction);
		UseCardInternal();
		mCanChange = false;
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
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-crateblocker", mRemainingTime / buffTime);
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
			mPlayer.cardIconIndicator.Show("game-card-ico-crateblocker", show: false);
		}
	}
}
