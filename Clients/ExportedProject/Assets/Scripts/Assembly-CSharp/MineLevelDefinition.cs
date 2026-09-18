using System;

[Serializable]
public class MineLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float deadRadius;

	public float hurtradius;

	public float explodeAfterTIme;

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		MineAmmoSetup mineAmmoSetup = weapon.ammoSetup as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			mineAmmoSetup.deadRadius = deadRadius;
			mineAmmoSetup.hurtRadius = hurtradius;
			mineAmmoSetup.explodeAfterTime = explodeAfterTIme;
			mineAmmoSetup.damageAmount = damageAmount;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
