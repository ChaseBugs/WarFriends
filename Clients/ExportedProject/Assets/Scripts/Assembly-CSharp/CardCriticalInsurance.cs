using System.Collections.Generic;
using UnityEngine;

public class CardCriticalInsurance : Card
{
	private const float effect = 0.5f;

	private const string ingameIcoName = "game-card-ico-criticalinsurance";

	public float timeInSec = 5f;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private List<float> mOldCriticals = new List<float>();

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mOldCriticals.Clear();
		for (int i = 0; i < mPlayer.weaponInventory.usedWeapons.Count; i++)
		{
			mOldCriticals.Add(mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability);
			mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability = 0.5f;
		}
		mRemainingTime = timeInSec;
		mUsed = true;
		mPlayer.cardIconIndicator.Show("game-card-ico-criticalinsurance", show: true);
		cardManager.CardWasUsed(this, fraction);
	}

	public override void DisconnectEvents()
	{
		if (mUsed)
		{
			for (int i = 0; i < mPlayer.weaponInventory.usedWeapons.Count; i++)
			{
				mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability = mOldCriticals[i];
			}
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-criticalinsurance", show: false);
		}
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-criticalinsurance", mRemainingTime / timeInSec);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}
}
