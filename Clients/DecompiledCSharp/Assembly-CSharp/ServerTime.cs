using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class ServerTime
{
	private const int warsInterval = 604800;

	private const int playerLeagueInterval = 604800;

	private ObscuredFloat mLastRealtimeSinceStartup;

	private ObscuredInt mServerTimeStamp;

	private int tmp;

	public int nextWarsEvaluation { get; private set; }

	public int nextLeagueEvaluation { get; private set; }

	public int midnight { get; set; }

	public int GetCurrentTimestamp()
	{
		return (int)mServerTimeStamp + (int)(Time.realtimeSinceStartup - (float)mLastRealtimeSinceStartup);
	}

	public int GetLastUpdateFromServer()
	{
		return (int)(Time.realtimeSinceStartup - (float)mLastRealtimeSinceStartup);
	}

	public double GetCurrentTimestampDouble()
	{
		return (double)(int)mServerTimeStamp + (double)(Time.realtimeSinceStartup - (float)mLastRealtimeSinceStartup);
	}

	public int GetPlayerDataLoadedTimestamp()
	{
		return mServerTimeStamp;
	}

	internal void Init(int timestamp)
	{
		mLastRealtimeSinceStartup = Time.realtimeSinceStartup;
		mServerTimeStamp = timestamp;
		tmp = 0;
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
	}

	internal int GetLastUpdateFromServerDebug()
	{
		int result = 0;
		if (GetLastUpdateFromServer() - tmp > 2)
		{
			result = GetLastUpdateFromServer() - tmp;
			tmp = GetLastUpdateFromServer();
		}
		return result;
	}

	public int GetNextWarsEvaluation()
	{
		InitNextWarsEvaluation(nextWarsEvaluation);
		return nextWarsEvaluation;
	}

	private int ProcessTimestamp(int timestamp, int interval)
	{
		int currentTimestamp = GetCurrentTimestamp();
		if (timestamp <= currentTimestamp)
		{
			Debug.Log("Evaluation is old! " + timestamp + ", current = " + currentTimestamp + ", interval = " + interval);
			while (timestamp <= currentTimestamp)
			{
				timestamp += interval;
			}
		}
		return timestamp;
	}

	internal void InitNextWarsEvaluation(int timestamp)
	{
		nextWarsEvaluation = ProcessTimestamp(timestamp, 604800);
		PushNotificationManager.instance.ScheduleLocalNextWarsNotification(nextWarsEvaluation - GetCurrentTimestamp());
	}

	internal void InitNextLeagueEvaluation(int timestamp)
	{
		int num = (int)(GameLoginManager.currentPlayer.leagueTier - 1);
		int interval = 604800;
		if (num < Singleton<GameVariables>.instance.playerLeaderboards.Rows.Count && num >= 0)
		{
			interval = Singleton<GameVariables>.instance.playerLeaderboards.Rows[num].DURATION * 3600;
		}
		nextLeagueEvaluation = ProcessTimestamp(timestamp, interval);
		PushNotificationManager.instance.ScheduleLocalNextLeagueNotification(nextLeagueEvaluation - GetCurrentTimestamp());
	}

	internal int GetNextLeagueEvaluation()
	{
		InitNextLeagueEvaluation(nextLeagueEvaluation);
		return nextLeagueEvaluation;
	}

	internal static double GetUtcOffset()
	{
		return (DateTime.Now - DateTime.UtcNow).TotalHours;
	}
}
