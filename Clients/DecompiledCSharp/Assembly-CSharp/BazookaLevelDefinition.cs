using System;

[Serializable]
public class BazookaLevelDefinition : LevelManager.WeaponLevelDefinition
{
	public float deadRadius;

	public float hurtradius;

	public float speed;

	public float explodeDamageAmount;

	public float playerBehindShieldDamageRatio;

	public override void Zero()
	{
		base.Zero();
		explodeDamageAmount = 0f;
		playerBehindShieldDamageRatio = 0f;
	}

	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		MissileSetup missileSetup = weapon.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.deadRadius = deadRadius;
			missileSetup.hurtRadius = hurtradius;
			missileSetup.damageAmount = damageAmount;
			missileSetup.explodeDamageAmount = explodeDamageAmount;
			missileSetup.speed = speed;
			missileSetup.playerBehindShieldRatio = playerBehindShieldDamageRatio;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
