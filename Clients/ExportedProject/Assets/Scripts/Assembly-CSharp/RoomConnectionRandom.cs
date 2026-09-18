public class RoomConnectionRandom : RoomConnection
{
	public override bool isRandom => true;

	public override RoomOptions roomOptions
	{
		get
		{
			RoomOptions roomOptions = base.roomOptions;
			roomOptions.IsVisible = true;
			return roomOptions;
		}
	}

	public override int maxSearchSteps => 10;

	public override string lobbyName => "randomLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;

	public override string GetSqlFilter(int attemt)
	{
		string sqlRangeFilterPart = GetSqlRangeFilterPart(attemt, LevelManager.instance.currentLevel.displayNumber, "C0", "Rank");
		string sqlRangeFilterPart2 = GetSqlRangeFilterPart(attemt, (int)GameLoginManager.currentPlayer.leagueTier, "C1", "League");
		string sqlRangeFilterPart3 = GetSqlRangeFilterPart(attemt, GameLoginManager.currentPlayer.medalsBalance, "C2", "Medals");
		string sqlRangeFilterPart4 = GetSqlRangeFilterPart(attemt, LevelManager.instance.armyPower, "C3", "ArmyPower");
		string sqlRangeFilterPart5 = GetSqlRangeFilterPart(attemt, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 100f), "C5", "winLooseStreak", 100f);
		return sqlRangeFilterPart + " AND " + sqlRangeFilterPart2 + " AND " + sqlRangeFilterPart3 + " AND " + sqlRangeFilterPart4 + " AND " + sqlRangeFilterPart5;
	}
}
