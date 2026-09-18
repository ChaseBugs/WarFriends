using System;

[Serializable]
public class ShotgunLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float shotHalfAngle;

	public float shotHalfAngleNear;

	public float radius;

	public float minDamage;

	public float maxDamage;

	public float speed;

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		ShotGunBulletSetup shotGunBulletSetup = weapon.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.maxDamage = maxDamage;
			shotGunBulletSetup.minDamage = minDamage;
			shotGunBulletSetup.radius = radius;
			shotGunBulletSetup.shotHalfAngle = shotHalfAngle;
			shotGunBulletSetup.shotHalfAngleNear = shotHalfAngleNear;
			shotGunBulletSetup.bulletSpeed = speed;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}

	public override void Zero()
	{
		base.Zero();
		minDamage = 0f;
		maxDamage = 0f;
	}
}
