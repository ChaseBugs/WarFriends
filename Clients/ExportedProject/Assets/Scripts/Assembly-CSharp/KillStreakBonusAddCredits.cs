using Google2u;
using UnityEngine;

public class KillStreakBonusAddCredits : KillStreakBonus
{
	private int gold;

	public override string fullName => "+" + gold;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		base.ActivateBonus(killStreakBonusBox, player);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelGoldMin).FLOATVALUE, 8, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelGoldMax).FLOATVALUE, 8, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE);
		gold = Random.Range((int)num, (int)num2);
		if (player.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.gotGoldBoxes = (int)instance.gotGoldBoxes + gold;
			BattleRewardsManager.instance.AddGold(gold);
			PlayerAnalytics.instance.data.goldBonuses++;
		}
		return true;
	}

	public override float GetBonusProbability(PlayerController owner)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 0f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE, 8, base.GetBonusProbability(owner));
	}
}
