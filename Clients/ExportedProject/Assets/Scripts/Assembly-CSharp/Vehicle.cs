using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Vehicle<T> : MechanicalUnit<T>, IMechanicalUnit, IVehicle where T : LevelBehaviour
{
	private readonly List<EnemyController> mEnemies = new List<EnemyController>();

	protected bool mDoReverseAnim;

	public virtual bool isParked { get; protected set; }

	protected void DestroySoldier(EnemyPoint point, DestroyableObject.DamageInfo? info, Action<IGameMainEntity, DestroyableObject.DamageInfo> soldierOnKilled = null)
	{
		EnemyController enemyController = point.enemyAtPoint as EnemyController;
		if (enemyController != null && enemyController.enemyPoint == point)
		{
			if (info.HasValue)
			{
				enemyController.destroyableObject.Explode(info.Value.force, float.MaxValue, info.Value.weapon, info.Value.owner, isNetworkCopy: false);
			}
			else
			{
				info = new DestroyableObject.DamageInfo
				{
					isNetwork = false,
					damageAmount = float.MaxValue,
					force = Vector3.up,
					owner = null
				};
				enemyController.destroyableObject.DoDamage(info.Value);
			}
			if (soldierOnKilled != null)
			{
				enemyController.Killed -= soldierOnKilled;
			}
			point.enemyAtPoint = null;
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		foreach (EnemyController mEnemy in mEnemies)
		{
			mEnemy.DestroyPooled(changeParentBack: true);
		}
		mEnemies.Clear();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (!isPrewiev)
		{
			return;
		}
		foreach (EnemyController mEnemy in mEnemies)
		{
			mEnemy.DestroyPooled(changeParentBack: true);
		}
		mEnemies.Clear();
	}

	protected void SetShadowsActive(bool value)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer in array)
		{
			meshRenderer.shadowCastingMode = (value ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = true;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
		{
			skinnedMeshRenderer.shadowCastingMode = (value ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		isParked = false;
		mDoReverseAnim = false;
	}

	protected EnemyController GeneratePreviewEnemy(LevelBehaviour beh, EnemyPoint point, bool disableWeapon)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(beh);
		if (enemyController != null)
		{
			enemyController.isPrewiev = true;
			enemyController.fraction = PlayerController.currentPlayer.fraction;
			enemyController.DisableSpawn();
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, string.Empty);
			enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(enemyController);
			enemyController.transform.parent = point.transform;
			enemyController.transform.localPosition = default(Vector3);
			enemyController.transform.localRotation = Quaternion.identity;
			enemyController.transform.localScale = Vector3.one;
			mEnemies.Add(enemyController);
			enemyController.UpdatePreview(inGame: false);
			enemyController.soldierParts.MakeTrigger(value: true);
			if (disableWeapon)
			{
				enemyController.soldierBehaviour.currentWeapon.gameObject.SetActive(value: false);
			}
		}
		return enemyController;
	}

	public virtual void DoReverseAnim()
	{
		mDoReverseAnim = true;
	}

	protected void ClearEnemyPoint(EnemyPointVehicle point, Action<IGameMainEntity, DestroyableObject.DamageInfo> soldierOnKilled)
	{
		if (point != null && point.enemyAtPoint != null)
		{
			point.enemyAtPoint.Killed -= soldierOnKilled;
			point.enemyAtPoint = null;
		}
	}
}
