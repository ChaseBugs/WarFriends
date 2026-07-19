using System;
using UnityEngine;

internal class ScorePointsAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-score";
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

	public override bool hasHint
	{
		get
		{
			return LevelManager.instance.currentLevel.displayNumber >= LevelManager.instance.dailyMissionUnlockLevel;
		}
	}

	public override string hintText
	{
		get
		{
			return Localization.Localize("ID_ASSIGNMENTHINTWARPATH");
		}
	}

	public ScorePointsAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Score Points Constructor");
		base.mData = Assignment.GetAloneObjectFor(5, 1, dbAssignment.target);
	}

	public override float Update()
	{
		int score = Singleton<ScoreManager>.instance.score;
		base.mCompleteFract = CompareIntAndInt(score, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
