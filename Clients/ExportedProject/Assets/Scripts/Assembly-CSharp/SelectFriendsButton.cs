using UnityEngine;

public class SelectFriendsButton : Core_BaseScript
{
	public UISprite background;

	public UISprite highlight;

	public UISprite arrow;

	public UILabel nameLabel;

	private bool mInactive;

	internal void SetHighlight(bool setHighlight)
	{
		if (!mInactive)
		{
			highlight.gameObject.SetActive(setHighlight);
			nameLabel.color = ((!setHighlight) ? Color.white : Colours.blue);
			arrow.transform.localRotation = ((!setHighlight) ? Quaternion.Euler(0f, 0f, 270f) : Quaternion.Euler(0f, 0f, 180f));
		}
	}

	internal void SetInactiveSquad(bool inactive)
	{
		mInactive = inactive;
		highlight.gameObject.SetActive(value: false);
		nameLabel.color = ((!inactive) ? Color.white : Colours.gray);
		arrow.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
	}

	internal void SetSize(bool longForm)
	{
		float num = ((!longForm) ? 466f : 672f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 0f)) ? 1 : (-1));
		localPosition.x = ((!longForm) ? 483f : 380f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = background.transform.localScale;
		localScale.x = num;
		background.transform.localScale = localScale;
		Vector3 localScale2 = highlight.transform.localScale;
		localScale2.x = num + 30f;
		highlight.transform.localScale = localScale2;
		Vector3 localPosition2 = arrow.transform.localPosition;
		localPosition2.x = (num / 2f - 60f) * -1f;
		arrow.transform.localPosition = localPosition2;
	}
}
