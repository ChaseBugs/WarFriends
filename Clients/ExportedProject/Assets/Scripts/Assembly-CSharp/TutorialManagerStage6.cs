using System;
using System.Collections;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class TutorialManagerStage6 : TutorialManagerBase
{
	private const int mTillMatches = 1;

	private static TutorialManagerStage6 mInstance;

	private bool mChangingScreen;

	private bool mInMenu;

	public static TutorialManagerStage6 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage6>();
			return mInstance;
		}
	}

	private bool isAnyElementShown => GuiElementSingle<LoadingDialog>.instance.isShowed || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			Debug.Log("Tutorial Manager 6: Battles played: " + StatsManager.instance.battlesPlayed + " tutorial running: " + Singleton<GameController>.instance.isTutorial);
			if (!Singleton<GameController>.instance.isTutorial && StatsManager.instance.battlesPlayed < 1)
			{
				RunTutorial();
			}
		};
	}

	public void RunTutorial()
	{
		if (!base.isTutorialRunning)
		{
			StopAllCoroutines();
			StartCoroutine(RadicalRoutine.Run(GuidePlayerToMatch()));
			Debug.Log("Tutorial Manager 6: Starting Tutorial - Guide player to match");
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	private void CleanUpAfterTutorial()
	{
		data.started = true;
		Save();
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
	}

	public IEnumerator GuidePlayerToMatch()
	{
		StartTutorial(isContinue: false);
		GuiScreen.ChangingScreen = (Action)Delegate.Remove(GuiScreen.ChangingScreen, new Action(OnChangingScreen));
		GuiScreen.ChangingScreen = (Action)Delegate.Combine(GuiScreen.ChangingScreen, new Action(OnChangingScreen));
		GuiElement.ShowingDialog = (Action)Delegate.Remove(GuiElement.ShowingDialog, new Action(OnShowingDialog));
		GuiElement.ShowingDialog = (Action)Delegate.Combine(GuiElement.ShowingDialog, new Action(OnShowingDialog));
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Remove(GuiElement.HidingDialog, new Action<GuiElement>(OnHidingDialog));
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Combine(GuiElement.HidingDialog, new Action<GuiElement>(OnHidingDialog));
		GuiElementSingle<ChatGuiElement>.instance.ChangingState -= OnChangingState;
		GuiElementSingle<ChatGuiElement>.instance.ChangingState += OnChangingState;
		StartAnimations();
		while (StatsManager.instance.battlesPlayed < 1)
		{
			if (Singleton<GameController>.instance.isTutorial)
			{
				if (mInMenu)
				{
					mInMenu = false;
					StopAnimations();
				}
				yield return new WaitForRealSeconds(1f);
				continue;
			}
			if (Singleton<GameController>.instance.gameState != GameController.GameState.Menu)
			{
				if (mInMenu)
				{
					mInMenu = false;
					StopAnimations();
				}
				yield return new WaitForRealSeconds(0.5f);
				continue;
			}
			if (!mInMenu)
			{
				StartAnimations();
			}
			if (mChangingScreen)
			{
				mChangingScreen = false;
				StopAnimations();
				yield return new WaitForSeconds(Singleton<GuiManager>.instance.currentScreen.fadeInTime);
				StartAnimations();
			}
			else
			{
				yield return null;
			}
		}
		if (mInMenu)
		{
			mInMenu = false;
			StopAnimations();
		}
		yield return new WaitForRealSeconds(0.5f);
		GuiScreen.ChangingScreen = (Action)Delegate.Remove(GuiScreen.ChangingScreen, new Action(OnChangingScreen));
		GuiElement.ShowingDialog = (Action)Delegate.Remove(GuiElement.ShowingDialog, new Action(OnShowingDialog));
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Remove(GuiElement.HidingDialog, new Action<GuiElement>(OnHidingDialog));
		GuiElementSingle<ChatGuiElement>.instance.ChangingState -= OnChangingState;
		yield return new WaitForSeconds(2.8f);
		CleanUpAfterTutorial();
		FinishTutorial();
	}

	private void OnChangingScreen()
	{
		mChangingScreen = true;
	}

	private void OnShowingDialog()
	{
		if (mInMenu)
		{
			StopAnimations();
		}
	}

	private void OnHidingDialog(GuiElement dialog)
	{
		if (mInMenu)
		{
			StartAnimations(specialCondition: true);
		}
	}

	private void OnChangingState()
	{
		if (mInMenu && Singleton<GuiManager>.instance.currentScreen != null && Singleton<GuiManager>.instance.currentScreen.isFullyShowed)
		{
			if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
			{
				StopAnimations();
			}
			else
			{
				StartAnimations();
			}
		}
	}

	private void StopAnimations()
	{
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopGoToBattle();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
	}

	private void StartAnimations(bool specialCondition = false)
	{
		mChangingScreen = false;
		mInMenu = Singleton<GameController>.instance.gameState == GameController.GameState.Menu;
		if (specialCondition)
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed || DialogManager.instance.numberOfShownDialogues > 1)
			{
				return;
			}
		}
		else if (isAnyElementShown)
		{
			return;
		}
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<MainScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartGoToBattle(GuiScreenSingle<MainScreen>.instance.positionForTutorialText.transform.position);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.positionForTutorialHand.transform.position);
		}
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<BattlePreparationScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartGoToBattle(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.positionForTutorialText.transform.position);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.positionForTutorialHand.transform.position);
		}
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardSelectionScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<CardSelectionScreen>.instance.positionForTutorialHand.transform.position);
		}
	}
}
