using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class StarterAssignmentGetSquadPoint : StarterAssignment
{
	protected override int numberId => 10;

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

	public override string textProgress => $"({Mathf.Min(mAssigmentsRow.VALUE, StatsManager.instance.data.squadPointsTotal)}\u00a0/\u00a0{mAssigmentsRow.VALUE})";

	public override bool Evaluate()
	{
		if (!base.completed && StatsManager.instance.data.squadPointsTotal >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
