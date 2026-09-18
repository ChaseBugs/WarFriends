using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArena : DatabaseSerializedObjectGeneric<WarArena.WarArenaData>
{
	[Serializable]
	public class WarArenaData
	{
		public ObscuredInt wins;

		public ObscuredInt lives = 3;

		public List<string> opponents = new List<string>();

		public string arenaId;

		public int runs;

		public string visualType;

		public int visualTimestamp;

		public int flawless;

		public int topRun;

		public int shields;

		public bool played;

		public bool heartDialogShown;
	}

	private static WarArena mInstance;

	public List<WarArenaRule> allRulles = new List<WarArenaRule>();

	public TextAsset config;

	public WarArenaConfig warArenaConfig;

	public WararenaLootboxReward lastLootboxReward;

	private WarArenaParameters mWarArenaParameters;

	private List<WarArenaRule> mCurrenArenaRules = new List<WarArenaRule>();

	private ArenaLootboxes mArenaLootboxes;

	private bool mIsDownloadingNewArena;

	private bool mWasOpened = true;

	public static WarArena instance
	{
		get
		{
			mInstance = mInstance ?? ((WarArena)UnityEngine.Object.FindObjectsOfType(typeof(WarArena))[0]);
			return mInstance;
		}
	}

	public WarArenaParameters warArenaParameters => mWarArenaParameters;

	public ArenaLootboxes arenaLootboxes => mArenaLootboxes ?? (mArenaLootboxes = GetComponent<ArenaLootboxes>());

	public WarArenaParameters wararenaParameters => mWarArenaParameters ?? (mWarArenaParameters = GetComponent<WarArenaParameters>());

	public bool isArenaTicketBought => warArenaConfig.id == data.arenaId && (int)data.lives > 0 && (int)data.wins < warArenaConfig.battles && isOpened;

	public bool isGoodPing => RoomConnectionWarArena.hasGoodPing;

	public bool isOpened
	{
		get
		{
			if (warArenaConfig == null)
			{
				return false;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			bool flag = warArenaConfig != null && data != null && warArenaConfig.start <= currentTimestamp && !isExpired;
			bool flag2 = mWasOpened;
			mWasOpened = flag;
			if (!flag2 && flag)
			{
				ArenaOpened();
			}
			return flag;
		}
	}

	public bool isExpired
	{
		get
		{
			if (warArenaConfig == null)
			{
				return true;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			bool flag = currentTimestamp > warArenaConfig.end;
			return warArenaConfig != null && data != null && flag;
		}
	}

	public bool isReminderTime
	{
		get
		{
			if (warArenaConfig == null)
			{
				return false;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = (int)(float)wararenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			int num2 = num * 3600;
			int num3 = warArenaConfig.start - num2;
			return num3 <= currentTimestamp && currentTimestamp <= warArenaConfig.start;
		}
	}

	public int remainigTimeTillStart => Mathf.Max(0, warArenaConfig.start - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public int remainigTimeTillEnd => Mathf.Max(0, warArenaConfig.end - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public bool goldShieldsActive => data.shields > Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public int phaseNumber => warArenaConfig.phaseNumber;

	public int wararenaTicketPrize
	{
		get
		{
			if (!data.played)
			{
				return 0;
			}
			if (data.arenaId != warArenaConfig.id)
			{
				data.runs = 0;
			}
			return warArenaConfig.WarArenaTicketPrice(data.runs);
		}
	}

	public int extraLiveCost
	{
		get
		{
			if (warArenaConfig.nodes.Count == 0)
			{
				return 0;
			}
			int index = Mathf.Clamp(data.wins, 0, warArenaConfig.nodes.Count);
			WarArenaConfig.Node node = warArenaConfig.nodes[index];
			return node.reviveCost;
		}
	}

	public List<WarArenaRule> currenArenaRules => mCurrenArenaRules;

	public event Action WarArenaDataChanged;

	public event Action<int> LivesChanged;

	public event Action WarArenaExpired;

	public event Action WarArenaStarter;

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		mWarArenaParameters = GetComponent<WarArenaParameters>();
	}

	public void LoadWarArenaConfig(JToken dict)
	{
		warArenaConfig = new WarArenaConfig(dict);
		string rules = warArenaConfig.rules;
		mCurrenArenaRules = DeserializeRules(rules);
		PushNotificationManager.instance.ScheduleWarArenaReminder(warArenaConfig.start);
		bool isArenaStart = true;
		int phaseStartTime = TimeOfStartArenaOrPhase(out isArenaStart);
		PushNotificationManager.instance.ScheduleWarArenaStart(phaseStartTime, isArenaStart);
		mIsDownloadingNewArena = false;
		if (this.WarArenaDataChanged != null)
		{
			this.WarArenaDataChanged();
		}
	}

	protected override void Load(JToken dictionary)
	{
		base.Load(dictionary);
		Debug.Log($"dialog shonw = {data.heartDialogShown}, lives = {data.lives}");
		if (isOpened && !data.heartDialogShown && (int)data.lives == 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new BuyHearthArenaMessage(instance.warArenaConfig.id));
		}
	}

	public void TryGetNewArena()
	{
		if (Singleton<BeanstalkServerManager>.instance.shouldGetMessages && isExpired && !mIsDownloadingNewArena)
		{
			DownloadNewArenaData();
			mIsDownloadingNewArena = true;
			if (this.WarArenaExpired != null)
			{
				this.WarArenaExpired();
			}
		}
	}

	private void DownloadNewArenaData()
	{
		WarArenaEndedRequest.Send();
	}

	private void OnGameEnded(GameController.GameEndReason gameEndReason)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			data.opponents.Add(Singleton<GameController>.instance.opponent.playerProperties.playerID);
		}
	}

	public void FailedDownloadWarArena()
	{
		mIsDownloadingNewArena = false;
	}

	public void TakePlayerLive()
	{
		UpdateLives(Mathf.Clamp((int)data.lives - 1, 0, int.MaxValue));
		Singleton<BeanstalkServerManager>.instance.TakeArenaLife();
	}

	public void UpdateLives(int lives)
	{
		int num = lives - (int)data.lives;
		data.lives = lives;
		if (this.LivesChanged != null && num != 0)
		{
			this.LivesChanged(num);
		}
	}

	private int TimeOfStartArenaOrPhase(out bool isArenaStart)
	{
		isArenaStart = true;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int start = warArenaConfig.start;
		int end = warArenaConfig.end;
		if (end < currentTimestamp)
		{
			return start;
		}
		if (start < currentTimestamp)
		{
			WarArenaConfig.PlayWindow nextWindow = warArenaConfig.nextWindow;
			isArenaStart = nextWindow == null;
			return (!isArenaStart) ? nextWindow.startTimestamp : start;
		}
		return start;
	}

	private void ArenaOpened()
	{
		WarArenaShownRequest.Send();
		data.topRun = 0;
		data.flawless = 0;
		if (this.WarArenaStarter != null)
		{
			this.WarArenaStarter();
		}
	}

	public bool SetupRules()
	{
		Singleton<GameController>.instance.gameControllerWarArena.ResetRules();
		bool flag = true;
		foreach (WarArenaRule mCurrenArenaRule in mCurrenArenaRules)
		{
			bool flag2 = mCurrenArenaRule.SetupRule();
			Debug.Log($"Mode with name {mCurrenArenaRule.GetType()} met criteria {flag2} ");
			flag = flag && flag2;
		}
		return flag;
	}

	public void ApplyRules()
	{
		if (!Singleton<GameController>.instance.isWarArena)
		{
			return;
		}
		foreach (WarArenaRule mCurrenArenaRule in mCurrenArenaRules)
		{
			mCurrenArenaRule.ApplyRule();
		}
	}

	private WarArenaRule GetRule(string ruleName)
	{
		foreach (WarArenaRule allRulle in allRulles)
		{
			if (allRulle.GetType().ToString() == ruleName)
			{
				return allRulle;
			}
		}
		return null;
	}

	public List<WarArenaRule> DeserializeRules(string rulesJson)
	{
		List<WarArenaRule> list = new List<WarArenaRule>();
		Dictionary<string, JToken> dictionary = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(rulesJson);
		foreach (KeyValuePair<string, JToken> item in dictionary)
		{
			WarArenaRule rule = GetRule(item.Key);
			rule.DeSerialize(item.Value);
			list.Add(rule);
		}
		return list;
	}
}
