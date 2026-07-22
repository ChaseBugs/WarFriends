using System;
using UnityEngine;

internal class PlayWarcardsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-cards";

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ));
		}
	}

	public PlayWarcardsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(14, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int count = CardManager.instance.cardUsedByMe.Count;
		base.mCompleteFract = CompareIntAndInt(count, Convert.ToInt32(base.mData[0]));
		Debug.Log("PlayWarcardsAssignment complate at: " + base.mCompleteFract + " a: " + count);
		return base.mCompleteFract;
	}
}
