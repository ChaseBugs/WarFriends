using UnityEngine;

public class CardFilter : Core_BaseScript
{
	[Header("Resizeable Parts")]
	public BoxCollider boxCollider;

	public UISprite highlight;

	public UISprite background;

	[Header("Content")]
	public UISprite checkbox;

	public UILabel filterLabel;

	internal void Init(string text, bool selected)
	{
		filterLabel.text = text;
		Selected(selected);
		float num = filterLabel.relativeSize.x * filterLabel.transform.localScale.x + 146f - 20f;
		Vector3 localScale = background.transform.localScale;
		localScale.x = num - 26f;
		background.transform.localScale = localScale;
		Vector3 localScale2 = highlight.transform.localScale;
		localScale2.x = num;
		highlight.transform.localScale = localScale2;
		boxCollider.center = new Vector3(num / 2f, 0f, -0.5f);
		boxCollider.size = new Vector3(num, highlight.transform.localScale.y, 1f);
	}

	public void Selected(bool select)
	{
		background.alpha = 0f;
		checkbox.alpha = ((!select) ? 0f : 1f);
		highlight.alpha = 0f;
		filterLabel.color = ((!select) ? Color.white : Colours.blue);
	}
}
