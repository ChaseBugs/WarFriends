using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Havoc : MechanicalUnit<HavocBehaviour>, FJKGDAAHFIE, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private sealed class EEHHNHGNCBM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public Havoc HNNCIECPFEJ;

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
		public EEHHNHGNCBM(int HEIHBBOBLGF)
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

	private sealed class FCBMKCDMMHN
	{
		public MeshRenderer AJHKFGLILHK;

		internal bool LMJLACDHLBL()
		{
			return false;
		}
	}

	private sealed class KBDPANLCCKN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameObject DCLEOLBEAOD;

		private FCBMKCDMMHN BKALCIDIPEF;

		public Havoc HNNCIECPFEJ;

		private Color PDIHHFBHFMB;

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
		public KBDPANLCCKN(int HEIHBBOBLGF)
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

	public ParticleSystem KPGABKOOCAO;

	public BatchedWeapon AEBEOCBIBFI;

	[SerializeField]
	private GameObject mShield;

	[SerializeField]
	private Transform mSecondPointForMenu;

	[SerializeField]
	private Animation mHavocAnimation;

	[SerializeField]
	private GameObject mImpactEffect;

	[SerializeField]
	private GameObject mMainGun;

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

	private DestroyableObject AIIDCMKBFCB;

	private bool EDIOAPODLCL;

	private bool JLLGBPOMHLJ;

	private Transform APAECJDOAIL;

	private Havoc JIPCDBHFAHI;

	private bool EAANNGODHLD;

	private GameShootableEntity LGFMBOJMMMB;

	private float FIMDEMINJFM;

	private float ENPNEKOAADG;

	private WayPointPath GKKOOAAFLBK;

	private int LMLBEMIDIIL;

	private int PJHCBBBHDFM;

	private WayPoint BEAMHLNIGIN;

	private Transform PICEPNMKMEA;

	private bool CDLADPEFBDP;

	private Rigidbody IEFPAMKAAFF;

	private Transform FBPHFCMEADA;

	private PlayerController MLLBIOLDLAI;

	private Vector3 BBDADDPGPIK;

	private float EDGPHDOAHBD;

	public float CHCDBICJAGD;

	public float KLEHAHEKCHA;

	public float DHLMJPMPNMP;

	private MapDefinition.DefendPosition FAGNDBOBHJH;

	private float BFEGDNDKMON;

	public float OMDDGLDKGHJ;

	private bool NHKECFNGJIH;

	private EnemyPoint BPANDMGJBFJ;

	[SerializeField]
	private AnimationCurve mGlowBeforeShoot;

	[SerializeField]
	private float mEarlyGlowDuration;

	[SerializeField]
	private AnimationCurve mGlowAfterShoot;

	[SerializeField]
	private float mLateGlowDuration;

	[SerializeField]
	private Renderer[] mGlowRenderers;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	public override DestroyableObject destroyableObj => null;

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

	public override void StartEnemyBehaviour()
	{
	}

	protected override void Awake()
	{
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	private void CFJLIJMACBP(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private IEnumerator HGKDFIJJGBF()
	{
		return null;
	}

	private IEnumerator OFBCDGJOAEK(GameObject DCLEOLBEAOD)
	{
		return null;
	}

	private void DKNJINLKJOA(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void OnCollisionEnter(Collision JGFBDMBBPBM)
	{
	}

	public override void OnInstancied()
	{
	}

	protected override void Start()
	{
	}

	private void FOKEABBIMJM(WayPoint KFFIDHDOBPA)
	{
	}

	protected override void Update()
	{
	}

	private void GJFJFGMMAFO(int JDCGPFJFPPE)
	{
	}

	[PunRPC]
	private void SetWeaponIngoreLayersMaskRPC(int JDCGPFJFPPE)
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void GKNJMOGJKAI()
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	public override void BeforeInstancied()
	{
	}

	private void OALPBIOJIMJ(LevelBehaviour ENPJMCECKGI, Transform KFFIDHDOBPA)
	{
	}

	private void KLLJKOEGIIG(Vector3 GAHBNFCPNBK, GameShootableEntity.ShotTarget JFFJNCBEGDB)
	{
	}

	[PunRPC]
	private void UpdateLastShootTimeRPC(float PBBNMBLGKLA)
	{
	}

	private void HKCIPDNCLNB()
	{
	}

	public override void Spawn()
	{
	}

	public override void DestroyPooled()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	protected override void OPNDMFKAEBL(HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	public void DoReverseAnim()
	{
	}

	private EnemyPointHavoc EGJMKKOJKAK()
	{
		return null;
	}

	private PlayerPoint MJJDPJNKMNM()
	{
		return null;
	}

	public void OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	[CompilerGenerated]
	private bool PAEJMFNBKGH(PlayerController MNMLHIMCENE)
	{
		return false;
	}
}
