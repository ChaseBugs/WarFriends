using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : GuiElementSingle<PauseScreen>, IGuiDialog
{
	[Header("Header")]
	public UILabel title;

	public GameObject heroicPart;

	public UISprite heroicSingle;

	public UISprite[] heroicCoop;

	[Header("Content")]
	public GameObject missionNumberPart;

	public UILabel missionNumber;

	public UILabel objectiveLabel;

	public List<AssignmentPauseRecord> assignments;

	[Header("Buttons")]
	public UIButton forfeitButton;

	public UILabel forfeitLabel;

	public UIButton continueButton;

	public UILabel continueLabel;

	[Header("Debug")]
	public UIButton skipTutorialButton;

	private bool mDoNotUpdate;

	private float mTimer;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(forfeitButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ForfeitClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(continueButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ContinueClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(skipTutorialButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SkipTutorialClick));
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	public override void InitGUIValues()
	{
		mDoNotUpdate = false;
		bool flag = TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocalyFocusLost || Singleton<GameController>.instance.isTutorial;
		bool flag2 = Singleton<GameController>.instance.isMission && MissionsManager.instance.currentMission.playingInHeroicMode;
		title.text = Localization.Localize(flag ? "ID_GAMEPAUSED" : ((!Singleton<GameController>.instance.isMission) ? "ID_OPPONENTPAUSED" : "ID_FRIENDPAUSED"));
		heroicPart.SetActive(flag2);
		if (flag2)
		{
			bool flag3 = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
			heroicSingle.gameObject.SetActive(!flag3);
			for (int i = 0; i < heroicCoop.Length; i++)
			{
				heroicCoop[i].gameObject.SetActive(flag3);
			}
		}
		missionNumberPart.SetActive(Singleton<GameController>.instance.isMission);
		if (missionNumberPart.activeSelf)
		{
			missionNumber.text = MissionsManager.instance.currentMission.number.ToString();
		}
		if (Singleton<GameController>.instance.isMission)
		{
			objectiveLabel.text = MissionsManager.instance.currentMission.missionObjectiveProgress;
		}
		else if (Singleton<GameController>.instance.isTutorial || TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			objectiveLabel.text = Localization.Localize("ID_TUTORIAL_OBJECTIVE");
		}
		else
		{
			objectiveLabel.text = Localization.Localize("ID_NORMAL_OBJECTIVE");
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			for (int j = 0; j < assignments.Count; j++)
			{
				assignments[j].gameObject.SetActive(value: false);
			}
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			for (int k = 0; k < assignments.Count; k++)
			{
				assignments[k].gameObject.SetActive(value: false);
			}
		}
		else
		{
			List<Assignment> list = AssignmentsManager.instance.GetAssignments();
			for (int l = 0; l < assignments.Count; l++)
			{
				bool flag4 = list != null && list.Count > l && list[l] != null;
				assignments[l].gameObject.SetActive(flag4);
				if (flag4)
				{
					assignments[l].Initialize(list[l]);
				}
			}
		}
		continueButton.isEnabled = flag;
		continueLabel.text = Localization.Localize("ID_CONTINUE");
		forfeitLabel.text = Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_FORFEIT" : "ID_RESTART");
		skipTutorialButton.gameObject.SetActive(Singleton<GameController>.instance.isTutorial && DebugSettings.isOurDevice);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<CantPauseDialog>.instance.isShowed)
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
		}
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		HideDialog();
	}

	private void SkipTutorialClick(GameObject go)
	{
		Singleton<GameController>.instance.gameControllerTutorial.SkipTutorial();
	}

	private void ContinueClick(GameObject go)
	{
		if (isShowed)
		{
			mDoNotUpdate = true;
			Singleton<GameController>.instance.mainController.ResumeGame();
		}
	}

	private void ForfeitClick(GameObject go)
	{
		if (!isShowed)
		{
			return;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_FORFEITARENA"), Localization.Localize("ID_CONFIRM_FORFEITARENA_TEXT"), delegate(ConfirmDialog dialog, bool b)
			{
				if (b)
				{
					Singleton<GameController>.instance.mainController.Forfeit();
					GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
					GuiScreenSingle<MainScreen>.instance.previousScreen = null;
				}
			}, 0f);
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_FORFEIT" : "ID_RESTART"), Localization.Localize((!Singleton<GameController>.instance.isTutorial) ? "ID_CONFIRM_FORFEIT_TEXT" : "ID_CONFIRM_RESTART_TEXT"), delegate(ConfirmDialog dialog, bool b)
		{
			if (b)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 0f);
	}

	protected override void Update()
	{
		base.Update();
		if (!mDoNotUpdate)
		{
			mTimer += Time.deltaTime;
			if (mTimer >= 0.333f)
			{
				mTimer -= 0.333f;
				UpdateTexts();
			}
		}
	}

	private void UpdateTexts()
	{
		if (Singleton<GameController>.instance.mainController.pauseCountDown)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocalyFocusLost)
			{
				continueLabel.text = string.Format("{0} ({1})", Localization.Localize("ID_CONTINUE"), MiscTools.PrintableTimeTwoDigits(TimeManager.pauseTimeLeft));
			}
			else
			{
				continueLabel.text = string.Format("{0} ({1})", Localization.Localize("ID_WAIT"), MiscTools.PrintableTimeTwoDigits(TimeManager.pauseTimeLeft));
			}
			bool isEnabled = TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocaly || TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedLocalyFocusLost || Singleton<GameController>.instance.isTutorial;
			continueButton.isEnabled = isEnabled;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (continueButton.isEnabled)
		{
			ContinueClick(continueButton.gameObject);
		}
	}

	public override void HideDialog()
	{
		Debug.Log("#VAVRO# PauseScreen Hide");
		base.HideDialog();
	}
}
