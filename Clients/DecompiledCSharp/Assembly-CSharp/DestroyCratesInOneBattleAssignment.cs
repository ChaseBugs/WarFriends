using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class DestroyCratesInOneBattleAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-crate";

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

	public override bool hasHint => true;

	public override string hintText => Localization.Localize("ID_ASSIGNMENTHINTCRATES");

	public DestroyCratesInOneBattleAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Destroy Crates in one battle constructor");
		data = Assignment.GetAloneObjectFor(1, 1, dbAssignment.target);
	}

	public override float Update()
	{
		if (base.completeFract >= 1f)
		{
			return 1f;
		}
		int gained = ((!Singleton<GameController>.instance.isMission) ? Singleton<KillStreakManager>.instance.numberOfDestroyedBoxesInLastGame : 0);
		base.completeFract = CompareIntAndInt(gained, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
