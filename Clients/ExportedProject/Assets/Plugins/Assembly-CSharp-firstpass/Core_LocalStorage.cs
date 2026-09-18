using UnityEngine;

public class Core_LocalStorage : MonoBehaviour
{
	protected const string GLOBAL_STORAGE_PREFAB_NAME = "GlobalStoragePrefab";

	public bool CAN_INIT_FOR_EDITOR;

	protected bool _isInitialized;

	public Object GlobalStoragePrefab;

	private GlobalStorage _globalStorage;

	public bool IsInitialized => _isInitialized;

	public GlobalStorage GlobalStorage
	{
		get
		{
			if (!_isInitialized)
			{
				if (Debug.isDebugBuild)
				{
					Debug.LogWarning("LocalStorage: Not initialized, access to get_GlobalStorage() denied");
				}
				return null;
			}
			if (_globalStorage == null)
			{
				GameObject gameObject = GameObject.Find("GlobalStoragePrefab");
				if (gameObject != null)
				{
					if (Debug.isDebugBuild)
					{
						Debug.Log("Global storage found");
					}
					_globalStorage = GetGlobalStorageScript(gameObject);
					if (_globalStorage == null && Debug.isDebugBuild)
					{
						Debug.LogError("LocalStorage: Error in GlobalStorage Prefab - GlobalStorage script not found");
					}
				}
				else
				{
					if (GlobalStoragePrefab == null && Debug.isDebugBuild)
					{
						Debug.LogError("LocalStorage: GlobalStoragePrefab not assigned");
					}
					gameObject = Object.Instantiate(GlobalStoragePrefab) as GameObject;
					gameObject.name = "GlobalStoragePrefab";
					_globalStorage = GetGlobalStorageScript(gameObject);
				}
			}
			return _globalStorage;
		}
	}

	protected virtual GlobalStorage GetGlobalStorageScript(GameObject globalStorageObject)
	{
		return globalStorageObject.GetComponent<GlobalStorage>();
	}

	protected virtual void Awake()
	{
		_isInitialized = true;
	}

	protected void OnApplicationQuit()
	{
		if (_globalStorage != null)
		{
			_globalStorage = null;
			GameObject gameObject = GameObject.Find("GlobalStoragePrefab");
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
	}

	public void InitForEditor()
	{
		if (GlobalStoragePrefab == null)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError("LocalStorage: Cannot init for Editor: GlobalStoragePrefab relation is missing");
			}
		}
		else if (CAN_INIT_FOR_EDITOR)
		{
			_isInitialized = true;
			GlobalStorage.InitForEditor();
		}
	}
}
