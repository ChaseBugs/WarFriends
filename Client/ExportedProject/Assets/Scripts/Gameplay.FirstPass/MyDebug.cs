using UnityEngine;

public static class MyDebug
{
	public static void Log(object o)
	{
		Debug.Log(o);
	}

	public static void LogError(object s)
	{
		Debug.LogError(s);
	}
}
