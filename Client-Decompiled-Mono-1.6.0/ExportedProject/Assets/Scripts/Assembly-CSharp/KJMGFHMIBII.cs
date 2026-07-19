using System.Collections.Generic;
using ExitGames.Client.Photon;
using Google2u;
using UnityEngine;

public abstract class KJMGFHMIBII
{
	private readonly List<CloudRegionCode> LKELMHBFOAH = new List<CloudRegionCode>
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

	public virtual bool MBOHGLCBEFJ
	{
		get
		{
			return false;
		}
	}

	protected virtual Hashtable GCFEIDJMLGE
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("C0", LevelManager.instance.currentLevel.displayNumber);
			hashtable.Add("C1", (int)GameLoginManager.currentPlayer.leagueTier);
			hashtable.Add("C2", GameLoginManager.currentPlayer.medalsBalance);
			hashtable.Add("C3", LevelManager.instance.bestArmyPower);
			hashtable.Add("C4", Singleton<MapManager>.instance.isRandomMap ? 1 : 0);
			hashtable.Add("battleID", GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			hashtable.Add("C5", StatsManager.instance.data.deathMatchWinLooseStreak * 100f);
			hashtable.Add("MatchStart", double.PositiveInfinity);
			return hashtable;
		}
	}

	public virtual string NJKMFAGIKIE
	{
		get
		{
			return "myLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
		}
	}

	public TypedLobby FDABONGOFJO
	{
		get
		{
			return new TypedLobby(NJKMFAGIKIE, LobbyType.SqlLobby);
		}
	}

	public virtual RoomOptions NCDDLBIJIIH
	{
		get
		{
			RoomOptions roomOptions = new RoomOptions();
			roomOptions.IsVisible = false;
			roomOptions.IsOpen = true;
			roomOptions.MaxPlayers = 2;
			roomOptions.CustomRoomProperties = GCFEIDJMLGE;
			roomOptions.CustomRoomPropertiesForLobby = new string[5] { "C0", "C1", "C2", "C3", "C5" };
			roomOptions.PublishUserId = true;
			return roomOptions;
		}
	}

	public virtual int MANOCBMEGOK
	{
		get
		{
			return 0;
		}
	}

	public virtual bool IGBMAJGJDEL
	{
		get
		{
			return true;
		}
	}

	public virtual float MGOBKMIGPEK
	{
		get
		{
			return Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
		}
	}

	public virtual int NBIJIDLEJBC
	{
		get
		{
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
			return (int)matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MaxMatchMakingRegionsAndroid).FLOATVALUE;
		}
	}

	public virtual List<CloudRegionCode> FCOKCCNOHBA
	{
		get
		{
			return LKELMHBFOAH;
		}
	}

	protected string OHDNLGHFNAH(int DKHDNINDEKD, int IDLMJLCFMJG, string DDBKNOGNAHF, string FDNEABNPCEO, float FJNJGHGMFND = 1f)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.matchmakingDeviations.GetRowIndex(FDNEABNPCEO + LevelManager.instance.currentLevel.displayNumber);
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.matchmakingDeviations.GetValue(rowIndex, "Step" + DKHDNINDEKD);
			num = (int)((float)num * FJNJGHGMFND);
		}
		else
		{
			Debug.LogError("Row: " + FDNEABNPCEO + LevelManager.instance.currentLevel.displayNumber + "doesnt exist");
		}
		int num2 = IDLMJLCFMJG - num;
		int num3 = IDLMJLCFMJG + num;
		return DDBKNOGNAHF + " >=" + num2 + " AND " + DDBKNOGNAHF + " <=" + num3;
	}

	public virtual string EKJACHPMFOM(int DKHDNINDEKD)
	{
		return string.Empty;
	}
}
