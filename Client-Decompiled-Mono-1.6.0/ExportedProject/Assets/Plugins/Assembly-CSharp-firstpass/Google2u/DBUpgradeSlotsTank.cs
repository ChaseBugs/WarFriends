using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class DBUpgradeSlotsTank : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ROW_1 = 0,
			ROW_2 = 1,
			ROW_3 = 2,
			ROW_4 = 3,
			ROW_5 = 4,
			ROW_6 = 5,
			ROW_7 = 6,
			ROW_8 = 7,
			ROW_9 = 8,
			ROW_10 = 9,
			ROW_11 = 10,
			ROW_12 = 11,
			ROW_13 = 12,
			ROW_14 = 13,
			ROW_15 = 14,
			ROW_16 = 15,
			ROW_17 = 16,
			ROW_18 = 17,
			ROW_19 = 18,
			ROW_20 = 19,
			ROW_21 = 20,
			ROW_22 = 21,
			ROW_23 = 22,
			ROW_24 = 23,
			ROW_25 = 24,
			ROW_26 = 25,
			ROW_27 = 26,
			ROW_28 = 27,
			ROW_29 = 28,
			ROW_30 = 29,
			ROW_31 = 30,
			ROW_32 = 31,
			ROW_33 = 32,
			ROW_34 = 33,
			ROW_35 = 34,
			ROW_36 = 35,
			ROW_37 = 36,
			ROW_38 = 37,
			ROW_39 = 38,
			ROW_40 = 39,
			ROW_41 = 40,
			ROW_42 = 41,
			ROW_43 = 42,
			ROW_44 = 43,
			ROW_45 = 44,
			ROW_46 = 45,
			ROW_47 = 46,
			ROW_48 = 47,
			ROW_49 = 48,
			ROW_50 = 49,
			ROW_51 = 50,
			SPECIAL_0 = 51,
			SPECIAL_1 = 52,
			SPECIAL_2 = 53,
			SPECIAL_3 = 54,
			SPECIAL_4 = 55,
			SPECIAL_5 = 56,
			WARARENA = 57
		}

		public string[] rowNames = new string[58]
		{
			"ROW_1", "ROW_2", "ROW_3", "ROW_4", "ROW_5", "ROW_6", "ROW_7", "ROW_8", "ROW_9", "ROW_10",
			"ROW_11", "ROW_12", "ROW_13", "ROW_14", "ROW_15", "ROW_16", "ROW_17", "ROW_18", "ROW_19", "ROW_20",
			"ROW_21", "ROW_22", "ROW_23", "ROW_24", "ROW_25", "ROW_26", "ROW_27", "ROW_28", "ROW_29", "ROW_30",
			"ROW_31", "ROW_32", "ROW_33", "ROW_34", "ROW_35", "ROW_36", "ROW_37", "ROW_38", "ROW_39", "ROW_40",
			"ROW_41", "ROW_42", "ROW_43", "ROW_44", "ROW_45", "ROW_46", "ROW_47", "ROW_48", "ROW_49", "ROW_50",
			"ROW_51", "SPECIAL_0", "SPECIAL_1", "SPECIAL_2", "SPECIAL_3", "SPECIAL_4", "SPECIAL_5", "WARARENA"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ROW_1", 0 },
			{ "ROW_2", 1 },
			{ "ROW_3", 2 },
			{ "ROW_4", 3 },
			{ "ROW_5", 4 },
			{ "ROW_6", 5 },
			{ "ROW_7", 6 },
			{ "ROW_8", 7 },
			{ "ROW_9", 8 },
			{ "ROW_10", 9 },
			{ "ROW_11", 10 },
			{ "ROW_12", 11 },
			{ "ROW_13", 12 },
			{ "ROW_14", 13 },
			{ "ROW_15", 14 },
			{ "ROW_16", 15 },
			{ "ROW_17", 16 },
			{ "ROW_18", 17 },
			{ "ROW_19", 18 },
			{ "ROW_20", 19 },
			{ "ROW_21", 20 },
			{ "ROW_22", 21 },
			{ "ROW_23", 22 },
			{ "ROW_24", 23 },
			{ "ROW_25", 24 },
			{ "ROW_26", 25 },
			{ "ROW_27", 26 },
			{ "ROW_28", 27 },
			{ "ROW_29", 28 },
			{ "ROW_30", 29 },
			{ "ROW_31", 30 },
			{ "ROW_32", 31 },
			{ "ROW_33", 32 },
			{ "ROW_34", 33 },
			{ "ROW_35", 34 },
			{ "ROW_36", 35 },
			{ "ROW_37", 36 },
			{ "ROW_38", 37 },
			{ "ROW_39", 38 },
			{ "ROW_40", 39 },
			{ "ROW_41", 40 },
			{ "ROW_42", 41 },
			{ "ROW_43", 42 },
			{ "ROW_44", 43 },
			{ "ROW_45", 44 },
			{ "ROW_46", 45 },
			{ "ROW_47", 46 },
			{ "ROW_48", 47 },
			{ "ROW_49", 48 },
			{ "ROW_50", 49 },
			{ "ROW_51", 50 },
			{ "SPECIAL_0", 51 },
			{ "SPECIAL_1", 52 },
			{ "SPECIAL_2", 53 },
			{ "SPECIAL_3", 54 },
			{ "SPECIAL_4", 55 },
			{ "SPECIAL_5", 56 },
			{ "WARARENA", 57 }
		};

		public List<DBUpgradeSlotsTankRow> Rows = new List<DBUpgradeSlotsTankRow>();

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
				return 18;
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
			Rows.Add(new DBUpgradeSlotsTankRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new DBUpgradeSlotsTankRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 19)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new DBUpgradeSlotsTankRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18]));
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

		public DBUpgradeSlotsTankRow GetRow(rowIds in_RowID)
		{
			DBUpgradeSlotsTankRow result = null;
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

		public DBUpgradeSlotsTankRow GetRow(string in_RowString)
		{
			DBUpgradeSlotsTankRow result = null;
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
