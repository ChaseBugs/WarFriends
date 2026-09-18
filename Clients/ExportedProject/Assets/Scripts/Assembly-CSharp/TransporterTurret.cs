using System;
using System.Collections.Generic;
using UnityEngine;

public class TransporterTurret : TurretWeaponBasic
{
	public List<BatchedWeapon> weapons;

	protected override void Awake()
	{
		base.Awake();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.weapon.owner = mOwner;
		}
	}

	public override void Reset()
	{
		base.Reset();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.Reset();
		}
	}

	public override void PickTarget()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(mOwner.fraction, new Type[1] { typeof(Decoy) });
		if (opponents.Count > 0)
		{
			mTarget = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		}
		else
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(mOwner.fraction);
			mTarget = enemyOf.gameShootableEntity;
		}
		if (mTarget != null)
		{
			mPhotonView.RPC("AimNetwork", PhotonTargets.Others, mTarget.transform.position + aimOffset);
			if (!Aim(mTarget.transform.position + aimOffset, base.OnAimed))
			{
				mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
			}
		}
		else
		{
			mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
		}
	}

	protected override void StartShooting()
	{
		int batch = UnityEngine.Random.Range(batchSizeMin, batchSizeMax);
		Vector3 pos = default(Vector3);
		PlayerController playerController = mTarget.owner as PlayerController;
		GameShootableEntity.ShotTarget t = null;
		GameShootableEntity.ShotTarget shotTarget = null;
		if (playerController != null)
		{
			float num = Vector3.Angle(playerController.aimForward, mTransform.position - mTarget.mTransform.position);
			if (num < 50f && playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield && UnityEngine.Random.value > playerShieldProbability)
			{
				List<GameShootableEntity.ShotTarget> shotTargets = mTarget.GetShotTargets(GameShootableEntity.ShotTargetType.WholeBody);
				t = shotTargets[1];
				shotTarget = shotTargets[0];
			}
			else if (playerController.playerState == PlayerController.PlayerStatex.Walking)
			{
				t = mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.Moving, base.transform.position);
				shotTarget = t;
			}
			else
			{
				t = mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, base.transform.position);
				shotTarget = t;
			}
		}
		PlayerController playerController2 = mTarget.owner as PlayerController;
		if (playerController2 != null)
		{
			pos = t.transform.position;
			Ammo.ShotType s = Ammo.GetShotType(t);
			pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, playerController2.gameShootableEntity.velocity, 0f);
			float pr = realShotProbability;
			weapons[0].ShootBatch(t, pos, (int)((double)batch * 0.5), pr, s);
			pos = shotTarget.transform.position;
			s = Ammo.GetShotType(shotTarget);
			pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, playerController2.gameShootableEntity.velocity, 0f);
			InvokeAfter(delegate
			{
				weapons[1].ShootBatch(t, pos, batch - (int)((double)batch * 0.5), pr, s);
			}, (float)weapons[1].weapon.cadence * 0.5f);
		}
	}
}
