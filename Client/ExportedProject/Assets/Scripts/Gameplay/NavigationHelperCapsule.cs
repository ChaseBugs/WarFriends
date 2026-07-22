using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PhysicsEventsListener))]
public class NavigationHelperCapsule : Core_BaseScript
{
	[FormerlySerializedAs("BHIBOFJIJMK")]
	public int IBHJHDFBONH;

	private CapsuleCollider DAONJHNFHLH;

	private float OJMHILPNJHA = 0.37f;

	[FormerlySerializedAs("GBGGJOPMKIP")]
	public NavigationAgent IBIPBGLCNMF;

	private Ray FFHAMGMKCIH;

	private int PKDLNCNNKAB;

	private Vector3 BFMIPPEBAAL => base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 0.01f);

	public bool NOLDCLBJDPE(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -24);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.KCEIPFNJBDF(base.transform.position + new Vector3(1692f, 1534f, 470f), 667f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1771f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1906f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return true;
		}
		return false;
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool FAMDCDNOBIK(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -8);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.PHGEDHLOGHH(base.transform.position + new Vector3(549f, 1599f, 396f), 1246f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 575f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 145f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return true;
		}
		return false;
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool ShouldAvoid(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << IBHJHDFBONH;
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DrawCross(base.transform.position + new Vector3(0f, 0.4f, 0f), 0.25f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 0f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 0f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private Vector3 ONAHKCMPFKG()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1139f);
	}

	[SpecialName]
	private Vector3 ABLGDCGGENE()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 936f);
	}

	protected void AAABJNBFLEG()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.DrawSphere(MLMBOKFFJHC() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1822f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.OFJBFMNHDFO(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 629f, Color.red);
			CameraLineRenderer.HHLGODPOFMC(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	[SpecialName]
	private Vector3 FEOKHCBILNE()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1100f);
	}

	public bool COGPGBKLCAF(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & -71);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DrawCross(base.transform.position + new Vector3(1294f, 1891f, 260f), 367f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1788f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1746f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void CMELHMEBEFI()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(ABLGDCGGENE() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1401f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DLLINJGMKMP(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1889f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool LOAEMBLFJCA(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & 0x20);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1477f, 642f, 506f), 508f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1017f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1502f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	protected void BBCOBMGHMGE()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.DrawSphere(MIDBPMAINCB() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1099f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DrawCross(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 961f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	public bool IBPLKFCCMLH(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & -80);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.PHGEDHLOGHH(base.transform.position + new Vector3(226f, 814f, 1807f), 1333f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1957f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 345f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return true;
		}
		return true;
	}

	[SpecialName]
	private Vector3 LJKEJMJMIEG()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1292f);
	}

	[SpecialName]
	private Vector3 MLMBOKFFJHC()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1386f);
	}

	public bool MEDLDLGEJCN(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & 0x22);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.OFJBFMNHDFO(base.transform.position + new Vector3(1505f, 1789f, 1105f), 807f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 36f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 51f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return true;
		}
		return true;
	}

	protected void FMKLDIJPHIH()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.PCICCKPDFIK(LJKEJMJMIEG() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1567f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.JMKPOFALHAC(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 131f, Color.red);
			CameraLineRenderer.NDABNOLDLMM(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected virtual void ECMMDCKONDK()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void MGAIKDBOPKI()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(FEOKHCBILNE() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 845f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DLLINJGMKMP(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 122f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected void FLDCHPBPKND()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.GKDPHMGHMBI(FEOKHCBILNE() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 602f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DrawCross(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 888f, Color.red);
			CameraLineRenderer.HHLGODPOFMC(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	[SpecialName]
	private Vector3 GBFDEBPEOME()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1324f);
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool JGAELCLFEEN(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -2);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1450f, 1213f, 1495f), 1416f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1057f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 999f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	[SpecialName]
	private Vector3 EODLFIKFHHO()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1129f);
	}

	protected virtual void IGOMLJOMFGA()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool PPOJIHLBCEM(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & 0x35);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1384f, 1560f, 1973f), 1646f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1128f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 559f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	private Vector3 IMANPMHGAMJ()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 403f);
	}

	[SpecialName]
	private Vector3 PAAGBCLBKAF()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 119f);
	}

	protected void Update()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.DrawSphere(BFMIPPEBAAL + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 0.8f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DrawCross(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 0.2f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void OGJGIMLMJBF()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(CBLKCJGBBHI() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1323f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.KCEIPFNJBDF(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1447f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	public bool MMJNIKPNGHL(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & 0xA);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1429f, 1798f, 896f), 1129f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1588f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1482f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	protected void FGECFIBLFMD()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.DrawSphere(BFMIPPEBAAL + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1869f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.JMKPOFALHAC(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 747f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	[SpecialName]
	private Vector3 CBLKCJGBBHI()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 424f);
	}

	public bool PDFGJGJPPPA(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -27);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.PHGEDHLOGHH(base.transform.position + new Vector3(956f, 1272f, 1353f), 1894f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1993f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1832f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return true;
		}
		return true;
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void CJAHPFMAMKK()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.PCICCKPDFIK(KIHGKCHGHJM() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1174f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.PHGEDHLOGHH(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1782f, Color.red);
			CameraLineRenderer.HHLGODPOFMC(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	public bool NIECHDGBJLJ(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & 0x73);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DrawCross(base.transform.position + new Vector3(1166f, 1205f, 1518f), 806f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1439f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1974f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	protected void HKPIHGBKAHO()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.PCICCKPDFIK(MLMBOKFFJHC() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1459f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.PHGEDHLOGHH(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1769f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	[SpecialName]
	private Vector3 KIHGKCHGHJM()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1724f);
	}

	protected void EKPBOMOMMFB()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(CBLKCJGBBHI() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1465f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.JMKPOFALHAC(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1664f, Color.red);
			CameraLineRenderer.NDABNOLDLMM(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected virtual void ACPHOCKEOII()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool GOAGFBBCBAH(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -1);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.PHGEDHLOGHH(base.transform.position + new Vector3(864f, 244f, 1834f), 613f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 762f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 27f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return false;
		}
		return true;
	}

	protected void JOCHCGHAIGH()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.GKDPHMGHMBI(EGHPCEAJNFA() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 620f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DrawCross(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 221f, Color.red);
			CameraLineRenderer.HHLGODPOFMC(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void EMFLLHFPOOB()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(KIHGKCHGHJM() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 550f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DLLINJGMKMP(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 666f, Color.red);
			CameraLineRenderer.NDABNOLDLMM(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	public bool FDCIIIOHKLJ(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 0 << (IBHJHDFBONH & -107);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(694f, 1426f, 1939f), 1380f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 14f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 793f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	[SpecialName]
	private Vector3 EGHPCEAJNFA()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1885f);
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void ANLFCJJCGMG()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.GKDPHMGHMBI(FEOKHCBILNE() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 294f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DLLINJGMKMP(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1791f, Color.red);
			CameraLineRenderer.HHLGODPOFMC(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	public bool INPFDAHLMLI(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -78);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1701f, 293f, 892f), 1931f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 20f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 735f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return false;
		}
		return true;
	}

	protected void OCBLKIFKJEG()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(EODLFIKFHHO() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1079f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.PHGEDHLOGHH(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 30f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}

	[SpecialName]
	private Vector3 MIDBPMAINCB()
	{
		return base.transform.position + IBIPBGLCNMF.direction.normalized * (DAONJHNFHLH.radius + 1800f);
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	public bool FGANHAKJFND(out RaycastHit MGECAKNCNBD)
	{
		FFHAMGMKCIH = new Ray(base.transform.position, IBIPBGLCNMF.direction);
		PKDLNCNNKAB = 1 << (IBHJHDFBONH & -38);
		if (Physics.Raycast(FFHAMGMKCIH, out MGECAKNCNBD, OJMHILPNJHA + DAONJHNFHLH.radius, PKDLNCNNKAB) && MGECAKNCNBD.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DLLINJGMKMP(base.transform.position + new Vector3(1725f, 1696f, 913f), 1859f, Color.red);
			}
			Vector3 vector = IBIPBGLCNMF.destnation - base.transform.position;
			vector.y = 1365f;
			Vector3 vector2 = MGECAKNCNBD.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 1701f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected virtual void AKBKAKINING()
	{
		base.Awake();
		DAONJHNFHLH = GetComponent<CapsuleCollider>();
		base.gameObject.layer = IBHJHDFBONH;
	}

	protected void CDJBEAIDHKH()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.BKFINOFLDIK(CBLKCJGBBHI() + IBIPBGLCNMF.direction.normalized * OJMHILPNJHA, DAONJHNFHLH.radius * 1516f, (!IBIPBGLCNMF.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.KCEIPFNJBDF(base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), 1588f, Color.red);
			CameraLineRenderer.NDABNOLDLMM(base.transform.position, base.transform.position + IBIPBGLCNMF.direction.normalized * (OJMHILPNJHA + DAONJHNFHLH.radius), Color.green);
		}
	}
}
