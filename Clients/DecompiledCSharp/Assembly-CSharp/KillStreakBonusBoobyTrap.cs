using Google2u;
using UnityEngine;

public class KillStreakBonusBoobyTrap : KillStreakBonus
{
	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		player.cardIconIndicator.Show("game-card-ico-boobytrap", 3f, 3f, animated: false);
		DestroyableObject.DamageInfo info = new DestroyableObject.DamageInfo
		{
			damageAmount = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BoobyTrapDamage).FLOATVALUE * player.destroyableParts.maxHealth,
			isNetwork = false,
			type = DestroyableObject.DamageType.Explosion,
			owner = PlayerController.GetEnemyOf(player.fraction)
		};
		player.destroyableParts.DoDamage(info);
		return true;
	}
}
