using System;
using UnityEngine;

public class CloseDialogElement : Core_BaseScript
{
	[Header("Core")]
	public UILabel closeLabel;

	public UISprite closeBackground;

	public BoxCollider closeCollider;

	public UISprite crossIcon;

	private bool mInitialized;

	private Vector3 mScaleUp = new Vector3(1.05f, 1.05f, 1f);

	private Vector3 mOriginalScale;

	protected override void Awake()
	{
		base.Awake();
		if (!mInitialized)
		{
			closeLabel.text = Localization.Localize("ID_CLOSE");
			float num = 136f + closeLabel.relativeSize.x * closeLabel.transform.localScale.x;
			closeBackground.transform.localScale = closeBackground.transform.localScale.ReplaceX(num);
			closeCollider.size = closeCollider.size.ReplaceXY(num + 40f, 116f);
			closeCollider.center = closeCollider.center.ReplaceX((0f - num) / 2f);
			mOriginalScale = closeLabel.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(closeCollider.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
			mInitialized = true;
		}
	}

	private void CloseClick(GameObject go)
	{
		TweenScale tweenScale = TweenScale.Begin(closeLabel.gameObject, 0.2f, mOriginalScale, Vector3.Scale(mOriginalScale, mScaleUp));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
		TweenRotationSpecial.Begin(crossIcon.gameObject, 0.4f, Vector3.forward, 0f, 360f);
	}
}
