using Beebyte.Obfuscator;

[SkipRename]
public class AchievementWinRankedBattles : Achievement
{
	public override Evaluation evaluation => Evaluation.AfterGame;

	public override bool Evaluate()
	{
		int num = base.currentValue;
		int battlesWonRanked = StatsManager.instance.battlesWonRanked;
		if (num != battlesWonRanked)
		{
			Report(battlesWonRanked);
			return true;
		}
		return false;
	}
}
