using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class BalanceTable : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ROW_0 = 0,
			ROW_1 = 1,
			ROW_2 = 2,
			ROW_3 = 3,
			ROW_4 = 4,
			ROW_5 = 5,
			ROW_6 = 6,
			ROW_7 = 7,
			ROW_8 = 8,
			ROW_9 = 9,
			ROW_10 = 10,
			ROW_11 = 11,
			ROW_12 = 12,
			ROW_13 = 13,
			ROW_14 = 14,
			ROW_15 = 15,
			ROW_16 = 16,
			ROW_17 = 17,
			ROW_18 = 18,
			ROW_19 = 19,
			ROW_20 = 20,
			ROW_21 = 21,
			ROW_22 = 22,
			ROW_23 = 23,
			ROW_24 = 24,
			ROW_25 = 25,
			ROW_26 = 26,
			ROW_27 = 27,
			ROW_28 = 28,
			ROW_29 = 29,
			ROW_30 = 30,
			ROW_31 = 31,
			ROW_32 = 32,
			ROW_33 = 33,
			ROW_34 = 34,
			ROW_35 = 35,
			ROW_36 = 36,
			ROW_37 = 37,
			ROW_38 = 38,
			ROW_39 = 39,
			ROW_40 = 40,
			ROW_41 = 41,
			ROW_42 = 42,
			ROW_43 = 43
		}

		public string[] rowNames = new string[44]
		{
			"ROW_0", "ROW_1", "ROW_2", "ROW_3", "ROW_4", "ROW_5", "ROW_6", "ROW_7", "ROW_8", "ROW_9",
			"ROW_10", "ROW_11", "ROW_12", "ROW_13", "ROW_14", "ROW_15", "ROW_16", "ROW_17", "ROW_18", "ROW_19",
			"ROW_20", "ROW_21", "ROW_22", "ROW_23", "ROW_24", "ROW_25", "ROW_26", "ROW_27", "ROW_28", "ROW_29",
			"ROW_30", "ROW_31", "ROW_32", "ROW_33", "ROW_34", "ROW_35", "ROW_36", "ROW_37", "ROW_38", "ROW_39",
			"ROW_40", "ROW_41", "ROW_42", "ROW_43"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ROW_0", 0 },
			{ "ROW_1", 1 },
			{ "ROW_2", 2 },
			{ "ROW_3", 3 },
			{ "ROW_4", 4 },
			{ "ROW_5", 5 },
			{ "ROW_6", 6 },
			{ "ROW_7", 7 },
			{ "ROW_8", 8 },
			{ "ROW_9", 9 },
			{ "ROW_10", 10 },
			{ "ROW_11", 11 },
			{ "ROW_12", 12 },
			{ "ROW_13", 13 },
			{ "ROW_14", 14 },
			{ "ROW_15", 15 },
			{ "ROW_16", 16 },
			{ "ROW_17", 17 },
			{ "ROW_18", 18 },
			{ "ROW_19", 19 },
			{ "ROW_20", 20 },
			{ "ROW_21", 21 },
			{ "ROW_22", 22 },
			{ "ROW_23", 23 },
			{ "ROW_24", 24 },
			{ "ROW_25", 25 },
			{ "ROW_26", 26 },
			{ "ROW_27", 27 },
			{ "ROW_28", 28 },
			{ "ROW_29", 29 },
			{ "ROW_30", 30 },
			{ "ROW_31", 31 },
			{ "ROW_32", 32 },
			{ "ROW_33", 33 },
			{ "ROW_34", 34 },
			{ "ROW_35", 35 },
			{ "ROW_36", 36 },
			{ "ROW_37", 37 },
			{ "ROW_38", 38 },
			{ "ROW_39", 39 },
			{ "ROW_40", 40 },
			{ "ROW_41", 41 },
			{ "ROW_42", 42 },
			{ "ROW_43", 43 }
		};

		public List<BalanceTableRow> Rows = new List<BalanceTableRow>();

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
				return 2;
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
			Rows.Add(new BalanceTableRow(input[0], input[1], input[2]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new BalanceTableRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 3)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new BalanceTableRow(input[0], input[1], input[2]));
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

		public BalanceTableRow GetRow(rowIds in_RowID)
		{
			BalanceTableRow result = null;
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

		public BalanceTableRow GetRow(string in_RowString)
		{
			BalanceTableRow result = null;
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
