using UnityEngine;

public class TweenColorMaterial : UITweener
{
	public Color from = Color.white;

	public Color to = Color.white;

	private Material mMaterial;

	public Color color
	{
		get
		{
			if (mMaterial != null)
			{
				return mMaterial.GetColor("_Color");
			}
			return default(Color);
		}
		set
		{
			if (mMaterial != null)
			{
				mMaterial.SetColor("_Color", value);
			}
		}
	}

	private void Awake()
	{
		mMaterial = GetComponent<Renderer>().material;
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		color = Color.Lerp(from, to, factor);
	}

	public static TweenColorMaterial Begin(GameObject go, float duration, Color color)
	{
		TweenColorMaterial tweenColorMaterial = UITweener.Begin<TweenColorMaterial>(go, duration);
		tweenColorMaterial.from = tweenColorMaterial.color;
		tweenColorMaterial.to = color;
		if (duration <= 0f)
		{
			tweenColorMaterial.Sample(1f, isFinished: true);
			tweenColorMaterial.enabled = false;
		}
		return tweenColorMaterial;
	}

	public static TweenColorMaterial Begin(GameObject go, float duration, Color from, Color to)
	{
		TweenColorMaterial tweenColorMaterial = UITweener.Begin<TweenColorMaterial>(go, duration);
		tweenColorMaterial.from = from;
		tweenColorMaterial.to = to;
		tweenColorMaterial.Sample(0f, isFinished: true);
		if (duration <= 0f)
		{
			tweenColorMaterial.Sample(1f, isFinished: true);
			tweenColorMaterial.enabled = false;
		}
		return tweenColorMaterial;
	}
}
