using Beebyte.Obfuscator;

[SkipRename]
public class AchievementFinishBootcamp : Achievement
{
	public override Evaluation evaluation => Evaluation.AfterGameOnServerResponse;

	public override bool Evaluate()
	{
		if (LevelManager.instance.currentLevel.displayNumber > 3)
		{
			CompleteAchievement();
			return true;
		}
		return false;
	}
}
