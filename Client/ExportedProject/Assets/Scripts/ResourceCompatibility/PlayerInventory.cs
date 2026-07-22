using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

public class PlayerInventory : DatabaseSerializedObjectGeneric<PlayerInventory.InventoryData>
{
	[Preserve]
	public class EquippedWeapon
	{
		public int weaponId;

		public int weaponUpgrade;

		public bool enabled;

		public int weaponFeature;
	}

	[Serializable]
	public class InventorySlot
	{
		public int index;

		public WeaponCategory category;

		public string dictionaryId;

		public string iconName;

		public string name => null;

		public int weaponIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public WeaponLevelsSetup weaponLevelsSetup => null;
	}

	[Preserve]
	public class InventoryData
	{
		public Dictionary<int, SerializedSlotDetail> slots;
	}

	[Preserve]
	public class SerializedSlotDetail
	{
		public string name;

		public int weaponIndex;

		public int specialFeature;
	}

	private static PlayerInventory mInstance;

	public List<InventorySlot> inventorySlots;

	public static PlayerInventory instance => null;

	public EquippedWeapon[] equippedWeapons => null;

	public void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}

	public void Init()
	{
	}

	private void OnPlayerDataLoaded()
	{
	}

	public InventorySlot GetSlotForCategory(WeaponCategory category)
	{
		return null;
	}

	public int GetIndexForCategory(WeaponCategory category)
	{
		return 0;
	}

	internal void LoadData(string inventoryData)
	{
	}

	private void CheckEquippedWeapons()
	{
	}

	private void CheckEquippedSlot(int index)
	{
	}
}
