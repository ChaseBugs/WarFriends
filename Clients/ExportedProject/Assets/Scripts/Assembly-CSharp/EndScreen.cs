using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : GuiScreenSingle<EndScreen>
{
	public enum Tab
	{
		Results,
		Assignments,
		Enemy,
		WarCards,
		Ribbons,
		None
	}

	[Header("Left Content")]
	public GameObject leftButtonsParent;

	public List<EndScreenButton> leftButtons;

	[Header("Center Content")]
	public List<GameObject> tabContents;

	public ResultsContent results;

	public ResultsCampaignContent resultCampaign;

	public AssignmentsContent assignments;

	public EnemyContent enemy;

	public CardsContent cards;

	public RibbonsContent ribbons;

	[Header("Bottom Content")]
	public ButtonsContent buttonsContent;

	[Header("Card Animations")]
	public GameObject placeForCardAnimation;

	public GainedCardsAnimation cardsAnimation;

	[Header("Debug")]
	public GameObject debugPart;

	public UIButton startUnitUpgrade;

	public UIButton startWeaponUpgrade;

	[HideInInspector]
	public float timeToShowNextAnimation = 0.8f;

	[HideInInspector]
	public List<LootboxContent> videoRewardLootbox;

	[HideInInspector]
	public bool shouldGetLootboxForAd;

	[HideInInspector]
	public bool isEndScreenLootboxAnimations;

	[HideInInspector]
	public bool isEnteredBeginnersLeague;

	[HideInInspector]
	public bool pausedShowDialogs;

	private Tab mActiveTab;

	private List<bool> mAnimationPlayed = new List<bool>();

	private TweenAnimator mAnimator;

	private Vector3 mButtonStartPos = new Vector3(-400f, 0f, 0f);

	private Vector3 mButtonMiddlePos = new Vector3(100f, 0f, 0f);

	private Vector3 mButtonEndPos = new Vector3(0f, 0f, 0f);

	private float mLeftButtonDistance = 156f;

	private bool mGameControllerQuit;

	public bool isSinglePlayer => Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isMission;

	public bool canShowLvlUp => (isSinglePlayer && resultCampaign.showLevelUp) || (!isSinglePlayer && results.showLevelUp);

	public bool buttonsEnabled => !canShowLvlUp && !cardsAnimation.gameObject.activeSelf;

	public override bool dialogsEnabled => base.dialogsEnabled && !pausedShowDialogs;

	public void TestReplay()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		mAnimator.FinishTweens();
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		InitGUIValues();
		mAnimator.PlayTweens();
	}

	public void TestReplayWithAddingLevel()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		mAnimator.FinishTweens();
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		LevelManager.instance.DebugAddLevel();
		InitGUIValues();
		mAnimator.PlayTweens();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		results.leagueArc.InitEvents();
	}

	protected override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(leftButtons[0].gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ResultsButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(leftButtons[1].gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AssignmentsButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(leftButtons[2].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EnemyButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(leftButtons[3].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CardsButtonClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(leftButtons[4].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(RibbonsButtonClick));
		results.InitControls();
		resultCampaign.InitControls();
		assignments.InitControls();
		enemy.InitControls();
		cards.InitControls();
		ribbons.InitControls();
		cardsAnimation.InitControls();
		buttonsContent.InitControls();
		mAnimationPlayed.Add(item: false);
		mAnimationPlayed.Add(item: false);
		mAnimationPlayed.Add(item: false);
		mAnimationPlayed.Add(item: false);
		mAnimationPlayed.Add(item: false);
		bool isiPadResolution = Singleton<GameVariables>.instance.isiPadResolution;
		float num = 0f;
		float num2 = (mLeftButtonDistance = ((!isiPadResolution) ? 134f : 156f));
		for (int i = 0; i < leftButtons.Count; i++)
		{
			leftButtons[i].SetButtonHeight(!isiPadResolution);
			leftButtons[i].transform.localPosition = leftButtons[i].transform.localPosition.ReplaceY(num);
			num += num2;
		}
		leftButtonsParent.transform.localPosition = leftButtonsParent.transform.localPosition.ReplaceY((!isiPadResolution) ? 392f : 305f);
		DebugSettings.instance.Changed += SetDebugButtons;
	}

	private void ResultsButtonClick(GameObject go)
	{
		if (!cardsAnimation.gameObject.activeSelf && mActiveTab != Tab.Results)
		{
			FinishTabAnimator(mActiveTab);
			SetActiveTab(Tab.Results);
		}
	}

	private void AssignmentsButtonClick(GameObject go)
	{
		if (!cardsAnimation.gameObject.activeSelf && mActiveTab != Tab.Assignments)
		{
			FinishTabAnimator(mActiveTab);
			SetActiveTab(Tab.Assignments);
			assignments.UpdateAssignments();
			if (!mAnimationPlayed[1])
			{
				StartCoroutine(PlayTabAnimator(assignments.Animator, 0.3f));
				mAnimationPlayed[1] = true;
			}
		}
	}

	private void EnemyButtonClick(GameObject go)
	{
		if (!cardsAnimation.gameObject.activeSelf && mActiveTab != Tab.Enemy)
		{
			FinishTabAnimator(mActiveTab);
			enemy.SetCardsAvailable();
			SetActiveTab(Tab.Enemy);
			if (!mAnimationPlayed[2])
			{
				StartCoroutine(PlayTabAnimator(enemy.Animator));
				mAnimationPlayed[2] = true;
			}
		}
	}

	private void CardsButtonClick(GameObject go)
	{
		if (!cardsAnimation.gameObject.activeSelf && mActiveTab != Tab.WarCards)
		{
			FinishTabAnimator(mActiveTab);
			cards.SetCardsAvailable();
			SetActiveTab(Tab.WarCards);
			cards.panelCards.ResetPosition();
			if (!mAnimationPlayed[3])
			{
				StartCoroutine(PlayTabAnimator(cards.Animator));
				mAnimationPlayed[3] = true;
			}
		}
	}

	private void RibbonsButtonClick(GameObject go)
	{
		if (!cardsAnimation.gameObject.activeSelf && mActiveTab != Tab.Ribbons)
		{
			FinishTabAnimator(mActiveTab);
			SetActiveTab(Tab.Ribbons);
			ribbons.panelRibbons.AlignToPos(instant: true);
			if (!mAnimationPlayed[4])
			{
				StartCoroutine(PlayTabAnimator(ribbons.Animator, 0f));
				mAnimationPlayed[4] = true;
			}
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		pausedShowDialogs = true;
		ResetAllAnimators();
		foreach (EndScreenButton leftButton in leftButtons)
		{
			leftButton.InitializedToOffscreen();
		}
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		mGameControllerQuit = true;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		isEndScreenLootboxAnimations = true;
		shouldGetLootboxForAd = false;
		mAnimator.PlayTweens();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		FinishTabAnimator(mActiveTab);
		LevelManager.instance.isLevelUp = false;
		LeagueArcManager.instance.LeftEndScreen();
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		Singleton<MessageManager>.instance.StopMessageCoroutine();
		if (mGameControllerQuit)
		{
			Singleton<GameController>.instance.Quit();
		}
		if (Singleton<GuiManager>.instance.toBeShowedUp != null)
		{
			Singleton<GuiManager>.instance.toBeShowedUp.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		assignments.DoAfterHide();
		enemy.DoAfterHide();
		cards.DoAfterHide();
		ribbons.DoAfterHide();
		Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		Singleton<Recording>.instance.CancelRecording();
		videoRewardLootbox = null;
		isEnteredBeginnersLeague = false;
	}

	public void ContinueButtonClick(Tab activeTab)
	{
		if (buttonsEnabled)
		{
			if (Singleton<GameController>.instance.isWarArena)
			{
				GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.EndArena;
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	public void NextButtonClick(Tab activeTab)
	{
		if (!buttonsEnabled)
		{
			return;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.isTutorialWeapon)
				{
					GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponLevelsSetup);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		}
		else if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.isTutorialUnit)
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(behaviour);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		}
		else if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			TutorialManagerStage3.instance.FinishMenuTutorial();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (LevelManager.instance.isWarpathLocked)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
			GuiScreenSingle<MissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		}
	}

	public void PlayAgainButtonClick(Tab activeTab)
	{
		if (buttonsEnabled)
		{
			if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
			{
				mGameControllerQuit = false;
				Singleton<GameController>.instance.Quit();
				TutorialManagerPlayWarcards.instance.StartTutorial(isContinue: false);
			}
			else if (Singleton<GameController>.instance.isWarArena)
			{
				Singleton<GameController>.instance.Rematch();
			}
			else if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				mGameControllerQuit = false;
				Singleton<GameController>.instance.Rematch();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 0f);
			}
		}
	}

	public void ReplayButtonClick(Tab activeTab)
	{
		if (!buttonsEnabled)
		{
			return;
		}
		if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
		{
			mGameControllerQuit = false;
			if (Singleton<GameController>.instance.isCampaign)
			{
				Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
			}
			if (Singleton<GameController>.instance.isCampaignBot)
			{
				MissionsManager.instance.currentMission.OpenMission(null, isInvite: false, isRematch: false, isHeroicMode: false);
			}
			if (Singleton<GameController>.instance.isCoopBot || Singleton<GameController>.instance.isCoop)
			{
				Singleton<GameController>.instance.Rematch();
			}
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 0f);
		}
	}

	public override void InitGUIValues()
	{
		SetDebugButtons();
		videoRewardLootbox = null;
		try
		{
			ribbons.InitGuiValues();
			cards.InitGuiValues();
			assignments.InitGuiValues();
			if (isSinglePlayer)
			{
				resultCampaign.InitGuiValues();
			}
			else
			{
				enemy.InitGuiValues();
				if (!Singleton<GameController>.instance.isChallenge)
				{
					results.InitGuiValues();
				}
			}
			cardsAnimation.InitGUIValues();
			buttonsContent.InitGuiValues();
		}
		catch (Exception ex)
		{
			Debug.LogError($"END SUBSCREEN OBJECT: {base.gameObject.name}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
			if (DebugSettings.debugEnabled)
			{
				WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
			}
			Crittercism.LogHandledException(ex);
		}
		tabContents[0].SetActive(value: false);
		tabContents[1].SetActive(value: false);
		tabContents[2].SetActive(value: false);
		tabContents[3].SetActive(value: false);
		tabContents[4].SetActive(value: false);
		tabContents[5].SetActive(value: false);
		buttonsContent.gameObject.SetActive(value: false);
		AddTweensForButtons();
		InitLeftButtons();
		mActiveTab = Tab.Results;
		SetButtons();
	}

	private void SetDebugButtons()
	{
		debugPart.SetActive(DebugSettings.isOurDevice && DebugSettings.debugEnabled);
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		results.AnimateShow(fadeInTime);
		resultCampaign.AnimateShow(fadeInTime);
		assignments.AnimateShow(fadeInTime);
		enemy.AnimateShow(fadeInTime);
		cards.AnimateShow(fadeInTime);
		ribbons.AnimateShow(fadeInTime);
	}

	private void AddTweensForButtons()
	{
		float time = 0.3f;
		float num = 0f;
		Vector3 vector = mButtonStartPos;
		Vector3 vector2 = mButtonMiddlePos;
		Vector3 vector3 = mButtonEndPos;
		mAnimator.allTweens.Clear();
		if (!Singleton<GameController>.instance.isChallenge)
		{
			mAnimator.AddTween(from: vector, id: 0, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftButtons[0].gameObject, time: time, to: vector2, delay: num);
			mAnimator.AddTween(1, TweenAnimator.TweenType.Position, leftButtons[0].gameObject, time, vector3, 0f, 0);
			vector2.y -= mLeftButtonDistance;
			vector.y -= mLeftButtonDistance;
			num += 0.1f;
			vector3.y -= mLeftButtonDistance;
		}
		if (!Singleton<GameController>.instance.isTutorial)
		{
			mAnimator.AddTween(from: vector, id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftButtons[1].gameObject, time: time, to: vector2, delay: num);
			mAnimator.AddTween(3, TweenAnimator.TweenType.Position, leftButtons[1].gameObject, time, vector3, 0f, 2);
			vector2.y -= mLeftButtonDistance;
			vector.y -= mLeftButtonDistance;
			num += 0.1f;
			vector3.y -= mLeftButtonDistance;
		}
		if (!isSinglePlayer)
		{
			mAnimator.AddTween(from: vector, id: 4, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftButtons[2].gameObject, time: time, to: vector2, delay: num);
			mAnimator.AddTween(5, TweenAnimator.TweenType.Position, leftButtons[2].gameObject, time, vector3, 0f, 4);
			vector2.y -= mLeftButtonDistance;
			vector.y -= mLeftButtonDistance;
			num += 0.1f;
			vector3.y -= mLeftButtonDistance;
		}
		if (!Singleton<GameController>.instance.isTutorial && !LevelManager.instance.isWarcardsLocked && !Singleton<GameController>.instance.isChallenge)
		{
			mAnimator.AddTween(from: vector, id: 6, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftButtons[3].gameObject, time: time, to: vector2, delay: num);
			mAnimator.AddTween(7, TweenAnimator.TweenType.Position, leftButtons[3].gameObject, time, vector3, 0f, 6);
			vector2.y -= mLeftButtonDistance;
			vector.y -= mLeftButtonDistance;
			num += 0.1f;
			vector3.y -= mLeftButtonDistance;
		}
		if (!Singleton<GameController>.instance.isTutorial)
		{
			mAnimator.AddTween(from: vector, id: 8, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftButtons[4].gameObject, time: time, to: vector2, delay: num);
			mAnimator.AddTween(9, TweenAnimator.TweenType.Position, leftButtons[4].gameObject, time, vector3, 0f, 8);
		}
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Remove(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
		TweenAnimator tweenAnimator2 = mAnimator;
		tweenAnimator2.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator2.TweenFinished, new Action<int>(OnTweenFinished));
		mAnimator.GenerateTweens();
	}

	private void OnTweenFinished(int tweenId)
	{
		if ((tweenId == 9 && !Singleton<GameController>.instance.isTutorial) || (tweenId == 1 && Singleton<GameController>.instance.isTutorial))
		{
			StartCoroutine(GainedWarCardsAnimations());
		}
	}

	private IEnumerator GainedWarCardsAnimations()
	{
		yield return StartCoroutine(cardsAnimation.PlayAnimation());
		SetActiveTab(Singleton<GameController>.instance.isChallenge ? Tab.Assignments : Tab.Results);
		if (!Singleton<GameController>.instance.isTutorial)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
		if (Singleton<GameController>.instance.isChallenge)
		{
			StartCoroutine(PlayTabAnimator(assignments.Animator, 0.3f));
		}
		else if (isSinglePlayer)
		{
			resultCampaign.StartCoroutineAnimation();
		}
		else
		{
			results.StartCoroutineAnimation();
		}
	}

	private void InitLeftButtons()
	{
		for (int i = 0; i < leftButtons.Count; i++)
		{
			leftButtons[i].gameObject.SetActive(value: true);
			mAnimationPlayed[i] = false;
			leftButtons[i].InitializeLeftButton();
		}
		if (isSinglePlayer)
		{
			leftButtons[2].gameObject.SetActive(value: false);
			mAnimationPlayed[2] = true;
		}
		if (LevelManager.instance.isWarcardsLocked)
		{
			leftButtons[3].gameObject.SetActive(value: false);
			mAnimationPlayed[3] = true;
		}
		if (Singleton<GameController>.instance.isChallenge)
		{
			leftButtons[0].gameObject.SetActive(value: false);
			mAnimationPlayed[0] = true;
			leftButtons[3].gameObject.SetActive(value: false);
			mAnimationPlayed[3] = true;
		}
	}

	private void FinishTabAnimator(Tab activeTab)
	{
		switch (activeTab)
		{
		case Tab.Results:
			if (isSinglePlayer)
			{
				resultCampaign.FinishAnimation();
			}
			else
			{
				results.FinishAnimation();
			}
			break;
		case Tab.Assignments:
			assignments.FinishAnimation();
			break;
		case Tab.Enemy:
			enemy.FinishAnimation();
			break;
		case Tab.WarCards:
			cards.FinishAnimation();
			break;
		case Tab.Ribbons:
			ribbons.FinishAnimation();
			break;
		}
		CheckLevelUp();
		mAnimator.FinishTweens();
	}

	private void CheckLevelUp()
	{
		if (canShowLvlUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 0f);
			resultCampaign.showLevelUp = false;
			results.showLevelUp = false;
		}
	}

	private void ResetAllAnimators()
	{
		if (isSinglePlayer)
		{
			resultCampaign.ResetAnimation();
		}
		else
		{
			results.ResetAnimation();
		}
		if (!isSinglePlayer)
		{
			enemy.ResetAnimation();
		}
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			assignments.ResetAnimation();
		}
		if (!LevelManager.instance.isWarcardsLocked)
		{
			cards.ResetAnimation();
		}
		ribbons.ResetAnimation();
		mAnimator.ResetTweens();
	}

	protected override void Update()
	{
		base.Update();
		if (mActiveTab == Tab.Assignments && StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			assignments.Update();
		}
	}

	private IEnumerator PlayTabAnimator(List<TweenAnimator> tabAnimator, float delay = 0.5f)
	{
		foreach (TweenAnimator tweenAnimator in tabAnimator)
		{
			if (tweenAnimator.allTweens.Count > 0)
			{
				tweenAnimator.PlayTweens();
				if (delay > 0f)
				{
					yield return new WaitForSeconds(delay);
				}
			}
		}
	}

	private void SetActiveTab(Tab activeTab)
	{
		int num = (int)((activeTab != Tab.Results || !isSinglePlayer) ? activeTab : Tab.None);
		for (int i = 0; i < leftButtons.Count; i++)
		{
			if (leftButtons[i].gameObject.activeSelf)
			{
				leftButtons[i].SetButton(i == (int)activeTab);
			}
		}
		for (int j = 0; j < tabContents.Count; j++)
		{
			tabContents[j].SetActive(j == num);
		}
		buttonsContent.SetActiveAccordingToTab(activeTab);
		mActiveTab = activeTab;
	}

	private void SetButtons()
	{
		leftButtons[0].SetButton(active: false);
		if (leftButtons[1].gameObject.activeSelf)
		{
			leftButtons[1].SetButton(active: false);
		}
		if (leftButtons[2].gameObject.activeSelf)
		{
			leftButtons[2].SetButton(active: false);
		}
		if (leftButtons[3].gameObject.activeSelf)
		{
			leftButtons[3].SetButton(active: false);
		}
		if (leftButtons[4].gameObject.activeSelf)
		{
			leftButtons[4].SetButton(active: false);
		}
	}

	public override void OnBack()
	{
		if (GuiScreenSingle<EndScreen>.instance.isSinglePlayer)
		{
			NextButtonClick(Tab.WarCards);
		}
		else
		{
			ContinueButtonClick(Tab.WarCards);
		}
	}
}
