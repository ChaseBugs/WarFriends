using System;
using System.Collections.Generic;
using UnityEngine;

public class WarArenaRuleWeaponsReload : WarArenaRuleGeneric<WarArenaRuleWeaponsReload.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public List<WeaponConfig> weapons = new List<WeaponConfig>();
	}

	[Serializable]
	public class WeaponConfig
	{
		public WeaponCategory category = WeaponCategory.Any;

		public float reloadTimeMultiplier;
	}

	private enum RuleReload
	{
		NoReload,
		FasterReload,
		SlowerReload,
		Other
	}

	private Dictionary<RuleReload, string> mText = new Dictionary<RuleReload, string>
	{
		{
			RuleReload.NoReload,
			"ID_ARENARULES_NORELOADING"
		},
		{
			RuleReload.FasterReload,
			"ID_ARENARULES_FASTERRELOADING"
		},
		{
			RuleReload.SlowerReload,
			"ID_ARENARULES_SLOWERRELOADING"
		}
	};

	private RuleReload GetReloadType(float reloadMultiplier)
	{
		if (reloadMultiplier <= 0f)
		{
			return RuleReload.NoReload;
		}
		if (reloadMultiplier > 0f && reloadMultiplier < 1f)
		{
			return RuleReload.FasterReload;
		}
		if (reloadMultiplier > 1f)
		{
			return RuleReload.SlowerReload;
		}
		return RuleReload.Other;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		RuleReload ruleReload = ((data.weapons.Count <= 0) ? RuleReload.Other : GetReloadType(data.weapons[0].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			RuleReload reloadType = GetReloadType(data.weapons[i].reloadTimeMultiplier);
			if (ruleReload != reloadType)
			{
				ruleReload = RuleReload.Other;
				break;
			}
		}
		if (ruleReload != RuleReload.Other)
		{
			string showText = Colours.stringGreenArena + Localization.Localize(mText[ruleReload]);
			return new WarArenaRuleGui(showText);
		}
		return base.GetGenericRule();
	}

	private WeaponConfig GetConfigForWeapon(WeaponCategory category)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == category)
			{
				return weapon;
			}
		}
		return null;
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		WeaponInventory weaponInventory = PlayerController.currentPlayer.weaponInventory;
		for (int i = 0; i < weaponInventory.usedWeapons.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.usedWeapons[i];
			WeaponConfig configForWeapon = GetConfigForWeapon(playerWeapon.weaponLevelSetup.weaponCategory);
			if (configForWeapon == null || Mathf.Approximately(configForWeapon.reloadTimeMultiplier, 1f))
			{
				continue;
			}
			if (playerWeapon.weapon.reloadableWeapon)
			{
				if (configForWeapon.reloadTimeMultiplier <= 0f)
				{
					playerWeapon.weapon.reloadTime = 0f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.reloadTime = (float)weapon.reloadTime * configForWeapon.reloadTimeMultiplier;
			}
			else if (configForWeapon.reloadTimeMultiplier <= 0f)
			{
				playerWeapon.weapon.cadence = 0f;
			}
			else
			{
				playerWeapon.weapon.cadence = configForWeapon.reloadTimeMultiplier;
			}
		}
	}
}
