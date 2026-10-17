using System.Collections;
using Google2u;

public class UpgradeSlotsVehicle<T> : UpgradeSlotsMechanical<T> where T : Google2uComponentBase
{
	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		LevelBehaviour beh = LevelManager.instance.behaviours[0];
		if (bought)
		{
            yield return BattleResourceLoadScope.StartNested(
                this,
                beh.PrepareVisualsForCardCoroutine(mine: true, opponent: false));
		}
		yield return BattleResourceLoadScope.StartNested(this, base.LoadMineVisualsCoroutine(unitUpgrades, bought));
	}

	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		LevelBehaviour beh = LevelManager.instance.behaviours[0];
		if (bought)
		{
            yield return BattleResourceLoadScope.StartNested(
                this,
                beh.PrepareVisualsForCardCoroutine(mine: false, opponent: true));
		}
		yield return BattleResourceLoadScope.StartNested(this, base.LoadOponentVisualsCoroutine(unitUpgrades, bought));
	}
}
