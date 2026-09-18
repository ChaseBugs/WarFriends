using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : Singleton<GameCamera>
{
	public GameObject cameraHUD;

	public CameraPlayerFollow.ThirdPersoncameraDefinition thirdPersoncameraDefinition;

	private Camera mCamera;

	public float shotPositionSpringStiffness = 0.5f;

	public float shotPositionSpringDamping = 0.8f;

	public float hitPositionSpringStiffness = 0.5f;

	public float hitPositionSpringDamping = 0.8f;

	private Transform mTransform;

	private vp_Spring mShotPositionSpring;

	private vp_Spring mHitPositionSpring;

	private CameraPlayerFollow mCameraPlayerFollow;

	public float radius;

	public float deltaAngle;

	public List<Vector3> positions;

	public List<Quaternion> rotations;

	public float goBackAfter = 4f;

	public float vehiclesGoBackAfter = 4f;

	public float ShowNewAfter = 2f;

	private readonly List<Vector3> debugPoints = new List<Vector3>();

	[Header("Focus Enemy Animation")]
	public float flyToTimeByPlayer = 1f;

	public float flyToTimeByOther = 2f;

	public float flyToFowTime = 0.3f;

	public float flyToFowBackTimeByPlayer = 0.2f;

	public float flyToFowBackTimeByOther = 0.2f;

	public float flyToFow = 70f;

	public float flyToParalelDistanceForShield = 0.5f;

	public Vector2 flyToOffset = new Vector2(1f, 0.25f);

	public float flyToLookAtPosition = 0.35f;

	public float flyToDelay = 0.2f;

	public float flyToCameraLean = 10f;

	public AnimationCurve flyToCameraLeanAnimation;

	public AnimationCurve flyToAnimation;

	public float flyToFocusTargetLerp = 1f;

	public float flyToTransitionTime = 8f;

	public float flyToTargetLerp = 1f;

	public AnimationCurve flyToRotationAnimation;

	public AnimationCurve flyToTransitionAnimation;

	public AnimationCurve flyToLeanBackAnimation;

	private PlayerWeapon mActiveWeapon;

	private TweenFOV mTweenFOV;

	private bool mSpringsEnabled = true;

	private bool mCameraFreezed;

	private Quaternion mOldRot;

	private bool mIsAnimating;

	private Vector3 mOldPos;

	private int mMask;

	private PlayerController mTarget;

	public Camera camera
	{
		get
		{
			if (mCamera == null)
			{
				mCamera = GetComponentsInChildren<Camera>(includeInactive: true)[0];
			}
			return mCamera;
		}
	}

	private float mFov => (!ScreenManager.isSmallScreen) ? 52 : 34;

	public event Action AnimationFinished;

	public event Action AnimationOnPlayerStop;

	public event Action SingleAnimationFinished;

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.BeforeGameStarted += InstanceOnBeforeGameStarted;
		Singleton<GameController>.instance.SceneFreed += OnSceneFree;
		mTransform = base.transform;
		mCamera = GetComponent<Camera>();
		mMask = camera.cullingMask;
		camera.fieldOfView = mFov;
		mShotPositionSpring = new vp_Spring(mTransform, vp_Spring.UpdateMode.PositionAdditive, autoUpdate: false)
		{
			Stiffness = new Vector3(shotPositionSpringStiffness, shotPositionSpringStiffness, shotPositionSpringStiffness),
			Damping = Vector3.one - new Vector3(shotPositionSpringDamping, shotPositionSpringDamping, shotPositionSpringDamping),
			RestState = Vector3.zero,
			State = Vector3.zero,
			MinState = -0.01f * Vector3.one,
			MaxState = 0.01f * Vector3.one
		};
		mHitPositionSpring = new vp_Spring(mTransform, vp_Spring.UpdateMode.PositionAdditive, autoUpdate: false)
		{
			Stiffness = new Vector3(hitPositionSpringStiffness, hitPositionSpringStiffness, hitPositionSpringStiffness),
			Damping = Vector3.one - new Vector3(hitPositionSpringDamping, hitPositionSpringDamping, hitPositionSpringDamping),
			RestState = Vector3.zero,
			State = Vector3.zero,
			MinState = -0.25f * Vector3.one,
			MaxState = 0.25f * Vector3.one
		};
		mCameraPlayerFollow = GetComponent<CameraPlayerFollow>();
		camera.cullingMask = 0;
		cameraHUD.gameObject.SetActive(value: false);
		Debug.Log(camera.depthTextureMode);
	}

	private void OnSceneFree()
	{
		mCamera.depthTextureMode = DepthTextureMode.None;
	}

	private void InstanceOnBeforeGameStarted()
	{
		SetTarget(PlayerController.currentPlayer);
		mCamera.depthTextureMode = DepthTextureMode.None;
		mSpringsEnabled = true;
	}

	protected override void Start()
	{
		base.Start();
		SetTarget(PlayerController.currentPlayer);
	}

	public IEnumerator SingleCameraAnimation(float time = 2f)
	{
		Enable();
		Transform pl = PlayerController.currentPlayer.currentPlayerPoint.point.transform;
		Vector3 fw = pl.forward;
		fw.Normalize();
		mCameraPlayerFollow.ForceSet();
		mCameraPlayerFollow.enabled = false;
		bool finished = false;
		TweenPosition tw = TweenPosition.Begin(fromnPos: mTransform.position + fw * 3f, go: base.gameObject, duration: time, toPos: mTransform.position);
		tw.onFinished = (UITweener.OnFinished)Delegate.Combine(tw.onFinished, (UITweener.OnFinished)delegate
		{
			finished = true;
		});
		while (!finished)
		{
			yield return null;
		}
		if (this.SingleAnimationFinished != null)
		{
			this.SingleAnimationFinished();
		}
		mCameraPlayerFollow.enabled = true;
		TweenFOV.Begin(base.gameObject, 1f, mFov);
	}

	public void SetFollowedActive(bool followed)
	{
		mCameraPlayerFollow.enabled = followed;
	}

	public void StartTutorialCamera()
	{
		Enable();
		CameraPathOnAnimationFinishedEvent();
		mCameraPlayerFollow.ForceSet();
		mCameraPlayerFollow.enabled = true;
	}

	public void Enable()
	{
		camera.cullingMask = mMask;
		camera.enabled = true;
		cameraHUD.gameObject.SetActive(value: true);
	}

	public void Disable()
	{
		camera.cullingMask = 0;
		camera.enabled = false;
		cameraHUD.gameObject.SetActive(value: false);
	}

	public IEnumerator StartBeginAnimation()
	{
		Singleton<PerformanceManager>.instance.SetShadowsDistance(shortDistance: true);
		Enable();
		Time.timeScale = 1.3f;
		mIsAnimating = true;
		mCameraPlayerFollow.enabled = false;
		camera.fieldOfView = 52f;
		CameraPathAnimator cameraPath = GetPath();
		PreparePath();
		cameraPath.animationObject = base.transform;
		cameraPath.Seek(0f);
		cameraPath.Play();
		cameraPath.AnimationFinishedEvent += CameraPathOnAnimationFinishedEvent;
		cameraPath.AnimationCustomEvent += CameraPathOnAnimationCustomEvent;
		do
		{
			yield return null;
		}
		while (mIsAnimating);
		UnitsPreview.GenerateArmy();
		float animTime = 2f / Time.timeScale;
		Vector3 start = base.transform.position;
		Vector3 end = base.transform.position + PlayerController.currentPlayer.currentPlayerPoint.point.transform.forward * 4f + Vector3.up * 0.6f;
		Quaternion startR = base.transform.rotation;
		Vector3 lookat = PlayerController.currentPlayer.currentPlayerPoint.point.transform.position - PlayerController.currentPlayer.currentPlayerPoint.point.transform.forward * 2f + 0.7f * Vector3.up;
		Quaternion endR = Quaternion.LookRotation(lookat - end);
		end.z = UnitsPreview.GetCenter(PlayerController.currentPlayer).z;
		bool finished = false;
		TweenPosition tw = TweenPosition.Begin(base.gameObject, animTime, start, end, useLocal: false);
		tw.method = UITweener.Method.EaseIn;
		TweenRotation.Begin(base.gameObject, animTime, startR, endR);
		TweenPosition tweenPosition = tw;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
		{
			Vector3 toPos = end + (end - start).normalized * 0.5f;
			TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, animTime, base.transform.position, toPos, useLocal: false);
			tweenPosition3.method = UITweener.Method.EaseOut;
			tweenPosition3.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition3.onFinished, (UITweener.OnFinished)delegate
			{
				finished = true;
			});
		});
		InvokeAfterRealTime(UnitsPreview.SoldiersGoBack, goBackAfter);
		InvokeAfterRealTime(UnitsPreview.VehiclesGoBack, vehiclesGoBackAfter);
		InvokeAfterRealTime(UnitsPreview.ShowNew, ShowNewAfter);
		while (!finished)
		{
			yield return null;
		}
		finished = false;
		Vector3 pos = Vector3.zero;
		Quaternion rot = Quaternion.identity;
		mCameraPlayerFollow.GetRotPos(ref pos, ref rot);
		tw = TweenPosition.Begin(base.gameObject, animTime, base.transform.position, pos, useLocal: false);
		tw.method = UITweener.Method.EaseInOut;
		TweenRotation.Begin(base.gameObject, animTime, base.transform.localRotation, rot);
		TweenFOV.Begin(base.gameObject, animTime, mFov);
		TweenPosition tweenPosition2 = tw;
		tweenPosition2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition2.onFinished, (UITweener.OnFinished)delegate
		{
			finished = true;
		});
		while (!finished)
		{
			yield return null;
		}
		Time.timeScale = 1f;
		Singleton<PerformanceManager>.instance.SetShadowsDistance(shortDistance: false);
		mCameraPlayerFollow.enabled = true;
		UnitsPreview.DestroyArmy();
	}

	private void PreparePath()
	{
		CameraPathAnimator path = GetPath();
		CameraPath cameraPath = path.cameraPath;
		Vector3 position = Singleton<GameController>.instance.opponent.currentPlayerPoint.point.transform.position;
		float nearestPoint = cameraPath.GetNearestPoint(position, ignoreNormalisation: true);
		debugPoints.Add(position);
		CameraPathDelay cameraPathDelay = cameraPath.delayList[1];
		cameraPathDelay.percent = nearestPoint;
		cameraPath.eventList[0].percent = nearestPoint;
	}

	private CameraPathAnimator GetPath()
	{
		return PlayerController.currentPlayer.currentPlayerPoint.cameraPath;
	}

	private void CameraPathOnAnimationCustomEvent(string eventName)
	{
		CameraPathAnimator path = GetPath();
		path.AnimationCustomEvent -= CameraPathOnAnimationCustomEvent;
		if (this.AnimationOnPlayerStop != null)
		{
			this.AnimationOnPlayerStop();
		}
	}

	private void CameraPathOnAnimationFinishedEvent()
	{
		mIsAnimating = false;
		mCameraPlayerFollow.definition = mTarget.weaponInventory.currentWeapon.weaponCamera;
		mCameraPlayerFollow.target = mTarget;
		ChangeScales();
		CameraPathAnimator path = GetPath();
		path.AnimationFinishedEvent -= CameraPathOnAnimationFinishedEvent;
		if (this.AnimationFinished != null)
		{
			this.AnimationFinished();
		}
	}

	public void FocusPlayer(PlayerController player, bool killedByPlayer)
	{
		mSpringsEnabled = false;
		cameraHUD.gameObject.SetActive(value: false);
		mCameraPlayerFollow.enabled = false;
		Singleton<PerformanceManager>.instance.SetShadowsDistance(shortDistance: true);
		if (player.fraction == PlayerController.currentPlayer.fraction)
		{
			if (Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCoop)
			{
				Debug.Log("FOCUS CAMPAIGN!!!!");
				StartCoroutine(FocusCurrentPlayerCampaign(player));
			}
			else
			{
				StartCoroutine(FocusCurrentPlayer(player));
			}
		}
		else
		{
			StartCoroutine(RadicalRoutine.Run(FocusEnemyPlayer(player, killedByPlayer)));
		}
	}

	private IEnumerator FocusCurrentPlayer(PlayerController player)
	{
		mCameraPlayerFollow.enabled = false;
		float duration = 1f;
		bool focus = false;
		bool quit = false;
		Vector3 newPos = player.destroyableParts.parts[1].transform.position - player.transform.forward * 1.5f + player.transform.right * 1f + Vector3.up * 1.2f;
		Vector3 target = player.destroyableParts.parts[1].transform.position;
		Vector3 dir = (newPos - base.transform.position).normalized;
		TimeManager.instance.EndGame();
		mOldRot = base.transform.rotation;
		TweenFOV.Begin(base.gameObject, duration, 40f);
		TweenRotation tw = TweenRotation.Begin(base.gameObject, duration, Quaternion.LookRotation(target - newPos));
		tw.delay = 0f;
		tw.method = UITweener.Method.EaseIn;
		TweenPosition.Begin(base.gameObject, duration, base.transform.position, newPos, useLocal: false).delay = 0f;
		tw.onFinished = (UITweener.OnFinished)Delegate.Combine(tw.onFinished, (UITweener.OnFinished)delegate
		{
			focus = true;
			Vector3 toPos = newPos + dir * 5f;
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 15f, base.transform.position, toPos, useLocal: false);
			tweenPosition.delay = 0f;
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
			{
				focus = false;
				quit = true;
			});
		});
		while (!quit)
		{
			target = Vector3.Lerp(target, player.destroyableParts.parts[1].transform.position, Time.unscaledDeltaTime / flyToFocusTargetLerp);
			if (focus)
			{
				base.transform.rotation = Quaternion.LookRotation(player.destroyableParts.parts[1].transform.position - base.transform.position);
			}
			yield return null;
		}
	}

	private IEnumerator FocusCurrentPlayerCampaign(PlayerController player)
	{
		mCameraPlayerFollow.enabled = false;
		TimeManager.instance.EndGame();
		float sideCoef = 1f;
		Vector3 playerPosition = player.soldierAnimator.rootBoneInner.transform.position;
		Vector3 startPosition = base.transform.position;
		Vector3 upPosition = player.destroyableParts.parts[1].transform.position - player.transform.forward * 1f + player.transform.right * sideCoef + Vector3.up * 1.2f;
		Vector3 lookVector = playerPosition - upPosition;
		Vector3 target = playerPosition;
		float transitionTime = 0f;
		while (transitionTime < flyToTransitionTime)
		{
			transitionTime += Time.unscaledDeltaTime;
			target = Vector3.Lerp(target, player.soldierAnimator.rootBoneInner.transform.position, Time.unscaledDeltaTime / flyToTargetLerp);
			Vector3 rotatedLookVector = Quaternion.Euler(0f, (0f - sideCoef) * flyToRotationAnimation.Evaluate(transitionTime), 0f) * lookVector;
			base.transform.position = Vector3.Lerp(startPosition, target - rotatedLookVector, flyToTransitionAnimation.Evaluate(transitionTime));
			base.transform.rotation = Quaternion.LookRotation(target.AddY(flyToLookAtPosition) - base.transform.position);
			yield return null;
		}
	}

	private IEnumerator FocusEnemyPlayer(PlayerController player, bool killedByPlayer)
	{
		float flyToTime = ((!killedByPlayer) ? flyToTimeByOther : flyToTimeByPlayer);
		float flyToFowBackTime = ((!killedByPlayer) ? flyToFowBackTimeByOther : flyToFowBackTimeByPlayer);
		TimeManager.FreezeGame();
		mCameraPlayerFollow.enabled = false;
		Vector3 currentCamPosition = base.transform.position;
		Vector3 playerForward = -player.currentPlayerPoint.point.transform.forward;
		Vector3 playerPosition = player.soldierAnimator.rootBoneInner.transform.position;
		Vector3 flyToPosition = playerPosition;
		Vector3 upVector = Vector3.up;
		float currentCameraLean = 0f;
		float sideCoef = 1f;
		foreach (MapDefinition.DefendPosition playerPoint in Singleton<MapManager>.instance.currentMapDef.availablePoints)
		{
			if (playerPoint.fraction == player.fraction)
			{
				Vector3 shieldToPlayer = playerPosition - playerPoint.point.transform.position;
				float paralelDistance = Vector3.Dot(shieldToPlayer, playerPoint.point.transform.right);
				if (paralelDistance <= flyToParalelDistanceForShield && paralelDistance >= 0f - flyToParalelDistanceForShield)
				{
					sideCoef = ((!(paralelDistance > 0f)) ? (-1f) : 1f);
					currentCameraLean = flyToCameraLean * sideCoef;
					flyToPosition = sideCoef * playerPoint.point.transform.right * flyToParalelDistanceForShield + playerPosition;
				}
			}
		}
		flyToPosition += playerForward * flyToOffset.x + Vector3.up * flyToOffset.y;
		TweenFOV.Begin(base.gameObject, flyToFowTime, flyToFow);
		float phase = 0f;
		float startTime = Time.realtimeSinceStartup;
		bool fowStarted = false;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / flyToTime);
			float flyToPhase = flyToAnimation.Evaluate(phase);
			float cameraLeanPhase = flyToCameraLeanAnimation.Evaluate(phase);
			base.transform.position = Vector3.Lerp(currentCamPosition, flyToPosition, flyToPhase);
			base.transform.rotation = Quaternion.LookRotation(playerPosition.AddY(flyToLookAtPosition) - base.transform.position) * Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, currentCameraLean, cameraLeanPhase));
			if (!fowStarted && phase > (flyToTime - flyToFowBackTime) / flyToTime)
			{
				fowStarted = true;
				TweenFOV.Begin(base.gameObject, flyToFowBackTime, 40f);
			}
			yield return 0;
		}
		float waitTo = Time.realtimeSinceStartup + flyToDelay;
		while (waitTo > Time.realtimeSinceStartup)
		{
			yield return 0;
		}
		TimeManager.instance.EndGame();
		Vector3 startPosition = base.transform.position;
		Vector3 upPosition = player.destroyableParts.parts[1].transform.position - player.transform.forward * 1.5f + player.transform.right * sideCoef + Vector3.up * 1.2f;
		Vector3 lookVector = playerPosition - upPosition;
		Vector3 target = playerPosition;
		float transitionTime = 0f;
		while (transitionTime < flyToTransitionTime)
		{
			float cameraLeanPhase2 = flyToLeanBackAnimation.Evaluate(transitionTime);
			transitionTime += Time.unscaledDeltaTime;
			target = Vector3.Lerp(target, player.soldierAnimator.rootBoneInner.transform.position, Time.unscaledDeltaTime / flyToTargetLerp);
			Vector3 rotatedLookVector = Quaternion.Euler(0f, (0f - sideCoef) * flyToRotationAnimation.Evaluate(transitionTime), 0f) * lookVector;
			base.transform.position = Vector3.Lerp(startPosition, target - rotatedLookVector, flyToTransitionAnimation.Evaluate(transitionTime));
			if ((target.AddY(flyToLookAtPosition) - base.transform.position).magnitude < 0.0001f)
			{
				Debug.LogWarning($"Look vector is small! .. phase: {phase} target: {target} transform.position: {base.transform.position} playerPosition: {playerPosition} upPosition: {upPosition} cameraLeanPhase: {cameraLeanPhase2} rotatedLookVector: {rotatedLookVector}");
			}
			else if (target.x == base.transform.position.x && target.z == base.transform.position.z)
			{
				Debug.LogWarning($"Look vector error! .. phase: {phase} target: {target} transform.position: {base.transform.position} playerPosition: {playerPosition} upPosition: {upPosition} cameraLeanPhase: {cameraLeanPhase2} rotatedLookVector: {rotatedLookVector}");
			}
			else
			{
				base.transform.rotation = Quaternion.LookRotation(target.AddY(flyToLookAtPosition) - base.transform.position) * Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, currentCameraLean, cameraLeanPhase2));
			}
			yield return null;
		}
	}

	public void FocusEnemyPlayerTutorial(PlayerController player)
	{
		float num = 2f;
		mCameraPlayerFollow.enabled = false;
		mOldRot = base.transform.rotation;
		mOldPos = base.transform.position;
		TweenFOV.Begin(base.gameObject, num, 40f);
		Vector3 vector = player.destroyableParts.parts[1].transform.position + player.transform.forward * 1.5f + player.transform.right * 1f + Vector3.up * 1.2f;
		Vector3 vector2 = player.destroyableParts.parts[1].transform.position + Vector3.up * 0.25f;
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 0.6f, Quaternion.LookRotation(vector2 - vector));
		tweenRotation.delay = num * 0.3f;
		TweenPosition.Begin(base.gameObject, num, base.transform.position, vector, useLocal: false);
	}

	public void UnfocusTutorial()
	{
		float num = 2f;
		TweenFOV.Begin(base.gameObject, num, mFov);
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 0.6f, mOldRot);
		TweenPosition.Begin(base.gameObject, num, base.transform.position, mOldPos, useLocal: false);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			mCameraPlayerFollow.enabled = true;
		});
	}

	private void OnFinishedUnfocus(UITweener tween)
	{
		mSpringsEnabled = true;
		mCameraPlayerFollow.enabled = true;
	}

	private void InstanceOnPlayerStateChanged(PlayerController.PlayerStatex playerStatex)
	{
		if (playerStatex == PlayerController.PlayerStatex.Walking)
		{
			mCameraFreezed = true;
			mCameraPlayerFollow.definition = thirdPersoncameraDefinition;
		}
		if (playerStatex == PlayerController.PlayerStatex.HidingBehindShield)
		{
			mActiveWeapon = mTarget.weaponInventory.currentWeapon;
			mCameraFreezed = false;
			mCameraPlayerFollow.definition = mActiveWeapon.weaponCamera;
		}
		ChangeScales();
	}

	private void ChangeScales()
	{
		if (ScreenManager.isSmallScreen)
		{
			mCameraPlayerFollow.definition.distanceScale = 1.62f;
			mCameraPlayerFollow.definition.scale = 1f;
			mCameraPlayerFollow.definition.fwScale = 2.41f;
		}
		else
		{
			mCameraPlayerFollow.definition.distanceScale = 1f;
			mCameraPlayerFollow.definition.scale = 1f;
			mCameraPlayerFollow.definition.fwScale = 1f;
		}
	}

	public void SetTarget(PlayerController player)
	{
		mCameraPlayerFollow.enabled = true;
		mCameraPlayerFollow.target = player;
		if (mTarget != null)
		{
			mTarget.PlayerStateChanged -= InstanceOnPlayerStateChanged;
		}
		mTarget = player;
		mTarget.PlayerStateChanged -= InstanceOnPlayerStateChanged;
		mTarget.PlayerStateChanged += InstanceOnPlayerStateChanged;
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotation component2 = GetComponent<TweenRotation>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		StopAllCoroutines();
		TweenFOV.Begin(base.gameObject, 1f, mFov);
	}

	protected void Update()
	{
		if (mIsAnimating || !(Time.timeScale > 0.001f))
		{
			return;
		}
		if (mSpringsEnabled && mShotPositionSpring != null)
		{
			mShotPositionSpring.FixedUpdate();
			mHitPositionSpring.FixedUpdate();
		}
		if (!mCameraFreezed && !(mTarget == null))
		{
			PlayerWeapon currentWeapon = mTarget.weaponInventory.currentWeapon;
			if (currentWeapon != mActiveWeapon || mActiveWeapon == null)
			{
				mActiveWeapon = currentWeapon;
				mCameraPlayerFollow.definition = mActiveWeapon.weaponCamera;
				ChangeScales();
			}
			if (mTweenFOV != null && !mSpringsEnabled)
			{
			}
		}
	}

	public void ShootShake()
	{
		if (mSpringsEnabled)
		{
			mShotPositionSpring.AddForce(new Vector3(0f, -0.06f, 0f));
		}
	}

	public void HitShake()
	{
		if (mSpringsEnabled)
		{
			Vector2 vector = UnityEngine.Random.insideUnitCircle.normalized * 0.3f;
			if (mHitPositionSpring.State != mHitPositionSpring.RestState)
			{
				vector *= 0.5f;
			}
			mHitPositionSpring.AddForce(new Vector3(0f, vector.x, vector.y));
		}
	}
}
