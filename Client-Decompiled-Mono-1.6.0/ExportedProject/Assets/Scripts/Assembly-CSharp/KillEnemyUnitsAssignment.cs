using System;

internal class KillEnemyUnitsAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-kill";
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

	public KillEnemyUnitsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(2, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int enemiesKilledAllTypes = Singleton<ScoreManager>.instance.enemiesKilledAllTypes;
		base.mCompleteFract = CompareIntAndInt(enemiesKilledAllTypes, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
