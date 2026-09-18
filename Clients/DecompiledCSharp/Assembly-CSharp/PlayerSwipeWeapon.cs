using UnityEngine;

public class PlayerSwipeWeapon : PlayerWeapon
{
	public float maxDistance = 5f;

	public float maxDistanceShot = 5f;

	public float maxThrowTime = 1f;

	public float minDistance;

	public float minDistanceShot = 2f;

	public float minThrowTime = 0.1f;

	public float throwfactor = 1f;

	public float distanceTreshold = 0.5f;

	public Transform spawnPointLeft;

	public Transform spawnPointRight;

	private Plane mCollisionPlane;

	private Vector3 mSwipeEnd;

	private Vector3 mSwipeStart;

	private Vector3 mShotPosition;

	private bool mIsTutorial;

	private float mPressedTime;

	private Vector3 mTutorialPosition;

	private bool mWillShoot;

	private bool mIsPressed;

	private bool mBotIsShooting;

	private float mShootTime;

	private bool mRight;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			mWillShoot = false;
			mIsTutorial = false;
			mBotIsShooting = false;
			mIsPressed = false;
			if (value)
			{
				mCollisionPlane = new Plane(Vector3.up, base.playerController.currentPlayerPoint.point.transform.position);
			}
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (base.playerController.isAlive && base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.rawSwipeInput.swipeStarted)
			{
				mPressedTime = Time.realtimeSinceStartup;
			}
			if (Singleton<InputController>.instance.rawSwipeInput.swipeDone)
			{
				Vector3 vector = Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart;
				float num = Vector3.Angle(vector, Vector3.up);
				if (vector.magnitude > (float)Screen.width * 0.05f && num <= 70f)
				{
					if (base.weapon.willShoot && base.playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
					{
						if (TryRaycastSwipe(ref mSwipeStart, ref mSwipeEnd))
						{
							float num2 = Mathf.Clamp(Time.realtimeSinceStartup - mPressedTime, minThrowTime, maxThrowTime);
							float num3 = Mathf.Clamp(Vector3.Distance(mSwipeEnd, mSwipeStart), minDistance, maxDistance);
							float value = num3 / num2 * throwfactor;
							if (num3 > distanceTreshold)
							{
								value = Mathf.Clamp(value, minDistanceShot, maxDistanceShot);
								Vector3 vector2 = (mSwipeEnd - mSwipeStart).normalized * value;
								mShotPosition = base.playerController.transform.position + vector2;
								mRight = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, vector2, Vector3.up) > 0f;
								Vector3 direction = mShotPosition - base.playerController.transform.position;
								direction.y = 0f;
								base.playerController.PlayShotAnimation(base.weapon.weaponType, mRight, direction);
								SwitchModel(mRight);
								if (CanShootAngle(mShotPosition))
								{
									mWillShoot = true;
									mShootTime = TimeManager.realTimeWithoutPauses + firstShotWaitTime;
									if (mIsTutorial)
									{
										float num4 = Vector3.Distance(mShotPosition, mTutorialPosition);
										mShotPosition = ((!(num4 < 3.5f)) ? mShotPosition : mTutorialPosition);
									}
								}
								else
								{
									Debug.LogWarning($"Can't shoot angle!!");
								}
							}
							else
							{
								Debug.Log("#Swipe failed, distance threshold condition");
							}
						}
					}
					else
					{
						GuiScreenSingle<HudScreen>.instance.ShowReloadingIco(this);
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
				}
			}
			if (mWillShoot && TimeManager.realTimeWithoutPauses >= mShootTime)
			{
				SwitchModel(right: false);
				mWillShoot = false;
				base.weapon.spawnPoint = (mRight ? spawnPointLeft : spawnPointRight);
				Ammo ammo = base.weapon.Fire(mShotPosition);
				if (Singleton<GameController>.instance.isTutorialStage2)
				{
					ammo.enabled = true;
				}
				PlayTouchCircle(mShotPosition);
				ShakeCamera();
			}
			if (DebugSettings.debugEnabled)
			{
				CameraLineRenderer.DrawCross(mSwipeEnd, 0.5f, Color.green);
				CameraLineRenderer.DrawCross(mSwipeStart, 0.5f, Color.green);
				CameraLineRenderer.DrawCross(mShotPosition, 0.5f, Color.red);
			}
		}
		mModel.gameObject.SetActive(base.weapon.hasAmmo);
	}

	public void SetTutorialPosition(Vector3 tutorialPosition)
	{
		mTutorialPosition = tutorialPosition;
		mIsTutorial = true;
	}

	private void OnEnable()
	{
		if (mModel != null)
		{
			mModel.SetActive(value: true);
		}
	}

	private void OnDisable()
	{
		if (mModel != null)
		{
			mModel.SetActive(value: false);
		}
	}

	private void SwitchModel(bool right)
	{
		if (mModel != null)
		{
			if (!right)
			{
				Quaternion localRotation = mModel.transform.localRotation;
				mModel.transform.parent = spawnPointRight.transform;
				mModel.transform.localPosition = default(Vector3);
				mModel.transform.localRotation = localRotation;
			}
			else
			{
				Quaternion localRotation2 = mModel.transform.localRotation;
				mModel.transform.parent = spawnPointLeft.transform;
				mModel.transform.localPosition = default(Vector3);
				mModel.transform.localRotation = localRotation2;
			}
		}
	}

	public override void ShootForBot(Vector3 position)
	{
		base.ShootForBot(position);
		if (base.weapon.willShoot && !mBotIsShooting)
		{
			bool right = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, position - base.playerController.transform.position, Vector3.up) > 0f;
			Vector3 dir = position - base.playerController.transform.position;
			base.playerController.PlayShotAnimation(base.weapon.weaponType, right, dir);
			dir = Vector3.ClampMagnitude(dir, maxDistanceShot);
			mBotIsShooting = true;
			InvokeAfterRealTimeWithoutPause(delegate
			{
				mBotIsShooting = false;
				Vector3 to = base.playerController.transform.position + dir;
				base.weapon.Fire(to);
			}, firstShotWaitTime);
		}
	}

	private bool TryRaycastSwipe(ref Vector3 swipeStart, ref Vector3 swipeEnd)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Singleton<InputController>.instance.rawSwipeInput.swipeStart);
		Ray ray2 = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Singleton<InputController>.instance.rawSwipeInput.swipeEnd);
		float enter = 0f;
		float enter2 = 0f;
		if (mCollisionPlane.Raycast(ray, out enter))
		{
			swipeStart = ray.GetPoint(enter);
			if (mCollisionPlane.Raycast(ray2, out enter2))
			{
				swipeEnd = ray2.GetPoint(enter2);
				return true;
			}
			Ray ray3 = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Singleton<InputController>.instance.rawSwipeInput.swipeStart + (Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart).normalized);
			if (mCollisionPlane.Raycast(ray3, out var enter3))
			{
				Vector3 point = ray3.GetPoint(enter3);
				swipeEnd = swipeStart + (point - swipeStart).normalized * maxDistance;
				return true;
			}
			Debug.LogError($"Swipe Raycasts End FAILED!");
		}
		else
		{
			Debug.LogError($"Swipe Raycasts Start FAILED!");
		}
		return false;
	}
}
