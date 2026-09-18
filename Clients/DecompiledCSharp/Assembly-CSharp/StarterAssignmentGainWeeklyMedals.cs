using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class StarterAssignmentGainWeeklyMedals : StarterAssignment
{
	protected override int numberId => 4;

	public override string text => Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId, MiscTools.FormatFloatNumberSigned(mAssigmentsRow.VALUE));

	public override string textProgress => $"({Mathf.Min(mAssigmentsRow.VALUE, GameLoginManager.currentPlayer.medalsBalance)}\u00a0/\u00a0{mAssigmentsRow.VALUE})";

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
