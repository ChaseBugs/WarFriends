using UnityEngine;

public class BuyCardsReminder : DatabaseMessage
{
	public BuyCardsReminder()
		: base($"BuyCardsReminder {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.BuyCardsReminder)
	{
		Debug.Log("About to show Buy Cards Reminder");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ReminderDialog>.instance.ShowDialog(ReminderDialog.ReminderTypes.OfferingCards, delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
			GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}
}
