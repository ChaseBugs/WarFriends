using UnityEngine;

public class KillStreakBonusKevlar : KillStreakBonus
{
	public DestroyableObject destroyableObject;

	private DestroyableObjectMultipleParts mPlayerDestroyableParts;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		if (base.ActivateBonus(killStreakBonusBox, player))
		{
			player.SetUpKevlar(0.1f);
		}
		return false;
	}
}
