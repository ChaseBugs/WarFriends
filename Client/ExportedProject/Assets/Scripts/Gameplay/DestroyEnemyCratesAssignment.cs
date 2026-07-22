using System;
using UnityEngine;

internal class DestroyEnemyCratesAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-crateenemy";

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ));
		}
	}

	public override bool hasHint => true;

	public override string hintText => Localization.Localize("ID_ASSIGNMENTHINTCRATES");

	public DestroyEnemyCratesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: DestroyEnemyCratesAssignment Constructor");
		base.mData = Assignment.GetAloneObjectFor(17, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int cratesStolen = StatsManager.instance.matchStats.cratesStolen;
		base.mCompleteFract = CompareIntAndInt(cratesStolen, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
