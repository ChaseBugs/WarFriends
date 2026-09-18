using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class KillEnemyUnitsInOneBattleAssignment : Assignment
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

	public override string progressBarSpriteForProgress => (base.currentState != State.InProgress) ? AssignmentsManager.goldProgressBar : AssignmentsManager.redProgressBar;

	public override string redStatus
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			string arg = Colours.stringRed + MiscTools.FormatAssignmentNumber(MiscTools.RoundToInt((float)num * GetEndProgress())) + Colours.stringWhite;
			return $"({arg} / {MiscTools.FormatAssignmentNumber(num)})";
		}
	}

	public KillEnemyUnitsInOneBattleAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Destroy Crates Constructor");
		data = Assignment.GetAloneObjectFor(3, 1, dbAssignment.target);
	}

	public override float Update()
	{
		if (base.completeFract >= 1f)
		{
			return 1f;
		}
		int gained = ((!Singleton<GameController>.instance.isMission) ? Singleton<ScoreManager>.instance.enemiesKilledAllTypes : 0);
		base.completeFract = CompareIntAndInt(gained, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
