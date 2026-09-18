using System;
using System.Collections.Generic;

public class WarArenaRuleWeapons : WarArenaRuleGeneric<WarArenaRuleWeapons.Data>
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
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		RuleType showType = RuleType.InfoRule;
		bool flag = SetupRule();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.slotCategory[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.slotCategory[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				string weaponCategoryId = Singleton<GameVariables>.instance.GetWeaponCategoryId(item2.Key, StringCase.LowerCase, StringCount.Plural);
				string weaponCategoryId2 = Singleton<GameVariables>.instance.GetWeaponCategoryId(item2.Key);
				list2.Add(Localization.Localize(weaponCategoryId));
				list3.Add(Localization.Localize(weaponCategoryId2));
				if (item2.Key != item2.Value[0])
				{
					showType = ((!flag) ? RuleType.DoesNotMeet : RuleType.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ID_ARENARULES_ONLY", string.Join(" & ", list2.ToArray()));
		string hintText = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			hintText = Localization.LocalizeFormat("ID_YOUNEEDTOEQUIPWEAPON", Colours.stringGreenArena, string.Join(" & ", list3.ToArray()));
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				string weaponCategoryId3 = Singleton<GameVariables>.instance.GetWeaponCategoryId(item3, StringCase.LowerCase, StringCount.Plural);
				list4.Add(Localization.Localize(weaponCategoryId3));
			}
			string item = Localization.LocalizeFormat("ID_ARENARULES_NO", string.Join(" & ", list4.ToArray()));
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string showText = Colours.stringGreenArena + string.Join("\n", list.ToArray());
		return new WarArenaRuleGui(showText, hintText, text, showType);
	}

	public override bool SetupRule()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.EquippedWeapon[] equippedWeapons = Singleton<GameController>.instance.gameControllerWarArena.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].enabled = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].weaponLevelsSetup;
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.weaponCategory & category) != weaponLevelsSetup.weaponCategory && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.currentPlayer.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.usedWeapons[i];
			}
		}
	}
}
