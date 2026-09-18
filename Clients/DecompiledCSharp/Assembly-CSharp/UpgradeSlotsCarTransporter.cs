using Google2u;

public class UpgradeSlotsCarTransporter : UpgradeSlotsVehicle<DBUpgradeSlotsTransporter>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)def;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(rowIndex, "repairBotHP");
	}
}
