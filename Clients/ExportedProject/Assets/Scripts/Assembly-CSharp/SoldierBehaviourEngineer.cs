using UnityEngine;

public class SoldierBehaviourEngineer : SoldierBehaviourGeneric<SoldierBehaviourDefinititonEngineer>
{
	private Turret mTurret;

	public override bool AcceptsPoint(EnemyPoint point)
	{
		if (point.enemyPointType == EnemyPoint.EnemyPointType.EngineerTurret && controller.fraction == point.fraction)
		{
			return true;
		}
		return false;
	}

	public override void UpdateVisual()
	{
		base.UpdateVisual();
		if (controller.isPrewiev && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			if (mTurret == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour);
				aIObject.isPrewiev = true;
				mTurret = (Turret)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject);
				mTurret.transform.parent = controller.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			mTurret.HideShadow();
			mTurret.LoadUpgrades(turretUpgradeLevel, 1f, 1f);
			controller.transform.localScale = new Vector3(0.666f, 0.666f, 0.666f);
			controller.transform.localPosition = new Vector3(0.09f, -0.16f, 0f);
			mTurret.transform.localPosition = new Vector3(-0.25f, 0f, 0f);
			mTurret.transform.localRotation = Quaternion.Euler(0f, 28f, 0f);
			mTurret.transform.localScale = Vector3.one * 0.9f;
			mTurret.isPrewiev = true;
			ArmyUnit3DModel component = controller.GetComponent<ArmyUnit3DModel>();
			component.slots[2].slotPosition = mTurret.slotsTurret.transform;
		}
	}

	private void OnDisable()
	{
		if (mTurret != null)
		{
			mTurret.pool.InvokeAfter(delegate
			{
				mTurret.DestroyPooled(changeParentBack: true);
				mTurret = null;
			}, 0.005f);
		}
	}
}
