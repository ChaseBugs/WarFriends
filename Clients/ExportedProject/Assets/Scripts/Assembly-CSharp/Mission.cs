using UnityEngine.AI;
using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Mission : Core_BaseScript
{
	public enum MissionType
	{
		Elimination,
		Survive,
		Boss,
		Score
	}

	public string map = "Unknown";

	public int index;

	protected bool mIsMissionPlaying;

	public static Dictionary<string, Tuple<Type, int>> behavioursDictionary = new Dictionary<string, Tuple<Type, int>>(StringComparer.OrdinalIgnoreCase)
	{
		{
			"Assaulter",
			new Tuple<Type, int>(typeof(SoldierBehaviourAssaulter), 0)
		},
		{
			"Sniper",
			new Tuple<Type, int>(typeof(SoldierBehaviourSniper), 4)
		},
		{
			"Grenadier",
			new Tuple<Type, int>(typeof(SoldierBehaviourGrennader), 4)
		},
		{
			"Shotgunner",
			new Tuple<Type, int>(typeof(SoldierBehaviourShotgunner), 2)
		},
		{
			"Parachuter",
			new Tuple<Type, int>(typeof(SoldierBehaviourParachuter), 4)
		},
		{
			"Minigunner",
			new Tuple<Type, int>(typeof(SoldierBehaviourMinigunner), 2)
		},
		{
			"RocketLauncher",
			new Tuple<Type, int>(typeof(SoldierBehaviourBazooka), 2)
		},
		{
			"Swat",
			new Tuple<Type, int>(typeof(SoldierBehaviourSwat), 2)
		},
		{
			"Engineer",
			new Tuple<Type, int>(typeof(SoldierBehaviourEngineer), 2)
		},
		{
			"Drone",
			new Tuple<Type, int>(typeof(DroneBehaviour), 2)
		},
		{
			"Helicopter",
			new Tuple<Type, int>(typeof(AssaultHelicopterBehaviour), 1)
		},
		{
			"DeployHeli",
			new Tuple<Type, int>(typeof(HelicopterBehaviour), 1)
		},
		{
			"Humvee",
			new Tuple<Type, int>(typeof(CarBehaviour), 1)
		},
		{
			"Buggy",
			new Tuple<Type, int>(typeof(CarBuggyBehaviour), 1)
		},
		{
			"Tank",
			new Tuple<Type, int>(typeof(TankBehaviour), 1)
		},
		{
			"MachineGunner",
			new Tuple<Type, int>(typeof(SoldierBehaviourMachineGunner), 5)
		},
		{
			"SciFi",
			new Tuple<Type, int>(typeof(SoldierBehaviourSciFi), 3)
		},
		{
			"Transporter",
			new Tuple<Type, int>(typeof(CarTransporterBehaviour), 1)
		},
		{
			"Commando",
			new Tuple<Type, int>(typeof(SoldierBehaviourCommando), 2)
		},
		{
			"Flamethrower",
			new Tuple<Type, int>(typeof(SoldierBehaviourFlamethrower), 2)
		},
		{
			"Gunslinger",
			new Tuple<Type, int>(typeof(SoldierBehaviourGunslinger), 2)
		},
		{
			"Warper",
			new Tuple<Type, int>(typeof(SoldierBehaviourWarper), 2)
		},
		{
			"Mortar",
			new Tuple<Type, int>(typeof(SoldierBehaviourMortar), 2)
		},
		{
			"Mech",
			new Tuple<Type, int>(typeof(MechBehaviour), 2)
		}
	};

	protected MissionDefinition mMissionDefinition;

	private int mLastTime;

	public int number => index + 1;

	public float remainingTime { get; set; }

	public virtual MissionType missionType => MissionType.Elimination;

	public MissionsManager.MissionData savedData
	{
		get
		{
			if (MissionsManager.instance.data == null)
			{
				Debug.LogError("No mission data");
				return null;
			}
			if (!MissionsManager.instance.data.missionData.ContainsKey(index))
			{
				Debug.LogError("Missions do not contains index " + index);
				return null;
			}
			return MissionsManager.instance.data.missionData[index];
		}
	}

	public int highscore => (savedData != null) ? savedData.highscore : 0;

	public int numberOfStars => (savedData != null) ? savedData.numberOfStars : 0;

	public bool completedAlone => savedData != null && savedData.completedAlone;

	public bool completedInCoop => savedData != null && savedData.completedInCoop;

	public bool completedWithGoldReward => savedData != null && (savedData.completedInCoop || savedData.completedAlone);

	public bool completed => completedAlone || completedInCoop;

	public bool shouldGetGold => savedData != null && !completedWithGoldReward;

	public bool opened
	{
		get
		{
			if (index == 0)
			{
				return true;
			}
			int key = index - 1;
			if (!MissionsManager.instance.data.missionData.ContainsKey(key))
			{
				return completed;
			}
			Mission mission = MissionsManager.instance.missions[key];
			return mission.completedWithGoldReward || completedWithGoldReward;
		}
	}

	public float maxTimeForMission => mMissionDefinition.maxTimeForMission;

	public int scoreFor1Star => mMissionDefinition.scoreFor1Star;

	public int scoreFor2Stars => mMissionDefinition.scoreFor2Stars;

	public int scoreFor3Stars => mMissionDefinition.scoreFor3Stars;

	protected float hpTarget => mMissionDefinition.hpFract;

	protected float timeTarget => mMissionDefinition.timeFract;

	public int rewardWBCompleted => Mathf.FloorToInt((float)mMissionDefinition.rewardWarbucks * 0.2f);

	public int rewardXPCompleted => Mathf.FloorToInt((float)mMissionDefinition.rewardXP * 0.2f);

	public int rewardWB => (!completed) ? mMissionDefinition.rewardWarbucks : rewardWBCompleted;

	public int rewardGold => mMissionDefinition.rewardGold;

	public int rewardXP => (!completed) ? mMissionDefinition.rewardXP : rewardXPCompleted;

	public bool playingInHeroicMode { get; set; }

	public bool isHeroic => MissionsManager.instance.data.heroicData.index == index;

	public bool completedInHeroic => isHeroic && MissionsManager.instance.data.heroicData.completed;

	public int heroicRewardGold => isHeroic ? MissionsManager.instance.data.heroicData.goldReward : 0;

	public int heroicRewardWB => isHeroic ? MissionsManager.instance.data.heroicData.warbucksReward : 0;

	public MissionsManager.HeroicType heroicType => MissionsManager.instance.data.heroicData.type;

	public int recommendedArmyPower => mMissionDefinition.recommendedAP;

	public virtual int hudProgress => 0;

	public virtual float progress => 0f;

	public virtual string hudObjective => "UNDEFINED";

	public virtual string missionObjectiveProgress => "Undefined mission progress end screen";

	public virtual void LoadMissionData(MissionDefinition missionDefinition)
	{
		mMissionDefinition = missionDefinition;
		int num = Mathf.Clamp(missionDefinition.map - 1, 0, Singleton<MapManager>.instance.mapEntries.Count - 1);
		map = Singleton<MapManager>.instance.mapEntries[num].name;
		remainingTime = maxTimeForMission;
	}

	public virtual void OpenMission(DatabasePlayer player, bool isInvite, bool isRematch, bool isHeroicMode)
	{
		playingInHeroicMode = isHeroicMode;
		Singleton<GameController>.instance.opponent = null;
	}

	public virtual void PlayMission(bool isMaster)
	{
		Debug.Log($"Play Mission id: {index}, {missionObjectiveProgress}");
		if (!isMaster)
		{
			return;
		}
		remainingTime = maxTimeForMission;
		Singleton<MapManager>.instance.SelectCurrentMap(map);
		if (playingInHeroicMode)
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoop)
			{
				savedData.attemptHeroCoop++;
			}
			else
			{
				savedData.attemptHero++;
			}
		}
		else if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoop)
		{
			savedData.attemptCoop++;
		}
		else
		{
			savedData.attemptCount++;
		}
		mMissionDefinition.OnPlayMission();
		MissionsManager.instance.LoadUnitsVisuals(this);
		SpawnInitialUnits();
	}

	public virtual void OnGameStarted()
	{
		mIsMissionPlaying = true;
	}

	public void OnAfterGameStarted()
	{
		int num = 0;
		int num2 = 0;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (num < mMissionDefinition.playerShieldStates.Count && item.fraction == PlayerController.currentPlayer.fraction)
			{
				MissionDefinitionShieldState missionDefinitionShieldState = mMissionDefinition.playerShieldStates[num];
				item.point.shield.canRegenerate = missionDefinitionShieldState.regenerate;
				item.point.shield.autoRepair = missionDefinitionShieldState.autoRepair;
				item.point.shield.RefillTo(missionDefinitionShieldState.healthRatio * missionDefinitionShieldState.maxHealthRatio * item.point.shield.maxHealth, missionDefinitionShieldState.maxHealthRatio * item.point.shield.maxHealth);
				num++;
			}
			if (num2 < mMissionDefinition.botShieldStates.Count && item.fraction != PlayerController.currentPlayer.fraction)
			{
				MissionDefinitionShieldState missionDefinitionShieldState2 = mMissionDefinition.botShieldStates[num2];
				item.point.shield.canRegenerate = missionDefinitionShieldState2.regenerate;
				item.point.shield.autoRepair = missionDefinitionShieldState2.autoRepair;
				item.point.shield.RefillTo(missionDefinitionShieldState2.healthRatio * missionDefinitionShieldState2.maxHealthRatio * item.point.shield.maxHealth, missionDefinitionShieldState2.maxHealthRatio * item.point.shield.maxHealth);
				num2++;
			}
		}
		if (mMissionDefinition.playerEnergy != 0)
		{
			Singleton<SpawningManagerDeathMatch>.instance.powerLeft = mMissionDefinition.playerEnergy;
		}
		if (mMissionDefinition.botEnergy != 0)
		{
			Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy = mMissionDefinition.botEnergy;
		}
	}

	public void LoadingStarted()
	{
		foreach (MissionDefinitionEvent @event in mMissionDefinition.events)
		{
			if (@event.isCardUnit && !string.IsNullOrEmpty(@event.behaviour))
			{
				Type value = behavioursDictionary[@event.behaviour].Value1;
				LevelBehaviour behaviour = LevelManager.instance.GetBehaviour(value);
				StartCoroutine(behaviour.PrepareVisualsForCardCoroutine(mine: false, opponent: true));
			}
		}
	}

	public void MissionSuccessCoopClient()
	{
		savedData.completedInCoopClient = true;
	}

	protected virtual int computedGainedSuccesScore()
	{
		int num = scoreFor1Star;
		float healthRatio = Singleton<GameController>.instance.mainPlayerController.destroyableParts.healthRatio;
		float num2 = Singleton<GameController>.instance.time / maxTimeForMission;
		if (healthRatio >= hpTarget && num2 >= timeTarget)
		{
			num += MiscTools.RoundToInt(healthRatio / hpTarget * (float)(scoreFor2Stars - scoreFor1Star));
			return num + MiscTools.RoundToInt(num2 / timeTarget * (float)(scoreFor3Stars - scoreFor2Stars));
		}
		num += MiscTools.RoundToInt(Mathf.Clamp01(healthRatio / hpTarget) * (float)(scoreFor2Stars - scoreFor1Star));
		return num + MiscTools.RoundToInt(Mathf.Clamp01(num2 / timeTarget) * (float)(scoreFor3Stars - scoreFor2Stars));
	}

	protected void MissionSuccess()
	{
		mIsMissionPlaying = false;
		Debug.Log("MISSIONS SCORE DEBUG - score for mission " + Singleton<ScoreManager>.instance.scoreCoop + " extra time score ");
		int num = computedGainedSuccesScore();
		int stars = GetStars(num);
		Debug.Log("Mission succes: coop score: " + num);
		Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.MissionSuccess;
		if (stars > numberOfStars)
		{
			MissionsManager.instance.MissionStarsSucceeded(index, numberOfStars, stars);
			savedData.numberOfStars = stars;
		}
		if (highscore <= num)
		{
			savedData.highscore = num;
		}
		if (playingInHeroicMode)
		{
			MissionsManager.instance.data.heroicData.completed = true;
		}
		else if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
		{
			if (!savedData.completedInCoop)
			{
				MissionsManager.instance.MissionNewTypeSucceeded(index, isCoop: true);
			}
			if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				savedData.completedInCoop = true;
			}
			else
			{
				savedData.completedInCoopClient = true;
			}
		}
		else
		{
			if (!savedData.completedAlone)
			{
				MissionsManager.instance.MissionNewTypeSucceeded(index, isCoop: false);
			}
			savedData.completedAlone = true;
		}
		MissionsManager.instance.MissionSucceeded(this);
		Debug.Log("Mission Manager: Data ready to be sent");
	}

	protected void MissionFail()
	{
		Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.MissionFailed;
	}

	public virtual void EndMission()
	{
		mIsMissionPlaying = false;
		MissionsManager.instance.EndMission(this);
	}

	public void UpdateCurrentMission()
	{
		if (mIsMissionPlaying && Singleton<GameController>.instance.gameIsRunning)
		{
			UpdateMission();
		}
	}

	protected virtual void UpdateMission()
	{
		if (remainingTime <= 0f)
		{
			Debug.Log($"End Mission id: {index}, remaining time: {remainingTime}");
			EndMission();
		}
		float num = maxTimeForMission - remainingTime;
		if (mLastTime != (int)remainingTime)
		{
			mLastTime = (int)remainingTime;
			foreach (MissionDefinitionEvent @event in mMissionDefinition.events)
			{
				if (@event.used || !(num >= @event.time))
				{
					continue;
				}
				@event.used = true;
				if (!string.IsNullOrEmpty(@event.card))
				{
					@event.used = Singleton<CardManagerDeathmatchOffline>.instance.UseMissionEventCard(@event.card);
				}
				if (string.IsNullOrEmpty(@event.behaviour))
				{
					continue;
				}
				bool flag = false;
				WaveManager.WaveBehaviourDefinition waveBehaviourDefinition = null;
				string a = behavioursDictionary[@event.behaviour].Value1.Name;
				foreach (WaveManager.WaveBehaviourDefinition behaviourDefinition in Singleton<WaveManager>.instance.waveDefinition.behaviourDefinitions)
				{
					if (string.Equals(a, behaviourDefinition.behaviourLevel.behaviorName, StringComparison.OrdinalIgnoreCase))
					{
						if (behaviourDefinition.spawned < behaviourDefinition.sceneLimit)
						{
							waveBehaviourDefinition = behaviourDefinition;
						}
						else
						{
							flag = true;
						}
						break;
					}
				}
				if (!flag)
				{
					if (behavioursDictionary.TryGetValue(@event.behaviour, out var value))
					{
						LevelBehaviour behaviour = LevelManager.instance.GetBehaviour(value.Value1);
						if (behaviour != null)
						{
							if (@event.isCardUnit)
							{
								float num2 = Mathf.Clamp01((float)@event.level / 25f);
								SpawningManager.instance.SpawnForCard(behaviour, 1, num2, Fractions.Enemies, Vector3.one * 9999f);
								if (waveBehaviourDefinition != null)
								{
									waveBehaviourDefinition.generatedCount++;
									waveBehaviourDefinition.eventUnitsCount++;
								}
								@event.spawned++;
							}
							else
							{
								int unitUpgrades = GetUnitUpgrades(behaviour, @event.level);
								if (Singleton<WaveManager>.instance.SpawnUnit(behaviour, unitUpgrades))
								{
									if (waveBehaviourDefinition != null)
									{
										waveBehaviourDefinition.generatedCount++;
										waveBehaviourDefinition.eventUnitsCount++;
									}
									@event.spawned++;
								}
							}
							@event.used = ((@event.count != 0) ? (@event.spawned >= @event.count) : (@event.spawned > 0));
						}
						else
						{
							Debug.Log($"Uknown behaviour in mission, behaviour: {@event.behaviour}");
						}
					}
					else
					{
						Debug.Log($"Uknown behaviour in mission, behaviour: {@event.behaviour}");
					}
				}
				else
				{
					@event.used = false;
				}
			}
		}
		remainingTime -= Time.deltaTime;
	}

	public virtual string Hud(int progressHud)
	{
		return hudObjective;
	}

	public virtual string GetMissionObjective()
	{
		return string.Empty;
	}

	public int GetStars(int score)
	{
		int result = 0;
		if (scoreFor1Star <= score)
		{
			result = 1;
		}
		if (scoreFor2Stars <= score)
		{
			result = 2;
		}
		if (scoreFor3Stars <= score)
		{
			result = 3;
		}
		return result;
	}

	public float ProgressMission(float star1AmountProgress, float star2AmountProgress, int score)
	{
		switch (GetStars(score))
		{
		case 0:
			return star1AmountProgress * Mathf.Clamp01((float)score / (float)scoreFor1Star);
		case 1:
		{
			float value2 = (float)(score - scoreFor1Star) / (float)(scoreFor2Stars - scoreFor1Star);
			return star1AmountProgress + (star2AmountProgress - star1AmountProgress) * Mathf.Clamp01(value2);
		}
		case 2:
		{
			float value = (float)(score - scoreFor2Stars) / (float)(scoreFor3Stars - scoreFor2Stars);
			return star2AmountProgress + (1f - star2AmountProgress) * Mathf.Clamp01(value);
		}
		default:
			return 1f;
		}
	}

	protected List<WaveManager.BehaviourLevel> GetBehaviourLevels(MissionsRow row)
	{
		List<WaveManager.BehaviourLevel> list = new List<WaveManager.BehaviourLevel>();
		foreach (KeyValuePair<string, Tuple<Type, int>> item in behavioursDictionary)
		{
			string stringData = row.GetStringData(item.Key.ToUpper());
			string[] array = stringData.Split(',');
			int num = int.Parse(array[0]);
			if (num >= 0)
			{
				list.Add(new WaveManager.BehaviourLevel
				{
					upgradesSingleLevel = num,
					behaviorName = item.Value.Value1.ToString()
				});
			}
		}
		return list;
	}

	protected List<WaveManager.BehaviourLevel> GetBehaviourLevels(MissionDefinition missionDefinition)
	{
		List<WaveManager.BehaviourLevel> list = new List<WaveManager.BehaviourLevel>();
		foreach (MissionDefinitionBehaviour behaviour in missionDefinition.behaviours)
		{
			list.Add(new WaveManager.BehaviourLevel
			{
				behaviorName = behavioursDictionary[behaviour.name].Value1.Name,
				upgradesSingleLevel = behaviour.level
			});
		}
		foreach (MissionDefinitionEvent @event in mMissionDefinition.events)
		{
			if (@event.isCardUnit || string.IsNullOrEmpty(@event.behaviour))
			{
				continue;
			}
			string text = behavioursDictionary[@event.behaviour].Value1.Name;
			bool flag = false;
			foreach (WaveManager.BehaviourLevel item in list)
			{
				if (item.behaviorName == text && item.upgradesSingleLevel == @event.level)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(new WaveManager.BehaviourLevel
				{
					behaviorName = text,
					upgradesSingleLevel = @event.level
				});
			}
		}
		return list;
	}

	public virtual List<MissionDialog.MissionEnemiesData> GetEnemiesInMission()
	{
		List<MissionDialog.MissionEnemiesData> list = new List<MissionDialog.MissionEnemiesData>();
		foreach (MissionDefinitionBehaviour behaviour3 in mMissionDefinition.behaviours)
		{
			Type value = behavioursDictionary[behaviour3.name].Value1;
			LevelBehaviour behaviour = LevelManager.instance.GetBehaviour(value);
			list.Add(new MissionDialog.MissionEnemiesData
			{
				iconName = behaviour.upgradeSlots.iconName,
				unitLevel = behaviour.upgradeSlots.GetDisplayLevelForIndex(behaviour3.level),
				unitType = MissionDialog.MissionEnemiesData.UnitType.Unit,
				unitUnlockedLevel = behaviour.upgradeSlots.unlockLevelIndex
			});
		}
		foreach (MissionDefinitionEvent @event in mMissionDefinition.events)
		{
			if (@event.isCardUnit)
			{
				Type value2 = behavioursDictionary[@event.behaviour].Value1;
				LevelBehaviour behaviour2 = LevelManager.instance.GetBehaviour(value2);
				if (string.IsNullOrEmpty(behaviour2.cardId))
				{
					Debug.LogError($"Mission {number} contains event for unit {@event.behaviour} that should be card event but unit does not contain card variant!!!");
					continue;
				}
				Card cardDef = CardManager.instance.GetCardInstance(behaviour2.cardId);
				int num = list.FindIndex((MissionDialog.MissionEnemiesData data1) => data1.iconName == cardDef.iconName);
				if (num < 0)
				{
					list.Add(new MissionDialog.MissionEnemiesData
					{
						iconName = cardDef.iconName,
						unitType = MissionDialog.MissionEnemiesData.UnitType.Card
					});
				}
			}
			else if (!string.IsNullOrEmpty(@event.behaviour))
			{
				Type value3 = behavioursDictionary[@event.behaviour].Value1;
				LevelBehaviour levelBehaviour = LevelManager.instance.GetBehaviour(value3);
				int num2 = list.FindIndex((MissionDialog.MissionEnemiesData data1) => data1.iconName == levelBehaviour.upgradeSlots.iconName);
				if (num2 < 0)
				{
					list.Add(new MissionDialog.MissionEnemiesData
					{
						iconName = levelBehaviour.upgradeSlots.iconName,
						unitLevel = levelBehaviour.upgradeSlots.GetDisplayLevelForIndex(@event.level),
						unitType = MissionDialog.MissionEnemiesData.UnitType.Unit,
						unitUnlockedLevel = levelBehaviour.upgradeSlots.unlockLevelIndex
					});
				}
			}
		}
		list.Sort((MissionDialog.MissionEnemiesData data1, MissionDialog.MissionEnemiesData data2) => data1.CompareTo(data2));
		return list;
	}

	public WaveManager.BehaviourLevel GetBehaviour(LevelBehaviour behaviour, List<WaveManager.BehaviourLevel> generatedArmies)
	{
		foreach (WaveManager.BehaviourLevel generatedArmy in generatedArmies)
		{
			if (generatedArmy.behaviorName == behaviour.GetType().Name)
			{
				return generatedArmy;
			}
		}
		return null;
	}

	public List<UnitUpgradeDefinition> GetUpgrades()
	{
		return ParseUpgrades(mMissionDefinition);
	}

	protected List<UnitUpgradeDefinition> ParseUpgrades(MissionDefinition missionDefinition)
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<WaveManager.BehaviourLevel> behaviourLevels = GetBehaviourLevels(missionDefinition);
		foreach (LevelBehaviour item in behaviours)
		{
			WaveManager.BehaviourLevel behaviour = GetBehaviour(item, behaviourLevels);
			if (behaviour != null)
			{
				int unitUpgrades = GetUnitUpgrades(item, behaviour.upgradesSingleLevel);
				list.Add(new UnitUpgradeDefinition(isEquipped: true, new UpgradeSlots.UnitUpgrades(1f)
				{
					slotUpgradeindex = unitUpgrades
				}, isNew: false, 1));
			}
			else
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item.upgradeSlots.LoadData(item);
				list.Add(new UnitUpgradeDefinition(isEquipped: false, upgradeIndex, isNew: false, 1));
			}
		}
		return list;
	}

	private int GetUnitUpgrades(LevelBehaviour behaviour, int level)
	{
		return Mathf.Clamp(level, 0, behaviour.upgradeSlots.numberOfUpgrades - 1);
	}

	public void LoadInitialUnitVisuals()
	{
		bool flag = false;
		bool flag2 = false;
		foreach (MissionDefinitionInitialUnit initialUnit in mMissionDefinition.initialUnits)
		{
			switch (initialUnit.behaviour)
			{
			case MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.HeavyTurret:
				flag2 = true;
				break;
			case MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.RocketTurret:
				flag = true;
				break;
			}
		}
		if (flag)
		{
			StartCoroutine(Singleton<ObjectPoolDatabase>.instance.turretRockets.preparedBehaviour.PrepareVisualsForCardCoroutine(mine: false, opponent: true));
		}
		if (flag2)
		{
			StartCoroutine(Singleton<ObjectPoolDatabase>.instance.heavyTurret.preparedBehaviour.PrepareVisualsForCardCoroutine(mine: false, opponent: true));
		}
	}

	private void SpawnInitialUnits()
	{
		foreach (MissionDefinitionInitialUnit initialUnit in mMissionDefinition.initialUnits)
		{
			LevelBehaviour levelBehaviour = null;
			switch (initialUnit.behaviour)
			{
			case MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.Turret:
				levelBehaviour = Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour;
				break;
			case MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.RocketTurret:
				levelBehaviour = Singleton<ObjectPoolDatabase>.instance.turretRockets.preparedBehaviour;
				break;
			case MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.HeavyTurret:
				levelBehaviour = Singleton<ObjectPoolDatabase>.instance.heavyTurret.preparedBehaviour;
				break;
			}
			if (levelBehaviour != null)
			{
				NavMesh.SamplePosition(initialUnit.position, out var hit, 10f, 1);
				float num = (float)initialUnit.level / (float)LevelManager.instance.maxDisplayLevel;
				SpawningManager.instance.SpawnForCard(levelBehaviour, 1, num, Fractions.Enemies, hit.position, spawnEnabled: false);
			}
			else
			{
				Debug.Log($"Uknown behaviour in mission (initial units), behaviour: {initialUnit.behaviour}");
			}
		}
	}

	public MissionDefinition GetDefinition()
	{
		return mMissionDefinition;
	}

	public virtual void OnBeforeGameStarted()
	{
	}

	public virtual void Quit()
	{
	}
}
