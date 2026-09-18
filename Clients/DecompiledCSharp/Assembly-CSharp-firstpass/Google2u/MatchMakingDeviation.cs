using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class MatchMakingDeviation : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		Rank1,
		Rank2,
		Rank3,
		Rank4,
		Rank5,
		Rank6,
		Rank7,
		Rank8,
		Rank9,
		Rank10,
		Rank11,
		Rank12,
		Rank13,
		Rank14,
		Rank15,
		Rank16,
		Rank17,
		Rank18,
		Rank19,
		Rank20,
		Rank21,
		Rank22,
		Rank23,
		Rank24,
		Rank25,
		Rank26,
		Rank27,
		Rank28,
		Rank29,
		Rank30,
		Rank31,
		Rank32,
		Rank33,
		Rank34,
		Rank35,
		Rank36,
		Rank37,
		Rank38,
		Rank39,
		Rank40,
		Rank41,
		Rank42,
		Rank43,
		League1,
		League2,
		League3,
		League4,
		League5,
		League6,
		League7,
		League8,
		League9,
		League10,
		League11,
		League12,
		League13,
		League14,
		League15,
		League16,
		League17,
		League18,
		League19,
		League20,
		League21,
		League22,
		League23,
		League24,
		League25,
		League26,
		League27,
		League28,
		League29,
		League30,
		League31,
		League32,
		League33,
		League34,
		League35,
		League36,
		League37,
		League38,
		League39,
		League40,
		League41,
		League42,
		League43,
		Medals1,
		Medals2,
		Medals3,
		Medals4,
		Medals5,
		Medals6,
		Medals7,
		Medals8,
		Medals9,
		Medals10,
		Medals11,
		Medals12,
		Medals13,
		Medals14,
		Medals15,
		Medals16,
		Medals17,
		Medals18,
		Medals19,
		Medals20,
		Medals21,
		Medals22,
		Medals23,
		Medals24,
		Medals25,
		Medals26,
		Medals27,
		Medals28,
		Medals29,
		Medals30,
		Medals31,
		Medals32,
		Medals33,
		Medals34,
		Medals35,
		Medals36,
		Medals37,
		Medals38,
		Medals39,
		Medals40,
		Medals41,
		Medals42,
		Medals43,
		ArmyPower1,
		ArmyPower2,
		ArmyPower3,
		ArmyPower4,
		ArmyPower5,
		ArmyPower6,
		ArmyPower7,
		ArmyPower8,
		ArmyPower9,
		ArmyPower10,
		ArmyPower11,
		ArmyPower12,
		ArmyPower13,
		ArmyPower14,
		ArmyPower15,
		ArmyPower16,
		ArmyPower17,
		ArmyPower18,
		ArmyPower19,
		ArmyPower20,
		ArmyPower21,
		ArmyPower22,
		ArmyPower23,
		ArmyPower24,
		ArmyPower25,
		ArmyPower26,
		ArmyPower27,
		ArmyPower28,
		ArmyPower29,
		ArmyPower30,
		ArmyPower31,
		ArmyPower32,
		ArmyPower33,
		ArmyPower34,
		ArmyPower35,
		ArmyPower36,
		ArmyPower37,
		ArmyPower38,
		ArmyPower39,
		ArmyPower40,
		ArmyPower41,
		ArmyPower42,
		ArmyPower43,
		winLooseStreak1,
		winLooseStreak2,
		winLooseStreak3,
		winLooseStreak4,
		winLooseStreak5,
		winLooseStreak6,
		winLooseStreak7,
		winLooseStreak8,
		winLooseStreak9,
		winLooseStreak10,
		winLooseStreak11,
		winLooseStreak12,
		winLooseStreak13,
		winLooseStreak14,
		winLooseStreak15,
		winLooseStreak16,
		winLooseStreak17,
		winLooseStreak18,
		winLooseStreak19,
		winLooseStreak20,
		winLooseStreak21,
		winLooseStreak22,
		winLooseStreak23,
		winLooseStreak24,
		winLooseStreak25,
		winLooseStreak26,
		winLooseStreak27,
		winLooseStreak28,
		winLooseStreak29,
		winLooseStreak30,
		winLooseStreak31,
		winLooseStreak32,
		winLooseStreak33,
		winLooseStreak34,
		winLooseStreak35,
		winLooseStreak36,
		winLooseStreak37,
		winLooseStreak38,
		winLooseStreak39,
		winLooseStreak40,
		winLooseStreak41,
		winLooseStreak42,
		winLooseStreak43
	}

	public string[] rowNames = new string[215]
	{
		"Rank1", "Rank2", "Rank3", "Rank4", "Rank5", "Rank6", "Rank7", "Rank8", "Rank9", "Rank10",
		"Rank11", "Rank12", "Rank13", "Rank14", "Rank15", "Rank16", "Rank17", "Rank18", "Rank19", "Rank20",
		"Rank21", "Rank22", "Rank23", "Rank24", "Rank25", "Rank26", "Rank27", "Rank28", "Rank29", "Rank30",
		"Rank31", "Rank32", "Rank33", "Rank34", "Rank35", "Rank36", "Rank37", "Rank38", "Rank39", "Rank40",
		"Rank41", "Rank42", "Rank43", "League1", "League2", "League3", "League4", "League5", "League6", "League7",
		"League8", "League9", "League10", "League11", "League12", "League13", "League14", "League15", "League16", "League17",
		"League18", "League19", "League20", "League21", "League22", "League23", "League24", "League25", "League26", "League27",
		"League28", "League29", "League30", "League31", "League32", "League33", "League34", "League35", "League36", "League37",
		"League38", "League39", "League40", "League41", "League42", "League43", "Medals1", "Medals2", "Medals3", "Medals4",
		"Medals5", "Medals6", "Medals7", "Medals8", "Medals9", "Medals10", "Medals11", "Medals12", "Medals13", "Medals14",
		"Medals15", "Medals16", "Medals17", "Medals18", "Medals19", "Medals20", "Medals21", "Medals22", "Medals23", "Medals24",
		"Medals25", "Medals26", "Medals27", "Medals28", "Medals29", "Medals30", "Medals31", "Medals32", "Medals33", "Medals34",
		"Medals35", "Medals36", "Medals37", "Medals38", "Medals39", "Medals40", "Medals41", "Medals42", "Medals43", "ArmyPower1",
		"ArmyPower2", "ArmyPower3", "ArmyPower4", "ArmyPower5", "ArmyPower6", "ArmyPower7", "ArmyPower8", "ArmyPower9", "ArmyPower10", "ArmyPower11",
		"ArmyPower12", "ArmyPower13", "ArmyPower14", "ArmyPower15", "ArmyPower16", "ArmyPower17", "ArmyPower18", "ArmyPower19", "ArmyPower20", "ArmyPower21",
		"ArmyPower22", "ArmyPower23", "ArmyPower24", "ArmyPower25", "ArmyPower26", "ArmyPower27", "ArmyPower28", "ArmyPower29", "ArmyPower30", "ArmyPower31",
		"ArmyPower32", "ArmyPower33", "ArmyPower34", "ArmyPower35", "ArmyPower36", "ArmyPower37", "ArmyPower38", "ArmyPower39", "ArmyPower40", "ArmyPower41",
		"ArmyPower42", "ArmyPower43", "winLooseStreak1", "winLooseStreak2", "winLooseStreak3", "winLooseStreak4", "winLooseStreak5", "winLooseStreak6", "winLooseStreak7", "winLooseStreak8",
		"winLooseStreak9", "winLooseStreak10", "winLooseStreak11", "winLooseStreak12", "winLooseStreak13", "winLooseStreak14", "winLooseStreak15", "winLooseStreak16", "winLooseStreak17", "winLooseStreak18",
		"winLooseStreak19", "winLooseStreak20", "winLooseStreak21", "winLooseStreak22", "winLooseStreak23", "winLooseStreak24", "winLooseStreak25", "winLooseStreak26", "winLooseStreak27", "winLooseStreak28",
		"winLooseStreak29", "winLooseStreak30", "winLooseStreak31", "winLooseStreak32", "winLooseStreak33", "winLooseStreak34", "winLooseStreak35", "winLooseStreak36", "winLooseStreak37", "winLooseStreak38",
		"winLooseStreak39", "winLooseStreak40", "winLooseStreak41", "winLooseStreak42", "winLooseStreak43"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "Rank1", 0 },
		{ "Rank2", 1 },
		{ "Rank3", 2 },
		{ "Rank4", 3 },
		{ "Rank5", 4 },
		{ "Rank6", 5 },
		{ "Rank7", 6 },
		{ "Rank8", 7 },
		{ "Rank9", 8 },
		{ "Rank10", 9 },
		{ "Rank11", 10 },
		{ "Rank12", 11 },
		{ "Rank13", 12 },
		{ "Rank14", 13 },
		{ "Rank15", 14 },
		{ "Rank16", 15 },
		{ "Rank17", 16 },
		{ "Rank18", 17 },
		{ "Rank19", 18 },
		{ "Rank20", 19 },
		{ "Rank21", 20 },
		{ "Rank22", 21 },
		{ "Rank23", 22 },
		{ "Rank24", 23 },
		{ "Rank25", 24 },
		{ "Rank26", 25 },
		{ "Rank27", 26 },
		{ "Rank28", 27 },
		{ "Rank29", 28 },
		{ "Rank30", 29 },
		{ "Rank31", 30 },
		{ "Rank32", 31 },
		{ "Rank33", 32 },
		{ "Rank34", 33 },
		{ "Rank35", 34 },
		{ "Rank36", 35 },
		{ "Rank37", 36 },
		{ "Rank38", 37 },
		{ "Rank39", 38 },
		{ "Rank40", 39 },
		{ "Rank41", 40 },
		{ "Rank42", 41 },
		{ "Rank43", 42 },
		{ "League1", 43 },
		{ "League2", 44 },
		{ "League3", 45 },
		{ "League4", 46 },
		{ "League5", 47 },
		{ "League6", 48 },
		{ "League7", 49 },
		{ "League8", 50 },
		{ "League9", 51 },
		{ "League10", 52 },
		{ "League11", 53 },
		{ "League12", 54 },
		{ "League13", 55 },
		{ "League14", 56 },
		{ "League15", 57 },
		{ "League16", 58 },
		{ "League17", 59 },
		{ "League18", 60 },
		{ "League19", 61 },
		{ "League20", 62 },
		{ "League21", 63 },
		{ "League22", 64 },
		{ "League23", 65 },
		{ "League24", 66 },
		{ "League25", 67 },
		{ "League26", 68 },
		{ "League27", 69 },
		{ "League28", 70 },
		{ "League29", 71 },
		{ "League30", 72 },
		{ "League31", 73 },
		{ "League32", 74 },
		{ "League33", 75 },
		{ "League34", 76 },
		{ "League35", 77 },
		{ "League36", 78 },
		{ "League37", 79 },
		{ "League38", 80 },
		{ "League39", 81 },
		{ "League40", 82 },
		{ "League41", 83 },
		{ "League42", 84 },
		{ "League43", 85 },
		{ "Medals1", 86 },
		{ "Medals2", 87 },
		{ "Medals3", 88 },
		{ "Medals4", 89 },
		{ "Medals5", 90 },
		{ "Medals6", 91 },
		{ "Medals7", 92 },
		{ "Medals8", 93 },
		{ "Medals9", 94 },
		{ "Medals10", 95 },
		{ "Medals11", 96 },
		{ "Medals12", 97 },
		{ "Medals13", 98 },
		{ "Medals14", 99 },
		{ "Medals15", 100 },
		{ "Medals16", 101 },
		{ "Medals17", 102 },
		{ "Medals18", 103 },
		{ "Medals19", 104 },
		{ "Medals20", 105 },
		{ "Medals21", 106 },
		{ "Medals22", 107 },
		{ "Medals23", 108 },
		{ "Medals24", 109 },
		{ "Medals25", 110 },
		{ "Medals26", 111 },
		{ "Medals27", 112 },
		{ "Medals28", 113 },
		{ "Medals29", 114 },
		{ "Medals30", 115 },
		{ "Medals31", 116 },
		{ "Medals32", 117 },
		{ "Medals33", 118 },
		{ "Medals34", 119 },
		{ "Medals35", 120 },
		{ "Medals36", 121 },
		{ "Medals37", 122 },
		{ "Medals38", 123 },
		{ "Medals39", 124 },
		{ "Medals40", 125 },
		{ "Medals41", 126 },
		{ "Medals42", 127 },
		{ "Medals43", 128 },
		{ "ArmyPower1", 129 },
		{ "ArmyPower2", 130 },
		{ "ArmyPower3", 131 },
		{ "ArmyPower4", 132 },
		{ "ArmyPower5", 133 },
		{ "ArmyPower6", 134 },
		{ "ArmyPower7", 135 },
		{ "ArmyPower8", 136 },
		{ "ArmyPower9", 137 },
		{ "ArmyPower10", 138 },
		{ "ArmyPower11", 139 },
		{ "ArmyPower12", 140 },
		{ "ArmyPower13", 141 },
		{ "ArmyPower14", 142 },
		{ "ArmyPower15", 143 },
		{ "ArmyPower16", 144 },
		{ "ArmyPower17", 145 },
		{ "ArmyPower18", 146 },
		{ "ArmyPower19", 147 },
		{ "ArmyPower20", 148 },
		{ "ArmyPower21", 149 },
		{ "ArmyPower22", 150 },
		{ "ArmyPower23", 151 },
		{ "ArmyPower24", 152 },
		{ "ArmyPower25", 153 },
		{ "ArmyPower26", 154 },
		{ "ArmyPower27", 155 },
		{ "ArmyPower28", 156 },
		{ "ArmyPower29", 157 },
		{ "ArmyPower30", 158 },
		{ "ArmyPower31", 159 },
		{ "ArmyPower32", 160 },
		{ "ArmyPower33", 161 },
		{ "ArmyPower34", 162 },
		{ "ArmyPower35", 163 },
		{ "ArmyPower36", 164 },
		{ "ArmyPower37", 165 },
		{ "ArmyPower38", 166 },
		{ "ArmyPower39", 167 },
		{ "ArmyPower40", 168 },
		{ "ArmyPower41", 169 },
		{ "ArmyPower42", 170 },
		{ "ArmyPower43", 171 },
		{ "winLooseStreak1", 172 },
		{ "winLooseStreak2", 173 },
		{ "winLooseStreak3", 174 },
		{ "winLooseStreak4", 175 },
		{ "winLooseStreak5", 176 },
		{ "winLooseStreak6", 177 },
		{ "winLooseStreak7", 178 },
		{ "winLooseStreak8", 179 },
		{ "winLooseStreak9", 180 },
		{ "winLooseStreak10", 181 },
		{ "winLooseStreak11", 182 },
		{ "winLooseStreak12", 183 },
		{ "winLooseStreak13", 184 },
		{ "winLooseStreak14", 185 },
		{ "winLooseStreak15", 186 },
		{ "winLooseStreak16", 187 },
		{ "winLooseStreak17", 188 },
		{ "winLooseStreak18", 189 },
		{ "winLooseStreak19", 190 },
		{ "winLooseStreak20", 191 },
		{ "winLooseStreak21", 192 },
		{ "winLooseStreak22", 193 },
		{ "winLooseStreak23", 194 },
		{ "winLooseStreak24", 195 },
		{ "winLooseStreak25", 196 },
		{ "winLooseStreak26", 197 },
		{ "winLooseStreak27", 198 },
		{ "winLooseStreak28", 199 },
		{ "winLooseStreak29", 200 },
		{ "winLooseStreak30", 201 },
		{ "winLooseStreak31", 202 },
		{ "winLooseStreak32", 203 },
		{ "winLooseStreak33", 204 },
		{ "winLooseStreak34", 205 },
		{ "winLooseStreak35", 206 },
		{ "winLooseStreak36", 207 },
		{ "winLooseStreak37", 208 },
		{ "winLooseStreak38", 209 },
		{ "winLooseStreak39", 210 },
		{ "winLooseStreak40", 211 },
		{ "winLooseStreak41", 212 },
		{ "winLooseStreak42", 213 },
		{ "winLooseStreak43", 214 }
	};

	public List<MatchMakingDeviationRow> Rows = new List<MatchMakingDeviationRow>();

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
		Rows.Add(new MatchMakingDeviationRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new MatchMakingDeviationRow());
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
		Rows.Add(new MatchMakingDeviationRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
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

	public MatchMakingDeviationRow GetRow(rowIds in_RowID)
	{
		MatchMakingDeviationRow result = null;
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

	public MatchMakingDeviationRow GetRow(string in_RowString)
	{
		MatchMakingDeviationRow result = null;
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
