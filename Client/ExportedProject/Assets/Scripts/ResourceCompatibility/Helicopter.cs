using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Helicopter : Vehicle<HelicopterBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private sealed class JGCBLPLBIID : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public float EABOLCDGLAF;

		public Helicopter HNNCIECPFEJ;

		private List<EnemyPointHelicopter>.Enumerator CAMJLFPMEAJ;

		private EnemyPointHelicopter HKHILOPHFCK;

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
		public JGCBLPLBIID(int HEIHBBOBLGF)
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

		private void LOGNGHDBDGO()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public float OBJABBKJCLI;

	public float GIJBBHPNMCG;

	public List<EnemyPointHelicopter> JFJPPIMDIFN;

	public EnemyPointVehicle OFAPKIMNHPI;

	public bool HEELDFKDCBL;

	private float LHLIFLAEFDD;

	private float BOJCPEKABNA;

	public float MAEMNOFPHAO;

	private int PJHCBBBHDFM;

	private DestroyableObjectMultipleParts AIIDCMKBFCB;

	private Quaternion IGHOBACJMIC;

	private bool OAPFIMCPPOJ;

	private bool NHKECFNGJIH;

	private int LMLBEMIDIIL;

	private Rigidbody IEFPAMKAAFF;

	private Vector3 MNAEDEBOCPA;

	private Vector3 CPLJJPJBING;

	private float CLAJNOJJGCD;

	private bool ELDEKHLJLHP;

	private Vector3 PMGACAHJDFA;

	private Transform BEAMHLNIGIN;

	private Transform PICEPNMKMEA;

	private float HLKDAEKIMHA;

	private float ENIPJMNENHO;

	private bool LGHBFCEMAPJ;

	public Transform APAECJDOAIL;

	public float DMPKAGHIGIB;

	private bool CDLADPEFBDP;

	private Vector3 NHKFDOAJEIO;

	private Quaternion ICIDMMCCHEH;

	public WayPointPath LDCKAOCPHOB;

	public QuickRope2 MFMAMHLNEDB;

	private EnemyController NFILMHJGGHP;

	public float ACLINDOAODK;

	public TurretWeaponBasic EADEPGKMMJP;

	public ParticleSystem[] GPPDGDMBFPO;

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

	protected override void Awake()
	{
	}

	private void KBCOOBDNJEL(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void OnCollisionEnter(Collision JGFBDMBBPBM)
	{
	}

	public override void OnInstancied()
	{
	}

	public override void SafeStart()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public void SetWayPoint(WayPoint KFFIDHDOBPA)
	{
	}

	protected override void Update()
	{
	}

	protected float FOBNNENHNOM()
	{
		return 0f;
	}

	public Vector3 Steer()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	private void BNJGAMIDLCE()
	{
	}

	private void KDAMLHOAGJA()
	{
	}

	[PunRPC]
	private void ShowRope()
	{
	}

	private IEnumerator BAKEGLDEBJA(float EABOLCDGLAF = 5f)
	{
		return null;
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	public override void Spawn()
	{
	}

	private void OPIPLFDHABB(EnemyPointHelicopter JDCKMKEGIGC, bool AMLADFPJFMA)
	{
	}

	private void EMGDEBAIOOK()
	{
	}

	private void HLADHFMHGLJ(AIObject AGECANAKJOL, bool KGLMAPDNJJL)
	{
	}

	private void OPKLBIILGEO(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public override void DestroyPooled()
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

	public override void DoReverseAnim()
	{
	}

	[PunRPC]
	private void SetSoldierPerksRPC(int NCNDABEOPDL)
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	[CompilerGenerated]
	private void DGDJHAAGJGF()
	{
	}
}
