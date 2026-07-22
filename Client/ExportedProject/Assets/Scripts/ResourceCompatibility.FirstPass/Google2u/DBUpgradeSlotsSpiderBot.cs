using System.Collections.Generic;

namespace Google2u
{
	public class DBUpgradeSlotsSpiderBot : Google2uComponentBase, IGoogle2uDB
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
			ROW_76,
			ROW_77,
			ROW_78,
			ROW_79,
			ROW_80,
			ROW_81,
			ROW_82,
			ROW_83,
			ROW_84,
			ROW_85,
			ROW_86,
			ROW_87,
			ROW_88,
			ROW_89,
			ROW_90,
			ROW_91,
			ROW_92,
			ROW_93,
			ROW_94,
			ROW_95,
			ROW_96,
			ROW_97,
			ROW_98,
			ROW_99,
			ROW_100,
			ROW_101,
			ROW_102,
			ROW_103,
			ROW_104,
			ROW_105,
			ROW_106,
			ROW_107,
			ROW_108,
			ROW_109,
			ROW_110,
			ROW_111,
			ROW_112,
			ROW_113,
			ROW_114,
			ROW_115,
			ROW_116,
			ROW_117,
			ROW_118,
			ROW_119,
			ROW_120,
			ROW_121,
			ROW_122,
			ROW_123,
			ROW_124,
			ROW_125,
			ROW_126,
			ROW_127,
			ROW_128,
			ROW_129,
			ROW_130,
			ROW_131,
			ROW_132,
			ROW_133,
			ROW_134,
			ROW_135,
			ROW_136,
			ROW_137,
			ROW_138,
			ROW_139,
			ROW_140,
			ROW_141,
			ROW_142,
			ROW_143,
			ROW_144,
			ROW_145,
			ROW_146,
			ROW_147,
			ROW_148,
			ROW_149,
			ROW_150,
			ROW_151,
			SPECIAL_0,
			SPECIAL_1,
			SPECIAL_2,
			SPECIAL_3,
			SPECIAL_4,
			SPECIAL_5,
			SPECIAL_6,
			SPECIAL_7,
			SPECIAL_8,
			SPECIAL_9,
			SPECIAL_10,
			SPECIAL_11,
			SPECIAL_12,
			SPECIAL_13,
			SPECIAL_14,
			SPECIAL_15,
			SPECIAL_16,
			SPECIAL_17,
			SPECIAL_18,
			SPECIAL_19,
			SPECIAL_20,
			ELITE_0,
			ELITE_1,
			ELITE_2,
			ELITE_3,
			ELITE_4,
			ELITE_5,
			ELITE_6,
			ELITE_7,
			ELITE_8,
			WARARENA,
			INVADER_MIN,
			INVADER_MAX
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<DBUpgradeSlotsSpiderBotRow> Rows;

		public override bool haveDictionary => false;

		public override int getColumnCount => 0;

		public override int GetRowIndex(string rowID)
		{
			return 0;
		}

		public override void AddRowGeneric(List<string> input)
		{
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			return 0;
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			return 0;
		}

		public override void CheckRows(List<string> rowIds)
		{
		}

		public override void Clear()
		{
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			return null;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			return null;
		}

		public DBUpgradeSlotsSpiderBotRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public DBUpgradeSlotsSpiderBotRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
