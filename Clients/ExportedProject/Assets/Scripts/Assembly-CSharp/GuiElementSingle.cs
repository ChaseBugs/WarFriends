using UnityEngine;

public abstract class GuiElementSingle<T> : GuiElement where T : GuiElement
{
	private static T _instance;

	private static object _lock = new object();

	private static bool applicationIsQuitting = false;

	public static T instance
	{
		get
		{
			if (applicationIsQuitting)
			{
				Debug.LogWarning(string.Concat("[Singleton] Instance '", typeof(T), "' already destroyed on application quit. Won't create again - returning null."));
				return (T)null;
			}
			lock (_lock)
			{
				if (_instance == null)
				{
					GuiManager manager = Singleton<GuiManager>.instance;
					if (manager == null || manager.root == null)
						return null;
					T[] elements = manager.root.GetComponentsInChildren<T>(includeInactive: true);
					if (elements.Length == 0)
						return null;
					_instance = elements[0];
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
						Object.DontDestroyOnLoad(gameObject);
						Debug.Log(string.Concat("[Singleton] An instance of ", typeof(T), " is needed in the scene, so '", gameObject, "' was created with DontDestroyOnLoad."));
					}
				}
				return _instance;
			}
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		_instance = this as T;
	}

	public void OnDestroy()
	{
		_instance = (T)null;
	}

	public virtual void HideDialog()
	{
		Singleton<GuiManager>.instance.FadeOut(this);
		if (GuiElement.HidingDialog != null)
		{
			GuiElement.HidingDialog(this);
		}
	}
}
