using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class ArmyUpgrades : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_1,
			ID_2,
			ID_3,
			ID_4,
			ID_5,
			ID_6,
			ID_7,
			ID_8,
			ID_9,
			ID_10,
			ID_11,
			ID_12,
			ID_13,
			ID_14,
			ID_15,
			ID_16,
			ID_17,
			ID_18,
			ID_19,
			ID_20,
			ID_21,
			ID_22,
			ID_23,
			ID_24,
			ID_25,
			ID_26,
			ID_27
		}

		public string[] rowNames = new string[27]
		{
			"ID_1", "ID_2", "ID_3", "ID_4", "ID_5", "ID_6", "ID_7", "ID_8", "ID_9", "ID_10",
			"ID_11", "ID_12", "ID_13", "ID_14", "ID_15", "ID_16", "ID_17", "ID_18", "ID_19", "ID_20",
			"ID_21", "ID_22", "ID_23", "ID_24", "ID_25", "ID_26", "ID_27"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ID_1", 0 },
			{ "ID_2", 1 },
			{ "ID_3", 2 },
			{ "ID_4", 3 },
			{ "ID_5", 4 },
			{ "ID_6", 5 },
			{ "ID_7", 6 },
			{ "ID_8", 7 },
			{ "ID_9", 8 },
			{ "ID_10", 9 },
			{ "ID_11", 10 },
			{ "ID_12", 11 },
			{ "ID_13", 12 },
			{ "ID_14", 13 },
			{ "ID_15", 14 },
			{ "ID_16", 15 },
			{ "ID_17", 16 },
			{ "ID_18", 17 },
			{ "ID_19", 18 },
			{ "ID_20", 19 },
			{ "ID_21", 20 },
			{ "ID_22", 21 },
			{ "ID_23", 22 },
			{ "ID_24", 23 },
			{ "ID_25", 24 },
			{ "ID_26", 25 },
			{ "ID_27", 26 }
		};

		public List<ArmyUpgradesRow> Rows = new List<ArmyUpgradesRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 33;

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
			Rows.Add(new ArmyUpgradesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22], input[23], input[24], input[25], input[26], input[27], input[28], input[29], input[30], input[31], input[32], input[33]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new ArmyUpgradesRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 34)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new ArmyUpgradesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22], input[23], input[24], input[25], input[26], input[27], input[28], input[29], input[30], input[31], input[32], input[33]));
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

		public ArmyUpgradesRow GetRow(rowIds in_RowID)
		{
			ArmyUpgradesRow result = null;
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

		public ArmyUpgradesRow GetRow(string in_RowString)
		{
			ArmyUpgradesRow result = null;
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
