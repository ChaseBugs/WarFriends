using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class BotNames : Google2uComponentBase, IGoogle2uDB
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
		ID_212,
		ID_213,
		ID_214,
		ID_215,
		ID_216,
		ID_217,
		ID_218,
		ID_219,
		ID_220,
		ID_221,
		ID_222,
		ID_223,
		ID_224,
		ID_225,
		ID_226,
		ID_227,
		ID_228,
		ID_229,
		ID_230,
		ID_231,
		ID_232,
		ID_233,
		ID_234,
		ID_235,
		ID_236,
		ID_237,
		ID_238,
		ID_239,
		ID_240,
		ID_241,
		ID_242,
		ID_243,
		ID_244,
		ID_245,
		ID_246,
		ID_247,
		ID_248,
		ID_249,
		ID_250,
		ID_251,
		ID_252,
		ID_253,
		ID_254,
		ID_255,
		ID_256,
		ID_257,
		ID_258,
		ID_259,
		ID_260,
		ID_261,
		ID_262,
		ID_263,
		ID_264,
		ID_265,
		ID_266,
		ID_267,
		ID_268,
		ID_269
	}

	public string[] rowNames = new string[269]
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
		"ID_131", "ID_132", "ID_133", "ID_134", "ID_135", "ID_136", "ID_137", "ID_138", "ID_139", "ID_140",
		"ID_141", "ID_142", "ID_143", "ID_144", "ID_145", "ID_146", "ID_147", "ID_148", "ID_149", "ID_150",
		"ID_151", "ID_152", "ID_153", "ID_154", "ID_155", "ID_156", "ID_157", "ID_158", "ID_159", "ID_160",
		"ID_161", "ID_162", "ID_163", "ID_164", "ID_165", "ID_166", "ID_167", "ID_168", "ID_169", "ID_170",
		"ID_171", "ID_172", "ID_173", "ID_174", "ID_175", "ID_176", "ID_177", "ID_178", "ID_179", "ID_180",
		"ID_181", "ID_182", "ID_183", "ID_184", "ID_185", "ID_186", "ID_187", "ID_188", "ID_189", "ID_190",
		"ID_191", "ID_192", "ID_193", "ID_194", "ID_195", "ID_196", "ID_197", "ID_198", "ID_199", "ID_200",
		"ID_201", "ID_202", "ID_203", "ID_204", "ID_205", "ID_206", "ID_207", "ID_208", "ID_209", "ID_210",
		"ID_211", "ID_212", "ID_213", "ID_214", "ID_215", "ID_216", "ID_217", "ID_218", "ID_219", "ID_220",
		"ID_221", "ID_222", "ID_223", "ID_224", "ID_225", "ID_226", "ID_227", "ID_228", "ID_229", "ID_230",
		"ID_231", "ID_232", "ID_233", "ID_234", "ID_235", "ID_236", "ID_237", "ID_238", "ID_239", "ID_240",
		"ID_241", "ID_242", "ID_243", "ID_244", "ID_245", "ID_246", "ID_247", "ID_248", "ID_249", "ID_250",
		"ID_251", "ID_252", "ID_253", "ID_254", "ID_255", "ID_256", "ID_257", "ID_258", "ID_259", "ID_260",
		"ID_261", "ID_262", "ID_263", "ID_264", "ID_265", "ID_266", "ID_267", "ID_268", "ID_269"
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
		{ "ID_134", 133 },
		{ "ID_135", 134 },
		{ "ID_136", 135 },
		{ "ID_137", 136 },
		{ "ID_138", 137 },
		{ "ID_139", 138 },
		{ "ID_140", 139 },
		{ "ID_141", 140 },
		{ "ID_142", 141 },
		{ "ID_143", 142 },
		{ "ID_144", 143 },
		{ "ID_145", 144 },
		{ "ID_146", 145 },
		{ "ID_147", 146 },
		{ "ID_148", 147 },
		{ "ID_149", 148 },
		{ "ID_150", 149 },
		{ "ID_151", 150 },
		{ "ID_152", 151 },
		{ "ID_153", 152 },
		{ "ID_154", 153 },
		{ "ID_155", 154 },
		{ "ID_156", 155 },
		{ "ID_157", 156 },
		{ "ID_158", 157 },
		{ "ID_159", 158 },
		{ "ID_160", 159 },
		{ "ID_161", 160 },
		{ "ID_162", 161 },
		{ "ID_163", 162 },
		{ "ID_164", 163 },
		{ "ID_165", 164 },
		{ "ID_166", 165 },
		{ "ID_167", 166 },
		{ "ID_168", 167 },
		{ "ID_169", 168 },
		{ "ID_170", 169 },
		{ "ID_171", 170 },
		{ "ID_172", 171 },
		{ "ID_173", 172 },
		{ "ID_174", 173 },
		{ "ID_175", 174 },
		{ "ID_176", 175 },
		{ "ID_177", 176 },
		{ "ID_178", 177 },
		{ "ID_179", 178 },
		{ "ID_180", 179 },
		{ "ID_181", 180 },
		{ "ID_182", 181 },
		{ "ID_183", 182 },
		{ "ID_184", 183 },
		{ "ID_185", 184 },
		{ "ID_186", 185 },
		{ "ID_187", 186 },
		{ "ID_188", 187 },
		{ "ID_189", 188 },
		{ "ID_190", 189 },
		{ "ID_191", 190 },
		{ "ID_192", 191 },
		{ "ID_193", 192 },
		{ "ID_194", 193 },
		{ "ID_195", 194 },
		{ "ID_196", 195 },
		{ "ID_197", 196 },
		{ "ID_198", 197 },
		{ "ID_199", 198 },
		{ "ID_200", 199 },
		{ "ID_201", 200 },
		{ "ID_202", 201 },
		{ "ID_203", 202 },
		{ "ID_204", 203 },
		{ "ID_205", 204 },
		{ "ID_206", 205 },
		{ "ID_207", 206 },
		{ "ID_208", 207 },
		{ "ID_209", 208 },
		{ "ID_210", 209 },
		{ "ID_211", 210 },
		{ "ID_212", 211 },
		{ "ID_213", 212 },
		{ "ID_214", 213 },
		{ "ID_215", 214 },
		{ "ID_216", 215 },
		{ "ID_217", 216 },
		{ "ID_218", 217 },
		{ "ID_219", 218 },
		{ "ID_220", 219 },
		{ "ID_221", 220 },
		{ "ID_222", 221 },
		{ "ID_223", 222 },
		{ "ID_224", 223 },
		{ "ID_225", 224 },
		{ "ID_226", 225 },
		{ "ID_227", 226 },
		{ "ID_228", 227 },
		{ "ID_229", 228 },
		{ "ID_230", 229 },
		{ "ID_231", 230 },
		{ "ID_232", 231 },
		{ "ID_233", 232 },
		{ "ID_234", 233 },
		{ "ID_235", 234 },
		{ "ID_236", 235 },
		{ "ID_237", 236 },
		{ "ID_238", 237 },
		{ "ID_239", 238 },
		{ "ID_240", 239 },
		{ "ID_241", 240 },
		{ "ID_242", 241 },
		{ "ID_243", 242 },
		{ "ID_244", 243 },
		{ "ID_245", 244 },
		{ "ID_246", 245 },
		{ "ID_247", 246 },
		{ "ID_248", 247 },
		{ "ID_249", 248 },
		{ "ID_250", 249 },
		{ "ID_251", 250 },
		{ "ID_252", 251 },
		{ "ID_253", 252 },
		{ "ID_254", 253 },
		{ "ID_255", 254 },
		{ "ID_256", 255 },
		{ "ID_257", 256 },
		{ "ID_258", 257 },
		{ "ID_259", 258 },
		{ "ID_260", 259 },
		{ "ID_261", 260 },
		{ "ID_262", 261 },
		{ "ID_263", 262 },
		{ "ID_264", 263 },
		{ "ID_265", 264 },
		{ "ID_266", 265 },
		{ "ID_267", 266 },
		{ "ID_268", 267 },
		{ "ID_269", 268 }
	};

	public List<BotNamesRow> Rows = new List<BotNamesRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 1;

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
		Rows.Add(new BotNamesRow(input[0], input[1]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new BotNamesRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 2)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new BotNamesRow(input[0], input[1]));
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

	public BotNamesRow GetRow(rowIds in_RowID)
	{
		BotNamesRow result = null;
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

	public BotNamesRow GetRow(string in_RowString)
	{
		BotNamesRow result = null;
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
