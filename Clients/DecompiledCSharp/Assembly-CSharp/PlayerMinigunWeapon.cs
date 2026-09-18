using UnityEngine;

public class PlayerMinigunWeapon : PlayerWeapon
{
	public float lockTimeAfterBurst = 0.3f;

	public int scopeNum;

	public bool showScope;

	public float waitTime = 1f;

	public PlayerMinigunWeaponMotor motor;

	private Vector3 mAimPosition;

	private Vector3 mFirstShotPos;

	private bool mIsWaitingForFirstShot;

	private float mLastButtonPress;

	private float mLockTime;

	private float mPressedTime;

	private bool mShootRight;

	private bool mIsFirst;

	private float mStartShootTime;

	private float mWaitTime;

	private int mShotsCounter;

	private bool mIsAiming;

	public float coolDown = 1f;

	private bool mShowScope => showScope && DebugSettings.showPrimaryScopes;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			if (!isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.Hide();
				motor.StopMotor();
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(scopeNum);
			}
			mIsWaitingForFirstShot = false;
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (!base.playerController.clicked)
		{
			if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
			{
				mPressedTime = TimeManager.realTimeWithoutPauses;
				mIsFirst = true;
				mShotsCounter = 0;
				mIsAiming = true;
				motor.StartMotor();
			}
			if (Singleton<InputController>.instance.isTapping && !mIsWaitingForFirstShot && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > mLockTime)
			{
				mLastButtonPress = TimeManager.realTimeWithoutPauses;
				if (base.weapon.willShoot)
				{
					mAimPosition = Singleton<AimingHelper>.instance.Aim(base.weapon);
					if (TimeManager.realTimeWithoutPauses > mPressedTime + waitTime)
					{
						if (CanShootAngle(mAimPosition))
						{
							Sh(mAimPosition);
							mIsAiming = false;
						}
					}
					else
					{
						Uncover(mAimPosition);
					}
				}
				if (mLastButtonPress - mPressedTime > 0.75f && mShowScope && Singleton<InputController>.instance.isTapping)
				{
					Singleton<SniperScope>.instance.Show(9f);
				}
			}
			if (mIsWaitingForFirstShot && TimeManager.realTimeWithoutPauses > mStartShootTime + mWaitTime)
			{
				mShotsCounter++;
				base.weapon.Fire(mFirstShotPos);
				PlayTouchCircle(mFirstShotPos);
				ShakeCamera();
				mIsWaitingForFirstShot = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > mStartShootTime + firstShotWaitTime))
			{
			}
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			motor.StopMotor();
			if (mIsAiming)
			{
				base.playerController.Uncover(mShootRight, hideBack: true);
				mIsAiming = false;
			}
		}
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			motor.StopMotor();
		}
	}

	private void Uncover(Vector3 targetPosition)
	{
		bool flag = GeometryTools.AngleSigned(base.playerController.transform.forward, targetPosition - base.playerController.transform.position, Vector3.up) > 0f;
		if (flag != mShootRight || mIsFirst)
		{
			mShootRight = flag;
			base.playerController.Uncover(mShootRight, hideBack: false);
		}
		mIsFirst = false;
	}

	private void Sh(Vector3 targetPosition)
	{
		mWaitTime = firstShotWaitTime;
		mLockTime = -1f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, targetPosition - base.playerController.transform.position, Vector3.up) > 0f;
		Vector3 direction = targetPosition - base.playerController.transform.position;
		direction.y = 0f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.soldierAnimator.isIdle || base.playerController.playerState == PlayerController.PlayerStatex.Walking)
		{
			flag = true;
			if (base.playerController.soldierAnimator.isHiding)
			{
				mWaitTime = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				mWaitTime = base.playerController.soldierAnimator.uncoverLength * 0.25f;
			}
			if (base.playerController.playerState == PlayerController.PlayerStatex.Walking)
			{
				mWaitTime = 0.05f;
			}
		}
		if (base.playerController.soldierAnimator.IsShooting || mWaitTime <= 0.01f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - mPressedTime) / coolDown);
			float num2 = Mathf.Clamp01(0.3f - num * 0.3f);
			mLockTime = TimeManager.realTimeWithoutPauses + num2;
			mShotsCounter++;
			base.weapon.Fire(targetPosition);
			PlayTouchCircle(targetPosition);
			ShakeCamera();
		}
		if (flag2 != mShootRight)
		{
			mShootRight = flag2;
			flag = true;
			mWaitTime = base.playerController.soldierAnimator.uncoverLength * 0.25f;
		}
		base.playerController.PlayShotAnimation(base.weapon.weaponType, mShootRight, direction);
		if (flag)
		{
			mStartShootTime = TimeManager.realTimeWithoutPauses;
			mFirstShotPos = targetPosition;
			mIsWaitingForFirstShot = true;
		}
	}

	public override void ShootForBot(Vector3 position)
	{
		base.ShootForBot(position);
		if (base.weapon.willShoot && !mIsWaitingForFirstShot)
		{
			mLastButtonPress = TimeManager.realTimeWithoutPauses;
			Sh(position);
		}
	}
}
