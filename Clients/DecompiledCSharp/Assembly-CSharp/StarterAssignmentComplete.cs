using UnityEngine;

public class StarterAssignmentComplete : Core_BaseScript
{
	[Header("Core")]
	public bool isLast;

	public UISprite foreground;

	public UILabel number;

	public UISprite check;

	public void SetCompleted()
	{
		foreground.gameObject.SetActive(value: true);
		number.gameObject.SetActive(value: false);
		check.gameObject.SetActive(value: true);
		StopTweens();
		foreground.alpha = 1f;
		check.alpha = 1f;
		check.transform.localScale = new Vector3(37f, 29f, 1f);
	}

	public void SetCurrent()
	{
		foreground.gameObject.SetActive(value: true);
		number.gameObject.SetActive(value: true);
		check.gameObject.SetActive(value: false);
		StopTweens();
		foreground.alpha = 1f;
		number.color = ((!isLast) ? Color.white : Colours.goldTier);
	}

	public void SetDefault()
	{
		foreground.gameObject.SetActive(value: false);
		number.gameObject.SetActive(value: true);
		check.gameObject.SetActive(value: false);
		StopTweens();
		number.color = ((!isLast) ? Colours.grayLight : Colours.goldTier);
	}

	public void AnimateFinish()
	{
		check.gameObject.SetActive(value: true);
		check.alpha = 0f;
		TweenAlpha.Begin(check.gameObject, 0.2f, 0f, 1f);
		TweenAlpha.Begin(number.gameObject, 0.2f, 1f, 0f);
		TweenScale.Begin(check.gameObject, 0.2f, new Vector3(111f, 87f, 1f), new Vector3(29.6f, 23.2f, 1f)).onFinished = delegate
		{
			TweenScale.Begin(check.gameObject, 0.2f, new Vector3(37f, 29f, 1f)).onFinished = null;
		};
	}

	public void AnimateProgress()
	{
		foreground.gameObject.SetActive(value: true);
		foreground.alpha = 0f;
		TweenColor.Begin(number.gameObject, 0.2f, (!isLast) ? Color.white : Colours.goldTier);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(foreground.gameObject, 0.2f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	private void StopTweens()
	{
		TweenAlpha component = foreground.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = check.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = number.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenColor component2 = number.gameObject.GetComponent<TweenColor>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		TweenScale component3 = check.gameObject.GetComponent<TweenScale>();
		if (component3 != null)
		{
			component3.onFinished = null;
			component3.enabled = false;
		}
	}
}
