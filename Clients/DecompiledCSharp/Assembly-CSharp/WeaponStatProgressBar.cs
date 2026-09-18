using System.Collections.Generic;
using UnityEngine;

public class WeaponStatProgressBar : Core_BaseScript
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

	[Header("Right")]
	public UISprite border;

	public GameObject numberIncreasePart;

	public UISprite numberIncreaseInside;

	public UILabel numberIncrease;

	public UILabel maxText;

	private Vector3 mDeliveringStartScale = new Vector3(88f, 74f, 1f);

	private Vector3 mDeliveringEndScale = new Vector3(176f, 148f, 1f);

	private Vector3 mStatNumberScale = new Vector3(57f, 57f, 1f);

	private Vector3 mStatNumberBigScale = new Vector3(80f, 80f, 1f);

	private bool mShouldAnimate;

	public void InitializeStat(WeaponLevelsSetup weapon, WeaponLevelsSetup equipppedWeapon, int statIndex)
	{
		List<Tuple<string, float[]>> guiStatistics = weapon.upgradeSlots.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[statIndex];
		bool flag = tuple.Value1 == "ID_SLOTUPGRADE_ROF" || tuple.Value1 == "ID_SLOTUPGRADE_HEAT";
		bool flag2 = tuple.Value1 == "ID_SLOTUPGRADE_POWER" || tuple.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (weapon.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? GetWeaponCategoryMaxValue(weapon, statIndex, flag) : LevelManager.instance.DamageFunction(GetWeaponCategoryMaxValue(weapon, statIndex, flag)));
		mShouldAnimate = num != num3;
		if (!flag && num2 == 0f)
		{
			num2 = 1f;
		}
		if (flag && num == 0f)
		{
			num = 1f;
		}
		statIcon.transform.localPosition = new Vector3(27f, statIcon.transform.localPosition.y, 0f);
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
				ShowUpgrade(num, num3, num2, num4, flag, weapon.weaponState == WeaponLevelsSetup.State.Delivering);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = equipppedWeapon.upgradeSlots.guiStatistics[statIndex];
		bool flag3 = tuple2.Value1 == "ID_SLOTUPGRADE_POWER" || tuple2.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float equippedWeaponValue = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float equippedWeaponMaxValue = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool showUpgrade = weapon.weaponState == WeaponLevelsSetup.State.Active || weapon.weaponState == WeaponLevelsSetup.State.Delivered || weapon.weaponState == WeaponLevelsSetup.State.Delivering;
		bool compare = tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		ShowUpgradeComparison(num, num3, num2, equippedWeaponValue, equippedWeaponMaxValue, num4, flag, showUpgrade, compare, weapon.weaponState == WeaponLevelsSetup.State.Delivering);
	}

	public void AnimateStat()
	{
		if (mShouldAnimate)
		{
			TweenScale tweenScale = TweenScale.Begin(statNumber.gameObject, GuiScreenSingle<WeaponScreen>.instance.upgradeDur * 4f, mStatNumberScale, mStatNumberBigScale);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
	}

	private void SetStatNumber(string statNumberText)
	{
		TweenScale component = statNumber.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		statNumber.transform.localScale = new Vector3(57f, 57f, 1f);
		statNumber.transform.localPosition = statNumber.transform.localPosition.ReplaceY(-4f);
		statNumber.text = statNumberText;
		MiscTools.SetUILabelRescale(statNumber, 57f, 20f, 155);
		float x = statNumber.transform.localScale.x;
		mStatNumberScale = new Vector3(x, x, 1f);
		x = Mathf.Round(x * 1.4f);
		mStatNumberBigScale = new Vector3(x, x, 1f);
	}

	private void ShowMaxUpgraded(float value, bool isTime)
	{
		statIcon.color = Colours.goldUpgrade;
		progressWhite.fillAmount = 1f;
		progressBlue.fillAmount = 1f;
		progressBlue.color = Colours.goldUpgrade;
		SetTextMax(string.Empty);
		SetStatNumber(FloatNumberAccordingToTime(value, isTime));
		statNumber.color = Colours.goldUpgrade;
		compareNumber.gameObject.SetActive(value: false);
		compareMarker.gameObject.SetActive(value: false);
		numberIncreasePart.SetActive(value: false);
		maxText.gameObject.SetActive(value: true);
		DeliveringAnimation(play: false, show: true);
	}

	private void ShowUpgrade(float value, float nextValue, float maxValue, float maxCategoryValue, bool isTime, bool delivering = false)
	{
		float fillAmount = Mathf.Clamp01((!isTime) ? (value / maxCategoryValue) : (maxCategoryValue / value));
		float fillAmount2 = Mathf.Clamp01((!isTime) ? (nextValue / maxCategoryValue) : (maxCategoryValue / nextValue));
		bool flag = ((!isTime) ? (value < nextValue) : (nextValue < value));
		statIcon.color = Colours.blue;
		progressWhite.fillAmount = fillAmount2;
		progressBlue.fillAmount = fillAmount;
		progressBlue.color = Colours.blue;
		SetTextMax(FloatNumberAccordingToTime(maxValue, isTime));
		SetStatNumber(FloatNumberAccordingToTime(value, isTime));
		statNumber.color = Color.white;
		compareNumber.gameObject.SetActive(value: false);
		compareMarker.gameObject.SetActive(value: false);
		numberIncreasePart.SetActive(flag);
		NumberIncreaseColorAndAnimation(delivering);
		maxText.gameObject.SetActive(value: false);
		numberIncrease.text = ((!isTime) ? $"+{MiscTools.FormatFloatNumber(nextValue - value)}" : MiscTools.FormatFloatNumber(nextValue - value));
		DeliveringAnimation(delivering && flag, delivering && flag);
	}

	private void ShowUpgradeComparison(float value, float nextValue, float maxValue, float equippedWeaponValue, float equippedWeaponMaxValue, float weaponCategoryMaxValue, bool isTime, bool showUpgrade, bool compare, bool delivering = false)
	{
		bool flag = showUpgrade && value == maxValue;
		bool flag2 = ((!isTime) ? (equippedWeaponValue < value) : (value < equippedWeaponValue));
		bool flag3 = value == equippedWeaponValue;
		bool flag4 = compare && !flag3;
		float fillAmount = Mathf.Clamp01((!isTime) ? (value / weaponCategoryMaxValue) : (weaponCategoryMaxValue / value));
		float fillAmount2 = Mathf.Clamp01((!isTime) ? (nextValue / weaponCategoryMaxValue) : (weaponCategoryMaxValue / nextValue));
		bool flag5 = ((!isTime) ? (value < nextValue) : (nextValue < value));
		float num = Mathf.Clamp01((!isTime) ? (equippedWeaponValue / weaponCategoryMaxValue) : (weaponCategoryMaxValue / equippedWeaponValue));
		statIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		progressWhite.fillAmount = fillAmount2;
		progressBlue.fillAmount = fillAmount;
		progressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		SetTextMax((!flag) ? FloatNumberAccordingToTime(maxValue, isTime) : string.Empty);
		SetStatNumber(FloatNumberAccordingToTime(value, isTime));
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
		numberIncreasePart.SetActive(showUpgrade && flag5 && !flag);
		maxText.gameObject.SetActive(flag);
		numberIncrease.text = ((!isTime) ? $"+{MiscTools.FormatFloatNumber(nextValue - value)}" : MiscTools.FormatFloatNumber(nextValue - value));
		NumberIncreaseColorAndAnimation(delivering);
		DeliveringAnimation(delivering && flag5, delivering && flag5);
		if (flag)
		{
			border.gameObject.SetActive(value: true);
		}
	}

	private void NumberIncreaseColorAndAnimation(bool delivering)
	{
		if (delivering)
		{
			TweenColor component = numberIncrease.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			numberIncrease.color = Colours.greenDelivering;
		}
		else
		{
			numberIncrease.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(numberIncrease.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.PingPong;
		}
	}

	private void DeliveringAnimation(bool play, bool show)
	{
		border.color = Color.white;
		if (!play)
		{
			TweenAlpha component = border.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			border.alpha = 1f;
			TweenScale component2 = border.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			border.transform.localScale = mDeliveringStartScale;
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(border.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(border.gameObject, 2f * num, mDeliveringStartScale, mDeliveringEndScale);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		border.gameObject.SetActive(show);
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
