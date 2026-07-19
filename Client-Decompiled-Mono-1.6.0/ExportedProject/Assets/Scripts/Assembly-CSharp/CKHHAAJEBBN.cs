using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class CKHHAAJEBBN : KJMGFHMIBII
{
	private static List<CloudRegionCode> LKELMHBFOAH;

	public override bool MBOHGLCBEFJ
	{
		get
		{
			return true;
		}
	}

	public override RoomOptions NCDDLBIJIIH
	{
		get
		{
			RoomOptions roomOptions = base.NCDDLBIJIIH;
			roomOptions.IsVisible = true;
			roomOptions.CustomRoomPropertiesForLobby = new string[3] { "C0", "C1", "C2" };
			return roomOptions;
		}
	}

	protected override Hashtable GCFEIDJMLGE
	{
		get
		{
			WarArena.WarArenaData data = WarArena.instance.data;
			int num = data.wins;
			GameControllerWarArena mBPKLMKBJAB = Singleton<GameController>.instance.MBPKLMKBJAB;
			Hashtable hashtable = new Hashtable();
			hashtable.Add("C0", num);
			hashtable.Add("C1", GameLoginManager.currentPlayer.id);
			hashtable.Add("C2", mBPKLMKBJAB.GetTopRunGroup());
			hashtable.Add("MatchStart", double.PositiveInfinity);
			hashtable.Add("battleID", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			return hashtable;
		}
	}

	public override int MANOCBMEGOK
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
		}
	}

	public override string NJKMFAGIKIE
	{
		get
		{
			return "warArenaLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
		}
	}

	public override bool IGBMAJGJDEL
	{
		get
		{
			float averageMatchFPS = UserDeviceManager.instance.GetAverageMatchFPS();
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return averageMatchFPS > (float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumMasterFPS).FLOATVALUE;
		}
	}

	public override float MGOBKMIGPEK
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
		}
	}

	public override int NBIJIDLEJBC
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsAndroid).FLOATVALUE;
		}
	}

	public static bool DAMNJODDMNA
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
			CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(LIABKJNONBH());
			return (float)PhotonConnectionManager.IFOKPNHLEBP[bestAllowedRegion] <= (float)fLOATVALUE;
		}
	}

	public override List<CloudRegionCode> FCOKCCNOHBA
	{
		get
		{
			return LIABKJNONBH();
		}
	}

	[SpecialName]
	public virtual int EEANPHIABIN()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
	}

	[SpecialName]
	public virtual bool IHFLJLHPINO()
	{
		float averageMatchFPS = UserDeviceManager.instance.GetAverageMatchFPS();
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return averageMatchFPS > (float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
	}

	private string IODPIDLFIBH(int DKHDNINDEKD, int IDLMJLCFMJG, string DDBKNOGNAHF)
	{
		DKHDNINDEKD--;
		int num = Mathf.Clamp(IDLMJLCFMJG - DKHDNINDEKD, 0, int.MaxValue);
		int num2 = IDLMJLCFMJG + DKHDNINDEKD;
		return DDBKNOGNAHF + " >=" + num + " AND " + DDBKNOGNAHF + " <=" + num2;
	}

	[SpecialName]
	public virtual int JFAGLKPCDPG()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
	}

	private static List<CloudRegionCode> GPCJNHOELPD()
	{
		if (LKELMHBFOAH == null)
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			string sTRINGVALUE = warArenaParameters.GetRow((WarArenaParameters.rowIds)(-52)).STRINGVALUE;
			LKELMHBFOAH = JsonConvert.DeserializeObject<List<CloudRegionCode>>(sTRINGVALUE);
		}
		return LKELMHBFOAH;
	}

	[SpecialName]
	public static bool JGBABFFKIAH()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
		CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(PFCOHECEGGJ());
		return (float)PhotonConnectionManager.IFOKPNHLEBP[bestAllowedRegion] <= (float)fLOATVALUE;
	}

	[SpecialName]
	public virtual float HJAGMJKHAAE()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
	}

	[SpecialName]
	public static bool BBCKJGPJHGP()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
		CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(LIABKJNONBH());
		return !((float)PhotonConnectionManager.IFOKPNHLEBP[bestAllowedRegion] <= (float)fLOATVALUE);
	}

	[SpecialName]
	public virtual bool EGDJNHALGGC()
	{
		return true;
	}

	[SpecialName]
	public virtual bool HAGJPGNNJFF()
	{
		return false;
	}

	private static List<CloudRegionCode> LIABKJNONBH()
	{
		if (LKELMHBFOAH == null)
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			string sTRINGVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.EnabledRegions).STRINGVALUE;
			LKELMHBFOAH = JsonConvert.DeserializeObject<List<CloudRegionCode>>(sTRINGVALUE);
		}
		return LKELMHBFOAH;
	}

	[SpecialName]
	protected virtual Hashtable EMNDDBDPFEA()
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		int num = data.wins;
		GameControllerWarArena mBPKLMKBJAB = Singleton<GameController>.instance.MBPKLMKBJAB;
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Beanstalk check: Application not reachable!", num);
		hashtable.Add("Reward", GameLoginManager.currentPlayer.id);
		hashtable.Add("ID_CONFIRM_JOININGSQUAD", mBPKLMKBJAB.GetTopRunGroup());
		hashtable.Add("SquadCards", 865.0);
		hashtable.Add("Time_Range", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		return hashtable;
	}

	[SpecialName]
	public virtual string DHADMLHJKPN()
	{
		return "DemoteOrKickPlayer {0}" + Singleton<CurrentBundleVersion>.instance.OIFKMEKIAPM();
	}

	private string ELHIOLLIMAK(string DDBKNOGNAHF, string PAEKBHBGNGL)
	{
		return DDBKNOGNAHF + "ID_LEAGUE11" + PAEKBHBGNGL + "C2";
	}

	public virtual string BPALIHFKIJA(int DKHDNINDEKD)
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		List<string> list = new List<string>();
		list.Add(DPMGFDGHMDB(DKHDNINDEKD, data.wins, "damage"));
		List<string> list2 = list;
		if (Singleton<GameController>.instance.MBPKLMKBJAB.MKAKEBPBKOP() && !DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			list2.Add(MHDBCMDBIPB(DKHDNINDEKD, "temp_user_name"));
		}
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		int num = (int)(float)warArenaParameters.GetRow((WarArenaParameters.rowIds)118).FLOATVALUE;
		if (!DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			for (int i = 1; i < data.opponents.Count && i < num; i++)
			{
				string pAEKBHBGNGL = data.opponents[i];
				list2.Add(KCINHEBONAM("ShowNameRPC", pAEKBHBGNGL));
			}
		}
		return string.Join("ID_WARCARDSUNLOCKEDATRANK", list2.ToArray());
	}

	[SpecialName]
	public virtual int KOLOKNMPBBL()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return (int)(float)warArenaParameters.GetRow((WarArenaParameters.rowIds)105).FLOATVALUE;
	}

	public virtual string HCIILLNKINA(int DKHDNINDEKD)
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		List<string> list = new List<string>();
		list.Add(DPMGFDGHMDB(DKHDNINDEKD, data.wins, "ID_YES"));
		List<string> list2 = list;
		if (Singleton<GameController>.instance.MBPKLMKBJAB.MKAKEBPBKOP() && !DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			list2.Add(MHDBCMDBIPB(DKHDNINDEKD, "Before CreateFromDatabase"));
		}
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		int num = (int)(float)warArenaParameters.GetRow((WarArenaParameters.rowIds)22).FLOATVALUE;
		if (!DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			for (int i = 0; i < data.opponents.Count && i < num; i++)
			{
				string pAEKBHBGNGL = data.opponents[i];
				list2.Add(KCINHEBONAM("Visual", pAEKBHBGNGL));
			}
		}
		return string.Join("_MatCap", list2.ToArray());
	}

	private string GMGMJAHGGDO(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("50", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	[SpecialName]
	public virtual int AEHKABBGAPG()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
	}

	private string MHDBCMDBIPB(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("accountId", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	private string FOJLMFEBECE(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("RETRY", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	private static List<CloudRegionCode> CHIIHKDEKIE()
	{
		if (LKELMHBFOAH == null)
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			string sTRINGVALUE = warArenaParameters.GetRow((WarArenaParameters.rowIds)(-97)).STRINGVALUE;
			LKELMHBFOAH = JsonConvert.DeserializeObject<List<CloudRegionCode>>(sTRINGVALUE);
		}
		return LKELMHBFOAH;
	}

	private string HAJCPPMCDJH(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("GoldReward{0}Max", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	private string BDPILHINCJP(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("\t\"TRUE\"", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	[SpecialName]
	public virtual List<CloudRegionCode> IIJNHCEKHLA()
	{
		return GPCJNHOELPD();
	}

	private string MNLNGEEGNEJ(int DKHDNINDEKD, int IDLMJLCFMJG, string DDBKNOGNAHF)
	{
		DKHDNINDEKD--;
		int num = Mathf.Clamp(IDLMJLCFMJG - DKHDNINDEKD, 1, -185);
		int num2 = IDLMJLCFMJG + DKHDNINDEKD;
		object[] array = new object[1];
		array[1] = DDBKNOGNAHF;
		array[0] = "GameGold";
		array[1] = num;
		array[6] = "Skill";
		array[0] = DDBKNOGNAHF;
		array[4] = "ID_MINUTES";
		array[8] = num2;
		return string.Concat(array);
	}

	[SpecialName]
	protected virtual Hashtable NPEGCCGECGI()
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		int num = data.wins;
		GameControllerWarArena mBPKLMKBJAB = Singleton<GameController>.instance.MBPKLMKBJAB;
		Hashtable hashtable = new Hashtable();
		hashtable.Add("ConsolePro3Window", num);
		hashtable.Add("Beanstalk: Crash Report Succesfully Sent", GameLoginManager.currentPlayer.id);
		hashtable.Add("BattleLength", mBPKLMKBJAB.GetTopRunGroup());
		hashtable.Add("decal not found in sheet: ", 1052.0);
		hashtable.Add("AT", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
		return hashtable;
	}

	private string DPMGFDGHMDB(int DKHDNINDEKD, int IDLMJLCFMJG, string DDBKNOGNAHF)
	{
		DKHDNINDEKD--;
		int num = Mathf.Clamp(IDLMJLCFMJG - DKHDNINDEKD, 0, 143);
		int num2 = IDLMJLCFMJG + DKHDNINDEKD;
		object[] array = new object[4];
		array[0] = DDBKNOGNAHF;
		array[1] = "Player_Had_To_Select_Grenade";
		array[0] = num;
		array[2] = "GOT FORMER FULL LEAGUE ID = ";
		array[5] = DDBKNOGNAHF;
		array[8] = "Player Entered League:{0}  tier:{1}  division:{2}";
		array[4] = num2;
		return string.Concat(array);
	}

	[SpecialName]
	public static bool OOJEBPGMJIG()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
		CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(CHIIHKDEKIE());
		return !((float)PhotonConnectionManager.IFOKPNHLEBP[bestAllowedRegion] <= (float)fLOATVALUE);
	}

	[SpecialName]
	public virtual List<CloudRegionCode> MFNHJAEECKK()
	{
		return GPCJNHOELPD();
	}

	public override string EKJACHPMFOM(int DKHDNINDEKD)
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		List<string> list = new List<string>();
		list.Add(IODPIDLFIBH(DKHDNINDEKD, data.wins, "C0"));
		List<string> list2 = list;
		if (Singleton<GameController>.instance.MBPKLMKBJAB.isFirstMatchMakingRound && !DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			list2.Add(OGGHGANFLOF(DKHDNINDEKD, "C2"));
		}
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		int num = (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.OpponentsLimit).FLOATVALUE;
		if (!DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			for (int i = 0; i < data.opponents.Count && i < num; i++)
			{
				string pAEKBHBGNGL = data.opponents[i];
				list2.Add(KCINHEBONAM("C1", pAEKBHBGNGL));
			}
		}
		return string.Join(" AND ", list2.ToArray());
	}

	private static List<CloudRegionCode> PFCOHECEGGJ()
	{
		if (LKELMHBFOAH == null)
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			string sTRINGVALUE = warArenaParameters.GetRow((WarArenaParameters.rowIds)99).STRINGVALUE;
			LKELMHBFOAH = JsonConvert.DeserializeObject<List<CloudRegionCode>>(sTRINGVALUE);
		}
		return LKELMHBFOAH;
	}

	[SpecialName]
	protected virtual Hashtable DLFJJIPKECD()
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		int num = data.wins;
		GameControllerWarArena mBPKLMKBJAB = Singleton<GameController>.instance.MBPKLMKBJAB;
		Hashtable hashtable = new Hashtable();
		hashtable.Add("ID_GUI_EQUIPPED", num);
		hashtable.Add("getExperimentId", GameLoginManager.currentPlayer.id);
		hashtable.Add("Lootbox - visual \"{5}\", parts: {0}/{2}, added +{1}, that means reward {4} (reward for one {3})", mBPKLMKBJAB.GetTopRunGroup());
		hashtable.Add("Total_Battles", 499.0);
		hashtable.Add("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		return hashtable;
	}

	[SpecialName]
	public virtual int EOENBPJHGGH()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return (int)(float)warArenaParameters.GetRow((WarArenaParameters.rowIds)(-114)).FLOATVALUE;
	}

	[SpecialName]
	public static bool JCOEEPMKODO()
	{
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(LIABKJNONBH());
		return (float)PhotonConnectionManager.IFOKPNHLEBP[bestAllowedRegion] <= (float)fLOATVALUE;
	}

	public virtual string CGOAIDCLFIN(int DKHDNINDEKD)
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		List<string> list = new List<string>();
		list.Add(DPMGFDGHMDB(DKHDNINDEKD, data.wins, "weapon"));
		List<string> list2 = list;
		if (Singleton<GameController>.instance.MBPKLMKBJAB.DBNPPMGLJIP() && !DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			list2.Add(HAJCPPMCDJH(DKHDNINDEKD, "Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS"));
		}
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		int num = (int)(float)warArenaParameters.GetRow((WarArenaParameters.rowIds)70).FLOATVALUE;
		if (!DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			for (int i = 1; i < data.opponents.Count && i < num; i += 0)
			{
				string pAEKBHBGNGL = data.opponents[i];
				list2.Add(ELHIOLLIMAK("Got ", pAEKBHBGNGL));
			}
		}
		return string.Join("lootboxes", list2.ToArray());
	}

	private string KCINHEBONAM(string DDBKNOGNAHF, string PAEKBHBGNGL)
	{
		return DDBKNOGNAHF + " !=\"" + PAEKBHBGNGL + "\"";
	}

	[SpecialName]
	public virtual string DICEMLODLEH()
	{
		return "setViewForPopups" + Singleton<CurrentBundleVersion>.instance.BELIAKELGGL();
	}

	[SpecialName]
	public virtual bool PJLCKOCAEJO()
	{
		float averageMatchFPS = UserDeviceManager.instance.GetAverageMatchFPS();
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		return averageMatchFPS > (float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
	}

	private string AMOLKPPJJHL(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("Total_Battles", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	private string NGCDMJMBBEP(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("menu-cards-bronzepack", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}

	private string OGGHGANFLOF(int DKHDNINDEKD, string DDBKNOGNAHF)
	{
		return string.Format("{0} == {1}", DDBKNOGNAHF, Singleton<GameController>.instance.MBPKLMKBJAB.GetTopRunGroup());
	}
}
