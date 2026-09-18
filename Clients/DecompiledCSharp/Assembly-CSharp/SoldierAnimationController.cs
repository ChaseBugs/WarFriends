using UnityEngine;

public class SoldierAnimationController : Core_BaseScript, TimeScaleIgnorable
{
	private enum CoverSide
	{
		Left,
		Right
	}

	public float currentUpperBodyRotation;

	public bool disableLookRot;

	public Transform mTransform;

	public Transform rootBone;

	public Transform rootBoneInner;

	public Transform upperBody;

	public Transform leftPalm;

	private Animation mAnimation;

	private CoverSide mCoverSide;

	private CoverSide mCoverSideBazooka;

	private bool mDontShootFromCover;

	private bool mEnabled;

	private float mHideToCoverAfter;

	private bool mIsDead;

	private bool mLookAtRotation;

	private bool mLookBack = true;

	private float mLookBackTime;

	private float mLookBackTimeUpperBody;

	private float mPlayBazookaShoot;

	private Vector3 mRootPos;

	private Vector3 mRootPosInner;

	private Quaternion mRootRot;

	private Quaternion mRootRotInner;

	private float mStopShootAdditive;

	private Quaternion mTargetRot = Quaternion.identity;

	private float mTimeToHideFromSideShoot;

	private float mTimeToHideToCrawl;

	private float mTimeStopStandShooting;

	private float mTimeToHideToSwatShield;

	private bool mUpperBodyRotation;

	private float mUpperBodyTargetRotation;

	private Weapon.WeaponType mWeaponType;

	private string lookAnimationNameLeft;

	private string fireAnimationNameLeft;

	private string coverBackAnimationNameLeft;

	private string lookAnimationNameRight;

	private string fireAnimationNameRight;

	private string coverBackAnimationNameRight;

	private bool mInScreen = true;

	private bool mForceInScreen;

	private Vector3 mLookDir;

	public float uncoverLength => mAnimation["player_look_right3"].length;

	public float swatShieldUncoverLength => mAnimation["shield_unhide"].length;

	public bool lookBack
	{
		get
		{
			return mLookBack;
		}
		set
		{
			mLookBack = value;
		}
	}

	public Vector3 aimingDir
	{
		get
		{
			if (mLookBack)
			{
				return -mLookDir;
			}
			return mLookDir;
		}
	}

	public bool isSitting => mAnimation.IsPlaying("buggy_idle");

	public bool isIdle => mAnimation.IsPlaying("idle") || mAnimation.IsPlaying("shield_idle") || mAnimation.IsPlaying("shotgunner_idle") || mAnimation.IsPlaying("bazooka_idle") || mAnimation.IsPlaying("pistol_idle") || mAnimation.IsPlaying("grenadelauncher_idle") || mAnimation.IsPlaying("qbz_idle") || mAnimation.IsPlaying("qbz2_idle") || mAnimation.IsPlaying("sniper_idle") || mAnimation.IsPlaying("grenade_idle") || mAnimation.IsPlaying("SMG_idle");

	public bool isRunning
	{
		get
		{
			foreach (AnimationState item in mAnimation)
			{
				if (item.enabled && (item.name.StartsWith("run") || item.name.EndsWith("run")))
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsShooting => mAnimation.IsPlaying(fireAnimationNameLeft) || mAnimation.IsPlaying(fireAnimationNameRight);

	public bool isHiding => mAnimation.IsPlaying(coverBackAnimationNameRight) || mAnimation.IsPlaying(coverBackAnimationNameLeft);

	public float hiddingTime
	{
		get
		{
			if (mAnimation.IsPlaying(coverBackAnimationNameRight))
			{
				float length = mAnimation[lookAnimationNameRight].length;
				length /= mAnimation[lookAnimationNameRight].speed;
				return length * mAnimation[coverBackAnimationNameRight].normalizedTime;
			}
			if (mAnimation.IsPlaying(coverBackAnimationNameLeft))
			{
				float length2 = mAnimation[lookAnimationNameLeft].length;
				length2 /= mAnimation[lookAnimationNameLeft].speed;
				return length2 * mAnimation[coverBackAnimationNameLeft].normalizedTime;
			}
			return 1f;
		}
	}

	public bool ignoreTimeScale { get; set; }

	public float mortarBuildTime => mAnimation["mortar_down"].length;

	public float mortarShotTime => mAnimation["mortar_hide"].length;

	public float mortarStandTime => mAnimation["mortar_up"].length;

	public float GetStandPhase0Length(Weapon.WeaponType weaponType)
	{
		string standAnimationName = GetStandAnimationName(weaponType, 0);
		string standAnimationName2 = GetStandAnimationName(weaponType, 1);
		string standAnimationName3 = GetStandAnimationName(weaponType, 2);
		if (mAnimation.IsPlaying(standAnimationName3))
		{
			return 0f;
		}
		if (mAnimation.IsPlaying(standAnimationName2))
		{
			return 0f;
		}
		return mAnimation[standAnimationName].length;
	}

	public float GetStandUpFromCrawlLength(Weapon.WeaponType weaponType)
	{
		string crawlName = GetCrawlName(weaponType, 0);
		return mAnimation[crawlName].length;
	}

	protected override void Awake()
	{
		base.Awake();
		mAnimation = GetComponent<Animation>();
		mTargetRot = Quaternion.identity;
		if (rootBone != null)
		{
			mRootPos = rootBone.transform.localPosition;
			mRootRot = rootBone.transform.localRotation;
		}
		if (rootBoneInner != null)
		{
			mRootPosInner = rootBoneInner.transform.localPosition;
			mRootRotInner = rootBoneInner.transform.localRotation;
		}
		mLookAtRotation = true;
		mTransform = base.transform;
	}

	protected override void Start()
	{
		base.Start();
		mAnimation["shootAdditive"].layer = 4;
		mAnimation["shootAdditive"].blendMode = AnimationBlendMode.Blend;
		mAnimation["shootAdditive"].wrapMode = WrapMode.ClampForever;
		mAnimation["shootAdditive"].AddMixingTransform(upperBody);
	}

	private void CheckIfInScreen()
	{
		if (!mEnabled || mForceInScreen)
		{
			return;
		}
		Vector3 vector = Singleton<GameCamera>.instance.camera.WorldToViewportPoint(mTransform.position);
		if ((double)vector.x < -0.1 || (double)vector.x > 1.1 || (double)vector.y < -0.1 || (double)vector.y > 1.1)
		{
			if (mInScreen)
			{
				mInScreen = false;
				mAnimation.enabled = false;
			}
		}
		else if (!mInScreen)
		{
			mInScreen = true;
			mAnimation.enabled = true;
		}
	}

	private void OnEnable()
	{
		mInScreen = true;
		mAnimation.enabled = true;
		CheckIfInScreen();
	}

	protected void Update()
	{
		CheckIfInScreen();
		if (mIsDead || !mEnabled)
		{
			return;
		}
		if (mCoverSide == CoverSide.Right)
		{
			if (Time.time > mTimeToHideFromSideShoot && mTimeToHideFromSideShoot != 0f)
			{
				mTimeToHideFromSideShoot = 0f;
				mAnimation[coverBackAnimationNameRight].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				mAnimation.Play(coverBackAnimationNameRight);
				Idle(mWeaponType, playQueued: true);
			}
		}
		else if (Time.time > mTimeToHideFromSideShoot && mTimeToHideFromSideShoot != 0f)
		{
			mTimeToHideFromSideShoot = 0f;
			mAnimation[coverBackAnimationNameLeft].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
			mAnimation.Play(coverBackAnimationNameLeft);
			Idle(mWeaponType, playQueued: true);
		}
		if (Time.time > mTimeToHideToCrawl && mTimeToHideToCrawl != 0f)
		{
			mTimeToHideToCrawl = 0f;
			mAnimation.Play("stand_up_crawl");
		}
		if (Time.time > mTimeStopStandShooting && mTimeStopStandShooting != 0f)
		{
			mTimeStopStandShooting = 0f;
			mAnimation.Play("colt_shooting_stop");
		}
		if (Time.time > mTimeToHideToSwatShield && mTimeToHideToSwatShield != 0f)
		{
			mTimeToHideToSwatShield = 0f;
			mAnimation.Play("shield_hide");
		}
		if (Time.time > mStopShootAdditive && mStopShootAdditive != 0f)
		{
			mAnimation["shootAdditive"].weight -= Time.deltaTime * 3f;
			if (mAnimation["shootAdditive"].weight < 0.1f)
			{
				mAnimation["shootAdditive"].weight = 0f;
				mAnimation["shootAdditive"].enabled = false;
				mStopShootAdditive = 0f;
			}
		}
		if (Time.time > mPlayBazookaShoot && mPlayBazookaShoot != 0f)
		{
			mPlayBazookaShoot = 0f;
			if (mCoverSideBazooka == CoverSide.Right)
			{
				mAnimation.Play("bazooka_shoot_right");
				mAnimation["bazooka_shoot_right"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				mAnimation.CrossFadeQueued("bazooka_idle");
			}
			else
			{
				mAnimation.Play("bazooka_shoot_left");
				mAnimation["bazooka_shoot_left"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				mAnimation.CrossFadeQueued("bazooka_idle");
			}
		}
		if (mLookAtRotation && !disableLookRot)
		{
			if (mLookDir.sqrMagnitude > 0f)
			{
				mTargetRot = Quaternion.LookRotation(mLookDir) * Quaternion.Inverse(mTransform.parent.rotation);
			}
			mTransform.localRotation = Quaternion.Slerp(mTransform.localRotation, mTargetRot, TimeManager.GetTimeScaledInterval(Time.deltaTime, ignoreTimeScale: true) * 10f);
			if (Time.time > mLookBackTime && mLookBackTime != 0f)
			{
				mTargetRot = Quaternion.identity;
				mLookDir = Vector3.zero;
			}
		}
	}

	private void LateUpdate()
	{
		if (!mUpperBodyRotation || disableLookRot)
		{
			return;
		}
		currentUpperBodyRotation = Mathf.Lerp(currentUpperBodyRotation, mUpperBodyTargetRotation, TimeManager.GetTimeScaledInterval(Time.deltaTime, ignoreTimeScale: true) * 12f);
		if (Mathf.Abs(currentUpperBodyRotation) > 1f)
		{
			upperBody.localRotation = Quaternion.AngleAxis(currentUpperBodyRotation, Vector3.right);
			if (Time.time > mLookBackTimeUpperBody && mLookBackTimeUpperBody != 0f)
			{
				mUpperBodyTargetRotation = 0f;
			}
		}
	}

	public void Pause()
	{
		mAnimation.enabled = false;
		mEnabled = false;
	}

	public void Resume()
	{
		mAnimation.enabled = true;
		mEnabled = true;
	}

	public void Stop()
	{
		mAnimation.Stop();
		mEnabled = false;
		mAnimation.enabled = false;
	}

	public void Enable()
	{
		mAnimation.enabled = true;
		mAnimation.Play();
	}

	public void Reset()
	{
		mIsDead = false;
		mTimeToHideToCrawl = 0f;
		mTimeToHideFromSideShoot = 0f;
		mTimeToHideToSwatShield = 0f;
		mTimeStopStandShooting = 0f;
		mAnimation.Stop();
		mLookDir = Vector3.zero;
		mInScreen = true;
		mAnimation.enabled = true;
		mForceInScreen = false;
		mAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		CheckIfInScreen();
		mEnabled = true;
		if (rootBone != null)
		{
			rootBone.localPosition = mRootPos;
			rootBone.localRotation = mRootRot;
		}
		if (rootBoneInner != null)
		{
			rootBoneInner.localPosition = mRootPosInner;
			rootBoneInner.localRotation = mRootRotInner;
		}
	}

	public void ForceInScreen()
	{
		mForceInScreen = true;
		mAnimation.enabled = true;
		mInScreen = true;
		mAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
	}

	private void ResetTimers()
	{
		mTimeToHideToCrawl = 0f;
		mTimeToHideFromSideShoot = 0f;
		mTimeToHideToSwatShield = 0f;
		mTimeStopStandShooting = 0f;
	}

	public void Warp()
	{
		ResetTimers();
		mAnimation.CrossFade("warp_movement");
	}

	public void WarpIdle()
	{
		ResetTimers();
		mAnimation.CrossFade("warp_idle");
	}

	public void Walk(Weapon.WeaponType type)
	{
		ResetTimers();
		switch (type)
		{
		case Weapon.WeaponType.Bazooka:
			mAnimation.CrossFade("bazooka_run");
			break;
		case Weapon.WeaponType.SwatPistol:
		case Weapon.WeaponType.SwatSMG:
			mAnimation.CrossFade("shield_run");
			break;
		case Weapon.WeaponType.Minigun:
			mAnimation.CrossFade("minigun_run");
			break;
		case Weapon.WeaponType.Pistol:
			mAnimation.CrossFade("pistol_run");
			break;
		case Weapon.WeaponType.Grenade:
			mAnimation.CrossFade("grenade_run");
			break;
		case Weapon.WeaponType.GrenadeLauncher:
			mAnimation.CrossFade("run_grenadelauncher");
			break;
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.Machinegun:
			mAnimation.CrossFade("shotgunner_run");
			break;
		case Weapon.WeaponType.QBZ:
			mAnimation.CrossFade("qbz_run");
			break;
		case Weapon.WeaponType.QBZ2:
			mAnimation.CrossFade("qbz2_run");
			break;
		case Weapon.WeaponType.SniperRiffle:
			mAnimation.CrossFade("sniper_run");
			break;
		case Weapon.WeaponType.Tool:
			mAnimation.CrossFade("engineer_run");
			break;
		case Weapon.WeaponType.Flamethrower:
			mAnimation.CrossFade("flamethrower_run");
			break;
		case Weapon.WeaponType.DoubleSMG:
			mAnimation.CrossFade("SMG_run");
			break;
		case Weapon.WeaponType.Colt:
			mAnimation.CrossFade("colt_run", 0.2f);
			break;
		case Weapon.WeaponType.Mortar:
			mAnimation.CrossFade("mortar_run", 0.2f);
			break;
		default:
			mAnimation.CrossFade("run");
			break;
		}
	}

	public void BazookaWalk()
	{
		mTimeToHideToCrawl = 0f;
		mTimeToHideFromSideShoot = 0f;
	}

	public void ShotFromCover(bool right, float animSpeed, float hideAfter, bool ignoreTimeScale, bool dontShoot, bool tryHide, Weapon.WeaponType weaponType)
	{
		mDontShootFromCover = dontShoot;
		ShotFromCover(right, animSpeed, hideAfter, ignoreTimeScale, weaponType);
		mHideToCoverAfter = 0f;
		if (!tryHide)
		{
			mTimeToHideFromSideShoot = 0f;
		}
	}

	public void ShotFromCover(bool right, float animSpeed, float hideAfter, bool ignoreTimeScale, Weapon.WeaponType weaponType)
	{
		mWeaponType = weaponType;
		this.ignoreTimeScale = ignoreTimeScale;
		mHideToCoverAfter = TimeManager.GetTimeScaledInterval(hideAfter, ignoreTimeScale);
		if (!mIsDead)
		{
			float timeScaledSpeed = TimeManager.GetTimeScaledSpeed(animSpeed, ignoreTimeScale);
			ShotFromCover((!right) ? CoverSide.Right : CoverSide.Left, weaponType, timeScaledSpeed);
		}
	}

	public void ThrowGrenadeFromCover(bool right, bool ignoreTimescale)
	{
		ignoreTimeScale = ignoreTimescale;
		if (!right)
		{
			ThrowGrenadeFromCoverRight();
		}
		else
		{
			ThrowGrenadeFromCoverLeft();
		}
	}

	public void ShootFromBazoka(bool right, bool ignoreTimeScale, float shootAfter = 0.7f)
	{
		float timeScaledSpeed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		this.ignoreTimeScale = ignoreTimeScale;
		if (right)
		{
			mCoverSideBazooka = CoverSide.Right;
			mAnimation["bazooka_uncover_right"].speed = timeScaledSpeed;
			mAnimation.CrossFade("bazooka_uncover_right", 0.1f);
			mAnimation["bazooka_uncover_right"].speed = timeScaledSpeed;
		}
		else
		{
			mCoverSideBazooka = CoverSide.Left;
			mAnimation["bazooka_uncover_left"].speed = timeScaledSpeed;
			mAnimation.CrossFade("bazooka_uncover_left", 0.1f);
			mAnimation["bazooka_uncover_left"].speed = timeScaledSpeed;
		}
		mPlayBazookaShoot = Time.time + TimeManager.GetTimeScaledInterval(shootAfter, ignoreTimeScale);
	}

	public void ShootFromBazokaWalk()
	{
		mAnimation.CrossFade("bazooka_shot_run");
		mAnimation.CrossFadeQueued("bazooka_run");
	}

	public void ShootFromBazokaCrawl()
	{
		mAnimation.CrossFade("bazooka_shot_barrier");
	}

	public void ThrowGrenadeFromCrawl()
	{
		mAnimation["throw_grenade_up"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		mAnimation["throw_grenade_up"].time = 0f;
		mAnimation.CrossFade("throw_grenade_up");
	}

	private void ThrowGrenadeFromCoverRight()
	{
		mAnimation["throw_grenade_right"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		mAnimation["throw_grenade_right"].time = 0f;
		mAnimation.CrossFade("throw_grenade_right");
		mAnimation.PlayQueued("idle");
	}

	private void ThrowGrenadeFromCoverLeft()
	{
		mAnimation["throw_grenade_left"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		mAnimation["throw_grenade_left"].time = 0f;
		mAnimation.CrossFade("throw_grenade_left");
		mAnimation.PlayQueued("idle");
	}

	private void ShotFromCover(CoverSide side, Weapon.WeaponType weaponType, float speed)
	{
		if (mIsDead)
		{
			return;
		}
		mStopShootAdditive = Time.time;
		mCoverSide = side;
		mTimeToHideFromSideShoot = Time.time + mHideToCoverAfter;
		SetWeaponType(weaponType);
		string lookAnimationName = GetLookAnimationName(weaponType, side, 0);
		string lookAnimationName2 = GetLookAnimationName(weaponType, side, 1);
		string lookAnimationName3 = GetLookAnimationName(weaponType, side, 2);
		mAnimation[lookAnimationName].speed = speed;
		mAnimation[lookAnimationName2].speed = 1f;
		if (mAnimation.IsPlaying(lookAnimationName))
		{
			return;
		}
		if (mAnimation.IsPlaying(lookAnimationName2))
		{
			mAnimation[lookAnimationName2].normalizedTime = 0f;
			mAnimation.Play(lookAnimationName2);
			return;
		}
		if (mAnimation.IsPlaying(lookAnimationName3))
		{
			mAnimation[lookAnimationName].normalizedTime = 1f - mAnimation[lookAnimationName3].normalizedTime;
			mAnimation.Play(lookAnimationName);
			mAnimation.PlayQueued(lookAnimationName2);
			return;
		}
		mAnimation.CrossFade(lookAnimationName, 0.02f);
		AnimationState animationState = mAnimation.PlayQueued(lookAnimationName2);
		if (mDontShootFromCover)
		{
			animationState.normalizedTime = 1f;
		}
	}

	public void ShootFromSwatShield(float hideAfter, float shotSpeed)
	{
		if (mIsDead)
		{
			return;
		}
		mTimeToHideToSwatShield = Time.time + hideAfter;
		if (!mAnimation.IsPlaying("shield_unhide"))
		{
			if (mAnimation.IsPlaying("shield_shot"))
			{
				mAnimation["shield_shot"].normalizedTime = 0f;
				mAnimation.Play("shield_shot");
				mAnimation.PlayQueued("shield_idle");
			}
			else if (mAnimation.IsPlaying("shield_hide"))
			{
				mAnimation["shield_unhide"].normalizedTime = 1f - mAnimation["shield_hide"].normalizedTime;
				mAnimation.Play("shield_unhide");
				mAnimation.PlayQueued("shield_shot");
				mAnimation.PlayQueued("shield_idle");
			}
			else
			{
				mAnimation.Play("shield_unhide");
				AnimationState animationState = mAnimation.PlayQueued("shield_shot");
				animationState.speed = shotSpeed;
				mAnimation.PlayQueued("shield_idle");
			}
		}
	}

	public void StartFlying()
	{
		mAnimation.CrossFade("flight_start_jetpack_elite");
		mAnimation.PlayQueued("flight_forward_jetpack_elite");
	}

	public void Repair()
	{
		mAnimation.CrossFade("engineer_repair");
	}

	public float StandShootLength(Weapon.WeaponType weaponType)
	{
		float speed;
		string shotStandName = GetShotStandName(weaponType, out speed);
		return mAnimation[shotStandName].length;
	}

	private string GetShotStandName(Weapon.WeaponType weaponType, out float speed)
	{
		speed = 1f;
		switch (weaponType)
		{
		case Weapon.WeaponType.Minigun:
			return "minigun_shot";
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.Machinegun:
			return "shotgunner_shot_loop";
		case Weapon.WeaponType.DoubleSMG:
			return "commando_shooting";
		case Weapon.WeaponType.Colt:
			return "colt_shooting_loop";
		case Weapon.WeaponType.Flamethrower:
			return "flamethrower_shot_loop";
		default:
			speed = 0.5f;
			return "rifle_shot_loop";
		}
	}

	public void ShootStandNew(Weapon.WeaponType type, float shotSpeed, float hideAfter)
	{
		if (mIsDead)
		{
			return;
		}
		string standAnimationName = GetStandAnimationName(type, 0);
		string standAnimationName2 = GetStandAnimationName(type, 1);
		string standAnimationName3 = GetStandAnimationName(type, 2);
		mTimeStopStandShooting = Time.time + hideAfter;
		mTimeToHideToCrawl = 0f;
		if (!mAnimation.IsPlaying(standAnimationName))
		{
			if (mAnimation.IsPlaying(standAnimationName2))
			{
				mAnimation[standAnimationName2].normalizedTime = 0f;
				mAnimation[standAnimationName2].wrapMode = WrapMode.ClampForever;
				mAnimation.Play(standAnimationName2);
				return;
			}
			float num = ((!mAnimation.IsPlaying(standAnimationName3)) ? 1f : Mathf.Clamp01(mAnimation[standAnimationName3].normalizedTime));
			mAnimation[standAnimationName].normalizedTime = 1f - num;
			mAnimation.CrossFade(standAnimationName, 0.05f);
			mAnimation[standAnimationName2].wrapMode = WrapMode.ClampForever;
			AnimationState animationState = mAnimation.PlayQueued(standAnimationName2);
			animationState.speed = shotSpeed;
		}
	}

	public void ShootStand(Weapon.WeaponType weaponType)
	{
		float speed;
		string shotStandName = GetShotStandName(weaponType, out speed);
		AnimationState animationState = mAnimation[shotStandName];
		animationState.speed = speed;
		animationState.wrapMode = WrapMode.Once;
		if (mAnimation.IsPlaying(shotStandName))
		{
			if (animationState.wrapMode == WrapMode.Once)
			{
				animationState.normalizedTime = 0f;
			}
			mAnimation.Play(shotStandName);
			Idle(weaponType, playQueued: true);
		}
		else
		{
			mAnimation.CrossFade(shotStandName, 0.1f);
			Idle(weaponType, playQueued: true);
			mTimeToHideToCrawl = 0f;
		}
	}

	public void ShotFly()
	{
		mAnimation.Play("shot_jetpack_elite");
		mAnimation.PlayQueued("flight_forward_jetpack_elite");
	}

	private string GetCrawlName(Weapon.WeaponType weapon, int phase)
	{
		return phase switch
		{
			0 => "stand_up_begin", 
			1 => "rifle_shot_loop", 
			2 => "stand_up_crawl", 
			_ => string.Empty, 
		};
	}

	private string GetStandAnimationName(Weapon.WeaponType weapon, int phase)
	{
		float speed;
		return phase switch
		{
			0 => "colt_shooting_start", 
			1 => GetShotStandName(weapon, out speed), 
			2 => "colt_shooting_stop", 
			_ => string.Empty, 
		};
	}

	public void ShootFromCrawl(float hideAfter, float shotSpeed, Weapon.WeaponType type)
	{
		if (mIsDead)
		{
			return;
		}
		string crawlName = GetCrawlName(type, 0);
		string crawlName2 = GetCrawlName(type, 1);
		string crawlName3 = GetCrawlName(type, 2);
		mTimeToHideToCrawl = Time.time + hideAfter;
		if (!mAnimation.IsPlaying(crawlName))
		{
			if (mAnimation.IsPlaying(crawlName2))
			{
				mAnimation[crawlName2].normalizedTime = 0f;
				mAnimation.Play(crawlName2);
				return;
			}
			float num = ((!mAnimation.IsPlaying(crawlName3)) ? 1f : Mathf.Clamp01(mAnimation[crawlName3].normalizedTime));
			mAnimation[crawlName].normalizedTime = 1f - num;
			mAnimation.CrossFade(crawlName, 0.05f);
			mAnimation[crawlName2].wrapMode = WrapMode.ClampForever;
			AnimationState animationState = mAnimation.PlayQueued(crawlName2);
			animationState.speed = shotSpeed;
		}
	}

	public void ShootStandAdditive(float hideAfter, bool hide = true)
	{
		if (!mIsDead)
		{
			mAnimation.CrossFade("shootAdditive", TimeManager.GetTimeScaledInterval(0.08f, ignoreTimeScale));
			mStopShootAdditive = Time.time + TimeManager.GetTimeScaledInterval(hideAfter, ignoreTimeScale);
			if (!hide)
			{
				mStopShootAdditive = 0f;
			}
		}
	}

	public void Reload(Weapon.WeaponType type)
	{
		switch (type)
		{
		case Weapon.WeaponType.Bazooka:
			mAnimation.CrossFade("bazooka_reload");
			break;
		case Weapon.WeaponType.Shotgun:
			mAnimation.CrossFade("shotgun_reload");
			break;
		case Weapon.WeaponType.Machinegun:
			mAnimation.CrossFade("machinegn_reload");
			break;
		case Weapon.WeaponType.QBZ:
			mAnimation.CrossFade("qbz_reload");
			break;
		case Weapon.WeaponType.QBZ2:
			mAnimation.CrossFade("qbz2_reload");
			break;
		case Weapon.WeaponType.Pistol:
			mAnimation.CrossFade("reload_pistol");
			break;
		case Weapon.WeaponType.SniperRiffle:
			mAnimation.CrossFade("sniper_reload");
			break;
		case Weapon.WeaponType.GrenadeLauncher:
			mAnimation.CrossFade("reload_grenadelauncher");
			break;
		case Weapon.WeaponType.Grenade:
			mAnimation.CrossFade("grenade_reload");
			break;
		default:
			mAnimation.CrossFade("reload_fast_01");
			break;
		}
		Idle(type, playQueued: true);
	}

	private string GetIdleName(Weapon.WeaponType type)
	{
		switch (type)
		{
		case Weapon.WeaponType.Bazooka:
			return "bazooka_idle";
		case Weapon.WeaponType.Grenade:
			return "grenade_idle";
		case Weapon.WeaponType.SwatPistol:
		case Weapon.WeaponType.SwatSMG:
			return "shield_idle";
		case Weapon.WeaponType.Pistol:
			return "pistol_idle";
		case Weapon.WeaponType.Minigun:
			return "minigun_idle";
		case Weapon.WeaponType.GrenadeLauncher:
			return "grenadelauncher_idle";
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.Machinegun:
			return "shotgunner_idle";
		case Weapon.WeaponType.Tool:
			return "engineer_idle";
		case Weapon.WeaponType.QBZ:
			return "qbz_idle";
		case Weapon.WeaponType.QBZ2:
			return "qbz2_idle";
		case Weapon.WeaponType.SniperRiffle:
			return "sniper_idle";
		case Weapon.WeaponType.Flamethrower:
			return "flamethrower_idle";
		case Weapon.WeaponType.DoubleSMG:
			return "SMG_idle";
		case Weapon.WeaponType.Colt:
			return "colt_idle01";
		case Weapon.WeaponType.Mortar:
			return "mortar_idle_standing";
		default:
			return "idle";
		}
	}

	public void SampleIdle(Weapon.WeaponType type, float time = 0f)
	{
		SamplemAnimation(GetIdleName(type), time);
	}

	public bool IsIdle(Weapon.WeaponType type, out float time)
	{
		string idleName = GetIdleName(type);
		bool result = mAnimation.IsPlaying(idleName);
		time = mAnimation[idleName].normalizedTime;
		return result;
	}

	public void Idle(Weapon.WeaponType type, bool playQueued = false)
	{
		mTimeToHideToCrawl = 0f;
		mTimeToHideFromSideShoot = 0f;
		mTimeToHideToSwatShield = 0f;
		mPlayBazookaShoot = 0f;
		string idleName = GetIdleName(type);
		if (playQueued)
		{
			mAnimation.CrossFadeQueued(idleName);
		}
		else
		{
			mAnimation.CrossFade(idleName);
		}
	}

	public void SetIdle(Weapon.WeaponType type)
	{
		mTimeToHideToCrawl = 0f;
		mTimeToHideFromSideShoot = 0f;
		mTimeToHideToSwatShield = 0f;
		mPlayBazookaShoot = 0f;
		string idleName = GetIdleName(type);
		mAnimation.Stop();
		SamplemAnimation(idleName, 0f);
	}

	public bool IsPlaying()
	{
		return mAnimation.enabled && mAnimation.isPlaying;
	}

	public void IdleBazooka()
	{
		mAnimation.CrossFade("bazooka_idle");
	}

	public void Crawl()
	{
		mAnimation.CrossFade("stand_up_crawl");
	}

	public void RopeSlide()
	{
		mAnimation.CrossFade("helicopter_jump_pose");
	}

	public void BazookaCrawl()
	{
		mAnimation.CrossFade("bazooka_crawl");
	}

	public void SampleStand()
	{
		SamplemAnimation("rifle_shot_loop", 0f);
	}

	public void SampleDead()
	{
		SamplemAnimation("bazooka_reload", 0.1f);
	}

	public void SetUpperBodyRot(float value)
	{
		mUpperBodyRotation = true;
		mUpperBodyTargetRotation = value;
		currentUpperBodyRotation = value;
		if (Mathf.Abs(value) < 1f)
		{
			mUpperBodyRotation = false;
		}
		mLookBackTimeUpperBody = 0f;
	}

	public void LookAt(Vector3 direction, float lookBackTime = 0.45f)
	{
		mLookAtRotation = true;
		mLookDir = ((!mLookBack) ? direction : (-direction));
		mTargetRot = Quaternion.LookRotation(mLookDir) * Quaternion.Inverse(mTransform.parent.rotation);
		mLookBackTime = Time.time + TimeManager.GetTimeScaledInterval((!mLookBack) ? 0.5f : lookBackTime, ignoreTimeScale);
	}

	public void LookAtUpperBody(Vector3 direction, float time = 0.5f)
	{
		mUpperBodyRotation = true;
		mLookBackTimeUpperBody = Time.time + TimeManager.GetTimeScaledInterval(0.25f, ignoreTimeScale);
		mUpperBodyTargetRotation = GeometryTools.AngleSigned(direction, mTransform.parent.forward, Vector3.up);
		if (mUpperBodyTargetRotation > 70f)
		{
			float num = mUpperBodyTargetRotation - 70f;
			mLookAtRotation = true;
			mTargetRot = Quaternion.AngleAxis(0f - num, Vector3.up);
			mLookBackTime = Time.time + TimeManager.GetTimeScaledInterval((!mLookBack) ? time : (time * 0.5f), ignoreTimeScale);
			mUpperBodyTargetRotation = 70f;
		}
		if (mUpperBodyTargetRotation < -70f)
		{
			float num2 = mUpperBodyTargetRotation + 70f;
			mLookAtRotation = true;
			mTargetRot = Quaternion.AngleAxis(0f - num2, Vector3.up);
			mLookBackTime = Time.time + TimeManager.GetTimeScaledInterval((!mLookBack) ? time : (time * 0.5f), ignoreTimeScale);
			mUpperBodyTargetRotation = -70f;
		}
	}

	public void SetWeaponType(Weapon.WeaponType weaponType)
	{
		mWeaponType = weaponType;
		lookAnimationNameLeft = GetLookAnimationName(weaponType, CoverSide.Left, 0);
		fireAnimationNameLeft = GetLookAnimationName(weaponType, CoverSide.Left, 1);
		coverBackAnimationNameLeft = GetLookAnimationName(weaponType, CoverSide.Left, 2);
		lookAnimationNameRight = GetLookAnimationName(weaponType, CoverSide.Right, 0);
		fireAnimationNameRight = GetLookAnimationName(weaponType, CoverSide.Right, 1);
		coverBackAnimationNameRight = GetLookAnimationName(weaponType, CoverSide.Right, 2);
	}

	private static string GetLookAnimationName(Weapon.WeaponType type, CoverSide side, int phase)
	{
		string text = string.Empty;
		string empty = string.Empty;
		switch (phase)
		{
		case 0:
			text = ((side != CoverSide.Left) ? "player_look_right" : "player_look_left");
			break;
		case 1:
			text = ((side != CoverSide.Left) ? "player_fire_right" : "player_fire_left");
			break;
		case 2:
			text = ((side != CoverSide.Left) ? "player_right_coverBack" : "player_left_coverBack");
			break;
		}
		switch (type)
		{
		case Weapon.WeaponType.Pistol:
			empty = "_pistol";
			break;
		case Weapon.WeaponType.Minigun:
			empty = "_minigun";
			break;
		case Weapon.WeaponType.GrenadeLauncher:
			empty = "_grenadelauncher";
			break;
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.Machinegun:
			empty = "_shotgun";
			break;
		case Weapon.WeaponType.QBZ:
			empty = "_qbz";
			break;
		case Weapon.WeaponType.QBZ2:
			empty = "_qbz2";
			break;
		case Weapon.WeaponType.SniperRiffle:
			empty = "_sniper";
			break;
		default:
			empty = "3";
			break;
		}
		return text + empty;
	}

	private void SamplemAnimation(string mAnimationName, float normalizedTime)
	{
		mAnimation.Stop();
		AnimationState animationState = mAnimation[mAnimationName];
		animationState.enabled = true;
		animationState.weight = 1f;
		animationState.normalizedTime = normalizedTime;
		mAnimation.Sample();
		animationState.enabled = false;
	}

	[ContextMenu("Set T_pose")]
	public void SetTPose()
	{
		Animation component = GetComponent<Animation>();
		component.Play("T_pose");
		component["T_pose"].normalizedTime = 1f;
		component.Sample();
	}

	public void SittingIdle()
	{
		SamplemAnimation("buggy_idle", 1f);
		mAnimation.Play("buggy_idle");
	}

	public void BuildMortar()
	{
		mAnimation.Play("mortar_down");
		mAnimation.PlayQueued("mortar_down_idle");
	}

	public void FiredMortar()
	{
		mAnimation.Play("mortar_hide");
		mAnimation.PlayQueued("mortar_up");
	}
}
