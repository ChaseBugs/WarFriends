using UnityEngine;

public class DailyGoldBoosterMessage : DatabaseMessage
{
	private long mGoldReward;

	private int mDay;

	public DailyGoldBoosterMessage(long goldReward, int day, string id)
		: base($"DailyGoldBooster-{day}-{id}", Type.NameChangeReminder)
	{
		mGoldReward = goldReward;
		mDay = day;
		Debug.Log("ABOUT TO SHOW DAILY GOLD BOOST " + goldReward + " FOR DAY " + day);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<RewardDialog>.instance.ShowDialog(RewardDialogType.DailyGold, mGoldReward, mDay);
	}

	public override bool CanShow()
	{
		return base.CanShow() || (DialogManager.instance.numberOfShownDialogues == 1 && GuiElementSingle<InappScreen>.instance.gameObject.activeSelf);
	}
}
