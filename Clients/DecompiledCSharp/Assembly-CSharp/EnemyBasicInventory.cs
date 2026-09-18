using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicInventory : Core_BaseScript
{
	[Serializable]
	public class InventoryWeapon
	{
		public Weapon weapon;

		public Weapon.WeaponType type;

		public bool leftHand;
	}

	public List<InventoryWeapon> weapons = new List<InventoryWeapon>();

	public GameObject shield;

	public List<InventoryWeapon> cardWeapons = new List<InventoryWeapon>();

	public GameObject cardShield;

	private bool mSpawnedByCard;

	private SoldierParts mSoldierParts;

	private List<Weapon> mWeaponInstancies;

	private int[] mWeaponLevels = new int[1];

	public Weapon currentWeapon => weaponInstancies[weaponIndex];

	public int weaponIndex { get; private set; }

	public List<Weapon> weaponInstancies => mWeaponInstancies;

	public List<Weapon> AttachAllWeapons(SoldierParts soldierParts, bool spawnedByCard, SoldierMeshChanger meshChanger)
	{
		weaponIndex = 0;
		mSpawnedByCard = spawnedByCard;
		mSoldierParts = soldierParts;
		if (mSpawnedByCard)
		{
			if (cardShield != null)
			{
				mSoldierParts.AttachShield(cardShield);
			}
			mSoldierParts.ChangeShieldMat(meshChanger.skinnedMeshRenderer.material);
			mWeaponInstancies = mSoldierParts.AttachWeapons(cardWeapons);
		}
		else
		{
			if (shield != null)
			{
				mSoldierParts.AttachShield(shield);
			}
			mWeaponInstancies = mSoldierParts.AttachWeapons(weapons);
		}
		SetWeaponsUpgrade(mWeaponLevels);
		return weaponInstancies;
	}

	public List<Weapon> AttachAllWeapons(SoldierParts soldierParts, byte[] indices, bool spawnedByCard, SoldierMeshChanger meshChanger)
	{
		weaponIndex = 0;
		mSpawnedByCard = spawnedByCard;
		mSoldierParts = soldierParts;
		if (mSpawnedByCard)
		{
			if (cardShield != null)
			{
				mSoldierParts.AttachShield(cardShield);
			}
			mWeaponInstancies = mSoldierParts.AttachWeapons(cardWeapons, indices);
			mSoldierParts.ChangeShieldMat(meshChanger.skinnedMeshRenderer.material);
		}
		else
		{
			if (shield != null)
			{
				mSoldierParts.AttachShield(shield);
			}
			mWeaponInstancies = mSoldierParts.AttachWeapons(weapons, indices);
		}
		SetWeaponsUpgrade(mWeaponLevels);
		return weaponInstancies;
	}

	public void DestroyWeapons()
	{
		if (weaponInstancies != null)
		{
			foreach (Weapon weaponInstancy in weaponInstancies)
			{
				weaponInstancy.DestroyPooled();
			}
		}
		mWeaponInstancies = null;
	}

	public Weapon SwitchWeapon(int weaponIndex)
	{
		Weapon result = null;
		this.weaponIndex = weaponIndex;
		if (weaponInstancies != null)
		{
			for (int i = 0; i < weaponInstancies.Count; i++)
			{
				Weapon weapon = weaponInstancies[i];
				if (i != weaponIndex)
				{
					weapon.gameObject.SetActive(value: false);
					continue;
				}
				mSoldierParts.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int level = ((i < mWeaponLevels.Length) ? mWeaponLevels[i] : 0);
					component.SetLevel(level);
				}
				weapon.gameObject.SetActive(value: true);
				result = weapon;
			}
		}
		return result;
	}

	public Weapon EnableSecondaryWeapon(int weaponIndex)
	{
		Weapon weapon = null;
		weaponInstancies[weaponIndex].gameObject.SetActive(value: true);
		weapon = weaponInstancies[weaponIndex];
		EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
		if (component != null)
		{
			int level = ((weaponIndex < mWeaponLevels.Length) ? mWeaponLevels[weaponIndex] : ((mWeaponLevels.Length > 0) ? mWeaponLevels[0] : 0));
			component.SetLevel(level);
		}
		return weaponInstancies[weaponIndex];
	}

	public IEnumerator PrepareWeaponCoroutine(int[] level, bool forCard)
	{
		List<InventoryWeapon> weaponList = ((!forCard) ? weapons : cardWeapons);
		for (int index = 0; index < weaponList.Count; index++)
		{
			InventoryWeapon inventoryWeapon = weaponList[index];
			EnemyLeveledWeapon[] leveledWeapons = inventoryWeapon.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
			if (leveledWeapons.Length > 0)
			{
				EnemyLeveledWeapon leveledWeapon = leveledWeapons[0];
				yield return StartCoroutine(leveledWeapon.PrepareAsync(level[index]));
			}
		}
	}

	public void SetWeaponsUpgrade(int[] levels)
	{
		mWeaponLevels = levels;
		if (weaponInstancies == null)
		{
			return;
		}
		for (int i = 0; i < weaponInstancies.Count; i++)
		{
			Weapon weapon = weaponInstancies[i];
			EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
			int level = ((mWeaponLevels.Length <= i) ? mWeaponLevels[0] : mWeaponLevels[i]);
			if (component != null)
			{
				component.SetLevel(level);
			}
		}
	}

	public void SetOwner(IFraction owner)
	{
		foreach (Weapon weaponInstancy in weaponInstancies)
		{
			weaponInstancy.owner = owner;
		}
	}
}
