using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
public class Packs : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		starterpack,
		valuepack,
		moneypack1,
		lapsed_player_1,
		lapsed_player_2,
		lapsed_player_3,
		valuepackB,
		moneypack1B,
		starterpackB,
		testpack001,
		elitepack1,
		elitepack2,
		elitepack3,
		elitepack4,
		elitepack5,
		elitepack6,
		custompack1,
		veteranpack1,
		veteranpack2,
		veteranpack3,
		veteranpack4,
		veteranpack5
	}

	public string[] rowNames = new string[22]
	{
		"starterpack", "valuepack", "moneypack1", "lapsed_player_1", "lapsed_player_2", "lapsed_player_3", "valuepackB", "moneypack1B", "starterpackB", "testpack001",
		"elitepack1", "elitepack2", "elitepack3", "elitepack4", "elitepack5", "elitepack6", "custompack1", "veteranpack1", "veteranpack2", "veteranpack3",
		"veteranpack4", "veteranpack5"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "starterpack", 0 },
		{ "valuepack", 1 },
		{ "moneypack1", 2 },
		{ "lapsed_player_1", 3 },
		{ "lapsed_player_2", 4 },
		{ "lapsed_player_3", 5 },
		{ "valuepackB", 6 },
		{ "moneypack1B", 7 },
		{ "starterpackB", 8 },
		{ "testpack001", 9 },
		{ "elitepack1", 10 },
		{ "elitepack2", 11 },
		{ "elitepack3", 12 },
		{ "elitepack4", 13 },
		{ "elitepack5", 14 },
		{ "elitepack6", 15 },
		{ "custompack1", 16 },
		{ "veteranpack1", 17 },
		{ "veteranpack2", 18 },
		{ "veteranpack3", 19 },
		{ "veteranpack4", 20 },
		{ "veteranpack5", 21 }
	};

	public List<PacksRow> Rows = new List<PacksRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 15;

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
		Rows.Add(new PacksRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new PacksRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 16)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new PacksRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15]));
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

	public PacksRow GetRow(rowIds in_RowID)
	{
		PacksRow result = null;
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

	public PacksRow GetRow(string in_RowString)
	{
		PacksRow result = null;
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
