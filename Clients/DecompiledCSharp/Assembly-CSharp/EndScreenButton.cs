using UnityEngine;

public class EndScreenButton : Core_BaseScript
{
	[Header("Basic")]
	public UIButton buttonScript;

	public BoxCollider buttonCollider;

	public UISprite background;

	public GameObject border;

	public UISprite borderSprite;

	public UISprite shadow;

	public UILabel buttonName;

	public void InitializedToOffscreen()
	{
		base.transform.localPosition = base.transform.localPosition.ReplaceX(-400f);
	}

	public void InitializeLeftButton()
	{
		TweenColor.Begin(background.gameObject, 0f, Colours.blueTransparent);
		TweenPosition.Begin(background.gameObject, 0f, background.transform.localPosition.ReplaceX(0f));
		TweenPosition.Begin(border, 0f, Vector3.zero);
		buttonName.color = Color.white;
	}

	public void SetButton(bool active)
	{
		float duration = 0.2f;
		buttonScript.defaultColor = ((!active) ? Colours.blueTransparent : Colours.blue);
		buttonScript.hover = ((!active) ? Colours.blueLowAlpha : Colours.blueHover);
		TweenColor.Begin(background.gameObject, duration, (!active) ? Colours.blueTransparent : Colours.blue);
		TweenPosition.Begin(background.gameObject, duration, background.transform.localPosition.ReplaceX((!active) ? 0f : 26f));
		TweenPosition.Begin(border, duration, border.transform.localPosition.ReplaceX((!active) ? 0f : 26f));
		TweenPosition.Begin(shadow.gameObject, duration, shadow.transform.localPosition.ReplaceX((!active) ? 83f : 109f));
		buttonName.color = ((!active) ? Color.white : Color.black);
	}

	public virtual void SetButtonHeight(bool smallHeight)
	{
		background.transform.localScale = background.transform.localScale.ReplaceY((!smallHeight) ? 126f : 104f);
		borderSprite.transform.localScale = borderSprite.transform.localScale.ReplaceY((!smallHeight) ? 138f : 116f);
		shadow.transform.localPosition = shadow.transform.localPosition.ReplaceY((!smallHeight) ? 26f : 15f);
		buttonCollider.size = buttonCollider.size.ReplaceY((!smallHeight) ? 150f : 128f);
	}
}
