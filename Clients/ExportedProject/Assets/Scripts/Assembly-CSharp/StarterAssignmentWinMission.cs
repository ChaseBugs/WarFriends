using UnityEngine;

public abstract class StarterAssignmentWinMission : StarterAssignment
{
	public override string text => Localization.LocalizeFormat("ID_STARTERASSIGNMENT6", MiscTools.FormatNumberToOrdinal(mAssigmentsRow.VALUE));

	public override string textProgress
	{
		get
		{
			int index = Mathf.Clamp(mAssigmentsRow.VALUE - 1, 0, LevelManager.instance.levels.Count);
			int num = (MissionsManager.instance.missions[index].completed ? 1 : 0);
			return $"({num}\u00a0/\u00a0{1})";
		}
	}

	public override bool Evaluate()
	{
		int value = mAssigmentsRow.VALUE - 1;
		value = Mathf.Clamp(value, 0, LevelManager.instance.levels.Count);
		bool flag = MissionsManager.instance.missions[value].completed;
		if (!base.completed && flag)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
