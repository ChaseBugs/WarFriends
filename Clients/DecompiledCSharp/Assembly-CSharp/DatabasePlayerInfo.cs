using System.Collections.Generic;
using Beebyte.Obfuscator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Skip]
public class DatabasePlayerInfo : DatabasePlayer
{
	public string squadEmblem;

	public bool isBanned;

	public static DatabasePlayer CreateFromDatabase(JToken item)
	{
		DatabasePlayerInfo databasePlayerInfo = (DatabasePlayerInfo)DatabasePlayer.CreateFromDatabase(item, new DatabasePlayerInfo());
		if (item["SquadEmblem"] != null)
		{
			databasePlayerInfo.squadEmblem = StringParser.ParseString("SquadEmblem", "S", item, string.Empty);
		}
		if (item["GameBan"] != null)
		{
			string text = StringParser.ParseString("GameBan", "S", item, string.Empty);
			if (text.Contains("timestamp"))
			{
				Dictionary<string, int> dictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(text);
				databasePlayerInfo.isBanned = ((dictionary["timestamp"] > Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? true : false);
			}
			if (text.Contains("forever"))
			{
				databasePlayerInfo.isBanned = true;
			}
		}
		else
		{
			databasePlayerInfo.isBanned = false;
		}
		return databasePlayerInfo;
	}

	public static DatabasePlayerInfo CreateBot(DatabasePlayer bot)
	{
		DatabasePlayerInfo databasePlayerInfo = new DatabasePlayerInfo();
		databasePlayerInfo.accountName = bot.accountName;
		databasePlayerInfo.level = bot.level;
		databasePlayerInfo.id = bot.id;
		databasePlayerInfo.medalsBalance = bot.medalsBalance;
		databasePlayerInfo.beginnersLeague = bot.beginnersLeague;
		databasePlayerInfo.skill = bot.skill;
		databasePlayerInfo.statisticsData = bot.statisticsData;
		databasePlayerInfo.playerVisuals = bot.playerVisuals;
		databasePlayerInfo.levelManagerData = bot.levelManagerData;
		databasePlayerInfo.inventoryData = bot.inventoryData;
		databasePlayerInfo.equippedUnits = bot.equippedUnits;
		databasePlayerInfo.armyPower = bot.armyPower;
		return databasePlayerInfo;
	}
}
