using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class Bazooka_RPG7BM : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ROW_1,
			ROW_2,
			ROW_3,
			ROW_4,
			ROW_5,
			ROW_6,
			ROW_7,
			ROW_8,
			ROW_9,
			ROW_10,
			ROW_11,
			ROW_12,
			ROW_13,
			ROW_14,
			ROW_15,
			ROW_16,
			ROW_17,
			ROW_18,
			ROW_19,
			ROW_20,
			ROW_21,
			ROW_22,
			ROW_23,
			ROW_24,
			ROW_25,
			WARARENA
		}

		public string[] rowNames = new string[26]
		{
			"ROW_1", "ROW_2", "ROW_3", "ROW_4", "ROW_5", "ROW_6", "ROW_7", "ROW_8", "ROW_9", "ROW_10",
			"ROW_11", "ROW_12", "ROW_13", "ROW_14", "ROW_15", "ROW_16", "ROW_17", "ROW_18", "ROW_19", "ROW_20",
			"ROW_21", "ROW_22", "ROW_23", "ROW_24", "ROW_25", "WARARENA"
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
			{ "WARARENA", 25 }
		};

		public List<Bazooka_RPG7BMRow> Rows = new List<Bazooka_RPG7BMRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 10;

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
			Rows.Add(new Bazooka_RPG7BMRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new Bazooka_RPG7BMRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 11)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new Bazooka_RPG7BMRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
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

		public Bazooka_RPG7BMRow GetRow(rowIds in_RowID)
		{
			Bazooka_RPG7BMRow result = null;
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

		public Bazooka_RPG7BMRow GetRow(string in_RowString)
		{
			Bazooka_RPG7BMRow result = null;
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
