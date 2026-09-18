using UnityEngine;

public class KillStreakBonusAddHealth : KillStreakBonus
{
	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		base.ActivateBonus(killStreakBonusBox, player);
		player.destroyableParts.Heal(player.destroyableParts.maxHealth * 0.1f, isNetworkCopy: false);
		player.destroyableParts.Sync();
		return true;
	}
}
