using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class Wallet : Singleton<Wallet>
{
	private ObscuredLong mGold;

	private ObscuredLong mTickets;

	private ObscuredLong mScraps;

	private ObscuredLong mWarbucks;

	public long gold
	{
		get
		{
			return mGold;
		}
		private set
		{
			mGold = value;
			Singleton<EventTrackingManager>.instance.fuseboxxService.RegisterCurrency(FuseboxxService.Currency.Gold, mGold);
		}
	}

	public long tickets
	{
		get
		{
			return mTickets;
		}
		private set
		{
			mTickets = value;
		}
	}

	public long scraps
	{
		get
		{
			return mScraps;
		}
		private set
		{
			mScraps = value;
		}
	}

	public long warBucks
	{
		get
		{
			return mWarbucks;
		}
		private set
		{
			mWarbucks = value;
			Singleton<EventTrackingManager>.instance.fuseboxxService.RegisterCurrency(FuseboxxService.Currency.Warbucks, mWarbucks);
		}
	}

	public long warbucksAfterGame => (Singleton<ServerResultsCache>.instance.lastGameReward == null) ? warBucks : (warBucks - Singleton<ServerResultsCache>.instance.lastGameReward.GetWbTotal());

	public long goldAfterGame => (Singleton<ServerResultsCache>.instance.lastGameReward == null) ? gold : (gold - Singleton<ServerResultsCache>.instance.lastGameReward.GetGoldTotal());

	public long warbucksAfterArena => (WarArena.instance.lastLootboxReward == null) ? warBucks : (warBucks - WarArena.instance.lastLootboxReward.warbucks);

	public long goldAfterArena => (WarArena.instance.lastLootboxReward == null) ? gold : (gold - WarArena.instance.lastLootboxReward.gold);

	public event Action<long, long> WarbucksChanged;

	public event Action<long, long> GoldChanged;

	public event Action<long, long> TicketsChanged;

	public event Action<long, long> ScrapsChanged;

	public bool CanBuyGold(int gold)
	{
		return this.gold - gold >= 0;
	}

	public bool CanBuyW(int warBucks)
	{
		return this.warBucks - warBucks >= 0;
	}

	public bool CanBuyTickets(int tickets)
	{
		return this.tickets - tickets >= 0;
	}

	public bool CanBuyScraps(int scraps)
	{
		return this.scraps - scraps >= 0;
	}

	internal void Init(long initGold, long initWarBucks)
	{
		Debug.Log($"WALLET - initialization - GOLD {MiscTools.DifferenceString(gold, initGold)} WB {MiscTools.DifferenceString(warBucks, initWarBucks)}");
		long arg = initGold - gold;
		long arg2 = warBucks - initWarBucks;
		gold = initGold;
		warBucks = initWarBucks;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, arg);
		}
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, arg2);
		}
	}

	internal void InitWarBucks(long initWarBucks)
	{
		Debug.Log($"WALLET - initialization WB {MiscTools.DifferenceString(warBucks, initWarBucks)}");
		long arg = warBucks - initWarBucks;
		warBucks = initWarBucks;
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, arg);
		}
	}

	internal void InitGold(long initGold)
	{
		Debug.Log($"WALLET - initialization GOLD {MiscTools.DifferenceString(gold, initGold)}");
		long arg = initGold - gold;
		gold = initGold;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, arg);
		}
	}

	public void InitTickets(long newTickets)
	{
		long arg = newTickets - tickets;
		tickets = newTickets;
		if (this.TicketsChanged != null)
		{
			this.TicketsChanged(newTickets, arg);
		}
	}

	public void InitScraps(long newScraps)
	{
		long arg = newScraps - scraps;
		scraps = newScraps;
		if (this.ScrapsChanged != null)
		{
			this.ScrapsChanged(newScraps, arg);
		}
	}

	internal void AddMoneyReward(long goldAmount, long warbucksAmount)
	{
		Debug.Log($"WALLET - money reward - GOLD {MiscTools.DifferenceString(gold, gold + goldAmount)} WB {MiscTools.DifferenceString(warBucks, warBucks + warbucksAmount)}");
		gold += goldAmount;
		warBucks += warbucksAmount;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, goldAmount);
		}
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, warbucksAmount);
		}
	}

	public void AddTickets(long amount)
	{
		tickets += amount;
		if (this.TicketsChanged != null)
		{
			this.TicketsChanged(tickets, amount);
		}
	}

	public void AddScraps(long amount)
	{
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new ElitePerkTutorialMessage());
			ElitesFeatureShownRequest.Send();
		}
		scraps += amount;
		if (this.ScrapsChanged != null)
		{
			this.ScrapsChanged(scraps, amount);
		}
	}

	internal void AddGoldBought(long goldAmount)
	{
		Debug.Log($"WALLET - bought GOLD {MiscTools.DifferenceString(gold, gold + goldAmount)}");
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CoinPurchase);
		gold += goldAmount;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, goldAmount);
		}
	}

	internal void AddGoldReward(long goldAmount, bool animate = true)
	{
		Debug.Log($"WALLET - reward GOLD {MiscTools.DifferenceString(gold, gold + goldAmount)} animate:{animate}");
		gold += goldAmount;
		if (animate && this.GoldChanged != null)
		{
			this.GoldChanged(gold, goldAmount);
		}
	}

	internal void GoldSpent(long goldAmount)
	{
		Debug.Log($"WALLET - spent GOLD {MiscTools.DifferenceString(gold, gold - goldAmount)}");
		gold -= goldAmount;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, -goldAmount);
		}
	}

	internal void GoldSpentFake(long goldAmount)
	{
		Debug.Log($"WALLET - fake spent GOLD {MiscTools.DifferenceString(gold, gold - goldAmount)}");
		gold -= goldAmount;
		if (this.GoldChanged != null)
		{
			this.GoldChanged(gold, -goldAmount);
		}
	}

	internal void AddWarbucksBought(long amount)
	{
		Debug.Log($"WALLET - bought WB {MiscTools.DifferenceString(warBucks, warBucks + amount)}");
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CoinPurchase);
		warBucks += amount;
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, amount);
		}
	}

	internal void AddWarBucksReward(long amount, bool animate = true)
	{
		Debug.Log($"WALLET - reward WB {MiscTools.DifferenceString(warBucks, warBucks + amount)} animate:{animate}");
		warBucks += amount;
		if (animate && this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, amount);
		}
	}

	internal void WarBucksSpent(long amount)
	{
		Debug.Log($"WALLET - spent WB {MiscTools.DifferenceString(warBucks, warBucks - amount)}");
		warBucks -= amount;
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, -amount);
		}
	}

	internal void WarBucksSpentFake(long amount)
	{
		Debug.Log($"WALLET - fake spent WB {MiscTools.DifferenceString(warBucks, warBucks - amount)}");
		warBucks -= amount;
		if (this.WarbucksChanged != null)
		{
			this.WarbucksChanged(warBucks, -amount);
		}
	}

	public void TicketsSpent(long amount)
	{
		Debug.Log($"WALLET - spent tickets {MiscTools.DifferenceString(tickets, tickets - amount)}");
		tickets -= amount;
		if (this.TicketsChanged != null)
		{
			this.TicketsChanged(tickets, -amount);
		}
	}

	public void ScrapsSpent(long amount)
	{
		Debug.Log($"WALLET - spent scraps {MiscTools.DifferenceString(scraps, scraps - amount)}");
		scraps -= amount;
		if (this.ScrapsChanged != null)
		{
			this.ScrapsChanged(scraps, -amount);
		}
	}

	public void SetRewardForTutorial(int gameWarbugs, int gameGold)
	{
		int num = (LevelManager.instance.isLevelUp ? LevelManager.instance.currentLevel.warbucks : 0);
		gameWarbugs += num;
		warBucks += gameWarbugs;
		int num2 = (LevelManager.instance.isLevelUp ? LevelManager.instance.currentLevel.golds : 0);
		gameGold += num2;
		gold += gameGold;
		Singleton<ServerResultsCache>.instance.lastGameReward = new DatabaseGameReward(Singleton<ScoreManager>.instance.score, gameWarbugs, gameGold);
		StatsManager.instance.winStreak = new WinStreakManager.WinStreak(0, 0);
	}

	public void SetTutorialCurrency(int warbucks, int goldAmount)
	{
		gold = goldAmount;
		warBucks = warbucks;
	}
}
