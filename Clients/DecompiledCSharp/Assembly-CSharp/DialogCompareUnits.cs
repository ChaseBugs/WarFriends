using System.Collections.Generic;
using UnityEngine;

public class DialogCompareUnits : GuiElementSingle<DialogCompareUnits>
{
	[Header("Header")]
	public UILabel myName;

	public UILabel opponentName;

	[Header("Center")]
	public List<UISprite> middleLine;

	public GameObject unitsGrid;

	public List<CompareUnitsRecord> compareUnits;

	[Header("Bottom")]
	public UIGrid weaponsGridMy;

	public UIGrid weaponsGridOpponnet;

	public List<CompareWeaponsRecord> compareWeapons;

	private List<LevelBehaviour.UnitType> mUnitsTypesOrder = new List<LevelBehaviour.UnitType>
	{
		LevelBehaviour.UnitType.Defender,
		LevelBehaviour.UnitType.AttackerRusher,
		LevelBehaviour.UnitType.AttackerShooter,
		LevelBehaviour.UnitType.AttackerExplosive
	};

	public override void InitEvents()
	{
		base.InitEvents();
		for (int i = 0; i < 7; i++)
		{
			CompareUnitsRecord compareUnitsRecord = Object.Instantiate(compareUnits[0]);
			compareUnitsRecord.transform.parent = compareUnits[0].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			compareUnits.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 7; j++)
		{
			CompareWeaponsRecord compareWeaponsRecord = Object.Instantiate(compareWeapons[0]);
			compareWeaponsRecord.transform.parent = ((j >= 3) ? weaponsGridOpponnet.transform : weaponsGridMy.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			compareWeapons.Add(compareWeaponsRecord);
			compareWeaponsRecord.InitializeSlot((j >= 3) ? (6 - j) : (j + 1));
		}
		compareWeapons[0].InitializeSlot(0);
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		PlayerProperties playerProperties = PlayerController.currentPlayer.playerProperties;
		PlayerProperties playerProperties2 = Singleton<GameController>.instance.opponent.playerProperties;
		myName.text = playerProperties.name;
		opponentName.text = playerProperties2.name;
		float num = 872f;
		float num2 = (float)UIRoot.list[0].activeHeight - 568f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		unitsGrid.transform.localScale = new Vector3(value, value, 1f);
		int num3 = InitializeUnits(value);
		foreach (UISprite item in middleLine)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 110f * value);
		}
		InitializeWeapons();
	}

	private int InitializeUnits(float scale)
	{
		PlayerProperties playerProperties = PlayerController.currentPlayer.playerProperties;
		PlayerProperties playerProperties2 = Singleton<GameController>.instance.opponent.playerProperties;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> units = GetUnits(playerProperties);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> units2 = GetUnits(playerProperties2);
		int num = 0;
		foreach (LevelBehaviour.UnitType item in mUnitsTypesOrder)
		{
			List<Tuple<LevelBehaviour, UnitUpgradeDefinition>> list = units[item];
			List<Tuple<LevelBehaviour, UnitUpgradeDefinition>> list2 = units2[item];
			list.Sort(CompareUnitsByUnitPower);
			list2.Sort(CompareUnitsByUnitPower);
			for (int num2 = list.Count - 1; num2 >= 2; num2--)
			{
				list.RemoveAt(num2);
			}
			for (int num3 = list2.Count - 1; num3 >= 2; num3--)
			{
				list2.RemoveAt(num3);
			}
			list.Sort(CompareUnitsByUnlockLevel);
			list2.Sort(CompareUnitsByUnlockLevel);
			bool flag = list.Count > 1 && list2.Count > 0 && list[1].Value1 == list2[0].Value1;
			bool flag2 = list2.Count > 1 && list.Count > 0 && list2[1].Value1 == list[0].Value1;
			if (flag)
			{
				list.Reverse();
			}
			if (flag2)
			{
				list2.Reverse();
			}
			if (list.Count > 0 || list2.Count > 0)
			{
				CompareUnitsRecord compareUnitsRecord = compareUnits[num];
				compareUnitsRecord.gameObject.SetActive(value: true);
				compareUnitsRecord.Initialize((list.Count <= 0) ? null : list[0].Value1, (list.Count <= 0) ? null : list[0].Value2, (list2.Count <= 0) ? null : list2[0].Value1, (list2.Count <= 0) ? null : list2[0].Value2, playerProperties.level, playerProperties2.level, scale);
				num++;
			}
			if (list.Count > 1 || list2.Count > 1)
			{
				CompareUnitsRecord compareUnitsRecord2 = compareUnits[num];
				compareUnitsRecord2.gameObject.SetActive(value: true);
				compareUnitsRecord2.Initialize((list.Count <= 1) ? null : list[1].Value1, (list.Count <= 1) ? null : list[1].Value2, (list2.Count <= 1) ? null : list2[1].Value1, (list2.Count <= 1) ? null : list2[1].Value2, playerProperties.level, playerProperties2.level, scale);
				num++;
			}
		}
		for (int i = num; i < compareUnits.Count; i++)
		{
			CompareUnitsRecord compareUnitsRecord3 = compareUnits[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> GetUnits(PlayerProperties properties)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 0; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = properties.upgrades[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	private void InitializeWeapons()
	{
		PlayerProperties playerProperties = PlayerController.currentPlayer.playerProperties;
		PlayerProperties playerProperties2 = Singleton<GameController>.instance.opponent.playerProperties;
		int num = 0;
		for (int i = 0; i < playerProperties.weapons.Length; i++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon = playerProperties.weapons[i];
			WeaponLevelsSetup setup = LevelManager.instance.weaponLevelsSetups[equippedWeapon.weaponId];
			int weaponUpgrade = equippedWeapon.weaponUpgrade;
			PlayerInventory.EquippedWeapon equippedWeapon2 = playerProperties2.weapons[i];
			WeaponLevelsSetup opponentSetup = LevelManager.instance.weaponLevelsSetups[equippedWeapon2.weaponId];
			int weaponUpgrade2 = equippedWeapon2.weaponUpgrade;
			bool isEquipped = equippedWeapon.enabled;
			compareWeapons[num].Initialize(setup, weaponUpgrade, opponentSetup, weaponUpgrade2, isOpponent: false, isEquipped);
			num++;
		}
		num = playerProperties.weapons.Length + playerProperties2.weapons.Length - 1;
		for (int j = 0; j < playerProperties2.weapons.Length; j++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon3 = playerProperties.weapons[j];
			WeaponLevelsSetup opponentSetup2 = LevelManager.instance.weaponLevelsSetups[equippedWeapon3.weaponId];
			int weaponUpgrade3 = equippedWeapon3.weaponUpgrade;
			PlayerInventory.EquippedWeapon equippedWeapon4 = playerProperties2.weapons[j];
			WeaponLevelsSetup setup2 = LevelManager.instance.weaponLevelsSetups[equippedWeapon4.weaponId];
			int weaponUpgrade4 = equippedWeapon4.weaponUpgrade;
			bool isEquipped2 = equippedWeapon4.enabled;
			compareWeapons[num].Initialize(setup2, weaponUpgrade4, opponentSetup2, weaponUpgrade3, isOpponent: true, isEquipped2);
			num--;
		}
		weaponsGridMy.repositionNow = true;
		weaponsGridOpponnet.repositionNow = true;
	}

	private static int CompareUnitsByUnitPower(Tuple<LevelBehaviour, UnitUpgradeDefinition> unit1, Tuple<LevelBehaviour, UnitUpgradeDefinition> unit2)
	{
		int slotUpgradeindex = unit1.Value2.unitUpgrades.slotUpgradeindex;
		int tier = unit1.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = unit1.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, unit1.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, unit1.Value2.unitUpgrades.slotUpgradeIndexElite, unit1.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = unit2.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = unit2.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return unit2.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, unit2.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, unit2.Value2.unitUpgrades.slotUpgradeIndexElite, unit2.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private static int CompareUnitsByUnlockLevel(Tuple<LevelBehaviour, UnitUpgradeDefinition> unit1, Tuple<LevelBehaviour, UnitUpgradeDefinition> unit2)
	{
		return unit1.Value1.upgradeSlots.unlockLevelIndex.CompareTo(unit2.Value1.upgradeSlots.unlockLevelIndex);
	}
}
