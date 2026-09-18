using UnityEngine;

public class HexRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite baseBackground;

	public UISprite leftBackground;

	public UISprite rightBackground;

	public void Initialize(float width, float height)
	{
		leftBackground.transform.localScale = leftBackground.transform.localScale.ReplaceX(width / 2f);
		rightBackground.transform.localScale = rightBackground.transform.localScale.ReplaceX(width / 2f);
		baseBackground.transform.localScale = baseBackground.transform.localScale.ReplaceXY(width, height);
	}
}
