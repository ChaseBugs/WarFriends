using UnityEngine;

public class SwitchableGui : Core_BaseScript
{
	public enum ScreenAnimationType
	{
		Fade,
		TweenPosition,
		TeenPositionAndFade,
		DialogSpecial
	}

	public bool reverseAnimation;

	public float fadeOutTime = 1f;

	public float fadeInTime = 1f;

	public ScreenAnimationType showAnimationType;

	public ScreenAnimationType hideAnimationType;

	private bool mIsFirstEnable = true;

	private bool mDoAfterShowUpInvoked;

	private float mDoAfterShowUpInvokeTime;

	private bool mDoAfterHideInvoked;

	private float mDoAfterHideInvokeTime;

	private Vector3 mPosition;

	protected UIPanel[] mPanels;

	public bool readyToHide { get; protected set; }

	public bool readyToShowUp { get; protected set; }

	public GuiScreen previousScreen { get; set; }

	public GuiScreen previousScreenForElementsToHide { get; set; }

	public virtual bool isShowed { get; protected set; }

	public bool isFullyShowed => isShowed && !mDoAfterShowUpInvoked;

	public bool isFullyHidden => !isShowed && !readyToHide;

	protected virtual void Update()
	{
		if (mDoAfterHideInvoked && Time.realtimeSinceStartup > mDoAfterHideInvokeTime)
		{
			mDoAfterHideInvoked = false;
			DoAfterHide();
		}
		if (mDoAfterShowUpInvoked && Time.realtimeSinceStartup > mDoAfterShowUpInvokeTime)
		{
			mDoAfterShowUpInvoked = false;
			DoAfterShowUp();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mPosition = base.transform.localPosition;
	}

	protected virtual void OnEnable()
	{
		StopAllCoroutines();
		if (mIsFirstEnable)
		{
			mIsFirstEnable = false;
		}
	}

	public virtual void DoBeforeShowUp()
	{
		readyToShowUp = true;
		isShowed = true;
	}

	public void AnimateShow()
	{
		AnimateShow(forceFadeIn: false);
	}

	public virtual void AnimateShow(bool forceFadeIn)
	{
		float timeAfter = 0f;
		base.gameObject.SetActive(value: true);
		if (forceFadeIn || showAnimationType == ScreenAnimationType.Fade || showAnimationType == ScreenAnimationType.TeenPositionAndFade)
		{
			timeAfter = FadeIn();
			base.transform.localPosition = mPosition;
			TweenPosition.Begin(base.gameObject, 0f, mPosition);
		}
		if (showAnimationType == ScreenAnimationType.TeenPositionAndFade || showAnimationType == ScreenAnimationType.TweenPosition)
		{
			float z = base.transform.localPosition.z;
			TweenPosition.Begin(base.gameObject, fadeInTime, (!reverseAnimation) ? new Vector3(0f, 1280f, z) : new Vector3(0f, -1280f, z), new Vector3(0f, 0f, z));
			timeAfter = fadeInTime;
		}
		InvokeDoAfterShowUp(timeAfter);
	}

	protected void InvokeDoAfterShowUp(float timeAfter)
	{
		mDoAfterShowUpInvoked = true;
		mDoAfterHideInvoked = false;
		mDoAfterShowUpInvokeTime = Time.realtimeSinceStartup + timeAfter;
	}

	public virtual void DoAfterShowUp()
	{
		readyToHide = false;
		readyToShowUp = false;
	}

	public virtual float FadeIn()
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: true);
		UIPanel[] array = componentsInChildren;
		foreach (UIPanel uIPanel in array)
		{
			uIPanel.isFreezed = false;
			uIPanel.alpha1 = 0.005f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, fadeInTime, 0.005f, 1f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
		}
		return fadeInTime;
	}

	public virtual void DoBeforeHide()
	{
		readyToHide = true;
		isShowed = false;
	}

	public void AnimateHide()
	{
		AnimateHide(forceFadeOut: false);
	}

	public virtual void AnimateHide(bool forceFadeOut)
	{
		if (base.gameObject.activeInHierarchy)
		{
			float num = 0f;
			if (forceFadeOut || hideAnimationType == ScreenAnimationType.Fade || hideAnimationType == ScreenAnimationType.TeenPositionAndFade)
			{
				num = FadeOut();
			}
			if (hideAnimationType == ScreenAnimationType.TeenPositionAndFade || hideAnimationType == ScreenAnimationType.TweenPosition)
			{
				float z = base.transform.localPosition.z;
				TweenPosition.Begin(base.gameObject, fadeOutTime, new Vector3(0f, 0f, z), (!reverseAnimation) ? new Vector3(0f, -1280f, z) : new Vector3(0f, 1280f, z));
				num = fadeOutTime;
			}
			InvokeDoAfterHide(num - 0.05f);
		}
	}

	protected void InvokeDoAfterHide(float timeAfter)
	{
		mDoAfterHideInvoked = true;
		mDoAfterShowUpInvoked = false;
		mDoAfterHideInvokeTime = Time.realtimeSinceStartup + timeAfter;
	}

	public virtual void DoAfterHide()
	{
		readyToHide = false;
		readyToShowUp = false;
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		TweenPosition.Begin(base.gameObject, 0f, mPosition);
	}

	public virtual float FadeOut()
	{
		mPanels = GetComponentsInChildren<UIPanel>();
		UIPanel[] array = mPanels;
		foreach (UIPanel uIPanel in array)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, fadeOutTime, 0.0051f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
		}
		InvokeAfterRealTime(delegate
		{
			UIPanel[] array2 = mPanels;
			foreach (UIPanel uIPanel2 in array2)
			{
				uIPanel2.isFreezed = true;
			}
		}, 0.3f);
		return fadeOutTime;
	}

	public virtual void InitEvents()
	{
	}

	public virtual void OnBack()
	{
		if (Singleton<GuiManager>.instance.currentScreen.previousScreen != null)
		{
			Singleton<GuiManager>.instance.ShowGui(Singleton<GuiManager>.instance.currentScreen.previousScreen);
		}
	}

	public virtual void OnMenu()
	{
	}
}
