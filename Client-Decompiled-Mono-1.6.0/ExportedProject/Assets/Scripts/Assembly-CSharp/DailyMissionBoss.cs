using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionBoss : DailyMissionG<DailyMissionBoss.BossMissionConfig>
{
	[Serializable]
	public class BossMissionConfig : MissionConfig
	{
		public List<MissionSpawningSystem.ECPJELBIMPA> waves = new List<MissionSpawningSystem.ECPJELBIMPA>();
	}

	private const int numberOfWaves = 3;

	private EnemyController mBoss;

	private int mCurrentWaveIndex;

	public int currentWaveNumber
	{
		get
		{
			return mCurrentWaveIndex + 1;
		}
	}

	public int waveKilledUnits { get; private set; }

	public int waveUnits { get; private set; }

	public float bossSpawnTime { get; private set; }

	public float bossWaitForSpawnTime { get; private set; }

	public float time { get; private set; }

	public float bossHealthRatio { get; private set; }

	public override float progress
	{
		get
		{
			float num = 1f / 3f;
			return num * (float)(currentWaveNumber - 1) + waveProgress * num;
		}
	}

	public float waveProgress
	{
		get
		{
			return (waveUnits != 0) ? ((float)waveKilledUnits / (float)waveUnits) : 0f;
		}
	}

	public float bossWaitProgress
	{
		get
		{
			return (bossSpawnTime != bossWaitForSpawnTime) ? ((time - bossWaitForSpawnTime) / (bossSpawnTime - bossWaitForSpawnTime)) : 0f;
		}
	}

	public override string objective
	{
		get
		{
			return Localization.LocalizeFormat("ID_MISSION_BOSS", base.missionColor, MEJMLNDFDBP.GMIPFLIEOHD(2));
		}
	}

	public override BOPAGEMBFGD GetGUIController()
	{
		KIMBLKJPMDC kIMBLKJPMDC = new KIMBLKJPMDC();
		kIMBLKJPMDC.JPEOHFFBFAK(this);
		return kIMBLKJPMDC;
	}

	public override bool ShowFight()
	{
		return false;
	}

	public override void StartMission()
	{
		base.StartMission();
		mCurrentWaveIndex = 0;
		base.remainingTime = 0f;
		waveKilledUnits = 0;
		waveUnits = 0;
		bossSpawnTime = 0f;
		bossWaitForSpawnTime = 0f;
		time = 0f;
		mBoss = null;
		bossHealthRatio = 1f;
		DailyMissionsManager.instance.spawningSystem.StartWaves(GetUpgrades(), base.missionConfig.waves, base.number, base.missionType);
	}

	public override void EndMission(bool isWin)
	{
		base.EndMission(isWin);
		DailyMissionsManager.instance.spawningSystem.StopSpawning();
		if (mBoss != null)
		{
			mBoss.Killed -= OnBossKilled;
		}
		DailyMissionsManager.DailyMissionsData dailyMissionsData = DailyMissionsManager.instance.data;
		if (isWin)
		{
			dailyMissionsData.isHeroicOpened = false;
		}
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

	private List<MissionUnit> GenerateUnitsForMission()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		int num = 0;
		foreach (LevelBehaviour item in behaviours)
		{
			if (item.upgradeSlots.unlockLevel.displayNumber <= displayNumber && item.upgradeSlots.upgradeSlotElite.isUnlocked && item.isSoldier)
			{
				list.Add(item);
				num++;
			}
		}
		foreach (LevelBehaviour item2 in behaviours)
		{
			if (item2.upgradeSlots.unlockLevel.displayNumber <= displayNumber && item2.hasCardVariant && item2.isSoldier)
			{
				list.Add(item2);
			}
		}
		int num2 = UnityEngine.Random.Range(0, list.Count);
		LevelBehaviour levelBehaviour = list[num2];
		bool flag = num2 < num;
		List<LevelBehaviour> list2 = new List<LevelBehaviour>();
		foreach (LevelBehaviour item3 in behaviours)
		{
			if (item3.upgradeSlots.unlockLevel.displayNumber <= displayNumber && item3 != levelBehaviour)
			{
				list2.Add(item3);
			}
		}
		list2.Shuffle();
		DailyMission.SelectUnits(list2);
		List<MissionUnit> list3 = PickUpgrades(list2);
		MissionUnit missionUnit = new MissionUnit();
		missionUnit.behaviourIndex = levelBehaviour.indexInLevelsManager;
		missionUnit.level = PickUnitLevel(levelBehaviour, GetMissionDifficulty(), DailyMissionsManager.instance.heroicMissionPlayerLevel);
		MissionUnit missionUnit2 = missionUnit;
		missionUnit2.isVeteran = !flag;
		missionUnit2.isElite = flag;
		list3.Insert(0, missionUnit2);
		return list3;
	}

	public override void UpdateMission()
	{
		base.UpdateMission();
		base.remainingTime += TimeManager.deltaTimeWithoutPauses;
		MissionSpawningSystem spawningSystem = DailyMissionsManager.instance.spawningSystem;
		spawningSystem.WaveSpawning();
		mCurrentWaveIndex = spawningSystem.currentWave.IDLMJLCFMJG;
		waveUnits = DailyMissionsManager.instance.spawningSystem.currentWave.JILDDDALNGF;
		waveKilledUnits = DailyMissionsManager.instance.spawningSystem.currentWave.DFIGDBKPLHI;
		time = Time.time;
		if (mCurrentWaveIndex == 2 && spawningSystem.spawning && mBoss == null)
		{
			if (bossSpawnTime == 0f)
			{
				MissionsConstants missionConstants = DailyMissionsManager.instance.missionConstants;
				bossWaitForSpawnTime = time;
				bossSpawnTime = bossWaitForSpawnTime + missionConstants.GetRow(MissionsConstants.rowIds.BossArrivalTime).VALUE;
			}
			else if (time > bossSpawnTime)
			{
				bossSpawnTime = 0f;
				SpawnBoss();
			}
		}
		if (mBoss != null)
		{
			bossHealthRatio = mBoss.destroyableObj.healthRatio;
		}
	}

	private void SpawnBoss()
	{
		MissionSpawningSystem spawningSystem = DailyMissionsManager.instance.spawningSystem;
		AIObject aIObject = spawningSystem.SpawnBoss();
		aIObject.Killed += OnBossKilled;
		mBoss = aIObject as EnemyController;
		if (mBoss != null)
		{
			mBoss.UpdateHeadScale(1.5f);
			mBoss.destroyableObj.destroyableByBonusBox = false;
			mBoss.destroyableObj.SetText(string.Empty);
		}
	}

	private void OnBossKilled(NKMKCCDCHCL gameMainEntity, DestroyableObject.CJLNCMMNPBM damageInfo)
	{
		EndMission(true);
		TimeManager.instance.SetupPhysicsTiming(true);
		Singleton<GameCamera>.instance.FocusBoss(mBoss);
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.isWriting)
		{
			stream.SendNext(mCurrentWaveIndex);
			stream.SendNext(base.remainingTime);
			stream.SendNext(waveKilledUnits);
			stream.SendNext(waveUnits);
			stream.SendNext(bossWaitForSpawnTime);
			stream.SendNext(bossSpawnTime);
			stream.SendNext(time);
			stream.SendNext(bossHealthRatio);
		}
		else
		{
			mCurrentWaveIndex = (int)stream.ReceiveNext();
			base.remainingTime = (float)stream.ReceiveNext();
			waveKilledUnits = (int)stream.ReceiveNext();
			waveUnits = (int)stream.ReceiveNext();
			bossWaitForSpawnTime = (float)stream.ReceiveNext();
			bossSpawnTime = (float)stream.ReceiveNext();
			time = (float)stream.ReceiveNext();
			bossHealthRatio = (float)stream.ReceiveNext();
		}
	}
}
