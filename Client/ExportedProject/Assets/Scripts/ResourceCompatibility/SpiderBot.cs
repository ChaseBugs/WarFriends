using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpiderBot : Vehicle<SpiderBotBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private enum OFFJHOILDID
	{
		Falling,
		Idle,
		Spawning,
		Shooting,
		Dieing
	}

	private sealed class HGJCNHCAFKD
	{
		public GameObject JJOEIJKGGEF;

		public UITweener.OnFinished KNJLKJEIFEL;

		internal void CMGFJHEHDGH(UITweener GDPAJADKOPD)
		{
		}

		internal void COADJAAMIME(UITweener IFKFLKDOLIJ)
		{
		}
	}

	private sealed class NCAHEIKIKOF
	{
		public SpiderBot HNNCIECPFEJ;

		public PlayerController CCKBEKGHHKH;

		public float BKPKKOJPPHE;
	}

	private sealed class PMCADCKCOCL
	{
		public int EPNGMAHENPA;

		public DestroyableObject LGFMBOJMMMB;

		public BatchedWeapon JNHKPNOHGCE;

		public NCAHEIKIKOF PAIPGOJKHMM;

		internal void GFBHHEAFOMK()
		{
		}

		internal void HOJEGJBHOLB()
		{
		}
	}

	[SerializeField]
	private DestroyableObjectMultipleParts mDestroyableObject;

	[SerializeField]
	private List<BatchedWeapon> mRockets;

	[SerializeField]
	private SpiderBotAnimator mAnimator;

	private OFFJHOILDID GGHMKMDDAPC;

	private OFFJHOILDID EJKCHGEPLLH;

	private float DIMKJOOLCHO;

	private int OAGOFDNICHO;

	private Spiderling FEGFPFACJGE;

	private SpawnPointCar KLJDLOLEAMP;

	public List<GameObject> EEECNOMFKHL;

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

	public override void OnInstancied()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	private void MNKEJLGHAGM(Vector3 MPHCJEIMBEB)
	{
	}

	private void LOIKKPKNNKM()
	{
	}

	private void DKNJINLKJOA(DestroyableObject KIHIFIBOOIM, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	[PunRPC]
	private void StartIndicatorAnimation(int EPNGMAHENPA, Vector3 MPHCJEIMBEB)
	{
	}

	public void RemoveSpiderling(Spiderling HOENDHBMLID)
	{
	}

	public override void Spawn()
	{
	}

	[PunRPC]
	private void AnimateSpawn(Vector3 GPCNPCKHKPD, Vector3 OIMMJIGPNDK, Quaternion KMPBJDNAEDB)
	{
	}

	protected override void LLGNKOCNOEI()
	{
	}

	public override void StartEnemyBehaviour()
	{
	}

	public override void DestroyPooled()
	{
	}

	public void OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	private void ANFBOFCHBPI()
	{
	}

	private void JCPBJDHJNNI()
	{
	}

	private void KLLJKOEGIIG()
	{
	}

	private bool INNBJBGCBJB()
	{
		return false;
	}

	protected override void Update()
	{
	}

	public override void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	[CompilerGenerated]
	private void OCAPPCLDMBI(UITweener GDPAJADKOPD)
	{
	}
}
