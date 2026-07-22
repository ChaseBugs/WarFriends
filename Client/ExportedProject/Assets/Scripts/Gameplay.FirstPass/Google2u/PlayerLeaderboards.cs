using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class PlayerLeaderboards : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			Bronze3,
			Bronze2,
			Bronze1,
			Silver3,
			Silver2,
			Silver1,
			Gold3,
			Gold2,
			Gold1,
			Elite3,
			Elite2,
			Elite1,
			Master3,
			Master2,
			Master1,
			Champion
		}

		public string[] rowNames = new string[16]
		{
			"Bronze3", "Bronze2", "Bronze1", "Silver3", "Silver2", "Silver1", "Gold3", "Gold2", "Gold1", "Elite3",
			"Elite2", "Elite1", "Master3", "Master2", "Master1", "Champion"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "Bronze3", 0 },
			{ "Bronze2", 1 },
			{ "Bronze1", 2 },
			{ "Silver3", 3 },
			{ "Silver2", 4 },
			{ "Silver1", 5 },
			{ "Gold3", 6 },
			{ "Gold2", 7 },
			{ "Gold1", 8 },
			{ "Elite3", 9 },
			{ "Elite2", 10 },
			{ "Elite1", 11 },
			{ "Master3", 12 },
			{ "Master2", 13 },
			{ "Master1", 14 },
			{ "Champion", 15 }
		};

		public List<PlayerLeaderboardsRow> Rows = new List<PlayerLeaderboardsRow>();

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
			Rows.Add(new PlayerLeaderboardsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new PlayerLeaderboardsRow());
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
			Rows.Add(new PlayerLeaderboardsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
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

		public PlayerLeaderboardsRow GetRow(rowIds in_RowID)
		{
			PlayerLeaderboardsRow result = null;
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

		public PlayerLeaderboardsRow GetRow(string in_RowString)
		{
			PlayerLeaderboardsRow result = null;
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
