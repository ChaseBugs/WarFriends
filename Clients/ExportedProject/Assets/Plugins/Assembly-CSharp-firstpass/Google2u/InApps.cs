using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
public class InApps : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		gold1,
		gold2,
		gold3,
		gold4,
		gold5,
		gold6,
		warbucks1,
		warbucks2,
		warbucks3,
		warbucks4,
		warbucks5,
		warbucks6,
		valuepack,
		starterpack,
		moneypack1,
		valuepackB,
		moneypack1B,
		starterpackB,
		testpack001,
		bgold1,
		bgold2,
		bgold3,
		bgold4,
		bgold5,
		bgold6,
		bwarbucks1,
		bwarbucks2,
		bwarbucks3,
		bwarbucks4,
		bwarbucks5,
		bwarbucks6,
		gold7daily1,
		bgold7daily1,
		elitepack1,
		elitepack2,
		elitepack3,
		elitepack4,
		elitepack5,
		elitepack6
	}

	public string[] rowNames = new string[39]
	{
		"gold1", "gold2", "gold3", "gold4", "gold5", "gold6", "warbucks1", "warbucks2", "warbucks3", "warbucks4",
		"warbucks5", "warbucks6", "valuepack", "starterpack", "moneypack1", "valuepackB", "moneypack1B", "starterpackB", "testpack001", "bgold1",
		"bgold2", "bgold3", "bgold4", "bgold5", "bgold6", "bwarbucks1", "bwarbucks2", "bwarbucks3", "bwarbucks4", "bwarbucks5",
		"bwarbucks6", "gold7daily1", "bgold7daily1", "elitepack1", "elitepack2", "elitepack3", "elitepack4", "elitepack5", "elitepack6"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "gold1", 0 },
		{ "gold2", 1 },
		{ "gold3", 2 },
		{ "gold4", 3 },
		{ "gold5", 4 },
		{ "gold6", 5 },
		{ "warbucks1", 6 },
		{ "warbucks2", 7 },
		{ "warbucks3", 8 },
		{ "warbucks4", 9 },
		{ "warbucks5", 10 },
		{ "warbucks6", 11 },
		{ "valuepack", 12 },
		{ "starterpack", 13 },
		{ "moneypack1", 14 },
		{ "valuepackB", 15 },
		{ "moneypack1B", 16 },
		{ "starterpackB", 17 },
		{ "testpack001", 18 },
		{ "bgold1", 19 },
		{ "bgold2", 20 },
		{ "bgold3", 21 },
		{ "bgold4", 22 },
		{ "bgold5", 23 },
		{ "bgold6", 24 },
		{ "bwarbucks1", 25 },
		{ "bwarbucks2", 26 },
		{ "bwarbucks3", 27 },
		{ "bwarbucks4", 28 },
		{ "bwarbucks5", 29 },
		{ "bwarbucks6", 30 },
		{ "gold7daily1", 31 },
		{ "bgold7daily1", 32 },
		{ "elitepack1", 33 },
		{ "elitepack2", 34 },
		{ "elitepack3", 35 },
		{ "elitepack4", 36 },
		{ "elitepack5", 37 },
		{ "elitepack6", 38 }
	};

	public List<InAppsRow> Rows = new List<InAppsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 4;

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
		Rows.Add(new InAppsRow(input[0], input[1], input[2], input[3], input[4]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new InAppsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 5)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new InAppsRow(input[0], input[1], input[2], input[3], input[4]));
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

	public InAppsRow GetRow(rowIds in_RowID)
	{
		InAppsRow result = null;
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

	public InAppsRow GetRow(string in_RowString)
	{
		InAppsRow result = null;
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
