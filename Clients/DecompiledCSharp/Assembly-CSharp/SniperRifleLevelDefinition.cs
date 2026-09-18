using System;

[Serializable]
public class SniperRifleLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float slowDownTimeScale;

	public float fov = 3.5f;

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		BulletSetup bulletSetup = weapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			bulletSetup.damageAmount = damageAmount;
			PlayerZoomOnTouchWeapon component = weapon.GetComponent<PlayerZoomOnTouchWeapon>();
			if (component != null)
			{
				component.fov = fov;
				return;
			}
			throw new NullReferenceException(string.Empty);
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
