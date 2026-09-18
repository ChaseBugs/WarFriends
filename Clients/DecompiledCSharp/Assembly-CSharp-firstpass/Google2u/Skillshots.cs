using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class Skillshots : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		HeadShot,
		Runner,
		LongShot,
		Covered,
		OneHitKill,
		DoubleKill,
		TrippleKill,
		MultiKill,
		SlowMotionKill,
		TeamKill,
		RevengeKill,
		Kill,
		ExplosiveKill,
		OnTheMove,
		EnemyPlayerHit,
		VehicleDestroyed,
		TankDestroyed,
		EnviromentalKill,
		ArmyKill,
		ArmyPlayerHit
	}

	public string[] rowNames = new string[20]
	{
		"HeadShot", "Runner", "LongShot", "Covered", "OneHitKill", "DoubleKill", "TrippleKill", "MultiKill", "SlowMotionKill", "TeamKill",
		"RevengeKill", "Kill", "ExplosiveKill", "OnTheMove", "EnemyPlayerHit", "VehicleDestroyed", "TankDestroyed", "EnviromentalKill", "ArmyKill", "ArmyPlayerHit"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "HeadShot", 0 },
		{ "Runner", 1 },
		{ "LongShot", 2 },
		{ "Covered", 3 },
		{ "OneHitKill", 4 },
		{ "DoubleKill", 5 },
		{ "TrippleKill", 6 },
		{ "MultiKill", 7 },
		{ "SlowMotionKill", 8 },
		{ "TeamKill", 9 },
		{ "RevengeKill", 10 },
		{ "Kill", 11 },
		{ "ExplosiveKill", 12 },
		{ "OnTheMove", 13 },
		{ "EnemyPlayerHit", 14 },
		{ "VehicleDestroyed", 15 },
		{ "TankDestroyed", 16 },
		{ "EnviromentalKill", 17 },
		{ "ArmyKill", 18 },
		{ "ArmyPlayerHit", 19 }
	};

	public List<SkillshotsRow> Rows = new List<SkillshotsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 5;

	public override int GetRowIndex(string rowID)
	{
		if (namesToIndex.ContainsKey(rowID))
		{
			return namesToIndex[rowID];
		}
		return -1;
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public override void AddRowGeneric(List<string> input)
	{
		Rows.Add(new SkillshotsRow(input[0], input[1], input[2], input[3], input[4], input[5]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new SkillshotsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 6)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new SkillshotsRow(input[0], input[1], input[2], input[3], input[4], input[5]));
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

	public SkillshotsRow GetRow(rowIds in_RowID)
	{
		SkillshotsRow result = null;
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

	public SkillshotsRow GetRow(string in_RowString)
	{
		SkillshotsRow result = null;
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
