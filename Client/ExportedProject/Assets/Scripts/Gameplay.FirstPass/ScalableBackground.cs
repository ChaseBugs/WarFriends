using System;
using UnityEngine;

public class ScalableBackground : MonoBehaviour
{
	public int DesignWidth = 640;

	public int DesignHeight = 960;

	private ScalableBackground _oldBg;

	private void Start()
	{
		float num = (float)Screen.height / (float)Screen.width;
		float num2 = (float)DesignHeight / (float)DesignWidth;
		if (num > num2)
		{
			Vector3 localScale = base.transform.localScale;
			localScale.y *= num / num2;
			localScale.x *= num / num2;
			float num3 = GetComponent<Renderer>().bounds.max.y - GetComponent<Renderer>().bounds.min.y;
			float y = num3 * (localScale.y - 1f) * 0.5f;
			base.transform.localPosition += new Vector3(0f, y, 0f);
			base.transform.localScale = localScale;
			base.enabled = false;
		}
		float y2 = GetComponent<Renderer>().bounds.min.y;
		float num4 = Camera.main.transform.position.y - Camera.main.orthographicSize;
		base.transform.localPosition -= new Vector3(0f, y2 - num4, 0f);
	}

	private void Update()
	{
	}

	public void Change(string s, Color color)
	{
		_oldBg = this;
		TweenAlphaTk2d.Begin(base.gameObject, 1f, 0f).method = UITweener.Method.EaseInOut;
		ScalableBackground scalableBackground = UnityEngine.Object.Instantiate(this, base.transform.position, Quaternion.identity);
		scalableBackground.transform.localScale = scalableBackground.transform.localScale;
		tk2dSprite component = scalableBackground.GetComponent<tk2dSprite>();
		component.SetSprite(s);
		component.color = new Color(component.color.r, component.color.g, component.color.b, 0f);
		TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(scalableBackground.gameObject, 1f, 1f);
		tweenAlphaTk2d.method = UITweener.Method.EaseInOut;
		tweenAlphaTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaTk2d.onFinished, new UITweener.OnFinished(ChangeFinished));
	}

	private void ChangeFinished(UITweener tween)
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
