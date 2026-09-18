using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class GameControllerTutorial : IGameController
{
	private readonly List<TutorialManagerBase> tutorialStages = new List<TutorialManagerBase>();

	protected PlayerController mBotInstance;

	public bool paused;

	[HideInInspector]
	public List<Card> tutorialCards;

	private List<Card> mTutorialRewardCards;

	private bool mPausedByTut;

	protected PlayerController mMainPlayerController => Singleton<GameController>.instance.mainPlayerController;

	public override bool dropCreates => false;

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

	public string tutorialStageId
	{
		get
		{
			if (TutorialManagerStage1.instance.isTutorialRunning)
			{
				return "Stage1";
			}
			if (TutorialManagerStage2.instance.isTutorialRunning)
			{
				return "Stage2";
			}
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				return "Stage3";
			}
			return "Unknown Tutorial Stage";
		}
	}

	public override bool canShowPause => true;

	public override float time { get; set; }

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

	public override bool canDeployUnits => Singleton<GameController>.instance.isTutorialStage3;

	public override string quitText => string.Empty;

	public override bool pauseCountDown => false;

	public override void FreeLevel()
	{
		if (Singleton<GameController>.instance.isTutorialStage1)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("119 LOADING MENU");
		}
		else if (Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("211 LOADING MENU");
		}
	}

	public override IEnumerator AquireLevelName()
	{
		yield break;
	}

	public override void Quit()
	{
	}

	public void PausematchMaking(bool pause)
	{
	}

	public override IEnumerator StartGame()
	{
		yield return StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(mMainPlayerController, useBackground: true);
		PlayerController.players.Clear();
		Debug.Log("Start TUTORIAL");
		Fractions fr = Fractions.Allies;
		MapDefinition.DefendPosition defendPosition = GetMainPlayerPoint(fr);
		mMainPlayerController.fraction = fr;
		mMainPlayerController.MoveTo(defendPosition.point.transform.position, defendPosition.point.transform.rotation);
		mMainPlayerController.currentPlayerPoint = defendPosition;
		mMainPlayerController.playerProperties = PlayerProperties.CreateForLocalPlayer();
		PlayerController.currentPlayer = mMainPlayerController;
		PlayerController.players[0] = mMainPlayerController;
		mMainPlayerController.playerNetworkId = 0;
		mMainPlayerController.InitPlayer();
		mMainPlayerController.Killed -= OnPlayerControllerKilled;
		mMainPlayerController.Killed += OnPlayerControllerKilled;
		SetUpBot();
		Singleton<BotManager>.instance.PrepareBotForTutorial(mBotInstance.playerBot);
		mBotInstance.InitPlayer();
		PlayerBot bot = mBotInstance.playerBot;
		bot.enabled = true;
		CardManager.instance.ClearCardsForGame();
		if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
		{
			bool isContinue = TutorialManagerStage2.instance.isTutorialRunning;
			Debug.Log("Starting stage 3 ");
			TutorialManagerStage2.instance.FinishTutorial();
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("221 END");
			TutorialManagerStage3.instance.StartTutorial(isContinue);
			CardManager.instance.cardsForGame.Clear();
			TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
			PlayerController.currentPlayer.playerProperties.chosenCards = CardManager.instance.selectedCards;
			yield return StartCoroutine(CardManager.instance.InitGameCards(PlayerController.currentPlayer.playerProperties.chosenCards, isOpponnetCard: false, isCurrentPlayer: false));
			yield return new WaitForSeconds(2f);
			Singleton<SoundsManager3D>.instance.LoadSounds();
			yield return StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(myUpgrades));
		}
		else if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
		{
			bool isContinue2 = TutorialManagerStage1.instance.isTutorialRunning;
			Debug.Log("Starting stage 2 ");
			TutorialManagerStage1.instance.FinishTutorial();
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("128 END");
			TutorialManagerStage2.instance.StartTutorial(isContinue2);
		}
		else
		{
			Debug.Log("Starting stage 1 ");
			TutorialManagerStage1.instance.StartTutorial(isContinue: false);
		}
		yield return new WaitForSeconds(0.25f);
		LoadingDialog.Hide();
		if (Singleton<GameController>.instance.isTutorialStage1)
		{
			mMainPlayerController.weaponInventory.startGameWithIndex = 3;
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampIntro);
			yield return StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1.5f));
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
			yield return StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
			yield return new WaitForSeconds(1f);
		}
		Time.timeScale = 1f;
		time = 90f;
		paused = false;
	}

	public override void FinishGame()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.Hide();
		Singleton<MatchManager>.instance.matchTime = 90f - time;
		if (gameIsRunning)
		{
			gameIsRunning = false;
			if (mMainController.gameEndReason == GameController.GameEndReason.Forfeit)
			{
				mMainController.StartCoroutine(mMainController.RestartTutorial());
			}
			else
			{
				mMainController.FinishGame();
			}
		}
	}

	internal void AddCardsForCardsTutorial()
	{
		InitTutorialCards();
		Card card = tutorialCards[0];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = tutorialCards[1];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = tutorialCards[2];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		Debug.Log("Added WarCards for tutorial: " + card.id + ", " + card2.id + ", " + card3.id);
	}

	public void RemoveCardsForCardsTutorial()
	{
		InitTutorialCards();
		string text = "Removed WarCards for tutorial: ";
		Card card = tutorialCards[0];
		if (card.amount > 0)
		{
			card.RemoveCard();
			text = text + card.id + " ";
		}
		Card card2 = tutorialCards[1];
		if (card2.amount > 0)
		{
			card2.RemoveCard();
			text = text + card2.id + " ";
		}
		Card card3 = tutorialCards[2];
		if (card3.amount > 0)
		{
			card3.RemoveCard();
			text = text + card3.id + " ";
		}
		Debug.Log(text);
	}

	public override void LoadingStarted()
	{
		PhotonConnectionManager.JoinOfflineGame();
		PrepareBot();
		LoadingDialog.SetLook(smallLook: false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_TUTORIAL"), showCancelButton: false, hideBackgroundElements: true);
		if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
		{
			LoadingDialog.SetHeader(string.Format("{0} 3 / 3", Localization.Localize("ID_TUTORIAL")));
		}
		else if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
		{
			LoadingDialog.SetHeader(string.Format("{0} 2 / 3", Localization.Localize("ID_TUTORIAL")));
		}
		else
		{
			LoadingDialog.SetHeader(string.Format("{0} 1 / 3", Localization.Localize("ID_TUTORIAL")));
		}
	}

	public override void StopGame(bool switchScreen = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(switchScreen);
	}

	public override void Forfeit()
	{
		mMainController.gameEndReason = GameController.GameEndReason.Forfeit;
		FinishGame();
	}

	public override void PauseGame(bool focusLost)
	{
		if (gameIsRunning && !TimeManager.instance.isPaused)
		{
			if (!TimeManager.instance.mIsFreezed)
			{
				TimeManager.Pause(focusLost);
				mPausedByTut = true;
			}
			else
			{
				mPausedByTut = false;
				Singleton<GameController>.instance.OnGamePaused(TimeManager.PauseStatus.PausedLocaly);
			}
		}
	}

	public override void ResumeGame()
	{
		if (mPausedByTut)
		{
			TimeManager.Resume(1f);
		}
		else
		{
			Singleton<GameController>.instance.OnGameResumed(TimeManager.PauseStatus.PausedLocaly);
		}
	}

	public override void UnPauseGame()
	{
	}

	public override void FinishChoosingCards()
	{
	}

	public override void Rematch()
	{
	}

	public override void GetTimeProgressText(StringBuilder text)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				text.Append(Localization.Localize("ID_OVERTIME"));
			}
			else
			{
				MiscTools.PrintableTimeTwoDigits(ref text, Singleton<GameController>.instance.time);
			}
		}
	}

	public static void RestartTutorial()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	public static string GetMapName()
	{
		return "Desert";
	}

	public static void ResetTutorialProgress()
	{
		Debug.Log("reset tutorial");
		TutorialManagerStage1.instance.SaveEmpty();
		TutorialManagerStage2.instance.SaveEmpty();
		TutorialManagerStage3.instance.SaveEmpty();
		TutorialManagerStage1.instance.Load();
		TutorialManagerStage2.instance.Load();
		TutorialManagerStage3.instance.Load();
	}

	public void SkipTutorial()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent($"SKIP TUTORIAL IN {tutorialStageId.ToUpper()}");
		foreach (TutorialManagerBase tutorialStage in tutorialStages)
		{
			tutorialStage.FinishTutorial();
			tutorialStage.data.started = true;
			tutorialStage.Save();
			tutorialStage.StopAllCoroutines();
		}
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
		Singleton<GameController>.instance.gameEndReason = GameController.GameEndReason.Win;
		FinishGame();
		TutorialManagerStage1.instance.EquipTutorialWeaponAfterSkipTutorial();
		TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
		LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: false);
		Singleton<TutorialProgressShower>.instance.Disable();
		GuiElementSingle<InventoryGuiElement>.instance.Show();
		StartCoroutine(WaitForMenuAndCallServer());
	}

	private IEnumerator WaitForMenuAndCallServer()
	{
		while (Singleton<GameController>.instance.gameState != GameController.GameState.Menu)
		{
			yield return null;
		}
		yield return new WaitForSeconds(3f);
		TutorialManagerStage3.instance.FinishMenuTutorial();
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
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		Debug.LogError("No main position was set in map definition");
		return null;
	}

	protected void SetUpBot()
	{
		Fractions fraction = Fractions.Enemies;
		MapDefinition.DefendPosition mainPlayerPoint = GetMainPlayerPoint(fraction);
		mBotInstance.transform.position = mainPlayerPoint.point.transform.position;
		mBotInstance.transform.rotation = mainPlayerPoint.point.transform.rotation;
		mBotInstance.fraction = fraction;
		mBotInstance.currentPlayerPoint = mainPlayerPoint;
		PlayerController.players[10] = mBotInstance;
		mBotInstance.playerNetworkId = 10;
		mBotInstance.Killed -= OnBotKilled;
		mBotInstance.Killed += OnBotKilled;
		PlayerBot playerBot = mBotInstance.playerBot;
		playerBot.enabled = true;
	}

	private void PrepareBot()
	{
		mBotInstance = (PlayerController)ObjectPoolDatabase.networkPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.player);
		mBotInstance.fraction = Fractions.Enemies;
		Singleton<GameController>.instance.opponent = mBotInstance;
		PlayerBot playerBot = mBotInstance.playerBot;
		Singleton<BotManager>.instance.PrepareBotForTutorial(playerBot);
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(mBotInstance, useBackground: true);
		playerBot.enabled = true;
	}

	private void OnBotKilled(IGameMainEntity arg1, DestroyableObject.DamageInfo arg2)
	{
		mBotInstance.Killed -= OnBotKilled;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(arg2);
			mMainController.gameEndReason = GameController.GameEndReason.Win;
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)arg1, arg2.owner is PlayerController);
			FinishGame();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		PlayerController.currentPlayer = mMainPlayerController;
		tutorialStages.Add(TutorialManagerStage1.instance);
		tutorialStages.Add(TutorialManagerStage2.instance);
		tutorialStages.Add(TutorialManagerStage3.instance);
	}

	private void OnPlayerControllerKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		mMainPlayerController.Killed -= OnPlayerControllerKilled;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(arg3);
			if (gameIsRunning)
			{
				PlayerController playerController = (PlayerController)gameMainEntity;
				mMainController.gameEndReason = (playerController.isCurrentPlayer ? GameController.GameEndReason.Killed : GameController.GameEndReason.Win);
				FinishGame();
			}
		}
	}

	protected void Update()
	{
		if (Singleton<GameController>.instance.mainController == this && gameIsRunning && !paused)
		{
			time -= Time.deltaTime;
		}
	}

	public void InitTutorialCards()
	{
		tutorialCards = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				tutorialCards.Add(CardManager.instance.GetCardInstance(item));
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Exception when creating cards for tutorial - creating default instead, msg = " + ex);
			Crittercism.LogHandledException(ex);
			tutorialCards.Add(CardManager.instance.GetCardInstance("ROCKETTURRET"));
			tutorialCards.Add(CardManager.instance.GetCardInstance("ELITESWAT"));
			tutorialCards.Add(CardManager.instance.GetCardInstance("CLUSTERGRENADE"));
		}
	}

	public void AddWarcardsForFinishingPlayWarcardsTutorial()
	{
		mTutorialRewardCards = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialRewardCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item7 in list)
			{
				Card item = CardManager.instance.AddCard(item7);
				CardManager.instance.obtainedCards.Add(item);
				mTutorialRewardCards.Add(item);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Exception when adding warcards reward for tutorial - adding default instead, msg = " + ex);
			Crittercism.LogHandledException(ex);
			Card item2 = CardManager.instance.AddCard("CLUSTERGRENADE");
			CardManager.instance.obtainedCards.Add(item2);
			mTutorialRewardCards.Add(item2);
			Card item3 = CardManager.instance.AddCard("ELITEPARA");
			CardManager.instance.obtainedCards.Add(item3);
			mTutorialRewardCards.Add(item3);
			Card item4 = CardManager.instance.AddCard("HEAVYTURRET");
			CardManager.instance.obtainedCards.Add(item4);
			mTutorialRewardCards.Add(item4);
			Card item5 = CardManager.instance.AddCard("ELECTRICTRAPS");
			CardManager.instance.obtainedCards.Add(item5);
			mTutorialRewardCards.Add(item5);
			Card item6 = CardManager.instance.AddCard("SABOTAGE");
			CardManager.instance.obtainedCards.Add(item6);
			mTutorialRewardCards.Add(item6);
		}
	}

	public string SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial()
	{
		List<Card> list = new List<Card>();
		if (!CardManager.instance.cardUsedByMe.Contains(tutorialCards[0]))
		{
			list.Add(tutorialCards[0]);
		}
		if (!CardManager.instance.cardUsedByMe.Contains(tutorialCards[1]))
		{
			list.Add(tutorialCards[1]);
		}
		if (!CardManager.instance.cardUsedByMe.Contains(tutorialCards[2]))
		{
			list.Add(tutorialCards[2]);
		}
		for (int i = 0; i < mTutorialRewardCards.Count; i++)
		{
			list.Add(mTutorialRewardCards[i]);
		}
		string[] array = new string[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			array[j] = list[j].id;
		}
		return JsonConvert.SerializeObject(array);
	}
}
