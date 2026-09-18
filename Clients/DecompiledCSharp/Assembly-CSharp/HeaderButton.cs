using System;
using UnityEngine;

public class HeaderButton : GuiElement
{
	public enum Anchor
	{
		TopLeft,
		Top
	}

	private GuiScreen mScreen;

	public UIButton button;

	public Anchor anchor;

	public float durationAnimation = 0.1f;

	private bool mHeaderFirstEnable = true;

	protected override void OnEnable()
	{
		base.OnEnable();
		if (mHeaderFirstEnable)
		{
			mScreen = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (mScreen == null)
			{
				Debug.LogError("Could not find parent screen");
			}
			mHeaderFirstEnable = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = button.transform.localPosition;
			if (anchor == Anchor.Top)
			{
				button.transform.parent = instance.topAnchor;
			}
			if (anchor == Anchor.TopLeft)
			{
				button.transform.parent = instance.topLeftAnchor;
			}
			button.transform.localPosition = localPosition;
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void ScreenBeforeShowUp()
	{
		base.ScreenBeforeShowUp();
		button.gameObject.SetActive(value: true);
		button.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(button.gameObject, durationAnimation, 0f, 1f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OnFinished));
	}

	private void OnFinished(UITweener tween)
	{
		button.Init();
	}

	protected override void ScreenBeforeHide()
	{
		base.ScreenBeforeHide();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(button.gameObject, durationAnimation, 1f, 0f);
		button.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OnFinished2));
	}

	private void OnFinished2(UITweener tween)
	{
		button.gameObject.SetActive(value: false);
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}
}
