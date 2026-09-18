using Google2u;

public class UpgradeSlotsSciFi : UpgradeSlotsBaseSoldier<DBUpgradeSlotsSciFi>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		}
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)def;
		base.LoadDefinitionFromXLS((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, rowIndex);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(rowIndex, "GrenadeMinDamage");
	}
}
