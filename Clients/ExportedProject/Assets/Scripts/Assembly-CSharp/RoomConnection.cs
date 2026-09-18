using System.Collections.Generic;
using ExitGames.Client.Photon;
using Google2u;
using UnityEngine;

public abstract class RoomConnection
{
	private readonly List<CloudRegionCode> mAllowedRegions = new List<CloudRegionCode>
	{
		CloudRegionCode.eu,
		CloudRegionCode.us,
		CloudRegionCode.asia,
		CloudRegionCode.jp,
		CloudRegionCode.au,
		CloudRegionCode.usw,
		CloudRegionCode.sa,
		CloudRegionCode.cae,
		CloudRegionCode.kr,
		CloudRegionCode.@in
	};

	public virtual bool isRandom => false;

	protected virtual Hashtable roomProperties
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("C0", LevelManager.instance.currentLevel.displayNumber);
			hashtable.Add("C1", (int)GameLoginManager.currentPlayer.leagueTier);
			hashtable.Add("C2", GameLoginManager.currentPlayer.medalsBalance);
			hashtable.Add("C3", LevelManager.instance.armyPower);
			hashtable.Add("C4", Singleton<MapManager>.instance.isRandomMap ? 1 : 0);
			hashtable.Add("battleID", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			hashtable.Add("C5", StatsManager.instance.data.deathMatchWinLooseStreak * 100f);
			hashtable.Add("MatchStart", double.PositiveInfinity);
			return hashtable;
		}
	}

	public virtual string lobbyName => "myLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;

	public TypedLobby lobby => new TypedLobby(lobbyName, LobbyType.SqlLobby);

	public virtual RoomOptions roomOptions
	{
		get
		{
			RoomOptions roomOptions = new RoomOptions();
			roomOptions.IsVisible = false;
			roomOptions.IsOpen = true;
			roomOptions.MaxPlayers = 2;
			roomOptions.CustomRoomProperties = roomProperties;
			roomOptions.CustomRoomPropertiesForLobby = new string[5] { "C0", "C1", "C2", "C3", "C5" };
			roomOptions.PublishUserId = true;
			return roomOptions;
		}
	}

	public virtual int maxSearchSteps => 0;

	public virtual bool shouldCreateRoom => true;

	public virtual float maxPing => Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;

	public virtual int maxRegionsToConnect
	{
		get
		{
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
			return (int)matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MaxMatchMakingRegionsAndroid).FLOATVALUE;
		}
	}

	public virtual List<CloudRegionCode> allowedRegions => mAllowedRegions;

	protected string GetSqlRangeFilterPart(int attemt, int number, string paramName, string column, float m = 1f)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.matchmakingDeviations.GetRowIndex(column + LevelManager.instance.currentLevel.displayNumber);
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.matchmakingDeviations.GetValue(rowIndex, "Step" + attemt);
			num = (int)((float)num * m);
		}
		else
		{
			Debug.LogError("Row: " + column + LevelManager.instance.currentLevel.displayNumber + "doesnt exist");
		}
		int num2 = number - num;
		int num3 = number + num;
		return paramName + " >=" + num2 + " AND " + paramName + " <=" + num3;
	}

	public virtual string GetSqlFilter(int attemt)
	{
		return string.Empty;
	}
}
