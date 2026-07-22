using System;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionSurvive : DailyMissionG<DailyMissionSurvive.SurviveMissionConfig>
{
	[Serializable]
	public class SurviveMissionConfig : MissionConfig
	{
		public float time = 90f;
	}

	public float time => base.missionConfig.time;

	public override float progress => Mathf.Clamp01((time - base.remainingTime) / time);

	public override string objective => Localization.LocalizeFormat("ID_MISSION_SURVIVE", base.missionColor, MEJMLNDFDBP.AIPKMDCJCOG(time));

	public override BOPAGEMBFGD GetGUIController()
	{
		HEHOOLGCCOK hEHOOLGCCOK = new HEHOOLGCCOK();
		hEHOOLGCCOK.JPEOHFFBFAK(this);
		return hEHOOLGCCOK;
	}

	public override bool ShowFight()
	{
		return true;
	}

	public override void StartMission()
	{
		base.StartMission();
		base.remainingTime = time;
		DailyMissionsManager.instance.spawningSystem.StartSpawning(GetUpgrades(), base.missionType, base.number);
	}

	public override void EndMission(bool isWin)
	{
		base.EndMission(isWin);
		DailyMissionsManager.instance.spawningSystem.StopSpawning();
	}

	public override void Load(JToken missionConfig, bool completedInSolo, bool completedInCoop, GEIKAIJBCPE type, int index, bool unitLevels = true)
	{
		base.Load(missionConfig, completedInSolo, completedInCoop, type, index, unitLevels);
		MissionsSettings missionsSettings = DailyMissionsManager.instance.missionsSettings;
		string valueName = string.Format("{0}{1}", (!base.isHeroic) ? "Daily" : "Heroic", index + 1);
		float num = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("SurviveTime"), valueName);
		base.missionConfig.time = num;
	}

	public string Hud(int remTime)
	{
		return Localization.LocalizeFormat("ID_MISSION_SURVIVE_HUD", MEJMLNDFDBP.LJDADOKBBNA(time - (float)remTime), time);
	}

	public override void UpdateMission()
	{
		base.UpdateMission();
		DailyMissionsManager.instance.spawningSystem.Spawning();
		base.remainingTime -= TimeManager.deltaTimeWithoutPauses;
		base.remainingTime = Mathf.Clamp(base.remainingTime, 0f, float.MaxValue);
		DailyMissionsManager.instance.spawningSystem.Spawning();
		if (base.remainingTime <= 0f)
		{
			EndMission(isWin: true);
		}
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.isWriting)
		{
			stream.SendNext(base.remainingTime);
		}
		else
		{
			base.remainingTime = (float)stream.ReceiveNext();
		}
	}
}
