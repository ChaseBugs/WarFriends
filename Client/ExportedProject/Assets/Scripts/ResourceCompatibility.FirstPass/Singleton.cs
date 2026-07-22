public class Singleton : Core_BaseScript
{
	public static bool applicationIsQuitting;

	public static bool isRestart;
}
public class Singleton<T> : Singleton where T : Core_BaseScript
{
	private static T _instance;

	private static object _lock;

	public static T instance => null;

	public virtual void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}
}
