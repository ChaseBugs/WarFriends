using System.Collections.Generic;

public class ActiveUnitsManager : Singleton<ActiveUnitsManager>
{
	public enum ActiveUnitState
	{
		Locked,
		NotSelected,
		Selectable,
		Selected,
		Selecting,
		Deselecting,
		Borrowed
	}

	public const int MaxMechanicalUnitEquipped = 3;

	public LevelBehaviour unitToEquip;

	private List<LevelBehaviour> mDefenderUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mRusherUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mShooterUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mExplosiveUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mEquippedDefenderUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mEquippedRusherUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mEquippedShooterUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mEquippedExplosiveUnits = new List<LevelBehaviour>();

	private int mEquippedNumber;

	private int mBorrowedNumber;

	private int mMechanicalEquipped;

	private int mMenuEquippedNumber;

	private int mMenuMechanicalEquipped;

	private List<LevelBehaviour> mMenuEquippedDefenderUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mMenuEquippedRusherUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mMenuEquippedShooterUnits = new List<LevelBehaviour>();

	private List<LevelBehaviour> mMenuEquippedExplosiveUnits = new List<LevelBehaviour>();

	public int numberOfMenuEquippedUnits => mMenuEquippedNumber + mBorrowedNumber;

	public bool menuMechanicalCanBeChosen => mMenuMechanicalEquipped < 3;

	public bool mechanicalCanBeChosen => mMechanicalEquipped < 3;

	public bool selectingUnit => unitToEquip != null;

	public bool nothingEquipped => mEquippedDefenderUnits.Count == 0 && mEquippedRusherUnits.Count == 0 && mEquippedShooterUnits.Count == 0 && mEquippedDefenderUnits.Count == 0;

	private bool enoughUnitsEquippedForMenu
	{
		get
		{
			int num = 0;
			int num2 = 0;
			foreach (LevelBehaviour defenderUnit in defenderUnits)
			{
				if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (defenderUnit.upgradeSlots.bought && !defenderUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour rusherUnit in rusherUnits)
			{
				if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (rusherUnit.upgradeSlots.bought && !rusherUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag2 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour shooterUnit in shooterUnits)
			{
				if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (shooterUnit.upgradeSlots.bought && !shooterUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag3 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour explosiveUnit in explosiveUnits)
			{
				if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (explosiveUnit.upgradeSlots.bought && !explosiveUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag4 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			return flag && flag2 && flag3 && flag4;
		}
	}

	public int fakeArmyPowerX10
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots != null && behaviour.upgradeSlots.inSelectMenuEquipped && !behaviour.upgradeSlots.borrowed)
				{
					num += behaviour.upgradeSlots.armyPowerX10;
				}
			}
			return LevelManager.instance.weaponPowerX10 + LevelManager.instance.rankPowerX10 + num;
		}
	}

	public List<LevelBehaviour> defenderUnits => mDefenderUnits;

	public List<LevelBehaviour> rusherUnits => mRusherUnits;

	public List<LevelBehaviour> shooterUnits => mShooterUnits;

	public List<LevelBehaviour> explosiveUnits => mExplosiveUnits;

	public List<LevelBehaviour> equippedDefenders => mEquippedDefenderUnits;

	public List<LevelBehaviour> equippedRushers => mEquippedRusherUnits;

	public List<LevelBehaviour> equippedShooters => mEquippedShooterUnits;

	public List<LevelBehaviour> equippedExplosives => mEquippedExplosiveUnits;

	public LevelBehaviour firstDefender => (mMenuEquippedDefenderUnits.Count != 0) ? mMenuEquippedDefenderUnits[0] : null;

	public LevelBehaviour secondDefender => (mMenuEquippedDefenderUnits.Count >= 2) ? mMenuEquippedDefenderUnits[1] : null;

	public LevelBehaviour firstRusher => (mMenuEquippedRusherUnits.Count != 0) ? mMenuEquippedRusherUnits[0] : null;

	public LevelBehaviour secondRusher => (mMenuEquippedRusherUnits.Count >= 2) ? mMenuEquippedRusherUnits[1] : null;

	public LevelBehaviour firstShooter => (mMenuEquippedShooterUnits.Count != 0) ? mMenuEquippedShooterUnits[0] : null;

	public LevelBehaviour secondShooter => (mMenuEquippedShooterUnits.Count >= 2) ? mMenuEquippedShooterUnits[1] : null;

	public LevelBehaviour firstExplosive => (mMenuEquippedExplosiveUnits.Count != 0) ? mMenuEquippedExplosiveUnits[0] : null;

	public LevelBehaviour secondExplosive => (mMenuEquippedExplosiveUnits.Count >= 2) ? mMenuEquippedExplosiveUnits[1] : null;

	public int selectableDefenders
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour mDefenderUnit in mDefenderUnits)
			{
				if (mDefenderUnit.upgradeSlots.bought && !mDefenderUnit.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableRusher
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour mRusherUnit in mRusherUnits)
			{
				if (mRusherUnit.upgradeSlots.bought && !mRusherUnit.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableShooter
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour mShooterUnit in mShooterUnits)
			{
				if (mShooterUnit.upgradeSlots.bought && !mShooterUnit.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableExplosive
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour mExplosiveUnit in mExplosiveUnits)
			{
				if (mExplosiveUnit.upgradeSlots.bought && !mExplosiveUnit.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public void Initialize()
	{
		mDefenderUnits.Clear();
		mRusherUnits.Clear();
		mShooterUnits.Clear();
		mExplosiveUnits.Clear();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				mDefenderUnits.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				mRusherUnits.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				mShooterUnits.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				mExplosiveUnits.Add(behaviour);
				break;
			}
		}
		mDefenderUnits.Sort(SortFunctionUnits);
		mRusherUnits.Sort(SortFunctionUnits);
		mShooterUnits.Sort(SortFunctionUnits);
		mExplosiveUnits.Sort(SortFunctionUnits);
		mEquippedNumber = 0;
		mMechanicalEquipped = 0;
		mBorrowedNumber = 0;
		mEquippedDefenderUnits.Clear();
		mEquippedRusherUnits.Clear();
		mEquippedShooterUnits.Clear();
		mEquippedExplosiveUnits.Clear();
		foreach (LevelBehaviour mDefenderUnit in mDefenderUnits)
		{
			if (mDefenderUnit.upgradeSlots.equipped && mDefenderUnit.upgradeSlots.bought)
			{
				mEquippedDefenderUnits.Add(mDefenderUnit);
				mEquippedNumber++;
				if (!mDefenderUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
			else if (mDefenderUnit.upgradeSlots.borrowed)
			{
				mBorrowedNumber++;
			}
		}
		foreach (LevelBehaviour mRusherUnit in mRusherUnits)
		{
			if (mRusherUnit.upgradeSlots.equipped && mRusherUnit.upgradeSlots.bought)
			{
				mEquippedRusherUnits.Add(mRusherUnit);
				mEquippedNumber++;
				if (!mRusherUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
			else if (mRusherUnit.upgradeSlots.borrowed)
			{
				mBorrowedNumber++;
			}
		}
		foreach (LevelBehaviour mShooterUnit in mShooterUnits)
		{
			if (mShooterUnit.upgradeSlots.equipped && mShooterUnit.upgradeSlots.bought)
			{
				mEquippedShooterUnits.Add(mShooterUnit);
				mEquippedNumber++;
				if (!mShooterUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
			else if (mShooterUnit.upgradeSlots.borrowed)
			{
				mBorrowedNumber++;
			}
		}
		foreach (LevelBehaviour mExplosiveUnit in mExplosiveUnits)
		{
			if (mExplosiveUnit.upgradeSlots.equipped && mExplosiveUnit.upgradeSlots.bought)
			{
				mEquippedExplosiveUnits.Add(mExplosiveUnit);
				mEquippedNumber++;
				if (!mExplosiveUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
			else if (mExplosiveUnit.upgradeSlots.borrowed)
			{
				mBorrowedNumber++;
			}
		}
		if (nothingEquipped)
		{
			EquipAll();
		}
	}

	private int SortFunctionUnits(LevelBehaviour unit1, LevelBehaviour unit2)
	{
		if (unit1.upgradeSlots.startTier == unit2.upgradeSlots.startTier)
		{
			return unit1.upgradeSlots.unlockLevelIndex.CompareTo(unit2.upgradeSlots.unlockLevelIndex);
		}
		return unit1.upgradeSlots.startTier.CompareTo(unit2.upgradeSlots.startTier);
	}

	public void PresetForSelectMenu()
	{
		mMenuEquippedNumber = 0;
		mMenuMechanicalEquipped = 0;
		mMenuEquippedDefenderUnits.Clear();
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			defenderUnit.upgradeSlots.inSelectMenuEquipped = defenderUnit.upgradeSlots.equipped && defenderUnit.upgradeSlots.bought;
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mMenuEquippedDefenderUnits.Add(defenderUnit);
				mMenuEquippedNumber++;
				if (!defenderUnit.isSoldier)
				{
					mMenuMechanicalEquipped++;
				}
			}
		}
		mMenuEquippedRusherUnits.Clear();
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			rusherUnit.upgradeSlots.inSelectMenuEquipped = rusherUnit.upgradeSlots.equipped && rusherUnit.upgradeSlots.bought;
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mMenuEquippedRusherUnits.Add(rusherUnit);
				mMenuEquippedNumber++;
				if (!rusherUnit.isSoldier)
				{
					mMenuMechanicalEquipped++;
				}
			}
		}
		mMenuEquippedShooterUnits.Clear();
		foreach (LevelBehaviour shooterUnit in shooterUnits)
		{
			shooterUnit.upgradeSlots.inSelectMenuEquipped = shooterUnit.upgradeSlots.equipped && shooterUnit.upgradeSlots.bought;
			if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mMenuEquippedShooterUnits.Add(shooterUnit);
				mMenuEquippedNumber++;
				if (!shooterUnit.isSoldier)
				{
					mMenuMechanicalEquipped++;
				}
			}
		}
		mMenuEquippedExplosiveUnits.Clear();
		foreach (LevelBehaviour explosiveUnit in explosiveUnits)
		{
			explosiveUnit.upgradeSlots.inSelectMenuEquipped = explosiveUnit.upgradeSlots.equipped && explosiveUnit.upgradeSlots.bought;
			if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mMenuEquippedExplosiveUnits.Add(explosiveUnit);
				mMenuEquippedNumber++;
				if (!explosiveUnit.isSoldier)
				{
					mMenuMechanicalEquipped++;
				}
			}
		}
	}

	public bool SetUnitsByMenu()
	{
		if (!enoughUnitsEquippedForMenu)
		{
			return false;
		}
		if (mMenuMechanicalEquipped > 3)
		{
			return false;
		}
		mMechanicalEquipped = 0;
		mEquippedNumber = 0;
		mEquippedDefenderUnits.Clear();
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			defenderUnit.upgradeSlots.equipped = defenderUnit.upgradeSlots.inSelectMenuEquipped;
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mEquippedDefenderUnits.Add(defenderUnit);
				mEquippedNumber++;
				if (!defenderUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
		}
		mEquippedRusherUnits.Clear();
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			rusherUnit.upgradeSlots.equipped = rusherUnit.upgradeSlots.inSelectMenuEquipped;
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mEquippedRusherUnits.Add(rusherUnit);
				mEquippedNumber++;
				if (!rusherUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
		}
		mEquippedShooterUnits.Clear();
		foreach (LevelBehaviour shooterUnit in shooterUnits)
		{
			shooterUnit.upgradeSlots.equipped = shooterUnit.upgradeSlots.inSelectMenuEquipped;
			if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mEquippedShooterUnits.Add(shooterUnit);
				mEquippedNumber++;
				if (!shooterUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
		}
		mEquippedExplosiveUnits.Clear();
		foreach (LevelBehaviour explosiveUnit in explosiveUnits)
		{
			explosiveUnit.upgradeSlots.equipped = explosiveUnit.upgradeSlots.inSelectMenuEquipped;
			if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
			{
				mEquippedExplosiveUnits.Add(explosiveUnit);
				mEquippedNumber++;
				if (!explosiveUnit.isSoldier)
				{
					mMechanicalEquipped++;
				}
			}
		}
		return true;
	}

	public bool MenuEquip(LevelBehaviour unit)
	{
		if (!unit.isSoldier && !menuMechanicalCanBeChosen)
		{
			return false;
		}
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (mMenuEquippedDefenderUnits.Count < 2)
			{
				EquipDefenderUnit(unit, onlyMenu: true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (mMenuEquippedRusherUnits.Count < 2)
			{
				EquipRusherUnit(unit, onlyMenu: true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (mMenuEquippedShooterUnits.Count < 2)
			{
				EquipShooterUnit(unit, onlyMenu: true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (mMenuEquippedExplosiveUnits.Count < 2)
			{
				EquipExplosiveUnit(unit, onlyMenu: true);
				return true;
			}
			break;
		}
		return false;
	}

	public bool MenuUnequip(LevelBehaviour unit)
	{
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (mMenuEquippedDefenderUnits.Contains(unit))
			{
				unit.upgradeSlots.inSelectMenuEquipped = false;
				mMenuEquippedDefenderUnits.Remove(unit);
				mMenuEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMenuMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (mMenuEquippedRusherUnits.Contains(unit))
			{
				unit.upgradeSlots.inSelectMenuEquipped = false;
				mMenuEquippedRusherUnits.Remove(unit);
				mMenuEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMenuMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (mMenuEquippedShooterUnits.Contains(unit))
			{
				unit.upgradeSlots.inSelectMenuEquipped = false;
				mMenuEquippedShooterUnits.Remove(unit);
				mMenuEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMenuMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (mMenuEquippedExplosiveUnits.Contains(unit))
			{
				unit.upgradeSlots.inSelectMenuEquipped = false;
				mMenuEquippedExplosiveUnits.Remove(unit);
				mMenuEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMenuMechanicalEquipped--;
				}
				return true;
			}
			break;
		}
		return false;
	}

	public bool Equip(LevelBehaviour unit)
	{
		if (!unit.isSoldier && !mechanicalCanBeChosen)
		{
			return false;
		}
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (mEquippedDefenderUnits.Count < 2)
			{
				EquipDefenderUnit(unit, onlyMenu: false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (mEquippedRusherUnits.Count < 2)
			{
				EquipRusherUnit(unit, onlyMenu: false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (mEquippedShooterUnits.Count < 2)
			{
				EquipShooterUnit(unit, onlyMenu: false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (mEquippedExplosiveUnits.Count < 2)
			{
				EquipExplosiveUnit(unit, onlyMenu: false);
				return true;
			}
			break;
		}
		return false;
	}

	public bool Unequip(LevelBehaviour unit)
	{
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (mEquippedDefenderUnits.Contains(unit))
			{
				unit.upgradeSlots.equipped = false;
				mEquippedDefenderUnits.Remove(unit);
				mEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (mEquippedRusherUnits.Contains(unit))
			{
				unit.upgradeSlots.equipped = false;
				mEquippedRusherUnits.Remove(unit);
				mEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (mEquippedShooterUnits.Contains(unit))
			{
				unit.upgradeSlots.equipped = false;
				mEquippedShooterUnits.Remove(unit);
				mEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMechanicalEquipped--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (mEquippedExplosiveUnits.Contains(unit))
			{
				unit.upgradeSlots.equipped = false;
				mEquippedExplosiveUnits.Remove(unit);
				mEquippedNumber--;
				if (!unit.isSoldier)
				{
					mMechanicalEquipped--;
				}
				return true;
			}
			break;
		}
		return false;
	}

	public ActiveUnitState GetState(LevelBehaviour unit, bool inMenu)
	{
		if (!unit.upgradeSlots.bought)
		{
			return ActiveUnitState.Locked;
		}
		if (unit.upgradeSlots.borrowed)
		{
			return ActiveUnitState.Borrowed;
		}
		bool flag = false;
		ActiveUnitState activeUnitState = ActiveUnitState.Locked;
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			flag = ((!inMenu) ? mEquippedDefenderUnits.Count : mMenuEquippedDefenderUnits.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			flag = ((!inMenu) ? mEquippedRusherUnits.Count : mMenuEquippedRusherUnits.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			flag = ((!inMenu) ? mEquippedShooterUnits.Count : mMenuEquippedShooterUnits.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			flag = ((!inMenu) ? mEquippedExplosiveUnits.Count : mMenuEquippedExplosiveUnits.Count) < 2;
			break;
		}
		if (!inMenu)
		{
			activeUnitState = ((unit.upgradeSlots.bought && unit.upgradeSlots.equipped) ? ActiveUnitState.Selected : ((!flag) ? ActiveUnitState.NotSelected : ActiveUnitState.Selectable));
		}
		else if (unit.upgradeSlots.inSelectMenuEquipped)
		{
			activeUnitState = ActiveUnitState.Selected;
			if (selectingUnit && unit.unitType == unitToEquip.unitType)
			{
				activeUnitState = ActiveUnitState.Deselecting;
			}
		}
		else if (flag)
		{
			activeUnitState = ActiveUnitState.Selectable;
		}
		else
		{
			activeUnitState = ActiveUnitState.NotSelected;
			if (selectingUnit)
			{
				activeUnitState = ((!(unitToEquip == unit)) ? ActiveUnitState.NotSelected : ActiveUnitState.Selecting);
			}
		}
		return activeUnitState;
	}

	public bool TryToEquip(LevelBehaviour unit)
	{
		if (GetState(unit, inMenu: false) == ActiveUnitState.Selectable)
		{
			return Equip(unit);
		}
		return false;
	}

	private void EquipDefenderUnit(LevelBehaviour unit, bool onlyMenu)
	{
		unit.upgradeSlots.wasEquipped = true;
		if (onlyMenu)
		{
			unit.upgradeSlots.inSelectMenuEquipped = true;
			mMenuEquippedDefenderUnits.Add(unit);
			mMenuEquippedDefenderUnits.Sort(SortFunctionUnits);
			mMenuEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMenuMechanicalEquipped++;
			}
		}
		else
		{
			unit.upgradeSlots.equipped = true;
			mEquippedDefenderUnits.Add(unit);
			mEquippedDefenderUnits.Sort(SortFunctionUnits);
			mEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMechanicalEquipped++;
			}
		}
	}

	private void EquipRusherUnit(LevelBehaviour unit, bool onlyMenu)
	{
		unit.upgradeSlots.wasEquipped = true;
		if (onlyMenu)
		{
			unit.upgradeSlots.inSelectMenuEquipped = true;
			mMenuEquippedRusherUnits.Add(unit);
			mMenuEquippedRusherUnits.Sort(SortFunctionUnits);
			mMenuEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMenuMechanicalEquipped++;
			}
		}
		else
		{
			unit.upgradeSlots.equipped = true;
			mEquippedRusherUnits.Add(unit);
			mEquippedRusherUnits.Sort(SortFunctionUnits);
			mEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMechanicalEquipped++;
			}
		}
	}

	private void EquipShooterUnit(LevelBehaviour unit, bool onlyMenu)
	{
		unit.upgradeSlots.wasEquipped = true;
		if (onlyMenu)
		{
			unit.upgradeSlots.inSelectMenuEquipped = true;
			mMenuEquippedShooterUnits.Add(unit);
			mMenuEquippedShooterUnits.Sort(SortFunctionUnits);
			mMenuEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMenuMechanicalEquipped++;
			}
		}
		else
		{
			unit.upgradeSlots.equipped = true;
			mEquippedShooterUnits.Add(unit);
			mEquippedShooterUnits.Sort(SortFunctionUnits);
			mEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMechanicalEquipped++;
			}
		}
	}

	private void EquipExplosiveUnit(LevelBehaviour unit, bool onlyMenu)
	{
		unit.upgradeSlots.wasEquipped = true;
		if (onlyMenu)
		{
			unit.upgradeSlots.inSelectMenuEquipped = true;
			mMenuEquippedExplosiveUnits.Add(unit);
			mMenuEquippedExplosiveUnits.Sort(SortFunctionUnits);
			mMenuEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMenuMechanicalEquipped++;
			}
		}
		else
		{
			unit.upgradeSlots.equipped = true;
			mEquippedExplosiveUnits.Add(unit);
			mEquippedExplosiveUnits.Sort(SortFunctionUnits);
			mEquippedNumber++;
			if (!unit.isSoldier)
			{
				mMechanicalEquipped++;
			}
		}
	}

	private void EquipAll()
	{
		foreach (LevelBehaviour mDefenderUnit in mDefenderUnits)
		{
			ActiveUnitState state = GetState(mDefenderUnit, inMenu: false);
			if (state == ActiveUnitState.Selectable)
			{
				Equip(mDefenderUnit);
			}
		}
		foreach (LevelBehaviour mRusherUnit in mRusherUnits)
		{
			ActiveUnitState state2 = GetState(mRusherUnit, inMenu: false);
			if (state2 == ActiveUnitState.Selectable)
			{
				Equip(mRusherUnit);
			}
		}
		foreach (LevelBehaviour mShooterUnit in mShooterUnits)
		{
			ActiveUnitState state3 = GetState(mShooterUnit, inMenu: false);
			if (state3 == ActiveUnitState.Selectable)
			{
				Equip(mShooterUnit);
			}
		}
		foreach (LevelBehaviour mExplosiveUnit in mExplosiveUnits)
		{
			ActiveUnitState state4 = GetState(mExplosiveUnit, inMenu: false);
			if (state4 == ActiveUnitState.Selectable)
			{
				Equip(mExplosiveUnit);
			}
		}
	}

	public void EquipRentalUnit(LevelBehaviour rentalUnit)
	{
		mBorrowedNumber++;
	}

	public void UnequipRentalUnit(LevelBehaviour rentalUnit)
	{
		mBorrowedNumber--;
	}

	public int MenuUnequipCategory(LevelBehaviour unit)
	{
		int num = 0;
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			for (int num5 = mMenuEquippedDefenderUnits.Count - 1; num5 >= 0; num5--)
			{
				num += mMenuEquippedDefenderUnits[num5].upgradeSlots.armyPowerX10;
				MenuUnequip(mMenuEquippedDefenderUnits[num5]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			for (int num3 = mMenuEquippedRusherUnits.Count - 1; num3 >= 0; num3--)
			{
				num += mMenuEquippedRusherUnits[num3].upgradeSlots.armyPowerX10;
				MenuUnequip(mMenuEquippedRusherUnits[num3]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			for (int num4 = mMenuEquippedShooterUnits.Count - 1; num4 >= 0; num4--)
			{
				num += mMenuEquippedShooterUnits[num4].upgradeSlots.armyPowerX10;
				MenuUnequip(mMenuEquippedShooterUnits[num4]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			for (int num2 = mMenuEquippedExplosiveUnits.Count - 1; num2 >= 0; num2--)
			{
				num += mMenuEquippedExplosiveUnits[num2].upgradeSlots.armyPowerX10;
				MenuUnequip(mMenuEquippedExplosiveUnits[num2]);
			}
			break;
		}
		}
		return num;
	}

	public LevelBehaviour IsEnoughBoughtUnits(LevelBehaviour.UnitType unitType)
	{
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			int num3 = 0;
			for (int k = 0; k < mEquippedDefenderUnits.Count; k++)
			{
				if (!mEquippedDefenderUnits[k].upgradeSlots.borrowed)
				{
					num3++;
				}
			}
			if (num3 < 2)
			{
				return mDefenderUnits[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			int num4 = 0;
			for (int l = 0; l < mEquippedRusherUnits.Count; l++)
			{
				if (!mEquippedRusherUnits[l].upgradeSlots.borrowed)
				{
					num4++;
				}
			}
			if (num4 < 2)
			{
				return mRusherUnits[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			int num2 = 0;
			for (int j = 0; j < mEquippedShooterUnits.Count; j++)
			{
				if (!mEquippedShooterUnits[j].upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			if (num2 < 2)
			{
				return mShooterUnits[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			int num = 0;
			for (int i = 0; i < mEquippedExplosiveUnits.Count; i++)
			{
				if (!mEquippedExplosiveUnits[i].upgradeSlots.borrowed)
				{
					num++;
				}
			}
			if (num < 2)
			{
				return mExplosiveUnits[1];
			}
			break;
		}
		}
		return null;
	}

	public int IndexOfUnit(LevelBehaviour unit)
	{
		switch (unit.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			for (int l = 0; l < mDefenderUnits.Count; l++)
			{
				if (unit == mDefenderUnits[l])
				{
					return l;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			for (int j = 0; j < mRusherUnits.Count; j++)
			{
				if (unit == mRusherUnits[j])
				{
					return j;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			for (int k = 0; k < mShooterUnits.Count; k++)
			{
				if (unit == mShooterUnits[k])
				{
					return k;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			for (int i = 0; i < mExplosiveUnits.Count; i++)
			{
				if (unit == mExplosiveUnits[i])
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}
}
