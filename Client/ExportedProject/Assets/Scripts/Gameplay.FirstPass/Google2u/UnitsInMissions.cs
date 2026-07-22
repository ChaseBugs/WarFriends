using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class UnitsInMissions : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			DBUpgradeSlotsAssaulter,
			DBUpgradeSlotsShotgunner,
			DBUpgradeSlotsSniper,
			DBUpgradeSlotsMachineGunner,
			DBUpgradeSlotsSwat,
			DBUpgradeSlotsBazooka,
			DBUpgradeSlotsParachuter,
			DBUpgradeSlotsGrennader,
			DBUpgradeSlotsMinigunner,
			DBUpgradeSlotsEngineer,
			DBUpgradeSlotsDrone,
			DBUpgradeSlotsHelicopter,
			DBUpgradeSlotsCar,
			DBUpgradeSlotsTank,
			DBUpgradeSlotsSciFi,
			DBUpgradeSlotsCarBuggy,
			DBUpgradeSlotsAssaultHeli,
			DBUpgradeSlotsTransporter,
			DBUpgradeSlotsFlamethrower,
			DBUpgradeSlotsCommando,
			DBUpgradeSlotsGunslinger,
			DBUpgradeSlotsMortar,
			DBUpgradeSlotsWarper,
			DBUpgradeSlotsMech
		}

		public string[] rowNames = new string[24]
		{
			"DBUpgradeSlotsAssaulter", "DBUpgradeSlotsShotgunner", "DBUpgradeSlotsSniper", "DBUpgradeSlotsMachineGunner", "DBUpgradeSlotsSwat", "DBUpgradeSlotsBazooka", "DBUpgradeSlotsParachuter", "DBUpgradeSlotsGrennader", "DBUpgradeSlotsMinigunner", "DBUpgradeSlotsEngineer",
			"DBUpgradeSlotsDrone", "DBUpgradeSlotsHelicopter", "DBUpgradeSlotsCar", "DBUpgradeSlotsTank", "DBUpgradeSlotsSciFi", "DBUpgradeSlotsCarBuggy", "DBUpgradeSlotsAssaultHeli", "DBUpgradeSlotsTransporter", "DBUpgradeSlotsFlamethrower", "DBUpgradeSlotsCommando",
			"DBUpgradeSlotsGunslinger", "DBUpgradeSlotsMortar", "DBUpgradeSlotsWarper", "DBUpgradeSlotsMech"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "DBUpgradeSlotsAssaulter", 0 },
			{ "DBUpgradeSlotsShotgunner", 1 },
			{ "DBUpgradeSlotsSniper", 2 },
			{ "DBUpgradeSlotsMachineGunner", 3 },
			{ "DBUpgradeSlotsSwat", 4 },
			{ "DBUpgradeSlotsBazooka", 5 },
			{ "DBUpgradeSlotsParachuter", 6 },
			{ "DBUpgradeSlotsGrennader", 7 },
			{ "DBUpgradeSlotsMinigunner", 8 },
			{ "DBUpgradeSlotsEngineer", 9 },
			{ "DBUpgradeSlotsDrone", 10 },
			{ "DBUpgradeSlotsHelicopter", 11 },
			{ "DBUpgradeSlotsCar", 12 },
			{ "DBUpgradeSlotsTank", 13 },
			{ "DBUpgradeSlotsSciFi", 14 },
			{ "DBUpgradeSlotsCarBuggy", 15 },
			{ "DBUpgradeSlotsAssaultHeli", 16 },
			{ "DBUpgradeSlotsTransporter", 17 },
			{ "DBUpgradeSlotsFlamethrower", 18 },
			{ "DBUpgradeSlotsCommando", 19 },
			{ "DBUpgradeSlotsGunslinger", 20 },
			{ "DBUpgradeSlotsMortar", 21 },
			{ "DBUpgradeSlotsWarper", 22 },
			{ "DBUpgradeSlotsMech", 23 }
		};

		public List<UnitsInMissionsRow> Rows = new List<UnitsInMissionsRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 32;

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
			Rows.Add(new UnitsInMissionsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22], input[23], input[24], input[25], input[26], input[27], input[28], input[29], input[30], input[31], input[32]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new UnitsInMissionsRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 33)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new UnitsInMissionsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22], input[23], input[24], input[25], input[26], input[27], input[28], input[29], input[30], input[31], input[32]));
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

		public UnitsInMissionsRow GetRow(rowIds in_RowID)
		{
			UnitsInMissionsRow result = null;
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

		public UnitsInMissionsRow GetRow(string in_RowString)
		{
			UnitsInMissionsRow result = null;
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
