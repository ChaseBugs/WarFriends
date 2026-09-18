using UnityEngine;

public class PowerBandBuyAfterLose : DatabaseMessage
{
	private PlayerVisual powerBand;

	public PowerBandBuyAfterLose(PlayerVisual band)
		: base("PowerBandBuyReminder", Type.PowerBandBuyAfterLose)
	{
		powerBand = band;
		string text = ((band != null) ? band.name : "null");
		messageId += $" {text} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		Debug.Log("About to show Buy Power Band Reminder: " + text);
	}

	public override void Show()
	{
		base.Show();
		if (powerBand == null)
		{
			Debug.LogError("No power band to show in reminder!!!");
			return;
		}
		GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(powerBand, delegate
		{
			GuiScreenSingle<CamosScreen>.instance.SelectVisual(powerBand);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
			GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}
}
