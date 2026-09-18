using UnityEngine;

public class RoundIcon : Core_BaseScript
{
	public enum RoundIconColorEnum
	{
		yellow,
		gray
	}

	[Header("Content")]
	public UILabel label;

	public UISprite sprite;

	public void InitIcon(int round, RoundIconColorEnum color)
	{
		label.text = round.ToString();
		if (color == RoundIconColorEnum.gray)
		{
			sprite.spriteName = "menu-leagues-squadwar-ico-bg-bw";
			label.color = Colours.gray;
		}
		else
		{
			sprite.spriteName = "menu-leagues-squadwar-ico-bg";
			label.color = Color.white;
		}
	}
}
