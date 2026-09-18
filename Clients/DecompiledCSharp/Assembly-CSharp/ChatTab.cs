using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatTab : Core_BaseScript
{
	public enum ChatLookState
	{
		normalChat,
		joinOrCreateSquad,
		bannedUser,
		guestNotAllowed
	}

	private enum ChatCacheStatus
	{
		NoChange,
		TopAdded,
		BigChange
	}

	private const float MIN_DIFFERENCE_THAT_CHAT_IS_ON_TOP = 0.5f;

	[Header("Master")]
	public UIPanel chatPanel;

	public ChatLookState showedContent;

	[Header("Guest Account Part")]
	public GameObject nonGuestContent;

	public UIButton loginWithFBButton;

	public GameObject loginToGooglePlay;

	[Header("Banned From Chat Part")]
	public GameObject bannedFromChatContent;

	public WinStreakCounter counter;

	public UILabel topBannerMessage;

	public UILabel bottomMessage;

	[Header("Join Or Create Squad Part")]
	public GameObject joinOrCreateSquadContent;

	public UITable hintsTable;

	public UITable getHintTable;

	public UILabel getLabel;

	public UILabel hintLabel;

	public UIButton joinSquadButton;

	public UIPanel joinLockedPanel;

	public GameObject joinLockedObject;

	public UIButton createSquadButton;

	public UIPanel createLockedPanel;

	public GameObject createLockedObject;

	[Header("Chat Part")]
	public GameObject chatContent;

	public GameObject inputFieldHolder;

	public UIInputChat input;

	public UIButton sendMessage;

	[Header("-Public Buttons")]
	public List<UIButton> channelButtons;

	public ChatSquadButtonOnline squadButton;

	[Header("-Squad Message")]
	public GameObject squadMessageHolder;

	public UILabel squadMessage;

	[Header("-Chat List")]
	public ChatRecord chatRecordPrefab;

	public UIPooledTable chatTable;

	public UIPanel scrollPanel;

	public UIDraggablePanel draggablePanel;

	public ChatPosition positionOfChat;

	public UILabel errorLabel;

	private ChatRecord mChatRecordForHeight;

	private int mSelectedChannelIndex = -1;

	private Chat.ChatRecordData mLastSeenMessage;

	private List<Chat.ChatRecordData> mChatMessages = new List<Chat.ChatRecordData>();

	private List<Chat.ChatRecordData> mSpecialSquadMessages = new List<Chat.ChatRecordData>();

	private bool mAligningChatNewMessages;

	private RadicalRoutine mAlignWorked;

	private int mSecondsToUnban;

	private bool mIsForeverBanned;

	public ChatRecord chatRecordForHeight
	{
		get
		{
			if (mChatRecordForHeight == null)
			{
				mChatRecordForHeight = UnityEngine.Object.Instantiate(chatRecordPrefab);
				mChatRecordForHeight.transform.parent = base.transform;
				mChatRecordForHeight.name = "Chat Record For Height";
				mChatRecordForHeight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth, -UIRoot.list[0].activeHeight, 0f);
				mChatRecordForHeight.transform.localScale = Vector3.one;
			}
			return mChatRecordForHeight;
		}
	}

	public ChatLookState currentContent
	{
		get
		{
			if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return ChatLookState.guestNotAllowed;
			}
			bool flag = ChatBanManager.instance.IsChatBanned(Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			mSecondsToUnban = ChatBanManager.instance.RemainingBanTime();
			mIsForeverBanned = ChatBanManager.instance.IsBannedForever();
			bool flag2 = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
			if (flag)
			{
				return ChatLookState.bannedUser;
			}
			if (!Singleton<Chat>.instance.shouldChat)
			{
				return ChatLookState.guestNotAllowed;
			}
			if (isSelectedSquadChat && flag2)
			{
				return ChatLookState.joinOrCreateSquad;
			}
			return ChatLookState.normalChat;
		}
	}

	public bool isSelectedSquadChat => mSelectedChannelIndex == 1;

	public bool isChatShown => chatPanel.gameObject.activeSelf;

	private bool mNearTopOfChat => chatTable.topHelperSprite.transform.position.y - positionOfChat.underTheHeaderOfChatPosition.transform.position.y < 0.5f;

	public void AddDatabaseMessageToSquadChat(DatabaseMessage databaseMessage, bool showNotification = true)
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		string id = databaseMessage.messageId;
		int num = mSpecialSquadMessages.FindIndex((Chat.ChatRecordData m1) => m1.databaseMessageId == id);
		bool flag = !databaseMessage.messageShown;
		if (num > -1)
		{
			return;
		}
		Chat.ChatRecordData item = Chat.ChatRecordData.CreateSquadAction(databaseMessage);
		mSpecialSquadMessages.Add(item);
		if (isSelectedSquadChat)
		{
			mChatMessages.Add(item);
			int count = mChatMessages.Count;
			bool flag2 = false;
			if (count > 2 && mChatMessages[count - 2].time > mChatMessages[count - 1].time)
			{
				mChatMessages.Sort(SortingFunctionForChatData);
				flag2 = true;
			}
			ChatCacheStatus chatCacheStatus = TimerMessagesAddingToCache();
			if (chatCacheStatus == ChatCacheStatus.BigChange)
			{
				flag2 = true;
			}
			if (isChatShown)
			{
				if (flag2)
				{
					InstantiateChatMessages();
				}
				else
				{
					bool flag3 = mNearTopOfChat;
					chatTable.IncreaseContainItems(1, align: false);
					if (flag3 || mAligningChatNewMessages)
					{
						AlignTableNextFrame(instant: false);
					}
				}
			}
		}
		if (showNotification && flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.AddNotificationsToChatButton(1);
		}
	}

	public void DebugLogPosition()
	{
	}

	public void ShowSquadTab()
	{
		mSelectedChannelIndex = 0;
		PublicChannelCLick(channelButtons[1].gameObject);
	}

	private void PublicChannelCLick(GameObject go)
	{
		Debug.Log("Chat Tab: PUBLIC BUTTON clicked on " + go.name);
		UIButton button = go.GetComponentsInChildren<UIButton>(includeInactive: true)[0];
		int num = channelButtons.FindIndex((UIButton a) => a == button);
		if (num != mSelectedChannelIndex)
		{
			mSelectedChannelIndex = num;
			for (int num2 = 0; num2 < channelButtons.Count; num2++)
			{
				ChatButtonUnderline component = channelButtons[num2].GetComponent<ChatButtonUnderline>();
				component.SetClicked(num2 == num);
				channelButtons[num2].sprites[1].gameObject.SetActive(num2 != num);
			}
			StopAlign();
			draggablePanel.AlignToPos(instant: true);
			switch (num)
			{
			case 0:
				GlobalContent();
				break;
			case 1:
				SquadContent();
				GuiElementSingle<ChatGuiElement>.instance.RemoveNotificationsFromChatButton();
				break;
			}
		}
	}

	private void SquadContent()
	{
		SetRightContent(currentContent);
		ShowHeaderWithSquadMessage();
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			Singleton<Chat>.instance.SelectPublicChannel(1);
			if (Singleton<Chat>.instance.checkChatConnection)
			{
				DrawMessages();
			}
			else
			{
				chatTable.MakeEmpty();
			}
		}
		else
		{
			chatTable.MakeEmpty();
		}
	}

	private void GlobalContent()
	{
		SetRightContent(currentContent);
		ShowHeaderWithSquadMessage();
		Singleton<Chat>.instance.SelectPublicChannel(0);
		if (Singleton<Chat>.instance.checkChatConnection)
		{
			DrawMessages();
		}
		else
		{
			chatTable.MakeEmpty();
		}
	}

	private void ShowHeaderWithSquadMessage()
	{
		bool flag = currentContent == ChatLookState.normalChat && isSelectedSquadChat;
		string text = GameLoginManager.instance.squadMessage;
		positionOfChat.SetTopOfChat(flag);
		squadMessageHolder.SetActive(flag);
		if (flag)
		{
			squadMessage.text = text;
		}
	}

	private void DrawMessages()
	{
		if (showedContent != ChatLookState.normalChat)
		{
			chatTable.MakeEmpty();
		}
		else
		{
			if (!Singleton<Chat>.instance.checkChatConnection)
			{
				return;
			}
			chatTable.MakeEmpty();
			mChatMessages.Clear();
			Singleton<Chat>.instance.GetMessages(out var messages);
			if (isSelectedSquadChat)
			{
				int num = -1;
				int num2 = 0;
				for (int i = 0; i < messages.Count; i++)
				{
					if (messages[i].chatType == Chat.ChatMessageType.Message)
					{
						num = i;
					}
					num2 = Mathf.Max(num2, messages[i].time);
				}
				if (num > -1 && messages[num].time > mLastSeenMessage.time)
				{
					mLastSeenMessage = messages[num];
				}
				PlayerAnalytics.instance.lastSeenSquadChatTimeStamp = num2;
			}
			for (int j = 0; j < messages.Count; j++)
			{
				mChatMessages.Add(messages[j]);
			}
			if (isSelectedSquadChat)
			{
				foreach (Chat.ChatRecordData mSpecialSquadMessage in mSpecialSquadMessages)
				{
					mChatMessages.Add(mSpecialSquadMessage);
				}
				mChatMessages.Sort(SortingFunctionForChatData);
			}
			TimerMessagesAddingToCache();
			if (isChatShown)
			{
				InstantiateChatMessages();
			}
		}
	}

	private Transform InstantiateChatMessage(int index)
	{
		if (index >= 0 && index < mChatMessages.Count)
		{
			ChatRecord chatRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(chatRecordPrefab, chatTable.gameObject, index.ToString("'chatRecord '0")) as ChatRecord;
			if (chatRecord != null)
			{
				try
				{
					chatRecord.InitChatMessage(mChatMessages[index]);
				}
				catch (Exception)
				{
					chatRecord.InitEmpty();
				}
				return chatRecord.transform;
			}
		}
		return null;
	}

	private void FreeChatMessage(Transform obj)
	{
		if (obj != null)
		{
			ChatRecord component = obj.GetComponent<ChatRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private float GetChatMessageHeight(int index, Transform trans)
	{
		if (trans != null)
		{
			ChatRecord component = trans.GetComponent<ChatRecord>();
			if (component != null)
			{
				return component.Height;
			}
		}
		if (index >= 0 && index < mChatMessages.Count)
		{
			if (mChatMessages[index].chatRecordHeight <= 10f)
			{
				chatRecordForHeight.InitializeForHeightOnly(mChatMessages[index]);
				Chat.ChatRecordData value = mChatMessages[index];
				value.chatRecordHeight = chatRecordForHeight.Height;
				mChatMessages[index] = value;
			}
			return mChatMessages[index].chatRecordHeight;
		}
		return 0f;
	}

	public void InstanceOnMessagesArrived(string channel, Chat.ChatRecordData[] messages)
	{
		bool flag = false;
		bool flag2 = Singleton<Chat>.instance.IsCorrectChannel(channel, mSelectedChannelIndex);
		bool flag3 = Singleton<Chat>.instance.IsSquadChannel(channel);
		bool flag4 = mNearTopOfChat;
		if (flag3)
		{
			int lastSeenSquadChatTimeStamp = PlayerAnalytics.instance.lastSeenSquadChatTimeStamp;
			int num = 0;
			int num2 = 0;
			int num3 = -1;
			for (int i = 0; i < messages.Length; i++)
			{
				if (messages[i].chatType == Chat.ChatMessageType.Message)
				{
					num2++;
					num3 = i;
				}
				if (mLastSeenMessage == messages[i] || lastSeenSquadChatTimeStamp >= messages[i].time)
				{
					num2 = 0;
				}
				num = Mathf.Max(num, messages[i].time);
			}
			PlayerAnalytics.instance.lastSeenSquadChatTimeStamp = num;
			if (num3 > -1)
			{
				mLastSeenMessage = messages[num3];
			}
			GuiElementSingle<ChatGuiElement>.instance.AddNotificationsToChatButton(num2);
		}
		if (flag2)
		{
			flag = messages.Length == 1 && messages[0].playerId == GameLoginManager.currentPlayer.id && messages[0].chatType == Chat.ChatMessageType.Message;
			int num4 = 0;
			for (int j = 0; j < messages.Length; j++)
			{
				num4++;
				mChatMessages.Add(messages[j]);
			}
			if (isChatShown)
			{
				if (showedContent != ChatLookState.normalChat)
				{
					chatTable.MakeEmpty();
					return;
				}
				chatTable.IncreaseContainItems(num4, align: false);
				if (flag || flag4 || mAligningChatNewMessages)
				{
					AlignTableNextFrame(instant: false);
				}
			}
		}
		if (TimerMessagesAddingToCache() == ChatCacheStatus.BigChange)
		{
			InstantiateChatMessages();
		}
	}

	private void SubmitChatMessage(GameObject go)
	{
		SendChatMessage(go);
	}

	private void SendChatMessage(GameObject go)
	{
		Singleton<Chat>.instance.SendChatMessage(input.text);
		input.text = string.Empty;
	}

	public void InitChat()
	{
		UIEventListener uIEventListener = UIEventListener.Get(sendMessage);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(SendChatMessage));
		UIInputChat uIInputChat = input;
		uIInputChat.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInputChat.onSubmit, (UIInput.OnSubmit)delegate
		{
			SendChatMessage(input.gameObject);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(joinSquadButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JoinSquadClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(createSquadButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CreateSquadClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(loginWithFBButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LoginToFacebook));
		UIEventListener uIEventListener5 = UIEventListener.Get(loginToGooglePlay);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LoginToGoogle));
		foreach (UIButton channelButton in channelButtons)
		{
			UIEventListener uIEventListener6 = UIEventListener.Get(channelButton);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PublicChannelCLick));
		}
		Singleton<Chat>.instance.newArrivedMessages += InstanceOnMessagesArrived;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterByMinute = (Action)Delegate.Combine(instance.updateCounterByMinute, new Action(CheckAndAddTimeMessages));
		GameLoginManager.instance.PlayerLeftSquad += ClearChatCache;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += ClearChatCache;
		PublicChannelCLick(channelButtons[0].gameObject);
		input.defaultText = Localization.Localize("ID_YOUCANTYPEHERE");
		getLabel.text = Localization.Localize("ID_GETSP");
		hintLabel.lineWidth = 590 - ((int)(getLabel.relativeSize.x * getLabel.transform.localScale.x) + 90);
		getHintTable.repositionNow = true;
		UITable uITable = getHintTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnHintTableReposition));
		squadButton.InitControls();
	}

	private void JoinSquadClick(GameObject go)
	{
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
	}

	private void CreateSquadClick(GameObject go)
	{
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
	}

	private void LoginToFacebook(GameObject go)
	{
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		GameLoginManager.instance.LoginToFacebook();
	}

	private void LoginToGoogle(GameObject go)
	{
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		GameLoginManager.instance.LoginToGoogle();
	}

	private void ClearChatCache()
	{
		mSpecialSquadMessages.Clear();
		mChatMessages.Clear();
		if (isSelectedSquadChat)
		{
			chatTable.MakeEmpty();
		}
		SquadBenefitsUpdate();
	}

	public void InitGui()
	{
		SquadBenefitsUpdate();
		channelButtons[1].gameObject.SetActive(value: true);
		channelButtons[0].gameObject.SetActive(value: true);
		Singleton<Chat>.instance.Connect();
	}

	private void SquadBenefitsUpdate()
	{
		getHintTable.repositionNow = true;
	}

	private void OnHintTableReposition()
	{
		if (getLabel.transform.localScale.x != hintLabel.transform.localScale.x)
		{
			getLabel.transform.localScale = hintLabel.transform.localScale;
			hintLabel.lineWidth = 590 - ((int)(getLabel.relativeSize.x * getLabel.transform.localScale.x) + 90);
			getHintTable.repositionNow = true;
		}
		else
		{
			hintsTable.repositionNow = true;
		}
	}

	public void ShowChat(bool enable)
	{
		if (enable)
		{
			bool flag = !isChatShown;
			chatPanel.gameObject.SetActive(value: true);
			chatPanel.isFreezed = false;
			ChatLookState chatLookState = currentContent;
			SetRightContent(chatLookState);
			if (chatLookState == ChatLookState.normalChat)
			{
				if (GuiElementSingle<ChatGuiElement>.instance.anyChatNotifications)
				{
					ShowSquadTab();
				}
				else
				{
					chatTable.MakeEmpty();
					DrawMessages();
				}
			}
			if (flag)
			{
				Debug.Log("Chat Tab: Opening Chat");
				chatPanel.alpha1 = 0.005f;
				TweenAlpha.Begin(chatPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0.005f, 1f).onFinished = null;
				scrollPanel.isFreezed = false;
				scrollPanel.alpha1 = 0.005f;
				TweenAlpha.Begin(scrollPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0.005f, 1f);
				if (createLockedPanel.gameObject.activeSelf)
				{
					createLockedPanel.isFreezed = false;
					createLockedPanel.alpha1 = 0.005f;
					TweenAlpha.Begin(createLockedPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0.005f, 1f);
				}
				if (joinLockedPanel.gameObject.activeSelf)
				{
					joinLockedPanel.isFreezed = false;
					joinLockedPanel.alpha1 = 0.005f;
					TweenAlpha.Begin(joinLockedPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0.005f, 1f);
				}
				squadButton.InitGui();
			}
		}
		else if (isChatShown)
		{
			Debug.Log("Chat Tab: Closing Chat");
			TweenAlpha.Begin(chatPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f).onFinished = delegate
			{
				chatTable.MakeEmpty();
				chatPanel.gameObject.SetActive(value: false);
			};
			TweenAlpha.Begin(scrollPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
			TweenAlpha.Begin(createLockedPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
			TweenAlpha.Begin(joinLockedPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
		}
	}

	public void SetRightContent(ChatLookState contentToShow)
	{
		bannedFromChatContent.SetActive(contentToShow == ChatLookState.bannedUser);
		if (contentToShow == ChatLookState.bannedUser)
		{
			counter.counterLabel.gameObject.SetActive(!mIsForeverBanned);
			topBannerMessage.transform.localPosition = topBannerMessage.transform.localPosition.ReplaceY(((!mIsForeverBanned) ? (-10f) : 0f) - 5f);
			topBannerMessage.text = Localization.Localize((!mIsForeverBanned) ? "ID_GUI_CHAT_BANNED_DESCBOX_TEMP" : "ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT");
			bottomMessage.text = Localization.LocalizeFormat("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING", Localization.Localize((!mIsForeverBanned) ? "ID_TEMPORARY" : "ID_PERMANENT"));
			if (!mIsForeverBanned)
			{
				UpdateBanProgress();
			}
		}
		nonGuestContent.SetActive(contentToShow == ChatLookState.guestNotAllowed);
		chatContent.SetActive(contentToShow == ChatLookState.normalChat || contentToShow == ChatLookState.joinOrCreateSquad);
		inputFieldHolder.SetActive(contentToShow == ChatLookState.normalChat);
		joinOrCreateSquadContent.SetActive(contentToShow == ChatLookState.joinOrCreateSquad);
		if (joinOrCreateSquadContent.activeSelf)
		{
			chatTable.MakeEmpty();
			JoinCreateButtonsLook();
		}
		ShowHeaderWithSquadMessage();
		showedContent = contentToShow;
	}

	private void UpdateBanProgress()
	{
		mSecondsToUnban = ChatBanManager.instance.RemainingBanTime();
		if (mSecondsToUnban > 0)
		{
			counter.StartCounter(mSecondsToUnban);
			WinStreakCounter winStreakCounter = counter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(UpdateBanProgress));
			WinStreakCounter winStreakCounter2 = counter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(UpdateBanProgress));
			return;
		}
		WinStreakCounter winStreakCounter3 = counter;
		winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(UpdateBanProgress));
		counter.StopCounter();
		counter.counterLabel.gameObject.SetActive(value: false);
		if (chatPanel.gameObject.activeInHierarchy)
		{
			SetRightContent(currentContent);
		}
	}

	private void JoinCreateButtonsLook()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = !flag && !isSquadWarsProcessing;
		bool flag3 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		bool flag4 = !flag3 && !isSquadWarsProcessing;
		joinLockedPanel.gameObject.SetActive(!flag2);
		joinLockedObject.SetActive(flag);
		if (!flag2)
		{
			TweenAlpha.Begin(joinLockedPanel.gameObject, 0.1f, 1f, 1f);
		}
		createLockedPanel.gameObject.SetActive(!flag4);
		createLockedObject.SetActive(flag3);
		if (!flag4)
		{
			TweenAlpha.Begin(createLockedPanel.gameObject, 0.1f, 1f, 1f);
		}
	}

	public void ShowError(string errorMessage)
	{
		bool flag = !errorLabel.gameObject.activeSelf;
		errorLabel.gameObject.SetActive(value: true);
		errorLabel.text = $"\n{errorMessage}\n";
		if (flag)
		{
			errorLabel.transform.localPosition = errorLabel.transform.localPosition.ReplaceY(chatTable.topHelperSprite.localPosition.y);
		}
		if (isChatShown)
		{
			AlignTableNextFrame(instant: true);
		}
	}

	public void HideError()
	{
		bool activeSelf = errorLabel.gameObject.activeSelf;
		errorLabel.gameObject.SetActive(value: false);
		if (isChatShown && activeSelf)
		{
			AlignTableNextFrame(instant: true);
		}
	}

	public void ChatConnected()
	{
		chatTable.MakeEmpty();
		HideError();
		DrawMessages();
	}

	private void AlignTableNextFrame(bool instant)
	{
		StopAlign();
		StartAlign(instant);
	}

	private void StartAlign(bool instant)
	{
		if (mAlignWorked == null)
		{
			mAlignWorked = RadicalRoutine.Create(AlignNextFrame(instant));
			StartCoroutine(RadicalRoutine.Run(mAlignWorked.enumerator));
		}
	}

	private void StopAlign()
	{
		if (mAlignWorked != null)
		{
			mAlignWorked.Cancel();
			mAlignWorked = null;
		}
	}

	private IEnumerator AlignNextFrame(bool instant)
	{
		mAligningChatNewMessages = mNearTopOfChat || mAligningChatNewMessages;
		draggablePanel.UpdateScrollbars(recalculateBounds: true);
		yield return null;
		draggablePanel.AlignToPos(instant);
		if (!instant)
		{
			SpringPanel spring = draggablePanel.GetComponent<SpringPanel>();
			while (spring != null && spring.enabled)
			{
				yield return null;
			}
			yield return null;
			draggablePanel.AlignToPos(instant);
		}
		mAligningChatNewMessages = false;
	}

	private void CheckAndAddTimeMessages()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			switch (TimerMessagesAddingToCache())
			{
			case ChatCacheStatus.BigChange:
				Debug.Log("Chat Tab: added time to messages, reinitializing chat messages.");
				InstantiateChatMessages();
				break;
			case ChatCacheStatus.TopAdded:
				Debug.Log("Chat Tab: added time to top.");
				chatTable.IncreaseContainItems(1, align: false);
				break;
			}
		}
	}

	private ChatCacheStatus TimerMessagesAddingToCache()
	{
		ChatCacheStatus chatCacheStatus = ChatCacheStatus.NoChange;
		int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		for (int num2 = mChatMessages.Count - 1; num2 >= 0; num2--)
		{
			bool flag = mChatMessages[num2].chatType == Chat.ChatMessageType.Timer;
			int num3 = Mathf.Abs(num - mChatMessages[num2].time);
			if (mChatMessages.Count - 1 == num2)
			{
				if (flag && num3 < 180)
				{
					mChatMessages.RemoveAt(num2);
					chatCacheStatus = ChatCacheStatus.BigChange;
				}
				else
				{
					if (!flag && num3 > 180)
					{
						mChatMessages.Add(Chat.ChatRecordData.CreateTime(mChatMessages[num2].time));
						chatCacheStatus = ((chatCacheStatus == ChatCacheStatus.NoChange) ? ChatCacheStatus.TopAdded : ChatCacheStatus.BigChange);
					}
					num = mChatMessages[num2].time;
				}
			}
			else
			{
				if (num2 == 0)
				{
					if (flag)
					{
						mChatMessages.RemoveAt(0);
						chatCacheStatus = ChatCacheStatus.BigChange;
					}
					else if (num3 > 180)
					{
						mChatMessages.Insert(1, Chat.ChatRecordData.CreateTime(mChatMessages[0].time));
						chatCacheStatus = ChatCacheStatus.BigChange;
					}
					break;
				}
				if (flag)
				{
					int time = mChatMessages[num2 - 1].time;
					if (Mathf.Abs(num - time) < 180)
					{
						mChatMessages.RemoveAt(num2);
						chatCacheStatus = ChatCacheStatus.BigChange;
					}
					num = time;
				}
				else
				{
					if (num3 > 180)
					{
						mChatMessages.Insert(num2 + 1, Chat.ChatRecordData.CreateTime(mChatMessages[num2].time));
						chatCacheStatus = ChatCacheStatus.BigChange;
					}
					num = mChatMessages[num2].time;
				}
			}
		}
		return chatCacheStatus;
	}

	private void InstantiateChatMessages()
	{
		chatTable.MakeEmpty();
		if (!isChatShown)
		{
			return;
		}
		for (int i = 0; i < mChatMessages.Count; i++)
		{
			if (mChatMessages[i].chatType == Chat.ChatMessageType.SquadAction)
			{
				mChatMessages[i].databaseMessage.messageShown = true;
			}
		}
		mChatMessages.Sort(SortingFunctionForChatData);
		chatTable.Init(mChatMessages.Count, InstantiateChatMessage, FreeChatMessage, GetChatMessageHeight, draggablePanel);
	}

	private int SortingFunctionForChatData(Chat.ChatRecordData data1, Chat.ChatRecordData data2)
	{
		int time = data1.time;
		int time2 = data2.time;
		if (time != time2)
		{
			return time.CompareTo(time2);
		}
		bool flag = data1.chatType != data2.chatType;
		if (data1.chatType == Chat.ChatMessageType.Timer && flag)
		{
			return 1;
		}
		if (data2.chatType == Chat.ChatMessageType.Timer && flag)
		{
			return -1;
		}
		return 0;
	}
}
