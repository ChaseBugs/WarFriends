using System;

public class DestroyCratesAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-crate";
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

	public override bool hasHint
	{
		get
		{
			return true;
		}
	}

	public override string hintText
	{
		get
		{
			return Localization.Localize("ID_ASSIGNMENTHINTCRATES");
		}
	}

	public DestroyCratesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(0, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int cPCHNGODJNF = Singleton<KillStreakManager>.instance.CPCHNGODJNF;
		base.mCompleteFract = CompareIntAndInt(cPCHNGODJNF, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
