using Newtonsoft.Json.Linq;

public class DatabasePlayerInfo : DatabasePlayer
{
	public string squadEmblem;

	public bool isBanned;

	public static DatabasePlayer CreateFromDatabase(JToken item)
	{
		return null;
	}

	public static DatabasePlayerInfo CreateBot(DatabasePlayer bot)
	{
		return null;
	}
}
