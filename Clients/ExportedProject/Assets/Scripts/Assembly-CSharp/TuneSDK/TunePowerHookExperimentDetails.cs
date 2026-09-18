using UnityEngine;

namespace TuneSDK
{
public class TunePowerHookExperimentDetails : TuneExperimentDetails
{
	public bool isRunning;

	public TunePowerHookExperimentDetails(AndroidJavaObject experimentDetails)
		: base(experimentDetails)
	{
		isRunning = experimentDetails.Call<bool>("isRunning", new object[0]);
	}

	public TunePowerHookExperimentDetails(TunePowerHookExperimentDetailsIos experimentDetails)
		: base(experimentDetails)
	{
		if (experimentDetails.is_running.Equals("true"))
		{
			isRunning = true;
		}
	}
}
}
