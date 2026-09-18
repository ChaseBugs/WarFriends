using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaveManager : Singleton<WaveManager>
{
	[Serializable]
	public class WaveDefinition
	{
		public string name;

		public int maxEnemies = 8;

		public int enemiesInWave;

		public List<WaveBehaviourDefinition> behaviourDefinitions;
	}

	[Serializable]
	public class BehaviourLevel
	{
		[ClassSelection(typeof(LevelBehaviour))]
		public string behaviorName;

		[Range(1f, 25f)]
		public int upgradesSingleLevel;
	}

	[Serializable]
	public class WaveBehaviourDefinition
	{
		[HideInInspector]
		public string name;

		public int sceneLimit;

		public int count;

		[HideInInspector]
		internal int generatedCount;

		[HideInInspector]
		internal int eventUnitsCount;

		[HideInInspector]
		internal int killedCount;

		public BehaviourLevel behaviourLevel;

		public int spawned => generatedCount - killedCount;

		public override string ToString()
		{
			string text = behaviourLevel.behaviorName.PadRight(40);
			text = text + " COUNT: " + ((count > 0) ? count.ToString("D2") : "INF");
			return text + " LIMIT: " + ((sceneLimit > 0) ? sceneLimit.ToString("D2") : "INF");
		}
	}

	public WaveDefinition waveDefinition;

	private SpawningManager mSpawningManager;

	private PhotonView mPhotonView;

	private NetworkObjectPool mPool;

	private bool mGenerationEnabled;

	private float mLastGenTime;

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			UpdateDefinition();
			mPhotonView = GetComponent<PhotonView>();
			mSpawningManager = GetComponent<SpawningManager>();
			mPool = ObjectPoolDatabase.networkPool;
			Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
			Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		}
	}

	protected override void Start()
	{
		base.Start();
		if (Application.isPlaying)
		{
			AIObject.AIObjectKilled += EnemyOnKilled;
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	protected void Update()
	{
		if (TimeManager.realTimeWithoutPauses > mLastGenTime + 0.25f)
		{
			mLastGenTime = TimeManager.realTimeWithoutPauses;
			if (mGenerationEnabled)
			{
				UpdateGeneration();
			}
		}
	}

	private void InstanceOnGameStarted()
	{
		if (!Singleton<GameController>.instance.isCampaign && (!Singleton<GameController>.instance.isCoop || !PhotonNetwork.isMasterClient))
		{
			return;
		}
		mGenerationEnabled = true;
		foreach (WaveBehaviourDefinition behaviourDefinition in waveDefinition.behaviourDefinitions)
		{
			behaviourDefinition.generatedCount = 0;
			behaviourDefinition.eventUnitsCount = 0;
			behaviourDefinition.killedCount = 0;
		}
		UpdateDefinition();
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		mGenerationEnabled = false;
	}

	private void EnemyOnKilled(AIObject aiObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (!mGenerationEnabled)
		{
			return;
		}
		if (!(aiObject != null))
		{
			return;
		}
		foreach (WaveBehaviourDefinition behaviourDefinition in waveDefinition.behaviourDefinitions)
		{
			LevelBehaviour levelBehaviour = Singleton<LevelBehaviourManager>.instance.behavioursDic[behaviourDefinition.behaviourLevel.behaviorName];
			if (levelBehaviour == aiObject.preparedBehaviour)
			{
				behaviourDefinition.killedCount++;
				break;
			}
		}
	}

	private void UpdateGeneration()
	{
		if (GetSpawnedUnitCount() >= waveDefinition.maxEnemies)
		{
			return;
		}
		List<WaveBehaviourDefinition> list = new List<WaveBehaviourDefinition>();
		foreach (WaveBehaviourDefinition behaviourDefinition in waveDefinition.behaviourDefinitions)
		{
			if ((behaviourDefinition.spawned < behaviourDefinition.sceneLimit || behaviourDefinition.sceneLimit <= 0) && (behaviourDefinition.generatedCount < behaviourDefinition.count + behaviourDefinition.eventUnitsCount || behaviourDefinition.count <= 0))
			{
				list.Add(behaviourDefinition);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			WaveBehaviourDefinition waveBehaviourDefinition = list[index];
			LevelBehaviour behaviour = Singleton<LevelBehaviourManager>.instance.behavioursDic[waveBehaviourDefinition.behaviourLevel.behaviorName];
			if (SpawnUnit(behaviour, waveBehaviourDefinition.behaviourLevel.upgradesSingleLevel))
			{
				waveBehaviourDefinition.generatedCount++;
			}
		}
	}

	private int GetSpawnedUnitCount()
	{
		int num = 0;
		foreach (WaveBehaviourDefinition behaviourDefinition in waveDefinition.behaviourDefinitions)
		{
			num += behaviourDefinition.spawned;
		}
		return num;
	}

	private void UpdateDefinition()
	{
		int num = 0;
		foreach (WaveBehaviourDefinition behaviourDefinition in waveDefinition.behaviourDefinitions)
		{
			behaviourDefinition.name = behaviourDefinition.behaviourLevel.behaviorName;
			num += behaviourDefinition.count;
		}
		waveDefinition.enemiesInWave = num;
	}

	public bool SpawnUnit(LevelBehaviour behaviour, int level)
	{
		Fractions fractions = Fractions.Enemies;
		if (!behaviour.CanBeSpawned(fractions, 1))
		{
			return false;
		}
		AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behaviour);
		if (aIObject != null && aIObject.prefab != null)
		{
			int num = mPool.prefabToIndexDic[aIObject.prefab];
			if (Singleton<GameController>.instance.isCoop)
			{
				level = Mathf.Clamp(level * 2, 1, 25);
			}
			mPhotonView.RPC("SpawnWaveAIObjectRPC", PhotonTargets.Others, num, aIObject.indexInObjectPool);
			aIObject.fraction = fractions;
			aIObject = (AIObject)mPool.ReInstantiate(num, aIObject.indexInObjectPool);
			aIObject.StartEnemyBehaviour();
			aIObject.transform.localScale = Vector3.one;
			return true;
		}
		return false;
	}

	[PunRPC]
	private void SpawnWaveAIObjectRPC(int indexInPool, int indexOfObject)
	{
		AIObject aIObject = mPool.ReInstantiate(indexInPool, indexOfObject, Vector3.one * 999999f, Quaternion.identity) as AIObject;
		aIObject.transform.localScale = Vector3.one;
		aIObject.fraction = Fractions.Enemies;
	}
}
