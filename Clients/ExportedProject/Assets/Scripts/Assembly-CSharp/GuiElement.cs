using System;
using UnityEngine;

public abstract class GuiElement : SwitchableGui
{
	public UISprite overlayBackground;

	private GuiScreen mGuiScreen;

	private bool mFirstEnable = true;

	protected float mDistance = 10f;

	public static Action ShowingDialog;

	public static Action<GuiElement> HidingDialog;

	public GuiScreen guiScreen
	{
		get
		{
			return mGuiScreen;
		}
		set
		{
			if ((mGuiScreen != null || mGuiScreen != value) && mGuiScreen != null)
			{
				mGuiScreen.AfterHide -= ScreenAfterHide;
				mGuiScreen.AfterShowUp -= ScreenAfterShowUp;
				mGuiScreen.BeforeHide -= ScreenBeforeHide;
				mGuiScreen.BeforeShowUp -= ScreenBeforeShowUp;
			}
			mGuiScreen = value;
			mGuiScreen.AfterHide += ScreenAfterHide;
			mGuiScreen.AfterShowUp += ScreenAfterShowUp;
			mGuiScreen.BeforeHide += ScreenBeforeHide;
			mGuiScreen.BeforeShowUp += ScreenBeforeShowUp;
			mGuiScreen = value;
		}
	}

	private void OnDestroy()
	{
		ShowingDialog = null;
		HidingDialog = null;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (mFirstEnable)
		{
			try
			{
				InitControls();
			}
			catch (Exception ex)
			{
				Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
				if (DebugSettings.debugEnabled)
				{
					WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
				}
				Crittercism.LogHandledException(ex);
			}
			mFirstEnable = false;
		}
		try
		{
			InitGUIValues();
		}
		catch (Exception ex2)
		{
			Debug.LogError($"OBJECT: {base.gameObject.name}\nERROR: {ex2.Message}\nSTACKTRACE: {ex2.StackTrace}");
			if (DebugSettings.debugEnabled)
			{
				WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
			}
			Crittercism.LogHandledException(ex2);
		}
	}

	protected virtual void ScreenBeforeShowUp()
	{
	}

	protected virtual void ScreenBeforeHide()
	{
	}

	protected virtual void ScreenAfterShowUp()
	{
	}

	protected virtual void ScreenAfterHide()
	{
	}

	public abstract void InitControls();

	public abstract void InitGUIValues();

	public override void DoBeforeShowUp()
	{
		if (overlayBackground != null && (showAnimationType == ScreenAnimationType.DialogSpecial || hideAnimationType == ScreenAnimationType.DialogSpecial))
		{
			overlayBackground.gameObject.SetActive(value: false);
		}
		base.DoBeforeShowUp();
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		if (showAnimationType == ScreenAnimationType.DialogSpecial)
		{
			base.gameObject.SetActive(value: true);
			float dur = fadeInTime / 15f;
			SpecialFadeIn(dur);
			float zzz = base.transform.localPosition.z;
			DialogOverlayGuiElement.instance.ShowDialogOverlay(fadeInTime);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, dur * 6f, new Vector3(0f, -4f * mDistance, zzz), new Vector3(0f, -4f * mDistance, zzz));
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, dur * 5f, new Vector3(0f, mDistance, zzz));
				tweenPosition2.method = UITweener.Method.Linear;
				tweenPosition2.onFinished = delegate
				{
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, dur * 4f, new Vector3(0f, 0f, zzz));
					tweenPosition3.method = UITweener.Method.EaseOut;
				};
			};
			InvokeDoAfterShowUp(fadeInTime);
		}
		else
		{
			base.AnimateShow(forceFadeIn);
		}
	}

	private void SpecialFadeIn(float dur)
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: true);
		UIPanel[] array = componentsInChildren;
		foreach (UIPanel uIPanel in array)
		{
			uIPanel.isFreezed = false;
			uIPanel.alpha1 = 0.005f;
			TweenAlpha.Begin(uIPanel.gameObject, dur * 6f, 0.005f, 0.005f).onFinished = delegate(UITweener tween)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(tween.gameObject, dur * 3f, 0.005f, 1f);
				tweenAlpha.method = UITweener.Method.EaseInOut;
			};
		}
	}

	public override void AnimateHide(bool forceFadeOut)
	{
		if (showAnimationType == ScreenAnimationType.DialogSpecial)
		{
			DialogOverlayGuiElement.instance.HideDialogOverlay(fadeOutTime);
			SpecialFadeOut();
			InvokeDoAfterHide(fadeOutTime);
		}
		else
		{
			base.AnimateHide(forceFadeOut);
		}
	}

	private void SpecialFadeOut()
	{
		FadeOut();
	}
}
