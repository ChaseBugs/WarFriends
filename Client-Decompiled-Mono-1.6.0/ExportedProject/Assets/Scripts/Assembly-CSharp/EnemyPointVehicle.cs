using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPointVehicle : EnemyPoint
{
	public float nextSpawnTime { get; set; }

	private void JHNNADOAFAN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1359f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public float LJJJBNFFBAG()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	[SpecialName]
	public float NDNCNKFAGIP()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	[SpecialName]
	public void CLBCAJAJPCM(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float PIAFDPMIPCK()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	private void PKJLOOOIJCC()
	{
	}

	[SpecialName]
	public float KJKPGBJDEOL()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	private void LLEKNBNBGKD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1514f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void OnEnable()
	{
	}

	private void FKPBJPJDCNA()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1167f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void COBALKANPIF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 422f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected virtual void MDOGOLCLDIB()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		base.enemyPointType = LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding;
	}

	protected virtual void IGOMLJOMFGA()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		KMPIAKMBIFL(LJGGJMAFEBN.Hiding);
	}

	private void KBNHICKADJD()
	{
	}

	public virtual bool FBHCEPBMGLK(Vector3 IBONOHAIAAC)
	{
		return FBGFMDOHAEG().PlanarDistance(IBONOHAIAAC) < 1503f;
	}

	private void KACCKHHMHOF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1467f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public float IIJHDLODKBB()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	[SpecialName]
	public void GIJILOBAKOC(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override bool IsEnemyPointReached(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 1f;
	}

	[SpecialName]
	public void POBMDOKFHCB(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool CKDKCNPFNOM(Vector3 IBONOHAIAAC)
	{
		return MGPNABOBKFP().PlanarDistance(IBONOHAIAAC) < 433f;
	}

	private void OHHNEOAHKDE()
	{
	}

	[SpecialName]
	public float FOEIHDBLMNB()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	[SpecialName]
	public float CIPHNKIFHPK()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	protected virtual void PAPFKMJEMML()
	{
		base.IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		NMLJBLGJCOA(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	[SpecialName]
	public void GBLGGJOLPME(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void APEKIGEONEC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1845f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected virtual void HIGCNIEAMBN()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		EMKAJOADOIH((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public float POEFDBKKBGC()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	[SpecialName]
	public void CKNAPMLDBBA(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void LCGGGCKNKDL(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void MECAOCJKMKN()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		NMLJBLGJCOA(LJGGJMAFEBN.Corner);
	}

	protected virtual void BLFKABLENCH()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	[SpecialName]
	public void MJAICDJIIDB(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LHPJCOPDOBM()
	{
	}

	[SpecialName]
	public float IOIFFLEJJCB()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	private void EKMGFCBEPID()
	{
	}

	private void AMHNBHGHOLG()
	{
	}

	[SpecialName]
	public float PMAKPMOIBBB()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	public virtual bool DELEGGCKMML(Vector3 IBONOHAIAAC)
	{
		return MGPNABOBKFP().PlanarDistance(IBONOHAIAAC) < 1118f;
	}

	protected virtual void OGFAHEALGFN()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		base.enemyPointType = LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner;
	}

	[SpecialName]
	public float MLAPEGEEOHM()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	public virtual bool EJOPBJAIAJO(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 1152f;
	}

	private void NDCOOFPHFNH()
	{
	}

	private void NDIILNGDOHD()
	{
	}

	private void LHAJGCDPHBK()
	{
	}

	private void PHFBPCOOOOB()
	{
	}

	protected virtual void MEBEHLLPMPK()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		EMKAJOADOIH(LJGGJMAFEBN.Car);
	}

	[SpecialName]
	public void HGPFKHIGHBL(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float OGCNCCBCHDK()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	protected virtual void JDPDEKENPLD()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		IOIIEDDBIKD(LJGGJMAFEBN.Car);
	}

	private void KBPCBKHDFCJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 411f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void DHAEBHKAIKC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 596f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public void FNGJMGMLBIH(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool INBKNJKJKIK(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 69f;
	}

	private void FJJCAHHMNNH()
	{
	}

	public override bool BAFHFALAINB(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 1355f;
	}

	[SpecialName]
	public void ABAAJOFJCGK(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FMIMKIOJLOI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 944f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	public virtual bool CHMFIONBPBC(Vector3 IBONOHAIAAC)
	{
		return KPOEEKLFALL().PlanarDistance(IBONOHAIAAC) < 1259f;
	}

	private void PALNOFNGIGH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 829f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void DKJCABGHIEM()
	{
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected virtual void PNCPCHDFBOB()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		CAEMAAMICOF((LJGGJMAFEBN)0);
	}

	[SpecialName]
	public float JHCKDOEGOAK()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	protected virtual void OBPMHHGJFEL()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		NGCBJNCNCCM(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	[SpecialName]
	public void FOFIGCICNFK(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float FOPACNHKAJE()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	protected virtual void LKCMKAELBFO()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		MMPAHCDHGCN(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	private void EDIGONDBCBH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 349f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public void OAMHHEHLBGD(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void JFDOGLFMHAE()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		MMPAHCDHGCN(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	private void DIBMABADKNG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1752f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	public virtual bool KMNEBPJIJOH(Vector3 IBONOHAIAAC)
	{
		return KOFFAHEAHEN().PlanarDistance(IBONOHAIAAC) < 1456f;
	}

	protected override void IODPOHKAKNN()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		HBBKGCJEDNO(LJGGJMAFEBN.Hiding);
	}

	public virtual bool MNNEOJIJMEG(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 141f;
	}

	private void DHBOLMOPGJJ()
	{
	}

	[SpecialName]
	public void LIDICBFCNPI(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void DPDJMDLIHOK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1424f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	public virtual bool DLHAGFNPNEO(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 751f;
	}

	[SpecialName]
	public float CKMNEDAFFAI()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	private void IGLJMAPNAON()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 753f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void KKGPIFIDKKE()
	{
	}

	private void PIENJHJKECF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1851f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected virtual void HMMKNCDDDLH()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		base.enemyPointType = LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner;
	}

	private void GKDFANEIGJI()
	{
	}

	protected virtual void HMADLOJIFGP()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	private void ILLMBEBCHLH()
	{
	}

	private void NKKPELCDHHC()
	{
	}

	public virtual bool CFPPKANOPAA(Vector3 IBONOHAIAAC)
	{
		return FBGFMDOHAEG().PlanarDistance(IBONOHAIAAC) < 564f;
	}

	[SpecialName]
	public void EJFGJLKBEAH(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FDGKIKCELDJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1959f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	public virtual bool DLMIGALBBAF(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 327f;
	}

	private void KMJHAKCFEPO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1610f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public void OBLICHINHEL(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		base.enemyPointType = LJGGJMAFEBN.Car;
	}

	public virtual bool GDKDGLBOFJD(Vector3 IBONOHAIAAC)
	{
		return KOFFAHEAHEN().PlanarDistance(IBONOHAIAAC) < 296f;
	}

	protected virtual void LBCMECNDOIO()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	private void DFFKEGMBDME()
	{
	}

	protected virtual void JGODEFOIACF()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	private void ADGENMCFHOM()
	{
	}

	[SpecialName]
	public void LPFNGDNDEIO(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void JNFEIKHKCKA()
	{
	}

	public virtual bool HIFMDHPCLDO(Vector3 IBONOHAIAAC)
	{
		return KPOEEKLFALL().PlanarDistance(IBONOHAIAAC) < 1008f;
	}

	[SpecialName]
	public void LIGPDFLMAHP(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JOPBJOFMPIO(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KEBMEMFHLNB()
	{
	}

	public virtual bool OHCPOGNAJDA(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 1948f;
	}

	[SpecialName]
	public void IEENHMPJENA(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void OMDILMPFKII()
	{
		KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	private void GNBLDFLJJJL()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 596f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	public virtual bool GHHHGKMLPKF(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 1447f;
	}

	private void PIEANDFDOIC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 809f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public float CCOIPECKEKA()
	{
		return _003CMFJBENPIPPE_003Ek__BackingField;
	}

	public virtual bool BLIAEBCIGGF(Vector3 IBONOHAIAAC)
	{
		return MOOGMFPMKEM().PlanarDistance(IBONOHAIAAC) < 255f;
	}

	public override bool ACICANPPGBC(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 1959f;
	}

	[SpecialName]
	public void EMONHNMFMBB(float IDEBKDPMPGM)
	{
		_003CMFJBENPIPPE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void EOBMLLEBMBC()
	{
	}

	public override bool EEGLPOLOCIP(Vector3 IBONOHAIAAC)
	{
		return KPOEEKLFALL().PlanarDistance(IBONOHAIAAC) < 1031f;
	}

	private void JKNOHDDDEAM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1505f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}
}
