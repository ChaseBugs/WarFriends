using UnityEngine;

public class PlayerBurstWeapon : PlayerWeapon
{
	public int burst = 3;

	private Vector3 mAimPosition;

	private int mBurstLeft;

	private Vector3 mFirstShotPos;

	private bool mIsWaitingForFirstShot;

	private float mLastButtonPress;

	private float mPressedTime;

	private bool mShootRight;

	private int mShotsCounter;

	private float mStartShootTime;

	private float mWaitTime;

	public int scopeNum;

	public bool showScope;

	public float lockTimeAfterBurst = 0.3f;

	private bool stoppedShooting = true;

	private float mLockTime;

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
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(scopeNum);
				mBurstLeft = 0;
			}
			mIsWaitingForFirstShot = false;
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					mPressedTime = TimeManager.realTimeWithoutPauses;
					mBurstLeft = burst;
					mShotsCounter = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || mBurstLeft > 0) && !mIsWaitingForFirstShot && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > mLockTime)
				{
					mLastButtonPress = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						mAimPosition = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CanShootAngle(mAimPosition))
						{
							Sh(mAimPosition);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						stoppedShooting = true;
						Singleton<SniperScope>.instance.Hide();
						mBurstLeft = 0;
					}
					else if (mLastButtonPress - mPressedTime > 0.25f && mShowScope && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.Show(9f);
					}
				}
			}
			if (mIsWaitingForFirstShot && TimeManager.realTimeWithoutPauses > mStartShootTime + mWaitTime)
			{
				mBurstLeft--;
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
		else
		{
			stoppedShooting = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	private void Sh(Vector3 targetPosition)
	{
		mWaitTime = firstShotWaitTime;
		mLockTime = -1f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, targetPosition - base.playerController.transform.position, Vector3.up) > 0f;
		Vector3 direction = targetPosition - base.playerController.transform.position;
		direction.y = 0f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.soldierAnimator.isIdle || (base.playerController.playerState == PlayerController.PlayerStatex.Walking && stoppedShooting))
		{
			flag = true;
			stoppedShooting = false;
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
		else if (base.playerController.soldierAnimator.IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			mBurstLeft--;
			mShotsCounter++;
			if (mShotsCounter % burst == 0)
			{
				mLockTime = TimeManager.realTimeWithoutPauses + lockTimeAfterBurst;
			}
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
