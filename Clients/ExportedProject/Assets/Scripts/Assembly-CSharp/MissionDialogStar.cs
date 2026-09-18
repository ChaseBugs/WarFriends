using UnityEngine;

public class MissionDialogStar : Core_BaseScript
{
	public GameObject star;

	public UILabel scoreForStar;

	internal void Initialize(bool showStar, int score)
	{
		star.SetActive(showStar);
		scoreForStar.text = MiscTools.FormatBigNumber(score);
		scoreForStar.color = ((!showStar) ? Colours.grayMission : Colours.goldMission);
	}
}
