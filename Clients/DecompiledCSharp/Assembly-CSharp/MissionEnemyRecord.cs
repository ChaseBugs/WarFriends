using System.Collections;
using UnityEngine;

public class MissionEnemyRecord : PoolableObject
{
	[Header("Icons")]
	public UISprite armyIcon;

	public UISprite cardIcon;

	public PlayerIcon bossIcon;

	[Header("Over Text")]
	public GameObject bottomPart;

	public UISprite background;

	public UILabel nameLabel;

	public void Initialize(MissionDialog.MissionEnemiesData enemyData)
	{
		armyIcon.gameObject.SetActive(enemyData.unitType == MissionDialog.MissionEnemiesData.UnitType.Unit);
		cardIcon.gameObject.SetActive(enemyData.unitType == MissionDialog.MissionEnemiesData.UnitType.Card);
		bossIcon.gameObject.SetActive(enemyData.unitType == MissionDialog.MissionEnemiesData.UnitType.Bot);
		bottomPart.SetActive(enemyData.unitType != MissionDialog.MissionEnemiesData.UnitType.Unit);
		if (enemyData.unitType == MissionDialog.MissionEnemiesData.UnitType.Unit)
		{
			armyIcon.spriteName = enemyData.iconName;
			armyIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(162f / armyIcon.transform.localScale.x, 118f / armyIcon.transform.localScale.y);
			armyIcon.transform.localScale = armyIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else if (enemyData.unitType == MissionDialog.MissionEnemiesData.UnitType.Card)
		{
			cardIcon.spriteName = enemyData.iconName;
			cardIcon.MakePixelPerfect();
			float multiplier2 = Mathf.Min(162f / cardIcon.transform.localScale.x, 118f / cardIcon.transform.localScale.y);
			cardIcon.transform.localScale = cardIcon.transform.localScale.MultiplyXY(multiplier2);
			background.color = Colours.blueElite;
			nameLabel.text = Localization.Localize("ID_ELITE");
		}
		else
		{
			background.color = Colours.goldBoss;
			nameLabel.text = Localization.Localize("ID_BOSS");
			bossIcon.Reset();
			StartCoroutine(BossIconWorker(enemyData.botVisuals));
		}
	}

	private IEnumerator BossIconWorker(string[] visualIndices)
	{
		Texture2D bossTexture = GuiElementSingle<MissionDialog>.instance.GetBossTexture();
		yield return StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreatePlayerTexture(visualIndices, bossTexture, useBackground: false));
		bossIcon.avatar = bossTexture;
	}
}
