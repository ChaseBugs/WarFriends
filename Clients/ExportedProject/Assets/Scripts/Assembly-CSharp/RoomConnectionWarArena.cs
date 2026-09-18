using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class RoomConnectionWarArena : RoomConnection
{
	private static List<CloudRegionCode> mAllowedRegions;

	public override bool isRandom => true;

	public override RoomOptions roomOptions
	{
		get
		{
			RoomOptions roomOptions = base.roomOptions;
			roomOptions.IsVisible = true;
			roomOptions.CustomRoomPropertiesForLobby = new string[2] { "C0", "C1" };
			return roomOptions;
		}
	}

	protected override Hashtable roomProperties
	{
		get
		{
			WarArena.WarArenaData data = WarArena.instance.data;
			int num = data.wins;
			Hashtable hashtable = new Hashtable();
			hashtable.Add("C0", num);
			hashtable.Add("C1", GameLoginManager.currentPlayer.id);
			hashtable.Add("MatchStart", double.PositiveInfinity);
			hashtable.Add("battleID", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			return hashtable;
		}
	}

	public override int maxSearchSteps
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
		}
	}

	public override string lobbyName => "warArenaLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;

	public override bool shouldCreateRoom
	{
		get
		{
			float averageMatchFPS = UserDeviceManager.instance.GetAverageMatchFPS();
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return averageMatchFPS > (float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumMasterFPS).FLOATVALUE;
		}
	}

	public override float maxPing
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
		}
	}

	public override int maxRegionsToConnect
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			return (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsAndroid).FLOATVALUE;
		}
	}

	public static bool hasGoodPing
	{
		get
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			ObscuredFloat fLOATVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
			CloudRegionCode bestAllowedRegion = PhotonConnectionManager.GetBestAllowedRegion(GetAllowdRegions());
			return (float)PhotonConnectionManager.bestRegions[bestAllowedRegion] <= (float)fLOATVALUE;
		}
	}

	public override List<CloudRegionCode> allowedRegions => GetAllowdRegions();

	private static List<CloudRegionCode> GetAllowdRegions()
	{
		if (mAllowedRegions == null)
		{
			WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
			string sTRINGVALUE = warArenaParameters.GetRow(WarArenaParameters.rowIds.EnabledRegions).STRINGVALUE;
			mAllowedRegions = JsonConvert.DeserializeObject<List<CloudRegionCode>>(sTRINGVALUE);
		}
		return mAllowedRegions;
	}

	private string GetFilterForWins(int attemt, int number, string paramName)
	{
		attemt--;
		int num = Mathf.Clamp(number - attemt, 0, int.MaxValue);
		int num2 = number + attemt;
		return paramName + " >=" + num + " AND " + paramName + " <=" + num2;
	}

	private string GetFilterForOpponent(string paramName, string opponentId)
	{
		return paramName + " !=\"" + opponentId + "\"";
	}

	public override string GetSqlFilter(int attemt)
	{
		WarArena.WarArenaData data = WarArena.instance.data;
		List<string> list = new List<string>();
		list.Add(GetFilterForWins(attemt, data.wins, "C0"));
		List<string> list2 = list;
		WarArenaParameters warArenaParameters = WarArena.instance.warArenaParameters;
		int num = (int)(float)warArenaParameters.GetRow(WarArenaParameters.rowIds.OpponentsLimit).FLOATVALUE;
		if (!DebugSettings.instance.data.warenaEnableMultipleMatches)
		{
			for (int i = 0; i < data.opponents.Count && i < num; i++)
			{
				string opponentId = data.opponents[i];
				list2.Add(GetFilterForOpponent("C1", opponentId));
			}
		}
		return string.Join(" AND ", list2.ToArray());
	}
}
