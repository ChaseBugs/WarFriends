using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScreen : GuiScreenSingle<HudScreen>
{
	[Header("Score")]
	public UISprite touchCircleSpriteSmall;

	public UILabel scoreLabel;

	public UILabel scoreAddedLabel;

	[Header("Overlays")]
	public UISprite slowMotionOverlay;

	public UISprite bloodOverlay;

	[Header("Bonus Progress and Fight")]
	public UISprite fight;

	public UISprite fightGlow;

	[Header("Reloading and No Ammo Indicators")]
	public UISprite reloadingProgress;

	public UISprite reloadingProgressBg;

	public GameObject reloadingGO;

	public Transform noAmmoTransform;

	public Transform reloadingIcoTransform;

	public UISprite reloadingIcoSprite;

	private PlayerWeapon mWeapon;

	[Header("Bazooka Targetting")]
	public UISprite bazookaTargettingCenter;

	public UISprite bazookaTargettingBorder;

	[Header("Pause")]
	public UIButton pauseButton;

	public UILabel pingLabel;

	[Header("Hit Arrow")]
	public GameObject hitArrow;

	private UISprite mHitArrowSprite;

	[Header("Flash Overlay")]
	public UISprite flashSprite;

	[Header("Hint")]
	public GameObject hintToKillEnemyPlayer;

	[Header("Recording Icon")]
	public GameObject recordingIcon;

	private TweenAnimator mAnimator;

	private int mLastScore;

	private bool mIsReloading;

	private bool mIsNoammoShowed;

	private bool mIsWeaponReloading;

	private bool mBazookaShootingAnimating;

	private int mNumberOfFlash = 4;

	private float mAccumulatedDamage;

	private float mAccumulatedDamageSmooth;

	private bool mCanPlayHitArrow = true;

	private float mFightAnimationInitialDelay = 0.5f;

	private float mFightAnimationScaleDownTime = 0.2f;

	private float mFightAnimationScaleUpTime = 0.15f;

	private float mFightAnimationDelayTime = 0.3f;

	private float mFightAnimationScaleBlink0Time = 0.03f;

	private float mFightAnimationScaleBlink1Time = 0.05f;

	private float mFightAnimationScaleFrom = 7f;

	private float mFightAnimationScaleTo = 0.8f;

	private float mFightAnimationScaleToTo = 1.2f;

	private float mFightAnimationGlowScaleUpTime = 0.1f;

	private float mFightAnimationGlowScaleDownTime = 0.4f;

	private Vector2 mFightAnimationGlowScale = new Vector2(10f, 7f);

	private float mFightAnimationMusicDelay = 0.5f;

	private float mSoundDelay = 0.55f;

	private float mTimerForUpdate;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += InstanceGameStarted;
		mHitArrowSprite = hitArrow.GetComponentsInChildren<UISprite>(includeInactive: true)[0];
		Singleton<ScoreManager>.instance.ScoreChanged += OnScoreChanged;
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.AddTween(from: scoreAddedLabel.transform.localPosition + new Vector3(1000f, 0f, 0f), id: 0, tweenType: TweenAnimator.TweenType.Position, tweenTarget: scoreAddedLabel.gameObject, time: 0.5f, to: scoreAddedLabel.transform.localPosition, delay: 0f);
		mAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, scoreAddedLabel.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(2, TweenAnimator.TweenType.Alpha, scoreAddedLabel.gameObject, 0.1f, 0f, 0.25f, 1, 1f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		mAnimator.AddTween(from: new Vector3(66f, 66f, 1f), id: 3, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: scoreLabel.gameObject, time: 0.3f, to: new Vector3(99f, 99f, 1f), delay: 0.2f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(from: new Vector3(99f, 99f, 1f), id: 4, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: scoreLabel.gameObject, time: 0.3f, to: new Vector3(66f, 66f, 1f), delay: 0.3f, playAfterIdFinished: 3, method: UITweener.Method.EaseOut);
		mAnimator.GenerateTweens();
		UIEventListener uIEventListener = UIEventListener.Get(pauseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PauseClick));
	}

	protected override void InitControls()
	{
	}

	protected override void Awake()
	{
		base.Awake();
		bloodOverlay.gameObject.SetActive(value: true);
	}

	private void InstanceGameStarted()
	{
		TweenTextCounter.Begin(scoreLabel.gameObject, 0.01f, new IntObject(Singleton<ScoreManager>.instance.score), new IntObject(Singleton<ScoreManager>.instance.score)).delay = 0f;
		mLastScore = Singleton<ScoreManager>.instance.score;
		scoreAddedLabel.alpha = 0f;
		mIsReloading = false;
		reloadingGO.SetActive(value: false);
		mIsNoammoShowed = false;
		noAmmoTransform.gameObject.SetActive(value: false);
		mIsWeaponReloading = false;
		reloadingIcoTransform.gameObject.SetActive(value: false);
		TweenAlpha.Begin(bloodOverlay.gameObject, 0f, 0f);
		mAccumulatedDamage = 0f;
		mAccumulatedDamageSmooth = 0f;
		StopBazzokaAnimation();
		hintToKillEnemyPlayer.gameObject.SetActive(value: false);
		TweenAlpha.Begin(mHitArrowSprite.gameObject, 0f, 0f);
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			FightAnimation();
			InvokeAfter(delegate
			{
				if (!DebugSettings.instance.data.showHud)
				{
					mPanels = GetComponentsInChildren<UIPanel>();
					UIPanel[] array = mPanels;
					foreach (UIPanel uIPanel in array)
					{
						TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, fadeOutTime, 0.0051f);
						tweenAlpha.method = UITweener.Method.EaseInOut;
					}
					GuiElementSingle<PlayerHealthBars>.instance.InitGUIValues();
				}
			}, 1.1f);
		}
		else
		{
			SoundsManager.Instance.PlayGameMusic();
			fight.gameObject.SetActive(value: false);
			fightGlow.gameObject.SetActive(value: false);
		}
		flashSprite.gameObject.SetActive(value: false);
		hintToKillEnemyPlayer.gameObject.SetActive(value: false);
	}

	private void PauseClick(GameObject go)
	{
		Singleton<GameController>.instance.mainController.PauseGame(focusLost: false);
	}

	public void ShowKillEnemyHint()
	{
		TweenAlpha.Begin(hintToKillEnemyPlayer, 0.3f, 1f);
		hintToKillEnemyPlayer.gameObject.SetActive(value: true);
	}

	public void HideKillEnemyHint()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(hintToKillEnemyPlayer, 0.3f, 0f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			hintToKillEnemyPlayer.gameObject.SetActive(value: true);
		});
	}

	public void PlayFlash(float time, float intensity)
	{
		flashSprite.gameObject.SetActive(value: true);
		flashSprite.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flashSprite.gameObject, time, intensity, 0f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.delay = 0.15f;
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(FlashOnFinished));
	}

	private void FlashOnFinished(UITweener tween)
	{
		flashSprite.gameObject.SetActive(value: false);
	}

	private void OnScoreChanged(int newScore, int difference)
	{
		scoreAddedLabel.text = "+" + difference;
		mAnimator.PlayTweens();
		TweenTextCounter.Begin(scoreLabel.gameObject, 1f, new IntObject(mLastScore), new IntObject(newScore)).delay = 0.5f;
		mLastScore = newScore;
	}

	public override void InitGUIValues()
	{
	}

	public void PlayWeaponReloading(PlayerWeapon weapon)
	{
		if (weapon.playerController.isCurrentPlayer)
		{
			reloadingGO.transform.position = GetLocalPositionFromScreen(Input.mousePosition);
			reloadingGO.SetActive(value: true);
			mWeapon = weapon;
			mIsReloading = true;
			reloadingProgress.fillAmount = mWeapon.weapon.nextShootProgress;
			TweenAlpha.Begin(reloadingProgress.gameObject, 0.3f, 0f, 1f);
			TweenAlpha.Begin(reloadingProgressBg.gameObject, 0.3f, 0f, 1f);
			TweenPosition.Begin(reloadingProgress.gameObject, 0.3f, Vector3.zero, Vector3.up * 100f);
			TweenPosition.Begin(reloadingProgressBg.gameObject, 0.3f, Vector3.zero, Vector3.up * 100f);
		}
	}

	public void ShowNoAmmoMagazine(PlayerWeapon weapon)
	{
		if (weapon.playerController.isCurrentPlayer)
		{
			noAmmoTransform.position = GetLocalPositionFromScreen(Input.mousePosition);
			Vector3 localPosition = noAmmoTransform.localPosition;
			localPosition.z = 0f;
			localPosition.y += 100f;
			noAmmoTransform.localPosition = localPosition;
			RestrictByScreen(noAmmoTransform, noAmmoTransform.localScale);
			noAmmoTransform.gameObject.SetActive(value: true);
			mWeapon = weapon;
			if (!mIsNoammoShowed)
			{
				TweenAlpha.Begin(reloadingProgress.gameObject, 0.3f, 1f).alpha = 0f;
			}
			mIsNoammoShowed = true;
		}
	}

	public void ShowReloadingIco(PlayerWeapon weapon)
	{
		if (weapon.playerController.isCurrentPlayer)
		{
			reloadingIcoTransform.position = GetLocalPositionFromScreen(Input.mousePosition);
			Vector3 localPosition = reloadingIcoTransform.localPosition;
			localPosition.z = 0f;
			localPosition.y += 100f;
			reloadingIcoTransform.localPosition = localPosition;
			RestrictByScreen(reloadingIcoTransform, reloadingIcoSprite.cachedTransform.localScale);
			reloadingIcoTransform.gameObject.SetActive(value: true);
			mWeapon = weapon;
			reloadingIcoSprite.fillAmount = mWeapon.weapon.reloadProgress;
			if (!mIsWeaponReloading)
			{
				TweenAlpha.Begin(reloadingIcoTransform.gameObject.gameObject, 0.3f, 1f).alpha = 0f;
			}
			mIsWeaponReloading = true;
		}
	}

	public void StartBazzokaTargettingAnimation(float time)
	{
		if (mBazookaShootingAnimating)
		{
			return;
		}
		mBazookaShootingAnimating = true;
		TweenScale.Begin(bazookaTargettingBorder.gameObject, 0.02f, new Vector3(440f, 440f, 1f));
		float dur = time - 0.1f;
		bazookaTargettingCenter.transform.parent.position = GetLocalPositionFromScreen(Input.mousePosition);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(bazookaTargettingCenter.gameObject, 0.1f, 0f, 1f);
		tweenAlpha.delay = 0f;
		TweenAlpha.Begin(bazookaTargettingBorder.gameObject, 0.1f, 0f, 1f).onFinished = delegate
		{
			if (mBazookaShootingAnimating)
			{
				mNumberOfFlash = 0;
				TweenScale.Begin(bazookaTargettingBorder.gameObject, dur, new Vector3(440f, 440f, 1f), new Vector3(190f, 190f, 1f)).onFinished = FlashingTargetting;
			}
		};
	}

	private void FlashingTargetting(UITweener tween)
	{
		if (!mBazookaShootingAnimating || mNumberOfFlash > 4)
		{
			return;
		}
		mNumberOfFlash++;
		TweenAlpha.Begin(bazookaTargettingBorder.gameObject, 0.01f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(bazookaTargettingCenter.gameObject, 0.01f, 0f);
		tweenAlpha.delay = 0.025f;
		tweenAlpha.onFinished = delegate
		{
			if (mNumberOfFlash == 4)
			{
				mBazookaShootingAnimating = false;
			}
			if (mBazookaShootingAnimating)
			{
				TweenAlpha.Begin(bazookaTargettingBorder.gameObject, 0.01f, 1f);
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(bazookaTargettingCenter.gameObject, 0.01f, 1f);
				tweenAlpha2.delay = 0.025f;
				tweenAlpha2.onFinished = FlashingTargetting;
			}
		};
	}

	public void StopBazzokaAnimation()
	{
		mBazookaShootingAnimating = false;
		mNumberOfFlash = 4;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(bazookaTargettingCenter.gameObject, 0.02f, 0f);
		tweenAlpha.delay = 0f;
		TweenAlpha.Begin(bazookaTargettingBorder.gameObject, 0.02f, 0f);
	}

	protected override void Update()
	{
		base.Update();
		mAccumulatedDamage -= Time.deltaTime * 30f;
		mAccumulatedDamage = Mathf.Clamp(mAccumulatedDamage, 0f, 100f);
		mAccumulatedDamageSmooth = Mathf.Lerp(mAccumulatedDamageSmooth, mAccumulatedDamage, Time.deltaTime * 6f);
		bloodOverlay.alpha = mAccumulatedDamageSmooth * 0.03f;
		if (mIsReloading)
		{
			reloadingProgress.fillAmount = mWeapon.weapon.nextShootProgress;
			if (mWeapon.weapon.nextShootProgress >= 0.99f || !mWeapon.isActiveWeapon)
			{
				reloadingGO.SetActive(value: false);
				mIsReloading = false;
			}
		}
		if (mIsNoammoShowed && (!mWeapon.isActiveWeapon || !mWeapon.weapon.outOfAmmo))
		{
			noAmmoTransform.gameObject.SetActive(value: false);
			mIsNoammoShowed = false;
		}
		if (mIsWeaponReloading)
		{
			if (!mWeapon.isActiveWeapon || !mWeapon.weapon.isReloading)
			{
				reloadingIcoTransform.gameObject.SetActive(value: false);
				mIsWeaponReloading = false;
			}
			else
			{
				reloadingIcoSprite.fillAmount = mWeapon.weapon.reloadProgress;
			}
		}
		slowMotionOverlay.alpha = Singleton<SlowMotionManager>.instance.slowMotionStrength;
		slowMotionOverlay.gameObject.SetActive(Singleton<SlowMotionManager>.instance.slowMotionStrength > 0.01f && Singleton<GameController>.instance.gameIsRunning && !Singleton<GameController>.instance.isTutorial);
		recordingIcon.gameObject.SetActive(Singleton<Recording>.instance.isRecording);
		mTimerForUpdate += Time.deltaTime;
		if (mTimerForUpdate >= 0.333f)
		{
			mTimerForUpdate -= 0.333f;
			pingLabel.text = ((!DebugSettings.debugEnabled) ? string.Empty : $"{PhotonNetwork.GetPing()}ms");
		}
	}

	public void PlayBloodOverlay(float damageAmount, float angle)
	{
		if (DebugSettings.instance.data.playBlood)
		{
			float num = (float)Singleton<GameVariables>.instance.balancetable.Rows[0].PLAYERHP / PlayerController.currentPlayer.destroyableParts.maxHealth;
			mAccumulatedDamage += damageAmount * num;
			if (angle != float.MaxValue && mCanPlayHitArrow)
			{
				hitArrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(mHitArrowSprite.gameObject, 0.2f, 1f);
				tweenAlpha.delay = 0f;
				tweenAlpha.onFinished = HitArrowColor;
			}
		}
	}

	private void HitArrowColor(UITweener tween)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mHitArrowSprite.gameObject, 0.5f, 0f);
		tweenAlpha.delay = 0.2f;
	}

	public void StopHitArrow()
	{
		mCanPlayHitArrow = false;
	}

	public void ResumeHitArrow()
	{
		mCanPlayHitArrow = true;
	}

	public void PlayTouchCircleSmall(Vector3 worldPosition)
	{
		touchCircleSpriteSmall.transform.position = GetLocalPosition(worldPosition);
		touchCircleSpriteSmall.alpha = 0f;
		TweenAlpha.Begin(touchCircleSpriteSmall.gameObject, 0.2f, 0.5f);
		TweenScale tweenScale = TweenScale.Begin(touchCircleSpriteSmall.gameObject, 0.2f, new Vector3(200f, 200f, 200f), new Vector3(109f, 109f, 109f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(OnPlayCircleSmall));
		touchCircleSpriteSmall.MakePixelPerfect();
	}

	private void OnPlayCircleSmall(UITweener tween)
	{
		TweenAlpha.Begin(touchCircleSpriteSmall.gameObject, 0.6f, 0f);
		TweenScale tweenScale = TweenScale.Begin(touchCircleSpriteSmall.gameObject, 0.6f, new Vector3(0f, 0f, 0f));
		tweenScale.method = UITweener.Method.EaseOut;
	}

	public void RestrictByScreen(Transform t, Vector3 size)
	{
		UIRoot uIRoot = UIRoot.list[0];
		float num = uIRoot.activeWidth * 0.5f / base.transform.localScale.x - 10f;
		float num2 = (float)uIRoot.activeHeight * 0.5f / base.transform.localScale.y - 10f;
		Vector3 localPosition = t.localPosition;
		bool flag = false;
		if (localPosition.y > 0f)
		{
			if (localPosition.y + size.y * 0.5f > num2)
			{
				localPosition.y = num2 - size.y * 0.5f - 20f;
				localPosition.x -= size.x + 20f;
				flag = true;
			}
		}
		else if (localPosition.y - size.y * 0.5f < 0f - num2)
		{
			localPosition.y = 20f + size.y * 0.5f - num2;
		}
		if (localPosition.x < 0f)
		{
			if (localPosition.x - size.x * 0.5f < 0f - num)
			{
				float num3 = size.x * 0.5f - num;
				if (flag)
				{
					float b = t.localPosition.x + size.x * 0.5f + 20f;
					localPosition.x = Mathf.Max(num3, b);
				}
				else
				{
					localPosition.x = num3;
				}
			}
		}
		else if (localPosition.x + size.x * 0.5f > num)
		{
			float num4 = num - size.x * 0.5f;
			if (flag)
			{
				float b2 = t.localPosition.x - size.x * 0.5f - 20f;
				localPosition.x = Mathf.Min(num4, b2);
			}
			else
			{
				localPosition.x = num4;
			}
		}
		t.localPosition = localPosition;
	}

	private Vector3 GetLocalPosition(Vector3 worldPosition)
	{
		Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(worldPosition);
		point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
		point.z = 0f;
		return point;
	}

	private Vector3 GetLocalPositionFromScreen(Vector3 screen)
	{
		Vector3 point = Camera.main.ScreenToViewportPoint(screen);
		point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
		point.z = 0f;
		return point;
	}

	public void SetTransparent()
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: true);
		UIPanel[] array = componentsInChildren;
		foreach (UIPanel uIPanel in array)
		{
			TweenAlpha.Begin(uIPanel.gameObject, 0f, 0f);
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (GuiElementSingle<PlayerHealthBars>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<PlayerHealthBars>.instance);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (!GuiElementSingle<PlayerHealthBars>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
		}
	}

	public override void OnBack()
	{
		PauseClick(pauseButton.gameObject);
	}

	public override void OnMenu()
	{
		PauseClick(pauseButton.gameObject);
	}

	private void FightAnimation()
	{
		StartCoroutine(PlayFightSound());
		fight.gameObject.SetActive(value: true);
		fightGlow.gameObject.SetActive(value: true);
		fight.MakePixelPerfect();
		float fightScaleX = fight.transform.localScale.x;
		float fightScaleY = fight.transform.localScale.y;
		float glowScaleX = 500f;
		float glowScaleY = 109f;
		TweenAlpha.Begin(fight.gameObject, 0f, 1f);
		TweenScale.Begin(fight.gameObject, 0f, Vector3.zero);
		TweenAlpha.Begin(fightGlow.gameObject, 0f, 0f);
		TweenScale.Begin(fightGlow.gameObject, 0f, Vector3.zero);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(fight.gameObject, mFightAnimationInitialDelay, 1f);
		tweenAlpha.onFinished = delegate
		{
			TweenScale tweenScale = TweenScale.Begin(fight.gameObject, mFightAnimationScaleDownTime, new Vector3(fightScaleX * mFightAnimationScaleFrom, fightScaleY * mFightAnimationScaleFrom, 1f), new Vector3(fightScaleX * mFightAnimationScaleTo, fightScaleY * mFightAnimationScaleTo, 1f));
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = delegate
			{
				InvokeAfter(delegate
				{
					SoundsManager.Instance.PlayGameMusic();
				}, mFightAnimationMusicDelay);
				TweenScale tweenScale2 = TweenScale.Begin(fight.gameObject, mFightAnimationScaleUpTime, new Vector3(fightScaleX * mFightAnimationScaleTo, fightScaleY * mFightAnimationScaleTo, 1f), new Vector3(fightScaleX * mFightAnimationScaleToTo, fightScaleY * mFightAnimationScaleToTo, 1f));
				tweenScale2.method = UITweener.Method.EaseOut;
				tweenScale2.onFinished = delegate
				{
					TweenAlpha tweenAlpha3 = TweenAlpha.Begin(fight.gameObject, mFightAnimationDelayTime, 1f);
					tweenAlpha3.onFinished = delegate
					{
						FightAnimationBlink(3);
					};
				};
			};
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(fightGlow.gameObject, mFightAnimationScaleDownTime, 0f);
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha.Begin(fightGlow.gameObject, 0f, 1f);
				TweenScale tweenScale2 = TweenScale.Begin(fightGlow.gameObject, mFightAnimationGlowScaleUpTime, new Vector3(glowScaleX * 0.001f, glowScaleY * 0.001f, 1f), new Vector3(glowScaleX * mFightAnimationGlowScale.x, glowScaleY * mFightAnimationGlowScale.y, 1f));
				tweenScale2.method = UITweener.Method.Linear;
				tweenScale2.onFinished = delegate
				{
					TweenScale tweenScale3 = TweenScale.Begin(fightGlow.gameObject, mFightAnimationGlowScaleDownTime, new Vector3(glowScaleX * mFightAnimationGlowScale.x, glowScaleY * mFightAnimationGlowScale.y, 1f), new Vector3(glowScaleX * 0.001f, glowScaleY * 0.001f, 1f));
					tweenScale3.method = UITweener.Method.EaseOut;
					tweenScale3.onFinished = delegate
					{
						fightGlow.gameObject.SetActive(value: false);
					};
				};
			};
		};
	}

	private void FightAnimationBlink(int count)
	{
		if (count == 0)
		{
			TweenAlpha.Begin(fight.gameObject, 0f, 0f);
			fight.gameObject.SetActive(value: false);
			return;
		}
		TweenAlpha.Begin(fight.gameObject, 0f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(fight.gameObject, mFightAnimationScaleBlink0Time, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(fight.gameObject, 0f, 1f);
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(fight.gameObject, mFightAnimationScaleBlink1Time, 1f);
			tweenAlpha2.onFinished = delegate
			{
				FightAnimationBlink(count - 1);
			};
		};
	}

	private IEnumerator PlayFightSound()
	{
		yield return new WaitForSeconds(mSoundDelay);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Fight);
	}
}
