using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class FakePlayersManager : InGameSerializedObjectGeneric<FakePlayersManager.FakePlayersData>
{
	[Skip]
	public class FakePlayersData
	{
		public int randomPosition;
	}

	private int mGeneratedForPosition = -1;

	private List<DatabasePlayer> mCachedFakePlayers;

	private RadicalRoutine mEnumerator;

	private static FakePlayersManager mInstance;

	public static FakePlayersManager instance
	{
		get
		{
			mInstance = mInstance ?? ((FakePlayersManager)UnityEngine.Object.FindObjectsOfType(typeof(FakePlayersManager))[0]);
			return mInstance;
		}
	}

	private int mRandomPosition
	{
		get
		{
			if (data.randomPosition == 0)
			{
				data.randomPosition = UnityEngine.Random.Range(8, 13);
				Save();
			}
			return data.randomPosition - 10;
		}
	}

	public event Action<int> UpdatedPosition;

	public event Action GeneratedPlayers;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void UpdateBeginnersLeaguePosition()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			int currentPositionInBeginnersLeague = instance.GetCurrentPositionInBeginnersLeague(100, currentPlayer.medalsBalance, currentPlayer.beginnersLeague);
			if (this.UpdatedPosition != null)
			{
				this.UpdatedPosition(currentPositionInBeginnersLeague);
			}
		}
	}

	public void GeneratePlayersForLeague()
	{
		if (mEnumerator != null)
		{
			mEnumerator.Cancel();
			mEnumerator = null;
		}
		mEnumerator = RadicalRoutine.Create(GeneratePlayers());
		StartCoroutine(RadicalRoutine.Run(mEnumerator.enumerator));
	}

	public int GetCurrentPositionInBeginnersLeague(int playersInLeague, int leagueMedals, int beginnersLeague)
	{
		int num = Mathf.RoundToInt((float)playersInLeague * 0.1f);
		int num2 = Mathf.RoundToInt((float)playersInLeague * 0.9f);
		int num3 = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
		int num4 = Mathf.RoundToInt((float)num3 * 0.2f);
		num3 += num4;
		leagueMedals += num4;
		if (leagueMedals < 0)
		{
			num3 += Mathf.Abs(leagueMedals);
			leagueMedals = 0;
		}
		int num5 = playersInLeague - Mathf.RoundToInt((float)leagueMedals * (float)(playersInLeague - 1) / (float)num3);
		int num6 = num5 + mRandomPosition;
		if (num5 < num || num6 < num || num5 > num2 || num6 > num2)
		{
			return num5;
		}
		return num6;
	}

	private IEnumerator GeneratePlayers()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			yield break;
		}
		DatabasePlayer me = GameLoginManager.currentPlayer;
		int position = instance.GetCurrentPositionInBeginnersLeague(100, me.medalsBalance, me.beginnersLeague);
		int indexOfMe = position - 1;
		if (position == mGeneratedForPosition)
		{
			mCachedFakePlayers[indexOfMe] = me;
			if (this.GeneratedPlayers != null)
			{
				this.GeneratedPlayers();
			}
			yield break;
		}
		mCachedFakePlayers = new List<DatabasePlayer>();
		List<string> fakeNames = FakeBotNames(99);
		int index = 0;
		int beginnersLeague = me.beginnersLeague;
		int maxLeagueMedals = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
		int minLeagueMedals = Mathf.RoundToInt((float)(-maxLeagueMedals) * 0.2f);
		int myMedals = me.medalsBalance;
		for (int i = 0; i < 100; i++)
		{
			if (i == indexOfMe)
			{
				mCachedFakePlayers.Add(me);
			}
			else if (i < indexOfMe)
			{
				int medals = Mathf.RoundToInt((float)Mathf.Abs(maxLeagueMedals - 2 - myMedals) * ((float)(indexOfMe - i) / (float)indexOfMe)) + 1;
				mCachedFakePlayers.Add(GenerateFakeBotBeginner(fakeNames[index], me, medals));
				index++;
			}
			else
			{
				int medals2 = -1 - Mathf.RoundToInt((float)(myMedals - 1 - minLeagueMedals) * ((float)(i - indexOfMe) / (float)(100 - indexOfMe)));
				mCachedFakePlayers.Add(GenerateFakeBotBeginner(fakeNames[index], me, medals2));
				index++;
			}
			if (i % 3 == 0)
			{
				yield return null;
			}
		}
		mGeneratedForPosition = position;
		if (this.GeneratedPlayers != null)
		{
			this.GeneratedPlayers();
		}
	}

	public List<DatabasePlayer> GenerateFakePlayers(int playersInLeague, int myPosition, int minLeagueMedals, int maxLeagueMedals)
	{
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		List<string> list2 = FakeBotNames(playersInLeague - 1);
		League leagueTier = currentPlayer.leagueTier;
		int medalsBalance = currentPlayer.medalsBalance;
		int num = 0;
		if (myPosition == 1)
		{
			maxLeagueMedals = medalsBalance;
		}
		if (myPosition == playersInLeague)
		{
			minLeagueMedals = medalsBalance;
		}
		int num2 = myPosition - 1;
		for (int i = 0; i < playersInLeague; i++)
		{
			if (i + 1 == myPosition)
			{
				list.Add(currentPlayer);
			}
			else if (i + 1 < myPosition)
			{
				int num3 = maxLeagueMedals - medalsBalance - 1;
				float num4 = (float)(num2 - i) / (float)num2;
				int diffMedals = Mathf.RoundToInt((float)num3 * num4) + medalsBalance + 1;
				list.Add(GenerateFakeBotBeginner(list2[num], currentPlayer, diffMedals));
				num++;
			}
			else
			{
				int num5 = medalsBalance - minLeagueMedals - 1;
				float num6 = (float)(playersInLeague - i) / (float)(playersInLeague - num2);
				int diffMedals2 = minLeagueMedals + Mathf.RoundToInt((float)num5 * num6);
				list.Add(GenerateFakeBotBeginner(list2[num], currentPlayer, diffMedals2));
				num++;
			}
			list[i].leagueTier = leagueTier;
		}
		return list;
	}

	public List<DatabasePlayer> ListOfPlayers()
	{
		return mCachedFakePlayers;
	}

	private List<string> FakeBotNames(int count)
	{
		List<string> list = new List<string>();
		if (count < 1)
		{
			return list;
		}
		int num = Mathf.RoundToInt((float)count * 0.1f);
		int num2 = 0;
		int count2 = Singleton<BotManager>.instance.botNamesSheet.Rows.Count;
		while (list.Count < num)
		{
			string nAME = Singleton<BotManager>.instance.botNamesSheet.Rows[UnityEngine.Random.Range(0, count2)].NAME;
			if (list.Contains(nAME))
			{
				num2++;
			}
			else
			{
				list.Add(nAME);
				num2 = 0;
			}
			if (num2 > 10)
			{
				break;
			}
		}
		int num3 = list.Count;
		while (num3 < count)
		{
			string item = $"Warfriend{UnityEngine.Random.Range(100000, 1000000)}";
			if (!list.Contains(item))
			{
				list.Add(item);
				num3++;
			}
		}
		for (int num4 = 50; num4 > 0; num4--)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list.Count);
			string value = list[index2];
			list[index2] = list[index];
			list[index] = value;
		}
		return list;
	}

	private DatabasePlayer GenerateFakeBotBeginner(string name, DatabasePlayer designPlayer, int diffMedals)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.accountName = name;
		databasePlayer.level = designPlayer.level;
		databasePlayer.id = "bot-" + name;
		databasePlayer.medalsBalance = designPlayer.medalsBalance + diffMedals;
		databasePlayer.beginnersLeague = designPlayer.beginnersLeague;
		databasePlayer.skill = designPlayer.skill + diffMedals;
		if (databasePlayer.statisticsData == null)
		{
			databasePlayer.statisticsData = new StatsManager.StatisticsData();
		}
		databasePlayer.statisticsData.maxMedals = designPlayer.statisticsData.maxMedals + diffMedals;
		databasePlayer.statisticsData.mmmGames = designPlayer.statisticsData.mmmGames;
		databasePlayer.country = Singleton<BotManager>.instance.GetBotCountry();
		databasePlayer.statisticsData.battlesWonRanked = designPlayer.statisticsData.battlesWonRanked + diffMedals / 9;
		databasePlayer.statisticsData.battlesLostRanked = designPlayer.statisticsData.battlesLost;
		databasePlayer.statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (databasePlayer.level >= LevelManager.instance.warcardsUnlockLevel)
		{
			List<Card> cards = CardManager.instance.cards;
			Card card = cards[UnityEngine.Random.Range(0, cards.Count)];
			while (card.isBuddyCard)
			{
				card = cards[UnityEngine.Random.Range(0, cards.Count)];
			}
			databasePlayer.statisticsData.cardsPlayedSeparately[card.id] = 100;
		}
		string[] botVisuals = Singleton<BotManager>.instance.GetBotVisuals(databasePlayer.level);
		databasePlayer.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < botVisuals.Length; i++)
		{
			string equippedID = botVisuals[i];
			databasePlayer.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		PlayerInventory.EquippedWeapon[] equippedWeapons;
		float value = BotManager.PickWeapons(databasePlayer.level, out equippedWeapons);
		databasePlayer.levelManagerData = new LevelManager.LevelManagerData();
		databasePlayer.inventoryData = new PlayerInventory.InventoryData();
		for (int j = 0; j < equippedWeapons.Length; j++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon = equippedWeapons[j];
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[equippedWeapon.weaponId];
			databasePlayer.levelManagerData.savedWeapons[weaponLevelsSetup.GetSheetName()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = equippedWeapon.weaponUpgrade
			};
			databasePlayer.inventoryData.slots[j] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = equippedWeapon.weaponId
			};
		}
		float botUnitPower = 0f;
		UnitUpgradeDefinition[] array = BotManager.PickBotUnits(out botUnitPower, databasePlayer.level);
		databasePlayer.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		databasePlayer.statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int k = 0; k < array.Length; k++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = array[k];
			string sheetName = LevelManager.instance.behaviours[k].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition.isEquipped)
			{
				databasePlayer.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition.isEquipped,
					boughtIndex = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition.tier
				};
				databasePlayer.statisticsData.unitsDeployedSpecific[k] = UnityEngine.Random.Range(0, 100);
			}
		}
		databasePlayer.armyPower = MiscTools.RoundToInt(botUnitPower) + MiscTools.RoundToInt(value) + LevelManager.instance.GetRankPower(databasePlayer.level);
		return databasePlayer;
	}
}
