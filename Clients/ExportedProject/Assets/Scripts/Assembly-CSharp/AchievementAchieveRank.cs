using Beebyte.Obfuscator;

[SkipRename]
public class AchievementAchieveRank : Achievement
{
	public override Evaluation evaluation => Evaluation.AfterGameOnServerResponse;

	public override bool Evaluate()
	{
		int num = base.currentValue;
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		if (num != displayNumber)
		{
			Report(displayNumber);
			return true;
		}
		return false;
	}
}
