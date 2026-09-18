using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourGrennader : SoldierBehaviourGeneric<SoldierBehaviourDefinititonGrennader>
{
	public override bool AcceptSpawnPoint(SpawnPoint point)
	{
		if (point.spawnPointType == SpawnPoint.SpawnPointType.Parachute && base.mBehaviourDef.canUseParachute && controller.fraction == point.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(point);
	}

	public override void UpdateVisual()
	{
		base.UpdateVisual();
		if (controller.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[2] != null)
			{
				mEnemyBasicInventory.SetWeaponsUpgrade(new int[2]
				{
					0,
					upgradeSlots.cardVisuals[2].weaponNumber
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(controller.unitUpgrades);
		if (visuals.Count > 2 && visuals[2] != null)
		{
			mEnemyBasicInventory.SetWeaponsUpgrade(new int[2]
			{
				0,
				visuals[2].weaponNumber
			});
		}
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (AcceptSpawnPoint(spawn))
			{
				list.Add(spawn);
				if (spawn.spawnPointType == SpawnPoint.SpawnPointType.Parachute)
				{
					return spawn;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public override bool CanBeSpawned(Fractions f, int numberOfEnemies)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && f == Fractions.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit armyDefinition in Singleton<SpawningManagerDeathMatch>.instance.armyDefinitions)
			{
				if (GetType() == armyDefinition.behaviour.GetType())
				{
					return armyDefinition.spawns[f] + numberOfEnemies < 2;
				}
			}
		}
		return base.CanBeSpawned(f, numberOfEnemies);
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotReal";
		bulletSetup.damageAmount = base.mBehaviourDef.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)mWeapons[1].ammoSetup;
		grenadeAmmoSetup.damageAmount = base.mBehaviourDef.grenadeMinDamage;
		grenadeAmmoSetup.explodeDamageAmount = base.mBehaviourDef.grenadeExplodeDamage;
		grenadeAmmoSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.damageToPlayerCoeficient = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.damageToPlayerOvertimeCoeficient = upgradeSlots.playerDamageOvertimeRatio;
		if (controller.hasSpecial)
		{
			grenadeAmmoSetup.explodeAfterTime = 3f - 3f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.explodeAfterTime = 3f;
		}
	}

	public override void PickTarget()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.mHasSeconadryWeapon && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !mUseExternalWeapon)
		{
			SwitchWeapon(isSecondary: true);
			mFireBatchSize = 1;
			mUseSecondaryWeapon = true;
		}
		if (!TryPickDecoy())
		{
			PickPlayerOpponent(upgradeSlots.shieldHitProbability);
		}
	}

	protected override int[] GetWeaponLevels(UpgradeSlots.UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(unitUpgrades);
		return new int[2]
		{
			0,
			visuals[2].weaponNumber
		};
	}

	protected override int[] GetCardWeaponLevels()
	{
		return new int[2]
		{
			0,
			upgradeSlots.cardVisuals[2].weaponNumber
		};
	}
}
