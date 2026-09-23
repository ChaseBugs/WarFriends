using UnityEngine;

public class PlayerZoomOnTouchWeapon : PlayerWeapon
{
	private bool mIsFirstShot;

	private bool mShootRight;

	private bool mShootingStarted = true;

	private Vector3 mAimPosition;

	private bool mIsAiming;

	private Vector3 mTouchViewPortPosition;

	private Vector3 dif;

	private float mTouchTime;

	public float zoomTresholdSqrDistance = 1f;

	public float zoomTresholdTime = 0.3f;

	public float fov;

	private bool mFovAnim;

	private bool mShowedScope;

	private bool mWillShoot;

	private bool mWeaponStartShooting;

	public int scopeNum = 1;

	private bool mBotWillShoot;

	private PlayerController.PlayerStatex mLastState;

	private float mBotShootWaitTime = 0.8f;

	private float mBotShootTime;

	private Plane mCollisionPlane;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			mBotWillShoot = false;
			if (!isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				SniperScope instance = Singleton<SniperScope>.instance;
				if (instance != null) instance.Hide();
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				SniperScope instance2 = Singleton<SniperScope>.instance;
				if (instance2 != null) instance2.SetScope(scopeNum);
				mIsAiming = false;
			}
			if (value)
			{
				Vector3 position = base.playerController.transform.position;
				if (base.playerController.currentPlayerPoint != null && base.playerController.currentPlayerPoint.point != null)
					position = base.playerController.currentPlayerPoint.point.transform.position;
				mCollisionPlane = new Plane(Vector3.up, position);
			}
		}
	}

	private bool mPlayerStateCHanged => mLastState != base.playerController.playerState;

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.touchCamera.fieldOfView = 9f;
				mIsAiming = true;
				mTouchViewPortPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				mTouchTime = Time.realtimeSinceStartup;
				dif = Vector3.zero;
				mFovAnim = false;
				mShowedScope = false;
				mWillShoot = false;
				if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (mIsAiming)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !mWillShoot)
					{
						mWillShoot = true;
						mTouchTime = Time.realtimeSinceStartup;
						mWeaponStartShooting = true;
					}
					if (mWillShoot)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - mTouchViewPortPosition;
						b *= 100000f;
						dif = Vector3.Lerp(dif, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, ignoreTimeScale: true) * 28f);
						if (!mFovAnim && Time.realtimeSinceStartup > mTouchTime + zoomTresholdTime && dif.sqrMagnitude < zoomTresholdSqrDistance)
						{
							Singleton<SniperScope>.instance.AnimFov(fov);
							mFovAnim = true;
						}
						if (!mShowedScope && Time.realtimeSinceStartup > mTouchTime + 0.17f)
						{
							Singleton<SniperScope>.instance.Show();
							mShowedScope = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						mTouchViewPortPosition = vector;
						float enter;
						Vector3 vector2 = ((!mCollisionPlane.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 0f;
						if (base.playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized);
						}
						else
						{
							base.playerController.soldierAnimator.LookAtUpperBody(v.normalized);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v, Vector3.up) > 0f;
						if (flag != mShootRight || mWeaponStartShooting || mPlayerStateCHanged)
						{
							mShootRight = flag;
							mWeaponStartShooting = false;
							base.playerController.Uncover(mShootRight, hideBack: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 0f;
						bool right = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 0f;
						base.playerController.Uncover(right, hideBack: false);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && mShowedScope)
					{
						mAimPosition = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CanShootAngle(mAimPosition))
						{
							Vector3 direction = mAimPosition - base.playerController.transform.position;
							direction.y = 0f;
							base.playerController.PlayShotAnimation(base.weapon.weaponType, mShootRight, direction);
							Shoot(mAimPosition);
						}
						else
						{
							base.playerController.Uncover(mShootRight, hideBack: true);
						}
					}
					else
					{
						base.playerController.Uncover(mShootRight, hideBack: true);
						if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && mIsAiming)
			{
				Singleton<SniperScope>.instance.Hide();
				mShowedScope = false;
				mIsAiming = false;
			}
		}
		else if (mBotWillShoot && TimeManager.realTimeWithoutPauses > mBotShootTime)
		{
			mBotWillShoot = false;
			Shoot(mAimPosition);
			bool right2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, mAimPosition - base.playerController.transform.position, Vector3.up) > 0f;
			base.playerController.PlayShotAnimation(base.weapon.weaponType, right2, mAimPosition - base.playerController.transform.position);
		}
		mLastState = base.playerController.playerState;
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && mIsAiming)
		{
			Singleton<SniperScope>.instance.Hide();
			mShowedScope = false;
			mIsAiming = false;
		}
	}

	protected void Update()
	{
		if (Input.GetMouseButtonUp(0) && mIsAiming && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			base.playerController.Uncover(mShootRight, hideBack: true);
		}
	}

	public void SetWaitTime(float value)
	{
		mBotShootWaitTime = value;
	}

	public override void ShootForBot(Vector3 position)
	{
		base.ShootForBot(position);
		if (base.weapon.willShoot && !mBotWillShoot)
		{
			bool right = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, position - base.playerController.transform.position, Vector3.up) > 0f;
			Vector3 vector = position - base.playerController.transform.position;
			vector.y = 0f;
			base.playerController.soldierAnimator.LookAt(vector.normalized);
			base.playerController.Uncover(right, hideBack: false);
			mBotWillShoot = true;
			mBotShootTime = TimeManager.realTimeWithoutPauses + mBotShootWaitTime;
			mAimPosition = position;
		}
	}

	private void Shoot(Vector3 shootPosition)
	{
		base.weapon.Fire(shootPosition);
		PlayTouchCircle(shootPosition);
		ShakeCamera();
	}
}
