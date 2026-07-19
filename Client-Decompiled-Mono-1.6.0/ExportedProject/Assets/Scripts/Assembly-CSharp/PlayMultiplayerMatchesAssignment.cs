using System;

internal class PlayMultiplayerMatchesAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-playvs";
		}
	}

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ));
		}
	}

	public PlayMultiplayerMatchesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(8, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int gained = ((!Singleton<GameController>.instance.isMission) ? 1 : 0);
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
