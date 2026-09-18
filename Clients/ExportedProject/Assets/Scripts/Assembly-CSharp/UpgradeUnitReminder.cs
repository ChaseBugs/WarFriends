using UnityEngine;

public class UpgradeUnitReminder : DatabaseMessage
{
	private LevelBehaviour unitToUpgrade;

	public UpgradeUnitReminder(LevelBehaviour unit)
		: base($"UpgradeUnitReminder {unit.unitName} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.UpgradeUnitReminder)
	{
		unitToUpgrade = unit;
		Debug.Log("About to show Upgrade Unit Reminder: " + unitToUpgrade.unitName);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ReminderDialog>.instance.ShowUnitDialog(unitToUpgrade, delegate
		{
			GuiScreenSingle<ArmyScreen>.instance.SelectUnit(unitToUpgrade);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}
}
