using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class LeagueArcManager : Core_BaseScript
{
	private LeagueArcData mCurrentData;

	private LeagueArcData mPreviousData;

	private List<DatabasePlayer> mPreviousDatabasePlayers;

	private List<DatabasePlayer> mCurrentDatabasePlayers;

	private bool mUpdatedData;

	private bool mAfterGameEnded;

	private RadicalRoutine mLeagueUpdate;

	private int mLeagueEndTime;

	private static LeagueArcManager mInstance;

	public static LeagueArcManager instance
	{
		get
		{
			mInstance = mInstance ?? ((LeagueArcManager)UnityEngine.Object.FindObjectsOfType(typeof(LeagueArcManager))[0]);
			return mInstance;
		}
	}

	public event Action<League, int> ShowLoading;

	public event Action<LeagueArcData> LeagueArcUpdate;

	public event Action<int, List<DatabasePlayer>> SorterPlayersLeague;

	public event Action StopIgnore;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void LeftEndScreen()
	{
		mAfterGameEnded = false;
		SaveDataToPrevious(mCurrentDatabasePlayers);
		if (this.StopIgnore != null)
		{
			this.StopIgnore();
		}
	}

	public LeagueArcData GetPreviousData()
	{
		if (mPreviousData == null)
		{
			mPreviousData = ((mCurrentData != null) ? new LeagueArcData(mCurrentData) : new LeagueArcData());
			mPreviousData.leagueMedals = 0;
		}
		return mPreviousData;
	}

	public List<DatabasePlayer> GetPreviousPlayers()
	{
		return mPreviousDatabasePlayers;
	}

	public LeagueArcData GetCurrentData()
	{
		return mCurrentData;
	}

	public List<DatabasePlayer> GetCurrentPlayers()
	{
		return mCurrentDatabasePlayers;
	}

	public bool GetWasDataUpdated()
	{
		return mUpdatedData;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		FakePlayersManager.instance.UpdatedPosition += OnFakePlayersUpdate;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.updateCounterBySecond = (Action)Delegate.Combine(counterManager.updateCounterBySecond, new Action(OnEverySecondUpdate));
	}

	private void OnAfterPlayerDataLoaded()
	{
		StartLeagueUpdate();
	}

	private void OnGameStarted()
	{
		StopLeagueUpdate();
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		if (Singleton<GameController>.instance.isRandomMatchMaking)
		{
			mAfterGameEnded = true;
			mUpdatedData = false;
			mCurrentDatabasePlayers = null;
		}
	}

	private void OnFakePlayersUpdate(int position)
	{
		int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		mCurrentData = new LeagueArcData(beginnersLeague, medalsBalance, position);
		mUpdatedData = true;
		if (this.LeagueArcUpdate != null)
		{
			this.LeagueArcUpdate(mCurrentData);
		}
		if (!mAfterGameEnded)
		{
			SaveDataToPrevious();
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.GetPlayerLeaguesDivision:
		{
			List<DatabasePlayer> playersFromLeague = Singleton<ServerResultsCache>.instance.GetPlayersFromLeague(GameLoginManager.currentPlayer.leagueId);
			if (playersFromLeague == null)
			{
				playersFromLeague = Singleton<ServerResultsCache>.instance.GetPlayersFromLeague(GameLoginManager.currentPlayer.leagueId, ommitTime: true);
				if (playersFromLeague == null)
				{
					break;
				}
			}
			DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
			int num = playersFromLeague.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
			if (num < 0)
			{
				playersFromLeague.Add(generatedCurrentPlayer);
			}
			else
			{
				playersFromLeague[num].medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			}
			for (int num2 = playersFromLeague.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(playersFromLeague[num2].name))
				{
					playersFromLeague.RemoveAt(num2);
				}
			}
			playersFromLeague.Sort(SortFunctionPlayers);
			CalculateCurrentData(playersFromLeague);
			if (this.LeagueArcUpdate != null)
			{
				this.LeagueArcUpdate(mCurrentData);
			}
			if (this.SorterPlayersLeague != null)
			{
				this.SorterPlayersLeague(mCurrentData.position, playersFromLeague);
			}
			if (!mAfterGameEnded)
			{
				SaveDataToPrevious(playersFromLeague);
			}
			else if (mCurrentData.isInLeague && !mCurrentData.isLeagueProcessing)
			{
				int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
				if (mPreviousData != null && mPreviousData.numberOfPlayers <= num3 && mCurrentData.numberOfPlayers > num3)
				{
					mPreviousData.hasPromote = mCurrentData.hasPromote;
					mPreviousData.promoteMedals = mCurrentData.promoteMedals;
					mPreviousData.hasDemote = mCurrentData.hasDemote;
					mPreviousData.demoteMedals = mCurrentData.demoteMedals;
				}
				if (mPreviousData != null && mPreviousData.numberOfPlayers < mCurrentData.numberOfPlayers)
				{
					mPreviousData.numberOfPlayers = mCurrentData.numberOfPlayers;
					int num4 = 0;
					for (int num5 = 0; num5 < playersFromLeague.Count; num5++)
					{
						if (playersFromLeague[num5].medalsBalance >= mPreviousData.leagueMedals)
						{
							num4++;
						}
					}
					mPreviousData.position = num4;
				}
			}
			mCurrentDatabasePlayers = playersFromLeague;
			break;
		}
		case DatabaseAction.GameEnded:
			StartLeagueUpdate();
			break;
		}
	}

	private void OnEverySecondUpdate()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && mLeagueEndTime > 0 && currentTimestamp >= mLeagueEndTime)
		{
			Debug.Log("#PETER# LEAGUE ENDED!!!");
			bool flag = Singleton<BeanstalkServerManager>.instance.currentTimestamp < mLeagueEndTime + 3600;
			mLeagueEndTime = Singleton<BeanstalkServerManager>.instance.GetNextLeagueEvaluationTimestamp();
			if (flag)
			{
				Debug.Log("#PETER# LEAGUE ENDED RECENTLY!");
				Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = true;
			}
			if (Singleton<GameController>.instance.gameState != GameController.GameState.Playing)
			{
				Debug.Log("#PETER# TRY FINISH PLAYER LEAGUE IN MENU!!");
				Singleton<BeanstalkServerManager>.instance.FinishPlayerLeague();
			}
		}
	}

	private int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (a.medalsBalance != b.medalsBalance)
		{
			return b.medalsBalance.CompareTo(a.medalsBalance);
		}
		if (a.skill != b.skill)
		{
			return b.skill.CompareTo(a.skill);
		}
		if (a.level != b.level)
		{
			return b.level.CompareTo(a.level);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private void CalculateCurrentData(List<DatabasePlayer> databasePlayers)
	{
		if (!GameLoginManager.currentPlayer.isInLeague)
		{
			mCurrentData = new LeagueArcData();
			mCurrentData.isInLeague = false;
			mUpdatedData = true;
			Debug.Log("#PETER# UPDATING DATA SERVER END - " + mCurrentData.debugMessage);
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			mCurrentData = new LeagueArcData();
			mCurrentData.isLeagueProcessing = true;
			mUpdatedData = true;
			Debug.Log("#PETER# UPDATING DATA SERVER END - " + mCurrentData.debugMessage);
			return;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int savePosition = databasePlayers.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id) + 1;
		int count = databasePlayers.Count;
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		bool flag2 = flag && Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier) > 0f;
		int savePromoteMedals = 0;
		if (flag2)
		{
			int num = Singleton<GameVariables>.instance.LeaguePositionPromote(count, leagueTier);
			savePromoteMedals = databasePlayers[num - 1].medalsBalance;
		}
		bool flag3 = flag && Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier) > 0f;
		int saveDemoteMedals = 0;
		if (flag3)
		{
			int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(count, leagueTier);
			saveDemoteMedals = databasePlayers[num2 - 1].medalsBalance;
		}
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		mCurrentData = new LeagueArcData(leagueTier, savePosition, count, flag2, savePromoteMedals, flag3, saveDemoteMedals, medalsBalance);
		mUpdatedData = true;
		Debug.Log("#PETER# UPDATING DATA SERVER END - " + mCurrentData.debugMessage);
	}

	private void SaveDataToPrevious(List<DatabasePlayer> databasePlayers = null)
	{
		mPreviousData = mCurrentData;
		mPreviousDatabasePlayers = databasePlayers;
	}

	public void UpdateData()
	{
		Debug.Log("#PETER# UPDATING DATA START - " + ((mCurrentData != null) ? mCurrentData.debugMessage : "null"));
		if (!LevelManager.instance.isMainScreenPartsLocked)
		{
			if (GameLoginManager.currentPlayer.isInBeginnersLeague)
			{
				FakePlayersManager.instance.UpdateBeginnersLeaguePosition();
			}
			else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
			{
				mCurrentData = new LeagueArcData();
				mCurrentData.isBeginnersLeague = false;
				mCurrentData.isLeagueProcessing = true;
				mUpdatedData = true;
				if (this.LeagueArcUpdate != null)
				{
					this.LeagueArcUpdate(mCurrentData);
				}
				if (!mAfterGameEnded)
				{
					SaveDataToPrevious();
				}
			}
			else if (GameLoginManager.currentPlayer.isInLeague)
			{
				League leagueTier = GameLoginManager.currentPlayer.leagueTier;
				int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
				if (this.ShowLoading != null)
				{
					this.ShowLoading(leagueTier, medalsBalance);
				}
				Singleton<BeanstalkServerManager>.instance.GetPlayersFromLeague(GameLoginManager.currentPlayer.leagueId);
			}
			else
			{
				mCurrentData = new LeagueArcData();
				mCurrentData.isBeginnersLeague = false;
				mCurrentData.isLeagueProcessing = false;
				mCurrentData.isInLeague = false;
				mUpdatedData = true;
				if (this.LeagueArcUpdate != null)
				{
					this.LeagueArcUpdate(mCurrentData);
				}
				if (!mAfterGameEnded)
				{
					SaveDataToPrevious();
				}
			}
		}
		Debug.Log("#PETER# UPDATING DATA END - " + ((mCurrentData != null) ? mCurrentData.debugMessage : "null"));
	}

	private void StartLeagueUpdate()
	{
		if (mLeagueUpdate == null)
		{
			mLeagueUpdate = RadicalRoutine.Create(UpdateLeagueCoroutine());
			StartCoroutine(RadicalRoutine.Run(mLeagueUpdate.enumerator));
		}
	}

	private void StopLeagueUpdate()
	{
		if (mLeagueUpdate != null)
		{
			mLeagueUpdate.Cancel();
			mLeagueUpdate = null;
		}
	}

	private IEnumerator UpdateLeagueCoroutine()
	{
		while (true)
		{
			yield return null;
			UpdateData();
			yield return new WaitForSeconds(180f);
		}
	}

	public void SetLeagueTimer(int leagueEvaluationTimestamp)
	{
		mLeagueEndTime = ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? leagueEvaluationTimestamp : 0);
	}

	public int GetLeagueTimer()
	{
		return mLeagueEndTime;
	}
}
