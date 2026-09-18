using System.Collections;
using System.Collections.Generic;

public class UpgradesManager : Singleton<UpgradesManager>
{
	public IEnumerator LoadMineUpgrades(List<UnitUpgradeDefinition> upgrades)
	{
		for (int index = 0; index < LevelManager.instance.behaviours.Count; index++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[index];
			if (!levelBehaviour.upgradeSlots.canUseInBattle)
			{
				levelBehaviour.Clear();
			}
		}
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour2 = LevelManager.instance.behaviours[i];
			UnitUpgradeDefinition unitUpgradeDefinition = upgrades[i];
			yield return StartCoroutine(levelBehaviour2.PrepareVisualsForGameCoroutine(unitUpgradeDefinition.unitUpgrades, unitUpgradeDefinition.isEquipped, mine: true));
		}
	}

	public IEnumerator LoadOpponentUpgradesForGame(List<UnitUpgradeDefinition> upgrades)
	{
		for (int index = 0; index < LevelManager.instance.behaviours.Count; index++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[index];
			UnitUpgradeDefinition unitUpgradeDefinition = upgrades[index];
			bool bought = upgrades[index].isEquipped;
			if (Singleton<GameController>.instance.isTutorial && (levelBehaviour is SoldierBehaviourBazooka || levelBehaviour is SoldierBehaviourGrennader || levelBehaviour is SoldierBehaviourSniper || levelBehaviour is SoldierBehaviourParachuter || levelBehaviour is SoldierBehaviourAssaulter || levelBehaviour is SoldierBehaviourShotgunner))
			{
				bought = true;
			}
			yield return StartCoroutine(levelBehaviour.PrepareVisualsForGameCoroutine(unitUpgradeDefinition.unitUpgrades, bought, mine: false));
		}
	}

	public void UnloadAll()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}
}
