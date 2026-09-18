public class LevelUpUnlock
{
	public enum ItemType
	{
		None,
		UnitUnlock,
		WeaponUnlock,
		MapUnlock,
		WarpathUnlock,
		JoinSquadUnlock,
		CreateSquadUnlock,
		WarCardsUnlock,
		DogTagRefill,
		GoldReceived,
		InstantBattleUnlock,
		WarArenaUnlock
	}

	public ItemType type;

	public LevelBehaviour unit;

	public WeaponLevelsSetup weapon;

	public MapManager.MapEntry mapEntry;

	public int goldReward;

	public static LevelUpUnlock CreateGold(int gold)
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.GoldReceived;
		levelUpUnlock.goldReward = gold;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateDogTag()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.DogTagRefill;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateWarCards()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.WarCardsUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateSquadCreate()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.CreateSquadUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateSquadJoin()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.JoinSquadUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateWarpath()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.WarpathUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateMap(MapManager.MapEntry map)
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.MapUnlock;
		levelUpUnlock.mapEntry = map;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateWeapon(WeaponLevelsSetup setup)
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.WeaponUnlock;
		levelUpUnlock.weapon = setup;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateUnit(LevelBehaviour army)
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.UnitUnlock;
		levelUpUnlock.unit = army;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateInstantBattle()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.InstantBattleUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateWarArena()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.WarArenaUnlock;
		return levelUpUnlock;
	}

	public static LevelUpUnlock CreateEmpty()
	{
		LevelUpUnlock levelUpUnlock = new LevelUpUnlock();
		levelUpUnlock.type = ItemType.None;
		return levelUpUnlock;
	}
}
