using Google2u;
using UnityEngine;

public class UpgradeSlotsBuddy : UpgradeSlotsBaseSoldier<DBUpgradeSlotsBuddy>
{
	protected override void Awake()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 0.5f,
			TOTALPOWER = 0
		};
	}

	public int LoadDataBuddy(LevelBehaviour behaviour, int? boughtIndex = null, bool forCard = false)
	{
		SoldierBehaviour soldierBehaviour = behaviour as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.Copy();
			soldierBehaviourDefinititonBuddy.LoadZeros();
			int num = ((!boughtIndex.HasValue) ? upgradeSlot.boughtIndex : boughtIndex.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "HP");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "realShotProbability");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "batchSizeMin");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "batchSizeMax");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ShotFrequencyMin");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ShotFrequencyMax");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "damage");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "ExplodeDamageMax");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "ExplodeDamageMin");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void LoadDataForBuddyCard(LevelBehaviour behaviour, float progress, LevelBehaviour.UnitType type, WeaponCategory category)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(type, "_MIN_", category));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(type, "_MAX_", category));
		if (rowIndex < 0 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("buddy card excel doesnt contain {0}", string.Concat(type, "_MIN_", category)));
		}
		LoadDataBuddy(behaviour, rowIndex, forCard: true);
		BehaviourDefinititon behaviourDefinition = behaviour.behaviourDefinition;
		LoadDataBuddy(behaviour, rowIndex2, forCard: true);
		BehaviourDefinititon behaviourDefinition2 = behaviour.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.Interpolate(behaviourDefinition, behaviourDefinition2, progress);
		behaviour.behaviourDefinition = behaviourDefinition3;
	}
}
