using System;
using Beebyte.Obfuscator;

[Skip]
internal class KillEnemyUnitsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-kill";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public KillEnemyUnitsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(2, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int enemiesKilledAllTypes = Singleton<ScoreManager>.instance.enemiesKilledAllTypes;
		base.completeFract = CompareIntAndInt(enemiesKilledAllTypes, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
