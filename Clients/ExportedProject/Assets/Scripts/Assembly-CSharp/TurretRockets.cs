using UnityEngine;

[RequireComponent(typeof(DestroyableObjectMultipleParts))]
public class TurretRockets : TurretBase<TurretRocketsBehaviour, TurretRocketsBehaviourDefinititon>, IFraction, IGameMainEntity
{
	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		MissileSetup missileSetup = (MissileSetup)turretWeapon.batchedWeapon.weapon.ammoSetup;
		missileSetup.explodeDamageAmount = (float)base.currentBeh.turretBehaviour.damage * 0.5f;
		missileSetup.damageAmount = (float)base.currentBeh.turretBehaviour.damage * 0.1f;
		missileSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		missileSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.playerBehindShieldRatio = preparedBehaviour.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.speed = base.currentBeh.turretBehaviour.shotSpeed;
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)turretWeapon;
		BatchedWeapon[] secondaryBatchedWeapons = turretWeaponMultipleWeapons.secondaryBatchedWeapons;
		foreach (BatchedWeapon batchedWeapon in secondaryBatchedWeapons)
		{
			missileSetup = (MissileSetup)batchedWeapon.weapon.ammoSetup;
			missileSetup.explodeDamageAmount = (float)base.currentBeh.turretBehaviour.damage * 0.5f;
			missileSetup.damageAmount = (float)base.currentBeh.turretBehaviour.damage * 0.1f;
			missileSetup.playerBehindShieldRatio = preparedBehaviour.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.speed = base.currentBeh.turretBehaviour.shotSpeed;
		}
		turretWeapon.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
	}
}
