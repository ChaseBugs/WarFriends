using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPointRusherSpare : EnemyPoint
{
	private bool PMJDGAIKLIM;

	private PlayerPoint GALCNOMEEOM;

	[FormerlySerializedAs("EPNGMAHENPA")]
	public int DFHAAIFFLOE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
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

	public override Vector3 position => (!(base.transform != null)) ? Vector3.zero : base.transform.position;

	public override bool isActive => playerPoint.shield.player != null;

	[SpecialName]
	public PlayerPoint NADGDBNPMMP()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	private void EMIPNAHFCLO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1977f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + OINMPPCDFGB());
	}

	protected virtual void BACJPKBJNIB()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-20);
		base.enemyPointType = ~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Minigunner);
	}

	private void ABBGKOIPHJK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1778f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + KKHKILDDEND());
	}

	[SpecialName]
	public PlayerPoint AIJPMKFLBGD()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public void DACJEAOKCFC(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void MEBEHLLPMPK()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-31);
		IOIIEDDBIKD(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter));
	}

	[SpecialName]
	public void BMEMAAGDOCM(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 LPMHPFCPHLF()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public Vector3 BOOGOGEFCBA()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void GIGEHNNOMGP()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1356f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + NBMNELMCICC());
	}

	[SpecialName]
	public Vector3 BGMPNGPAECE()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public PlayerPoint DNFNIAFBKOJ()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual Vector3 ECNFJJAGLHM()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 CMNANDHKFAD()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 JLNIJNODFKF()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public Vector3 PAHOIIKBMOF()
	{
		return base.transform.rotation * Vector3.forward;
	}

	protected virtual void LBMFKIDPCBL()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)111;
		MMPAHCDHGCN(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner);
	}

	private void LCAEAGMOPOM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1156f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + NBMNELMCICC());
	}

	[SpecialName]
	public virtual Vector3 KAINOJNBFDF()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public Vector3 IJELAGPHIAE()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual Vector3 CPMAMIEIHDF()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public void FIHCALBPALJ(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool FHOLPONILPC()
	{
		return COCKLAGAEOO().shield.OLOPPGKIJNF() != null;
	}

	[SpecialName]
	public void CMICCMOHJIK(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 GMIDPNGNKNK()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 LFKGIDJKKKO()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	protected virtual void ECCECGGCMHG()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)23;
		MMPAHCDHGCN(~(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower));
	}

	[SpecialName]
	public Vector3 NBMNELMCICC()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public Vector3 IGDNJJOBKJN()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual Vector3 PEJLKJDONAP()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	protected virtual void JDPDEKENPLD()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)38;
		base.enemyPointType = ~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	[SpecialName]
	public Vector3 JCCHIEHILJA()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual bool GIIGOBIFLFD()
	{
		return COCKLAGAEOO().shield.player != null;
	}

	[SpecialName]
	public Vector3 HDDLHPLHENK()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public override bool IJBCODPEPPG()
	{
		return AIJPMKFLBGD().LMHDAIBCLDP().NPOMEBDPBGL() != null;
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.RusherSpare;
		base.enemyPointType = LJGGJMAFEBN.RusherSpare;
	}

	[SpecialName]
	public void ABEIIEDKMNP(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FJMKBICPHLF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1161f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + JCCHIEHILJA());
	}

	[SpecialName]
	public virtual bool EBPIJHHHECG()
	{
		return playerPoint.IGEDGCNJCAP().player != null;
	}

	[SpecialName]
	public virtual Vector3 DICBPGFIHCC()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public void PAHPCLPGOCK(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	protected virtual void EEMLMJCHKLM()
	{
		KNLKFOHBCKI();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)76;
		NGCBJNCNCCM(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Swat));
	}

	[SpecialName]
	public virtual bool DABPCAKGJPD()
	{
		return COCKLAGAEOO().KJCHIHLJMMF().OLOPPGKIJNF() != null;
	}

	private void OFGNGGCIAAE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1682f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + HDDLHPLHENK());
	}

	[SpecialName]
	public virtual bool JEMGDOIJJKK()
	{
		return playerPoint.IGEDGCNJCAP().OLOPPGKIJNF() != null;
	}

	[SpecialName]
	public Vector3 OINMPPCDFGB()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void EBOALKHIJLN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1787f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + OINMPPCDFGB());
	}

	protected virtual void DLOLBFOOEBA()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-79);
		MMPAHCDHGCN(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Minigunner));
	}

	protected virtual void PBCDDNOCJOI()
	{
		KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Gunslinger;
		HBBKGCJEDNO(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Tower);
	}

	[SpecialName]
	public void BNBDKKDHIME(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 HEDAGHLFCHO()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public void NCFFBKPHNCG(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool GPMCFGFIIAA()
	{
		return NADGDBNPMMP().PKBPGCGNCAD().NPOMEBDPBGL() != null;
	}

	private void HHLLINDJOLB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 274f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + CPFNNGFMINP());
	}

	[SpecialName]
	public PlayerPoint COCKLAGAEOO()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	protected virtual void OHHLNKPIHBH()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-25);
		IOIIEDDBIKD(~(LJGGJMAFEBN.Car | LJGGJMAFEBN.Minigunner));
	}

	[SpecialName]
	public Vector3 OKGGKKBKDAC()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual Vector3 MPONEDMKKIE()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public void PHMNMCFMCKG(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GAMJHENJALI(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerPoint PJHMKOJGKEP()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool ABDMAJPOCEB()
	{
		return DNFNIAFBKOJ().CGKKGILAAPG().FCBGHBODHHP() != null;
	}

	[SpecialName]
	public void AMDFKKBCKAN(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void MAOLOCEHBAC(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public Vector3 KKHKILDDEND()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual Vector3 LADKFDOOLMD()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	protected virtual void HMOEHPBFECG()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)33;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Car | LJGGJMAFEBN.Minigunner);
	}

	[SpecialName]
	public void CBCLNHILJFC(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public override bool AEOOPOPOOPG()
	{
		return NADGDBNPMMP().CGKKGILAAPG().OLOPPGKIJNF() != null;
	}

	[SpecialName]
	public PlayerPoint LHFEPOMJHJC()
	{
		return _003CKABOOLCFGPP_003Ek__BackingField;
	}

	private void NFJDOELLMBC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1103f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + JCCHIEHILJA());
	}

	[SpecialName]
	public void DHAMOGGNGCM(PlayerPoint IDEBKDPMPGM)
	{
		_003CKABOOLCFGPP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public Vector3 CPFNNGFMINP()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public virtual bool KDKCAMMLADI()
	{
		return AIJPMKFLBGD().PNKKPNIMEPL().FCBGHBODHHP() != null;
	}

	private void EIHNEMHDMKN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 980f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + OKGGKKBKDAC());
	}
}
