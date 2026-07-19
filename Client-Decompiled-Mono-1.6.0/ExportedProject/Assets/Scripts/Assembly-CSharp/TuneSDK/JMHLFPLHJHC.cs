using UnityEngine;

namespace TuneSDK
{
	public class JMHLFPLHJHC
	{
		public string BEDHCPLIFKP;

		public string CHMMHFLPGIK;

		public string EDFPKJJNINC;

		public string NHPNMKINBPA;

		public string MLLFLDJIFGK;

		public string AGFDGGADAKN;

		public JMHLFPLHJHC(AndroidJavaObject PLMNDEMGBIP)
		{
			BEDHCPLIFKP = PLMNDEMGBIP.Call<string>("getExperimentId", new object[0]);
			CHMMHFLPGIK = PLMNDEMGBIP.Call<string>("getExperimentName", new object[0]);
			EDFPKJJNINC = PLMNDEMGBIP.Call<string>("getExperimentType", new object[0]);
			NHPNMKINBPA = PLMNDEMGBIP.Call<string>("getCurrentVariantId", new object[0]);
			MLLFLDJIFGK = PLMNDEMGBIP.Call<string>("getCurrentVariantName", new object[0]);
			AGFDGGADAKN = PLMNDEMGBIP.Call<string>("getCurrentVariantLetter", new object[0]);
		}

		public JMHLFPLHJHC(TuneExperimentDetailsIos PLMNDEMGBIP)
		{
			BEDHCPLIFKP = PLMNDEMGBIP.id;
			CHMMHFLPGIK = PLMNDEMGBIP.name;
			EDFPKJJNINC = PLMNDEMGBIP.type;
			NHPNMKINBPA = PLMNDEMGBIP.current_variation.id;
			MLLFLDJIFGK = PLMNDEMGBIP.current_variation.name;
			AGFDGGADAKN = PLMNDEMGBIP.current_variation.letter;
		}
	}
}
