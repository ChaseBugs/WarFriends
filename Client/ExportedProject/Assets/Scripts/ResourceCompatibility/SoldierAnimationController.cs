using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierAnimationController : AnimationController, TimeScaleIgnorable
{
	private class NBIKJEBJELD
	{
		public const string LBKLPGOHHGB = "shootAdditive";

		public const string PCCJELGLBFO = "sword_run_shoot";

		public const string GBICEBNEJOL = "sword_idle";

		public const string LMDGHLFEFKK = "hammer_menu";

		public const string HIPJFADOMKE = "hammer_run";

		public const string EAIIOJLMLKM = "hammer_attack";

		public const string LGDJLHFAIIO = "hammer_idle";

		public const string BANKHAALLCJ = "overseer_run";

		public const string EAADFAHENEK = "overseer_crawl";

		public const string DJGENAMOCJP = "overseer_stand";

		public const string JAJNAHCBDDF = "overseer_menu";

		public const string AHFLGBAFJFB = "specter_menu";
	}

	private enum FPHOBMBKOCN
	{
		Left,
		Right
	}

	public float BCNMFLMNDOC;

	public bool JIEPEKOKDMN;

	public Transform APAECJDOAIL;

	public Transform FCNPCOIGPEC;

	public Transform KEKEAFFAIJP;

	public Transform JMLINLIBKHJ;

	private FPHOBMBKOCN GLHNPJOIADE;

	private FPHOBMBKOCN HIEMCDFNGEO;

	private bool PILIPMPLDPJ;

	private bool GLGJKGBCNCO;

	private float BMCMBLKJNLC;

	private bool LBFDEHEINFK;

	private bool HBPHPINGIJB;

	private bool OOPCFHEMEKB;

	private float DPJIJMELCBG;

	private float GNOEEIAILOH;

	private float KPICPGAJFKI;

	private Vector3 JCFKFNNOJEO;

	private Vector3 CJEJCCLKHIN;

	private Quaternion APOBBBKGFDK;

	private Quaternion CIBPJLFOKKL;

	private float NMACMNPHDCB;

	private Quaternion BKINOIACBBF;

	private float FFJLNCCKMGD;

	private float FMAHFKJJJKA;

	private float HEMOAHKOGEM;

	private float LKEFDKBNJPB;

	private bool BPFHJCOBEOI;

	private float PEMOEGOELJF;

	private Weapon.BAGDEMJGIOF KGPNPKFDLMD;

	private string CKBAGGNBECH;

	private string JEKGJGFPKGA;

	private string LLINDIJGPEG;

	private string NGGCMGGIHFG;

	private string LFICDGAFGDA;

	private string OALIAGPFMFP;

	[CompilerGenerated]
	private bool _003CDEKBAKPBFEP_003Ek__BackingField;

	private bool FEDOIPALKJK;

	private bool BJOEFNAEMKC;

	private Vector3 EAEJDDPIKFG;

	public bool JJKKKKEECML;

	public float uncoverLength => 0f;

	public float swatShieldUncoverLength => 0f;

	public bool lookBack
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3 aimingDir => default(Vector3);

	public bool isSitting => false;

	public bool isIdle => false;

	public bool isRunning => false;

	public bool IsShooting => false;

	public bool isHiding => false;

	public float hiddingTime => 0f;

	public bool ignoreTimeScale
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float mortarBuildTime => 0f;

	public float mortarShotTime => 0f;

	public float mortarStandTime => 0f;

	public float breachTriggerTime => 0f;

	public float GetStandPhase0Length(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
		return 0f;
	}

	public float GetStandUpFromCrawlLength(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
		return 0f;
	}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void FLCDEALEHAF()
	{
	}

	public bool CanStartShooting()
	{
		return false;
	}

	private void OnEnable()
	{
	}

	protected void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}

	public void Stop()
	{
	}

	public void Enable()
	{
	}

	public void Reset()
	{
	}

	public void ForceInScreen()
	{
	}

	private void HKEFBONAAMN()
	{
	}

	public void Warp()
	{
	}

	public void WarpIdle()
	{
	}

	public void Walk(Weapon.BAGDEMJGIOF JFACCKJNHHC)
	{
	}

	public void WalkWithoutWeapon()
	{
	}

	public string GetWalk(Weapon.BAGDEMJGIOF JFACCKJNHHC)
	{
		return null;
	}

	public void BazookaWalk()
	{
	}

	public void ShotFromCover(bool FFIEFLILBAE, float ADGJMMHBAKI, float JLEAGAFPKID, bool AHPDFHNBCCN, bool CAEPHPKMABI, bool PAPOAMPDEKM, Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
	}

	public void ShotFromCover(bool FFIEFLILBAE, float ADGJMMHBAKI, float JLEAGAFPKID, bool AHPDFHNBCCN, Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
	}

	public void ThrowGrenadeFromCover(bool FFIEFLILBAE, bool BLCCJAGMFBA)
	{
	}

	public void ShootFromBazoka(bool FFIEFLILBAE, bool AHPDFHNBCCN, float LPLGFAPHFFK = 0.7f)
	{
	}

	public void ShootFromBazokaWalk()
	{
	}

	public void ShootFromBazokaCrawl()
	{
	}

	public void ThrowGrenadeFromCrawl()
	{
	}

	private void EBGJJJHDGDN()
	{
	}

	private void LKNEOPLKPBI()
	{
	}

	private void HBAHPGNCHBM(FPHOBMBKOCN KLFHHDMGBLL, Weapon.BAGDEMJGIOF JHEJINKHHLK, float ACLINDOAODK)
	{
	}

	public void ShootFromSwatShield(float JLEAGAFPKID, float DKGJPOAIEDL)
	{
	}

	public void StartFlying()
	{
	}

	public void Repair()
	{
	}

	public float StandShootLength(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
		return 0f;
	}

	private string ACHMNNMAIME(Weapon.BAGDEMJGIOF JHEJINKHHLK, out float ACLINDOAODK)
	{
		ACLINDOAODK = default(float);
		return null;
	}

	public void ShootStandNew(Weapon.BAGDEMJGIOF JFACCKJNHHC, float DKGJPOAIEDL, float JLEAGAFPKID)
	{
	}

	public void ShootStand(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
	}

	public void ShotFly()
	{
	}

	private string PPKPPKDBBDK(Weapon.BAGDEMJGIOF JHEJINKHHLK, int GACONNNGJBB)
	{
		return null;
	}

	private string JBOJGCILBGN(Weapon.BAGDEMJGIOF AEBEOCBIBFI, int GACONNNGJBB)
	{
		return null;
	}

	public void ShootFromCrawl(float JLEAGAFPKID, float DKGJPOAIEDL, Weapon.BAGDEMJGIOF JFACCKJNHHC)
	{
	}

	private string CHCIDJNOPDE(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
		return null;
	}

	public void ShootStandAdditive(float JLEAGAFPKID, bool EHLOMGKJLGG, Weapon.BAGDEMJGIOF JHEJINKHHLK = Weapon.BAGDEMJGIOF.Riffle)
	{
	}

	public void Reload(Weapon.BAGDEMJGIOF JFACCKJNHHC)
	{
	}

	private string BENHFBCFHEK(Weapon.BAGDEMJGIOF JFACCKJNHHC, bool LJCMDLNAFOH)
	{
		return null;
	}

	public void SampleIdle(Weapon.BAGDEMJGIOF JFACCKJNHHC, float GAMFJEOGHJD = 0f, bool LJCMDLNAFOH = false)
	{
	}

	public void SampleIdleNoWeapon(float GAMFJEOGHJD = 0f, bool LJCMDLNAFOH = false)
	{
	}

	public bool IsIdle(Weapon.BAGDEMJGIOF JFACCKJNHHC, bool LJCMDLNAFOH, out float GAMFJEOGHJD)
	{
		GAMFJEOGHJD = default(float);
		return false;
	}

	public void Idle(Weapon.BAGDEMJGIOF JFACCKJNHHC, bool MNEFIHGHLMN = false, bool LJCMDLNAFOH = false)
	{
	}

	public void IdleWithoutWeapon(bool MNEFIHGHLMN = false, bool LJCMDLNAFOH = false)
	{
	}

	public void SetIdle(Weapon.BAGDEMJGIOF JFACCKJNHHC)
	{
	}

	public bool IsPlaying()
	{
		return false;
	}

	public void IdleBazooka()
	{
	}

	public void Crawl()
	{
	}

	public void CrawlWithoutWeapon()
	{
	}

	public void RopeSlide()
	{
	}

	public void SampleStand()
	{
	}

	public void SampleDead()
	{
	}

	public void SetUpperBodyRot(float HHDCBKDKICG)
	{
	}

	public void LookAt(Vector3 LAOJMLCBLBN, float FJFABLEBIOB = 0.45f)
	{
	}

	public void LookAtUpperBody(Vector3 LAOJMLCBLBN, float GAMFJEOGHJD = 0.5f, float AEFEICBFKPH = 0.25f)
	{
	}

	public void SetWeaponType(Weapon.BAGDEMJGIOF JHEJINKHHLK)
	{
	}

	private static string DJIFBBBFFMM(Weapon.BAGDEMJGIOF JFACCKJNHHC, FPHOBMBKOCN KLFHHDMGBLL, int GACONNNGJBB)
	{
		return null;
	}

	public void SetTPose()
	{
	}

	public void SittingIdle()
	{
	}

	public void BuildMortar()
	{
	}

	public void FiredMortar()
	{
	}

	public void TriggerExplosive()
	{
	}

	public void Disable()
	{
	}

	public void ThrowWeaponAway()
	{
	}
}
