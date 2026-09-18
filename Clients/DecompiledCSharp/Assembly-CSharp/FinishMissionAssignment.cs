using System;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
internal class FinishMissionAssignment : Assignment
{
	public override bool isCompleted
	{
		get
		{
			if (data == null || data.Length == 0)
			{
				return false;
			}
			return base.completeFract > 0f;
		}
	}

	public override string status => string.Empty;

	public override string assignmentPicture => "menu-assignments-type-warpathmission";

	protected override string basicDescription
	{
		get
		{
			string missionName = MissionsManager.instance.GetMissionName(Convert.ToInt32(data[0]));
			return Localization.LocalizeFormat(base.translationId, missionName);
		}
	}

	public FinishMissionAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		data = Assignment.GetAloneObjectFor(9, 1, dbAssignment.target);
		int secondTarget = dbAssignment.secondTarget;
		Debug.Log("SECOND PARAMETER = " + secondTarget + ", default val = " + data[0]);
		int num = Convert.ToInt32(data[0]) - secondTarget;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= MissionsManager.instance.missions.Count)
		{
			num = MissionsManager.instance.missions.Count - 1;
		}
		data[0] = num;
		Debug.Log("Assignment: FinishMission Constructor, id = " + data[0]);
	}

	public override float Update()
	{
		if (base.completeFract >= 1f)
		{
			return 1f;
		}
		bool flag = Singleton<GameController>.instance.isMission && Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.MissionSuccess && MissionsManager.instance.indexMissionToStart == Convert.ToInt32(data[0]);
		base.completeFract = ((!flag) ? 0f : 1f);
		return base.completeFract;
	}
}
