using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOverlayGuiElement : GuiElementSingle<TutorialOverlayGuiElement>
{
	[Header("Center")]
	public GameObject pointOfCenter;

	[Header("Hand")]
	public GameObject gameHandRotate;

	public UISprite gameHand;

	public GameObject swipeTrail;

	[Header("Circles")]
	public UISprite gameCircle;

	public UISprite gameCircle2;

	public UISprite gameRing;

	[Header("Global Local Transforming")]
	public GameObject transformerObject;

	[Header("Go To Battle")]
	public UILabel goToBattleLabel;

	private Vector3 mHandScale = new Vector3(177f, 236f, 1f);

	private Vector3 mCircleScale = new Vector3(109f, 109f, 1f);

	private Vector3 mRingScale = new Vector3(64f, 64f, 1f);

	private Vector3 mFingerAngel9 = new Vector3(103f, -152f, 0f);

	private Vector3 mFingerAngel50 = new Vector3(179f, -53f, 0f);

	private Vector3 mStartPoint;

	private TweenAnimator mSwipeAnimator;

	private TweenAnimator.TweenRecord mSwipePosition;

	private TweenAnimator.TweenRecord mFadeHand;

	private bool mSwipePlaying;

	private TweenAnimator mTapAnimator;

	private TweenAnimator.TweenRecord mRotateStart;

	private TweenAnimator.TweenRecord mRotateEnd;

	private bool mTapPlaying;

	private TweenAnimator mHoldAnimator;

	private bool mHoldPlaying;

	private bool mInitialized;

	private bool mTapingSmall;

	private EnemyController mSoldierTap;

	private RadicalRoutine mRoutineSoldierTap;

	private PlayerController mEnemyTap;

	private RadicalRoutine mRoutineEnemyTap;

	private int mTapAllowed;

	private RadicalRoutine mHideCheck;

	private bool mWasHidden;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
	}

	private void InstanceOnGameStarted()
	{
		if (!mInitialized)
		{
			InitAnimators();
		}
		mHideCheck = RadicalRoutine.Create(HideCheck());
		StartCoroutine(RadicalRoutine.Run(mHideCheck.enumerator));
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		FinishTweens();
		mHideCheck.Cancel();
	}

	public override void InitControls()
	{
		transformerObject.transform.localPosition = Vector3.zero;
		if (mSwipeAnimator == null)
		{
			InitAnimators();
		}
	}

	private void InitAnimators()
	{
		Singleton<GuiManager>.instance.FadeIn(this);
		InitHand();
		mSwipeAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mSwipeAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddSwipeAnimations();
		TweenAnimator tweenAnimator = mSwipeAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnSwipeFinished));
		mSwipeAnimator.GenerateTweens();
		mSwipePlaying = false;
		mTapAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mTapAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddTapAnimations();
		TweenAnimator tweenAnimator2 = mTapAnimator;
		tweenAnimator2.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator2.TweenFinished, new Action<int>(OnTapFinished));
		mTapAnimator.GenerateTweens();
		mTapPlaying = false;
		mHoldAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mHoldAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddHoldAnimations();
		TweenAnimator tweenAnimator3 = mHoldAnimator;
		tweenAnimator3.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator3.TweenFinished, new Action<int>(OnHoldFinished));
		mHoldAnimator.GenerateTweens();
		mHoldPlaying = false;
		mInitialized = true;
	}

	public override void InitGUIValues()
	{
	}

	private void InitHand(bool isAngel9 = true)
	{
		gameHand.alpha = 0f;
		gameCircle.color = Colours.blackTransparent;
		gameCircle2.color = Colours.blackTransparent;
		gameRing.color = Colours.blackTransparent;
		gameHandRotate.transform.localPosition = ((!isAngel9) ? mFingerAngel50 : mFingerAngel9);
		gameHandRotate.transform.localRotation = ((!isAngel9) ? Quaternion.Euler(0f, 0f, 41f) : Quaternion.Euler(0f, 0f, 0f));
		gameHand.transform.localScale = mHandScale;
		swipeTrail.SetActive(value: false);
	}

	public void StartSwipeAnimation(Vector3 worldPointFrom, Vector3 worldPointTo, float speed = 0.3f, bool isGui = true, float delay = 0.2f)
	{
		if (!mInitialized)
		{
			InitAnimators();
		}
		mSwipePlaying = true;
		InvokeAfterRealTime(delegate
		{
			if (mSwipePlaying)
			{
				Vector3 vector = TransformWorldPositionToLocal(worldPointFrom, isGui);
				Vector3 vector2 = TransformWorldPositionToLocal(worldPointTo, isGui);
				mSwipeAnimator.ResetTweens();
				mStartPoint = vector;
				pointOfCenter.transform.localPosition = vector;
				mSwipePosition.from = vector;
				mSwipePosition.to = vector2;
				mSwipePosition.time = speed;
				mFadeHand.delay = speed - 0.05f;
				InitHand();
				mSwipeAnimator.PlayTweens();
			}
		}, delay);
	}

	public void UpdateSwipeAnimation(Vector3 worldPointFrom, Vector3 worldPointTo, bool isGui = true)
	{
		Vector3 vector = TransformWorldPositionToLocal(worldPointFrom, isGui);
		Vector3 vector2 = TransformWorldPositionToLocal(worldPointTo, isGui);
		mStartPoint = vector;
		mSwipePosition.from = vector;
		mSwipePosition.to = vector2;
	}

	public void StopSwipeAnimation()
	{
		if (mSwipePlaying)
		{
			mSwipePlaying = false;
			mSwipeAnimator.FinishTweens();
			EndTrail();
			TweenAlpha.Begin(gameHand.gameObject, 0.2f, 0f);
		}
	}

	private void AddSwipeAnimations()
	{
		mSwipeAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, gameHand.gameObject, 0.2f, 1f, 0f);
		mSwipeAnimator.AddTween(2, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.5f, Quaternion.Euler(0f, 0f, 9f), 0f, 1);
		mSwipePosition = mSwipeAnimator.AddTween(from: Vector3.one, id: 3, tweenType: TweenAnimator.TweenType.Position, tweenTarget: pointOfCenter, time: 0.3f, to: Vector3.zero, delay: 0f, playAfterIdFinished: 2, method: UITweener.Method.Linear);
		mSwipeAnimator.AddTween(4, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.25f, Quaternion.Euler(0f, 0f, 0f), 0f, 3);
		mFadeHand = mSwipeAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, gameHand.gameObject, 0.3f, 0f, 0.25f, 2);
	}

	private void OnSwipeFinished(int tweenId)
	{
		if (tweenId == 2)
		{
			StartTrail();
		}
		if (tweenId == 3)
		{
			EndTrail();
		}
		if (tweenId != 5)
		{
			return;
		}
		InvokeAfterRealTime(delegate
		{
			if (mSwipePlaying)
			{
				mSwipeAnimator.ResetTweens();
				pointOfCenter.transform.localPosition = mStartPoint;
				mSwipeAnimator.PlayTweens();
			}
		}, 0.2f);
	}

	private void StartTrail()
	{
		swipeTrail.SetActive(value: true);
		TrailRenderer component = swipeTrail.GetComponent<TrailRenderer>();
		component.time = 0.15f;
	}

	private void EndTrail()
	{
		TrailRenderer component = swipeTrail.GetComponent<TrailRenderer>();
		component.time = 0f;
		swipeTrail.SetActive(value: false);
	}

	public void StartTapAnimation(Vector3 worldPoint, bool isGui = true, bool scaleHand = true, float delay = 0.2f)
	{
		StartTapAnimation(worldPoint, Vector3.zero, isGui, scaleHand, delay);
	}

	public void StartTapAnimation(Vector3 worldPoint, Vector3 localOffset, bool isGui = true, bool scaleHand = true, float delay = 0.2f)
	{
		if (!mInitialized)
		{
			InitAnimators();
		}
		mTapPlaying = true;
		InvokeAfterRealTime(delegate
		{
			if (mTapPlaying)
			{
				Vector3 localPosition = TransformWorldPositionToLocal(worldPoint, isGui);
				localPosition += localOffset;
				mTapAnimator.ResetTweens();
				bool flag = (float)UIRoot.list[0].activeHeight / 2f - mHandScale.y < -1f * localPosition.y || mTapingSmall;
				pointOfCenter.transform.localPosition = localPosition;
				mRotateStart.from = ((!flag) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 41f));
				mRotateStart.to = ((!flag) ? Quaternion.Euler(0f, 0f, 9f) : Quaternion.Euler(0f, 0f, 50f));
				mRotateEnd.to = ((!flag) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 41f));
				InitHand(!flag);
				gameCircle.transform.localScale = Vector3.one;
				gameCircle2.transform.localScale = mCircleScale * 3f;
				if (scaleHand)
				{
					gameHand.transform.localScale = mHandScale.MultiplyXY(3f);
				}
				if (mTapingSmall)
				{
					scaleHand = false;
					gameHand.transform.localScale = mHandScale.MultiplyXY(0.75f);
					gameHandRotate.transform.localPosition = mFingerAngel50 * 0.75f + new Vector3(28f, -6f, 0f);
				}
				TweenAlpha.Begin(gameHand.gameObject, 0.2f, 1f).onFinished = delegate
				{
					if (scaleHand)
					{
						TweenScale.Begin(gameHand.gameObject, 0.3f, mHandScale).onFinished = delegate
						{
							ResetTapAndPlay();
						};
					}
					else
					{
						ResetTapAndPlay();
					}
				};
			}
		}, delay);
	}

	public void UpdateTapAnimation(Vector3 worldPoint, bool isGui = true)
	{
		Vector3 localPosition = TransformWorldPositionToLocal(worldPoint, isGui);
		pointOfCenter.transform.localPosition = localPosition;
	}

	public void UpdateTapAnimation(Vector3 worldPoint, Vector3 localOffset, bool isGui = true)
	{
		Vector3 localPosition = TransformWorldPositionToLocal(worldPoint, isGui) + localOffset;
		pointOfCenter.transform.localPosition = localPosition;
	}

	public void StopTapAnimation()
	{
		if (mTapPlaying)
		{
			mTapPlaying = false;
			mTapAllowed = 0;
			mTapAnimator.FinishTweens();
			TweenAlpha.Begin(gameCircle.gameObject, 0.2f, 0f);
			TweenAlpha.Begin(gameCircle2.gameObject, 0.2f, 0f);
			TweenAlpha.Begin(gameHand.gameObject, 0.2f, 0f);
		}
	}

	private void AddTapAnimations()
	{
		mRotateStart = mTapAnimator.AddTween(1, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.7f, Quaternion.Euler(0f, 0f, 9f), 0f, -1, null, UITweener.Method.EaseIn);
		mTapAnimator.AddTween(2, TweenAnimator.TweenType.Alpha, gameCircle.gameObject, 0.1f, 0.3f, 0.6f, -1, 0f);
		mTapAnimator.AddTween(from: Vector3.one, id: 3, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: gameCircle.gameObject, time: 0.4f, to: mCircleScale, delay: 0.6f, playAfterIdFinished: -1, method: UITweener.Method.Linear);
		mTapAnimator.AddTween(4, TweenAnimator.TweenType.Alpha, gameCircle.gameObject, 0.1f, 0f, 0.2f, 2);
		mTapAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, gameCircle2.gameObject, 0.1f, 0.3f, 0.6f, -1, 0f);
		mTapAnimator.AddTween(from: mCircleScale * 3f, id: 6, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: gameCircle2.gameObject, time: 0.4f, to: Vector3.one, delay: 0.6f, playAfterIdFinished: -1, method: UITweener.Method.Linear);
		mTapAnimator.AddTween(7, TweenAnimator.TweenType.Alpha, gameCircle2.gameObject, 0.1f, 0f, 0.2f, 5);
		mRotateEnd = mTapAnimator.AddTween(8, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.5f, Quaternion.Euler(0f, 0f, 0f), 0f, 1, null, UITweener.Method.EaseOut);
	}

	private void OnTapFinished(int tweenId)
	{
		if (tweenId != 8)
		{
			return;
		}
		if (mTapAllowed != 1)
		{
			InvokeAfterRealTime(delegate
			{
				ResetTapAndPlay();
			}, 0.01f);
		}
		else
		{
			StopTapAnimation();
		}
		mTapAllowed--;
	}

	private void ResetTapAndPlay()
	{
		if (mTapPlaying)
		{
			mTapAnimator.ResetTweens();
			gameCircle.transform.localScale = Vector3.one;
			gameCircle2.transform.localScale = mCircleScale * 3f;
			mTapAnimator.PlayTweens();
		}
	}

	public void StartHoldAnimation(Vector3 worldPoint, bool isGui = true, float delay = 0.2f)
	{
		if (!mInitialized)
		{
			InitAnimators();
		}
		mHoldPlaying = true;
		InvokeAfterRealTime(delegate
		{
			if (mHoldPlaying)
			{
				Vector3 localPosition = TransformWorldPositionToLocal(worldPoint, isGui);
				mHoldAnimator.ResetTweens();
				pointOfCenter.transform.localPosition = localPosition;
				InitHand();
				mHoldAnimator.PlayTweens();
			}
		}, delay);
	}

	public void UpdateHoldAnimation(Vector3 worldPoint, bool isGui = true)
	{
		Vector3 localPosition = TransformWorldPositionToLocal(worldPoint, isGui);
		pointOfCenter.transform.localPosition = localPosition;
	}

	public void StopHoldAnimation()
	{
		if (mHoldPlaying)
		{
			mHoldPlaying = false;
			mHoldAnimator.FinishTweens();
			TweenAlpha.Begin(gameRing.gameObject, 0.2f, 0f);
			TweenAlpha.Begin(gameHand.gameObject, 0.2f, 0f);
		}
	}

	public void InstantStopHoldAnimation()
	{
		if (mHoldPlaying)
		{
			mHoldPlaying = false;
			mHoldAnimator.FinishTweens();
			TweenAlpha.Begin(gameRing.gameObject, 0f, 0f);
			TweenAlpha.Begin(gameHand.gameObject, 0f, 0f);
		}
	}

	private void AddHoldAnimations()
	{
		mHoldAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, gameHand.gameObject, 0.2f, 1f, 0f);
		mHoldAnimator.AddTween(2, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.4f, Quaternion.Euler(0f, 0f, 9f), 0f, 1);
		mHoldAnimator.AddTween(3, TweenAnimator.TweenType.Alpha, gameRing.gameObject, 0.4f, 0.3f, 0.3f, 1, 0f);
		mHoldAnimator.AddTween(from: Vector3.one, id: 4, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: gameRing.gameObject, time: 0.4f, to: 1.5f * mRingScale, delay: 0.3f, playAfterIdFinished: 1);
		float delay = 2f;
		mHoldAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, gameRing.gameObject, 0.4f, 0f, delay, 3);
		mHoldAnimator.AddTween(6, TweenAnimator.TweenType.Scale, gameRing.gameObject, 0.4f, 3f * mRingScale, delay, 3);
		mHoldAnimator.AddTween(7, TweenAnimator.TweenType.Rotation, gameHandRotate, 0.4f, Quaternion.Euler(0f, 0f, 0f), delay, 3);
		mHoldAnimator.AddTween(8, TweenAnimator.TweenType.Alpha, gameHand.gameObject, 0.2f, 0f, 0f, 7);
	}

	private void OnHoldFinished(int tweenId)
	{
		if (tweenId != 8)
		{
			return;
		}
		InvokeAfterRealTime(delegate
		{
			if (mHoldPlaying)
			{
				mHoldAnimator.ResetTweens();
				mHoldAnimator.PlayTweens();
			}
		}, 0.2f);
	}

	public void StartTapingSoldier(int taps = 4)
	{
		mTapAllowed = taps;
		mSoldierTap = GetSoldier();
		if (!(mSoldierTap == null))
		{
			mTapingSmall = true;
			StartTapAnimation(mSoldierTap.destroyableObject.parts[1].transform.position, isGui: false, scaleHand: false);
			mRoutineSoldierTap = RadicalRoutine.Create(UpdateSoldierTap());
			TutorialManagerStage1.instance.StartCoroutine(RadicalRoutine.Run(mRoutineSoldierTap.enumerator));
		}
	}

	public void StopTapingSoldier()
	{
		if (mTapPlaying)
		{
			mRoutineSoldierTap.Cancel();
			StopTapAnimation();
			mTapingSmall = false;
		}
	}

	private IEnumerator UpdateSoldierTap()
	{
		while (mTapPlaying)
		{
			if (!TimeManager.instance.isPaused)
			{
				if (!mSoldierTap.isAlive)
				{
					mSoldierTap = GetSoldier();
					if (mSoldierTap == null)
					{
						StopTapingSoldier();
					}
					else
					{
						UpdateTapAnimation(mSoldierTap.destroyableObject.parts[1].transform.position, isGui: false);
					}
				}
				else
				{
					UpdateTapAnimation(mSoldierTap.destroyableObject.parts[1].transform.position, isGui: false);
				}
			}
			yield return null;
		}
	}

	private EnemyController GetSoldier()
	{
		EnemyController result = null;
		float num = 3200f;
		foreach (PoolableObject item in ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy))
		{
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.isInstantiated && enemyController.fraction == Fractions.Enemies && enemyController.isAlive)
			{
				float num2 = Vector3.Distance(Singleton<MapManager>.instance.currentMapDef.floorTransform.position, enemyController.destroyableObject.parts[1].transform.position);
				if (num2 < num)
				{
					num = num2;
					result = enemyController;
				}
			}
		}
		return result;
	}

	public void StartTapingEnemy()
	{
		mTapAllowed = 4;
		mEnemyTap = PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction);
		if (!(mEnemyTap == null))
		{
			mTapingSmall = true;
			StartTapAnimation(mEnemyTap.destroyableParts.parts[1].transform.position, isGui: false, scaleHand: false);
			mRoutineEnemyTap = RadicalRoutine.Create(UpdateEnemyTap());
			TutorialManagerStage1.instance.StartCoroutine(RadicalRoutine.Run(mRoutineEnemyTap.enumerator));
		}
	}

	public void StopTapingEnemy()
	{
		mRoutineEnemyTap.Cancel();
		StopTapAnimation();
		mTapingSmall = false;
	}

	private IEnumerator UpdateEnemyTap()
	{
		while (true)
		{
			if (!TimeManager.instance.isPaused)
			{
				UpdateTapAnimation(mEnemyTap.destroyableParts.parts[1].transform.position, isGui: false);
			}
			yield return null;
		}
	}

	private IEnumerator HideCheck()
	{
		while (true)
		{
			bool shouldHide = TimeManager.instance.isPaused && !Singleton<GameController>.instance.gameIsRunning;
			if (mWasHidden != shouldHide)
			{
				mWasHidden = shouldHide;
				if (shouldHide)
				{
					TweenAlpha.Begin(base.gameObject, GuiElementSingle<PauseScreen>.instance.fadeInTime, 0f);
					yield return new WaitForRealSeconds(GuiElementSingle<PauseScreen>.instance.fadeInTime);
				}
				else
				{
					TweenAlpha.Begin(base.gameObject, GuiElementSingle<PauseScreen>.instance.fadeOutTime, 1f);
					yield return new WaitForRealSeconds(GuiElementSingle<PauseScreen>.instance.fadeOutTime);
				}
			}
			yield return null;
		}
	}

	public void FinishTweens()
	{
		StopSwipeAnimation();
		StopTapAnimation();
		StopHoldAnimation();
	}

	private Vector3 TransformWorldPositionToLocal(Vector3 worldPosition, bool isGui)
	{
		if (!isGui)
		{
			worldPosition = TransformWorldPositionToGui(worldPosition);
		}
		transformerObject.transform.position = worldPosition;
		Vector3 localPosition = transformerObject.transform.localPosition;
		localPosition.z = -2f;
		transformerObject.transform.localPosition = Vector3.zero;
		return localPosition;
	}

	private Vector3 TransformWorldPositionToGui(Vector3 worldPosition)
	{
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(worldPosition);
		point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
		point.z = 0f;
		return point;
	}

	public void StartGoToBattle(Vector3 position)
	{
		goToBattleLabel.transform.position = position;
		goToBattleLabel.transform.localPosition = new Vector3(goToBattleLabel.transform.localPosition.x, goToBattleLabel.transform.localPosition.y - 3f, -1f);
		TweenColor component = goToBattleLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		goToBattleLabel.color = Color.white.ReplaceA(0f);
		TweenAlpha.Begin(goToBattleLabel.gameObject, 0.3f, 1f).onFinished = delegate
		{
			TweenColor.Begin(goToBattleLabel.gameObject, 0.3f, Color.white, Colours.blue).style = UITweener.Style.PingPong;
		};
	}

	public void StopGoToBattle()
	{
		TweenColor component = goToBattleLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha.Begin(goToBattleLabel.gameObject, 0.3f, 0f).onFinished = null;
	}
}
