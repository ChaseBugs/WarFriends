using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsBaseSoldier<T> : UpgradeSlotsGeneric<T> where T : Google2uComponentBase
{
	[Header("Visuals")]
	public List<TechnologyVisualDefinition> visualsBody;

	public List<TechnologyVisualDefinition> visualsHelmet;

	public List<TechnologyVisualDefinition> visualsWeapon;

	[Header("Elite Visuals")]
	public List<TechnologyVisualDefinition> eliteVisualsBody;

	public List<TechnologyVisualDefinition> eliteVisualsHelmet;

	public List<TechnologyVisualDefinition> eliteVisualsWeapon;

	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "damage");
		}
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)def;
		soldierBehaviourDefinititon.health = (float)soldierBehaviourDefinititon.health + (float)base.excel.GetValue(rowIndex, "HP");
		soldierBehaviourDefinititon.probabilityOfRealShot += (float)base.excel.GetValue(rowIndex, "realShotProbability");
		soldierBehaviourDefinititon.fireBatchSizeMin += (int)base.excel.GetValue(rowIndex, "batchSizeMin");
		soldierBehaviourDefinititon.fireBatchSizeMax += (int)base.excel.GetValue(rowIndex, "batchSizeMax");
		soldierBehaviourDefinititon.minShootTime += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMin");
		soldierBehaviourDefinititon.maxShootTime += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMax");
		soldierBehaviourDefinititon.walkShotTimeMin += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMin");
		soldierBehaviourDefinititon.walkShotTimeMax += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMax");
		soldierBehaviourDefinititon.damage = (float)soldierBehaviourDefinititon.damage + (float)base.excel.GetValue(rowIndex, "damage");
		if (base.excel.HasColumn("special"))
		{
			soldierBehaviourDefinititon.special += (float)base.excel.GetValue(rowIndex, "special");
		}
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "DPS", "ID_ATTACK"));
		list.Add(StatsFor(slot, "HP", "ID_HEALTH"));
		return list;
	}

	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		if (unitUpgrades.isElite)
		{
			yield return StartCoroutine(LoadMineVisualAsync(unitUpgrades.slotUpgradeindex, bought, eliteVisualsBody));
			yield return StartCoroutine(LoadMineVisualAsync(unitUpgrades.slotUpgradeindex, bought, eliteVisualsHelmet));
		}
		else
		{
			yield return StartCoroutine(LoadMineVisualAsync(unitUpgrades.slotUpgradeindex, bought, visualsBody));
			yield return StartCoroutine(LoadMineVisualAsync(unitUpgrades.slotUpgradeindex, bought, visualsHelmet));
		}
	}

	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		if (unitUpgrades.isElite)
		{
			yield return StartCoroutine(LoadOpponentVisualAsync(unitUpgrades.slotUpgradeindex, bought, eliteVisualsBody));
			yield return StartCoroutine(LoadOpponentVisualAsync(unitUpgrades.slotUpgradeindex, bought, eliteVisualsHelmet));
		}
		else
		{
			yield return StartCoroutine(LoadOpponentVisualAsync(unitUpgrades.slotUpgradeindex, bought, visualsBody));
			yield return StartCoroutine(LoadOpponentVisualAsync(unitUpgrades.slotUpgradeindex, bought, visualsHelmet));
		}
	}

	public override void NullOpponentVisuals()
	{
		foreach (TechnologyVisualDefinition item in visualsBody)
		{
			item.NullOpponent();
		}
		foreach (TechnologyVisualDefinition item2 in eliteVisualsBody)
		{
			item2.NullOpponent();
		}
		foreach (TechnologyVisualDefinition item3 in visualsHelmet)
		{
			item3.NullOpponent();
		}
		foreach (TechnologyVisualDefinition item4 in eliteVisualsHelmet)
		{
			item4.NullOpponent();
		}
	}

	public override void NullMineVisuals()
	{
		foreach (TechnologyVisualDefinition item in visualsBody)
		{
			item.NullMine();
		}
		foreach (TechnologyVisualDefinition item2 in eliteVisualsBody)
		{
			item2.NullMine();
		}
		foreach (TechnologyVisualDefinition item3 in visualsHelmet)
		{
			item3.NullMine();
		}
		foreach (TechnologyVisualDefinition item4 in eliteVisualsHelmet)
		{
			item4.NullMine();
		}
	}

	public override void UnloadVisuals()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in visualsBody)
		{
			item.UnloadAll();
		}
		foreach (TechnologyVisualDefinition item2 in eliteVisualsBody)
		{
			item2.UnloadAll();
		}
		foreach (TechnologyVisualDefinition item3 in visualsHelmet)
		{
			item3.UnloadAll();
		}
		foreach (TechnologyVisualDefinition item4 in eliteVisualsHelmet)
		{
			item4.UnloadAll();
		}
	}

	public override List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (unitUpgrades.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, eliteVisualsBody));
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, eliteVisualsHelmet));
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, eliteVisualsWeapon));
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, visualsBody));
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, visualsHelmet));
			list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, visualsWeapon));
		}
		return list;
	}
}
