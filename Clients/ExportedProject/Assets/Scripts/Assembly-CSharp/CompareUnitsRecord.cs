using System.Collections.Generic;
using UnityEngine;

public class CompareUnitsRecord : MonoBehaviour
{
	[Header("My Unit")]
	public UISprite myUnit;

	public UISprite myUnitType;

	public UISprite myUnitTypeStripe;

	public UILabel myUnitLevel;

	public List<UISprite> myStars;

	public UILabel myEarlyUnlock;

	public UISprite myUnitEliteIcon;

	public UISprite myUnitEliteIconBuff;

	public UILabel myUnitElitePower;

	public UISprite myUnitEliteBuff;

	public UISprite myUnitEliteDebuff;

	[Header("Middle")]
	public GameObject middlePart;

	public UILabel myUnitPower;

	public UISprite myUnitAbilityIcon;

	public UILabel myUnitSpecialPower;

	public UISprite progressBg;

	public UISprite progress;

	public UILabel opponentUnitPower;

	public UISprite opponentUnitAbilityIcon;

	public UILabel opponentUnitSpecialPower;

	[Header("Opponent Unit")]
	public GameObject opponnentPart;

	public UISprite opponentUnit;

	public UISprite opponentUnitType;

	public UISprite opponentUnitTypeStripe;

	public UILabel opponentUnitLevel;

	public List<UISprite> opponentStars;

	public UILabel opponentEarlyUnlock;

	public UISprite opponentUnitEliteIcon;

	public UISprite opponentUnitEliteIconBuff;

	public UILabel opponentUnitElitePower;

	public UISprite opponentUnitEliteBuff;

	public UISprite opponentUnitEliteDebuff;

	public void Initialize(LevelBehaviour me, UnitUpgradeDefinition myUnitDefinition, LevelBehaviour opponent, UnitUpgradeDefinition opponentUnitDefinition, int myDisplayLevel, int opponentDisplayLevel, float scale)
	{
		InitializeUnit(me, myUnitDefinition, myDisplayLevel, myUnit, myUnitAbilityIcon, myUnitLevel, myUnitPower, myEarlyUnlock, myUnitSpecialPower, myStars, myUnitEliteIcon, myUnitEliteIconBuff, myUnitElitePower, myUnitEliteBuff, myUnitEliteDebuff, PlayerController.currentPlayer.fraction);
		InitializeUnit(opponent, opponentUnitDefinition, opponentDisplayLevel, opponentUnit, opponentUnitAbilityIcon, opponentUnitLevel, opponentUnitPower, opponentEarlyUnlock, opponentUnitSpecialPower, opponentStars, opponentUnitEliteIcon, opponentUnitEliteIconBuff, opponentUnitElitePower, opponentUnitEliteBuff, opponentUnitEliteDebuff, Singleton<GameController>.instance.opponent.fraction);
		InitializeColours(me, myUnitDefinition, opponent, opponentUnitDefinition);
		InitializeUnitType(me, opponent);
		float num = 1f / scale;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num2 = activeWidth - 360f * scale - 180f;
		num2 *= num;
		progress.transform.localScale = progress.transform.localScale.ReplaceX(num2);
		progressBg.transform.localScale = progressBg.transform.localScale.ReplaceX(num2);
		opponnentPart.transform.localPosition = opponnentPart.transform.localPosition.ReplaceX(num2 + 180f);
		middlePart.transform.localPosition = middlePart.transform.localPosition.ReplaceX(num2 * 0.5f + 180f);
	}

	private void InitializeUnit(LevelBehaviour unit, UnitUpgradeDefinition unitUpgradesDef, int displayLevel, UISprite unitIcon, UISprite unitAbilityIcon, UILabel unitLevelLabel, UILabel unitPowerLabel, UILabel unitEarlyUnlockLabel, UILabel unitSpecialPowerLabel, List<UISprite> unitStars, UISprite eliteIcon, UISprite eliteIconBuff, UILabel elitePower, UISprite buffs, UISprite debuffs, Fractions fraction)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			SetUnitSprite(unitIcon, unit);
			FillStars(0, unitStars);
			unitLevelLabel.gameObject.SetActive(value: false);
			unitEarlyUnlockLabel.gameObject.SetActive(value: false);
			unitPowerLabel.text = string.Empty;
			unitSpecialPowerLabel.text = string.Empty;
			unitAbilityIcon.gameObject.SetActive(value: false);
			elitePower.text = string.Empty;
			eliteIcon.gameObject.SetActive(value: false);
			eliteIconBuff.gameObject.SetActive(value: false);
			buffs.gameObject.SetActive(value: false);
			debuffs.gameObject.SetActive(value: false);
			return;
		}
		unitLevelLabel.gameObject.SetActive(unit != null);
		unitEarlyUnlockLabel.gameObject.SetActive(unit != null && unit.upgradeSlots.unlockLevel.displayNumber > displayLevel);
		if (unit != null)
		{
			UpgradeSlots.UnitUpgrades unitUpgrades = unitUpgradesDef.unitUpgrades;
			bool isSpecial = unitUpgrades.isSpecial;
			bool isElite = unitUpgrades.isElite;
			int armyPowerX = unit.upgradeSlots.GetArmyPowerX10(unitUpgrades.slotUpgradeindex, unitUpgrades.slotUpgradeIndexSpecial, unitUpgradesDef.tier, unitUpgrades.slotUpgradeIndexElite, isElite);
			int armyPowerX2 = unit.upgradeSlots.upgradeSlotSpecial.GetArmyPowerX10(unitUpgrades.slotUpgradeIndexSpecial, unitUpgradesDef.tier);
			int armyPowerX3 = unit.upgradeSlots.upgradeSlotElite.GetArmyPowerX10(unitUpgrades.slotUpgradeIndexElite, isElite);
			int actualLevelForIndex = unit.upgradeSlots.GetActualLevelForIndex(unitUpgradesDef.unitUpgrades.slotUpgradeindex);
			Perk perk = Singleton<GameController>.instance.mainController.CheckForPerks(unit, fraction);
			int buffCount = perk.GetBuffCount(PerkType.Buff);
			int buffCount2 = perk.GetBuffCount(PerkType.Debuff);
			SetUnitSprite(unitIcon, unit);
			FillStars(unitUpgradesDef.tier, unitStars);
			unitLevelLabel.text = ((actualLevelForIndex <= 0) ? string.Empty : MiscTools.FormatBigNumber(actualLevelForIndex));
			unitPowerLabel.text = MiscTools.FormatBigNumber(armyPowerX);
			unitSpecialPowerLabel.text = ((!isSpecial) ? string.Empty : MiscTools.FormatBigNumber(armyPowerX2));
			unitAbilityIcon.gameObject.SetActive(isSpecial);
			if (isSpecial)
			{
				unitAbilityIcon.spriteName = unit.abilityIcon;
			}
			elitePower.text = ((!isElite) ? string.Empty : MiscTools.FormatBigNumber(armyPowerX3));
			eliteIcon.gameObject.SetActive(isElite);
			eliteIconBuff.gameObject.SetActive(isElite);
			if (isElite)
			{
				unit.SetUpEliteIcon(eliteIcon, eliteIconBuff);
			}
			buffs.gameObject.SetActive(buffCount > 0 || buffCount2 > 0);
			debuffs.gameObject.SetActive(buffCount > 0 && buffCount2 > 0);
			if (buffs.gameObject.activeSelf)
			{
				buffs.spriteName = ((buffCount <= 0) ? ("game-elite-debuff" + buffCount2) : ("game-elite-buff" + buffCount));
				buffs.MakePixelPerfect();
			}
			if (debuffs.gameObject.activeSelf)
			{
				debuffs.spriteName = "game-elite-debuff" + buffCount2;
				debuffs.MakePixelPerfect();
			}
		}
		else
		{
			SetUnitSprite(unitIcon, null);
			FillStars(0, unitStars);
			unitPowerLabel.text = Localization.Localize("ID_NA");
			unitSpecialPowerLabel.text = string.Empty;
			unitAbilityIcon.gameObject.SetActive(value: false);
			elitePower.text = string.Empty;
			eliteIcon.gameObject.SetActive(value: false);
			eliteIconBuff.gameObject.SetActive(value: false);
			buffs.gameObject.SetActive(value: false);
			debuffs.gameObject.SetActive(value: false);
		}
	}

	private void SetUnitSprite(UISprite sprite, LevelBehaviour unit)
	{
		sprite.gameObject.SetActive(value: true);
		if (unit != null)
		{
			sprite.spriteName = unit.upgradeSlots.iconName;
			sprite.MakePixelPerfect();
			Vector3 localScale = sprite.transform.localScale;
			float a = localScale.x / 180f;
			float b = localScale.y / 90f;
			float num = Mathf.Max(a, b);
			sprite.transform.localScale = localScale.MultiplyXY(1f / num);
			sprite.color = Color.white;
			sprite.pivot = ((!unit.isSoldier) ? UIWidget.Pivot.Center : UIWidget.Pivot.Bottom);
			sprite.transform.localPosition = sprite.transform.localPosition.ReplaceY((!unit.isSoldier) ? (-50f) : (-100f));
		}
		else
		{
			sprite.pivot = UIWidget.Pivot.Center;
			sprite.transform.localPosition = sprite.transform.localPosition.ReplaceY(-50f);
			sprite.spriteName = "whiteRectangle";
			sprite.transform.localScale = new Vector3(44f, 8f, 1f);
			sprite.color = Colours.grayLight;
		}
	}

	private void FillStars(int tier, List<UISprite> stars)
	{
		for (int i = 0; i < stars.Count; i++)
		{
			UISprite uISprite = stars[i];
			uISprite.gameObject.SetActive(i < tier);
		}
	}

	private void InitializeColours(LevelBehaviour me, UnitUpgradeDefinition myUnitDefinition, LevelBehaviour opponent, UnitUpgradeDefinition opponentUnitDefinition)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			progress.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			progress.invert = me == null;
			progress.fillAmount = ((!(me == null) && !(opponent == null)) ? 1f : 0f);
			return;
		}
		progress.invert = false;
		if (me == null)
		{
			progress.fillAmount = 0f;
			progress.color = Colours.redWeaponStats.ReplaceA(0.3f);
			myUnitPower.color = Colours.grayLight;
			opponentUnitPower.color = Colours.greenWeaponStats;
			return;
		}
		if (opponent == null)
		{
			progress.fillAmount = 1f;
			progress.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			myUnitPower.color = Colours.greenWeaponStats;
			opponentUnitPower.color = Colours.grayLight;
			return;
		}
		int armyPowerX = me.upgradeSlots.GetArmyPowerX10(myUnitDefinition.unitUpgrades.slotUpgradeindex, myUnitDefinition.unitUpgrades.slotUpgradeIndexSpecial, myUnitDefinition.tier, myUnitDefinition.unitUpgrades.slotUpgradeIndexElite, myUnitDefinition.unitUpgrades.isElite);
		int armyPowerX2 = opponent.upgradeSlots.GetArmyPowerX10(opponentUnitDefinition.unitUpgrades.slotUpgradeindex, opponentUnitDefinition.unitUpgrades.slotUpgradeIndexSpecial, opponentUnitDefinition.tier, opponentUnitDefinition.unitUpgrades.slotUpgradeIndexElite, opponentUnitDefinition.unitUpgrades.isElite);
		progress.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			progress.color = Color.white.ReplaceA(0.2f);
			myUnitPower.color = Color.white;
			opponentUnitPower.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			progress.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			myUnitPower.color = Colours.greenWeaponStats;
			opponentUnitPower.color = Colours.redWeaponStats;
		}
		else
		{
			progress.color = Colours.redWeaponStats.ReplaceA(0.3f);
			myUnitPower.color = Colours.redWeaponStats;
			opponentUnitPower.color = Colours.greenWeaponStats;
		}
	}

	private void InitializeUnitType(LevelBehaviour me, LevelBehaviour opponent)
	{
		LevelBehaviour.UnitType key = ((!(me != null)) ? opponent.unitType : me.unitType);
		myUnitType.spriteName = GameVariables.unitCategory[key].Value1;
		opponentUnitType.spriteName = GameVariables.unitCategory[key].Value1;
		myUnitTypeStripe.color = GameVariables.unitCategory[key].Value2;
		opponentUnitTypeStripe.color = GameVariables.unitCategory[key].Value2;
	}
}
