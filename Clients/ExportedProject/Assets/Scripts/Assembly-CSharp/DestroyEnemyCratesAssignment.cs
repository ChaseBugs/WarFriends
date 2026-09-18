using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class DestroyEnemyCratesAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-crateenemy";

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

	public DestroyEnemyCratesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: DestroyEnemyCratesAssignment Constructor");
		data = Assignment.GetAloneObjectFor(17, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int cratesStolen = StatsManager.instance.matchStats.cratesStolen;
		base.completeFract = CompareIntAndInt(cratesStolen, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
