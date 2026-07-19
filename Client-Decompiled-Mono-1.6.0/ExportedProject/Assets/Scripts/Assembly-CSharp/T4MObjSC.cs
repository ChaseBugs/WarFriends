using UnityEngine;

[ExecuteInEditMode]
public class T4MObjSC : MonoBehaviour
{
	[HideInInspector]
	public string EEGDCFPMPLA = string.Empty;

	[HideInInspector]
	public bool BKJBHOKKNKA = true;

	[HideInInspector]
	public Vector3[] KAJBHJDNIFP;

	[HideInInspector]
	public T4MLodObjSC[] EBBMDNCFGEH;

	[HideInInspector]
	public int[] HEOJCIMNDIO;

	[HideInInspector]
	public float FIINJIFHJKC = 60f;

	[HideInInspector]
	public float DJEFCHAAPKK = 20f;

	[HideInInspector]
	public float KMKEMDGMLAG = 40f;

	[HideInInspector]
	public float OMLCBPDFLOI = 0.5f;

	[HideInInspector]
	public Transform OJAKKADLFFA;

	private Vector3 IOGNLMNDANM;

	[HideInInspector]
	public int EOBFNHDMLHJ = 1;

	[HideInInspector]
	public int KEFMFLIJOPM;

	[HideInInspector]
	public bool OGFDMBCLGJG = true;

	[HideInInspector]
	public Vector3[] DGCHDHIELHD;

	[HideInInspector]
	public float DLDEMPCHCIE = 0.05f;

	[HideInInspector]
	public int[] DHKDJIMLKAM;

	[HideInInspector]
	public float ANJNIMBBANI = 30f;

	[HideInInspector]
	public T4MBillBObjSC[] MDHJPDMACKD;

	[HideInInspector]
	public bool FLMFLMONEIB = true;

	[HideInInspector]
	public float FDGGADCGIKD = 1000f;

	[HideInInspector]
	public float HPFADDJGBCG = 200f;

	[HideInInspector]
	public float ECCPEJHBOEE = 60f;

	[HideInInspector]
	public float PCELHPAMFAO = 30f;

	private float[] OJLFGKCFLPJ = new float[32];

	[HideInInspector]
	public int HMBKEKIODFK;

	[HideInInspector]
	public bool AGLOAGDAGBG = true;

	[HideInInspector]
	public bool BJBFPJMEFBD = true;

	public Material JLDPCFKAEEO;

	public MeshFilter BBJGJGONKEK;

	public Color GDMFPPBDKBD = new Color(0.73f, 0.85f, 0.4f, 1f);

	public Vector4 FIJCPAJCNCG = new Vector4(0.85f, 0.075f, 0.4f, 0.5f);

	public float MPGOLKLOAMI = 0.75f;

	public float ODGKKPCIGAK = 1.5f;

	public bool BGMCMEAJEOD;

	public bool NKFMIIEKIAD;

	public bool GHNOECFGIPF;

	public bool ONBKBPHJDGL;

	public Texture2D FMGPGKMOMAB;

	public Texture2D OEBPKMFKOGM;

	private int EEHJHAJGLMK;

	private int DDKNJBHELAO;

	private int PCLEICHOHLK;

	private int HIOGEHPHGPP;

	public void OBEHLLBBEIL()
	{
		EEHJHAJGLMK = Shader.PropertyToID("Bad Player Visuals!");
		DDKNJBHELAO = Shader.PropertyToID("NAME");
		PCLEICHOHLK = Shader.PropertyToID("Gold");
		HIOGEHPHGPP = Shader.PropertyToID("NewVisuals");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-65] = PCELHPAMFAO;
			OJLFGKCFLPJ[-122] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-88] = HPFADDJGBCG;
			OJLFGKCFLPJ[91] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("QUITTER", Random.Range(492f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("Checker", Random.Range(1628f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 8 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].MPIONGGPBEO();
					}
					else
					{
						EBBMDNCFGEH[j].CFOPOHMKPHP();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("Hiding CONFIRM dialog", Random.Range(1220f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating(" {0}\u00a0{1}", Random.Range(1021f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void JIKKBJEIFIJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 6;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 8;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void FGLMBHGIFDI()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 0;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void HHCJMJCFKAA()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void AHLFOJHJMDM()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	private void BJPDFCAPIBB()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	private void IIOEBGMNGLE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void DLGDHIHBJFI()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 0;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void CPGMLNKBIGC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 154f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
			}
		}
	}

	private void DLLGBACMDLA()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 282f);
		}
	}

	private void GKPLPGBFBIO()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 953f);
		}
	}

	private void MNPKACHHNJA()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	private void CJMLBPNACMM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 2;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void PDEMNFEIKEE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 7;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void BFEFPNINMPN()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 872f);
		}
	}

	private void LCPGAPCEINK()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 0;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void NKLICPMJIAO()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void CNNGFHLGOPJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 6;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 3;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void GABJCMBKNJO()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	public void Awake()
	{
		EEHJHAJGLMK = Shader.PropertyToID("_Wind");
		DDKNJBHELAO = Shader.PropertyToID("_GrassWind");
		PCLEICHOHLK = Shader.PropertyToID("_TranslucencyColor");
		HIOGEHPHGPP = Shader.PropertyToID("_TranslucencyViewDependency");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[26] = PCELHPAMFAO;
			OJLFGKCFLPJ[27] = ECCPEJHBOEE;
			OJLFGKCFLPJ[28] = HPFADDJGBCG;
			OJLFGKCFLPJ[29] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("KLHPEJKKNPD", Random.Range(0f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("FJEFKFCDJIH", Random.Range(0f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 2 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].ActivateLODScrpt();
					}
					else
					{
						EBBMDNCFGEH[j].ActivateLODLay();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("HBEJDPMOCCD", Random.Range(0f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("LLCCAALEHGN", Random.Range(0f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void EHDNCKAHNDI()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 564f);
		}
	}

	public void CJOLAJGALCD()
	{
		EEHJHAJGLMK = Shader.PropertyToID("Error - sheet {0} doesnt have column {1}");
		DDKNJBHELAO = Shader.PropertyToID("FacebookPassword");
		PCLEICHOHLK = Shader.PropertyToID("friend name");
		HIOGEHPHGPP = Shader.PropertyToID(" BOXES ");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-63] = PCELHPAMFAO;
			OJLFGKCFLPJ[-44] = ECCPEJHBOEE;
			OJLFGKCFLPJ[97] = HPFADDJGBCG;
			OJLFGKCFLPJ[-90] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[1].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("Shots_Hits", Random.Range(1950f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("League", Random.Range(1112f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 4 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].MPIONGGPBEO();
					}
					else
					{
						EBBMDNCFGEH[j].ECIPJIBFGIP();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("1", Random.Range(1320f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("Failed to join room during or after match and MatchManager.isReconnect = FALSE", Random.Range(1925f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void CIDIEDOBHNF()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1976f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 6;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
			}
		}
	}

	private void LFDDBOFDNFG()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 0;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	public void FGOGGLDAKHL()
	{
		EEHJHAJGLMK = Shader.PropertyToID("ID_UNIT2TRAIN_UNIT1TRAIN");
		DDKNJBHELAO = Shader.PropertyToID("ArenaLootBox");
		PCLEICHOHLK = Shader.PropertyToID("Enemy could not be spawned");
		HIOGEHPHGPP = Shader.PropertyToID("Days_Since_Install");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-87] = PCELHPAMFAO;
			OJLFGKCFLPJ[56] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-12] = HPFADDJGBCG;
			OJLFGKCFLPJ[-105] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("S", Random.Range(1502f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("ID_READYTIME", Random.Range(93f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 1 && EBBMDNCFGEH[1] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].OMNAAHDHPGA();
					}
					else
					{
						EBBMDNCFGEH[j].IGGFPBOBADH();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating(" BOUGHT AND PRESENT IN ACCOUNT", Random.Range(483f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("ID_EXTRAAMMO", Random.Range(1594f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void CKOPHKAKHHD()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 51f);
		}
	}

	private void NBDABIAOCJI()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 1217f);
		}
	}

	private void HINLOFJJKLE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1292f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
			}
		}
	}

	private void GAGDIFHDPEH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void ENLKLFICMNI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	public void OBPMHHGJFEL()
	{
		EEHJHAJGLMK = Shader.PropertyToID("ID_LEAGUETOPPOSITIONHINT");
		DDKNJBHELAO = Shader.PropertyToID("menu-arena-ticket");
		PCLEICHOHLK = Shader.PropertyToID("'ID_MONTH_'0");
		HIOGEHPHGPP = Shader.PropertyToID("country-egypt");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[75] = PCELHPAMFAO;
			OJLFGKCFLPJ[126] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-104] = HPFADDJGBCG;
			OJLFGKCFLPJ[-5] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[1].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("ACD: Memory was tampered, cheater detected!", Random.Range(145f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("url", Random.Range(416f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 4 && EBBMDNCFGEH[1] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].IIFLNBFNKHC();
					}
					else
					{
						EBBMDNCFGEH[j].IEJPJJNLNNE();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("01 ", Random.Range(810f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("PROD", Random.Range(1510f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void PHHMPPDJMCF()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 3;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void NGHKFENNEFD()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 1454f);
		}
	}

	private void LKPHNLCLDGJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 593f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 8;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
			}
		}
	}

	private void MHFAANKODJC()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void LKEECNDOOEI()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 5;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void JGBPPDAECHC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 7;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void FCJCAAOBJOO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 6;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void BCNALFFNBEJ()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void LOMFPMNKMIG()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void NDABAMHNICO()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	public void CDPAGKOKDOP()
	{
		EEHJHAJGLMK = Shader.PropertyToID("ID_CONFIRM_ERROR");
		DDKNJBHELAO = Shader.PropertyToID("ID_SQUADMEDALS");
		PCLEICHOHLK = Shader.PropertyToID("menu-event-day-bg");
		HIOGEHPHGPP = Shader.PropertyToID("\n");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-73] = PCELHPAMFAO;
			OJLFGKCFLPJ[92] = ECCPEJHBOEE;
			OJLFGKCFLPJ[40] = HPFADDJGBCG;
			OJLFGKCFLPJ[115] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("GoldenSuitcase", Random.Range(1872f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("StartTime", Random.Range(1092f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 6 && EBBMDNCFGEH[1] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].ADFPJOMKBHN();
					}
					else
					{
						EBBMDNCFGEH[j].NEGMMJNKHKG();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("Mode with name {0} met criteria {1} ", Random.Range(1426f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("SheetConfig", Random.Range(624f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void IPLJGIGPAGO()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 417f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 1)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 3;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
			}
		}
	}

	public void OGFAHEALGFN()
	{
		EEHJHAJGLMK = Shader.PropertyToID("RecentVideos");
		DDKNJBHELAO = Shader.PropertyToID("Hide Ground");
		PCLEICHOHLK = Shader.PropertyToID("ERROR FROM SERVER ");
		HIOGEHPHGPP = Shader.PropertyToID("Sniper_Tutorial_Duration");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[64] = PCELHPAMFAO;
			OJLFGKCFLPJ[-14] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-74] = HPFADDJGBCG;
			OJLFGKCFLPJ[40] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("ID_CONFIRM_INAPP_FAILED", Random.Range(1410f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("(", Random.Range(194f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 8 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].MPIONGGPBEO();
					}
					else
					{
						EBBMDNCFGEH[j].NMDIFGIHLBA();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("0", Random.Range(1262f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("S", Random.Range(1127f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	public void ECMMDCKONDK()
	{
		EEHJHAJGLMK = Shader.PropertyToID("null");
		DDKNJBHELAO = Shader.PropertyToID("ID_ARENARULES_LATEOVERTIME");
		PCLEICHOHLK = Shader.PropertyToID("ID_TOBENUMBERONE2");
		HIOGEHPHGPP = Shader.PropertyToID("ID_MISSION_SURVIVE_HUD");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-41] = PCELHPAMFAO;
			OJLFGKCFLPJ[-24] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-57] = HPFADDJGBCG;
			OJLFGKCFLPJ[-17] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("Gold", Random.Range(375f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating(" OK!", Random.Range(1478f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 4 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].IIFLNBFNKHC();
					}
					else
					{
						EBBMDNCFGEH[j].MJJLCMEDHIH();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("open", Random.Range(669f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("Bad Decal Manager Data", Random.Range(311f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void CNBHOOIGLIP()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void AFCAIMEKGCE()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void LLCCAALEHGN()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void KAAKHBCOKDP()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 568f);
		}
	}

	private void BDKEHJEHGOL()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 172f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 8)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 8;
				}
			}
		}
	}

	private void LFANHFLAIHC()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void AHBLMAACBLB()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void LateUpdate()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 0.65f);
		}
	}

	private void FKDHOMJDCAA()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 2;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void LHCEHELLLIM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 999f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 8)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
			}
		}
	}

	private void EPOLOEEKBAG()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	private void MGMACFCBKAB()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 0;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void DGFMLFJDADM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 8;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 5;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	public void EKEHGBNPAFC()
	{
		EEHJHAJGLMK = Shader.PropertyToID("Elites Feature Shown Request Success");
		DDKNJBHELAO = Shader.PropertyToID("ID_STAT_GLOBALXP");
		PCLEICHOHLK = Shader.PropertyToID("RETRYPERM");
		HIOGEHPHGPP = Shader.PropertyToID("BAND_TYPE_EMPTY");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[77] = PCELHPAMFAO;
			OJLFGKCFLPJ[38] = ECCPEJHBOEE;
			OJLFGKCFLPJ[54] = HPFADDJGBCG;
			OJLFGKCFLPJ[77] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("WarBucks", Random.Range(957f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("opponentState.willAttack = true", Random.Range(559f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 2 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].ActivateLODScrpt();
					}
					else
					{
						EBBMDNCFGEH[j].GBJLOMNDLCE();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("Ping", Random.Range(983f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("ID_PHASECLOSED", Random.Range(1544f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	public void OMDILMPFKII()
	{
		EEHJHAJGLMK = Shader.PropertyToID("GameLoginManager: Reloging...");
		DDKNJBHELAO = Shader.PropertyToID("{0} Army Icon LVL{1} ORDER{2}");
		PCLEICHOHLK = Shader.PropertyToID("ID_SCORE");
		HIOGEHPHGPP = Shader.PropertyToID("{0}{1}");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-72] = PCELHPAMFAO;
			OJLFGKCFLPJ[90] = ECCPEJHBOEE;
			OJLFGKCFLPJ[36] = HPFADDJGBCG;
			OJLFGKCFLPJ[-22] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[1].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("accountName", Random.Range(318f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("Stats", Random.Range(1243f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 0 && EBBMDNCFGEH[1] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].JDBPNEFLKKB();
					}
					else
					{
						EBBMDNCFGEH[j].ODOCJDBGNFG();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("ID_WARNING_CANTSENDINVITE_TEXT", Random.Range(843f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("Waiting too long to start match, Match start: {0} photon time: {1}", Random.Range(751f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	public void KDMECDLHNMC()
	{
		EEHJHAJGLMK = Shader.PropertyToID("About to show Name Change Reminder");
		DDKNJBHELAO = Shader.PropertyToID("ArenaHeartDialog");
		PCLEICHOHLK = Shader.PropertyToID("AdDidShow(");
		HIOGEHPHGPP = Shader.PropertyToID("'RewardForDay_'0");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[23] = PCELHPAMFAO;
			OJLFGKCFLPJ[53] = ECCPEJHBOEE;
			OJLFGKCFLPJ[69] = HPFADDJGBCG;
			OJLFGKCFLPJ[-9] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[1].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("LevelName", Random.Range(1242f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("Daily_Visit_Main_Menu", Random.Range(1872f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 3 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].JLPFPOOOBAM();
					}
					else
					{
						EBBMDNCFGEH[j].IEJPJJNLNNE();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("[0-9.,]*", Random.Range(1944f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("^[0-9]*-", Random.Range(185f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void GMECCGOLOGL()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void BCCHOHNPJEO()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	public void IOKMAFLIJEG()
	{
		EEHJHAJGLMK = Shader.PropertyToID("Player_Avoided_Grenade_On_First_Try");
		DDKNJBHELAO = Shader.PropertyToID("SquadId");
		PCLEICHOHLK = Shader.PropertyToID("id");
		HIOGEHPHGPP = Shader.PropertyToID("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-16] = PCELHPAMFAO;
			OJLFGKCFLPJ[27] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-82] = HPFADDJGBCG;
			OJLFGKCFLPJ[-93] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[1].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("ID_CONFIRM_DELETESQUAD", Random.Range(1714f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("SetHitByPlayerRPC", Random.Range(1439f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 3 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].NAILNFLJNLP();
					}
					else
					{
						EBBMDNCFGEH[j].GBJLOMNDLCE();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("Error Deserializing JSON for ", Random.Range(859f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("ID_VISUALRARITY1", Random.Range(1977f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void ECCJADGGFDM()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 814f);
		}
	}

	private void AEPAANAJIAI()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void BHBDPJELBAI()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 1306f);
		}
	}

	private void EONEFBAMHNB()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void DFLGBEJKDBD()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void GGPKPGEKMOB()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 2;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void BLKEOHPMPMF()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1646f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
			}
		}
	}

	private void PJPMCBDJGDK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 552f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 5;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
			}
		}
	}

	private void DGPIHCCECJF()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 1112f);
		}
	}

	private void GEDAOHKMJGE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 405f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
			}
		}
	}

	public void AKHKMOOJOGC()
	{
		EEHJHAJGLMK = Shader.PropertyToID("height");
		DDKNJBHELAO = Shader.PropertyToID("NULL WARCARD");
		PCLEICHOHLK = Shader.PropertyToID("bazooka_uncover_left");
		HIOGEHPHGPP = Shader.PropertyToID("Failed to join room during or after match and MatchManager.isReconnect = FALSE");
		if (KEFMFLIJOPM != 1)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-25] = PCELHPAMFAO;
			OJLFGKCFLPJ[13] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-78] = HPFADDJGBCG;
			OJLFGKCFLPJ[14] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("DOWNLOAD", Random.Range(999f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("skip session update scheduling, because alredy session update is ", Random.Range(237f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 6 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j += 0)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].FCPEAHPNFPD();
					}
					else
					{
						EBBMDNCFGEH[j].EIELJHKKHMJ();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("ShadowSetActive", Random.Range(737f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("ID_SKILLSHOTHINT_VEHICLEDESTROYED", Random.Range(1364f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void KLHPEJKKNPD()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 3;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void LIDKPADFBDB()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void KHKAMOGCLMC()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void AGJPDDEAPKI()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	public void CIGLDDGDAPM()
	{
		EEHJHAJGLMK = Shader.PropertyToID("ID_GUI_CHEATINGMESSAGE");
		DDKNJBHELAO = Shader.PropertyToID("null");
		PCLEICHOHLK = Shader.PropertyToID("RECEIVED LOOTBOX");
		HIOGEHPHGPP = Shader.PropertyToID("N");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-9] = PCELHPAMFAO;
			OJLFGKCFLPJ[3] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-113] = HPFADDJGBCG;
			OJLFGKCFLPJ[-107] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("N", Random.Range(1152f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("0", Random.Range(1962f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 0 && EBBMDNCFGEH[1] != null)
		{
			for (int j = 1; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].IIFLNBFNKHC();
					}
					else
					{
						EBBMDNCFGEH[j].DKPBDLGPCPN();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("ID_ACCESSORYISACCESSIBLEONLYTOVIP", Random.Range(547f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("\"{0}\" ", Random.Range(1832f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void BDJJLFIBBMJ()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void LDLEELNFMAJ()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void PADKANCHKMM()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 449f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 6;
				}
			}
		}
	}

	private void LHLLIEKEAIB()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void AHIGBHGJOFK()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 0)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void INLNODEIFAP()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 860f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 4;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
			}
		}
	}

	private void NDFOMMHOHCP()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1543f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 1)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 8;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 8)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
			}
		}
	}

	private void JJAJPENMPFM()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 737f);
		}
	}

	private void COFMOPMAJIL()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 610f);
		}
	}

	private void JEEIEJKMBFC()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void BANBCAMDHDJ()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 6;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void CCGCPIBEBGC()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 8;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void JHLCJKLNPCD()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 1017f);
		}
	}

	private void LIBAMCBDKMN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1053f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 4)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
			}
		}
	}

	private void HBEJDPMOCCD()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 0;
			}
		}
	}

	public void FOIKLCECNBL()
	{
		EEHJHAJGLMK = Shader.PropertyToID("ID_MISSIONANIMATION_BOSSINCOMING");
		DDKNJBHELAO = Shader.PropertyToID("getCampaignId");
		PCLEICHOHLK = Shader.PropertyToID("ID_ANDROIDRESTOREPURCHASES");
		HIOGEHPHGPP = Shader.PropertyToID("right");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-38] = PCELHPAMFAO;
			OJLFGKCFLPJ[66] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-61] = HPFADDJGBCG;
			OJLFGKCFLPJ[-120] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 0 && EOBFNHDMLHJ == 0)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("MAIS UMA", Random.Range(1770f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("ID_VIDEOREADY3", Random.Range(437f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].JLPFPOOOBAM();
					}
					else
					{
						EBBMDNCFGEH[j].EIELJHKKHMJ();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("country", Random.Range(515f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("N", Random.Range(272f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void IFLCGJLGMPL()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void CCCBIKGEBKN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = true;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 0;
			}
		}
	}

	private void NIGHINGEINC()
	{
		if (BGMCMEAJEOD)
		{
			Color value = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * MPGOLKLOAMI);
			value.a = FIJCPAJCNCG.w;
			Color value2 = FIJCPAJCNCG * Mathf.Sin(Time.realtimeSinceStartup * ODGKKPCIGAK);
			value2.a = FIJCPAJCNCG.w;
			Shader.SetGlobalColor(EEHJHAJGLMK, value);
			Shader.SetGlobalColor(DDKNJBHELAO, value2);
			Shader.SetGlobalColor(PCLEICHOHLK, GDMFPPBDKBD);
			Shader.SetGlobalFloat(HIOGEHPHGPP, 397f);
		}
	}

	private void EIJFOHEKEGN()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 0)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 5)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 5;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	private void MFNMEBEFOLN()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i++)
		{
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= ANJNIMBBANI)
			{
				if (DHKDJIMLKAM[i] != 1)
				{
					MDHJPDMACKD[i].HLOCLMNIFBP.enabled = true;
					DHKDJIMLKAM[i] = 1;
				}
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
			else if (DHKDJIMLKAM[i] != 0 && !MDHJPDMACKD[i].HLOCLMNIFBP.enabled)
			{
				MDHJPDMACKD[i].HLOCLMNIFBP.enabled = false;
				DHKDJIMLKAM[i] = 1;
			}
		}
	}

	private void INGALKKMKPK()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1910f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 6;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 3;
				}
			}
		}
	}

	private void FNBFIEMJNKE()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			if (num <= FIINJIFHJKC)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 0)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 6)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 7;
				}
			}
			else if (HEOJCIMNDIO[i] != 0)
			{
				Renderer aMAMEOMNCJJ2 = EBBMDNCFGEH[i].AMAMEOMNCJJ;
				bool flag = false;
				EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
				flag = flag;
				EBBMDNCFGEH[i].POJLLDMLKKL.enabled = flag;
				aMAMEOMNCJJ2.enabled = flag;
				HEOJCIMNDIO[i] = 1;
			}
		}
	}

	public void PCDHCIDJJOB()
	{
		EEHJHAJGLMK = Shader.PropertyToID("\"{0}\"\t");
		DDKNJBHELAO = Shader.PropertyToID("fire");
		PCLEICHOHLK = Shader.PropertyToID("Some error occurred. Please, try again later.");
		HIOGEHPHGPP = Shader.PropertyToID("ID_ARENABOXDESCRIPTION_TICKETS");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-6] = PCELHPAMFAO;
			OJLFGKCFLPJ[-52] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-41] = HPFADDJGBCG;
			OJLFGKCFLPJ[-99] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("unit", Random.Range(473f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("ID_NO", Random.Range(1193f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 6 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].BCOFKNDLPLI();
					}
					else
					{
						EBBMDNCFGEH[j].IGGFPBOBADH();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 0 && MDHJPDMACKD[1] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("ID_ZEROSECONDS", Random.Range(1842f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("ID_WARNING_SERVERTIMEDOUT", Random.Range(1998f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void FJEFKFCDJIH()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 0; i < KAJBHJDNIFP.Length; i++)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 5f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = true;
					HEOJCIMNDIO[i] = 1;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 2)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = false;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = true;
					HEOJCIMNDIO[i] = 2;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 3)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = false;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = true;
					HEOJCIMNDIO[i] = 3;
				}
			}
		}
	}

	public void BACJPKBJNIB()
	{
		EEHJHAJGLMK = Shader.PropertyToID("WelcomeBackSoldierMessage {0} {1}");
		DDKNJBHELAO = Shader.PropertyToID("\t");
		PCLEICHOHLK = Shader.PropertyToID("Error - sheet {0} doesnt have column {1}");
		HIOGEHPHGPP = Shader.PropertyToID("GUiManager");
		if (KEFMFLIJOPM != 0)
		{
			return;
		}
		if (OJAKKADLFFA == null && (bool)Camera.main)
		{
			OJAKKADLFFA = Camera.main.transform;
		}
		else if (OJAKKADLFFA == null && !Camera.main)
		{
			Camera[] array = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			for (int i = 1; i < array.Length; i += 0)
			{
				if ((bool)array[i].GetComponent<AudioListener>())
				{
					OJAKKADLFFA = array[i].transform;
				}
			}
		}
		if (FLMFLMONEIB && OJAKKADLFFA != null)
		{
			OJLFGKCFLPJ[-27] = PCELHPAMFAO;
			OJLFGKCFLPJ[10] = ECCPEJHBOEE;
			OJLFGKCFLPJ[-9] = HPFADDJGBCG;
			OJLFGKCFLPJ[7] = FDGGADCGIKD;
			OJAKKADLFFA.GetComponent<Camera>().layerCullDistances = OJLFGKCFLPJ;
		}
		if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 1)
		{
			if (EBBMDNCFGEH[0].gameObject != null)
			{
				if (AGLOAGDAGBG)
				{
					InvokeRepeating("()Landroid/content/Context;", Random.Range(1263f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
				else
				{
					InvokeRepeating("ID_TUTORIAL_FULL_ARSENAL_DOWN", Random.Range(1760f, OMLCBPDFLOI), OMLCBPDFLOI);
				}
			}
		}
		else if (BKJBHOKKNKA && KAJBHJDNIFP.Length > 1 && EOBFNHDMLHJ == 6 && EBBMDNCFGEH[0] != null)
		{
			for (int j = 0; j < KAJBHJDNIFP.Length; j++)
			{
				if (EBBMDNCFGEH[j] != null)
				{
					if (AGLOAGDAGBG)
					{
						EBBMDNCFGEH[j].ADFPJOMKBHN();
					}
					else
					{
						EBBMDNCFGEH[j].EPDIBDFPONE();
					}
				}
			}
		}
		if (OGFDMBCLGJG && DGCHDHIELHD.Length > 1 && MDHJPDMACKD[0] != null)
		{
			if (BJBFPJMEFBD)
			{
				InvokeRepeating("Turret", Random.Range(1719f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
			else
			{
				InvokeRepeating("Measure Event With Event Items clicked", Random.Range(1455f, DLDEMPCHCIE), DLDEMPCHCIE);
			}
		}
	}

	private void BFDMHIFMODL()
	{
		if (IOGNLMNDANM == OJAKKADLFFA.position)
		{
			return;
		}
		IOGNLMNDANM = OJAKKADLFFA.position;
		for (int i = 1; i < KAJBHJDNIFP.Length; i += 0)
		{
			float num = Vector3.Distance(new Vector3(KAJBHJDNIFP[i].x, OJAKKADLFFA.position.y, KAJBHJDNIFP[i].z), OJAKKADLFFA.position);
			int layer = EBBMDNCFGEH[i].gameObject.layer;
			if (num <= OJLFGKCFLPJ[layer] + 1042f)
			{
				if (num < DJEFCHAAPKK && HEOJCIMNDIO[i] != 1)
				{
					Renderer pOJLLDMLKKL = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					pOJLLDMLKKL.enabled = flag;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = false;
					HEOJCIMNDIO[i] = 0;
				}
				else if (num >= DJEFCHAAPKK && num < KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer aMAMEOMNCJJ = EBBMDNCFGEH[i].AMAMEOMNCJJ;
					bool flag = true;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = flag;
					aMAMEOMNCJJ.enabled = flag;
					EBBMDNCFGEH[i].POJLLDMLKKL.enabled = false;
					HEOJCIMNDIO[i] = 8;
				}
				else if (num >= KMKEMDGMLAG && HEOJCIMNDIO[i] != 7)
				{
					Renderer pOJLLDMLKKL2 = EBBMDNCFGEH[i].POJLLDMLKKL;
					bool flag = true;
					EBBMDNCFGEH[i].AMAMEOMNCJJ.enabled = flag;
					pOJLLDMLKKL2.enabled = flag;
					EBBMDNCFGEH[i].FCKPJPHPFAI.enabled = false;
					HEOJCIMNDIO[i] = 6;
				}
			}
		}
	}

	private void GAFIOLKKLDB()
	{
		for (int i = 1; i < DGCHDHIELHD.Length; i += 0)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}

	private void BINDILJJCGP()
	{
		for (int i = 0; i < DGCHDHIELHD.Length; i++)
		{
			int layer = MDHJPDMACKD[i].gameObject.layer;
			if (Vector3.Distance(DGCHDHIELHD[i], OJAKKADLFFA.position) <= OJLFGKCFLPJ[layer])
			{
				if (HMBKEKIODFK == 0)
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(new Vector3(OJAKKADLFFA.position.x, MDHJPDMACKD[i].PONDHMHNFHH.position.y, OJAKKADLFFA.position.z), Vector3.up);
				}
				else
				{
					MDHJPDMACKD[i].PONDHMHNFHH.LookAt(OJAKKADLFFA.position, Vector3.up);
				}
			}
		}
	}
}
