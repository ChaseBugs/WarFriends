using System;

internal class DeployUnitsAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-deploy";
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

	public DeployUnitsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(12, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int unitsSpawned = StatsManager.instance.matchStats.unitsSpawned;
		base.mCompleteFract = CompareIntAndInt(unitsSpawned, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
