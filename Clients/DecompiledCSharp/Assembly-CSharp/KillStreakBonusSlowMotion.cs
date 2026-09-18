using UnityEngine;

public class KillStreakBonusSlowMotion : KillStreakBonus
{
	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		if (base.ActivateBonus(killStreakBonusBox, player))
		{
			Singleton<SlowMotionManager>.instance.SlowMotionFor(4f);
			return true;
		}
		return false;
	}
}
