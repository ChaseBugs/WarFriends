using System;
using System.Collections.Generic;
using UnityEngine;

public class AIObjectG<T> : AIObject where T : LevelBehaviour
{
	public bool isInField => Singleton<MapManager>.instance.currentMapDef != null && Singleton<MapManager>.instance.currentMapDef.fieldArea != null && Singleton<MapManager>.instance.currentMapDef.fieldArea.bounds.Contains(base.transform.position);

	public T currentBeh => (T)behaviour;

	public override void PrepareInstancies()
	{
		base.PrepareInstancies();
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(this);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			AIObject aIObject = (AIObject)item;
			T val = Singleton<LevelBehaviourManager>.instance.GetPreparedBehaviour<T>();
			Type typeFromHandle = typeof(T);
			if (val == null)
			{
				Debug.LogError("Null behaviour for " + base.name + " type: " + typeFromHandle);
			}
			aIObject.preparedBehaviour = val;
			preparedBehaviour = val;
			if (preparedBehaviour != null)
			{
				preparedBehaviour.Copy(aIObject);
			}
			Singleton<LevelBehaviourManager>.instance.preparedInstancies[aIObject.preparedBehaviour].Add(aIObject);
		}
	}
}
