using UnityEngine;

public class HexPackRecord : Core_BaseScript
{
	[Header("Background")]
	public UISprite baseBackground;

	public UISprite leftBackground;

	public UISprite rightBackground;

	[Header("Icon Part")]
	public UISprite icon;

	public GameObject weaponPart;

	public UILabel weaponType;

	public GameObject unitPart;

	public UISprite unitType;

	public GameObject unitTiersPart;

	public UISprite[] unitStars;

	public GameObject vipPart;

	public GameObject goldPart;

	[Header("Special Labels")]
	public GameObject earlyUnlockPart;

	public UISprite earlyUnlockBackground;

	public UILabel earlyUnlockLabel;

	public UILabel earlyUnlockLevel;

	public GameObject packExclusivePart;

	public UISprite packExclusiveBackground;

	public UILabel packExclusiveLabel;

	public GameObject freePart;

	[Header("Bottom")]
	public UILabel nameLabel;

	public UILabel descriptionLabel;

	public void InitializeSize(float width, float height)
	{
		float num = width / 2f;
		baseBackground.transform.localScale = baseBackground.transform.localScale.ReplaceXY(width, height);
		leftBackground.transform.localScale = leftBackground.transform.localScale.ReplaceX(num);
		rightBackground.transform.localScale = rightBackground.transform.localScale.ReplaceX(num);
		weaponType.transform.localPosition = weaponType.transform.localPosition.ReplaceX(num - 80f);
		unitType.transform.localPosition = unitType.transform.localPosition.ReplaceX(num - 85f);
		unitTiersPart.transform.localPosition = unitTiersPart.transform.localPosition.ReplaceX(65f - num);
		earlyUnlockBackground.transform.localScale = earlyUnlockBackground.transform.localScale.ReplaceX(width - 90f);
		earlyUnlockLabel.text = Localization.Localize("ID_EARLYUNLOCK");
		MiscTools.SetUILabelRescale(earlyUnlockLabel, 30f, 20f, (int)width - 210);
		earlyUnlockLevel.transform.localPosition = earlyUnlockLevel.transform.localPosition.ReplaceY(earlyUnlockLabel.transform.localPosition.y);
		earlyUnlockLevel.transform.localScale = earlyUnlockLabel.transform.localScale;
		packExclusiveBackground.transform.localScale = packExclusiveBackground.transform.localScale.ReplaceX(width - 90f);
		packExclusiveLabel.text = Localization.Localize("ID_PACKEXCLUSIVE");
		MiscTools.SetUILabelRescale(packExclusiveLabel, 30f, 20f, (int)width - 140);
		nameLabel.lineWidth = (int)width - 40;
		descriptionLabel.lineWidth = (int)width - 40;
	}

	public void InitializeUnit(LevelBehaviour unit)
	{
		icon.gameObject.SetActive(value: true);
		weaponPart.gameObject.SetActive(value: false);
		unitPart.gameObject.SetActive(value: true);
		vipPart.gameObject.SetActive(value: false);
		goldPart.gameObject.SetActive(value: false);
		icon.spriteName = unit.upgradeSlots.iconName;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(1.5f);
		icon.transform.localPosition = icon.transform.localPosition.ReplaceY(0f);
		unitType.spriteName = unit.unitTypeIcon;
		for (int i = 0; i < unitStars.Length; i++)
		{
			unitStars[i].gameObject.SetActive(i < unit.upgradeSlots.actualTier);
		}
		bool flag = unit.upgradeSlots.unlockLevel.displayNumber > LevelManager.instance.currentLevel.displayNumber;
		earlyUnlockPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = unit.upgradeSlots.unlockLevel.displayString;
		}
		packExclusivePart.SetActive(value: false);
		freePart.SetActive(value: false);
		nameLabel.transform.localPosition = nameLabel.transform.localPosition.ReplaceY(-162f);
		nameLabel.text = unit.unitName.ToUpper();
		bool flag2 = nameLabel.relativeSize.y > 1f;
		descriptionLabel.transform.localPosition = descriptionLabel.transform.localPosition.ReplaceY((!flag2) ? (-302f) : (-325f));
		descriptionLabel.text = Localization.LocalizeFormat("ID_ELITEPACK_UNITDESCRIPTION", MiscTools.FormatBigNumber(unit.upgradeSlots.armyPowerX10), MiscTools.FormatBigNumber(unit.upgradeSlots.armyPowerX10Max));
	}

	public void InitializeWeapon(WeaponLevelsSetup weapon)
	{
		icon.gameObject.SetActive(value: true);
		weaponPart.gameObject.SetActive(value: true);
		unitPart.gameObject.SetActive(value: false);
		vipPart.gameObject.SetActive(value: false);
		goldPart.gameObject.SetActive(value: false);
		icon.spriteName = weapon.playerWeapon.iconName;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(1.5294118f);
		icon.transform.localPosition = icon.transform.localPosition.ReplaceY(36f);
		string weaponCategoryId = Singleton<GameVariables>.instance.GetWeaponCategoryId(weapon.weaponCategory, StringCase.UpperCase);
		weaponType.text = Localization.Localize(weaponCategoryId);
		bool flag = weapon.unlockLevel.displayNumber > LevelManager.instance.currentLevel.displayNumber;
		earlyUnlockPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = weapon.unlockLevel.displayString;
		}
		packExclusivePart.SetActive(value: true);
		freePart.SetActive(value: false);
		nameLabel.text = weapon.weaponName.ToUpper();
		bool flag2 = nameLabel.relativeSize.y > 1f;
		descriptionLabel.transform.localPosition = descriptionLabel.transform.localPosition.ReplaceY((!flag2) ? (-302f) : (-325f));
		descriptionLabel.text = Localization.LocalizeFormat("ID_ELITEPACK_WEAPONDESCRIPTION", MiscTools.FormatBigNumber(weapon.weaponPowerX10), MiscTools.FormatBigNumber(weapon.weaponPowerX10Max));
	}

	public void InitializeVip(int seconds)
	{
		icon.gameObject.SetActive(value: false);
		weaponPart.gameObject.SetActive(value: false);
		unitPart.gameObject.SetActive(value: false);
		vipPart.gameObject.SetActive(value: true);
		goldPart.gameObject.SetActive(value: false);
		earlyUnlockPart.SetActive(value: false);
		packExclusivePart.SetActive(value: false);
		freePart.SetActive(value: true);
		nameLabel.transform.localPosition = nameLabel.transform.localPosition.ReplaceY(-162f);
		nameLabel.text = Localization.Localize("ID_VIPBENEFIT");
		descriptionLabel.transform.localPosition = descriptionLabel.transform.localPosition.ReplaceY(-302f);
		descriptionLabel.text = Localization.LocalizeFormat("ID_ELITEPACK_VIPDESCRIPTION", MiscTools.PrintableTimeVipConvert(seconds).ToLower());
	}

	public void InitializeGold(int amount)
	{
		icon.gameObject.SetActive(value: false);
		weaponPart.gameObject.SetActive(value: false);
		unitPart.gameObject.SetActive(value: false);
		vipPart.gameObject.SetActive(value: false);
		goldPart.gameObject.SetActive(value: true);
		earlyUnlockPart.SetActive(value: false);
		packExclusivePart.SetActive(value: false);
		freePart.SetActive(value: true);
		nameLabel.transform.localPosition = nameLabel.transform.localPosition.ReplaceY(-162f);
		nameLabel.text = string.Format("{0} {1}", MiscTools.FormatBigNumber(amount), Localization.Localize("ID_GOLD"));
		descriptionLabel.transform.localPosition = descriptionLabel.transform.localPosition.ReplaceY(-302f);
		descriptionLabel.text = Localization.Localize("ID_ELITEPACK_GOLDDESCRIPTION");
	}

	public void StopAnimation()
	{
		TweenAlpha component = baseBackground.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = leftBackground.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = rightBackground.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		baseBackground.alpha = GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha;
		leftBackground.alpha = GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha;
		rightBackground.alpha = GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha;
	}

	public void StartAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(baseBackground.gameObject, GuiElementSingle<PackContentDialog>.instance.duration, GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha, GuiElementSingle<PackContentDialog>.instance.highBlackAlpha);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(leftBackground.gameObject, GuiElementSingle<PackContentDialog>.instance.duration, GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha, GuiElementSingle<PackContentDialog>.instance.highBlackAlpha);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(rightBackground.gameObject, GuiElementSingle<PackContentDialog>.instance.duration, GuiElementSingle<PackContentDialog>.instance.lowBlackAlpha, GuiElementSingle<PackContentDialog>.instance.highBlackAlpha);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
	}
}
