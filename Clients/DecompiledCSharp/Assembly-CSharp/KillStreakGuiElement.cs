using System;
using UnityEngine;

public class KillStreakGuiElement : GuiElementSingle<KillStreakGuiElement>
{
	public UISprite blueBackground;

	public UISprite blueCrate;

	public UISprite whiteBackground;

	public UISprite whiteCrate;

	public UILabel scoreStreakLabel;

	public UILabel crateIncomingLabel;

	public UISprite leftBracket;

	public UISprite rightBracket;

	public Color killStreakBasicColor;

	public Color killStreakHighlightColor;

	public UISprite killStreakProgress;

	public UISprite killStreakIcon;

	public GameObject killStreakGUI;

	public UIPanel killstreakPanel;

	private TweenAnimator mAnimator;

	private bool mPlaying;

	private float mLastKillStreakProgress;

	private bool mIsNewKillStreak;

	public bool mStopped;

	[Header("Score Streak Animation")]
	public float blueCrateFadeInTime = 0.1f;

	public float blueCrateFlyInTime = 0.15f;

	public Vector3 blueCrateFlyFrom = new Vector3(-560f, -150f, 0f);

	public Vector3 blueCrateFlyTo = new Vector3(0f, -150f, 0f);

	public Vector3 blueCrateScaleFrom = new Vector3(100f, 100f, 0f);

	public Vector3 blueCrateScaleTo = new Vector3(220f, 220f, 0f);

	public float blueBackgroundPopinDelay = 0.3f;

	public float blueBackgroundPopinUpTime = 0.2f;

	public float blueBackgroundPopinDownTime = 0.2f;

	public Vector3 blueBackgroundPopinScale = new Vector3(1100f, 160.6f, 1f);

	public Vector3 blueBackgroundScale = new Vector3(940f, 160.6f, 1f);

	public float bracketsDelay = 0.7f;

	public float bracketsFlyTime = 0.3f;

	public Vector3 bracketsFlyFrom = new Vector3(-470f, -149f, 0f);

	public Vector3 bracketsFlyTo = new Vector3(-570f, -149f, 0f);

	public float blueCrateOutDelay = 0.1f;

	public float blueCrateJumpUp = -50f;

	public float blueCrateJumpDown = 50f;

	public float blueCrateJumpUpTime = 0.1f;

	public float blueCrateJumpDownTime = 0.1f;

	public float scoreStreakFadeInDelay = 0.6f;

	public float scoreStreakFadeInTime = 0.1f;

	public float scoreStreakFadeOutDelay = 0.4f;

	public float scoreStreakFadeOutTime = 0.2f;

	public float whiteBackgroundDelay = 1.4f;

	public float whiteBackgroundFadeInTime = 0.1f;

	public float whiteCrateJumpUpTime = 0.1f;

	public Vector3 crateIncomingTo = new Vector3(50f, -160f, -50f);

	public float crateIncomingJumpDown = 50f;

	public Vector3 whiteCrateTo = new Vector3(-450f, -150f, 0f);

	public float whiteCrateJumpDown = -50f;

	public float whiteCrateJumpUp = 25f;

	public float whiteBackgroundBlinkDelay = 0.7f;

	public float whiteBackgroundBlinkTime = 0.05f;

	public override void InitEvents()
	{
		base.InitEvents();
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		InitScoreStreakAnimation();
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(TweenFinished));
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<GameController>.instance.GameStarted += InstanceGameStarted;
	}

	public override void InitControls()
	{
	}

	public void Stop()
	{
		if (mPlaying)
		{
			mAnimator.FinishTweens();
			mPlaying = false;
		}
		mStopped = true;
	}

	public void Resume()
	{
		mStopped = false;
	}

	private void InstanceGameStarted()
	{
		killStreakGUI.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		mAnimator.FinishTweens();
		mPlaying = false;
	}

	private void TweenFinished(int i)
	{
		if (i == 36)
		{
			mPlaying = false;
			GuiElementSingle<RibbonGuiElement>.instance.Resume();
			killstreakPanel.gameObject.SetActive(value: false);
		}
	}

	public override void InitGUIValues()
	{
		mIsNewKillStreak = false;
		mLastKillStreakProgress = 0f;
		blueBackground.alpha = 0f;
		blueCrate.alpha = 0f;
		whiteBackground.alpha = 0f;
		whiteCrate.alpha = 0f;
		scoreStreakLabel.alpha = 0f;
		crateIncomingLabel.alpha = 0f;
		leftBracket.alpha = 0f;
		rightBracket.alpha = 0f;
	}

	protected override void Update()
	{
		base.Update();
		KillStreakProgressBar();
		if (mPlaying)
		{
			killstreakPanel.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
	}

	private void NewKillStreak()
	{
		PopKillstreakIcon();
		mAnimator.PlayTweens();
		mPlaying = true;
		GuiElementSingle<RibbonGuiElement>.instance.Stop();
	}

	private void KillStreakProgressBar()
	{
		if (Singleton<ScoreManager>.instance.isNewKillStreak && !mStopped)
		{
			Singleton<ScoreManager>.instance.isNewKillStreak = false;
			mIsNewKillStreak = true;
			NewKillStreak();
			TweenColor tweenColor = TweenColor.Begin(killStreakProgress.gameObject, 0.2f, killStreakBasicColor, killStreakHighlightColor);
			tweenColor.style = UITweener.Style.PingPong;
			tweenColor.NumOfRepetitions = 6;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, (UITweener.OnFinished)delegate
			{
				mLastKillStreakProgress = 0f;
				mIsNewKillStreak = false;
			});
			killstreakPanel.gameObject.SetActive(value: true);
		}
		if (mIsNewKillStreak)
		{
			mLastKillStreakProgress = Mathf.Lerp(mLastKillStreakProgress, 100f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(8f, ignoreTimeScale: true));
		}
		else
		{
			mLastKillStreakProgress = Mathf.Lerp(mLastKillStreakProgress, Singleton<ScoreManager>.instance.killStreakProgress, Time.deltaTime * TimeManager.GetTimeScaledSpeed(5f, ignoreTimeScale: true));
		}
		killStreakProgress.fillAmount = mLastKillStreakProgress * 0.01f;
	}

	private void PopKillstreakIcon()
	{
		TweenScale tweenScale = TweenScale.Begin(killStreakIcon.gameObject, 0.1f, new Vector3(70f, 70f, 1f));
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(killStreakIcon.gameObject, 0.2f, new Vector3(50f, 50f, 1f));
			tweenScale2.method = UITweener.Method.EaseIn;
		};
	}

	private void InitScoreStreakAnimation()
	{
		float num = 1.3333334f;
		float num2 = 1.7777778f;
		float num3 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num, num2);
		float num4 = (num3 - num2) / (num - num2);
		blueCrateFlyFrom.x = -1026f + num4 * 211f;
		mAnimator.allTweens.Clear();
		mAnimator.AddTween(1000, TweenAnimator.TweenType.Alpha, blueBackground.gameObject, 0f, 1f, 0f, -1, 1f);
		mAnimator.AddTween(from: blueCrateScaleFrom, id: 1001, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: blueCrate.gameObject, time: blueCrateFlyInTime, to: blueCrateScaleTo, delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseOut);
		mAnimator.AddTween(from: crateIncomingTo.AddY(crateIncomingJumpDown), id: 1002, tweenType: TweenAnimator.TweenType.Position, tweenTarget: crateIncomingLabel.gameObject, time: whiteBackgroundFadeInTime, to: crateIncomingTo, delay: 0f, playAfterIdFinished: 20);
		mAnimator.AddTween(0, TweenAnimator.TweenType.Alpha, blueCrate.gameObject, blueCrateFadeInTime, 1f, 0f, -1, 0f, UITweener.Method.EaseOut);
		mAnimator.AddTween(from: blueCrateFlyFrom, id: 1, tweenType: TweenAnimator.TweenType.Position, tweenTarget: blueCrate.gameObject, time: blueCrateFlyInTime, to: blueCrateFlyTo, delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseOut);
		mAnimator.AddTween(from: new Vector3(0f, 0f, 1f), id: 2, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: blueBackground.gameObject, time: blueBackgroundPopinDelay, to: new Vector3(0f, 0f, 1f), delay: 0f);
		mAnimator.AddTween(from: blueBackgroundPopinScale.ReplaceX(0f), id: 3, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: blueBackground.gameObject, time: blueBackgroundPopinUpTime, to: blueBackgroundPopinScale, delay: 0f, playAfterIdFinished: 2);
		mAnimator.AddTween(from: blueBackgroundPopinScale, id: 4, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: blueBackground.gameObject, time: blueBackgroundPopinDownTime, to: blueBackgroundScale, delay: 0f, playAfterIdFinished: 3);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, leftBracket.gameObject, bracketsDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(from: bracketsFlyFrom, id: 6, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftBracket.gameObject, time: bracketsFlyTime, to: bracketsFlyTo, delay: 0f, playAfterIdFinished: 5, method: UITweener.Method.EaseOut);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Alpha, leftBracket.gameObject, bracketsFlyTime, 0f, 0f, 5, 1f, UITweener.Method.EaseOut);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Alpha, rightBracket.gameObject, bracketsDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(from: bracketsFlyFrom.ReplaceX(0f - bracketsFlyFrom.x), id: 9, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rightBracket.gameObject, time: bracketsFlyTime, to: bracketsFlyTo.ReplaceX(0f - bracketsFlyTo.x), delay: 0f, playAfterIdFinished: 8, method: UITweener.Method.EaseOut);
		mAnimator.AddTween(10, TweenAnimator.TweenType.Alpha, rightBracket.gameObject, bracketsFlyTime, 0f, 0f, 8, 1f, UITweener.Method.EaseOut);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Alpha, blueCrate.gameObject, blueCrateOutDelay, 1f, 0f, 1, 1f);
		mAnimator.AddTween(from: blueCrateFlyTo, id: 12, tweenType: TweenAnimator.TweenType.Position, tweenTarget: blueCrate.gameObject, time: blueCrateJumpUpTime, to: blueCrateFlyTo.AddY(blueCrateJumpUp), delay: 0f, playAfterIdFinished: 11);
		mAnimator.AddTween(from: blueCrateFlyTo, id: 13, tweenType: TweenAnimator.TweenType.Position, tweenTarget: blueCrate.gameObject, time: blueCrateJumpDownTime, to: blueCrateFlyTo.AddY(blueCrateJumpDown), delay: 0f, playAfterIdFinished: 12);
		mAnimator.AddTween(14, TweenAnimator.TweenType.Alpha, blueCrate.gameObject, blueCrateOutDelay, 0f, 0f, 12, 1f);
		mAnimator.AddTween(15, TweenAnimator.TweenType.Alpha, scoreStreakLabel.gameObject, scoreStreakFadeInDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(16, TweenAnimator.TweenType.Alpha, scoreStreakLabel.gameObject, scoreStreakFadeInTime, 1f, 0f, 15, 0f);
		mAnimator.AddTween(17, TweenAnimator.TweenType.Alpha, scoreStreakLabel.gameObject, scoreStreakFadeOutDelay, 1f, 0f, 16, 1f);
		mAnimator.AddTween(18, TweenAnimator.TweenType.Alpha, scoreStreakLabel.gameObject, scoreStreakFadeOutTime, 0f, 0f, 17, 1f);
		mAnimator.AddTween(19, TweenAnimator.TweenType.Alpha, blueBackground.gameObject, scoreStreakFadeOutTime, 0f, 0f, 17, 1f);
		mAnimator.AddTween(20, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(21, TweenAnimator.TweenType.Alpha, whiteCrate.gameObject, whiteBackgroundDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(22, TweenAnimator.TweenType.Alpha, crateIncomingLabel.gameObject, whiteBackgroundDelay, 0f, 0f, -1, 0f);
		mAnimator.AddTween(23, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundFadeInTime, 0.75f, 0f, 20, 0f);
		mAnimator.AddTween(24, TweenAnimator.TweenType.Alpha, whiteCrate.gameObject, whiteBackgroundFadeInTime, 1f, 0f, 20, 0f);
		mAnimator.AddTween(25, TweenAnimator.TweenType.Alpha, crateIncomingLabel.gameObject, whiteBackgroundFadeInTime, 1f, 0f, 20, 0f);
		mAnimator.AddTween(from: whiteCrateTo.AddY(whiteCrateJumpUp), id: 26, tweenType: TweenAnimator.TweenType.Position, tweenTarget: whiteCrate.gameObject, time: whiteBackgroundFadeInTime, to: whiteCrateTo.AddY(whiteCrateJumpDown), delay: 0f, playAfterIdFinished: 20);
		mAnimator.AddTween(from: whiteCrateTo.AddY(whiteCrateJumpDown), id: 27, tweenType: TweenAnimator.TweenType.Position, tweenTarget: whiteCrate.gameObject, time: whiteBackgroundFadeInTime, to: whiteCrateTo, delay: 0f, playAfterIdFinished: 26);
		mAnimator.AddTween(28, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundBlinkDelay, 0.75f, 0f, 20, 0.75f);
		mAnimator.AddTween(29, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundBlinkTime, 0f, 0f, 28, 0.75f);
		mAnimator.AddTween(30, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundBlinkTime, 0.75f, 0f, 29, 0f);
		mAnimator.AddTween(31, TweenAnimator.TweenType.Alpha, whiteBackground.gameObject, whiteBackgroundBlinkTime, 0f, 0f, 30, 0.75f);
		mAnimator.AddTween(32, TweenAnimator.TweenType.Alpha, crateIncomingLabel.gameObject, whiteBackgroundBlinkTime, 0f, 0f, 28, 1f);
		mAnimator.AddTween(33, TweenAnimator.TweenType.Alpha, crateIncomingLabel.gameObject, whiteBackgroundBlinkTime, 1f, 0f, 32, 0f);
		mAnimator.AddTween(34, TweenAnimator.TweenType.Alpha, crateIncomingLabel.gameObject, whiteBackgroundBlinkTime, 0f, 0f, 33, 1f);
		mAnimator.AddTween(from: whiteCrateTo, id: 35, tweenType: TweenAnimator.TweenType.Position, tweenTarget: whiteCrate.gameObject, time: whiteBackgroundBlinkTime, to: whiteCrateTo.AddY(whiteCrateJumpDown), delay: 0f, playAfterIdFinished: 31);
		mAnimator.AddTween(36, TweenAnimator.TweenType.Alpha, whiteCrate.gameObject, whiteBackgroundBlinkTime, 0f, 0f, 31, 1f);
	}
}
