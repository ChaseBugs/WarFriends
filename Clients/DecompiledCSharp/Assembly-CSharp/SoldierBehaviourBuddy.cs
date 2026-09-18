using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class SoldierBehaviourBuddy : SoldierBehaviourRusher<SoldierBehaviourDefinititonBuddy>
{
	private UnitType mBuddyType;

	private WeaponCategory mWeaponCategory;

	private int mPrimary;

	private int mSecondary;

	public override void ShootJustStarted()
	{
		if (mShotTarget != null && mBuddyType == UnitType.Defender)
		{
			targetPosition = Singleton<AimingHelper>.instance.PredictPosition(currentWeapon, targetPosition, mShotTarget.shootableEntity.velocity, 0.05f);
			currentWeapon.SetBullletSpeedCoef((mShotTarget == null || !(mShotTarget.shootableEntity.owner is PlayerController)) ? 2.5f : 1f);
		}
		base.ShootJustStarted();
	}

	protected override void ApplyWeaponsSetup()
	{
		mEnemyBasicInventory.SetOwner(controller);
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[mPrimary];
		mWeapons[0].ammoSetup.damageToPlayerCoeficient = weaponLevelsSetup.damageToPlayerRatio;
		mWeapons[0].ammoSetup.damageToPlayerOvertimeCoeficient = weaponLevelsSetup.damageToPlayerRatioOvertime;
		switch (mWeaponCategory)
		{
		case WeaponCategory.Pistol:
		{
			GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)mWeapons[1].ammoSetup;
			grenadeAmmoSetup.damageAmount = base.mBehaviourDef.explodeMinDamage;
			grenadeAmmoSetup.explodeDamageAmount = base.mBehaviourDef.explodeMaxDamage;
			grenadeAmmoSetup.explodeAfterTime = 2f;
			WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.weaponLevelsSetups[mSecondary];
			grenadeAmmoSetup.damageToPlayerCoeficient = weaponLevelsSetup2.damageToPlayerRatio;
			grenadeAmmoSetup.damageToPlayerOvertimeCoeficient = weaponLevelsSetup2.damageToPlayerRatioOvertime;
			mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
			mWeapons[0].cadence = 0.35f;
			BulletSetup bulletSetup2 = (BulletSetup)mWeapons[0].ammoSetup;
			bulletSetup2.realShotTexture = "shotReal";
			bulletSetup2.damageAmount = base.mBehaviourDef.damage;
			bulletSetup2.bulletSpeed = 5f;
			break;
		}
		case WeaponCategory.AssaultRifle:
		case WeaponCategory.SMG:
		case WeaponCategory.LMG:
		case WeaponCategory.SniperRifle:
		{
			mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
			mWeapons[0].cadence = 0.35f;
			BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
			bulletSetup.realShotTexture = ((mWeaponCategory != WeaponCategory.SniperRifle) ? "shotReal" : "shotSniper");
			bulletSetup.bulletSpeed = ((mWeaponCategory != WeaponCategory.SniperRifle) ? 5 : 10);
			bulletSetup.damageAmount = base.mBehaviourDef.damage;
			break;
		}
		case WeaponCategory.Shotgun:
		{
			ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)mWeapons[0].ammoSetup;
			mWeapons[0].cadence = 0.35f;
			shotGunBulletSetup.maxDamage = base.soldierBehaviourDefinititon.damage;
			shotGunBulletSetup.minDamage = (float)base.soldierBehaviourDefinititon.damage * 0.1f;
			shotGunBulletSetup.bulletSpeed = 10f;
			break;
		}
		case WeaponCategory.Grenade:
		case WeaponCategory.GrenadeLauncher:
		case WeaponCategory.Explosive:
			break;
		case WeaponCategory.RocketLauncher:
		{
			MissileSetup missileSetup = (MissileSetup)mWeapons[0].ammoSetup;
			missileSetup.damageAmount = base.mBehaviourDef.explodeMinDamage;
			missileSetup.explodeDamageAmount = base.mBehaviourDef.explodeMaxDamage;
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override void Init(AIObject aiObject)
	{
		base.Init(aiObject);
		EnemyController enemyController = (EnemyController)aiObject;
		controller = enemyController;
		mSoldierParts = controller.GetComponent<SoldierParts>();
		mEnemyBasicInventory = GetComponent<EnemyBasicInventory>();
	}

	public override void Restart()
	{
	}

	public void ChangeCamo(Dictionary<int, CamosManager.SavedPlayerVisualSlot> equippedVisuals)
	{
		controller.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(controller, equippedVisuals, useHighRes: true);
		mSoldierParts.RepositionHelmetAttachments();
		mPhotonView.RPC("ChangeCamoRPC", PhotonTargets.Others, JsonConvert.SerializeObject(equippedVisuals));
	}

	[PunRPC]
	public void ChangeCamoRPC(string equippedVisualsString)
	{
		controller.equippedCamo = null;
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> playerVisuals = JsonConvert.DeserializeObject<Dictionary<int, CamosManager.SavedPlayerVisualSlot>>(equippedVisualsString);
		CamosManager.instance.ApplyVisuals(controller, playerVisuals, useHighRes: true);
		mSoldierParts.RepositionHelmetAttachments();
	}

	public void ChangeWeapons(int primaryIndex, int secondaryIndex)
	{
		ChangeEquippedWeapons(primaryIndex, secondaryIndex);
		mPhotonView.RPC("ChangeWeaponsRPC", PhotonTargets.Others, primaryIndex, secondaryIndex);
		int unitWeaponLevel = LevelManager.instance.weaponLevelsSetups[primaryIndex].unitWeaponLevel;
		int num = ((secondaryIndex > 0) ? LevelManager.instance.weaponLevelsSetups[secondaryIndex].unitWeaponLevel : 0);
		mEnemyBasicInventory.SetWeaponsUpgrade(new int[2] { unitWeaponLevel, num });
		Debug.Log($"SoldierBehaviourBuddy SetWeaponsUpgrades: Prim: {unitWeaponLevel} Sec: {num}");
		mPhotonView.RPC("SetWeaponsUpgradeRPC", PhotonTargets.Others, unitWeaponLevel, num);
		base.Restart();
	}

	[PunRPC]
	private void SetWeaponsUpgradeRPC(int level, int levelSec)
	{
		mEnemyBasicInventory.SetWeaponsUpgrade(new int[2] { level, levelSec });
	}

	[PunRPC]
	private void ChangeWeaponsRPC(int primaryIndex, int secondaryIndex)
	{
		ChangeEquippedWeapons(primaryIndex, secondaryIndex);
	}

	private void ChangeEquippedWeapons(int primaryIndex, int secondaryIndex)
	{
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[primaryIndex];
		WeaponLevelsSetup weaponLevelsSetup2 = ((secondaryIndex <= 0) ? null : LevelManager.instance.weaponLevelsSetups[secondaryIndex]);
		Debug.Log(string.Format("SoldierBehaviourBuddy ChangeEquippedWeapons: Prim: {0} Sec: {1}", weaponLevelsSetup.name, (!(weaponLevelsSetup2 != null)) ? "null" : weaponLevelsSetup2.name));
		EnemyBasicInventory.InventoryWeapon inventoryWeapon = new EnemyBasicInventory.InventoryWeapon();
		inventoryWeapon.weapon = weaponLevelsSetup.unitWeaponPrefab;
		inventoryWeapon.type = weaponLevelsSetup.weaponType;
		EnemyBasicInventory.InventoryWeapon item = inventoryWeapon;
		EnemyBasicInventory.InventoryWeapon inventoryWeapon2 = null;
		if (weaponLevelsSetup2 != null)
		{
			inventoryWeapon = new EnemyBasicInventory.InventoryWeapon();
			inventoryWeapon.weapon = weaponLevelsSetup2.unitWeaponPrefab;
			inventoryWeapon.type = weaponLevelsSetup2.weaponType;
			inventoryWeapon2 = inventoryWeapon;
		}
		mEnemyBasicInventory.DestroyWeapons();
		mEnemyBasicInventory.cardWeapons = new List<EnemyBasicInventory.InventoryWeapon> { item };
		if (inventoryWeapon2 != null)
		{
			mEnemyBasicInventory.cardWeapons.Add(inventoryWeapon2);
		}
	}

	private void PickUpgrades(float progress, float hpToAdd, float damageToAdd)
	{
		ApplyUpgradess(progress, hpToAdd, damageToAdd);
		mPhotonView.RPC("PickUpgradesRPC", PhotonTargets.Others, (int)mBuddyType, (int)mWeaponCategory, progress, hpToAdd, damageToAdd, mPrimary, mSecondary);
	}

	private void SetDangerCoef()
	{
		UnitsContants unitsConstants = Singleton<GameVariables>.instance.unitsConstants;
		switch (mBuddyType)
		{
		case UnitType.Defender:
			botProperties.dangerCoeficient = (int)unitsConstants.GetRow(UnitsContants.rowIds.BuddyDangerCoeficientDefender).FLOATVALUE;
			break;
		case UnitType.AttackerExplosive:
			botProperties.dangerCoeficient = (int)unitsConstants.GetRow(UnitsContants.rowIds.BuddyDangerCoeficientExplosive).FLOATVALUE;
			break;
		case UnitType.AttackerShooter:
			botProperties.dangerCoeficient = (int)unitsConstants.GetRow(UnitsContants.rowIds.BuddyDangerCoeficientAttackerShooter).FLOATVALUE;
			break;
		case UnitType.AttackerRusher:
			botProperties.dangerCoeficient = (int)unitsConstants.GetRow(UnitsContants.rowIds.BuddyDangerCoeficientRusher).FLOATVALUE;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	[PunRPC]
	private void PickUpgradesRPC(int buddyType, int weaponCategory, float progress, float hpToAdd, float damageToAdd, int primary, int secondary)
	{
		mBuddyType = (UnitType)buddyType;
		mPrimary = primary;
		mSecondary = secondary;
		SetDangerCoef();
		mWeaponCategory = (WeaponCategory)weaponCategory;
		ApplyUpgradess(progress, hpToAdd, damageToAdd);
	}

	private void ApplyUpgradess(float progress, float hpToAdd, float damageToAdd)
	{
		UpgradeSlotsBuddy upgradeSlotsBuddy = (UpgradeSlotsBuddy)upgradeSlots;
		upgradeSlotsBuddy.LoadDataForBuddyCard(this, progress, mBuddyType, mWeaponCategory);
		SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = base.mBehaviourDef;
		soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + hpToAdd;
		SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy2 = base.mBehaviourDef;
		soldierBehaviourDefinititonBuddy2.damage = (float)soldierBehaviourDefinititonBuddy2.damage + damageToAdd;
		base.mBehaviourDef.explodeMaxDamage += damageToAdd;
		base.mBehaviourDef.explodeMinDamage += damageToAdd * 0.1f;
		controller.UpgradesLoaded();
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		if (mBuddyType == UnitType.AttackerRusher)
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
		return base.PickSpawnPoint(spawns);
	}

	public void Init(CardManager.BuddyCardData buddyCardData, float progress)
	{
		mBuddyType = buddyCardData.unityType;
		mPrimary = buddyCardData.primaryWeapon;
		mSecondary = buddyCardData.secondaryWeapon;
		SetDangerCoef();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[buddyCardData.primaryWeapon];
		mWeaponCategory = weaponLevelsSetup.weaponCategory;
		int rowIndex = upgradeSlots.excel.GetRowIndex(string.Concat(mBuddyType, "_MIN_", weaponLevelsSetup.weaponCategory));
		int rowIndex2 = upgradeSlots.excel.GetRowIndex(string.Concat(mBuddyType, "_MAX_", weaponLevelsSetup.weaponCategory));
		float a = (float)upgradeSlots.excel.GetValue(rowIndex, "BonusHP");
		float b = (float)upgradeSlots.excel.GetValue(rowIndex2, "BonusHP");
		float t = (float)buddyCardData.level / (float)LevelManager.instance.maxDisplayLevel;
		float hpToAdd = Mathf.Lerp(a, b, t);
		float a2 = (float)upgradeSlots.excel.GetValue(rowIndex, "BonusDamage");
		float b2 = (float)upgradeSlots.excel.GetValue(rowIndex2, "BonusDamage");
		t = (float)(buddyCardData.armypower - 480) / 4554f;
		float damageToAdd = Mathf.Lerp(a2, b2, t);
		controller.EnableSpawn();
		controller.Spawn();
		PickUpgrades(progress, hpToAdd, damageToAdd);
		ChangeWeapons(buddyCardData.primaryWeapon, buddyCardData.secondaryWeapon);
		ShowName(buddyCardData.buddyName);
		base.StartEnemyBehaviour();
	}

	private void ShowName(string buddyName)
	{
		mPhotonView.RPC("ShowNameRPC", PhotonTargets.Others, buddyName);
		DisplayBuddyName(buddyName);
	}

	[PunRPC]
	private void ShowNameRPC(string buddyName)
	{
		DisplayBuddyName(buddyName);
	}

	private void DisplayBuddyName(string buddyName)
	{
		BuddyNameDisplayer buddyNameDisplayer = (BuddyNameDisplayer)ObjectPoolDatabase.mainPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.buddyNameDisplayer);
		buddyNameDisplayer.Init(buddyName, controller, controller.destroyableObj.healthBarPosition, controller.fraction == PlayerController.currentPlayer.fraction);
	}

	public override void PickTarget()
	{
		base.PickTarget();
		if (TryPickDecoy())
		{
			return;
		}
		switch (mBuddyType)
		{
		case UnitType.Defender:
			PickRandomOpponent(UnitType.AttackerRusher);
			break;
		case UnitType.AttackerExplosive:
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.unitsConstants.GetRow(UnitsContants.rowIds.BuddySwitchToGrenade).FLOATVALUE;
			if (base.mHasSeconadryWeapon && UnityEngine.Random.value < fLOATVALUE)
			{
				SwitchWeapon(isSecondary: true);
				mFireBatchSize = 1;
				mUseSecondaryWeapon = true;
			}
			PickPlayerOpponent(1f);
			break;
		}
		case UnitType.AttackerShooter:
			PickPlayerOpponent(0.2f);
			break;
		case UnitType.AttackerRusher:
			PickRusherTarget();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override EnemyPoint GetInitPoint()
	{
		if (mBuddyType == UnitType.AttackerRusher)
		{
			return base.GetInitPoint();
		}
		return SpawningManager.instance.GetPoint(this, 0f);
	}

	private bool Accept(EnemyPoint.EnemyPointType type, EnemyPoint point)
	{
		return (type & point.enemyPointType) == point.enemyPointType && controller.fraction == point.fraction;
	}

	public override bool AcceptsPoint(EnemyPoint point)
	{
		switch (mBuddyType)
		{
		case UnitType.Defender:
		case UnitType.AttackerExplosive:
			return Accept(EnemyPoint.EnemyPointType.Hiding, point);
		case UnitType.AttackerShooter:
			return Accept(EnemyPoint.EnemyPointType.Hiding | EnemyPoint.EnemyPointType.Corner, point);
		case UnitType.AttackerRusher:
			return Accept(EnemyPoint.EnemyPointType.Rusher | EnemyPoint.EnemyPointType.RusherSpare, point);
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override void StartEnemyBehaviour()
	{
	}

	public override void UpdateVisual()
	{
	}
}
