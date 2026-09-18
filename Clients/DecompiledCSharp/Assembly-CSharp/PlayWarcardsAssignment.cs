using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class PlayWarcardsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-cards";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public PlayWarcardsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(14, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int count = CardManager.instance.cardUsedByMe.Count;
		base.completeFract = CompareIntAndInt(count, Convert.ToInt32(data[0]));
		Debug.Log("PlayWarcardsAssignment complate at: " + base.completeFract + " a: " + count);
		return base.completeFract;
	}
}
