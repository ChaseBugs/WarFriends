using UnityEngine;

[RequireComponent(typeof(DestroyableObjectMultipleParts))]
public class Turret : TurretBase<TurretBehaviour, TurretBehaviourDefinititon>
{
	public GameObject slotsTurret;

	public void LoadUpgrades(int upgrades, float scaleDamage, float scaleHP)
	{
		unitUpgrades = new UpgradeSlots.UnitUpgrades(1f)
		{
			slotUpgradeindex = upgrades,
			scaleHp = scaleHP,
			scaleDamage = scaleDamage
		};
		behaviour.upgradeSlots.LoadData(behaviour, unitUpgrades, perk);
		behaviour.behaviourDefinition.ScaleDamageAndHP(unitUpgrades.scaleDamage, unitUpgrades.scaleHp);
		SyncUpgrades();
		UpgradesLoaded();
	}
}
