using UnityEngine;

[AddComponentMenu("NGUI/Tween/Color Special")]
public class TweenColorSpecial : UITweener
{
	public Color from = Color.white;

	public Color to = Color.white;

	private UIWidget mWidget;

	private Material mMat;

	private Light mLight;

	public Color color
	{
		get
		{
			if (mWidget != null)
			{
				return mWidget.color;
			}
			if (mLight != null)
			{
				return mLight.color;
			}
			if (mMat != null)
			{
				return mMat.color;
			}
			return Color.black;
		}
		set
		{
			Color color = value.ReplaceA(this.color.a);
			if (mWidget != null)
			{
				mWidget.color = color;
			}
			if (mMat != null)
			{
				mMat.color = color;
			}
			if (mLight != null)
			{
				mLight.color = color;
				mLight.enabled = color.r + color.g + color.b > 0.01f;
			}
		}
	}

	private void Awake()
	{
		mWidget = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			mMat = component.material;
		}
		mLight = GetComponent<Light>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		color = Color.Lerp(from, to, factor);
	}

	public static TweenColor Begin(GameObject go, float duration, Color color)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
		tweenColor.from = tweenColor.color.ReplaceA(1f);
		tweenColor.to = color.ReplaceA(1f);
		if (duration <= 0f)
		{
			tweenColor.Sample(1f, isFinished: true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor Begin(GameObject go, float duration, Color from, Color to)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
		tweenColor.from = from.ReplaceA(1f);
		tweenColor.to = to.ReplaceA(1f);
		if (duration <= 0f)
		{
			tweenColor.Sample(1f, isFinished: true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}
}
