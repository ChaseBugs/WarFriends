using Newtonsoft.Json.Linq;

public class DatabaseBattle
{
	public long opponentFacebookId;

	public string opponentId;

	public string opponentName;

	public bool playerWon;

	public int skillDifference;

	public int timestamp;

	public static DatabaseBattle CreateFromDatabase(JToken item)
	{
		DatabaseBattle databaseBattle = new DatabaseBattle();
		if (item["TimeStamp"] != null)
		{
			databaseBattle.timestamp = StringParser.ParseInt("TimeStamp", "N", item);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((item["ClientId"] == null) ? "-1" : StringParser.ParseString("ClientId", "S", item, string.Empty));
		string text2 = ((item["MasterId"] == null) ? "-1" : StringParser.ParseString("MasterId", "S", item, string.Empty));
		string text3;
		string text4;
		if (playerId == text)
		{
			databaseBattle.opponentId = text2;
			text3 = "Client";
			text4 = "Master";
		}
		else
		{
			databaseBattle.opponentId = text;
			text3 = "Master";
			text4 = "Client";
		}
		databaseBattle.opponentName = ((item[text4 + "Name"] == null) ? "p0lski" : StringParser.ParseString(text4 + "Name", "S", item, string.Empty));
		databaseBattle.opponentFacebookId = ((item[text4 + "FacebookId"] == null) ? (-1) : StringParser.ParseLong(text4 + "FacebookId", "S", item));
		databaseBattle.skillDifference = ((item[text3 + "SkillDifference"] != null) ? StringParser.ParseInt(text3 + "SkillDifference", "N", item) : 0);
		databaseBattle.playerWon = databaseBattle.skillDifference > 0;
		return databaseBattle;
	}
}
