using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class PlayerBots : Google2uComponentBase, IGoogle2uDB
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
		ID_49,
		ID_50,
		ID_51,
		ID_52,
		ID_53,
		ID_54,
		ID_55,
		ID_56,
		ID_57,
		ID_58,
		ID_59,
		ID_60,
		ID_61,
		ID_62,
		ID_63,
		ID_64
	}

	public string[] rowNames = new string[64]
	{
		"ID_1", "ID_2", "ID_3", "ID_4", "ID_5", "ID_6", "ID_7", "ID_8", "ID_9", "ID_10",
		"ID_11", "ID_12", "ID_13", "ID_14", "ID_15", "ID_16", "ID_17", "ID_18", "ID_19", "ID_20",
		"ID_21", "ID_22", "ID_23", "ID_24", "ID_25", "ID_26", "ID_27", "ID_28", "ID_29", "ID_30",
		"ID_31", "ID_32", "ID_33", "ID_34", "ID_35", "ID_36", "ID_37", "ID_38", "ID_39", "ID_40",
		"ID_41", "ID_42", "ID_43", "ID_44", "ID_45", "ID_46", "ID_47", "ID_48", "ID_49", "ID_50",
		"ID_51", "ID_52", "ID_53", "ID_54", "ID_55", "ID_56", "ID_57", "ID_58", "ID_59", "ID_60",
		"ID_61", "ID_62", "ID_63", "ID_64"
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
		{ "ID_27", 26 },
		{ "ID_28", 27 },
		{ "ID_29", 28 },
		{ "ID_30", 29 },
		{ "ID_31", 30 },
		{ "ID_32", 31 },
		{ "ID_33", 32 },
		{ "ID_34", 33 },
		{ "ID_35", 34 },
		{ "ID_36", 35 },
		{ "ID_37", 36 },
		{ "ID_38", 37 },
		{ "ID_39", 38 },
		{ "ID_40", 39 },
		{ "ID_41", 40 },
		{ "ID_42", 41 },
		{ "ID_43", 42 },
		{ "ID_44", 43 },
		{ "ID_45", 44 },
		{ "ID_46", 45 },
		{ "ID_47", 46 },
		{ "ID_48", 47 },
		{ "ID_49", 48 },
		{ "ID_50", 49 },
		{ "ID_51", 50 },
		{ "ID_52", 51 },
		{ "ID_53", 52 },
		{ "ID_54", 53 },
		{ "ID_55", 54 },
		{ "ID_56", 55 },
		{ "ID_57", 56 },
		{ "ID_58", 57 },
		{ "ID_59", 58 },
		{ "ID_60", 59 },
		{ "ID_61", 60 },
		{ "ID_62", 61 },
		{ "ID_63", 62 },
		{ "ID_64", 63 }
	};

	public List<PlayerBotsRow> Rows = new List<PlayerBotsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 9;

	public override int GetRowIndex(string rowID)
	{
		if (namesToIndex.ContainsKey(rowID))
		{
			return namesToIndex[rowID];
		}
		return -1;
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public override void AddRowGeneric(List<string> input)
	{
		Rows.Add(new PlayerBotsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new PlayerBotsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 10)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new PlayerBotsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]));
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

	public PlayerBotsRow GetRow(rowIds in_RowID)
	{
		PlayerBotsRow result = null;
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

	public PlayerBotsRow GetRow(string in_RowString)
	{
		PlayerBotsRow result = null;
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
