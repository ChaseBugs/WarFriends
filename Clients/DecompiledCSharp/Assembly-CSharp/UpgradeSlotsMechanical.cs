using System.Collections.Generic;
using Google2u;

public class UpgradeSlotsMechanical<T> : UpgradeSlotsGeneric<T> where T : Google2uComponentBase
{
	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)def;
		vehicleBehaviourDefinititon.health = (float)vehicleBehaviourDefinititon.health + (float)base.excel.GetValue(rowIndex, "HP");
		vehicleBehaviourDefinititon.probabilityOfRealShot += (float)base.excel.GetValue(rowIndex, "realShotProbability");
		vehicleBehaviourDefinititon.fireBatchSizeMin += (int)base.excel.GetValue(rowIndex, "batchSizeMin");
		vehicleBehaviourDefinititon.fireBatchSizeMax += (int)base.excel.GetValue(rowIndex, "batchSizeMax");
		vehicleBehaviourDefinititon.minShootTime += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMin");
		vehicleBehaviourDefinititon.maxShootTime += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMax");
		vehicleBehaviourDefinititon.damage = (float)vehicleBehaviourDefinititon.damage + (float)base.excel.GetValue(rowIndex, "damage");
		if (base.excel.HasColumn("special"))
		{
			vehicleBehaviourDefinititon.special += (float)base.excel.GetValue(rowIndex, "special");
		}
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "DPS", "ID_ATTACK"));
		list.Add(StatsFor(slot, "HP", "ID_HEALTH"));
		return list;
	}
}
