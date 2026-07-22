using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VTOL : Heli<VTOLBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	public enum OEEDNPDCCNA
	{
		MachineGuns,
		RocketLauncherSpecial
	}

	private sealed class FKNANHHNILG
	{
		public VTOL HNNCIECPFEJ;

		public GameShootableEntity.ShotTarget JFFJNCBEGDB;

		public Vector3 OIMMJIGPNDK;

		public Ammo.BICKHONNMCG DNBHJJEOFCP;
	}

	private sealed class EGLMOIGLCII
	{
		public BatchedWeapon BLNJMJAOBNM;

		public FKNANHHNILG PAIPGOJKHMM;

		internal void GFBHHEAFOMK()
		{
		}
	}

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

	[SerializeField]
	private List<DestroyableObject> mRotors;

	[SerializeField]
	private List<ParticleSystem> mRotorDamageParticles;

	[SerializeField]
	private List<BatchedWeapon> mMachineGuns;

	[SerializeField]
	private List<BatchedWeapon> mRocketLaunchersSpecial;

	private Rigidbody IEFPAMKAAFF;

	private DestroyableObjectMultipleParts AIIDCMKBFCB;

	private float HFINAFDEHPH;

	private GameShootableEntity AGPKMGLIACJ;

	private float HLLDHFLIFLE;

	private GameShootableEntity MCFJEPIMGMP;

	private Transform APAECJDOAIL;

	private bool JLLGBPOMHLJ;

	private readonly Timer OOPAOPOANJF;

	private List<GameShootableEntity.ShotTarget> BEFBIDGCPCC;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	private GameShootableEntity KMGPADEABOA
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private GameShootableEntity KGGCLBGPONL
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

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

	public override void BeforeInstancied()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	private float IBAJCPCIPLN()
	{
		return 0f;
	}

	private void PHMLCOBGELP(float BJJCGIGPKPG)
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	public override void DoReverseAnim()
	{
	}

	public override void OnInstancied()
	{
	}

	private void FixedUpdate()
	{
	}

	protected override void Update()
	{
	}

	private void GKNJMOGJKAI(OEEDNPDCCNA AEBEOCBIBFI)
	{
	}

	private void LOIKKPKNNKM()
	{
	}

	private void NHLFFFIMHOD(OEEDNPDCCNA AEBEOCBIBFI)
	{
	}

	private void KLLJKOEGIIG(OEEDNPDCCNA AEBEOCBIBFI, Vector3 GAHBNFCPNBK, GameShootableEntity.ShotTarget JFFJNCBEGDB, GameShootableEntity.ShotTarget MEHLMFOKKCJ)
	{
	}

	private Vector3[] IGENPLKPLNJ(int JODAGEAJGOD, Vector3 OIMMJIGPNDK)
	{
		return null;
	}

	protected virtual void HKCIPDNCLNB(OEEDNPDCCNA AEBEOCBIBFI)
	{
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	public override void DestroyPooled()
	{
	}

	protected override void OPNDMFKAEBL(HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	private void OnCollisionEnter(Collision JGFBDMBBPBM)
	{
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	private void DKNJINLKJOA(DestroyableObject IILHBBEDLPP, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void FBNAMJNPCME(DestroyableObject BAIADEIEOBB, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void OLGOKGNENGG(DestroyableObject BAIADEIEOBB, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	protected override SpawnPointHeli.GHLBJBMDHDB OJNEIHINONB()
	{
		return default(SpawnPointHeli.GHLBJBMDHDB);
	}

	public void PrepareAsInvader()
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	public void ScaleHealth(float NKNNJJICDDF)
	{
	}
}
