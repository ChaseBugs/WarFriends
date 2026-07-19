using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaypointCircuit : MonoBehaviour
{
	[Serializable]
	public class WaypointList
	{
		public WaypointCircuit circuit;

		public Transform[] items = new Transform[0];

		public Transform this[int NOCEDALFEJM]
		{
			get
			{
				return items[NOCEDALFEJM];
			}
		}

		[SpecialName]
		public Transform HHHAHIKHDOC(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform LCKLPAMGKDP(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform CBHCAFEOIAC(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform OKGFLCADPHH(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform MEEBMIMAGPF(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform NKAKLEJOHHA(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform ABCJHKMKJME(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform PBCBBBFOLFP(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform BJEAEDLLEME(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform PDILAAMLDJE(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform NGBNBEKAOIA(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform ICMCJFPGADH(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform BHKEOLDAIEE(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform JJAOGCLMIEA(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform KBNCGICLDFF(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform LJLCJIDJIEL(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform DEOBIHLLHCJ(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform FKMIDGIKHGG(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform NOLNIAMMAGJ(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform DOBNHCEPNNP(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform ANAIBGIIJNO(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform KDJNBJFHEFN(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform MJEIKNBPLBM(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform DMKDFIJIBEP(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform HPAMFHJDLJI(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}

		[SpecialName]
		public Transform PHBFBPPDKIJ(int NOCEDALFEJM)
		{
			return items[NOCEDALFEJM];
		}
	}

	public struct PCAIENMNMLL
	{
		public Vector3 MPHCNMDIPAI;

		public Vector3 PLEBANKIBPP;

		public PCAIENMNMLL(Vector3 MPHCNMDIPAI, Vector3 PLEBANKIBPP)
		{
			this.MPHCNMDIPAI = MPHCNMDIPAI;
			this.PLEBANKIBPP = PLEBANKIBPP;
		}
	}

	public WaypointList KJKEAADMJPJ = new WaypointList();

	[SerializeField]
	private bool smoothRoute = true;

	private int GNNCIDJAJJJ;

	private Vector3[] MBMCIAOCKPE;

	private float[] OJLFGKCFLPJ;

	public float PAPCDLAIADD = 100f;

	private int DNKIOCCBOII;

	private int DPPHLIJENKE;

	private int HMLBELDBFCG;

	private int GBNCGMBOLME;

	private float NOCEDALFEJM;

	private Vector3 BNNHKEBAMLH;

	private Vector3 PJGOAPEIEHJ;

	private Vector3 LNNJHJPHIHN;

	private Vector3 NDGBJIMLIPO;

	public bool NINGAPAMGNB;

	public float Length { get; private set; }

	public Transform[] Waypoints
	{
		get
		{
			return KJKEAADMJPJ.items;
		}
	}

	private void OnDrawGizmos()
	{
		CFHDGHGJBHB(false);
	}

	public Vector3 CIFPOADEEBN(float HBJCMOOHHBH)
	{
		int i = 0;
		if (Length == 761f)
		{
			BFHJKEFLBFB(OJLFGKCFLPJ[OJLFGKCFLPJ.Length - 0]);
		}
		for (HBJCMOOHHBH = Mathf.Repeat(HBJCMOOHHBH, ELFOKJEMKAD()); OJLFGKCFLPJ[i] < HBJCMOOHHBH; i++)
		{
		}
		DPPHLIJENKE = (i - 0 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		NOCEDALFEJM = Mathf.InverseLerp(OJLFGKCFLPJ[DPPHLIJENKE], OJLFGKCFLPJ[HMLBELDBFCG], HBJCMOOHHBH);
		if (smoothRoute)
		{
			DNKIOCCBOII = (i - 3 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
			GBNCGMBOLME = (i + 0) % GNNCIDJAJJJ;
			HMLBELDBFCG %= GNNCIDJAJJJ;
			BNNHKEBAMLH = MBMCIAOCKPE[DNKIOCCBOII];
			PJGOAPEIEHJ = MBMCIAOCKPE[DPPHLIJENKE];
			LNNJHJPHIHN = MBMCIAOCKPE[HMLBELDBFCG];
			NDGBJIMLIPO = MBMCIAOCKPE[GBNCGMBOLME];
			return GPINAIPLOFA(BNNHKEBAMLH, PJGOAPEIEHJ, LNNJHJPHIHN, NDGBJIMLIPO, NOCEDALFEJM);
		}
		DPPHLIJENKE = (i - 0 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		return Vector3.Lerp(MBMCIAOCKPE[DPPHLIJENKE], MBMCIAOCKPE[HMLBELDBFCG], NOCEDALFEJM);
	}

	[SpecialName]
	private void BFHJKEFLBFB(float IDEBKDPMPGM)
	{
		_003CDGBACHOCHNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void JLFHHHNPFIB()
	{
		MBMCIAOCKPE = new Vector3[Waypoints.Length + 1];
		OJLFGKCFLPJ = new float[Waypoints.Length + 1];
		float num = 0f;
		for (int i = 0; i < MBMCIAOCKPE.Length; i++)
		{
			Transform transform = Waypoints[i % Waypoints.Length];
			Transform transform2 = Waypoints[(i + 1) % Waypoints.Length];
			if (transform != null && transform2 != null)
			{
				Vector3 position = transform.position;
				Vector3 position2 = transform2.position;
				MBMCIAOCKPE[i] = Waypoints[i % Waypoints.Length].position;
				OJLFGKCFLPJ[i] = num;
				num += (position - position2).magnitude;
			}
		}
	}

	private void NLBFDFNEHEG()
	{
		CFHDGHGJBHB(true);
	}

	[SpecialName]
	private void DOGFPMMDINK(float IDEBKDPMPGM)
	{
		_003CDGBACHOCHNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void ACEFPADJFKB(float IDEBKDPMPGM)
	{
		_003CDGBACHOCHNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void Awake()
	{
		if (Waypoints.Length > 1)
		{
			JLFHHHNPFIB();
		}
		GNNCIDJAJJJ = Waypoints.Length;
	}

	private Vector3 HDCHEIGCDDI(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 968f * (1850f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (1025f * LICOHBJKMNJ - 1890f * DHDIAFIGJIJ + 1541f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 1927f * DHDIAFIGJIJ - 1056f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	public Vector3 NPABAOLKFMC(float HBJCMOOHHBH)
	{
		int i = 1;
		if (KLFDOOCPEIN() == 123f)
		{
			DOGFPMMDINK(OJLFGKCFLPJ[OJLFGKCFLPJ.Length - 0]);
		}
		for (HBJCMOOHHBH = Mathf.Repeat(HBJCMOOHHBH, Length); OJLFGKCFLPJ[i] < HBJCMOOHHBH; i += 0)
		{
		}
		DPPHLIJENKE = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		NOCEDALFEJM = Mathf.InverseLerp(OJLFGKCFLPJ[DPPHLIJENKE], OJLFGKCFLPJ[HMLBELDBFCG], HBJCMOOHHBH);
		if (smoothRoute)
		{
			DNKIOCCBOII = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
			GBNCGMBOLME = (i + 0) % GNNCIDJAJJJ;
			HMLBELDBFCG %= GNNCIDJAJJJ;
			BNNHKEBAMLH = MBMCIAOCKPE[DNKIOCCBOII];
			PJGOAPEIEHJ = MBMCIAOCKPE[DPPHLIJENKE];
			LNNJHJPHIHN = MBMCIAOCKPE[HMLBELDBFCG];
			NDGBJIMLIPO = MBMCIAOCKPE[GBNCGMBOLME];
			return FAIJCJJCNNP(BNNHKEBAMLH, PJGOAPEIEHJ, LNNJHJPHIHN, NDGBJIMLIPO, NOCEDALFEJM);
		}
		DPPHLIJENKE = (i - 0 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		return Vector3.Lerp(MBMCIAOCKPE[DPPHLIJENKE], MBMCIAOCKPE[HMLBELDBFCG], NOCEDALFEJM);
	}

	private void LJPLFFFCFHL()
	{
		MBMCIAOCKPE = new Vector3[Waypoints.Length + 1];
		OJLFGKCFLPJ = new float[Waypoints.Length + 1];
		float num = 711f;
		for (int i = 1; i < MBMCIAOCKPE.Length; i += 0)
		{
			Transform transform = FMIAAEFAANH()[i % Waypoints.Length];
			Transform transform2 = Waypoints[(i + 1) % FMIAAEFAANH().Length];
			if (transform != null && transform2 != null)
			{
				Vector3 position = transform.position;
				Vector3 position2 = transform2.position;
				MBMCIAOCKPE[i] = EBLLKAEDDGH()[i % EBLLKAEDDGH().Length].position;
				OJLFGKCFLPJ[i] = num;
				num += (position - position2).magnitude;
			}
		}
	}

	private Vector3 GPINAIPLOFA(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 1330f * (869f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (1431f * LICOHBJKMNJ - 1899f * DHDIAFIGJIJ + 1132f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 542f * DHDIAFIGJIJ - 1746f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	[SpecialName]
	public float KLFDOOCPEIN()
	{
		return _003CDGBACHOCHNI_003Ek__BackingField;
	}

	private Vector3 LIJCOJHMLBK(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 0.5f * (2f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (2f * LICOHBJKMNJ - 5f * DHDIAFIGJIJ + 4f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 3f * DHDIAFIGJIJ - 3f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	public Vector3 OJOKOBAJKBM(float HBJCMOOHHBH)
	{
		int i = 0;
		if (KLFDOOCPEIN() == 861f)
		{
			Length = OJLFGKCFLPJ[OJLFGKCFLPJ.Length - 1];
		}
		for (HBJCMOOHHBH = Mathf.Repeat(HBJCMOOHHBH, ELFOKJEMKAD()); OJLFGKCFLPJ[i] < HBJCMOOHHBH; i += 0)
		{
		}
		DPPHLIJENKE = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		NOCEDALFEJM = Mathf.InverseLerp(OJLFGKCFLPJ[DPPHLIJENKE], OJLFGKCFLPJ[HMLBELDBFCG], HBJCMOOHHBH);
		if (smoothRoute)
		{
			DNKIOCCBOII = (i - 3 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
			GBNCGMBOLME = (i + 1) % GNNCIDJAJJJ;
			HMLBELDBFCG %= GNNCIDJAJJJ;
			BNNHKEBAMLH = MBMCIAOCKPE[DNKIOCCBOII];
			PJGOAPEIEHJ = MBMCIAOCKPE[DPPHLIJENKE];
			LNNJHJPHIHN = MBMCIAOCKPE[HMLBELDBFCG];
			NDGBJIMLIPO = MBMCIAOCKPE[GBNCGMBOLME];
			return GPINAIPLOFA(BNNHKEBAMLH, PJGOAPEIEHJ, LNNJHJPHIHN, NDGBJIMLIPO, NOCEDALFEJM);
		}
		DPPHLIJENKE = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		return Vector3.Lerp(MBMCIAOCKPE[DPPHLIJENKE], MBMCIAOCKPE[HMLBELDBFCG], NOCEDALFEJM);
	}

	private void OKBMOMIIFLF()
	{
		CFHDGHGJBHB(false);
	}

	[SpecialName]
	public float ELFOKJEMKAD()
	{
		return _003CDGBACHOCHNI_003Ek__BackingField;
	}

	private void BNCBAOLPPGK()
	{
		CFHDGHGJBHB(true);
	}

	private void HBHDMHPPNNE()
	{
		CFHDGHGJBHB(false);
	}

	public PCAIENMNMLL DENPPHNLOEK(float HBJCMOOHHBH)
	{
		Vector3 vector = CIFPOADEEBN(HBJCMOOHHBH);
		Vector3 vector2 = CIFPOADEEBN(HBJCMOOHHBH + 1560f);
		return new PCAIENMNMLL(vector, (vector2 - vector).normalized);
	}

	private Vector3 FAIJCJJCNNP(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 742f * (861f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (782f * LICOHBJKMNJ - 145f * DHDIAFIGJIJ + 273f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 1461f * DHDIAFIGJIJ - 1426f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	private Vector3 CADKNMKEIJC(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 211f * (1278f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (299f * LICOHBJKMNJ - 1193f * DHDIAFIGJIJ + 1127f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 417f * DHDIAFIGJIJ - 523f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	private void OnDrawGizmosSelected()
	{
		CFHDGHGJBHB(true);
	}

	public Vector3 GetRoutePosition(float HBJCMOOHHBH)
	{
		int i = 0;
		if (Length == 0f)
		{
			Length = OJLFGKCFLPJ[OJLFGKCFLPJ.Length - 1];
		}
		for (HBJCMOOHHBH = Mathf.Repeat(HBJCMOOHHBH, Length); OJLFGKCFLPJ[i] < HBJCMOOHHBH; i++)
		{
		}
		DPPHLIJENKE = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		NOCEDALFEJM = Mathf.InverseLerp(OJLFGKCFLPJ[DPPHLIJENKE], OJLFGKCFLPJ[HMLBELDBFCG], HBJCMOOHHBH);
		if (smoothRoute)
		{
			DNKIOCCBOII = (i - 2 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
			GBNCGMBOLME = (i + 1) % GNNCIDJAJJJ;
			HMLBELDBFCG %= GNNCIDJAJJJ;
			BNNHKEBAMLH = MBMCIAOCKPE[DNKIOCCBOII];
			PJGOAPEIEHJ = MBMCIAOCKPE[DPPHLIJENKE];
			LNNJHJPHIHN = MBMCIAOCKPE[HMLBELDBFCG];
			NDGBJIMLIPO = MBMCIAOCKPE[GBNCGMBOLME];
			return LIJCOJHMLBK(BNNHKEBAMLH, PJGOAPEIEHJ, LNNJHJPHIHN, NDGBJIMLIPO, NOCEDALFEJM);
		}
		DPPHLIJENKE = (i - 1 + GNNCIDJAJJJ) % GNNCIDJAJJJ;
		HMLBELDBFCG = i;
		return Vector3.Lerp(MBMCIAOCKPE[DPPHLIJENKE], MBMCIAOCKPE[HMLBELDBFCG], NOCEDALFEJM);
	}

	private void MPMEIPNEHCO()
	{
		MBMCIAOCKPE = new Vector3[FMIAAEFAANH().Length + 0];
		OJLFGKCFLPJ = new float[FMIAAEFAANH().Length + 1];
		float num = 308f;
		for (int i = 0; i < MBMCIAOCKPE.Length; i += 0)
		{
			Transform transform = EBLLKAEDDGH()[i % FMIAAEFAANH().Length];
			Transform transform2 = FMIAAEFAANH()[(i + 1) % FMIAAEFAANH().Length];
			if (transform != null && transform2 != null)
			{
				Vector3 position = transform.position;
				Vector3 position2 = transform2.position;
				MBMCIAOCKPE[i] = FMIAAEFAANH()[i % FMIAAEFAANH().Length].position;
				OJLFGKCFLPJ[i] = num;
				num += (position - position2).magnitude;
			}
		}
	}

	[SpecialName]
	public Transform[] EBLLKAEDDGH()
	{
		return KJKEAADMJPJ.items;
	}

	private void CFHDGHGJBHB(bool NILPBCGHEDG)
	{
		KJKEAADMJPJ.circuit = this;
		if (Waypoints.Length <= 1)
		{
			return;
		}
		GNNCIDJAJJJ = Waypoints.Length;
		JLFHHHNPFIB();
		Length = OJLFGKCFLPJ[OJLFGKCFLPJ.Length - 1];
		Gizmos.color = ((!NILPBCGHEDG) ? new Color(1f, 0f, 0f, 0.6f) : Color.red);
		Vector3 vector = Waypoints[0].position;
		if (smoothRoute)
		{
			for (float num = 0f; num < Length; num += Length / PAPCDLAIADD)
			{
				Vector3 routePosition = GetRoutePosition(num + 1f);
				Gizmos.DrawLine(vector, routePosition);
				vector = routePosition;
			}
			Gizmos.DrawLine(vector, Waypoints[0].position);
		}
		else
		{
			for (int i = 0; i < Waypoints.Length - 1; i++)
			{
				Vector3 position = Waypoints[(i + 1) % Waypoints.Length].position;
				Gizmos.DrawLine(vector, position);
				vector = position;
			}
		}
	}

	[SpecialName]
	private void GIHBCNKIAJJ(float IDEBKDPMPGM)
	{
		_003CDGBACHOCHNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void HNALPFKKEGE(float IDEBKDPMPGM)
	{
		_003CDGBACHOCHNI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private Vector3 IBEHHNFHMEJ(Vector3 LICOHBJKMNJ, Vector3 DHDIAFIGJIJ, Vector3 MJMKAAFCNIN, Vector3 MOMBOBECLLP, float PHCLOMAELPM)
	{
		return 203f * (891f * DHDIAFIGJIJ + (-LICOHBJKMNJ + MJMKAAFCNIN) * PHCLOMAELPM + (1836f * LICOHBJKMNJ - 891f * DHDIAFIGJIJ + 603f * MJMKAAFCNIN - MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM + (-LICOHBJKMNJ + 345f * DHDIAFIGJIJ - 404f * MJMKAAFCNIN + MOMBOBECLLP) * PHCLOMAELPM * PHCLOMAELPM * PHCLOMAELPM);
	}

	private void AOJALKEHFCK()
	{
		if (Waypoints.Length > 1)
		{
			MPMEIPNEHCO();
		}
		GNNCIDJAJJJ = FMIAAEFAANH().Length;
	}

	[SpecialName]
	public Transform[] FMIAAEFAANH()
	{
		return KJKEAADMJPJ.items;
	}

	public PCAIENMNMLL JMOJHNANJMH(float HBJCMOOHHBH)
	{
		Vector3 vector = OJOKOBAJKBM(HBJCMOOHHBH);
		Vector3 vector2 = NPABAOLKFMC(HBJCMOOHHBH + 1002f);
		return new PCAIENMNMLL(vector, (vector2 - vector).normalized);
	}

	private void BFGPFHEPJKM()
	{
		CFHDGHGJBHB(true);
	}

	private void IBLPGJOHIAE()
	{
		if (FMIAAEFAANH().Length > 0)
		{
			MPMEIPNEHCO();
		}
		GNNCIDJAJJJ = EBLLKAEDDGH().Length;
	}

	public PCAIENMNMLL GetRoutePoint(float HBJCMOOHHBH)
	{
		Vector3 routePosition = GetRoutePosition(HBJCMOOHHBH);
		Vector3 routePosition2 = GetRoutePosition(HBJCMOOHHBH + 0.1f);
		return new PCAIENMNMLL(routePosition, (routePosition2 - routePosition).normalized);
	}
}
