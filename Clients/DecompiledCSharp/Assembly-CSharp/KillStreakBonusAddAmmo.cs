using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class KillStreakBonusAddAmmo : KillStreakBonus
{
	private int wb;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		base.ActivateBonus(killStreakBonusBox, player);
		List<PlayerWeapon> usedWeapons = player.weaponInventory.usedWeapons;
		foreach (PlayerWeapon item in usedWeapons)
		{
			item.weapon.ammoLeft += item.weapon.clipSize;
		}
		return true;
	}

	public override float GetBonusProbability(PlayerController owner)
	{
		bool flag = false;
		for (int i = 0; i < Mathf.Min(2, owner.weaponInventory.usedWeapons.Count); i++)
		{
			PlayerWeapon playerWeapon = owner.weaponInventory.usedWeapons[i];
			if (playerWeapon.weapon.hasLowAmmo)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
			return fLOATVALUE * base.GetBonusProbability(owner);
		}
		return base.GetBonusProbability(owner);
	}
}
