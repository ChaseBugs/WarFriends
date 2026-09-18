using Newtonsoft.Json.Linq;
using UnityEngine;

public class WararenaLootboxReward
{
	private string mUnitId;

	private int mUnitEliteParts;

	private int mWarbucks;

	private int mGold;

	private int mTickets;

	private int mScraps;

	public LevelBehaviour unit => LevelManager.instance.Unit(mUnitId);

	public int eliteParts => mUnitEliteParts;

	public int warbucks => mWarbucks;

	public int gold => mGold;

	public int tickets => mTickets;

	public int scraps => mScraps;

	public string unitId => mUnitId;

	public WararenaLootboxReward(JToken token)
	{
		mUnitId = StringParser.ParseString(token["ArmyUnitId"], string.Empty);
		mUnitEliteParts = StringParser.ParseIntToken(token["ArmyUnitParts"]);
		mWarbucks = StringParser.ParseIntToken(token["WarBucks"]);
		mGold = StringParser.ParseIntToken(token["Gold"]);
		mTickets = StringParser.ParseIntToken(token["Tickets"]);
		mScraps = StringParser.ParseIntToken(token["Scraps"]);
		Debug.Log(ToString());
	}

	public void AddToClient()
	{
		unit.upgradeSlots.upgradeSlotElite.currentParts += mUnitEliteParts;
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new ElitePerkTutorialMessage());
			ElitesFeatureShownRequest.Send();
		}
		Singleton<Wallet>.instance.AddWarBucksReward(mWarbucks);
		Singleton<Wallet>.instance.AddGoldReward(mGold);
		Singleton<Wallet>.instance.AddTickets(mTickets);
		Singleton<Wallet>.instance.AddScraps(mScraps);
	}

	public override string ToString()
	{
		string text = "Arena Lootbox:\n";
		text += $"Unit \"{mUnitId}\" elite parts: {mUnitEliteParts}\n";
		text += $"Warbucks: {mWarbucks}\n";
		text += $"Gold:     {mGold}\n";
		text += $"Tickets:  {mTickets}\n";
		return text + $"Scraps:   {mScraps}\n";
	}
}
