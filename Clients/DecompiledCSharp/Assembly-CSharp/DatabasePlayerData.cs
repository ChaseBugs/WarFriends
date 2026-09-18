using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabasePlayerData : IDatabasePlayer
{
	public int armyPower;

	public long experience;

	public long facebookId;

	public string id;

	public int level;

	public int levelExperience;

	public string accountName;

	public int skill;

	public string squadId;

	public string country;

	public string leagueDivision;

	public string leagueId;

	public League leagueTier = League.Bronze3;

	public int beginnersLeague;

	public int leaderboardPosition;

	public CamosManager.DecalManagerData decalData;

	private WarArena.WarArenaData mWarArenaData;

	public int armyPowerX10 => 10 * armyPower;

	public bool isInBeginnersLeague => beginnersLeague > 0 && string.IsNullOrEmpty(leagueId);

	public bool isInLeague
	{
		get
		{
			if (leagueDivision == "placement" || isInBeginnersLeague)
			{
				return false;
			}
			return !string.IsNullOrEmpty(leagueDivision);
		}
	}

	public WarArenaCrown warArenaCrown
	{
		get
		{
			if (mWarArenaData == null)
			{
				return WarArenaCrown.None;
			}
			if (mWarArenaData.visualTimestamp < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				return WarArenaCrown.None;
			}
			return mWarArenaData.visualType switch
			{
				"bronze" => WarArenaCrown.BronzeCrown, 
				"silver" => WarArenaCrown.SilverCrown, 
				"gold" => WarArenaCrown.GoldCrown, 
				"flawless" => WarArenaCrown.Flawless, 
				_ => WarArenaCrown.None, 
			};
		}
	}

	public bool hasFlawlessRun => mWarArenaData.flawless > 0;

	public int heroWins => (!hasFlawlessRun) ? mWarArenaData.topRun : mWarArenaData.flawless;

	public string name => accountName;

	public string visualsDebugLog
	{
		get
		{
			if (decalData.slots == null)
			{
				return "visuals: null";
			}
			if (decalData.slots.Count != 4)
			{
				string arg = string.Empty;
				foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in decalData.slots)
				{
					arg = " " + slot.Value.equippedID;
				}
				return $"visuals: wrong number {decalData.slots.Count} -{arg}";
			}
			return $"visuals: {decalData.slots[0].equippedID} {decalData.slots[1].equippedID} {decalData.slots[2].equippedID} {decalData.slots[3].equippedID}";
		}
	}

	public static DatabasePlayerData currentPlayer
	{
		get
		{
			DatabasePlayerData databasePlayerData = new DatabasePlayerData();
			databasePlayerData.armyPower = LevelManager.instance.armyPower;
			databasePlayerData.experience = LevelManager.instance.experience;
			databasePlayerData.facebookId = GameLoginManager.currentPlayer.facebookId;
			databasePlayerData.id = GameLoginManager.currentPlayer.id;
			databasePlayerData.level = LevelManager.instance.currentLevel.index;
			databasePlayerData.levelExperience = LevelManager.instance.levelExperience;
			databasePlayerData.accountName = GameLoginManager.currentPlayer.accountName;
			databasePlayerData.skill = GameLoginManager.currentPlayer.skill;
			databasePlayerData.squadId = GameLoginManager.currentPlayer.squadName;
			databasePlayerData.leaderboardPosition = PlayerAnalytics.instance.globalPositon;
			databasePlayerData.decalData = CamosManager.instance.data;
			databasePlayerData.country = GameLoginManager.currentPlayer.country;
			databasePlayerData.leagueTier = GameLoginManager.currentPlayer.leagueTier;
			databasePlayerData.leagueDivision = GameLoginManager.currentPlayer.leagueDivision;
			databasePlayerData.mWarArenaData = WarArena.instance.data;
			return databasePlayerData;
		}
	}

	internal static DatabasePlayerData CreateFromDatabase(JToken item)
	{
		DatabasePlayerData databasePlayerData = new DatabasePlayerData();
		if (item["PlayerId"] != null)
		{
			databasePlayerData.id = StringParser.ParseString("PlayerId", "S", item, string.Empty);
		}
		if (item["PlayerName"] != null)
		{
			databasePlayerData.accountName = StringParser.ParseString("PlayerName", "S", item, string.Empty);
		}
		if (item["Experience"] != null)
		{
			databasePlayerData.experience = StringParser.ParseLong("Experience", "N", item);
		}
		if (item["Level"] != null)
		{
			databasePlayerData.level = StringParser.ParseInt("Level", "N", item);
		}
		if (item["LevelExperience"] != null)
		{
			databasePlayerData.levelExperience = StringParser.ParseInt("LevelExperience", "N", item);
		}
		if (item["ArmyPower"] != null)
		{
			databasePlayerData.armyPower = StringParser.ParseInt("ArmyPower", "N", item);
		}
		if (item["Skill"] != null)
		{
			databasePlayerData.skill = StringParser.ParseInt("Skill", "N", item);
		}
		if (item["FacebookId"] != null)
		{
			databasePlayerData.facebookId = StringParser.ParseLong("FacebookId", "S", item);
		}
		if (item["SquadId"] != null)
		{
			databasePlayerData.squadId = StringParser.ParseString("SquadId", "S", item, string.Empty);
		}
		if (item["Position"] != null)
		{
			databasePlayerData.leaderboardPosition = StringParser.ParseInt("Position", "N", item);
		}
		if (item["LeagueId"] != null)
		{
			databasePlayerData.leagueId = StringParser.ParseString("LeagueId", "S", item, string.Empty);
			databasePlayerData.leagueTier = (League)StringParser.ParseInt(Regex.Replace(databasePlayerData.leagueId, "-[^-]*$", string.Empty));
			databasePlayerData.leagueDivision = StringParser.ParseString(Regex.Replace(databasePlayerData.leagueId, "^[0-9]*-", string.Empty), string.Empty);
		}
		if (item["BeginnersLeague"] != null)
		{
			databasePlayerData.beginnersLeague = StringParser.ParseInt("BeginnersLeague", "N", item);
		}
		if (item["BeginnersLeague"] == null && item["LeagueId"] == null)
		{
			databasePlayerData.leagueId = "1-placement";
			databasePlayerData.leagueTier = (League)StringParser.ParseInt(Regex.Replace(databasePlayerData.leagueId, "-[^-]*$", string.Empty));
			databasePlayerData.leagueDivision = StringParser.ParseString(Regex.Replace(databasePlayerData.leagueId, "^[0-9]*-", string.Empty), string.Empty);
		}
		if (item["Country"] != null)
		{
			databasePlayerData.country = StringParser.ParseString("Country", "S", item, string.Empty);
		}
		if (item["WarArenaData"] != null)
		{
			try
			{
				databasePlayerData.mWarArenaData = JsonConvert.DeserializeObject<WarArena.WarArenaData>(StringParser.ParseString("WarArenaData", "S", item, string.Empty));
			}
			catch (Exception exception)
			{
				Debug.LogError("Bad War Arena Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, "Bad WAR ARENA Data, data= " + StringParser.ParseString("WarArenaData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["DecalManagerData"] != null)
		{
			try
			{
				CamosManager.DecalManagerData decalManagerData = new CamosManager.DecalManagerData();
				object obj = JsonConvert.DeserializeObject(StringParser.ParseString("DecalManagerData", "S", item, string.Empty));
				JToken jToken = (JToken)obj;
				JToken jToken2 = jToken["slots"];
				if (jToken2 != null)
				{
					foreach (JToken item2 in jToken2.Children())
					{
						if (item2 is JProperty { First: not null, First: var first } jProperty)
						{
							CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
							if (first["equippedID"] != null)
							{
								savedPlayerVisualSlot.equippedID = first["equippedID"].ToObject<string>();
							}
							decalManagerData.slots.Add(Convert.ToInt32(jProperty.Name), savedPlayerVisualSlot);
						}
					}
				}
				databasePlayerData.decalData = decalManagerData;
			}
			catch (Exception exception2)
			{
				Debug.LogError("Bad Decal Manager Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception2, "Bad Decal Manager Data, data= " + StringParser.ParseString("DecalManagerData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		return databasePlayerData;
	}

	public string GetSquadId()
	{
		return squadId;
	}

	public string GetId()
	{
		return id;
	}

	public void SetSquadId(string newSquadId)
	{
		squadId = newSquadId;
	}
}
