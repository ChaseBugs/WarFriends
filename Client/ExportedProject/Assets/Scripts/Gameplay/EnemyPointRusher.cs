using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPointRusher : EnemyPoint
{
	private bool PMJDGAIKLIM;

	private PlayerPoint GALCNOMEEOM;

	[FormerlySerializedAs("EPNGMAHENPA")]
	public int DFHAAIFFLOE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private PlayerPoint _003CKABOOLCFGPP_003Ek__BackingField;

	private EnemyPointRusher MGEOFCJNCBM;

	public Vector3 direction => base.transform.rotation * Vector3.forward;

	public PlayerPoint playerPoint
	{
		[CompilerGenerated]
		get
		{
			return _003CKABOOLCFGPP_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CKABOOLCFGPP_003Ek__BackingField = value;
		}
	}

	public override Vector3 position => base.transform.position;

	public override bool isActive => playerPoint.shield.player != null;

	public bool EACEJFCAKEO(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return BNAALFJKAHB();
		}
		return PKKBHKIOOFN() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.JCOPEJOIIIH();
	}

	protected virtual void IOKMAFLIJEG()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		EMKAJOADOIH((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public void PAHPCLPGOCK(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OFPMLKNCBGK(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public Vector3 OEMEOHOMDOG()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	[SpecialName]
	public override bool NNDOIDEGFBO()
	{
		return PPKCJIDHOPO().shield.player != null;
	}

	[SpecialName]
	public void IPLKJJPJIBM(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected override void Start()
	{
		base.Start();
		float num = float.MaxValue;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 3f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.position, position);
				if (num3 < num && num3 <= 0.2f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	public bool CFKDLIEPBPO(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return DHBLIDKNANH();
		}
		return EHGKKKBCKCL() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.PKKBHKIOOFN();
	}

	protected virtual void HCNOHLLOGBO()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher);
	}

	[SpecialName]
	public virtual bool ELNPGDACGFG()
	{
		return AIJPMKFLBGD().IGEDGCNJCAP().player != null;
	}

	[SpecialName]
	public Vector3 JFHLALHBNDI()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public PlayerPoint PJHMKOJGKEP()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual Vector3 MHKCPCHADNP()
	{
		return base.transform.position;
	}

	private void HCOJFEKEJCN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 983f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PAHOIIKBMOF());
	}

	protected virtual void NOOIMHHHKMN()
	{
		base.Start();
		float num = 1227f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 1347f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.MOOGMFPMKEM(), MGPNABOBKFP());
				if (num3 < num && num3 <= 1040f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	[SpecialName]
	public PlayerPoint KEEKOJBIBEC()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	protected virtual void KACEBKMKACO()
	{
		base.Start();
		float num = 1310f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 1242f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.FBGFMDOHAEG(), KOFFAHEAHEN());
				if (num3 < num && num3 <= 1854f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	protected virtual void HCDNNGFBJOE()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		IOIIEDDBIKD((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public Vector3 JDGKAIPLAOI()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void MJMBODPGAGD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1902f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	[SpecialName]
	public void KEMMALMOAPD(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LPPMHFEEJFK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1346f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GABEPPKLPNB());
	}

	[SpecialName]
	public Vector3 ODMLBNJANEA()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool AGEOILBEFNN(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return MMDCNGCOLEP();
		}
		return !DKCLHDBPKCI() || (!(MGEOFCJNCBM == null) && MGEOFCJNCBM.JCOPEJOIIIH());
	}

	[SpecialName]
	public PlayerPoint DBOOMCAGLEM()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	private void MNCPGFAHIFH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 654f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	[SpecialName]
	public virtual Vector3 EHBINHGGDKK()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 HAMOLDFBLJJ()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 PLNGNIGPMBA()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual bool ANMJDEHBGPP()
	{
		return EIGJJAGIBHI().JPHAJDIIAAI().player != null;
	}

	[SpecialName]
	public PlayerPoint PPKCJIDHOPO()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	private void HKBINKOFGJL()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1418f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + NBMNELMCICC());
	}

	[SpecialName]
	public virtual Vector3 PIFJEHAGNFA()
	{
		return base.transform.position;
	}

	[SpecialName]
	public PlayerPoint EJJKBLJAFEA()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual Vector3 OBBPNKCOJNO()
	{
		return base.transform.position;
	}

	[SpecialName]
	public Vector3 GFJPNIICIBN()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void OONACPNEMFN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1161f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + ODMLBNJANEA());
	}

	public bool BDAFNOHIBCH(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return IBCECFGPMJO();
		}
		return MMDCNGCOLEP() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.isFree;
	}

	public bool AHPIKGNEEKJ(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return NNDGHFOLJIB();
		}
		return !DHBLIDKNANH() || (!(MGEOFCJNCBM == null) && MGEOFCJNCBM.IBCECFGPMJO());
	}

	protected virtual void INLCJEIEHKH()
	{
		base.Start();
		float num = 302f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 556f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.PFOBADFGAKF(), FBGFMDOHAEG());
				if (num3 < num && num3 <= 356f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	[SpecialName]
	public override Vector3 FBGFMDOHAEG()
	{
		return base.transform.position;
	}

	[SpecialName]
	public Vector3 GABEPPKLPNB()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool KKADBKMNKAC(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return DKCLHDBPKCI();
		}
		return !JKJBGIGAKIN() || MGEOFCJNCBM == null || MGEOFCJNCBM.DHBLIDKNANH();
	}

	public bool IEHOAEMHIEE(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return EHGKKKBCKCL();
		}
		return !BNAALFJKAHB() || (!(MGEOFCJNCBM == null) && MGEOFCJNCBM.MMDCNGCOLEP());
	}

	[SpecialName]
	public virtual bool AGLNGCDEFLO()
	{
		return AICFDBHBAJI().KJCHIHLJMMF().player != null;
	}

	private void DEEIFBABFMO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 291f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GFJPNIICIBN());
	}

	[SpecialName]
	public Vector3 KGIGDPGCNNI()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool FCLFJLFIODP(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return JCOPEJOIIIH();
		}
		return PKKBHKIOOFN() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.JKJBGIGAKIN();
	}

	private void NDDIGLCJGOE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1338f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GABEPPKLPNB());
	}

	[SpecialName]
	public virtual bool AKGOKECECEP()
	{
		return ANLPMBNFECF().CGKKGILAAPG().NPOMEBDPBGL() != null;
	}

	[SpecialName]
	public virtual Vector3 LCJNIGELGII()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual bool HAEGKMNMHAJ()
	{
		return AICFDBHBAJI().IGEDGCNJCAP().player != null;
	}

	public bool FPPFEJOBAAA(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return DKCLHDBPKCI();
		}
		return isFree && (MGEOFCJNCBM == null || MGEOFCJNCBM.NNDGHFOLJIB());
	}

	[SpecialName]
	public void CMMOLNHPODD(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void APPDMNHGFON()
	{
		base.Start();
		float num = 1783f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 7f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.MOOGMFPMKEM(), FBGFMDOHAEG());
				if (num3 < num && num3 <= 453f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	protected override void IBLPGJOHIAE()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH((LJGGJMAFEBN)0);
	}

	private void AAJINFILNOM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1711f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + IJELAGPHIAE());
	}

	[SpecialName]
	public virtual bool OMEMDBMJMHP()
	{
		return ANLPMBNFECF().IGEDGCNJCAP().player != null;
	}

	[SpecialName]
	public virtual Vector3 ODDAFNNIDKP()
	{
		return base.transform.position;
	}

	private void LFDEIPIDFMI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 829f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PAHOIIKBMOF());
	}

	private void EFNOPJDKBCO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1185f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + JDGKAIPLAOI());
	}

	public bool IOKBBNIMKLI(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return OAPIGEDOKEO();
		}
		return OAPIGEDOKEO() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.BNAALFJKAHB();
	}

	[SpecialName]
	public PlayerPoint AICFDBHBAJI()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	protected virtual void HFKIAIEGNGI()
	{
		base.Start();
		float num = 373f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 1709f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.KOFFAHEAHEN(), FBGFMDOHAEG());
				if (num3 < num && num3 <= 654f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	public bool CDOGGCPBDPA(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return DHBLIDKNANH();
		}
		return !OAPIGEDOKEO() || (!(MGEOFCJNCBM == null) && MGEOFCJNCBM.EHGKKKBCKCL());
	}

	protected virtual void FJIDLPDMAFM()
	{
		base.Start();
		float num = 188f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 1558f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.MGPNABOBKFP(), MOOGMFPMKEM());
				if (num3 < num && num3 <= 1319f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	[SpecialName]
	public void DKGIJAFAEPM(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerPoint BJIDLOCAOIJ()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		KMPIAKMBIFL((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public virtual Vector3 NIBJNCPFIOK()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual bool EKDJAIKAAGO()
	{
		return playerPoint.PKBPGCGNCAD().FCBGHBODHHP() != null;
	}

	[SpecialName]
	public PlayerPoint ANLPMBNFECF()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	public bool PDJFICHOFJF(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return OAPIGEDOKEO();
		}
		return OAPIGEDOKEO() && (MGEOFCJNCBM == null || MGEOFCJNCBM.NNDGHFOLJIB());
	}

	[SpecialName]
	public Vector3 PAHOIIKBMOF()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public void BNGGFALDICO(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void NPLBOMKAKCC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1960f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	[SpecialName]
	public virtual Vector3 AFBPEAGGDJL()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual bool OEAIPHLFPGP()
	{
		return AIJPMKFLBGD().shield.player != null;
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		base.enemyPointType = LJGGJMAFEBN.Rusher;
	}

	public bool ONFNJLFFPEJ(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return OAPIGEDOKEO();
		}
		return !DKCLHDBPKCI() || MGEOFCJNCBM == null || MGEOFCJNCBM.JCOPEJOIIIH();
	}

	[SpecialName]
	public virtual Vector3 COMGFALDPGD()
	{
		return base.transform.position;
	}

	[SpecialName]
	public void JJOFLOMLFPI(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool DMCBHCPNJNB()
	{
		return BJIDLOCAOIJ().LHHMNLJKOAO().OLOPPGKIJNF() != null;
	}

	protected virtual void PGPNEJKHNII()
	{
		base.Start();
		float num = 551f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 605f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.position, PBFDGDPLFKN());
				if (num3 < num && num3 <= 222f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	[SpecialName]
	public virtual bool EGFIKABLPJE()
	{
		return KEEKOJBIBEC().LHHMNLJKOAO().OLOPPGKIJNF() != null;
	}

	protected virtual void NOOLAIEENFB()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		KMPIAKMBIFL((LJGGJMAFEBN)0);
	}

	protected virtual void FJJAEHJDKNL()
	{
		base.MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		MMPAHCDHGCN((LJGGJMAFEBN)0);
	}

	protected override void EALPHOPMAMP()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher);
	}

	[SpecialName]
	public virtual Vector3 FIJMOCKAHFM()
	{
		return base.transform.position;
	}

	protected virtual void BPKLLAIPEGF()
	{
		base.Start();
		float num = 205f;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			PlayerPoint point = item.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 1268f)
			{
				continue;
			}
			foreach (EnemyPointRusher item2 in point.JGAIPICHEDP)
			{
				float num3 = Vector3.Distance(item2.PFOBADFGAKF(), MGPNABOBKFP());
				if (num3 < num && num3 <= 136f && item2 != this)
				{
					num = num3;
					MGEOFCJNCBM = item2;
				}
			}
		}
	}

	[SpecialName]
	public PlayerPoint DKFHIPIJJJG()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public Vector3 KKHKILDDEND()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void FKGCIOJAAMO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1210f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PAHOIIKBMOF());
	}

	[SpecialName]
	public PlayerPoint EIGJJAGIBHI()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerPoint DPHNNHCLOHC()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public void NDJMBFGHAHH(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected override void MLBAFICPECE()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Rusher);
	}

	[SpecialName]
	public PlayerPoint AIJPMKFLBGD()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	protected virtual void FJOCJOOFJBI()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		IOIIEDDBIKD((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public Vector3 NBMNELMCICC()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool isFreeWithNearNeighbour(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return isFree;
		}
		return isFree && (MGEOFCJNCBM == null || MGEOFCJNCBM.isFree);
	}

	[SpecialName]
	public Vector3 IJELAGPHIAE()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool KPEBANNLELH(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return EHGKKKBCKCL();
		}
		return PKKBHKIOOFN() && !(MGEOFCJNCBM == null) && MGEOFCJNCBM.EHGKKKBCKCL();
	}

	protected virtual void LLKBLBNEBPA()
	{
		base.IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		EMKAJOADOIH((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public Vector3 NLMCMBPKLFB()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public bool OONGCEOOLFF(EnemyPoint LNAJKKMIDCA)
	{
		if (LNAJKKMIDCA == MGEOFCJNCBM)
		{
			return IBCECFGPMJO();
		}
		return !BNAALFJKAHB() || MGEOFCJNCBM == null || MGEOFCJNCBM.BNAALFJKAHB();
	}

	[SpecialName]
	public virtual bool NEPFGFIHLBM()
	{
		return DKFHIPIJJJG().LMHDAIBCLDP().FCBGHBODHHP() != null;
	}

	[SpecialName]
	public void HMILLGDMBGD(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void MMBMHLABBKN()
	{
		base.IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher);
	}

	[SpecialName]
	public void NEIJFNBAIKE(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void KABIBEFIGII(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}
}
