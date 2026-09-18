using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsHeadTest : Core_BaseScript
{
	private List<HeadSizeSetter> setters = new List<HeadSizeSetter>();

	public float scale = 1f;

	private new void Awake()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += InstanceOnPlayerDataLoaded;
	}

	private void Update()
	{
		foreach (HeadSizeSetter setter in setters)
		{
			setter.scaleF = scale;
		}
	}

	private void InstanceOnPlayerDataLoaded()
	{
		StartCoroutine(Show());
	}

	private IEnumerator Show()
	{
		yield return new WaitForSeconds(5f);
		int c = 0;
		foreach (LevelBehaviour behavior in LevelManager.instance.behaviours)
		{
			if (behavior is SoldierBehaviour)
			{
				yield return StartCoroutine(behavior.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(behavior, 1f), bought: true, mine: true));
				AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behavior);
				if (enemy != null && enemy.prefab != null)
				{
					enemy.isPrewiev = true;
					EnemyController mInstance = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(enemy);
					mInstance.transform.position = Vector3.right * c * 0.5f;
					mInstance.transform.localRotation = Quaternion.identity;
					mInstance.isPrewiev = true;
					mInstance.UpdatePreview(inGame: false);
					c++;
					HeadSizeSetter s = mInstance.GetComponentInChildren<HeadSizeSetter>();
					setters.Add(s);
					mInstance.mSoldierAnimationController.SampleIdle(Weapon.WeaponType.Riffle);
				}
			}
		}
	}
}
