using System.Collections.Generic;
using Google2u;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class AICarTransporter : AICarBase<CarTransporterBehaviour>
{
	public EnemyPointVehicle coDriverPoint;

	public TransporterTurret turret;

	public List<WayPointPath> pathsForMiniDrones;

	private List<MiniDrone> mMiniDrones = new List<MiniDrone>();

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.carTransporterBehaviourDefinititon.health;
		mDestroyableObject.RefillOffline();
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		foreach (BatchedWeapon weapon in turret.weapons)
		{
			BulletSetup bulletSetup = (BulletSetup)weapon.weapon.ammoSetup;
			bulletSetup.damageAmount = base.currentBeh.carTransporterBehaviourDefinititon.damage;
			bulletSetup.speed = base.currentBeh.carTransporterBehaviourDefinititon.shotSpeed;
			bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
			bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		}
		turret.batchSizeMax = base.currentBeh.carTransporterBehaviourDefinititon.fireBatchSizeMax;
		turret.batchSizeMin = base.currentBeh.carTransporterBehaviourDefinititon.fireBatchSizeMin;
		turret.minShootTime = base.currentBeh.carTransporterBehaviourDefinititon.minShootTime;
		turret.maxShootTime = base.currentBeh.carTransporterBehaviourDefinititon.maxShootTime;
		turret.realShotProbability = base.currentBeh.carTransporterBehaviourDefinititon.probabilityOfRealShot;
		turret.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (inGame)
		{
			ChangeWheels(0.5f, 0.09f);
		}
		else
		{
			ChangeWheels(0f, 0f);
		}
		EnemyController enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, coDriverPoint, disableWeapon: true);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		turret.ResetAiming();
		carController.MaxSpeed = ((!isPrewiev) ? 1f : 1.7f);
		if (isPrewiev)
		{
			return;
		}
		if (photonView.isMine)
		{
			GenerateEnemy(isFirst: true, coDriverPoint);
			SetTarget(spawnedFrom.waypointCircuit, spawnedFrom.waypointCircuit.waypointList[spawnedFrom.waypointCircuit.waypointList.items.Length - 1]);
			if (base.hasSpecial)
			{
				GenerateMiniDrones();
			}
		}
		turret.enabled = true;
		turret.Reset();
		ChangeWheels(0.5f, 0.09f);
	}

	private void GenerateMiniDrones()
	{
		mMiniDrones.Clear();
		foreach (WayPointPath pathsForMiniDrone in pathsForMiniDrones)
		{
			SpawnMiniDrone(pathsForMiniDrone);
		}
	}

	private void SpawnMiniDrone(WayPointPath pathForMiniDrone)
	{
		Debug.Log("Spawn minidrone at: " + pathForMiniDrone.name);
		Transform transform = pathForMiniDrone.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.miniDrone, transform.position, transform.rotation);
		miniDrone.SetWayPoint(pathForMiniDrone);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.repairRatioPerSec = base.currentBeh.carTransporterBehaviourDefinititon.special;
		miniDrone.Killed += MiniDroneOnKilled;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.carTransporterBehaviourDefinititon.health * base.currentBeh.carTransporterBehaviourDefinititon.repairBotHP;
		miniDrone.destroyableObject.Refill();
		mMiniDrones.Add(miniDrone);
	}

	private void MiniDroneOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		gameMainEntity.Killed -= MiniDroneOnKilled;
		MiniDrone miniDrone = (MiniDrone)gameMainEntity;
		mMiniDrones.Remove(miniDrone);
		WayPointPath p = miniDrone.wayPointPath;
		InvokeAfterRealTime(delegate
		{
			SpawnMiniDrone(p);
		}, Random.Range(35f, 45f));
		Debug.Log("Killed minidrone at: " + miniDrone.name + " path: " + p.name);
	}

	protected override void Update()
	{
		if (!isPrewiev)
		{
			base.Update();
		}
	}

	private void SoldierOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		gameMainEntity.Killed -= SoldierOnKilled;
		EnemyController enemyController = (EnemyController)gameMainEntity;
		if (enemyController.enemyPoint == coDriverPoint)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				GenerateEnemy(isFirst: false, coDriverPoint);
			}, behaviour.upgradeSlots.soldierRespawnRate);
			turret.enabled = false;
			turret.Reset();
		}
	}

	protected override void OnKilled(DestroyableObject.DamageInfo arg2)
	{
		DestroySoldier(coDriverPoint, arg2, SoldierOnKilled);
		if (photonView.isMine)
		{
			DestroyableObject.DamageInfo info = new DestroyableObject.DamageInfo
			{
				isNetwork = false,
				damageAmount = float.MaxValue,
				force = Vector3.up,
				owner = null
			};
			foreach (MiniDrone mMiniDrone in mMiniDrones)
			{
				mMiniDrone.Killed -= MiniDroneOnKilled;
				mMiniDrone.destroyableObject.DoDamage(info);
			}
		}
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
			enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.carTransporterBehaviourDefinititon;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			turret.enabled = true;
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
		foreach (MiniDrone mMiniDrone in mMiniDrones)
		{
			mMiniDrone.Killed -= MiniDroneOnKilled;
		}
	}
}
