using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class Squads : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_0,
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
			ID_27,
			ID_28,
			ID_29,
			ID_30,
			ID_31,
			ID_32,
			ID_33,
			ID_34,
			ID_35,
			ID_36,
			ID_37,
			ID_38,
			ID_39,
			ID_40,
			ID_41,
			ID_42,
			ID_43,
			ID_44,
			ID_45,
			ID_46,
			ID_47,
			ID_48,
			ID_49
		}

		public string[] rowNames = new string[50]
		{
			"ID_0", "ID_1", "ID_2", "ID_3", "ID_4", "ID_5", "ID_6", "ID_7", "ID_8", "ID_9",
			"ID_10", "ID_11", "ID_12", "ID_13", "ID_14", "ID_15", "ID_16", "ID_17", "ID_18", "ID_19",
			"ID_20", "ID_21", "ID_22", "ID_23", "ID_24", "ID_25", "ID_26", "ID_27", "ID_28", "ID_29",
			"ID_30", "ID_31", "ID_32", "ID_33", "ID_34", "ID_35", "ID_36", "ID_37", "ID_38", "ID_39",
			"ID_40", "ID_41", "ID_42", "ID_43", "ID_44", "ID_45", "ID_46", "ID_47", "ID_48", "ID_49"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ID_0", 0 },
			{ "ID_1", 1 },
			{ "ID_2", 2 },
			{ "ID_3", 3 },
			{ "ID_4", 4 },
			{ "ID_5", 5 },
			{ "ID_6", 6 },
			{ "ID_7", 7 },
			{ "ID_8", 8 },
			{ "ID_9", 9 },
			{ "ID_10", 10 },
			{ "ID_11", 11 },
			{ "ID_12", 12 },
			{ "ID_13", 13 },
			{ "ID_14", 14 },
			{ "ID_15", 15 },
			{ "ID_16", 16 },
			{ "ID_17", 17 },
			{ "ID_18", 18 },
			{ "ID_19", 19 },
			{ "ID_20", 20 },
			{ "ID_21", 21 },
			{ "ID_22", 22 },
			{ "ID_23", 23 },
			{ "ID_24", 24 },
			{ "ID_25", 25 },
			{ "ID_26", 26 },
			{ "ID_27", 27 },
			{ "ID_28", 28 },
			{ "ID_29", 29 },
			{ "ID_30", 30 },
			{ "ID_31", 31 },
			{ "ID_32", 32 },
			{ "ID_33", 33 },
			{ "ID_34", 34 },
			{ "ID_35", 35 },
			{ "ID_36", 36 },
			{ "ID_37", 37 },
			{ "ID_38", 38 },
			{ "ID_39", 39 },
			{ "ID_40", 40 },
			{ "ID_41", 41 },
			{ "ID_42", 42 },
			{ "ID_43", 43 },
			{ "ID_44", 44 },
			{ "ID_45", 45 },
			{ "ID_46", 46 },
			{ "ID_47", 47 },
			{ "ID_48", 48 },
			{ "ID_49", 49 }
		};

		public List<SquadsRow> Rows = new List<SquadsRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 5;

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
			Rows.Add(new SquadsRow(input[0], input[1], input[2], input[3], input[4], input[5]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new SquadsRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 6)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new SquadsRow(input[0], input[1], input[2], input[3], input[4], input[5]));
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

		public SquadsRow GetRow(rowIds in_RowID)
		{
			SquadsRow result = null;
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

		public SquadsRow GetRow(string in_RowString)
		{
			SquadsRow result = null;
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
