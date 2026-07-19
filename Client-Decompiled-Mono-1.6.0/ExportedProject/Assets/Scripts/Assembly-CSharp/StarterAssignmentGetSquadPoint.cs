using UnityEngine;

public class StarterAssignmentGetSquadPoint : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 10;
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
			return string.Format("({0}\u00a0/\u00a0{1})", Mathf.Min(mAssigmentsRow.VALUE, StatsManager.instance.data.squadPointsTotal), mAssigmentsRow.VALUE);
		}
	}

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
