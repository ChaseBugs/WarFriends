using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class DBUpgradeSlotsBuddy : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			Defender_MIN_AssaultRifle,
			Defender_MAX_AssaultRifle,
			Defender_MIN_LMG,
			Defender_MAX_LMG,
			Defender_MIN_SMG,
			Defender_MAX_SMG,
			AttackerShooter_MIN_AssaultRifle,
			AttackerShooter_MAX_AssaultRifle,
			AttackerShooter_MIN_LMG,
			AttackerShooter_MAX_LMG,
			AttackerShooter_MIN_SMG,
			AttackerShooter_MAX_SMG,
			AttackerShooter_MIN_SniperRifle,
			AttackerShooter_MAX_SniperRifle,
			AttackerExplosive_MIN_Pistol,
			AttackerExplosive_MAX_Pistol,
			AttackerExplosive_MIN_RocketLauncher,
			AttackerExplosive_MAX_RocketLauncher,
			AttackerRusher_MIN_Shotgun,
			AttackerRusher_MAX_Shotgun,
			AttackerRusher_MIN_AssaultRifle,
			AttackerRusher_MAX_AssaultRifle,
			AttackerRusher_MIN_LMG,
			AttackerRusher_MAX_LMG,
			AttackerRusher_MIN_SMG,
			AttackerRusher_MAX_SMG
		}

		public string[] rowNames = new string[26]
		{
			"Defender_MIN_AssaultRifle", "Defender_MAX_AssaultRifle", "Defender_MIN_LMG", "Defender_MAX_LMG", "Defender_MIN_SMG", "Defender_MAX_SMG", "AttackerShooter_MIN_AssaultRifle", "AttackerShooter_MAX_AssaultRifle", "AttackerShooter_MIN_LMG", "AttackerShooter_MAX_LMG",
			"AttackerShooter_MIN_SMG", "AttackerShooter_MAX_SMG", "AttackerShooter_MIN_SniperRifle", "AttackerShooter_MAX_SniperRifle", "AttackerExplosive_MIN_Pistol", "AttackerExplosive_MAX_Pistol", "AttackerExplosive_MIN_RocketLauncher", "AttackerExplosive_MAX_RocketLauncher", "AttackerRusher_MIN_Shotgun", "AttackerRusher_MAX_Shotgun",
			"AttackerRusher_MIN_AssaultRifle", "AttackerRusher_MAX_AssaultRifle", "AttackerRusher_MIN_LMG", "AttackerRusher_MAX_LMG", "AttackerRusher_MIN_SMG", "AttackerRusher_MAX_SMG"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "Defender_MIN_AssaultRifle", 0 },
			{ "Defender_MAX_AssaultRifle", 1 },
			{ "Defender_MIN_LMG", 2 },
			{ "Defender_MAX_LMG", 3 },
			{ "Defender_MIN_SMG", 4 },
			{ "Defender_MAX_SMG", 5 },
			{ "AttackerShooter_MIN_AssaultRifle", 6 },
			{ "AttackerShooter_MAX_AssaultRifle", 7 },
			{ "AttackerShooter_MIN_LMG", 8 },
			{ "AttackerShooter_MAX_LMG", 9 },
			{ "AttackerShooter_MIN_SMG", 10 },
			{ "AttackerShooter_MAX_SMG", 11 },
			{ "AttackerShooter_MIN_SniperRifle", 12 },
			{ "AttackerShooter_MAX_SniperRifle", 13 },
			{ "AttackerExplosive_MIN_Pistol", 14 },
			{ "AttackerExplosive_MAX_Pistol", 15 },
			{ "AttackerExplosive_MIN_RocketLauncher", 16 },
			{ "AttackerExplosive_MAX_RocketLauncher", 17 },
			{ "AttackerRusher_MIN_Shotgun", 18 },
			{ "AttackerRusher_MAX_Shotgun", 19 },
			{ "AttackerRusher_MIN_AssaultRifle", 20 },
			{ "AttackerRusher_MAX_AssaultRifle", 21 },
			{ "AttackerRusher_MIN_LMG", 22 },
			{ "AttackerRusher_MAX_LMG", 23 },
			{ "AttackerRusher_MIN_SMG", 24 },
			{ "AttackerRusher_MAX_SMG", 25 }
		};

		public List<DBUpgradeSlotsBuddyRow> Rows = new List<DBUpgradeSlotsBuddyRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 12;

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
			Rows.Add(new DBUpgradeSlotsBuddyRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new DBUpgradeSlotsBuddyRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 13)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new DBUpgradeSlotsBuddyRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12]));
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

		public DBUpgradeSlotsBuddyRow GetRow(rowIds in_RowID)
		{
			DBUpgradeSlotsBuddyRow result = null;
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

		public DBUpgradeSlotsBuddyRow GetRow(string in_RowString)
		{
			DBUpgradeSlotsBuddyRow result = null;
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
