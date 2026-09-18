using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourMachineGunner : SoldierBehaviourGeneric<SoldierBehaviourDefinititonMachineGunner>
{
	private float mTimer;

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
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		Weapon weapon = mWeapons[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.cadence = 0.25f;
		mTimer = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(15f, 30f);
		weapon.bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		bulletSetup.realShotTexture = "shotReal";
	}

	public override void PickTarget()
	{
		if (!TryPickDecoy())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				PickPlayerOpponent(0.3f);
			}
			else
			{
				PickPlayerOpponent(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (controller != null && TimeManager.realTimeWithoutPauses > mTimer && controller.fraction == PlayerController.currentPlayer.fraction && Singleton<GameController>.instance.gameIsRunning && controller.isInField && controller.hasSpecial)
		{
			mTimer = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(30f, 60f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.shootableBox, controller.transform.position + Vector3.up * 0.2f + controller.transform.forward * 0.2f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.Mode.Ammo;
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
		}
	}
}
