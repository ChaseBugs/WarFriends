using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

[Serializable]
public class WarArenaConfig
{
	public enum NLEFGCLBJMN
	{
		None,
		Bronze,
		Silver,
		Gold
	}

	public enum MHODPJBCFAP
	{
		None,
		Bronze,
		Silver,
		Gold
	}

	[Serializable]
	public class Node
	{
		public int reviveCost;

		public NLEFGCLBJMN lootBoxType;

		public MHODPJBCFAP visualType;

		public AGGODCMFNHJ visualReward;

		public WarArenaLootboxConfig.WarArenaLootbox lootboxConfig;
	}

	[Serializable]
	public class PlayWindow
	{
		public int start;

		public int end;

		public int arenaStartTime;

		public int windowIndex;

		public int startTimestamp => 0;

		public int endTimestamp => 0;

		public bool isActive => false;

		public int remainingTimeTillWindowEnd => 0;

		public int remainingTimeTillWindowStart => 0;
	}

	public Dictionary<LevelBehaviour, int> unitDropRates;

	public List<AGGODCMFNHJ> warArenaRewards;

	public Dictionary<string, Tuple<string, string>> rulesTexts;

	public int battles;

	public List<Node> nodes;

	public int lootBoxesCount;

	public List<PlayWindow> playWindows;

	public int start;

	public int end;

	public string rules;

	public int lifeCount;

	public string arenaName;

	public string arenaDescription;

	private List<int> mPrices;

	private bool mExtraLifeEnabled;

	private int mGuaranteedScraps;

	private int mPauseDuration;

	private int mPlayWindowCount;

	private int mWindowDuration;

	private WarArenaLootboxConfig mLootboxesSetups;

	public string id;

	public PlayWindow currentWindow => null;

	public PlayWindow nextWindow => null;

	public int phaseNumber => 0;

	public bool isBeforeArenaStart => false;

	public int remainingTimeTillStart => 0;

	public bool isAfterArenaEnd => false;

	public LevelBehaviour doubleDropUnit => null;

	private int currentWindowIndex => 0;

	public WarArenaConfig(JToken JFNEGCPHIFI)
	{
	}

	private void EFFPPCLJIAO(JToken JFNEGCPHIFI)
	{
	}

	public int BLAMEOOAEND(int MLIACEKECHD)
	{
		return 0;
	}

	public int JBJLPICALBI(MHODPJBCFAP NEJOPKJFFMI)
	{
		return 0;
	}
}
