using System;
using UnityEngine;

public class GuiManager : Singleton<GuiManager>
{
	public GuiScreen currentScreen;

	public ObjectPool objectPool;

	public UISprite overlay;

	public ParticleSystem particles;

	public UIRoot root;

	public Camera guiCamera;

	public float overlayStrength = 1f;

	private SwitchableGui mToBeShowedUp;

	private bool mCanChangeInput = true;

	public SwitchableGui toBeShowedUp => mToBeShowedUp;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void Start()
	{
		base.Start();
		SwitchableGui[] componentsInChildren = root.GetComponentsInChildren<SwitchableGui>(includeInactive: true);
		SwitchableGui[] array = componentsInChildren;
		foreach (SwitchableGui switchableGui in array)
		{
			switchableGui.InitEvents();
		}
	}

	public void ShowGui(GuiScreen toBeShowedUp)
	{
		if (toBeShowedUp == currentScreen && currentScreen.isShowed)
		{
			if (toBeShowedUp.showDialogs)
			{
				Debug.Log("Gui Manager: Starting Messages Coroutine for: " + toBeShowedUp.name);
				Singleton<MessageManager>.instance.StartMessageCoroutine();
			}
			return;
		}
		TurnOffInput();
		toBeShowedUp.reverseAnimation = false;
		if ((bool)currentScreen)
		{
			currentScreen.reverseAnimation = false;
		}
		if (currentScreen != null && currentScreen.previousScreen == toBeShowedUp)
		{
			toBeShowedUp.reverseAnimation = true;
			currentScreen.reverseAnimation = true;
		}
		if (currentScreen != null && currentScreen.previousScreen != toBeShowedUp)
		{
			toBeShowedUp.previousScreen = currentScreen;
		}
		toBeShowedUp.previousScreenForElementsToHide = currentScreen;
		if (currentScreen != null && currentScreen.isShowed)
		{
			mToBeShowedUp = toBeShowedUp;
			HideGui(currentScreen);
			mToBeShowedUp = null;
		}
		currentScreen = toBeShowedUp;
		toBeShowedUp.DoBeforeShowUp();
		if (toBeShowedUp.readyToShowUp)
		{
			toBeShowedUp.AnimateShow();
		}
	}

	public void ShowDialog(SwitchableGui toBeShowedUp, float delay = 0f)
	{
		if (GuiElement.ShowingDialog != null)
		{
			GuiElement.ShowingDialog();
		}
		if (delay <= 0f)
		{
			FadeIn(toBeShowedUp);
		}
		else if (delay > 0f)
		{
			InvokeAfterRealTime(delegate
			{
				FadeIn(toBeShowedUp);
			}, delay);
		}
		else
		{
			FadeIn(toBeShowedUp);
		}
	}

	public void ShowDialogInstant(SwitchableGui toBeShowedUp)
	{
		if (GuiElement.ShowingDialog != null)
		{
			GuiElement.ShowingDialog();
		}
		float fadeInTime = toBeShowedUp.fadeInTime;
		toBeShowedUp.fadeInTime = 0f;
		FadeIn(toBeShowedUp);
		toBeShowedUp.fadeInTime = fadeInTime;
	}

	public void TurnOffInputCompletly()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Input turned OFF completely: " + Time.time);
		}
		mCanChangeInput = true;
		TurnOffInput();
		mCanChangeInput = false;
	}

	public void TurnOnInputCompletly()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Input turned on completely: " + Time.time);
		}
		mCanChangeInput = true;
		TurnOnInput();
	}

	public bool IsInputTurnedOffCompletly()
	{
		return !mCanChangeInput;
	}

	public void TurnOffInput()
	{
		if (mCanChangeInput)
		{
			UICamera.useMouse = false;
			UICamera.useTouch = false;
		}
	}

	public void TurnOnInput()
	{
		if (mCanChangeInput)
		{
			if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
			{
				UICamera.useMouse = true;
			}
			UICamera.useMouse = true;
			UICamera.useTouch = true;
		}
	}

	public void HideGui(SwitchableGui toBeHidden)
	{
		toBeHidden.DoBeforeHide();
		if (toBeHidden.readyToHide)
		{
			toBeHidden.AnimateHide();
		}
	}

	public void FadeOut(SwitchableGui toBeHidden)
	{
		toBeHidden.DoBeforeHide();
		if (toBeHidden.readyToHide)
		{
			toBeHidden.AnimateHide(forceFadeOut: true);
		}
	}

	public void FadeIn(SwitchableGui toBeShowUp)
	{
		toBeShowUp.DoBeforeShowUp();
		if (toBeShowUp.readyToShowUp)
		{
			toBeShowUp.AnimateShow(forceFadeIn: true);
		}
		else
		{
			Debug.Log("NOT READY TO SHOW UP");
		}
	}

	private void CheckForShowUpInvocation(SwitchableGui toBeShowedUp)
	{
	}

	public void HideOverlay()
	{
		float alpha = overlay.alpha;
		float duration = alpha + 0.01f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(Singleton<GuiManager>.instance.overlay.gameObject, duration, 0f);
		tweenAlpha.method = UITweener.Method.EaseInOut;
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			overlay.gameObject.SetActive(value: false);
		});
	}

	public void ShowOverlay()
	{
		overlay.gameObject.SetActive(value: true);
		float alpha = overlay.alpha;
		float duration = 1f - alpha + 0.01f;
		TweenAlpha.Begin(Singleton<GuiManager>.instance.overlay.gameObject, duration, overlayStrength).method = UITweener.Method.EaseInOut;
	}

	public void ShowParticles()
	{
		Singleton<GuiManager>.instance.particles.Play();
	}

	public void HideParticles()
	{
		Singleton<GuiManager>.instance.particles.Stop();
	}

	internal void ShowMainScreen()
	{
		FadeIn(GuiElementSingle<Background>.instance);
		ShowGui(GuiScreenSingle<MainScreen>.instance);
	}
}
