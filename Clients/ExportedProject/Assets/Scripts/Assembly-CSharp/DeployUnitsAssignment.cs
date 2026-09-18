using System;
using Beebyte.Obfuscator;

[Skip]
internal class DeployUnitsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-deploy";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public DeployUnitsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(12, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int unitsSpawned = StatsManager.instance.matchStats.unitsSpawned;
		base.completeFract = CompareIntAndInt(unitsSpawned, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
