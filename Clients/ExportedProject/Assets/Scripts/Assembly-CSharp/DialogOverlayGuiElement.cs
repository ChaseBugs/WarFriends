using System;
using UnityEngine;

public class DialogOverlayGuiElement : Core_BaseScript
{
	public UIPanel mainPanel;

	public UISprite overlay;

	public UISprite glow;

	private Vector3 mGlowScale = new Vector3(685f, 678f, 1f);

	private static DialogOverlayGuiElement mInstance;

	public static DialogOverlayGuiElement instance
	{
		get
		{
			mInstance = Singleton<GuiManager>.instance.root.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true)[0];
			if (mInstance == null)
			{
				Debug.LogError("DialogOverlayGuiElement is not in scene -> add it.");
			}
			return mInstance;
		}
	}

	public void ShowDialogOverlay(float time)
	{
		base.gameObject.SetActive(value: true);
		float dur = time / 15f;
		TweenAlpha.Begin(mainPanel.gameObject, dur, 0.005f, 1f).onFinished = null;
		Vector3 UpScale = new Vector3(mGlowScale.x * 5f, mGlowScale.y * 2f, 1f);
		Vector3 EndScale = new Vector3(mGlowScale.x * 4f, mGlowScale.y * 1.5f, 1f);
		TweenAlpha.Begin(overlay.gameObject, dur * 6f, 0f, 0.84f);
		TweenScale tweenScale = TweenScale.Begin(glow.gameObject, dur * 11f, Vector3.one, Vector3.one);
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(glow.gameObject, dur * 2f, Vector3.one, UpScale);
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.onFinished = delegate
			{
				TweenScale tweenScale3 = TweenScale.Begin(glow.gameObject, dur * 2f, EndScale);
				tweenScale3.method = UITweener.Method.EaseOut;
				tweenScale3.onFinished = delegate(UITweener tweenGlowScaleEnd)
				{
					UIEventListener uIEventListener = UIEventListener.Get(overlay.gameObject);
					uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HideOpenedDialog));
					UIEventListener uIEventListener2 = UIEventListener.Get(overlay.gameObject);
					uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HideOpenedDialog));
					tweenGlowScaleEnd.onFinished = null;
				};
			};
		};
		TweenAlpha.Begin(glow.gameObject, dur * 9f, 0f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(glow.gameObject, dur * 2f, 1f).onFinished = null;
		};
	}

	public void HideDialogOverlay(float time)
	{
		TweenAlpha.Begin(overlay.gameObject, time, 0f);
		TweenScale.Begin(glow.gameObject, time, Vector3.one).onFinished = null;
		TweenAlpha.Begin(glow.gameObject, time, 0f).onFinished = null;
		TweenAlpha.Begin(mainPanel.gameObject, time, 0.005f).onFinished = delegate(UITweener tween)
		{
			UIEventListener uIEventListener = UIEventListener.Get(overlay.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HideOpenedDialog));
			tween.onFinished = null;
			base.gameObject.SetActive(value: false);
		};
	}

	private void HideOpenedDialog(GameObject go)
	{
		DialogManager.instance.HideAllDialogs();
	}
}
