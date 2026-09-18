using System.Collections.Generic;
using UnityEngine;

public class BotMission : Mission
{
	public List<WaveManager.BehaviourLevel> generatedArmies;

	private bool mBotKilled;

	public override MissionType missionType => MissionType.Boss;

	public PlayerController botInstance { get; private set; }

	public bool botWasKilled => mBotKilled;

	public override string hudObjective => Localization.Localize("ID_MISSION_KILLBOT_HUD");

	public override string missionObjectiveProgress => Localization.LocalizeFormat("ID_MISSION_KILLBOT_OBJ", MiscTools.PrintableTimeDescription(base.maxTimeForMission));

	public WaveManager.BehaviourLevel GetBehaviour(LevelBehaviour behaviour)
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

	protected MapDefinition.DefendPosition GetMainPlayerPoint(Fractions fraction)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition playersPosition in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			if (playersPosition.mainPosition && playersPosition.fraction == fraction)
			{
				list.Add(playersPosition);
			}
		}
		if (list.Count > 0)
		{
			return list[0];
		}
		Debug.LogError("No main position was set in map definition");
		return null;
	}

	protected void CreateBotInstance()
	{
		PlayerController.currentPlayer.fraction = Fractions.Allies;
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.player);
		botInstance = ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.player) as PlayerController;
		botInstance.playerNetworkId = 10;
		botInstance.fraction = Fractions.Enemies;
		PlayerController.players[10] = botInstance;
		PlayerBot playerBot = botInstance.playerBot;
		Singleton<BotManager>.instance.PrepareBotForMission(playerBot, mMissionDefinition);
		botInstance.InitPlayer();
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(botInstance, useBackground: true);
		playerBot.enabled = true;
		Singleton<GameController>.instance.opponent = botInstance;
		botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.CardsChosen;
	}

	protected void InitBot(bool isMaster)
	{
		PlayerController.players[10] = botInstance;
		if (!botInstance.isInstantiated)
		{
			botInstance = (PlayerController)ObjectPoolDatabase.networkPool.ReInstantiate(botInstance);
		}
		CamosManager.instance.ApplyVisuals(botInstance, botInstance.playerProperties.playerVisuals, useHighRes: true);
		botInstance.gameObject.SetActive(value: true);
		Fractions fractions = Fractions.Enemies;
		MapDefinition.DefendPosition mainPlayerPoint = GetMainPlayerPoint(fractions);
		botInstance.MoveTo(mainPlayerPoint.point.transform.position, mainPlayerPoint.point.transform.rotation);
		botInstance.fraction = fractions;
		botInstance.mPhotonView.RPC("InitBotRPC", PhotonTargets.Others, (byte)fractions);
		botInstance.currentPlayerPoint = mainPlayerPoint;
		botInstance.Killed -= OnBotKilled;
		botInstance.Killed += OnBotKilled;
		botInstance.networkStatus.startAnimationFinished = true;
		if (isMaster)
		{
			PlayerBot playerBot = botInstance.playerBot;
			playerBot.enabled = true;
		}
	}

	public override void Quit()
	{
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.player);
		base.Quit();
	}

	public override void OnGameStarted()
	{
		base.OnGameStarted();
		if (PhotonNetwork.isMasterClient)
		{
			PlayerBot playerBot = botInstance.playerBot;
			playerBot.enabled = true;
		}
	}

	public override void OnBeforeGameStarted()
	{
		base.OnBeforeGameStarted();
		botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.LoadingFinished;
		botInstance.networkStatus.startAnimationFinished = true;
	}

	private void OnBotKilled(IGameMainEntity arg1, DestroyableObject.DamageInfo arg2)
	{
		Singleton<MatchManager>.instance.SetHitBy(arg2);
		mBotKilled = true;
		Singleton<GameCamera>.instance.FocusPlayer((PlayerController)arg1, arg2.owner is PlayerController);
		if (PhotonNetwork.isMasterClient)
		{
			EndMission();
		}
	}

	public override void LoadMissionData(MissionDefinition missionDefinition)
	{
		base.LoadMissionData(missionDefinition);
		if (string.IsNullOrEmpty(missionDefinition.bot.camo) || !CamosManager.instance.IsCamoIdPressent(missionDefinition.bot.camo))
		{
			mMissionDefinition.bot.camo = CamosManager.instance.RandomPlayerVisual(0).id;
		}
		if (string.IsNullOrEmpty(missionDefinition.bot.helmet) || !CamosManager.instance.IsHelmetIdPressent(missionDefinition.bot.helmet))
		{
			mMissionDefinition.bot.helmet = CamosManager.instance.RandomPlayerVisual(1).id;
		}
		if (string.IsNullOrEmpty(missionDefinition.bot.headAccesory) || !CamosManager.instance.IsHeadAccessoriesIdPressent(missionDefinition.bot.headAccesory))
		{
			mMissionDefinition.bot.headAccesory = CamosManager.instance.RandomPlayerVisual(2).id;
		}
		if (string.IsNullOrEmpty(missionDefinition.bot.powerBand) || !CamosManager.instance.IsPowerBandIdPressent(missionDefinition.bot.powerBand))
		{
			mMissionDefinition.bot.powerBand = CamosManager.instance.RandomPlayerVisual(3).id;
		}
		mMissionDefinition.bot.botVisuals = new string[4]
		{
			mMissionDefinition.bot.camo,
			mMissionDefinition.bot.helmet,
			mMissionDefinition.bot.headAccesory,
			mMissionDefinition.bot.powerBand
		};
		if (string.IsNullOrEmpty(missionDefinition.bot.name))
		{
			mMissionDefinition.bot.name = Localization.Localize("ID_ENEMYPLAYER");
		}
		generatedArmies = GetBehaviourLevels(missionDefinition);
	}

	public override void PlayMission(bool isMaster)
	{
		base.PlayMission(isMaster);
		mBotKilled = false;
		InitBot(isMaster);
	}

	public override void OpenMission(DatabasePlayer player, bool isInvite, bool isRematch, bool isHeroicMode)
	{
		base.OpenMission(player, isInvite, isRematch, isHeroicMode);
		if (Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCampaignBot)
		{
			Singleton<DogTagManager>.instance.UseDogTagLocaly();
		}
		CreateBotInstance();
		if (isInvite)
		{
			Singleton<GameController>.instance.StartHostMultiplayer();
		}
		else if (isRematch)
		{
			botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.Rematch;
		}
		else if (Singleton<GameController>.instance.isCampaignBot)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
		}
		PlayerController.players[10] = botInstance;
	}

	public override void EndMission()
	{
		if (!mIsMissionPlaying)
		{
			Debug.LogError("Ending mission when not playing this mission");
			return;
		}
		if (mBotKilled)
		{
			MissionSuccess();
		}
		else
		{
			MissionFail();
		}
		if (botInstance != null)
		{
			botInstance.Killed -= OnBotKilled;
			botInstance = null;
		}
		base.EndMission();
	}

	public override string GetMissionObjective()
	{
		return mMissionDefinition.bot.name;
	}

	public override List<MissionDialog.MissionEnemiesData> GetEnemiesInMission()
	{
		List<MissionDialog.MissionEnemiesData> enemiesInMission = base.GetEnemiesInMission();
		enemiesInMission.Add(new MissionDialog.MissionEnemiesData
		{
			botVisuals = mMissionDefinition.bot.botVisuals,
			iconName = string.Empty,
			unitLevel = mMissionDefinition.bot.level,
			unitType = MissionDialog.MissionEnemiesData.UnitType.Bot
		});
		enemiesInMission.Sort((MissionDialog.MissionEnemiesData data1, MissionDialog.MissionEnemiesData data2) => data1.CompareTo(data2));
		return enemiesInMission;
	}
}
