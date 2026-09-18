using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class SquadEmblems : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		menu_squad_1,
		menu_squad_2,
		menu_squad_3,
		menu_squad_4,
		menu_squad_5,
		menu_squad_6,
		menu_squad_7,
		menu_squad_8,
		menu_squad_9,
		menu_squad_10,
		menu_squad_11,
		menu_squad_12,
		menu_squad_13,
		menu_squad_14,
		menu_squad_15,
		menu_squad_16,
		menu_squad_17,
		menu_squad_18,
		menu_squad_19,
		menu_squad_20,
		menu_squad_21,
		menu_squad_22,
		menu_squad_23,
		menu_squad_24,
		menu_squad_25,
		menu_squad_26,
		menu_squad_27,
		menu_squad_28,
		menu_squad_29,
		menu_squad_30,
		menu_squad_31,
		menu_squad_32,
		menu_squad_33,
		menu_squad_34,
		menu_squad_35,
		menu_squad_36,
		country_argentinia,
		country_australia,
		country_austria,
		country_belarus,
		country_belgium,
		country_brazil,
		country_bulgaria,
		country_canada,
		country_chile,
		country_china,
		country_croatia,
		country_czech_republic,
		country_danmark,
		country_egypt,
		country_england,
		country_estonia,
		country_finland,
		country_france,
		country_germany,
		country_greece,
		country_hong_kong,
		country_hungaria,
		country_india,
		country_indonesia,
		country_ireland,
		country_israel,
		country_italy,
		country_japan,
		country_latvia,
		country_lithuania,
		country_malaysia,
		country_mexico,
		country_netherlands,
		country_new_zealand,
		country_norway,
		country_philippines,
		country_poland,
		country_portugal,
		country_romania,
		country_russia,
		country_saudi_arabia,
		country_slovakia,
		country_slovenia,
		country_south_africa,
		country_south_korea,
		country_spain,
		country_sweden,
		country_switzerland,
		country_taiwan,
		country_thailand,
		country_turkey,
		country_ukraine,
		country_united_kingdom,
		country_usa,
		country_vietnam
	}

	public string[] rowNames = new string[91]
	{
		"menu_squad_1", "menu_squad_2", "menu_squad_3", "menu_squad_4", "menu_squad_5", "menu_squad_6", "menu_squad_7", "menu_squad_8", "menu_squad_9", "menu_squad_10",
		"menu_squad_11", "menu_squad_12", "menu_squad_13", "menu_squad_14", "menu_squad_15", "menu_squad_16", "menu_squad_17", "menu_squad_18", "menu_squad_19", "menu_squad_20",
		"menu_squad_21", "menu_squad_22", "menu_squad_23", "menu_squad_24", "menu_squad_25", "menu_squad_26", "menu_squad_27", "menu_squad_28", "menu_squad_29", "menu_squad_30",
		"menu_squad_31", "menu_squad_32", "menu_squad_33", "menu_squad_34", "menu_squad_35", "menu_squad_36", "country_argentinia", "country_australia", "country_austria", "country_belarus",
		"country_belgium", "country_brazil", "country_bulgaria", "country_canada", "country_chile", "country_china", "country_croatia", "country_czech_republic", "country_danmark", "country_egypt",
		"country_england", "country_estonia", "country_finland", "country_france", "country_germany", "country_greece", "country_hong_kong", "country_hungaria", "country_india", "country_indonesia",
		"country_ireland", "country_israel", "country_italy", "country_japan", "country_latvia", "country_lithuania", "country_malaysia", "country_mexico", "country_netherlands", "country_new_zealand",
		"country_norway", "country_philippines", "country_poland", "country_portugal", "country_romania", "country_russia", "country_saudi_arabia", "country_slovakia", "country_slovenia", "country_south_africa",
		"country_south_korea", "country_spain", "country_sweden", "country_switzerland", "country_taiwan", "country_thailand", "country_turkey", "country_ukraine", "country_united_kingdom", "country_usa",
		"country_vietnam"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "menu_squad_1", 0 },
		{ "menu_squad_2", 1 },
		{ "menu_squad_3", 2 },
		{ "menu_squad_4", 3 },
		{ "menu_squad_5", 4 },
		{ "menu_squad_6", 5 },
		{ "menu_squad_7", 6 },
		{ "menu_squad_8", 7 },
		{ "menu_squad_9", 8 },
		{ "menu_squad_10", 9 },
		{ "menu_squad_11", 10 },
		{ "menu_squad_12", 11 },
		{ "menu_squad_13", 12 },
		{ "menu_squad_14", 13 },
		{ "menu_squad_15", 14 },
		{ "menu_squad_16", 15 },
		{ "menu_squad_17", 16 },
		{ "menu_squad_18", 17 },
		{ "menu_squad_19", 18 },
		{ "menu_squad_20", 19 },
		{ "menu_squad_21", 20 },
		{ "menu_squad_22", 21 },
		{ "menu_squad_23", 22 },
		{ "menu_squad_24", 23 },
		{ "menu_squad_25", 24 },
		{ "menu_squad_26", 25 },
		{ "menu_squad_27", 26 },
		{ "menu_squad_28", 27 },
		{ "menu_squad_29", 28 },
		{ "menu_squad_30", 29 },
		{ "menu_squad_31", 30 },
		{ "menu_squad_32", 31 },
		{ "menu_squad_33", 32 },
		{ "menu_squad_34", 33 },
		{ "menu_squad_35", 34 },
		{ "menu_squad_36", 35 },
		{ "country_argentinia", 36 },
		{ "country_australia", 37 },
		{ "country_austria", 38 },
		{ "country_belarus", 39 },
		{ "country_belgium", 40 },
		{ "country_brazil", 41 },
		{ "country_bulgaria", 42 },
		{ "country_canada", 43 },
		{ "country_chile", 44 },
		{ "country_china", 45 },
		{ "country_croatia", 46 },
		{ "country_czech_republic", 47 },
		{ "country_danmark", 48 },
		{ "country_egypt", 49 },
		{ "country_england", 50 },
		{ "country_estonia", 51 },
		{ "country_finland", 52 },
		{ "country_france", 53 },
		{ "country_germany", 54 },
		{ "country_greece", 55 },
		{ "country_hong_kong", 56 },
		{ "country_hungaria", 57 },
		{ "country_india", 58 },
		{ "country_indonesia", 59 },
		{ "country_ireland", 60 },
		{ "country_israel", 61 },
		{ "country_italy", 62 },
		{ "country_japan", 63 },
		{ "country_latvia", 64 },
		{ "country_lithuania", 65 },
		{ "country_malaysia", 66 },
		{ "country_mexico", 67 },
		{ "country_netherlands", 68 },
		{ "country_new_zealand", 69 },
		{ "country_norway", 70 },
		{ "country_philippines", 71 },
		{ "country_poland", 72 },
		{ "country_portugal", 73 },
		{ "country_romania", 74 },
		{ "country_russia", 75 },
		{ "country_saudi_arabia", 76 },
		{ "country_slovakia", 77 },
		{ "country_slovenia", 78 },
		{ "country_south_africa", 79 },
		{ "country_south_korea", 80 },
		{ "country_spain", 81 },
		{ "country_sweden", 82 },
		{ "country_switzerland", 83 },
		{ "country_taiwan", 84 },
		{ "country_thailand", 85 },
		{ "country_turkey", 86 },
		{ "country_ukraine", 87 },
		{ "country_united_kingdom", 88 },
		{ "country_usa", 89 },
		{ "country_vietnam", 90 }
	};

	public List<SquadEmblemsRow> Rows = new List<SquadEmblemsRow>();

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
		Rows.Add(new SquadEmblemsRow(input[0], input[1], input[2], input[3]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new SquadEmblemsRow());
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
		Rows.Add(new SquadEmblemsRow(input[0], input[1], input[2], input[3]));
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

	public SquadEmblemsRow GetRow(rowIds in_RowID)
	{
		SquadEmblemsRow result = null;
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

	public SquadEmblemsRow GetRow(string in_RowString)
	{
		SquadEmblemsRow result = null;
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
