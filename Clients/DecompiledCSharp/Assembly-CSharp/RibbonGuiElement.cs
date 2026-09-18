using System;
using System.Collections.Generic;
using UnityEngine;

public class RibbonGuiElement : GuiElementSingle<RibbonGuiElement>
{
	public GameObject ribbonParent;

	public UISprite ribbonIcon;

	public UISprite ribbonIconBg;

	public UILabel ribbonName;

	public UILabel labelNewRibbon;

	public UILabel score;

	public UILabel scoreAdded;

	private TweenAnimator mAnimator;

	public static Queue<RibbonManager.RibbonItemDefinition> events = new Queue<RibbonManager.RibbonItemDefinition>();

	private bool mIsAnimationPlaying;

	private bool mStopped;

	private UIPanel mPanel;

	public override void InitControls()
	{
		events = new Queue<RibbonManager.RibbonItemDefinition>();
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.GenerateTweens();
		AddAnimations();
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		mAnimator.FinishTweens();
		events = new Queue<RibbonManager.RibbonItemDefinition>();
		mIsAnimationPlaying = false;
	}

	private void AddAnimations()
	{
		float time = 0.4f;
		float delay = 0.5f;
		mAnimator.AddTween(15, TweenAnimator.TweenType.Alpha, score.gameObject, 0.2f, 0f, 0f);
		mAnimator.AddTween(16, TweenAnimator.TweenType.Alpha, scoreAdded.gameObject, 0.2f, 0f, 0f);
		mAnimator.AddTween(17, TweenAnimator.TweenType.Alpha, score.gameObject, 0.2f, 1f, 0f, 14);
		mAnimator.AddTween(from: new Vector3(0f, 70f, -15f), id: 0, tweenType: TweenAnimator.TweenType.Position, tweenTarget: ribbonParent.gameObject, time: time, to: new Vector3(0f, -186f, -15f), delay: 0f);
		time = 0.2f;
		mAnimator.AddTween(1, TweenAnimator.TweenType.Position, ribbonParent.gameObject, time, new Vector3(0f, -160f, -15f), 0f, 0);
		mAnimator.AddTween(4, TweenAnimator.TweenType.Position, ribbonParent.gameObject, 0.4f, new Vector3(0f, 230f, -15f), delay, 12);
		time = 0.4f;
		mAnimator.AddTween(from: new Vector3(0f, -433f, -2f), id: 5, tweenType: TweenAnimator.TweenType.Position, tweenTarget: labelNewRibbon.gameObject, time: time, to: new Vector3(0f, -297f, -2f), delay: 0f);
		time = 0.2f;
		mAnimator.AddTween(6, TweenAnimator.TweenType.Position, labelNewRibbon.gameObject, time, new Vector3(0f, -307f, -2f), 0f, 5);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Alpha, labelNewRibbon.gameObject, 0.4f, 1f, 0f);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Alpha, labelNewRibbon.gameObject, 0.08f, 1f, 0f, 6, 0f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		mAnimator.AddTween(9, TweenAnimator.TweenType.Alpha, labelNewRibbon.gameObject, time, 0f, 0f, 8);
		mAnimator.AddTween(10, TweenAnimator.TweenType.Position, labelNewRibbon.gameObject, 0.4f, new Vector3(350f, -307f, -2f), 0f, 8);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Alpha, ribbonName.gameObject, time, 1f, 0f, 8);
		mAnimator.AddTween(from: new Vector3(-350f, -307f, -2f), id: 12, tweenType: TweenAnimator.TweenType.Position, tweenTarget: ribbonName.gameObject, time: 0.4f, to: new Vector3(0f, -307f, -2f), delay: 0f, playAfterIdFinished: 8);
		time = 0.4f;
		mAnimator.AddTween(13, TweenAnimator.TweenType.Position, ribbonName.gameObject, 0.4f, new Vector3(0f, -433f, -2f), delay, 12);
		time = 0.2f;
		mAnimator.AddTween(14, TweenAnimator.TweenType.Alpha, ribbonName.gameObject, time, 0f, delay, 12);
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(TweenFinished));
	}

	private void TweenFinished(int obj)
	{
		if (obj == 17)
		{
			mIsAnimationPlaying = false;
		}
	}

	public void Stop()
	{
		if (mIsAnimationPlaying)
		{
			mAnimator.FinishTweens();
			mIsAnimationPlaying = false;
		}
		mStopped = true;
	}

	public void Resume()
	{
		mStopped = false;
		mIsAnimationPlaying = false;
	}

	public override void InitGUIValues()
	{
		PrepareAnimation();
	}

	private void PrepareAnimation()
	{
		TweenPosition.Begin(ribbonParent, 0f, new Vector3(0f, 230f, -15f));
		ribbonName.alpha = 0f;
		labelNewRibbon.alpha = 0f;
	}

	protected override void Awake()
	{
		base.Awake();
		mPanel = GetComponent<UIPanel>();
	}

	protected override void Update()
	{
		base.Update();
		if (events.Count > 0 && !mIsAnimationPlaying && !mStopped)
		{
			RibbonManager.RibbonItemDefinition ribbonItemDefinition = events.Peek();
			events.Dequeue();
			ribbonIcon.spriteName = ribbonItemDefinition.iconName;
			ribbonIcon.MakePixelPerfect();
			ribbonIconBg.spriteName = ribbonItemDefinition.iconBgName;
			ribbonName.text = ribbonItemDefinition.name;
			NewRibbon();
			mIsAnimationPlaying = true;
		}
		if (mIsAnimationPlaying && mPanel != null)
		{
			mPanel.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
		if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.Semicolon))
		{
			events.Enqueue(Singleton<RibbonManager>.instance.ribbons[0]);
		}
	}

	public void NewRibbon()
	{
		PrepareAnimation();
		mAnimator.PlayTweens();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Ribbon);
	}
}
