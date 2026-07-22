using UnityEngine;
using WarFriends.Legacy;

public class Singleton : Core_BaseScript
{
	public static bool applicationIsQuitting;

	public static bool isRestart;

	public void OnApplicationQuit()
	{
		applicationIsQuitting = true;
	}
}
public class Singleton<T> : Singleton where T : Core_BaseScript
{
	private static T _instance;

	private static object _lock = new object();

	public static T instance
	{
		get
		{
			if (Singleton.applicationIsQuitting && Application.isPlaying)
			{
				Debug.LogWarning(string.Concat("[Singleton] Instance '", typeof(T), "' already destroyed on application quit. Won't create again - returning null."));
				return (T)null;
			}
			lock (_lock)
			{
				if (_instance == null)
				{
					_instance = (T)Object.FindObjectOfType(typeof(T));
					if (Object.FindObjectsOfType(typeof(T)).Length > 1)
					{
						Debug.LogError("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.");
						Debug.LogError("Type" + typeof(T));
						return _instance;
					}
					if (_instance == null)
					{
						GameObject gameObject = new GameObject();
						_instance = gameObject.AddComponent<T>();
						gameObject.name = "(singleton) " + typeof(T).ToString();
						SingletonSupport.DontDestroyOnLoadIfPlaying((Object)gameObject);
						Debug.Log(string.Concat("[Singleton] An instance of ", typeof(T), " is needed in the scene, so '", gameObject, "' was created with DontDestroyOnLoad."));
					}
				}
				return _instance;
			}
		}
	}

	public void OnDestroy()
	{
		// ILSpy loses the closed generic argument for this private static field and emits
		// the invalid open-generic expression `Singleton<>._instance`. This method already
		// belongs to Singleton<T>, so assigning the field directly preserves the original
		// behavior: the cached instance is released when this component is destroyed.
		_instance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		if (_instance != null && _instance != this)
		{
			Debug.LogErrorFormat("Already having instance of {0}", typeof(T));
		}
		else
		{
			_instance = this as T;
		}
	}
}
