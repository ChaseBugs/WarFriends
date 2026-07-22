using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : AIObjectG<SoldierBehaviour>, PHOFJEDENDJ, IBFMOMDLFEP, AFIKFLMIBBA, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	public enum KMEPKJIDDIH
	{
		Walk,
		Idle,
		ObstacleHiding,
		CornerHiding,
		Rusher,
		Vehicle,
		Parachute,
		Helicopter,
		Swat,
		MachineGunPoint,
		Minigunner,
		EngineerTurret,
		EngineerRepair,
		Fly,
		RusherSpare,
		Gunslinger,
		Mortar,
		Warp,
		Backbone,
		Havoc,
		Trigger,
		Surge,
		Replica,
		OverseerCrouch,
		OverseerStand
	}

	private enum MIELMMANJJE
	{
		Driving,
		Spawning,
		Spawned,
		Falling
	}

	private sealed class PBEOFABGCPO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public EnemyController HNNCIECPFEJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public PBEOFABGCPO(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class DLHLHLBLBNN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public EnemyController HNNCIECPFEJ;

		public EnemyController FAJIIAMLADN;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public DLHLHLBLBNN(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public NavigationAgent LPAJIFHNLKO;

	public DestroyableObjectMultipleParts IILHBBEDLPP;

	public Kevlar OFCBADJNJHF;

	public UnitShield ENPBILNLGGE;

	public EnemyPoint AJNMLEGNFMJ;

	public bool HDKFBMHJFGP;

	public SoldierParts IHIBKBDPFKD;

	[SerializeField]
	private DestroyableObject mShield;

	[SerializeField]
	public SoldierAnimationController mSoldierAnimationController;

	[SerializeField]
	private SoldierMeshChanger mSoldierSoldierMeshChanger;

	public Transform APAECJDOAIL;

	private bool EFDNCMMLIAE;

	private bool NHOIFCIOGEL;

	private float LMIABEGIICM;

	private bool NONAKAEHJCF;

	public KMEPKJIDDIH OOEGIICLMFM;

	public HeadSizeSetter APJHOIONFGC;

	private Material GEEBNGGJAID;

	[CompilerGenerated]
	private Action DOLJBJHGINC;

	private float FEMNFGHENJF;

	private bool ACBEJKJNMMH;

	public bool JLLGBPOMHLJ;

	private bool HINNOJMNLBB;

	private float EJMMEMELCKK;

	private MIELMMANJJE ADPFIEKFHIK;

	private bool HMOHNNNCOOK;

	private bool IOLIJOMKIAG;

	private bool PBOHKMLHBJD;

	private float PKFGHLFHKEC;

	private float OHAKLGCEBME;

	private float IEBJACBBLPI;

	private float HKPEIBJIMCB;

	private bool DMNCFHCGCOP;

	private float KJAEBIFPFLO;

	private float OAPMMOHKLNL;

	private DAENECCJJNP MFBDJIPNNHO;

	private float PJKJPILJJGC;

	private int KPBDKOJJPJL;

	[CompilerGenerated]
	private Action<EnemyController> CEKIHGCCCFB;

	private bool NCAACPDIOAF;

	private Parachute ICEKMPOLGPK;

	private float BFJDAPGEJDC;

	private bool OKDNFBCALNG;

	private bool JHDBPJNHOFG;

	public bool LELFKPCNEBA;

	private EnemyPointHelicopter ENGJBGGLCLI;

	private bool MONPDGBGJCM;

	public bool ODJLKLFAKGK;

	private List<GameObject> EEMIOMJEJHK;

	private float BFILFIFJKLN;

	private float KANOOLINBDD;

	private bool JJDDBNFANMM;

	private float NKCOCFELLOL;

	private float MMAEGMEKHBD;

	[CompilerGenerated]
	private SpawnPoint _003CGBNEHHPHKJH_003Ek__BackingField;

	private bool NJDPPCMHMEB;

	private Vector3 DBHMFJDEGGB;

	private float PFBLCMBJNHD;

	private Vector3 EGCOOOCNNPO;

	private int EPCAKHFCDKH;

	private Vector3 FFKCIGABBEM;

	private PlayerPoint DEMDKNKAKAB;

	private double NMIDLCHGJFM;

	private GBNMKDCEBLE HNNGHKNFNFL;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	private float FJHKENJAKJO;

	private bool JICPFOLNIFG;

	private bool AJBFHKODDFJ;

	private int OPAENGEKAKG;

	private float AJHDDEFAMPP;

	public bool canBeFreezed => false;

	private bool BDDNHIHIDKF => false;

	public bool allowShoot
	{
		set
		{
		}
	}

	public bool isCovered => false;

	public bool isRunning => false;

	public override DestroyableObject destroyableObj => null;

	public int rusherCounts => 0;

	public new bool isInField => false;

	public SoldierBehaviour soldierBehaviour => null;

	public SpawnPoint spawnPoint
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public SoldierMeshChanger meshChanger => null;

	public string[] playerVisuals
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool canDie
	{
		set
		{
		}
	}

	public Guid? PhotonSubscriberId
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public int replicaCounts => 0;

	public event Action OnTargetReached
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<EnemyController> onShoot
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	protected override void IOOJIDNOILO()
	{
	}

	private void LMAICIAFMDN(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void PIHGLAOAPDN(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public void PlayShotRagdoll(DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public void ClearEnemyPoint()
	{
	}

	private void PBGGCKEEPCG()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void OnInstancied()
	{
	}

	public void StartEnemyBehaviour(KMEPKJIDDIH ODOFPDCADDF)
	{
	}

	public void SetStateTo(KMEPKJIDDIH ODOFPDCADDF, EnemyPoint LGFMBOJMMMB)
	{
	}

	public void StartEnemyBehaviour(KMEPKJIDDIH ODOFPDCADDF, EnemyPoint LGFMBOJMMMB)
	{
	}

	public override void StartEnemyBehaviour()
	{
	}

	private bool EGBJFDDHMNM(EnemyPoint KFFIDHDOBPA = null)
	{
		return false;
	}

	public void SetFinalTarget(EnemyPoint LGFMBOJMMMB)
	{
	}

	protected override void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void ImproveAllWeapons(float DMPKAGHIGIB)
	{
	}

	public override void BoostDamage(float DMPKAGHIGIB)
	{
	}

	private void EEGPHOKFALE()
	{
	}

	private void NIEGBPBBNMC()
	{
	}

	private void IKJPCKBHBEL()
	{
	}

	private void IOLGCCGHCHN()
	{
	}

	private Vector3 GCPLMOFGDMN(Vector3 NGOEEEHNGMP)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void SpawnFromHelicopter()
	{
	}

	private void PLLEOMNJHNK(UITweener GDPAJADKOPD)
	{
	}

	private void PKAJFBFMFDH()
	{
	}

	public void LeavePosition()
	{
	}

	private IEnumerator IPHAAGAHICB()
	{
		return null;
	}

	public void GenerateNextShootTime()
	{
	}

	public void SetNextShootTime(float GAMFJEOGHJD, float BGIOBKDLNLD, bool BHJBBBNCKMC = true)
	{
	}

	public void SwitchState(KMEPKJIDDIH CBADPHMMCIM)
	{
	}

	[PunRPC]
	private void PlayeScifiParticles(bool JINBPFJOEMI)
	{
	}

	private void DFFOFCKEOJI()
	{
	}

	private void KHLAJAPFMPH()
	{
	}

	private void HHOGMOJDOLM()
	{
	}

	private void KLLJKOEGIIG(float AIMBLFBICGH)
	{
	}

	public void EndShooting()
	{
	}

	private void LGAFBAKNOKB()
	{
	}

	private void BFBFCFOBFFK()
	{
	}

	public override void DestroyPooled()
	{
	}

	private bool HLKHPMKHOGP()
	{
		return false;
	}

	private bool DFPCCJDBCCH(bool MOICPMGJCGF, bool IJDCIJLFCDO, float KGJKHMGGNIO = 0f)
	{
		return false;
	}

	public void OnShot()
	{
	}

	public override void DisableSpawn()
	{
	}

	public override void Spawn()
	{
	}

	private void ODPHLAPPOHI(bool EGMJAECMHBP)
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	public void Wait(float GAMFJEOGHJD)
	{
	}

	public void Resume()
	{
	}

	public void Freeze(bool CJKMMLNADMA)
	{
	}

	public void FreezByCard(bool CJKMMLNADMA)
	{
	}

	[PunRPC]
	public void FreezeRPC(bool CJKMMLNADMA)
	{
	}

	public void MultiplySpeed(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplySpeedRPC(float HHDCBKDKICG)
	{
	}

	public void SetUpKevlar(float JEACPJIEJLJ = 0.2f)
	{
	}

	private void BAJBNJCMPCJ(bool CBJHILBILDN)
	{
	}

	private void IICKAPDLGNK()
	{
	}

	private void LDFEFAMLHKI()
	{
	}

	private void JPAHAPODCKA()
	{
	}

	private void NLMCCAOKFPK()
	{
	}

	private void PCHOGEFFKIN()
	{
	}

	public void SwitchStateToMachineGun()
	{
	}

	public override void ReSync()
	{
	}

	private PlayerPoint MJJDPJNKMNM()
	{
		return null;
	}

	private EnemyPointRusher PGOJMOLPLPP()
	{
		return null;
	}

	private void HNAJCPGKHOD()
	{
	}

	private void OLPGALCBGGB()
	{
	}

	private void DDHKEIECKPB()
	{
	}

	private void JDPHBNKNHLN()
	{
	}

	private void PIGDLGNMOLB()
	{
	}

	private void JKBHLNHNGOK()
	{
	}

	private void CHOFMPMJBFI()
	{
	}

	private void EGPAKOHDFIC()
	{
	}

	private void PABKHFFBGHH()
	{
	}

	private void JJLIABKCGOC()
	{
	}

	public void StartStandShoot()
	{
	}

	private void LKPGDOBCCML()
	{
	}

	private void PIEHBJFAHJO()
	{
	}

	public void StartAnim(Vector3 FFJGKOLGFLL)
	{
	}

	private void MHHOHFEODCO()
	{
	}

	public void EnableWeapon()
	{
	}

	private void MPMEHLLDDPC()
	{
	}

	private void NDCGFEANMJE()
	{
	}

	private void EAMECOJDCIP()
	{
	}

	private void MOLBMPNCONP()
	{
	}

	[PunRPC]
	private void TriggerExplosive()
	{
	}

	private void DDBHEKGLJLO()
	{
	}

	private void ABCPCPACNJD()
	{
	}

	private void FPBMBJCNFND()
	{
	}

	private void CJIFGGKMLHD()
	{
	}

	private void OJJJMBNOFPI()
	{
	}

	[PunRPC]
	public void SnapColt(bool ADJFAFMGEBI)
	{
	}

	private void OEMHIMHDOLC()
	{
	}

	private void LMPGNHNGKOH()
	{
	}

	private void JJBGAPIDJHJ()
	{
	}

	[PunRPC]
	private void BuildMortar()
	{
	}

	[PunRPC]
	private void FireMortar(bool KEFFHECMKDP)
	{
	}

	private void MJGOGPIBFGG()
	{
	}

	private void GMEEJGMGGNJ()
	{
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	private void EOIHOBCABPB(KMEPKJIDDIH CBADPHMMCIM)
	{
	}

	[PunRPC]
	private void ShootFromCrawl(float JLEAGAFPKID)
	{
	}

	[PunRPC]
	private void ShootStandNew(float JLEAGAFPKID)
	{
	}

	[PunRPC]
	private void Crawl()
	{
	}

	[PunRPC]
	private void Idle()
	{
	}

	[PunRPC]
	public void SittingIdle()
	{
	}

	[PunRPC]
	private void Repair()
	{
	}

	[PunRPC]
	private void StartFlying()
	{
	}

	[PunRPC]
	private void ShootFromCover(bool FFIEFLILBAE, float JLEAGAFPKID)
	{
	}

	[PunRPC]
	private void Walk()
	{
	}

	[PunRPC]
	private void RopeSlide()
	{
	}

	[PunRPC]
	private void ThrowGrenadeFromCrawl()
	{
	}

	[PunRPC]
	private void ShootFromShield()
	{
	}

	[PunRPC]
	private void ThrowGrenadeFromCover(bool FFIEFLILBAE)
	{
	}

	[PunRPC]
	private void ShootFromBazookaFromCrawl()
	{
	}

	[PunRPC]
	private void ShootFromBazookaFromCover(bool FFIEFLILBAE)
	{
	}

	[PunRPC]
	private void ShootStand()
	{
	}

	[PunRPC]
	private void ShootWalk(Vector3 IIDEMAELGHH)
	{
	}

	[PunRPC]
	private void ShootAdditive()
	{
	}

	[PunRPC]
	private void ShadowSetActive(bool HHDCBKDKICG)
	{
	}

	[PunRPC]
	public void SoldierBehaviourSwitchWeapon(bool BNLPFPFIPFE, bool MOKJAIGOJKP = false)
	{
	}

	[PunRPC]
	private void SoldierBehaviourStartShootingNetwork(Vector3 MPHCJEIMBEB, int IHKALJJNNDD, bool KMKNPEHKLMI, byte HIMACIIHLDE, byte JPNOFLJNGNF)
	{
	}

	[PunRPC]
	private void SetCanDie(bool OPGKFKHLNGA)
	{
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePart(float MGMIJPLPHLN, int EPNGMAHENPA)
	{
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float MGMIJPLPHLN, int EPNGMAHENPA)
	{
	}

	public override void UpgradesLoaded()
	{
	}

	[PunRPC]
	public void ShowEngineerBuildingIndicator(bool FDADEAHAIKP, byte CMKJFIBLJIO)
	{
	}

	[PunRPC]
	public void UpdateEngineerBuildingIndicator(float IDIFAEGGBFA)
	{
	}

	[PunRPC]
	public void ImproveAllWeaponsRPC(float OFMBKFALFAM)
	{
	}

	[PunRPC]
	public void SetHealthbarActive(bool HLGENOLFNMN)
	{
	}

	[PunRPC]
	public void WeaponIgnoreLayer(int HKFJCKFDJHA)
	{
	}

	public void UpdateHeadScale(float KCDCIHIIAAC)
	{
	}

	[PunRPC]
	private void UpdateHeadScaleRPC(float KCDCIHIIAAC)
	{
	}

	public void SetMaxHealthAndRefill(float BIMKNONLOJD)
	{
	}

	private void PHLJNANBHED(bool OBMHDDDOPEA)
	{
	}

	private void OPAMKEKJEPP()
	{
	}

	private void IFOCLDLNAJO()
	{
	}

	private void HDFBIKIGJKJ(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	[PunRPC]
	private void SpawnReplica()
	{
	}

	private IEnumerator OHPPEOGOOBB(EnemyController FAJIIAMLADN)
	{
		return null;
	}

	private Vector3 NBBCHDNINBM()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	private void CNJOKDCAOGI(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void COBKEFJDLDA()
	{
	}

	private void BMNEMEAEFON()
	{
	}

	private EnemyPointReplica AKMLHGDKFMP()
	{
		return null;
	}

	[PunRPC]
	private void ReplicaWarp(Vector3 NICJPBBGKJD)
	{
	}

	[PunRPC]
	private void ReplicaWarpEnded()
	{
	}

	private void KCOLBMAKBLB()
	{
	}

	private Vector3 GDDMEHOMAIN()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	private Vector3 JMAIDKBJCBI()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void WarpAgain()
	{
	}

	private void FMCHACAFLFG()
	{
	}

	[PunRPC]
	private void Warp()
	{
	}

	[PunRPC]
	private void WarpIdle()
	{
	}

	private void GBJKMANAELC()
	{
	}

	[PunRPC]
	private void SyncWarperRPC(Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
	}

	[CompilerGenerated]
	private void MGDGBNFMLNF()
	{
	}

	[CompilerGenerated]
	private void GIKFAEHJEPO()
	{
	}

	[CompilerGenerated]
	private void MGJDHDKBCKH()
	{
	}

	[CompilerGenerated]
	private void LEGELFJEHNC()
	{
	}

	[CompilerGenerated]
	private void PFFLJKJKGAC()
	{
	}

	[CompilerGenerated]
	private void NLOBNPBFGKH()
	{
	}

	[CompilerGenerated]
	private void GMCIOCHFFAH()
	{
	}

	[CompilerGenerated]
	private void JOOAEOEEDCB()
	{
	}
}
