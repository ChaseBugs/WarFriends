using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsContent : Core_BaseScript
{
	[Header("Single Player Buttons")]
	public GameObject singleplayerButtons;

	[Header("-Play Again")]
	public UIButton playAgainSingle;

	public BoxCollider playAgainSingleCollider;

	[Header("-Continue")]
	public UIButton continueSingle;

	public BoxCollider continueSingleCollider;

	public GameObject continueSingleNotificationObject;

	public UILabel continueSingleNotificationText;

	public List<UISprite> playAgainSingleSprites;

	[Header("-Text")]
	public UILabel infoTextSingle;

	[Header("Multi Player Buttons")]
	public GameObject multiplayerButtons;

	[Header("-Play Again")]
	public GameObject playAgainMultiObject;

	public BoxCollider playAgainMultiCollider;

	public GameObject playAgainMultiDogTagParent;

	public List<UISprite> playAgainMultiSprites;

	public UILabel playAgainLabel;

	public UILabel playAgainSublabel;

	[Header("--Lootbox Part")]
	public GameObject lootboxPart;

	public UILabel lootboxHint;

	[Header("--Winstreak Part")]
	public GameObject winstreakPart;

	public UITable winstreakTable;

	public UILabel winstreakNumber;

	public WinStreakCounter winstreakCounter;

	[Header("-Continue")]
	public UIButton continueMulti;

	public BoxCollider continueMultiCollider;

	public GameObject continueMultiNotificationObject;

	public UILabel continueMultiNotificationText;

	[Header("-Text")]
	public UILabel infoText;

	[Header("Setting")]
	public List<EndScreen.Tab> availableScreens;

	private bool mLastUpdateButtonsEnabled;

	private float mDur = 0.2f;

	private float mTimer;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(playAgainSingle.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PlayAgainSingleClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(continueSingle.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ContinueSingleClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(playAgainMultiObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PlayAgainMultiClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(continueMulti.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ContinueMultiClick));
		MatchManager.MatchStateChanged += MatchStateChanged;
		Singleton<NotificationManager>.instance.UnitDelivered += delegate
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				UpdateNotifications();
			}
		};
		Singleton<NotificationManager>.instance.WeaponDelivered += delegate
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				UpdateNotifications();
			}
		};
		Singleton<NotificationManager>.instance.VisualWasShown += delegate
		{
			Debug.Log("End Screen - button content - visual notification changed. End Screen active " + GuiScreenSingle<EndScreen>.instance.isShowed + " BUTTONS CONTENT " + base.gameObject.activeSelf);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				UpdateNotifications();
			}
		};
	}

	private void ContinueMultiClick(GameObject go)
	{
		GuiScreenSingle<EndScreen>.instance.ContinueButtonClick(EndScreen.Tab.WarCards);
	}

	private void PlayAgainMultiClick(GameObject go)
	{
		GuiScreenSingle<EndScreen>.instance.PlayAgainButtonClick(EndScreen.Tab.WarCards);
	}

	private void ContinueSingleClick(GameObject go)
	{
		GuiScreenSingle<EndScreen>.instance.NextButtonClick(EndScreen.Tab.WarCards);
	}

	private void PlayAgainSingleClick(GameObject go)
	{
		GuiScreenSingle<EndScreen>.instance.ReplayButtonClick(EndScreen.Tab.WarCards);
	}

	internal void InitGuiValues()
	{
		mLastUpdateButtonsEnabled = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
		SetScale(GuiScreenSingle<EndScreen>.instance.buttonsEnabled);
		infoTextSingle.text = string.Empty;
		bool isSinglePlayer = GuiScreenSingle<EndScreen>.instance.isSinglePlayer;
		singleplayerButtons.SetActive(isSinglePlayer);
		multiplayerButtons.SetActive(!isSinglePlayer);
		if (isSinglePlayer)
		{
			infoText.text = string.Empty;
			bool flag = Singleton<GameController>.instance.isTutorial || (Singleton<GameController>.instance.isMission && MissionsManager.instance.currentMission.playingInHeroicMode);
			playAgainSingle.gameObject.SetActive(!flag);
			if (playAgainSingle.gameObject.activeSelf)
			{
				SetPlayAgainSingleButton(enabled: true);
			}
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				bool activeInHierarchy = playAgainSingle.gameObject.activeInHierarchy;
				infoTextSingle.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
			}
		}
		else
		{
			bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
			playAgainLabel.text = Localization.Localize((!isRandomMatchMaking) ? "ID_PLAYAGAIN" : "ID_RANKEDBATTLE");
			playAgainSublabel.text = Localization.Localize((!isRandomMatchMaking) ? "ID_AGAINSTTHESAMEOPPONENT" : "ID_ENEMYWILLBESELECTEDRANDOMLY");
			playAgainMultiDogTagParent.SetActive(isRandomMatchMaking);
			MiscTools.SetUILabelRescale(playAgainLabel, 58f, 29f, 580);
			SetUpPlayAgainMultiplayerButton();
			infoText.text = MatchManager.matchStatusAfterMatch;
		}
		UpdateNotifications();
	}

	private void UpdateNotifications()
	{
		int numberOfEndScreenNotifications = Singleton<NotificationManager>.instance.GetNumberOfEndScreenNotifications();
		continueSingleNotificationText.text = numberOfEndScreenNotifications.ToString();
		continueMultiNotificationText.text = numberOfEndScreenNotifications.ToString();
		continueSingleNotificationObject.SetActive(value: false);
		continueMultiNotificationObject.SetActive(numberOfEndScreenNotifications > 0);
	}

	private void SetScale(bool enable)
	{
		Debug.Log("END SCREEN - BUTTONS - enabled " + enable);
		continueMultiCollider.enabled = enable;
		continueSingleCollider.enabled = enable;
		playAgainSingleCollider.enabled = enable;
		playAgainMultiCollider.enabled = enable;
	}

	private void UpdateTexts()
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			string matchTimeStatus = MatchManager.matchTimeStatus;
			infoText.text = ((!string.IsNullOrEmpty(matchTimeStatus)) ? $"{MatchManager.matchStatusAfterMatch} ({matchTimeStatus})" : MatchManager.matchStatusAfterMatch);
			SetPlayAgainMultiplayerButton(MatchManager.canRematch);
		}
		else
		{
			SetPlayAgainMultiplayerButton(enabled: true);
			infoText.text = string.Empty;
		}
		if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
		{
			if (playAgainSingle.gameObject.activeInHierarchy)
			{
				string matchTimeStatus2 = MatchManager.matchTimeStatus;
				infoTextSingle.text = ((!string.IsNullOrEmpty(matchTimeStatus2)) ? $"{MatchManager.matchStatusAfterMatch} ({matchTimeStatus2})" : MatchManager.matchStatusAfterMatch);
				SetPlayAgainSingleButton(MatchManager.canRematch);
			}
			else
			{
				infoTextSingle.text = string.Empty;
			}
		}
		else
		{
			SetPlayAgainSingleButton(enabled: true);
			infoTextSingle.text = string.Empty;
		}
	}

	protected void Update()
	{
		mTimer += Time.deltaTime;
		if (mTimer >= 0.333f)
		{
			mTimer -= 0.333f;
			UpdateTexts();
		}
		if (mLastUpdateButtonsEnabled != GuiScreenSingle<EndScreen>.instance.buttonsEnabled)
		{
			mLastUpdateButtonsEnabled = GuiScreenSingle<EndScreen>.instance.buttonsEnabled;
			SetScale(mLastUpdateButtonsEnabled);
		}
	}

	private void SetPlayAgainMultiplayerButton(bool enabled)
	{
		playAgainMultiCollider.enabled = enabled;
		foreach (UISprite playAgainMultiSprite in playAgainMultiSprites)
		{
			playAgainMultiSprite.color = ((!enabled) ? Colours.grayLight : Color.white);
		}
	}

	private void SetPlayAgainSingleButton(bool enabled)
	{
		playAgainSingleCollider.enabled = enabled;
		foreach (UISprite playAgainSingleSprite in playAgainSingleSprites)
		{
			playAgainSingleSprite.color = ((!enabled) ? Colours.grayLight : Color.white);
		}
	}

	private void SetUpPlayAgainMultiplayerButton()
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		WinStreakManager.WinStreak winStreak = StatsManager.instance.winStreak;
		bool flag = Singleton<GameController>.instance.isRandomMatchMaking && winStreak != null && winStreak.IsActive();
		playAgainSublabel.gameObject.SetActive(!isRandomMatchMaking && !flag);
		lootboxPart.SetActive(isRandomMatchMaking);
		if (isRandomMatchMaking)
		{
			int remainingMatchesToNextLootbox = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			lootboxHint.text = ((remainingMatchesToNextLootbox != 1) ? Localization.LocalizeFormat("ID_NEWLOOTBOXINBATTLES", remainingMatchesToNextLootbox) : Localization.Localize("ID_NEWLOOTBOXINBATTLE"));
			MiscTools.SetUILabelRescale(lootboxHint, 30f, 20f, 520);
		}
		winstreakPart.SetActive(flag);
		if (flag)
		{
			winstreakNumber.text = string.Format("{0} {1}", Localization.Localize("ID_WINSTREAK"), winStreak.winstreakNumber);
			winstreakTable.repositionNow = true;
			winstreakCounter.StartCountingTo(winStreak.Deadline);
			winstreakCounter.winStreakTimer = delegate
			{
				SetUpPlayAgainMultiplayerButton();
			};
		}
		else
		{
			winstreakCounter.StopCountingTo();
			winstreakCounter.winStreakTimer = null;
		}
		if (isRandomMatchMaking && flag)
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

	private void MatchStateChanged(MatchState obj)
	{
		if (!GuiScreenSingle<EndScreen>.instance.isSinglePlayer && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			infoText.text = MatchManager.matchStatusAfterMatch;
		}
		if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
		{
			bool activeInHierarchy = playAgainSingle.gameObject.activeInHierarchy;
			infoTextSingle.text = ((!activeInHierarchy) ? string.Empty : MatchManager.matchStatusAfterMatch);
		}
	}

	public void SetActiveAccordingToTab(EndScreen.Tab currentTab)
	{
		base.gameObject.SetActive(availableScreens.Contains(currentTab));
	}
}
