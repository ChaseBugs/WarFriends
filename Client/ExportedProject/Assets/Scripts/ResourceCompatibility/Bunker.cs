using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bunker : Vehicle<BunkerBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private enum FOGHEJGPKCL
	{
		Spawning,
		Ready,
		Resurecting,
		Dieing
	}

	private sealed class NNPBNNAEAFM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public Bunker HNNCIECPFEJ;

		private float CNIDEIGCJEL;

		private Quaternion KIKCDKKGALF;

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
		public NNPBNNAEAFM(int HEIHBBOBLGF)
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

	private sealed class LFIHDLGEPCC
	{
		public Bunker HNNCIECPFEJ;

		public Vector3 OIMMJIGPNDK;

		public Action JBILNPCLHKH;

		public UITweener.OnFinished FILHBIHDDFL;

		public UITweener.OnFinished JNOIKPKHMGB;

		public Action KKHLOMJLHEE;

		internal void BCMLMCBOLAD(UITweener HKJICEAAGPA)
		{
		}

		internal void CFFDPGFFHLA(UITweener GDPAJADKOPD)
		{
		}

		internal void LBOKJEHBBIL()
		{
		}

		internal void AFDNBOBLFGA()
		{
		}

		internal void CLBPHFJKFIN(UITweener HKJICEAAGPA)
		{
		}

		internal void MCIHJKNIIPH(UITweener MLFEPBLAKBA)
		{
		}
	}

	private DestroyableObjectMultipleParts AIIDCMKBFCB;

	[SerializeField]
	private EnemyPointVehicle point;

	[SerializeField]
	private GameObject obstacleCollider;

	[SerializeField]
	private Rigidbody mainBody;

	[SerializeField]
	private Rigidbody roofBody;

	[SerializeField]
	private GameObject roofHitCollider;

	[SerializeField]
	private BunkerParachute parachutes;

	[SerializeField]
	private List<GameObject> mParts;

	[SerializeField]
	private AudioSource mAudioSource;

	public Transform CNODPHJLJHI;

	public TurretWeaponBasic EADEPGKMMJP;

	public Transform IPOLIGAEEDH;

	public Transform HCLBIKIPDOM;

	public Transform PACPGMJJFCD;

	private FOGHEJGPKCL GGHMKMDDAPC;

	private SpawnPointCar KLJDLOLEAMP;

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

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

	public override DestroyableObject destroyableObj => null;

	public void OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	protected override void Awake()
	{
	}

	private void DKIOCKMFKCF(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	private void HLADHFMHGLJ(AIObject AGECANAKJOL, bool KGLMAPDNJJL)
	{
	}

	private void ANMBBLCHKHG(bool HLGENOLFNMN)
	{
	}

	private void NBPPGEAPBBC()
	{
	}

	private void PIHGLAOAPDN(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	protected override void MLCLIAOFKNE(DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	private void HLPGKIFDMHE(FOGHEJGPKCL ANFKJAJJPAE)
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void OnInstancied()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	protected override void OPNDMFKAEBL(HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	private IEnumerator MKFGGDDHKGA()
	{
		return null;
	}

	public override void Spawn()
	{
	}

	public override void DestroyPooled()
	{
	}

	protected override void LLGNKOCNOEI()
	{
	}

	[PunRPC]
	private void AnimateSpawn(Vector3 GPCNPCKHKPD, Vector3 OIMMJIGPNDK, Quaternion KMPBJDNAEDB)
	{
	}

	public override void DestroyPooled(bool DAJDFCOFHJN)
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	[CompilerGenerated]
	private void NOBLGMNPEDO()
	{
	}

	[CompilerGenerated]
	private void AECOKGCKCPF()
	{
	}

	[CompilerGenerated]
	private void IONPOHHAHCL()
	{
	}
}
