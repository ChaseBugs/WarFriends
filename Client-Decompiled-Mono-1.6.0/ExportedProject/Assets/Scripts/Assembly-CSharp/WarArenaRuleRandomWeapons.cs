using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleRandomWeapons", menuName = "War Arena Rules/WarArena Random Weapons", order = int.MaxValue)]
public class WarArenaRuleRandomWeapons : WarArenaRuleGeneric<WarArenaRuleRandomWeapons.Data>
{
	[Serializable]
	public class Data : RuleData
	{
	}

	private int mLastMatches;

	private PlayerInventory.JIMOKIIJHNA[] mEquippedWeapons;

	public override bool AIMGMMCHEIO()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.PGMBDLLHBBA(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.KFJLPGPAAAN();
	}

	public virtual bool JOMINLGEFME()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.EDNAIMPLPGL();
	}

	protected virtual OCCICIIEHEF ONNPAFIOOGE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Army_Unit_ID"), (OBNJAIHEJOJ)4);
	}

	public virtual bool LCLHBPOHONI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HOPJOGPPDIJ(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.OEAODGFDMGC();
	}

	public virtual bool BEAIFLHACMB()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.PGMBDLLHBBA(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.MPNDBIBDOCD();
	}

	protected virtual OCCICIIEHEF BEBKKFBIEJJ()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("UsedCards"), (OBNJAIHEJOJ)4);
	}

	protected virtual OCCICIIEHEF ICHICEHGCHP()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ArenaPrice"), OBNJAIHEJOJ.DoesNotMeet);
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-close"), (OBNJAIHEJOJ)4);
	}

	public virtual bool ABNFFOOKMDF()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.CLPEMLCLDIJ();
	}

	public virtual bool HFCHLFNKAAL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HOPJOGPPDIJ(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.AIMGMMCHEIO();
	}

	public virtual bool HJEDAJDHEIG()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.KJDMOCMBFLJ();
	}

	public virtual bool DOCIOINNLBP()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.EKMMLNKADIL();
	}

	public virtual bool OEIAKOCOBNH()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.DDFGIDBHJIK();
	}

	public virtual bool EKGJEGJKHBE()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.NIGDGGIBLHA(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.EKMMLNKADIL();
	}

	public virtual bool GEDHBEADJGG()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HOPJOGPPDIJ(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.AIMGMMCHEIO();
	}

	public virtual bool LFJLHMIJLHK()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Setting weapon delivery"));
	}

	protected override OCCICIIEHEF CKKHLNNIKHE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("HeroicMissionsCompletionRewardArmyUnitId"), (OBNJAIHEJOJ)5);
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("weapons"), OBNJAIHEJOJ.DoesNotMeet);
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_"));
	}

	public virtual bool ACJHEBEKFPM()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HHNMDNLNPHH(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.AIMGMMCHEIO();
	}

	protected virtual OCCICIIEHEF PKEGIGAEKNM()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("localPlayerLeaderboard"), (OBNJAIHEJOJ)7);
	}

	protected override OCCICIIEHEF IBOOCJPKFLG()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("stopAutoManage"), OBNJAIHEJOJ.InfoText);
	}

	public virtual bool IGIMHDBBFJI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HHNMDNLNPHH(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.DJDCOJHOBJP();
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Unfreeze "), (OBNJAIHEJOJ)6);
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_RANDOMWEAPONS"));
	}

	public virtual bool IMOAIPDNDKL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HHNMDNLNPHH(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.KJDMOCMBFLJ();
	}

	protected virtual OCCICIIEHEF IMMALNHKFBH()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("AA:BB:CC:DD:EE:FF"), OBNJAIHEJOJ.DoesNotMeet);
	}

	public virtual bool FLLKDDFAFAD()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.NIGDGGIBLHA(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.FGHKBLLKOBL();
	}

	public virtual bool DOLNPMMBCLF()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.OEAODGFDMGC();
	}

	public virtual bool NNJFECMPDCI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.CLPEMLCLDIJ();
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DatabasePlayer Name: {0}  Id: {1}  Level: {2}  SquadRank: {3}"), (OBNJAIHEJOJ)4);
	}

	public virtual bool KOHMDOHKMIH()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.NMPPLCHLCDK();
	}

	protected virtual OCCICIIEHEF KMLOHPNKIDO()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}{1}[-]"), OBNJAIHEJOJ.FulFill);
	}

	public virtual bool ENFDGBOGOIC()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.KJDMOCMBFLJ();
	}

	protected virtual OCCICIIEHEF BNLBBIAKFJB()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BattleRewards"), (OBNJAIHEJOJ)6);
	}

	public override bool EKMMLNKADIL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.EKMMLNKADIL();
	}

	protected virtual OCCICIIEHEF MLKICHDLCIE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SEND PLAYER REPORT ERROR - NO PLAYER ID"), OBNJAIHEJOJ.InfoText);
	}

	public virtual bool MIPKONGICFO()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.KJDMOCMBFLJ();
	}

	public virtual bool KJBLKMDHJMC()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.CLPEMLCLDIJ();
	}

	protected override OCCICIIEHEF BEDAAOOPNLB()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("------------------\n"), OBNJAIHEJOJ.FulFill);
	}

	public virtual bool MMCGGCFABAJ()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.warArenaUpgrade,
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.KFJLPGPAAAN();
	}

	protected virtual OCCICIIEHEF EFAOEMFMBHI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Card_2_Played"), (OBNJAIHEJOJ)5);
	}

	public virtual bool DANEHBKOOGF()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.NIGDGGIBLHA(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.FGHKBLLKOBL();
	}

	public virtual bool JDOHJEEMAKO()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.NIGDGGIBLHA(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.KFJLPGPAAAN();
	}

	protected virtual OCCICIIEHEF BNBPAJLLFPI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ATTACK"), OBNJAIHEJOJ.InfoText);
	}

	protected virtual OCCICIIEHEF OIJBDMDPHGD()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ENVIRONMENTALKILL"), (OBNJAIHEJOJ)5);
	}

	protected virtual OCCICIIEHEF CNCKNEMOHJL()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ZoneHasIAPOffer"), OBNJAIHEJOJ.FulFill);
	}

	protected virtual OCCICIIEHEF HJHMLCPKGAB()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Corrected squad name for current player"), (OBNJAIHEJOJ)7);
	}

	public virtual bool APBOMMHMLBI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.HHNMDNLNPHH(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.MPNDBIBDOCD();
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WENEEDTO"));
	}

	public virtual bool APDCHBMJHEC()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.CLPEMLCLDIJ();
	}

	public virtual bool IHIGFGJMKDB()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.LPLPANBJDAM();
	}

	protected virtual OCCICIIEHEF MACMHJNLCKM()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player wants to join squad, name ="), OBNJAIHEJOJ.FulFill);
	}

	public virtual bool AKEHNCAPIDE()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.KJDMOCMBFLJ();
	}

	protected virtual OCCICIIEHEF FEDFLFMCOHG()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("(Landroid/os/Parcel;I)V"), (OBNJAIHEJOJ)5);
	}

	public virtual bool FBHCPDPGHFC()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.OAELLJPGBPC();
	}

	public virtual bool OBNNGDGICIK()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.BKNCIECHIKB(),
					GJNGLPOBFJI = true,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.BMLJPOEKNKB(mEquippedWeapons);
		return base.EDNAIMPLPGL();
	}

	public override bool CLPEMLCLDIJ()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.MPNDBIBDOCD();
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_VIPMEMBERSHIPALMOST_DESC"), (OBNJAIHEJOJ)5);
	}

	public virtual bool DHFOKAIJMDN()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.JNMJIMNBJNM(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.MPNDBIBDOCD();
	}

	public virtual bool EOPGNLCHNAA()
	{
		if (WarArena.instance.data.matches != mLastMatches || mEquippedWeapons == null || mEquippedWeapons.Length == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
			List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
			foreach (PlayerInventory.InventorySlot item in inventorySlots)
			{
				WeaponLevelsSetup randomInCategory = LevelManager.GetRandomInCategory(item.category);
				list.Add(new PlayerInventory.JIMOKIIJHNA
				{
					EPNKPKHCKNG = randomInCategory.indexInLevelManager,
					DGPAEJJENDP = randomInCategory.MGAGEKAAJOL.CGMKKNIHHMN(),
					GJNGLPOBFJI = false,
					FIPONKNHIAL = -1
				});
			}
			mEquippedWeapons = list.ToArray();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetWeapons(mEquippedWeapons);
		return base.DDFGIDBHJIK();
	}

	protected virtual OCCICIIEHEF GIGFFEIMCDL()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("02 "), OBNJAIHEJOJ.DoesNotMeet);
	}
}
