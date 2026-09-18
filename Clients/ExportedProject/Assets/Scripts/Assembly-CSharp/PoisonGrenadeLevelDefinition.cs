using System;

[Serializable]
public class PoisonGrenadeLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float explodeAfterTIme;

	public float radius = 2f;

	public float throwDistance;

	public float time = 12f;

	public override void Zero()
	{
		base.Zero();
		time = 0f;
		radius = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		PoisonGrenadeAmmoSetup poisonGrenadeAmmoSetup = weapon.ammoSetup as PoisonGrenadeAmmoSetup;
		if (poisonGrenadeAmmoSetup != null)
		{
			poisonGrenadeAmmoSetup.explodeAfterTime = explodeAfterTIme;
			poisonGrenadeAmmoSetup.throwDistance = throwDistance;
			poisonGrenadeAmmoSetup.damageAmount = damageAmount;
			poisonGrenadeAmmoSetup.radius = radius;
			poisonGrenadeAmmoSetup.lastTime = time;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
