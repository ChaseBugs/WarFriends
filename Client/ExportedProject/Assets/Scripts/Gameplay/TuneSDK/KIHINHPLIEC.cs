using UnityEngine;

namespace TuneSDK
{
	public class KIHINHPLIEC : JMHLFPLHJHC
	{
		public bool CBILNAOFMHG;

		public KIHINHPLIEC(AndroidJavaObject PLMNDEMGBIP)
			: base(PLMNDEMGBIP)
		{
			CBILNAOFMHG = PLMNDEMGBIP.Call<bool>("isRunning", new object[0]);
		}

		public KIHINHPLIEC(TunePowerHookExperimentDetailsIos PLMNDEMGBIP)
			: base(PLMNDEMGBIP)
		{
			if (PLMNDEMGBIP.is_running.Equals("true"))
			{
				CBILNAOFMHG = true;
			}
		}
	}
}
