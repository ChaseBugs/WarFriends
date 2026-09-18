using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public abstract class Weapon : PoolableObject, TimeScaleIgnorable, IFraction
{
	public enum WeaponType : byte
	{
		Riffle,
		Grenade,
		Bazooka,
		SwatPistol,
		Minigun,
		Pistol,
		GrenadeLauncher,
		Shotgun,
		Tool,
		QBZ,
		SniperRiffle,
		SwatSMG,
		Flamethrower,
		QBZ2,
		DoubleSMG,
		Machinegun,
		Colt,
		Mortar
	}

	public delegate void ShotHit(Weapon weapon, Ammo ammo, Vector3 position, bool isNetwork, DestroyableObject destroyableObject);

	public Ammo bulletPrefab;

	public ObscuredFloat cadence = 0.5f;

	public ObscuredInt clipSize = 20;

	public ObscuredFloat reloadTime = 5f;

	public bool friendKill = true;

	public bool infiniteAmmo;

	public bool reloadableWeapon;

	public bool disableSync;

	public Transform spawnPoint;

	public ObscuredInt startingAmmmoCount;

	public bool useAiming = true;

	public bool isFake;

	public Ammo.ShotType shotType;

	public int ignoreLayersMask;

	private ObscuredInt mAmmoLeftInClip;

	private ObscuredInt mAmmoLeft;

	private AmmoSetup mAmmoSetup;

	private bool mIsReloading;

	protected float mLastShotTime;

	protected PhotonView mPhotonView;

	private float mReloadStartTime;

	public Sounds3DEnum reloadSound = Sounds3DEnum.RELOAD_ASSAULT;

	public Sounds3DEnum shotSound = Sounds3DEnum.SHOT_ASSAULT_1;

	public float soundVolume = 1f;

	public WeaponType weaponType;

	public PlayerWeapon playerWeapon { get; set; }

	public virtual int ammoLeft
	{
		get
		{
			return mAmmoLeft;
		}
		set
		{
			mAmmoLeft = value;
		}
	}

	public int ammoLeftInClip
	{
		get
		{
			return mAmmoLeftInClip;
		}
		set
		{
			mAmmoLeftInClip = value;
			mIsReloading = false;
		}
	}

	public AmmoSetup ammoSetup => mAmmoSetup ?? (mAmmoSetup = GetComponent<AmmoSetup>());

	public bool isReloading
	{
		get
		{
			if (reloadableWeapon)
			{
				return mIsReloading;
			}
			return reloadProgress < 1f && !outOfAmmo;
		}
	}

	public virtual bool willShoot
	{
		get
		{
			if (reloadableWeapon)
			{
				return hasAmmoInClip && !mIsReloading;
			}
			return hasAmmo || infiniteAmmo;
		}
	}

	public virtual bool hasAmmo => ammoLeft > 0 || infiniteAmmo;

	public bool outOfAmmo
	{
		get
		{
			if (reloadableWeapon)
			{
				bool flag = ammoLeft <= 0 && ammoLeftInClip <= 0;
				if (!flag && !mIsReloading && ammoLeftInClip <= 0)
				{
					Reload();
				}
				return flag;
			}
			return ammoLeft <= 0 && !infiniteAmmo;
		}
	}

	public virtual bool hasAmmoInClip => ammoLeftInClip > 0;

	public virtual bool hasLowAmmo => reloadableWeapon && (float)(ammoLeft + ammoLeftInClip) / (float)(int)startingAmmmoCount < Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;

	public virtual float reloadProgress
	{
		get
		{
			if (reloadableWeapon)
			{
				if (mReloadStartTime == 0f)
				{
					return 0f;
				}
				float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - mReloadStartTime) / (float)reloadTime);
				if (mIsReloading && num >= 1f)
				{
					FinishReload();
				}
				return num;
			}
			return nextShootProgress;
		}
	}

	public virtual float reloadingTimeLeft
	{
		get
		{
			if (reloadableWeapon)
			{
				if (!mIsReloading)
				{
					return 0f;
				}
				return (1f - reloadProgress) * (float)reloadTime;
			}
			return (1f - nextShootProgress) * (float)cadence;
		}
	}

	public virtual float nextShootProgress => 1f;

	public float lastShotTime => mLastShotTime;

	public Fractions fraction
	{
		get
		{
			if (owner == null)
			{
				return Fractions.None;
			}
			return owner.fraction;
		}
		set
		{
			Debug.LogError("Should not set fraction to weapon");
		}
	}

	public virtual IFraction owner { get; set; }

	public bool ignoreTimeScale { get; set; }

	public static event ShotHit OnShotHit;

	public static event Action<Weapon, Vector3> OnShotFired;

	public override void OnInstancied()
	{
		base.OnInstancied();
		ignoreLayersMask = 0;
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
	}

	public virtual Ammo Fire(Vector3 to)
	{
		if (DebugSettings.stopShooting && owner != PlayerController.currentPlayer)
		{
			return null;
		}
		Ammo ammo = null;
		if (willShoot)
		{
			ammo = Shoot(to, isNetworkCopy: false);
			if (ammo != null)
			{
				ShotNetworkCopy(to);
			}
			if (reloadableWeapon)
			{
				ammoLeftInClip--;
			}
			else
			{
				ammoLeft--;
			}
		}
		if (!hasAmmoInClip && reloadableWeapon && hasAmmo)
		{
			Reload();
		}
		return ammo;
	}

	protected virtual void ShotNetworkCopy(Vector3 to)
	{
		if (!disableSync && mPhotonView != null && mPhotonView.isMine)
		{
			mPhotonView.RPC("FireNetworkRPC", PhotonTargets.Others, to, isFake, (byte)shotType);
		}
	}

	[PunRPC]
	public virtual void FireNetworkRPC(Vector3 to, bool fake, byte type)
	{
		isFake = fake;
		shotType = (Ammo.ShotType)type;
		Shoot(to, isNetworkCopy: true);
	}

	protected virtual Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		if (Weapon.OnShotFired != null)
		{
			Weapon.OnShotFired(this, position);
		}
		mLastShotTime = TimeManager.realTimeWithoutPauses;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, shotSound, soundVolume);
		return null;
	}

	protected void Update()
	{
		if (mIsReloading && reloadProgress >= 1f)
		{
			FinishReload();
		}
	}

	private void FinishReload()
	{
		int num = Math.Min((int)clipSize - ammoLeftInClip, ammoLeft);
		ammoLeftInClip += num;
		ammoLeft -= num;
		mReloadStartTime = 0f;
		mIsReloading = false;
	}

	public void Reload()
	{
		if ((reloadableWeapon || !mIsReloading) && ammoLeft > 0)
		{
			mIsReloading = true;
			mReloadStartTime = TimeManager.realTimeWithoutPauses;
			InvokeAfterRealTime(delegate
			{
				Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, reloadSound);
			}, 0.5f);
		}
	}

	public virtual float ComputeFlyTimeToTarget(Vector3 position)
	{
		return 0f;
	}

	[PunRPC]
	public void SetBullletSpeedCoef(float coef)
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("SetBullletSpeedCoef", PhotonTargets.Others, coef);
		}
		BulletSetup bulletSetup = ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			bulletSetup.speedMultiplayer = coef;
		}
	}

	public void ReportShotHit(Ammo ammo, Vector3 position, bool isNetworkCopy, DestroyableObject destroyableObject)
	{
		bool flag = destroyableObject != null && destroyableObject.fraction != Fractions.None && destroyableObject.fraction != PlayerController.currentPlayer.fraction;
		if (!isNetworkCopy && owner == PlayerController.currentPlayer && flag)
		{
			if (Singleton<GameController>.instance.isPVP)
			{
				StatsManager.instance.matchStats.hits++;
			}
			else if (Singleton<GameController>.instance.isMission)
			{
				StatsManager.instance.matchStats.missionsHits++;
			}
		}
		if (Weapon.OnShotHit != null)
		{
			Weapon.OnShotHit(this, ammo, position, isNetworkCopy, destroyableObject);
		}
	}
}
