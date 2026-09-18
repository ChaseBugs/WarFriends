using UnityEngine;

public class InappButton : MonoBehaviour
{
	[Header("Button Core")]
	public UISprite border;

	public UISprite highlight;

	public UILabel buttonName;

	public UIButtonSetter buttonSetter;

	public float iconWidth;

	private bool mHiding;

	protected float mDuration = 0.2f;

	protected float mAlphaBorderMax = 0.7f;

	protected float mSpaceAround = 76f;

	public bool pressed => highlight.alpha > 0f;

	public float width => border.transform.localScale.x;

	public float posX => 47f + base.transform.localPosition.x;

	protected virtual float mInsideWidth => Mathf.Max(iconWidth, buttonName.relativeSize.x * buttonName.transform.localScale.x);

	public void Initialize(string nameOfButton, float duration, bool toHighlight = false)
	{
		mHiding = false;
		mDuration = duration;
		buttonName.text = nameOfButton;
		if (buttonSetter != null)
		{
			buttonSetter.SetWidth(mInsideWidth + mSpaceAround);
		}
		InstantAnimate(toHighlight);
	}

	public virtual TweenAlpha Animate(bool toHighlight)
	{
		if (mHiding)
		{
			return null;
		}
		TweenColor.Begin(buttonName.gameObject, mDuration, (!toHighlight) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(border.gameObject, mDuration, (!toHighlight) ? mAlphaBorderMax : 0f);
		return TweenAlpha.Begin(highlight.gameObject, mDuration, (!toHighlight) ? 0f : 1f);
	}

	public virtual void InstantAnimate(bool toHighlight)
	{
		if (!mHiding)
		{
			border.alpha = ((!toHighlight) ? mAlphaBorderMax : 0f);
			highlight.alpha = ((!toHighlight) ? 0f : 1f);
			buttonName.color = ((!toHighlight) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	public void AnimatedHide()
	{
		mHiding = true;
		TweenAlpha.Begin(border.gameObject, mDuration, 0f);
		TweenAlpha.Begin(buttonName.gameObject, mDuration, 0f);
		TweenAlpha.Begin(highlight.gameObject, mDuration, 0f).onFinished = delegate
		{
			mHiding = false;
			base.gameObject.SetActive(value: false);
			GuiElementSingle<InappScreen>.instance.buttonsTable.repositionNow = true;
		};
	}
}
