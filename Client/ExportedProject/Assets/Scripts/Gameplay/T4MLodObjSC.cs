using UnityEngine;
using UnityEngine.Serialization;

public class T4MLodObjSC : MonoBehaviour
{
	[FormerlySerializedAs("MALJMCPDAHF")]
	[HideInInspector]
	public Renderer AMAMEOMNCJJ;

	[HideInInspector]
	[FormerlySerializedAs("DGJOLMOCLGD")]
	public Renderer POJLLDMLKKL;

	[FormerlySerializedAs("HMGDBEOFHMG")]
	[HideInInspector]
	public Renderer FCKPJPHPFAI;

	[FormerlySerializedAs("ACCODOAGDEN")]
	[HideInInspector]
	public float OMLCBPDFLOI = 0.5f;

	[FormerlySerializedAs("JFKAEKOLEBE")]
	[HideInInspector]
	public Transform OJAKKADLFFA;

	[HideInInspector]
	[FormerlySerializedAs("LIPEICHGJGC")]
	public int EOBFNHDMLHJ;

	private Vector3 IOGNLMNDANM;

	[HideInInspector]
	[FormerlySerializedAs("IOGJDELHEEC")]
	public int HEOJCIMNDIO;

	[HideInInspector]
	[FormerlySerializedAs("DNJBBCEACJJ")]
	public float FIINJIFHJKC = 60f;

	[HideInInspector]
	[FormerlySerializedAs("KECECLMJONH")]
	public float DJEFCHAAPKK = 20f;

	[FormerlySerializedAs("FKIMDDBDPMP")]
	[HideInInspector]
	public float KMKEMDGMLAG = 40f;

	public void PIIPINAHBPH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 949f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 7;
			}
		}
	}

	public void OOIAJJMPANG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 901f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void NOOGHIIKHCJ()
	{
		if (EOBFNHDMLHJ == 8)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("DemotedPlayerId", Random.Range(215f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void ActivateLODLay()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("AFLODLay", Random.Range(0f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void IIFLNBFNKHC()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("Win", Random.Range(436f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void AMFONEGPMHK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 547f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 3;
			}
		}
	}

	public void MECGMDKLDOC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 7;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void ONKCPLDDCAG()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}", Random.Range(1604f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void KPODCLANIOG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 5;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void BFOCLMKHIBF()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("count", Random.Range(1712f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void MPIONGGPBEO()
	{
		if (EOBFNHDMLHJ == 8)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_ERRORPROFANITYNICK", Random.Range(1635f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void AIIMGNBDDHF()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 8;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 3;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void KLGBIIGBIBE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 988f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 0;
			}
		}
	}

	public void DFBINIOODIG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void PNBPKDDPCED()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void HOLMMGIFELA()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 3;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void OBFGAOAMDFM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1044f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 8;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void LKOCFMIEHDJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 3;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void CBOKMBBNGMO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 930f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 3;
			}
		}
	}

	public void DFHLDAOLMHN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 5;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void HPBMNAKENLH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 4;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void ICMFIGKPEHJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 638f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 2;
			}
		}
	}

	public void GHICFGCKEDM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 432f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 5;
			}
		}
	}

	public void BLKAHEAHEHJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1783f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 5;
			}
		}
	}

	public void DLDFFAGOHCD()
	{
		if (EOBFNHDMLHJ == 8)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_VETERANPACKDESCRIPTION", Random.Range(1736f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void GHMODBNDDGI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 5;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void LIPCFLLIPNO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 0;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void NLPLEEDCDGH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 7;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void ABHADNMKEOC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1206f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
	}

	public void AOBGAALAJDC()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("special", Random.Range(21f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void KCLMJOAFCJN()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("1", Random.Range(1102f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void MFFKMAILKFE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void JOIIDEDGLJO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 8;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 3;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void IGEKMADLELB()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("DailyBonus", Random.Range(1406f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void CBMOLPAIBGJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void BOGEHIAHMEN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1405f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 5;
			}
		}
	}

	public void NEGMMJNKHKG()
	{
		if (EOBFNHDMLHJ == 7)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("Skill", Random.Range(1366f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void JDBPNEFLKKB()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("added", Random.Range(1490f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void PICNENDOGHJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void JKIJAKENAEE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void AFLODLay()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 5f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 3;
			}
		}
	}

	public void MBGFBABGJIK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void IEJPJJNLNNE()
	{
		if (EOBFNHDMLHJ == 4)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_UPGRADED", Random.Range(1466f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void IHPBEDGOGFE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 37f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void GBJLOMNDLCE()
	{
		if (EOBFNHDMLHJ == 7)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("+{0}", Random.Range(1111f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void AOIDJPKNDAD()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1534f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 6;
			}
		}
	}

	public void GGLKKPKNJLG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 0;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void JLPFPOOOBAM()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("GameController.LoadAndStartNewMap - InstantiatePooledObjects", Random.Range(1043f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void OPGFFEOPJHE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 8;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void GPOPKBKJDFH()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("PlayerId", Random.Range(702f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void LBCHGLNPIBA()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void AHJFEMAACOI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 123f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 0;
			}
		}
	}

	public void CCBCKKOOEMO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1002f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 5;
			}
		}
	}

	public void LFMNAFHHEFC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 8;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void IGGFPBOBADH()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("MegaReward", Random.Range(563f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void ODOCJDBGNFG()
	{
		if (EOBFNHDMLHJ == 0)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("B", Random.Range(740f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void BJNLOJDOENL()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating(" bonusIcon:", Random.Range(990f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void GFKJHFJEEOM()
	{
		if (EOBFNHDMLHJ == 0)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating(", key = ", Random.Range(1602f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void HEOGAHALINJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1346f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void CPFBDPPILBM()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("UsedGolds", Random.Range(1001f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void NAILNFLJNLP()
	{
		if (EOBFNHDMLHJ == 4)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_ARENARULES_LATEOVERTIME", Random.Range(1728f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void ADFPJOMKBHN()
	{
		if (EOBFNHDMLHJ == 7)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_NOTIFICATION_PLAYERLEAGUEEND", Random.Range(446f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void GFBGMBLFPIJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 738f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 7;
			}
		}
	}

	public void OMNAAHDHPGA()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("experiment id is ", Random.Range(66f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void EPDIBDFPONE()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("Arena Wins: ", Random.Range(1767f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void CEKDEBHPCFF()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("SyncShieldRPC", Random.Range(1898f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void LKGHOPKGCLL()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 627f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void EILBCPKGJLK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1105f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 4;
			}
		}
	}

	public void HHPIKJFDLBK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void MJJLCMEDHIH()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ArenaPrice", Random.Range(609f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void HNPNFAHOHBK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 7;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void CPECBFIEENH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 650f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
	}

	public void BCOFKNDLPLI()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("getCustomProfileNumber", Random.Range(179f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void NJBEHOMKKLD()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void MIACGNNHABI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 7;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void DKPBDLGPCPN()
	{
		if (EOBFNHDMLHJ == 3)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("reset tutorial", Random.Range(1706f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void CGJMNIEFGMF()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = true;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void BJDKKDIPOBM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void HCKNIJHNJLD()
	{
		if (EOBFNHDMLHJ == 1)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_UNITTYPE2", Random.Range(475f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void FKIMKOBCMFB()
	{
		if (EOBFNHDMLHJ == 1)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_GUI_EQUIPPED", Random.Range(505f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void BFFGJOALKMK()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_CONFIRM_ERROR", Random.Range(633f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void NMDIFGIHLBA()
	{
		if (EOBFNHDMLHJ == 4)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_CATEGORY_LOW_SG_EXPLOSIVE", Random.Range(424f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void AIJBHEEIHHJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 4;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void GAHGJNCLFCI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 6;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 1;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void DLCIJAMIMBK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void ActivateLODScrpt()
	{
		if (EOBFNHDMLHJ == 2)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("AFLODScrpt", Random.Range(0f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void DFJOCOFJFLG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 8;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 4;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void HPMGADFNPOH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 7;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void FGLEPMGFGMP()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 8;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void AFLODScrpt()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 3)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 3;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void CFOPOHMKPHP()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_CONFIRM_UNKNOWNREASON", Random.Range(271f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void PKJLMLMKJHB()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 1398f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 6)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 2;
			}
		}
	}

	public void ICKAEOOAENJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 901f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 1;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 2)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 6;
			}
		}
	}

	public void FCPEAHPNFPD()
	{
		if (EOBFNHDMLHJ == 1)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("Token", Random.Range(1584f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void ECIPJIBFGIP()
	{
		if (EOBFNHDMLHJ == 5)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("champion", Random.Range(67f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void DIPKKPOBJPB()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 2;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 6;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 1;
		}
	}

	public void IKNIFLNCMGA()
	{
		if (EOBFNHDMLHJ == 8)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("reload_grenadelauncher", Random.Range(819f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void PAMFHFJEEKM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 773f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 1)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 1)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 4;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 7)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 1;
			}
		}
	}

	public void BBFFDOAMAOJ()
	{
		if (EOBFNHDMLHJ == 6)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("ID_GUI_SQUADLEVELEDUP_NOINCR", Random.Range(1657f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void EIELJHKKHMJ()
	{
		if (EOBFNHDMLHJ == 7)
		{
			if (OJAKKADLFFA == null)
			{
				OJAKKADLFFA = Camera.main.transform;
			}
			InvokeRepeating("WarBucks", Random.Range(211f, OMLCBPDFLOI), OMLCBPDFLOI);
		}
	}

	public void ECOHEHPGGBO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		if (num <= FIINJIFHJKC)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 4)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 5)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 0;
			}
		}
		else if (HEOJCIMNDIO != 0)
		{
			Renderer aMAMEOMNCJJ3 = AMAMEOMNCJJ;
			bool flag = false;
			FCKPJPHPFAI.enabled = flag;
			flag = flag;
			POJLLDMLKKL.enabled = flag;
			aMAMEOMNCJJ3.enabled = flag;
			HEOJCIMNDIO = 0;
		}
	}

	public void IHKDJHOPBBN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 689f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = false;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = false;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = false;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 5;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = true;
				HEOJCIMNDIO = 1;
			}
		}
	}

	public void CHLKINDEBAD()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, OJAKKADLFFA.position.y, base.transform.position.z), OJAKKADLFFA.position);
		int layer = base.gameObject.layer;
		if (num <= OJAKKADLFFA.GetComponent<Camera>().layerCullDistances[layer] + 577f)
		{
			if (num < DJEFCHAAPKK && HEOJCIMNDIO != 0)
			{
				Renderer fCKPJPHPFAI = FCKPJPHPFAI;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				fCKPJPHPFAI.enabled = flag;
				AMAMEOMNCJJ.enabled = true;
				HEOJCIMNDIO = 0;
			}
			else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO != 0)
			{
				Renderer aMAMEOMNCJJ = AMAMEOMNCJJ;
				bool flag = true;
				FCKPJPHPFAI.enabled = flag;
				aMAMEOMNCJJ.enabled = flag;
				POJLLDMLKKL.enabled = true;
				HEOJCIMNDIO = 3;
			}
			else if (num >= KMKEMDGMLAG && HEOJCIMNDIO != 8)
			{
				Renderer aMAMEOMNCJJ2 = AMAMEOMNCJJ;
				bool flag = true;
				POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				FCKPJPHPFAI.enabled = false;
				HEOJCIMNDIO = 1;
			}
		}
	}
}
