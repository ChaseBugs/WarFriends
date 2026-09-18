using System;
using UnityEngine;

public class MiniDrone : MainGameEntity
{
	public ParticleSystem fireDamage;

	public ParticleSystem sparks;

	private new bool isAlive;

	private DestroyableObject mDestroyableObject;

	private DroneSteering mDroneSteering;

	private bool mExploded;

	private PhotonView mPhotonView;

	private Transform mTransform;

	private Fractions mFraction;

	private int mHealTimer;

	private AICarTransporter mTransporterToRepair;

	public AICarTransporter transporterToRepair
	{
		get
		{
			return mTransporterToRepair;
		}
		set
		{
			mTransporterToRepair = value;
			GameShootableEntity component = GetComponent<GameShootableEntity>();
			if (component != null)
			{
				component.owner = mTransporterToRepair;
				component.isMain = false;
			}
		}
	}

	public override Fractions fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			mFraction = value;
			mPhotonView.RPC("SetFractionRPC", PhotonTargets.Others, (byte)value);
			SetUpHealthBar();
			mDestroyableObject.ChangeLayer(mFraction, isFlying: false);
		}
	}

	public override IFraction owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public override int power { get; set; }

	public WayPointPath wayPointPath { get; private set; }

	public DestroyableObject destroyableObject => mDestroyableObject;

	public float repairRatioPerSec { get; set; }

	public override event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	[PunRPC]
	private void SetFractionRPC(byte byteFraction)
	{
		mFraction = (Fractions)byteFraction;
		SetUpHealthBar();
		mDestroyableObject.ChangeLayer(mFraction, isFlying: false);
	}

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObject>();
		destroyableObject.isMetal = true;
		destroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		destroyableObject.OnDamage += DestroyableObjectOnOnDamage;
		mTransform = base.transform;
		mDroneSteering = GetComponent<DroneSteering>();
		mPhotonView = GetComponent<PhotonView>();
		mDroneSteering.ArrivedToWayPoint += DroneSteeringOnArrivedToWayPoint;
	}

	private void DroneSteeringOnArrivedToWayPoint(WayPoint wayPoint)
	{
		if (wayPoint.stayTime > 0f)
		{
			PlaySparks();
		}
	}

	[PunRPC]
	private void PlaySparks()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("PlaySparks", PhotonTargets.Others);
		}
		sparks.Play();
	}

	private void DestroyableObjectOnOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if ((double)this.destroyableObject.healthRatio < 0.4)
		{
			fireDamage.Play();
		}
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		mDroneSteering.Clear();
		mDroneSteering.FallDown();
		isAlive = false;
		if (Killed != null)
		{
			Killed(this, damageInfo);
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (!isAlive && !mExploded)
		{
			Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
			mExploded = true;
			DestroyEntity(0.2f);
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = destroyableObject.maxHealth * 0.5f;
			explosionInfo.damageAmount = destroyableObject.maxHealth * 0.05f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !mPhotonView.isMine;
			explosionInfo.deadRadius = 0.7f;
			explosionInfo.hurtRadius = 1.4f;
			explosionInfo.type = Explosion.ExplosionType.Small;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.Explode(i);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		mDroneSteering.Init();
		fireDamage.Stop();
		isAlive = true;
		StopAllCoroutines();
		mExploded = false;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, Sounds3DEnum.PredatorDeployRepairDrone);
	}

	protected override void Start()
	{
		base.Start();
		fireDamage.Stop();
	}

	public void SetWayPoint(WayPointPath path)
	{
		mDroneSteering.SetWayPoint(path.wayPoints[0], this);
		mDroneSteering.lookTarget = path.transform;
		wayPointPath = path;
	}

	protected override void Update()
	{
		base.Update();
		if (mPhotonView.isMine && (int)Time.time > mHealTimer)
		{
			mHealTimer = (int)Time.time;
			if (transporterToRepair != null)
			{
				float num = repairRatioPerSec;
				transporterToRepair.destroyableObj.Heal(transporterToRepair.destroyableObj.maxHealth * num, isNetworkCopy: false);
			}
		}
	}

	private void SetUpHealthBar()
	{
		destroyableObject.healthbarColor = ((PlayerController.currentPlayer.fraction == fraction) ? Color.green : Color.red);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mDroneSteering.Clear();
	}
}
