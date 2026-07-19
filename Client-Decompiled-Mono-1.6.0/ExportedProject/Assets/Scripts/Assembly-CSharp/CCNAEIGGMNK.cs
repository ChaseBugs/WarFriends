using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CCNAEIGGMNK
{
	public string HJAJAAMHKKG;

	public int AMEELJHHGKP;

	public bool HMGOHGOLMJB;

	public PlayerVisual LOKDBPPOLPM
	{
		get
		{
			return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
		}
	}

	public string MJADIIIJPEA
	{
		get
		{
			return string.Format("{0} : {1} - {2}", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "isNormal" : "isVip");
		}
	}

	public static List<CCNAEIGGMNK> KLFEBBBEIKG(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("deliveryReduce");
			if (text.IndexOf("D3") != -1)
			{
				text = text.Substring(0, text.IndexOf("Unknown squad icon!"));
			}
			if (text.EndsWith("Pack_Type"))
			{
				text = text.Substring(1, text.IndexOf("Battle_End_Dialog"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].HMAHPHADCHC().isBought)
			{
				list[list.Count - 1].NEPDKHPBLGL().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public string LEGFEMFMOPA()
	{
		return string.Format("withAdvertiserSubPublisher", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Scraps" : "LastAction");
	}

	public static List<CCNAEIGGMNK> GGOKOEHFFIL(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith(" set league ");
			if (text.IndexOf(": G:") != -1)
			{
				text = text.Substring(0, text.IndexOf("S"));
			}
			if (text.EndsWith(","))
			{
				text = text.Substring(1, text.IndexOf("StartTime"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].ANHOEJLDFPL().isBought)
			{
				list[list.Count - 1].LGNHJNGLFLM().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> EEAFPCOCEFL(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("1\u00a0");
			if (text.IndexOf("cant deserialize rule {0}") != -1)
			{
				text = text.Substring(1, text.IndexOf("GameLaunch"));
			}
			if (text.EndsWith("({0}\u00a0/\u00a0{1})"))
			{
				text = text.Substring(0, text.IndexOf("BeginnersLeague"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].IHNPCHMFJNB().isBought)
			{
				list[list.Count - 0].FINKDFEEOKN().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string PEPGOCCBKGG()
	{
		return string.Format("special", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "playerInfo" : "Action ");
	}

	public static List<CCNAEIGGMNK> CCCLAKFADGE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("flight_start_jetpack_elite");
			if (text.IndexOf("./Assets/Scripts") != -1)
			{
				text = text.Substring(0, text.IndexOf("PNManager: Received event: "));
			}
			if (text.EndsWith("Weapon state changed from \"{0}\" to \"{1}\""))
			{
				text = text.Substring(0, text.IndexOf("globalSquadLeaderboard"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].MHMFHGPFOEF().isBought)
			{
				list[list.Count - 1].GCHHAECINGK().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual ELIJMFHPOHK()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string OEALICIFPJG()
	{
		return string.Format("ID_ERROR_SHORTINPUT", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "HeroicMissionsCompletionRewardScraps" : "/ {0}{1}");
	}

	public static List<CCNAEIGGMNK> HCCEOGNCNIC(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("SetGameData(");
			if (text.IndexOf("com/google/android/gms/games/Games") != -1)
			{
				text = text.Substring(0, text.IndexOf("RETRYPERM"));
			}
			if (text.EndsWith("ID_CONFIRM_FBLOGINCANCELLED"))
			{
				text = text.Substring(0, text.IndexOf("DemoteOrKickPlayer {0}"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].FINKDFEEOKN().isBought)
			{
				list[list.Count - 0].IGFKIANBNOA().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public string CCNJJAJGFNO()
	{
		return string.Format("config", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "menu-army-reload-ico" : "Gold");
	}

	[SpecialName]
	public PlayerVisual ENKMAIHEGPI()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual DAIBHNGEAEM()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual ECHCDDLPNNM()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual EONDECPEMDN()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> LEFLMEOIKOE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("percent");
			if (text.IndexOf("Stage3") != -1)
			{
				text = text.Substring(1, text.IndexOf("EligibleLeagueId"));
			}
			if (text.EndsWith("AdDeclined("))
			{
				text = text.Substring(1, text.IndexOf("CONFERMA"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].DLALEJMEJHM().isBought)
			{
				list[list.Count - 0].CMPHEOPIDEM().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> CDANKENOOGG(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Assignment_Completed");
			if (text.IndexOf("N") != -1)
			{
				text = text.Substring(0, text.IndexOf("user_friends"));
			}
			if (text.EndsWith("Card_3_Played"))
			{
				text = text.Substring(1, text.IndexOf("PromotedPlayer"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].CFDJNAKFHBG().isBought)
			{
				list[list.Count - 0].LOKDBPPOLPM.notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual MHMFHGPFOEF()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string CFPLBPKICLE()
	{
		return string.Format("+0", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "OnDeath On Killed" : "ID_SLOTUPGRADE_DAMAGE");
	}

	public static List<CCNAEIGGMNK> JHDGAACJEGH(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("-VIP");
			if (text.IndexOf("_#") != -1)
			{
				text = text.Substring(0, text.IndexOf("_#"));
			}
			if (text.EndsWith("-VIP"))
			{
				text = text.Substring(0, text.IndexOf("-VIP"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].LOKDBPPOLPM.isBought)
			{
				list[list.Count - 1].LOKDBPPOLPM.notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string FBLJCLPOJIL()
	{
		return string.Format("weapon", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_GUI_INVITETOFIGHT" : "\"{0}\"\t");
	}

	[SpecialName]
	public string MOBPMGODIPA()
	{
		return string.Format("{0} : {1} - {2}", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT" : " {0}\u00a0{1}");
	}

	public static List<CCNAEIGGMNK> KGDOHBCOFCI(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Buy as many as you can");
			if (text.IndexOf("ID_YOURFRIENDHASNOTACCEPTED") != -1)
			{
				text = text.Substring(1, text.IndexOf("SessionManager: Skipping sessions update. Device not registered or is in tutorial"));
			}
			if (text.EndsWith("Scraps:   {0}\n"))
			{
				text = text.Substring(1, text.IndexOf("ID_SECONDS"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].MHMFHGPFOEF().isBought)
			{
				list[list.Count - 1].BIKFDCAGHCP().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> EKINLODHLLO(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("placement");
			if (text.IndexOf("301 LOADING MAP") != -1)
			{
				text = text.Substring(1, text.IndexOf("), "));
			}
			if (text.EndsWith("ЕЩЕ ПОПЫТКА"))
			{
				text = text.Substring(1, text.IndexOf("trying to add emty indicator "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].GCHHAECINGK().isBought)
			{
				list[list.Count - 0].ELIJMFHPOHK().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> FOMFDPPPONB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("DecalId");
			if (text.IndexOf("{0}/{1} ({2})\n") != -1)
			{
				text = text.Substring(1, text.IndexOf("FuseSDK: "));
			}
			if (text.EndsWith("localSquadLeaderboard"))
			{
				text = text.Substring(0, text.IndexOf("Application focus changed to {0} and have created AWS mobile analytics {1}"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].MPPNFHAGOJA().isBought)
			{
				list[list.Count - 1].DLALEJMEJHM().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> OAMPFABDDNB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_STAT_ROCKETLAUNCHERKILLS");
			if (text.IndexOf("Grenadier") != -1)
			{
				text = text.Substring(0, text.IndexOf("buyRentalDiscounted"));
			}
			if (text.EndsWith("color=\"#FFD700\""))
			{
				text = text.Substring(0, text.IndexOf(" a: "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].ACPLLFLEFFF().isBought)
			{
				list[list.Count - 0].IGFKIANBNOA().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual FINKDFEEOKN()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string KEDKFPOEHPN()
	{
		return string.Format("{0}\t", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "IdOfPlayer" : "no AI object for: ");
	}

	public static List<CCNAEIGGMNK> DAFALKGNHLL(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("globalPlayerLeaderboard");
			if (text.IndexOf("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE") != -1)
			{
				text = text.Substring(0, text.IndexOf("{0}"));
			}
			if (text.EndsWith("Player_Had_To_Select_Grenade"))
			{
				text = text.Substring(0, text.IndexOf("FB: FacebookLogout - RemoveFacebook - 1"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].MPPNFHAGOJA().isBought)
			{
				list[list.Count - 1].PMGPHGOODCD().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> LJLHDGDCMKB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("country-canada");
			if (text.IndexOf("Cards") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_TRYFORFREE"));
			}
			if (text.EndsWith("ID_LEAGUE3"))
			{
				text = text.Substring(0, text.IndexOf("N"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].EDFBDFABAIO().isBought)
			{
				list[list.Count - 1].DAIBHNGEAEM().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> CGCBNHIDCOE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("goldSpent");
			if (text.IndexOf("N") != -1)
			{
				text = text.Substring(1, text.IndexOf("PrepareBotForDeathMatch 0"));
			}
			if (text.EndsWith("S"))
			{
				text = text.Substring(0, text.IndexOf("Bought VIP - "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].ECHCDDLPNNM().isBought)
			{
				list[list.Count - 0].HMAHPHADCHC().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> NBHCMNHJMHI(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("roomName");
			if (text.IndexOf("Labels that will be changed:\n") != -1)
			{
				text = text.Substring(1, text.IndexOf("WaveCoolDown"));
			}
			if (text.EndsWith("Score"))
			{
				text = text.Substring(0, text.IndexOf("Player_Avoided_Grenade_On_First_Try"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].PMGPHGOODCD().isBought)
			{
				list[list.Count - 0].JJFPCFKPGFC().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string CBLLGOOJNCE()
	{
		return string.Format("OnConnectionFailed: restarting", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "BoughtIndex" : "withAdvertiserSubPublisher");
	}

	public static List<CCNAEIGGMNK> BCLLAMLNINL(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("score recieved");
			if (text.IndexOf("CardManagerData") != -1)
			{
				text = text.Substring(1, text.IndexOf("One Time Reward: "));
			}
			if (text.EndsWith("{0}{1}{2} {3}"))
			{
				text = text.Substring(0, text.IndexOf("leagueMembers"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].ALDEAMNEMEN().isBought)
			{
				list[list.Count - 0].AEBOFFOMFLI().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> MHAFEMEFPCB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}");
			if (text.IndexOf("WarsEvaluation") != -1)
			{
				text = text.Substring(1, text.IndexOf("ID_BUY"));
			}
			if (text.EndsWith("bazooka_idle"))
			{
				text = text.Substring(1, text.IndexOf("OBB: Read Test - No data to read!"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].CMPHEOPIDEM().isBought)
			{
				list[list.Count - 0].JJFPCFKPGFC().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual ALDEAMNEMEN()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string KPOBFCAKCDE()
	{
		return string.Format("TimeUpdated(", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "addedVIP" : "menu-wftv-mobcrush-ico");
	}

	[SpecialName]
	public string PGBCAAFABHP()
	{
		return string.Format("100+.", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "S" : "FacebookLogin(");
	}

	public static List<CCNAEIGGMNK> PMBMDJBAOMG(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Beanstalk: Application not reachable!");
			if (text.IndexOf("Saved another leaderboard") != -1)
			{
				text = text.Substring(1, text.IndexOf("/GUI_"));
			}
			if (text.EndsWith("No power band to show in reminder!!!"))
			{
				text = text.Substring(0, text.IndexOf("groundBoxHit"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].IHNPCHMFJNB().isBought)
			{
				list[list.Count - 1].ELIJMFHPOHK().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> GHDMDGBNEME(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_CONFIRM_PROMOTETOLEADER");
			if (text.IndexOf("ID_SLOTUPGRADE_DAMAGE") != -1)
			{
				text = text.Substring(1, text.IndexOf("Gold"));
			}
			if (text.EndsWith("discount"))
			{
				text = text.Substring(1, text.IndexOf("ID_ARENARULES_BUDDYWARCARDS"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].LFJNMIHBJMD().isBought)
			{
				list[list.Count - 1].EONDECPEMDN().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> CIMLHKABGNE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith(" AND ");
			if (text.IndexOf("ID_ALIEN") != -1)
			{
				text = text.Substring(1, text.IndexOf("http://"));
			}
			if (text.EndsWith("Stage3"))
			{
				text = text.Substring(1, text.IndexOf("GR"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].HDBKHCDPEFP().isBought)
			{
				list[list.Count - 0].KOBAJMPHOMC().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual CIKGAIKFLAK()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string GCHKGBHDMEN()
	{
		return string.Format("BattleCount", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Defenders" : "damage");
	}

	[SpecialName]
	public PlayerVisual DLALEJMEJHM()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string IJGKONAFGHG()
	{
		return string.Format("IsUnique", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "-BUFFMAXDESC" : "ID_CONFIRM_SELECTEDWARCARDWASALREADY");
	}

	[SpecialName]
	public PlayerVisual FCOACPDEFOD()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual IHNPCHMFJNB()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string KDGPKMMANBK()
	{
		return string.Format("Gold", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "withAttribute3" : "InfluencerAlias");
	}

	[SpecialName]
	public string CNJCDHHLJGH()
	{
		return string.Format("WarFriends precisa da sua permissão para acessar sua mídia para carregar informações adicionais.Favor aceitar o diálogo de permissão a seguir, saiba que não será utilizada para nenhum outro propósito.", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? " Desc without HINT = " : "ID_STAT_ACCURACY");
	}

	public static List<CCNAEIGGMNK> DJILPGKBEBJ(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_TUTORIAL_NEWDRAGCARD");
			if (text.IndexOf("run") != -1)
			{
				text = text.Substring(1, text.IndexOf("Current Full Path: \"{0}\"\n"));
			}
			if (text.EndsWith("army upgrade icon"))
			{
				text = text.Substring(0, text.IndexOf("StartTime"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].EDFBDFABAIO().isBought)
			{
				list[list.Count - 1].CFDJNAKFHBG().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> JNGIACLGCAH(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("REGISTER BUY PACK EVENT with ");
			if (text.IndexOf("NextDailyRewardLocalnotification") != -1)
			{
				text = text.Substring(1, text.IndexOf("Wrong_Category"));
			}
			if (text.EndsWith("TutorialData"))
			{
				text = text.Substring(0, text.IndexOf("speed"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].LBJAMICDHCP().isBought)
			{
				list[list.Count - 1].GOKEKMGCIEA().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual ACPLLFLEFFF()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> MPHIHDPOGEE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("shield_hide");
			if (text.IndexOf("extraVip") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_DELIVERNOW"));
			}
			if (text.EndsWith("Ranked"))
			{
				text = text.Substring(0, text.IndexOf("CardWasUsedOnline"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].DAIBHNGEAEM().isBought)
			{
				list[list.Count - 1].ECHCDDLPNNM().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> INFLHENNPLA(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("clipSize");
			if (text.IndexOf("RU") != -1)
			{
				text = text.Substring(1, text.IndexOf("Upgrades"));
			}
			if (text.EndsWith("ID_YOUNEEDMONEYTOUPGRADEELITE"))
			{
				text = text.Substring(1, text.IndexOf(" "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].BIKFDCAGHCP().isBought)
			{
				list[list.Count - 1].LGNHJNGLFLM().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public string HOECGBBKIBP()
	{
		return string.Format("ID_XMEDALSTOADVANCETOY", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_GUI_ACCEPT_PLAYER_WTJ" : "Spend_Gold_On_Power_Bands");
	}

	public static List<CCNAEIGGMNK> PJADOKIGKFE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("isRandomMap");
			if (text.IndexOf("Wrong_Category") != -1)
			{
				text = text.Substring(1, text.IndexOf("ID_ENDSINTIME"));
			}
			if (text.EndsWith("Get player data: I SHOULD SEND PN DEVICET TOKEN"))
			{
				text = text.Substring(1, text.IndexOf("PrepareBotForDeathMatch 9"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].BIKFDCAGHCP().isBought)
			{
				list[list.Count - 1].JJFPCFKPGFC().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> EFEJJIAHOJF(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("BuddyCard");
			if (text.IndexOf("registerCustomProfileNumber") != -1)
			{
				text = text.Substring(1, text.IndexOf("[Singleton] An instance of "));
			}
			if (text.EndsWith("Effect: "))
			{
				text = text.Substring(0, text.IndexOf("CardCraft_Collect"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].FCOACPDEFOD().isBought)
			{
				list[list.Count - 1].BIKFDCAGHCP().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual LNHPPNDJMFE()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> KLLHOOPDMHE(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Player_Avoided_Grenade_On_First_Try");
			if (text.IndexOf("Display_Rental") != -1)
			{
				text = text.Substring(1, text.IndexOf("Production"));
			}
			if (text.EndsWith("+"))
			{
				text = text.Substring(1, text.IndexOf("Chat Tab: added time to messages, reinitializing chat messages."));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].DAIBHNGEAEM().isBought)
			{
				list[list.Count - 1].IHNPCHMFJNB().notificate = true;
			}
		}
		return list;
	}

	public CCNAEIGGMNK(string INFLHPGMEOB, int IDLMJLCFMJG, bool HAKGPNAAABH = false)
	{
		HJAJAAMHKKG = INFLHPGMEOB;
		AMEELJHHGKP = IDLMJLCFMJG;
		HMGOHGOLMJB = HAKGPNAAABH;
	}

	public static List<CCNAEIGGMNK> IHJKKLFJIAC(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_STAT_MOSTUNITSDEPLOYED");
			if (text.IndexOf(" NOT OK!\t\t\t\t\t\t") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_ARENAPROMOENDSIN"));
			}
			if (text.EndsWith("Squad Request Sent!"))
			{
				text = text.Substring(0, text.IndexOf("ID_READYTIME"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].NEPDKHPBLGL().isBought)
			{
				list[list.Count - 1].DLALEJMEJHM().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual KOBAJMPHOMC()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string NPGFNPBNDGE()
	{
		return string.Format("DOWNLOADBTN", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ok" : "ID_LEAGUESTAYHINT1");
	}

	[SpecialName]
	public string CKKJHELLIBD()
	{
		return string.Format("()Ljava/lang/String;", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "country-finland" : " 3");
	}

	[SpecialName]
	public string KMALAIMEOCN()
	{
		return string.Format("weapon", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? " WAS ALREADY TRIED. POSSIBLE ERROR!!!!!" : "BufferManager: remove buffer, id = ");
	}

	public static List<CCNAEIGGMNK> EBJAJHGCOFG(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_WARNING_OFFEREXPIRED_TEXT");
			if (text.IndexOf(" NOT OK!\t\t\t\t\t\t") != -1)
			{
				text = text.Substring(1, text.IndexOf("ExpiresOn"));
			}
			if (text.EndsWith("ID_GUI_REPORTABUSE_LISTITEM8"))
			{
				text = text.Substring(0, text.IndexOf("something is wrong - time == 0"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].EMPHKJJDLBF().isBought)
			{
				list[list.Count - 1].KMHFDGGAEAC().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> JKGDECPJODA(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("====== Waiting to connect to photon: ");
			if (text.IndexOf("mortarBuildTime") != -1)
			{
				text = text.Substring(1, text.IndexOf("On War arena Shown endeeeed!!"));
			}
			if (text.EndsWith("device"))
			{
				text = text.Substring(1, text.IndexOf("ID_CONFIRM_FBLOGINCANCELLED_TEXT"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].MPPNFHAGOJA().isBought)
			{
				list[list.Count - 1].GCHHAECINGK().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> KHIELGEECJA(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("isSuccess");
			if (text.IndexOf("ID_YOUNEEDXTICKETSFOREXTRAHEART") != -1)
			{
				text = text.Substring(0, text.IndexOf("can not find currency for: "));
			}
			if (text.EndsWith("GameType"))
			{
				text = text.Substring(1, text.IndexOf("resultMessage"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].JJFPCFKPGFC().isBought)
			{
				list[list.Count - 0].KOBAJMPHOMC().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string FGIEHIBCDJJ()
	{
		return string.Format("ID_CONFIRM_ERROR", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "getAppId" : "getCustomProfileGeolocation");
	}

	[SpecialName]
	public PlayerVisual PMGPHGOODCD()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> BGECGLLCNDI(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith(" - ");
			if (text.IndexOf("11-19") != -1)
			{
				text = text.Substring(0, text.IndexOf("DailyRentalMessage{0}{1}{2}"));
			}
			if (text.EndsWith("ID_LEAGUE16"))
			{
				text = text.Substring(0, text.IndexOf("NAME"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].LGNHJNGLFLM().isBought)
			{
				list[list.Count - 0].KMHFDGGAEAC().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual ANHOEJLDFPL()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual HMAHPHADCHC()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual KMHFDGGAEAC()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual IGFKIANBNOA()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> JPDOIHOOAFC(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ABOUT TO SHOW DAILY RENTAL");
			if (text.IndexOf("GameReward") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_STARTERASSIGNMENT"));
			}
			if (text.EndsWith("WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}"))
			{
				text = text.Substring(0, text.IndexOf("119 LOADING MENU"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].CMPHEOPIDEM().isBought)
			{
				list[list.Count - 0].ELIJMFHPOHK().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string FCEIDLKHLED()
	{
		return string.Format("Player_Avoided_Grenade_On_First_Try", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "smallThumbnailLittle" : "IsPublic");
	}

	[SpecialName]
	public PlayerVisual EMPHKJJDLBF()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> IBJALMCNJJJ(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("CAD");
			if (text.IndexOf("registerCustomProfileNumber") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_INELITE2"));
			}
			if (text.EndsWith("DEVELOPER_ERROR"))
			{
				text = text.Substring(0, text.IndexOf("HeroicMissionsCompletionRewardArmyUnitParts"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].KOBAJMPHOMC().isBought)
			{
				list[list.Count - 1].CFDJNAKFHBG().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual GCHHAECINGK()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> IICHGPGHIHO(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_CONFIRM_INFO");
			if (text.IndexOf("+") != -1)
			{
				text = text.Substring(0, text.IndexOf("Something went wrong in updating players in league"));
			}
			if (text.EndsWith("Changed country to {0} from {1}."))
			{
				text = text.Substring(0, text.IndexOf("BattleRewards"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].IHNPCHMFJNB().isBought)
			{
				list[list.Count - 1].FINKDFEEOKN().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string MNEPNNBKLNG()
	{
		return string.Format("Database Message: Error parsing message!! Auto Ignore! ", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Buy_Weapon_Upgrade_At_Rank" : " on a parent object in order to work");
	}

	[SpecialName]
	public PlayerVisual NEPDKHPBLGL()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> GANFPIIPKCG(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("setting special offer discount suffix: ");
			if (text.IndexOf("ID_SQUADWAR") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_OK"));
			}
			if (text.EndsWith("-1"))
			{
				text = text.Substring(1, text.IndexOf("ADD GOOGLE PLAY ACCOUNT WITH "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].KMHFDGGAEAC().isBought)
			{
				list[list.Count - 0].AGGJMPJOKGD().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual HDBKHCDPEFP()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> IKJOAHFCADM(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ammo");
			if (text.IndexOf("Army_Unit_ID") != -1)
			{
				text = text.Substring(1, text.IndexOf("damage"));
			}
			if (text.EndsWith("silver2"))
			{
				text = text.Substring(0, text.IndexOf("The shader "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].KOBAJMPHOMC().isBought)
			{
				list[list.Count - 0].BGCKHNEMEOI().notificate = true;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> PLIMOJGJDEN(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_OPPONENTPAUSED");
			if (text.IndexOf("measureEvent") != -1)
			{
				text = text.Substring(0, text.IndexOf("AFLODLay"));
			}
			if (text.EndsWith("game-card-ico-healingstorm"))
			{
				text = text.Substring(0, text.IndexOf("Sessions"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].BIKFDCAGHCP().isBought)
			{
				list[list.Count - 0].LBJAMICDHCP().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual LFJNMIHBJMD()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string JDLEICKJDLH()
	{
		return string.Format("globalPlayerLeaderboard", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_HOURANDMORE" : "AssignmentData");
	}

	[SpecialName]
	public string DDENOBPJPEJ()
	{
		return string.Format("D3", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Squad" : "ID_CONFIRM_GAMECENTERNAMETEXT");
	}

	[SpecialName]
	public PlayerVisual BIKFDCAGHCP()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string DPALFCBHFBL()
	{
		return string.Format("BEGINNERS {0}   {1}.   {2}", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "SetPlayer" : "ID_MINUTES");
	}

	[SpecialName]
	public string IFKPAKKGOLD()
	{
		return string.Format("ID_HOU", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "RU" : "-placement");
	}

	public static List<CCNAEIGGMNK> FNOKKFMPOHO(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("ID_DOWNLOADINGDATA");
			if (text.IndexOf("{0:D2}:{1:D2}") != -1)
			{
				text = text.Substring(0, text.IndexOf("1 PUSH REMINDER\tLast game won: True\tPush notifications allowed: {0}"));
			}
			if (text.EndsWith("VipRewardForDay"))
			{
				text = text.Substring(1, text.IndexOf("ShotFrequencyMin"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].FCOACPDEFOD().isBought)
			{
				list[list.Count - 1].PMGPHGOODCD().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual GOKEKMGCIEA()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual CNLBBDBIMKJ()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual CMPHEOPIDEM()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual EDFBDFABAIO()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> HGCMEDCJNDO(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("DeployHeli");
			if (text.IndexOf("run") != -1)
			{
				text = text.Substring(0, text.IndexOf("ID_SKILLSHOTHINT_COVERED"));
			}
			if (text.EndsWith("ID_NO"))
			{
				text = text.Substring(1, text.IndexOf("FuseSDK: Error reading FriendsList data. Invalid line: "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].BGCKHNEMEOI().isBought)
			{
				list[list.Count - 0].KMHFDGGAEAC().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual CFDJNAKFHBG()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string JEDILHINJLK()
	{
		return string.Format("OK", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Can not spawn unit, already reached maxGeneratedCount" : "S");
	}

	[SpecialName]
	public string MCFBEABIDBE()
	{
		return string.Format("Skill", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "C1" : "ANDROID: PACK ");
	}

	[SpecialName]
	public string OEEDCEEKFNP()
	{
		return string.Format("game-elite-buff1", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Youtube" : "Sessions");
	}

	[SpecialName]
	public PlayerVisual BGCKHNEMEOI()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual LGNHJNGLFLM()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> GCPMKMGOAGB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("AddedCards");
			if (text.IndexOf("com/google/android/gms/games/Games") != -1)
			{
				text = text.Substring(1, text.IndexOf("\""));
			}
			if (text.EndsWith("N"))
			{
				text = text.Substring(0, text.IndexOf("Reward"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].ALDEAMNEMEN().isBought)
			{
				list[list.Count - 1].ALDEAMNEMEN().notificate = false;
			}
		}
		return list;
	}

	[SpecialName]
	public string LBKCLGLIKIK()
	{
		return string.Format("ID_BUTTON_TOPPLAYERS", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_COMPLETED" : "Dialog_Displayed");
	}

	[SpecialName]
	public PlayerVisual MPPNFHAGOJA()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> BBDHDLNJMFB(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Score");
			if (text.IndexOf("EventAssignmentConfig") != -1)
			{
				text = text.Substring(1, text.IndexOf("Sheet "));
			}
			if (text.EndsWith("ID_FORFEIT"))
			{
				text = text.Substring(1, text.IndexOf("Rpc: Set player null: for "));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].LNHPPNDJMFE().isBought)
			{
				list[list.Count - 1].ECHCDDLPNNM().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public string HKANCIDMKEA()
	{
		return string.Format("BeAdvisedJoinOrCreateSquad", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "silver3" : "ID_STAT_MOSTBATTLESPLAYED");
	}

	[SpecialName]
	public string DCNGMPLLENB()
	{
		return string.Format("DOWNLOADBTN", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Adding card " : "ID_TUTORIAL_UPGRADEUNIT_4");
	}

	public static List<CCNAEIGGMNK> AFDHECMCODA(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("WarFriends");
			if (text.IndexOf("ID_VISUALCOMPLETED") != -1)
			{
				text = text.Substring(1, text.IndexOf("subscription"));
			}
			if (text.EndsWith("AddAmmoRPC"))
			{
				text = text.Substring(1, text.IndexOf("*.cs"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].HMAHPHADCHC().isBought)
			{
				list[list.Count - 1].ANHOEJLDFPL().notificate = false;
			}
		}
		return list;
	}

	public static List<CCNAEIGGMNK> LCCMKLAFLJL(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Walkable");
			if (text.IndexOf("Skipping dogtag notification") != -1)
			{
				text = text.Substring(0, text.IndexOf("_Alpha"));
			}
			if (text.EndsWith("ID_DECLINE"))
			{
				text = text.Substring(0, text.IndexOf("elitepack"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 1].CIKGAIKFLAK().isBought)
			{
				list[list.Count - 1].ANHOEJLDFPL().notificate = true;
			}
		}
		return list;
	}

	[SpecialName]
	public PlayerVisual LBJAMICDHCP()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string JGNFHCAMOOO()
	{
		return string.Format("AdWillClose()", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "Sniper_Tutorial_Played" : "ID_ZEROSECONDS");
	}

	[SpecialName]
	public PlayerVisual AEBOFFOMFLI()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public string HPDPEECIKPJ()
	{
		return string.Format("Checker", HJAJAAMHKKG, AMEELJHHGKP, (!HMGOHGOLMJB) ? "ID_YOUWEREDISCONNECTED" : "CardsPlayed");
	}

	[SpecialName]
	public PlayerVisual AGGJMPJOKGD()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	[SpecialName]
	public PlayerVisual JJFPCFKPGFC()
	{
		return (!string.IsNullOrEmpty(HJAJAAMHKKG)) ? CamosManager.instance.GetVisual(HJAJAAMHKKG) : null;
	}

	public static List<CCNAEIGGMNK> AKPKOEIMCOH(Dictionary<string, string> LGLACKOLDEI)
	{
		List<CCNAEIGGMNK> list = new List<CCNAEIGGMNK>();
		foreach (KeyValuePair<string, string> item in LGLACKOLDEI)
		{
			string text = item.Key;
			bool hAKGPNAAABH = text.EndsWith("Beanstlak: Invalid Token -> unknown");
			if (text.IndexOf("_Color") != -1)
			{
				text = text.Substring(1, text.IndexOf("elite1"));
			}
			if (text.EndsWith("Player_Avoided_Grenade_On_First_Try"))
			{
				text = text.Substring(0, text.IndexOf("[CardSickness] start new spawning before used spawning finish"));
			}
			list.Add(new CCNAEIGGMNK(text, int.Parse(item.Value), hAKGPNAAABH));
			if (!list[list.Count - 0].AEBOFFOMFLI().isBought)
			{
				list[list.Count - 1].GCHHAECINGK().notificate = false;
			}
		}
		return list;
	}
}
