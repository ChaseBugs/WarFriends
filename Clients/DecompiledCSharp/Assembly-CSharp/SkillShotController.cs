using UnityEngine;
using UnityEngine.Serialization;

public class SkillShotController : Core_BaseScript
{
	protected IGameMainEntity mGameEntity;

	[FormerlySerializedAs("mPosition")]
	public Transform skillshotPosition;

	protected PhotonView mPhotonView;

	private bool mIsMine;

	protected override void Awake()
	{
		base.Awake();
		mGameEntity = GetComponentImplementing<IGameMainEntity>();
		mGameEntity.Killed += GameEntityOnKilled;
		mPhotonView = GetComponent<PhotonView>();
	}

	protected virtual void GameEntityOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo info)
	{
		if (info.isNetwork)
		{
			return;
		}
		PlayerController playerController = info.owner as PlayerController;
		if (playerController != null)
		{
			SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
			float num = Singleton<SkillShotManager>.instance.longShotKillDistance * Singleton<SkillShotManager>.instance.longShotKillDistance;
			if (info.isOneHit)
			{
				skillShotType |= SkillShot.SkillShotType.OneHitKill;
			}
			if (mGameEntity is EnemyController)
			{
				EnemyController enemyController = mGameEntity as EnemyController;
				skillShotType |= SkillShot.SkillShotType.Kill;
				if (enemyController.isHeadShot)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot;
				}
				if (info.type == DestroyableObject.DamageType.Explosion)
				{
					skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
				}
				if (info.type == DestroyableObject.DamageType.Basic)
				{
					skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
				}
				if (enemyController.isCovered)
				{
					skillShotType |= SkillShot.SkillShotType.Covered;
				}
				if (enemyController.isRunning)
				{
					skillShotType |= SkillShot.SkillShotType.Runner;
				}
				if (enemyController.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.RevengeKill;
				}
			}
			if (mGameEntity is Drone)
			{
				Drone drone = mGameEntity as Drone;
				skillShotType |= SkillShot.SkillShotType.Kill;
				skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
				if (info.type == DestroyableObject.DamageType.Explosion)
				{
					skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
				}
				if (info.type == DestroyableObject.DamageType.Basic)
				{
					skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
				}
				if (drone.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.RevengeKill;
				}
			}
			if (mGameEntity is Tank)
			{
				Tank tank = mGameEntity as Tank;
				skillShotType |= SkillShot.SkillShotType.Kill;
				skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
				skillShotType |= SkillShot.SkillShotType.TankDestroyed;
				if (info.type == DestroyableObject.DamageType.Explosion)
				{
					skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
				}
				if (info.type == DestroyableObject.DamageType.Basic)
				{
					skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
				}
				if (tank.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.RevengeKill;
				}
			}
			if (mGameEntity is AICar || mGameEntity is AICarBuggy || mGameEntity is AICarTransporter || mGameEntity is Helicopter || mGameEntity is AssaultHelicopter || mGameEntity is Mech)
			{
				AIObject aIObject = mGameEntity as AIObject;
				skillShotType |= SkillShot.SkillShotType.Kill;
				skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
				if (info.type == DestroyableObject.DamageType.Explosion)
				{
					skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
				}
				if (info.type == DestroyableObject.DamageType.Basic)
				{
					skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
				}
				if (aIObject.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.RevengeKill;
				}
			}
			if (Time.timeScale < 0.4f)
			{
				skillShotType |= SkillShot.SkillShotType.SlowMotionKill;
			}
			if (info.weapon != null && (base.transform.position - info.weapon.transform.position).sqrMagnitude > num && info.type == DestroyableObject.DamageType.Shot)
			{
				skillShotType |= SkillShot.SkillShotType.LongShot;
			}
			mIsMine = playerController.isCurrentPlayer;
			SkillShot skillShot = new SkillShot();
			skillShot.type = skillShotType;
			SkillShot skillShot2 = skillShot;
			Singleton<SkillShotManager>.instance.RecieveKill(ref skillShot2);
			if (playerController.fraction != gameMainEntity.fraction)
			{
				Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
				if (mIsMine)
				{
					PlaySkillshot(skillShot2, info.isCritical && playerController.fraction != mGameEntity.fraction, gameMainEntity.power);
				}
				else
				{
					mPhotonView.RPC("RecieveSkillshot", PhotonTargets.Others, (int)skillShot2.type, gameMainEntity.power, playerController.playerNetworkId);
				}
			}
			if (mGameEntity is AIObject)
			{
				StatsManager.instance.AddWeaponKill(PlayerController.currentPlayer.weaponInventory.currentWeapon.weaponLevelSetup.indexInLevelManager);
			}
			return;
		}
		if (info.owner is IGameMainEntity gameMainEntity2)
		{
			Fractions fraction = PlayerController.currentPlayer.fraction;
			Fractions fraction2 = mGameEntity.fraction;
			if (gameMainEntity2.fraction != fraction2)
			{
				SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.ArmyKill;
				if (fraction2 != fraction)
				{
					SkillShot skillShot = new SkillShot();
					skillShot.type = skillShotType2;
					SkillShot skillShot3 = skillShot;
					PlaySkillshot(skillShot3, isCritical: false, mGameEntity.power);
					Singleton<SkillShotManager>.instance.AddSkillshot(skillShot3, PlayerController.currentPlayer);
				}
				else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
				{
					mPhotonView.RPC("RecieveSkillshot", PhotonTargets.Others, (int)skillShotType2, mGameEntity.power, Singleton<GameController>.instance.opponent.playerNetworkId);
					Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
					{
						type = skillShotType2
					}, Singleton<GameController>.instance.opponent);
				}
			}
			return;
		}
		Fractions fraction3 = PlayerController.currentPlayer.fraction;
		Fractions fraction4 = mGameEntity.fraction;
		if (fraction4 != fraction3 && (info.type == DestroyableObject.DamageType.Basic || info.type == DestroyableObject.DamageType.Explosion))
		{
			SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.Kill | SkillShot.SkillShotType.EnviromentalKill;
			if (info.type == DestroyableObject.DamageType.Explosion)
			{
				skillShotType3 |= SkillShot.SkillShotType.ExplosiveKill;
			}
			SkillShot skillShot = new SkillShot();
			skillShot.type = skillShotType3;
			SkillShot skillShot4 = skillShot;
			PlaySkillshot(skillShot4, isCritical: false, mGameEntity.power);
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot4, PlayerController.currentPlayer);
		}
	}

	[PunRPC]
	protected void RecieveSkillshot(int type, int power, int playerId)
	{
		SkillShot skillShot = new SkillShot();
		skillShot.type = (SkillShot.SkillShotType)type;
		SkillShot skillShot2 = skillShot;
		PlaySkillshot(skillShot2, isCritical: false, power);
		Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, PlayerController.players[playerId]);
	}

	protected void PlaySkillshot(SkillShot skillShot, bool isCritical, int power)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayer);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(skillshotPosition.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayDeath(power, skillShot);
			if (isCritical)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}
}
