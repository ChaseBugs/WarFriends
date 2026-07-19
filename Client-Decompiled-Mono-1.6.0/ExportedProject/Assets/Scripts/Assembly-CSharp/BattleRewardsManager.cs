using System.Collections.Generic;
using UnityEngine;

public class BattleRewardsManager : InGameSerializedObjectGeneric<BattleRewardsManager.SaveData>
{
	public class SaveData
	{
		public List<string> warcardsPlayedInMatch = new List<string>();

		public List<string> warcards = new List<string>();

		public int gold;

		public int wb;
	}

	private static BattleRewardsManager mInstance;

	public static BattleRewardsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((BattleRewardsManager)Object.FindObjectsOfType(typeof(BattleRewardsManager))[0]);
			return mInstance;
		}
	}

	public bool isSomeUnsentRewards
	{
		get
		{
			return data.warcards.Count > 0 || data.gold > 0 || data.wb > 0 || data.warcardsPlayedInMatch.Count > 0;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void ClearAllRewards()
	{
		data.gold = 0;
		data.wb = 0;
		data.warcards = new List<string>();
		data.warcardsPlayedInMatch = new List<string>();
		Save();
	}

	public void AddGold(int amount)
	{
		data.gold += amount;
		Save();
	}

	public void AddWB(int amount)
	{
		data.wb += amount;
		Save();
	}

	public void AddWarcard(string cardId)
	{
		data.warcards.Add(cardId);
		Save();
	}

	public void ConsumeWarcardInMatch(string cardId)
	{
		data.warcardsPlayedInMatch.Add(cardId);
		Save();
	}
}
