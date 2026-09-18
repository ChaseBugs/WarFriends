using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : Singleton<SpawningManager>
{
	private static SpawningManager _instance;

	public List<EnemyPoint> enemyPoints;

	private List<EnemyPoint> mAllPosiblePointsForEnemy;

	private bool mDataLoaded;

	private PhotonView mPhotonView;

	private NetworkObjectPool mPool;

	public new static SpawningManager instance
	{
		get
		{
			_instance = _instance ?? ((SpawningManager)Object.FindObjectsOfType(typeof(SpawningManager))[0]);
			return _instance;
		}
	}

	public new void OnDestroy()
	{
		_instance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		mPool = ObjectPoolDatabase.networkPool;
		Singleton<MapManager>.instance.NewLevelLoaded += InstanceOnNewLevelLoaded;
	}

	private void InstanceOnNewLevelLoaded()
	{
		enemyPoints = Singleton<MapManager>.instance.currentMapDef.enemyPointsCollection.enemyPoints;
	}

	public int GetBehaviourIndex(LevelBehaviour beh)
	{
		List<LevelBehaviourManager.BehaviourEntry> levelBehaviours = Singleton<LevelBehaviourManager>.instance.levelBehaviours;
		for (int i = 0; i < levelBehaviours.Count; i++)
		{
			LevelBehaviourManager.BehaviourEntry behaviourEntry = levelBehaviours[i];
			if (beh == behaviourEntry.behaviour)
			{
				return i;
			}
		}
		return -1;
	}

	public void SpawnForCard(LevelBehaviour behaviour, int count, float progress, Fractions fraction, Vector3 position, bool spawnEnabled = true)
	{
		if (mPhotonView.isMine)
		{
			StartCoroutine(RadicalRoutine.Run(SpawnUnitsByCard(behaviour, fraction, progress, count, position, spawnEnabled)));
			return;
		}
		int behaviourIndex = GetBehaviourIndex(behaviour);
		mPhotonView.RPC("SpawnForCardRPC", PhotonTargets.Others, behaviourIndex, count, progress, (byte)fraction, position, spawnEnabled);
	}

	[PunRPC]
	private void SpawnForCardRPC(int behaviourIndex, int count, float progress, byte fraction, Vector3 position, bool spawnEnabled)
	{
		List<LevelBehaviourManager.BehaviourEntry> levelBehaviours = Singleton<LevelBehaviourManager>.instance.levelBehaviours;
		StartCoroutine(RadicalRoutine.Run(SpawnUnitsByCard(levelBehaviours[behaviourIndex].behaviour, (Fractions)fraction, progress, count, position, spawnEnabled)));
	}

	private IEnumerator SpawnUnitsByCard(LevelBehaviour beh, Fractions fraction, float progress, int count, Vector3 pos, bool spawnEnabled)
	{
		for (int i = 0; i < count; i++)
		{
			AIObject enemy = SpawnCardBehaviour(beh, fraction, progress, pos, spawnEnabled);
			yield return new WaitForRealSeconds(0.3f);
		}
	}

	public AIObject SpawnCardBehaviour(LevelBehaviour beh, Fractions fraction, float progress, Vector3 pos, bool spawnEnabled, string cardId = null)
	{
		AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(beh);
		if (spawnEnabled)
		{
			aIObject.EnableSpawn();
		}
		else
		{
			aIObject.DisableSpawn();
		}
		if (cardId == null)
		{
			cardId = beh.cardId;
		}
		aIObject.SpawnByCard(progress, cardId);
		Spawn(aIObject, fraction, useEnergy: false, pos);
		return aIObject;
	}

	public void Spawn(AIObject enemy, Fractions fraction, bool useEnergy, Vector3 pos, bool startBehaviour = true)
	{
		if (enemy != null && enemy.prefab != null)
		{
			int num = mPool.prefabToIndexDic[enemy.prefab];
			mPhotonView.RPC("SpawnAIObjectRPC", PhotonTargets.Others, num, enemy.indexInObjectPool, (byte)fraction, pos);
			enemy.fraction = fraction;
			enemy = (AIObject)mPool.ReInstantiate(num, enemy.indexInObjectPool, pos, Quaternion.identity);
			enemy.transform.localScale = Vector3.one;
			if (!useEnergy)
			{
				enemy.power = 0;
			}
			if (startBehaviour)
			{
				enemy.StartEnemyBehaviour();
			}
		}
	}

	[PunRPC]
	private void SpawnAIObjectRPC(int indexInPool, int indexOfObject, byte fraction, Vector3 pos)
	{
		AIObject aIObject = mPool.pooledObjects[indexInPool][indexOfObject] as AIObject;
		aIObject.fraction = (Fractions)fraction;
		AIObject aIObject2 = mPool.ReInstantiate(indexInPool, indexOfObject, pos, Quaternion.identity) as AIObject;
		aIObject2.transform.localScale = Vector3.one;
		aIObject2.fraction = (Fractions)fraction;
	}

	public EnemyPoint GetNextFreeEnemyPoint(EnemyPoint enemyPoint, SoldierBehaviour soldierBehaviour)
	{
		mAllPosiblePointsForEnemy = new List<EnemyPoint>();
		foreach (EnemyPoint enemyPoint2 in enemyPoints)
		{
			float num = Vector3.Distance(enemyPoint2.position, PlayerController.currentPlayer.transform.position);
			if (soldierBehaviour.AcceptsPoint(enemyPoint2) && enemyPoint2.isFree && enemyPoint2 != enemyPoint)
			{
				mAllPosiblePointsForEnemy.Add(enemyPoint2);
			}
		}
		if (mAllPosiblePointsForEnemy.Count > 0)
		{
			int index = Random.Range(0, mAllPosiblePointsForEnemy.Count);
			return mAllPosiblePointsForEnemy[index];
		}
		return null;
	}

	public List<EnemyPoint> GetFreeEnemyPoints(EnemyPoint enemyPoint, SoldierBehaviour soldierBehaviour)
	{
		mAllPosiblePointsForEnemy = new List<EnemyPoint>();
		foreach (EnemyPoint enemyPoint2 in enemyPoints)
		{
			if (soldierBehaviour.AcceptsPoint(enemyPoint2) && enemyPoint2.isFree && enemyPoint2 != enemyPoint)
			{
				mAllPosiblePointsForEnemy.Add(enemyPoint2);
			}
		}
		return mAllPosiblePointsForEnemy;
	}

	public EnemyPoint GetPoint(SoldierBehaviour behaviour, float minDistance = 0f, Transform transform = null)
	{
		mAllPosiblePointsForEnemy = new List<EnemyPoint>();
		foreach (EnemyPoint enemyPoint2 in enemyPoints)
		{
			float num = ((!(transform != null)) ? float.MaxValue : Vector3.Distance(enemyPoint2.position, transform.position));
			if (behaviour.AcceptsPoint(enemyPoint2) && enemyPoint2.isFree && num > minDistance)
			{
				mAllPosiblePointsForEnemy.Add(enemyPoint2);
			}
		}
		if (mAllPosiblePointsForEnemy.Count > 0)
		{
			EnemyPoint result = mAllPosiblePointsForEnemy[0];
			float num2 = float.MaxValue;
			for (int i = 0; i < mAllPosiblePointsForEnemy.Count; i++)
			{
				EnemyPoint enemyPoint = mAllPosiblePointsForEnemy[i];
				float num3 = Vector3.Distance(enemyPoint.transform.position, behaviour.controller.transform.position);
				if (num3 < num2)
				{
					num2 = num3;
					result = mAllPosiblePointsForEnemy[i];
				}
			}
			return result;
		}
		return null;
	}

	public List<EnemyPoint> GetPoints(EnemyPoint.EnemyPointType type, EnemyPoint p, Fractions fraction)
	{
		mAllPosiblePointsForEnemy = new List<EnemyPoint>();
		foreach (EnemyPoint enemyPoint in enemyPoints)
		{
			if (enemyPoint.enemyPointType == type && enemyPoint.isFree && p != enemyPoint && fraction == enemyPoint.fraction)
			{
				mAllPosiblePointsForEnemy.Add(enemyPoint);
			}
		}
		return mAllPosiblePointsForEnemy;
	}

	public EnemyPoint GetNearestFreePoint(SoldierBehaviour behaviour, Transform transform)
	{
		mAllPosiblePointsForEnemy = new List<EnemyPoint>();
		foreach (EnemyPoint enemyPoint2 in enemyPoints)
		{
			if (behaviour.AcceptsPoint(enemyPoint2) && enemyPoint2.isFree)
			{
				mAllPosiblePointsForEnemy.Add(enemyPoint2);
			}
		}
		if (mAllPosiblePointsForEnemy.Count > 0)
		{
			EnemyPoint result = mAllPosiblePointsForEnemy[0];
			float num = float.MaxValue;
			for (int i = 0; i < mAllPosiblePointsForEnemy.Count; i++)
			{
				EnemyPoint enemyPoint = mAllPosiblePointsForEnemy[i];
				float num2 = Vector3.Distance(enemyPoint.position, transform.position);
				if (num2 < num)
				{
					num = num2;
					result = mAllPosiblePointsForEnemy[i];
				}
			}
			return result;
		}
		return null;
	}

	public void ReSyncUnits()
	{
		NetworkObjectPool networkPool = ObjectPoolDatabase.networkPool;
		foreach (KeyValuePair<int, List<PoolableObject>> pooledObject in networkPool.pooledObjects)
		{
			foreach (PoolableObject item in pooledObject.Value)
			{
				AIObject aIObject = item as AIObject;
				if (aIObject != null)
				{
					aIObject.ReSync();
				}
			}
		}
	}
}
