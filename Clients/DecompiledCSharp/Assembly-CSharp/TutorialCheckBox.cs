using UnityEngine;

public class TutorialCheckBox : MonoBehaviour
{
	public UISprite bg;

	public UISprite checkBG;

	public UISprite checker;

	public void Clear()
	{
		checkBG.gameObject.SetActive(value: false);
		checker.gameObject.SetActive(value: false);
	}

	public void SetChecked()
	{
		checkBG.gameObject.SetActive(value: true);
		checker.gameObject.SetActive(value: true);
		checkBG.alpha = 0f;
		checker.alpha = 0f;
		checker.MakePixelPerfect();
		TweenAlpha.Begin(checkBG.gameObject, 0.25f, 1f);
		TweenAlpha.Begin(checker.gameObject, 0.25f, 1f);
		checker.cachedTransform.localScale = TweenScale.Begin(checker.gameObject, 0.5f, checker.cachedTransform.localScale.MultiplyXY(5f)).to;
	}

	public void ShowBig()
	{
		base.transform.localScale = Vector3.one;
		base.gameObject.SetActive(value: true);
	}

	public void ShowSmall()
	{
		base.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
