using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabaseGameReward
{
	private bool mIsVip;

	private int mXpBattleRewards;

	private int mXpExtraRewards;

	private int mXpWinstreak;

	private int mXpTime;

	private int mWbBattleRewards;

	private int mWbExtraRewards;

	private int mWbWinstreak;

	private int mWbLeague;

	private int mGoldBattleRewards;

	private int mGoldExtraRewards;

	private int mGoldWinstreak;

	private int mGoldLeague;

	public int mRemainingFightsToAssign;

	public int mOldMedals;

	public int mNewMedals;

	public int mOldBalanceMedals;

	public int mNewBalanceMedals;

	private int mSquadPoints;

	private List<LootboxContent> mLootboxes;

	public string debugGameRewards
	{
		get
		{
			string text = "Game Results Debug Log:\n";
			text += $"Warbucks - League:{mWbLeague} Battle:{mWbBattleRewards} Extra:{mWbExtraRewards} Winstreak:{mWbWinstreak}\n";
			text += $"Gold - League:{mGoldLeague} Battle:{mGoldBattleRewards} Extra:{mGoldExtraRewards} Winstreak:{mGoldWinstreak}\n";
			text += $"XP - Battle:{mXpBattleRewards} Extra:{mXpExtraRewards} Winstreak:{mXpWinstreak} Time:{mXpTime}\n";
			text += $"VIP - {mIsVip}\n";
			text += $"Medals - old:{mOldMedals} new:{mNewMedals} Balance old:{mOldBalanceMedals} Balance new:{mNewBalanceMedals} Remaining fights:{mRemainingFightsToAssign}\n";
			text += $"Squad Points - {mSquadPoints}\n";
			return text + debugLootboxes;
		}
	}

	public string debugLootboxes
	{
		get
		{
			if (mLootboxes == null || mLootboxes.Count == 0)
			{
				return "Game Rewards no lootboxes\n";
			}
			string text = "Game Rewards lootboxes contents:\n";
			foreach (LootboxContent mLootbox in mLootboxes)
			{
				text = text + mLootbox.debugString + "\n";
			}
			return text;
		}
	}

	public int warbucksLeague => mWbLeague;

	public int warbucksLeagueVip => (int)((float)mWbLeague * Singleton<VipManager>.instance.vipWarbucksMultiplier);

	public int warbucksBattle => mWbBattleRewards + mWbExtraRewards;

	public int warbucksBattleVip => (int)((float)(mWbBattleRewards + mWbExtraRewards) * Singleton<VipManager>.instance.vipWarbucksMultiplier);

	public int warbucksWinstreak => mWbWinstreak;

	public int warbucksWinstreakVip => (int)((float)mWbWinstreak * Singleton<VipManager>.instance.vipWarbucksMultiplier);

	public int warbucksTotal => warbucksLeague + warbucksBattle + warbucksWinstreak;

	public int warbucksTotalVip => warbucksLeagueVip + warbucksBattleVip + warbucksWinstreakVip;

	public int goldLeague => mGoldLeague;

	public int goldLeagueVip => (int)((float)mGoldLeague * Singleton<VipManager>.instance.vipGoldMultiplier);

	public int goldBattle => mGoldBattleRewards + mGoldExtraRewards;

	public int goldBattleVip => (int)((float)(mGoldBattleRewards + mGoldExtraRewards) * Singleton<VipManager>.instance.vipGoldMultiplier);

	public int goldWinstreak => mGoldWinstreak;

	public int goldWinstreakVip => (int)((float)mGoldWinstreak * Singleton<VipManager>.instance.vipGoldMultiplier);

	public int goldTotal => goldLeague + goldBattle + goldWinstreak;

	public int goldTotalVip => goldLeagueVip + goldBattleVip + goldWinstreakVip;

	public bool isInLeague => mRemainingFightsToAssign == 0;

	public int medalsAllOld => mOldMedals;

	public int medalsAllNew => mNewMedals;

	public int medalsWeeklyOld => mOldBalanceMedals;

	public int medalsWeeklyNew => mNewBalanceMedals;

	public int squadPoints => mSquadPoints;

	public int remainingMatches => mRemainingFightsToAssign;

	public bool anyLeagueRewards => mWbLeague > 0 || mGoldLeague > 0;

	public List<LootboxContent> lootboxesReward => mLootboxes;

	public DatabaseGameReward(int gameXp, int gameWb, int gameGold)
	{
		mIsVip = false;
		mXpBattleRewards = gameXp;
		mXpExtraRewards = 0;
		mXpWinstreak = 0;
		mXpTime = 0;
		mWbBattleRewards = gameWb;
		mWbExtraRewards = 0;
		mWbWinstreak = 0;
		mWbLeague = 0;
		mGoldBattleRewards = gameGold;
		mGoldExtraRewards = 0;
		mGoldWinstreak = 0;
		mGoldLeague = 0;
		if (mLootboxes == null)
		{
			mLootboxes = new List<LootboxContent>();
		}
		else
		{
			mLootboxes.Clear();
		}
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			mXpWinstreak += 5000;
		}
	}

	public DatabaseGameReward(JToken token)
	{
		if (token["Warbucks"] != null)
		{
			mWbBattleRewards = token["Warbucks"]["BattleRewards"].ToObject<int>();
			mWbExtraRewards = token["Warbucks"]["ExtraRewards"].ToObject<int>();
			mWbWinstreak = token["Warbucks"]["Winstreak"].ToObject<int>();
			mWbLeague = token["Warbucks"]["League"].ToObject<int>();
		}
		if (token["Xp"] != null)
		{
			mXpBattleRewards = token["Xp"]["BattleRewards"].ToObject<int>();
			mXpExtraRewards = token["Xp"]["ExtraRewards"].ToObject<int>();
			mXpWinstreak = token["Xp"]["Winstreak"].ToObject<int>();
			mXpTime = token["Xp"]["Time"].ToObject<int>();
		}
		if (token["GameGold"] != null)
		{
			mGoldBattleRewards = token["GameGold"]["BattleRewards"].ToObject<int>();
			mGoldLeague = token["GameGold"]["League"].ToObject<int>();
			mGoldExtraRewards = 0;
			mGoldWinstreak = 0;
		}
		else if (token["Gold"] != null)
		{
			mGoldBattleRewards = token["Gold"].ToObject<int>();
			mGoldExtraRewards = 0;
			mGoldWinstreak = 0;
			mGoldLeague = 0;
		}
		if (token["IsVip"] != null)
		{
			mIsVip = token["IsVip"].ToObject<bool>();
		}
		mOldMedals = GameLoginManager.currentPlayer.skill;
		mNewMedals = mOldMedals;
		mOldBalanceMedals = GameLoginManager.currentPlayer.medalsBalance;
		mNewBalanceMedals = mOldBalanceMedals;
		mRemainingFightsToAssign = GameLoginManager.currentPlayer.remainingMatches;
		mSquadPoints = 0;
		if (mLootboxes == null)
		{
			mLootboxes = new List<LootboxContent>();
		}
		else
		{
			mLootboxes.Clear();
		}
		if (token["NewVisuals"] != null)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(StringParser.ParseString(token["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				mLootboxes = LootboxContent.getLootboxes(dictionary);
			}
		}
		Singleton<Wallet>.instance.AddMoneyReward(GetGoldTotal(), GetWbTotal());
	}

	public void AddMedalsInformations(int skill, int medalsBalance, int placementMatchesRequired)
	{
		mNewMedals = skill;
		if (skill == 0)
		{
			mNewMedals = medalsBalance - mOldBalanceMedals;
		}
		mNewBalanceMedals = medalsBalance;
		mRemainingFightsToAssign = placementMatchesRequired;
		Debug.Log($"Game Rewards - Medals old:{mOldMedals} new:{mNewMedals} Balance old:{mOldBalanceMedals} new:{mNewBalanceMedals} Remaining fights:{mRemainingFightsToAssign}");
	}

	public void AddSquadPoints(int squadP)
	{
		mSquadPoints = squadP;
		StatsManager.instance.data.squadPointsTotal++;
		Debug.Log($"Game Rewards - Squad Points: {squadP}");
	}

	internal int GetXpBattle()
	{
		return (!mIsVip) ? (mXpBattleRewards + mXpExtraRewards) : ((int)((float)(mXpBattleRewards + mXpExtraRewards) * Singleton<VipManager>.instance.vipXpMultiplier));
	}

	internal int GetXpWin()
	{
		return (!mIsVip) ? mXpWinstreak : ((int)((float)mXpWinstreak * Singleton<VipManager>.instance.vipXpMultiplier));
	}

	internal int GetXpTime()
	{
		return (!mIsVip) ? mXpTime : ((int)((float)mXpTime * Singleton<VipManager>.instance.vipXpMultiplier));
	}

	internal int GetXpTotal()
	{
		return GetXpBattle() + GetXpWin() + GetXpTime();
	}

	internal int GetWbLeague()
	{
		return (!mIsVip) ? warbucksLeague : warbucksLeagueVip;
	}

	internal int GetWbBattle()
	{
		return (!mIsVip) ? warbucksBattle : warbucksBattleVip;
	}

	internal int GetWbWinstreak()
	{
		return (!mIsVip) ? warbucksWinstreak : warbucksWinstreakVip;
	}

	internal long GetWbTotal()
	{
		return (!mIsVip) ? warbucksTotal : warbucksTotalVip;
	}

	internal int GetGoldLeague()
	{
		return (!mIsVip) ? goldLeague : goldLeagueVip;
	}

	internal int GetGoldBattle()
	{
		return (!mIsVip) ? goldBattle : goldBattleVip;
	}

	internal int GetGoldWinstreak()
	{
		return (!mIsVip) ? goldWinstreak : goldWinstreakVip;
	}

	internal long GetGoldTotal()
	{
		return (!mIsVip) ? goldTotal : goldTotalVip;
	}
}
