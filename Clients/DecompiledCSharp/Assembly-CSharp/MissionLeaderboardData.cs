public class MissionLeaderboardData
{
	public bool isInvite;

	public int score;

	public DatabasePlayerMissionLeaderboard data;

	public static MissionLeaderboardData Load(DatabasePlayerMissionLeaderboard missionScores, int missionIndex)
	{
		MissionLeaderboardData missionLeaderboardData = new MissionLeaderboardData();
		missionLeaderboardData.isInvite = false;
		missionLeaderboardData.data = missionScores;
		if (missionScores.id == GameLoginManager.instance.playerId && MissionsManager.instance.data.missionData.ContainsKey(missionIndex))
		{
			missionLeaderboardData.score = MissionsManager.instance.data.missionData[missionIndex].highscore;
		}
		else
		{
			missionLeaderboardData.score = missionScores.GetMissionScore(missionIndex);
		}
		return missionLeaderboardData;
	}

	public static MissionLeaderboardData CreateInvite()
	{
		MissionLeaderboardData missionLeaderboardData = new MissionLeaderboardData();
		missionLeaderboardData.isInvite = true;
		missionLeaderboardData.score = -1;
		return missionLeaderboardData;
	}
}
