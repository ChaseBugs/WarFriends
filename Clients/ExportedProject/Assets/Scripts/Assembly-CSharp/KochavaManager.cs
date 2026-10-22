using UnityEngine;

public class KochavaManager : MonoBehaviour
{
	private void Start()
	{
		// Offline builds have no attribution service or Kochava runtime instance.
	}

	private static void AttributionCallback(string data)
	{
		Debug.Log("Attribution Data " + data);
	}

	public static void LinkPlayer(string playerId)
	{
		// Account persistence and the following PlayerData callback must never depend on analytics.
	}

	public static string GetKochavaDeviceId()
	{
		return string.Empty;
	}

	public static string GetIDFA()
	{
		return string.Empty;
	}

	public static string GetIDFV()
	{
		return string.Empty;
	}

	public static string GetAndroidID()
	{
		return string.Empty;
	}

	public static string GetAndroidAdvertisingID()
	{
		return string.Empty;
	}
}
