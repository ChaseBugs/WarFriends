using UnityEngine;

public class ScoreMission : HordeMission
{
	public int scoreToSucces;

	public override MissionType missionType => MissionType.Score;

	public override int hudProgress => Singleton<ScoreManager>.instance.scoreCoop;

	public override float progress => Mathf.Clamp01((float)Singleton<ScoreManager>.instance.scoreCoop / (float)scoreToSucces);

	public override string hudObjective => Localization.LocalizeFormat("ID_MISSION_SCORE_HUD", MiscTools.FormatBigNumber(Mathf.Min(Singleton<ScoreManager>.instance.scoreCoop, scoreToSucces)), MiscTools.FormatBigNumber(scoreToSucces));

	public override string missionObjectiveProgress
	{
		get
		{
			int num = Mathf.Min(scoreToSucces, Singleton<ScoreManager>.instance.scoreCoop);
			return Localization.LocalizeFormat("ID_MISSION_SCORE_OBJ", MiscTools.FormatBigNumber(scoreToSucces), MiscTools.PrintableTimeDescription(base.maxTimeForMission), MiscTools.FormatBigNumber(num));
		}
	}

	public override void LoadMissionData(MissionDefinition missionDefinition)
	{
		base.LoadMissionData(missionDefinition);
		scoreToSucces = missionDefinition.objective;
		if (scoreToSucces <= 0)
		{
			Debug.LogError("ScoreMission with scoreToSucces == 0!");
		}
	}

	public override void EndMission()
	{
		if (Singleton<ScoreManager>.instance.scoreCoop < scoreToSucces)
		{
			Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.MissionFailed;
		}
		else
		{
			MissionSuccess();
		}
		Debug.Log("END SCORE MISSION score:" + Singleton<ScoreManager>.instance.scoreCoop + "/" + base.highscore + " (" + base.numberOfStars + ")");
		base.EndMission();
	}

	protected override void UpdateMission()
	{
		base.UpdateMission();
		int scoreCoop = Singleton<ScoreManager>.instance.scoreCoop;
		if (scoreCoop >= scoreToSucces)
		{
			EndMission();
		}
	}

	public override string Hud(int progressHud)
	{
		return Localization.LocalizeFormat("ID_MISSION_SCORE_HUD", MiscTools.FormatBigNumber(Mathf.Min(progressHud, scoreToSucces)), MiscTools.FormatBigNumber(scoreToSucces));
	}

	public override string GetMissionObjective()
	{
		return MiscTools.FormatBigNumber(scoreToSucces);
	}
}
