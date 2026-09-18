using System;
using UnityEngine;

public class MineAmmo : PhysicalAmmo
{
	private float mBlinkInterval;

	private float mLastSyncTime;

	public HudObjectIndicator hudObjectIndicator;

	private bool mBlinkOnOff;

	private float mBlinkingTime;

	private bool mExploded;

	private MineAmmoSetup mSetup;

	public MeshRenderer mineModel;

	public PhysicsEventsListener trigger;

	private AudioSource mAudioSource;

	private bool mBeep;

	public CardIconIndicator cardIconIndicator { get; private set; }

	public float blinkInterval
	{
		get
		{
			return mBlinkInterval;
		}
		set
		{
			if (mBlinkInterval != value)
			{
				mBlinkInterval = value;
				if (Time.realtimeSinceStartup > mLastSyncTime + 1f)
				{
					photonView.RPC("SetBlinkIntervalRPC", PhotonTargets.Others, value);
					mLastSyncTime = Time.realtimeSinceStartup;
				}
			}
		}
	}

	public bool beep
	{
		get
		{
			return mBeep;
		}
		set
		{
			if (mBeep != value)
			{
				mBeep = value;
				photonView.RPC("SetBeepRPC", PhotonTargets.Others, value);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		photonView = GetComponent<PhotonView>();
		PhysicsEventsListener physicsEventsListener = trigger;
		physicsEventsListener.onTriggerEnter = (Action<Collider>)Delegate.Combine(physicsEventsListener.onTriggerEnter, new Action<Collider>(TriggerOnTriggerEnter));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.hudObjectIndicator = hudObjectIndicator;
		photonView.RebuildCache();
		mAudioSource = GetComponent<AudioSource>();
	}

	private void TriggerOnTriggerEnter(Collider other)
	{
		if (photonView.isMine && !mExploded && TagsAndLayers.IsDestroyableObject(other.transform.gameObject))
		{
			DestroyableObject component = other.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != fraction && !component.isMetal)
			{
				Boom();
			}
		}
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		base.transform.position = to;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		mExploded = false;
		mBlinkInterval = 0.25f;
		mBeep = false;
		if (hudObjectIndicator != null)
		{
			hudObjectIndicator.Show(value: false);
		}
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		MineAmmoSetup mineAmmoSetup = setup as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			mSetup = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to mine");
		}
	}

	protected void Update()
	{
		if (mExploded)
		{
			return;
		}
		Material material = mineModel.materials[1];
		mBlinkingTime += ((!mBlinkOnOff) ? ((0f - Time.deltaTime) * 0.5f) : Time.deltaTime);
		if ((mBlinkingTime > blinkInterval && mBlinkOnOff) || (mBlinkingTime < 0f && !mBlinkOnOff))
		{
			mBlinkOnOff = !mBlinkOnOff;
			if (!mBlinkOnOff && mBeep)
			{
				Singleton<SoundsManager3D>.instance.Play(mAudioSource, mAudioSource.clip);
			}
		}
		Color color = Color.Lerp(Color.black, new Color(1f, 0.5f, 0.5f, 1f), mBlinkingTime / blinkInterval);
		material.SetColor("_TintColor", color);
	}

	private void Explode()
	{
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = base.transform.position;
		explosionInfo.explodeDamage = mSetup.explodeDamageAmount;
		explosionInfo.damageAmount = mSetup.damageAmount;
		explosionInfo.owner = weapon.owner;
		explosionInfo.weapon = weapon;
		explosionInfo.deadRadius = mSetup.deadRadius;
		explosionInfo.hurtRadius = mSetup.hurtRadius;
		explosionInfo.exposionCoef = mSetup.exposionCoef;
		explosionInfo.additionalUpForce = mSetup.additionalUpForce;
		explosionInfo.isNetworkCopy = isNetworkCopy;
		explosionInfo.playerRadiusCoef = 0.9f;
		Explosion.ExplosionInfo i = explosionInfo;
		Explosion.MissileExplode(i);
	}

	public void Boom()
	{
		if (!mExploded)
		{
			mExploded = true;
			DestroyPooled(0.4f);
			weapon.ReportShotHit(this, base.transform.position, !photonView.isMine, null);
			Explode();
			photonView.RPC("SendExplode", PhotonTargets.Others);
		}
	}

	[PunRPC]
	public void SendExplode()
	{
		if (!mExploded)
		{
			mExploded = true;
			Explode();
			DestroyPooled(0.4f);
			weapon.ReportShotHit(this, base.transform.position, !photonView.isMine, null);
		}
	}

	[PunRPC]
	protected void SetBlinkIntervalRPC(float value)
	{
		mBlinkInterval = value;
	}

	[PunRPC]
	protected void SetBeepRPC(bool value)
	{
		mBeep = value;
	}
}
