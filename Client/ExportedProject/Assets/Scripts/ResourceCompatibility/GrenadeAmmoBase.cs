using System.Runtime.CompilerServices;
using UnityEngine;

public class GrenadeAmmoBase : PhysicalAmmo
{
	public enum MOIPIIPBMLN
	{
		Frag,
		Poison,
		Smoke,
		Flash,
		Molotov,
		Sticky
	}

	[CompilerGenerated]
	private IBFMOMDLFEP _003CAMPEDKKHMII_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CMJDJICAOJFN_003Ek__BackingField;

	public GrenadeAmmoBaseSetup IDIIEBBLDAM;

	public GrenadeAmmoEnemy MGKPHGMHMEC;

	public MolotovGrenadeAmmo LEHHPHKEGBG;

	[SerializeField]
	private GrenadeAmmoEnemy mStickyGrenade;

	[SerializeField]
	private AnimationCurve mBlinkBefore;

	[SerializeField]
	private AnimationCurve mBlinkAfter;

	[SerializeField]
	private Renderer mBlinkRenderer;

	[SerializeField]
	private AudioSource mBeepAudioSource;

	[CompilerGenerated]
	private GrenadeAmmoContent _003CNJPAOPBEGKK_003Ek__BackingField;

	[SerializeField]
	private Material mMaterial;

	[SerializeField]
	private Mesh mMesh;

	[SerializeField]
	private MeshRenderer mMeshRenderer;

	private Rigidbody IEFPAMKAAFF;

	private TrailRenderer FIDMMGPEELM;

	private Vector3 BBDADDPGPIK;

	private Collider OGEPBCKDNMN;

	private DestroyableObject AIIDCMKBFCB;

	private Vector3 KFDKFAKPAPG;

	private bool GLGJKGBCNCO;

	private float LLJMIHLOPPD;

	private float CMFGOHGPCLO;

	private bool CFECCDANJFN;

	private bool DLMLLAKINFP;

	private MOIPIIPBMLN DMEMGKCNGBL;

	private Shield PMIPGMBKJAC;

	private Transform BHEGPFOFJGE;

	private Vector3 GIMNDJEDOFC;

	private Quaternion HOLFPNMPALB;

	private float AIHJAOPKCHG;

	public IBFMOMDLFEP cachedOwner
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

	public bool exploded
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

	private GrenadeAmmoContent OKFGOABODLA
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

	protected override void Awake()
	{
	}

	public void ChangeGrenade(MOIPIIPBMLN BEPOLIIPGGA, MeshRenderer AOJFOOFBCMB, Mesh GPNMAPHHKAA)
	{
	}

	public override void Fire(Vector3 EMMCJEEABGA, Vector3 FFJGKOLGFLL)
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	protected void Update()
	{
	}

	private void OnCollisionEnter(Collision JGFBDMBBPBM)
	{
	}

	protected virtual void FKNJKBDKOKK()
	{
	}

	public override void OnInstancied()
	{
	}

	public virtual void Explode()
	{
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}

	protected virtual void AENLCALEBDK(Vector3 MPHCJEIMBEB)
	{
	}

	protected virtual void GLNANDJAJLA(Vector3 MPHCJEIMBEB)
	{
	}

	public override void LoadAmmoSetup(AmmoSetup IDIIEBBLDAM)
	{
	}

	[PunRPC]
	public void ExplodeNetwork(Vector3 MPHCJEIMBEB)
	{
	}

	private Vector3 FDODLFOGOEH(Vector3 EMMCJEEABGA, Vector3 LGFMBOJMMMB, float PGMNLHFGOOK)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void TriggerExplosion()
	{
	}
}
