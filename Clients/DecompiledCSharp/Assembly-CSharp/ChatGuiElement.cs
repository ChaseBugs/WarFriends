using System;
using UnityEngine;

public class ChatGuiElement : GuiElementSingle<ChatGuiElement>
{
	public enum State
	{
		Closed,
		Chat,
		MessageCenter,
		ActiveUnits
	}

	[Header("Core")]
	public GameObject chatParent;

	public UIButton hidingInvisibleButton;

	[Header("CHAT")]
	public ChatTab chatContent;

	public UIPanel chatButtonPanel;

	public GameObject chatButton;

	public GameObject chatButtonOverlay;

	public BoxCollider chatButtonCollider;

	public UILabel chatNotificationLabel;

	public UISprite chatNotificationBackground;

	public UISprite chatNotificationExclamation;

	[Header("MESSAGE")]
	public MessageCenterTab messageContent;

	public GameObject messageCenterButton;

	public GameObject messageCenterButtonOverlay;

	public BoxCollider messageCenterButtonCollider;

	public UILabel mcNotificationLabel;

	public UISprite mcNotificationBackground;

	public UISprite mcNotificationExclamation;

	[Header("ACTIVE UNITS")]
	public ActiveUnitsTab activeUnitsContent;

	public UIPanel activeUnitsButtonPanel;

	public GameObject activeUnitsButton;

	public GameObject activeUnitsButtonOverlay;

	public BoxCollider activeUnitsButtonCollider;

	public GameObject activeUnitsNotifications;

	public UILabel activeUnitsNumber;

	public float duration = 0.4f;

	private int mChatMessages;

	private int mMessageCenterMessages;

	private bool mEnabledButtons = true;

	private Vector3 mSidetabWindowPosition;

	private State mCurrentState;

	public bool isRightPartDisplayed => mCurrentState != State.Closed;

	public bool anyChatNotifications => mChatMessages > 0;

	public bool anyMessageCenterNotifications => mMessageCenterMessages > 0;

	private bool mIsAnyTutorialRunning => (Singleton<GameController>.instance.isTutorial && (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.isTutorialRunning)) || TutorialManagerPlayWarcards.instance.isTutorialRunning;

	public event Action ChangingState;

	public bool HideRightContent()
	{
		if (Singleton<GuiManager>.instance.currentScreen != null && Singleton<GuiManager>.instance.currentScreen is GuiScreen && Singleton<GuiManager>.instance.currentScreen.showActiveUnits && mCurrentState == State.ActiveUnits && !activeUnitsContent.CanClose())
		{
			return false;
		}
		if (mCurrentState != State.Closed)
		{
			mCurrentState = State.Closed;
			Animate();
			return true;
		}
		return false;
	}

	public void ShowActiveUnits()
	{
		if (!mIsAnyTutorialRunning)
		{
			if (activeUnitsButtonPanel.gameObject.activeSelf)
			{
				mCurrentState = State.ActiveUnits;
				Animate();
			}
			else
			{
				Debug.LogError("Cannot show active units on this screen.");
			}
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		activeUnitsContent.InitEvents();
		GameLoginManager.instance.PlayerLeftSquad += delegate
		{
			mChatMessages = 0;
			ShowChatNotificationNumber();
		};
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(chatButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ChatButtonClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(messageCenterButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NotificationCenterButtonClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(activeUnitsButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ActiveUnitsButtonClicked));
		UIEventListener uIEventListener4 = UIEventListener.Get(hidingInvisibleButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			HideRightContent();
		});
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			if (isShowed)
			{
				HideRightContent();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed && (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook))
			{
				HideRightContent();
			}
		};
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			InitGUIValues();
		};
		AssignmentsManager.instance.AssignmentsLoaded += UpdateAssignmentsNotifications;
		AssignmentsManager.instance.AssignmentClaimed += DailyAssignmentClaimed;
		StarterAssignmentsManager.instance.AssignmentClaimed += UpdateAssignmentsNotifications;
		mSidetabWindowPosition = chatParent.transform.localPosition;
		chatContent.InitChat();
		messageContent.InitMessageCenter();
		activeUnitsContent.InitControls();
		mChatMessages = 0;
		mMessageCenterMessages = 0;
		mCurrentState = State.Closed;
		UICamera.genericEventHandler = base.gameObject;
	}

	private void ChatButtonClicked(GameObject go)
	{
		if (!mEnabledButtons || mIsAnyTutorialRunning || (mCurrentState == State.ActiveUnits && !activeUnitsContent.CanClose()))
		{
			return;
		}
		if (mCurrentState == State.Chat)
		{
			if (anyChatNotifications)
			{
				chatContent.ShowSquadTab();
			}
			else
			{
				HideRightContent();
			}
		}
		else
		{
			mCurrentState = State.Chat;
			Animate();
			FirstTimeShowing();
		}
		mChatMessages = 0;
		ShowChatNotificationNumber();
	}

	private void FirstTimeShowing()
	{
		if (!PlayerAnalytics.instance.data.chatShown && GameLoginManager.currentPlayer.accountType != AccountType.Guest)
		{
			Singleton<MessageManager>.instance.AddMessage(new ChatTutorialMessage());
		}
	}

	private void NotificationCenterButtonClicked(GameObject go)
	{
		if (mEnabledButtons && !mIsAnyTutorialRunning && (mCurrentState != State.ActiveUnits || activeUnitsContent.CanClose()))
		{
			if (mCurrentState == State.MessageCenter)
			{
				HideRightContent();
			}
			else
			{
				mCurrentState = State.MessageCenter;
				Animate();
			}
			mMessageCenterMessages = 0;
			ShowMCNotificationNumber();
		}
	}

	private void ActiveUnitsButtonClicked(GameObject go)
	{
		if (mEnabledButtons && !mIsAnyTutorialRunning && (mCurrentState != State.ActiveUnits || activeUnitsContent.CanClose()))
		{
			mCurrentState = ((mCurrentState != State.ActiveUnits) ? State.ActiveUnits : State.Closed);
			Animate();
		}
	}

	public void BattleStarted()
	{
		if (mCurrentState == State.ActiveUnits)
		{
			activeUnitsContent.CanClose();
		}
	}

	private void DailyAssignmentClaimed(int index)
	{
		UpdateAssignmentsNotifications();
	}

	private void UpdateAssignmentsNotifications()
	{
		if (isShowed)
		{
			ShowMCNotificationNumber();
		}
	}

	public override void InitGUIValues()
	{
		ShowChatNotificationNumber();
		ShowMCNotificationNumber();
		ActiveUnitsNotificationUpdate();
		mCurrentState = State.Closed;
		Animate();
		UpdateButtonLook();
		chatContent.InitGui();
		messageContent.InitGui();
	}

	public void ShowContent(bool showChat, bool showActiveUnits)
	{
		if (showChat)
		{
			ShowChatPart();
		}
		else
		{
			HideChatPart();
		}
		if (showActiveUnits)
		{
			ShowActiveUnitsPart();
		}
		else
		{
			HideActiveUnitsPart();
		}
	}

	private void ShowChatPart()
	{
		if (!chatButtonPanel.gameObject.activeSelf)
		{
			chatButtonPanel.gameObject.SetActive(value: true);
			chatButtonPanel.isFreezed = false;
		}
		chatContent.ShowChat(mCurrentState == State.Chat);
		messageContent.ShowMessageCenter(mCurrentState == State.MessageCenter);
		TweenAlpha.Begin(chatButtonPanel.gameObject, duration, 1f).onFinished = null;
	}

	private void HideChatPart()
	{
		if (chatButtonPanel.gameObject.activeSelf)
		{
			mEnabledButtons = false;
			chatContent.ShowChat(enable: false);
			messageContent.ShowMessageCenter(enable: false);
			TweenAlpha.Begin(chatButtonPanel.gameObject, duration, 0f).onFinished = delegate
			{
				mEnabledButtons = true;
				chatButtonPanel.gameObject.SetActive(value: false);
			};
		}
	}

	private void ShowActiveUnitsPart()
	{
		if (!activeUnitsButtonPanel.gameObject.activeSelf)
		{
			activeUnitsButtonPanel.gameObject.SetActive(value: true);
			activeUnitsButtonPanel.isFreezed = false;
		}
		activeUnitsContent.ShowTab(mCurrentState == State.ActiveUnits);
		TweenAlpha.Begin(activeUnitsButtonPanel.gameObject, duration, 1f).onFinished = null;
	}

	private void HideActiveUnitsPart()
	{
		if (activeUnitsButtonPanel.gameObject.activeSelf)
		{
			mEnabledButtons = false;
			activeUnitsContent.ShowTab(enable: false);
			TweenAlpha.Begin(activeUnitsButtonPanel.gameObject, duration, 0f).onFinished = delegate
			{
				mEnabledButtons = true;
				activeUnitsButtonPanel.gameObject.SetActive(value: false);
			};
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (activeUnitsButtonPanel.alpha1 < 1f)
		{
			activeUnitsButtonPanel.gameObject.SetActive(value: false);
		}
		if (chatButtonPanel.alpha1 < 1f)
		{
			chatButtonPanel.gameObject.SetActive(value: false);
		}
		mEnabledButtons = true;
	}

	public void AddNotificationsToChatButton(int newNotifications)
	{
		Debug.Log($"Chat - new notifications: {newNotifications}, selectedSquadChat: {chatContent.isSelectedSquadChat}, currentState: {mCurrentState}");
		if (mCurrentState != State.Chat || !chatContent.isSelectedSquadChat)
		{
			mChatMessages += newNotifications;
			ShowChatNotificationNumber();
		}
	}

	private void ShowChatNotificationNumber()
	{
		if (chatContent.currentContent != ChatTab.ChatLookState.normalChat || mIsAnyTutorialRunning)
		{
			mChatMessages = 0;
		}
		chatNotificationBackground.alpha = ((mChatMessages != 0) ? 1f : 0f);
		chatNotificationExclamation.alpha = ((mChatMessages != 0) ? 1f : 0f);
	}

	public void RemoveNotificationsFromChatButton()
	{
		mChatMessages = 0;
		ShowChatNotificationNumber();
	}

	public void AddNotificationsToMessageCenterButton(int newNotifications)
	{
		if (mCurrentState != State.MessageCenter)
		{
			mMessageCenterMessages += newNotifications;
			ShowMCNotificationNumber();
		}
	}

	public void RemoveOneNotificationFromMessageCenterButton()
	{
		if (mCurrentState != State.MessageCenter)
		{
			mMessageCenterMessages = Mathf.Max(0, mMessageCenterMessages - 1);
			ShowMCNotificationNumber();
		}
	}

	private void ShowMCNotificationNumber()
	{
		int num = mMessageCenterMessages;
		if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			num++;
		}
		num += Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		if (mIsAnyTutorialRunning)
		{
			num = 0;
		}
		mcNotificationBackground.alpha = ((num != 0) ? 1f : 0f);
		mcNotificationExclamation.alpha = ((num != 0) ? 1f : 0f);
	}

	public void ActiveUnitsNotificationUpdate()
	{
		int num = Singleton<NotificationManager>.instance.ActiveUnitToChoose();
		activeUnitsNotifications.SetActive(num > 0);
		activeUnitsNumber.text = num.ToString();
	}

	private void Animate()
	{
		mEnabledButtons = false;
		mSidetabWindowPosition.x = -812f;
		if (mCurrentState == State.Closed)
		{
			mSidetabWindowPosition.x = 0f;
		}
		if (mCurrentState == State.ActiveUnits)
		{
			mSidetabWindowPosition.x = -1330f;
		}
		TweenPosition tweenPosition = TweenPosition.Begin(chatParent, duration, mSidetabWindowPosition);
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
		{
			mEnabledButtons = true;
			UpdateButtonLook();
		});
		ShowContent();
		if (this.ChangingState != null)
		{
			this.ChangingState();
		}
	}

	private void ShowContent()
	{
		chatContent.ShowChat(mCurrentState == State.Chat);
		messageContent.ShowMessageCenter(mCurrentState == State.MessageCenter);
		activeUnitsContent.ShowTab(mCurrentState == State.ActiveUnits);
		UpdateButtonLook();
		hidingInvisibleButton.gameObject.SetActive(mCurrentState != State.Closed);
		UIDraggablePanel.panelDisabled = mCurrentState != State.Closed;
		if (mCurrentState == State.Closed)
		{
			Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
		}
	}

	private void HideContent()
	{
		chatContent.ShowChat(enable: false);
		messageContent.ShowMessageCenter(enable: false);
		activeUnitsContent.ShowTab(enable: false);
	}

	public void UpdateButtonLook()
	{
		ChatButtonLook(!mIsAnyTutorialRunning && mEnabledButtons, mCurrentState == State.Chat || mCurrentState == State.Closed);
		MessageCenterLook(!mIsAnyTutorialRunning && mEnabledButtons, mCurrentState == State.MessageCenter || mCurrentState == State.Closed);
		ActiveUnitsLook(!mIsAnyTutorialRunning && mEnabledButtons, mCurrentState == State.ActiveUnits || mCurrentState == State.Closed);
	}

	private void ChatButtonLook(bool enable, bool rightState)
	{
		chatButtonOverlay.SetActive(!enable || !rightState);
		chatButtonCollider.enabled = enable;
	}

	private void MessageCenterLook(bool enable, bool rightState)
	{
		messageCenterButtonOverlay.SetActive(!enable || !rightState);
		messageCenterButtonCollider.enabled = enable;
	}

	private void ActiveUnitsLook(bool enable, bool rightState)
	{
		activeUnitsButtonOverlay.SetActive(!enable || !rightState);
		activeUnitsButtonCollider.enabled = enable;
	}

	private void OnPress(bool pressed)
	{
		if (pressed && UICamera.currentTouch.pressed != base.gameObject)
		{
			GameObject pressed2 = UICamera.currentTouch.pressed;
			if (mCurrentState != State.Closed && !isPressedOnChatContent(pressed2))
			{
				HideRightContent();
			}
		}
	}

	private bool isPressedOnChatContent(GameObject pressedObject)
	{
		bool flag = pressedObject.GetComponentInParent<IGuiDialog>() != null;
		bool flag2 = pressedObject.GetComponentInParent<ChatGuiElement>() != null;
		bool flag3 = pressedObject.GetComponentInParent<DialogOverlayGuiElement>() != null;
		return flag || flag2 || flag3;
	}
}
