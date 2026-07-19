using System;

namespace TuneSDK
{
	[Serializable]
	public class TuneExperimentDetailsIos
	{
		public string type;

		public string id;

		public string name;

		public string experiment_end_date;

		public string experiment_start_date;

		public Variation current_variation;
	}
}
