using UnityEngine;

public class PlayerClickWeapon : PlayerWeapon
{
	public bool autofire;

	private Vector3 mAimPosition;

	private bool mCanFireNoAuto;

	private Vector3 mFirstShotPos;

	private bool mIsWaitingForFirstShot;

	private float mLastButtonPress;

	private float mPressedTime;

	private bool mShootRight;

	private float mStartShootTime;

	private float mWaitTime;

	public int scopeNum;

	public bool showScope;

	private bool stoppedShooting = true;

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
			}
			mIsWaitingForFirstShot = false;
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !autofire)
		{
			mCanFireNoAuto = true;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.gameIsRunning && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					mPressedTime = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !mIsWaitingForFirstShot)
				{
					mLastButtonPress = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (mCanFireNoAuto || autofire))
					{
						mAimPosition = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CanShootAngle(mAimPosition))
						{
							Sh(mAimPosition);
						}
					}
					else if ((float)base.weapon.cadence > 1f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						stoppedShooting = true;
						Singleton<SniperScope>.instance.Hide();
					}
					else if (mLastButtonPress - mPressedTime > 0.25f && mShowScope && autofire)
					{
						Singleton<SniperScope>.instance.Show(9f);
					}
				}
			}
			if (mIsWaitingForFirstShot && TimeManager.realTimeWithoutPauses > mStartShootTime + mWaitTime)
			{
				base.weapon.Fire(mFirstShotPos);
				PlayTouchCircle(mFirstShotPos);
				ShakeCamera();
				mIsWaitingForFirstShot = false;
			}
		}
		else
		{
			stoppedShooting = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			mCanFireNoAuto = true;
		}
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			mCanFireNoAuto = true;
		}
	}

	private void Sh(Vector3 targetPosition)
	{
		mWaitTime = firstShotWaitTime;
		mCanFireNoAuto = false;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, targetPosition - base.playerController.transform.position, Vector3.up) > 0f;
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
			Sh(position);
		}
	}
}
