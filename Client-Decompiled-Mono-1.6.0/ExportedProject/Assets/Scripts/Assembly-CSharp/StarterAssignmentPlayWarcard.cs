using UnityEngine;

public class StarterAssignmentPlayWarcard : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 2;
		}
	}

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

	public override string textProgress
	{
		get
		{
			return string.Format("({0}\u00a0/\u00a0{1})", Mathf.Min(mAssigmentsRow.VALUE, StatsManager.instance.cardsPlayed), mAssigmentsRow.VALUE);
		}
	}

	public override bool Evaluate()
	{
		if (!base.completed && StatsManager.instance.cardsPlayed >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
