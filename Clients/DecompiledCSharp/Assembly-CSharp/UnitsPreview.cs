using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitsPreview
{
	public static readonly List<AIObject> soldiers = new List<AIObject>();

	private static readonly List<AIObject> vehicles = new List<AIObject>();

	private static int mVehiclesCount;

	private static int mHeliCount;

	public static void DestroyArmy()
	{
		Singleton<GameCamera>.instance.cameraHUD.SetActive(value: false);
		try
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.preparedInstancies[behaviour][0];
				if (aIObject != null && aIObject.prefab != null)
				{
					ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(aIObject.prefab);
				}
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	public static void LoadSoldierPositions()
	{
		try
		{
			List<Vector3> positions = Singleton<GameCamera>.instance.positions;
			List<Quaternion> rotations = Singleton<GameCamera>.instance.rotations;
			for (int i = 0; i < soldiers.Count; i++)
			{
				EnemyController enemyController = (EnemyController)soldiers[i];
				if (enemyController != null)
				{
					Transform transform = PlayerController.currentPlayer.currentPlayerPoint.point.transform;
					Vector3 vector = GetCenter(PlayerController.currentPlayer) + transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * positions[i];
					Vector3 vector2 = transform.forward * 2f;
					NavMesh.SamplePosition(vector + vector2, out var hit, 10f, 1);
					enemyController.transform.position = hit.position;
					enemyController.transform.rotation = transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * rotations[i];
					enemyController.transform.localScale = Vector3.one;
					enemyController.StartAnim(vector);
				}
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	public static void SoldiersGoBack()
	{
		Singleton<GameCamera>.instance.StartCoroutine(FadeOutSounds());
		try
		{
			List<Vector3> positions = Singleton<GameCamera>.instance.positions;
			for (int i = 0; i < soldiers.Count; i++)
			{
				EnemyController enemyController = (EnemyController)soldiers[i];
				if (enemyController != null)
				{
					Transform transform = PlayerController.currentPlayer.currentPlayerPoint.point.transform;
					Vector3 vector = GetCenter(PlayerController.currentPlayer) + transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * positions[i];
					Vector3 vector2 = transform.forward * 3f;
					enemyController.StartAnim(vector + vector2);
				}
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	public static void VehiclesGoBack()
	{
		foreach (AIObject vehicle in vehicles)
		{
			if (vehicle is IMechanicalUnit mechanicalUnit)
			{
				mechanicalUnit.DoReverseAnim();
			}
		}
	}

	public static Vector3 GetCenter(PlayerController p)
	{
		bool flag = true;
		List<MapDefinition.DefendPosition> playersPositions = Singleton<MapManager>.instance.currentMapDef.playersPositions;
		Vector3 a = ((p.currentPlayerPoint.index <= 3) ? playersPositions[0].point.transform.position : playersPositions[4].point.transform.position);
		Vector3 b = ((p.currentPlayerPoint.index <= 3) ? playersPositions[3].point.transform.position : playersPositions[7].point.transform.position);
		return Vector3.Lerp(a, b, 0.5f);
	}

	public static Vector3 GetVehiclePosition(PlayerController p, LevelBehaviour b)
	{
		bool flag = true;
		List<MapDefinition.DefendPosition> playersPositions = Singleton<MapManager>.instance.currentMapDef.playersPositions;
		Vector3 vector = ((p.currentPlayerPoint.index <= 3) ? playersPositions[0].point.transform.position : playersPositions[4].point.transform.position);
		Vector3 vector2 = ((p.currentPlayerPoint.index <= 3) ? playersPositions[3].point.transform.position : playersPositions[7].point.transform.position);
		vector -= p.currentPlayerPoint.point.transform.forward * 0.1f;
		vector2 -= p.currentPlayerPoint.point.transform.forward * 0.1f;
		if (b is HelicopterBehaviour || b is AssaultHelicopterBehaviour)
		{
			if (mHeliCount > 0)
			{
				flag = false;
			}
			mHeliCount++;
			Vector3 vector3 = (vector2 - vector).normalized;
			if (flag)
			{
				vector3 = -vector3;
			}
			if (flag)
			{
				return vector + vector3 + 2f * Vector3.up;
			}
			return vector2 + vector3 + 2f * Vector3.up + 0.3f * Vector3.up;
		}
		if (b is CarBehaviour || b is CarBuggyBehaviour || b is TankBehaviour || b is CarTransporterBehaviour)
		{
			Vector3 normalized = (vector - vector2).normalized;
			mVehiclesCount++;
			Vector3 zero = Vector3.zero;
			switch (mVehiclesCount)
			{
			case 1:
				normalized = (vector - vector2).normalized * 1.2f;
				zero = vector + normalized;
				break;
			case 2:
				normalized = (vector2 - vector).normalized * 1.2f;
				zero = vector2 + normalized;
				break;
			case 3:
				normalized = p.currentPlayerPoint.point.transform.forward * 1.8f + (vector - vector2).normalized * 0.3f;
				zero = vector + normalized;
				break;
			default:
				normalized = p.currentPlayerPoint.point.transform.forward * 1.8f + (vector2 - vector).normalized * 0.3f;
				zero = vector2 + normalized;
				break;
			}
			if (NavMesh.SamplePosition(zero, out var hit, 10f, 1))
			{
				zero = hit.position;
			}
			Vector3 position = hit.position;
			return zero;
		}
		if (b is MechBehaviour)
		{
			Vector3 vector4 = p.currentPlayerPoint.point.transform.forward * 3f;
			Vector3 vector5 = Vector3.Lerp(vector, vector2, 0.5f);
			Vector3 vector6 = vector5 + vector4;
			if (NavMesh.SamplePosition(vector6, out var hit2, 10f, 1))
			{
				vector6 = hit2.position;
			}
			return vector6;
		}
		return Vector3.Lerp(vector, vector2, 0.5f) + Vector3.up * 0.5f + p.currentPlayerPoint.point.transform.forward * 1f + p.currentPlayerPoint.point.transform.right * 2.6f + 0.3f * Vector3.up;
	}

	public static Vector3 GetSoldierPos(int i, int total)
	{
		return Vector3.zero;
	}

	public static void GenerateArmy()
	{
		Singleton<GameCamera>.instance.cameraHUD.SetActive(value: false);
		soldiers.Clear();
		vehicles.Clear();
		int num = 0;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		List<LevelBehaviour> list2 = new List<LevelBehaviour>();
		List<Bounds> list3 = new List<Bounds>();
		PlayerController master = PlayerController.GetMaster();
		List<UnitUpgradeDefinition> upgrades = master.playerProperties.upgrades;
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			if (levelBehaviour is SoldierBehaviour)
			{
				list.Add(levelBehaviour);
			}
		}
		for (int j = 0; j < LevelManager.instance.behaviours.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = LevelManager.instance.behaviours[j];
			bool isEquipped = upgrades[j].isEquipped;
			if (!(levelBehaviour2 is SoldierBehaviour) && isEquipped)
			{
				list2.Add(levelBehaviour2);
			}
		}
		Crittercism.LeaveBreadcrumb("Generate army 1");
		try
		{
			for (int k = 0; k < list.Count; k++)
			{
				LevelBehaviour levelBehaviour3 = list[k];
				if (upgrades[levelBehaviour3.indexInLevelsManager].isEquipped)
				{
					AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(levelBehaviour3);
					if (aIObject != null && aIObject.prefab != null)
					{
						aIObject.isPrewiev = true;
						aIObject.fraction = PlayerController.currentPlayer.fraction;
						AIObject aIObject2 = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject);
						soldiers.Add(aIObject2);
						Vector3 soldierPos = GetSoldierPos(num, list.Count);
						aIObject2.transform.position = soldierPos;
						Vector3 forward = Singleton<MapManager>.instance.currentMapDef.floorTransform.position - soldierPos;
						aIObject2.transform.rotation = Quaternion.LookRotation(forward);
						aIObject2.isPrewiev = true;
						aIObject2.UpdatePreview(inGame: true);
						num++;
					}
				}
				else
				{
					soldiers.Add(null);
				}
			}
			Crittercism.LeaveBreadcrumb("Generate army 2");
			mHeliCount = 0;
			mVehiclesCount = 0;
			foreach (LevelBehaviour item in list2)
			{
				AIObject aIObject3 = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(item);
				if (aIObject3 != null && aIObject3.prefab != null)
				{
					aIObject3.isPrewiev = true;
					aIObject3.fraction = PlayerController.currentPlayer.fraction;
					AIObject aIObject4 = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject3);
					ArmyUnit3DModel component = aIObject4.GetComponent<ArmyUnit3DModel>();
					Vector3 vehiclePosition = GetVehiclePosition(PlayerController.currentPlayer, item);
					aIObject4.transform.position = vehiclePosition;
					Vector3 forward2 = Singleton<MapManager>.instance.currentMapDef.floorTransform.position - vehiclePosition;
					forward2.y = 0f;
					aIObject4.transform.rotation = Quaternion.LookRotation(forward2);
					aIObject4.isPrewiev = true;
					aIObject4.UpdatePreview(inGame: true);
					vehicles.Add(aIObject4);
					num++;
				}
			}
			Crittercism.LeaveBreadcrumb("Generate army 3");
			LoadSoldierPositions();
			Crittercism.LeaveBreadcrumb("Generate army 4");
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	public static void ShowNew()
	{
		bool wasAlreadyUsed;
		LevelBehaviour lastBoughtUnit = PlayerAnalytics.instance.GetLastBoughtUnit(out wasAlreadyUsed);
		if (wasAlreadyUsed)
		{
			return;
		}
		for (int i = 0; i < soldiers.Count; i++)
		{
			EnemyController enemyController = (EnemyController)soldiers[i];
			if (enemyController != null && enemyController.preparedBehaviour == lastBoughtUnit && lastBoughtUnit.upgradeSlots.unlockLevelIndex != 0)
			{
				NewUnitLabel(enemyController);
			}
		}
		for (int j = 0; j < vehicles.Count; j++)
		{
			AIObject aIObject = vehicles[j];
			if (aIObject != null && aIObject.preparedBehaviour == lastBoughtUnit && lastBoughtUnit.upgradeSlots.unlockLevelIndex != 0)
			{
				NewUnitLabel(aIObject);
			}
		}
	}

	private static void NewUnitLabel(AIObject aiObject)
	{
		SkillShotController component = aiObject.GetComponent<SkillShotController>();
		if (component != null)
		{
			NewUnitDisplayerItem newUnitDisplayerItem = UnityEngine.Object.Instantiate(Singleton<ObjectPoolDatabase>.instance.newUnitDisplayer);
			newUnitDisplayerItem.Play(aiObject.behaviour.unitName, component.skillshotPosition.transform.position);
		}
		else
		{
			Debug.LogError(aiObject.gameObject.name + " has no SkillShotController");
		}
	}

	private static IEnumerator FadeOutSounds()
	{
		List<AudioSource> audioSources = new List<AudioSource>();
		foreach (AIObject vehicle in vehicles)
		{
			vehicle.GetAudioSources(audioSources);
		}
		float fadeOutTime = 0.75f;
		float startTime = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup - startTime <= fadeOutTime)
		{
			float fadeOutAmount = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / fadeOutTime);
			foreach (AudioSource audioSource in audioSources)
			{
				audioSource.volume = 1f - fadeOutAmount;
			}
			yield return null;
		}
	}
}
