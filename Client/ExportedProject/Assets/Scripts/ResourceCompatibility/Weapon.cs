using System;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public abstract class Weapon : PoolableObject, TimeScaleIgnorable, IBFMOMDLFEP
{
	public enum BAGDEMJGIOF : byte
	{
		Riffle,
		Grenade,
		Bazooka,
		SwatPistol,
		Minigun,
		Pistol,
		GrenadeLauncher,
		Shotgun,
		Tool,
		QBZ,
		SniperRiffle,
		SwatSMG,
		Flamethrower,
		QBZ2,
		DoubleSMG,
		Machinegun,
		Colt,
		Mortar,
		Sword,
		Bow,
		BackboneSMG,
		LaserGun,
		Turret,
		Hammer,
		SpecterRifle
	}

	public delegate void GAGDKPLOEPD(Weapon AEBEOCBIBFI, Ammo OKOIFALMFFC, Vector3 MPHCJEIMBEB, bool IBHIIDHCGDP, DestroyableObject IILHBBEDLPP);

	public enum MGMIHFCHJEJ
	{
		Standard,
		Special
	}

	private Ammo LIKBHOIPPKG;

	private float? BKIMMKOKIHN;

	private float? BDFLNOAIIMO;

	public Ammo CENKNMFLMOA;

	[NonSerialized]
	public Ammo AFLLMJBJJNG;

	public ObscuredFloat FCJJOOMKHBG;

	public ObscuredInt IHEODOGNPJM;

	public ObscuredFloat HEIIGCCOKNE;

	public ObscuredFloat FJDOCFEMDAA;

	public bool LMGNJEIFPBP;

	public bool FKEOIMGIGBH;

	public bool EGLMIGGHLBG;

	public bool IKNHKCKCIOM;

	public bool ABDEOOHNDOJ;

	public Transform JFMPMODLNNN;

	public ObscuredInt JLNKLJLNGII;

	public bool LHGCDLBAOOA;

	public bool HKGICFLDIHH;

	public Ammo.BICKHONNMCG HIMACIIHLDE;

	public int NNAKKJKOBLF;

	private ObscuredInt PNHGPPKHEHI;

	private ObscuredInt IJGMCGDOCMB;

	private AmmoSetup MCCPFMOIKOD;

	private bool CDMIPPKMMPN;

	protected float CCJPNPOLJDH;

	protected PhotonView IBBJLFJLAFA;

	private float BAGLEMKMPOO;

	private float DLLMDGHAPCD;

	protected float NGFPINEJAFB;

	private float HHKGDEBFCHC;

	public ICHBAJOHDJC FFABGEMLPKO;

	public ICHBAJOHDJC LCKHKEPCGCI;

	public ICHBAJOHDJC NLOIFALJLDF;

	public ICHBAJOHDJC DABPIMCILJE;

	public float LLLJACAOIMI;

	public BAGDEMJGIOF JHEJINKHHLK;

	[CompilerGenerated]
	private PlayerWeapon _003CILPJMPPJNNA_003Ek__BackingField;

	[CompilerGenerated]
	private static GAGDKPLOEPD OIMJMMGAEHD;

	[CompilerGenerated]
	private static Action<Weapon, Vector3> KPOPBPCHKDC;

	[CompilerGenerated]
	private static Action<Weapon> JCGHOFJJIEK;

	[CompilerGenerated]
	private static Action<Weapon> HPHMDBCFNFN;

	[CompilerGenerated]
	private IBFMOMDLFEP _003CMBNKCDNNBNK_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDEKBAKPBFEP_003Ek__BackingField;

	public PlayerWeapon playerWeapon
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

	public float cadence => 0f;

	public bool isCoolingDown => false;

	public virtual int ammoLeft
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int ammoLeftInClip
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public AmmoSetup ammoSetup => null;

	public virtual bool isReloading => false;

	public virtual bool willShoot => false;

	public virtual bool hasAmmo => false;

	public bool outOfAmmo => false;

	public virtual bool hasAmmoInClip => false;

	public virtual bool hasLowAmmo => false;

	public virtual float reloadProgress => 0f;

	public virtual float cooldownProgress => 0f;

	public virtual float overheatProgress
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual float reloadingTimeLeft => 0f;

	public bool hasCustomDamageToPlayerCoefficient => false;

	public bool hasCustomDamageToPlayerOvertimeCoefficient => false;

	public bool hasCustomDamageToPlayerCoefficients => false;

	public virtual float nextShootProgress => 0f;

	public float lastShotTime => 0f;

	public HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public virtual IBFMOMDLFEP owner
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

	public static event GAGDKPLOEPD OnShotHit
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

	public static event Action<Weapon, Vector3> OnShotFired
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

	public static event Action<Weapon> OnReload
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

	public static event Action<Weapon> OnReloadFinished
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

	public override void OnInstancied()
	{
	}

	protected override void Awake()
	{
	}

	public virtual Ammo Fire(Vector3 FFJGKOLGFLL)
	{
		return null;
	}

	public virtual Ammo FireMultipleAmmos(Vector3 FFJGKOLGFLL, int MJNAKJCPGNC)
	{
		return null;
	}

	protected virtual void ECLHPEOCOMP(Vector3 FFJGKOLGFLL)
	{
	}

	[PunRPC]
	public virtual void FireNetworkRPC(Vector3 FFJGKOLGFLL, bool MFLHJEBNBNE, byte JFACCKJNHHC)
	{
	}

	protected virtual void GNJELKLICME(Vector3 FFJGKOLGFLL, int MJNAKJCPGNC)
	{
	}

	[PunRPC]
	public virtual void FireMultipleAmmoNetworkRPC(Vector3 FFJGKOLGFLL, bool MFLHJEBNBNE, byte JFACCKJNHHC, int MJNAKJCPGNC)
	{
	}

	public void SetBulletPrefab(MGMIHFCHJEJ CENKNMFLMOA)
	{
	}

	[PunRPC]
	public void SetBulletPrefabRPC(byte CENKNMFLMOA)
	{
	}

	public void SetDamageToPlayerCoefficients(float PNODKJEGCJK, float PHEBJPOFJIM)
	{
	}

	public void SetInitialDamageToPlayerCoefficients()
	{
	}

	[PunRPC]
	public void SetDamageToPlayerCoefficientsRPC(float PNODKJEGCJK, float PHEBJPOFJIM)
	{
	}

	[PunRPC]
	public void SetInitialDamageToPlayerCoefficientsRPC()
	{
	}

	public void MultiplyCadenceMultiplier(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	private void MultiplyCadenceMultiplierRPC(float DMPKAGHIGIB)
	{
	}

	protected virtual Ammo KLLJKOEGIIG(Vector3 MPHCJEIMBEB, bool KMKNPEHKLMI)
	{
		return null;
	}

	protected virtual Ammo PNCFDNHEGMK(Vector3 MPHCJEIMBEB, bool KMKNPEHKLMI, int MJNAKJCPGNC)
	{
		return null;
	}

	protected virtual ICHBAJOHDJC HPIAPNLIFON()
	{
		return default(ICHBAJOHDJC);
	}

	protected virtual ICHBAJOHDJC HBHJPJHHLFH()
	{
		return default(ICHBAJOHDJC);
	}

	protected void Update()
	{
	}

	private void BDMADPHJKGI()
	{
	}

	public void Reload()
	{
	}

	public void Overheat()
	{
	}

	public virtual float ComputeFlyTimeToTarget(Vector3 MPHCJEIMBEB)
	{
		return 0f;
	}

	[PunRPC]
	public void SetBullletSpeedCoef(float DAMNCHALAPG)
	{
	}

	public virtual void ReportShotHit(Ammo OKOIFALMFFC, Vector3 MPHCJEIMBEB, bool KMKNPEHKLMI, DestroyableObject IILHBBEDLPP)
	{
	}

	public void UpdatePhotonView(PhotonView LOAGAOKNAPI)
	{
	}

	public void DestroyPhotonView()
	{
	}

	public virtual Weapon GetAdditionalWeapon()
	{
		return null;
	}

	public void AddAmmoDamageFromCharAug(float PIMDLOBOGIM)
	{
	}

	[PunRPC]
	protected void AddAmmoDamageFromCharAugRPC(float PIMDLOBOGIM)
	{
	}

	public void ScaleCriticalProbability(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	protected void ScaleCriticalProbabilityRPC(float DMPKAGHIGIB)
	{
	}

	public void AddAmmo(int CKFPFCJDBJK)
	{
	}

	[PunRPC]
	protected void AddAmmoRPC(int CKFPFCJDBJK)
	{
	}

	public void MultiplyShotVelocity(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	protected void MultiplyShotVelocityRPC(float DMPKAGHIGIB)
	{
	}

	public void MultiplyMissChance(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	protected void MultiplyMissChanceRPC(float DMPKAGHIGIB)
	{
	}

	public void AddExtraDamage(float PIMDLOBOGIM, int LGFMBOJMMMB)
	{
	}

	[PunRPC]
	protected void AddExtraDamageRPC(float PIMDLOBOGIM, int LGFMBOJMMMB)
	{
	}

	public void AddExtraHeadshotDamage(float PIMDLOBOGIM, int LGFMBOJMMMB)
	{
	}

	[PunRPC]
	protected void AddExtraHeadshotDamageRPC(float PIMDLOBOGIM, int LGFMBOJMMMB)
	{
	}

	public void RemoveExtraDamage()
	{
	}

	public void RemoveExtraHeadshotDamage()
	{
	}

	public virtual void MeshChanged(Mesh KKLOODEHLIF)
	{
	}

	[CompilerGenerated]
	private void AIOBDMNKGFC()
	{
	}
}
