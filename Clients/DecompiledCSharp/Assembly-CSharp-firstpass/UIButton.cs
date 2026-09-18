using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
	public Color disabledColor = Color.grey;

	public List<UISprite> sprites;

	public List<UILabel> labels;

	public bool isEnabled
	{
		get
		{
			Collider component = GetComponent<Collider>();
			return (bool)component && component.enabled;
		}
		set
		{
			Collider component = GetComponent<Collider>();
			if ((bool)component)
			{
				component.enabled = value;
				UpdateColor(value, immediate: false);
			}
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	public override void OnHover(bool isOver)
	{
		if (isEnabled)
		{
			base.OnHover(isOver);
		}
	}

	public override void OnPress(bool isPressed)
	{
		if (isEnabled)
		{
			base.OnPress(isPressed);
		}
	}

	public void UpdateColor(bool shouldBeEnabled, bool immediate)
	{
		if (!tweenTarget)
		{
			return;
		}
		if (!mStarted)
		{
			mStarted = true;
			Init();
		}
		Color color = ((!shouldBeEnabled) ? disabledColor : base.defaultColor);
		TweenColor tweenColor = TweenColor.Begin(tweenTarget, 0.15f, color);
		for (int i = 0; i < extratweenTargets.Count; i++)
		{
			GameObject go = extratweenTargets[i];
			if (mColors.Count > i)
			{
				color = ((!shouldBeEnabled) ? disabledColor : mColors[i]);
			}
			tweenColor = TweenColor.Begin(go, 0.15f, color);
		}
		if (immediate)
		{
			tweenColor.color = color;
			tweenColor.enabled = false;
		}
	}
}
