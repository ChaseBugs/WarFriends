using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class PlayerInventory : DatabaseSerializedObjectGeneric<PlayerInventory.InventoryData>
{
	public class EquippedWeapon
	{
		public int weaponId;

		public int weaponUpgrade;

		public bool enabled = true;
	}

	[Serializable]
	public class InventorySlot
	{
		public int index;

		public WeaponCategory category;

		public string dictionaryId;

		public string iconName;

		public string name => Localization.Localize(dictionaryId);

		public int weaponIndex
		{
			get
			{
				SerializedSlotDetail value = null;
				if (instance.data.slots.TryGetValue(index, out value))
				{
					return value.weaponIndex;
				}
				Debug.LogError("data.slots doesnt contain: " + index);
				return 0;
			}
			set
			{
				instance.data.slots[index].weaponIndex = value;
			}
		}

		public WeaponLevelsSetup weaponLevelsSetup => (weaponIndex >= 0) ? LevelManager.instance.weaponLevelsSetups[weaponIndex] : null;
	}

	[Skip]
	public class InventoryData
	{
		public Dictionary<int, SerializedSlotDetail> slots = new Dictionary<int, SerializedSlotDetail>();
	}

	[Skip]
	public class SerializedSlotDetail
	{
		public string name;

		public int weaponIndex;
	}

	private static PlayerInventory mInstance;

	public List<InventorySlot> inventorySlots;

	public static PlayerInventory instance
	{
		get
		{
			mInstance = mInstance ?? ((PlayerInventory)UnityEngine.Object.FindObjectsOfType(typeof(PlayerInventory))[0]);
			return mInstance;
		}
	}

	public EquippedWeapon[] equippedWeapons
	{
		get
		{
			List<EquippedWeapon> list = new List<EquippedWeapon>();
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				InventorySlot inventorySlot = inventorySlots[i];
				if (inventorySlot.weaponLevelsSetup != null)
				{
					list.Add(new EquippedWeapon
					{
						weaponId = inventorySlot.weaponIndex,
						weaponUpgrade = inventorySlot.weaponLevelsSetup.upgradeSlots.boughtIndex,
						enabled = true
					});
				}
			}
			return list.ToArray();
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	public void Init()
	{
		for (int i = 0; i < inventorySlots.Count; i++)
		{
			if (data.slots.ContainsKey(i))
			{
				continue;
			}
			int num = -1;
			int num2 = int.MaxValue;
			for (int j = 0; j < LevelManager.instance.weaponLevelsSetups.Count; j++)
			{
				if ((LevelManager.instance.weaponLevelsSetups[j].weaponCategory & inventorySlots[i].category) == LevelManager.instance.weaponLevelsSetups[j].weaponCategory && LevelManager.instance.weaponLevelsSetups[j].unlockLevelIndex < num2)
				{
					num2 = LevelManager.instance.weaponLevelsSetups[j].unlockLevelIndex;
					num = j;
				}
			}
			data.slots[i] = new SerializedSlotDetail
			{
				name = LevelManager.instance.weaponLevelsSetups[num].GetSheetName(),
				weaponIndex = num
			};
		}
	}

	private void OnPlayerDataLoaded()
	{
	}

	internal void LoadData(string inventoryData)
	{
		InventoryData inventoryData2 = JsonConvert.DeserializeObject<InventoryData>(inventoryData);
		foreach (KeyValuePair<int, SerializedSlotDetail> slot in inventoryData2.slots)
		{
			((InventoryData)SerializedObject).slots[slot.Key] = slot.Value;
		}
	}
}
