using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OverseerOrb : MechanicalUnit<OrbBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private sealed class CPOFCDIADLM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public Vector3 JPFODDPABBM;

		public Vector3 GEFICOMCFIL;

		public OverseerOrb HNNCIECPFEJ;

		private float GNCLMGHBBBN;

		private float PGJKDOMLMNE;

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
		public CPOFCDIADLM(int HEIHBBOBLGF)
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

	[SerializeField]
	private ParticleSystem mFireDamage;

	[SerializeField]
	private DestroyableObject mDestroyableObject;

	[SerializeField]
	private Animation mBaseAnimation;

	[SerializeField]
	private Animation mEliteAnimation;

	[SerializeField]
	private BatchedWeapon mRocket;

	[SerializeField]
	private UnitModelLoader mEliteModelLoader;

	[SerializeField]
	private VehicleVisuals mEliteVisuals;

	[SerializeField]
	private Transform mGunVisuals;

	[SerializeField]
	private Transform mNormalGunSnap;

	[SerializeField]
	private Transform mEliteGunSnap;

	[SerializeField]
	private AudioSource mAudioSource;

	public SoldierBehaviourOverseer PLILEDIBOJF;

	public bool NPBJFNAFMNK;

	public bool PKFPCHECJBK;

	private Transform APAECJDOAIL;

	private bool JLLGBPOMHLJ;

	private PoolableObject MCLBOIMMILI;

	private Animation OCMHPKCBPLA;

	private Texture GKACBGFPGKE;

	private GameShootableEntity OANKNHGMIAD;

	private float FIMDEMINJFM;

	private float ENPNEKOAADG;

	private WaypointCircuit KCJAGALBBDI;

	private int LMLBEMIDIIL;

	private int PJHCBBBHDFM;

	private Transform PICEPNMKMEA;

	private bool CDLADPEFBDP;

	private Rigidbody IEFPAMKAAFF;

	private Transform FBPHFCMEADA;

	private Vector3 BBDADDPGPIK;

	private float FLMOBNENAOH;

	private float ONPIPGILFIL;

	private float EDGPHDOAHBD;

	private float AOPOIJEPNIC;

	private float CKPCCOAHFOF;

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

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

	public override void BeforeInstancied()
	{
	}

	public override void OnInstancied()
	{
	}

	public override void Spawn()
	{
	}

	public void SetTextures(Texture FBMJALEANDB)
	{
	}

	public override void UpgradesLoaded()
	{
	}

	private void OILHKLPAANG()
	{
	}

	public void SetOrbOwner(SoldierBehaviourOverseer ALCEAEELEJJ)
	{
	}

	private void GKLFELEKING()
	{
	}

	private void FOKEABBIMJM(WaypointCircuit DEGAICEENLJ)
	{
	}

	protected override void Start()
	{
	}

	protected override void Awake()
	{
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	public override void DestroyPooled()
	{
	}

	protected override void Update()
	{
	}

	[PunRPC]
	private void UpdateLastShootTimeOrbRPC(float JJPOCBHBLFH)
	{
	}

	private void HKCIPDNCLNB()
	{
	}

	protected override void LLGNKOCNOEI()
	{
	}

	private void GKNJMOGJKAI()
	{
	}

	private void KLLJKOEGIIG(Vector3 GAHBNFCPNBK, GameShootableEntity.ShotTarget JFFJNCBEGDB)
	{
	}

	private void DKNJINLKJOA(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void CFJLIJMACBP(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void LOIKKPKNNKM()
	{
	}

	private void AHOBOBBMPAN()
	{
	}

	private void GKCHMODGHNE(PHOFJEDENDJ AGECANAKJOL, DestroyableObject.LDOKCBNNLCH IEDOEMFMGCP)
	{
	}

	private IEnumerator GKCHMODGHNE(Vector3 GEFICOMCFIL, Vector3 JPFODDPABBM)
	{
		return null;
	}

	[PunRPC]
	private void KamikazeExplode()
	{
	}

	private void OnCollisionEnter(Collision JGFBDMBBPBM)
	{
	}

	private void OnDrawGizmos()
	{
	}

	public void OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	public void LoadUpgrades(int IDHKHECHPHJ, bool GCBAHJNDMDE, float BFJNAINNBGB, float HAGGJLBMIIF)
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}
}
