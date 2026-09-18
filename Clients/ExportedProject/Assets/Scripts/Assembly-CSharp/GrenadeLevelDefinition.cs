using System;
using CodeStage.AntiCheat.ObscuredTypes;

[Serializable]
public class GrenadeLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float deadRadius;

	public float hurtradius;

	public float throwDistance;

	public float explodeAfterTIme;

	public ObscuredFloat explodeDamageAmount;

	public ObscuredFloat playerBehindShieldDamageRatio;

	public override void Zero()
	{
		base.Zero();
		explodeDamageAmount = 0f;
		playerBehindShieldDamageRatio = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		GrenadeAmmoSetup grenadeAmmoSetup = weapon.ammoSetup as GrenadeAmmoSetup;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.deadRadius = deadRadius;
			grenadeAmmoSetup.hurtRadius = hurtradius;
			grenadeAmmoSetup.explodeAfterTime = explodeAfterTIme;
			grenadeAmmoSetup.damageAmount = damageAmount;
			grenadeAmmoSetup.throwDistance = throwDistance;
			grenadeAmmoSetup.explodeDamageAmount = explodeDamageAmount;
			grenadeAmmoSetup.playerBehindShieldRatio = playerBehindShieldDamageRatio;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
