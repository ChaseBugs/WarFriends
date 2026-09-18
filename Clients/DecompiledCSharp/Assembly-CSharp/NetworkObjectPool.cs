using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonNetwork))]
public class NetworkObjectPool : ObjectPool
{
	private static int mLastViewId = 200;

	private PhotonView mPhotonView;

	public static int AllocateNetworkId()
	{
		mLastViewId++;
		return mLastViewId;
	}

	public static int AllocateMyNetworkId()
	{
		mLastViewId++;
		return mLastViewId + 1000 * PhotonNetwork.player.ID;
	}

	protected override void Awake()
	{
		base.Awake();
		if (!mIsInitialized)
		{
			Init();
		}
	}

	protected override void Init()
	{
		mIsInitialized = true;
		mPhotonView = GetComponent<PhotonView>();
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
				GameObject gameObject2 = Object.Instantiate(Entries[i].Prefab.gameObject, base.transform.position, base.transform.rotation) as GameObject;
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
				PhotonView[] componentsInChildren = gameObject2.GetComponentsInChildren<PhotonView>(includeInactive: true);
				PhotonView[] array = componentsInChildren;
				foreach (PhotonView photonView in array)
				{
					photonView.viewID = AllocateNetworkId();
					PhotonNetwork.RegisterPooledPhotonView(photonView);
				}
			}
			objectPoolEntry.Prefab.gameObject.SetActive(value: true);
		}
	}

	public PoolableObject ReInstantiate(PoolableObject objectPrefab, int indexInObjectPool)
	{
		int i = prefabToIndexDic[objectPrefab];
		return ReInstantiate(i, indexInObjectPool);
	}

	public PoolableObject ReInstantiate(int i, int indexInObjectPool)
	{
		PoolableObject poolableObject = pooledObjects[i][indexInObjectPool];
		freePooledObjects.TryGetValue(i, out var value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = true;
			poolableObject2.Init();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(value: true);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + poolableObject.name);
		}
		return null;
	}

	public PoolableObject ReInstantiate(PoolableObject objectPrefab, int indexInObjectPool, Vector3 position, Quaternion rotation)
	{
		int i = prefabToIndexDic[objectPrefab];
		return ReInstantiate(i, indexInObjectPool, position, rotation);
	}

	private int GetFirstFreeIndex(PoolableObject objectPrefab)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = prefabToIndexDic[objectPrefab];
		freePooledObjects.TryGetValue(key, out var value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	public PoolableObject InstantiateNetwork(PoolableObject objectPrefab, Vector3 position, Quaternion rotation)
	{
		int firstFreeIndex = GetFirstFreeIndex(objectPrefab);
		if (firstFreeIndex >= 0)
		{
			mPhotonView.RPC("NetworkReInstantiate", PhotonTargets.Others, prefabToIndexDic[objectPrefab], firstFreeIndex, position, rotation);
		}
		return Instantiate(objectPrefab, position, rotation);
	}

	[PunRPC]
	private void NetworkReInstantiate(int prefabIndex, int indexInObjectPool, Vector3 position, Quaternion rotation)
	{
		ReInstantiate(prefabIndex, indexInObjectPool, position, rotation);
	}

	public PoolableObject InstantiateNetwork(PoolableObject objectPrefab)
	{
		int firstFreeIndex = GetFirstFreeIndex(objectPrefab);
		if (firstFreeIndex >= 0)
		{
			mPhotonView.RPC("NetworkReInstantiate_1", PhotonTargets.Others, prefabToIndexDic[objectPrefab], firstFreeIndex);
		}
		return Instantiate(objectPrefab);
	}

	[PunRPC]
	private void NetworkReInstantiate_1(int prefabIndex, int indexInObjectPool)
	{
		ReInstantiate(prefabIndex, indexInObjectPool);
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject pooledObject, Vector3 position, Quaternion rotation)
	{
		mPhotonView.RPC("NetworkReInstantiate", PhotonTargets.Others, prefabToIndexDic[pooledObject.prefab], pooledObject.indexInObjectPool, position, rotation);
		return ReInstantiate(pooledObject, position, rotation);
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject pooledObject)
	{
		mPhotonView.RPC("NetworkReInstantiate_1", PhotonTargets.Others, prefabToIndexDic[pooledObject.prefab], pooledObject.indexInObjectPool);
		return ReInstantiate(pooledObject);
	}

	public PoolableObject ReInstantiate(int i, int indexInObjectPool, Vector3 position, Quaternion rotation)
	{
		PoolableObject poolableObject = pooledObjects[i][indexInObjectPool];
		freePooledObjects.TryGetValue(i, out var value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = position;
			poolableObject2.transform.rotation = rotation;
			poolableObject2.enabled = true;
			poolableObject2.Init();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(value: true);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + poolableObject.name);
		}
		return null;
	}

	[PunRPC]
	private void NetworkInstantiate(int index, Vector3 position, Quaternion rotation)
	{
		Instantiate(index, position, rotation);
	}

	public override PoolableObject Instantiate(int index, Vector3 position, Quaternion rotation)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		freePooledObjects.TryGetValue(index, out var value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = pooledObjects[index][(!isMasterClient) ? value.Last.Value : value.First.Value];
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
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
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
}
