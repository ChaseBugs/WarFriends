using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaConfig
{
	public enum LootBoxType
	{
		None,
		Bronze,
		Silver,
		Gold
	}

	public enum VisualType
	{
		None,
		Bronze,
		Silver,
		Gold
	}

	public class Node
	{
		public int reviveCost;

		public LootBoxType lootBoxType;

		public VisualType visualType;

		public WarArenaReward visualReward;

		private static Dictionary<LootBoxType, ArenaLootboxes.rowIds> mRowIndex = new Dictionary<LootBoxType, ArenaLootboxes.rowIds>
		{
			{
				LootBoxType.Bronze,
				ArenaLootboxes.rowIds.bronze
			},
			{
				LootBoxType.Silver,
				ArenaLootboxes.rowIds.silver
			},
			{
				LootBoxType.Gold,
				ArenaLootboxes.rowIds.gold
			}
		};

		public ArenaLootboxesRow lootboxRow => (lootBoxType != LootBoxType.None) ? WarArena.instance.arenaLootboxes.GetRow(mRowIndex[lootBoxType]) : null;

		public int minWarbucks
		{
			get
			{
				ArenaLootboxesRow arenaLootboxesRow = lootboxRow;
				int displayNumber = LevelManager.instance.currentLevel.displayNumber;
				float num = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1.033f, displayNumber - 3);
				return Mathf.FloorToInt(0.9f * num / 100f) * 100;
			}
		}

		public int maxWarbucks
		{
			get
			{
				ArenaLootboxesRow arenaLootboxesRow = lootboxRow;
				int displayNumber = LevelManager.instance.currentLevel.displayNumber;
				float num = (float)arenaLootboxesRow.WARBUCKS * Mathf.Pow(1.033f, displayNumber - 3);
				return Mathf.FloorToInt(1.1f * num / 100f) * 100;
			}
		}
	}

	public class PlayWindow
	{
		public int start;

		public int end;

		public int arenaStartTime;

		public int windowIndex;

		public int startTimestamp => start + arenaStartTime;

		public int endTimestamp => end + arenaStartTime;

		public bool isActive
		{
			get
			{
				int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				return startTimestamp <= currentTimestamp && currentTimestamp <= endTimestamp;
			}
		}

		public int remainingTimeTillWindowEnd => Mathf.Max(0, endTimestamp - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

		public int remainingTimeTillWindowStart => Mathf.Max(0, startTimestamp - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	public Dictionary<LevelBehaviour, int> unitDropRates = new Dictionary<LevelBehaviour, int>();

	public List<WarArenaReward> warArenaRewards = new List<WarArenaReward>();

	public Dictionary<string, Tuple<string, string>> rulesTexts = new Dictionary<string, Tuple<string, string>>();

	public int battles;

	public List<Node> nodes = new List<Node>();

	public int lootBoxesCount;

	public List<PlayWindow> playWindows = new List<PlayWindow>();

	public int start;

	public int end;

	public string rules;

	public int lifeCount;

	public string arenaName;

	public string arenaDescription;

	private List<int> mPrices = new List<int>();

	private bool mExtraLifeEnabled;

	private int mGuaranteedScraps;

	private int mPauseDuration;

	private int mPlayWindowCount;

	private int mWindowDuration;

	public string id;

	public PlayWindow currentWindow
	{
		get
		{
			int num = currentWindowIndex;
			return (num >= 0) ? playWindows[num] : null;
		}
	}

	public PlayWindow nextWindow
	{
		get
		{
			int num = currentWindowIndex;
			if (num < 0)
			{
				return null;
			}
			int num2 = playWindows.Count - 1;
			return (num != num2) ? playWindows[num + 1] : null;
		}
	}

	public int phaseNumber
	{
		get
		{
			if (currentWindow == null)
			{
				return 0;
			}
			int num = currentWindowIndex;
			if (currentWindow.isActive)
			{
				return num + 1;
			}
			if (nextWindow == null)
			{
				return num + 1;
			}
			return num + 2;
		}
	}

	public bool isBeforeArenaStart => Singleton<BeanstalkServerManager>.instance.currentTimestamp < start;

	public int remainingTimeTillStart => Mathf.Max(0, start - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public bool isAfterArenaEnd => Singleton<BeanstalkServerManager>.instance.currentTimestamp > end;

	public LevelBehaviour doubleDropUnit
	{
		get
		{
			foreach (WarArenaReward warArenaReward in warArenaRewards)
			{
				if (warArenaReward is WarArenaRewardUnit { doubleDrop: not false } warArenaRewardUnit)
				{
					return warArenaRewardUnit.behaviour;
				}
			}
			return null;
		}
	}

	private int currentWindowIndex
	{
		get
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (currentTimestamp < start || end < currentTimestamp)
			{
				return -1;
			}
			if (playWindows == null || playWindows.Count == 0)
			{
				return -1;
			}
			for (int i = 0; i < playWindows.Count; i++)
			{
				int startTimestamp = playWindows[i].startTimestamp;
				int endTimestamp = playWindows[i].endTimestamp;
				if (endTimestamp >= currentTimestamp)
				{
					if (currentTimestamp < startTimestamp)
					{
						return (i <= 0) ? (-1) : (i - 1);
					}
					return i;
				}
			}
			return -1;
		}
	}

	public WarArenaConfig(JToken dict)
	{
		lootBoxesCount = 0;
		warArenaRewards = new List<WarArenaReward>();
		rulesTexts = new Dictionary<string, Tuple<string, string>>();
		if (dict["Translation"] != null)
		{
			ParseArenaLocalization(dict["Translation"]);
		}
		if (dict["Id"] != null)
		{
			id = StringParser.ParseString("Id", "S", dict, string.Empty);
		}
		if (dict["Rules"] != null)
		{
			rules = StringParser.ParseString("Rules", "S", dict, string.Empty);
		}
		if (dict["ExtraLifeEnabled"] != null)
		{
			mExtraLifeEnabled = true;
		}
		if (dict["LifeCount"] != null)
		{
			lifeCount = StringParser.ParseIntToken(dict["LifeCount"]["N"]);
		}
		if (dict["PauseDuration"] != null)
		{
			mPauseDuration = StringParser.ParseIntToken(dict["PauseDuration"]["N"]);
		}
		if (dict["PlayWindowCount"] != null)
		{
			mPlayWindowCount = StringParser.ParseIntToken(dict["PlayWindowCount"]["N"]);
			if (mPlayWindowCount > 12)
			{
				Debug.LogErrorFormat("There are {0} play windows. Max is 12. Setting 12 play windows.", mPlayWindowCount);
				mPlayWindowCount = 12;
			}
		}
		if (dict["MaxBattles"] != null)
		{
			battles = StringParser.ParseIntToken(dict["MaxBattles"]["N"]);
			Mathf.Clamp(battles, 1, 12);
		}
		if (dict["GuaranteedScraps"] != null)
		{
			mGuaranteedScraps = StringParser.ParseIntToken(dict["GuaranteedScraps"]["N"]);
		}
		if (dict["StartTime"] != null)
		{
			start = StringParser.ParseIntToken(dict["StartTime"]["N"]);
		}
		if (dict["WindowDuration"] != null)
		{
			mWindowDuration = StringParser.ParseIntToken(dict["WindowDuration"]["N"]);
		}
		if (dict["ArenaPrice"] != null)
		{
			string text = StringParser.ParseString("ArenaPrice", "S", dict, string.Empty);
			string[] array = text.Split(',');
			foreach (string value in array)
			{
				mPrices.Add(Convert.ToInt32(value));
			}
		}
		for (int j = 1; j < 4; j++)
		{
			if (dict["Unit" + j] != null)
			{
				string sheetName = StringParser.ParseString("Unit" + j, "S", dict, string.Empty);
				LevelBehaviour levelBehaviour = LevelManager.instance.Unit(sheetName);
				int num = StringParser.ParseIntToken(dict["Unit" + j + "DropRate"]["N"]);
				unitDropRates[levelBehaviour] = num;
				warArenaRewards.Add(new WarArenaRewardUnit
				{
					behaviour = levelBehaviour,
					dropAmount = num
				});
			}
		}
		bool flag = false;
		for (int k = 1; k <= battles; k++)
		{
			Node node = new Node();
			if (dict["HeartPrice" + k] != null)
			{
				node.reviveCost = StringParser.ParseInt("HeartPrice" + k, "N", dict);
			}
			if (dict["LootboxType" + k] != null)
			{
				flag = true;
				switch (StringParser.ParseString("LootboxType" + k, "S", dict, string.Empty))
				{
				case "bronze":
					node.lootBoxType = LootBoxType.Bronze;
					lootBoxesCount++;
					break;
				case "silver":
					node.lootBoxType = LootBoxType.Silver;
					lootBoxesCount++;
					break;
				case "gold":
					node.lootBoxType = LootBoxType.Gold;
					lootBoxesCount++;
					break;
				}
			}
			if (dict["VisualType" + k] != null)
			{
				switch (StringParser.ParseString("VisualType" + k, "S", dict, string.Empty))
				{
				case "bronze":
					node.visualType = VisualType.Bronze;
					node.visualReward = new WarArenaRewardCrown
					{
						crown = CamosManager.instance.GetVisual("HELMETS_CROWNBRONZE"),
						type = VisualType.Bronze
					};
					warArenaRewards.Add(node.visualReward);
					break;
				case "silver":
					node.visualType = VisualType.Silver;
					node.visualReward = new WarArenaRewardCrown
					{
						crown = CamosManager.instance.GetVisual("HELMETS_CROWNSILVER"),
						type = VisualType.Silver
					};
					warArenaRewards.Add(node.visualReward);
					break;
				case "gold":
					node.visualType = VisualType.Gold;
					node.visualReward = new WarArenaRewardCrown
					{
						crown = CamosManager.instance.GetVisual("HELMETS_CROWNGOLD"),
						type = VisualType.Gold
					};
					warArenaRewards.Add(node.visualReward);
					break;
				}
			}
			nodes.Add(node);
		}
		if (flag)
		{
			warArenaRewards.Add(new WarArenaRewardTickets());
			warArenaRewards.Add(new WarArenaRewardScraps());
			warArenaRewards.Add(new WarArenaRewardGold());
			warArenaRewards.Add(new WarArenaRewardWarbucks());
		}
		warArenaRewards.Sort((WarArenaReward reward1, WarArenaReward reward2) => reward1.order.CompareTo(reward2.order));
		playWindows = new List<PlayWindow>();
		for (int num2 = 0; num2 < mPlayWindowCount; num2++)
		{
			PlayWindow playWindow = new PlayWindow();
			playWindow.arenaStartTime = start;
			playWindow.windowIndex = num2;
			playWindow.start = num2 * (mWindowDuration * 60 + mPauseDuration * 60);
			playWindow.end = playWindow.start + mWindowDuration * 60;
			playWindows.Add(playWindow);
		}
		end = ((playWindows.Count != 0) ? playWindows[playWindows.Count - 1].endTimestamp : start);
	}

	private void ParseArenaLocalization(JToken dict)
	{
		JObject jObject = JObject.Parse(dict.ToString());
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			string text = item.Value.ToString();
			if (item.Key.Equals("Name"))
			{
				arenaName = text;
				continue;
			}
			if (item.Key.Equals("Description"))
			{
				arenaDescription = text;
				continue;
			}
			string[] array = text.Split('|');
			if (array.Length > 1)
			{
				rulesTexts[item.Key] = new Tuple<string, string>(array[0], array[1]);
				Debug.Log(" Desc = " + array[0] + " | Hint " + array[1]);
			}
			else
			{
				rulesTexts[item.Key] = new Tuple<string, string>(text, string.Empty);
				Debug.Log(" Desc without HINT = " + text);
			}
		}
	}

	public int WarArenaTicketPrice(int run)
	{
		int index = Mathf.Clamp(run, 0, mPrices.Count - 1);
		return (mPrices.Count != 0) ? mPrices[index] : 0;
	}

	public int GetVisualRequirements(VisualType visualType)
	{
		if (visualType != VisualType.None)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				Node node = nodes[i];
				if (node.visualType == visualType)
				{
					return i + 1;
				}
			}
		}
		return 0;
	}
}
