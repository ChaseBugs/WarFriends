using UnityEngine;

public class PlayerHoldWeapon : PlayerWeapon
{
	public float holdTime = 1f;

	private Vector3 mAimPosition;

	private bool mBotIsShooting;

	private bool mIsWaitingForShot;

	private float mLastButtonPress;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			mBotIsShooting = false;
			if (!value)
			{
				mIsWaitingForShot = false;
			}
			if (isActiveWeapon && !base.playerController.isCurrentPlayer)
			{
			}
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (!base.playerController.isCurrentPlayer || (base.playerController.clicked && !mIsWaitingForShot))
		{
			return;
		}
		if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.willShoot && base.weapon.nextShootProgress > 0.2f && (float)base.weapon.cadence > 0.4f)
		{
			GuiScreenSingle<HudScreen>.instance.ShowReloadingIco(this);
			GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
		}
		if (Singleton<InputController>.instance.isTapping && base.playerController.playerState != PlayerController.PlayerStatex.HidingBehindShield)
		{
			mIsWaitingForShot = false;
		}
		if (Singleton<InputController>.instance.isTapping && base.weapon.willShoot && base.playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
		{
			if (mIsWaitingForShot)
			{
				GuiScreenSingle<HudScreen>.instance.StartBazzokaTargettingAnimation(holdTime);
				if (TimeManager.realTimeWithoutPauses > mLastButtonPress + holdTime)
				{
					mIsWaitingForShot = false;
					Shoot(mAimPosition);
				}
			}
			else
			{
				mAimPosition = Singleton<AimingHelper>.instance.Aim(base.weapon);
				if (CanShootAngle(mAimPosition))
				{
					Uncover(mAimPosition);
					mIsWaitingForShot = true;
					mLastButtonPress = TimeManager.realTimeWithoutPauses;
				}
			}
		}
		if (Input.GetMouseButtonUp(0) && mIsWaitingForShot)
		{
			mIsWaitingForShot = false;
			base.playerController.Uncover(right: true, hideBack: true);
			GuiScreenSingle<HudScreen>.instance.StopBazzokaAnimation();
		}
	}

	private void Uncover(Vector3 targetPosition)
	{
		bool right = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, targetPosition - base.playerController.transform.position, Vector3.up) > 0f;
		Vector3 direction = targetPosition - base.playerController.transform.position;
		direction.y = 0f;
		base.playerController.PlayShotAnimation(base.weapon.weaponType, right, direction);
	}

	public override void ShootForBot(Vector3 position)
	{
		base.ShootForBot(position);
		if (base.weapon.willShoot && !mBotIsShooting)
		{
			bool right = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, position - base.playerController.transform.position, Vector3.up) > 0f;
			Vector3 direction = position - base.playerController.transform.position;
			direction.y = 0f;
			base.playerController.PlayShotAnimation(base.weapon.weaponType, right, direction);
			mBotIsShooting = true;
			InvokeAfterRealTimeWithoutPause(delegate
			{
				Shoot(position);
				mBotIsShooting = false;
			}, holdTime);
		}
	}

	private void Shoot(Vector3 shootPosition)
	{
		base.weapon.Fire(shootPosition);
		PlayTouchCircle(shootPosition);
		ShakeCamera();
	}
}
