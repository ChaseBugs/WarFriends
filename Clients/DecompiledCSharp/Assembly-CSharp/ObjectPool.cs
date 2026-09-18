using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectPool : Core_BaseScript
{
	[Serializable]
	public class ObjectPoolEntry
	{
		[SerializeField]
		public string Name = "undefined";

		[SerializeField]
		public PoolableObject Prefab;

		[SerializeField]
		public int Count = 1;

		[SerializeField]
		public bool limitInstances;

		[SerializeField]
		public int limitAmount = 100;

		[SerializeField]
		public bool cullDespawned;

		[SerializeField]
		public int cullAbove = 50;
	}

	public static Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();

	public List<ObjectPoolEntry> Entries;

	public List<bool> foldoutStates = new List<bool>();

	public Dictionary<int, List<PoolableObject>> pooledObjects;

	public Dictionary<int, LinkedList<int>> freePooledObjects;

	public Dictionary<PoolableObject, int> prefabToIndexDic;

	protected bool mIsInitialized;

	public void OnDestroy()
	{
		pools = new Dictionary<string, ObjectPool>();
	}

	public static ObjectPool GetPool(string poolName)
	{
		if (Application.isPlaying)
		{
			if (pools.Count == 0)
			{
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(ObjectPool));
				UnityEngine.Object[] array2 = array;
				foreach (UnityEngine.Object obj in array2)
				{
					ObjectPool objectPool = obj as ObjectPool;
					if (objectPool != null)
					{
						pools[obj.name] = objectPool;
					}
				}
			}
			ObjectPool value = null;
			pools.TryGetValue(poolName, out value);
			return value;
		}
		pools = new Dictionary<string, ObjectPool>();
		return null;
	}

	protected virtual void Init()
	{
		mIsInitialized = true;
		if (!Application.isPlaying)
		{
			return;
		}
		pooledObjects = new Dictionary<int, List<PoolableObject>>();
		freePooledObjects = new Dictionary<int, LinkedList<int>>();
		prefabToIndexDic = new Dictionary<PoolableObject, int>();
		for (int i = 0; i < Entries.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = Entries[i];
			if (objectPoolEntry.Prefab == null)
			{
				Debug.LogError("MISSING PREFAB IN OBJECT POOL: " + base.name);
			}
			objectPoolEntry.Prefab.isActivated = false;
			prefabToIndexDic[objectPoolEntry.Prefab] = i;
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			List<PoolableObject> list = new List<PoolableObject>(objectPoolEntry.Count);
			pooledObjects[i] = list;
			List<PoolableObject> list2 = list;
			LinkedList<int> linkedList = new LinkedList<int>();
			freePooledObjects[i] = linkedList;
			LinkedList<int> linkedList2 = linkedList;
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = base.transform;
			bool flag = false;
			for (int j = 0; j < objectPoolEntry.Count; j++)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(Entries[i].Prefab.gameObject, base.transform.position, base.transform.rotation) as GameObject;
				gameObject2.layer = Entries[i].Prefab.gameObject.layer;
				if (!flag)
				{
					gameObject.name = gameObject2.name + "Pool";
					flag = true;
				}
				gameObject2.name = gameObject2.name + "pooled:" + j.ToString("D4");
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.gameObject.SetActive(value: false);
				PoolableObject component = gameObject2.GetComponent<PoolableObject>();
				component.poolParent = gameObject.transform;
				component.indexInObjectPool = j;
				component.prefab = objectPoolEntry.Prefab;
				component.pool = this;
				list2.Add(component);
				linkedList2.AddLast(j);
			}
			objectPoolEntry.Prefab.gameObject.SetActive(value: true);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!mIsInitialized)
		{
			Init();
		}
	}

	public bool AreThereAvailableInstances(PoolableObject objectPrefab)
	{
		int key = prefabToIndexDic[objectPrefab];
		freePooledObjects.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 0;
		}
		throw new Exception("Prefab not found in pool");
	}

	public PoolableObject Instantiate(PoolableObject objectPrefab)
	{
		return Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
	}

	public virtual PoolableObject Instantiate(PoolableObject objectPrefab, Vector3 position, Quaternion rotation)
	{
		if (!mIsInitialized)
		{
			Init();
		}
		int index = prefabToIndexDic[objectPrefab];
		return Instantiate(index, position, rotation);
	}

	public virtual PoolableObject Instantiate(int index, Vector3 position, Quaternion rotation)
	{
		freePooledObjects.TryGetValue(index, out var value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = pooledObjects[index][value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = position;
			poolableObject.transform.rotation = rotation;
			poolableObject.Init();
			poolableObject.BeforeInstancied();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.RemoveFirst();
			poolableObject.gameObject.SetActive(value: true);
			poolableObject.pool = this;
			poolableObject.OnInstancied();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + pooledObjects[index][0].name);
		}
		return null;
	}

	public PoolableObject ReInstantiate(PoolableObject @object, Vector3 position, Quaternion rotation)
	{
		PoolableObject prefab = @object.prefab;
		int key = prefabToIndexDic[prefab];
		freePooledObjects.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			@object.enabled = true;
			if (@object.GetComponent<Rigidbody>() != null && !@object.GetComponent<Rigidbody>().isKinematic)
			{
				@object.GetComponent<Rigidbody>().velocity = Vector3.zero;
				@object.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			@object.transform.position = position;
			@object.transform.rotation = rotation;
			@object.Init();
			@object.BeforeInstancied();
			value.Remove(@object.indexInObjectPool);
			@object.gameObject.SetActive(value: true);
			@object.pool = this;
			@object.OnInstancied();
			return @object;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + prefab.name);
		}
		return null;
	}

	public PoolableObject InstantiateAsChild(PoolableObject objectPrefab, Vector3 localPostion, Quaternion rotation, GameObject parent)
	{
		Vector3 localScale = objectPrefab.transform.localScale;
		PoolableObject poolableObject = Instantiate(objectPrefab, parent.transform.position, rotation);
		poolableObject.transform.parent = parent.transform;
		poolableObject.transform.localPosition = localPostion;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = parent.layer;
		return poolableObject;
	}

	public PoolableObject InstantiateAsChild(PoolableObject objectPrefab, GameObject parent, string name)
	{
		Vector3 localScale = objectPrefab.transform.localScale;
		PoolableObject poolableObject = Instantiate(objectPrefab, parent.transform.position, Quaternion.identity);
		if (poolableObject != null)
		{
			poolableObject.transform.parent = parent.transform;
			poolableObject.transform.localScale = localScale;
			poolableObject.name = name;
		}
		return poolableObject;
	}

	public int GetCountInPool(PoolableObject obj)
	{
		int key = prefabToIndexDic[obj];
		if (pooledObjects.TryGetValue(key, out var value))
		{
			return value.Count;
		}
		return 0;
	}

	public int GetNumberOfInstancies(PoolableObject obj)
	{
		int key = prefabToIndexDic[obj];
		if (freePooledObjects.TryGetValue(key, out var value))
		{
			return GetCountInPool(obj) - value.Count;
		}
		return 0;
	}

	public bool FreeObject(PoolableObject obj)
	{
		if (obj.prefab == null)
		{
			UnityEngine.Object.Destroy(obj.gameObject);
			return true;
		}
		int key = prefabToIndexDic[obj.prefab];
		freePooledObjects.TryGetValue(key, out var value);
		if (value != null && !value.Contains(obj.indexInObjectPool))
		{
			value.AddFirst(obj.indexInObjectPool);
			obj.gameObject.SetActive(value: false);
			return true;
		}
		return false;
	}

	public void FreeObjectsWithPrefab(PoolableObject obj)
	{
		int key = prefabToIndexDic[obj];
		pooledObjects.TryGetValue(key, out var value);
		foreach (PoolableObject item in value)
		{
			item.DestroyPooled();
		}
	}

	public void FreeWholePool()
	{
		foreach (KeyValuePair<int, List<PoolableObject>> pooledObject in pooledObjects)
		{
			foreach (PoolableObject item in pooledObject.Value)
			{
				if (item.gameObject.activeSelf)
				{
					item.DestroyPooled();
				}
			}
		}
	}

	public List<PoolableObject> GetObjectsMadeOfPrefab(PoolableObject obj)
	{
		int value = 0;
		if (prefabToIndexDic.TryGetValue(obj, out value))
		{
			pooledObjects.TryGetValue(value, out var value2);
			return value2;
		}
		return new List<PoolableObject>();
	}

	private IEnumerator FreeObjecCorroutine(PoolableObject obj, float time)
	{
		yield return new WaitForSeconds(time);
		FreeObject(obj);
	}

	public bool FreeObject(PoolableObject obj, float time)
	{
		StartCoroutine(FreeObjecCorroutine(obj, time));
		return true;
	}

	public PoolableObject ReInstantiate(PoolableObject @object)
	{
		PoolableObject prefab = @object.prefab;
		int key = prefabToIndexDic[prefab];
		freePooledObjects.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			@object.enabled = true;
			@object.Init();
			@object.BeforeInstancied();
			if (@object.GetComponent<Rigidbody>() != null && !@object.GetComponent<Rigidbody>().isKinematic)
			{
				@object.GetComponent<Rigidbody>().velocity = Vector3.zero;
				@object.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(@object.indexInObjectPool);
			@object.gameObject.SetActive(value: true);
			@object.pool = this;
			@object.OnInstancied();
			return @object;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + prefab.name);
		}
		return null;
	}
}
