using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraPlayerFollow : Core_BaseScript
{
	[Serializable]
	public class ThirdPersoncameraDefinition
	{
		public float distance = 3f;

		public float distanceScale = 1f;

		[FormerlySerializedAs("forwardScale")]
		public float forward;

		public float fwScale = 1f;

		public float height = 3f;

		public float scale = 1f;

		public float Distance
		{
			get
			{
				return distance * distanceScale;
			}
			set
			{
				distance = value;
			}
		}

		public float Height
		{
			get
			{
				return height * scale;
			}
			set
			{
				height = value;
			}
		}

		public float ForwardScale
		{
			get
			{
				return forward * scale * fwScale;
			}
			set
			{
				forward = value;
			}
		}

		[SpecialName]
		public void KALGDFDOBJD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float EIGNFCACPCG()
		{
			return height * scale;
		}

		[SpecialName]
		public float FJCAGEICMMB()
		{
			return height * scale;
		}

		[SpecialName]
		public void FPAALAOAFOO(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void CODINHBDOGP(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float KOHLHKJJJIB()
		{
			return height * scale;
		}

		[SpecialName]
		public float BKBDKHBFCDO()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float GCPFKDPIKPF()
		{
			return height * scale;
		}

		[SpecialName]
		public float FHFAGINDIOC()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float OPJCAOODFBO()
		{
			return height * scale;
		}

		[SpecialName]
		public void MOAGJPCFBIN(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float PHLAOGDGBGP()
		{
			return height * scale;
		}

		[SpecialName]
		public float AGBDMOOKEKD()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float ACFNBLOGHKL()
		{
			return height * scale;
		}

		[SpecialName]
		public void JBDCLHKNNHG(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float IHFAIFLLJCM()
		{
			return height * scale;
		}

		[SpecialName]
		public void PGNHMBHBOAD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void OFFKIPHLDHM(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float ANHFLJKIDDH()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void FJMDEPGFOOO(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public void MKJHILDMNKD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float CKBEFPGJIIP()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void AEAKHMJBGON(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void JFHEGGKNHEL(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void CEBELBFJNLO(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public void MLFGCFEGMPL(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public void IDOIKMMJLPD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float HJMHEDFNHBC()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void MDJMBKMEDKK(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float MEHLNBEJAFH()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float NBKOGKMLCNP()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void OOAGONMIAJJ(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float INCOBAHPCHP()
		{
			return height * scale;
		}

		[SpecialName]
		public void GBNLODGBPAD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void AMFJBIDJHIP(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float PMAGAIMEMAK()
		{
			return height * scale;
		}

		[SpecialName]
		public float MOGJOPPKCMM()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void ALFNDOGCLDD(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float CENKIANNGPK()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float FDEKJICHONA()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float NBHEJEJECBA()
		{
			return height * scale;
		}

		[SpecialName]
		public void GOPBEPGJMOK(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float BPFLGFBBBPN()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void GHMJFHAJOLG(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float MNAMHKDLDCP()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float BPHNNLBHBJM()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void PCNGJCCNAPO(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public void GHOFMGDEBMI(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float AEDANIAAOOB()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float KOGACAKEHOE()
		{
			return height * scale;
		}

		[SpecialName]
		public float EAEMIBINOJD()
		{
			return height * scale;
		}

		[SpecialName]
		public float CEBBCIGCOMC()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float CMNELGHHBCL()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void JCHBMGHPCGB(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void ENNEDDJAHCF(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float DIBFECIELFL()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float FNGIBEPPBHB()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float OGKEMANELML()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float MAEKDIMLIAC()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float HBKHLFHKCDO()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void AEOLIJOBNFJ(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float NFLIODDPPBF()
		{
			return height * scale;
		}

		[SpecialName]
		public float JCLOAKHDOAB()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void OABILIKKPHK(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public void AABDBNADKDO(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float FLKNGJNLEDH()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void FFOMNNIHCFD(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public void HGFGDODDHJD(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float APHMKKFEBAI()
		{
			return height * scale;
		}

		[SpecialName]
		public void EBLGCAHNMGN(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float PIAFNGMPPLE()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void DHBBMALMFFG(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float GFNOPMBKJDJ()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void IHKLKPBLADH(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public void FPCENMHGILM(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float OLBMEOMLOBN()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void LFECACDNCCC(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float GMPBPOPBMMJ()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void KCFEGBODKOE(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float KCMONNKNIHK()
		{
			return height * scale;
		}

		[SpecialName]
		public float FIHHANAGIKL()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void KKGEFDMGIJO(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float HMAOKIMOGDJ()
		{
			return height * scale;
		}

		[SpecialName]
		public void PHBAFKIIJJF(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public void AGJIEHIDDAN(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public void POAHGPFEKIA(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float FNANPLIPAFI()
		{
			return height * scale;
		}

		[SpecialName]
		public void LCHICONGJDM(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float GHJBOJEHFEN()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float FNPHJHDBMGB()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float CMCAJADMNPF()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float LBMCGAKGEPJ()
		{
			return height * scale;
		}

		[SpecialName]
		public void AFBNCJOKHCK(float IDEBKDPMPGM)
		{
			distance = IDEBKDPMPGM;
		}

		[SpecialName]
		public float PFDKNBCCGDB()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public void IGKHDEFNFGK(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public float NKKPFPCMMJL()
		{
			return height * scale;
		}

		[SpecialName]
		public float PHEEJOCHFGI()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public void JKOPIOOOOJD(float IDEBKDPMPGM)
		{
			height = IDEBKDPMPGM;
		}

		[SpecialName]
		public void PBGBNMGGGMH(float IDEBKDPMPGM)
		{
			forward = IDEBKDPMPGM;
		}

		[SpecialName]
		public float JMMCKGAGCNL()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float KBDJMOAMMDN()
		{
			return distance * distanceScale;
		}

		[SpecialName]
		public float LMDMODOABHK()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float NCCKEBLEDDJ()
		{
			return forward * scale * fwScale;
		}

		[SpecialName]
		public float PHFPOKCKGEI()
		{
			return distance * distanceScale;
		}
	}

	public float KPHNBLPPNJJ = 5f;

	public ThirdPersoncameraDefinition GIFJOLADLEB;

	public GyroController NPLCMDGJDEA;

	public float NLJANGLJNCB = 15f;

	private Quaternion DAFGEIDJBGM;

	public float OFJBOKHOFLD = 10f;

	private Vector3 FFFOJDHGJMF;

	public bool DJLMJMAJJAA = true;

	public PlayerController MKIPAEDAADL;

	protected void NIGOADNHHFC()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			FJNBPCOBFKN(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected virtual void EJNKMAMBOEF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JCLMLGGMKCL;
	}

	public void EEILLNBGHIM()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		OJGFGDELNMI(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void OBLOBMPIDPN()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		GetRotPos(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected virtual void JLOKAFKICIM()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LEJDOKOGFHJ;
	}

	protected void BHIABNNGKFO()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			MLOMBPAPGDM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += HFCFNBFEMNO;
	}

	public void FOILEDGBICE()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PJOFKCFBFOI(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected virtual void EALPHOPMAMP()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LEJDOKOGFHJ;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += PBCFEOFIOPO;
	}

	private void JBKJJKLIDOP()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void AJDGCPKKJKB()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		HKKOAONIMPK(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void PBCFEOFIOPO()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	private void DPNLGDBMPJI()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void MGCDFLAMAMN()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PLAIEKOFODM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void LEJDOKOGFHJ()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	private void NLEOKOIAACP()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected void LIHOPIGNFFM()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			LIHLBECDEGF(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void OJGFGDELNMI(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 112f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1760f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1342f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(866f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(399f, GIFJOLADLEB.APHMKKFEBAI(), 0f - GIFJOLADLEB.BKBDKHBFCDO());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.DIBFECIELFL();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Result");
		}
	}

	public void LBGOMOPKOIB(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1595f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1792f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 839f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(642f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(302f, GIFJOLADLEB.KOHLHKJJJIB(), 0f - GIFJOLADLEB.HBKHLFHKCDO());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.GMPBPOPBMMJ();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("offerMult");
		}
	}

	private void NNLCNEELCBK()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected void MGAIKDBOPKI()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			IANEDAONDIH(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void PLAIEKOFODM(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 234f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1571f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 881f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1780f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(756f, GIFJOLADLEB.OPJCAOODFBO(), 0f - GIFJOLADLEB.JCLOAKHDOAB());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.OLBMEOMLOBN();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("CARD BUDDY - SHOW IN MENU - Player: {0} actual reference count: {1}");
		}
	}

	protected void Update()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			GetRotPos(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	private void KICBAGJMDIC()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	public void FLNKFOLGNKM(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1215f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1264f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 476f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(459f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(1111f, GIFJOLADLEB.KOGACAKEHOE(), 0f - GIFJOLADLEB.BPFLGFBBBPN());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.ForwardScale;
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Rotate Camera");
		}
	}

	protected void INHEEMEAIDJ()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			OOPOMCJEBBK(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JBKJJKLIDOP;
	}

	protected void NCLHOHNKMOJ()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			PLFAAGBFGEB(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += HFCFNBFEMNO;
	}

	public void ADOFEHNMMOC(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1756f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1034f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 90f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1177f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(755f, GIFJOLADLEB.EAEMIBINOJD(), 0f - GIFJOLADLEB.CKBEFPGJIIP());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.ForwardScale;
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("experiment name is ");
		}
	}

	public void APBDNEFNHEF()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		LBGOMOPKOIB(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected virtual void OGFAHEALGFN()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LOCNFIKIHCF;
	}

	public void PJCCKALAOJH(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 961f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1280f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 31f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1212f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(392f, GIFJOLADLEB.INCOBAHPCHP(), 0f - GIFJOLADLEB.HBKHLFHKCDO());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.PFDKNBCCGDB();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("ShowRope");
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
	}

	private void HLHIPCIBMNP()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void PLFAAGBFGEB(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 197f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1123f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 388f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1849f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(1542f, GIFJOLADLEB.FJCAGEICMMB(), 0f - GIFJOLADLEB.AGBDMOOKEKD());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.FDEKJICHONA();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Walk");
		}
	}

	public void EMEMHHCNLCN(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1648f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1660f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 781f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1365f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(991f, GIFJOLADLEB.LBMCGAKGEPJ(), 0f - GIFJOLADLEB.CKBEFPGJIIP());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.MNAMHKDLDCP();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("ID_CONFIRM_ERROR");
		}
	}

	public void CHFGHFKCNHL()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		ADOFEHNMMOC(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected void JMPDHKPOHEA()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			LIHLBECDEGF(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void FJNBPCOBFKN(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 839f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1105f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1510f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1249f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(1284f, GIFJOLADLEB.GCPFKDPIKPF(), 0f - GIFJOLADLEB.Distance);
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.MNAMHKDLDCP();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Total_Matchmaking_Battles");
		}
	}

	public void DIHEMGGLGHJ()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PJCCKALAOJH(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected void OPMNIHDAHAA()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			MLOMBPAPGDM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void KPFJCEPLKGO()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		NEEONABJDNP(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void GIPGLGFALDM()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		NEEONABJDNP(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LEJDOKOGFHJ;
	}

	public void GHIHBDKMBMI()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		LBGOMOPKOIB(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void FDOMPNIBOAC()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BOGCLLNHLNO;
	}

	protected virtual void MLBAFICPECE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JBKJJKLIDOP;
	}

	public void NEEONABJDNP(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1906f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(854f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 847f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(320f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(774f, GIFJOLADLEB.NBHEJEJECBA(), 0f - GIFJOLADLEB.KBDJMOAMMDN());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.MEHLNBEJAFH();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("OnConnectionFailed: restarting minus dogtag");
		}
	}

	protected virtual void OMDILMPFKII()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JBKJJKLIDOP;
	}

	private void JCLMLGGMKCL()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected virtual void IIPMNCCFNIA()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
	}

	private void PBNHHLNFDAC()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void DNOECONBLEP(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1013f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(741f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1212f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1849f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(1415f, GIFJOLADLEB.NKKPFPCMMJL(), 0f - GIFJOLADLEB.GFNOPMBKJDJ());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.NCCKEBLEDDJ();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Error: Incorrect assignments ");
		}
	}

	public void LOAMMLMMJLD()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		ADOFEHNMMOC(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void PJOFKCFBFOI(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1863f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(243f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1420f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(552f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(203f, GIFJOLADLEB.GCPFKDPIKPF(), 0f - GIFJOLADLEB.MAEKDIMLIAC());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.FDEKJICHONA();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Game created on server+");
		}
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	public void GFLMPOFPKMA()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		IANEDAONDIH(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void HKKOAONIMPK(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 966f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1741f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1488f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1957f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(1028f, GIFJOLADLEB.KOHLHKJJJIB(), 0f - GIFJOLADLEB.BKBDKHBFCDO());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.FDEKJICHONA();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("{0}\n----------\n");
		}
	}

	public void MLOMBPAPGDM(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1902f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(106f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 339f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(165f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(724f, GIFJOLADLEB.KOHLHKJJJIB(), 0f - GIFJOLADLEB.CKBEFPGJIIP());
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.FDEKJICHONA();
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("0");
		}
	}

	private void BCOCBMPCJFO()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	private void ACLCPJHKHLL()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected void IAPBHPLNNNO()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			PLFAAGBFGEB(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LOCNFIKIHCF;
	}

	public void GetRotPos(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 aimToMiddleOfMap = MKIPAEDAADL.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 15f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(15f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < -15f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(-15f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = aimToMiddleOfMap;
			Vector3 vector = new Vector3(0f, GIFJOLADLEB.Height, 0f - GIFJOLADLEB.Distance);
			vector = DAFGEIDJBGM * vector;
			vector = MKIPAEDAADL.transform.position + vector;
			MPHCNMDIPAI = vector;
			Vector3 vector2 = Vector3.forward * GIFJOLADLEB.ForwardScale;
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			OOMCGGAFJNH = Quaternion.LookRotation(vector2 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("camera not set");
		}
	}

	public void MPDIIPBLPPO()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		DNOECONBLEP(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void BOGCLLNHLNO()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	private void GNBDMACLGPJ()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected void IIFBKHDMIAD()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			ADOFEHNMMOC(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	private void MOOHNDODPII()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void LGOPANPKPME(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1025f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(491f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1884f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1972f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(702f, GIFJOLADLEB.NFLIODDPPBF(), 0f - GIFJOLADLEB.JMMCKGAGCNL());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.HJMHEDFNHBC();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("601 TUTORIAL STARTED");
		}
	}

	protected void PKPIMPKNFJJ()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			FLNKFOLGNKM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	private void CFAHGKMBEDD()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void IBIANIFLBMF()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PJCCKALAOJH(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void HFCFNBFEMNO()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	protected void ECFIMCCNBBN()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			PJOFKCFBFOI(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected void OFGAKKAFOCD()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			PJOFKCFBFOI(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	protected void OGJGIMLMJBF()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			DNOECONBLEP(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	private void LOCNFIKIHCF()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void OOPOMCJEBBK(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1365f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1174f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1031f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1344f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(803f, GIFJOLADLEB.KOGACAKEHOE(), 0f - GIFJOLADLEB.CEBBCIGCOMC());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.FIHHANAGIKL();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Skill");
		}
	}

	protected void JMHMGOGIOMG()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			LGOPANPKPME(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void LIHLBECDEGF(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 554f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(962f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 692f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(550f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(112f, GIFJOLADLEB.ACFNBLOGHKL(), 0f - GIFJOLADLEB.Distance);
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.FIHHANAGIKL();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("Avg_fps");
		}
	}

	protected void CKFENMDKKPE()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			IANEDAONDIH(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void IANEDAONDIH(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.EJAEPLJMEGN();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 999f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1868f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 1588f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1533f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(624f, GIFJOLADLEB.PMAGAIMEMAK(), 0f - GIFJOLADLEB.CMCAJADMNPF());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.PFDKNBCCGDB();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("()F");
		}
	}

	private void ALDCHFCKJJD()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void PFKGJINHKPL(ref Vector3 MPHCNMDIPAI, ref Quaternion OOMCGGAFJNH)
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 vector = MKIPAEDAADL.GOEGBNBHGAJ();
			if (vector != Vector3.zero)
			{
				DAFGEIDJBGM = Quaternion.LookRotation(vector);
				float num = GeometryTools.AngleSigned(vector, MKIPAEDAADL.aimForward, Vector3.up);
				if (num > 1710f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(1470f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
				if (num < 874f)
				{
					DAFGEIDJBGM = Quaternion.LookRotation(Quaternion.AngleAxis(785f, -Vector3.up) * MKIPAEDAADL.aimForward);
				}
			}
			FFFOJDHGJMF = vector;
			Vector3 vector2 = new Vector3(922f, GIFJOLADLEB.NFLIODDPPBF(), 0f - GIFJOLADLEB.CENKIANNGPK());
			vector2 = DAFGEIDJBGM * vector2;
			vector2 = MKIPAEDAADL.transform.position + vector2;
			MPHCNMDIPAI = vector2;
			Vector3 vector3 = Vector3.forward * GIFJOLADLEB.FHFAGINDIOC();
			vector3 = DAFGEIDJBGM * vector3;
			vector3 = MKIPAEDAADL.transform.position + vector3;
			OOMCGGAFJNH = Quaternion.LookRotation(vector3 - MPHCNMDIPAI, MKIPAEDAADL.transform.up);
		}
		else
		{
			Debug.LogError("PlayerLeagueFinished - SHOWING LEAGUE RESULTS DIALOG!");
		}
	}

	protected void PHABEKGALCE()
	{
		if (PlayerController.OGMBJPKOPCB != null)
		{
			if (MKIPAEDAADL == null)
			{
				MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
			}
			DAFGEIDJBGM = Quaternion.identity;
			Vector3 MPHCNMDIPAI = default(Vector3);
			Quaternion OOMCGGAFJNH = default(Quaternion);
			PFKGJINHKPL(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
			base.transform.position = Vector3.Lerp(base.transform.position, MPHCNMDIPAI, Time.deltaTime * KPHNBLPPNJJ);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OOMCGGAFJNH, Time.deltaTime * OFJBOKHOFLD);
		}
	}

	public void JBNBCEHPPLK()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		NEEONABJDNP(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	private void LCCKGNJGNKE()
	{
		MKIPAEDAADL = PlayerController.OGMBJPKOPCB;
	}

	public void ForceSet()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		GetRotPos(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void PEJFNCOEHEL()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PLAIEKOFODM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void EHJMIANAJCO()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		PLFAAGBFGEB(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}

	public void FLLJODDEALI()
	{
		Vector3 MPHCNMDIPAI = default(Vector3);
		Quaternion OOMCGGAFJNH = default(Quaternion);
		MLOMBPAPGDM(ref MPHCNMDIPAI, ref OOMCGGAFJNH);
		base.transform.position = MPHCNMDIPAI;
		base.transform.rotation = OOMCGGAFJNH;
	}
}
