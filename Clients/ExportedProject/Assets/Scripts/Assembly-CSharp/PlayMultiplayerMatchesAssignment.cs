using System;
using Beebyte.Obfuscator;

[Skip]
internal class PlayMultiplayerMatchesAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-playvs";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public PlayMultiplayerMatchesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(8, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int gained = ((!Singleton<GameController>.instance.isMission) ? 1 : 0);
		base.completeFract = CompareIntAndInt(gained, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
