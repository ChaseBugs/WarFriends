using UnityEngine;

public abstract class PCBGILMJNCE : StarterAssignment
{
	public override string text => Localization.LocalizeFormat("ID_STARTERASSIGNMENT5", mAssigmentsRow.VALUE);

	public override string textProgress => $"({Mathf.Min(mAssigmentsRow.VALUE, LevelManager.instance.currentLevel.displayNumber)}\u00a0/\u00a0{mAssigmentsRow.VALUE})";

	public override bool Evaluate()
	{
		if (!base.completed && LevelManager.instance.currentLevel.displayNumber >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
