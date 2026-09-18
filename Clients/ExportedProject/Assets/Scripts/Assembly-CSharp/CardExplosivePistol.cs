using Google2u;
using UnityEngine;

public class CardExplosivePistol : Card
{
	public int shotCount = 3;

	public float deadRadius = 1.5f;

	public float hurtRadius = 2.2f;

	public Vector3 explosionCoef = new Vector3(5f, 8f, 5f);

	public float additionalUpForce = 5f;

	public float playerDamageRatio = 0.2f;

	private PlayerController mPlayer;

	private PlayerBot mBot;

	private bool mUsed;

	private int mRemainingShots;

	private int mRemainingExplosions;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mBot = mPlayer.playerBot;
		cardManager.CardWasUsed(this, fraction);
		mUsed = true;
		mBot.explosivePistol = true;
		Weapon.OnShotHit += WeaponOnShotHit;
		Weapon.OnShotFired += WeaponOnShotFired;
		mRemainingShots = shotCount;
		mRemainingExplosions = shotCount;
		if (PlayerController.currentPlayer == PlayerController.GetPlayerOld(fraction))
		{
			SetPistolIcon(active: true);
		}
	}

	private void WeaponOnShotHit(Weapon weapon, Ammo ammo, Vector3 position, bool isNetworkCopy, DestroyableObject hit)
	{
		if (!isNetworkCopy && weapon.owner == mPlayer && weapon.weaponType == Weapon.WeaponType.Pistol)
		{
			float t = (float)mPlayer.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float damageAmount = 0.1f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolPlayerBehindShieldConstant).FLOATVALUE;
			Singleton<ExplosionManager>.instance.MissileExplode(position, num, damageAmount, deadRadius, hurtRadius, explosionCoef, additionalUpForce, mPlayer, weapon, fLOATVALUE, Explosion.ExplosionType.Small);
			mRemainingExplosions--;
			if (mRemainingShots <= 0)
			{
				DisableEffect();
			}
		}
	}

	public void WeaponOnShotFired(Weapon weapon, Vector3 position)
	{
		if (weapon.weaponType == Weapon.WeaponType.Pistol && weapon.owner == mPlayer)
		{
			mRemainingShots--;
			if (mRemainingShots < 0)
			{
				DisableEffect();
			}
		}
	}

	private void SetPistolIcon(bool active)
	{
		foreach (InventoryItem invItem in GuiElementSingle<InventoryGuiElement>.instance.invItems)
		{
			PlayerWeapon playerWeapon = invItem.GetPlayerWeapon();
			if (playerWeapon != null && playerWeapon.weapon.weaponType == Weapon.WeaponType.Pistol)
			{
				invItem.explosivePistolIcon.gameObject.SetActive(active);
			}
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (mUsed && mPlayer.mPhotonView.isMine)
		{
			DisableEffect();
		}
	}

	private void DisableEffect()
	{
		if (mUsed)
		{
			mUsed = false;
			mBot.explosivePistol = false;
			Weapon.OnShotHit -= WeaponOnShotHit;
			Weapon.OnShotFired -= WeaponOnShotFired;
			if (PlayerController.currentPlayer == mPlayer)
			{
				SetPistolIcon(active: false);
			}
		}
	}
}
