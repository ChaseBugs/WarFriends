using System;
using UnityEngine;

internal class FinishMissionAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-mission";
		}
	}

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(base.mData[0]);
			string keyFormat = ((num <= 1) ? base.translationId : string.Format("{0}S", base.translationId));
			return Localization.LocalizeFormat(keyFormat, num);
		}
	}

	public FinishMissionAssignment(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress)
		: base(dbAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(9, 1, dbAssignment.target);
		int num = Convert.ToInt32(base.mData[0]);
		base.mData[0] = num;
		Debug.Log("Assignment: Finish Missions Constructor, count = " + base.mData[0]);
	}

	public override float Update()
	{
		if (base.mCompleteFract >= 1f)
		{
			return 1f;
		}
		int gained = ((Singleton<GameController>.instance.isMission && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.MissionSuccess) ? 1 : 0);
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
