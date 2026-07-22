using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class CountryInfo : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			AD,
			AE,
			AF,
			AG,
			AI,
			AL,
			AM,
			AO,
			AQ,
			AR,
			AS,
			AT,
			AU,
			AW,
			AX,
			AZ,
			BA,
			BB,
			BD,
			BE,
			BF,
			BG,
			BH,
			BI,
			BJ,
			BL,
			BM,
			BN,
			BO,
			BQ,
			BR,
			BS,
			BT,
			BV,
			BW,
			BY,
			BZ,
			CA,
			CC,
			CD,
			CF,
			CG,
			CH,
			CI,
			CK,
			CL,
			CM,
			CN,
			CO,
			CR,
			CU,
			CV,
			CW,
			CX,
			CY,
			CZ,
			DE,
			DJ,
			DK,
			DM,
			DO,
			DZ,
			EC,
			EE,
			EG,
			EH,
			ER,
			ES,
			ET,
			FI,
			FJ,
			FK,
			FM,
			FO,
			FR,
			GA,
			GB,
			GD,
			GE,
			GF,
			GG,
			GH,
			GI,
			GL,
			GM,
			GN,
			GP,
			GQ,
			GR,
			GS,
			GT,
			GU,
			GW,
			GY,
			HK,
			HM,
			HN,
			HR,
			HT,
			HU,
			ID,
			IE,
			IL,
			IM,
			IN,
			IO,
			IQ,
			IR,
			IS,
			IT,
			JE,
			JM,
			JO,
			JP,
			KE,
			KG,
			KH,
			KI,
			KM,
			KN,
			KP,
			KR,
			XK,
			KW,
			KY,
			KZ,
			LA,
			LB,
			LC,
			LI,
			LK,
			LR,
			LS,
			LT,
			LU,
			LV,
			LY,
			MA,
			MC,
			MD,
			ME,
			MF,
			MG,
			MH,
			MK,
			ML,
			MM,
			MN,
			MO,
			MP,
			MQ,
			MR,
			MS,
			MT,
			MU,
			MV,
			MW,
			MX,
			MY,
			MZ,
			NA,
			NC,
			NE,
			NF,
			NG,
			NI,
			NL,
			NO,
			NP,
			NR,
			NU,
			NZ,
			OM,
			PA,
			PE,
			PF,
			PG,
			PH,
			PK,
			PL,
			PM,
			PN,
			PR,
			PS,
			PT,
			PW,
			PY,
			QA,
			RE,
			RO,
			RS,
			RU,
			RW,
			SA,
			SB,
			SC,
			SD,
			SS,
			SE,
			SG,
			SH,
			SI,
			SJ,
			SK,
			SL,
			SM,
			SN,
			SO,
			SR,
			ST,
			SV,
			SX,
			SY,
			SZ,
			TC,
			TD,
			TF,
			TG,
			TH,
			TJ,
			TK,
			TL,
			TM,
			TN,
			TO,
			TR,
			TT,
			TV,
			TW,
			TZ,
			UA,
			UG,
			UM,
			US,
			UY,
			UZ,
			VA,
			VC,
			VE,
			VG,
			VI,
			VN,
			VU,
			WF,
			WS,
			YE,
			YT,
			ZA,
			ZM,
			ZW,
			CS,
			AN
		}

		public string[] rowNames = new string[252]
		{
			"AD", "AE", "AF", "AG", "AI", "AL", "AM", "AO", "AQ", "AR",
			"AS", "AT", "AU", "AW", "AX", "AZ", "BA", "BB", "BD", "BE",
			"BF", "BG", "BH", "BI", "BJ", "BL", "BM", "BN", "BO", "BQ",
			"BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD",
			"CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO", "CR",
			"CU", "CV", "CW", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM",
			"DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI",
			"FJ", "FK", "FM", "FO", "FR", "GA", "GB", "GD", "GE", "GF",
			"GG", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS",
			"GT", "GU", "GW", "GY", "HK", "HM", "HN", "HR", "HT", "HU",
			"ID", "IE", "IL", "IM", "IN", "IO", "IQ", "IR", "IS", "IT",
			"JE", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN",
			"KP", "KR", "XK", "KW", "KY", "KZ", "LA", "LB", "LC", "LI",
			"LK", "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD",
			"ME", "MF", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP",
			"MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ",
			"NA", "NC", "NE", "NF", "NG", "NI", "NL", "NO", "NP", "NR",
			"NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL",
			"PM", "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO",
			"RS", "RU", "RW", "SA", "SB", "SC", "SD", "SS", "SE", "SG",
			"SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST",
			"SV", "SX", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ",
			"TK", "TL", "TM", "TN", "TO", "TR", "TT", "TV", "TW", "TZ",
			"UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG",
			"VI", "VN", "VU", "WF", "WS", "YE", "YT", "ZA", "ZM", "ZW",
			"CS", "AN"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "AD", 0 },
			{ "AE", 1 },
			{ "AF", 2 },
			{ "AG", 3 },
			{ "AI", 4 },
			{ "AL", 5 },
			{ "AM", 6 },
			{ "AO", 7 },
			{ "AQ", 8 },
			{ "AR", 9 },
			{ "AS", 10 },
			{ "AT", 11 },
			{ "AU", 12 },
			{ "AW", 13 },
			{ "AX", 14 },
			{ "AZ", 15 },
			{ "BA", 16 },
			{ "BB", 17 },
			{ "BD", 18 },
			{ "BE", 19 },
			{ "BF", 20 },
			{ "BG", 21 },
			{ "BH", 22 },
			{ "BI", 23 },
			{ "BJ", 24 },
			{ "BL", 25 },
			{ "BM", 26 },
			{ "BN", 27 },
			{ "BO", 28 },
			{ "BQ", 29 },
			{ "BR", 30 },
			{ "BS", 31 },
			{ "BT", 32 },
			{ "BV", 33 },
			{ "BW", 34 },
			{ "BY", 35 },
			{ "BZ", 36 },
			{ "CA", 37 },
			{ "CC", 38 },
			{ "CD", 39 },
			{ "CF", 40 },
			{ "CG", 41 },
			{ "CH", 42 },
			{ "CI", 43 },
			{ "CK", 44 },
			{ "CL", 45 },
			{ "CM", 46 },
			{ "CN", 47 },
			{ "CO", 48 },
			{ "CR", 49 },
			{ "CU", 50 },
			{ "CV", 51 },
			{ "CW", 52 },
			{ "CX", 53 },
			{ "CY", 54 },
			{ "CZ", 55 },
			{ "DE", 56 },
			{ "DJ", 57 },
			{ "DK", 58 },
			{ "DM", 59 },
			{ "DO", 60 },
			{ "DZ", 61 },
			{ "EC", 62 },
			{ "EE", 63 },
			{ "EG", 64 },
			{ "EH", 65 },
			{ "ER", 66 },
			{ "ES", 67 },
			{ "ET", 68 },
			{ "FI", 69 },
			{ "FJ", 70 },
			{ "FK", 71 },
			{ "FM", 72 },
			{ "FO", 73 },
			{ "FR", 74 },
			{ "GA", 75 },
			{ "GB", 76 },
			{ "GD", 77 },
			{ "GE", 78 },
			{ "GF", 79 },
			{ "GG", 80 },
			{ "GH", 81 },
			{ "GI", 82 },
			{ "GL", 83 },
			{ "GM", 84 },
			{ "GN", 85 },
			{ "GP", 86 },
			{ "GQ", 87 },
			{ "GR", 88 },
			{ "GS", 89 },
			{ "GT", 90 },
			{ "GU", 91 },
			{ "GW", 92 },
			{ "GY", 93 },
			{ "HK", 94 },
			{ "HM", 95 },
			{ "HN", 96 },
			{ "HR", 97 },
			{ "HT", 98 },
			{ "HU", 99 },
			{ "ID", 100 },
			{ "IE", 101 },
			{ "IL", 102 },
			{ "IM", 103 },
			{ "IN", 104 },
			{ "IO", 105 },
			{ "IQ", 106 },
			{ "IR", 107 },
			{ "IS", 108 },
			{ "IT", 109 },
			{ "JE", 110 },
			{ "JM", 111 },
			{ "JO", 112 },
			{ "JP", 113 },
			{ "KE", 114 },
			{ "KG", 115 },
			{ "KH", 116 },
			{ "KI", 117 },
			{ "KM", 118 },
			{ "KN", 119 },
			{ "KP", 120 },
			{ "KR", 121 },
			{ "XK", 122 },
			{ "KW", 123 },
			{ "KY", 124 },
			{ "KZ", 125 },
			{ "LA", 126 },
			{ "LB", 127 },
			{ "LC", 128 },
			{ "LI", 129 },
			{ "LK", 130 },
			{ "LR", 131 },
			{ "LS", 132 },
			{ "LT", 133 },
			{ "LU", 134 },
			{ "LV", 135 },
			{ "LY", 136 },
			{ "MA", 137 },
			{ "MC", 138 },
			{ "MD", 139 },
			{ "ME", 140 },
			{ "MF", 141 },
			{ "MG", 142 },
			{ "MH", 143 },
			{ "MK", 144 },
			{ "ML", 145 },
			{ "MM", 146 },
			{ "MN", 147 },
			{ "MO", 148 },
			{ "MP", 149 },
			{ "MQ", 150 },
			{ "MR", 151 },
			{ "MS", 152 },
			{ "MT", 153 },
			{ "MU", 154 },
			{ "MV", 155 },
			{ "MW", 156 },
			{ "MX", 157 },
			{ "MY", 158 },
			{ "MZ", 159 },
			{ "NA", 160 },
			{ "NC", 161 },
			{ "NE", 162 },
			{ "NF", 163 },
			{ "NG", 164 },
			{ "NI", 165 },
			{ "NL", 166 },
			{ "NO", 167 },
			{ "NP", 168 },
			{ "NR", 169 },
			{ "NU", 170 },
			{ "NZ", 171 },
			{ "OM", 172 },
			{ "PA", 173 },
			{ "PE", 174 },
			{ "PF", 175 },
			{ "PG", 176 },
			{ "PH", 177 },
			{ "PK", 178 },
			{ "PL", 179 },
			{ "PM", 180 },
			{ "PN", 181 },
			{ "PR", 182 },
			{ "PS", 183 },
			{ "PT", 184 },
			{ "PW", 185 },
			{ "PY", 186 },
			{ "QA", 187 },
			{ "RE", 188 },
			{ "RO", 189 },
			{ "RS", 190 },
			{ "RU", 191 },
			{ "RW", 192 },
			{ "SA", 193 },
			{ "SB", 194 },
			{ "SC", 195 },
			{ "SD", 196 },
			{ "SS", 197 },
			{ "SE", 198 },
			{ "SG", 199 },
			{ "SH", 200 },
			{ "SI", 201 },
			{ "SJ", 202 },
			{ "SK", 203 },
			{ "SL", 204 },
			{ "SM", 205 },
			{ "SN", 206 },
			{ "SO", 207 },
			{ "SR", 208 },
			{ "ST", 209 },
			{ "SV", 210 },
			{ "SX", 211 },
			{ "SY", 212 },
			{ "SZ", 213 },
			{ "TC", 214 },
			{ "TD", 215 },
			{ "TF", 216 },
			{ "TG", 217 },
			{ "TH", 218 },
			{ "TJ", 219 },
			{ "TK", 220 },
			{ "TL", 221 },
			{ "TM", 222 },
			{ "TN", 223 },
			{ "TO", 224 },
			{ "TR", 225 },
			{ "TT", 226 },
			{ "TV", 227 },
			{ "TW", 228 },
			{ "TZ", 229 },
			{ "UA", 230 },
			{ "UG", 231 },
			{ "UM", 232 },
			{ "US", 233 },
			{ "UY", 234 },
			{ "UZ", 235 },
			{ "VA", 236 },
			{ "VC", 237 },
			{ "VE", 238 },
			{ "VG", 239 },
			{ "VI", 240 },
			{ "VN", 241 },
			{ "VU", 242 },
			{ "WF", 243 },
			{ "WS", 244 },
			{ "YE", 245 },
			{ "YT", 246 },
			{ "ZA", 247 },
			{ "ZM", 248 },
			{ "ZW", 249 },
			{ "CS", 250 },
			{ "AN", 251 }
		};

		public List<CountryInfoRow> Rows = new List<CountryInfoRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 8;

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
			Rows.Add(new CountryInfoRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new CountryInfoRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 9)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new CountryInfoRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8]));
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

		public CountryInfoRow GetRow(rowIds in_RowID)
		{
			CountryInfoRow result = null;
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

		public CountryInfoRow GetRow(string in_RowString)
		{
			CountryInfoRow result = null;
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
