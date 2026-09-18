using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : MonoBehaviour
{
	public GameObject tweenTarget;

	public List<GameObject> extratweenTargets;

	protected List<Color> mColors;

	public Color hover = new Color(0.6f, 1f, 0.2f, 1f);

	public Color pressed = Color.grey;

	public float duration = 0.2f;

	protected Color mColor;

	protected bool mStarted;

	protected bool mHighlighted;

	public Color defaultColor
	{
		get
		{
			if (!mStarted)
			{
				Init();
			}
			return mColor;
		}
		set
		{
			mColor = value;
		}
	}

	private void Start()
	{
		if (!mStarted)
		{
			Init();
			mStarted = true;
		}
	}

	protected virtual void OnEnable()
	{
		if (mStarted && mHighlighted)
		{
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void OnDisable()
	{
		if (mStarted && tweenTarget != null)
		{
			TweenColor component = tweenTarget.GetComponent<TweenColor>();
			if (component != null)
			{
				component.color = mColor;
				component.enabled = false;
			}
		}
	}

	public void Init()
	{
		if (tweenTarget == null)
		{
			tweenTarget = base.gameObject;
		}
		UIWidget component = tweenTarget.GetComponent<UIWidget>();
		mColors = new List<Color>();
		foreach (GameObject extratweenTarget in extratweenTargets)
		{
			UIWidget component2 = extratweenTarget.GetComponent<UIWidget>();
			if (component2 != null)
			{
				mColors.Add(component2.color);
			}
		}
		if (component != null)
		{
			mColor = component.color;
		}
		else
		{
			Renderer component3 = tweenTarget.GetComponent<Renderer>();
			if (component3 != null)
			{
				mColor = component3.material.color;
			}
			else
			{
				Light component4 = tweenTarget.GetComponent<Light>();
				if (component4 != null)
				{
					mColor = component4.color;
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		OnEnable();
	}

	public virtual void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!mStarted)
			{
				Start();
			}
			TweenColor.Begin(tweenTarget, duration, isPressed ? pressed : ((!UICamera.IsHighlighted(base.gameObject)) ? mColor : hover));
		}
	}

	public virtual void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!mStarted)
			{
				Start();
			}
			TweenColor.Begin(tweenTarget, duration, (!isOver) ? mColor : hover);
			mHighlighted = isOver;
		}
	}
}
