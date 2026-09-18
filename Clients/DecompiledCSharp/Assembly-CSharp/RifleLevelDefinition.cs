using System;

[Serializable]
public class RifleLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float speed;

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		BulletSetup bulletSetup = weapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			bulletSetup.bulletSpeed = speed;
			bulletSetup.damageAmount = damageAmount;
			bulletSetup.criticalProbability = criticalDamage;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
