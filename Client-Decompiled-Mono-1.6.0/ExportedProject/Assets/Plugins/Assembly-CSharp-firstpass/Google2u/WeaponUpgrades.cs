using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class WeaponUpgrades : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_1 = 0,
			ID_2 = 1,
			ID_3 = 2,
			ID_4 = 3,
			ID_5 = 4,
			ID_6 = 5,
			ID_7 = 6,
			ID_8 = 7,
			ID_9 = 8,
			ID_10 = 9,
			ID_11 = 10,
			ID_12 = 11,
			ID_13 = 12,
			ID_14 = 13,
			ID_15 = 14,
			ID_16 = 15,
			ID_17 = 16,
			ID_18 = 17,
			ID_19 = 18,
			ID_20 = 19,
			ID_21 = 20,
			ID_22 = 21,
			ID_23 = 22,
			ID_24 = 23,
			ID_25 = 24,
			ID_26 = 25,
			ID_27 = 26,
			ID_28 = 27,
			ID_29 = 28,
			ID_30 = 29,
			ID_31 = 30,
			ID_32 = 31,
			ID_33 = 32,
			ID_34 = 33,
			ID_35 = 34,
			ID_36 = 35,
			ID_37 = 36,
			ID_38 = 37,
			ID_39 = 38,
			ID_40 = 39,
			ID_41 = 40,
			ID_42 = 41,
			ID_43 = 42,
			ID_44 = 43,
			ID_45 = 44,
			ID_46 = 45,
			ID_47 = 46,
			ID_48 = 47,
			ID_49 = 48,
			ID_50 = 49,
			ID_51 = 50,
			ID_52 = 51,
			ID_53 = 52,
			ID_54 = 53,
			ID_55 = 54,
			ID_56 = 55,
			ID_57 = 56,
			ID_58 = 57,
			ID_59 = 58,
			ID_60 = 59,
			ID_61 = 60,
			ID_62 = 61,
			ID_63 = 62,
			ID_64 = 63,
			ID_65 = 64,
			ID_66 = 65,
			ID_67 = 66,
			ID_68 = 67,
			ID_69 = 68,
			ID_70 = 69,
			ID_71 = 70,
			ID_72 = 71,
			ID_73 = 72,
			ID_74 = 73,
			ID_75 = 74,
			ID_76 = 75,
			ID_77 = 76,
			ID_78 = 77,
			ID_79 = 78,
			ID_80 = 79,
			ID_81 = 80,
			ID_82 = 81,
			ID_83 = 82,
			ID_84 = 83,
			ID_85 = 84,
			ID_86 = 85,
			ID_87 = 86,
			ID_88 = 87,
			ID_89 = 88,
			ID_90 = 89,
			ID_91 = 90,
			ID_92 = 91,
			ID_93 = 92,
			ID_94 = 93,
			ID_95 = 94,
			ID_96 = 95,
			ID_97 = 96,
			ID_98 = 97,
			ID_99 = 98,
			ID_100 = 99,
			ID_101 = 100,
			ID_102 = 101,
			ID_103 = 102,
			ID_104 = 103,
			ID_105 = 104,
			ID_106 = 105,
			ID_107 = 106,
			ID_108 = 107,
			ID_109 = 108,
			ID_110 = 109,
			ID_111 = 110,
			ID_112 = 111,
			ID_113 = 112,
			ID_114 = 113,
			ID_115 = 114,
			ID_116 = 115,
			ID_117 = 116,
			ID_118 = 117,
			ID_119 = 118,
			ID_120 = 119,
			ID_121 = 120,
			ID_122 = 121,
			ID_123 = 122,
			ID_124 = 123,
			ID_125 = 124,
			ID_126 = 125,
			ID_127 = 126,
			ID_128 = 127,
			ID_129 = 128,
			ID_130 = 129,
			ID_131 = 130,
			ID_132 = 131,
			ID_133 = 132,
			ID_134 = 133
		}

		public string[] rowNames = new string[134]
		{
			"ID_1", "ID_2", "ID_3", "ID_4", "ID_5", "ID_6", "ID_7", "ID_8", "ID_9", "ID_10",
			"ID_11", "ID_12", "ID_13", "ID_14", "ID_15", "ID_16", "ID_17", "ID_18", "ID_19", "ID_20",
			"ID_21", "ID_22", "ID_23", "ID_24", "ID_25", "ID_26", "ID_27", "ID_28", "ID_29", "ID_30",
			"ID_31", "ID_32", "ID_33", "ID_34", "ID_35", "ID_36", "ID_37", "ID_38", "ID_39", "ID_40",
			"ID_41", "ID_42", "ID_43", "ID_44", "ID_45", "ID_46", "ID_47", "ID_48", "ID_49", "ID_50",
			"ID_51", "ID_52", "ID_53", "ID_54", "ID_55", "ID_56", "ID_57", "ID_58", "ID_59", "ID_60",
			"ID_61", "ID_62", "ID_63", "ID_64", "ID_65", "ID_66", "ID_67", "ID_68", "ID_69", "ID_70",
			"ID_71", "ID_72", "ID_73", "ID_74", "ID_75", "ID_76", "ID_77", "ID_78", "ID_79", "ID_80",
			"ID_81", "ID_82", "ID_83", "ID_84", "ID_85", "ID_86", "ID_87", "ID_88", "ID_89", "ID_90",
			"ID_91", "ID_92", "ID_93", "ID_94", "ID_95", "ID_96", "ID_97", "ID_98", "ID_99", "ID_100",
			"ID_101", "ID_102", "ID_103", "ID_104", "ID_105", "ID_106", "ID_107", "ID_108", "ID_109", "ID_110",
			"ID_111", "ID_112", "ID_113", "ID_114", "ID_115", "ID_116", "ID_117", "ID_118", "ID_119", "ID_120",
			"ID_121", "ID_122", "ID_123", "ID_124", "ID_125", "ID_126", "ID_127", "ID_128", "ID_129", "ID_130",
			"ID_131", "ID_132", "ID_133", "ID_134"
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
			{ "ID_64", 63 },
			{ "ID_65", 64 },
			{ "ID_66", 65 },
			{ "ID_67", 66 },
			{ "ID_68", 67 },
			{ "ID_69", 68 },
			{ "ID_70", 69 },
			{ "ID_71", 70 },
			{ "ID_72", 71 },
			{ "ID_73", 72 },
			{ "ID_74", 73 },
			{ "ID_75", 74 },
			{ "ID_76", 75 },
			{ "ID_77", 76 },
			{ "ID_78", 77 },
			{ "ID_79", 78 },
			{ "ID_80", 79 },
			{ "ID_81", 80 },
			{ "ID_82", 81 },
			{ "ID_83", 82 },
			{ "ID_84", 83 },
			{ "ID_85", 84 },
			{ "ID_86", 85 },
			{ "ID_87", 86 },
			{ "ID_88", 87 },
			{ "ID_89", 88 },
			{ "ID_90", 89 },
			{ "ID_91", 90 },
			{ "ID_92", 91 },
			{ "ID_93", 92 },
			{ "ID_94", 93 },
			{ "ID_95", 94 },
			{ "ID_96", 95 },
			{ "ID_97", 96 },
			{ "ID_98", 97 },
			{ "ID_99", 98 },
			{ "ID_100", 99 },
			{ "ID_101", 100 },
			{ "ID_102", 101 },
			{ "ID_103", 102 },
			{ "ID_104", 103 },
			{ "ID_105", 104 },
			{ "ID_106", 105 },
			{ "ID_107", 106 },
			{ "ID_108", 107 },
			{ "ID_109", 108 },
			{ "ID_110", 109 },
			{ "ID_111", 110 },
			{ "ID_112", 111 },
			{ "ID_113", 112 },
			{ "ID_114", 113 },
			{ "ID_115", 114 },
			{ "ID_116", 115 },
			{ "ID_117", 116 },
			{ "ID_118", 117 },
			{ "ID_119", 118 },
			{ "ID_120", 119 },
			{ "ID_121", 120 },
			{ "ID_122", 121 },
			{ "ID_123", 122 },
			{ "ID_124", 123 },
			{ "ID_125", 124 },
			{ "ID_126", 125 },
			{ "ID_127", 126 },
			{ "ID_128", 127 },
			{ "ID_129", 128 },
			{ "ID_130", 129 },
			{ "ID_131", 130 },
			{ "ID_132", 131 },
			{ "ID_133", 132 },
			{ "ID_134", 133 }
		};

		public List<WeaponUpgradesRow> Rows = new List<WeaponUpgradesRow>();

		public override bool haveDictionary
		{
			get
			{
				return true;
			}
		}

		public override int getColumnCount
		{
			get
			{
				return 19;
			}
		}

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
			Rows.Add(new WeaponUpgradesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new WeaponUpgradesRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 20)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new WeaponUpgradesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19]));
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

		public WeaponUpgradesRow GetRow(rowIds in_RowID)
		{
			WeaponUpgradesRow result = null;
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

		public WeaponUpgradesRow GetRow(string in_RowString)
		{
			WeaponUpgradesRow result = null;
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
