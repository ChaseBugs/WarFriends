using UnityEngine;

public class ArmyUnitStatistics : Core_BaseScript
{
	[Header("Optional")]
	public UISprite[] statisticIcons;

	[Header("Core")]
	public UILabel statisticValue;

	public GameObject statisticBox;

	public UISprite statisticBoxBorder;

	public UILabel statisticBoxLabel;

	public UILabel statisticBoxMaxLabel;

	private Vector3 mNumberScale = new Vector3(75f, 75f, 1f);

	private Vector3 mNumberBigScale = new Vector3(105f, 105f, 1f);

	public void InitializeAbilityIcon(string iconName)
	{
		for (int i = 0; i < statisticIcons.Length; i++)
		{
			statisticIcons[i].gameObject.SetActive(i == 0);
		}
		UISprite uISprite = statisticIcons[0];
		uISprite.spriteName = iconName;
		uISprite.MakePixelPerfect();
	}

	public void InitializeEliteIcon(LevelBehaviour unit)
	{
		bool isUnlocked = unit.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 0; i < statisticIcons.Length; i++)
		{
			statisticIcons[i].gameObject.SetActive(isUnlocked);
		}
		unit.SetUpEliteIcon(statisticIcons[0], statisticIcons[1]);
	}

	public void Initialize(Tuple<string, float[]> statistic, bool isBought, bool isDelivering, bool isDamage = false)
	{
		float num = ((!isDamage) ? statistic.Value2[0] : LevelManager.instance.DamageFunction(statistic.Value2[0]));
		float num2 = ((!isDamage) ? statistic.Value2[1] : LevelManager.instance.DamageFunction(statistic.Value2[1]));
		float num3 = ((!isDamage) ? statistic.Value2[2] : LevelManager.instance.DamageFunction(statistic.Value2[2]));
		float num4 = num3 - num;
		bool flag = num4 > 0f;
		bool flag2 = num == num2;
		SetStatText(MiscTools.FormatFloatNumber(num));
		statisticBox.SetActive(isBought);
		if (isBought)
		{
			if (flag2)
			{
				SetMax(Colours.blue);
			}
			else
			{
				SetIncrease((!flag) ? string.Empty : $"+{MiscTools.FormatFloatNumber(num4)}");
			}
			if (isDelivering && flag)
			{
				StartDeliveryAnimation();
			}
			else
			{
				StopDeliveryAnimation();
			}
		}
	}

	public void InitializeSpecial(Tuple<string, float[]> statistic, bool isBought, bool isDelivering)
	{
		float num = statistic.Value2[0];
		float num2 = statistic.Value2[1];
		float num3 = statistic.Value2[2];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 0f) : (num4 < 0f));
		bool flag3 = num == num2;
		if (statistic.Value1 == "percent")
		{
			SetStatText(MiscTools.FormatFloatNumberAsPercent(num));
		}
		else if (statistic.Value1 == "seconds")
		{
			SetStatText(MiscTools.FormatNumberAsSeconds(num));
		}
		else if (statistic.Value1 == "damage")
		{
			SetStatText(MiscTools.FormatFloatNumberRoundZeroOrOne(num));
		}
		statisticBox.SetActive(isBought);
		if (!isBought)
		{
			return;
		}
		if (flag3)
		{
			SetMax(Colours.yellow);
		}
		else if (flag2)
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
		}
		else
		{
			SetIncrease(string.Empty);
		}
		if (isDelivering && flag2)
		{
			StartDeliveryAnimation();
		}
		else
		{
			StopDeliveryAnimation();
		}
	}

	public void InitializeElite(Tuple<string, float[]> statistic, bool isBought)
	{
		float num = statistic.Value2[0];
		float num2 = statistic.Value2[1];
		float num3 = statistic.Value2[2];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 0f) : (num4 < 0f));
		bool flag3 = num == num2;
		SetStatText(MiscTools.FormatFloatNumberAsPercent(num));
		statisticBox.SetActive(isBought);
		if (isBought)
		{
			if (flag3)
			{
				SetMax(Colours.greenArena);
			}
			else if (flag2)
			{
				SetIncrease(MiscTools.FormatFloatNumberAsPercentSigned(num4));
			}
			else
			{
				SetIncrease(string.Empty);
			}
		}
	}

	private void StartDeliveryAnimation()
	{
		statisticBoxLabel.color = Colours.greenDelivering;
		statisticBoxBorder.gameObject.SetActive(value: true);
		statisticBoxBorder.color = Color.white;
		float num = 0.5f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(statisticBoxBorder.gameObject, 2f * num, 1f, 0f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(statisticBoxBorder.gameObject, 2f * num, new Vector3(88f, 74f, 1f), new Vector3(176f, 148f, 1f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	private void StopDeliveryAnimation()
	{
		statisticBoxLabel.color = Colours.gray;
		TweenAlpha component = statisticBoxBorder.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		statisticBoxBorder.alpha = 1f;
		TweenScale component2 = statisticBoxBorder.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		statisticBoxBorder.transform.localScale = new Vector3(88f, 74f, 1f);
	}

	public void AnimateStat()
	{
		TweenScale tweenScale = TweenScale.Begin(statisticValue.gameObject, GuiScreenSingle<WeaponScreen>.instance.upgradeDur * 4f, mNumberScale, mNumberBigScale);
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void SetStatText(string statText)
	{
		TweenScale component = statisticValue.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		statisticValue.transform.localScale = new Vector3(52f, 52f, 1f);
		statisticValue.transform.localPosition = statisticValue.transform.localPosition.ReplaceY(-4f);
		statisticValue.text = statText;
		MiscTools.SetUILabelRescale(statisticValue, 52f, 20f, 155);
		mNumberScale = statisticValue.transform.localScale;
		mNumberBigScale = mNumberScale.MultiplyXY(1.4f);
	}

	private void SetIncrease(string textValue)
	{
		statisticBoxBorder.gameObject.SetActive(value: false);
		statisticBoxLabel.gameObject.SetActive(value: true);
		statisticBoxLabel.text = textValue;
		statisticBoxMaxLabel.gameObject.SetActive(value: false);
	}

	private void SetMax(Color colour)
	{
		statisticBoxBorder.gameObject.SetActive(value: true);
		statisticBoxBorder.color = Colours.grayMax;
		statisticBoxLabel.gameObject.SetActive(value: false);
		statisticBoxMaxLabel.gameObject.SetActive(value: true);
		statisticBoxMaxLabel.color = colour;
	}
}
