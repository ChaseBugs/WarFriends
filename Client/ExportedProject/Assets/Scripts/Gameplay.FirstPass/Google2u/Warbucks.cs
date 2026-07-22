using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class Warbucks : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			warbucks1,
			warbucks2,
			warbucks3,
			warbucks4,
			warbucks5,
			warbucks6,
			bwarbucks1,
			bwarbucks2,
			bwarbucks3,
			bwarbucks4,
			bwarbucks5,
			bwarbucks6
		}

		public string[] rowNames = new string[12]
		{
			"warbucks1", "warbucks2", "warbucks3", "warbucks4", "warbucks5", "warbucks6", "bwarbucks1", "bwarbucks2", "bwarbucks3", "bwarbucks4",
			"bwarbucks5", "bwarbucks6"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "warbucks1", 0 },
			{ "warbucks2", 1 },
			{ "warbucks3", 2 },
			{ "warbucks4", 3 },
			{ "warbucks5", 4 },
			{ "warbucks6", 5 },
			{ "bwarbucks1", 6 },
			{ "bwarbucks2", 7 },
			{ "bwarbucks3", 8 },
			{ "bwarbucks4", 9 },
			{ "bwarbucks5", 10 },
			{ "bwarbucks6", 11 }
		};

		public List<WarbucksRow> Rows = new List<WarbucksRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 3;

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
			Rows.Add(new WarbucksRow(input[0], input[1], input[2], input[3]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new WarbucksRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 4)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new WarbucksRow(input[0], input[1], input[2], input[3]));
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

		public WarbucksRow GetRow(rowIds in_RowID)
		{
			WarbucksRow result = null;
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

		public WarbucksRow GetRow(string in_RowString)
		{
			WarbucksRow result = null;
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
