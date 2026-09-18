using Beebyte.Obfuscator;

[SkipRename]
public class AchievementCompleteWarpath : Achievement
{
	public override Evaluation evaluation => Evaluation.AfterGame;

	public override bool Evaluate()
	{
		int num = base.currentValue;
		int completedMissionsCount = MissionsManager.instance.completedMissionsCount;
		if (num != completedMissionsCount)
		{
			Report(completedMissionsCount);
			return true;
		}
		return false;
	}
}
