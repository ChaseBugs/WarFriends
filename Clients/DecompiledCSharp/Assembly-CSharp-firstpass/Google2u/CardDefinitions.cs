using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class CardDefinitions : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		SLOWMOVE,
		FREEZE,
		HEAVYDRONE,
		APOCALYPSE,
		SHIELDRAFFLE,
		MINEENEMY,
		BIGROCKET,
		ELITEMINIGUN,
		IMMORTAL,
		ROCKETTURRET,
		DISARMED,
		ELITESWAT,
		CHEMICALUNIT,
		ELITETANK,
		TOPBUILDERS,
		BIGMEDKIT,
		AIRSTRIKE,
		MADGANG,
		SABOTAGE,
		HEAVYTURRET,
		ELITESNIPER,
		CLUSTERGRENADE,
		HEADAHEAD,
		HELISTRIKE,
		KEVLARUP,
		MIRRORMYSELF,
		REFLECTION,
		AMMOTHIEF,
		EMPTYMAG,
		GREATGRENADIER,
		MEATHEADS,
		INVISIBILITY,
		BOOBYTRAP,
		ELECTRICTRAPS,
		SMALLMEDKIT,
		ELITEPARA,
		VEHICLEHEALTH,
		TURRETCRATE,
		HEALTHCRATE,
		KEVLARCRATE,
		BULLETHARMLESS,
		AMMOBOX,
		BACKSTAB,
		EXPLOSIVEPISTOL,
		MEDKIT,
		DECOY,
		MAXHEALTHINC,
		MINE,
		TURRET,
		RANDOMKEVLAR,
		EXPLOSIVETIMING,
		STREAKBOOST,
		DESTROYSHIELD,
		SHIELDSPAWNER,
		SHIELDSHEALTH,
		SLOWDOWN,
		HEALINGSTORM,
		TRIGGERHAPPY,
		AMMOCRATE,
		SICKNESS,
		CRITICALS,
		SUPERSOLDIERS,
		PARALYZE,
		CRATEBLOCKER,
		SHIELDGENERATOR,
		PLAGUE,
		PLAYERINVIS,
		HELIASSAULT,
		HEALTEAM,
		SCORESTREAK,
		HEALTHYUNIT,
		HEALINGSALVE,
		GRENADETIMING,
		DESTRUCTIVESHOT,
		SHIELDINGSHOT,
		SHRINK,
		ARMYSPAWNFAST,
		MAXHEALTHINCSOL,
		SEEENEMY,
		INCREASERANKS,
		ENGINEER,
		DEPLOYALL,
		CANTDIENOW
	}

	public string[] rowNames = new string[83]
	{
		"SLOWMOVE", "FREEZE", "HEAVYDRONE", "APOCALYPSE", "SHIELDRAFFLE", "MINEENEMY", "BIGROCKET", "ELITEMINIGUN", "IMMORTAL", "ROCKETTURRET",
		"DISARMED", "ELITESWAT", "CHEMICALUNIT", "ELITETANK", "TOPBUILDERS", "BIGMEDKIT", "AIRSTRIKE", "MADGANG", "SABOTAGE", "HEAVYTURRET",
		"ELITESNIPER", "CLUSTERGRENADE", "HEADAHEAD", "HELISTRIKE", "KEVLARUP", "MIRRORMYSELF", "REFLECTION", "AMMOTHIEF", "EMPTYMAG", "GREATGRENADIER",
		"MEATHEADS", "INVISIBILITY", "BOOBYTRAP", "ELECTRICTRAPS", "SMALLMEDKIT", "ELITEPARA", "VEHICLEHEALTH", "TURRETCRATE", "HEALTHCRATE", "KEVLARCRATE",
		"BULLETHARMLESS", "AMMOBOX", "BACKSTAB", "EXPLOSIVEPISTOL", "MEDKIT", "DECOY", "MAXHEALTHINC", "MINE", "TURRET", "RANDOMKEVLAR",
		"EXPLOSIVETIMING", "STREAKBOOST", "DESTROYSHIELD", "SHIELDSPAWNER", "SHIELDSHEALTH", "SLOWDOWN", "HEALINGSTORM", "TRIGGERHAPPY", "AMMOCRATE", "SICKNESS",
		"CRITICALS", "SUPERSOLDIERS", "PARALYZE", "CRATEBLOCKER", "SHIELDGENERATOR", "PLAGUE", "PLAYERINVIS", "HELIASSAULT", "HEALTEAM", "SCORESTREAK",
		"HEALTHYUNIT", "HEALINGSALVE", "GRENADETIMING", "DESTRUCTIVESHOT", "SHIELDINGSHOT", "SHRINK", "ARMYSPAWNFAST", "MAXHEALTHINCSOL", "SEEENEMY", "INCREASERANKS",
		"ENGINEER", "DEPLOYALL", "CANTDIENOW"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "SLOWMOVE", 0 },
		{ "FREEZE", 1 },
		{ "HEAVYDRONE", 2 },
		{ "APOCALYPSE", 3 },
		{ "SHIELDRAFFLE", 4 },
		{ "MINEENEMY", 5 },
		{ "BIGROCKET", 6 },
		{ "ELITEMINIGUN", 7 },
		{ "IMMORTAL", 8 },
		{ "ROCKETTURRET", 9 },
		{ "DISARMED", 10 },
		{ "ELITESWAT", 11 },
		{ "CHEMICALUNIT", 12 },
		{ "ELITETANK", 13 },
		{ "TOPBUILDERS", 14 },
		{ "BIGMEDKIT", 15 },
		{ "AIRSTRIKE", 16 },
		{ "MADGANG", 17 },
		{ "SABOTAGE", 18 },
		{ "HEAVYTURRET", 19 },
		{ "ELITESNIPER", 20 },
		{ "CLUSTERGRENADE", 21 },
		{ "HEADAHEAD", 22 },
		{ "HELISTRIKE", 23 },
		{ "KEVLARUP", 24 },
		{ "MIRRORMYSELF", 25 },
		{ "REFLECTION", 26 },
		{ "AMMOTHIEF", 27 },
		{ "EMPTYMAG", 28 },
		{ "GREATGRENADIER", 29 },
		{ "MEATHEADS", 30 },
		{ "INVISIBILITY", 31 },
		{ "BOOBYTRAP", 32 },
		{ "ELECTRICTRAPS", 33 },
		{ "SMALLMEDKIT", 34 },
		{ "ELITEPARA", 35 },
		{ "VEHICLEHEALTH", 36 },
		{ "TURRETCRATE", 37 },
		{ "HEALTHCRATE", 38 },
		{ "KEVLARCRATE", 39 },
		{ "BULLETHARMLESS", 40 },
		{ "AMMOBOX", 41 },
		{ "BACKSTAB", 42 },
		{ "EXPLOSIVEPISTOL", 43 },
		{ "MEDKIT", 44 },
		{ "DECOY", 45 },
		{ "MAXHEALTHINC", 46 },
		{ "MINE", 47 },
		{ "TURRET", 48 },
		{ "RANDOMKEVLAR", 49 },
		{ "EXPLOSIVETIMING", 50 },
		{ "STREAKBOOST", 51 },
		{ "DESTROYSHIELD", 52 },
		{ "SHIELDSPAWNER", 53 },
		{ "SHIELDSHEALTH", 54 },
		{ "SLOWDOWN", 55 },
		{ "HEALINGSTORM", 56 },
		{ "TRIGGERHAPPY", 57 },
		{ "AMMOCRATE", 58 },
		{ "SICKNESS", 59 },
		{ "CRITICALS", 60 },
		{ "SUPERSOLDIERS", 61 },
		{ "PARALYZE", 62 },
		{ "CRATEBLOCKER", 63 },
		{ "SHIELDGENERATOR", 64 },
		{ "PLAGUE", 65 },
		{ "PLAYERINVIS", 66 },
		{ "HELIASSAULT", 67 },
		{ "HEALTEAM", 68 },
		{ "SCORESTREAK", 69 },
		{ "HEALTHYUNIT", 70 },
		{ "HEALINGSALVE", 71 },
		{ "GRENADETIMING", 72 },
		{ "DESTRUCTIVESHOT", 73 },
		{ "SHIELDINGSHOT", 74 },
		{ "SHRINK", 75 },
		{ "ARMYSPAWNFAST", 76 },
		{ "MAXHEALTHINCSOL", 77 },
		{ "SEEENEMY", 78 },
		{ "INCREASERANKS", 79 },
		{ "ENGINEER", 80 },
		{ "DEPLOYALL", 81 },
		{ "CANTDIENOW", 82 }
	};

	public List<CardDefinitionsRow> Rows = new List<CardDefinitionsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 4;

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
		Rows.Add(new CardDefinitionsRow(input[0], input[1], input[2], input[3], input[4]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new CardDefinitionsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 5)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new CardDefinitionsRow(input[0], input[1], input[2], input[3], input[4]));
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

	public CardDefinitionsRow GetRow(rowIds in_RowID)
	{
		CardDefinitionsRow result = null;
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

	public CardDefinitionsRow GetRow(string in_RowString)
	{
		CardDefinitionsRow result = null;
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
