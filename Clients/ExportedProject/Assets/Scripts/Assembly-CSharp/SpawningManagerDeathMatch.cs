using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;
using War.Protocol;

[ExecuteInEditMode]
public class SpawningManagerDeathMatch : Singleton<SpawningManagerDeathMatch>
{
	[Serializable]
	public class ArmyUnit
	{
		public LevelBehaviour behaviour;

		public float fillAmount;

		public float fillAmountBack;

		public string focusSpriteName;

		public float focusSpritePosition;

		public float height = 190f;

		public int index;

		public Vector3 localPosition = new Vector3(0f, -96f, -0.5f);

		public string menuIcon;

		public UIWidget.Pivot pivot = UIWidget.Pivot.Bottom;

		public SpawnHelper spawns = new SpawnHelper();

		public List<ArmyUnitDefinition> unitsCounts;

		public override string ToString()
		{
			string text = index.ToString("D2") + " TYPE: " + behaviour.GetType();
			text = text + " " + menuIcon;
			text = text + " MAX COUNT: " + behaviour.maxGeneratedCount;
			return text + " ENTRIES: " + unitsCounts.Count;
		}
	}

	[Serializable]
	public class ArmyUnitDefinition
	{
		[NonSerialized]
		[HideInInspector]
		public ArmyUnit armyUnit;

		[HideInInspector]
		public int index;

		public int numberOfEnemies;

		public int power => numberOfEnemies * armyUnit.behaviour.totalPower;

		public float coolDown => (float)numberOfEnemies * armyUnit.behaviour.coolDown;

		public override string ToString()
		{
			return " ENEMIES: " + numberOfEnemies.ToString("D2");
		}

		public bool CanSpawnAllUnits(Fractions fr)
		{
			return numberOfEnemies + armyUnit.spawns[fr] <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool CanBesSpawned(Fractions fr, int numberOfUnits)
		{
			return numberOfUnits + armyUnit.spawns[fr] <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}
	}

	public List<ArmyUnit> armyDefinitions;

	public float baseCoolDown = 5f;

	public List<ArmyUnitDefinition> currentArmyUnitDefinitions = new List<ArmyUnitDefinition>();

	public bool isTutorial;

	public bool log;

	private ArmyUnitDefinition mCurrentDefinition;

	private bool mGenerateNewUnits;

	private float mGenerateTime;

	private bool mGenerationEnabled;

	private bool mHasPregeneratedArmy;

	private float mNextTime;

	private PhotonView mPhotonView;

	private NetworkObjectPool mPool;

	private ArmyUnitDefinition mPregenerated;

	private float? mWaitingForClientUnitsSinceTime;

	public Action<Fractions, ArmyUnitDefinition> onFinishSpawning;

	public Action<Fractions, ArmyUnitDefinition> onStartSpawning;

	public ObscuredInt powerLeft;

	public ObscuredInt powerLeftEnemy;

	public bool sendUnit;

	public Fractions sendUnitFraction = Fractions.Allies;

	public int sendUnitNumber;

	private Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> unitsByType = new Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>>();

	public Action<ArmyUnitDefinition> UnitWasPregenerated;

	private Dictionary<Fractions, List<ArmyUnitDefinition>> mLastUnits = new Dictionary<Fractions, List<ArmyUnitDefinition>>();

	private bool mFirstSpawn;

	private bool mFirstSpawnHost;

	private float mCoolDownMultiplier = 1f;

	private float mCoolDown;
	private SelfHostedBattleClient mSelfHosted;
	private bool mSelfHostedMode;
	private bool mSelfHostedDeployPending;
	private bool mSelfHostedForceRefresh;

	private bool mAutoDeployEnabled;

	public float progress
	{
		get
		{
			if (mCurrentDefinition == null)
			{
				return 0f;
			}
			return Mathf.Clamp01((mNextTime - TimeManager.realTimeWithoutPauses) / mCoolDown);
		}
	}

	public bool autoDeployEnabled
	{
		get
		{
			return mAutoDeployEnabled;
		}
		set
		{
			mAutoDeployEnabled = value;
			if (!value)
			{
				semiAutoDeployEnabled = false;
			}
		}
	}

	public bool semiAutoDeployEnabled { get; set; }

	public float autoDeployProgress { get; private set; }

	public bool hasEnergyForAll
	{
		get
		{
			if (currentArmyUnitDefinitions != null)
			{
				bool flag = true;
				foreach (ArmyUnitDefinition currentArmyUnitDefinition in currentArmyUnitDefinitions)
				{
					if (currentArmyUnitDefinition != null && currentArmyUnitDefinition.power > (int)powerLeft)
					{
						flag = false;
					}
				}
				if (flag && progress <= 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool hasEnergyForAtLeastOne
	{
		get
		{
			if (currentArmyUnitDefinitions != null)
			{
				foreach (ArmyUnitDefinition currentArmyUnitDefinition in currentArmyUnitDefinitions)
				{
					if (currentArmyUnitDefinition != null && currentArmyUnitDefinition.power <= (int)powerLeft)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public bool canSendAllUnit
	{
		get
		{
			foreach (ArmyUnitDefinition currentArmyUnitDefinition in currentArmyUnitDefinitions)
			{
				if (currentArmyUnitDefinition != null && currentArmyUnitDefinition.power > (int)powerLeft)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool powerForSemiDeploy => (int)powerLeft > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SemiAutoDeployEnergy).FLOATVALUE;

	public float coolDownMultiplier
	{
		get
		{
			return mCoolDownMultiplier;
		}
		set
		{
			mCoolDownMultiplier = value;
		}
	}

	private int maxEnergy => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;

	public event Action ArmyChanged;

	public void BindSelfHosted(SelfHostedBattleClient client)
	{
		if (client == null || !client.IsConnected || mSelfHostedMode)
		{
			throw new InvalidOperationException("Bind one connected self-hosted army session.");
		}
		mSelfHosted = client;
		mSelfHostedMode = true;
		mSelfHosted.ArmyOffersReceived += ApplySelfHostedArmy;
		mAutoDeployEnabled = false;
		semiAutoDeployEnabled = false;
		mGenerateNewUnits = false;
		mWaitingForClientUnitsSinceTime = null;
	}

	public void UnbindSelfHosted(SelfHostedBattleClient client)
	{
		if (mSelfHosted != client) return;
		mSelfHosted.ArmyOffersReceived -= ApplySelfHostedArmy;
		mSelfHosted = null;
		mSelfHostedDeployPending = false;
		mSelfHostedForceRefresh = false;
		mGenerationEnabled = false;
		currentArmyUnitDefinitions.Clear();
		if (ArmyChanged != null) ArmyChanged();
	}

	private void ApplySelfHostedArmy(MatchArmyBatch batch)
	{
		if (mSelfHosted == null) return;
		var next = new List<ArmyUnitDefinition>();
		if (batch.Code == "army-offers")
		{
			if (batch.OptionIndexes.Count != 3)
				throw new InvalidOperationException("Host army hand must contain three source options.");
			foreach (int index in batch.OptionIndexes)
			{
				ArmyUnitDefinition found = null;
				foreach (ArmyUnit family in armyDefinitions)
					foreach (ArmyUnitDefinition option in family.unitsCounts)
						if (option.index == index) found = option;
				if (found == null)
					throw new InvalidOperationException("Host army option is absent from the source scene.");
				next.Add(found);
			}
		}
		else if (batch.Code != "army-unavailable" && batch.Code != "army-not-running" &&
		         batch.Code != "army-disabled")
			throw new InvalidOperationException("Unknown host army response.");
		bool changed = mSelfHostedForceRefresh || currentArmyUnitDefinitions.Count != next.Count ||
			(int)powerLeft != batch.Energy;
		if (!changed)
			for (int i = 0; i < next.Count; i++)
				if (currentArmyUnitDefinitions[i] != next[i]) { changed = true; break; }
		currentArmyUnitDefinitions = next;
		powerLeft = batch.Energy;
		mGenerateNewUnits = false;
		mWaitingForClientUnitsSinceTime = null;
		mSelfHostedForceRefresh = false;
		if (mCurrentDefinition != null)
		{
			double remaining = Math.Max(0d, ((double)batch.NextDeployTick -
				(double)mSelfHosted.State.ServerTick) / 30d);
			mCoolDown = Math.Max(1f, mCoolDown);
			mNextTime = TimeManager.realTimeWithoutPauses + (float)remaining;
		}
		if (changed && ArmyChanged != null) ArmyChanged();
	}

	public event Action<ArmyUnitDefinition> RandomArmySent;

	public SpawningManagerDeathMatch()
	{
		autoDeployProgress = 0f;
	}

	public void ResetAutoDeployProgress()
	{
		autoDeployProgress = 0f;
	}

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
			Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
			Singleton<GameController>.instance.BeforeGameStarted += InstanceOnBeforeGameStarted;
			Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += InstanceOnPlayerDataLoaded;
			mPool = ObjectPoolDatabase.networkPool;
			mPhotonView = GetComponent<PhotonView>();
			int num = 0;
			foreach (ArmyUnit armyDefinition in armyDefinitions)
			{
				foreach (ArmyUnitDefinition unitsCount in armyDefinition.unitsCounts)
				{
					unitsCount.armyUnit = armyDefinition;
					unitsCount.index = num;
					num++;
				}
			}
		}
		unitsByType = new Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>>();
	}

	protected void Update()
	{
		if (sendUnit)
		{
			sendUnit = false;
			SendBotUnit(armyDefinitions[sendUnitNumber].unitsCounts[0], sendUnitFraction);
		}
		if (Application.isPlaying && mGenerationEnabled && Singleton<GameController>.instance.gameIsRunning)
		{
			if (progress <= 0f && mGenerateNewUnits)
			{
				GetUnitsForClient();
			}
			float? num = mWaitingForClientUnitsSinceTime;
			if (num.HasValue && TimeManager.realTimeWithoutPauses > mWaitingForClientUnitsSinceTime.Value + 5f)
			{
				GetUnitsForClient();
			}
			if (mAutoDeployEnabled)
			{
				if (TimeManager.realTimeWithoutPauses > mNextTime + 1f && canSendAllUnit)
				{
					ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FullAutoDeployTime).FLOATVALUE;
					autoDeployProgress += TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE;
				}
				if (autoDeployProgress >= 1f && progress <= 0f)
				{
					autoDeployProgress = 0f;
					SendRandomUnit();
				}
				if (autoDeployProgress >= 0.7f && progress <= 0f && !mHasPregeneratedArmy)
				{
					PreGenerateRandomUnit(sendEvent: true);
				}
			}
			else if (semiAutoDeployEnabled)
			{
				if (TimeManager.realTimeWithoutPauses > mNextTime + 1f && canSendAllUnit && powerForSemiDeploy)
				{
					ObscuredFloat fLOATVALUE2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SemiAutoDeployTime).FLOATVALUE;
					autoDeployProgress += TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE2;
				}
				if (autoDeployProgress >= 1f && progress <= 0f)
				{
					autoDeployProgress = 0f;
					SendRandomUnit();
				}
				if (autoDeployProgress >= 0.7f && progress <= 0f && !mHasPregeneratedArmy)
				{
					PreGenerateRandomUnit(sendEvent: true);
				}
			}
		}
		if (log)
		{
			log = false;
			string text = string.Empty;
			for (int i = 0; i < armyDefinitions.Count; i++)
			{
				ArmyUnit armyUnit = armyDefinitions[i];
				text = string.Concat(text, armyUnit, "\n");
				text += armyUnit.spawns.ToString();
			}
			Debug.LogError(text);
		}
	}

	public void SendRandomUnit()
	{
		if (!mHasPregeneratedArmy)
		{
			if (PreGenerateRandomUnit(sendEvent: false) && this.RandomArmySent != null)
			{
				this.RandomArmySent(mPregenerated);
				SendUnit(mPregenerated, PlayerController.currentPlayer.fraction);
			}
		}
		else if (this.RandomArmySent != null)
		{
			this.RandomArmySent(mPregenerated);
			SendUnit(mPregenerated, PlayerController.currentPlayer.fraction);
		}
	}

	public bool PreGenerateRandomUnit(bool sendEvent)
	{
		mHasPregeneratedArmy = false;
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		foreach (ArmyUnitDefinition currentArmyUnitDefinition in currentArmyUnitDefinitions)
		{
			if (currentArmyUnitDefinition != null && currentArmyUnitDefinition.power <= (int)powerLeft)
			{
				list.Add(currentArmyUnitDefinition);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			mPregenerated = list[index];
			mHasPregeneratedArmy = true;
			if (sendEvent && UnitWasPregenerated != null)
			{
				UnitWasPregenerated(mPregenerated);
			}
			return true;
		}
		return false;
	}

	public void PreGenerateRandomUnit(ArmyUnitDefinition unit)
	{
		mHasPregeneratedArmy = true;
		if (UnitWasPregenerated != null)
		{
			UnitWasPregenerated(unit);
		}
	}

	private void InstanceOnPlayerDataLoaded()
	{
		for (int i = 0; i < armyDefinitions.Count; i++)
		{
			ArmyUnit armyUnit = armyDefinitions[i];
			armyUnit.index = i;
			string[] array = armyUnit.behaviour.upgradeSlots.armyUpgradesRow.SPAWNS.Split(' ');
			armyUnit.unitsCounts = new List<ArmyUnitDefinition>();
			string[] array2 = array;
			foreach (string value in array2)
			{
				armyUnit.unitsCounts.Add(new ArmyUnitDefinition
				{
					numberOfEnemies = Convert.ToInt32(value),
					armyUnit = armyUnit
				});
			}
		}
		int num = 0;
		foreach (ArmyUnit armyDefinition in armyDefinitions)
		{
			foreach (ArmyUnitDefinition unitsCount in armyDefinition.unitsCounts)
			{
				unitsCount.index = num;
				num++;
			}
		}
	}

	private void InstanceOnBeforeGameStarted()
	{
		foreach (ArmyUnit armyDefinition in armyDefinitions)
		{
			armyDefinition.spawns.Reset();
		}
		mGenerateNewUnits = true;
		mFirstSpawn = true;
		mFirstSpawnHost = true;
		baseCoolDown = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SendUnitsCoolDown).FLOATVALUE;
		mLastUnits = new Dictionary<Fractions, List<ArmyUnitDefinition>>();
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		mGenerationEnabled = false;
	}

	private void InstanceOnGameStarted()
	{
		isTutorial = false;
		mGenerationEnabled = Singleton<GameController>.instance.mainController.canDeployUnits || Singleton<GameController>.instance.isTutorialStage2;
		powerLeft = maxEnergy;
		powerLeftEnemy = maxEnergy;
		mCurrentDefinition = null;
		mGenerateTime = TimeManager.realTimeWithoutPauses;
		mNextTime = TimeManager.realTimeWithoutPauses;
		mAutoDeployEnabled = DebugSettings.instance.data.autoDeploy;
		semiAutoDeployEnabled = !DebugSettings.instance.data.autoDeploy;
		if (mSelfHostedMode) { mAutoDeployEnabled = false; semiAutoDeployEnabled = false; }
		mWaitingForClientUnitsSinceTime = null;
		autoDeployProgress = 0f;
	}

	protected override void Start()
	{
		base.Start();
		if (Application.isPlaying)
		{
			AIObject.AfterSpawned += OnAfterSpawned;
			AIObject.AIObjectKilled += AiObjectOnAiObjectKilled;
		}
	}

	private void AiObjectOnAiObjectKilled(AIObject aiObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (mSelfHostedMode) return;
		if (damageInfo.type == DestroyableObject.DamageType.Suicide)
		{
			if (aiObject.fraction == PlayerController.currentPlayer.fraction)
			{
				powerLeft = (int)powerLeft + aiObject.power;
			}
			if (aiObject.fraction != PlayerController.currentPlayer.fraction)
			{
				powerLeftEnemy = (int)powerLeftEnemy + aiObject.power;
			}
		}
		else
		{
			if (aiObject.fraction != PlayerController.currentPlayer.fraction)
			{
				powerLeft = (int)powerLeft + aiObject.power;
			}
			if (aiObject.fraction == PlayerController.currentPlayer.fraction)
			{
				powerLeftEnemy = (int)powerLeftEnemy + aiObject.power;
			}
		}
		if (mGenerationEnabled || isTutorial)
		{
			foreach (ArmyUnit armyDefinition in armyDefinitions)
			{
				if (aiObject.preparedBehaviour == armyDefinition.behaviour)
				{
					armyDefinition.spawns.Kill(aiObject.fraction);
				}
			}
		}
		powerLeft = Mathf.Clamp(powerLeft, 0, maxEnergy * 2);
		powerLeftEnemy = Mathf.Clamp(powerLeftEnemy, 0, maxEnergy * 2);
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (mSelfHostedMode) return;
		if (mGenerationEnabled || isTutorial)
		{
			ArmyUnit definition = GetDefinition(aiObject);
			if (aiObject.fraction == PlayerController.currentPlayer.fraction || Singleton<GameController>.instance.isCampaign)
			{
				powerLeft = (int)powerLeft - aiObject.power;
			}
			if (aiObject.fraction != PlayerController.currentPlayer.fraction)
			{
				powerLeftEnemy = (int)powerLeftEnemy - aiObject.power;
			}
			if (definition != null && !aiObject.spawnedByCard)
			{
				definition.spawns.Spawn(aiObject.fraction, 1);
			}
			powerLeft = Mathf.Clamp(powerLeft, 0, maxEnergy * 2);
			powerLeftEnemy = Mathf.Clamp(powerLeftEnemy, 0, maxEnergy * 2);
		}
	}

	private ArmyUnit GetDefinition(AIObject aiObject)
	{
		if (mGenerationEnabled && mPhotonView.isMine)
		{
			foreach (ArmyUnit armyDefinition in armyDefinitions)
			{
				if (aiObject.preparedBehaviour == armyDefinition.behaviour)
				{
					return armyDefinition;
				}
			}
		}
		return null;
	}

	public List<ArmyUnitDefinition> GetTutorial(List<Tuple<int, int>> unitsNums)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		for (int i = 0; i < unitsNums.Count && i < 3; i++)
		{
			list.Add(armyDefinitions[unitsNums[i].Value1].unitsCounts[unitsNums[i].Value2]);
		}
		for (int j = unitsNums.Count; j < 3; j++)
		{
			list.Add(null);
		}
		return list;
	}

	public void SetTutorialUnits(List<ArmyUnitDefinition> cards)
	{
		mGenerateNewUnits = false;
		currentArmyUnitDefinitions = cards;
		if (this.ArmyChanged != null)
		{
			this.ArmyChanged();
		}
	}

	public List<ArmyUnitDefinition> GetThreeRandomUnits(Fractions fraction)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		bool flag = false;
		if (fraction == PlayerController.currentPlayer.fraction)
		{
			flag = mFirstSpawn;
			mFirstSpawn = false;
		}
		else
		{
			flag = mFirstSpawnHost;
			mFirstSpawnHost = false;
		}
		ArmyUnitDefinition armyUnitDefinition = null;
		foreach (ArmyUnit armyDefinition in armyDefinitions)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = PlayerController.GetPlayer(fraction).playerProperties.upgradesDictionary[armyDefinition.behaviour.GetType().ToString()];
			bool isEquipped = unitUpgradeDefinition.isEquipped;
			bool isNew = unitUpgradeDefinition.isNew;
			int num = armyDefinition.spawns[fraction];
			foreach (ArmyUnitDefinition unitsCount in armyDefinition.unitsCounts)
			{
				if (armyDefinition.behaviour.CanBeSpawned(fraction, unitsCount.numberOfEnemies) && isEquipped && (unitsCount.numberOfEnemies + num <= armyDefinition.behaviour.maxGeneratedCount || armyDefinition.behaviour.maxGeneratedCount == 0))
				{
					list.Add(unitsCount);
					if (isNew)
					{
						armyUnitDefinition = unitsCount;
					}
				}
			}
		}
		List<ArmyUnitDefinition> list2 = new List<ArmyUnitDefinition>();
		foreach (KeyValuePair<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> item2 in unitsByType)
		{
			if (item2.Value != null)
			{
				item2.Value.Clear();
			}
		}
		foreach (ArmyUnitDefinition item3 in list)
		{
			if (unitsByType.TryGetValue(item3.armyUnit.behaviour.unitType, out var value))
			{
				value.Add(item3);
				continue;
			}
			List<ArmyUnitDefinition> list3 = new List<ArmyUnitDefinition>();
			list3.Add(item3);
			value = list3;
			unitsByType[item3.armyUnit.behaviour.unitType] = value;
		}
		List<ArmyUnitDefinition> value2 = null;
		if (Singleton<GameController>.instance.mainController.spawningType == SpawningType.Fixed && mLastUnits.TryGetValue(fraction, out value2))
		{
			foreach (ArmyUnitDefinition item4 in value2)
			{
				LevelBehaviour.UnitType unitType = item4.armyUnit.behaviour.unitType;
				if (unitsByType[unitType].Contains(item4))
				{
					unitsByType[unitType] = new List<ArmyUnitDefinition> { item4 };
				}
			}
		}
		List<ArmyUnitDefinition> list4 = new List<ArmyUnitDefinition>();
		foreach (KeyValuePair<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> item5 in unitsByType)
		{
			if (item5.Value.Count > 0)
			{
				list4.Add(item5.Value[UnityEngine.Random.Range(0, item5.Value.Count)]);
			}
		}
		while (list4.Count == 4)
		{
			int index = UnityEngine.Random.Range(0, 4);
			if (value2 == null || !value2.Contains(list4[index]))
			{
				list4.RemoveAt(index);
			}
		}
		if (list4.Count == 3)
		{
			list = list4;
		}
		List<int> list5 = new List<int>();
		if (list.Count >= 3)
		{
			while (list5.Count != 3)
			{
				int item = UnityEngine.Random.Range(0, list.Count);
				if (!list5.Contains(item))
				{
					list5.Add(item);
				}
			}
			foreach (int item6 in list5)
			{
				list2.Add(list[item6]);
			}
			if (list2.Count != 3)
			{
				Debug.LogError("error in count of army");
			}
		}
		else
		{
			if (list.Count == 0)
			{
				list.Add(armyDefinitions[0].unitsCounts[0]);
			}
			foreach (ArmyUnitDefinition item7 in list)
			{
				list2.Add(item7);
			}
			while (list2.Count != 3)
			{
				list2.Add(list[list.Count - 1]);
			}
			if (list2.Count != 3)
			{
				Debug.LogError("error in count of army");
			}
		}
		if (flag && armyUnitDefinition != null)
		{
			bool flag2 = false;
			for (int i = 0; i < list2.Count; i++)
			{
				ArmyUnitDefinition armyUnitDefinition2 = list2[i];
				if (armyUnitDefinition2.armyUnit.behaviour == armyUnitDefinition.armyUnit.behaviour)
				{
					list2[i] = armyUnitDefinition;
					flag2 = true;
				}
			}
			if (!flag2)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					ArmyUnitDefinition armyUnitDefinition3 = list2[j];
					if (armyUnitDefinition3.armyUnit.behaviour.unitType == armyUnitDefinition.armyUnit.behaviour.unitType)
					{
						list2[j] = armyUnitDefinition;
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list2[0] = armyUnitDefinition;
				}
			}
		}
		mLastUnits[fraction] = list2;
		return list2;
	}

	public void SendUnit(ArmyUnitDefinition definition, Fractions fraction, bool useEnergy = true, bool clicked = false)
	{
		if (mSelfHostedMode)
		{
			if (mSelfHosted == null || !mSelfHosted.IsConnected || mSelfHostedDeployPending || !useEnergy ||
				fraction != PlayerController.currentPlayer.fraction || definition == null ||
				!currentArmyUnitDefinitions.Contains(definition)) return;
			mSelfHostedDeployPending = true;
			SendSelfHostedUnit(definition, clicked);
			return;
		}
		autoDeployProgress = 0f;
		mCurrentDefinition = definition;
		mCoolDown = (baseCoolDown + definition.coolDown) * mCoolDownMultiplier;
		mNextTime = TimeManager.realTimeWithoutPauses + mCoolDown;
		mGenerateTime = TimeManager.realTimeWithoutPauses;
		if (PlayerController.currentPlayer.fraction == fraction)
		{
			StatsManager.instance.matchStats.DeployUnit(definition.armyUnit.behaviour.indexInLevelsManager, definition.numberOfEnemies, clicked);
		}
		mGenerateNewUnits = true;
		mHasPregeneratedArmy = false;
		mPhotonView.RPC("SendUnitRPC", PhotonTargets.AllViaServer, definition.index, (byte)PlayerController.currentPlayer.fraction, useEnergy);
	}

	private async void SendSelfHostedUnit(ArmyUnitDefinition definition, bool clicked)
	{
		try
		{
			MatchReply reply = await mSelfHosted.DeployArmyResult(definition.index);
			mSelfHostedForceRefresh = reply.Code != "army-deploying";
			if (reply.Code == "army-deploying")
			{
				autoDeployProgress = 0f;
				mCurrentDefinition = definition;
				mCoolDown = (baseCoolDown + definition.coolDown) * mCoolDownMultiplier;
				if (clicked)
					StatsManager.instance.matchStats.DeployUnit(
						definition.armyUnit.behaviour.indexInLevelsManager,
						definition.numberOfEnemies, true);
			}
			await mSelfHosted.RefreshArmy();
		}
		catch (Exception error)
		{
			mSelfHostedForceRefresh = true;
			Debug.LogException(error);
		}
		finally { mSelfHostedDeployPending = false; }
	}

	public void SendBotUnit(ArmyUnitDefinition definition, Fractions fraction)
	{
		if (mSelfHostedMode) return;
		StartCoroutine(RadicalRoutine.Run(Spawn(definition, fraction)));
	}

	[PunRPC]
	private void SendUnitRPC(int index, byte fraction, bool useEnergy)
	{
		if (mSelfHostedMode) return;
		if (!Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			return;
		}
		foreach (ArmyUnit armyDefinition in armyDefinitions)
		{
			foreach (ArmyUnitDefinition unitsCount in armyDefinition.unitsCounts)
			{
				if (unitsCount.index == index)
				{
					StartCoroutine(RadicalRoutine.Run(Spawn(unitsCount, (Fractions)fraction, useEnergy)));
					if (mLastUnits.TryGetValue((Fractions)fraction, out var value))
					{
						value.Remove(unitsCount);
					}
					break;
				}
			}
		}
	}

	private void GetUnitsForClient()
	{
		mGenerateNewUnits = false;
		if (mSelfHostedMode) { mWaitingForClientUnitsSinceTime = null; return; }
		mWaitingForClientUnitsSinceTime = TimeManager.realTimeWithoutPauses;
		PhotonCachedRPC.SendOfflineRPC(mPhotonView, "GetRandomUnitsForHost", PhotonTargets.MasterClient, (byte)PlayerController.currentPlayer.fraction, PlayerController.currentPlayer.playerNetworkId);
	}

	[PunRPC]
	private void GetRandomUnitsForHost(byte fraction, int playerID)
	{
		if (mSelfHostedMode) return;
		List<ArmyUnitDefinition> threeRandomUnits = GetThreeRandomUnits((Fractions)fraction);
		byte[] array = new byte[3];
		for (int i = 0; i < threeRandomUnits.Count; i++)
		{
			ArmyUnitDefinition armyUnitDefinition = threeRandomUnits[i];
			array[i] = (byte)armyUnitDefinition.index;
		}
		PlayerController player = PlayerController.GetPlayer(playerID);
		if (player != null)
		{
			PhotonCachedRPC.SendOfflineRPC(mPhotonView, "RecieveRandomUnitsForHost", PhotonTargets.AllViaServer, array, player.playerNetworkId);
		}
	}

	[PunRPC]
	private void RecieveRandomUnitsForHost(byte[] armies, int id)
	{
		if (mSelfHostedMode) return;
		if (!PlayerController.players.ContainsKey(id) || !PlayerController.players[id].isCurrentPlayer)
		{
			return;
		}
		mWaitingForClientUnitsSinceTime = null;
		currentArmyUnitDefinitions = new List<ArmyUnitDefinition>();
		foreach (byte b in armies)
		{
			foreach (ArmyUnit armyDefinition in armyDefinitions)
			{
				foreach (ArmyUnitDefinition unitsCount in armyDefinition.unitsCounts)
				{
					if ((byte)unitsCount.index == b)
					{
						currentArmyUnitDefinitions.Add(unitsCount);
						goto end_IL_00c0;
					}
				}
				continue;
				end_IL_00c0:
				break;
			}
		}
		if (this.ArmyChanged != null)
		{
			this.ArmyChanged();
		}
	}

	private IEnumerator Spawn(ArmyUnitDefinition definition, Fractions fraction, bool useEnergy = true)
	{
		if (onStartSpawning != null)
		{
			onStartSpawning(fraction, definition);
		}
		Fractions fr = fraction;
		if (Singleton<GameController>.instance.isCampaign)
		{
			fr = Fractions.Enemies;
		}
		if (definition.CanSpawnAllUnits(fr))
		{
			for (int i = 0; i < definition.numberOfEnemies; i++)
			{
				AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(definition.armyUnit.behaviour);
				if (enemy != null && enemy.prefab != null)
				{
					if (definition.CanBesSpawned(fr, 1))
					{
						SpawningManager.instance.Spawn(enemy, fr, useEnergy, Vector3.one * 9999f);
					}
					else
					{
						Debug.LogError("Can not spawn unit, already reached maxGeneratedCount");
						Debug.LogError(string.Concat(definition.armyUnit, definition.ToString()));
					}
				}
				yield return new WaitForRealSeconds(0.3f);
			}
		}
		else
		{
			Debug.LogError("Trying to generate army but this definition shouldnt be used !!!!!!!!!!!! ");
			Debug.LogError(string.Concat(definition.armyUnit, definition.ToString()));
			string str = "ALL: \n";
			for (int index = 0; index < armyDefinitions.Count; index++)
			{
				ArmyUnit armyUnitDefinition = armyDefinitions[index];
				str = string.Concat(str, armyUnitDefinition, "\n");
				str += armyUnitDefinition.spawns.ToString();
			}
			Debug.LogError(str);
			str = "CURRENT: \n";
			foreach (ArmyUnitDefinition armyUnitDefinition2 in currentArmyUnitDefinitions)
			{
				if (armyUnitDefinition2 != null)
				{
					str = string.Concat(str, armyUnitDefinition2.armyUnit, "\n");
					str += armyUnitDefinition2.armyUnit.spawns.ToString();
				}
				else
				{
					str += "NULL unit";
				}
			}
			Debug.LogError(str);
		}
		if (onFinishSpawning != null)
		{
			onFinishSpawning(fr, definition);
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	public new void OnDestroy()
	{
		if (mSelfHosted != null)
		{
			mSelfHosted.ArmyOffersReceived -= ApplySelfHostedArmy;
			mSelfHosted = null;
		}
		base.OnDestroy();
	}

	public void Enable()
	{
		mGenerationEnabled = true;
	}

	public void ReSyncPower()
	{
		if (mSelfHostedMode) return;
		mPhotonView.RPC("ReSyncPowerRPC", PhotonTargets.Others, (int)powerLeft, (int)powerLeftEnemy);
	}

	[PunRPC]
	private void ReSyncPowerRPC(int masterPower, int clientPower)
	{
		if (mSelfHostedMode) return;
		powerLeft = clientPower;
		powerLeftEnemy = masterPower;
	}
}
