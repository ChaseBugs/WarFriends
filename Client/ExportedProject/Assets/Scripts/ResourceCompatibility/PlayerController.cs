using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MainGameEntity, TimeScaleIgnorable, PHOFJEDENDJ, IBFMOMDLFEP, AFIKFLMIBBA, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	public enum NJHAKCPJBFD
	{
		HidingBehindShield,
		Walking,
		WalkingToNewlevel
	}

	private sealed class GAGKFGGFOIA
	{
		public PlayerController HNNCIECPFEJ;

		public MapDefinition.DefendPosition MPHCJEIMBEB;

		internal void BDLFOBGIOAE()
		{
		}
	}

	public static PlayerController CLLHHDHPBKF;

	public static Dictionary<int, PlayerController> OBDGJHDDLAM;

	public LIIMFPNNGAC ABPFDIIGMCI;

	public List<AimTarget> AHCFJLPHLCE;

	public DestroyableObjectPlayer CIJJKCCALAD;

	public bool CJPHFLKKIPD;

	private Material GEEBNGGJAID;

	public PhotonView IBBJLFJLAFA;

	private NJHAKCPJBFD IIAHIPJPMPN;

	public SoldierParts IHIBKBDPFKD;

	public int ABJFGBPIPIM;

	public KJLIMOPJICE NFKPFHGALNC;

	public PlayerCoefficients JGJKKPMCLEN;

	public PlayerAugmentations CJHHIAMDDKJ;

	public AimTarget FBDMDOJKEHK;

	[CompilerGenerated]
	private WeaponInventory _003CAPPIFBPGDNI_003Ek__BackingField;

	[CompilerGenerated]
	private SoldierAnimationController _003CFCHKELBNBFF_003Ek__BackingField;

	[CompilerGenerated]
	private GameShootableEntity _003CANHCKJAGEBI_003Ek__BackingField;

	public KinematicRagdoll LPEJLMHKFLH;

	[SerializeField]
	private SoldierMeshChanger mMeshChanger;

	public PlayerBot NAEFLHAPMBO;

	[CompilerGenerated]
	private bool _003CALKKPDJAPEL_003Ek__BackingField;

	private float NDBNFDBPHFK;

	[CompilerGenerated]
	private Action<NJHAKCPJBFD> IJALEBKNGPA;

	public float BDPGDOEGBDC;

	public PlayerStats CLOFKENLHLH;

	private static readonly List<PlayerController> DCFJNFMABAF;

	public bool EFAFAPLIDMD;

	public bool OOCJOKMEDJB;

	public bool FKIHJANCLKF;

	private GameObject OJKOAGBICIK;

	private MapDefinition.DefendPosition DHNGDNDIJHM;

	public HPHFGNJPDKN GNCHIMKGGNO;

	private bool IIGLLMACDDF;

	private bool FHCGFLBBKOP;

	private MapDefinition.DefendPosition PPFFJEJJLBF;

	private float JCJADKLDIOM;

	private bool NDANLCMPMGM;

	private float MBGNLFGJKCI;

	private Vector3 DFBLKCEEODO;

	private int? BIHDHHBBKKF;

	private SkinnedMeshRenderer BLAAPCEPLLA;

	private Vector3 PONOABIKOKE;

	private bool ODNOOHPIBAO;

	private Transform APAECJDOAIL;

	private Quaternion MLOCNEACNBH;

	private GBNMKDCEBLE HNNGHKNFNFL;

	private float HDAHBGOEAPO;

	public bool MEBKPOBJDPB;

	public float KHKPEOEGDMI;

	public bool BHEOGIAOOHF;

	public bool HOGCBLALCAH;

	[CompilerGenerated]
	private float _003CHOJHGKGBGBL_003Ek__BackingField;

	public float MDHPLJFLAKI;

	public List<Collider> MGAJJAPNCBP;

	private float GBCHHMMJDCH;

	[CompilerGenerated]
	private Action<PHOFJEDENDJ, DestroyableObject.LDOKCBNNLCH> DBNKCOADOGP;

	[CompilerGenerated]
	private int _003CCLKAJAEBPBF_003Ek__BackingField;

	private bool OEDGOCBBNEO;

	public bool ELLDDENCLHG;

	private NavigationAgent DJCNMKFDJKL;

	private float EELMHPOFKMH;

	private float EOMGHEPJCKF;

	private float INDGCKNHMMG;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	public WeaponInventory weaponInventory
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public SoldierAnimationController soldierAnimator
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public GameShootableEntity gameShootableEntity
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool clicked
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public MapDefinition.DefendPosition currentPlayerPoint
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isImmortal
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float weaponReloadCoef
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float baseSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float speed => 0f;

	public NJHAKCPJBFD playerState
	{
		get
		{
			return default(NJHAKCPJBFD);
		}
		private set
		{
		}
	}

	public Vector3 position => default(Vector3);

	public Vector3 aimForward => default(Vector3);

	public Vector3 aimToMiddleOfMap => default(Vector3);

	public bool isCurrentPlayer => false;

	public override HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public override IBFMOMDLFEP owner
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override int power
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool ignoreTimeScale
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override DestroyableObject destroyableObj => null;

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

	public event Action<NJHAKCPJBFD> PlayerStateChanged
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

	public override event Action<PHOFJEDENDJ, DestroyableObject.LDOKCBNNLCH> Killed
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

	public void ChangeWeightForDestroyablePart(float MGMIJPLPHLN, int EPNGMAHENPA)
	{
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float MGMIJPLPHLN, int EPNGMAHENPA)
	{
	}

	[PunRPC]
	private void SetCurrentPoint(int EPNGMAHENPA)
	{
	}

	[PunRPC]
	public void AddAmmoRPC(int EPNGMAHENPA, int CKFPFCJDBJK)
	{
	}

	public void SetNoDamageChance(float CMMFKJLHBMI)
	{
	}

	[PunRPC]
	public void SetNoDamageChanceRPC(float CMMFKJLHBMI)
	{
	}

	protected override void Start()
	{
	}

	protected override void Awake()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO DFEHIADKKNO)
	{
	}

	private void DJIKBALBFCM()
	{
	}

	private void OIIIJKGFNMB(float GHMOCCOCDNO, float BBGNGLEDNCC)
	{
	}

	private void LOHMGGPFOLL()
	{
	}

	private Vector3 PLIHIICADPJ(Vector3 MPHCJEIMBEB)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void MoveTo(Vector3 OIMMJIGPNDK, Quaternion PMDOCDBALPO)
	{
	}

	public void InitPlayerForCamera()
	{
	}

	public void InitPlayer()
	{
	}

	public void SelectPrimary()
	{
	}

	public void HideWeapon()
	{
	}

	public void Preview(bool DFIIKCOHIGG)
	{
	}

	[PunRPC]
	private void InitBotRPC(byte MJPHCDCIAIE)
	{
	}

	public override void OnInstancied()
	{
	}

	private void LLOMIJADPCA(DestroyableObject.LDOKCBNNLCH INADGPICPMO, Vector3 EMMCJEEABGA, float GAMFJEOGHJD)
	{
	}

	[PunRPC]
	private void PlayTrailRPC(Vector3 EMMCJEEABGA, Vector3 FFJGKOLGFLL, float GAMFJEOGHJD)
	{
	}

	[PunRPC]
	private void SetShootingDisabled()
	{
	}

	[PunRPC]
	private void ShowSpecterHitIndicatorRpc()
	{
	}

	public void ShowSpecterHitIndicator()
	{
	}

	private void KLAMICNCDKB(DestroyableObject.BMOKOKCHMLP AHFBNJHCANA, float GHPPCNBBHDK)
	{
	}

	private void LMAICIAFMDN(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void PIHGLAOAPDN(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void MNJOIGHHGPK(DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void PNHANHODJKG()
	{
	}

	protected override void Update()
	{
	}

	private void GODPIHKHNHN(bool EGMJAECMHBP)
	{
	}

	private void IGCHJDPIOHF(PlayerWeapon KJHDNCCBCOO)
	{
	}

	protected virtual void MLCLIAOFKNE(DestroyableObject IEDOEMFMGCP, DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	public void PlayShotAnimation(Weapon.BAGDEMJGIOF AEBEOCBIBFI, bool FFIEFLILBAE, Vector3 LAOJMLCBLBN)
	{
	}

	[PunRPC]
	public void PlayShotAnimationNetwork(byte AEBEOCBIBFI, bool FFIEFLILBAE)
	{
	}

	[PunRPC]
	public void Uncover(bool FFIEFLILBAE, bool AKGHJGPGLNK)
	{
	}

	[PunRPC]
	private void Idle()
	{
	}

	[PunRPC]
	private void Walk()
	{
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	public static PlayerController GetEnemyOf(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static List<PlayerController> GetEnemiesOf(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static PlayerController GetRandomEnemy(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static PlayerController GetPlayerOld(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static PlayerController GetPlayer(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static PlayerController GetFriend(HPHFGNJPDKN MJPHCDCIAIE)
	{
		return null;
	}

	public static PlayerController GetMaster()
	{
		return null;
	}

	public static PlayerController GetPlayer(int IKEONGGFDFA)
	{
		return null;
	}

	public static PlayerController FindPlayerWithUserId(string NLKAAAOICNO)
	{
		return null;
	}

	public MapDefinition.DefendPosition GoLeft()
	{
		return null;
	}

	public MapDefinition.DefendPosition GoLeft(MapDefinition.DefendPosition KFFIDHDOBPA)
	{
		return null;
	}

	private void EGLPBKHPFIK(MapDefinition.DefendPosition MPHCJEIMBEB, float PCCJGICLAEL = 0.02f)
	{
	}

	private void CLNLNMMEIIP()
	{
	}

	public MapDefinition.DefendPosition GoRight()
	{
		return null;
	}

	public MapDefinition.DefendPosition GoRight(MapDefinition.DefendPosition KFFIDHDOBPA)
	{
		return null;
	}

	private void PBOJNGAEDFF(int LAOJMLCBLBN)
	{
	}

	public void MakeBlind(float GAMFJEOGHJD)
	{
	}

	public override void DestroyPooled()
	{
	}

	public void SetUpKevlar(float OINGAEMFEPF = 0.25f)
	{
	}

	private void OPNDMFKAEBL(HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	public bool IsNearDeath()
	{
		return false;
	}

	public bool IsDeath()
	{
		return false;
	}

	public bool HasDisabledShooting()
	{
		return false;
	}

	public bool HasDisabledMoving()
	{
		return false;
	}

	protected void LateUpdate()
	{
	}

	private void OnPress(bool KEPGBOAAEON)
	{
	}

	public override void BeforeInstancied()
	{
	}

	public void ReSync()
	{
	}

	public void ChangeArmyUpgrade(int MPFFBBHNMBA, int GGPDCMJGAGB, bool LJLFEFJCLBO, bool KEFEDLPCFAL = false, bool LMHPDDCGOKO = false)
	{
	}

	[PunRPC]
	private void ChangeArmyUpgradeRPC(int MPFFBBHNMBA, int GGPDCMJGAGB, bool LJLFEFJCLBO, bool KEFEDLPCFAL, bool LMHPDDCGOKO)
	{
	}

	private void FDPICMKDLIH(LevelBehaviour NGEDOMFLLKI, bool LJLFEFJCLBO)
	{
	}
}
