using Google2u;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class AICar : AICarBase<CarBehaviour>, IFraction, IGameMainEntity
{
	public TurretWeaponBasic turret;

	public TurretWeaponBasic cannon;

	private EnemyController soldier;

	protected bool mEnemyKilled;

	private bool mIsFirstEnemy;

	private EnemyPointVehicle enemyPoint;

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.carBehaviourDefinititon.health;
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)turret.batchedWeapon.weapon.ammoSetup;
		bulletSetup.damageAmount = base.currentBeh.carBehaviourDefinititon.damage;
		bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.speed = base.currentBeh.carBehaviourDefinititon.shotSpeed;
		turret.batchSizeMax = base.currentBeh.carBehaviourDefinititon.fireBatchSizeMax;
		turret.batchSizeMin = base.currentBeh.carBehaviourDefinititon.fireBatchSizeMin;
		turret.minShootTime = base.currentBeh.carBehaviourDefinititon.minShootTime;
		turret.maxShootTime = base.currentBeh.carBehaviourDefinititon.maxShootTime;
		turret.realShotProbability = base.currentBeh.carBehaviourDefinititon.probabilityOfRealShot;
		turret.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
		cannon.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)cannon.batchedWeapon.weapon.ammoSetup;
		missileSetup.damageAmount = base.currentBeh.carBehaviourDefinititon.special * 0.1f;
		missileSetup.explodeDamageAmount = base.currentBeh.carBehaviourDefinititon.special;
		missileSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		missileSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		cannon.batchSizeMax = 1;
		cannon.batchSizeMin = 1;
		cannon.minShootTime = 5f;
		cannon.maxShootTime = 15f;
		cannon.realShotProbability = 1f;
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (inGame)
		{
			ChangeWheels(0.7f, 0.16f);
		}
		else
		{
			ChangeWheels(0f, 0f);
		}
		cannon.gameObject.SetActive(base.hasSpecial);
		GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, enemyPointVehicle, disableWeapon: true);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		turret.ResetAiming();
		cannon.ResetAiming();
		if (!isPrewiev)
		{
			if (photonView.isMine)
			{
				GenerateEnemy(isFirst: true);
				SetTarget(spawnedFrom.waypointCircuit, ((SpawnPointCar)spawnedFrom).target);
			}
			ChangeWheels(0.7f, 0.16f);
			turret.enabled = true;
			turret.Reset();
			cannon.Reset();
		}
	}

	protected override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
	}

	private void SoldierOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		gameMainEntity.Killed -= SoldierOnKilled;
		if (gameMainEntity == soldier && !mEnemyKilled && base.isInstantiated)
		{
			soldier.ClearEnemyPoint();
			mEnemyKilled = true;
			EnemyController enemyController = (EnemyController)gameMainEntity;
			enemyController.enemyPoint = null;
			if (mIsFirstEnemy && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = BrakeCondition.TargetDirectionDifference;
				obstacleCollider.gameObject.SetActive(value: false);
			}
			turret.enabled = false;
			turret.Reset();
			InvokeAfter(delegate
			{
				GenerateEnemy(isFirst: false);
			}, behaviour.upgradeSlots.soldierRespawnRate);
		}
	}

	protected override void OnKilled(DestroyableObject.DamageInfo arg2)
	{
		DestroySoldier(enemyPointVehicle, arg2, SoldierOnKilled);
		base.OnKilled(arg2);
	}

	private void GenerateEnemy(bool isFirst)
	{
		enemyPoint = enemyPoint ?? GetComponentInChildren<EnemyPointVehicle>();
		soldier = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour);
		mIsFirstEnemy = isFirst;
		enemyPoint.enemyAtPoint = null;
		if (soldier != null)
		{
			soldier.DisableSpawn();
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			soldier.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
			SpawningManager.instance.Spawn(soldier, fraction, useEnergy: false, enemyPoint.position, startBehaviour: false);
			enemyPoint.enemyAtPoint = soldier;
			soldier.enemyPoint = enemyPoint;
			soldier.StartEnemyBehaviour(EnemyController.EnemyAIState.Vehicle);
			soldier.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
			soldier.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
			VehicleBehaviourDefinititon carBehaviourDefinititon = base.currentBeh.carBehaviourDefinititon;
			soldier.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carBehaviourDefinititon.minShootTime;
			soldier.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carBehaviourDefinititon.maxShootTime;
			soldier.Killed += SoldierOnKilled;
			mEnemyKilled = false;
			turret.enabled = true;
			turret.Reset();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (soldier != null)
		{
			soldier.Killed -= SoldierOnKilled;
		}
		ClearEnemyPoint(enemyPoint, SoldierOnKilled);
	}
}
