using System;
using System.Collections.Generic;
using UnityEngine;

public class ServerResultsCache : Singleton<ServerResultsCache>
{
	public static class Key
	{
		public const string GlobalPlayerLeaderboard = "globalPlayerLeaderboard";

		public const string LocalPlayerLeaderboard = "localPlayerLeaderboard";

		public const string PlayersFromLeague = "leagueMembers";

		public const string Squad = "squad";

		public const string MissionLeaderboard = "missionLeaderboards";

		public const string FacebookFriends = "facebookFriends";

		public const string SquadMembers = "squadMembers";

		public const string GlobalSquadLeaderboard = "globalSquadLeaderboard";

		public const string LocalSquadLeaderboard = "localSquadLeaderboard";

		public const string LastWeekPlayerLeague = "lastWeeksPlayerLeague";

		public const string Friends = "players";

		public const string SquadsFromLeague = "squadsFromLeague";

		public const string PlayerInfo = "playerInfo";

		public const string ArenaLeaderboard = "arenaLeaderboard";
	}

	public DatabaseGameReward lastGameReward;

	public Action AnyPlayerUpdated;

	public Action PlayerLeagueProcessingChanged;

	public Action SquadWarProcessingChanged;

	private Dictionary<DatabaseAction, int> mWaitList;

	private Dictionary<string, Tuple<DateTime, object>> mCache;

	private bool mIsSquadWarsProcessing;

	private bool mIsPlayerLeagueProcessing;

	public string squadWarsId;

	public string playerLeaguesId;

	public DatabaseSquadEventDefinition squadEventDefinition { get; set; }

	public DatabaseSquadEventProgress squadEventProgress { get; set; }

	public List<DatabasePlayer> playerSearchResult { get; set; }

	public List<DatabaseSquad> squadSearchResult { get; set; }

	public bool squadSearchIsLocal { get; set; }

	public bool isSquadWarsProcessing
	{
		get
		{
			return mIsSquadWarsProcessing;
		}
		set
		{
			if (value != mIsSquadWarsProcessing)
			{
				mIsSquadWarsProcessing = value;
				if (SquadWarProcessingChanged != null)
				{
					SquadWarProcessingChanged();
				}
			}
		}
	}

	public bool isPlayerLeagueProcessing
	{
		get
		{
			return mIsPlayerLeagueProcessing;
		}
		set
		{
			if (value != mIsPlayerLeagueProcessing)
			{
				mIsPlayerLeagueProcessing = value;
				if (PlayerLeagueProcessingChanged != null)
				{
					PlayerLeagueProcessingChanged();
				}
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mCache = new Dictionary<string, Tuple<DateTime, object>>();
		mWaitList = new Dictionary<DatabaseAction, int>();
		GameLoginManager.instance.PlayerLeftSquad += delegate
		{
			ClearCache();
		};
		GameLoginManager.instance.DeviceRegistered += delegate
		{
			ClearCache();
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook)
			{
				Debug.Log("Cache: Cleared");
				ClearCache();
			}
		};
		Singleton<GameController>.instance.GameStarted += delegate
		{
			lastGameReward = null;
		};
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += delegate
		{
			Debug.LogError("Clearing Waitlist cache...");
			mWaitList.Clear();
		};
	}

	private void ClearCache()
	{
		mCache.Clear();
		mWaitList.Clear();
	}

	private bool Exists<T>(string key, bool ommitTime = false) where T : class
	{
		Type typeFromHandle = typeof(T);
		return mCache.ContainsKey(typeFromHandle.Name + key) && (ommitTime || DateTime.Now < mCache[typeFromHandle.Name + key].Value1);
	}

	public void RemovePlayerLeagueLeaderboard(string leagueId)
	{
		if (Remove<List<DatabaseSquad>>("leagueMembers" + leagueId))
		{
			Debug.Log("Leaderboard removed succesfully");
		}
	}

	private T Get<T>(string key, bool ommitTime = false) where T : class
	{
		Type typeFromHandle = typeof(T);
		if (!mCache.ContainsKey(typeFromHandle.Name + key) || (DateTime.Now >= mCache[typeFromHandle.Name + key].Value1 && !ommitTime))
		{
			throw new ApplicationException("An object of the desired type does not exist: " + typeFromHandle.Name + ", key = " + key);
		}
		return mCache[typeFromHandle.Name + key].Value2 as T;
	}

	internal List<DatabasePlayer> GetPlayersFromLeague(string leagueId, bool ommitTime = false)
	{
		if (!Exists<List<DatabasePlayer>>("leagueMembers" + leagueId, ommitTime))
		{
			return null;
		}
		return Get<List<DatabasePlayer>>("leagueMembers" + leagueId, ommitTime);
	}

	public void Insert<T>(string key, object value, DateTime expirationTime, DatabaseAction action = DatabaseAction.Test)
	{
		Type typeFromHandle = typeof(T);
		mCache[typeFromHandle.Name + key] = new Tuple<DateTime, object>
		{
			Value1 = expirationTime,
			Value2 = value
		};
		if (mWaitList.ContainsKey(action))
		{
			Debug.Log(string.Concat("Cache: Removing ", action, " from waitlist"));
			mWaitList.Remove(action);
		}
		if (key.StartsWith("leagueMembers"))
		{
			UpdateCache<DatabasePlayer, DatabasePlayerData>(key, value, expirationTime, "globalPlayerLeaderboard");
		}
		else if (key.StartsWith("globalPlayerLeaderboard"))
		{
			string text = (string.IsNullOrEmpty(GameLoginManager.currentPlayer.leagueId) ? string.Empty : GameLoginManager.currentPlayer.leagueId);
			UpdateCache<DatabasePlayerData, DatabasePlayer>(key, value, expirationTime, "leagueMembers" + text);
		}
		else if (key.StartsWith("playerInfo") && value is IDatabasePlayer)
		{
			UpdateCache<DatabasePlayerData>(value as IDatabasePlayer, "globalPlayerLeaderboard");
			UpdateCache<DatabasePlayerData>(value as IDatabasePlayer, "localPlayerLeaderboard");
			UpdateCache<DatabasePlayer>(value as IDatabasePlayer, "leagueMembers");
			if (AnyPlayerUpdated != null)
			{
				AnyPlayerUpdated();
			}
		}
	}

	public void UpdateCache<TU>(IDatabasePlayer newDataForPlayer, string cacheKey)
	{
		string key = typeof(Dictionary<string, TU>).Name + cacheKey;
		if (mCache.ContainsKey(key))
		{
			Tuple<DateTime, object> tuple = mCache[key];
			Dictionary<string, TU> dictionary = tuple.Value2 as Dictionary<string, TU>;
			if (dictionary.ContainsKey(newDataForPlayer.GetId()))
			{
				IDatabasePlayer databasePlayer = dictionary[newDataForPlayer.GetId()] as IDatabasePlayer;
				databasePlayer.SetSquadId(newDataForPlayer.GetSquadId());
			}
		}
	}

	private void UpdateCache<T, TU>(string key, object value, DateTime expirationTime, string keyOfOtherLeaderboard)
	{
		List<T> list = new List<T>(((Dictionary<string, T>)value).Values);
		mCache[typeof(List<T>).Name + key] = new Tuple<DateTime, object>
		{
			Value1 = expirationTime,
			Value2 = list
		};
		string key2 = string.Concat(typeof(Dictionary<string, TU>), keyOfOtherLeaderboard);
		if (!mCache.ContainsKey(key2))
		{
			return;
		}
		Tuple<DateTime, object> tuple = mCache[key2];
		if (!(tuple.Value2 is Dictionary<string, TU> dictionary))
		{
			return;
		}
		foreach (T item in list)
		{
			IDatabasePlayer databasePlayer = item as IDatabasePlayer;
			if (dictionary.ContainsKey(databasePlayer.GetId()))
			{
				IDatabasePlayer databasePlayer2 = (IDatabasePlayer)(object)dictionary[databasePlayer.GetId()];
				databasePlayer2.SetSquadId(databasePlayer.GetSquadId());
				dictionary[databasePlayer.GetId()] = (TU)databasePlayer2;
			}
		}
		Debug.Log("Saved another leaderboard");
		mCache[key2].Value2 = dictionary;
		mCache[string.Concat(typeof(List<TU>), "globalPlayerLeaderboard")].Value2 = new List<TU>(dictionary.Values);
	}

	public bool Remove<T>(string key)
	{
		Type typeFromHandle = typeof(T);
		if (!mCache.ContainsKey(typeFromHandle.Name + key))
		{
			return false;
		}
		mCache.Remove(typeFromHandle.Name + key);
		return true;
	}

	internal List<DatabaseSquad> GetGlobalSquadLeaderboard(bool ommitTime = false)
	{
		if (!Exists<List<DatabaseSquad>>("globalSquadLeaderboard", ommitTime))
		{
			return null;
		}
		return Get<List<DatabaseSquad>>("globalSquadLeaderboard", ommitTime);
	}

	internal List<DatabaseSquad> GetLocalSquadLeaderboard()
	{
		if (!Exists<List<DatabaseSquad>>("localSquadLeaderboard"))
		{
			return null;
		}
		return Get<List<DatabaseSquad>>("localSquadLeaderboard");
	}

	internal DatabasePlayerInfo GetPlayer(string playerId)
	{
		if (!Exists<DatabasePlayerInfo>("playerInfo" + playerId))
		{
			return null;
		}
		return Get<DatabasePlayerInfo>("playerInfo" + playerId);
	}

	internal bool IsWaitingFor(DatabaseAction dbAction)
	{
		bool result = true;
		if (!mWaitList.ContainsKey(dbAction))
		{
			result = false;
			mWaitList.Add(dbAction, 1);
		}
		return result;
	}

	internal List<DatabasePlayerData> GetGlobalPlayerLeaderboard()
	{
		if (!Exists<List<DatabasePlayerData>>("globalPlayerLeaderboard"))
		{
			return null;
		}
		return Get<List<DatabasePlayerData>>("globalPlayerLeaderboard");
	}

	internal List<DatabasePlayerData> GetArenaLeaderboard()
	{
		if (!Exists<List<DatabasePlayerData>>("arenaLeaderboard"))
		{
			return null;
		}
		return Get<List<DatabasePlayerData>>("arenaLeaderboard");
	}

	internal List<DatabasePlayerData> GetLocalPlayerLeaderboard()
	{
		if (!Exists<List<DatabasePlayerData>>("localPlayerLeaderboard"))
		{
			return null;
		}
		return Get<List<DatabasePlayerData>>("localPlayerLeaderboard");
	}

	internal DatabaseSquad GetSquad(string squadName, bool ommitTime = false)
	{
		if (!Exists<DatabaseSquad>("squad" + squadName, ommitTime))
		{
			return null;
		}
		return Get<DatabaseSquad>("squad" + squadName, ommitTime);
	}

	internal List<DatabasePlayer> GetLastWeekPlayerLeague()
	{
		if (!Exists<List<DatabasePlayer>>("lastWeeksPlayerLeague"))
		{
			return null;
		}
		return Get<List<DatabasePlayer>>("lastWeeksPlayerLeague");
	}

	internal List<DatabasePlayerMissionLeaderboard> GetMissionLeaderboards()
	{
		if (!Exists<List<DatabasePlayerMissionLeaderboard>>("missionLeaderboards"))
		{
			return null;
		}
		return Get<List<DatabasePlayerMissionLeaderboard>>("missionLeaderboards");
	}

	internal List<DatabasePlayer> GetFacebookFriends()
	{
		if (!Exists<List<DatabasePlayer>>("facebookFriends"))
		{
			return null;
		}
		return Get<List<DatabasePlayer>>("facebookFriends");
	}

	internal List<DatabasePlayer> GetSquadMembers(string squadName, bool ommitTime = false)
	{
		if (!Exists<List<DatabasePlayer>>("squadMembers" + squadName, ommitTime))
		{
			return null;
		}
		return Get<List<DatabasePlayer>>("squadMembers" + squadName, ommitTime);
	}

	internal List<DatabasePlayer> GetFriends()
	{
		if (!Exists<List<DatabasePlayer>>("players"))
		{
			return null;
		}
		return Get<List<DatabasePlayer>>("players");
	}

	internal List<DatabaseSquad> GetSquadsFromLeague(string roundId)
	{
		if (!Exists<List<DatabaseSquad>>("squadsFromLeague" + roundId))
		{
			return null;
		}
		return Get<List<DatabaseSquad>>("squadsFromLeague" + roundId);
	}

	internal void AddPlayerAfterAcceptJoin(DatabasePlayer player)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (string.IsNullOrEmpty(squadName))
		{
			Debug.LogError("Player not in squad! - WTF");
			return;
		}
		List<DatabasePlayer> squadMembers = GetSquadMembers(squadName);
		if (squadMembers == null)
		{
			Debug.LogError("Squad Members not in client cache!");
			return;
		}
		string key = typeof(List<DatabasePlayer>).Name + "squadMembers" + squadName;
		DateTime expirationTime = ((!mCache.ContainsKey(key)) ? DateTime.Now.AddSeconds(20.0) : mCache[key].Value1);
		for (int i = 0; i < squadMembers.Count; i++)
		{
			DatabasePlayer databasePlayer = squadMembers[i];
			if (databasePlayer.id == player.id)
			{
				Debug.LogError("already in clan (in cache)");
				return;
			}
		}
		squadMembers.Add(player);
		Insert<List<DatabasePlayer>>("squadMembers" + squadName, squadMembers, expirationTime, DatabaseAction.AcceptSquadJoinRequest);
		string key2 = typeof(DatabaseSquad).Name + "squad" + squadName;
		if (mCache.ContainsKey(key2))
		{
			DateTime value = mCache[key2].Value1;
			DatabaseSquad squad = GetSquad(squadName, ommitTime: true);
			squad.size = squadMembers.Count;
			Insert<DatabaseSquad>("squad" + squadName, squad, value);
		}
	}

	internal void UpdateSquadPlayer(DatabasePlayer player)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (string.IsNullOrEmpty(squadName))
		{
			Debug.LogError("Player no longer in squad!");
			return;
		}
		List<DatabasePlayer> squadMembers = GetSquadMembers(squadName);
		if (squadMembers == null)
		{
			Debug.LogError("Squad Members not in client cache!");
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName);
			return;
		}
		string key = typeof(List<DatabasePlayer>).Name + "squadMembers" + squadName;
		DateTime expirationTime = ((!mCache.ContainsKey(key)) ? DateTime.Now.AddSeconds(20.0) : mCache[key].Value1);
		int num = -1;
		for (int i = 0; i < squadMembers.Count; i++)
		{
			DatabasePlayer databasePlayer = squadMembers[i];
			if (databasePlayer.id == player.id)
			{
				num = i;
			}
		}
		if (num != -1)
		{
			if (player.squadRank == SquadRank.None)
			{
				squadMembers.RemoveAt(num);
			}
			else
			{
				squadMembers[num] = player;
			}
		}
		Insert<List<DatabasePlayer>>("squadMembers" + squadName, squadMembers, expirationTime, DatabaseAction.GetAllSquadMembers);
		string key2 = typeof(DatabaseSquad).Name + "squad" + squadName;
		if (mCache.ContainsKey(key2))
		{
			DateTime value = mCache[key2].Value1;
			DatabaseSquad squad = GetSquad(squadName, ommitTime: true);
			squad.size = squadMembers.Count;
			Insert<DatabaseSquad>("squad" + squadName, squad, value);
		}
	}

	internal void UpdateSquad(DatabaseSquad squad)
	{
		string key = typeof(List<DatabaseSquad>).Name + "globalSquadLeaderboard";
		if (mCache.ContainsKey(key))
		{
			DateTime value = mCache[key].Value1;
			List<DatabaseSquad> globalSquadLeaderboard = GetGlobalSquadLeaderboard();
			if (globalSquadLeaderboard != null)
			{
				int num = globalSquadLeaderboard.FindIndex((DatabaseSquad databaseSquad) => databaseSquad.name == squad.name);
				if (num > -1)
				{
					globalSquadLeaderboard[num] = squad;
					Insert<List<DatabaseSquad>>("globalSquadLeaderboard", globalSquadLeaderboard, value);
				}
			}
		}
		key = typeof(List<DatabaseSquad>).Name + "localSquadLeaderboard";
		if (!mCache.ContainsKey(key))
		{
			return;
		}
		DateTime value2 = mCache[key].Value1;
		List<DatabaseSquad> localSquadLeaderboard = GetLocalSquadLeaderboard();
		if (localSquadLeaderboard != null)
		{
			int num2 = localSquadLeaderboard.FindIndex((DatabaseSquad databaseSquad) => databaseSquad.name == squad.name);
			if (num2 > -1)
			{
				localSquadLeaderboard[num2] = squad;
				Insert<List<DatabaseSquad>>("localSquadLeaderboard", localSquadLeaderboard, value2);
			}
		}
	}

	internal void UpdatePlayer(DatabasePlayerInfo player)
	{
		GuiElementSingle<ChatGuiElement>.instance.messageContent.UpdatePlayerInMessages(player);
	}
}
