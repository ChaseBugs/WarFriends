using Newtonsoft.Json.Linq;

public class DatabasePlayerOnHitList : DatabasePlayer
{
	public int totalBattles;

	public int wonBattles;

	public static DatabasePlayerOnHitList CreateFromDatabase(JToken item)
	{
		DatabasePlayerOnHitList databasePlayerOnHitList = new DatabasePlayerOnHitList();
		if (item["Id"] != null)
		{
			databasePlayerOnHitList.id = StringParser.ParseString("Id", "S", item, string.Empty);
		}
		if (item["Name"] != null)
		{
			databasePlayerOnHitList.accountName = StringParser.ParseString("Name", "S", item, string.Empty);
		}
		if (item["ArmyPower"] != null)
		{
			databasePlayerOnHitList.armyPower = StringParser.ParseInt("ArmyPower", "N", item);
		}
		if (item["Status"] != null)
		{
			databasePlayerOnHitList.status = (PlayerStatus)StringParser.ParseInt("Status", "N", item);
		}
		if (item["LastAction"] != null)
		{
			databasePlayerOnHitList.lastAction = StringParser.ParseInt("LastAction", "N", item);
		}
		if (item["DeviceToken"] != null)
		{
			databasePlayerOnHitList.deviceToken = StringParser.ParseString("DeviceToken", "S", item, string.Empty);
		}
		if (item["HitListItem"] == null)
		{
			return databasePlayerOnHitList;
		}
		JToken jToken = item["HitListItem"];
		if (jToken["TotalBattles"] != null)
		{
			databasePlayerOnHitList.totalBattles = StringParser.ParseInt("TotalBattles", "N", item);
		}
		if (jToken["WonBattles"] != null)
		{
			databasePlayerOnHitList.wonBattles = StringParser.ParseInt("WonBattles", "N", item);
		}
		return databasePlayerOnHitList;
	}
}
