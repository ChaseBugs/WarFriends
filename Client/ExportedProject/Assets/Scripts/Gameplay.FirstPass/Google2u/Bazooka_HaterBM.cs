using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class Bazooka_HaterBM : Google2uComponentBase, IGoogle2uDB
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
			ROW_26,
			ROW_27,
			ROW_28,
			ROW_29,
			ROW_30,
			ROW_31,
			ROW_32,
			ROW_33,
			ROW_34,
			ROW_35,
			ROW_36,
			ROW_37,
			ROW_38,
			ROW_39,
			ROW_40,
			ROW_41,
			ROW_42,
			ROW_43,
			ROW_44,
			ROW_45,
			ROW_46,
			ROW_47,
			ROW_48,
			ROW_49,
			ROW_50,
			ROW_51,
			ROW_52,
			ROW_53,
			ROW_54,
			ROW_55,
			ROW_56,
			ROW_57,
			ROW_58,
			ROW_59,
			ROW_60,
			ROW_61,
			ROW_62,
			ROW_63,
			ROW_64,
			ROW_65,
			ROW_66,
			ROW_67,
			ROW_68,
			ROW_69,
			ROW_70,
			ROW_71,
			ROW_72,
			ROW_73,
			ROW_74,
			ROW_75,
			WARARENA
		}

		public string[] rowNames = new string[76]
		{
			"ROW_1", "ROW_2", "ROW_3", "ROW_4", "ROW_5", "ROW_6", "ROW_7", "ROW_8", "ROW_9", "ROW_10",
			"ROW_11", "ROW_12", "ROW_13", "ROW_14", "ROW_15", "ROW_16", "ROW_17", "ROW_18", "ROW_19", "ROW_20",
			"ROW_21", "ROW_22", "ROW_23", "ROW_24", "ROW_25", "ROW_26", "ROW_27", "ROW_28", "ROW_29", "ROW_30",
			"ROW_31", "ROW_32", "ROW_33", "ROW_34", "ROW_35", "ROW_36", "ROW_37", "ROW_38", "ROW_39", "ROW_40",
			"ROW_41", "ROW_42", "ROW_43", "ROW_44", "ROW_45", "ROW_46", "ROW_47", "ROW_48", "ROW_49", "ROW_50",
			"ROW_51", "ROW_52", "ROW_53", "ROW_54", "ROW_55", "ROW_56", "ROW_57", "ROW_58", "ROW_59", "ROW_60",
			"ROW_61", "ROW_62", "ROW_63", "ROW_64", "ROW_65", "ROW_66", "ROW_67", "ROW_68", "ROW_69", "ROW_70",
			"ROW_71", "ROW_72", "ROW_73", "ROW_74", "ROW_75", "WARARENA"
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
			{ "ROW_26", 25 },
			{ "ROW_27", 26 },
			{ "ROW_28", 27 },
			{ "ROW_29", 28 },
			{ "ROW_30", 29 },
			{ "ROW_31", 30 },
			{ "ROW_32", 31 },
			{ "ROW_33", 32 },
			{ "ROW_34", 33 },
			{ "ROW_35", 34 },
			{ "ROW_36", 35 },
			{ "ROW_37", 36 },
			{ "ROW_38", 37 },
			{ "ROW_39", 38 },
			{ "ROW_40", 39 },
			{ "ROW_41", 40 },
			{ "ROW_42", 41 },
			{ "ROW_43", 42 },
			{ "ROW_44", 43 },
			{ "ROW_45", 44 },
			{ "ROW_46", 45 },
			{ "ROW_47", 46 },
			{ "ROW_48", 47 },
			{ "ROW_49", 48 },
			{ "ROW_50", 49 },
			{ "ROW_51", 50 },
			{ "ROW_52", 51 },
			{ "ROW_53", 52 },
			{ "ROW_54", 53 },
			{ "ROW_55", 54 },
			{ "ROW_56", 55 },
			{ "ROW_57", 56 },
			{ "ROW_58", 57 },
			{ "ROW_59", 58 },
			{ "ROW_60", 59 },
			{ "ROW_61", 60 },
			{ "ROW_62", 61 },
			{ "ROW_63", 62 },
			{ "ROW_64", 63 },
			{ "ROW_65", 64 },
			{ "ROW_66", 65 },
			{ "ROW_67", 66 },
			{ "ROW_68", 67 },
			{ "ROW_69", 68 },
			{ "ROW_70", 69 },
			{ "ROW_71", 70 },
			{ "ROW_72", 71 },
			{ "ROW_73", 72 },
			{ "ROW_74", 73 },
			{ "ROW_75", 74 },
			{ "WARARENA", 75 }
		};

		public List<Bazooka_HaterBMRow> Rows = new List<Bazooka_HaterBMRow>();

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
			Rows.Add(new Bazooka_HaterBMRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new Bazooka_HaterBMRow());
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
			Rows.Add(new Bazooka_HaterBMRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]));
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

		public Bazooka_HaterBMRow GetRow(rowIds in_RowID)
		{
			Bazooka_HaterBMRow result = null;
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

		public Bazooka_HaterBMRow GetRow(string in_RowString)
		{
			Bazooka_HaterBMRow result = null;
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
