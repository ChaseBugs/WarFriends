using UnityEngine;

internal class DailyRewardMessage : DatabaseMessage
{
	public DailyRewardMessage(int toClaim)
		: base($"DailyRewardMessage-{toClaim}", Type.DailyReward)
	{
		Debug.Log("ABOUT TO SHOW DAILY REWARD " + toClaim);
	}

	public override void Show()
	{
		base.Show();
		if (LevelManager.instance.isDailyRewardsLocked)
		{
			Debug.Log("DAILY REWARDS - currently locked!");
			return;
		}
		GuiScreenSingle<DailyRewardMonthScreen>.instance.showedFromDialog = true;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyRewardMonthScreen>.instance);
	}
}
