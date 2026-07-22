using UnityEngine;

public abstract class GuiScreenSingle<T> : GuiScreen where T : GuiScreen
{
	private static T MKELPFGCKKG;

	private static object LNLEHLKLCKG = new object();

	private static bool OOEMIIDICKC = false;

	public static T instance
	{
		get
		{
			if (OOEMIIDICKC)
			{
				Debug.LogWarning(string.Concat("[Singleton] Instance '", typeof(T), "' already destroyed on application quit. Won't create again - returning null."));
				return (T)null;
			}
			lock (LNLEHLKLCKG)
			{
				if (MKELPFGCKKG == null)
				{
					T[] componentsInChildren = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<T>(includeInactive: true);
					if (componentsInChildren.Length <= 0)
					{
						Debug.LogError($"GuiScreenSingle<{typeof(T)}>.instance not found!");
						return (T)null;
					}
					MKELPFGCKKG = componentsInChildren[0];
					if (!(MKELPFGCKKG == null))
					{
					}
				}
				return MKELPFGCKKG;
			}
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		MKELPFGCKKG = this as T;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		MKELPFGCKKG = (T)null;
	}
}
