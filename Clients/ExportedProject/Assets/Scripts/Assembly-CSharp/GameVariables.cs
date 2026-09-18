using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Google2u;
using UnityEngine;

public class GameVariables : Singleton<GameVariables>
{
	public const int challengeAcceptTime = 120;

	public const int rematchTime = 30;

	public const int maxTier = 6;

	public const float guiUpdateTextsTime = 0.333f;

	public const int playersInBeginnersLeague = 100;

	public const float weaponIconMultiplier = 1.1764706f;

	public static float durationOfNameButtonColor = 0.15f;

	public static Dictionary<League, Tuple<string, string>> leagueNames = new Dictionary<League, Tuple<string, string>>();

	public static Dictionary<SkillShot.SkillShotType, Tuple<string, string, string>> skillshotNames = new Dictionary<SkillShot.SkillShotType, Tuple<string, string, string>>();

	public static Dictionary<SquadRank, string> squadFunctions = new Dictionary<SquadRank, string>
	{
		{
			SquadRank.Member,
			"ID_MEMBER"
		},
		{
			SquadRank.Veteran,
			"ID_VETERAN"
		},
		{
			SquadRank.Coleader,
			"ID_COLEADER"
		},
		{
			SquadRank.Leader,
			"ID_LEADER"
		}
	};

	public static List<WeaponCategory> slotCategory = new List<WeaponCategory>
	{
		WeaponCategory.Primary,
		WeaponCategory.Special,
		WeaponCategory.Explosive,
		WeaponCategory.Pistol
	};

	public static Dictionary<WeaponCategory, string> weaponCategoryLowerSingularId = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.Primary,
			"ID_CATEGORY_LOW_SG_PRIMARY"
		},
		{
			WeaponCategory.AssaultRifle,
			"ID_CATEGORY_LOW_SG_ASSAULT"
		},
		{
			WeaponCategory.SMG,
			"ID_CATEGORY_LOW_SG_SMG"
		},
		{
			WeaponCategory.LMG,
			"ID_CATEGORY_LOW_SG_LMG"
		},
		{
			WeaponCategory.Special,
			"ID_CATEGORY_LOW_SG_SPECIAL"
		},
		{
			WeaponCategory.Minigun,
			"ID_CATEGORY_LOW_SG_MINIGUN"
		},
		{
			WeaponCategory.SniperRifle,
			"ID_CATEGORY_LOW_SG_SNIPER"
		},
		{
			WeaponCategory.Shotgun,
			"ID_CATEGORY_LOW_SG_SHOTGUN"
		},
		{
			WeaponCategory.Explosive,
			"ID_CATEGORY_LOW_SG_EXPLOSIVE"
		},
		{
			WeaponCategory.Grenade,
			"ID_CATEGORY_LOW_SG_GRENADE"
		},
		{
			WeaponCategory.RocketLauncher,
			"ID_CATEGORY_LOW_SG_ROCKET"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"ID_CATEGORY_LOW_SG_GRENADELAUNCHER"
		},
		{
			WeaponCategory.Pistol,
			"ID_CATEGORY_LOW_SG_HANDGUN"
		}
	};

	public static Dictionary<WeaponCategory, string> weaponCategoryLowerPluralId = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.Primary,
			"ID_CATEGORY_LOW_PL_PRIMARY"
		},
		{
			WeaponCategory.AssaultRifle,
			"ID_CATEGORY_LOW_PL_ASSAULT"
		},
		{
			WeaponCategory.SMG,
			"ID_CATEGORY_LOW_PL_SMG"
		},
		{
			WeaponCategory.LMG,
			"ID_CATEGORY_LOW_PL_LMG"
		},
		{
			WeaponCategory.Special,
			"ID_CATEGORY_LOW_PL_SPECIAL"
		},
		{
			WeaponCategory.Minigun,
			"ID_CATEGORY_LOW_PL_MINIGUN"
		},
		{
			WeaponCategory.SniperRifle,
			"ID_CATEGORY_LOW_PL_SNIPER"
		},
		{
			WeaponCategory.Shotgun,
			"ID_CATEGORY_LOW_PL_SHOTGUN"
		},
		{
			WeaponCategory.Explosive,
			"ID_CATEGORY_LOW_PL_EXPLOSIVE"
		},
		{
			WeaponCategory.Grenade,
			"ID_CATEGORY_LOW_PL_GRENADE"
		},
		{
			WeaponCategory.RocketLauncher,
			"ID_CATEGORY_LOW_PL_ROCKET"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"ID_CATEGORY_LOW_PL_GRENADELAUNCHER"
		},
		{
			WeaponCategory.Pistol,
			"ID_CATEGORY_LOW_PL_HANDGUN"
		}
	};

	public static Dictionary<WeaponCategory, string> weaponCategoryIdRental = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.AssaultRifle,
			"ID_RENTAL_ASSAULTRIFLE"
		},
		{
			WeaponCategory.SMG,
			"ID_RENTAL_SMG"
		},
		{
			WeaponCategory.LMG,
			"ID_RENTAL_LMG"
		},
		{
			WeaponCategory.Minigun,
			"ID_RENTAL_MINIGUN"
		},
		{
			WeaponCategory.SniperRifle,
			"ID_RENTAL_SNIPERRIFLE"
		},
		{
			WeaponCategory.Shotgun,
			"ID_RENTAL_SHOTGUN"
		},
		{
			WeaponCategory.Grenade,
			"ID_RENTAL_GRENADE"
		},
		{
			WeaponCategory.RocketLauncher,
			"ID_RENTAL_ROCKETLAUNCHER"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"ID_RENTAL_GRENADELAUNCHER"
		},
		{
			WeaponCategory.Pistol,
			"ID_RENTAL_PISTOL"
		}
	};

	public static Dictionary<WeaponCategory, string> weaponCategoryIdWeaponScreen = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.AssaultRifle,
			"ID_CATEGORY_ASSAULTRIFLE"
		},
		{
			WeaponCategory.SMG,
			"ID_CATEGORY_SMG"
		},
		{
			WeaponCategory.LMG,
			"ID_CATEGORY_LMG"
		},
		{
			WeaponCategory.Minigun,
			"ID_CATEGORY_MINIGUN"
		},
		{
			WeaponCategory.SniperRifle,
			"ID_CATEGORY_SNIPERRIFLE"
		},
		{
			WeaponCategory.Shotgun,
			"ID_CATEGORY_SHOTGUN"
		},
		{
			WeaponCategory.Grenade,
			"ID_CATEGORY_GRENADE"
		},
		{
			WeaponCategory.RocketLauncher,
			"ID_CATEGORY_ROCKETLAUNCHER"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"ID_CATEGORY_GRENADELAUNCHER"
		},
		{
			WeaponCategory.Pistol,
			"ID_CATEGORY_PISTOL"
		}
	};

	public static Dictionary<LevelBehaviour.UnitType, Tuple<string, string, string, string>> unitType = new Dictionary<LevelBehaviour.UnitType, Tuple<string, string, string, string>>
	{
		{
			LevelBehaviour.UnitType.Defender,
			new Tuple<string, string, string, string>("ID_UNITTYPE1", "menu-army-cat-defender", "ID_UNITTYPE1-DESCRIPTION", "ID_UNITTYPE1-HUD")
		},
		{
			LevelBehaviour.UnitType.AttackerExplosive,
			new Tuple<string, string, string, string>("ID_UNITTYPE2", "menu-army-cat-explosive", "ID_UNITTYPE2-DESCRIPTION", "ID_UNITTYPE2-HUD")
		},
		{
			LevelBehaviour.UnitType.AttackerShooter,
			new Tuple<string, string, string, string>("ID_UNITTYPE3", "menu-army-cat-shooter", "ID_UNITTYPE3-DESCRIPTION", "ID_UNITTYPE3-HUD")
		},
		{
			LevelBehaviour.UnitType.AttackerRusher,
			new Tuple<string, string, string, string>("ID_UNITTYPE4", "menu-army-cat-rusher", "ID_UNITTYPE4-DESCRIPTION", "ID_UNITTYPE4-HUD")
		}
	};

	public static Dictionary<LevelBehaviour.UnitType, Tuple<string, Color>> unitCategory = new Dictionary<LevelBehaviour.UnitType, Tuple<string, Color>>
	{
		{
			LevelBehaviour.UnitType.Defender,
			new Tuple<string, Color>("menu-army-cat-defender", Colours.defender)
		},
		{
			LevelBehaviour.UnitType.AttackerExplosive,
			new Tuple<string, Color>("menu-army-cat-explosive", Colours.explosive)
		},
		{
			LevelBehaviour.UnitType.AttackerShooter,
			new Tuple<string, Color>("menu-army-cat-shooter", Colours.shooter)
		},
		{
			LevelBehaviour.UnitType.AttackerRusher,
			new Tuple<string, Color>("menu-army-cat-rusher", Colours.rusher)
		}
	};

	public static Dictionary<string, string> weaponStatisticsIcon = new Dictionary<string, string>
	{
		{ "ID_SLOTUPGRADE_AMMO", "menu-army-ammo-ico" },
		{ "ID_SLOTUPGRADE_CLIP_SIZE", "menu-army-ammo-ico" },
		{ "ID_SLOTUPGRADE_ROF", "menu-army-reload-ico" },
		{ "ID_SLOTUPGRADE_HEAT", "menu-army-reload-ico" },
		{ "ID_SLOTUPGRADE_POWER", "menu-army-power-ico" },
		{ "ID_SLOTUPGRADE_DAMAGE", "menu-attack-ico" }
	};

	public static Dictionary<CardPack, Tuple<string, string>> cardpackLook = new Dictionary<CardPack, Tuple<string, string>>
	{
		{
			CardPack.None,
			new Tuple<string, string>(string.Empty, "game-card-silver")
		},
		{
			CardPack.Bronze,
			new Tuple<string, string>("ID_BRONZE", "menu-cards-bronzepack")
		},
		{
			CardPack.Silver,
			new Tuple<string, string>("ID_SILVER", "menu-cards-silverpack")
		},
		{
			CardPack.Gold,
			new Tuple<string, string>("ID_GOLDC", "menu-cards-goldpack")
		},
		{
			CardPack.Starter,
			new Tuple<string, string>("ID_STARTER", "menu-startervalue")
		},
		{
			CardPack.Value,
			new Tuple<string, string>("ID_VALUE", "menu-startervalue")
		}
	};

	public static Dictionary<CardManager.CardType, string> warcardName = new Dictionary<CardManager.CardType, string>
	{
		{
			CardManager.CardType.Bronze,
			"ID_BRONZE"
		},
		{
			CardManager.CardType.Silver,
			"ID_SILVER"
		},
		{
			CardManager.CardType.Gold,
			"ID_GOLDC"
		}
	};

	public static Dictionary<PlayerStatus, Tuple<string, Color>> playerStatus = new Dictionary<PlayerStatus, Tuple<string, Color>>
	{
		{
			PlayerStatus.Online,
			new Tuple<string, Color>("ID_ONLINE", Colours.greenOnline)
		},
		{
			PlayerStatus.InGame,
			new Tuple<string, Color>("ID_PLAYING", Colours.yellowPlaying)
		},
		{
			PlayerStatus.Offline,
			new Tuple<string, Color>("ID_OFFLINE", Colours.gray)
		}
	};

	public static Dictionary<int, string> noWarCardsDictionary = new Dictionary<int, string>
	{
		{ 0, "ID_YOUHAVENOWARCARDSAVAILABLE" },
		{ 1, "ID_YOUHAVENOBRONZEWARCARDSAVAILABLE" },
		{ 2, "ID_YOUHAVENOSILVERWARCARDSAVAILABLE" },
		{ 3, "ID_YOUHAVENOGOLDWARCARDSAVAILABLE" },
		{ 4, "ID_YOUHAVENOBUDDYWARCARDSAVAILABLE" }
	};

	public static Dictionary<string, string> countryCodes = new Dictionary<string, string>
	{
		{ "AR", "country-argentinia" },
		{ "AU", "country-australia" },
		{ "AT", "country-austria" },
		{ "BE", "country-belgium" },
		{ "BR", "country-brazil" },
		{ "BG", "country-bulgaria" },
		{ "BY", "country-belarus" },
		{ "CA", "country-canada" },
		{ "CL", "country-chile" },
		{ "CN", "country-china" },
		{ "HR", "country-croatia" },
		{ "CZ", "country-czech-republic" },
		{ "DK", "country-danmark" },
		{ "EG", "country-egypt" },
		{ "UK", "country-england" },
		{ "EE", "country-estonia" },
		{ "FI", "country-finland" },
		{ "FR", "country-france" },
		{ "DE", "country-germany" },
		{ "GR", "country-greece" },
		{ "HK", "country-hong-kong" },
		{ "HU", "country-hungaria" },
		{ "IN", "country-india" },
		{ "ID", "country-indonesia" },
		{ "IE", "country-ireland" },
		{ "IT", "country-italy" },
		{ "IL", "country-israel" },
		{ "JP", "country-japan" },
		{ "LV", "country-latvia" },
		{ "LT", "country-lithuania" },
		{ "MY", "country-malaysia" },
		{ "MX", "country-mexico" },
		{ "NL", "country-netherlands" },
		{ "NZ", "country-new-zealand" },
		{ "NO", "country-norway" },
		{ "PH", "country-philippines" },
		{ "PL", "country-poland" },
		{ "PT", "country-portugal" },
		{ "RO", "country-romania" },
		{ "RU", "country-russia" },
		{ "SA", "country-saudi-arabia" },
		{ "SK", "country-slovakia" },
		{ "SI", "country-slovenia" },
		{ "ZA", "country-south-africa" },
		{ "KR", "country-south-korea" },
		{ "ES", "country-spain" },
		{ "SE", "country-sweden" },
		{ "CH", "country-switzerland" },
		{ "TW", "country-taiwan" },
		{ "TH", "country-thailand" },
		{ "TR", "country-turkey" },
		{ "UA", "country-ukraine" },
		{ "GB", "country-united-kingdom" },
		{ "US", "country-USA" },
		{ "VN", "country-vietnam" }
	};

	public static Dictionary<Mission.MissionType, Tuple<string, string>> missionDialogTranslationIds = new Dictionary<Mission.MissionType, Tuple<string, string>>
	{
		{
			Mission.MissionType.Elimination,
			new Tuple<string, string>("ID_MISSION_ELIMINATION", "ID_MISSION_ELIMINATION_TASK")
		},
		{
			Mission.MissionType.Survive,
			new Tuple<string, string>("ID_MISSION_SURVIVAL", "ID_MISSION_SURVIVAL_TASK")
		},
		{
			Mission.MissionType.Boss,
			new Tuple<string, string>("ID_MISSION_BOSSFIGHT", "ID_MISSION_BOSSFIGHT_TASK")
		},
		{
			Mission.MissionType.Score,
			new Tuple<string, string>("ID_MISSION_SCOREHUNT", "ID_MISSION_SCOREHUNT_TASK")
		}
	};

	public static Dictionary<PlayerVisual.Rarity, Color> rarityColours = new Dictionary<PlayerVisual.Rarity, Color>
	{
		{
			PlayerVisual.Rarity.Common,
			Colours.rarityCommon
		},
		{
			PlayerVisual.Rarity.Uncommon,
			Colours.rarityUncommon
		},
		{
			PlayerVisual.Rarity.Rare,
			Colours.rarityRare
		},
		{
			PlayerVisual.Rarity.Epic,
			Colours.rarityEpic
		},
		{
			PlayerVisual.Rarity.Legendary,
			Colours.rarityLegendary
		}
	};

	public static Dictionary<WarArenaCrown, string> crownSprites = new Dictionary<WarArenaCrown, string>
	{
		{
			WarArenaCrown.None,
			string.Empty
		},
		{
			WarArenaCrown.BronzeCrown,
			"menu-crown-bronze"
		},
		{
			WarArenaCrown.SilverCrown,
			"menu-crown-silver"
		},
		{
			WarArenaCrown.GoldCrown,
			"menu-crown-gold"
		},
		{
			WarArenaCrown.Flawless,
			"menu-arena-flawless-ico"
		}
	};

	public string starterpackABtestingName = string.Empty;

	public string valuePackABtestingName = string.Empty;

	public string moneyPackABtestingName = string.Empty;

	private Squads mSquads;

	private BalanceTable mBalanceTable;

	private Constants mConstants;

	private Versions mVersions;

	private HeroicRewards mHeroicRewards;

	private MatchMakingDeviation mMatchmakingDeviations;

	private BonussesDefinitions mBonussesDefinitions;

	private CardConstants mCardConstants;

	private MatchMakingConstants mMatchMakingConstants;

	private InApps mInApps;

	private CardPacks mCardPacks;

	private VIP mVip;

	private PlayerLeaderboards mPlayerLeaderboardsDefinitions;

	private Packs mPacks;

	private SquadEmblems mSquadEmblems;

	private StringConstants mStringConstants;

	private UnitsContants mUnitsConstants;

	private CountryInfo mCountryInfo;

	private SquadLeaderboards mSquadLeaderboards;

	private SquadWarsReward mSquadWarsReward;

	private Lootboxes mLootboxes;

	private SpecialPackContent mStarterPack;

	private SpecialPackContent mValuePack;

	private SpecialPackContent mMoneyPack;

	public static int matchStartTime => (!LevelManager.instance.isWarcardsLocked) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.CardsChoosingTime).FLOATVALUE) : 5;

	public static string iOSAppStoreURL => "https://itunes.apple.com/app/warfriends/id" + Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.AppID).VALUE;

	public static string GooglePlayMarketURL => $"market://details?id={BundleVersionBindings.BundleID}";

	public static int lowFacebookFriends => 5;

	public bool isiPadResolution
	{
		get
		{
			float num = 1.3333334f;
			float max = 1.7777778f;
			float num2 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num, max);
			return num2 <= num + 0.001f;
		}
	}

	public CardPacks cardPacks => mCardPacks ?? (mCardPacks = GetComponent<CardPacks>());

	public VIP vip => mVip ?? (mVip = GetComponent<VIP>());

	public InApps inApps => mInApps ?? (mInApps = GetComponent<InApps>());

	public BalanceTable balancetable => mBalanceTable ?? (mBalanceTable = GetComponent<BalanceTable>());

	public CountryInfo countryInfo => mCountryInfo ?? (mCountryInfo = GetComponent<CountryInfo>());

	public Squads squads => mSquads ?? (mSquads = GetComponent<Squads>());

	public Constants constants => mConstants ?? (mConstants = GetComponent<Constants>());

	public bool isInstantBattleEnabled => 1 == (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleEnabled).FLOATVALUE;

	public UnitsContants unitsConstants => mUnitsConstants ?? (mUnitsConstants = GetComponent<UnitsContants>());

	public Versions versions => mVersions ?? (mVersions = GetComponent<Versions>());

	public HeroicRewards heroicRewards => mHeroicRewards ?? (mHeroicRewards = GetComponent<HeroicRewards>());

	public MatchMakingDeviation matchmakingDeviations => mMatchmakingDeviations ?? (mMatchmakingDeviations = GetComponent<MatchMakingDeviation>());

	public StringConstants stringConstants => mStringConstants ?? (mStringConstants = GetComponent<StringConstants>());

	public BonussesDefinitions bonussesDefinitions => mBonussesDefinitions ?? (mBonussesDefinitions = GetComponent<BonussesDefinitions>());

	public CardConstants cardConstants => mCardConstants ?? (mCardConstants = GetComponent<CardConstants>());

	public MatchMakingConstants matchMakingConstants => mMatchMakingConstants ?? (mMatchMakingConstants = GetComponent<MatchMakingConstants>());

	public PlayerLeaderboards playerLeaderboards => mPlayerLeaderboardsDefinitions ?? (mPlayerLeaderboardsDefinitions = Singleton<BeanstalkServerManager>.instance.GetComponent<PlayerLeaderboards>());

	public Packs packsDefinition => mPacks ?? (mPacks = Singleton<BeanstalkServerManager>.instance.GetComponent<Packs>());

	public SpecialPackContent starterPack
	{
		get
		{
			if (mStarterPack == null)
			{
				mStarterPack = SpecialPackContent.CreatePackFromId(PackId(CardPack.Starter));
			}
			return mStarterPack;
		}
	}

	public SpecialPackContent valuePack
	{
		get
		{
			if (mValuePack == null)
			{
				mValuePack = SpecialPackContent.CreatePackFromId(PackId(CardPack.Value));
			}
			return mValuePack;
		}
	}

	public SpecialPackContent moneyPack
	{
		get
		{
			if (mMoneyPack == null)
			{
				mMoneyPack = SpecialPackContent.CreatePackFromId(PackId(CardPack.Money));
			}
			return mMoneyPack;
		}
	}

	public SquadEmblems squadEmblems => mSquadEmblems ?? (mSquadEmblems = GetComponent<SquadEmblems>());

	public SquadLeaderboards squadLeaderboards => mSquadLeaderboards ?? (mSquadLeaderboards = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadLeaderboards>());

	public SquadWarsReward squadWarsReward => mSquadWarsReward ?? (mSquadWarsReward = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadWarsReward>());

	public Lootboxes lootboxes => mLootboxes ?? (mLootboxes = GetComponent<Lootboxes>());

	public float maxMatchmakingTime => matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MaxMatchMakingTimeAndroid).FLOATVALUE;

	public static int GetMatchStartTime(int forLevel)
	{
		return (LevelManager.instance.warcardsUnlockLevel <= forLevel) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.CardsChoosingTime).FLOATVALUE) : 5;
	}

	public string GetWeaponCategoryId(WeaponCategory category, StringCase stringCase = StringCase.LowerCase, StringCount stringCount = StringCount.Singular)
	{
		if (!weaponCategoryLowerSingularId.ContainsKey(category))
		{
			return string.Empty;
		}
		bool flag = stringCase == StringCase.LowerCase;
		if (stringCount == StringCount.Singular)
		{
			return (!flag) ? weaponCategoryLowerSingularId[category].ToUpper() : weaponCategoryLowerSingularId[category];
		}
		return (!flag) ? weaponCategoryLowerPluralId[category].ToUpper() : weaponCategoryLowerPluralId[category];
	}

	public static string CountryCodeSpriteName(string cc)
	{
		if (string.IsNullOrEmpty(cc))
		{
			return "country-noflag";
		}
		return (!countryCodes.ContainsKey(cc.ToUpper())) ? "country-noflag" : countryCodes[cc.ToUpper()];
	}

	public long SquadExperience(int squadDisplayLevel)
	{
		int index = Mathf.Clamp(squadDisplayLevel - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].EXPERIENCE;
	}

	public int GetSquadRankSize(int squadDisplayLevel)
	{
		int index = Mathf.Clamp(squadDisplayLevel - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].SIZE;
	}

	public int GetNextSquadRankIncreaseSize(int squadDisplayLevel)
	{
		int num = Mathf.Clamp(squadDisplayLevel - 1, 0, squads.Rows.Count - 1);
		int sIZE = squads.Rows[num].SIZE;
		for (int i = num; i < squads.Rows.Count; i++)
		{
			if (sIZE < squads.Rows[i].SIZE)
			{
				return squads.Rows[i].LEVEL;
			}
		}
		return -1;
	}

	public int MaxSquadDisplayLevel()
	{
		return squads.Rows[squads.Rows.Count - 1].LEVEL;
	}

	public int MaxSquadSize()
	{
		return squads.Rows[squads.Rows.Count - 1].SIZE;
	}

	public int SquadCardpoolSize(int squadDisplayLevel)
	{
		int index = Mathf.Clamp(squadDisplayLevel - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].CARDPOOLSIZE;
	}

	public float LeagueProgress(League league)
	{
		return (float)league / 16f;
	}

	public float LeagueGoUpPercent(League league)
	{
		return (league != League.NoLeague) ? playerLeaderboards.Rows[(int)(league - 1)].GOUP : 0f;
	}

	public float LeagueGoDownPercent(League league)
	{
		return (league != League.NoLeague) ? playerLeaderboards.Rows[(int)(league - 1)].GODOWN : 0f;
	}

	public int MedalsWarbucksBonusLeague(League actualLeague)
	{
		return (actualLeague != League.NoLeague) ? playerLeaderboards.Rows[(int)(actualLeague - 1)].REWARDWARBUCKS : 0;
	}

	public int GoldRewardForTopInNotEnoughtPlayersLeague(League actualLeague)
	{
		return (actualLeague != League.NoLeague) ? playerLeaderboards.Rows[(int)(actualLeague - 1)].NOTENOUGHTPLAYERSGOLDREWARD : 0;
	}

	public int MedalsSquadPointsBonusLeague(League actualLeague)
	{
		return (actualLeague != League.NoLeague) ? playerLeaderboards.Rows[(int)(actualLeague - 1)].REWARDSQUADPOINTS : 0;
	}

	public string BeginnersLeagueName(int beginnersNumber)
	{
		switch (beginnersNumber)
		{
			case 1:
				return Localization.Localize("ID_BEGINNERSLEAGUE3");
			case 2:
				return Localization.Localize("ID_BEGINNERSLEAGUE2");
			case 3:
				return Localization.Localize("ID_BEGINNERSLEAGUE1");
			default:
				return leagueNames[League.Bronze3].Value1;
		}
	}

	public string BeginnersLeagueIcon(int beginnersNumber)
	{
		switch (beginnersNumber)
		{
			case 1:
				return "rookie3";
			case 2:
				return "rookie2";
			case 3:
				return "rookie1";
			default:
				return "bronze3";
		}
	}

	public int BeginnersLeagueMaxMedals(int beginnersNumber)
	{
		string vALUE = stringConstants.GetRow(StringConstants.rowIds.BeginnersLeagues).VALUE;
		int num = vALUE.IndexOf($"\"{beginnersNumber}\"");
		int result = 0;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf(":", num);
			int num3 = vALUE.IndexOf(",", num2) - 1;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 2) : num3);
			string s = vALUE.Substring(num2 + 1, num4 - num2);
			int.TryParse(s, out result);
		}
		return result;
	}

	public int BeginnersLeagueRewards(int beginnersNumber, bool squadPoints = true)
	{
		string vALUE = stringConstants.GetRow(StringConstants.rowIds.BeginnersRewards).VALUE;
		int num = vALUE.IndexOf($"\"{beginnersNumber}\"");
		int result = 0;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf((!squadPoints) ? "wb\":" : "sp\":", num) + 4;
			int num3 = vALUE.IndexOf((!squadPoints) ? "," : "}", num2) - 1;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 3) : num3);
			string text = vALUE.Substring(num2, num4 - num2 + 1);
			text.Trim();
			int.TryParse(text, out result);
		}
		return result;
	}

	public LeagueType LeaguePositionType(bool lowPlayers, League leagueTier, int positionInPlayersLeague, int positionPromote, int positionDemote)
	{
		if (lowPlayers || positionInPlayersLeague < 1)
		{
			return LeagueType.Stay;
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier) > 0f))
		{
			return (positionInPlayersLeague >= positionDemote) ? LeagueType.Demote : LeagueType.Top;
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier) > 0f))
		{
			return (positionInPlayersLeague <= positionPromote) ? LeagueType.Promote : LeagueType.Stay;
		}
		return (positionInPlayersLeague <= positionPromote) ? LeagueType.Promote : ((positionInPlayersLeague >= positionDemote) ? LeagueType.Demote : LeagueType.Stay);
	}

	public Color LeagueColorHighlight(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			case LeagueType.Top:
				return Colours.yellowLeague;
			default:
				return Colours.blue;
		}
	}

	public Color LeagueColorPosition(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			case LeagueType.Top:
				return Colours.yellowLeague;
			default:
				return Colours.blue;
		}
	}

	public Color LeagueColorBackground(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			default:
				return Color.white;
		}
	}

	public Color LeagueColorMedals(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			case LeagueType.Top:
				return Colours.yellowLeague;
			default:
				return Color.white;
		}
	}

	public Color LeaguePositionColor(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			case LeagueType.Top:
				return Colours.yellowLeague;
			default:
				return Colours.grayMedium;
		}
	}

	public Color LeaguePositionColorLeagueRecord(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeague;
			case LeagueType.Demote:
				return Colours.redLeague;
			case LeagueType.Top:
				return Colours.yellowLeague;
			default:
				return Color.white;
		}
	}

	public Color LeaguePositionColorLeagueRecordBg(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenLeagueBg;
			case LeagueType.Demote:
				return Colours.redLeagueBg;
			case LeagueType.Top:
				return Colours.goldLeagueBg;
			default:
				return Colours.grayLeagueBg;
		}
	}

	public int LeaguePositionPromote(int count, League league)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(league);
		int num2 = Mathf.RoundToInt(num * 100f);
		int num3 = Mathf.CeilToInt((float)(count * num2) / 100f);
		return (!(num > 0f)) ? (-1) : num3;
	}

	public int LeaguePositionDemote(int count, League league)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(league);
		int num2 = Mathf.RoundToInt(num * 100f);
		int num3 = Mathf.CeilToInt((float)(count * num2) / 100f);
		return (!(num > 0f)) ? 101 : ((count <= 1) ? 101 : (count + 1 - num3));
	}

	public string PackId(CardPack packName)
	{
		return GetPackRow(packName).NAME;
	}

	public int GetPackGold(string packId)
	{
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(packId) < 0)
		{
			return 0;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(packId);
		return row.GOLD;
	}

	public int GetPackWarbucks(string packId)
	{
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(packId) < 0)
		{
			return 0;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(packId);
		return row.WARBUCKS;
	}

	public int numberOfGoldCards(CardPack packName)
	{
		if (packName == CardPack.Starter || packName == CardPack.Value)
		{
			return GetPackRow(packName).GOLDCARDS;
		}
		return 0;
	}

	public int numberOfSilverCards(CardPack packName)
	{
		if (packName == CardPack.Starter || packName == CardPack.Value)
		{
			return GetPackRow(packName).SILVERCARDS;
		}
		return 0;
	}

	public string packVisuals(CardPack packName)
	{
		if (packName == CardPack.Starter || packName == CardPack.Value)
		{
			return GetPackRow(packName).PLAYERVISUALS;
		}
		return string.Empty;
	}

	public Tuple<float, string> PriceOfPack(CardPack packName)
	{
		return Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(GetPackRow(packName).NAME);
	}

	public string StoreCountryCode(CardPack packName)
	{
		return Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemCountryCode(GetPackRow(packName).NAME);
	}

	public Tuple<float, string> RegularPriceOfPack(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return RegularPriceOfPack(packRow.SALE, GetPackRow(packName).NAME);
	}

	public Tuple<float, string> RegularPriceOfPack(float sale, string id)
	{
		Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(id);
		string itemCountryCode = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemCountryCode(id);
		string cultureInfo = GetCultureInfo(itemCountryCode);
		bool flag = Regex.IsMatch(itemPrice.Value2, "^[^0-9\\.\\,].*$");
		string text = Regex.Replace(itemPrice.Value2, "[0-9\\.\\,]*", string.Empty);
		itemPrice.Value1 /= 1f - sale;
		itemPrice.Value1 = Mathf.Ceil(itemPrice.Value1);
		string text2 = ((!(itemPrice.Value1 > 0f)) ? string.Empty : itemPrice.Value1.ToString("N2", new CultureInfo(cultureInfo)));
		if (flag)
		{
			itemPrice.Value2 = text + text2;
		}
		else
		{
			itemPrice.Value2 = text2 + text;
		}
		return itemPrice;
	}

	public string GetCultureInfo(string iStoreCountryCode)
	{
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
		foreach (CultureInfo cultureInfo in cultures)
		{
			if (cultureInfo.ToString().Substring(3).Equals(iStoreCountryCode))
			{
				return cultureInfo.ToString();
			}
		}
		return "en-US";
	}

	public int VipTimeSeconds(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return packRow.VIPSECONDS;
	}

	public float SaleOfPack(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return Mathf.Clamp01(packRow.SALE);
	}

	public float SaleOfPack(string packId)
	{
		PacksRow row = packsDefinition.GetRow(packId);
		return (row != null) ? Mathf.Clamp01(row.SALE) : 0f;
	}

	public int GoldOfPack(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return packRow.GOLD;
	}

	public int WarbucksOfPack(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return packRow.WARBUCKS;
	}

	public int VipSecondsOfPack(CardPack packName)
	{
		PacksRow packRow = GetPackRow(packName);
		return packRow.VIPSECONDS;
	}

	public int CardPackWarbucks(CardPack packName)
	{
		CardPacksRow cardPackRow = GetCardPackRow(packName);
		return cardPackRow.WARBUCKS;
	}

	public int CardPackGold(CardPack packName)
	{
		CardPacksRow cardPackRow = GetCardPackRow(packName);
		return cardPackRow.GOLD;
	}

	public CardPacksRow GetCardPackRow(CardPack packName)
	{
		switch (packName)
		{
			case CardPack.Gold:
				return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.GOLD_CARDPACK);
			case CardPack.Silver:
				return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK);
			default:
				return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		}
	}

	public PacksRow GetPackRow(CardPack packName)
	{
		switch (packName)
		{
		case CardPack.Starter:
			if (!string.IsNullOrEmpty(starterpackABtestingName))
			{
				PacksRow row3 = packsDefinition.GetRow(starterpackABtestingName);
				if (row3 != null)
				{
					return row3;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.starterpack);
		case CardPack.Value:
			if (!string.IsNullOrEmpty(valuePackABtestingName))
			{
				PacksRow row2 = packsDefinition.GetRow(valuePackABtestingName);
				if (row2 != null)
				{
					return row2;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.valuepack);
		default:
			if (!string.IsNullOrEmpty(moneyPackABtestingName))
			{
				PacksRow row = packsDefinition.GetRow(moneyPackABtestingName);
				if (row != null)
				{
					return row;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.moneypack1);
		}
	}

	public void PowerBandInPack(string xslCell, ref PlayerVisual powerBand, ref int seconds)
	{
		string[] array = xslCell.Split(',');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Split(':').Length >= 3)
			{
				string[] array3 = text.Split(':');
				int num = array3[0].IndexOf('"') + 1;
				int num2 = array3[0].LastIndexOf('"');
				powerBand = CamosManager.instance.GetPowerBand(array3[0].Substring(num, num2 - num));
				seconds = Convert.ToInt32(array3[2].Substring(1, array3[2].IndexOf('}') - 1));
			}
		}
	}

	public PlayerVisual[] PlayerVisualsInPack(string xslCell)
	{
		string[] array = xslCell.Split(',');
		int num = 0;
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Split(':').Length <= 2)
			{
				int num2 = text.IndexOf('"') + 1;
				int num3 = text.LastIndexOf('"');
				if (num2 > 0 && num3 > num2)
				{
					num++;
				}
			}
		}
		PlayerVisual[] array3 = new PlayerVisual[num];
		num = 0;
		string[] array4 = array;
		foreach (string text2 in array4)
		{
			if (text2.Split(':').Length <= 2)
			{
				int num4 = text2.IndexOf('"') + 1;
				int num5 = text2.LastIndexOf('"');
				if (num4 > 0 && num5 > num4)
				{
					array3[num] = CamosManager.instance.GetVisual(text2.Substring(num4, num5 - num4));
					num++;
				}
			}
		}
		return array3;
	}

	public LevelBehaviour UnitInPack(string xslCell)
	{
		int num = xslCell.IndexOf('"') + 1;
		int num2 = xslCell.LastIndexOf('"');
		return (num >= num2) ? null : LevelManager.instance.Unit(xslCell.Substring(num, num2 - num));
	}

	public WeaponLevelsSetup WeaponInPack(string xslCell)
	{
		int num = xslCell.IndexOf('"') + 1;
		int num2 = xslCell.LastIndexOf('"');
		return (num >= num2) ? null : LevelManager.instance.Weapon(xslCell.Substring(num, num2 - num));
	}

	public string[] CustomizationIdsFromPack(string xslCell)
	{
		string[] array = xslCell.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			int num = array2[0].IndexOf('"') + 1;
			int num2 = array2[0].LastIndexOf('"');
			if (num > 0 && num2 > num)
			{
				array[i] = array2[0].Substring(num, num2 - num);
			}
			else
			{
				array[i] = string.Empty;
			}
		}
		return array;
	}

	public string SquadEmblemUnlockedOnLevel(int displayLevel)
	{
		for (int i = 0; i < squadEmblems.Rows.Count; i++)
		{
			if (displayLevel == squadEmblems.Rows[i].UNLOCKLEVEL)
			{
				return squadEmblems.Rows[i].ICONNAME;
			}
		}
		return string.Empty;
	}

	public float GetSquadMedalWeight(int position)
	{
		if (position < 8)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight1).FLOATVALUE;
		}
		if (position < 16)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight2).FLOATVALUE;
		}
		if (position < 24)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight3).FLOATVALUE;
		}
		if (position < 32)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight4).FLOATVALUE;
		}
		if (position < 40)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight5).FLOATVALUE;
		}
		return constants.GetRow(Constants.rowIds.SquadMedalWeight6).FLOATVALUE;
	}

	public int ReputationPointsForWarcard(CardManager.CardType rarity)
	{
		switch (rarity)
		{
			case CardManager.CardType.Buddy:
				return (int)cardConstants.GetRow(CardConstants.rowIds.RepPointsBuddyCard).FLOATVALUE;
			case CardManager.CardType.Gold:
				return (int)cardConstants.GetRow(CardConstants.rowIds.RepPointsGoldCard).FLOATVALUE;
			case CardManager.CardType.Silver:
				return (int)cardConstants.GetRow(CardConstants.rowIds.RepPointsSilverCard).FLOATVALUE;
			default:
				return (int)cardConstants.GetRow(CardConstants.rowIds.RepPointsBronzeCard).FLOATVALUE;
		}
	}

	public int SquadWarsRewardForMember(int tier, int division, int memberPosition)
	{
		if (tier == 0)
		{
			return 0;
		}
		int index = Mathf.Clamp(division - 1, 0, squadLeaderboards.Rows.Count);
		int num = 0;
		switch (tier)
		{
		case 1:
			num = squadLeaderboards.Rows[index].Get_TIER1REWARD;
			break;
		case 2:
			num = squadLeaderboards.Rows[index].Get_TIER2REWARD;
			break;
		case 3:
			num = squadLeaderboards.Rows[index].Get_TIER3REWARD;
			break;
		case 4:
			num = squadLeaderboards.Rows[index].Get_TIER4REWARD;
			break;
		case 5:
			num = squadLeaderboards.Rows[index].Get_TIER5REWARD;
			break;
		}
		if (memberPosition < 2)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		}
		if (memberPosition < 6)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (memberPosition < 11)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_2).FRACTION);
		}
		if (memberPosition < 20)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_3).FRACTION);
		}
		if (memberPosition < 30)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_4).FRACTION);
		}
		if (memberPosition < 41)
		{
			return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_5).FRACTION);
		}
		return MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_6).FRACTION);
	}

	public int SquadWarsRewardForSquad(int tier, int division)
	{
		int index = Mathf.Clamp(division - 1, 0, squadLeaderboards.Rows.Count);
		int num = 0;
		switch (tier)
		{
		case 1:
			num = squadLeaderboards.Rows[index].Get_TIER1REWARD;
			break;
		case 2:
			num = squadLeaderboards.Rows[index].Get_TIER2REWARD;
			break;
		case 3:
			num = squadLeaderboards.Rows[index].Get_TIER3REWARD;
			break;
		case 4:
			num = squadLeaderboards.Rows[index].Get_TIER4REWARD;
			break;
		case 5:
			num = squadLeaderboards.Rows[index].Get_TIER5REWARD;
			break;
		}
		if (num == 0)
		{
			return 0;
		}
		int num2 = MiscTools.RoundToInt((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		int num3 = MiscTools.RoundToInt(4f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_1).FRACTION));
		int num4 = MiscTools.RoundToInt(5f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_2).FRACTION));
		int num5 = MiscTools.RoundToInt(9f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_3).FRACTION));
		int num6 = MiscTools.RoundToInt(10f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_4).FRACTION));
		int num7 = MiscTools.RoundToInt(11f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_5).FRACTION));
		int num8 = MiscTools.RoundToInt((float)(MaxSquadSize() - 40) * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_6).FRACTION));
		return num2 + num3 + num4 + num5 + num6 + num7 + num8;
	}

	public float SquadWarPromoteConstant(int division)
	{
		int index = Mathf.Clamp(division - 1, 0, squadLeaderboards.Rows.Count);
		return squadLeaderboards.Rows[index].GOUPPERCENTAGE;
	}

	public float SquadWarDemoteConstant(int division)
	{
		int index = Mathf.Clamp(division - 1, 0, squadLeaderboards.Rows.Count);
		return squadLeaderboards.Rows[index].GODOWNPERCENTAGE;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded -= ClearCache;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += ClearCache;
		leagueNames.Add(League.NoLeague, new Tuple<string, string>(Localization.Localize("ID_LEAGUE0"), "bronze3"));
		leagueNames.Add(League.Bronze3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE1"), "bronze3"));
		leagueNames.Add(League.Bronze2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE2"), "bronze2"));
		leagueNames.Add(League.Bronze1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE3"), "bronze1"));
		leagueNames.Add(League.Silver3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE4"), "silver3"));
		leagueNames.Add(League.Silver2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE5"), "silver2"));
		leagueNames.Add(League.Silver1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE6"), "silver1"));
		leagueNames.Add(League.Gold3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE7"), "gold3"));
		leagueNames.Add(League.Gold2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE8"), "gold2"));
		leagueNames.Add(League.Gold1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE9"), "gold1"));
		leagueNames.Add(League.Elite3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE10"), "elite3"));
		leagueNames.Add(League.Elite2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE11"), "elite2"));
		leagueNames.Add(League.Elite1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE12"), "elite1"));
		leagueNames.Add(League.Master3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE13"), "master3"));
		leagueNames.Add(League.Master2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE14"), "master2"));
		leagueNames.Add(League.Master1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE15"), "master1"));
		leagueNames.Add(League.Champion, new Tuple<string, string>(Localization.Localize("ID_LEAGUE16"), "champion"));
		skillshotNames.Add(SkillShot.SkillShotType.HeadShot, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_HEADSHOTS"), Localization.Localize("ID_RIBBON_HEADSHOT"), Localization.Localize("ID_SKILLSHOTHINT_HEADSHOT")));
		skillshotNames.Add(SkillShot.SkillShotType.Runner, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_RUNNERS"), Localization.Localize("ID_RIBBON_RUNNER"), Localization.Localize("ID_SKILLSHOTHINT_RUNNER")));
		skillshotNames.Add(SkillShot.SkillShotType.LongShot, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_LONGSHOTS"), Localization.Localize("ID_RIBBON_LONGSHOT"), Localization.Localize("ID_SKILLSHOTHINT_LONGSHOT")));
		skillshotNames.Add(SkillShot.SkillShotType.Covered, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_COVEREDS"), Localization.Localize("ID_RIBBON_COVERED"), Localization.Localize("ID_SKILLSHOTHINT_COVERED")));
		skillshotNames.Add(SkillShot.SkillShotType.OneHitKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_ONEHITKILLS"), Localization.Localize("ID_RIBBON_ONEHITKILL"), Localization.Localize("ID_SKILLSHOTHINT_ONEHITKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.DoubleKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_DOUBLEKILLS"), Localization.Localize("ID_RIBBON_DOUBLEKILL"), Localization.Localize("ID_SKILLSHOTHINT_DOUBLEKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.TrippleKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_TRIPLEKILLS"), Localization.Localize("ID_RIBBON_TRIPLEKILL"), Localization.Localize("ID_SKILLSHOTHINT_TRIPPLEKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.MultiKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_MULTIKILLS"), Localization.Localize("ID_RIBBON_MULTIKILL"), Localization.Localize("ID_SKILLSHOTHINT_MULTIKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.SlowMotionKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_SLOWMOTIONS"), Localization.Localize("ID_RIBBON_SLOWMOTION"), Localization.Localize("ID_SKILLSHOTHINT_SLOWMOTIONKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.RevengeKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_REVENGEKILLS"), Localization.Localize("ID_RIBBON_REVENGEKILL"), Localization.Localize("ID_SKILLSHOTHINT_REVENGEKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.ExplosiveKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_EXPLOSIVES"), Localization.Localize("ID_RIBBON_EXPLOSIVE"), Localization.Localize("ID_SKILLSHOTHINT_EXPLOSIVEKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.OnTheMove, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_ONMOVES"), Localization.Localize("ID_RIBBON_ONMOVE"), Localization.Localize("ID_SKILLSHOTHINT_ONTHEMOVE")));
		skillshotNames.Add(SkillShot.SkillShotType.EnemyPlayerHit, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_PLAYERHITS"), Localization.Localize("ID_RIBBON_PLAYERHIT"), Localization.Localize("ID_SKILLSHOTHINT_ENEMYPLAYERHIT")));
		skillshotNames.Add(SkillShot.SkillShotType.VehicleDestroyed, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_VEHICLEKILLS"), Localization.Localize("ID_RIBBON_VEHICLEKILL"), Localization.Localize("ID_SKILLSHOTHINT_VEHICLEDESTROYED")));
		skillshotNames.Add(SkillShot.SkillShotType.TankDestroyed, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_TANKKILLS"), Localization.Localize("ID_RIBBON_TANKKILL"), Localization.Localize("ID_SKILLSHOTHINT_TANKDESTROYED")));
		skillshotNames.Add(SkillShot.SkillShotType.EnviromentalKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_ENVIRONMENTS"), Localization.Localize("ID_RIBBON_ENVIRONMENT"), Localization.Localize("ID_SKILLSHOTHINT_ENVIROMENTALKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.ArmyKill, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_ARMYKILLS"), Localization.Localize("ID_RIBBON_ARMYKILL"), Localization.Localize("ID_SKILLSHOTHINT_ARMYKILL")));
		skillshotNames.Add(SkillShot.SkillShotType.ArmyPlayerHit, new Tuple<string, string, string>(Localization.Localize("ID_SKILL_ARMYPLAYERHITS"), Localization.Localize("ID_RIBBON_ARMYPLAYERHIT"), Localization.Localize("ID_SKILLSHOTHINT_ARMYPLAYERHIT")));
	}

	private void ClearCache()
	{
		mStarterPack = null;
		mValuePack = null;
		mMoneyPack = null;
	}
}
