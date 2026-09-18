using UnityEngine;

public class ArenaLiveRecord : Core_BaseScript
{
	public UISprite leftHeart;

	public UISprite rightHeart;

	private Vector3 mOriginalScale = new Vector3(28f, 56f, 1f);

	private Vector3 mOriginalPosition = new Vector3(0f, -27f, 0f);

	public void SetFull()
	{
		ResetLife();
		leftHeart.gameObject.SetActive(value: true);
		rightHeart.gameObject.SetActive(value: true);
	}

	public void SetEmpty()
	{
		ResetLife();
		leftHeart.gameObject.SetActive(value: false);
		rightHeart.gameObject.SetActive(value: false);
	}

	private void ResetLife()
	{
		TweenScale.Begin(leftHeart.gameObject, 0f, mOriginalScale);
		TweenScale.Begin(rightHeart.gameObject, 0f, mOriginalScale);
		TweenPosition.Begin(leftHeart.gameObject, 0f, mOriginalPosition);
		TweenPosition.Begin(rightHeart.gameObject, 0f, mOriginalPosition);
	}

	public void AnimateHeart()
	{
		TweenScale.Begin(leftHeart.gameObject, 0.4f, mOriginalScale * 2.3f).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DogTagUsed);
			TweenPosition.Begin(leftHeart.gameObject, 0.4f, leftHeart.transform.localPosition.ReplaceX(-50f)).onFinished = delegate
			{
				TweenAlpha.Begin(leftHeart.gameObject, 0.3f, 0f);
				TweenPosition.Begin(leftHeart.gameObject, 0.4f, leftHeart.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
				{
					leftHeart.transform.localScale = mOriginalScale;
					leftHeart.transform.localPosition = mOriginalPosition;
					leftHeart.gameObject.SetActive(value: false);
					leftHeart.alpha = 1f;
				};
			};
		};
		TweenScale.Begin(rightHeart.gameObject, 0.4f, mOriginalScale * 2.3f).onFinished = delegate
		{
			TweenPosition.Begin(rightHeart.gameObject, 0.4f, rightHeart.transform.localPosition.ReplaceX(50f)).onFinished = delegate
			{
				TweenAlpha.Begin(rightHeart.gameObject, 0.3f, 0f);
				TweenPosition.Begin(rightHeart.gameObject, 0.4f, rightHeart.transform.localPosition.ReplaceXY(50f, -150f)).onFinished = delegate
				{
					rightHeart.transform.localScale = mOriginalScale;
					rightHeart.transform.localPosition = mOriginalPosition;
					rightHeart.gameObject.SetActive(value: false);
					rightHeart.alpha = 1f;
					GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
					GuiScreenSingle<ArenaScreen>.instance.mainContent.AfterAnimation();
				};
			};
		};
	}
}
