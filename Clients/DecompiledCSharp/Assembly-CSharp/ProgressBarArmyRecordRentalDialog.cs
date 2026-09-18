using System.Collections.Generic;
using UnityEngine;

public class ProgressBarArmyRecordRentalDialog : Core_BaseScript
{
	[Header("Left")]
	public UISprite statIcon;

	[Header("Middle")]
	public UILabel statName;

	[Header("-Ability Locked Tier")]
	public UITable abilityLockedTierTable;

	public UILabel abilityLockedTier;

	public List<UISprite> abilityLockedTierStars;

	[Header("-Progress Bar")]
	public GameObject progressBarPart;

	public UISprite progressBlue;

	public UILabel maxStatNumber;

	public UILabel statNumber;

	public void InitializeStat(LevelBehaviour unit, bool attack = true)
	{
		Tuple<string, float[]> tuple = unit.upgradeSlots.upgradeSlot.guiStatistics[(!attack) ? 1 : 0];
		float num = ((!attack) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!attack) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 0f)
		{
			num2 = 1f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		statIcon.transform.localPosition = new Vector3(22f, statIcon.transform.localPosition.y, 0f);
		statIcon.spriteName = ((!attack) ? "menu-health-ico" : "menu-attack-ico");
		statIcon.MakePixelPerfect();
		statIcon.color = Colours.blue;
		statName.text = ((!attack) ? Localization.Localize("ID_HEALTH") : Localization.Localize("ID_ATTACK"));
		abilityLockedTierTable.gameObject.SetActive(value: false);
		progressBarPart.SetActive(value: true);
		progressBlue.fillAmount = fillAmount;
		progressBlue.color = Colours.blue;
		SetTextMax(MiscTools.FormatFloatNumber(num2));
		statNumber.text = MiscTools.FormatFloatNumber(num);
		statNumber.color = Color.white;
	}

	public void InitializeAbility(LevelBehaviour unit)
	{
		int num = unit.upgradeSlots.startTier + 1;
		statIcon.transform.localPosition = new Vector3(27f, statIcon.transform.localPosition.y, 0f);
		statIcon.spriteName = unit.abilityIcon;
		statIcon.MakePixelPerfect();
		statIcon.color = Colours.gray;
		abilityLockedTierTable.gameObject.SetActive(value: true);
		progressBarPart.SetActive(value: false);
		statName.text = unit.unitAbilityName;
		abilityLockedTier.text = Localization.LocalizeFormat("ID_UNLOCKEDATTIER", num);
		for (int i = 0; i < abilityLockedTierStars.Count; i++)
		{
			abilityLockedTierStars[i].gameObject.SetActive(i < num);
		}
		statNumber.text = string.Empty;
		SetTextMax(string.Empty);
	}

	private void SetTextMax(string stringToSet)
	{
		if (string.IsNullOrEmpty(stringToSet))
		{
			maxStatNumber.text = string.Empty;
			float y = maxStatNumber.transform.localScale.y;
			float y2 = statName.transform.localScale.y;
			float num = 25f;
			maxStatNumber.transform.localScale = new Vector3(num, num, 1f);
			statName.transform.localScale = new Vector3(num, num, 1f);
			MiscTools.SetUILabelNewLocalPosition(maxStatNumber, y);
			MiscTools.SetUILabelNewLocalPosition(statName, y2);
			return;
		}
		float y3 = maxStatNumber.transform.localScale.y;
		float y4 = statName.transform.localScale.y;
		maxStatNumber.text = Localization.LocalizeFormat("ID_MAXSTAT", stringToSet);
		float x = maxStatNumber.getSizeForString(statName.text + " " + maxStatNumber.text).x;
		float num2 = Mathf.Floor(224f / x);
		if (num2 < 20f)
		{
			maxStatNumber.text = stringToSet;
			x = maxStatNumber.getSizeForString(statName.text + " " + maxStatNumber.text).x;
			num2 = Mathf.Floor(224f / x);
		}
		if (num2 < 20f)
		{
			Debug.LogError("Problem for max! in army/weapon stats");
		}
		float num3 = Mathf.Clamp(num2, 20f, 25f);
		maxStatNumber.transform.localScale = new Vector3(num3, num3, 1f);
		statName.transform.localScale = new Vector3(num3, num3, 1f);
		MiscTools.SetUILabelNewLocalPosition(maxStatNumber, y3);
		MiscTools.SetUILabelNewLocalPosition(statName, y4);
	}
}
