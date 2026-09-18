using System.Collections;
using UnityEngine;

public class DogTagRecordAnimation : Core_BaseScript
{
	[Header("Setting")]
	public bool isVIPDogtag;

	[Header("Animation part")]
	public UIPanel panel;

	public UISprite topPart;

	public UISprite bottomPart;

	public float speed = 0.3f;

	[Header("Audio")]
	public float lostSoundWaitTime = 0.75f;

	public void StartAnimation()
	{
		Initialize();
		Animation_DogTagConsumed();
		StartCoroutine(PlayLostSound());
	}

	public void StopAnimation()
	{
		StopAllCoroutines();
		EndOfAnimation();
	}

	public void SetDepthsAndColor(bool VIPDogtag)
	{
		topPart.depth = 100;
		bottomPart.depth = topPart.depth + 1;
		topPart.color = ((!VIPDogtag) ? Color.white : Colours.goldDogtag);
		bottomPart.color = ((!VIPDogtag) ? Color.white : Colours.goldDogtag);
	}

	private IEnumerator PlayLostSound()
	{
		yield return new WaitForSeconds(lostSoundWaitTime);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DogTagUsed);
	}

	private void Initialize()
	{
		base.gameObject.SetActive(value: true);
		base.transform.localScale = Vector3.one;
		base.transform.localPosition = new Vector3(0f, 0f, -15f);
		topPart.transform.localPosition = Vector3.zero;
		bottomPart.transform.localPosition = Vector3.zero;
		panel.alpha1 = 0f;
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = base.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		TweenPosition component3 = base.gameObject.GetComponent<TweenPosition>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		TweenPosition component4 = topPart.gameObject.GetComponent<TweenPosition>();
		if (component4 != null)
		{
			component4.enabled = false;
		}
		TweenPosition component5 = bottomPart.gameObject.GetComponent<TweenPosition>();
		if (component5 != null)
		{
			component5.enabled = false;
		}
	}

	private void Animation_DogTagConsumed()
	{
		panel.alpha1 = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(base.gameObject, speed * 1.1f, 0f, 1f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(base.gameObject, speed * 2.16f, 1f, 0f);
			tweenAlpha2.delay = 2.8f * speed;
			tweenAlpha2.onFinished = delegate
			{
				EndOfAnimation();
			};
		};
		TweenScale.Begin(base.gameObject, speed, Vector3.one, new Vector3(1.55f, 1.55f, 1f)).onFinished = delegate
		{
			TweenScale.Begin(base.gameObject, speed, new Vector3(1.55f, 1.55f, 1f), new Vector3(1.4f, 1.4f, 1f)).onFinished = null;
		};
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, speed * 0.8f, new Vector3(0f, 0f, -15f), new Vector3(0f, -150f, -15f));
		tweenPosition.delay = 3.1f * speed;
		TweenPosition tweenPosition2 = TweenPosition.Begin(topPart.gameObject, speed * 1.2f, Vector3.zero, new Vector3(-150f, 0f, 0f));
		tweenPosition2.delay = 3.9f * speed;
		TweenPosition tweenPosition3 = TweenPosition.Begin(bottomPart.gameObject, speed * 1.2f, Vector3.zero, new Vector3(150f, 0f, 0f));
		tweenPosition3.delay = 3.9f * speed;
	}

	private void EndOfAnimation()
	{
		base.gameObject.SetActive(value: false);
	}
}
