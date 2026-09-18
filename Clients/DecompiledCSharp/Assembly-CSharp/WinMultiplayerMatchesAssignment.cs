using System;
using Beebyte.Obfuscator;

[Skip]
internal class WinMultiplayerMatchesAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-win";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num));
		}
	}

	public WinMultiplayerMatchesAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(7, 1, dbAssignment.target);
	}

	public override float Update()
	{
		GameController.GameEndReason gameEndReason = Singleton<GameController>.instance.gameEndReason;
		int gained = (((gameEndReason == GameController.GameEndReason.Win || gameEndReason == GameController.GameEndReason.WinByForfeit) && !Singleton<GameController>.instance.isMission) ? 1 : 0);
		base.completeFract = CompareIntAndInt(gained, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
