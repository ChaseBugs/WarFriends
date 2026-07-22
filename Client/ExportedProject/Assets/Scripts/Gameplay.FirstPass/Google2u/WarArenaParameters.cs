using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class WarArenaParameters : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			PlayerLevel,
			PlayerHP,
			ShieldHP,
			MinimumMasterFPS,
			MinimumPing,
			UnlockLevel,
			MaxPositionDiff,
			WarArenaReminderHours,
			MaxRegionsiOS,
			MaxRegionsAndroid,
			EnabledRegions,
			OpponentsLimit,
			ShowMatchesInfo,
			LowMatches,
			TopRunGroupDelimiter
		}

		public string[] rowNames = new string[15]
		{
			"PlayerLevel", "PlayerHP", "ShieldHP", "MinimumMasterFPS", "MinimumPing", "UnlockLevel", "MaxPositionDiff", "WarArenaReminderHours", "MaxRegionsiOS", "MaxRegionsAndroid",
			"EnabledRegions", "OpponentsLimit", "ShowMatchesInfo", "LowMatches", "TopRunGroupDelimiter"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "PlayerLevel", 0 },
			{ "PlayerHP", 1 },
			{ "ShieldHP", 2 },
			{ "MinimumMasterFPS", 3 },
			{ "MinimumPing", 4 },
			{ "UnlockLevel", 5 },
			{ "MaxPositionDiff", 6 },
			{ "WarArenaReminderHours", 7 },
			{ "MaxRegionsiOS", 8 },
			{ "MaxRegionsAndroid", 9 },
			{ "EnabledRegions", 10 },
			{ "OpponentsLimit", 11 },
			{ "ShowMatchesInfo", 12 },
			{ "LowMatches", 13 },
			{ "TopRunGroupDelimiter", 14 }
		};

		public List<WarArenaParametersRow> Rows = new List<WarArenaParametersRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 2;

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
			Rows.Add(new WarArenaParametersRow(input[0], input[1], input[2]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new WarArenaParametersRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 3)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new WarArenaParametersRow(input[0], input[1], input[2]));
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

		public WarArenaParametersRow GetRow(rowIds in_RowID)
		{
			WarArenaParametersRow result = null;
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

		public WarArenaParametersRow GetRow(string in_RowString)
		{
			WarArenaParametersRow result = null;
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
