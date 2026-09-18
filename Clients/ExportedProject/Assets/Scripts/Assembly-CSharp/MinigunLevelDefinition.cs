using System;

[Serializable]
public class MinigunLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float coolDown = 1f;

	public override void Zero()
	{
		base.Zero();
		coolDown = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		BulletSetup bulletSetup = weapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			bulletSetup.damageAmount = damageAmount;
			PlayerMinigunWeapon component = weapon.GetComponent<PlayerMinigunWeapon>();
			if (component != null)
			{
				component.coolDown = coolDown;
				return;
			}
			throw new NullReferenceException(string.Empty);
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
