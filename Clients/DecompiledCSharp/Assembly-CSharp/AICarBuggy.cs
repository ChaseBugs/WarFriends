using Google2u;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class AICarBuggy : AICarBase<CarBuggyBehaviour>
{
	public EnemyPointVehicle coDriverPoint;

	public EnemyPointVehicle driverPoint;

	private bool mIsWaitingForDriver;

	public TurretWeaponMultipleWeapons cannon;

	public TurretWeaponBasic turret;

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.carBuggyBehaviourDefinititon.health;
		mDestroyableObject.RefillOffline();
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)turret.batchedWeapon.weapon.ammoSetup;
		bulletSetup.damageAmount = base.currentBeh.carBuggyBehaviourDefinititon.damage;
		bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		turret.batchSizeMax = base.currentBeh.carBuggyBehaviourDefinititon.fireBatchSizeMax;
		turret.batchSizeMin = base.currentBeh.carBuggyBehaviourDefinititon.fireBatchSizeMin;
		turret.minShootTime = base.currentBeh.carBuggyBehaviourDefinititon.minShootTime;
		turret.maxShootTime = base.currentBeh.carBuggyBehaviourDefinititon.maxShootTime;
		turret.realShotProbability = base.currentBeh.carBuggyBehaviourDefinititon.probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)cannon.batchedWeapon.weapon.ammoSetup;
		missileSetup.explodeDamageAmount = base.currentBeh.carBuggyBehaviourDefinititon.damageCannon * 0.5f;
		missileSetup.playerBehindShieldRatio = preparedBehaviour.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		missileSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.speed = base.currentBeh.carBuggyBehaviourDefinititon.shotSpeed;
		BatchedWeapon[] secondaryBatchedWeapons = cannon.secondaryBatchedWeapons;
		foreach (BatchedWeapon batchedWeapon in secondaryBatchedWeapons)
		{
			missileSetup = (MissileSetup)batchedWeapon.weapon.ammoSetup;
			missileSetup.explodeDamageAmount = base.currentBeh.carBuggyBehaviourDefinititon.damageCannon * 0.5f;
			missileSetup.playerBehindShieldRatio = preparedBehaviour.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
			missileSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.speed = base.currentBeh.carBuggyBehaviourDefinititon.shotSpeed;
		}
		cannon.batchSizeMax = 1;
		cannon.batchSizeMin = 1;
		cannon.minShootTime = base.currentBeh.carBuggyBehaviourDefinititon.minShootTimeCannon;
		cannon.maxShootTime = base.currentBeh.carBuggyBehaviourDefinititon.maxShootTimeCannon;
		cannon.realShotProbability = 1f;
		cannon.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
		turret.gameObject.SetActive(base.hasSpecial);
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (inGame)
		{
			ChangeWheels(0.5f, 0.14f);
		}
		else
		{
			ChangeWheels(0f, 0f);
		}
		turret.gameObject.SetActive(base.hasSpecial);
		EnemyController enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, coDriverPoint, disableWeapon: true);
		enemyController.SittingIdle();
		enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, driverPoint, disableWeapon: true);
		enemyController.SittingIdle();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		cannon.ResetAiming();
		turret.ResetAiming();
		if (!isPrewiev)
		{
			if (photonView.isMine)
			{
				GenerateEnemy(isFirst: true, driverPoint);
				GenerateEnemy(isFirst: true, coDriverPoint);
				SetTarget(spawnedFrom.waypointCircuit, ((SpawnPointCar)spawnedFrom).target);
				mIsWaitingForDriver = false;
				cannon.enabled = true;
				turret.enabled = true;
			}
			cannon.Reset();
			turret.Reset();
			ChangeWheels(0.5f, 0.14f);
		}
	}

	protected override void Update()
	{
		if (isPrewiev)
		{
			return;
		}
		base.Update();
		if (mIsWaitingForDriver && driverPoint.enemyAtPoint != null)
		{
			EnemyController enemyController = driverPoint.enemyAtPoint as EnemyController;
			if (enemyController != null && enemyController.enemyAiState == EnemyController.EnemyAIState.Vehicle)
			{
				mIsWaitingForDriver = false;
				obstacleCollider.gameObject.SetActive(value: false);
				mDriving = true;
				brakeCondition = BrakeCondition.TargetDirectionDifference;
			}
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient && Singleton<GameController>.instance.gameIsRunning && isAlive)
		{
			if (TimeManager.realTimeWithoutPauses > coDriverPoint.nextSpawnTime && coDriverPoint.enemyAtPoint == null)
			{
				GenerateEnemy(isFirst: false, coDriverPoint);
			}
			if (TimeManager.realTimeWithoutPauses > driverPoint.nextSpawnTime && driverPoint.enemyAtPoint == null)
			{
				GenerateEnemy(isFirst: false, driverPoint);
			}
		}
	}

	private void SoldierOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		gameMainEntity.Killed -= SoldierOnKilled;
		EnemyController enemyController = (EnemyController)gameMainEntity;
		if (enemyController.enemyPoint == driverPoint)
		{
			enemyController.ClearEnemyPoint();
			mDriving = false;
			brakeCondition = BrakeCondition.Stop;
			mIsWaitingForDriver = true;
			driverPoint.nextSpawnTime = TimeManager.realTimeWithoutPauses + behaviour.upgradeSlots.soldierRespawnRate;
		}
		if (enemyController.enemyPoint == coDriverPoint)
		{
			cannon.enabled = false;
			cannon.Reset();
			turret.enabled = false;
			turret.Reset();
			enemyController.ClearEnemyPoint();
			coDriverPoint.nextSpawnTime = TimeManager.realTimeWithoutPauses + behaviour.upgradeSlots.soldierRespawnRate;
		}
	}

	protected override void OnKilled(DestroyableObject.DamageInfo arg2)
	{
		DestroySoldier(driverPoint, arg2, SoldierOnKilled);
		DestroySoldier(coDriverPoint, arg2, SoldierOnKilled);
		base.OnKilled(arg2);
	}

	private void GenerateEnemy(bool isFirst, EnemyPointVehicle point)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour);
		point.enemyAtPoint = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, useEnergy: false, point.position, startBehaviour: false);
			point.enemyAtPoint = enemyController;
			enemyController.enemyPoint = point;
			enemyController.StartEnemyBehaviour(EnemyController.EnemyAIState.Vehicle);
			enemyController.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
			if (point == coDriverPoint)
			{
				enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = base.currentBeh.carBuggyBehaviourDefinititon;
				cannon.enabled = true;
				cannon.Reset();
				turret.enabled = true;
				turret.Reset();
			}
			else
			{
				enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = base.currentBeh.carBuggyBehaviourDefinititon;
			}
			enemyController.SittingIdle();
			enemyController.Killed += SoldierOnKilled;
		}
	}

	protected override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		ClearEnemyPoint(coDriverPoint, SoldierOnKilled);
		ClearEnemyPoint(driverPoint, SoldierOnKilled);
	}
}
