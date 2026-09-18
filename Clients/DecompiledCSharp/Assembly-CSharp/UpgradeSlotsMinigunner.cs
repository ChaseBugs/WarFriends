using Google2u;

public class UpgradeSlotsMinigunner : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)def;
		base.LoadDefinitionFromXLS((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, rowIndex);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(rowIndex, "ShieldRechargeRate");
	}
}
