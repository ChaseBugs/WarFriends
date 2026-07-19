using UnityEngine;

public class StarterAssignmentGainWeeklyMedals : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 4;
		}
	}

	public override string text
	{
		get
		{
			return Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId, MEJMLNDFDBP.AKEMDPDJPLH(mAssigmentsRow.VALUE));
		}
	}

	public override string textProgress
	{
		get
		{
			return string.Format("({0}\u00a0/\u00a0{1})", Mathf.Min(mAssigmentsRow.VALUE, GameLoginManager.currentPlayer.medalsBalance), mAssigmentsRow.VALUE);
		}
	}

	public override bool Evaluate()
	{
		if (!base.completed && GameLoginManager.currentPlayer.medalsBalance >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
