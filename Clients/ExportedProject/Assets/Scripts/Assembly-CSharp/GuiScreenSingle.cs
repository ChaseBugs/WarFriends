using UnityEngine;

public abstract class GuiScreenSingle<T> : GuiScreen where T : GuiScreen
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
					T[] componentsInChildren = Singleton<GuiManager>.instance.root.GetComponentsInChildren<T>(includeInactive: true);
					if (componentsInChildren.Length <= 0)
					{
						Debug.LogError($"GuiScreenSingle<{typeof(T)}>.instance not found!");
						return (T)null;
					}
					_instance = componentsInChildren[0];
					if (!(_instance == null))
					{
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

	public override void OnDestroy()
	{
		base.OnDestroy();
		_instance = (T)null;
	}
}
