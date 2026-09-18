using System.Collections;
using Google2u;

public class UpgradeSlotsVehicle<T> : UpgradeSlotsMechanical<T> where T : Google2uComponentBase
{
	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		LevelBehaviour beh = LevelManager.instance.behaviours[0];
		if (bought)
		{
			yield return StartCoroutine(beh.PrepareVisualsForCardCoroutine(mine: true, opponent: false));
		}
		yield return StartCoroutine(base.LoadMineVisualsCoroutine(unitUpgrades, bought));
	}

	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		LevelBehaviour beh = LevelManager.instance.behaviours[0];
		if (bought)
		{
			yield return StartCoroutine(beh.PrepareVisualsForCardCoroutine(mine: false, opponent: true));
		}
		yield return StartCoroutine(base.LoadOponentVisualsCoroutine(unitUpgrades, bought));
	}
}
