using UnityEngine;

public class CheckBoxButton : Core_BaseScript
{
	public UISprite checkBox;

	public UILabel nameOfCheck;

	public BoxCollider boxCollider;

	internal void Initialize(string nameToFill)
	{
		nameOfCheck.text = nameToFill;
		nameOfCheck.color = Colours.grayButton;
		checkBox.alpha = 0f;
		float num = nameOfCheck.relativeSize.x * nameOfCheck.transform.localScale.x + 60f;
		boxCollider.center = new Vector3(num / 2f, 0f, -0.5f);
		boxCollider.size = new Vector3(num + 20f, 56f, 0f);
	}

	public void SetSelected(bool isSelected)
	{
		checkBox.alpha = ((!isSelected) ? 0f : 1f);
		nameOfCheck.color = ((!isSelected) ? Colours.grayButton : Colours.blue);
	}
}
