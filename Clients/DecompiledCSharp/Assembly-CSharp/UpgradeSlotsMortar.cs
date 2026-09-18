using System.Collections.Generic;
using Google2u;

public class UpgradeSlotsMortar : UpgradeSlotsBaseSoldier<DBUpgradeSlotsGrennader>
{
	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			list.Add(new Tuple<string, float>("ID_MORTARBUILDTIME", (float)base.excel.GetValue(rowIndex, "mortarBuildTime")));
			return list;
		}
	}

	public override bool isSpecificTime => true;

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)def;
		base.LoadDefinitionFromXLS((BehaviourDefinititon)soldierBehaviourDefinititonMortar, rowIndex);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(rowIndex, "mortarBuildTime");
	}
}
