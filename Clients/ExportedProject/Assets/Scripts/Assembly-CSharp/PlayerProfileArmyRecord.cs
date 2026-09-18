using UnityEngine;

public class PlayerProfileArmyRecord : Core_BaseScript
{
	[Header("Core")]
	public UIPanel starsPanel;

	public UISprite background;

	public UISprite armyIcon;

	public UISprite[] stars;

	public GameObject earlyUnlockPart;

	public void InitializeUnit(LevelBehaviour unit, int tier = 0, bool isEarlyUnlock = false)
	{
		background.color = ((!(unit != null)) ? Colours.grayLog : GameVariables.unitCategory[unit.unitType].Value2);
		background.alpha = 0.2f;
		armyIcon.gameObject.SetActive(unit != null);
		if (unit == null)
		{
			tier = 0;
		}
		else
		{
			armyIcon.spriteName = unit.upgradeSlots.iconName;
			armyIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(167f / armyIcon.transform.localScale.x, 124f / armyIcon.transform.localScale.y);
			armyIcon.transform.localScale = armyIcon.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < stars.Length; i++)
		{
			stars[i].gameObject.SetActive(i < tier);
		}
		earlyUnlockPart.SetActive(isEarlyUnlock);
	}

	public void AnimationSet(float fromAlpha, float dur)
	{
		float num = (1f - fromAlpha) * dur;
		if (num < 0.05f)
		{
			starsPanel.alpha1 = 1f;
			TweenAlpha.Begin(starsPanel.gameObject, 0.01f, 1f);
		}
		else
		{
			starsPanel.alpha1 = fromAlpha;
			TweenAlpha.Begin(starsPanel.gameObject, num, fromAlpha, 1f);
		}
	}
}
