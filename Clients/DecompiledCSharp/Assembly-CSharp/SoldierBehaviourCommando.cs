using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SoldierBehaviourCommando : SoldierBehaviourRusher<SoldierBehaviourDefinititonFlamethrower>
{
	public float thinTrailDistance = 2f;

	private Weapon mLeftWeapon;

	private int mCounter;

	public override void ShootJustStarted()
	{
		if (mShotTarget != null)
		{
			targetPosition = Singleton<AimingHelper>.instance.PredictPosition(currentWeapon, targetPosition, mShotTarget.shootableEntity.velocity, 0.05f);
		}
		base.ShootJustStarted();
	}

	public override void Restart()
	{
		if (controller.photonView.isMine || controller.isPrewiev)
		{
			mWeapons = mEnemyBasicInventory.AttachAllWeapons(mSoldierParts, controller.spawnedByCard, base.mSoldierMeshChanger);
			currentWeapon = mEnemyBasicInventory.SwitchWeapon(0);
			mLeftWeapon = mEnemyBasicInventory.EnableSecondaryWeapon(1);
			SyncWeapons();
			ApplyWeaponsSetup();
		}
		mShotCounter = 0;
		StopAllCoroutines();
		mIsNetworkShoot = false;
		mUseExternalWeapon = false;
	}

	protected override void Shoot(Vector3 position, bool isFake)
	{
		mCounter++;
		if (mCounter % 2 == 0)
		{
			currentWeapon = mWeapons[1];
		}
		base.Shoot(position, isFake);
		currentWeapon = mWeapons[0];
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (AcceptSpawnPoint(spawn))
			{
				list.Add(spawn);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		PlayerController pl = PlayerController.GetEnemyOf(controller.fraction);
		list.Sort(delegate(SpawnPoint a, SpawnPoint b)
		{
			float sqrMagnitude = (pl.transform.position - a.transform.position).sqrMagnitude;
			return (pl.transform.position - b.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		});
		return list[0];
	}

	private void SetWeaponParameters(Weapon w)
	{
		BulletSetup bulletSetup = (BulletSetup)w.ammoSetup;
		if (controller.hasSpecial)
		{
			bulletSetup.realShotTexture = "shotPoison";
			w.bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletPoison;
		}
		else
		{
			bulletSetup.realShotTexture = "shotReal";
			w.bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		}
		bulletSetup.poisonTime = Singleton<GameVariables>.instance.unitsConstants.GetRow(UnitsContants.rowIds.PoisonShotTime).FLOATVALUE;
		bulletSetup.poisonRatio = base.soldierBehaviourDefinititon.special;
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].cadence = 0.2f;
		mWeapons[1].ammoSetup.damageAmount = base.soldierBehaviourDefinititon.damage;
		mWeapons[1].ammoSetup.damageToPlayerCoeficient = upgradeSlots.playerDamageRatio;
		mWeapons[1].ammoSetup.damageToPlayerOvertimeCoeficient = upgradeSlots.playerDamageOvertimeRatio;
		mWeapons[1].cadence = 0.2f;
		SetWeaponParameters(mWeapons[0]);
		SetWeaponParameters(mWeapons[1]);
	}

	[PunRPC]
	protected override void AttachWeaponsRPC(byte[] indices)
	{
		base.AttachWeaponsRPC(indices);
		mLeftWeapon = mEnemyBasicInventory.EnableSecondaryWeapon(1);
	}

	protected override void OnBeforeFire()
	{
		base.OnBeforeFire();
		BulletSetup bulletSetup = currentWeapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(controller.fraction);
			float num = controller.transform.position.PlanarDistance(enemyOf.position);
			bulletSetup.useThinTrail = num < thinTrailDistance;
		}
	}

	protected override int[] GetWeaponLevels(UpgradeSlots.UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(unitUpgrades);
		return new int[2]
		{
			visuals[2].weaponNumber,
			visuals[2].weaponNumber
		};
	}

	protected override int[] GetCardWeaponLevels()
	{
		return new int[2]
		{
			upgradeSlots.cardVisuals[2].weaponNumber,
			upgradeSlots.cardVisuals[2].weaponNumber
		};
	}
}
