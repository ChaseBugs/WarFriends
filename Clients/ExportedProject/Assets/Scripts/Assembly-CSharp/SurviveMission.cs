using UnityEngine;

public class SurviveMission : HordeMission
{
	public override MissionType missionType => MissionType.Survive;

	public override float progress => (base.maxTimeForMission - base.remainingTime) / base.maxTimeForMission;

	public override string hudObjective => Localization.LocalizeFormat("ID_MISSION_SURVIVE_HUD", MiscTools.RoundToInt(base.maxTimeForMission - MissionsManager.instance.time), base.maxTimeForMission);

	public override string missionObjectiveProgress
	{
		get
		{
			int num = (int)base.maxTimeForMission;
			int a = MiscTools.RoundToInt(base.maxTimeForMission - MissionsManager.instance.time);
			return Localization.LocalizeFormat("ID_MISSION_SURVIVE_OBJ", MiscTools.PrintableTimeDescription(base.maxTimeForMission), Mathf.Min(a, num), num);
		}
	}

	public override void EndMission()
	{
		int scoreCoop = Singleton<ScoreManager>.instance.scoreCoop;
		if (base.remainingTime > 0f)
		{
			Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.MissionFailed;
		}
		else
		{
			MissionSuccess();
		}
		Debug.Log("END SURVIVE MISSION score:" + scoreCoop + "/" + base.highscore + " (" + base.numberOfStars + ")");
		base.EndMission();
	}

	protected override int computedGainedSuccesScore()
	{
		int num = base.scoreFor1Star;
		float healthRatio = Singleton<GameController>.instance.mainPlayerController.destroyableParts.healthRatio;
		return num + MiscTools.RoundToInt(healthRatio / base.hpTarget * (float)(base.scoreFor3Stars - base.scoreFor1Star));
	}

	public override string GetMissionObjective()
	{
		return MiscTools.PrintableTimeTwoDigits(base.maxTimeForMission);
	}
}
