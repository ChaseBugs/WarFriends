using TuneSDK;
using UnityEngine;

public class MobileAppTrackingManager : MonoBehaviour
{
	public bool debug;

	public string advertiserId;

	public string conversionKey;

	public string packageName;

	private void Awake()
	{
		Tune.Init(advertiserId, conversionKey);
		Tune.CheckForDeferredDeeplink();
		Tune.AutomateIapEventMeasurement(automate: true);
		if (debug)
		{
			Tune.SetDebugMode(debug: true);
		}
		Tune.MeasureSession();
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (!pauseStatus)
		{
			Tune.MeasureSession();
		}
	}
}
