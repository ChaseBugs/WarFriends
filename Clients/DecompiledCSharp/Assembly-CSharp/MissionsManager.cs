using System.Collections.Generic;
using System.IO;
using System.Text;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class MissionsManager : DatabaseSerializedObjectGeneric<MissionsManager.MissionManagerData>
{
	[Skip]
	public class MissionData
	{
		public int attemptCount;

		public bool completedAlone;

		public bool completedInCoop;

		public bool completedInCoopClient;

		public int highscore;

		public int numberOfStars;

		public int attemptHero;

		public int attemptCoop;

		public int attemptHeroCoop;
	}

	[Skip]
	public enum HeroicType
	{
		Single,
		Coop
	}

	[Skip]
	public class HeroicMissionData
	{
		public int goldReward;

		public int index;

		public int warbucksReward;

		public bool completed;

		public HeroicType type;
	}

	[Skip]
	public class MissionManagerData
	{
		public Dictionary<int, MissionData> missionData = new Dictionary<int, MissionData>();

		public HeroicMissionData heroicData = new HeroicMissionData();
	}

	private static MissionsManager mInstance;

	public List<MissionDefinition> missionData;

	[Header("Serialization (context menu)")]
	public int missionIndex;

	public string dumpPath;

	public bool useEditorValues;

	[HideInInspector]
	public int indexMissionToStart;

	[HideInInspector]
	public List<Mission> missions;

	private PhotonView mPhotonView;

	private float mProgress;

	private float mRemainingTime;

	private int mHudObjective;

	private int mOpenedMissions;

	private MissionData mMissionStateBeforeStart;

	private int mMissionIndexBeforeStart;

	public static MissionsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((MissionsManager)Object.FindObjectsOfType(typeof(MissionsManager))[0]);
			return mInstance;
		}
	}

	public Mission currentMission => (indexMissionToStart >= 0 && indexMissionToStart < missions.Count) ? missions[indexMissionToStart] : null;

	public bool isHeroicLocked => missions.Count < 6 || !missions[5].opened;

	public string missionHudObjective => (!mPhotonView.isMine) ? currentMission.Hud(mHudObjective) : currentMission.hudObjective;

	public float missionProgress => (!mPhotonView.isMine) ? mProgress : currentMission.progress;

	public float time => (!mPhotonView.isMine) ? mRemainingTime : currentMission.remainingTime;

	public bool isHeroicMissionCompleted => heroicMission.completedInHeroic;

	public Mission heroicMission => missions[data.heroicData.index];

	public int completedMissionsCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < missions.Count; i++)
			{
				Mission mission = missions[i];
				if (mission.completed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	public Mission GetMission(int index)
	{
		return missions[Mathf.Clamp(index, 0, missions.Count)];
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.AfterGameStarted += OnAfterGameStarted;
		Singleton<GameController>.instance.BeforeGameStarted += OnBeforeGameStarted;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
		if (Application.isPlaying)
		{
			mInstance = this;
		}
	}

	private void OnBeforeGameStarted()
	{
		if (Singleton<GameController>.instance.isMission && PhotonNetwork.isMasterClient)
		{
			currentMission.OnBeforeGameStarted();
		}
	}

	private void OnPlayerDataLoaded()
	{
		GenerateMissions();
		mOpenedMissions = 0;
		for (int i = 0; i < missions.Count; i++)
		{
			Mission mission = missions[i];
			mission.index = i;
			if (!data.missionData.ContainsKey(i))
			{
				data.missionData[i] = new MissionData
				{
					highscore = 0,
					numberOfStars = 0
				};
			}
			if (mission.completed)
			{
				mOpenedMissions++;
			}
		}
	}

	private void CurrentPlayerOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		Singleton<GameController>.instance.mainPlayerController.Killed -= CurrentPlayerOnKilled;
		if (Singleton<GameController>.instance.isMission)
		{
			Singleton<MatchManager>.instance.SetHitBy(damageInfo);
			if (PhotonNetwork.isMasterClient)
			{
				currentMission.EndMission();
			}
		}
	}

	public void PlayCurrentMission()
	{
		Singleton<GameController>.instance.mainPlayerController.Killed -= CurrentPlayerOnKilled;
		Singleton<GameController>.instance.mainPlayerController.Killed += CurrentPlayerOnKilled;
		currentMission.PlayMission(PhotonNetwork.isMasterClient);
	}

	public void QuitCurrentMission()
	{
		Singleton<GameController>.instance.mainPlayerController.Killed -= CurrentPlayerOnKilled;
		if (currentMission != null)
		{
			currentMission.Quit();
		}
	}

	private void OnGameStarted()
	{
		if (Singleton<GameController>.instance.isMission && PhotonNetwork.isMasterClient)
		{
			currentMission.OnGameStarted();
		}
	}

	private void OnAfterGameStarted()
	{
		if (Singleton<GameController>.instance.isMission && PhotonNetwork.isMasterClient)
		{
			currentMission.OnAfterGameStarted();
		}
	}

	public void SetMissionDataBeforeStart(int index)
	{
		if (index < 0 || index >= missions.Count)
		{
			mMissionStateBeforeStart = null;
			return;
		}
		mMissionStateBeforeStart = new MissionData();
		mMissionStateBeforeStart.completedAlone = missions[index].completedAlone;
		mMissionStateBeforeStart.completedInCoop = missions[index].completedInCoop;
		mMissionStateBeforeStart.highscore = missions[index].highscore;
		mMissionStateBeforeStart.numberOfStars = missions[index].numberOfStars;
		mMissionIndexBeforeStart = index;
		Debug.Log("SETTED: MISSION " + (index + 1) + "\t\tcompleted A:" + mMissionStateBeforeStart.completedAlone + " C:" + mMissionStateBeforeStart.completedInCoop + "\t\tSTARS:" + mMissionStateBeforeStart.numberOfStars + "\t\tHIGHSCORE:" + mMissionStateBeforeStart.highscore);
	}

	public bool WasMissionOpened()
	{
		if (mMissionStateBeforeStart == null)
		{
			return false;
		}
		if (!mMissionStateBeforeStart.completedAlone && !mMissionStateBeforeStart.completedInCoop && missions[mMissionIndexBeforeStart].completed)
		{
			return true;
		}
		return false;
	}

	public bool WasGainedStars()
	{
		if (mMissionStateBeforeStart == null)
		{
			return false;
		}
		if (mMissionStateBeforeStart.numberOfStars < missions[mMissionIndexBeforeStart].numberOfStars)
		{
			return true;
		}
		return false;
	}

	public bool WasNewTypeCompleted()
	{
		if (mMissionStateBeforeStart == null)
		{
			return false;
		}
		if ((!mMissionStateBeforeStart.completedAlone && missions[mMissionIndexBeforeStart].completedAlone) || (!mMissionStateBeforeStart.completedInCoop && missions[mMissionIndexBeforeStart].completedInCoop))
		{
			return true;
		}
		return false;
	}

	public int LastHighscore()
	{
		if (mMissionStateBeforeStart != null)
		{
			return mMissionStateBeforeStart.highscore;
		}
		return 0;
	}

	public int LastStars()
	{
		if (mMissionStateBeforeStart != null)
		{
			return mMissionStateBeforeStart.numberOfStars;
		}
		return 0;
	}

	public string MissionsCompleted()
	{
		return mOpenedMissions + " / " + missions.Count;
	}

	[PunRPC]
	protected void MissionSucceededRPC(int missionIndex)
	{
		missions[missionIndex].MissionSuccessCoopClient();
	}

	public void MissionSucceeded(Mission mission)
	{
		mPhotonView.RPC("MissionSucceededRPC", PhotonTargets.Others, mission.index);
		int num = mission.index + 1;
		if (num < 1 || num >= missions.Count || !WasMissionOpened())
		{
			Debug.Log(" MISSION NOT SUCCEDED - nextIndex:" + num + "  was opened:" + WasMissionOpened());
		}
		else
		{
			Debug.Log("Mission was opened for the first time: " + WasMissionOpened());
			GuiScreenSingle<MissionScreen>.instance.animateNewMissionOpened = true;
			mOpenedMissions++;
		}
	}

	public void MissionNewTypeSucceeded(int index, bool isCoop)
	{
		if (!GuiScreenSingle<MissionScreen>.instance.animateNewMissionOpened)
		{
			GuiScreenSingle<MissionScreen>.instance.animateNewTypeCompletition = WasNewTypeCompleted();
			GuiScreenSingle<MissionScreen>.instance.indexNewTypeCompletition = index;
			GuiScreenSingle<MissionScreen>.instance.isCoopNewTypeCompletition = isCoop;
		}
	}

	public void MissionStarsSucceeded(int index, int oldStars, int newStars)
	{
		if (!GuiScreenSingle<MissionScreen>.instance.animateNewMissionOpened)
		{
			GuiScreenSingle<MissionScreen>.instance.animateNewStarsCompletition = WasGainedStars();
			GuiScreenSingle<MissionScreen>.instance.indexNewStarsCompletition = index;
			GuiScreenSingle<MissionScreen>.instance.numberOfStarsOld = oldStars;
			GuiScreenSingle<MissionScreen>.instance.numberOfStarsNew = newStars;
		}
	}

	public int GetMissionIndexForAssignment()
	{
		for (int i = 0; i < missions.Count; i++)
		{
			if (!missions[i].opened)
			{
				return i;
			}
		}
		int num;
		for (num = Random.Range(0, missions.Count); num == indexMissionToStart; num = Random.Range(0, missions.Count))
		{
		}
		return num;
	}

	public string GetMissionName(int index)
	{
		if (index >= missions.Count || index < 0)
		{
			Debug.LogError("Mission definition was not found for index " + index);
			return string.Format("{0} -", Localization.Localize("ID_MISSION"));
		}
		return string.Format("{0} {1}", Localization.Localize("ID_MISSION"), missions[index].number);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
		{
			if (stream.isWriting)
			{
				stream.SendNext(currentMission.progress);
				stream.SendNext(currentMission.remainingTime);
				stream.SendNext(currentMission.hudProgress);
			}
			else
			{
				mProgress = (float)stream.ReceiveNext();
				mRemainingTime = (float)stream.ReceiveNext();
				mHudObjective = (int)stream.ReceiveNext();
			}
		}
	}

	private void GenerateMissions()
	{
		Missions component = GetComponent<Missions>();
		missions = new List<Mission>();
		useEditorValues = false;
		if (!useEditorValues)
		{
			missionData.Clear();
			for (int i = 0; i < component.Rows.Count; i++)
			{
				MissionsRow missionsRow = component.Rows[i];
				MissionDefinition item = JsonConvert.DeserializeObject<MissionDefinition>(missionsRow.DATA);
				missionData.Add(item);
			}
		}
		for (int j = 0; j < missionData.Count; j++)
		{
			MissionDefinition missionDefinition = missionData[j];
			MissionsRow missionsRow2 = component.Rows[j];
			missionDefinition.map = missionsRow2.MAP_STAGE;
			if (int.TryParse(missionsRow2.OBJECTIVE, out var result))
			{
				missionDefinition.objective = result;
			}
			missionDefinition.maxTimeForMission = missionsRow2.TIME;
			missionDefinition.scoreFor1Star = missionsRow2.SCORE1;
			missionDefinition.scoreFor2Stars = missionsRow2.SCORE2;
			missionDefinition.scoreFor3Stars = missionsRow2.SCORE3;
			missionDefinition.maxUnits = missionsRow2.MAX_UNITS_AT_ONCE;
			missionDefinition.rewardWarbucks = missionsRow2.REWARD_WARBUCKS;
			missionDefinition.rewardGold = missionsRow2.REWARD_GOLD;
			missionDefinition.rewardXP = missionsRow2.REWARD_XP;
			missionDefinition.hpFract = missionsRow2.HPTARGET;
			missionDefinition.timeFract = missionsRow2.TIMETARGET;
			missionDefinition.recommendedAP = missionsRow2.RECOMMENDEDARMYPOWER;
			switch (missionsRow2.MISSIONTYPE)
			{
			case "KillOpponent":
				missionDefinition.type = MissionDefinitionMissionTypes.KillOpponent;
				break;
			case "SurviveXSeconds":
				missionDefinition.type = MissionDefinitionMissionTypes.SurviveXSeconds;
				break;
			case "KillXEnemies":
				missionDefinition.type = MissionDefinitionMissionTypes.KillXEnemies;
				break;
			case "Score":
				missionDefinition.type = MissionDefinitionMissionTypes.Score;
				break;
			default:
				Debug.LogError("UNKNOWN MISSION TYPE!!!");
				break;
			}
			GameObject gameObject = new GameObject("Mission " + j.ToString("D2"));
			gameObject.transform.parent = base.transform;
			Mission mission = missionDefinition.AddMissionComponent(gameObject);
			mission.LoadMissionData(missionDefinition);
			missions.Add(mission);
		}
	}

	internal MissionData GetMissionData()
	{
		int index = currentMission.index;
		Debug.Log("SENDING MISSION DATA FOR INDEX = " + index);
		return data.missionData[index];
	}

	[ContextMenu("Serialize")]
	public void Serialize()
	{
		if (missionIndex >= 0 && missionIndex < missionData.Count)
		{
			Debug.LogWarning($"SERIALIZED MISSION {missionIndex}");
			string arg = JsonConvert.SerializeObject(missionData[missionIndex]);
			Debug.LogWarning($"{arg}");
		}
		else
		{
			Debug.LogError($"Bad mission number! Expecting number between {1} and {missionData.Count}.");
		}
	}

	[ContextMenu("Dump")]
	public void Dump()
	{
		if (!string.IsNullOrEmpty(dumpPath))
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < missionData.Count; i++)
			{
				string value = JsonConvert.SerializeObject(missionData[i]);
				stringBuilder.AppendLine(value);
			}
			File.WriteAllText(dumpPath, stringBuilder.ToString());
			Debug.Log($"Dump done, check '{dumpPath}' file.");
		}
		else
		{
			Debug.LogError($"Set dump path!");
		}
	}

	[ContextMenu("Fill From Excell (Old)")]
	public void FillFromExcell()
	{
		Missions component = GetComponent<Missions>();
		missions = new List<Mission>();
		if (missionData == null)
		{
			missionData = new List<MissionDefinition>();
		}
		for (int i = 0; i < component.Rows.Count; i++)
		{
			if (i >= missionData.Count)
			{
				missionData.Add(new MissionDefinition());
			}
			MissionsRow missionsRow = component.Rows[i];
			MissionDefinition missionDefinition = missionData[i];
			missionDefinition.map = missionsRow.MAP_STAGE;
			if (int.TryParse(missionsRow.OBJECTIVE, out var result))
			{
				missionDefinition.objective = result;
			}
			missionDefinition.maxTimeForMission = missionsRow.TIME;
			missionDefinition.scoreFor1Star = missionsRow.SCORE1;
			missionDefinition.scoreFor2Stars = missionsRow.SCORE2;
			missionDefinition.scoreFor3Stars = missionsRow.SCORE3;
			missionDefinition.maxUnits = missionsRow.MAX_UNITS_AT_ONCE;
			missionDefinition.rewardWarbucks = missionsRow.REWARD_WARBUCKS;
			missionDefinition.rewardGold = missionsRow.REWARD_GOLD;
			missionDefinition.rewardXP = missionsRow.REWARD_XP;
			missionDefinition.hpFract = missionsRow.HPTARGET;
			missionDefinition.timeFract = missionsRow.TIMETARGET;
			missionDefinition.recommendedAP = missionsRow.RECOMMENDEDARMYPOWER;
			if (missionDefinition.bot == null)
			{
				missionDefinition.bot = new MissionDefinitionBot();
			}
			missionDefinition.bot.difficulty = missionsRow.BOT_NUMBER_DIFFICULTY;
			missionDefinition.bot.level = missionsRow.BOTLEVEL;
			missionDefinition.bot.hpReduction = missionsRow.BOTHPREDUCTION;
			switch (missionsRow.MISSIONTYPE)
			{
			case "KillOpponent":
				missionDefinition.type = MissionDefinitionMissionTypes.KillOpponent;
				break;
			case "SurviveXSeconds":
				missionDefinition.type = MissionDefinitionMissionTypes.SurviveXSeconds;
				break;
			case "KillXEnemies":
				missionDefinition.type = MissionDefinitionMissionTypes.KillXEnemies;
				break;
			case "Score":
				missionDefinition.type = MissionDefinitionMissionTypes.Score;
				break;
			default:
				Debug.LogError("UNKNOWN MISSION TYPE!!!");
				break;
			}
			List<MissionDefinitionBehaviour> behaviours = new List<MissionDefinitionBehaviour>();
			missionDefinition.behaviours = behaviours;
		}
	}

	[ContextMenu("Fill From Excell (New)")]
	public void FillFromExcellData()
	{
		Missions component = GetComponent<Missions>();
		missionData.Clear();
		for (int i = 0; i < component.Rows.Count; i++)
		{
			MissionsRow missionsRow = component.Rows[i];
			MissionDefinition item = JsonConvert.DeserializeObject<MissionDefinition>(missionsRow.DATA);
			missionData.Add(item);
		}
	}

	internal void LoadData(string data)
	{
		SerializedObject = JsonConvert.DeserializeObject<MissionManagerData>(data);
		OnPlayerDataLoaded();
	}

	protected void Update()
	{
		if (currentMission != null)
		{
			currentMission.UpdateCurrentMission();
		}
	}

	public void EndMission(Mission mission)
	{
		Singleton<GameController>.instance.mainPlayerController.Killed -= CurrentPlayerOnKilled;
		Singleton<GameController>.instance.mainController.FinishGame();
	}

	public void LoadUnitsVisuals(Mission mission)
	{
		mission.LoadInitialUnitVisuals();
		mPhotonView.RPC("LoadUnitsVisualsRPC", PhotonTargets.Others, mission.index);
	}

	[PunRPC]
	private void LoadUnitsVisualsRPC(int missionIndex)
	{
		Mission mission = missions[missionIndex];
		mission.LoadInitialUnitVisuals();
		mPhotonView.RPC("LoadUnitsVisualsRPC", PhotonTargets.Others, mission.index);
	}

	public static UpgradeSlots.UnitUpgrades ScaleUpgradesForMission(Fractions fraction, LevelBehaviour behaviour, UpgradeSlots.UnitUpgrades unitUpgrades)
	{
		if (Singleton<GameController>.instance.isMission && fraction != PlayerController.currentPlayer.fraction && behaviour.upgradeSlots.armyUpgradesRow != null)
		{
			bool playingInHeroicMode = instance.currentMission.playingInHeroicMode;
			ArmyUpgradesRow armyUpgradesRow = behaviour.upgradeSlots.armyUpgradesRow;
			if (Singleton<GameController>.instance.isCoop)
			{
				if (playingInHeroicMode)
				{
					unitUpgrades.scaleHp = armyUpgradesRow.HEROICCOOPHP;
					unitUpgrades.scaleDamage = armyUpgradesRow.HEROICCOOPDAMAGE;
				}
				else
				{
					unitUpgrades.scaleHp = armyUpgradesRow.COOPHP;
					unitUpgrades.scaleDamage = armyUpgradesRow.COOPDAMAGE;
				}
			}
			else if (playingInHeroicMode)
			{
				unitUpgrades.scaleHp = armyUpgradesRow.HEROICHP;
				unitUpgrades.scaleDamage = armyUpgradesRow.HEROICDAMAGE;
			}
		}
		return unitUpgrades;
	}
}
