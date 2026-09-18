using System.Collections.Generic;
using UnityEngine;

public class ArmyLeftContent : Core_BaseScript
{
	[Header("Header")]
	public UITable headerTable;

	[Header("-Line 1")]
	public UITable screenTable;

	[Header("-Line 2")]
	public UILabel unitName;

	[Header("-Line 3")]
	public UITable levelTable;

	public List<UISprite> armyTierStars;

	public UILabel unitLevel;

	[Header("Statistics And Ability Hint")]
	public UIGrid progressBarGrid;

	public List<ArmyStatProgressBar> progressBarsLeft;

	public ArmyLeftHint abilityHint;

	public ArmyLeftHint eliteHint;

	[Header("Button")]
	public ArmyLeftButton leftButton;

	private LevelBehaviour mUnit;

	public void InitControls()
	{
		leftButton.InitControls();
		abilityHint.InitControls();
		eliteHint.InitControls();
		screenTable.onReposition = OnReposited;
		levelTable.onReposition = OnReposited;
	}

	public void InitGUIValues()
	{
		leftButton.InitGUIValues();
		abilityHint.InitGUIValues();
		eliteHint.InitGUIValues();
		RepositionLeft();
	}

	public void DoAfterHide()
	{
		leftButton.DoAfterHide();
		abilityHint.DoAfterHide();
		eliteHint.DoAfterHide();
	}

	public void SelectUnit(LevelBehaviour selectedUnit)
	{
		mUnit = selectedUnit;
		UpdateUnitName();
		levelTable.repositionNow = true;
		leftButton.SelectUnit(selectedUnit);
	}

	public void UpdateUnitName()
	{
		bool flag = mUnit.upgradeSlots.upgradeSlotElite.isUnlocked && mUnit.upgradeSlots.upgradeSlotElite.isBought;
		unitName.text = ((!flag) ? mUnit.unitName.ToUpper() : Localization.LocalizeFormat("ID_ELITEUNITNAME", mUnit.unitName.ToUpper()));
		unitName.color = ((!flag) ? Colours.blue : Colours.greenArena);
		screenTable.repositionNow = true;
	}

	private void OnReposited()
	{
		headerTable.repositionNow = true;
	}

	public void UpdateLeftContent(bool changedUnit = true)
	{
		UpdateUnitName();
		LeftTopUnitInfo(mUnit.upgradeSlots.actualUnitLevel, mUnit.upgradeSlots.actualMaxUnitLevel, mUnit.upgradeSlots.actualTier);
		if (changedUnit)
		{
			FillHints();
			RepositionLeft();
		}
		leftButton.UpdateLeftContent(changedUnit);
	}

	private void LeftTopUnitInfo(int level, int maxLevel, int tier)
	{
		unitLevel.text = $"{level}{Colours.stringGray} / {maxLevel}";
		for (int i = 0; i < armyTierStars.Count; i++)
		{
			armyTierStars[i].gameObject.SetActive(i < tier);
		}
		levelTable.repositionNow = true;
	}

	public void SetSaleAndPrize()
	{
		leftButton.powerDialog.SetSaleAndPrize();
		leftButton.abilityDialog.SetAbilitySaleAndPrize();
		leftButton.buffDialog.SetEliteSaleAndPrize();
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		leftButton.UpdateDeliveringTime(remainingTime, progress);
	}

	public void UpdateProgresses()
	{
		progressBarsLeft[0].InitializeStat(mUnit, isDamage: true);
		progressBarsLeft[1].InitializeStat(mUnit, isDamage: false);
		progressBarsLeft[2].InitializeSpecial(mUnit);
		if (mUnit.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			progressBarsLeft[3].InitializeElite(mUnit);
		}
		FillHints();
	}

	private void FillHints()
	{
		abilityHint.Initialize(mUnit);
		if (mUnit.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			eliteHint.Initialize(mUnit);
		}
	}

	private void RepositionLeft()
	{
		bool isUnlocked = mUnit.upgradeSlots.upgradeSlotElite.isUnlocked;
		progressBarGrid.transform.localPosition = progressBarGrid.transform.localPosition.ReplaceY((!isUnlocked) ? 756f : 856f);
		progressBarsLeft[3].gameObject.SetActive(isUnlocked);
		abilityHint.transform.localPosition = abilityHint.transform.localPosition.ReplaceY((!isUnlocked) ? 560f : 660f);
		eliteHint.gameObject.SetActive(isUnlocked);
	}
}
