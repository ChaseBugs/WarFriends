using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class PlayerAnalytics : DatabaseSerializedObjectGeneric<PlayerAnalytics.PlayerAnalyticsData>
{
	public class PlayerAnalyticsData
	{
		public int warbucksSpent;

		public int goldSpent;

		public bool boughtInApp;

		public int installTimestamp;

		public float realMoneySpent;

		public int numberOfSessions;

		public int moneyPackDeadline;

		public int starterPackDeadline;

		public Dictionary<string, int> elitePackDeadlines = new Dictionary<string, int>();

		public List<Transaction> transactions;

		public Dictionary<string, int> collectedRewards = new Dictionary<string, int>();

		public int totalBattles;

		public bool chatShown;

		public bool elitesShown;

		public bool customizationShown;

		public bool warpathShown;

		public bool cardpoolShown;

		public bool craftingShown;

		public bool leagueLeaderboardsShown;

		public bool anticheatStatus;

		public int goldBonuses;

		public int rateAppShownCounter;

		public string rateAppFirstVersion;

		public string rateAppClientVersion;

		public int rateAppClickYesCounter;

		public int renameCount;

		public int squadCreationsCount;

		public int matchesToNextLootboxes;

		public int lastSeenSquadChatTimeStampDB;

		public int instantBattlesTime;

		public int instantBattles;

		public int paidInstantBattles;

		public bool showDailyOneTimeOffer;

		public int spentMoneyAfterFirstDailyInApp;

		public int cardTutState;

		public int getDailyGoldInAppDays
		{
			get
			{
				if (!showDailyOneTimeOffer || spentMoneyAfterFirstDailyInApp == 0)
				{
					return 7;
				}
				if (spentMoneyAfterFirstDailyInApp < 5)
				{
					return 14;
				}
				if (spentMoneyAfterFirstDailyInApp < 25)
				{
					return 21;
				}
				return 30;
			}
		}

		public bool isMoneyPackAvailable
		{
			get
			{
				return moneyPackDeadline != 0 && Singleton<BeanstalkServerManager>.instance.currentTimestamp <= moneyPackDeadline;
			}
		}

		public bool isStarterPackAvailable
		{
			get
			{
				return starterPackDeadline != 0 && Singleton<BeanstalkServerManager>.instance.currentTimestamp <= starterPackDeadline;
			}
		}

		public bool IsPackAvailable(string packId)
		{
			return PackDeadline(packId) >= Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}

		public bool IsInstantBattlesFull()
		{
			return GetTimestampOfFullInstantBattles() <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}

		public int GetInstantBattlesReady()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
			if (instantBattlesTime == 0)
			{
				return num;
			}
			int num2 = Singleton<BeanstalkServerManager>.instance.currentTimestamp - instantBattlesTime;
			int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleReload).FLOATVALUE;
			int num4 = num3 * 60;
			int value = num2 / num4;
			return Mathf.Clamp(value, 0, num);
		}

		public int GetTimestampOfNextInstantBattle()
		{
			if (instantBattlesTime == 0)
			{
				return 0;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = currentTimestamp - instantBattlesTime;
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleReload).FLOATVALUE;
			int num3 = num2 * 60;
			int num4 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
			int num5 = num3 * num4;
			if (num > num5)
			{
				return 0;
			}
			int num6 = num % num3;
			int num7 = num3 - num6;
			return currentTimestamp + num7;
		}

		public int GetInstantBattleCost()
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleCostMin).FLOATVALUE;
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleCostMax).FLOATVALUE;
			float max = Mathf.Sqrt((float)num2 / (float)num) + 1f;
			float num3 = Mathf.Clamp(paidInstantBattles, 0f, max);
			int num4 = num * (int)Math.Pow(2.0, num3);
			return (num4 <= num2) ? num4 : num2;
		}

		public int GetTimestampOfFullInstantBattles()
		{
			if (instantBattlesTime == 0)
			{
				return 0;
			}
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleReload).FLOATVALUE;
			int num2 = num * 60;
			int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
			int num4 = num2 * num3;
			return instantBattlesTime + num4;
		}

		public int PackDeadline(string packId)
		{
			return elitePackDeadlines.ContainsKey(packId) ? elitePackDeadlines[packId] : 0;
		}

		public void SetPackDeadline(string packId, int packDeadline)
		{
			if (elitePackDeadlines.ContainsKey(packId))
			{
				elitePackDeadlines[packId] = packDeadline;
			}
			else
			{
				elitePackDeadlines.Add(packId, packDeadline);
			}
		}

		public bool IsPackBought(NGNPIOOAHEH pack)
		{
			return instance.IsPackBought(Singleton<GameVariables>.instance.PackId(pack));
		}

		public int GetInappCount()
		{
			if (transactions == null)
			{
				return 0;
			}
			int num = 0;
			foreach (Transaction transaction in transactions)
			{
				if (transaction.id == 142)
				{
					num++;
				}
			}
			return num;
		}

		public int GetDaysSinceInstall()
		{
			int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp - installTimestamp;
			return num / 86400;
		}

		public int TotalTransactions()
		{
			if (transactions == null)
			{
				return 0;
			}
			return transactions.Count;
		}

		public int GetPlayerLevel()
		{
			return LevelManager.instance.currentLevel.displayNumber;
		}

		public int HasFacebook()
		{
			long facebookId = GameLoginManager.instance.facebookId;
			return (facebookId != 0 && facebookId != -1) ? 1 : 0;
		}

		public string GetCohort()
		{
			if ((double)realMoneySpent <= 0.001)
			{
				return "$0";
			}
			if ((double)realMoneySpent <= 5.001)
			{
				return "$0-$5";
			}
			if ((double)realMoneySpent <= 10.001)
			{
				return "$5-$10";
			}
			if ((double)realMoneySpent <= 20.001)
			{
				return "$10-$20";
			}
			if ((double)realMoneySpent <= 50.001)
			{
				return "$20-$50";
			}
			if ((double)realMoneySpent <= 100.001)
			{
				return "$50-$100";
			}
			if ((double)realMoneySpent <= 200.001)
			{
				return "$100-$200";
			}
			if ((double)realMoneySpent <= 500.001)
			{
				return "$200-$500";
			}
			return ">$500";
		}

		public int MadeInApp()
		{
			if (realMoneySpent > 0f)
			{
				return 1;
			}
			return 0;
		}
	}

	public class Transaction
	{
		public int id;

		public string p;

		public int gold;

		public int wb;

		public float money;
	}

	private static PlayerAnalytics mInstance;

	public int globalPositon;

	public bool tutorialFinished;

	public static PlayerAnalytics instance
	{
		get
		{
			mInstance = mInstance ?? ((PlayerAnalytics)UnityEngine.Object.FindObjectsOfType(typeof(PlayerAnalytics))[0]);
			return mInstance;
		}
	}

	public int lastSeenSquadChatTimeStamp
	{
		get
		{
			return (data != null) ? data.lastSeenSquadChatTimeStampDB : 0;
		}
		set
		{
			if (data.lastSeenSquadChatTimeStampDB < value)
			{
				data.lastSeenSquadChatTimeStampDB = value;
				RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
				requestBuffer.AddRequest(DatabaseAction.SaveLastSeenSquadChatTimeStamp, value.ToString(), 0, 0, string.Empty);
			}
		}
	}

	public bool showMoneyPack
	{
		get
		{
			return data != null && data.isMoneyPackAvailable && !data.IsPackBought(NGNPIOOAHEH.Money);
		}
	}

	public bool showStarterPack
	{
		get
		{
			return data != null && data.isStarterPackAvailable && !data.IsPackBought(NGNPIOOAHEH.Starter);
		}
	}

	public int renameGoldPrice
	{
		get
		{
			if (data == null || data.renameCount == 0)
			{
				return 0;
			}
			int num = 1 << Mathf.Clamp(data.renameCount - 1, 0, 31);
			return num * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SecondRenameGoldCost).FLOATVALUE;
		}
	}

	public int createSquadWarBucksPrice
	{
		get
		{
			if (data == null)
			{
				return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarBucksCreateSquadPrice).FLOATVALUE;
			}
			return (data.squadCreationsCount + 1) * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarBucksCreateSquadPrice).FLOATVALUE;
		}
	}

	public int remainingMatchesToNextLootbox
	{
		get
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
			return Mathf.Clamp(data.matchesToNextLootboxes, 1, num + 1);
		}
	}

	public bool IsAllowedGoldBonus
	{
		get
		{
			if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
			{
				return false;
			}
			if (LevelManager.instance.currentLevel.displayNumber <= 5)
			{
				return true;
			}
			return data.goldBonuses < 3;
		}
	}

	public bool IsAllowedMoneyBonus
	{
		get
		{
			if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
			{
				return false;
			}
			return true;
		}
	}

	public event Action<string> AddedOneTimeReward;

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	public void AddTransaction(int trId, string trParameter, int trGold, int trWarbucks, float trRealMoney)
	{
		if (data.transactions == null)
		{
			data.transactions = new List<Transaction>();
		}
		data.transactions.Add(new Transaction
		{
			id = trId,
			gold = trGold,
			wb = trWarbucks,
			money = trRealMoney,
			p = trParameter
		});
		data.warbucksSpent += trWarbucks;
		data.goldSpent += trGold;
		data.realMoneySpent += trRealMoney;
	}

	private void OutputAnalytics()
	{
		Debug.Log("PA: After player data loaded");
		Debug.Log("PA: install timestamp " + data.installTimestamp);
		Debug.Log("PA: warbucks spent " + data.warbucksSpent);
		Debug.Log("PA: gold spent " + data.goldSpent);
		Debug.Log("PA: number of sessions" + data.numberOfSessions);
		if (data.transactions != null)
		{
			Debug.Log("PA: transactions count = " + data.transactions.Count);
			{
				foreach (Transaction transaction in data.transactions)
				{
					Debug.Log("PA:Transaction id = " + transaction.id + ", p = " + transaction.p);
				}
				return;
			}
		}
		Debug.Log("PA: transactions NULL");
	}

	private void OnPlayerDataLoaded()
	{
	}

	public LevelBehaviour GetLastBoughtUnit(out bool wasAlreadyUsed)
	{
		wasAlreadyUsed = true;
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		LevelBehaviour levelBehaviour = behaviours[0];
		foreach (LevelBehaviour item in behaviours)
		{
			if (item.upgradeSlots.bought && levelBehaviour.upgradeSlots.unlockLevelIndex < item.upgradeSlots.unlockLevelIndex)
			{
				levelBehaviour = item;
			}
		}
		if (!SavingLastSelected.instance.data.usedInGame.ContainsKey(levelBehaviour.upgradeSlots.GetSheetName()))
		{
			wasAlreadyUsed = false;
		}
		return levelBehaviour;
	}

	public void UseLastBoughtUnit()
	{
		bool wasAlreadyUsed;
		LevelBehaviour lastBoughtUnit = GetLastBoughtUnit(out wasAlreadyUsed);
		if (!wasAlreadyUsed)
		{
			SavingLastSelected.instance.data.usedInGame[lastBoughtUnit.upgradeSlots.GetSheetName()] = true;
			SavingLastSelected.instance.Save();
		}
	}

	public void AddOneTimeReward(string rewardId)
	{
		data.collectedRewards[rewardId] = 1;
		if (this.AddedOneTimeReward != null)
		{
			this.AddedOneTimeReward(rewardId);
		}
	}

	public bool WasOneTimeRewardAdded(Constants.rowIds id)
	{
		return data.collectedRewards.ContainsKey(Singleton<GameVariables>.instance.constants.GetRow(id).DBKEY);
	}

	public bool WasOneTimeRewardAdded(string id)
	{
		return data.collectedRewards.ContainsKey(id);
	}

	public bool TryGetOneTimeReward(Constants.rowIds id, out int value)
	{
		return data.collectedRewards.TryGetValue(Singleton<GameVariables>.instance.constants.GetRow(id).DBKEY, out value);
	}

	public bool ShowPack(string packId)
	{
		return data != null && data.IsPackAvailable(packId) && !IsPackBought(packId);
	}

	public string GetAbTestPackId(string packId)
	{
		if (packId.EndsWith("B"))
		{
			return packId.Substring(0, packId.Length - 1);
		}
		return packId + "B";
	}

	public bool IsPackBought(string packId)
	{
		if (data == null || data.transactions == null)
		{
			return false;
		}
		string abTestPackId = GetAbTestPackId(packId);
		foreach (Transaction transaction in data.transactions)
		{
			if (transaction.id == 130 && (transaction.p == packId || transaction.p == abTestPackId))
			{
				return true;
			}
		}
		return false;
	}

	internal Dictionary<string, object> GetUpdates()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("rateAppShownCounter", data.rateAppShownCounter);
		dictionary.Add("rateAppFirstVersion", data.rateAppFirstVersion);
		dictionary.Add("rateAppClientVersion", data.rateAppClientVersion);
		dictionary.Add("rateAppClickYesCounter", data.rateAppClickYesCounter);
		return dictionary;
	}
}
