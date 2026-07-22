using System.Collections.Generic;

namespace Google2u
{
	public class WeaponUpgrades : Google2uComponentBase, IGoogle2uDB
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
			ID_64,
			ID_65,
			ID_66,
			ID_67,
			ID_68,
			ID_69,
			ID_70,
			ID_71,
			ID_72,
			ID_73,
			ID_74,
			ID_75,
			ID_76,
			ID_77,
			ID_78,
			ID_79,
			ID_80,
			ID_81,
			ID_82,
			ID_83,
			ID_84,
			ID_85,
			ID_86,
			ID_87,
			ID_88,
			ID_89,
			ID_90,
			ID_91,
			ID_92,
			ID_93,
			ID_94,
			ID_95,
			ID_96,
			ID_97,
			ID_98,
			ID_99,
			ID_100,
			ID_101,
			ID_102,
			ID_103,
			ID_104,
			ID_105,
			ID_106,
			ID_107,
			ID_108,
			ID_109,
			ID_110,
			ID_111,
			ID_112,
			ID_113,
			ID_114,
			ID_115,
			ID_116,
			ID_117,
			ID_118,
			ID_119,
			ID_120,
			ID_121,
			ID_122,
			ID_123,
			ID_124,
			ID_125,
			ID_126,
			ID_127,
			ID_128,
			ID_129,
			ID_130,
			ID_131,
			ID_132,
			ID_133,
			ID_134,
			ID_135,
			ID_136,
			ID_137,
			ID_138,
			ID_139,
			ID_140,
			ID_141,
			ID_142,
			ID_143,
			ID_144,
			ID_145,
			ID_146,
			ID_147,
			ID_148,
			ID_149,
			ID_150,
			ID_151,
			ID_152,
			ID_153,
			ID_154,
			ID_155,
			ID_156,
			ID_157,
			ID_158,
			ID_159,
			ID_160,
			ID_161,
			ID_162,
			ID_163,
			ID_164,
			ID_165,
			ID_166,
			ID_167,
			ID_168,
			ID_169,
			ID_170,
			ID_171,
			ID_172,
			ID_173,
			ID_174,
			ID_175,
			ID_176,
			ID_177,
			ID_178,
			ID_179,
			ID_180,
			ID_181,
			ID_182,
			ID_183,
			ID_184,
			ID_185,
			ID_186,
			ID_187,
			ID_188,
			ID_189,
			ID_190,
			ID_191,
			ID_192,
			ID_193,
			ID_194,
			ID_195,
			ID_196,
			ID_197,
			ID_198,
			ID_199,
			ID_200,
			ID_201,
			ID_202,
			ID_203,
			ID_204,
			ID_205,
			ID_206,
			ID_207,
			ID_208,
			ID_209,
			ID_210,
			ID_211,
			ID_212
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<WeaponUpgradesRow> Rows;

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

		public WeaponUpgradesRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public WeaponUpgradesRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
