using System;

internal class WinMultiplayerMatchesAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-win";
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

	public WinMultiplayerMatchesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(7, 1, dbAssignment.target);
	}

	public override float Update()
	{
		GameController.HKGHCIEPGEL mNMLNIMFMJP = Singleton<GameController>.instance.MNMLNIMFMJP;
		int gained = (((mNMLNIMFMJP == GameController.HKGHCIEPGEL.Win || mNMLNIMFMJP == GameController.HKGHCIEPGEL.WinByForfeit) && !Singleton<GameController>.instance.isMission) ? 1 : 0);
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
