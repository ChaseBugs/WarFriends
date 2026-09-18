using Beebyte.Obfuscator;

[SkipRename]
public class AchievementDeployUnits : Achievement
{
	public override Evaluation evaluation => Evaluation.AfterGame;

	public override bool Evaluate()
	{
		int num = base.currentValue;
		int unitsDeployedTotal = StatsManager.instance.unitsDeployedTotal;
		if (num != unitsDeployedTotal)
		{
			Report(unitsDeployedTotal);
			return true;
		}
		return false;
	}
}
