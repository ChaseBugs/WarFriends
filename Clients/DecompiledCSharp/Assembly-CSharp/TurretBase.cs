using UnityEngine;

public class TurretBase<T, U> : MechanicalUnit<T> where T : TurretBaseBehaviourG<U> where U : VehicleBehaviourDefinititon
{
	public TurretWeaponBasic turretWeapon;

	protected PhotonView mPhotonView;

	protected DestroyableObject mDestroyableObject;

	private TurretPosition mTurretPosition;

	public GameObject shadow;

	public override DestroyableObject destroyableObj => mDestroyableObject;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		mDestroyableObject = GetComponent<DestroyableObject>();
		mDestroyableObject.isMetal = true;
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		turretWeapon.turretParent = base.gameObject.transform;
		mSpawnEnabled = false;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		turretWeapon.Reset();
		turretWeapon.ResetAiming();
		turretWeapon.enabled = true;
		if (shadow != null)
		{
			shadow.gameObject.SetActive(value: true);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mSpawnEnabled = false;
		if (mTurretPosition != null)
		{
			mTurretPosition.used = false;
			mTurretPosition = null;
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		DestroyableObject destroyableObject = mDestroyableObject;
		T val = base.currentBeh;
		destroyableObject.maxHealth = val.turretBehaviour.health;
		mDestroyableObject.RefillOffline();
		AmmoSetup ammoSetup = turretWeapon.batchedWeapon.weapon.ammoSetup;
		T val2 = base.currentBeh;
		ammoSetup.damageAmount = val2.turretBehaviour.damage;
		ammoSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		ammoSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		TurretWeaponBasic turretWeaponBasic = turretWeapon;
		T val3 = base.currentBeh;
		turretWeaponBasic.minShootTime = val3.turretBehaviour.minShootTime;
		TurretWeaponBasic turretWeaponBasic2 = turretWeapon;
		T val4 = base.currentBeh;
		turretWeaponBasic2.maxShootTime = val4.turretBehaviour.maxShootTime;
		TurretWeaponBasic turretWeaponBasic3 = turretWeapon;
		T val5 = base.currentBeh;
		turretWeaponBasic3.batchSizeMin = val5.turretBehaviour.fireBatchSizeMin;
		TurretWeaponBasic turretWeaponBasic4 = turretWeapon;
		T val6 = base.currentBeh;
		turretWeaponBasic4.batchSizeMax = val6.turretBehaviour.fireBatchSizeMax;
		BulletSetup bulletSetup = ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			T val7 = base.currentBeh;
			bulletSetup.speed = val7.turretBehaviour.shotSpeed;
		}
		turretWeapon.Reset();
		if (isPrewiev)
		{
			turretWeapon.enabled = false;
		}
		turretWeapon.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
		OnKilled(damageInfo);
		DestroyEntity(0.2f);
		if (damageInfo.type != DestroyableObject.DamageType.Explosion)
		{
			Explosion.PlayEffects(Explosion.ExplosionType.Medium, damageInfo.hitPosition);
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		if (!photonView.isMine || !mSpawnEnabled)
		{
			return;
		}
		PlayerController player = PlayerController.GetPlayer(fraction);
		if (!(player != null))
		{
			return;
		}
		float num = float.MaxValue;
		TurretPosition turretPosition = null;
		int num2 = -1;
		int num3 = -1;
		for (int i = 0; i < Singleton<MapManager>.instance.currentMapDef.playersPositions.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = Singleton<MapManager>.instance.currentMapDef.playersPositions[i];
			if (defendPosition.fraction != fraction)
			{
				continue;
			}
			for (int j = 0; j < defendPosition.point.turretPositions.Count; j++)
			{
				TurretPosition turretPosition2 = defendPosition.point.turretPositions[j];
				if (!turretPosition2.used)
				{
					float sqrMagnitude = (player.position - turretPosition2.transform.position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						turretPosition = turretPosition2;
						num2 = i;
						num3 = j;
					}
				}
			}
		}
		if (turretPosition != null)
		{
			mTurretPosition = turretPosition;
			mTurretPosition.used = true;
			SetTurretWorldPosition();
			mPhotonView.RPC("SetShieldPositionRPC", PhotonTargets.Others, num2, num3);
		}
	}

	private void SetTurretWorldPosition()
	{
		NavMesh.SamplePosition(mTurretPosition.transform.position, out var hit, 10f, 1);
		Vector3 position = hit.position;
		base.transform.position = position;
	}

	[PunRPC]
	protected void SetShieldPositionRPC(int playerPositionIndex, int turretPositionIndex)
	{
		mTurretPosition = Singleton<MapManager>.instance.currentMapDef.playersPositions[playerPositionIndex].point.turretPositions[turretPositionIndex];
		SetTurretWorldPosition();
	}

	public void HideShadow()
	{
		if (shadow != null)
		{
			shadow.gameObject.SetActive(value: false);
		}
	}
}
