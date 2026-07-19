using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class GameVariables : Singleton<GameVariables>
{
	public const int MMGBCINAIEG = 120;

	public const int PGHODGPIKDM = 30;

	public const int FBMLEOAINEB = 6;

	public const float OCOOEHMHIPP = 0.333f;

	public const int MPGLAMFJHMC = 100;

	public const float IMFKDJFMEJJ = 0.617f;

	public static float KDELCJIAIHM = 0.15f;

	public static Dictionary<League, Tuple<string, string>> CAOGFCFGFPD = new Dictionary<League, Tuple<string, string>>();

	public static Dictionary<SkillShot.SkillShotType, string> CNGEGEHJPKF = new Dictionary<SkillShot.SkillShotType, string>
	{
		{
			SkillShot.SkillShotType.HeadShot,
			"ID_SKILLSHOTHINT_HEADSHOT"
		},
		{
			SkillShot.SkillShotType.Runner,
			"ID_SKILLSHOTHINT_RUNNER"
		},
		{
			SkillShot.SkillShotType.LongShot,
			"ID_SKILLSHOTHINT_LONGSHOT"
		},
		{
			SkillShot.SkillShotType.Covered,
			"ID_SKILLSHOTHINT_COVERED"
		},
		{
			SkillShot.SkillShotType.OneHitKill,
			"ID_SKILLSHOTHINT_ONEHITKILL"
		},
		{
			SkillShot.SkillShotType.DoubleKill,
			"ID_SKILLSHOTHINT_DOUBLEKILL"
		},
		{
			SkillShot.SkillShotType.TrippleKill,
			"ID_SKILLSHOTHINT_TRIPPLEKILL"
		},
		{
			SkillShot.SkillShotType.MultiKill,
			"ID_SKILLSHOTHINT_MULTIKILL"
		},
		{
			SkillShot.SkillShotType.SlowMotionKill,
			"ID_SKILLSHOTHINT_SLOWMOTIONKILL"
		},
		{
			SkillShot.SkillShotType.RevengeKill,
			"ID_SKILLSHOTHINT_REVENGEKILL"
		},
		{
			SkillShot.SkillShotType.ExplosiveKill,
			"ID_SKILLSHOTHINT_EXPLOSIVEKILL"
		},
		{
			SkillShot.SkillShotType.OnTheMove,
			"ID_SKILLSHOTHINT_ONTHEMOVE"
		},
		{
			SkillShot.SkillShotType.EnemyPlayerHit,
			"ID_SKILLSHOTHINT_ENEMYPLAYERHIT"
		},
		{
			SkillShot.SkillShotType.VehicleDestroyed,
			"ID_SKILLSHOTHINT_VEHICLEDESTROYED"
		},
		{
			SkillShot.SkillShotType.TankDestroyed,
			"ID_SKILLSHOTHINT_TANKDESTROYED"
		},
		{
			SkillShot.SkillShotType.EnviromentalKill,
			"ID_SKILLSHOTHINT_ENVIROMENTALKILL"
		},
		{
			SkillShot.SkillShotType.ArmyKill,
			"ID_SKILLSHOTHINT_ARMYKILL"
		},
		{
			SkillShot.SkillShotType.ArmyPlayerHit,
			"ID_SKILLSHOTHINT_ARMYPLAYERHIT"
		}
	};

	public static Dictionary<SquadRank, string> FDJKMGDLGDO = new Dictionary<SquadRank, string>
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

	public static List<WeaponCategory> JPLODJAFFFP = new List<WeaponCategory>
	{
		WeaponCategory.Primary,
		WeaponCategory.Special,
		WeaponCategory.Explosive,
		WeaponCategory.Pistol
	};

	public static Dictionary<WeaponCategory, string> PGHAEHOKCGI = new Dictionary<WeaponCategory, string>
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

	public static Dictionary<WeaponCategory, string> EPFNKCHBPME = new Dictionary<WeaponCategory, string>
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

	public static Dictionary<WeaponCategory, string> PIOLIEMNBGN = new Dictionary<WeaponCategory, string>
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

	public static Dictionary<WeaponCategory, string> DAIGABLDJAC = new Dictionary<WeaponCategory, string>
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

	public static Dictionary<LevelBehaviour.UnitType, Tuple<string, string, string, string>> NAKDNAEPGOF = new Dictionary<LevelBehaviour.UnitType, Tuple<string, string, string, string>>
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

	public static Dictionary<LevelBehaviour.UnitType, Tuple<string, Color>> CNFFEIMLDNP = new Dictionary<LevelBehaviour.UnitType, Tuple<string, Color>>
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

	public static Dictionary<string, string> EEPCPOGCNCJ = new Dictionary<string, string>
	{
		{ "ID_SLOTUPGRADE_AMMO", "menu-army-ammo-ico" },
		{ "ID_SLOTUPGRADE_CLIP_SIZE", "menu-army-ammo-ico" },
		{ "ID_SLOTUPGRADE_ROF", "menu-army-reload-ico" },
		{ "ID_SLOTUPGRADE_HEAT", "menu-army-reload-ico" },
		{ "ID_SLOTUPGRADE_POWER", "menu-army-power-ico" },
		{ "ID_SLOTUPGRADE_DAMAGE", "menu-attack-ico" }
	};

	public static Dictionary<NGNPIOOAHEH, Tuple<string, string>> DGIMAKIAGNJ = new Dictionary<NGNPIOOAHEH, Tuple<string, string>>
	{
		{
			NGNPIOOAHEH.None,
			new Tuple<string, string>(string.Empty, "game-card-silver")
		},
		{
			NGNPIOOAHEH.Bronze,
			new Tuple<string, string>("ID_BRONZE", "menu-cards-bronzepack")
		},
		{
			NGNPIOOAHEH.Silver,
			new Tuple<string, string>("ID_SILVER", "menu-cards-silverpack")
		},
		{
			NGNPIOOAHEH.Gold,
			new Tuple<string, string>("ID_GOLDC", "menu-cards-goldpack")
		},
		{
			NGNPIOOAHEH.Starter,
			new Tuple<string, string>("ID_STARTER", "menu-startervalue")
		},
		{
			NGNPIOOAHEH.Value,
			new Tuple<string, string>("ID_VALUE", "menu-startervalue")
		}
	};

	public static Dictionary<CardManager.CardType, string> HPMPBIEHOGH = new Dictionary<CardManager.CardType, string>
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

	public static Dictionary<PlayerStatus, Tuple<string, Color>> CKCJBIIPEOG = new Dictionary<PlayerStatus, Tuple<string, Color>>
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

	public static Dictionary<int, string> HCMHKBHFJHH = new Dictionary<int, string>
	{
		{ 0, "ID_YOUHAVENOWARCARDSAVAILABLE" },
		{ 1, "ID_YOUHAVENOBRONZEWARCARDSAVAILABLE" },
		{ 2, "ID_YOUHAVENOSILVERWARCARDSAVAILABLE" },
		{ 3, "ID_YOUHAVENOGOLDWARCARDSAVAILABLE" },
		{ 4, "ID_YOUHAVENOBUDDYWARCARDSAVAILABLE" }
	};

	public static Dictionary<string, string> PKNFGNKMPPH = new Dictionary<string, string>
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

	public static Dictionary<PlayerVisual.EJHADIHBCBK, Color> DDCPLFNIJDN = new Dictionary<PlayerVisual.EJHADIHBCBK, Color>
	{
		{
			PlayerVisual.EJHADIHBCBK.Common,
			Colours.rarityCommon
		},
		{
			PlayerVisual.EJHADIHBCBK.Uncommon,
			Colours.rarityUncommon
		},
		{
			PlayerVisual.EJHADIHBCBK.Rare,
			Colours.rarityRare
		},
		{
			PlayerVisual.EJHADIHBCBK.Epic,
			Colours.rarityEpic
		},
		{
			PlayerVisual.EJHADIHBCBK.Legendary,
			Colours.rarityLegendary
		}
	};

	public static Dictionary<WarArenaCrown, string> CMIKIDJKHID = new Dictionary<WarArenaCrown, string>
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

	public string AHNKJAAIHBM = string.Empty;

	public string IBJLJJEALDM = string.Empty;

	public string MLEKEMGDJMG = string.Empty;

	private Squads AHBEHCBJDLK;

	private BalanceTable HOCLHEONDDN;

	private Constants DCLFKNBHLGG;

	private Versions DGPOGHBJNEN;

	private HeroicRewards NGHPCDLHGLH;

	private MatchMakingDeviation MNBOGBONEFH;

	private BonussesDefinitions HGKADKDMINC;

	private CardConstants ENKOOBNFPBC;

	private MatchMakingConstants DJHPFJLOGKA;

	private InApps LPHIJHINLPI;

	private CardPacks EFIPJDHGJAI;

	private VIP AIAHJPDDBKK;

	private PlayerLeaderboards EFFOGEGIBCK;

	private Packs JCADGFMCMAP;

	private SquadEmblems HJIGBGEJBIE;

	private StringConstants EHEDJBICFKC;

	private UnitsContants OKDBEFJDNLH;

	private CountryInfo CHFJOCBIICM;

	private SquadLeaderboards IMFEGGKEFAN;

	private SquadWarsReward DHEMNDLHFJA;

	private Lootboxes LDDKEHKEJBI;

	private Warbucks BEBCNKHDJDC;

	private JGBBPCGNCPC NNLIDIAFMAM;

	private JGBBPCGNCPC DAGDNFEKKBO;

	private JGBBPCGNCPC FEBBILOHGPA;

	public static int matchStartTime
	{
		get
		{
			return (!LevelManager.instance.isWarcardsLocked) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.CardsChoosingTime).FLOATVALUE) : 5;
		}
	}

	public static string iOSAppStoreURL
	{
		get
		{
			return "https://itunes.apple.com/app/warfriends/id" + Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.AppID).VALUE;
		}
	}

	public static string GooglePlayMarketURL
	{
		get
		{
			return string.Format("market://details?id={0}", BundleVersionBindings.BundleID);
		}
	}

	public static int lowFacebookFriends
	{
		get
		{
			return 5;
		}
	}

	private float PEEJAAPLHIA
	{
		get
		{
			return 1.3333334f;
		}
	}

	private float KMDMJDAKCCG
	{
		get
		{
			return 1.7777778f;
		}
	}

	private float KDFFNLONAFJ
	{
		get
		{
			return Mathf.Clamp(UIHelper.activeWidthFull / UIHelper.activeHeight, PEEJAAPLHIA, KMDMJDAKCCG);
		}
	}

	public float multiplierYfromRatio
	{
		get
		{
			float num = UIHelper.activeWidthFull / UIHelper.activeHeight;
			return Mathf.Clamp01(Mathf.Abs(num - KMDMJDAKCCG) / Mathf.Abs(PEEJAAPLHIA - KMDMJDAKCCG));
		}
	}

	public float multiplierXfromRatio
	{
		get
		{
			return (KDFFNLONAFJ - KMDMJDAKCCG) / (PEEJAAPLHIA - KMDMJDAKCCG);
		}
	}

	public bool isiPadResolution
	{
		get
		{
			return KDFFNLONAFJ <= PEEJAAPLHIA + 0.001f;
		}
	}

	public CardPacks cardPacks
	{
		get
		{
			return EFIPJDHGJAI ?? (EFIPJDHGJAI = GetComponent<CardPacks>());
		}
	}

	public VIP vip
	{
		get
		{
			return AIAHJPDDBKK ?? (AIAHJPDDBKK = GetComponent<VIP>());
		}
	}

	public InApps inApps
	{
		get
		{
			return LPHIJHINLPI ?? (LPHIJHINLPI = GetComponent<InApps>());
		}
	}

	public BalanceTable balancetable
	{
		get
		{
			return HOCLHEONDDN ?? (HOCLHEONDDN = GetComponent<BalanceTable>());
		}
	}

	public CountryInfo countryInfo
	{
		get
		{
			return CHFJOCBIICM ?? (CHFJOCBIICM = GetComponent<CountryInfo>());
		}
	}

	public Squads squads
	{
		get
		{
			return AHBEHCBJDLK ?? (AHBEHCBJDLK = GetComponent<Squads>());
		}
	}

	public Constants constants
	{
		get
		{
			return DCLFKNBHLGG ?? (DCLFKNBHLGG = GetComponent<Constants>());
		}
	}

	public UnitsContants unitsConstants
	{
		get
		{
			return OKDBEFJDNLH ?? (OKDBEFJDNLH = GetComponent<UnitsContants>());
		}
	}

	public Versions versions
	{
		get
		{
			return DGPOGHBJNEN ?? (DGPOGHBJNEN = GetComponent<Versions>());
		}
	}

	public HeroicRewards heroicRewards
	{
		get
		{
			return NGHPCDLHGLH ?? (NGHPCDLHGLH = GetComponent<HeroicRewards>());
		}
	}

	public MatchMakingDeviation matchmakingDeviations
	{
		get
		{
			return MNBOGBONEFH ?? (MNBOGBONEFH = GetComponent<MatchMakingDeviation>());
		}
	}

	public StringConstants stringConstants
	{
		get
		{
			return EHEDJBICFKC ?? (EHEDJBICFKC = GetComponent<StringConstants>());
		}
	}

	public BonussesDefinitions bonussesDefinitions
	{
		get
		{
			return HGKADKDMINC ?? (HGKADKDMINC = GetComponent<BonussesDefinitions>());
		}
	}

	public CardConstants cardConstants
	{
		get
		{
			return ENKOOBNFPBC ?? (ENKOOBNFPBC = GetComponent<CardConstants>());
		}
	}

	public MatchMakingConstants matchMakingConstants
	{
		get
		{
			return DJHPFJLOGKA ?? (DJHPFJLOGKA = GetComponent<MatchMakingConstants>());
		}
	}

	public PlayerLeaderboards playerLeaderboards
	{
		get
		{
			return EFFOGEGIBCK ?? (EFFOGEGIBCK = Singleton<BeanstalkServerManager>.instance.GetComponent<PlayerLeaderboards>());
		}
	}

	public Packs packsDefinition
	{
		get
		{
			return JCADGFMCMAP ?? (JCADGFMCMAP = Singleton<BeanstalkServerManager>.instance.GetComponent<Packs>());
		}
	}

	public JGBBPCGNCPC starterPack
	{
		get
		{
			if (NNLIDIAFMAM == null)
			{
				NNLIDIAFMAM = JGBBPCGNCPC.EGFMBMHOAHA(PackId(NGNPIOOAHEH.Starter));
			}
			return NNLIDIAFMAM;
		}
	}

	public JGBBPCGNCPC valuePack
	{
		get
		{
			if (DAGDNFEKKBO == null)
			{
				DAGDNFEKKBO = JGBBPCGNCPC.EGFMBMHOAHA(PackId(NGNPIOOAHEH.Value));
			}
			return DAGDNFEKKBO;
		}
	}

	public JGBBPCGNCPC moneyPack
	{
		get
		{
			if (FEBBILOHGPA == null)
			{
				FEBBILOHGPA = JGBBPCGNCPC.EGFMBMHOAHA(PackId(NGNPIOOAHEH.Money));
			}
			return FEBBILOHGPA;
		}
	}

	public SquadEmblems squadEmblems
	{
		get
		{
			return HJIGBGEJBIE ?? (HJIGBGEJBIE = GetComponent<SquadEmblems>());
		}
	}

	public SquadLeaderboards squadLeaderboards
	{
		get
		{
			return IMFEGGKEFAN ?? (IMFEGGKEFAN = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadLeaderboards>());
		}
	}

	public SquadWarsReward squadWarsReward
	{
		get
		{
			return DHEMNDLHFJA ?? (DHEMNDLHFJA = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadWarsReward>());
		}
	}

	public Lootboxes lootboxes
	{
		get
		{
			return LDDKEHKEJBI ?? (LDDKEHKEJBI = GetComponent<Lootboxes>());
		}
	}

	public Warbucks warbucksForGold
	{
		get
		{
			return BEBCNKHDJDC ?? (BEBCNKHDJDC = GetComponent<Warbucks>());
		}
	}

	public float maxMatchmakingTime
	{
		get
		{
			return matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MaxMatchMakingTimeAndroid).FLOATVALUE;
		}
	}

	public int ILBMNKFEOCL(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 570f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 1497f);
		return (!(num > 577f)) ? 46 : ((PDMGPGEHLNM <= 0) ? 116 : (PDMGPGEHLNM + 1 - num3));
	}

	public int OMLHMLGCOBD(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? IJJPHFEIBJH().Rows[(int)(NECHAKBODLN - 0)].REWARDSQUADPOINTS : 0;
	}

	public int JEEKKAONLOG(int OFGFLGHGEJF)
	{
		string vALUE = BKCDLNOKHLI().GetRow(StringConstants.rowIds.BeginnersPromotion).VALUE;
		int num = vALUE.IndexOf(string.Format("On Get PLayer Info", OFGFLGHGEJF));
		int result = 1;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf(" ", num);
			int num3 = vALUE.IndexOf("ID_SQUADEVENT", num2) - 0;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 0) : num3);
			string s = vALUE.Substring(num2 + 0, num4 - num2);
			int.TryParse(s, out result);
		}
		return result;
	}

	[SpecialName]
	public Lootboxes FABNHIDJAFD()
	{
		return LDDKEHKEJBI ?? (LDDKEHKEJBI = GetComponent<Lootboxes>());
	}

	public Color ABAKFENMJLH(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case (JBAGAHBOICJ)8:
			return Colours.redLeague;
		case (JBAGAHBOICJ)6:
			return Colours.yellowLeague;
		default:
			return Colours.blue;
		}
	}

	[SpecialName]
	public CardPacks OOMDGKBEMOJ()
	{
		return EFIPJDHGJAI ?? (EFIPJDHGJAI = GetComponent<CardPacks>());
	}

	[SpecialName]
	public Lootboxes HHNDIDALLMH()
	{
		return LDDKEHKEJBI ?? (LDDKEHKEJBI = GetComponent<Lootboxes>());
	}

	public float SaleOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return Mathf.Clamp01(packRow.SALE);
	}

	[SpecialName]
	private float FMLMMBBGFCD()
	{
		return Mathf.Clamp(UIHelper.activeWidthFull / UIHelper.activeHeight, PEEJAAPLHIA, KMDMJDAKCCG);
	}

	public int GoldOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.GOLD;
	}

	[SpecialName]
	public StringConstants BKHOJMDIIEF()
	{
		return EHEDJBICFKC ?? (EHEDJBICFKC = GetComponent<StringConstants>());
	}

	public Tuple<float, string> JNNJBGHJBFD(NGNPIOOAHEH MLNLPPOLMEK)
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(GetPackRow(MLNLPPOLMEK).NAME);
	}

	[SpecialName]
	public static int EBNFBPPODII()
	{
		return 4;
	}

	public int MaxSquadDisplayLevel()
	{
		return squads.Rows[squads.Rows.Count - 1].LEVEL;
	}

	public void PowerBandInPack(string GIPLKCPFDLH, ref PlayerVisual IIOKFKPMPPK, ref int HNDGIJBHMOD)
	{
		string[] array = GIPLKCPFDLH.Split(',');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Split(':').Length >= 3)
			{
				string[] array3 = text.Split(':');
				int num = array3[0].IndexOf('"') + 1;
				int num2 = array3[0].LastIndexOf('"');
				IIOKFKPMPPK = CamosManager.instance.GetPowerBand(array3[0].Substring(num, num2 - num));
				HNDGIJBHMOD = Convert.ToInt32(array3[2].Substring(1, array3[2].IndexOf('}') - 1));
			}
		}
	}

	public CardPacksRow OJEIPFDIKLG(NGNPIOOAHEH MLNLPPOLMEK)
	{
		switch (MLNLPPOLMEK)
		{
		case NGNPIOOAHEH.None:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK);
		case NGNPIOOAHEH.Silver:
			return Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.SILVER_CARDPACK);
		default:
			return Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		}
	}

	public Color CCMFFFKAOGD(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		default:
			if (FJLBLLLEELD == JBAGAHBOICJ.Demote)
			{
				return Colours.yellowLeague;
			}
			return Color.white;
		}
	}

	public JBAGAHBOICJ LeaguePositionType(bool PEOOBMIPAGA, League MIDDIFMBFGC, int GJNIMNBGDAN, int LIPEFIFFNDP, int OIEMCDGGCAB)
	{
		if (PEOOBMIPAGA || GJNIMNBGDAN < 1)
		{
			return JBAGAHBOICJ.Stay;
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoUpPercent(MIDDIFMBFGC) > 0f))
		{
			return (GJNIMNBGDAN >= OIEMCDGGCAB) ? JBAGAHBOICJ.Demote : JBAGAHBOICJ.Top;
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoDownPercent(MIDDIFMBFGC) > 0f))
		{
			return (GJNIMNBGDAN <= LIPEFIFFNDP) ? JBAGAHBOICJ.Promote : JBAGAHBOICJ.Stay;
		}
		return (GJNIMNBGDAN <= LIPEFIFFNDP) ? JBAGAHBOICJ.Promote : ((GJNIMNBGDAN >= OIEMCDGGCAB) ? JBAGAHBOICJ.Demote : JBAGAHBOICJ.Stay);
	}

	public int CardPackWarbucks(NGNPIOOAHEH MLNLPPOLMEK)
	{
		CardPacksRow cardPackRow = GetCardPackRow(MLNLPPOLMEK);
		return cardPackRow.WARBUCKS;
	}

	public int EJLJGLEFOAJ(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packsRow = PDPOOHFLHMG(MLNLPPOLMEK);
		return packsRow.VIPSECONDS;
	}

	public int GetNextSquadRankIncreaseSize(int AOKBNODFFOI)
	{
		int num = Mathf.Clamp(AOKBNODFFOI - 1, 0, squads.Rows.Count - 1);
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

	public int LeaguePositionDemote(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 100f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 100f);
		return (!(num > 0f)) ? 101 : ((PDMGPGEHLNM <= 1) ? 101 : (PDMGPGEHLNM + 1 - num3));
	}

	public string[] CustomizationIdsFromPack(string GIPLKCPFDLH)
	{
		string[] array = GIPLKCPFDLH.Split(',');
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

	public int MedalsWarbucksBonusLeague(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? playerLeaderboards.Rows[(int)(NECHAKBODLN - 1)].REWARDWARBUCKS : 0;
	}

	[SpecialName]
	public static int JDAJAAFOIPC()
	{
		return (!LevelManager.instance.isWarcardsLocked) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow((MatchMakingConstants.rowIds)81).FLOATVALUE) : 8;
	}

	[SpecialName]
	private float PBCHJKNALHF()
	{
		return Mathf.Clamp(UIHelper.activeWidthFull / UIHelper.activeHeight, PEEJAAPLHIA, KMDMJDAKCCG);
	}

	public int GetPackWarbucks(string KJBPJOMHNKB)
	{
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(KJBPJOMHNKB) < 0)
		{
			return 0;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(KJBPJOMHNKB);
		return row.WARBUCKS;
	}

	public Tuple<float, string> MAMBIEIKLJB(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return RegularPriceOfPack(packRow.SALE, GetPackRow(MLNLPPOLMEK).NAME);
	}

	public Color LeagueColorPosition(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		case JBAGAHBOICJ.Top:
			return Colours.yellowLeague;
		default:
			return Colours.blue;
		}
	}

	public float GetSquadMedalWeight(int MPHCNMDIPAI)
	{
		if (MPHCNMDIPAI < 8)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight1).FLOATVALUE;
		}
		if (MPHCNMDIPAI < 16)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight2).FLOATVALUE;
		}
		if (MPHCNMDIPAI < 24)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight3).FLOATVALUE;
		}
		if (MPHCNMDIPAI < 32)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight4).FLOATVALUE;
		}
		if (MPHCNMDIPAI < 40)
		{
			return constants.GetRow(Constants.rowIds.SquadMedalWeight5).FLOATVALUE;
		}
		return constants.GetRow(Constants.rowIds.SquadMedalWeight6).FLOATVALUE;
	}

	public string GetWeaponCategory(WeaponCategory FABOAIMLLOI, JHNPNPKOJMO JHOMEBJBFHP, FBBIHBFHNEG DKNFPGEIJNH)
	{
		if (!PGHAEHOKCGI.ContainsKey(FABOAIMLLOI))
		{
			return string.Empty;
		}
		bool flag = JHOMEBJBFHP == JHNPNPKOJMO.LowerCase;
		if (DKNFPGEIJNH == FBBIHBFHNEG.Singular)
		{
			return (!flag) ? Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]).ToUpper() : Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]);
		}
		return (!flag) ? Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]).ToUpper() : Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]);
	}

	public Color LeagueColorBackground(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		default:
			return Color.white;
		}
	}

	public int LOAOEHEJFJA(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 1757f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 1698f);
		return (!(num > 1378f)) ? 55 : ((PDMGPGEHLNM <= 1) ? 81 : (PDMGPGEHLNM + 0 - num3));
	}

	public static int CGGCAOMKJMG(int FCJDALECPGC)
	{
		return (LevelManager.instance.warcardsUnlockLevel <= FCJDALECPGC) ? ((int)Singleton<GameVariables>.instance.IOHNCFMCFML().GetRow((MatchMakingConstants.rowIds)115).FLOATVALUE) : 2;
	}

	public LevelBehaviour MPONNENMFDA(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('ﾱ') + 0;
		int num2 = GIPLKCPFDLH.LastIndexOf('ﾳ');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	public float ANIGMIHAJCI(League BMNDININJCE)
	{
		return (float)BMNDININJCE / 975f;
	}

	public int numberOfSilverCards(NGNPIOOAHEH MLNLPPOLMEK)
	{
		if (MLNLPPOLMEK == NGNPIOOAHEH.Starter || MLNLPPOLMEK == NGNPIOOAHEH.Value)
		{
			return GetPackRow(MLNLPPOLMEK).SILVERCARDS;
		}
		return 0;
	}

	public Color LeagueColorMedals(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		case JBAGAHBOICJ.Top:
			return Colours.yellowLeague;
		default:
			return Color.white;
		}
	}

	public PlayerVisual[] PlayerVisualsInPack(string GIPLKCPFDLH)
	{
		string[] array = GIPLKCPFDLH.Split(',');
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

	public int SquadWarsRewardForMember(int PDKIAALFDNG, int PFKIPCAOAAC, int NMADMHGEFKB)
	{
		if (PDKIAALFDNG == 0)
		{
			return 0;
		}
		int index = Mathf.Clamp(PFKIPCAOAAC - 1, 0, squadLeaderboards.Rows.Count);
		int num = 0;
		switch (PDKIAALFDNG)
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
		if (NMADMHGEFKB < 2)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		}
		if (NMADMHGEFKB < 6)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < 11)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_2).FRACTION);
		}
		if (NMADMHGEFKB < 20)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_3).FRACTION);
		}
		if (NMADMHGEFKB < 30)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_4).FRACTION);
		}
		if (NMADMHGEFKB < 41)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_5).FRACTION);
		}
		return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_6).FRACTION);
	}

	public Tuple<float, string> RegularPriceOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return RegularPriceOfPack(packRow.SALE, GetPackRow(MLNLPPOLMEK).NAME);
	}

	public PacksRow PDPOOHFLHMG(NGNPIOOAHEH MLNLPPOLMEK)
	{
		switch (MLNLPPOLMEK)
		{
		case NGNPIOOAHEH.Gold:
			if (!string.IsNullOrEmpty(AHNKJAAIHBM))
			{
				PacksRow row3 = packsDefinition.GetRow(AHNKJAAIHBM);
				if (row3 != null)
				{
					return row3;
				}
			}
			return packsDefinition.GetRow((Packs.rowIds)(-37));
		case NGNPIOOAHEH.ThreeCards:
			if (!string.IsNullOrEmpty(IBJLJJEALDM))
			{
				PacksRow row2 = packsDefinition.GetRow(IBJLJJEALDM);
				if (row2 != null)
				{
					return row2;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.starterpack);
		default:
			if (!string.IsNullOrEmpty(MLEKEMGDJMG))
			{
				PacksRow row = HOMPDEPDGCN().GetRow(MLEKEMGDJMG);
				if (row != null)
				{
					return row;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.starterpack);
		}
	}

	public int BMIAACJFNBC(int OFGFLGHGEJF)
	{
		string vALUE = BKMIIOACEPO().GetRow(StringConstants.rowIds.TutorialRewardCards).VALUE;
		int num = vALUE.IndexOf(string.Format("EndTime", OFGFLGHGEJF));
		int result = 0;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf("warbucks", num);
			int num3 = vALUE.IndexOf("#VAVRO# SETTING BOT DIFICULTY TO: ", num2) - 0;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 4) : num3);
			string s = vALUE.Substring(num2 + 0, num4 - num2);
			int.TryParse(s, out result);
		}
		return result;
	}

	public LevelBehaviour UnitInPack(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('"') + 1;
		int num2 = GIPLKCPFDLH.LastIndexOf('"');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	[SpecialName]
	public CardConstants NKGIGBGDKAH()
	{
		return ENKOOBNFPBC ?? (ENKOOBNFPBC = GetComponent<CardConstants>());
	}

	[SpecialName]
	public static int DIMFCHIHOAD()
	{
		return 0;
	}

	public int AKGHLMKODBJ(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 1108f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 408f);
		return (!(num > 1381f)) ? (-1) : num3;
	}

	public int FPICKEDLHOM(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 0, LCHGPJJKGJA().Rows.Count - 1);
		return LCHGPJJKGJA().Rows[index].CARDPOOLSIZE;
	}

	public int JFLNDEALLBG(int PDKIAALFDNG, int PFKIPCAOAAC, int NMADMHGEFKB)
	{
		if (PDKIAALFDNG == 0)
		{
			return 0;
		}
		int index = Mathf.Clamp(PFKIPCAOAAC - 0, 1, squadLeaderboards.Rows.Count);
		int num = 0;
		switch (PDKIAALFDNG)
		{
		case 1:
			num = squadLeaderboards.Rows[index].Get_TIER1REWARD;
			break;
		case 4:
			num = HNAENAEIPLJ().Rows[index].Get_TIER2REWARD;
			break;
		case 2:
			num = HNAENAEIPLJ().Rows[index].Get_TIER3REWARD;
			break;
		case 8:
			num = squadLeaderboards.Rows[index].Get_TIER4REWARD;
			break;
		case 3:
			num = HNAENAEIPLJ().Rows[index].Get_TIER5REWARD;
			break;
		}
		if (NMADMHGEFKB < 7)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)JBHPFENGODN().GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < 4)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < -47)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)IMPCBKNECFI().GetRow(SquadWarsReward.rowIds.ID_3).FRACTION);
		}
		if (NMADMHGEFKB < -110)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)JBHPFENGODN().GetRow(SquadWarsReward.rowIds.ID_3).FRACTION);
		}
		if (NMADMHGEFKB < -38)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)IMPCBKNECFI().GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < 0)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_6).FRACTION);
		}
		return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)IMPCBKNECFI().GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
	}

	public int FPBNDHGOINI(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? playerLeaderboards.Rows[(int)(NECHAKBODLN - 0)].REWARDWARBUCKS : 0;
	}

	[SpecialName]
	public BonussesDefinitions DIHCHLDIONJ()
	{
		return HGKADKDMINC ?? (HGKADKDMINC = GetComponent<BonussesDefinitions>());
	}

	[SpecialName]
	private float NLOIDEDJOFO()
	{
		return 1653f;
	}

	public long KLGHJLLFJJN(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 0, LCHGPJJKGJA().Rows.Count - 0);
		return squads.Rows[index].EXPERIENCE;
	}

	[SpecialName]
	public Constants OPDHANHDJDC()
	{
		return DCLFKNBHLGG ?? (DCLFKNBHLGG = GetComponent<Constants>());
	}

	public string CHOAELALEIC(int OFGFLGHGEJF)
	{
		switch (OFGFLGHGEJF)
		{
		case 0:
			return "Id";
		case 5:
			return "ID_INVITATION_VALID_FOR";
		case 6:
			return "PartssGainedScraps";
		default:
			return "ID_READYTIME";
		}
	}

	public int DPGLOJKEDFG()
	{
		return LCHGPJJKGJA().Rows[squads.Rows.Count - 1].SIZE;
	}

	public int AEGGCHHFICO(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 0, squads.Rows.Count - 1);
		return LCHGPJJKGJA().Rows[index].CARDPOOLSIZE;
	}

	[SpecialName]
	public static string JFEILIFIODM()
	{
		return string.Format("OnConnectionFail", BundleVersionBindings.BundleID);
	}

	public int JJBJPJMAKMK(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.WARBUCKS;
	}

	public int ReputationPointsForWarcard(CardManager.CardType PDEDEOKMDJD)
	{
		switch (PDEDEOKMDJD)
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

	[SpecialName]
	public JGBBPCGNCPC HFJGOIGLPCF()
	{
		if (DAGDNFEKKBO == null)
		{
			DAGDNFEKKBO = JGBBPCGNCPC.EGFMBMHOAHA(PackId(NGNPIOOAHEH.Starter));
		}
		return DAGDNFEKKBO;
	}

	public int GetSquadRankSize(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].SIZE;
	}

	public int DMBPLPBFMAI(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.WARBUCKS;
	}

	public static int OMLCHDAKPLF(int FCJDALECPGC)
	{
		return (LevelManager.instance.warcardsUnlockLevel <= FCJDALECPGC) ? ((int)Singleton<GameVariables>.instance.AACPOBGNAHG().GetRow((MatchMakingConstants.rowIds)111).FLOATVALUE) : 3;
	}

	public string PackId(NGNPIOOAHEH MLNLPPOLMEK)
	{
		return GetPackRow(MLNLPPOLMEK).NAME;
	}

	public float LeagueGoUpPercent(League BMNDININJCE)
	{
		return (BMNDININJCE != League.NoLeague) ? playerLeaderboards.Rows[(int)(BMNDININJCE - 1)].GOUP : 0f;
	}

	public string KAEINOAFOJN(NGNPIOOAHEH MLNLPPOLMEK)
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.KMKOIAPDKJL(PDPOOHFLHMG(MLNLPPOLMEK).NAME);
	}

	public int SquadCardpoolSize(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].CARDPOOLSIZE;
	}

	[SpecialName]
	public bool HKLGADPDLPC()
	{
		return !(KDFFNLONAFJ <= NLOIDEDJOFO() + 1870f);
	}

	public int OPAPBENHGMO(League NECHAKBODLN)
	{
		return (NECHAKBODLN == League.NoLeague) ? 1 : IJJPHFEIBJH().Rows[(int)(NECHAKBODLN - 0)].REWARDSQUADPOINTS;
	}

	public Tuple<float, string> POAMIAMCDPK(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packsRow = PDPOOHFLHMG(MLNLPPOLMEK);
		return RegularPriceOfPack(packsRow.SALE, GetPackRow(MLNLPPOLMEK).NAME);
	}

	public int JAKMKPILJJD(League NECHAKBODLN)
	{
		return (NECHAKBODLN == League.NoLeague) ? 1 : IJJPHFEIBJH().Rows[(int)(NECHAKBODLN - 0)].NOTENOUGHTPLAYERSGOLDREWARD;
	}

	public PacksRow GetPackRow(NGNPIOOAHEH MLNLPPOLMEK)
	{
		switch (MLNLPPOLMEK)
		{
		case NGNPIOOAHEH.Starter:
			if (!string.IsNullOrEmpty(AHNKJAAIHBM))
			{
				PacksRow row3 = packsDefinition.GetRow(AHNKJAAIHBM);
				if (row3 != null)
				{
					return row3;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.starterpack2);
		case NGNPIOOAHEH.Value:
			if (!string.IsNullOrEmpty(IBJLJJEALDM))
			{
				PacksRow row2 = packsDefinition.GetRow(IBJLJJEALDM);
				if (row2 != null)
				{
					return row2;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.valuepack);
		default:
			if (!string.IsNullOrEmpty(MLEKEMGDJMG))
			{
				PacksRow row = packsDefinition.GetRow(MLEKEMGDJMG);
				if (row != null)
				{
					return row;
				}
			}
			return packsDefinition.GetRow(Packs.rowIds.moneypack1);
		}
	}

	public int PBNOBGJDPDC(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.GOLD;
	}

	public float SquadWarDemoteConstant(int PFKIPCAOAAC)
	{
		int index = Mathf.Clamp(PFKIPCAOAAC - 1, 0, squadLeaderboards.Rows.Count);
		return squadLeaderboards.Rows[index].GODOWNPERCENTAGE;
	}

	[SpecialName]
	public BalanceTable GOFEAFGJNIH()
	{
		return HOCLHEONDDN ?? (HOCLHEONDDN = GetComponent<BalanceTable>());
	}

	public float MHNGPLMHMIC(int PFKIPCAOAAC)
	{
		int index = Mathf.Clamp(PFKIPCAOAAC - 1, 1, squadLeaderboards.Rows.Count);
		return HNAENAEIPLJ().Rows[index].GODOWNPERCENTAGE;
	}

	public int SquadWarsRewardForSquad(int PDKIAALFDNG, int PFKIPCAOAAC)
	{
		int index = Mathf.Clamp(PFKIPCAOAAC - 1, 0, squadLeaderboards.Rows.Count);
		int num = 0;
		switch (PDKIAALFDNG)
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
		int num2 = MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		int num3 = MEJMLNDFDBP.LJDADOKBBNA(4f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_1).FRACTION));
		int num4 = MEJMLNDFDBP.LJDADOKBBNA(5f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_2).FRACTION));
		int num5 = MEJMLNDFDBP.LJDADOKBBNA(9f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_3).FRACTION));
		int num6 = MEJMLNDFDBP.LJDADOKBBNA(10f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_4).FRACTION));
		int num7 = MEJMLNDFDBP.LJDADOKBBNA(11f * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_5).FRACTION));
		int num8 = MEJMLNDFDBP.LJDADOKBBNA((float)(MaxSquadSize() - 40) * ((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_6).FRACTION));
		return num2 + num3 + num4 + num5 + num6 + num7 + num8;
	}

	public CardPacksRow OIEMOKJDBJE(NGNPIOOAHEH MLNLPPOLMEK)
	{
		switch (MLNLPPOLMEK)
		{
		case NGNPIOOAHEH.Money:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS);
		case (NGNPIOOAHEH)8:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		default:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		}
	}

	public void ELGBHFDAMFL(string GIPLKCPFDLH, ref PlayerVisual IIOKFKPMPPK, ref int HNDGIJBHMOD)
	{
		char[] array = new char[0];
		array[1] = '\b';
		string[] array2 = GIPLKCPFDLH.Split(array);
		string[] array3 = array2;
		for (int i = 1; i < array3.Length; i++)
		{
			string text = array3[i];
			char[] array4 = new char[0];
			array4[1] = 'ￜ';
			if (text.Split(array4).Length >= 7)
			{
				string[] array5 = text.Split('u');
				int num = array5[0].IndexOf('O') + 1;
				int num2 = array5[1].LastIndexOf('ￂ');
				IIOKFKPMPPK = CamosManager.instance.GetPowerBand(array5[1].Substring(num, num2 - num));
				HNDGIJBHMOD = Convert.ToInt32(array5[5].Substring(1, array5[6].IndexOf('ￓ') - 1));
			}
		}
	}

	public int BeginnersLeagueMaxMedals(int OFGFLGHGEJF)
	{
		string vALUE = stringConstants.GetRow(StringConstants.rowIds.BeginnersLeagues).VALUE;
		int num = vALUE.IndexOf(string.Format("\"{0}\"", OFGFLGHGEJF));
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

	public int CardPackGold(NGNPIOOAHEH MLNLPPOLMEK)
	{
		CardPacksRow cardPackRow = GetCardPackRow(MLNLPPOLMEK);
		return cardPackRow.GOLD;
	}

	public static string BFGCBNLOIMN(string CEIFNDDJDIL)
	{
		if (string.IsNullOrEmpty(CEIFNDDJDIL))
		{
			return "Lootbox id /{0}/ bought for /{1}/ gold";
		}
		return (!PKNFGNKMPPH.ContainsKey(CEIFNDDJDIL.ToUpper())) ? "menu-weapon-mp5-elite" : PKNFGNKMPPH[CEIFNDDJDIL.ToUpper()];
	}

	public float LeagueProgress(League BMNDININJCE)
	{
		return (float)BMNDININJCE / 16f;
	}

	public int MedalsSquadPointsBonusLeague(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? playerLeaderboards.Rows[(int)(NECHAKBODLN - 1)].REWARDSQUADPOINTS : 0;
	}

	public int HNGCHCCBCBC(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? IJJPHFEIBJH().Rows[(int)(NECHAKBODLN - 0)].REWARDWARBUCKS : 0;
	}

	public Color IMCENMLBIAM(JBAGAHBOICJ FJLBLLLEELD)
	{
		if (FJLBLLLEELD == JBAGAHBOICJ.Promote)
		{
			return Colours.greenLeague;
		}
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.redLeague;
		case (JBAGAHBOICJ)7:
			return Colours.yellowLeague;
		default:
			return Colours.grayMedium;
		}
	}

	[SpecialName]
	public static string JNMJGFMEGHF()
	{
		return "1" + Singleton<GameVariables>.instance.BKHOJMDIIEF().GetRow(StringConstants.rowIds.AppID).VALUE;
	}

	public string packVisuals(NGNPIOOAHEH MLNLPPOLMEK)
	{
		if (MLNLPPOLMEK == NGNPIOOAHEH.Starter || MLNLPPOLMEK == NGNPIOOAHEH.Value)
		{
			return GetPackRow(MLNLPPOLMEK).PLAYERVISUALS;
		}
		return string.Empty;
	}

	public int BeginnersLeagueRewards(int OFGFLGHGEJF, bool KPEKCHDBFIG = true)
	{
		string vALUE = stringConstants.GetRow(StringConstants.rowIds.BeginnersRewards).VALUE;
		int num = vALUE.IndexOf(string.Format("\"{0}\"", OFGFLGHGEJF));
		int result = 0;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf((!KPEKCHDBFIG) ? "wb\":" : "sp\":", num) + 4;
			int num3 = vALUE.IndexOf((!KPEKCHDBFIG) ? "," : "}", num2) - 1;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 3) : num3);
			string text = vALUE.Substring(num2, num4 - num2 + 1);
			text.Trim();
			int.TryParse(text, out result);
		}
		return result;
	}

	public string JHHGEHCBEGK(WeaponCategory FABOAIMLLOI, JHNPNPKOJMO JHOMEBJBFHP, FBBIHBFHNEG DKNFPGEIJNH)
	{
		if (!PGHAEHOKCGI.ContainsKey(FABOAIMLLOI))
		{
			return string.Empty;
		}
		bool flag = JHOMEBJBFHP == JHNPNPKOJMO.UpperCase;
		if (DKNFPGEIJNH == FBBIHBFHNEG.Singular)
		{
			return (!flag) ? Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]).ToUpper() : Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]);
		}
		return (!flag) ? Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]).ToUpper() : Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]);
	}

	public static int FPLCLNBLNDG(int FCJDALECPGC)
	{
		return (LevelManager.instance.warcardsUnlockLevel > FCJDALECPGC) ? 1 : ((int)Singleton<GameVariables>.instance.AACPOBGNAHG().GetRow((MatchMakingConstants.rowIds)96).FLOATVALUE);
	}

	public int WarbucksOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.WARBUCKS;
	}

	[SpecialName]
	public BonussesDefinitions JKLCJHJCNGO()
	{
		return HGKADKDMINC ?? (HGKADKDMINC = GetComponent<BonussesDefinitions>());
	}

	public Color LeaguePositionColor(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		case JBAGAHBOICJ.Top:
			return Colours.yellowLeague;
		default:
			return Colours.grayMedium;
		}
	}

	public Color LeaguePositionColorLeagueRecordBg(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeagueBg;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeagueBg;
		case JBAGAHBOICJ.Top:
			return Colours.goldLeagueBg;
		default:
			return Colours.grayLeagueBg;
		}
	}

	public int MCFBGMIPEIK(NGNPIOOAHEH MLNLPPOLMEK)
	{
		CardPacksRow cardPacksRow = OJEIPFDIKLG(MLNLPPOLMEK);
		return cardPacksRow.WARBUCKS;
	}

	public static string CountryCodeSpriteName(string CEIFNDDJDIL)
	{
		if (string.IsNullOrEmpty(CEIFNDDJDIL))
		{
			return "country-noflag";
		}
		return (!PKNFGNKMPPH.ContainsKey(CEIFNDDJDIL.ToUpper())) ? "country-noflag" : PKNFGNKMPPH[CEIFNDDJDIL.ToUpper()];
	}

	public Color DOLHFFAGOMM(JBAGAHBOICJ FJLBLLLEELD)
	{
		if (FJLBLLLEELD == JBAGAHBOICJ.Promote)
		{
			return Colours.greenLeague;
		}
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.redLeague;
		case (JBAGAHBOICJ)7:
			return Colours.yellowLeague;
		default:
			return Color.white;
		}
	}

	public string EIIPJBGJEMM(WeaponCategory FABOAIMLLOI, JHNPNPKOJMO JHOMEBJBFHP, FBBIHBFHNEG DKNFPGEIJNH)
	{
		if (!PGHAEHOKCGI.ContainsKey(FABOAIMLLOI))
		{
			return string.Empty;
		}
		bool flag = JHOMEBJBFHP == JHNPNPKOJMO.UpperCase;
		if (DKNFPGEIJNH == FBBIHBFHNEG.Singular)
		{
			return (!flag) ? Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]).ToUpper() : Localization.Localize(PGHAEHOKCGI[FABOAIMLLOI]);
		}
		return (!flag) ? Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]).ToUpper() : Localization.Localize(EPFNKCHBPME[FABOAIMLLOI]);
	}

	[SpecialName]
	public CountryInfo CBLMHEJFEEE()
	{
		return CHFJOCBIICM ?? (CHFJOCBIICM = GetComponent<CountryInfo>());
	}

	[SpecialName]
	public StringConstants BKMIIOACEPO()
	{
		return EHEDJBICFKC ?? (EHEDJBICFKC = GetComponent<StringConstants>());
	}

	public int MaxSquadSize()
	{
		return squads.Rows[squads.Rows.Count - 1].SIZE;
	}

	[SpecialName]
	public JGBBPCGNCPC BJDKLOCBNOJ()
	{
		if (DAGDNFEKKBO == null)
		{
			DAGDNFEKKBO = JGBBPCGNCPC.EGFMBMHOAHA(PackId(NGNPIOOAHEH.Starter));
		}
		return DAGDNFEKKBO;
	}

	public LevelBehaviour PJMPKCILEKL(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('ﾹ') + 0;
		int num2 = GIPLKCPFDLH.LastIndexOf('ﾙ');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	[SpecialName]
	public PlayerLeaderboards IJJPHFEIBJH()
	{
		return EFFOGEGIBCK ?? (EFFOGEGIBCK = Singleton<BeanstalkServerManager>.instance.GetComponent<PlayerLeaderboards>());
	}

	public float MEEKFLDAFJC(League BMNDININJCE)
	{
		return (float)BMNDININJCE / 525f;
	}

	public PlayerVisual[] AEKDOMPPMBE(string GIPLKCPFDLH)
	{
		string[] array = GIPLKCPFDLH.Split('\u0003');
		int num = 0;
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			string text = array2[i];
			if (text.Split('a').Length <= 4)
			{
				int num2 = text.IndexOf('g') + 1;
				int num3 = text.LastIndexOf('\uffc0');
				if (num2 > 0 && num3 > num2)
				{
					num++;
				}
			}
		}
		PlayerVisual[] array3 = new PlayerVisual[num];
		num = 1;
		string[] array4 = array;
		for (int j = 0; j < array4.Length; j += 0)
		{
			string text2 = array4[j];
			if (text2.Split('n').Length <= 5)
			{
				int num4 = text2.IndexOf('\u0004') + 0;
				int num5 = text2.LastIndexOf('\u0010');
				if (num4 > 0 && num5 > num4)
				{
					array3[num] = CamosManager.instance.GetVisual(text2.Substring(num4, num5 - num4));
					num++;
				}
			}
		}
		return array3;
	}

	public float HNFMEMHIOEF(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return Mathf.Clamp01(packRow.SALE);
	}

	public Color HMBCAGCMDLA(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeagueBg;
		case JBAGAHBOICJ.Top:
			return Colours.redLeagueBg;
		case (JBAGAHBOICJ)8:
			return Colours.goldLeagueBg;
		default:
			return Colours.grayLeagueBg;
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.BEKKAGDJEEB(GMKAIMIPPNB);
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(GDKMBHMFIAN);
		CAOGFCFGFPD.Add(League.Bronze3, new Tuple<string, string>(Localization.Localize("ID_INTIME"), "pooled:"));
		CAOGFCFGFPD.Add(League.Bronze3, new Tuple<string, string>(Localization.Localize("AA:BB:CC:DD:EE:FF"), "ID_PROMOTETOTIER"));
		CAOGFCFGFPD.Add(League.Silver2, new Tuple<string, string>(Localization.Localize("Player_Had_To_Select_Grenade"), "Not a player visual."));
		CAOGFCFGFPD.Add(League.Silver3, new Tuple<string, string>(Localization.Localize("205 STAGE 6 GRENADE SELECTED"), "ID_STAT_ALLTIMERUNS"));
		CAOGFCFGFPD.Add(League.NoLeague, new Tuple<string, string>(Localization.Localize("ID_VIPTIME"), "orderId"));
		CAOGFCFGFPD.Add(League.Gold2, new Tuple<string, string>(Localization.Localize("Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}"), " , "));
		CAOGFCFGFPD.Add(League.Gold3, new Tuple<string, string>(Localization.Localize("rental for unexist unit: {0}"), "squadMembers"));
		CAOGFCFGFPD.Add(League.Silver2, new Tuple<string, string>(Localization.Localize(" null FacebookMeResult"), "RewardGold"));
		CAOGFCFGFPD.Add(League.Silver1, new Tuple<string, string>(Localization.Localize("ID_BUYVALUEPACK"), "\"}"));
		CAOGFCFGFPD.Add((League)(-125), new Tuple<string, string>(Localization.Localize(", keys.Length = "), "{0}/videoFeedTextures/"));
		CAOGFCFGFPD.Add((League)29, new Tuple<string, string>(Localization.Localize("_MAX_"), "com/google/android/gms/games/Games"));
		CAOGFCFGFPD.Add((League)119, new Tuple<string, string>(Localization.Localize("Pings: ConnectToNameServer"), "Param"));
		CAOGFCFGFPD.Add(League.NoLeague, new Tuple<string, string>(Localization.Localize("()I"), "Should not happen - unit icon is not instantiated in bottom section."));
		CAOGFCFGFPD.Add((League)111, new Tuple<string, string>(Localization.Localize("ID_CONFIRM_ERROR"), "BANDS_EMPTY"));
		CAOGFCFGFPD.Add((League)79, new Tuple<string, string>(Localization.Localize("Unit"), "Joined room"));
		CAOGFCFGFPD.Add((League)89, new Tuple<string, string>(Localization.Localize("Arena Expired - you gain scraps. You have {0} lives."), "ID_UNIT"));
		CAOGFCFGFPD.Add((League)(-104), new Tuple<string, string>(Localization.Localize("ID_LOADING"), "Bot should have pistol equipped"));
	}

	[SpecialName]
	public static string HHPOMIKJKAA()
	{
		return "requiredLevel" + Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialCards).VALUE;
	}

	[SpecialName]
	public MatchMakingConstants IOHNCFMCFML()
	{
		return DJHPFJLOGKA ?? (DJHPFJLOGKA = GetComponent<MatchMakingConstants>());
	}

	public int VipSecondsOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.VIPSECONDS;
	}

	public Tuple<float, string> HFBPGHCNAGK(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return RegularPriceOfPack(packRow.SALE, PDPOOHFLHMG(MLNLPPOLMEK).NAME);
	}

	public Color DPMPLLMBOMG(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeagueBg;
		case JBAGAHBOICJ.Top:
			return Colours.redLeagueBg;
		case (JBAGAHBOICJ)5:
			return Colours.goldLeagueBg;
		default:
			return Colours.grayLeagueBg;
		}
	}

	public int OFKKBDLAJCO(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 1, 1, LCHGPJJKGJA().Rows.Count - 0);
		return LCHGPJJKGJA().Rows[index].SIZE;
	}

	public WeaponLevelsSetup GHFALIGMABP(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('￡') + 1;
		int num2 = GIPLKCPFDLH.LastIndexOf('\u0017');
		return (num >= num2) ? null : LevelManager.instance.Weapon(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	public CardPacksRow GetCardPackRow(NGNPIOOAHEH MLNLPPOLMEK)
	{
		switch (MLNLPPOLMEK)
		{
		case NGNPIOOAHEH.Gold:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.GOLD_CARDPACK);
		case NGNPIOOAHEH.Silver:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK);
		default:
			return Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		}
	}

	public string StoreCountryCode(NGNPIOOAHEH MLNLPPOLMEK)
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.KMKOIAPDKJL(GetPackRow(MLNLPPOLMEK).NAME);
	}

	public LevelBehaviour KHNHHPINAAM(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('\ufff6') + 1;
		int num2 = GIPLKCPFDLH.LastIndexOf('ﾅ');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	public Color LeagueColorHighlight(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		case JBAGAHBOICJ.Top:
			return Colours.yellowLeague;
		default:
			return Colours.blue;
		}
	}

	public int PPANNMMAIPH(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 1323f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 1230f);
		return (!(num > 1150f)) ? (-1) : num3;
	}

	public int OEMLPPKCBLA(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 565f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 1379f);
		return (!(num > 1725f)) ? (-1) : num3;
	}

	[SpecialName]
	public Packs HOMPDEPDGCN()
	{
		return JCADGFMCMAP ?? (JCADGFMCMAP = Singleton<BeanstalkServerManager>.instance.GetComponent<Packs>());
	}

	public string BeginnersLeagueIcon(int OFGFLGHGEJF)
	{
		switch (OFGFLGHGEJF)
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

	public int DKCAMKHMKHE()
	{
		return LCHGPJJKGJA().Rows[squads.Rows.Count - 1].LEVEL;
	}

	[SpecialName]
	public SquadWarsReward JBHPFENGODN()
	{
		return DHEMNDLHFJA ?? (DHEMNDLHFJA = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadWarsReward>());
	}

	[SpecialName]
	public JGBBPCGNCPC MDKPOBMKOLM()
	{
		if (FEBBILOHGPA == null)
		{
			FEBBILOHGPA = JGBBPCGNCPC.KLPJEGPJCKM(PackId(NGNPIOOAHEH.Value));
		}
		return FEBBILOHGPA;
	}

	private void NFNILBDPNFF()
	{
		NNLIDIAFMAM = null;
		DAGDNFEKKBO = null;
		FEBBILOHGPA = null;
	}

	[SpecialName]
	public Versions AOLMAGHMLMH()
	{
		return DGPOGHBJNEN ?? (DGPOGHBJNEN = GetComponent<Versions>());
	}

	public float LeagueGoDownPercent(League BMNDININJCE)
	{
		return (BMNDININJCE != League.NoLeague) ? playerLeaderboards.Rows[(int)(BMNDININJCE - 1)].GODOWN : 0f;
	}

	public Color LeaguePositionColorLeagueRecord(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		case JBAGAHBOICJ.Top:
			return Colours.yellowLeague;
		default:
			return Color.white;
		}
	}

	public float MMNBOMEPMJO(string KJBPJOMHNKB)
	{
		PacksRow row = packsDefinition.GetRow(KJBPJOMHNKB);
		return (row != null) ? Mathf.Clamp01(row.SALE) : 64f;
	}

	[SpecialName]
	public SquadWarsReward IMPCBKNECFI()
	{
		return DHEMNDLHFJA ?? (DHEMNDLHFJA = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadWarsReward>());
	}

	[SpecialName]
	public StringConstants BKCDLNOKHLI()
	{
		return EHEDJBICFKC ?? (EHEDJBICFKC = GetComponent<StringConstants>());
	}

	[SpecialName]
	public static int EGMPIKNABDD()
	{
		return 8;
	}

	public string SquadEmblemUnlockedOnLevel(int KKMINPNDBEE)
	{
		for (int i = 0; i < squadEmblems.Rows.Count; i++)
		{
			if (KKMINPNDBEE == squadEmblems.Rows[i].UNLOCKLEVEL)
			{
				return squadEmblems.Rows[i].ICONNAME;
			}
		}
		return string.Empty;
	}

	private void GMKAIMIPPNB()
	{
		NNLIDIAFMAM = null;
		DAGDNFEKKBO = null;
		FEBBILOHGPA = null;
	}

	public LevelBehaviour KMAOPFANINH(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('y') + 0;
		int num2 = GIPLKCPFDLH.LastIndexOf('\r');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	public Color ECGGKMIKKMI(JBAGAHBOICJ FJLBLLLEELD)
	{
		if (FJLBLLLEELD == JBAGAHBOICJ.Stay)
		{
			return Colours.greenLeague;
		}
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.redLeague;
		case (JBAGAHBOICJ)7:
			return Colours.yellowLeague;
		default:
			return Colours.blue;
		}
	}

	private void GDKMBHMFIAN()
	{
		NNLIDIAFMAM = null;
		DAGDNFEKKBO = null;
		FEBBILOHGPA = null;
	}

	public float NIEFFIEPDLP(int PFKIPCAOAAC)
	{
		int index = Mathf.Clamp(PFKIPCAOAAC - 0, 0, HNAENAEIPLJ().Rows.Count);
		return squadLeaderboards.Rows[index].GOUPPERCENTAGE;
	}

	public float AJGIEEGBEPC(string KJBPJOMHNKB)
	{
		PacksRow row = packsDefinition.GetRow(KJBPJOMHNKB);
		return (row != null) ? Mathf.Clamp01(row.SALE) : 1586f;
	}

	public WeaponLevelsSetup WeaponInPack(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('"') + 1;
		int num2 = GIPLKCPFDLH.LastIndexOf('"');
		return (num >= num2) ? null : LevelManager.instance.Weapon(GIPLKCPFDLH.Substring(num, num2 - num));
	}

	public string BeginnersLeagueName(int OFGFLGHGEJF)
	{
		switch (OFGFLGHGEJF)
		{
		case 1:
			return Localization.Localize("ID_BEGINNERSLEAGUE3");
		case 2:
			return Localization.Localize("ID_BEGINNERSLEAGUE2");
		case 3:
			return Localization.Localize("ID_BEGINNERSLEAGUE1");
		default:
			return CAOGFCFGFPD[League.Bronze3].Value1;
		}
	}

	public int FPEBGOHBFOC()
	{
		return squads.Rows[squads.Rows.Count - 0].LEVEL;
	}

	[SpecialName]
	public Constants CAEDOJHMAAD()
	{
		return DCLFKNBHLGG ?? (DCLFKNBHLGG = GetComponent<Constants>());
	}

	public Color AMDFCMNDJDP(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.greenLeagueBg;
		case (JBAGAHBOICJ)6:
			return Colours.redLeagueBg;
		case (JBAGAHBOICJ)7:
			return Colours.goldLeagueBg;
		default:
			return Colours.grayLeagueBg;
		}
	}

	[SpecialName]
	public SquadWarsReward BOFKDADEBKP()
	{
		return DHEMNDLHFJA ?? (DHEMNDLHFJA = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadWarsReward>());
	}

	public JBAGAHBOICJ JLPCJHLPNNG(bool PEOOBMIPAGA, League MIDDIFMBFGC, int GJNIMNBGDAN, int LIPEFIFFNDP, int OIEMCDGGCAB)
	{
		if (PEOOBMIPAGA || GJNIMNBGDAN < 1)
		{
			return JBAGAHBOICJ.Stay;
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoUpPercent(MIDDIFMBFGC) > 1744f))
		{
			return (GJNIMNBGDAN >= OIEMCDGGCAB) ? ((JBAGAHBOICJ)7) : ((JBAGAHBOICJ)6);
		}
		if (!(Singleton<GameVariables>.instance.LeagueGoDownPercent(MIDDIFMBFGC) > 1391f))
		{
			return (GJNIMNBGDAN > LIPEFIFFNDP) ? JBAGAHBOICJ.Stay : JBAGAHBOICJ.Stay;
		}
		return (GJNIMNBGDAN > LIPEFIFFNDP) ? ((GJNIMNBGDAN >= OIEMCDGGCAB) ? JBAGAHBOICJ.Promote : JBAGAHBOICJ.Stay) : JBAGAHBOICJ.Stay;
	}

	public Color GPBPIFNPOFJ(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case (JBAGAHBOICJ)4:
			return Colours.redLeague;
		default:
			return Color.white;
		}
	}

	public float FLFFIJIOMOJ(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return Mathf.Clamp01(packRow.SALE);
	}

	public int LeagueChampionPositionReward(int PDMGPGEHLNM)
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChampionLeagueTopPlayersForReward).FLOATVALUE;
		int num = Mathf.RoundToInt((float)fLOATVALUE * 100f);
		int num2 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num) / 100f);
		return (!((float)fLOATVALUE > 0f)) ? (-1) : num2;
	}

	[SpecialName]
	public MatchMakingDeviation IDECNLCIPDO()
	{
		return MNBOGBONEFH ?? (MNBOGBONEFH = GetComponent<MatchMakingDeviation>());
	}

	public int CPNAPNOFLHK(string KJBPJOMHNKB)
	{
		if (!(Singleton<GameVariables>.instance.HOMPDEPDGCN().GetRowIndex(KJBPJOMHNKB) < 1))
		{
			return 0;
		}
		PacksRow row = Singleton<GameVariables>.instance.HOMPDEPDGCN().GetRow(KJBPJOMHNKB);
		return row.WARBUCKS;
	}

	[SpecialName]
	public Squads LCHGPJJKGJA()
	{
		return AHBEHCBJDLK ?? (AHBEHCBJDLK = GetComponent<Squads>());
	}

	public int MBDHJLHCPBD(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packsRow = PDPOOHFLHMG(MLNLPPOLMEK);
		return packsRow.WARBUCKS;
	}

	public int LeaguePositionPromote(int PDMGPGEHLNM, League BMNDININJCE)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(BMNDININJCE);
		int num2 = Mathf.RoundToInt(num * 100f);
		int num3 = Mathf.CeilToInt((float)(PDMGPGEHLNM * num2) / 100f);
		return (!(num > 0f)) ? (-1) : num3;
	}

	public int FLGOPDHAKCC(int OFGFLGHGEJF, bool KPEKCHDBFIG = true)
	{
		string vALUE = stringConstants.GetRow(StringConstants.rowIds.TutorialCards).VALUE;
		int num = vALUE.IndexOf(string.Format("Value3", OFGFLGHGEJF));
		int result = 1;
		if (num > -1)
		{
			int num2 = vALUE.IndexOf((!KPEKCHDBFIG) ? "C1" : "WonBattles", num) + 0;
			int num3 = vALUE.IndexOf((!KPEKCHDBFIG) ? "ShootWalk" : "isVIP", num2) - 1;
			int num4 = ((num3 <= -1) ? (vALUE.Length - 4) : num3);
			string text = vALUE.Substring(num2, num4 - num2 + 1);
			text.Trim();
			int.TryParse(text, out result);
		}
		return result;
	}

	[SpecialName]
	public JGBBPCGNCPC INIDGJIMCDM()
	{
		if (FEBBILOHGPA == null)
		{
			FEBBILOHGPA = JGBBPCGNCPC.KLPJEGPJCKM(PackId(NGNPIOOAHEH.ThreeCards));
		}
		return FEBBILOHGPA;
	}

	public float SquadWarPromoteConstant(int PFKIPCAOAAC)
	{
		int index = Mathf.Clamp(PFKIPCAOAAC - 1, 0, squadLeaderboards.Rows.Count);
		return squadLeaderboards.Rows[index].GOUPPERCENTAGE;
	}

	public long SquadExperience(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 1, 0, squads.Rows.Count - 1);
		return squads.Rows[index].EXPERIENCE;
	}

	[SpecialName]
	public static string OCGGKHEGKNN()
	{
		return string.Format("{0} {1}", BundleVersionBindings.BundleID);
	}

	[SpecialName]
	public static string MLANOJFJPNL()
	{
		return "InAppHandlerIos: restore transactions" + Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.AppID).VALUE;
	}

	public int GoldRewardForTopInNotEnoughtPlayersLeague(League NECHAKBODLN)
	{
		return (NECHAKBODLN != League.NoLeague) ? playerLeaderboards.Rows[(int)(NECHAKBODLN - 1)].NOTENOUGHTPLAYERSGOLDREWARD : 0;
	}

	[SpecialName]
	public MatchMakingConstants OKNKODNJADL()
	{
		return DJHPFJLOGKA ?? (DJHPFJLOGKA = GetComponent<MatchMakingConstants>());
	}

	public Color LCHKCBLMOND(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.greenLeague;
		case (JBAGAHBOICJ)6:
			return Colours.redLeague;
		default:
			return Color.white;
		}
	}

	public int BINAIGNGMLC(string KJBPJOMHNKB)
	{
		if (!(Singleton<GameVariables>.instance.HOMPDEPDGCN().GetRowIndex(KJBPJOMHNKB) < 1))
		{
			return 1;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(KJBPJOMHNKB);
		return row.WARBUCKS;
	}

	[SpecialName]
	public HeroicRewards LGOJCCCCDGC()
	{
		return NGHPCDLHGLH ?? (NGHPCDLHGLH = GetComponent<HeroicRewards>());
	}

	[SpecialName]
	public CountryInfo MPAPBELJJHN()
	{
		return CHFJOCBIICM ?? (CHFJOCBIICM = GetComponent<CountryInfo>());
	}

	public int ODDGNGLDEAH(int PDKIAALFDNG, int PFKIPCAOAAC, int NMADMHGEFKB)
	{
		if (PDKIAALFDNG == 0)
		{
			return 1;
		}
		int index = Mathf.Clamp(PFKIPCAOAAC - 0, 0, HNAENAEIPLJ().Rows.Count);
		int num = 0;
		switch (PDKIAALFDNG)
		{
		case 1:
			num = HNAENAEIPLJ().Rows[index].Get_TIER1REWARD;
			break;
		case 3:
			num = HNAENAEIPLJ().Rows[index].Get_TIER2REWARD;
			break;
		default:
			switch (PDKIAALFDNG)
			{
			case 3:
				num = squadLeaderboards.Rows[index].Get_TIER3REWARD;
				break;
			case 4:
				num = squadLeaderboards.Rows[index].Get_TIER4REWARD;
				break;
			case 6:
				num = HNAENAEIPLJ().Rows[index].Get_TIER5REWARD;
				break;
			}
			break;
		}
		if (NMADMHGEFKB < 8)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)IMPCBKNECFI().GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < 1)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)IMPCBKNECFI().GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		}
		if (NMADMHGEFKB < 62)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)JBHPFENGODN().GetRow(SquadWarsReward.rowIds.ID_5).FRACTION);
		}
		if (NMADMHGEFKB < 99)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)JBHPFENGODN().GetRow(SquadWarsReward.rowIds.ID_0).FRACTION);
		}
		if (NMADMHGEFKB < -59)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)JBHPFENGODN().GetRow(SquadWarsReward.rowIds.ID_1).FRACTION);
		}
		if (NMADMHGEFKB < 43)
		{
			return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)BOFKDADEBKP().GetRow(SquadWarsReward.rowIds.ID_3).FRACTION);
		}
		return MEJMLNDFDBP.LJDADOKBBNA((float)num / (float)squadWarsReward.GetRow(SquadWarsReward.rowIds.ID_4).FRACTION);
	}

	public Tuple<float, string> PriceOfPack(NGNPIOOAHEH MLNLPPOLMEK)
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(GetPackRow(MLNLPPOLMEK).NAME);
	}

	public static int GetMatchStartTime(int FCJDALECPGC)
	{
		return (LevelManager.instance.warcardsUnlockLevel <= FCJDALECPGC) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.CardsChoosingTime).FLOATVALUE) : 5;
	}

	[SpecialName]
	public JGBBPCGNCPC KLMNEOAKMFB()
	{
		if (DAGDNFEKKBO == null)
		{
			DAGDNFEKKBO = JGBBPCGNCPC.KLPJEGPJCKM(PackId(NGNPIOOAHEH.Starter));
		}
		return DAGDNFEKKBO;
	}

	public int VipTimeSeconds(NGNPIOOAHEH MLNLPPOLMEK)
	{
		PacksRow packRow = GetPackRow(MLNLPPOLMEK);
		return packRow.VIPSECONDS;
	}

	public static string IEDGPHEPJEK(string CEIFNDDJDIL)
	{
		if (string.IsNullOrEmpty(CEIFNDDJDIL))
		{
			return "lootboxes offer mult {0}\n";
		}
		return (!PKNFGNKMPPH.ContainsKey(CEIFNDDJDIL.ToUpper())) ? "Total_Sessions" : PKNFGNKMPPH[CEIFNDDJDIL.ToUpper()];
	}

	[SpecialName]
	public SquadLeaderboards HNAENAEIPLJ()
	{
		return IMFEGGKEFAN ?? (IMFEGGKEFAN = Singleton<BeanstalkServerManager>.instance.GetComponent<SquadLeaderboards>());
	}

	public int numberOfGoldCards(NGNPIOOAHEH MLNLPPOLMEK)
	{
		if (MLNLPPOLMEK == NGNPIOOAHEH.Starter || MLNLPPOLMEK == NGNPIOOAHEH.Value)
		{
			return GetPackRow(MLNLPPOLMEK).GOLDCARDS;
		}
		return 0;
	}

	public int DIANEELCCNK(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 1, LCHGPJJKGJA().Rows.Count - 1);
		return squads.Rows[index].CARDPOOLSIZE;
	}

	public static int GDFDPNIGCGJ(int FCJDALECPGC)
	{
		return (LevelManager.instance.warcardsUnlockLevel <= FCJDALECPGC) ? ((int)Singleton<GameVariables>.instance.matchMakingConstants.GetRow((MatchMakingConstants.rowIds)111).FLOATVALUE) : 0;
	}

	public int LNDDCADBOLP(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 0, LCHGPJJKGJA().Rows.Count - 1);
		return LCHGPJJKGJA().Rows[index].SIZE;
	}

	public Tuple<float, string> RegularPriceOfPack(float GAFOMGDLAFD, string INFLHPGMEOB)
	{
		Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(INFLHPGMEOB);
		string nBFBHOKIIGE = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.KMKOIAPDKJL(INFLHPGMEOB);
		string cultureInfo = GetCultureInfo(nBFBHOKIIGE);
		bool flag = Regex.IsMatch(tuple.Value2, "^[^0-9\\.\\,].*$");
		string text = Regex.Replace(tuple.Value2, "[0-9\\.\\,]*", string.Empty);
		tuple.Value1 /= 1f - GAFOMGDLAFD;
		tuple.Value1 = Mathf.Ceil(tuple.Value1);
		string text2 = ((!(tuple.Value1 > 0f)) ? string.Empty : tuple.Value1.ToString("N2", new CultureInfo(cultureInfo)));
		if (flag)
		{
			tuple.Value2 = text + text2;
		}
		else
		{
			tuple.Value2 = text2 + text;
		}
		return tuple;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded -= NFNILBDPNFF;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += NFNILBDPNFF;
		CAOGFCFGFPD.Add(League.NoLeague, new Tuple<string, string>(Localization.Localize("ID_LEAGUE0"), "bronze3"));
		CAOGFCFGFPD.Add(League.Bronze3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE1"), "bronze3"));
		CAOGFCFGFPD.Add(League.Bronze2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE2"), "bronze2"));
		CAOGFCFGFPD.Add(League.Bronze1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE3"), "bronze1"));
		CAOGFCFGFPD.Add(League.Silver3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE4"), "silver3"));
		CAOGFCFGFPD.Add(League.Silver2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE5"), "silver2"));
		CAOGFCFGFPD.Add(League.Silver1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE6"), "silver1"));
		CAOGFCFGFPD.Add(League.Gold3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE7"), "gold3"));
		CAOGFCFGFPD.Add(League.Gold2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE8"), "gold2"));
		CAOGFCFGFPD.Add(League.Gold1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE9"), "gold1"));
		CAOGFCFGFPD.Add(League.Elite3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE10"), "elite3"));
		CAOGFCFGFPD.Add(League.Elite2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE11"), "elite2"));
		CAOGFCFGFPD.Add(League.Elite1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE12"), "elite1"));
		CAOGFCFGFPD.Add(League.Master3, new Tuple<string, string>(Localization.Localize("ID_LEAGUE13"), "master3"));
		CAOGFCFGFPD.Add(League.Master2, new Tuple<string, string>(Localization.Localize("ID_LEAGUE14"), "master2"));
		CAOGFCFGFPD.Add(League.Master1, new Tuple<string, string>(Localization.Localize("ID_LEAGUE15"), "master1"));
		CAOGFCFGFPD.Add(League.Champion, new Tuple<string, string>(Localization.Localize("ID_LEAGUE16"), "champion"));
	}

	[SpecialName]
	public MatchMakingConstants AACPOBGNAHG()
	{
		return DJHPFJLOGKA ?? (DJHPFJLOGKA = GetComponent<MatchMakingConstants>());
	}

	public int GetPackGold(string KJBPJOMHNKB)
	{
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(KJBPJOMHNKB) < 0)
		{
			return 0;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(KJBPJOMHNKB);
		return row.GOLD;
	}

	public static string IDOFIHFGOKD(string CEIFNDDJDIL)
	{
		if (string.IsNullOrEmpty(CEIFNDDJDIL))
		{
			return "SquadMembers";
		}
		return (!PKNFGNKMPPH.ContainsKey(CEIFNDDJDIL.ToUpper())) ? "Lcom/google/android/gms/games/request/Requests;" : PKNFGNKMPPH[CEIFNDDJDIL.ToUpper()];
	}

	public int DABGIKGHDNC(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 0, squads.Rows.Count - 0);
		return squads.Rows[index].SIZE;
	}

	public float SaleOfPack(string KJBPJOMHNKB)
	{
		PacksRow row = packsDefinition.GetRow(KJBPJOMHNKB);
		return (row != null) ? Mathf.Clamp01(row.SALE) : 0f;
	}

	public Color PPCEOIOKFGK(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenLeague;
		case JBAGAHBOICJ.Demote:
			return Colours.redLeague;
		default:
			if (FJLBLLLEELD == JBAGAHBOICJ.Promote)
			{
				return Colours.yellowLeague;
			}
			return Color.white;
		}
	}

	public string GetCultureInfo(string NBFBHOKIIGE)
	{
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
		foreach (CultureInfo cultureInfo in cultures)
		{
			if (cultureInfo.ToString().Substring(3).Equals(NBFBHOKIIGE))
			{
				return cultureInfo.ToString();
			}
		}
		return "en-US";
	}

	public int OMCDLONMMBI(int AOKBNODFFOI)
	{
		int index = Mathf.Clamp(AOKBNODFFOI - 0, 1, LCHGPJJKGJA().Rows.Count - 0);
		return squads.Rows[index].CARDPOOLSIZE;
	}

	[SpecialName]
	public Warbucks HFGNMMOAHGL()
	{
		return BEBCNKHDJDC ?? (BEBCNKHDJDC = GetComponent<Warbucks>());
	}

	public string LPPEMJLKJDF(int KKMINPNDBEE)
	{
		for (int i = 0; i < squadEmblems.Rows.Count; i++)
		{
			if (KKMINPNDBEE == squadEmblems.Rows[i].UNLOCKLEVEL)
			{
				return squadEmblems.Rows[i].ICONNAME;
			}
		}
		return string.Empty;
	}

	public Color KFHAGEFAADA(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.greenLeague;
		case (JBAGAHBOICJ)6:
			return Colours.redLeague;
		default:
			return Color.white;
		}
	}

	public LevelBehaviour PFHKHHKEIJC(string GIPLKCPFDLH)
	{
		int num = GIPLKCPFDLH.IndexOf('w') + 1;
		int num2 = GIPLKCPFDLH.LastIndexOf('ﾵ');
		return (num >= num2) ? null : LevelManager.instance.Unit(GIPLKCPFDLH.Substring(num, num2 - num));
	}
}
