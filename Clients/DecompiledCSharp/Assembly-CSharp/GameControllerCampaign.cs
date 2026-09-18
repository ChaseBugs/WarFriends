using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameControllerCampaign : IGameController
{
	protected PlayerController mMainPlayerController => Singleton<GameController>.instance.mainPlayerController;

	public override bool dropCreates => !LevelManager.isNoob;

	public override float time
	{
		get
		{
			return MissionsManager.instance.currentMission.remainingTime;
		}
		set
		{
		}
	}

	public override List<Card> cardsForGame
	{
		get
		{
			return Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame;
		}
		set
		{
			Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame = value;
		}
	}

	public GameController mMainController
	{
		get
		{
			return Singleton<GameController>.instance;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public override bool gameIsRunning
	{
		get
		{
			return mMainController.gameIsRunning;
		}
		set
		{
			mMainController.gameIsRunning = value;
		}
	}

	public override bool canShowPause => true;

	public override bool canDeployUnits => MissionsManager.instance.currentMission is BotMission;

	public bool shouldLooseDogtagWhenQuit => false;

	public override string quitText => string.Empty;

	public override bool pauseCountDown => false;

	private Dictionary<string, UnitUpgradeDefinition> mUpgradedSlotsDic { get; set; }

	public override List<UnitUpgradeDefinition> opponentUpgrades
	{
		get
		{
			List<UnitUpgradeDefinition> upgrades = MissionsManager.instance.currentMission.GetUpgrades();
			mUpgradedSlotsDic = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				mUpgradedSlotsDic[levelBehaviour.GetType().ToString()] = upgrades[i];
			}
			return upgrades;
		}
	}

	public override IEnumerator StartGame()
	{
		PlayerController.players.Clear();
		PhotonNetwork.offlineMode = true;
		MapDefinition.DefendPosition p = null;
		foreach (MapDefinition.DefendPosition point in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			if (point.mainPosition && point.fraction == Fractions.Allies)
			{
				p = point;
			}
			point.point.shield.player = null;
		}
		if (p != null)
		{
			mMainPlayerController.MoveTo(p.point.transform.position, p.point.transform.rotation);
			mMainPlayerController.fraction = Fractions.Allies;
			mMainPlayerController.currentPlayerPoint = p;
			PlayerController.currentPlayer = mMainPlayerController;
			PlayerController.players[0] = mMainPlayerController;
			mMainPlayerController.playerNetworkId = 0;
			mMainPlayerController.InitPlayer();
		}
		else
		{
			Debug.LogError("No main position was set in map definition");
		}
		MissionsManager.instance.PlayCurrentMission();
		Singleton<MapManager>.instance.currentMapDef.InitShields();
		yield return new WaitForSeconds(0.2f);
		LoadingDialog.Hide();
		Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
		if (mMainController.isCoopBot || mMainController.isCampaignBot)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
			yield return StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
			yield return new WaitForSeconds(0.2f);
		}
		else
		{
			yield return StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(2f));
			yield return new WaitForSeconds(0.8f);
		}
	}

	public override void FinishGame()
	{
		if (mMainController.isCampaign)
		{
			TimeManager.instance.EndMission();
		}
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = false;
		mMainController.FinishGame();
	}

	public override void LoadingStarted()
	{
		PhotonConnectionManager.JoinOfflineGame();
		mMainPlayerController.playerProperties = PlayerProperties.CreateForLocalPlayer();
		Singleton<GameController>.instance.battleId = GameLoginManager.currentPlayer.id + "-" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		MissionsManager.instance.currentMission.LoadingStarted();
		Singleton<BeanstalkServerManager>.instance.GameStartedCampaign();
		LoadingDialog.SetLook(smallLook: false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
	}

	public override void StopGame(bool switchScreen = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(switchScreen);
	}

	public override void FreeLevel()
	{
	}

	public override IEnumerator AquireLevelName()
	{
		yield break;
	}

	public virtual IEnumerator WaitForServerResponse()
	{
		yield break;
	}

	public override void Quit()
	{
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
		MissionsManager.instance.QuitCurrentMission();
	}

	public void PausematchMaking(bool pause)
	{
	}

	public override void Forfeit()
	{
		mMainController.gameEndReason = GameController.GameEndReason.Forfeit;
		MissionsManager.instance.currentMission.EndMission();
	}

	public override void PauseGame(bool focusLost)
	{
		if (gameIsRunning)
		{
			TimeManager.Pause(focusLost);
		}
	}

	public override void FinishChoosingCards()
	{
		GuiScreenSingle<CardSelectionScreen>.instance.SetCardsForGame();
		PlayerController.currentPlayer.playerProperties.chosenCards = CardManager.instance.selectedCards;
		PlayerController.currentPlayer.playerProperties.buddyCards = CardManager.instance.selectedBuddyCards;
		Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
	}

	public override void Rematch()
	{
	}

	public override void ResumeGame()
	{
		TimeManager.Resume();
	}

	public override void UnPauseGame()
	{
	}

	public override void GetTimeProgressText(StringBuilder text)
	{
		MiscTools.PrintableTimeTwoDigits(ref text, MissionsManager.instance.time);
	}

	protected override Dictionary<string, UnitUpgradeDefinition> GetUpgradesDictionary(Fractions fraction)
	{
		if (fraction == PlayerController.currentPlayer.fraction)
		{
			return PlayerController.currentPlayer.playerProperties.upgradesDictionary;
		}
		return mUpgradedSlotsDic;
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool isPreview, AIObject o)
	{
		LevelBehaviour behaviour = o.behaviour;
		Fractions fraction = o.fraction;
		UpgradeSlots.UnitUpgrades unitUpgrades = base.PickUpgradesForUnit(isPreview, o);
		unitUpgrades = MissionsManager.ScaleUpgradesForMission(fraction, behaviour, unitUpgrades);
		behaviour.behaviourDefinition.ScaleDamageAndHP(unitUpgrades.scaleDamage, unitUpgrades.scaleHp);
		return unitUpgrades;
	}
}
