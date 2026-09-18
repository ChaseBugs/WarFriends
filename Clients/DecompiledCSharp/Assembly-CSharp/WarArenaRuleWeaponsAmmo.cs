using System;
using System.Collections.Generic;
using UnityEngine;

public class WarArenaRuleWeaponsAmmo : WarArenaRuleGeneric<WarArenaRuleWeaponsAmmo.Data>
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

		public float ammoMultiplier;
	}

	private enum RuleAmmo
	{
		Half,
		Double,
		Tripple,
		Unlimited,
		Other
	}

	private Dictionary<RuleAmmo, string> mText = new Dictionary<RuleAmmo, string>
	{
		{
			RuleAmmo.Half,
			"ID_ARENARULES_HALVEDAMMO"
		},
		{
			RuleAmmo.Double,
			"ID_ARENARULES_DOUBLEAMMO"
		},
		{
			RuleAmmo.Tripple,
			"ID_ARENARULES_TRIPLEAMMO"
		},
		{
			RuleAmmo.Unlimited,
			"ID_ARENARULES_UNLIMITEDAMMO"
		}
	};

	private RuleAmmo GetAmmoType(float ammoMultiplier)
	{
		if (Mathf.Approximately(ammoMultiplier, 0.5f))
		{
			return RuleAmmo.Half;
		}
		if (Mathf.Approximately(ammoMultiplier, 2f))
		{
			return RuleAmmo.Double;
		}
		if (Mathf.Approximately(ammoMultiplier, 3f))
		{
			return RuleAmmo.Tripple;
		}
		if (ammoMultiplier < 0f)
		{
			return RuleAmmo.Unlimited;
		}
		return RuleAmmo.Other;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		RuleAmmo ruleAmmo = ((data.weapons.Count <= 0) ? RuleAmmo.Other : GetAmmoType(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			RuleAmmo ammoType = GetAmmoType(data.weapons[i].ammoMultiplier);
			if (ruleAmmo != ammoType)
			{
				ruleAmmo = RuleAmmo.Other;
				break;
			}
		}
		if (ruleAmmo != RuleAmmo.Other)
		{
			string showText = Colours.stringGreenArena + Localization.Localize(mText[ruleAmmo]);
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
			if (configForWeapon != null)
			{
				if (configForWeapon.ammoMultiplier > 0f)
				{
					playerWeapon.weapon.ammoLeft = (int)(configForWeapon.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (configForWeapon.ammoMultiplier < 0f)
				{
					playerWeapon.weapon.infiniteAmmo = true;
				}
			}
		}
	}
}
