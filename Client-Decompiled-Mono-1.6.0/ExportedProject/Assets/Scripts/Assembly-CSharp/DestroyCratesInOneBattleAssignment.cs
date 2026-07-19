using System;
using UnityEngine;

internal class DestroyCratesInOneBattleAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-crate";
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

	public override string progressBarSpriteForProgress
	{
		get
		{
			return (base.currentState != JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : AssignmentsManager.redProgressBar;
		}
	}

	public override string redStatus
	{
		get
		{
			int num = Convert.ToInt32(base.mData[0]);
			string arg = Colours.stringRed + MEJMLNDFDBP.PHCBFODPDOD(MEJMLNDFDBP.LJDADOKBBNA((float)num * GetEndProgress())) + Colours.stringWhite;
			return string.Format("({0} / {1})", arg, MEJMLNDFDBP.PHCBFODPDOD(num));
		}
	}

	public override bool hasHint
	{
		get
		{
			return true;
		}
	}

	public override string hintText
	{
		get
		{
			return Localization.Localize("ID_ASSIGNMENTHINTCRATES");
		}
	}

	public DestroyCratesInOneBattleAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Destroy Crates in one battle constructor");
		base.mData = Assignment.GetAloneObjectFor(1, 1, dbAssignment.target);
	}

	public override float Update()
	{
		if (base.mCompleteFract >= 1f)
		{
			return 1f;
		}
		int gained = ((!Singleton<GameController>.instance.isMission) ? Singleton<KillStreakManager>.instance.CPCHNGODJNF : 0);
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
