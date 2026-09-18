using UnityEngine;

public class HealthBarManager : GeneratedObjectManager
{
	public Healthbar healthbarPrefab;

	public Camera guiCamera;

	private static HealthBarManager _instance;

	public static HealthBarManager instance
	{
		get
		{
			_instance = _instance ?? ((HealthBarManager)Object.FindObjectsOfType(typeof(HealthBarManager))[0]);
			return _instance;
		}
	}

	public void OnDestroy()
	{
		_instance = null;
	}
}
