using Google2u;
using UnityEngine;

public class CardDisarmedAndLocked : Card
{
	public const string ingameIcoName = "game-card-ico-disarmed";

	private PlayerWeapon mSavedWeapon;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private ICardManager cardManager;

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.DisarmedTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.PrintableTimeDescription(buffTime));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		this.cardManager = cardManager;
		mPlayer = PlayerController.GetEnemyOf(fraction);
		cardManager.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses + buffTime - 0.1f;
		Debug.Log("Start TimeLock: " + CardManager.instance.timeLockWeaponSwitch);
		if (mPlayer.weaponInventory.cannotChange)
		{
			cardManager.grenadeSaved = mPlayer.weaponInventory.currentWeapon;
			mPlayer.weaponInventory.cannotChange = false;
			cardManager.timeLockWeaponSwitch += 1000f;
		}
		mPlayer.weaponInventory.currentWeapon = mPlayer.weaponInventory.pistol;
		mPlayer.weaponInventory.cannotChange = true;
		mPlayer.weaponInventory.canNotChangeFract = 1f;
		mRemainingTime = buffTime;
		mUsed = true;
		mPlayer.cardIconIndicator.Show("game-card-ico-disarmed", show: true);
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
				float num = mRemainingTime / buffTime;
				mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-disarmed", num);
				mPlayer.weaponInventory.canNotChangeFract = num;
			}
			else
			{
				mPlayer.weaponInventory.cannotChange = false;
				mPlayer.weaponInventory.canNotChangeFract = 0f;
				Debug.Log("Ending TimeLock: " + CardManager.instance.timeLockWeaponSwitch);
				cardManager.timeLockWeaponSwitch = TimeManager.realTimeWithoutPauses;
				mRemainingTime = 0f;
				mUsed = false;
				mPlayer.cardIconIndicator.Show("game-card-ico-disarmed", show: false);
			}
		}
	}
}
