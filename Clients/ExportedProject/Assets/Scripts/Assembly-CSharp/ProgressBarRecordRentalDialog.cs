using System.Collections.Generic;
using UnityEngine;

public class ProgressBarRecordRentalDialog : Core_BaseScript
{
	[Header("Left")]
	public UISprite statIcon;

	[Header("Middle")]
	public UILabel statName;

	public UISprite progressWhite;

	public UISprite progressBlue;

	public UILabel maxStatNumber;

	public UILabel statNumber;

	public UILabel compareNumber;

	public UISprite compareMarker;

	public void InitializeStat(WeaponLevelsSetup weapon, WeaponLevelsSetup equipppedWeapon, int statIndex)
	{
		List<Tuple<string, float[]>> guiStatistics = weapon.upgradeSlots.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[statIndex];
		bool flag = tuple.Value1 == "ID_SLOTUPGRADE_ROF" || tuple.Value1 == "ID_SLOTUPGRADE_HEAT";
		bool flag2 = tuple.Value1 == "ID_SLOTUPGRADE_POWER" || tuple.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float nextValue = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		float num3 = ((!flag2) ? GetWeaponCategoryMaxValue(weapon, statIndex, flag) : LevelManager.instance.DamageFunction(GetWeaponCategoryMaxValue(weapon, statIndex, flag)));
		if (!flag && num2 == 0f)
		{
			num2 = 1f;
		}
		if (flag && num == 0f)
		{
			num = 1f;
		}
		statIcon.transform.localPosition = statIcon.transform.localPosition.ReplaceX(27f);
		statIcon.spriteName = GameVariables.weaponStatisticsIcon[tuple.Value1];
		statIcon.MakePixelPerfect();
		statName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_ATTACK"));
		if (weapon == equipppedWeapon || equipppedWeapon == null)
		{
			if (num == num2)
			{
				ShowMaxUpgraded(num, flag);
			}
			else
			{
				ShowUpgrade(num, nextValue, num2, num3, flag, weapon.weaponState == WeaponLevelsSetup.State.Delivering);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = equipppedWeapon.upgradeSlots.guiStatistics[statIndex];
		bool flag3 = tuple2.Value1 == "ID_SLOTUPGRADE_POWER" || tuple2.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float equippedWeaponValue = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float equippedWeaponMaxValue = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool showUpgrade = weapon.weaponState == WeaponLevelsSetup.State.Active || weapon.weaponState == WeaponLevelsSetup.State.Delivered || weapon.weaponState == WeaponLevelsSetup.State.Delivering;
		bool compare = weapon.weaponCategory == equipppedWeapon.weaponCategory && (tuple2.Value1 == tuple.Value1 || (flag2 && flag3));
		ShowUpgradeComparison(num, nextValue, num2, equippedWeaponValue, equippedWeaponMaxValue, num3, flag, showUpgrade, compare, weapon.weaponState == WeaponLevelsSetup.State.Delivering);
	}

	private void ShowMaxUpgraded(float value, bool isTime)
	{
		statIcon.color = Colours.goldUpgrade;
		progressWhite.fillAmount = 1f;
		progressBlue.fillAmount = 1f;
		progressBlue.color = Colours.goldUpgrade;
		SetTextMax(string.Empty);
		statNumber.text = FloatNumberAccordingToTime(value, isTime);
		statNumber.color = Colours.goldUpgrade;
		compareNumber.gameObject.SetActive(value: false);
		compareMarker.gameObject.SetActive(value: false);
	}

	private void ShowUpgrade(float value, float nextValue, float maxValue, float maxCategoryValue, bool isTime, bool delivering = false)
	{
		float fillAmount = Mathf.Clamp01((!isTime) ? (value / maxCategoryValue) : (maxCategoryValue / value));
		float fillAmount2 = Mathf.Clamp01((!isTime) ? (nextValue / maxCategoryValue) : (maxCategoryValue / nextValue));
		statIcon.color = Colours.blue;
		progressWhite.fillAmount = fillAmount2;
		progressBlue.fillAmount = fillAmount;
		progressBlue.color = Colours.blue;
		SetTextMax(FloatNumberAccordingToTime(maxValue, isTime));
		statNumber.text = FloatNumberAccordingToTime(value, isTime);
		statNumber.color = Color.white;
		compareNumber.gameObject.SetActive(value: false);
		compareMarker.gameObject.SetActive(value: false);
	}

	private void ShowUpgradeComparison(float value, float nextValue, float maxValue, float equippedWeaponValue, float equippedWeaponMaxValue, float weaponCategoryMaxValue, bool isTime, bool showUpgrade, bool compare, bool delivering = false)
	{
		bool flag = showUpgrade && value == maxValue;
		bool flag2 = ((!isTime) ? (equippedWeaponValue < value) : (value < equippedWeaponValue));
		bool flag3 = value == equippedWeaponValue;
		bool flag4 = compare && !flag3;
		float fillAmount = Mathf.Clamp01((!isTime) ? (value / weaponCategoryMaxValue) : (weaponCategoryMaxValue / value));
		float fillAmount2 = Mathf.Clamp01((!isTime) ? (nextValue / weaponCategoryMaxValue) : (weaponCategoryMaxValue / nextValue));
		float num = Mathf.Clamp01((!isTime) ? (equippedWeaponValue / weaponCategoryMaxValue) : (weaponCategoryMaxValue / equippedWeaponValue));
		statIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		progressWhite.fillAmount = fillAmount2;
		progressBlue.fillAmount = fillAmount;
		progressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		SetTextMax(FloatNumberAccordingToTime(maxValue, isTime));
		statNumber.text = FloatNumberAccordingToTime(value, isTime);
		statNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		compareNumber.gameObject.SetActive(flag4);
		compareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			compareNumber.text = MiscTools.FormatFloatNumberSigned(value - equippedWeaponValue);
			compareMarker.transform.localPosition = compareMarker.transform.localPosition.ReplaceX(progressBlue.transform.parent.localPosition.x + progressBlue.transform.localPosition.x + progressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			progressBlue.color = color;
			statNumber.color = color;
			compareNumber.color = color;
		}
	}

	private float GetWeaponCategoryMaxValue(WeaponLevelsSetup weapon, int statIndex, bool isTimeValue)
	{
		float num = ((!isTimeValue) ? float.MinValue : float.MaxValue);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.weaponCategory != weapon.weaponCategory)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.upgradeSlots.guiStatistics[statIndex].Value2[1];
			if (isTimeValue)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
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

	private string FloatNumberAccordingToTime(float value, bool isTimeValue)
	{
		return (!isTimeValue) ? MiscTools.FormatFloatNumber(value) : MiscTools.FormatNumberAsSeconds(value);
	}
}
