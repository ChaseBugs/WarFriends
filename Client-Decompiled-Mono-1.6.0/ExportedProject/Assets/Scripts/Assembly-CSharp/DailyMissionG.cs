using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionG<T> : DailyMission where T : MissionConfig
{
	public T missionConfig
	{
		get
		{
			return (T)base.config;
		}
	}

	public override void Load(JToken missionConfig, bool completedInSolo, bool completedInCoop, GEIKAIJBCPE type, int index, bool unitLevels = true)
	{
		base.config = missionConfig.ToObject<T>();
		base.data = new LFKIJFPIAOM
		{
			JBMFGOOHOLB = completedInSolo,
			JOGLEJIECGG = completedInCoop
		};
		base.number = index + 1;
		mMissionType = type;
		int level = ((type != GEIKAIJBCPE.Heroic) ? DailyMissionsManager.instance.dailyMissionPlayerLevel : DailyMissionsManager.instance.heroicMissionPlayerLevel);
		float missionDifficulty = GetMissionDifficulty();
		if (unitLevels)
		{
			GetUnitsLevels(missionDifficulty, level);
		}
		GenerateRewards();
	}

	private void GetUnitsLevels(float difficulty, int level)
	{
		foreach (MissionUnit unit in base.config.units)
		{
			if (unit == null)
			{
				Debug.LogErrorFormat("There is null unit in mission {0} {1} configuration", mMissionType, base.number);
			}
			else
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[unit.behaviourIndex];
				unit.level = PickUnitLevel(levelBehaviour, difficulty, level);
			}
		}
	}

	public override BOPAGEMBFGD GetGUIController()
	{
		return null;
	}
}
