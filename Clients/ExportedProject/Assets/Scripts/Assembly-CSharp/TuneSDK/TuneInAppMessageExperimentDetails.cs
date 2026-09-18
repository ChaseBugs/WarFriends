using UnityEngine;

namespace TuneSDK
{
public class TuneInAppMessageExperimentDetails : TuneExperimentDetails
{
	public TuneInAppMessageExperimentDetails(AndroidJavaObject experimentDetails)
		: base(experimentDetails)
	{
	}

	public TuneInAppMessageExperimentDetails(TuneInAppMessageExperimentDetailsIos experimentDetails)
		: base(experimentDetails)
	{
	}
}
}
