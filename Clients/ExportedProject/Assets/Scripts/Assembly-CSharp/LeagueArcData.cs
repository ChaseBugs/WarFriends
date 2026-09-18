public class LeagueArcData
{
	public bool isBeginnersLeague;

	public int beginnersLeague;

	public int leagueMedals;

	public int position;

	public League league;

	public int numberOfPlayers;

	public bool hasPromote;

	public int promoteMedals;

	public bool hasDemote;

	public int demoteMedals;

	public bool isLeagueProcessing;

	public bool isInLeague;

	public string debugMessage
	{
		get
		{
			if (isBeginnersLeague)
			{
				return $"BEGINNERS {beginnersLeague}   {position}.   {MiscTools.FormatMedalsDifference(leagueMedals)}";
			}
			if (isLeagueProcessing)
			{
				return "PROCESSING";
			}
			if (isInLeague)
			{
				string text = $"{league}   {position}./{numberOfPlayers}   {MiscTools.FormatMedalsDifference(leagueMedals)}";
				if (hasPromote)
				{
					text += $"    promote:{MiscTools.FormatMedalsDifference(promoteMedals)}";
				}
				if (hasDemote)
				{
					text += $"    demote:{MiscTools.FormatMedalsDifference(demoteMedals)}";
				}
				return text;
			}
			return "NOT IN LEAGUE";
		}
	}

	public LeagueArcData()
	{
	}

	public LeagueArcData(League saveLeague, int savePosition, int saveNumberOfPlayers, bool saveHasPromote, int savePromoteMedals, bool saveHasDemote, int saveDemoteMedals, int saveLeagueMedals)
	{
		isBeginnersLeague = false;
		league = saveLeague;
		position = savePosition;
		numberOfPlayers = saveNumberOfPlayers;
		hasPromote = saveHasPromote;
		promoteMedals = savePromoteMedals;
		hasDemote = saveHasDemote;
		demoteMedals = saveDemoteMedals;
		leagueMedals = saveLeagueMedals;
		isInLeague = true;
	}

	public LeagueArcData(int saveBeginnersLeague, int saveLeagueMedals, int savePosition)
	{
		isBeginnersLeague = true;
		beginnersLeague = saveBeginnersLeague;
		leagueMedals = saveLeagueMedals;
		position = savePosition;
	}

	public LeagueArcData(LeagueArcData data)
	{
		isBeginnersLeague = data.isBeginnersLeague;
		beginnersLeague = data.beginnersLeague;
		leagueMedals = data.leagueMedals;
		position = data.position;
		league = data.league;
		numberOfPlayers = data.numberOfPlayers;
		hasPromote = data.hasPromote;
		promoteMedals = data.promoteMedals;
		hasDemote = data.hasDemote;
		demoteMedals = data.demoteMedals;
		isLeagueProcessing = data.isLeagueProcessing;
		isInLeague = data.isInLeague;
	}
}
