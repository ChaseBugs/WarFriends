using UnityEngine;

public class PlayerStatsScreenRecord : PoolableObject
{
	[Header("Header")]
	public UILabel titleLabel;

	[Header("Content")]
	public UILabel contentLabel;

	[Header("Left Part")]
	public UISprite medalsIcon;

	public UISprite leagueIcon;

	public UISprite missionIcon;

	public GameObject coopIcon;

	public UISprite starsIcon;

	public UISprite armyPowerIcon;

	public UISprite squadPointsIcon;

	public void Init(OverallStats.PlayerStat statToShow)
	{
		titleLabel.text = statToShow.statisticsName;
		MiscTools.SetUILabelRescale(titleLabel, 37f, 20f, 500);
		contentLabel.color = ((statToShow.statisticsType == OverallStats.PlayerStat.StatType.ArmyPower) ? Colours.greenArmyPower : ((statToShow.statisticsType != OverallStats.PlayerStat.StatType.SquadPoints) ? Colours.blue : Colours.goldWar));
		switch (statToShow.statisticsType)
		{
		case OverallStats.PlayerStat.StatType.SimpleInt:
		case OverallStats.PlayerStat.StatType.Medals:
		case OverallStats.PlayerStat.StatType.ArmyPower:
		case OverallStats.PlayerStat.StatType.SquadPoints:
			contentLabel.text = ((statToShow.statisticSimpleInt >= 0) ? MiscTools.FormatBigNumber(statToShow.statisticSimpleInt) : "-");
			break;
		case OverallStats.PlayerStat.StatType.SimpleFloat:
			contentLabel.text = ((!(statToShow.statisticsSimpleFloat < 0f)) ? MiscTools.FormatFloatNumberRoundOne(statToShow.statisticsSimpleFloat) : "-");
			break;
		case OverallStats.PlayerStat.StatType.SimplePercent:
			contentLabel.text = ((statToShow.statisticSimpleInt >= 0) ? MiscTools.FormatNumberAsPercent(statToShow.statisticSimpleInt) : "-");
			break;
		case OverallStats.PlayerStat.StatType.SimpleTime:
			contentLabel.text = MiscTools.PrintableWholeTime(statToShow.statisticSimpleInt, showSeconds: false);
			break;
		case OverallStats.PlayerStat.StatType.SimpleIntInt:
		case OverallStats.PlayerStat.StatType.Missions:
		case OverallStats.PlayerStat.StatType.Coop:
		case OverallStats.PlayerStat.StatType.Stars:
			contentLabel.text = $"{MiscTools.FormatBigNumber(statToShow.statisticSimpleInt)} {Colours.stringGrayLight}/ {MiscTools.FormatBigNumber(statToShow.statisticsSecondInt)}";
			break;
		case OverallStats.PlayerStat.StatType.League:
			contentLabel.text = GameVariables.leagueNames[statToShow.statisticsLeague].Value1;
			leagueIcon.alpha = ((statToShow.statisticsLeague != League.NoLeague) ? 1f : 0f);
			leagueIcon.spriteName = GameVariables.leagueNames[statToShow.statisticsLeague].Value2;
			leagueIcon.MakePixelPerfect();
			break;
		case OverallStats.PlayerStat.StatType.SimpleLong:
			contentLabel.text = ((statToShow.statisticSimpleLong >= 0) ? MiscTools.FormatBigNumberLong(statToShow.statisticSimpleLong) : "-");
			break;
		}
		medalsIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.Medals);
		leagueIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.League);
		missionIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.Missions);
		coopIcon.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.Coop);
		starsIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.Stars);
		armyPowerIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.ArmyPower);
		squadPointsIcon.gameObject.SetActive(statToShow.statisticsType == OverallStats.PlayerStat.StatType.SquadPoints);
	}
}
