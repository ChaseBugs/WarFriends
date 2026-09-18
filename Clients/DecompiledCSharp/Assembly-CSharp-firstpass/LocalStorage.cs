using UnityEngine;

public class LocalStorage : Core_LocalStorage
{
	public static LocalStorage Instance { get; private set; }

	public static GlobalStorage GlobalStorageInstance { get; private set; }

	protected override GlobalStorage GetGlobalStorageScript(GameObject globalStorageObject)
	{
		return globalStorageObject.GetComponent<GlobalStorage>();
	}

	protected override void Awake()
	{
		base.Awake();
		Instance = this;
		GlobalStorageInstance = base.GlobalStorage;
	}
}
