using UnityEngine;

public class KillMission : HordeMission
{
	public int killFor1Star;

	public override int hudProgress => Singleton<ScoreManager>.instance.enemiesKilledAllTypes;

	public override float progress => (float)Singleton<ScoreManager>.instance.enemiesKilledAllTypes / (float)killFor1Star;

	public override string hudObjective => Localization.LocalizeFormat("ID_MISSION_KILL_HUD", MiscTools.FormatBigNumber(Mathf.Min(Singleton<ScoreManager>.instance.enemiesKilledAllTypes, killFor1Star)), MiscTools.FormatBigNumber(killFor1Star));

	public override string missionObjectiveProgress => Localization.LocalizeFormat("ID_MISSION_KILL_OBJ", MiscTools.FormatBigNumber(killFor1Star), MiscTools.PrintableTimeDescription(base.maxTimeForMission), MiscTools.FormatBigNumber(Mathf.Min(Singleton<ScoreManager>.instance.enemiesKilledAllTypes, killFor1Star)));

	public override void LoadMissionData(MissionDefinition missionDefinition)
	{
		base.LoadMissionData(missionDefinition);
		killFor1Star = missionDefinition.objective;
	}

	public override void EndMission()
	{
		int scoreCoop = Singleton<ScoreManager>.instance.scoreCoop;
		if (Singleton<ScoreManager>.instance.enemiesKilledAllTypes >= killFor1Star)
		{
			MissionSuccess();
		}
		else
		{
			Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.MissionFailed;
		}
		Debug.Log("END KILL MISSION " + Singleton<ScoreManager>.instance.enemiesKilledAllTypes + " score:" + scoreCoop + "/" + base.highscore + " (" + base.numberOfStars + ")");
		base.EndMission();
	}

	protected override void UpdateMission()
	{
		base.UpdateMission();
		if (Singleton<ScoreManager>.instance.enemiesKilledAllTypes >= killFor1Star)
		{
			EndMission();
		}
	}

	protected override int computedGainedSuccesScore()
	{
		int num = base.scoreFor1Star;
		float healthRatio = Singleton<GameController>.instance.mainPlayerController.destroyableParts.healthRatio;
		return num + MiscTools.RoundToInt(healthRatio / base.hpTarget * (float)(base.scoreFor3Stars - base.scoreFor1Star));
	}

	public override string Hud(int progressHud)
	{
		return Localization.LocalizeFormat("ID_MISSION_KILL_HUD", MiscTools.FormatBigNumber(Mathf.Min(progressHud, killFor1Star)), MiscTools.FormatBigNumber(killFor1Star));
	}

	public override string GetMissionObjective()
	{
		return MiscTools.FormatBigNumber(killFor1Star);
	}
}
