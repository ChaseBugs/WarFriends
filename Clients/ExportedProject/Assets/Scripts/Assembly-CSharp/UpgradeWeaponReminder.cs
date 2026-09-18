using UnityEngine;

public class UpgradeWeaponReminder : DatabaseMessage
{
	private WeaponLevelsSetup weaponToUpgrade;

	public UpgradeWeaponReminder(WeaponLevelsSetup weapon)
		: base($"UpgradeWeaponReminder {weapon.weaponName} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.UpgradeWeaponReminder)
	{
		weaponToUpgrade = weapon;
		Debug.Log("About to show Upgrade Weapon Reminder: " + weaponToUpgrade.weaponName);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ReminderDialog>.instance.ShowWeaponDialog(weaponToUpgrade, delegate
		{
			GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponToUpgrade);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}
}
