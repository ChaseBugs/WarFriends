using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelBehaviourManager : Singleton<LevelBehaviourManager>
{
	[Serializable]
	public class BehaviourEntry
	{
		[HideInInspector]
		public string name = "hide";

		public LevelBehaviour behaviour;

		public int maxCount = int.MaxValue;

		[NonSerialized]
		[HideInInspector]
		public int count;
	}

	public List<BehaviourEntry> levelBehaviours;

	public Dictionary<string, LevelBehaviour> behavioursDic = new Dictionary<string, LevelBehaviour>();

	public Dictionary<LevelBehaviour, List<AIObject>> preparedInstancies = new Dictionary<LevelBehaviour, List<AIObject>>();

	protected override void Awake()
	{
		base.Awake();
		foreach (BehaviourEntry levelBehaviour in levelBehaviours)
		{
			behavioursDic[levelBehaviour.behaviour.GetType().Name] = levelBehaviour.behaviour;
		}
		foreach (BehaviourEntry levelBehaviour2 in levelBehaviours)
		{
			LevelBehaviour behaviour = levelBehaviour2.behaviour;
			if (!(behaviour.unitName == "ID_UNIT-BUDDY"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "-DESCRIPTION");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "-ABILITY");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "-BUFF");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "-ELITEPARTS");
			}
		}
		GameShootableEntity.Init();
	}

	public T GetPreparedBehaviour<T>() where T : LevelBehaviour
	{
		T val = (T)null;
		int index = 0;
		for (int i = 0; i < levelBehaviours.Count; i++)
		{
			BehaviourEntry behaviourEntry = levelBehaviours[i];
			if (behaviourEntry.behaviour is T)
			{
				index = i;
				if (behaviourEntry.count < behaviourEntry.maxCount)
				{
					break;
				}
			}
		}
		levelBehaviours[index].count++;
		val = levelBehaviours[index].behaviour as T;
		if (val == null)
		{
			Debug.LogError(string.Concat("Null +", typeof(T), " ", levelBehaviours[index].behaviour.ToString()));
		}
		return val;
	}

	protected override void Start()
	{
		if (Application.isPlaying)
		{
			base.Start();
			PrepareInstancies();
		}
	}

	private void PrepareInstancies()
	{
		foreach (BehaviourEntry levelBehaviour in levelBehaviours)
		{
			preparedInstancies.Add(levelBehaviour.behaviour, new List<AIObject>());
		}
		Singleton<ObjectPoolDatabase>.instance.enemy.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.drone.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.humvee.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.helicopter.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.tank.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.turret.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.heavyTurret.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.buggy.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.assaultHelicopter.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.transporter.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.turretRockets.PrepareInstancies();
		Singleton<ObjectPoolDatabase>.instance.mech.PrepareInstancies();
	}

	public AIObject GenerateNewEnemy(LevelBehaviour levelBehaviour)
	{
		if (levelBehaviour != null)
		{
			List<AIObject> list = preparedInstancies[levelBehaviour];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.isInstantiated)
				{
					return item;
				}
			}
		}
		return null;
	}
}
