using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour
{
	public Transform IMACDBHDNAK;

	public float HOALBBJLNIG = 100f;

	public bool BFDHFOEJBOO;

	public bool EMKNNCMGALJ;

	[SerializeField]
	private float particleRate = 3f;

	[SerializeField]
	private float slideThreshold = 10f;

	private float JEDHFIDHCKG;

	private float HONJFFHOPCH;

	private float KLFLKFGKKEO;

	private Rigidbody HCFEHGIEFIO;

	private bool CBDLMDOJOHD;

	private RaycastHit MGECAKNCNBD;

	private Vector3 ADAIOGEHIKM;

	private float DHOCBMKEMBL;

	private float DBGNJAFGEPN;

	private float CLPKGLEMCKL;

	private float IPNBKAJFPCJ;

	private float GNEBHHGADEH;

	private float BJKKKBNPFDG;

	private float ADPHCPKOEAL;

	private float HCJNPPJEPBB;

	private float BHCEMGKEKLE;

	private float LGKCAFPHEGK;

	private float HDLEKJNKCLB;

	private Vector3 NEPEOFFCLEA;

	private int JGFDGEDHDJE;

	public float Rpm { get; private set; }

	public float MaxRpm { get; private set; }

	public float SkidFactor { get; private set; }

	public bool onGround { get; private set; }

	public Transform Hub { get; set; }

	public WheelCollider wheelCollider { get; private set; }

	public CarController car { get; private set; }

	public float suspensionSpringPos { get; private set; }

	[SpecialName]
	private void DEOACDINOOM(float IDEBKDPMPGM)
	{
		_003CGGFGHDMJMMG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void PEPOHKNBDPP(CarController IDEBKDPMPGM)
	{
		_003CJEAMFGBAGKC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void NIIGBFHFEHP(float IDEBKDPMPGM)
	{
		_003CEHNDDPIBCIE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void HFJBCNMHPAE()
	{
		PEPOHKNBDPP(base.transform.parent.GetComponent<CarController>());
		if (IMACDBHDNAK != null)
		{
			NEPEOFFCLEA = IMACDBHDNAK.localPosition;
			base.transform.position = IMACDBHDNAK.position;
		}
		MaxRpm = car.MaxSpeed / (1156f * wheelCollider.radius * 1073f) * 1503f;
		HCFEHGIEFIO = wheelCollider.attachedRigidbody;
	}

	private void PFAAHEPCNCP()
	{
		OPCADCHEJBI(base.transform.parent.GetComponent<CarController>());
		if (IMACDBHDNAK != null)
		{
			NEPEOFFCLEA = IMACDBHDNAK.localPosition;
			base.transform.position = IMACDBHDNAK.position;
		}
		DEOACDINOOM(JBLFJBFCCAI().MaxSpeed / (1385f * wheelCollider.radius * 1359f) * 40f);
		HCFEHGIEFIO = wheelCollider.attachedRigidbody;
	}

	[SpecialName]
	public float EEFDHBNPFFL()
	{
		return _003CGGFGHDMJMMG_003Ek__BackingField;
	}

	[SpecialName]
	public float IFNMKDINAGP()
	{
		return _003CEHNDDPIBCIE_003Ek__BackingField;
	}

	[SpecialName]
	public float AACILBLADOB()
	{
		return _003CIINNFKDIPAL_003Ek__BackingField;
	}

	[SpecialName]
	public float JAIICMHPGHM()
	{
		return _003CEHNDDPIBCIE_003Ek__BackingField;
	}

	[SpecialName]
	private void BKAHGAFHLOB(float IDEBKDPMPGM)
	{
		_003CGGFGHDMJMMG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float EAIICAFHKBA()
	{
		return _003CGGFGHDMJMMG_003Ek__BackingField;
	}

	[SpecialName]
	private void JHGFINDIAAL(float IDEBKDPMPGM)
	{
		_003CIINNFKDIPAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float EGELONHBFPI()
	{
		return _003CGGFGHDMJMMG_003Ek__BackingField;
	}

	private void FixedUpdate()
	{
		ADAIOGEHIKM = base.transform.InverseTransformDirection(HCFEHGIEFIO.velocity);
		CLPKGLEMCKL = wheelCollider.motorTorque / car.MaxTorque;
		IPNBKAJFPCJ = 0f;
		if (EMKNNCMGALJ)
		{
			IPNBKAJFPCJ = (CLPKGLEMCKL - (1f - car.BurnoutTendency)) / (1f - car.BurnoutTendency);
		}
		LGKCAFPHEGK = car.MaxSpeed * car.BurnoutTendency / ((float)Math.PI * wheelCollider.radius * 2f) * 60f;
		Rpm = ((!(LGKCAFPHEGK > wheelCollider.rpm)) ? wheelCollider.rpm : Mathf.Lerp(wheelCollider.rpm, LGKCAFPHEGK, IPNBKAJFPCJ));
		JEDHFIDHCKG += Rpm * 6f * Time.deltaTime;
		if (JGFDGEDHDJE % 3 == 0)
		{
			WheelHit hit;
			if (wheelCollider.GetGroundHit(out hit))
			{
				onGround = true;
				suspensionSpringPos = hit.point.y - base.transform.position.y + wheelCollider.radius;
			}
			else
			{
				suspensionSpringPos = 0f - wheelCollider.suspensionDistance;
				onGround = false;
				KLFLKFGKKEO = 0f;
				SkidFactor = 0f;
			}
			if (IMACDBHDNAK != null)
			{
				IMACDBHDNAK.localPosition = NEPEOFFCLEA + Vector3.up * suspensionSpringPos;
				IMACDBHDNAK.localRotation = Quaternion.AngleAxis(wheelCollider.steerAngle, Vector3.up) * Quaternion.Euler(JEDHFIDHCKG, 0f, 0f);
			}
		}
		JGFDGEDHDJE++;
	}

	[SpecialName]
	public bool DCKJAGDIMJE()
	{
		return _003CMLPJOKMGCNH_003Ek__BackingField;
	}

	[SpecialName]
	public bool EKDOKECBJHA()
	{
		return _003CMLPJOKMGCNH_003Ek__BackingField;
	}

	[SpecialName]
	private void FCNKLKEGHEC(bool IDEBKDPMPGM)
	{
		_003CMLPJOKMGCNH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void LNDOMGELMJB(Transform IDEBKDPMPGM)
	{
		_003CGHOGJJLNNCE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LPKEGOIAEJC()
	{
		PEPOHKNBDPP(base.transform.parent.GetComponent<CarController>());
		if (IMACDBHDNAK != null)
		{
			NEPEOFFCLEA = IMACDBHDNAK.localPosition;
			base.transform.position = IMACDBHDNAK.position;
		}
		MaxRpm = JBLFJBFCCAI().MaxSpeed / (1480f * wheelCollider.radius * 1246f) * 1051f;
		HCFEHGIEFIO = wheelCollider.attachedRigidbody;
	}

	[SpecialName]
	public float MCBDMJEMKFP()
	{
		return _003CGGFGHDMJMMG_003Ek__BackingField;
	}

	[SpecialName]
	private void ENEMBEFGIJF(float IDEBKDPMPGM)
	{
		_003CEHNDDPIBCIE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void CFGDCEOLKJG()
	{
		wheelCollider = GetComponent<Collider>() as WheelCollider;
	}

	[SpecialName]
	public float JHJNGAOHCJH()
	{
		return _003CEHNDDPIBCIE_003Ek__BackingField;
	}

	private void Start()
	{
		car = base.transform.parent.GetComponent<CarController>();
		if (IMACDBHDNAK != null)
		{
			NEPEOFFCLEA = IMACDBHDNAK.localPosition;
			base.transform.position = IMACDBHDNAK.position;
		}
		MaxRpm = car.MaxSpeed / ((float)Math.PI * wheelCollider.radius * 2f) * 60f;
		HCFEHGIEFIO = wheelCollider.attachedRigidbody;
	}

	[SpecialName]
	public Transform NGDIIOMJHIC()
	{
		return _003CGHOGJJLNNCE_003Ek__BackingField;
	}

	[SpecialName]
	public float NFPECPMNIDJ()
	{
		return _003CGGFGHDMJMMG_003Ek__BackingField;
	}

	[SpecialName]
	private void LCOLLGPMGHJ(float IDEBKDPMPGM)
	{
		_003CEHNDDPIBCIE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public WheelCollider ONPNLGLHPMA()
	{
		return _003CKDPHLPFANFI_003Ek__BackingField;
	}

	[SpecialName]
	private void JGNOKDBOFBD(bool IDEBKDPMPGM)
	{
		_003CMLPJOKMGCNH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float CEKNPBOKFJP()
	{
		return _003CIINNFKDIPAL_003Ek__BackingField;
	}

	[SpecialName]
	public CarController JBLFJBFCCAI()
	{
		return _003CJEAMFGBAGKC_003Ek__BackingField;
	}

	[SpecialName]
	private void GKDOHDBMICO(float IDEBKDPMPGM)
	{
		_003CGGFGHDMJMMG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void DCMHEAPCJIP(float IDEBKDPMPGM)
	{
		_003CEHNDDPIBCIE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void OPCADCHEJBI(CarController IDEBKDPMPGM)
	{
		_003CJEAMFGBAGKC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float ODPPNJHILCL()
	{
		return _003CEHNDDPIBCIE_003Ek__BackingField;
	}

	private void BFLIPLAIDMO()
	{
		car = base.transform.parent.GetComponent<CarController>();
		if (IMACDBHDNAK != null)
		{
			NEPEOFFCLEA = IMACDBHDNAK.localPosition;
			base.transform.position = IMACDBHDNAK.position;
		}
		GKDOHDBMICO(car.MaxSpeed / (1896f * ONPNLGLHPMA().radius * 1941f) * 196f);
		HCFEHGIEFIO = ONPNLGLHPMA().attachedRigidbody;
	}

	[SpecialName]
	public void IHKHEEBJGIL(Transform IDEBKDPMPGM)
	{
		_003CGHOGJJLNNCE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void Awake()
	{
		wheelCollider = GetComponent<Collider>() as WheelCollider;
	}

	[SpecialName]
	private void JFANJIKCEJA(float IDEBKDPMPGM)
	{
		_003CILDMIHGOOIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void AIPDPFFLLFE(float IDEBKDPMPGM)
	{
		_003CIINNFKDIPAL_003Ek__BackingField = IDEBKDPMPGM;
	}
}
