using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionKillUnits : DailyMissionG<DailyMissionKillUnits.KillMissionConfig>
{
	[Serializable]
	public class KillMissionConfig : MissionConfig
	{
		public float time = 90f;

		public int killUnits = 10;
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CkilledUnits_003Ek__BackingField;

	public int killedUnits
	{
		[CompilerGenerated]
		get
		{
			return _003CkilledUnits_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CkilledUnits_003Ek__BackingField = value;
		}
	}

	public float time => base.missionConfig.time;

	public int killUnits => base.missionConfig.killUnits;

	public override string objective => Localization.LocalizeFormat("ID_MISSION_KILLUNIT", base.missionColor, MEJMLNDFDBP.GMIPFLIEOHD(killUnits), MEJMLNDFDBP.AIPKMDCJCOG(time));

	public override float progress => (killUnits != 0) ? ((float)(killUnits - killedUnits) / (float)killUnits) : 0f;

	public float timeProgress => base.remainingTime / time;

	public override BOPAGEMBFGD GetGUIController()
	{
		PFLBHBLJGKL pFLBHBLJGKL = new PFLBHBLJGKL();
		pFLBHBLJGKL.JPEOHFFBFAK(this);
		return pFLBHBLJGKL;
	}

	public override bool ShowFight()
	{
		return true;
	}

	public override void StartMission()
	{
		base.StartMission();
		base.remainingTime = time;
		killedUnits = 0;
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
		float num = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("EliminateTime"), valueName);
		float num2 = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("EliminateUnits"), valueName);
		base.missionConfig.time = num;
		base.missionConfig.killUnits = (int)num2;
	}

	public override void UpdateMission()
	{
		base.UpdateMission();
		killedUnits = Singleton<ScoreManager>.instance.enemiesKilledAllTypes;
		DailyMissionsManager.instance.spawningSystem.Spawning();
		base.remainingTime -= TimeManager.deltaTimeWithoutPauses;
		base.remainingTime = Mathf.Clamp(base.remainingTime, 0f, float.MaxValue);
		if (base.remainingTime <= 0f)
		{
			EndMission(isWin: false);
		}
		if (killedUnits >= killUnits)
		{
			EndMission(isWin: true);
		}
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.isWriting)
		{
			stream.SendNext(killedUnits);
			stream.SendNext(base.remainingTime);
		}
		else
		{
			killedUnits = (int)stream.ReceiveNext();
			base.remainingTime = (float)stream.ReceiveNext();
		}
	}
}
