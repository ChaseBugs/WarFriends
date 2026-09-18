using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourWarper : SoldierBehaviourRusher<SoldierBehaviourDefinititonFlamethrower>
{
	public float thinTrailDistance = 2f;

	public Material transparentWarp;

	private WarpTrails mWarpTrails;

	private Material mOriginalmaterial;

	public void ChangeToTransparent()
	{
		base.mSoldierMeshChanger.ChangeMaterial(transparentWarp);
		base.mSoldierMeshChanger.bodyAttachemnts.SetAttachmentsMaterial(transparentWarp);
		base.mSoldierMeshChanger.helmetAttachments.SetAttachmentsMaterial(transparentWarp);
		currentWeapon.gameObject.SetActive(value: false);
		if (mWarpTrails != null)
		{
			mWarpTrails.mainTrail.gameObject.SetActive(value: true);
			mWarpTrails.additionalTrail.gameObject.SetActive(value: true);
		}
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, Sounds3DEnum.WarpSound);
	}

	public void ChangeToNormalMat()
	{
		base.mSoldierMeshChanger.ChangeMaterial(mOriginalmaterial);
		base.mSoldierMeshChanger.bodyAttachemnts.SetAttachmentsMaterial(mOriginalmaterial);
		base.mSoldierMeshChanger.helmetAttachments.SetAttachmentsMaterial(mOriginalmaterial);
		currentWeapon.gameObject.SetActive(value: true);
		mEnemyBasicInventory.SwitchWeapon(0);
	}

	public override void UpdateVisual()
	{
		if (mOriginalmaterial == null)
		{
			mOriginalmaterial = base.mSoldierMeshChanger.material;
		}
		if (mWarpTrails == null)
		{
			mWarpTrails = controller.GetComponent<WarpTrails>();
		}
		if (mOriginalmaterial != null)
		{
			base.mSoldierMeshChanger.ChangeMaterial(mOriginalmaterial);
		}
		base.UpdateVisual();
	}

	public override void StartEnemyBehaviour()
	{
		controller.StartEnemyBehaviour(EnemyController.EnemyAIState.Warp);
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

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].cadence = 0.2f;
		ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)mWeapons[0].ammoSetup;
		shotGunBulletSetup.maxDamage = base.soldierBehaviourDefinititon.damage;
		shotGunBulletSetup.minDamage = (float)base.soldierBehaviourDefinititon.damage * 0.1f;
		shotGunBulletSetup.realShotTexture = "shotReal";
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

	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
		if (controller.enemyAiState == EnemyController.EnemyAIState.Rusher)
		{
			InvokeAfter(delegate
			{
				controller.WarpAgain();
			}, 1f);
		}
	}

	public override void OnDeath(DestroyableObject.DamageInfo damageInfo)
	{
		base.OnDeath(damageInfo);
		ChangeToNormalMat();
	}

	public override void DestroyBehaviour()
	{
		base.DestroyBehaviour();
		if (mWarpTrails != null)
		{
			mWarpTrails.mainTrail.gameObject.SetActive(value: false);
			mWarpTrails.additionalTrail.gameObject.SetActive(value: false);
		}
		if (controller != null)
		{
			controller.agent.speed = 0.8f;
		}
	}

	public override void Copy(AIObject to)
	{
		base.Copy(to);
		WarpTrails component = GetComponent<WarpTrails>();
		WarpTrails warpTrails = to.gameObject.AddComponent<WarpTrails>();
		warpTrails.mainTrail = UnityEngine.Object.Instantiate(component.mainTrail);
		warpTrails.additionalTrail = UnityEngine.Object.Instantiate(component.additionalTrail);
		warpTrails.mainTrail.gameObject.transform.parent = to.gameObject.transform;
		warpTrails.mainTrail.gameObject.transform.localPosition = component.mainTrail.transform.localPosition;
		warpTrails.additionalTrail.gameObject.transform.parent = to.gameObject.transform;
		warpTrails.additionalTrail.gameObject.transform.localPosition = component.additionalTrail.transform.localPosition;
	}
}
