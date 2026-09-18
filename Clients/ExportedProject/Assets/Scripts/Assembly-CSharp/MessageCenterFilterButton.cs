using UnityEngine;

public class MessageCenterFilterButton : Core_BaseScript
{
	[Header("Name")]
	public UILabel filterName;

	[Header("Core")]
	public UISprite border;

	public UISprite highlight;

	public BoxCollider boxCollider;

	[Header("Spacer")]
	public UISprite spacer;

	public void InitializeFilter(string name, float size, bool selected)
	{
		filterName.text = name;
		filterName.transform.localScale = new Vector3(size, size, 1f);
		border.transform.localScale = new Vector3(filterName.relativeSize.x * filterName.transform.localScale.x + 46f, 80f, 1f);
		highlight.transform.localScale = new Vector3(border.transform.localScale.x + 26f, border.transform.localScale.y + 26f, 1f);
		spacer.transform.localScale = new Vector3(border.transform.localScale.x + 12f, highlight.transform.localScale.y, 1f);
		boxCollider.size = spacer.transform.localScale;
		Select(selected);
	}

	internal void InitFilter(string name, bool selected)
	{
		filterName.text = name;
		border.transform.localScale = new Vector3(filterName.relativeSize.x * filterName.transform.localScale.x + 40f, 80f, 1f);
		highlight.transform.localScale = new Vector3(border.transform.localScale.x + 26f, border.transform.localScale.y + 26f, 1f);
		spacer.transform.localScale = new Vector3(border.transform.localScale.x + 12f, highlight.transform.localScale.y, 1f);
		boxCollider.size = spacer.transform.localScale;
		Select(selected);
	}

	public void Select(bool selected)
	{
		filterName.color = ((!selected) ? Color.white : Colours.blue);
		border.gameObject.SetActive(!selected);
		highlight.gameObject.SetActive(selected);
	}
}
