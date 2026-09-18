using System.Collections;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class TutorialManagerPlayWarcards : TutorialManagerBase
{
	public const string id = "PlayWarcards";

	private static TutorialManagerPlayWarcards mInstance;

	public CardsGuiElementNew cardGUI;

	private bool mGameStarted;

	public static TutorialManagerPlayWarcards instance
	{
		get
		{
			mInstance = mInstance ?? Object.FindObjectOfType<TutorialManagerPlayWarcards>();
			return mInstance;
		}
	}

	public bool shouldStartTutorial => PlayerAnalytics.instance.data.cardTutState == 1 && !LevelManager.instance.isWarcardsLocked;

	public bool fightPressed { get; set; }

	public override bool autoDeployEnabled => true;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		AIObject.AfterSpawned += AfterSpawned;
	}

	public override void FinishTutorial()
	{
		base.FinishTutorial();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
	}

	private void OnGameStarted()
	{
		if (base.isTutorialRunning)
		{
			mGameStarted = true;
		}
	}

	private void OnGameEnded(GameController.GameEndReason obj)
	{
		if (base.isTutorialRunning)
		{
			if (obj != GameController.GameEndReason.Forfeit)
			{
				Debug.Log(string.Concat("#VAVRO# IT WAS ", obj, " IN TUTORIAL"));
				PlayerAnalytics.instance.data.cardTutState = 2;
			}
			else
			{
				Singleton<GameController>.instance.gameControllerTutorial.RemoveCardsForCardsTutorial();
				Debug.LogError("IT WAS FORFEIT IN TUTORIAL");
			}
			Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded("604 GAME END");
			Singleton<AtlasPreparer>.instance.UnloadTutorial();
			StopAllCoroutines();
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			Debug.Log("*****   Bootcamp Play warcards Ended   *****");
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		data.started = true;
		Save();
		base.StartTutorial(isContinue);
		Singleton<GameController>.instance.SwitchToDeathMatch();
		Singleton<GameController>.instance.gameControllerDeathMatch.StartTutorialMatch();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		StartCoroutine(RadicalRoutine.Run(Tutorial()));
	}

	private IEnumerator Tutorial()
	{
		yield return StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
		Singleton<GameController>.instance.gameControllerTutorial.AddCardsForCardsTutorial();
		GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
		yield return StartCoroutine(RadicalRoutine.Run(CardSelection()));
		yield return StartCoroutine(RadicalRoutine.Run(Welcome()));
	}

	private IEnumerator Welcome()
	{
		mGameStarted = false;
		yield return new WaitForEndOfFrame();
		Debug.Log("*****   Bootcamp Play WarCards Started   *****");
		while (!mGameStarted)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("603 GAME STARTED");
		PlayerController.currentPlayer.tutorialImmortality = true;
		while (!Singleton<GameController>.instance.gameIsRunning)
		{
			yield return null;
		}
		yield return new WaitForSeconds(2.5f);
		StartCoroutine(RadicalRoutine.Run(GameCardTutorial()));
	}

	private IEnumerator GameCardTutorial()
	{
		int startCount = CardManager.instance.cardsForGame.Count;
		float cardTutStartTime = Time.time + 30f;
		PlayerController enemyPlayer = PlayerController.GetEnemyOf(Fractions.Allies);
		while (Time.time < cardTutStartTime)
		{
			if (CardManager.instance.cardsForGame.Count != 3)
			{
				enemyPlayer.tutorialImmortality = false;
			}
			yield return null;
		}
		enemyPlayer.tutorialImmortality = false;
		bool cardTutorialPlayed = false;
		int cardTutorialTime = 0;
		if (CardManager.instance.cardsForGame.Count == startCount)
		{
			cardTutorialPlayed = true;
			cardTutorialTime = (int)TimeManager.realTimeWithoutPauses;
			TimeManager.FreezeGame();
			PlayerController.currentPlayer.canSendUnits = false;
			PlayerController.currentPlayer.updateWeapons = false;
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_PLAY_CARD_UP", "ID_TUTORIAL_PLAY_CARD_DOWN", 0.2f);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(cardGUI.GetFirstCardPosition(), new Vector3(0f, 50f, 0f));
			while (startCount == CardManager.instance.cardsForGame.Count)
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(cardGUI.GetFirstCardPosition(), new Vector3(0f, 50f, 0f));
				yield return null;
			}
			cardTutorialTime = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - cardTutorialTime);
			TimeManager.UnFreezeGame(0f);
			PlayerController.currentPlayer.canSendUnits = true;
			PlayerController.currentPlayer.updateWeapons = true;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("635 STAGE 10 PLAY CARD", cardTutorialPlayed, cardTutorialTime);
	}

	private IEnumerator CardSelection()
	{
		UIDraggablePanel.panelDisabled = true;
		fightPressed = false;
		Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
		GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
		yield return new WaitForSeconds(0.4f);
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorialDirectly(Localization.Localize("ID_TUTORIAL_WARCARDS_STARTUP"), Localization.Localize("ID_TUTORIAL_WARCARDS_STARTDOWN"), 0f, TutorialDialog.DialogPosition.Center, showContinue: true, useCollider: true);
		yield return new WaitForSeconds(0.4f);
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.Hide();
		while (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.1f);
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("601 TUTORIAL STARTED");
		yield return StartCoroutine(RadicalRoutine.Run(CheckCards()));
		yield return new WaitForSeconds(0.5f);
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("602 LOADING MAP");
		UIDraggablePanel.panelDisabled = false;
		fightPressed = false;
	}

	private IEnumerator CheckCards()
	{
		while (!fightPressed)
		{
			int filledContainers = 0;
			foreach (CardContainer container in GuiScreenSingle<CardSelectionScreen>.instance.containers)
			{
				if (container.isAvailable && !container.isEmpty)
				{
					filledContainers++;
				}
			}
			if (filledContainers < 3)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_NEWDRAGCARD", -0.7f, TutorialDialog.DialogPosition.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(AvailableCardRecord().position, AvailableCardContainer().position, 0.6f);
			}
			while (filledContainers < 3)
			{
				filledContainers = 0;
				foreach (CardContainer container2 in GuiScreenSingle<CardSelectionScreen>.instance.containers)
				{
					if (container2.isAvailable && !container2.isEmpty)
					{
						filledContainers++;
					}
				}
				Transform cardRec = AvailableCardRecord();
				if (cardRec != null && filledContainers < 3)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(cardRec.position, AvailableCardContainer().position);
				}
				if (!GuiElementSingle<TutorialDialog>.instance.isShowed)
				{
					break;
				}
				yield return null;
			}
			if (filledContainers > 2)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.EnableFightButton();
			}
			if (GuiElementSingle<TutorialDialog>.instance.isShowed)
			{
				GuiElementSingle<TutorialDialog>.instance.Hide();
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
			while (!GuiElementSingle<TutorialDialog>.instance.isShowed && DialogManager.instance.isSomeDialogShowed)
			{
				yield return null;
			}
			yield return null;
		}
	}

	private Transform AvailableCardContainer()
	{
		foreach (CardContainer container in GuiScreenSingle<CardSelectionScreen>.instance.containers)
		{
			if (container.isAvailable && container.isEmpty)
			{
				return container.transform;
			}
		}
		return null;
	}

	private Transform AvailableCardRecord()
	{
		foreach (CardRecord value in GuiScreenSingle<CardSelectionScreen>.instance.instantiatedCards.Values)
		{
			if (value.isAvailable)
			{
				return value.transform;
			}
		}
		return null;
	}
}
