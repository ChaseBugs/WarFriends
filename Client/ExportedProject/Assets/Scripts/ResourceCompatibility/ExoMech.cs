using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ExoMech : Vehicle<ExoMechBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private enum EOJDMBCLMBP
	{
		Walk,
		Shoot,
		Idle
	}

	private sealed class BBDPENBOIEC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public ExoMech HNNCIECPFEJ;

		private EnemyPoint EOFFMAOGOMI;

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
		public BBDPENBOIEC(int HEIHBBOBLGF)
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

	private sealed class HHIJMOOFBGO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public ExoMech HNNCIECPFEJ;

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
		public HHIJMOOFBGO(int HEIHBBOBLGF)
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

	private sealed class LNBFPGDBJBH
	{
		public ExoMech HNNCIECPFEJ;

		public PlayerController NLLAKIDPPDH;

		public GameShootableEntity.ShotTarget JFFJNCBEGDB;

		internal void LFOKIAPBNCP()
		{
		}
	}

	private sealed class NCCJOFILFNM
	{
		public ExoMech HNNCIECPFEJ;

		public GameShootableEntity.ShotTarget JFFJNCBEGDB;

		public Vector3 OIMMJIGPNDK;

		public Ammo.BICKHONNMCG DNBHJJEOFCP;
	}

	private sealed class KGONJADOHHI
	{
		public BatchedWeapon JNHKPNOHGCE;

		public float BKPKKOJPPHE;

		public NCCJOFILFNM PAIPGOJKHMM;

		internal void GFBHHEAFOMK()
		{
		}
	}

	[SerializeField]
	private NavigationAgent mAgent;

	[SerializeField]
	private DestroyableObjectMultipleParts mDestroyableObject;

	[SerializeField]
	private DestroyableObjectMultipleParts mGlassDestroyableObject;

	[SerializeField]
	private Glass mGlass;

	[SerializeField]
	private ExoMechAnimator mMechAnimator;

	[SerializeField]
	private EnemyPointVehicle mSoldierPoint;

	[SerializeField]
	private EnemyPointVehicle mSoldierPointForMenu;

	[SerializeField]
	private List<BatchedWeapon> mRockets;

	[SerializeField]
	private BatchedWeapon mMachineGun;

	private EnemyController NKGANJBAIBL;

	private EnemyPoint BPANDMGJBFJ;

	private bool NHOIFCIOGEL;

	private float LMIABEGIICM;

	private GameShootableEntity OANKNHGMIAD;

	private EOJDMBCLMBP KACIEIJMAFD;

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

	private bool NJFFLMEPFFE;

	private bool MMOCPGGHHHK;

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

	public override void GetAudioSources(List<AudioSource> JLFDMGDOEKP)
	{
	}

	public override bool CanProcessing()
	{
		return false;
	}

	protected override void Awake()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void OnInstancied()
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	public override void DestroyPooled()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	public override void StartEnemyBehaviour()
	{
	}

	protected override EnemyController DFKFEDIEKNI(EnemyPoint AJNMLEGNFMJ)
	{
		return null;
	}

	[PunRPC]
	private void SetSoldierPointRPC(int NCNDABEOPDL)
	{
	}

	private void AGJELKDPAMH(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void HILMKKPOJBA(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void MINPIIKDCMI(AIObject NFILMHJGGHP, bool CBJHILBILDN)
	{
	}

	private void CFJLIJMACBP(DestroyableObject AGECANAKJOL, DestroyableObject.LDOKCBNNLCH IEDOEMFMGCP)
	{
	}

	private void DKNJINLKJOA(DestroyableObject KIHIFIBOOIM, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private IEnumerator NLGBPABFKAJ()
	{
		return null;
	}

	[PunRPC]
	private void AnimateSpawn(Quaternion PMDOCDBALPO, Vector3 OIMMJIGPNDK)
	{
	}

	private bool OIHPAHJCJHB()
	{
		return false;
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	protected override void IOOJIDNOILO()
	{
	}

	protected override void Update()
	{
	}

	private void MILIDPAFJMP()
	{
	}

	private IEnumerator ICOJIPGGNFL()
	{
		return null;
	}

	private void PLDFLLBAOPF()
	{
	}

	private void NHLFFFIMHOD()
	{
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	private void HKCIPDNCLNB(bool GNEECLNOMLG)
	{
	}

	private void FOAEPAOIBNF()
	{
	}

	private void GKNJMOGJKAI()
	{
	}

	private void KLLJKOEGIIG(Vector3 GAHBNFCPNBK, GameShootableEntity.ShotTarget JFFJNCBEGDB, bool GNEECLNOMLG)
	{
	}

	private void LOIKKPKNNKM()
	{
	}

	private void JMCMMDGIAJA()
	{
	}

	private void MCNLJLENPGO(Vector3 PKIOICCPCBA)
	{
	}

	private void MNKEJLGHAGM(Vector3 PKIOICCPCBA)
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	[CompilerGenerated]
	private void BDNJEELFEAM(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void CENNDCDJBBP()
	{
	}
}
