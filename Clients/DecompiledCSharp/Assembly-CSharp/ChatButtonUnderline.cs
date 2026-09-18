public class ChatButtonUnderline : Core_BaseScript
{
	public UISprite background;

	public UISprite underline;

	public UILabel label;

	private float mPositionY = -100f;

	public void SetClicked(bool clicked)
	{
		background.color = ((!clicked) ? Colours.blueLowAlpha : Colours.blue);
		underline.gameObject.SetActive(!clicked);
		Rescale();
		AnimateLabel(clicked);
	}

	public void Rescale()
	{
		underline.transform.localScale = underline.transform.localScale.ReplaceX(label.relativeSize.x * label.transform.localScale.x);
	}

	private void AnimateLabel(bool clicked)
	{
		if (mPositionY < -50f)
		{
			mPositionY = label.transform.localPosition.y;
			return;
		}
		if (clicked)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(label.gameObject, 0.2f, label.transform.localPosition.ReplaceY(mPositionY), label.transform.localPosition.ReplaceY(mPositionY + 14f));
			tweenPosition.style = UITweener.Style.PingPong;
			tweenPosition.NumOfRepetitions = 2;
			return;
		}
		TweenPosition component = label.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		label.transform.localPosition = label.transform.localPosition.ReplaceY(mPositionY);
	}
}
