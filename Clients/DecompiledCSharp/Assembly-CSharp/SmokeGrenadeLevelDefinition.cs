using System;

[Serializable]
public class SmokeGrenadeLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float explodeAfterTIme;

	public float throwDistance;

	public float time;

	public float radius;

	public override void Zero()
	{
		base.Zero();
		time = 0f;
		radius = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		SmokeGrenadeAmmoSetup smokeGrenadeAmmoSetup = weapon.ammoSetup as SmokeGrenadeAmmoSetup;
		if (smokeGrenadeAmmoSetup != null)
		{
			smokeGrenadeAmmoSetup.explodeAfterTime = explodeAfterTIme;
			smokeGrenadeAmmoSetup.throwDistance = throwDistance;
			smokeGrenadeAmmoSetup.lastTime = time;
			smokeGrenadeAmmoSetup.radius = radius;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
