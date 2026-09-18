using UnityEngine;

public class WeaponTutorialDialogMessage : DatabaseMessage
{
	private WeaponLevelsSetup mWeapon;

	public WeaponTutorialDialogMessage(WeaponLevelsSetup weapon)
		: base($"WeaponTutorialDialogMessage {weapon.weaponName}", Type.WeaponTutorialDialogMessage)
	{
		mWeapon = weapon;
		Debug.Log("About to show Tutorial for " + weapon.weaponName);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<TutorialWeaponDialog>.instance.ShowDialog(mWeapon);
	}
}
