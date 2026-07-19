using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class WeaponFeatures : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ValueAssaultRifle = 0,
			ValueSMG = 1,
			ValueLMG = 2,
			ValueSniperRifle = 3,
			ValueRocketLauncher = 4,
			ValueShotgun = 5,
			ValueGrenade = 6,
			ValuePistol = 7,
			ValueMinigun = 8,
			ValueGrenadeLauncher = 9,
			DpsCoefAssaultRifle = 10,
			DpsCoefSMG = 11,
			DpsCoefLMG = 12,
			DpsCoefSniperRifle = 13,
			DpsCoefRocketLauncher = 14,
			DpsCoefShotgun = 15,
			DpsCoefGrenade = 16,
			DpsCoefPistol = 17,
			DpsCoefMinigun = 18,
			DpsCoefGrenadeLauncher = 19,
			AttackCoefAssaultRifle = 20,
			AttackCoefSMG = 21,
			AttackCoefLMG = 22,
			AttackCoefSniperRifle = 23,
			AttackCoefRocketLauncher = 24,
			AttackCoefShotgun = 25,
			AttackCoefGrenade = 26,
			AttackCoefPistol = 27,
			AttackCoefMinigun = 28,
			AttackCoefGrenadeLauncher = 29
		}

		public string[] rowNames = new string[30]
		{
			"ValueAssaultRifle", "ValueSMG", "ValueLMG", "ValueSniperRifle", "ValueRocketLauncher", "ValueShotgun", "ValueGrenade", "ValuePistol", "ValueMinigun", "ValueGrenadeLauncher",
			"DpsCoefAssaultRifle", "DpsCoefSMG", "DpsCoefLMG", "DpsCoefSniperRifle", "DpsCoefRocketLauncher", "DpsCoefShotgun", "DpsCoefGrenade", "DpsCoefPistol", "DpsCoefMinigun", "DpsCoefGrenadeLauncher",
			"AttackCoefAssaultRifle", "AttackCoefSMG", "AttackCoefLMG", "AttackCoefSniperRifle", "AttackCoefRocketLauncher", "AttackCoefShotgun", "AttackCoefGrenade", "AttackCoefPistol", "AttackCoefMinigun", "AttackCoefGrenadeLauncher"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "ValueAssaultRifle", 0 },
			{ "ValueSMG", 1 },
			{ "ValueLMG", 2 },
			{ "ValueSniperRifle", 3 },
			{ "ValueRocketLauncher", 4 },
			{ "ValueShotgun", 5 },
			{ "ValueGrenade", 6 },
			{ "ValuePistol", 7 },
			{ "ValueMinigun", 8 },
			{ "ValueGrenadeLauncher", 9 },
			{ "DpsCoefAssaultRifle", 10 },
			{ "DpsCoefSMG", 11 },
			{ "DpsCoefLMG", 12 },
			{ "DpsCoefSniperRifle", 13 },
			{ "DpsCoefRocketLauncher", 14 },
			{ "DpsCoefShotgun", 15 },
			{ "DpsCoefGrenade", 16 },
			{ "DpsCoefPistol", 17 },
			{ "DpsCoefMinigun", 18 },
			{ "DpsCoefGrenadeLauncher", 19 },
			{ "AttackCoefAssaultRifle", 20 },
			{ "AttackCoefSMG", 21 },
			{ "AttackCoefLMG", 22 },
			{ "AttackCoefSniperRifle", 23 },
			{ "AttackCoefRocketLauncher", 24 },
			{ "AttackCoefShotgun", 25 },
			{ "AttackCoefGrenade", 26 },
			{ "AttackCoefPistol", 27 },
			{ "AttackCoefMinigun", 28 },
			{ "AttackCoefGrenadeLauncher", 29 }
		};

		public List<WeaponFeaturesRow> Rows = new List<WeaponFeaturesRow>();

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
				return 9;
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
			Rows.Add(new WeaponFeaturesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new WeaponFeaturesRow());
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
			Rows.Add(new WeaponFeaturesRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]));
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

		public WeaponFeaturesRow GetRow(rowIds in_RowID)
		{
			WeaponFeaturesRow result = null;
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

		public WeaponFeaturesRow GetRow(string in_RowString)
		{
			WeaponFeaturesRow result = null;
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
