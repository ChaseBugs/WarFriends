using System;
using Beebyte.Obfuscator;

[Skip]
public class DestroyCratesAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-crate";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public override bool hasHint => true;

	public override string hintText => Localization.Localize("ID_ASSIGNMENTHINTCRATES");

	public DestroyCratesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(0, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int numberOfDestroyedBoxesInLastGame = Singleton<KillStreakManager>.instance.numberOfDestroyedBoxesInLastGame;
		base.completeFract = CompareIntAndInt(numberOfDestroyedBoxesInLastGame, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
