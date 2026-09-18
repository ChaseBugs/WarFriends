using System.Collections.Generic;
using UnityEngine;

public class ArmyStatProgressBar : Core_BaseScript
{
	private enum StatType
	{
		Normal,
		SpecialAbility,
		ElitePerk
	}

	[SerializeField]
	[Header("Core")]
	private StatType mCurrentType;

	public UISprite statIcon;

	public UISprite statBuffIcon;

	public UILabel statName;

	[Header("-Ability Locked")]
	public GameObject abilityLockedPart;

	public UITable abilityLockedTierTable;

	public UILabel abilityLockedTier;

	public UISprite[] abilityLockedTierStars;

	[Header("-Elite Locked")]
	public GameObject eliteLockedPart;

	public UILabel eliteLockedLabel;

	[Header("-Progress Bar")]
	public GameObject progressBarPart;

	public UISprite progressWhite;

	public UISprite progressBlue;

	public UILabel maxStatNumber;

	public UILabel statNumber;

	[Header("--Right Box")]
	public UISprite border;

	public UILabel numberIncrease;

	public UILabel maxText;

	private Vector3 mStatNumberScale = new Vector3(62f, 62f, 1f);

	private Vector3 mStatNumberBigScale = new Vector3(87f, 87f, 1f);

	private static Dictionary<StatType, Color> mColor1 = new Dictionary<StatType, Color>
	{
		{
			StatType.Normal,
			Colours.blueUpgradeAnim1
		},
		{
			StatType.SpecialAbility,
			Colours.yellowUpgradeAnim1
		},
		{
			StatType.ElitePerk,
			Colours.greenUpgradeAnim1
		}
	};

	private static Dictionary<StatType, Color> mColor2 = new Dictionary<StatType, Color>
	{
		{
			StatType.Normal,
			Colours.blueUpgradeAnim2
		},
		{
			StatType.SpecialAbility,
			Colours.yellowUpgradeAnim2
		},
		{
			StatType.ElitePerk,
			Colours.greenUpgradeAnim2
		}
	};

	private static Dictionary<StatType, Color> mMaxColor = new Dictionary<StatType, Color>
	{
		{
			StatType.Normal,
			Colours.blue
		},
		{
			StatType.SpecialAbility,
			Colours.goldUpgrade
		},
		{
			StatType.ElitePerk,
			Colours.greenArena
		}
	};

	public void InitializeStat(LevelBehaviour unit, bool isDamage)
	{
		Tuple<string, float[]> tuple = unit.upgradeSlots.upgradeSlot.guiStatistics[(!isDamage) ? 1 : 0];
		bool bought = unit.upgradeSlots.bought;
		bool flag = unit.upgradeSlots.unitState == UpgradeSlots.State.Delivering && !unit.upgradeSlots.deliveringSlot.isSpecial;
		float num = ((!isDamage) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!isDamage) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!isDamage) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (unit.upgradeSlots.borrowed)
		{
			num3 = num;
		}
		float num4 = num3 - num;
		bool flag2 = num4 > 0f;
		bool flag3 = num == num2;
		float num5 = ((!flag3) ? Mathf.Clamp01(num / num2) : 1f);
		float fillAmount = ((!bought) ? num5 : (flag3 ? 1f : ((!flag) ? num5 : Mathf.Clamp01(num3 / num2))));
		statIcon.spriteName = ((!isDamage) ? "menu-health-ico" : "menu-attack-ico");
		statIcon.MakePixelPerfect();
		statIcon.transform.localPosition = statIcon.transform.localPosition.ReplaceX(27f);
		statBuffIcon.gameObject.SetActive(value: false);
		statName.text = ((!isDamage) ? Localization.Localize("ID_HEALTH") : Localization.Localize("ID_ATTACK"));
		abilityLockedPart.SetActive(value: false);
		eliteLockedPart.SetActive(value: false);
		progressBarPart.SetActive(value: true);
		SetStatText(MiscTools.FormatFloatNumber(num));
		SetTextMax((!flag3) ? MiscTools.FormatFloatNumber(num2) : string.Empty);
		Color color = mMaxColor[mCurrentType];
		statIcon.color = ((!flag3) ? Colours.blue : color);
		progressBlue.color = ((!flag3) ? Colours.blue : color);
		statNumber.color = ((!flag3) ? Color.white : color);
		progressBlue.fillAmount = num5;
		progressWhite.fillAmount = fillAmount;
		if (bought)
		{
			if (flag3)
			{
				SetMax(color);
			}
			else
			{
				SetIncrease((!flag2) ? string.Empty : $"+{MiscTools.FormatFloatNumber(num4)}");
			}
			if (flag && flag2)
			{
				StartDeliveryAnimation();
			}
			else
			{
				StopDeliveryAnimation();
			}
		}
		else
		{
			SetIncrease(string.Empty);
			StopDeliveryAnimation();
		}
	}

	public void InitializeSpecial(LevelBehaviour unit)
	{
		bool flag = unit.upgradeSlots.bought && unit.upgradeSlots.upgradeSlotSpecial.isBought;
		statIcon.transform.localPosition = statIcon.transform.localPosition.ReplaceX(27f);
		statIcon.spriteName = unit.abilityIcon;
		statIcon.MakePixelPerfect();
		statBuffIcon.gameObject.SetActive(value: false);
		statName.text = Localization.Localize("ID_ABILITY");
		if (flag)
		{
			bool isDelivering = unit.upgradeSlots.unitState == UpgradeSlots.State.Delivering && unit.upgradeSlots.deliveringSlot.isSpecial;
			ShowAbility(unit.upgradeSlots.upgradeSlotSpecial.guiStatistics[0], isDelivering);
		}
		else
		{
			ShowLockedAbility(unit);
		}
	}

	public void InitializeElite(LevelBehaviour unit)
	{
		bool flag = unit.upgradeSlots.bought && unit.upgradeSlots.upgradeSlotElite.isBought;
		statBuffIcon.gameObject.SetActive(value: true);
		unit.SetUpEliteIcon(statIcon, statBuffIcon);
		statIcon.MakePixelPerfect();
		statIcon.transform.localPosition.ReplaceX(27f);
		statName.text = Localization.Localize("ID_ELITEPERK");
		if (flag)
		{
			ShowBuff(unit.upgradeSlots.upgradeSlotElite.guiStatistics[0]);
		}
		else
		{
			ShowLockedBuff(unit);
		}
	}

	private void ShowLockedAbility(LevelBehaviour unit)
	{
		int num = unit.upgradeSlots.startTier + 1;
		abilityLockedPart.SetActive(value: true);
		eliteLockedPart.SetActive(value: false);
		progressBarPart.SetActive(value: false);
		abilityLockedTier.text = Localization.LocalizeFormat("ID_UNLOCKEDATTIER", num);
		MiscTools.SetUILabelRescale(abilityLockedTier, 25f, 20f, 320);
		for (int i = 0; i < abilityLockedTierStars.Length; i++)
		{
			abilityLockedTierStars[i].gameObject.SetActive(i < num);
		}
		statIcon.color = Colours.gray;
		SetTextMax(string.Empty);
	}

	private void ShowAbility(Tuple<string, float[]> statistic, bool isDelivering)
	{
		float num = statistic.Value2[0];
		float num2 = statistic.Value2[1];
		float num3 = statistic.Value2[2];
		bool flag = num == num2;
		bool flag2 = num3 < num;
		float num4 = num3 - num;
		bool flag3 = ((!flag2) ? (num4 > 0f) : (num4 < 0f));
		float num5 = ((!flag) ? Mathf.Clamp01((!flag2) ? (num / num2) : (num2 / num)) : 1f);
		float fillAmount = (flag ? 1f : ((!isDelivering) ? num5 : Mathf.Clamp01((!flag2) ? (num3 / num2) : (num2 / num3))));
		abilityLockedPart.SetActive(value: false);
		eliteLockedPart.SetActive(value: false);
		progressBarPart.SetActive(value: true);
		if (statistic.Value1 == "percent")
		{
			SetStatText(MiscTools.FormatFloatNumberAsPercent(num));
			SetTextMax((!flag) ? MiscTools.FormatFloatNumberAsPercent(num2) : string.Empty);
		}
		else if (statistic.Value1 == "seconds")
		{
			SetStatText(MiscTools.FormatNumberAsSeconds(num));
			SetTextMax((!flag) ? MiscTools.FormatNumberAsSeconds(num2) : string.Empty);
		}
		else if (statistic.Value1 == "damage")
		{
			SetStatText(MiscTools.FormatFloatNumberRoundZeroOrOne(num));
			SetTextMax((!flag) ? MiscTools.FormatFloatNumberRoundZeroOrOne(num2) : string.Empty);
		}
		else
		{
			SetStatText(string.Empty);
			SetTextMax(string.Empty);
		}
		Color color = mMaxColor[mCurrentType];
		statNumber.color = ((!flag) ? Color.white : color);
		statIcon.color = ((!flag) ? Colours.yellow : color);
		progressBlue.color = ((!flag) ? Colours.yellow : color);
		progressBlue.fillAmount = num5;
		progressWhite.fillAmount = fillAmount;
		if (flag)
		{
			SetMax(color);
		}
		else if (flag3)
		{
			if (statistic.Value1 == "percent")
			{
				SetIncrease(MiscTools.FormatFloatNumberAsPercentSigned(num4));
			}
			else if (statistic.Value1 == "seconds")
			{
				SetIncrease(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MiscTools.FormatNumberAsSeconds(num4)));
			}
			else if (statistic.Value1 == "damage")
			{
				SetIncrease(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MiscTools.FormatFloatNumberRoundZeroOrOne(num4)));
			}
			MiscTools.SetUILabelRescale(numberIncrease, 47f, 15f, 88);
		}
		else
		{
			SetIncrease(string.Empty);
		}
		if (isDelivering && flag3)
		{
			StartDeliveryAnimation();
		}
		else
		{
			StopDeliveryAnimation();
		}
	}

	private void ShowLockedBuff(LevelBehaviour unit)
	{
		int currentParts = unit.upgradeSlots.upgradeSlotElite.currentParts;
		int upgradePriceParts = unit.upgradeSlots.upgradeSlotElite.upgradePriceParts;
		abilityLockedPart.SetActive(value: false);
		eliteLockedPart.SetActive(value: true);
		progressBarPart.SetActive(value: false);
		eliteLockedLabel.text = Localization.LocalizeFormat("ID_COLLECTXELITEPARTSX", Colours.stringGreenArena, upgradePriceParts, Colours.stringWhite, currentParts);
		MiscTools.SetUILabelRescale(eliteLockedLabel, 25f, 20f, 490);
		statIcon.color = Colours.gray;
		SetTextMax(string.Empty);
	}

	private void ShowBuff(Tuple<string, float[]> statistic)
	{
		float num = statistic.Value2[0];
		float num2 = statistic.Value2[1];
		float num3 = statistic.Value2[2];
		bool flag = num == num2;
		float value = num3 - num;
		bool flag2 = true;
		float num4 = ((!flag) ? Mathf.Clamp01(num / num2) : 1f);
		float fillAmount = ((!flag) ? num4 : 1f);
		abilityLockedPart.SetActive(value: false);
		eliteLockedPart.SetActive(value: false);
		progressBarPart.SetActive(value: true);
		SetStatText(MiscTools.FormatFloatNumberAsPercent(num));
		SetTextMax((!flag) ? MiscTools.FormatFloatNumberAsPercent(num2) : string.Empty);
		Color color = mMaxColor[mCurrentType];
		statNumber.color = ((!flag) ? Color.white : color);
		statIcon.color = ((!flag) ? Colours.greenArena : color);
		progressBlue.color = ((!flag) ? Colours.greenArena : color);
		progressBlue.fillAmount = num4;
		progressWhite.fillAmount = fillAmount;
		if (flag)
		{
			SetMax(color);
		}
		else if (flag2)
		{
			SetIncrease(MiscTools.FormatFloatNumberAsPercentSigned(value));
			MiscTools.SetUILabelRescale(numberIncrease, 47f, 15f, 88);
		}
	}

	private void StartDeliveryAnimation()
	{
		float num = 0.5f;
		TweenColor component = numberIncrease.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		numberIncrease.color = Colours.greenDelivering;
		border.gameObject.SetActive(value: true);
		border.color = Color.white;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(border.gameObject, 2f * num, 1f, 0f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(border.gameObject, 2f * num, new Vector3(88f, 74f, 1f), new Vector3(176f, 148f, 1f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	private void StopDeliveryAnimation()
	{
		Color color = mColor1[mCurrentType];
		Color to = mColor2[mCurrentType];
		numberIncrease.color = color;
		TweenColor tweenColor = TweenColor.Begin(numberIncrease.gameObject, 0.6f, color, to);
		tweenColor.NumOfRepetitions = 0;
		tweenColor.style = UITweener.Style.PingPong;
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
		border.transform.localScale = new Vector3(88f, 74f, 1f);
	}

	public void AnimateStat()
	{
		if (progressBarPart.activeSelf)
		{
			TweenScale tweenScale = TweenScale.Begin(statNumber.gameObject, GuiScreenSingle<WeaponScreen>.instance.upgradeDur * 4f, mStatNumberScale, mStatNumberBigScale);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
	}

	private void SetStatText(string statText)
	{
		TweenScale component = statNumber.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		statNumber.transform.localScale = new Vector3(62f, 62f, 1f);
		statNumber.transform.localPosition = statNumber.transform.localPosition.ReplaceY(12f);
		statNumber.text = statText;
		MiscTools.SetUILabelRescale(statNumber, 62f, 20f, 155);
		mStatNumberScale = statNumber.transform.localScale;
		mStatNumberBigScale = statNumber.transform.localScale.MultiplyXY(1.4f);
	}

	private void SetIncrease(string textValue)
	{
		border.gameObject.SetActive(value: false);
		numberIncrease.gameObject.SetActive(value: true);
		numberIncrease.text = textValue;
		maxText.gameObject.SetActive(value: false);
	}

	private void SetMax(Color colour)
	{
		border.gameObject.SetActive(value: true);
		border.color = Color.white;
		numberIncrease.gameObject.SetActive(value: false);
		maxText.gameObject.SetActive(value: true);
		maxText.color = colour;
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
