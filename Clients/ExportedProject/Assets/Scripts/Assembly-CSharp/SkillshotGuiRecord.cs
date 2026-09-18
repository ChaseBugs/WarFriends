using System;
using UnityEngine;

public class SkillshotGuiRecord : PoolableObject, IComparable<SkillshotGuiRecord>
{
	[Header("Left Part")]
	public UISprite playerBackground;

	public UILabel playerScore;

	public UILabel playerModifier;

	public UISprite playerWin;

	[Header("Right Part")]
	public UISprite opponentBackground;

	public UILabel opponentScore;

	public UILabel opponentModifier;

	public UISprite opponentWin;

	[Header("Middle Part")]
	public UISprite skillshotIcon;

	public UILabel skillshotType;

	public GameObject barParent;

	public UISprite bar;

	public UISprite whiteBar;

	public UISprite backgroundBar;

	[Header("Settings")]
	public bool isSpecial;

	[HideInInspector]
	public int plModifier;

	[HideInInspector]
	public int opModifier;

	[HideInInspector]
	public int plScore;

	[HideInInspector]
	public int opScore;

	[HideInInspector]
	public float plProgress;

	private Color mInactiveColor = Color.gray;

	private Color mActiveColorPl = Color.white;

	public void MultiplayerSkillshot(int playerCount, int opponentCount, SkillShot.SkillShotType skillType)
	{
		isSpecial = false;
		SetMultiPlayer();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(skillType);
		skillshotType.text = itemDefinition.menuName;
		MiscTools.SetUILabelRescale(skillshotType, 37f, 20f, 420);
		skillshotIcon.spriteName = itemDefinition.iconName;
		skillshotIcon.MakePixelPerfect();
		plScore = playerCount;
		plModifier = playerCount * itemDefinition.points;
		playerScore.text = $"x{playerCount}";
		playerModifier.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MiscTools.FormatBigNumber(playerCount * itemDefinition.points);
		opScore = opponentCount;
		opModifier = opponentCount * itemDefinition.points;
		opponentScore.text = $"x{opponentCount}";
		opponentModifier.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MiscTools.FormatBigNumber(opponentCount * itemDefinition.points);
		playerModifier.color = ((playerCount < opponentCount) ? mInactiveColor : mActiveColorPl);
		playerWin.alpha = ((playerCount <= opponentCount) ? 0f : 1f);
		opponentModifier.color = ((playerCount > opponentCount) ? mInactiveColor : mActiveColorPl);
		opponentWin.alpha = ((playerCount >= opponentCount) ? 0f : 1f);
		bar.fillAmount = ((playerCount + opponentCount <= 0) ? 0.5f : ((float)playerCount / (float)(playerCount + opponentCount)));
		plProgress = bar.fillAmount;
		whiteBar.fillAmount = bar.fillAmount;
	}

	public void SingleplayerSkillshot(int playerCount, SkillShot.SkillShotType skillType)
	{
		isSpecial = false;
		SetSinglePlayer();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(skillType);
		skillshotType.text = itemDefinition.menuName;
		MiscTools.SetUILabelRescale(skillshotType, 37f, 20f, 420);
		skillshotIcon.spriteName = itemDefinition.iconName;
		skillshotIcon.MakePixelPerfect();
		plScore = playerCount;
		plModifier = playerCount * itemDefinition.points;
		playerScore.text = $"x{playerCount}";
		playerModifier.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MiscTools.FormatBigNumber(playerCount * itemDefinition.points);
		playerModifier.color = mActiveColorPl;
		playerWin.alpha = 0f;
		opScore = 0;
		opModifier = -1;
		opponentScore.text = string.Empty;
		opponentModifier.text = string.Empty;
		opponentModifier.color = mInactiveColor;
		opponentWin.alpha = 0f;
		bar.fillAmount = ((playerCount <= 0) ? 0f : 1f);
		plProgress = bar.fillAmount;
		whiteBar.fillAmount = bar.fillAmount;
	}

	public void MultiplayerSkillshotSpecial(int playerScoreValue, int opponentScoreValue)
	{
		isSpecial = true;
		SetMultiPlayer();
		skillshotType.text = Localization.Localize("ID_SCORE");
		MiscTools.SetUILabelRescale(skillshotType, 37f, 20f, 420);
		plScore = playerScoreValue;
		plModifier = 0;
		playerScore.text = MiscTools.FormatBigNumber(playerScoreValue);
		playerModifier.text = string.Empty;
		opScore = opponentScoreValue;
		opModifier = 0;
		opponentScore.text = MiscTools.FormatBigNumber(opponentScoreValue);
		opponentModifier.text = string.Empty;
		playerModifier.color = ((playerScoreValue < opponentScoreValue) ? mInactiveColor : mActiveColorPl);
		playerWin.alpha = ((playerScoreValue <= opponentScoreValue) ? 0f : 1f);
		opponentModifier.color = ((playerScoreValue > opponentScoreValue) ? mInactiveColor : mActiveColorPl);
		opponentWin.alpha = ((playerScoreValue >= opponentScoreValue) ? 0f : 1f);
		bar.fillAmount = ((playerScoreValue + opponentScoreValue <= 0) ? 0.5f : ((float)playerScoreValue / (float)(playerScoreValue + opponentScoreValue)));
		plProgress = bar.fillAmount;
		whiteBar.fillAmount = bar.fillAmount;
	}

	public void SingleplayerSkillshotSpecial(int playerScoreValue)
	{
		isSpecial = true;
		SetSinglePlayer();
		skillshotType.text = Localization.Localize("ID_SCORE");
		MiscTools.SetUILabelRescale(skillshotType, 37f, 20f, 420);
		plScore = playerScoreValue;
		plModifier = 0;
		playerScore.text = MiscTools.FormatBigNumber(playerScoreValue);
		playerModifier.text = string.Empty;
		playerModifier.color = mActiveColorPl;
		playerWin.alpha = 0f;
		opScore = 0;
		opModifier = -1;
		opponentScore.text = string.Empty;
		opponentModifier.text = string.Empty;
		opponentModifier.color = mInactiveColor;
		opponentWin.alpha = 0f;
		bar.fillAmount = ((playerScoreValue <= 0) ? 0f : 1f);
		plProgress = bar.fillAmount;
		whiteBar.fillAmount = bar.fillAmount;
	}

	private void SetSinglePlayer()
	{
		barParent.transform.localPosition = new Vector3(101f, barParent.transform.localPosition.y, barParent.transform.localPosition.z);
		bar.transform.localScale = new Vector3(1134f, bar.transform.localScale.y, bar.transform.localScale.z);
		whiteBar.transform.localScale = new Vector3(1134f, whiteBar.transform.localScale.y, whiteBar.transform.localScale.z);
		backgroundBar.transform.localScale = new Vector3(1134f, backgroundBar.transform.localScale.y, backgroundBar.transform.localScale.z);
	}

	private void SetMultiPlayer()
	{
		barParent.transform.localPosition = new Vector3(0f, barParent.transform.localPosition.y, barParent.transform.localPosition.z);
		bar.transform.localScale = new Vector3(932f, bar.transform.localScale.y, bar.transform.localScale.z);
		whiteBar.transform.localScale = new Vector3(932f, whiteBar.transform.localScale.y, whiteBar.transform.localScale.z);
		backgroundBar.transform.localScale = new Vector3(932f, backgroundBar.transform.localScale.y, backgroundBar.transform.localScale.z);
	}

	public int CompareTo(SkillshotGuiRecord other)
	{
		if (other == null)
		{
			return -1;
		}
		if (isSpecial && !other.isSpecial)
		{
			return -1;
		}
		if (!isSpecial && other.isSpecial)
		{
			return 1;
		}
		return base.name.CompareTo(other.name);
	}

	public void HideAll()
	{
		playerBackground.alpha = 0f;
		playerScore.alpha = 0f;
		playerModifier.alpha = 0f;
		playerWin.alpha = 0f;
		skillshotIcon.alpha = 0f;
		skillshotType.alpha = 0f;
		bar.alpha = 0f;
		whiteBar.alpha = 0f;
		backgroundBar.alpha = 0f;
		opponentBackground.alpha = 0f;
		opponentScore.alpha = 0f;
		opponentModifier.alpha = 0f;
		opponentWin.alpha = 0f;
		TweenAlpha.Begin(playerBackground.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(playerScore.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(playerModifier.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(playerWin.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(skillshotIcon.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(skillshotType.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(bar.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(whiteBar.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(backgroundBar.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(opponentBackground.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(opponentScore.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(opponentModifier.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(opponentWin.gameObject, 0.01f, 0f);
	}
}
