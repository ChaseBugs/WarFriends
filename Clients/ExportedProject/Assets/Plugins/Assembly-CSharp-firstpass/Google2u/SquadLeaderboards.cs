using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
public class SquadLeaderboards : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		Level8,
		Level7,
		Level6,
		Level5,
		Level4,
		Level3,
		Level2,
		Level1
	}

	public string[] rowNames = new string[8] { "Level8", "Level7", "Level6", "Level5", "Level4", "Level3", "Level2", "Level1" };

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "Level8", 0 },
		{ "Level7", 1 },
		{ "Level6", 2 },
		{ "Level5", 3 },
		{ "Level4", 4 },
		{ "Level3", 5 },
		{ "Level2", 6 },
		{ "Level1", 7 }
	};

	public List<SquadLeaderboardsRow> Rows = new List<SquadLeaderboardsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 8;

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
		Rows.Add(new SquadLeaderboardsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new SquadLeaderboardsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 9)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new SquadLeaderboardsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8]));
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

	public SquadLeaderboardsRow GetRow(rowIds in_RowID)
	{
		SquadLeaderboardsRow result = null;
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

	public SquadLeaderboardsRow GetRow(string in_RowString)
	{
		SquadLeaderboardsRow result = null;
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
