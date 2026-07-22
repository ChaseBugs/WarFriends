using UnityEngine;
using WarFriends.Legacy;

public abstract class GuiElementSingle<T> : GuiElement where T : GuiElement
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
					MKELPFGCKKG = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<T>(includeInactive: true)[0];
					if (Object.FindObjectsOfType(typeof(T)).Length > 1)
					{
						Debug.LogError("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.");
						Debug.LogError("Type" + typeof(T));
						return MKELPFGCKKG;
					}
					if (MKELPFGCKKG == null)
					{
						GameObject gameObject = new GameObject();
						MKELPFGCKKG = gameObject.AddComponent<T>();
						gameObject.name = "(singleton) " + typeof(T).ToString();
						SingletonSupport.DontDestroyOnLoadIfPlaying((Object)gameObject);
						Debug.Log(string.Concat("[Singleton] An instance of ", typeof(T), " is needed in the scene, so '", gameObject, "' was created with DontDestroyOnLoad."));
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

	public void OnDestroy()
	{
		MKELPFGCKKG = (T)null;
	}

	public virtual void HideDialog()
	{
		Singleton<GuiManager>.instance.FadeOut(this);
		if (GuiElement.GLNGDNMNGIO != null)
		{
			GuiElement.GLNGDNMNGIO(this);
		}
	}
}
