using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public abstract class DailyMission
{
	protected GEIKAIJBCPE mMissionType;

	public MissionConfig config { get; protected set; }

	public LFKIJFPIAOM data { get; protected set; }

	public List<CDACJEGCGLB> rewards { get; private set; }

	public bool completedHeroic
	{
		get
		{
			return data.JBMFGOOHOLB && isHeroic;
		}
	}

	public int number { get; protected set; }

	public GEIKAIJBCPE missionType
	{
		get
		{
			return mMissionType;
		}
	}

	public bool isHeroic
	{
		get
		{
			return missionType == GEIKAIJBCPE.Heroic;
		}
	}

	public bool isSolo
	{
		get
		{
			return missionType == GEIKAIJBCPE.Daily;
		}
	}

	public bool isCoop
	{
		get
		{
			return missionType == GEIKAIJBCPE.Coop;
		}
	}

	public bool isCoopClient
	{
		get
		{
			return missionType == GEIKAIJBCPE.CoopClient;
		}
	}

	public string missionGuiName
	{
		get
		{
			if (isHeroic)
			{
				return Localization.LocalizeFormat((number != 5) ? "ID_HEROICMISSIONX" : "ID_BOSSMISSION", number);
			}
			return Localization.LocalizeFormat("ID_DAILYMISSIONX", number);
		}
	}

	public virtual string objective
	{
		get
		{
			return GetType().ToString();
		}
	}

	public string missionColor
	{
		get
		{
			return (mMissionType != GEIKAIJBCPE.Heroic) ? Colours.stringBlue : Colours.stringGoldHeroic;
		}
	}

	public float remainingTime { get; protected set; }

	public virtual float progress
	{
		get
		{
			return 0f;
		}
	}

	public DailyMission()
	{
		data = new LFKIJFPIAOM();
	}

	public virtual bool ShowFight()
	{
		return true;
	}

	public abstract BOPAGEMBFGD GetGUIController();

	public abstract void Load(JToken missionConfig, bool completedInSolo, bool completedInCoop, GEIKAIJBCPE type, int index, bool unitLevels = true);

	public virtual void StartMission()
	{
		remainingTime = 0f;
		Singleton<GameController>.instance.opponent = null;
	}

	public virtual void UpdateMission()
	{
	}

	public virtual void EndMission(bool isWin)
	{
		GameController.HKGHCIEPGEL mNMLNIMFMJP = ((!isWin) ? GameController.HKGHCIEPGEL.MissionFailed : GameController.HKGHCIEPGEL.MissionSuccess);
		Singleton<GameController>.instance.MNMLNIMFMJP = mNMLNIMFMJP;
		Singleton<GameController>.instance.mainController.FinishGame();
		DailyMissionsManager.instance.EndMission();
		Singleton<EventTrackingManager>.instance.EndMission(this, isWin);
		DailyMissionsManager.DailyMissionsData dailyMissionsData = DailyMissionsManager.instance.data;
		if (isWin)
		{
			data.JBMFGOOHOLB = mMissionType == GEIKAIJBCPE.Daily || mMissionType == GEIKAIJBCPE.Heroic;
			data.JOGLEJIECGG = mMissionType == GEIKAIJBCPE.Coop;
		}
	}

	protected float GetMissionDifficulty()
	{
		MissionsSettings missionsSettings = DailyMissionsManager.instance.missionsSettings;
		string valueName = string.Format("{0}{1}", (!isHeroic) ? "Daily" : "Heroic", number);
		return (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("Difficulty"), valueName);
	}

	protected List<MissionUnit> PickUpgrades(List<LevelBehaviour> possibleUnits)
	{
		List<MissionUnit> list = new List<MissionUnit>();
		float missionDifficulty = GetMissionDifficulty();
		int myLevel = ((!isHeroic) ? DailyMissionsManager.instance.dailyMissionPlayerLevel : DailyMissionsManager.instance.heroicMissionPlayerLevel);
		foreach (LevelBehaviour possibleUnit in possibleUnits)
		{
			list.Add(new MissionUnit
			{
				behaviourIndex = possibleUnit.indexInLevelsManager,
				level = PickUnitLevel(possibleUnit, missionDifficulty, myLevel)
			});
		}
		return list;
	}

	protected int PickUnitLevel(LevelBehaviour levelBehaviour, float difficulty, int myLevel)
	{
		UpgradeSlots upgradeSlots = levelBehaviour.upgradeSlots;
		int maxTierForLevel = levelBehaviour.upgradeSlots.GetMaxTierForLevel(myLevel);
		int tier = maxTierForLevel + 1;
		int unlockLevelForTier = upgradeSlots.GetUnlockLevelForTier(maxTierForLevel);
		float num = Mathf.Clamp(upgradeSlots.GetUnlockLevelForTier(tier), 0, LevelManager.instance.maxDisplayLevel);
		float value = (float)upgradeSlots.upgradeSlot.KAOADMHOELI(maxTierForLevel) + (float)upgradeSlots.startUnitLevel;
		value = Mathf.Clamp(value, 0f, upgradeSlots.maxLevelOfUnit);
		float value2 = (float)upgradeSlots.upgradeSlot.AFDBPKHKJHJ(maxTierForLevel) - 1f + (float)upgradeSlots.startUnitLevel;
		value2 = Mathf.Clamp(value2, 0f, upgradeSlots.maxLevelOfUnit);
		int num2 = (int)Mathf.Ceil((float)(myLevel + 1 - unlockLevelForTier) / num * value2 + value) - 1;
		return Mathf.Clamp(Mathf.CeilToInt((float)num2 * difficulty), 0, upgradeSlots.maxLevelOfUnit);
	}

	protected static int SelectUnits(List<LevelBehaviour> selectFrom)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < selectFrom.Count; i++)
		{
			LevelBehaviour levelBehaviour = selectFrom[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 3)
				{
					selectFrom.RemoveAt(i);
					i--;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < selectFrom.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = selectFrom[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 2)
			{
				selectFrom.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	protected void GenerateRewards()
	{
		rewards = new List<CDACJEGCGLB>();
		MissionsSettings missionsSettings = DailyMissionsManager.instance.missionsSettings;
		string arg = ((!isHeroic) ? "Daily" : "Heroic");
		int num = ((!isHeroic) ? 3 : 5);
		float num2 = 0f;
		float num3 = 0f;
		for (int i = 1; i <= num; i++)
		{
			string valueName = string.Format("{0}{1}", arg, i);
			num2 += (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("RweardModifierXP"), valueName);
			num3 += (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("RweardModifierWB"), valueName);
		}
		string valueName2 = string.Format("{0}{1}", arg, number);
		float num4 = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("RweardModifierXP"), valueName2);
		float num5 = (float)missionsSettings.GetValue(missionsSettings.GetRowIndex("RweardModifierWB"), valueName2);
		MissionsConstants missionConstants = DailyMissionsManager.instance.missionConstants;
		float vALUE = missionConstants.GetRow(MissionsConstants.rowIds.RewardXpBaseValue).VALUE;
		float vALUE2 = missionConstants.GetRow(MissionsConstants.rowIds.RewardWbBaseValue).VALUE;
		float vALUE3 = missionConstants.GetRow(MissionsConstants.rowIds.RewardXpRoot).VALUE;
		float vALUE4 = missionConstants.GetRow(MissionsConstants.rowIds.RewardWbRoot).VALUE;
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		float num6 = vALUE2 * Mathf.Pow(vALUE4, displayNumber - 3) * (float)num * (num5 / num3);
		float num7 = vALUE * Mathf.Pow(vALUE3, displayNumber - 3) * (float)num * (num4 / num2);
		if (mMissionType == GEIKAIJBCPE.Daily)
		{
			rewards.Add(CDACJEGCGLB.KHBBIJFAGNC(MEJMLNDFDBP.EDEIDMHHCAO(num6, 50)));
			rewards.Add(CDACJEGCGLB.ONCBFMEFMKJ(MEJMLNDFDBP.EDEIDMHHCAO(num7, 50)));
			rewards.Add(CDACJEGCGLB.MHIONBHIOOE(1));
		}
		else if (mMissionType == GEIKAIJBCPE.Coop)
		{
			rewards.Add(CDACJEGCGLB.MHIONBHIOOE(1));
		}
		if (mMissionType == GEIKAIJBCPE.CoopClient)
		{
			rewards.Add(CDACJEGCGLB.KHBBIJFAGNC(MEJMLNDFDBP.EDEIDMHHCAO(num6 * 0.5f, 50)));
			rewards.Add(CDACJEGCGLB.ONCBFMEFMKJ(MEJMLNDFDBP.EDEIDMHHCAO(num7 * 0.5f, 50)));
		}
		else if (mMissionType == GEIKAIJBCPE.Heroic)
		{
			rewards.Add(CDACJEGCGLB.KHBBIJFAGNC(MEJMLNDFDBP.EDEIDMHHCAO(num6, 50)));
			rewards.Add(CDACJEGCGLB.ONCBFMEFMKJ(MEJMLNDFDBP.EDEIDMHHCAO(num7, 50)));
			MissionsRewardsRow rewardRow = DailyMissionsManager.instance.GetRewardRow(DailyMissionsManager.instance.heroicMissionPlayerLevel);
			rewards.Add(CDACJEGCGLB.MJGNIAFBMNF(rewardRow.HEROICGOLDMISSION));
		}
	}

	public List<UnitUpgradeDefinition> GetUpgrades()
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		foreach (LevelBehaviour item in behaviours)
		{
			MissionUnit missionUnit = GetMissionUnit(item);
			if (missionUnit != null)
			{
				int slotUpgradeindex = Mathf.Clamp(missionUnit.level - item.upgradeSlots.startUnitLevel, 0, item.upgradeSlots.upgradeSlot.maxIndexInExcel);
				list.Add(new UnitUpgradeDefinition(true, new UpgradeSlots.UnitUpgrades(1f)
				{
					slotUpgradeindex = slotUpgradeindex,
					isElite = missionUnit.isElite,
					isVeteran = missionUnit.isVeteran
				}, false, 1));
			}
			else
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item.upgradeSlots.LoadData(item);
				list.Add(new UnitUpgradeDefinition(false, upgradeIndex, false, 1));
			}
		}
		return list;
	}

	private MissionUnit GetMissionUnit(LevelBehaviour behaviour)
	{
		foreach (MissionUnit unit in config.units)
		{
			if (unit.behaviourIndex == behaviour.indexInLevelsManager)
			{
				return unit;
			}
		}
		return null;
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}
