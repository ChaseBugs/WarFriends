using System;

[Serializable]
public class BazookaFangsLevelDefinition : BazookaLevelDefinition
{
	public override void SetWeaponparameters(Weapon weapon)
	{
		base.SetWeaponparameters(weapon);
		MissileSetup missileSetup = weapon.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.deadRadius = deadRadius;
			missileSetup.hurtRadius = hurtradius;
			missileSetup.damageAmount = damageAmount;
			missileSetup.explodeDamageAmount = explodeDamageAmount * 0.5f;
			missileSetup.speed = speed;
			missileSetup.playerBehindShieldRatio = playerBehindShieldDamageRatio;
			BazookaFangs bazookaFangs = weapon as BazookaFangs;
			if (bazookaFangs != null)
			{
				bazookaFangs.add.playerWeapon = weapon.playerWeapon;
				SetWeaponparameters(bazookaFangs.add);
				bazookaFangs.SetupGun();
			}
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}
}
