using UnityEngine;

public class CardBulletSponge : Card
{
	private const string ingameIcoName = "game-card-ico-bulletsponge-full";

	private const float timeInSeconds = 60f;

	private const float noDamageChance = 0.05f;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mPlayer.SetNoDamageChance(0.05f);
		mRemainingTime = 60f;
		mUsed = true;
		mPlayer.cardIconIndicator.Show("game-card-ico-bulletsponge-full", show: true);
		cardManager.CardWasUsed(this, fraction);
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-bulletsponge-full", mRemainingTime / 60f);
				return;
			}
			mPlayer.SetNoDamageChance(0f);
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-bulletsponge-full", show: false);
		}
	}
}
