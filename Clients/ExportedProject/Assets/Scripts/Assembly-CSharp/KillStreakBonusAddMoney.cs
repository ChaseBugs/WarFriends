using Google2u;
using UnityEngine;

public class KillStreakBonusAddMoney : KillStreakBonus
{
	private int mAddedWarBucks;

	public override string fullName => "+" + mAddedWarBucks;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		base.ActivateBonus(killStreakBonusBox, player);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		mAddedWarBucks = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarbucksScalingBase).FLOATVALUE;
		mAddedWarBucks = (int)(Mathf.Pow(f, player.playerProperties.level - 3) * (float)mAddedWarBucks);
		if (player.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.gotWarbucksBoxes = (int)instance.gotWarbucksBoxes + mAddedWarBucks;
			BattleRewardsManager.instance.AddWB(mAddedWarBucks);
		}
		return true;
	}

	public override float GetBonusProbability(PlayerController owner)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 0f;
		}
		return base.GetBonusProbability(owner);
	}
}
