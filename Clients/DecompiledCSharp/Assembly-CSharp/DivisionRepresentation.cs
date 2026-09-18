using UnityEngine;

public class DivisionRepresentation : Core_BaseScript
{
	[Header("Core")]
	public UISprite background;

	public UISprite[] arrows;

	public UILabel divisionNumber;

	public UILabel goldRewardLabel;

	private float mMinHeight = 490f;

	public void Initialization(int number)
	{
		background.transform.localScale = new Vector3(background.transform.localScale.x, mMinHeight + (float)number * 58f, 1f);
		divisionNumber.text = MiscTools.FormatBigNumber(8 - number);
		for (int i = 0; i < arrows.Length; i++)
		{
			arrows[i].gameObject.SetActive(i <= number);
		}
		goldRewardLabel.text = MiscTools.FormatFloatNumberSigned(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, number + 1));
	}
}
