using System;
using UnityEngine;

public class PlayerVsPlayerButton : Core_BaseScript
{
	public enum Type
	{
		Tutorial,
		Normal,
		Winstreak,
		Lootbox,
		WinstreakAndLootbox
	}

	[Header("Core")]
	public UIButtonSetter pvpButtonSetter;

	public GameObject pvpButton;

	public GameObject pvpPart;

	public UITable pvpTable;

	public UILabel pvpFirstLabel;

	public UILabel pvpSecondLabel;

	[Header("-Lootbox Part")]
	public GameObject lootboxPart;

	public UILabel lootboxHint;

	[Header("-Winstreak Part")]
	public GameObject winstreakPart;

	public UITable winstreakTable;

	public UILabel winstreakNumber;

	public WinStreakCounter winstreakCounter;

	[Header("-Tutorial")]
	public GameObject positionForTutorialText;

	public GameObject positionForTutorialHand;

	public UILabel tutorialPvPLabel;

	private float mDur = 0.2f;

	private Type mCurrentType
	{
		get
		{
			if (Singleton<GameController>.instance.isTutorial)
			{
				return Type.Tutorial;
			}
			if (TutorialManagerStage6.instance.isTutorialRunning)
			{
				return Type.Normal;
			}
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			if (winStreak != null && winStreak.IsActive())
			{
				return Type.WinstreakAndLootbox;
			}
			return Type.Lootbox;
		}
	}

	public void InitEvents()
	{
		GameLoginManager.instance.PlayerLogOut += InitBlank;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(pvpButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PvPClick));
		pvpFirstLabel.text = Localization.Localize("ID_PVP_RANKED");
		pvpSecondLabel.text = Localization.Localize("ID_PVP_BATTLE");
		float num = pvpFirstLabel.relativeSize.x + pvpSecondLabel.relativeSize.x;
		float a = 450f / num;
		float defaultHeight = Mathf.Max(a, 57f);
		MiscTools.SetUILabelRescale(pvpFirstLabel, defaultHeight, 20f, 450);
		MiscTools.SetUILabelRescale(pvpSecondLabel, defaultHeight, 20f, 450);
		pvpTable.repositionNow = true;
		winstreakTable.repositionNow = true;
	}

	public void PvPClick(GameObject go)
	{
		if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
		{
			TutorialManagerPlayWarcards.instance.StartTutorial(isContinue: false);
		}
		else if (Singleton<GameController>.instance.isTutorialStage1 || Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<GameController>.instance.ContinueTutorialImmediately();
		}
		else if (!ReminderManager.instance.ShowWarcardsReminder())
		{
			if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				Singleton<GameController>.instance.SwitchToDeathMatch();
				Singleton<GameController>.instance.gameControllerDeathMatch.StartRandomMatchMaking();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 0f);
			}
		}
	}

	public void InitGUIValues()
	{
		SetUpButton();
	}

	public void InitBlank()
	{
		tutorialPvPLabel.gameObject.SetActive(value: false);
		pvpPart.SetActive(value: true);
		winstreakPart.SetActive(value: false);
		lootboxPart.SetActive(value: false);
		pvpPart.transform.localPosition = pvpPart.transform.localPosition.ReplaceY(8f);
		winstreakCounter.StopCountingTo();
		winstreakCounter.winStreakTimer = null;
	}

	private void SetUpButton()
	{
		Type type = mCurrentType;
		tutorialPvPLabel.gameObject.SetActive(type == Type.Tutorial);
		if (type == Type.Tutorial)
		{
			tutorialPvPLabel.text = Localization.Localize((!Singleton<GameController>.instance.isTutorialStage1) ? "ID_CONTINUETOBOOTCAMP3" : "ID_CONTINUETOBOOTCAMP2");
			if (Localization.isEnglish)
			{
				pvpButtonSetter.labels.Clear();
				tutorialPvPLabel.lineWidth = 500;
			}
		}
		pvpPart.SetActive(type != Type.Tutorial);
		pvpPart.transform.localPosition = pvpPart.transform.localPosition.ReplaceY((type != Type.Normal) ? 30f : 8f);
		lootboxPart.SetActive(type == Type.Lootbox || type == Type.WinstreakAndLootbox);
		if (lootboxPart.activeSelf)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			lootboxHint.text = ((remainingMatchesToNextLootbox != 1) ? Localization.LocalizeFormat("ID_NEWLOOTBOXINBATTLES", remainingMatchesToNextLootbox) : Localization.Localize("ID_NEWLOOTBOXINBATTLE"));
			MiscTools.SetUILabelRescale(lootboxHint, 30f, 20f, Mathf.Max(400, pvpButtonSetter.width - 386));
		}
		winstreakPart.SetActive(type == Type.Winstreak || type == Type.WinstreakAndLootbox);
		if (winstreakPart.activeSelf)
		{
			WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
			winstreakNumber.text = string.Format("{0} {1}", Localization.Localize("ID_WINSTREAK"), winStreak.winstreakNumber);
			winstreakTable.repositionNow = true;
			winstreakCounter.StartCountingTo(winStreak.Deadline);
			winstreakCounter.winStreakTimer = delegate
			{
				SetUpButton();
			};
		}
		else
		{
			winstreakCounter.StopCountingTo();
			winstreakCounter.winStreakTimer = null;
		}
		if (type == Type.WinstreakAndLootbox)
		{
			WaitOnWinstreak();
		}
		else
		{
			StopAnimation();
		}
	}

	private void StopAnimation()
	{
		TweenPosition component = lootboxPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = winstreakPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
		lootboxPart.transform.localPosition = lootboxPart.transform.localPosition.ReplaceY(0f);
		winstreakPart.transform.localPosition = winstreakPart.transform.localPosition.ReplaceY(18f);
	}

	private void WaitOnWinstreak()
	{
		lootboxPart.transform.localPosition = lootboxPart.transform.localPosition.ReplaceY(60f);
		winstreakPart.transform.localPosition = winstreakPart.transform.localPosition.ReplaceY(18f);
		TweenPosition component = lootboxPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(winstreakPart, 10f * mDur, winstreakPart.transform.localPosition, winstreakPart.transform.localPosition);
		component.onFinished = delegate
		{
			ChangeToLootbox();
		};
	}

	private void ChangeToLootbox()
	{
		TweenPosition.Begin(lootboxPart, mDur, lootboxPart.transform.localPosition, lootboxPart.transform.localPosition.ReplaceY(0f));
		TweenPosition tweenPosition = TweenPosition.Begin(winstreakPart, mDur, winstreakPart.transform.localPosition, winstreakPart.transform.localPosition.ReplaceY(-42f));
		tweenPosition.onFinished = delegate
		{
			WaitOnLootbox();
		};
	}

	private void WaitOnLootbox()
	{
		lootboxPart.transform.localPosition = lootboxPart.transform.localPosition.ReplaceY(0f);
		winstreakPart.transform.localPosition = winstreakPart.transform.localPosition.ReplaceY(78f);
		TweenPosition component = lootboxPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = TweenPosition.Begin(winstreakPart, 10f * mDur, winstreakPart.transform.localPosition, winstreakPart.transform.localPosition);
		component.onFinished = delegate
		{
			ChangeToWinstreak();
		};
	}

	private void ChangeToWinstreak()
	{
		TweenPosition.Begin(lootboxPart, mDur, lootboxPart.transform.localPosition, lootboxPart.transform.localPosition.ReplaceY(-60f));
		TweenPosition tweenPosition = TweenPosition.Begin(winstreakPart, mDur, winstreakPart.transform.localPosition, winstreakPart.transform.localPosition.ReplaceY(18f));
		tweenPosition.onFinished = delegate
		{
			WaitOnWinstreak();
		};
	}
}
