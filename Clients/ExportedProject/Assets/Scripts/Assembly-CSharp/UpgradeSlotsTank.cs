using System.Collections.Generic;
using Google2u;

public class UpgradeSlotsTank : UpgradeSlotsVehicle<DBUpgradeSlotsTank>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "CannonDamage");
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			float val = (float)base.excel.GetValue(rowIndex, "damage");
			list.Add(new Tuple<string, float>("ID_SECONDWEAPONDAMAGE", val));
			return list;
		}
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)def;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMaxCannon");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMinCannon");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(rowIndex, "CannonDamage");
	}
}
