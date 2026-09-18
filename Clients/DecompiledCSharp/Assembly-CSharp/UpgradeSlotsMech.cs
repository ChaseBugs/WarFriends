using Google2u;

public class UpgradeSlotsMech : UpgradeSlotsMechanical<DBUpgradeSlotsMech>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
}
