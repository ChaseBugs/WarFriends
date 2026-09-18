using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

public class DatabaseSquad
{
	public static int maxMedalsRequirement = 5000;

	public static int maxSquadName = 15;

	public static int maxSquadMessage = 100;

	public int experience;

	public string icon;

	public bool isPublic;

	public long levelExperience;

	public string message;

	public string name;

	public int rank;

	public string roundId;

	public int squadWarDivision;

	public int size;

	public int skill;

	public int skillRequirement;

	public int squadPoints;

	public int globalPosition;

	public int warsPosition;

	public int bestSkill;

	public string division;

	public int battlesLost;

	public int battlesWon;

	public int cardsPlayed;

	public int kills;

	public int unitsDeployed;

	public int tiersCompleted;

	public int squadPointsBest;

	public int squadWarWins;

	public bool isInDivision => squadPoints > 0 && !string.IsNullOrEmpty(roundId) && division != "placement";

	public int battlesPlayed => battlesWon + battlesLost;

	public float winLoseRatio
	{
		get
		{
			if (battlesLost == 0)
			{
				return -1f;
			}
			return (float)battlesWon / (float)battlesLost;
		}
	}

	internal static DatabaseSquad CreateFromDatabase(JToken item)
	{
		DatabaseSquad databaseSquad = new DatabaseSquad();
		if (item == null)
		{
			return databaseSquad;
		}
		if (item["Id"] != null)
		{
			databaseSquad.name = GetString(item, "Id");
		}
		if (item["IsPublic"] != null)
		{
			int num = GetInt(item, "IsPublic");
			databaseSquad.isPublic = num != 0;
		}
		databaseSquad.globalPosition = GetInt(item, "Position");
		databaseSquad.message = GetString(item, "Message");
		databaseSquad.roundId = GetString(item, "RoundId");
		databaseSquad.division = StringParser.ParseString(Regex.Replace(databaseSquad.roundId, "^[0-9]*-", string.Empty), string.Empty);
		int result = 1;
		int.TryParse(Regex.Replace(databaseSquad.roundId, "-[^-]*$", string.Empty), out result);
		databaseSquad.squadWarDivision = result;
		databaseSquad.size = GetInt(item, "Size");
		databaseSquad.skill = GetInt(item, "Skill");
		databaseSquad.rank = GetInt(item, "Level");
		databaseSquad.skillRequirement = GetInt(item, "SkillRequirement");
		databaseSquad.squadPoints = GetInt(item, "SquadPoints");
		string squadWarsId = Singleton<ServerResultsCache>.instance.squadWarsId;
		if (!string.IsNullOrEmpty(squadWarsId))
		{
			databaseSquad.squadPoints += GetInt(item, squadWarsId);
		}
		databaseSquad.experience = GetInt(item, "Experience");
		databaseSquad.levelExperience = GetLong(item, "LevelExperience");
		databaseSquad.icon = GetString(item, "Icon");
		databaseSquad.kills = GetInt(item, "Kills");
		databaseSquad.battlesLost = GetInt(item, "BattlesLost");
		databaseSquad.battlesWon = GetInt(item, "BattlesWon");
		databaseSquad.cardsPlayed = GetInt(item, "CardsPlayed");
		databaseSquad.bestSkill = GetInt(item, "BestSkill");
		if (databaseSquad.bestSkill == 0 && databaseSquad.skill > 0)
		{
			databaseSquad.bestSkill = databaseSquad.skill;
		}
		databaseSquad.unitsDeployed = GetInt(item, "UnitsDeployed");
		databaseSquad.tiersCompleted = GetInt(item, "TiersCompleted");
		databaseSquad.squadPointsBest = GetInt(item, "SquadPointsBest");
		if (databaseSquad.squadPointsBest == 0 || databaseSquad.squadPointsBest < databaseSquad.squadPoints)
		{
			databaseSquad.squadPointsBest = databaseSquad.squadPoints;
		}
		databaseSquad.squadWarWins = GetInt(item, "SquadWarWins");
		return databaseSquad;
	}

	public int GetPlacesLeft()
	{
		int squadRankSize = Singleton<GameVariables>.instance.GetSquadRankSize(rank);
		return squadRankSize - size;
	}

	public bool IsFull()
	{
		int squadRankSize = Singleton<GameVariables>.instance.GetSquadRankSize(rank);
		return squadRankSize <= size;
	}

	private static string GetString(JToken item, string key)
	{
		if (item[key] == null)
		{
			return string.Empty;
		}
		JToken jToken = item[key];
		return (jToken is JValue) ? StringParser.ParseString(jToken, string.Empty) : StringParser.ParseString(key, "S", item, string.Empty);
	}

	private static int GetInt(JToken item, string key)
	{
		if (item[key] == null)
		{
			return 0;
		}
		JToken jToken = item[key];
		return (jToken is JValue) ? StringParser.ParseIntToken(jToken) : StringParser.ParseInt(key, "N", item);
	}

	private static long GetLong(JToken item, string key)
	{
		if (item[key] == null)
		{
			return 0L;
		}
		JToken jToken = item[key];
		return (jToken is JValue) ? StringParser.ParseLongToken(jToken, 0L) : StringParser.ParseLong(key, "N", item);
	}
}
