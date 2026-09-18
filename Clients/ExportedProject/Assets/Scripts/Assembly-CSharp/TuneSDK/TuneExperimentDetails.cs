using UnityEngine;

namespace TuneSDK
{
public class TuneExperimentDetails
{
	public string experimentId;

	public string experimentName;

	public string experimentType;

	public string currentVariantId;

	public string currentVariantName;

	public string currentVariantLetter;

	public TuneExperimentDetails(AndroidJavaObject experimentDetails)
	{
		experimentId = experimentDetails.Call<string>("getExperimentId", new object[0]);
		experimentName = experimentDetails.Call<string>("getExperimentName", new object[0]);
		experimentType = experimentDetails.Call<string>("getExperimentType", new object[0]);
		currentVariantId = experimentDetails.Call<string>("getCurrentVariantId", new object[0]);
		currentVariantName = experimentDetails.Call<string>("getCurrentVariantName", new object[0]);
		currentVariantLetter = experimentDetails.Call<string>("getCurrentVariantLetter", new object[0]);
	}

	public TuneExperimentDetails(TuneExperimentDetailsIos experimentDetails)
	{
		experimentId = experimentDetails.id;
		experimentName = experimentDetails.name;
		experimentType = experimentDetails.type;
		currentVariantId = experimentDetails.current_variation.id;
		currentVariantName = experimentDetails.current_variation.name;
		currentVariantLetter = experimentDetails.current_variation.letter;
	}
}
}
