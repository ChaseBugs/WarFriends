using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
	public class PlayerVisuals : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			CAMOS_DEFAULT,
			CAMOS_MACHINEGUNNER,
			CAMOS_PARA,
			CAMOS_ALIEN,
			CAMOS_COWBOY,
			CAMOS_NINJA,
			CAMOS_SCIENTIST,
			CAMOS_SUITGUY,
			CAMOS_ZOMBIE,
			CAMOS_SARAH,
			CAMOS_OREN,
			CAMOS_RAPPER,
			CAMOS_RAMBO,
			CAMOS_SPECOPS,
			CAMOS_MADMAX,
			CAMOS_COMMANDO,
			CAMOS_DUSTY,
			BANDS_EMPTY,
			BANDS_CRITICAL_0,
			BANDS_CRITICAL_1,
			BANDS_DAMAGE_0,
			BANDS_DAMAGE_1,
			BANDS_HEALTH_0,
			BANDS_HEALTH_1,
			HEAD_EMPTY,
			HEAD_CIGAR,
			HEAD_SUNGLASSES,
			HEAD_MASK_ROCKET,
			HEAD_GLASSES_SNIPER,
			HEAD_BB_GLASSES,
			HEAD_BEARD,
			HEAD_SANTABEARD,
			HEAD_CLOWN,
			HEAD_EYE_PATCH,
			HEAD_GOOGLES,
			HEAD_LENNON,
			HEAD_LOS_SANTOS,
			HEAD_REBREATHER,
			HEAD_WEST,
			HEAD_ENGINEERELITEGLASSES,
			HEAD_GRENADIERELITEMASK,
			HEAD_GRENADIERMASK,
			HEAD_MACHINEGUNNERBAND,
			HEAD_MACHINEGUNNERGLASSES,
			HEAD_HIPSTERGLASSES,
			HEAD_STEAMPUNKGLASSES,
			HEAD_MADMAXGLASSES,
			HEAD_ROCKETLAUNCHERMASK,
			HEAD_SCIFIGRENADIERMASK,
			HEAD_SWATGLASSES,
			HEAD_BAND,
			HELMETS_SANTA,
			HELMETS_EMPTY,
			HELMETS_DEFAULT,
			HELMETS_BLUEBARRET,
			HELMETS_BLACKCAP,
			HELMETS_EAGLE,
			HELMETS_FOOTBALL,
			HELMETS_HAT,
			HELMETS_CYLINDER,
			HELMETS_MINIGUNHAT,
			HELMETS_HEADCOVER,
			HELMETS_HORNS,
			HELMETS_JASON,
			HELMETS_PUNK,
			HELMETS_SKULL,
			HELMETS_SPARTAN,
			HELMETS_ASSAULT,
			HELMETS_COWBOYHAT,
			HELMETS_ENGINEERELITE,
			HELMETS_ENGINEER,
			HELMETS_FLAMETHROWER,
			HELMETS_GRENADIERELITE,
			HELMETS_GRENADIER,
			HELMETS_MADMAX,
			HELMETS_ROCKETLAUNCHERELITE,
			HELMETS_ROCKETLAUNCHER,
			HELMETS_ELFHAT,
			HELMETS_SCIFIMINIGUNNER,
			HELMETS_SCIFIMINIGUNNERELITE,
			HELMETS_SHOTGUNNER,
			HELMETS_SWATELITE,
			HELMETS_SWATHAT,
			HELMETS_PROPHAT,
			CAMOS_BRUCELEE,
			CAMOS_ASSAULT,
			CAMOS_ELITEENGINEER,
			CAMOS_ELITEPARATROOPER,
			CAMOS_ROCKETLAUNCHER,
			CAMOS_SCIENTIST2,
			HELMETS_VIETNAM,
			HELMETS_CROWNBRONZE,
			HELMETS_CROWNSILVER,
			HELMETS_CROWNGOLD,
			HEAD_HANNIBAL,
			HEAD_PLAGUE,
			HELMETS_PAPERBAG
		}

		public string[] rowNames = new string[97]
		{
			"CAMOS_DEFAULT", "CAMOS_MACHINEGUNNER", "CAMOS_PARA", "CAMOS_ALIEN", "CAMOS_COWBOY", "CAMOS_NINJA", "CAMOS_SCIENTIST", "CAMOS_SUITGUY", "CAMOS_ZOMBIE", "CAMOS_SARAH",
			"CAMOS_OREN", "CAMOS_RAPPER", "CAMOS_RAMBO", "CAMOS_SPECOPS", "CAMOS_MADMAX", "CAMOS_COMMANDO", "CAMOS_DUSTY", "BANDS_EMPTY", "BANDS_CRITICAL_0", "BANDS_CRITICAL_1",
			"BANDS_DAMAGE_0", "BANDS_DAMAGE_1", "BANDS_HEALTH_0", "BANDS_HEALTH_1", "HEAD_EMPTY", "HEAD_CIGAR", "HEAD_SUNGLASSES", "HEAD_MASK_ROCKET", "HEAD_GLASSES_SNIPER", "HEAD_BB_GLASSES",
			"HEAD_BEARD", "HEAD_SANTABEARD", "HEAD_CLOWN", "HEAD_EYE_PATCH", "HEAD_GOOGLES", "HEAD_LENNON", "HEAD_LOS_SANTOS", "HEAD_REBREATHER", "HEAD_WEST", "HEAD_ENGINEERELITEGLASSES",
			"HEAD_GRENADIERELITEMASK", "HEAD_GRENADIERMASK", "HEAD_MACHINEGUNNERBAND", "HEAD_MACHINEGUNNERGLASSES", "HEAD_HIPSTERGLASSES", "HEAD_STEAMPUNKGLASSES", "HEAD_MADMAXGLASSES", "HEAD_ROCKETLAUNCHERMASK", "HEAD_SCIFIGRENADIERMASK", "HEAD_SWATGLASSES",
			"HEAD_BAND", "HELMETS_SANTA", "HELMETS_EMPTY", "HELMETS_DEFAULT", "HELMETS_BLUEBARRET", "HELMETS_BLACKCAP", "HELMETS_EAGLE", "HELMETS_FOOTBALL", "HELMETS_HAT", "HELMETS_CYLINDER",
			"HELMETS_MINIGUNHAT", "HELMETS_HEADCOVER", "HELMETS_HORNS", "HELMETS_JASON", "HELMETS_PUNK", "HELMETS_SKULL", "HELMETS_SPARTAN", "HELMETS_ASSAULT", "HELMETS_COWBOYHAT", "HELMETS_ENGINEERELITE",
			"HELMETS_ENGINEER", "HELMETS_FLAMETHROWER", "HELMETS_GRENADIERELITE", "HELMETS_GRENADIER", "HELMETS_MADMAX", "HELMETS_ROCKETLAUNCHERELITE", "HELMETS_ROCKETLAUNCHER", "HELMETS_ELFHAT", "HELMETS_SCIFIMINIGUNNER", "HELMETS_SCIFIMINIGUNNERELITE",
			"HELMETS_SHOTGUNNER", "HELMETS_SWATELITE", "HELMETS_SWATHAT", "HELMETS_PROPHAT", "CAMOS_BRUCELEE", "CAMOS_ASSAULT", "CAMOS_ELITEENGINEER", "CAMOS_ELITEPARATROOPER", "CAMOS_ROCKETLAUNCHER", "CAMOS_SCIENTIST2",
			"HELMETS_VIETNAM", "HELMETS_CROWNBRONZE", "HELMETS_CROWNSILVER", "HELMETS_CROWNGOLD", "HEAD_HANNIBAL", "HEAD_PLAGUE", "HELMETS_PAPERBAG"
		};

		public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
		{
			{ "CAMOS_DEFAULT", 0 },
			{ "CAMOS_MACHINEGUNNER", 1 },
			{ "CAMOS_PARA", 2 },
			{ "CAMOS_ALIEN", 3 },
			{ "CAMOS_COWBOY", 4 },
			{ "CAMOS_NINJA", 5 },
			{ "CAMOS_SCIENTIST", 6 },
			{ "CAMOS_SUITGUY", 7 },
			{ "CAMOS_ZOMBIE", 8 },
			{ "CAMOS_SARAH", 9 },
			{ "CAMOS_OREN", 10 },
			{ "CAMOS_RAPPER", 11 },
			{ "CAMOS_RAMBO", 12 },
			{ "CAMOS_SPECOPS", 13 },
			{ "CAMOS_MADMAX", 14 },
			{ "CAMOS_COMMANDO", 15 },
			{ "CAMOS_DUSTY", 16 },
			{ "BANDS_EMPTY", 17 },
			{ "BANDS_CRITICAL_0", 18 },
			{ "BANDS_CRITICAL_1", 19 },
			{ "BANDS_DAMAGE_0", 20 },
			{ "BANDS_DAMAGE_1", 21 },
			{ "BANDS_HEALTH_0", 22 },
			{ "BANDS_HEALTH_1", 23 },
			{ "HEAD_EMPTY", 24 },
			{ "HEAD_CIGAR", 25 },
			{ "HEAD_SUNGLASSES", 26 },
			{ "HEAD_MASK_ROCKET", 27 },
			{ "HEAD_GLASSES_SNIPER", 28 },
			{ "HEAD_BB_GLASSES", 29 },
			{ "HEAD_BEARD", 30 },
			{ "HEAD_SANTABEARD", 31 },
			{ "HEAD_CLOWN", 32 },
			{ "HEAD_EYE_PATCH", 33 },
			{ "HEAD_GOOGLES", 34 },
			{ "HEAD_LENNON", 35 },
			{ "HEAD_LOS_SANTOS", 36 },
			{ "HEAD_REBREATHER", 37 },
			{ "HEAD_WEST", 38 },
			{ "HEAD_ENGINEERELITEGLASSES", 39 },
			{ "HEAD_GRENADIERELITEMASK", 40 },
			{ "HEAD_GRENADIERMASK", 41 },
			{ "HEAD_MACHINEGUNNERBAND", 42 },
			{ "HEAD_MACHINEGUNNERGLASSES", 43 },
			{ "HEAD_HIPSTERGLASSES", 44 },
			{ "HEAD_STEAMPUNKGLASSES", 45 },
			{ "HEAD_MADMAXGLASSES", 46 },
			{ "HEAD_ROCKETLAUNCHERMASK", 47 },
			{ "HEAD_SCIFIGRENADIERMASK", 48 },
			{ "HEAD_SWATGLASSES", 49 },
			{ "HEAD_BAND", 50 },
			{ "HELMETS_SANTA", 51 },
			{ "HELMETS_EMPTY", 52 },
			{ "HELMETS_DEFAULT", 53 },
			{ "HELMETS_BLUEBARRET", 54 },
			{ "HELMETS_BLACKCAP", 55 },
			{ "HELMETS_EAGLE", 56 },
			{ "HELMETS_FOOTBALL", 57 },
			{ "HELMETS_HAT", 58 },
			{ "HELMETS_CYLINDER", 59 },
			{ "HELMETS_MINIGUNHAT", 60 },
			{ "HELMETS_HEADCOVER", 61 },
			{ "HELMETS_HORNS", 62 },
			{ "HELMETS_JASON", 63 },
			{ "HELMETS_PUNK", 64 },
			{ "HELMETS_SKULL", 65 },
			{ "HELMETS_SPARTAN", 66 },
			{ "HELMETS_ASSAULT", 67 },
			{ "HELMETS_COWBOYHAT", 68 },
			{ "HELMETS_ENGINEERELITE", 69 },
			{ "HELMETS_ENGINEER", 70 },
			{ "HELMETS_FLAMETHROWER", 71 },
			{ "HELMETS_GRENADIERELITE", 72 },
			{ "HELMETS_GRENADIER", 73 },
			{ "HELMETS_MADMAX", 74 },
			{ "HELMETS_ROCKETLAUNCHERELITE", 75 },
			{ "HELMETS_ROCKETLAUNCHER", 76 },
			{ "HELMETS_ELFHAT", 77 },
			{ "HELMETS_SCIFIMINIGUNNER", 78 },
			{ "HELMETS_SCIFIMINIGUNNERELITE", 79 },
			{ "HELMETS_SHOTGUNNER", 80 },
			{ "HELMETS_SWATELITE", 81 },
			{ "HELMETS_SWATHAT", 82 },
			{ "HELMETS_PROPHAT", 83 },
			{ "CAMOS_BRUCELEE", 84 },
			{ "CAMOS_ASSAULT", 85 },
			{ "CAMOS_ELITEENGINEER", 86 },
			{ "CAMOS_ELITEPARATROOPER", 87 },
			{ "CAMOS_ROCKETLAUNCHER", 88 },
			{ "CAMOS_SCIENTIST2", 89 },
			{ "HELMETS_VIETNAM", 90 },
			{ "HELMETS_CROWNBRONZE", 91 },
			{ "HELMETS_CROWNSILVER", 92 },
			{ "HELMETS_CROWNGOLD", 93 },
			{ "HEAD_HANNIBAL", 94 },
			{ "HEAD_PLAGUE", 95 },
			{ "HELMETS_PAPERBAG", 96 }
		};

		public List<PlayerVisualsRow> Rows = new List<PlayerVisualsRow>();

		public override bool haveDictionary => true;

		public override int getColumnCount => 13;

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
			Rows.Add(new PlayerVisualsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13]));
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			if (namesToIndex.ContainsKey(rowId))
			{
				return -1;
			}
			namesToIndex.Add(rowId, Rows.Count);
			Rows.Add(new PlayerVisualsRow());
			mRows = null;
			return namesToIndex[rowId];
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			if (namesToIndex.ContainsKey(input[0]))
			{
				return -1;
			}
			if (input.Count < 14)
			{
				return -3;
			}
			namesToIndex.Add(input[0], Rows.Count);
			Rows.Add(new PlayerVisualsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13]));
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

		public PlayerVisualsRow GetRow(rowIds in_RowID)
		{
			PlayerVisualsRow result = null;
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

		public PlayerVisualsRow GetRow(string in_RowString)
		{
			PlayerVisualsRow result = null;
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
