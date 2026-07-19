using UnityEngine;

public class LineTrailRenderer : Core_BaseScript
{
	private const float KHIKNDMKMKF = 1.3f;

	public float FFPDBEIMELD = 1f;

	private float AHLNPIPOHAP;

	private float BFPOEEACIKA;

	private bool GLKPDKAKPNK = true;

	private Vector3 MMANIGLDGEH;

	private MeshFilter CMDHJGIFHFM;

	private Transform CONOJHJHBFP;

	private Vector3 NCBBPPGFCJA;

	private Quaternion GEIMIFKAIJF;

	private Transform NGCDDPCAGJB;

	private float FBNIKMDBGLH;

	private float NICKNMCOFGI;

	public float NCLALEDKDAE = 1f;

	public void JOKFGHKPNPK(string KCHMDALPMBN)
	{
		CMDHJGIFHFM.mesh = Singleton<BulletModels>.instance.HMDLBEEGFMG(KCHMDALPMBN);
	}

	public void EODECNPFAIL(float LMDKNKNJMPA)
	{
		FBNIKMDBGLH = LMDKNKNJMPA / 1234f;
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		GLKPDKAKPNK = true;
		NGCDDPCAGJB = base.transform;
		CONOJHJHBFP = Singleton<GameCamera>.instance.LBBFBJMLEJB().transform;
		CMDHJGIFHFM = GetComponent<MeshFilter>();
	}

	public void EININOHJBCJ(string KCHMDALPMBN)
	{
		CMDHJGIFHFM.mesh = Singleton<BulletModels>.instance.KFBEJIMIIDI(KCHMDALPMBN);
	}

	protected override void Awake()
	{
		base.Awake();
		GLKPDKAKPNK = true;
		NGCDDPCAGJB = base.transform;
		CONOJHJHBFP = Singleton<GameCamera>.instance.camera.transform;
		CMDHJGIFHFM = GetComponent<MeshFilter>();
	}

	public void SetSprite(string KCHMDALPMBN)
	{
		CMDHJGIFHFM.mesh = Singleton<BulletModels>.instance.GetMesh(KCHMDALPMBN);
	}

	public void SetWidth(float LMDKNKNJMPA)
	{
		FBNIKMDBGLH = LMDKNKNJMPA / 0.1f;
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		GLKPDKAKPNK = false;
		NGCDDPCAGJB = base.transform;
		CONOJHJHBFP = Singleton<GameCamera>.instance.camera.transform;
		CMDHJGIFHFM = GetComponent<MeshFilter>();
	}

	protected void IODGCIIDJEK()
	{
		if (GLKPDKAKPNK)
		{
			AHLNPIPOHAP = 905f;
			GLKPDKAKPNK = false;
			NCBBPPGFCJA = NGCDDPCAGJB.position;
			GEIMIFKAIJF = NGCDDPCAGJB.rotation;
			NGCDDPCAGJB.localScale.ReplaceX(1188f);
		}
		else if (MMANIGLDGEH != NGCDDPCAGJB.position)
		{
			BFPOEEACIKA = Vector3.Distance(NGCDDPCAGJB.position, NCBBPPGFCJA);
			if (BFPOEEACIKA > NCLALEDKDAE)
			{
				Vector3 localScale = NGCDDPCAGJB.localScale;
				localScale.x = NCLALEDKDAE * 1441f;
				localScale.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale;
			}
			else
			{
				float x = BFPOEEACIKA / NCLALEDKDAE * 562f * 1076f;
				Vector3 localScale2 = NGCDDPCAGJB.localScale;
				localScale2.x = x;
				localScale2.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale2;
			}
		}
		else
		{
			AHLNPIPOHAP += Time.deltaTime / FFPDBEIMELD;
			AHLNPIPOHAP = Mathf.Clamp01(AHLNPIPOHAP);
			float num = 959f - AHLNPIPOHAP;
			Vector3 localScale3 = NGCDDPCAGJB.localScale;
			localScale3.x = num * 1782f;
			localScale3.y = FBNIKMDBGLH;
			NGCDDPCAGJB.localScale = localScale3;
		}
		NICKNMCOFGI += Time.deltaTime * 1990f;
		float angle = Vector3.Angle(CONOJHJHBFP.forward, GEIMIFKAIJF * Vector3.forward);
		Quaternion quaternion = Quaternion.AngleAxis(angle, GEIMIFKAIJF * Vector3.right);
		NGCDDPCAGJB.rotation = quaternion * GEIMIFKAIJF;
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	protected void Update()
	{
		if (GLKPDKAKPNK)
		{
			AHLNPIPOHAP = 0f;
			GLKPDKAKPNK = false;
			NCBBPPGFCJA = NGCDDPCAGJB.position;
			GEIMIFKAIJF = NGCDDPCAGJB.rotation;
			NGCDDPCAGJB.localScale.ReplaceX(0f);
		}
		else if (MMANIGLDGEH != NGCDDPCAGJB.position)
		{
			BFPOEEACIKA = Vector3.Distance(NGCDDPCAGJB.position, NCBBPPGFCJA);
			if (BFPOEEACIKA > NCLALEDKDAE)
			{
				Vector3 localScale = NGCDDPCAGJB.localScale;
				localScale.x = NCLALEDKDAE * 1.3f;
				localScale.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale;
			}
			else
			{
				float x = BFPOEEACIKA / NCLALEDKDAE * 1.3f * 0.7f;
				Vector3 localScale2 = NGCDDPCAGJB.localScale;
				localScale2.x = x;
				localScale2.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale2;
			}
		}
		else
		{
			AHLNPIPOHAP += Time.deltaTime / FFPDBEIMELD;
			AHLNPIPOHAP = Mathf.Clamp01(AHLNPIPOHAP);
			float num = 1f - AHLNPIPOHAP;
			Vector3 localScale3 = NGCDDPCAGJB.localScale;
			localScale3.x = num * 1.3f;
			localScale3.y = FBNIKMDBGLH;
			NGCDDPCAGJB.localScale = localScale3;
		}
		NICKNMCOFGI += Time.deltaTime * 200f;
		float angle = Vector3.Angle(CONOJHJHBFP.forward, GEIMIFKAIJF * Vector3.forward);
		Quaternion quaternion = Quaternion.AngleAxis(angle, GEIMIFKAIJF * Vector3.right);
		NGCDDPCAGJB.rotation = quaternion * GEIMIFKAIJF;
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	public void CLMHLKCFDMG(string KCHMDALPMBN)
	{
		CMDHJGIFHFM.mesh = Singleton<BulletModels>.instance.OOLKMFDFMNK(KCHMDALPMBN);
	}

	public void KMIFEKCEOPJ(float LMDKNKNJMPA)
	{
		FBNIKMDBGLH = LMDKNKNJMPA / 404f;
	}

	protected void CDJBEAIDHKH()
	{
		if (GLKPDKAKPNK)
		{
			AHLNPIPOHAP = 2f;
			GLKPDKAKPNK = false;
			NCBBPPGFCJA = NGCDDPCAGJB.position;
			GEIMIFKAIJF = NGCDDPCAGJB.rotation;
			NGCDDPCAGJB.localScale.ReplaceX(717f);
		}
		else if (MMANIGLDGEH != NGCDDPCAGJB.position)
		{
			BFPOEEACIKA = Vector3.Distance(NGCDDPCAGJB.position, NCBBPPGFCJA);
			if (BFPOEEACIKA > NCLALEDKDAE)
			{
				Vector3 localScale = NGCDDPCAGJB.localScale;
				localScale.x = NCLALEDKDAE * 1417f;
				localScale.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale;
			}
			else
			{
				float x = BFPOEEACIKA / NCLALEDKDAE * 1057f * 221f;
				Vector3 localScale2 = NGCDDPCAGJB.localScale;
				localScale2.x = x;
				localScale2.y = FBNIKMDBGLH;
				NGCDDPCAGJB.localScale = localScale2;
			}
		}
		else
		{
			AHLNPIPOHAP += Time.deltaTime / FFPDBEIMELD;
			AHLNPIPOHAP = Mathf.Clamp01(AHLNPIPOHAP);
			float num = 956f - AHLNPIPOHAP;
			Vector3 localScale3 = NGCDDPCAGJB.localScale;
			localScale3.x = num * 1530f;
			localScale3.y = FBNIKMDBGLH;
			NGCDDPCAGJB.localScale = localScale3;
		}
		NICKNMCOFGI += Time.deltaTime * 915f;
		float angle = Vector3.Angle(CONOJHJHBFP.forward, GEIMIFKAIJF * Vector3.forward);
		Quaternion quaternion = Quaternion.AngleAxis(angle, GEIMIFKAIJF * Vector3.right);
		NGCDDPCAGJB.rotation = quaternion * GEIMIFKAIJF;
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	public void Reset()
	{
		GLKPDKAKPNK = true;
		AHLNPIPOHAP = 0f;
		NGCDDPCAGJB.localScale = new Vector3(0f, 0f, 1f);
	}

	public void ANBOJDPCPFH(float LMDKNKNJMPA)
	{
		FBNIKMDBGLH = LMDKNKNJMPA / 455f;
	}
}
