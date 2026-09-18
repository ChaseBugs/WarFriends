using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class StarterAssignmentWinPVPBattle : StarterAssignment
{
	protected override int numberId => 1;

	public override string text
	{
		get
		{
			int vALUE = mAssigmentsRow.VALUE;
			if (vALUE > 1)
			{
				return Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId + "S", vALUE);
			}
			return Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId, vALUE);
		}
	}

	public override string textProgress => $"({Mathf.Min(mAssigmentsRow.VALUE, StatsManager.instance.battlesWonRanked)}\u00a0/\u00a0{mAssigmentsRow.VALUE})";

	public override bool Evaluate()
	{
		if (!base.completed && StatsManager.instance.battlesWonRanked >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
