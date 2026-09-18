using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class ScorePointsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-score";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public override bool hasHint => LevelManager.instance.currentLevel.displayNumber >= LevelManager.instance.warpathUnlockLevel;

	public override string hintText => Localization.Localize("ID_ASSIGNMENTHINTWARPATH");

	public ScorePointsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Score Points Constructor");
		data = Assignment.GetAloneObjectFor(5, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int score = Singleton<ScoreManager>.instance.score;
		base.completeFract = CompareIntAndInt(score, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
