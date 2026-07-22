using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionWaves : DailyMissionG<DailyMissionWaves.WavesMissionConfig>
{
	[Serializable]
	public class WavesMissionConfig : MissionConfig
	{
		public List<MissionSpawningSystem.ECPJELBIMPA> waves = new List<MissionSpawningSystem.ECPJELBIMPA>();
	}

	private const int numberOfWaves = 3;

	private int mCurrentWaveIndex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CwaveUnits_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CwaveKilledUnits_003Ek__BackingField;

	public int waveUnits
	{
		[CompilerGenerated]
		get
		{
			return _003CwaveUnits_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CwaveUnits_003Ek__BackingField = value;
		}
	}

	public int waveKilledUnits
	{
		[CompilerGenerated]
		get
		{
			return _003CwaveKilledUnits_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CwaveKilledUnits_003Ek__BackingField = value;
		}
	}

	public int currentWaveNumber => mCurrentWaveIndex + 1;

	public override float progress
	{
		get
		{
			float num = 1f / 3f;
			return num * (float)(currentWaveNumber - 1) + waveProgress * num;
		}
	}

	public float waveProgress => (waveUnits != 0) ? ((float)waveKilledUnits / (float)waveUnits) : 0f;

	public override string objective => Localization.LocalizeFormat("ID_MISSION_WAVE", base.missionColor, MEJMLNDFDBP.GMIPFLIEOHD(3));

	public override bool ShowFight()
	{
		return false;
	}

	public override BOPAGEMBFGD GetGUIController()
	{
		DIJIAFJNKLG dIJIAFJNKLG = new DIJIAFJNKLG();
		dIJIAFJNKLG.JPEOHFFBFAK(this);
		return dIJIAFJNKLG;
	}

	public override void StartMission()
	{
		base.StartMission();
		mCurrentWaveIndex = 0;
		waveUnits = 0;
		waveKilledUnits = 0;
		DailyMissionsManager.instance.spawningSystem.StartWaves(GetUpgrades(), base.missionConfig.waves, base.number, base.missionType);
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
		float aBLEFBIIIIH = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("WaveCoolDown"), valueName);
		float nCGMDLAPJBA = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("WaveDelay"), valueName);
		List<MissionSpawningSystem.ECPJELBIMPA> list = new List<MissionSpawningSystem.ECPJELBIMPA>();
		for (int i = 1; i <= 3; i++)
		{
			int min = (int)(float)missionsSettings.GetValue(missionsSettings.GetRowIndex(string.Format("{0}{1}{2}", "Wave", i, "Min")), valueName);
			int max = (int)(float)missionsSettings.GetValue(missionsSettings.GetRowIndex(string.Format("{0}{1}{2}", "Wave", i, "Max")), valueName);
			list.Add(new MissionSpawningSystem.ECPJELBIMPA
			{
				ABLEFBIIIIH = aBLEFBIIIIH,
				NCGMDLAPJBA = nCGMDLAPJBA,
				PPBMAJAKLGE = UnityEngine.Random.Range(min, max)
			});
		}
		base.missionConfig.waves = list;
	}

	public override void UpdateMission()
	{
		base.UpdateMission();
		base.remainingTime += TimeManager.deltaTimeWithoutPauses;
		DailyMissionsManager.instance.spawningSystem.WaveSpawning();
		mCurrentWaveIndex = DailyMissionsManager.instance.spawningSystem.currentWave.IDLMJLCFMJG;
		waveUnits = DailyMissionsManager.instance.spawningSystem.currentWave.JILDDDALNGF;
		waveKilledUnits = DailyMissionsManager.instance.spawningSystem.currentWave.DFIGDBKPLHI;
		if (DailyMissionsManager.instance.spawningSystem.wavesFinished)
		{
			EndMission(isWin: true);
		}
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.isWriting)
		{
			stream.SendNext(mCurrentWaveIndex);
			stream.SendNext(base.remainingTime);
			stream.SendNext(waveUnits);
			stream.SendNext(waveKilledUnits);
		}
		else
		{
			mCurrentWaveIndex = (int)stream.ReceiveNext();
			base.remainingTime = (float)stream.ReceiveNext();
			waveUnits = (int)stream.ReceiveNext();
			waveKilledUnits = (int)stream.ReceiveNext();
		}
	}
}
