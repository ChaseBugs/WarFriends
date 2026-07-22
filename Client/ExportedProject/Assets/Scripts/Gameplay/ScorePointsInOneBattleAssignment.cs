using System;
using UnityEngine;

internal class ScorePointsInOneBattleAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-score";

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ));
		}
	}

	public override string progressBarSpriteForProgress => (base.currentState != JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : AssignmentsManager.redProgressBar;

	public override string redStatus
	{
		get
		{
			int num = Convert.ToInt32(base.mData[0]);
			string arg = Colours.stringRed + MEJMLNDFDBP.PHCBFODPDOD(MEJMLNDFDBP.LJDADOKBBNA((float)num * GetEndProgress())) + Colours.stringWhite;
			return $"({arg} / {MEJMLNDFDBP.PHCBFODPDOD(num)})";
		}
	}

	public ScorePointsInOneBattleAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Score points in one battle");
		base.mData = Assignment.GetAloneObjectFor(6, 1, dbAssignment.target);
	}

	public override float Update()
	{
		if (base.mCompleteFract >= 1f)
		{
			return 1f;
		}
		int gained = ((!Singleton<GameController>.instance.isMission) ? Convert.ToInt32(Singleton<ScoreManager>.instance.score) : 0);
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
