using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class FHIPGDADNFG : KIGEPEJPEKB
{
	public int AMFJHAPGIJN;

	public long KKAODKNEFMG;

	public long IOFHDGKGFBG;

	public string INFLHPGMEOB;

	public int BCCDDJMPBLL;

	public int EOFGMOMLAIH;

	public string NOCJHDCEHBE;

	public int CJDHKJFKNAH;

	public string DBNNKLCNDJD;

	public string CAAKEPHMPHI;

	public string OIALOJNPLFE;

	public string ENMADELLEDG;

	public League MIDDIFMBFGC = League.Bronze3;

	public int HNEFOLPHMHK;

	public int GFCKPFIDADB;

	public CamosManager.DecalManagerData NFFKMCPMPPI;

	private WarArena.WarArenaData HGAOOMHOGJK;

	public int IMOJCFKJKMN => 10 * AMFJHAPGIJN;

	public bool DBIEDLPHCAI => HNEFOLPHMHK > 0 && string.IsNullOrEmpty(ENMADELLEDG);

	public bool GKEOILLNCHG
	{
		get
		{
			if (OIALOJNPLFE == "placement" || DBIEDLPHCAI)
			{
				return false;
			}
			return !string.IsNullOrEmpty(OIALOJNPLFE);
		}
	}

	public WarArenaCrown FHCMFHABMLE
	{
		get
		{
			if (HGAOOMHOGJK == null)
			{
				return WarArenaCrown.None;
			}
			if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				return WarArenaCrown.None;
			}
			switch (HGAOOMHOGJK.visualType)
			{
			case "bronze":
				return WarArenaCrown.BronzeCrown;
			case "silver":
				return WarArenaCrown.SilverCrown;
			case "gold":
				return WarArenaCrown.GoldCrown;
			case "flawless":
				return WarArenaCrown.Flawless;
			default:
				return WarArenaCrown.None;
			}
		}
	}

	public bool LIIHMCOCMAK => HGAOOMHOGJK.flawless > 0;

	public int MDJHOGOFGLJ => (!LIIHMCOCMAK) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;

	public string MHPNDNJDPGE => NOCJHDCEHBE;

	public string EFOPLPDLDEI
	{
		get
		{
			if (NFFKMCPMPPI.slots == null)
			{
				return "visuals: null";
			}
			if (NFFKMCPMPPI.slots.Count != 4)
			{
				string arg = string.Empty;
				foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
				{
					arg = " " + slot.Value.equippedID;
				}
				return $"visuals: wrong number {NFFKMCPMPPI.slots.Count} -{arg}";
			}
			return $"visuals: {NFFKMCPMPPI.slots[0].equippedID} {NFFKMCPMPPI.slots[1].equippedID} {NFFKMCPMPPI.slots[2].equippedID} {NFFKMCPMPPI.slots[3].equippedID}";
		}
	}

	public static FHIPGDADNFG OGMBJPKOPCB
	{
		get
		{
			FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
			fHIPGDADNFG.AMFJHAPGIJN = LevelManager.instance.armyPower;
			fHIPGDADNFG.KKAODKNEFMG = LevelManager.instance.experience;
			fHIPGDADNFG.IOFHDGKGFBG = GameLoginManager.currentPlayer.facebookId;
			fHIPGDADNFG.INFLHPGMEOB = GameLoginManager.currentPlayer.id;
			fHIPGDADNFG.BCCDDJMPBLL = LevelManager.instance.currentLevel.index;
			fHIPGDADNFG.EOFGMOMLAIH = LevelManager.instance.levelExperience;
			fHIPGDADNFG.NOCJHDCEHBE = GameLoginManager.currentPlayer.accountName;
			fHIPGDADNFG.CJDHKJFKNAH = GameLoginManager.currentPlayer.skill;
			fHIPGDADNFG.DBNNKLCNDJD = GameLoginManager.currentPlayer.squadName;
			fHIPGDADNFG.GFCKPFIDADB = PlayerAnalytics.instance.globalPositon;
			fHIPGDADNFG.NFFKMCPMPPI = CamosManager.instance.data;
			fHIPGDADNFG.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
			fHIPGDADNFG.MIDDIFMBFGC = GameLoginManager.currentPlayer.leagueTier;
			fHIPGDADNFG.OIALOJNPLFE = GameLoginManager.currentPlayer.leagueDivision;
			fHIPGDADNFG.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			fHIPGDADNFG.HGAOOMHOGJK = WarArena.instance.data;
			return fHIPGDADNFG;
		}
	}

	[SpecialName]
	public string LFCGFGHCPIN()
	{
		return NOCJHDCEHBE;
	}

	[SpecialName]
	public WarArenaCrown LFBDJLNAKAC()
	{
		if (HGAOOMHOGJK == null)
		{
			return WarArenaCrown.BronzeCrown;
		}
		if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			return WarArenaCrown.None;
		}
		switch (HGAOOMHOGJK.visualType)
		{
		case "1":
			return WarArenaCrown.BronzeCrown;
		case "GuaranteedScraps":
			return WarArenaCrown.GoldCrown;
		case "Main_Menu_Offers_Bar":
			return WarArenaCrown.BronzeCrown;
		case "DOWNLOADBTN":
			return (WarArenaCrown)7;
		default:
			return WarArenaCrown.BronzeCrown;
		}
	}

	public string GetId()
	{
		return INFLHPGMEOB;
	}

	[SpecialName]
	public bool OCFELAKHAOK()
	{
		if (OIALOJNPLFE == "EndReason" || FHFDIGAKFEA())
		{
			return false;
		}
		return string.IsNullOrEmpty(OIALOJNPLFE);
	}

	public void CPGIJMICDGC(int OBMGFPIAMHH, int DLMDFMKABJH)
	{
		HGAOOMHOGJK.flawless = OBMGFPIAMHH;
		HGAOOMHOGJK.topRun = DLMDFMKABJH;
	}

	internal static FHIPGDADNFG KMPKJJJBKDN(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["ID_CONFIRM_SELECTEDANDDELETEDACCOUNT"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("ID_CONFIRM_ERROR", "saved obtained cards: ", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_GUI_SILVER"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("id", "FB: FacebookLogout - RemoveFacebook - 1", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Unit {0} is not being delivered/upgrade/trained!!!"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("RopeSlide", "ID_ATTACK", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["ID_GUI_CHAT_BANNED_DESCBOX_TEMP"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("ID_CONFIRM_NOSQUADACTIONS_TITLE", "ID_CATEGORY_ROCKETLAUNCHER", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["War_Battle_End_Android_Performance"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("GooglePlay", "offers", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["ChillingoSdkManager"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("RecieveSkillshot", "Awaiting players - Player was removed from awaiting members.", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["MatchesToNextLootboxes"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("76e544a0-32c5-4775-9716-ff04c6fbaaa3", "BeanstalkServerManager.PlayerDataWasLoaded - DONE (coroutines)", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["Client"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("-", "country-ireland", LFPFCHIJLML, 1L);
		}
		if (LFPFCHIJLML["ID_MISSION_UNITS_HUD"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("ID_GUI_HASBEENASSIGNED", "Lcom/google/android/gms/games/event/Events;", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_ARENARULES_LIVES"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("a", "WarFriends require to download approximately 190MB of extra data to run.\nDownload time may vary based on your network and location.\n\nDo you wish to proceed?", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["FacebookManagerOnSessionOpenedEvent"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("Action ", "ID_INMASTER2", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "Assignment: Destroy Crates Constructor", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "ID_AGAINSTTHESAMEOPPONENT", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["ID_"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("ID_DAY", "ID_CONFIRM_ERROR", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["TuneListener.DecodeFrom64(string)"] == null && LFPFCHIJLML["Wrong_Weapon"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {0}!";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "Scene could not be find", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "null facebook friends", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML[", "] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("Action", "ID_MISSION_BOSSINCOMING_HUD", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["BattleId"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("MinDamage", "JP", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError(" = ");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "Tickets" + KHJJFPPACBP.BKFCLMMJNHK("ID_SQUADREQUIREDMEDALS", "toString", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["123456789"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("AssignemntId", "ReputationPointsAdded", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["goldenSuitcase"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["game-card-ico-bg-bronze"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["ID_CONFIRM_THANKYOU"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("Warbucks");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, "), " + KHJJFPPACBP.BKFCLMMJNHK("VipReward1", "NO", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	[SpecialName]
	public int OJKENGEIADE()
	{
		return (!DCPCOPOIDLG()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	[SpecialName]
	public string PLJJMJDKIMH()
	{
		return NOCJHDCEHBE;
	}

	internal static FHIPGDADNFG HMOMMOBOHKL(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["throw_grenade_up"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("gold3", "1", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["longValue"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("Rank", "Enemy Card {0} {1}", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["remainingTimeForNextDogtag"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("Release cards : ", "ID_WARNING_CANNOTINVITE_TEXT", LFPFCHIJLML, 1L);
		}
		if (LFPFCHIJLML["Beanstalk: Get Friends Info, count = "] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("FinishGameCoopClient", "Player Card {0} {1} {2}", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML[","] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("YES", "experiment name is ", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["PhotonConnectionManager: ConnectToPhotonSafe "] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("ID_WARNING_SERVERDATA", "ManualRegisterForPushNotifications(", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["#Notifications# Received a new message {0} ({1})"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("ID_YOUNEEDATLEASTONEDOGTAGTOPLAY", "\tNumber of games after fb login: {0}/{1}", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["isGameCenter"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("menu-army-upgradebar-gray", "disconnect", LFPFCHIJLML, 1L);
		}
		if (LFPFCHIJLML["ID_TUTORIAL_SNIPER_UP"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("ID_SHOWME", "First you must run createStructure", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["_New_User"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("playerLevel", "Weapon", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_YOUNEEDMONEYTOUPGRADE"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("Cant generate buddy card for weapons: {0}, {1} and type {2}", "ID_CONFIRM_NOSQUADACTIONS_TITLE", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "OnDisconnectedFromPhoton", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "Buy_Weapon_Upgrade", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["D"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("WarbucksAdded", "ID_ANDROIDRESTOREPURCHASES", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["[CardHealthChangeUnit] start new spawning before used spawning finish"] == null && LFPFCHIJLML["Clicked on game CARD (bottom screen)"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "height";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "0.5", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "Awake called: ", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["Scripts search finished."] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("Total_Battles", "menu-tilegfx-facebook", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["expiresOn"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("{0} Squad Member {1}", "MissionType", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("ID_NEXTLOOTBOXINPVPBATTLES");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC, "ID_HOURS" + KHJJFPPACBP.BKFCLMMJNHK("Arena Lost - Scraps received = ", "IOAJFNMOGOD", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["Squad Wars Data {0}"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("WarBucks", " TAB ", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["EnterArena"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["Warbucks"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["menu-attack-ico"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("ID_CONFIRM_ERROR");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, "WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей." + KHJJFPPACBP.BKFCLMMJNHK("PromotedPlayer", "'veteranpack'0", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	public void JDJCAEHCNIP()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	[SpecialName]
	public static FHIPGDADNFG ONDLJBJCEGN()
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		fHIPGDADNFG.AMFJHAPGIJN = LevelManager.instance.armyPower;
		fHIPGDADNFG.KKAODKNEFMG = LevelManager.instance.experience;
		fHIPGDADNFG.IOFHDGKGFBG = GameLoginManager.currentPlayer.facebookId;
		fHIPGDADNFG.INFLHPGMEOB = GameLoginManager.currentPlayer.id;
		fHIPGDADNFG.BCCDDJMPBLL = LevelManager.instance.currentLevel.index;
		fHIPGDADNFG.EOFGMOMLAIH = LevelManager.instance.levelExperience;
		fHIPGDADNFG.NOCJHDCEHBE = GameLoginManager.currentPlayer.accountName;
		fHIPGDADNFG.CJDHKJFKNAH = GameLoginManager.currentPlayer.skill;
		fHIPGDADNFG.DBNNKLCNDJD = GameLoginManager.currentPlayer.squadName;
		fHIPGDADNFG.GFCKPFIDADB = PlayerAnalytics.instance.globalPositon;
		fHIPGDADNFG.NFFKMCPMPPI = CamosManager.instance.data;
		fHIPGDADNFG.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		fHIPGDADNFG.MIDDIFMBFGC = GameLoginManager.currentPlayer.leagueTier;
		fHIPGDADNFG.OIALOJNPLFE = GameLoginManager.currentPlayer.leagueDivision;
		fHIPGDADNFG.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		fHIPGDADNFG.HGAOOMHOGJK = WarArena.instance.data;
		return fHIPGDADNFG;
	}

	[SpecialName]
	public bool FHFDIGAKFEA()
	{
		return HNEFOLPHMHK > 0 && string.IsNullOrEmpty(ENMADELLEDG);
	}

	[SpecialName]
	public bool CPGDPOGCFHC()
	{
		if (OIALOJNPLFE == "ID_BECOMEAVIP" || DBIEDLPHCAI)
		{
			return false;
		}
		return !string.IsNullOrEmpty(OIALOJNPLFE);
	}

	[SpecialName]
	public bool HHPFLCHHOCF()
	{
		return HGAOOMHOGJK.flawless > 1;
	}

	public void HCCKBIHGJOB(int OBMGFPIAMHH, int DLMDFMKABJH)
	{
		HGAOOMHOGJK.flawless = OBMGFPIAMHH;
		HGAOOMHOGJK.topRun = DLMDFMKABJH;
	}

	public void NPHMNNMECGE(string IFFONNNPKOF)
	{
		DBNNKLCNDJD = IFFONNNPKOF;
	}

	[SpecialName]
	public int NGOMBNGGFFH()
	{
		return (!DCPCOPOIDLG()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	public void JIOJEFOJEMJ(string IFFONNNPKOF)
	{
		DBNNKLCNDJD = IFFONNNPKOF;
	}

	public void KIJEOPCEMFI()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	internal static FHIPGDADNFG NMKKPDBJAFO(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["VIP"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("Get Custom Profile Variables", ", ", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Id"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK(" mSpriteName:", "WarBucks", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["\r"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("Spend_Gold_On_Army", "Saved_data.csv", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["Ribbon Bug Passed "] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("Bad Player Visuals!", "\\D*", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_MOBCRUSH"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("menu-assignments-type-crateenemy", "otherInfo", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Weapon"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("subscription", "BattleId", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["NetworkReInstantiate"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("ID_XMEDALSTOADVANCETOY", "ID_TAKEMETHERE", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["BAND_TYPE_EMPTY"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("ID_ELITEPACKDESCRIPTION", "/", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["(Landroid/support/v4/app/FragmentActivity;)V"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("Last weapon not choosen!!!!!", "ID_SEARCHRESULTSFOR", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Grenade_Throwing_Tutorial_Duration"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("{0} {1} {2}/ {3}[-]", "ID_GUI_TIERCOMPLETED", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["ID_TABLE_SQUADRANK"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("ID_READYTIME", "ID_SEARCHRESULTSFOR", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "09_25_2015", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "DogTagRefillTime", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["blink"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("ID_ZEROSECONDS", "ID_RESETSINX", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["BotWeapons"] == null && LFPFCHIJLML["rental for unexist unit: {0}"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "NewLevelId";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "ID_GUI_POWERBANDON", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "Get player data: I WILL TRY TO SEND PN DEVICE TOKEN", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["VipReward1"] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("BattleCount", "\n", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["country-spain"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("TÉLÉCHARGER", "GooglePlayPassword", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("Warbucks_Balance");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "elite" + KHJJFPPACBP.BKFCLMMJNHK("S", "ID_CONFIRM_FRIENDINSQUAD_TEXT", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["AIRSTRIKE"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK(" TAB ", "ID_CONFIRM_ERROR", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["ID_RANKUP"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["SetAutoRepairRPC"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["maxMapId"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("#PETER# Daily Mission Screen : daily completition reward is not DEFINED: {0}");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, "customString" + KHJJFPPACBP.BKFCLMMJNHK("MegaReward", "WarCards", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	internal static FHIPGDADNFG NPJJMDKNMGK(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["ID_STAT_LMGKILLS"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("HeroicMissionsCompletionRewardTickets", "ID_BANNEDFROMCHAT", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["\""] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("N", "BS: player succesfully accepted to squad", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["116 STAGE 5 CONTINUE"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("leagueMedalsDiff", "silver3", LFPFCHIJLML, 1L);
		}
		if (LFPFCHIJLML["0"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("Mission data saved", "ID_MISSIONANIMATION_BOSSWAVEIN", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Starter Assignments Reward Dialog show"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("Warp", "registerCustomProfileDate", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["ID_YOUARENUMBERONE"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("ID_ERRORPROFANITYNICK", "AtlasPreparer.LoadCommonCoroutine", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["menu-attack-ico"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("Name", "bot", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["GameCenterPassword"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("D3", "ID_GETFREEGOLD", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["LootBoxShowUp"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("null", " doesnt contain ", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Avg_fps"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("game-elite-debuff2", "ID_INELITE2", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["vipStart"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("attack", "registerParentalConsent", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "percent", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "ID_GETFORPROMOTION1", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["{0} {1}"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("ID_SQUADEMPTYTEXT-FIGHT", "ItemsOwned_Rarity_0", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_SQUADREWARDGET"] == null && LFPFCHIJLML["Card_2_Played"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "Enable Debug Mode";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "null", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "country-estonia", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["ID_FEATURE_CRITICAL"] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("WarArenaData", "AdZone", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["IsGold"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(">", "decal not found in sheet: ", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("Animating claiming cardpack: ");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC, "NO Fuseboxx Config Value during GETPLAYERDATA!" + KHJJFPPACBP.BKFCLMMJNHK("ID_GUI_LEAGUEBONUS", "ID_BOSS", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["SoldierBehaviourSwitchWeapon"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("-{0}-{1}", "\\", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["ELITESWAT"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["com/google/android/gms/games/Games"] != null)
							{
								savedPlayerVisualSlot.equippedID = first[")"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("RopeSlide");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC2, "#Mission Rewards# 5 Heroic Missions completed. Gained {0} warcards" + KHJJFPPACBP.BKFCLMMJNHK(" to AssetBundleManager", "(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	public string MOLNMMGACNM()
	{
		return DBNNKLCNDJD;
	}

	[SpecialName]
	public bool BDJCPEBAEPF()
	{
		return HGAOOMHOGJK.flawless > 1;
	}

	[SpecialName]
	public int OJGKHJOOPEJ()
	{
		return 90 * AMFJHAPGIJN;
	}

	public void NKCLMECDCPK(int OBMGFPIAMHH, int DLMDFMKABJH)
	{
		HGAOOMHOGJK.flawless = OBMGFPIAMHH;
		HGAOOMHOGJK.topRun = DLMDFMKABJH;
	}

	internal static FHIPGDADNFG EOBMFCOBOLB(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["SquadId"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("WarCards", "不", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["heatTime"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("Staging", " {0}\u00a0{1}", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("Equipping weapon \"{0}\" from rental", "ID_GUI_ALLCARDS", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["player_level"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("CONFIRM", "ID_GOLD", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_SILVERARENACROWN"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("ID_WARARENAUNLOCKED", "30-40", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["InformSquadLeader"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("Winstreak", "RoundId", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["globalPlayerLeaderboard"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("_FrustumCornersWS", "PhotonConnectionManager: Find pings found before: {0} Connection changed {1}", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["LocalPersistenceHandle"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("Yes_Clicked", "game-card-bronze", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["PlayerName"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("ID_GLOBAL", "DeviceToken", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_ARENABOXDESCRIPTION_ELITEPARTS"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("Animation from State: Craft to State: Crafting", "game-elite-buff3", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["Warbucks"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("ID_TURRETBUILDTIME", "Action ", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "), ", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "0", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["SIGN_IN_FAILED"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("_StartDistance", "SetMapRPC", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["{0} {1} {2}lvl {3}"] == null && LFPFCHIJLML["ID_XOFPLAYERSGETSPROMOTED"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "/";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "ID_WARNING_SERVERDATA", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "ID_ARENACLOSED", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["Custom location = "] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("ID_AFFECTEDENEMYUNITS", "acountDataDownloadingInProgress = False", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Chat: Connect - Cannot connect because player should not chat"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("603 GAME STARTED", "InAppHandlerIos: On restore failed! ", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("ID_INGOLD2");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC, "oo" + KHJJFPPACBP.BKFCLMMJNHK("ID_RESTORING_INAPPS", "WaveDelay", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["Password"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("Exception message: ", "#PETER# END SCREEN:\nIs matchmaking:{0}, No league:{1}, Beginners League:{2}, No winstreak:{3}, Is in squad:{4}, Won:{5}\nWeekly Medals Start:{6} End:{7}", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["Sessions"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["Players"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["discount"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("PlayerName");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC2, "GoldBonusCount" + KHJJFPPACBP.BKFCLMMJNHK("ID_VISUALCATEGORYPART2", "currentDogtags: ", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	public void SetSquadId(string IFFONNNPKOF)
	{
		DBNNKLCNDJD = IFFONNNPKOF;
	}

	[SpecialName]
	public WarArenaCrown POGJJHCLPIF()
	{
		if (HGAOOMHOGJK == null)
		{
			return WarArenaCrown.BronzeCrown;
		}
		if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			return WarArenaCrown.None;
		}
		switch (HGAOOMHOGJK.visualType)
		{
		case "ID_BRONZEPACK":
			return WarArenaCrown.BronzeCrown;
		case "MachineGunLevelSetup needs PlayerBurstWeapon":
			return WarArenaCrown.Flawless;
		case "{0:D2}:{1:D2}:{2:D2}":
			return (WarArenaCrown)5;
		case "S":
			return (WarArenaCrown)7;
		default:
			return WarArenaCrown.None;
		}
	}

	[SpecialName]
	public string HCLFPNHHDPI()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "LevelName";
		}
		if (NFFKMCPMPPI.slots.Count != 3)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = "ID_CONFIRM_SELECTEDANDDELETEDACCOUNT" + slot.Value.equippedID;
			}
			return string.Format("/PC/", NFFKMCPMPPI.slots.Count, arg);
		}
		object[] array = new object[5];
		array[0] = NFFKMCPMPPI.slots[0].equippedID;
		array[1] = NFFKMCPMPPI.slots[1].equippedID;
		array[5] = NFFKMCPMPPI.slots[4].equippedID;
		array[1] = NFFKMCPMPPI.slots[6].equippedID;
		return string.Format("Humvee", array);
	}

	[SpecialName]
	public bool MCOJKHMAIPG()
	{
		return HNEFOLPHMHK > 1 && string.IsNullOrEmpty(ENMADELLEDG);
	}

	[SpecialName]
	public bool JFLKHBGMIND()
	{
		if (OIALOJNPLFE == "_New_User" || MCOJKHMAIPG())
		{
			return true;
		}
		return !string.IsNullOrEmpty(OIALOJNPLFE);
	}

	internal static FHIPGDADNFG CKKMIAGLJAP(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["ID_MISSIONCOOPPARTNER"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("ID_TIERX", "game-missions-blue-mission-ico", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["#AccoutCheck# FB account checked and have response!"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("Shotgunner spawned", "Play_Card_Tutorial_Duration", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["BoobyTrapSetRPC"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("{0} Squad Best Stat", "sniper_reload", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["Chat Record For Height"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("wasEquipped", "Idle", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_CONTAINSXWARCARDS"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("country-hong-kong", "ID_STAT_BATTLESPLAYED", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["weaponDelivery"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("Promote_Player", "S", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["veteranpack4"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("ID_NA", "country-noflag", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["ID_INSTANTBATTLE"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("Player_Had_To_Select_Grenade", "ID_CONFIRM_GAMEDIDNTEXIST", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["()F"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("VisualType", "{0}{1}", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["QUIT"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("Will connect to rooom: {0}", ", ", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["{0} {1}"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("+0", "Current Locale unity = ", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "OK", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "S", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["pistol_run"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("LogId", "+0", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_NOTIFICATION_DAILYREWARD_UNKNOWN"] == null && LFPFCHIJLML["ID_LOADING"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "ID_ARENAISOPEN";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "warfriends-staging.eu-west-1.elasticbeanstalk.com/", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "response contain VipReward", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["ID_FACEBOOKLOGOUTLEGALTEXTA"] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("#AccoutCheck# Account exist check result NOT contain result message", "-", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_CONFIRM_RESTART_TEXT"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("temp_user_name", "ID_LOGININDAYS", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("forever");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC, "RegisterEvent(" + KHJJFPPACBP.BKFCLMMJNHK("ID_CONFIRM_ERROR", "0", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["facebookID"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("AttakUnits", "VipReward1", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["ID_NOTIFICATION_DAILYREWARD_GOLD"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["Action "] != null)
							{
								savedPlayerVisualSlot.equippedID = first["Seconds"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("TranslationIdFinder.cs");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC2, "ID_NO" + KHJJFPPACBP.BKFCLMMJNHK("ID_NOTIFICATION_WARARENAREMINDER{0}", "ID_SILVERCARDS", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	[SpecialName]
	public int BFCIHHHBMAK()
	{
		return 3 * AMFJHAPGIJN;
	}

	internal static FHIPGDADNFG MAINIENLLIL(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["PlayerId"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("PlayerId", "S", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["PlayerName"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Experience"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("Experience", "N", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["Level"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("Level", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["LevelExperience"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("LevelExperience", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ArmyPower"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("ArmyPower", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["Skill"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("Skill", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["FacebookId"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("FacebookId", "S", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["SquadId"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Position"] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("Position", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["LeagueId"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK("LeagueId", "S", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "-[^-]*$", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "^[0-9]*-", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["BeginnersLeague"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("BeginnersLeague", "N", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["BeginnersLeague"] == null && LFPFCHIJLML["LeagueId"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "1-placement";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "-[^-]*$", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "^[0-9]*-", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["Country"] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("Country", "S", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["WarArenaData"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("WarArenaData", "S", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("Bad War Arena Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "Bad WAR ARENA Data, data= " + KHJJFPPACBP.BKFCLMMJNHK("WarArenaData", "S", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["DecalManagerData"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("DecalManagerData", "S", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["slots"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["equippedID"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["equippedID"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("Bad Decal Manager Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, "Bad Decal Manager Data, data= " + KHJJFPPACBP.BKFCLMMJNHK("DecalManagerData", "S", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	[SpecialName]
	public string HGPBIFOJBEA()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "ShootBatchRPC";
		}
		if (NFFKMCPMPPI.slots.Count != 2)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = "squadMembers" + slot.Value.equippedID;
			}
			return string.Format("Xp", NFFKMCPMPPI.slots.Count, arg);
		}
		object[] array = new object[7];
		array[0] = NFFKMCPMPPI.slots[1].equippedID;
		array[0] = NFFKMCPMPPI.slots[1].equippedID;
		array[1] = NFFKMCPMPPI.slots[7].equippedID;
		array[4] = NFFKMCPMPPI.slots[4].equippedID;
		return string.Format("ID_ARENARULES_RUSHERSPROHIBITED", array);
	}

	public void MLHJMPDMFJF()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	public void HKANHGMBMIJ()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	public string HMFJMFMFPGA()
	{
		return DBNNKLCNDJD;
	}

	[SpecialName]
	public bool KIIPMFGHGLF()
	{
		if (OIALOJNPLFE == "Will connect to rooom: {0}" || FHFDIGAKFEA())
		{
			return false;
		}
		return !string.IsNullOrEmpty(OIALOJNPLFE);
	}

	[SpecialName]
	public int MCAFCPFAJOF()
	{
		return -97 * AMFJHAPGIJN;
	}

	[SpecialName]
	public WarArenaCrown LEBKAPAMFGI()
	{
		if (HGAOOMHOGJK == null)
		{
			return WarArenaCrown.BronzeCrown;
		}
		if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			return WarArenaCrown.BronzeCrown;
		}
		switch (HGAOOMHOGJK.visualType)
		{
		case "-":
			return WarArenaCrown.None;
		case "Made_IAP_Spend":
			return (WarArenaCrown)5;
		case "com.tune.TuneEvent":
			return WarArenaCrown.BronzeCrown;
		case "不":
			return (WarArenaCrown)6;
		default:
			return WarArenaCrown.None;
		}
	}

	[SpecialName]
	public int GFFGKMKNADO()
	{
		return (!MCLGEGLNMGO()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	public void HNAJKNPBJAM(string IFFONNNPKOF)
	{
		DBNNKLCNDJD = IFFONNNPKOF;
	}

	[SpecialName]
	public int GNHAIAGNIGN()
	{
		return (!MCLGEGLNMGO()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	internal static FHIPGDADNFG GHHJFAMMCND(JToken LFPFCHIJLML)
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		if (LFPFCHIJLML["globalSquadLeaderboard"] != null)
		{
			fHIPGDADNFG.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK("ID_SECONDS", "\\D*(?<num>[\\d\\s\\.,]+?)(?<dec>([\\.,]\\s*\\d?\\d?)?)\\D*$", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["Vip"] != null)
		{
			fHIPGDADNFG.NOCJHDCEHBE = KHJJFPPACBP.BKFCLMMJNHK("ID_WARNING_NOTENOUGHGOLDHEARTH", "ID_GETFORPROMOTION1", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["TranslationIdFinder.cs"] != null)
		{
			fHIPGDADNFG.KKAODKNEFMG = KHJJFPPACBP.OOAIMCEBPOK("test_attribute5", "DPS", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["ID_FEATURE_ACCURACY-WEAPONPREFIX"] != null)
		{
			fHIPGDADNFG.BCCDDJMPBLL = KHJJFPPACBP.PELILBMKGHE("Name", "ID_FEATURE_DAMAGE-FANCY", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["MachineGunLevelSetup needs PlayerBurstWeapon"] != null)
		{
			fHIPGDADNFG.EOFGMOMLAIH = KHJJFPPACBP.PELILBMKGHE("BeginnersLeague", "registerPowerHook", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["ID_CONFIRM_ERROR"] != null)
		{
			fHIPGDADNFG.AMFJHAPGIJN = KHJJFPPACBP.PELILBMKGHE("CAMOS_DEFAULT", "Crawl", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["grenade_idle"] != null)
		{
			fHIPGDADNFG.CJDHKJFKNAH = KHJJFPPACBP.PELILBMKGHE("veteranpack3", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", LFPFCHIJLML);
		}
		if (LFPFCHIJLML["1"] != null)
		{
			fHIPGDADNFG.IOFHDGKGFBG = KHJJFPPACBP.OOAIMCEBPOK("CONFIRM", "menu-arena-ticket", LFPFCHIJLML, 0L);
		}
		if (LFPFCHIJLML["game-card-ico-reload"] != null)
		{
			fHIPGDADNFG.DBNNKLCNDJD = KHJJFPPACBP.BKFCLMMJNHK("Wood", "game-kill-environmental", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["C: "] != null)
		{
			fHIPGDADNFG.GFCKPFIDADB = KHJJFPPACBP.PELILBMKGHE("1", "GrenadeMinDamage", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["N"] != null)
		{
			fHIPGDADNFG.ENMADELLEDG = KHJJFPPACBP.BKFCLMMJNHK(" action:", "Particle with name: ", LFPFCHIJLML, string.Empty);
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "armyPower", string.Empty));
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "FakeDoNotClick{0:2}", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["CardManagerData"] != null)
		{
			fHIPGDADNFG.HNEFOLPHMHK = KHJJFPPACBP.PELILBMKGHE("313 MENU ENABLE PUSH", "Sniper_Tutorial_Duration", LFPFCHIJLML, 1);
		}
		if (LFPFCHIJLML["ID_YOUAREPREMIUMMEMBERWITHBENEFITS"] == null && LFPFCHIJLML["game-card-ico-boobytrap"] == null)
		{
			fHIPGDADNFG.ENMADELLEDG = "gold";
			fHIPGDADNFG.MIDDIFMBFGC = (League)KHJJFPPACBP.PELILBMKGHE(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "gained offer from fuse: {0}", string.Empty), 1);
			fHIPGDADNFG.OIALOJNPLFE = KHJJFPPACBP.BKFCLMMJNHK(Regex.Replace(fHIPGDADNFG.ENMADELLEDG, "{0} {1}", string.Empty), string.Empty);
		}
		if (LFPFCHIJLML["\n"] != null)
		{
			fHIPGDADNFG.CAAKEPHMPHI = KHJJFPPACBP.BKFCLMMJNHK("ZA", "globalPlayerLeaderboard", LFPFCHIJLML, string.Empty);
		}
		if (LFPFCHIJLML["ID_CONFIRM_EXITINGMATCH"] != null)
		{
			try
			{
				fHIPGDADNFG.HGAOOMHOGJK = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK("ID_BLACKMARKETWEAPONPOWER", "Shots_Fired", LFPFCHIJLML, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("WarBucks");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC, "squad name" + KHJJFPPACBP.BKFCLMMJNHK("ID_YOUNEEDMONEYTODELIVERSPECIAL", "dogTagTimerLock", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		if (LFPFCHIJLML["()Lcom/google/android/gms/common/ConnectionResult;"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK("Player", "addPowerbandTime", LFPFCHIJLML, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["pooled:"];
				if (jToken2 != null)
				{
					foreach (JToken item in jToken2.Children())
					{
						if (item is JProperty jProperty && jProperty.First != null)
						{
							JToken first = jProperty.First;
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["cardPack"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["ID_SILVERLOOTBOXSMALL"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				fHIPGDADNFG.NFFKMCPMPPI = decalManagerData;
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("ID_SECONDWEAPONDAMAGE");
				Singleton<BeanstalkServerManager>.instance.KOIOPACIMDM(kIJELCLONNC2, "Awaiting players - Player id:\"{0}\" was not added to message center - cannot remove it from MC" + KHJJFPPACBP.BKFCLMMJNHK("Average_Player_Level", "Shotgunner spawned", LFPFCHIJLML, string.Empty), Environment.StackTrace);
			}
		}
		return fHIPGDADNFG;
	}

	[SpecialName]
	public string OLJPDPLLIAI()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "Physical ammo is null !!!";
		}
		if (NFFKMCPMPPI.slots.Count != 2)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = ", keys.Length = " + slot.Value.equippedID;
			}
			return string.Format("squad", NFFKMCPMPPI.slots.Count, arg);
		}
		object[] array = new object[2];
		array[0] = NFFKMCPMPPI.slots[0].equippedID;
		array[1] = NFFKMCPMPPI.slots[1].equippedID;
		array[0] = NFFKMCPMPPI.slots[0].equippedID;
		array[2] = NFFKMCPMPPI.slots[0].equippedID;
		return string.Format("Automatic_Equip", array);
	}

	[SpecialName]
	public int LANIPFOMABP()
	{
		return (!MCLGEGLNMGO()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	public void DBJMAKLFDEH(int OBMGFPIAMHH, int DLMDFMKABJH)
	{
		HGAOOMHOGJK.flawless = OBMGFPIAMHH;
		HGAOOMHOGJK.topRun = DLMDFMKABJH;
	}

	public string GetSquadId()
	{
		return DBNNKLCNDJD;
	}

	[SpecialName]
	public int KELKJNAKCJB()
	{
		return 60 * AMFJHAPGIJN;
	}

	[SpecialName]
	public bool MCLGEGLNMGO()
	{
		return HGAOOMHOGJK.flawless > 1;
	}

	public string CNOGOJPCFMM()
	{
		return DBNNKLCNDJD;
	}

	public string NBJGFIAOLBB()
	{
		return DBNNKLCNDJD;
	}

	[SpecialName]
	public int NFCCHBEGOIH()
	{
		return (!HHPFLCHHOCF()) ? HGAOOMHOGJK.topRun : HGAOOMHOGJK.flawless;
	}

	[SpecialName]
	public bool DCPCOPOIDLG()
	{
		return HGAOOMHOGJK.flawless > 1;
	}

	[SpecialName]
	public int ABPAHLFCEMH()
	{
		return 14 * AMFJHAPGIJN;
	}

	[SpecialName]
	public string CNCCFOPJKOH()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "Regions";
		}
		if (NFFKMCPMPPI.slots.Count != 4)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = "await" + slot.Value.equippedID;
			}
			return string.Format("ShowArenaDialog", NFFKMCPMPPI.slots.Count, arg);
		}
		object[] array = new object[6];
		array[1] = NFFKMCPMPPI.slots[1].equippedID;
		array[1] = NFFKMCPMPPI.slots[0].equippedID;
		array[5] = NFFKMCPMPPI.slots[0].equippedID;
		array[7] = NFFKMCPMPPI.slots[1].equippedID;
		return string.Format("Card_1_Played", array);
	}

	[SpecialName]
	public string EJDLJFFGHLJ()
	{
		return NOCJHDCEHBE;
	}

	public string NKFALACLMBG()
	{
		return INFLHPGMEOB;
	}

	[SpecialName]
	public bool JOIPOGLNNFF()
	{
		return HNEFOLPHMHK > 0 && string.IsNullOrEmpty(ENMADELLEDG);
	}

	[SpecialName]
	public bool GNKHGGPGFBC()
	{
		return HNEFOLPHMHK > 1 && string.IsNullOrEmpty(ENMADELLEDG);
	}

	[SpecialName]
	public static FHIPGDADNFG KPNIIMJDHCM()
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		fHIPGDADNFG.AMFJHAPGIJN = LevelManager.instance.armyPower;
		fHIPGDADNFG.KKAODKNEFMG = LevelManager.instance.experience;
		fHIPGDADNFG.IOFHDGKGFBG = GameLoginManager.currentPlayer.facebookId;
		fHIPGDADNFG.INFLHPGMEOB = GameLoginManager.currentPlayer.id;
		fHIPGDADNFG.BCCDDJMPBLL = LevelManager.instance.currentLevel.index;
		fHIPGDADNFG.EOFGMOMLAIH = LevelManager.instance.levelExperience;
		fHIPGDADNFG.NOCJHDCEHBE = GameLoginManager.currentPlayer.accountName;
		fHIPGDADNFG.CJDHKJFKNAH = GameLoginManager.currentPlayer.skill;
		fHIPGDADNFG.DBNNKLCNDJD = GameLoginManager.currentPlayer.squadName;
		fHIPGDADNFG.GFCKPFIDADB = PlayerAnalytics.instance.globalPositon;
		fHIPGDADNFG.NFFKMCPMPPI = CamosManager.instance.data;
		fHIPGDADNFG.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		fHIPGDADNFG.MIDDIFMBFGC = GameLoginManager.currentPlayer.leagueTier;
		fHIPGDADNFG.OIALOJNPLFE = GameLoginManager.currentPlayer.leagueDivision;
		fHIPGDADNFG.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		fHIPGDADNFG.HGAOOMHOGJK = WarArena.instance.data;
		return fHIPGDADNFG;
	}

	[SpecialName]
	public string MBDNIBFNPBE()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "Shields";
		}
		if (NFFKMCPMPPI.slots.Count != 4)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = "Medals/" + slot.Value.equippedID;
			}
			return string.Format("ID_CONFIRM_NOTENOUGHDOGTAGS", NFFKMCPMPPI.slots.Count, arg);
		}
		object[] array = new object[3];
		array[1] = NFFKMCPMPPI.slots[1].equippedID;
		array[1] = NFFKMCPMPPI.slots[0].equippedID;
		array[7] = NFFKMCPMPPI.slots[5].equippedID;
		array[1] = NFFKMCPMPPI.slots[6].equippedID;
		return string.Format("#AccoutCheck# FacebookLoginDuringTutorial - wrong situation -> do nothing", array);
	}

	[SpecialName]
	public bool FDPKDBPCCOF()
	{
		if (OIALOJNPLFE == "BattleRewards" || FHFDIGAKFEA())
		{
			return true;
		}
		return string.IsNullOrEmpty(OIALOJNPLFE);
	}

	[SpecialName]
	public string NGGIADLBNCM()
	{
		if (NFFKMCPMPPI.slots == null)
		{
			return "重試";
		}
		if (NFFKMCPMPPI.slots.Count != 3)
		{
			string arg = string.Empty;
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in NFFKMCPMPPI.slots)
			{
				arg = "T" + slot.Value.equippedID;
			}
			return $"Client has new config for: {NFFKMCPMPPI.slots.Count} with version {arg}";
		}
		object[] array = new object[3];
		array[0] = NFFKMCPMPPI.slots[0].equippedID;
		array[0] = NFFKMCPMPPI.slots[1].equippedID;
		array[1] = NFFKMCPMPPI.slots[5].equippedID;
		array[4] = NFFKMCPMPPI.slots[1].equippedID;
		return string.Format("UNLOCKLEVEL", array);
	}

	public string GCDGFEJOFGE()
	{
		return DBNNKLCNDJD;
	}

	[SpecialName]
	public WarArenaCrown JDKCFLOKEGO()
	{
		if (HGAOOMHOGJK == null)
		{
			return WarArenaCrown.None;
		}
		if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			return WarArenaCrown.BronzeCrown;
		}
		switch (HGAOOMHOGJK.visualType)
		{
		case "hashCode":
			return WarArenaCrown.BronzeCrown;
		case "menu-assignments-type-cards":
			return (WarArenaCrown)7;
		case "Tutorial_Step_Complete":
			return WarArenaCrown.Flawless;
		case "BANDS_WEAPON_DAMAGE":
			return (WarArenaCrown)7;
		default:
			return WarArenaCrown.BronzeCrown;
		}
	}

	public void OLPOHBAOOJB()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	[SpecialName]
	public bool OAJFIKIMOEP()
	{
		if (OIALOJNPLFE == "VideoFeed" || MCOJKHMAIPG())
		{
			return false;
		}
		return !string.IsNullOrEmpty(OIALOJNPLFE);
	}

	[SpecialName]
	public static FHIPGDADNFG HLHKHAMAFDI()
	{
		FHIPGDADNFG fHIPGDADNFG = new FHIPGDADNFG();
		fHIPGDADNFG.AMFJHAPGIJN = LevelManager.instance.armyPower;
		fHIPGDADNFG.KKAODKNEFMG = LevelManager.instance.experience;
		fHIPGDADNFG.IOFHDGKGFBG = GameLoginManager.currentPlayer.facebookId;
		fHIPGDADNFG.INFLHPGMEOB = GameLoginManager.currentPlayer.id;
		fHIPGDADNFG.BCCDDJMPBLL = LevelManager.instance.currentLevel.index;
		fHIPGDADNFG.EOFGMOMLAIH = LevelManager.instance.levelExperience;
		fHIPGDADNFG.NOCJHDCEHBE = GameLoginManager.currentPlayer.accountName;
		fHIPGDADNFG.CJDHKJFKNAH = GameLoginManager.currentPlayer.skill;
		fHIPGDADNFG.DBNNKLCNDJD = GameLoginManager.currentPlayer.squadName;
		fHIPGDADNFG.GFCKPFIDADB = PlayerAnalytics.instance.globalPositon;
		fHIPGDADNFG.NFFKMCPMPPI = CamosManager.instance.data;
		fHIPGDADNFG.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		fHIPGDADNFG.MIDDIFMBFGC = GameLoginManager.currentPlayer.leagueTier;
		fHIPGDADNFG.OIALOJNPLFE = GameLoginManager.currentPlayer.leagueDivision;
		fHIPGDADNFG.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		fHIPGDADNFG.HGAOOMHOGJK = WarArena.instance.data;
		return fHIPGDADNFG;
	}

	[SpecialName]
	public bool NFOLLMIBHMM()
	{
		if (OIALOJNPLFE == "isRandomMap" || GNKHGGPGFBC())
		{
			return false;
		}
		return string.IsNullOrEmpty(OIALOJNPLFE);
	}

	[SpecialName]
	public string KKIIICDNIDM()
	{
		return NOCJHDCEHBE;
	}

	public string DMCHNKDFDJF()
	{
		return DBNNKLCNDJD;
	}

	public void AOCJPLKFGFO()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	[SpecialName]
	public WarArenaCrown CIMFFIHNENA()
	{
		if (HGAOOMHOGJK == null)
		{
			return WarArenaCrown.BronzeCrown;
		}
		if (HGAOOMHOGJK.visualTimestamp < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			return WarArenaCrown.None;
		}
		switch (HGAOOMHOGJK.visualType)
		{
		case "Yes_Clicked":
			return WarArenaCrown.None;
		case "{0} {1}":
			return WarArenaCrown.None;
		case "I Got New Squad Messages":
			return (WarArenaCrown)8;
		case "Found Pack Id":
			return (WarArenaCrown)8;
		default:
			return WarArenaCrown.BronzeCrown;
		}
	}

	public string JDKEMGHJBCP()
	{
		return DBNNKLCNDJD;
	}

	public void DMDLHGHAEKM()
	{
		HGAOOMHOGJK = new WarArena.WarArenaData();
	}

	public string IMIJKDJJKHM()
	{
		return DBNNKLCNDJD;
	}
}
