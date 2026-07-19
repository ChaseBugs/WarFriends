using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class Achievements : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			acquireUnits_1 = 0,
			acquireUnits_2 = 1,
			acquireUnits_3 = 2,
			acquireWeapons_1 = 3,
			acquireWeapons_2 = 4,
			acquireWeapons_3 = 5,
			winRankedBattles_1 = 6,
			winRankedBattles_2 = 7,
			winRankedBattles_3 = 8,
			winArenaBattles_1 = 9,
			winArenaBattles_2 = 10,
			winArenaBattles_3 = 11,
			becomeAFlawlessHero_1 = 12,
			becomeAFlawlessHero_2 = 13,
			becomeAFlawlessHero_3 = 14,
			completeMissions_1 = 15,
			completeMissions_2 = 16,
			completeMissions_3 = 17,
			deploySoldierUnits_1 = 18,
			deploySoldierUnits_2 = 19,
			deploySoldierUnits_3 = 20,
			deployVehicles_1 = 21,
			deployVehicles_2 = 22,
			deployVehicles_3 = 23,
			playWarcards_1 = 24,
			playWarcards_2 = 25,
			playWarcards_3 = 26,
			trainSoldierUnitsTimes_1 = 27,
			trainSoldierUnitsTimes_2 = 28,
			trainSoldierUnitsTimes_3 = 29,
			upgradeVehiclesTimes_1 = 30,
			upgradeVehiclesTimes_2 = 31,
			upgradeVehiclesTimes_3 = 32,
			upgradeWeaponsTimes_1 = 33,
			upgradeWeaponsTimes_2 = 34,
			upgradeWeaponsTimes_3 = 35,
			completeAssignments_1 = 36,
			completeAssignments_2 = 37,
			completeAssignments_3 = 38,
			getToLeague_1 = 39,
			getToLeague_2 = 40,
			getToLeague_3 = 41,
			earnSquadPoints_1 = 42,
			earnSquadPoints_2 = 43,
			earnSquadPoints_3 = 44,
			collectCosmeticItems_1 = 45,
			collectCosmeticItems_2 = 46,
			collectCosmeticItems_3 = 47,
			claimDailyRewards_1 = 48,
			claimDailyRewards_2 = 49,
			claimDailyRewards_3 = 50,
			playWarcardsInASingleBattle_1 = 51,
			stealEnemyCrates_1 = 52,
			stealEnemyCrates_2 = 53,
			stealEnemyCrates_3 = 54
		}

		public string[] rowNames = new string[55]
		{
			"acquireUnits_1", "acquireUnits_2", "acquireUnits_3", "acquireWeapons_1", "acquireWeapons_2", "acquireWeapons_3", "winRankedBattles_1", "winRankedBattles_2", "winRankedBattles_3", "winArenaBattles_1",
			"winArenaBattles_2", "winArenaBattles_3", "becomeAFlawlessHero_1", "becomeAFlawlessHero_2", "becomeAFlawlessHero_3", "completeMissions_1", "completeMissions_2", "completeMissions_3", "deploySoldierUnits_1", "deploySoldierUnits_2",
			"deploySoldierUnits_3", "deployVehicles_1", "deployVehicles_2", "deployVehicles_3", "playWarcards_1", "playWarcards_2", "playWarcards_3", "trainSoldierUnitsTimes_1", "trainSoldierUnitsTimes_2", "trainSoldierUnitsTimes_3",
			"upgradeVehiclesTimes_1", "upgradeVehiclesTimes_2", "upgradeVehiclesTimes_3", "upgradeWeaponsTimes_1", "upgradeWeaponsTimes_2", "upgradeWeaponsTimes_3", "completeAssignments_1", "completeAssignments_2", "completeAssignments_3", "getToLeague_1",
			"getToLeague_2", "getToLeague_3", "earnSquadPoints_1", "earnSquadPoints_2", "earnSquadPoints_3", "collectCosmeticItems_1", "collectCosmeticItems_2", "collectCosmeticItems_3", "claimDailyRewards_1", "claimDailyRewards_2",
			"claimDailyRewards_3", "playWarcardsInASingleBattle_1", "stealEnemyCrates_1", "stealEnemyCrates_2", "stealEnemyCrates_3"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "acquireUnits_1", 0 },
			{ "acquireUnits_2", 1 },
			{ "acquireUnits_3", 2 },
			{ "acquireWeapons_1", 3 },
			{ "acquireWeapons_2", 4 },
			{ "acquireWeapons_3", 5 },
			{ "winRankedBattles_1", 6 },
			{ "winRankedBattles_2", 7 },
			{ "winRankedBattles_3", 8 },
			{ "winArenaBattles_1", 9 },
			{ "winArenaBattles_2", 10 },
			{ "winArenaBattles_3", 11 },
			{ "becomeAFlawlessHero_1", 12 },
			{ "becomeAFlawlessHero_2", 13 },
			{ "becomeAFlawlessHero_3", 14 },
			{ "completeMissions_1", 15 },
			{ "completeMissions_2", 16 },
			{ "completeMissions_3", 17 },
			{ "deploySoldierUnits_1", 18 },
			{ "deploySoldierUnits_2", 19 },
			{ "deploySoldierUnits_3", 20 },
			{ "deployVehicles_1", 21 },
			{ "deployVehicles_2", 22 },
			{ "deployVehicles_3", 23 },
			{ "playWarcards_1", 24 },
			{ "playWarcards_2", 25 },
			{ "playWarcards_3", 26 },
			{ "trainSoldierUnitsTimes_1", 27 },
			{ "trainSoldierUnitsTimes_2", 28 },
			{ "trainSoldierUnitsTimes_3", 29 },
			{ "upgradeVehiclesTimes_1", 30 },
			{ "upgradeVehiclesTimes_2", 31 },
			{ "upgradeVehiclesTimes_3", 32 },
			{ "upgradeWeaponsTimes_1", 33 },
			{ "upgradeWeaponsTimes_2", 34 },
			{ "upgradeWeaponsTimes_3", 35 },
			{ "completeAssignments_1", 36 },
			{ "completeAssignments_2", 37 },
			{ "completeAssignments_3", 38 },
			{ "getToLeague_1", 39 },
			{ "getToLeague_2", 40 },
			{ "getToLeague_3", 41 },
			{ "earnSquadPoints_1", 42 },
			{ "earnSquadPoints_2", 43 },
			{ "earnSquadPoints_3", 44 },
			{ "collectCosmeticItems_1", 45 },
			{ "collectCosmeticItems_2", 46 },
			{ "collectCosmeticItems_3", 47 },
			{ "claimDailyRewards_1", 48 },
			{ "claimDailyRewards_2", 49 },
			{ "claimDailyRewards_3", 50 },
			{ "playWarcardsInASingleBattle_1", 51 },
			{ "stealEnemyCrates_1", 52 },
			{ "stealEnemyCrates_2", 53 },
			{ "stealEnemyCrates_3", 54 }
		};

		public List<AchievementsRow> Rows = new List<AchievementsRow>();

		public override bool haveDictionary
		{
			get
			{
				return true;
			}
		}

		public override int getColumnCount
		{
			get
			{
				return 13;
			}
		}

		public override int GetRowIndex(string rowID)
		{
			if (namesToIndex.ContainsKey(rowID))
			{
				return namesToIndex[rowID];
			}
			return -1;
		}

		public override void AddRowGeneric(List<string> input)
		{
			Rows.Add(new AchievementsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new AchievementsRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 14)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new AchievementsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13]));
			mRows = null;
			return namesToIndex[input[0]];
		}

		public override void CheckRows(List<string> rowIds)
		{
			int num = rowNames.Length;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, int> item in namesToIndex)
			{
				if (item.Value >= num && !rowIds.Contains(item.Key))
				{
					list.Add(item.Key);
				}
			}
			foreach (string item2 in list)
			{
				int num2 = namesToIndex[item2];
				if (num2 == Rows.Count - 1)
				{
					namesToIndex.Remove(item2);
					Rows.RemoveAt(Rows.Count - 1);
					continue;
				}
				int num3 = Rows.Count - 1;
				string key = string.Empty;
				foreach (KeyValuePair<string, int> item3 in namesToIndex)
				{
					if (item3.Value == num3)
					{
						key = item3.Key;
						break;
					}
				}
				namesToIndex[key] = num2;
				Rows[num2] = Rows[num3];
				namesToIndex.Remove(item2);
				Rows.RemoveAt(Rows.Count - 1);
			}
			mRows = null;
		}

		public override void Clear()
		{
			Rows.Clear();
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow result = null;
			try
			{
				result = Rows[(int)Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch (ArgumentException)
			{
				Debug.LogError(in_RowString + " is not a member of the rowIds enumeration.");
			}
			return result;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow result = null;
			try
			{
				result = Rows[(int)in_RowID];
			}
			catch (KeyNotFoundException ex)
			{
				Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
			}
			return result;
		}

		public AchievementsRow GetRow(rowIds in_RowID)
		{
			AchievementsRow result = null;
			try
			{
				result = Rows[(int)in_RowID];
			}
			catch (KeyNotFoundException ex)
			{
				Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
			}
			return result;
		}

		public AchievementsRow GetRow(string in_RowString)
		{
			AchievementsRow result = null;
			if (namesToIndex.ContainsKey(in_RowString))
			{
				result = Rows[namesToIndex[in_RowString]];
			}
			else
			{
				Debug.LogError(in_RowString + " is not stored in translate dictionary.");
			}
			return result;
		}
	}
}
