using System;

[Serializable]
public class FlashGrenadeLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float explodeAfterTIme;

	public float throwDistance;

	public float radius = 2f;

	public float time;

	public override void Zero()
	{
		base.Zero();
		radius = 0f;
		time = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		FlashGrenadeAmmoSetup flashGrenadeAmmoSetup = weapon.ammoSetup as FlashGrenadeAmmoSetup;
		if (flashGrenadeAmmoSetup != null)
		{
			flashGrenadeAmmoSetup.explodeAfterTime = explodeAfterTIme;
			flashGrenadeAmmoSetup.throwDistance = throwDistance;
			flashGrenadeAmmoSetup.radius = radius;
			flashGrenadeAmmoSetup.lastTime = time;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
