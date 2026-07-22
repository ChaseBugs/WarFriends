using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPoint : Core_BaseScript, KMHCMCBGFFC
{
	[Flags]
	public enum LJGGJMAFEBN
	{
		Rusher = 1,
		Hiding = 2,
		Corner = 4,
		Car = 8,
		Helicopter = 0x10,
		Swat = 0x20,
		Tower = 0x40,
		Minigunner = 0x80,
		EngineerTurret = 0x100,
		EngineerRepair = 0x200,
		RusherSpare = 0x400,
		Gunslinger = 0x800,
		Mortar = 0x1000,
		Mech = 0x2000
	}

	[FormerlySerializedAs("HIKBHDMADCK")]
	public AIObject IDNNIHBIMNO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private LJGGJMAFEBN _003CBHKMLGGANJP_003Ek__BackingField;

	public EnemyController.AJGFGCHCAPA MJGBKHOFNHK;

	private bool HKNENLOJOPO = true;

	[FormerlySerializedAs("JEOEDDAOHLH")]
	public int DGKCJBFEBBJ;

	[SerializeField]
	private GHPGNELIDBM mFraction = GHPGNELIDBM.Enemies;

	public LJGGJMAFEBN enemyPointType
	{
		[CompilerGenerated]
		get
		{
			return _003CBHKMLGGANJP_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CBHKMLGGANJP_003Ek__BackingField = value;
		}
	}

	public virtual Vector3 position => (!(base.transform != null)) ? Vector3.zero : base.transform.position;

	public virtual bool isFree
	{
		get
		{
			return HKNENLOJOPO && IDNNIHBIMNO == null;
		}
		set
		{
			HKNENLOJOPO = value;
		}
	}

	public virtual GHPGNELIDBM fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			mFraction = value;
		}
	}

	public KMHCMCBGFFC owner => this;

	public virtual bool isActive => true;

	[SpecialName]
	public virtual bool GFLJBLFCHIE()
	{
		return false;
	}

	public virtual bool MOKMCBFCMFJ(Vector3 IBONOHAIAAC)
	{
		return KOFFAHEAHEN().PlanarDistance(IBONOHAIAAC) < 1112f;
	}

	public virtual void MCHHJNPCBLA()
	{
	}

	[SpecialName]
	public KMHCMCBGFFC JCIJNPMKCLJ()
	{
		return this;
	}

	[SpecialName]
	public virtual bool APGHOHFMPAB()
	{
		return true;
	}

	[SpecialName]
	public virtual GHPGNELIDBM EJDFGMKHGLN()
	{
		return mFraction;
	}

	public virtual void EGFMMANPHAK()
	{
	}

	[SpecialName]
	public virtual void IPIPGHPBMAH(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	protected virtual void MLBAFICPECE()
	{
		base.Awake();
	}

	[SpecialName]
	public KMHCMCBGFFC BNMLJJPGEFJ()
	{
		return this;
	}

	[SpecialName]
	public virtual bool DHBLIDKNANH()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual bool DKCLHDBPKCI()
	{
		return HKNENLOJOPO && IDNNIHBIMNO == null;
	}

	protected virtual void PJEMCLFLGBL()
	{
		base.Awake();
	}

	[SpecialName]
	public LJGGJMAFEBN MODBJDDNNFN()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool GKIHPFMCNPP()
	{
		return true;
	}

	protected virtual void HLBLKFLJEIG()
	{
		base.Awake();
	}

	[SpecialName]
	public virtual bool IJBCODPEPPG()
	{
		return false;
	}

	[SpecialName]
	public LJGGJMAFEBN HECCAFJBKGP()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual GHPGNELIDBM MMEJGAPHKPJ()
	{
		return mFraction;
	}

	[SpecialName]
	public virtual Vector3 MOOGMFPMKEM()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual bool FPOBCCLOJEL()
	{
		return false;
	}

	[SpecialName]
	public virtual GHPGNELIDBM IOPIBCMGGDG()
	{
		return mFraction;
	}

	[SpecialName]
	public virtual bool BNAALFJKAHB()
	{
		return HKNENLOJOPO && IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual GHPGNELIDBM IPFNDJEGKKJ()
	{
		return mFraction;
	}

	public virtual void ECHLJNJBHEC()
	{
	}

	public virtual bool HHLKLPKLICD(Vector3 IBONOHAIAAC)
	{
		return FBGFMDOHAEG().PlanarDistance(IBONOHAIAAC) < 1390f;
	}

	[SpecialName]
	public KMHCMCBGFFC CJGAFDAFKAF()
	{
		return this;
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
	}

	[SpecialName]
	public LJGGJMAFEBN LOIJJLGGNFN()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	public virtual bool LBFEMEJPJIC(Vector3 IBONOHAIAAC)
	{
		return FGKJILDKPHC().PlanarDistance(IBONOHAIAAC) < 1206f;
	}

	[SpecialName]
	public virtual bool OAPIGEDOKEO()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual Vector3 PFOBADFGAKF()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	public virtual void ECAPFJPCFPG()
	{
	}

	[SpecialName]
	public virtual GHPGNELIDBM CIOGGAKBBOJ()
	{
		return mFraction;
	}

	[SpecialName]
	public virtual Vector3 PBFDGDPLFKN()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public LJGGJMAFEBN LJPBPIDDMAE()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	[SpecialName]
	public virtual void LCFLCIKNPKI(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool JKJBGIGAKIN()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual GHPGNELIDBM KGMCJIICFKH()
	{
		return mFraction;
	}

	[SpecialName]
	public virtual bool EHGKKKBCKCL()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	protected void NMLJBLGJCOA(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool PKKBHKIOOFN()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual GHPGNELIDBM BLNNGHLFHPK()
	{
		return mFraction;
	}

	[SpecialName]
	public virtual void EKPNLGKNHEH(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool MMDCNGCOLEP()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual bool AEOOPOPOOPG()
	{
		return false;
	}

	[SpecialName]
	public virtual void ENMFHMIMFCL(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	public virtual void DMHGNJEHJJG()
	{
	}

	public virtual void DNBCBNMOGIN()
	{
	}

	[SpecialName]
	public virtual void OEOGEFBHCAP(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	public virtual void JKAKFCELAHM()
	{
	}

	[SpecialName]
	public KMHCMCBGFFC KPIIAPDNOJB()
	{
		return this;
	}

	[SpecialName]
	public virtual GHPGNELIDBM JJDDKGIGJNI()
	{
		return mFraction;
	}

	protected virtual void EALPHOPMAMP()
	{
		base.Awake();
	}

	[SpecialName]
	public virtual void DBGEHLMIKBI(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void HEAFLENCADI(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void OALHIGPAJNC(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public KMHCMCBGFFC FENJPPKNPPD()
	{
		return this;
	}

	[SpecialName]
	protected void NGCBJNCNCCM(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void KGJIHHEEHFL(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual GHPGNELIDBM MHLKAEOAGAM()
	{
		return mFraction;
	}

	[SpecialName]
	public KMHCMCBGFFC DFAIPNIHGNG()
	{
		return this;
	}

	[SpecialName]
	public virtual bool GHBNKBLONKA()
	{
		return true;
	}

	protected virtual void CADJAJCEFCF()
	{
		base.Awake();
	}

	[SpecialName]
	public KMHCMCBGFFC NLECFMFFOIB()
	{
		return this;
	}

	[SpecialName]
	public virtual void CILFJEPPEIL(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 MGPNABOBKFP()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual bool LJGBPHJKOGL()
	{
		return true;
	}

	public virtual void HNANEDOKHNK()
	{
	}

	public virtual bool IsEnemyPointReached(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 0.04f;
	}

	public virtual void GGACGAMGMEF()
	{
	}

	[SpecialName]
	public virtual bool ACJOIOALHOE()
	{
		return false;
	}

	[SpecialName]
	public virtual GHPGNELIDBM HIBCKDBMHIM()
	{
		return mFraction;
	}

	[SpecialName]
	protected void IOIIEDDBIKD(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool LOAMMJPGKHO(Vector3 IBONOHAIAAC)
	{
		return FBGFMDOHAEG().PlanarDistance(IBONOHAIAAC) < 744f;
	}

	[SpecialName]
	public virtual bool JAAIACGJDGB()
	{
		return false;
	}

	public virtual void LBOKMMJILDB()
	{
	}

	[SpecialName]
	protected void CAEMAAMICOF(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
	}

	[SpecialName]
	public LJGGJMAFEBN CNGHKNPJAPN()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	[SpecialName]
	public KMHCMCBGFFC PMHFOIILLLO()
	{
		return this;
	}

	[SpecialName]
	public virtual Vector3 FBGFMDOHAEG()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	public virtual void PJDJCKGAAIK()
	{
	}

	[SpecialName]
	protected void KMPIAKMBIFL(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void GJKIEMEPHAF(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual GHPGNELIDBM HIALJKICLKJ()
	{
		return mFraction;
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
	}

	[SpecialName]
	public LJGGJMAFEBN GIEIGPKGGNL()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	[SpecialName]
	public KMHCMCBGFFC MMMDIDEBCED()
	{
		return this;
	}

	[SpecialName]
	public virtual bool JCOPEJOIIIH()
	{
		return HKNENLOJOPO && IDNNIHBIMNO == null;
	}

	[SpecialName]
	protected void EMKAJOADOIH(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 KOFFAHEAHEN()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual void OLONIJDMLJB(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void FLBOEJADLBA(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	public virtual bool EPDKLCKBPEK(Vector3 IBONOHAIAAC)
	{
		return PBFDGDPLFKN().PlanarDistance(IBONOHAIAAC) < 1255f;
	}

	public virtual void CAPPHNHCADC()
	{
	}

	public virtual bool PMIDEPGMDGE(Vector3 IBONOHAIAAC)
	{
		return MGPNABOBKFP().PlanarDistance(IBONOHAIAAC) < 1089f;
	}

	[SpecialName]
	public virtual bool LLACCPGCFMI()
	{
		return false;
	}

	[SpecialName]
	public virtual Vector3 FGKJILDKPHC()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	public virtual bool LJIDCOOJPME(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 15f;
	}

	[SpecialName]
	public virtual bool NNDGHFOLJIB()
	{
		return HKNENLOJOPO && IDNNIHBIMNO == null;
	}

	[SpecialName]
	public virtual void MHFHNLCDCDM(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void BGPIHGIMLNJ(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public LJGGJMAFEBN GNEHPIPGJCO()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	public virtual void CFMDDIEGAEG()
	{
	}

	public virtual bool ACICANPPGBC(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 587f;
	}

	[SpecialName]
	public virtual bool OGJAALIPELA()
	{
		return true;
	}

	[SpecialName]
	public LJGGJMAFEBN NDFKANKCFFO()
	{
		return _003CBHKMLGGANJP_003Ek__BackingField;
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
	}

	public virtual bool EEGLPOLOCIP(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 911f;
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
	}

	public virtual void GeneratePosition()
	{
	}

	[SpecialName]
	public virtual void HIPIIFNGJON(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void IOPPBHCHNPD(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 KPOEEKLFALL()
	{
		return (!(base.transform != null)) ? Vector3.zero : base.transform.position;
	}

	[SpecialName]
	public virtual void KFDGHIFGAHC(GHPGNELIDBM IDEBKDPMPGM)
	{
		mFraction = IDEBKDPMPGM;
	}

	public virtual void IAPJBOCGBGL()
	{
	}

	public virtual bool ELDBGDCGEOJ(Vector3 IBONOHAIAAC)
	{
		return KOFFAHEAHEN().PlanarDistance(IBONOHAIAAC) < 915f;
	}

	[SpecialName]
	public KMHCMCBGFFC CNOEBEFGHJC()
	{
		return this;
	}

	public virtual void LFDGGKIFGHP()
	{
	}

	[SpecialName]
	public virtual bool NNDOIDEGFBO()
	{
		return true;
	}

	[SpecialName]
	public virtual void GEEHKDDBPCK(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
	}

	[SpecialName]
	public virtual void HKMIEGPKEHB(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	public virtual void IPBMGHPLHIF()
	{
	}

	[SpecialName]
	public virtual bool IBCECFGPMJO()
	{
		return !HKNENLOJOPO || IDNNIHBIMNO == null;
	}

	public virtual bool BAFHFALAINB(Vector3 IBONOHAIAAC)
	{
		return MOOGMFPMKEM().PlanarDistance(IBONOHAIAAC) < 1909f;
	}

	[SpecialName]
	public KMHCMCBGFFC JNKDAOFJDBA()
	{
		return this;
	}

	[SpecialName]
	protected void MMPAHCDHGCN(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void DOKFCAACOJH(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	[SpecialName]
	public virtual bool LJLKNEBOLEL()
	{
		return false;
	}

	[SpecialName]
	protected void HBBKGCJEDNO(LJGGJMAFEBN IDEBKDPMPGM)
	{
		_003CBHKMLGGANJP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void MGMAGPGKBCJ(bool IDEBKDPMPGM)
	{
		HKNENLOJOPO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool APKFGIGLNOL()
	{
		return true;
	}

	[SpecialName]
	public virtual GHPGNELIDBM BKIIMANDLPL()
	{
		return mFraction;
	}

	public virtual bool ICJBDMEDNCE(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 1130f;
	}
}
