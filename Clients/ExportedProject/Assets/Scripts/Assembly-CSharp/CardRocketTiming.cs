using UnityEngine;

public class CardRocketTiming : Card
{
	public const string ingameIcoName = "game-card-ico-explosivetiming";

	public float multiplierCadence;

	private PlayerWeapon mExplosiveWeapon;

	private float mSavedCadence;

	private bool mUsed;

	private bool mFired;

	private bool mEventAllocated;

	private ICardManager mCardManager;

	private PlayerController mPlayer;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		if (mEventAllocated && mExplosiveWeapon != null)
		{
			mExplosiveWeapon.haveNextNoReload = false;
		}
		mExplosiveWeapon = mPlayer.weaponInventory.usedWeapons[2];
		mCardManager = cardManager;
		mPlayer.cardIconIndicator.Show("game-card-ico-explosivetiming", show: true);
		mExplosiveWeapon.haveNextNoReload = true;
		mFired = false;
		if (mEventAllocated)
		{
			cardManager.CardWasUsed(this, mPlayer.fraction);
			return;
		}
		Weapon.OnShotFired += HandleOnShotFired;
		mEventAllocated = true;
		mSavedCadence = mExplosiveWeapon.weapon.cadence;
		mUsed = true;
		cardManager.CardWasUsed(this, mPlayer.fraction);
	}

	private void HandleOnShotFired(Weapon obj, Vector3 pos)
	{
		if (!(obj == mExplosiveWeapon.weapon) || !mUsed)
		{
			return;
		}
		if (mFired)
		{
			mExplosiveWeapon.weapon.cadence = mSavedCadence;
			mUsed = false;
			mFired = false;
			if (mEventAllocated)
			{
				Weapon.OnShotFired -= HandleOnShotFired;
				mEventAllocated = false;
			}
		}
		else
		{
			mExplosiveWeapon.weapon.cadence = mSavedCadence * multiplierCadence;
			mFired = true;
			mPlayer.cardIconIndicator.Show("game-card-ico-explosivetiming", show: false);
			mExplosiveWeapon.haveNextNoReload = false;
		}
	}

	public override void DisconnectEvents()
	{
		if (mEventAllocated)
		{
			mExplosiveWeapon.haveNextNoReload = false;
			Weapon.OnShotFired -= HandleOnShotFired;
			mEventAllocated = false;
		}
	}
}
