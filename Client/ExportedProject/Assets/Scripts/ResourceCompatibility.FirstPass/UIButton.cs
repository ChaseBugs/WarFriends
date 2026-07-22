using System.Collections.Generic;
using UnityEngine;

public class UIButton : UIButtonColor
{
	public Color disabledColor;

	public List<UISprite> sprites;

	public List<UILabel> labels;

	public bool isEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool isEnabledImmediate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	protected override void OnEnable()
	{
	}

	public override void OnHover(bool isOver)
	{
	}

	public override void OnPress(bool isPressed)
	{
	}

	public void UpdateColor(bool shouldBeEnabled, bool immediate)
	{
	}
}
