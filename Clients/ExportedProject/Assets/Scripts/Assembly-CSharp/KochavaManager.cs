using UnityEngine;

public class KochavaManager : MonoBehaviour
{
	private void Start()
	{
		Kochava.AttributionCallback attributionCallback = AttributionCallback;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	private static void AttributionCallback(string data)
	{
		Debug.Log("Attribution Data " + data);
	}

	public static void LinkPlayer(string playerId)
	{
		if (!string.IsNullOrEmpty(playerId))
		{
			Kochava.IdentityLink("playerId", playerId);
		}
	}

	public static string GetKochavaDeviceId()
	{
		return Kochava.GetKochavaDeviceId();
	}

	public static string GetIDFA()
	{
		return Kochava.GetKochavaIDFA();
	}

	public static string GetIDFV()
	{
		return Kochava.GetKochavaIDFV();
	}

	public static string GetAndroidID()
	{
		return Kochava.GetAndroidID();
	}

	public static string GetAndroidAdvertisingID()
	{
		return Kochava.GetAndroidAdvertisingID();
	}
}
