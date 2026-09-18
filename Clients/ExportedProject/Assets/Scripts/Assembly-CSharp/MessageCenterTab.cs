using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenterTab : Core_BaseScript
{
	public enum MessageCenterType
	{
		SQUAD = 1,
		PLAYER,
		SYSTEM
	}

	public class AdditionalData
	{
		public string iconName;

		public MessageCenterType type;

		public string headerText;

		public string messageText;

		public AdditionalData(string ico, MessageCenterType typ, string header, string message)
		{
			iconName = ico;
			type = typ;
			headerText = header;
			messageText = message;
		}
	}

	[Header("Message Center")]
	public UIPanel messageContent;

	[Header("Message List")]
	public MessageCenterRecord messageRecordPrefab;

	public UIPooledTableSimplified tablePooled;

	public UIDraggablePanel draggablePanel;

	public UIPanel scrollPanel;

	[Header("Filter Buttons")]
	public UITable filtersTable;

	public List<MessageCenterFilterButton> filters;

	[Header("AssignmentsPart")]
	public AssignmentsTab assignmentsPart;

	public static Dictionary<DatabaseMessage.Type, AdditionalData> messageInfo = new Dictionary<DatabaseMessage.Type, AdditionalData>
	{
		{
			DatabaseMessage.Type.Challenge,
			new AdditionalData("menu-sidetab-invite-game", MessageCenterType.PLAYER, "ID_GUI_GAMEINVITATION", "ID_GUI_INVITETOFIGHT")
		},
		{
			DatabaseMessage.Type.CheatWarning,
			new AdditionalData("menu-exmark", MessageCenterType.PLAYER, "ID_GUI_CHEATWARNING", "ID_GUI_CHEATINGMESSAGE")
		},
		{
			DatabaseMessage.Type.LeagueEntered,
			new AdditionalData(string.Empty, MessageCenterType.PLAYER, "ID_GUI_LEAGUE", "ID_GUI_HASBEENASSIGNED")
		},
		{
			DatabaseMessage.Type.InformSquadLeaderAboutEvent,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_SQUADEVENT", "ID_GUI_INFORMLEADERTEXT")
		},
		{
			DatabaseMessage.Type.SquadDemotion,
			new AdditionalData("menu-sidetab-player-demote", MessageCenterType.SQUAD, "ID_GUI_SQUADDEMOTION", "ID_GUI_SQUADDEMOTIONTEXT")
		},
		{
			DatabaseMessage.Type.UnitReadyForPromotion,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_SQUADEVENT", "ID_GUI_SQUADCHALLENGEENTERED")
		},
		{
			DatabaseMessage.Type.SquadEventTierReward,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_SQUADEVENT", "ID_GUI_TIERCOMPLETED")
		},
		{
			DatabaseMessage.Type.WelcomBackSoldierMessage,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_SQUADEVENT", "ID_GUI_SQUADCHALLENGEENDED")
		},
		{
			DatabaseMessage.Type.SquadInvitation,
			new AdditionalData("menu-sidetab-invite", MessageCenterType.SQUAD, "ID_GUI_SQUADINVITATION", "ID_GUI_INVITETOSQUAD")
		},
		{
			DatabaseMessage.Type.SquadJoined,
			new AdditionalData("menu-sidetab-joinedsquad", MessageCenterType.SQUAD, "ID_SQUADEVENT", "ID_GUI_JOINEDOURSQUAD")
		},
		{
			DatabaseMessage.Type.SquadJoinRequest,
			new AdditionalData("menu-sidetab-player-add", MessageCenterType.SQUAD, "ID_GUI_ACCEPT_PLAYER", "ID_GUI_ACCEPT_PLAYER_WTJ")
		},
		{
			DatabaseMessage.Type.SquadPromotion,
			new AdditionalData("menu-sidetab-player-promote", MessageCenterType.SQUAD, "ID_GUI_SQUADPROMOTE", "ID_GUI_SQUADPROMOTETEXT")
		},
		{
			DatabaseMessage.Type.SquadLevelUp,
			new AdditionalData("menu-squadrank-ico", MessageCenterType.SQUAD, "ID_GUI_SQUADRANKUP", "ID_GUI_SQUADLEVELEDUP")
		},
		{
			DatabaseMessage.Type.SquadWarEnd,
			new AdditionalData("menu-squadpoint-ico", MessageCenterType.SQUAD, "ID_GUI_SQUADWARSEND", "ID_GUI_SQUADWARSENDNOREWARD")
		},
		{
			DatabaseMessage.Type.SquadDepositedCardsChanged,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_YOURWARCARDWITHDREW", "ID_REPUTATIONSMALL")
		},
		{
			DatabaseMessage.Type.DepositWarcards,
			new AdditionalData(string.Empty, MessageCenterType.SQUAD, "ID_HEYDEPOSITSOMEWARCARDS", "ID_WANTSYOUTODEPOSITTOCARDPOOL")
		},
		{
			DatabaseMessage.Type.BeAdvisedConnectFacebook,
			new AdditionalData("menu-tilegfx-facebook", MessageCenterType.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_CONNECTFB")
		},
		{
			DatabaseMessage.Type.BeAdvisedJoinOrCreateSquad,
			new AdditionalData(string.Empty, MessageCenterType.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_JORCSQUAD")
		},
		{
			DatabaseMessage.Type.BeAdvisedPurchaseVIP,
			new AdditionalData("menu-hub-multiplayer-vipico", MessageCenterType.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_PURCHASEVIP")
		},
		{
			DatabaseMessage.Type.FollowUsOnTwitter,
			new AdditionalData("menu-twitter", MessageCenterType.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_FOLLOWTWITTER_DESC")
		},
		{
			DatabaseMessage.Type.LikeUsOnFacebook,
			new AdditionalData("menu-tilegfx-facebook", MessageCenterType.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_LIKEFB_DESC")
		},
		{
			DatabaseMessage.Type.EnablePushNotificationMessage,
			new AdditionalData(string.Empty, MessageCenterType.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_RATEWFNOW_DESC")
		},
		{
			DatabaseMessage.Type.SystemMessage,
			new AdditionalData("menu-sidetab-servermaintenance-ico", MessageCenterType.SYSTEM, "ID_GUI_SYSTEMMAINTENANCE", "ID_GUI_SYSTEMMAINTENANCE_DESC")
		},
		{
			DatabaseMessage.Type.TweetAboutWarfriends,
			new AdditionalData("menu-twitter", MessageCenterType.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_TWEETABOUT_DESC")
		},
		{
			DatabaseMessage.Type.VIPMemeberShipAlmostEnded,
			new AdditionalData("menu-hub-multiplayer-vipico", MessageCenterType.SYSTEM, "ID_GUI_VIPMEMBERSHIP", "ID_GUI_VIPMEMBERSHIPALMOST_DESC")
		},
		{
			DatabaseMessage.Type.VIPMembershipExpired,
			new AdditionalData("menu-hub-multiplayer-vipico", MessageCenterType.SYSTEM, "ID_GUI_VIPMEMBERSHIP", "ID_GUI_VIPMEMBERSHIPEXPIRED_DESC")
		},
		{
			DatabaseMessage.Type.TimeLimitedOffer,
			new AdditionalData(string.Empty, MessageCenterType.SYSTEM, "ID_GUI_TIMELIMITEDOFFER", "ID_GUI_TIMELIMITEDOFFER_DESC")
		},
		{
			DatabaseMessage.Type.StarterPackTimeLimitedOffer,
			new AdditionalData(string.Empty, MessageCenterType.SYSTEM, "ID_GUI_TIMELIMITEDOFFER", "ID_GUI_STARTERPACKTIMELIMITEDOFFER_DESC")
		},
		{
			DatabaseMessage.Type.InGameMessage,
			new AdditionalData("menu-sidetab-messageicon", MessageCenterType.SYSTEM, "ID_GUI_MESSAGEFORYOU", string.Empty)
		}
	};

	private bool mIsActive;

	private bool mInitialized;

	private MessageCenterFilterButton mSelectedFilter;

	private List<DatabaseMessage> mShowingCache = new List<DatabaseMessage>();

	private MessageCenterRecord mMessageCenterRecordForHeight;

	private Dictionary<string, DatabaseMessage> mNotificationCenterCache;

	public MessageCenterRecord messageCenterRecordForHeight
	{
		get
		{
			if (mMessageCenterRecordForHeight == null)
			{
				mMessageCenterRecordForHeight = UnityEngine.Object.Instantiate(messageRecordPrefab);
				mMessageCenterRecordForHeight.transform.parent = base.transform;
				mMessageCenterRecordForHeight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth, -UIRoot.list[0].activeHeight, 0f);
				mMessageCenterRecordForHeight.transform.localScale = Vector3.one;
			}
			return mMessageCenterRecordForHeight;
		}
	}

	public List<string> messageBuddies
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, DatabaseMessage> item in mNotificationCenterCache)
			{
				if (item.Value is WithdrewWarcard withdrewWarcard && withdrewWarcard.buddyData != null)
				{
					list.Add(withdrewWarcard.cardId);
				}
			}
			CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
			if (cardBuddy != null)
			{
				list.Add(cardBuddy.id);
			}
			return list;
		}
	}

	internal void AddMessage(DatabaseMessage message)
	{
		bool flag = !message.messageShown;
		AddMessageWithoutNotification(message);
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.AddNotificationsToMessageCenterButton(1);
		}
	}

	internal void AddMessageWithoutNotification(DatabaseMessage message)
	{
		Debug.Log("#PETER# NOTIFICATION CENTER - Add message " + message.messageTime + " " + message.messageId + " " + message.messageType.ToString());
		if (!mInitialized)
		{
			InitMessageCenter();
		}
		if (mNotificationCenterCache.ContainsKey(message.messageId))
		{
			Debug.LogError($"DatabaseMessage id: {message.messageId}\t\t type:{message.messageType} already in notification center");
			return;
		}
		mNotificationCenterCache.Add(message.messageId, message);
		InstantiateNewMessage(message);
	}

	internal void RemoveMessage(DatabaseMessage message)
	{
		if (message == null)
		{
			Debug.LogError("Wanted to remove null database message!!!");
			return;
		}
		Debug.Log($"REMOVING {message.messageType}");
		if (mNotificationCenterCache.ContainsKey(message.messageId))
		{
			mNotificationCenterCache.Remove(message.messageId);
			DisplayMessages();
		}
		else
		{
			Debug.LogError("Message " + message.messageId + " " + message.messageTime + " was not found in Notification Center to remove");
		}
		if (mNotificationCenterCache.Count == 0)
		{
			GuiElementSingle<ChatGuiElement>.instance.RemoveOneNotificationFromMessageCenterButton();
		}
	}

	public void InitMessageCenter()
	{
		if (mInitialized)
		{
			return;
		}
		mInitialized = true;
		mNotificationCenterCache = new Dictionary<string, DatabaseMessage>();
		foreach (MessageCenterFilterButton filter in filters)
		{
			UIEventListener uIEventListener = UIEventListener.Get(filter.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ChangeFilter));
		}
		GameLoginManager.instance.PlayerLeftSquad += OnPlayerLeftSquad;
		string txt = Localization.Localize("ID_GUI_ALL") + Localization.Localize("ID_SQUAD") + Localization.Localize("ID_GUI_PLAYER") + Localization.Localize("ID_ASSIGNMENTSSHORT");
		float x = filters[0].filterName.getSizeForString(txt).x;
		float num = 540f;
		float size = Mathf.Clamp(Mathf.Floor(num / x), 25f, 37f);
		filters[0].InitializeFilter(Localization.Localize("ID_GUI_ALL"), size, selected: false);
		filters[1].InitializeFilter(Localization.Localize("ID_SQUAD"), size, selected: false);
		filters[2].InitializeFilter(Localization.Localize("ID_GUI_PLAYER"), size, selected: false);
		filters[3].InitializeFilter(Localization.Localize("ID_ASSIGNMENTSSHORT"), size, selected: false);
		SetIndex();
		filtersTable.repositionNow = true;
		assignmentsPart.InitControls();
	}

	private void ChangeFilter(GameObject go)
	{
		MessageCenterFilterButton filter = go.GetComponentsInChildren<MessageCenterFilterButton>(includeInactive: true)[0];
		int num = filters.FindIndex((MessageCenterFilterButton a) => a == filter);
		for (int num2 = 0; num2 < filters.Count; num2++)
		{
			filters[num2].Select(num2 == num);
		}
		if (num > -1)
		{
			mSelectedFilter = filters[num];
		}
		DisplayMessages(buttonClick: true);
	}

	private void OnPlayerLeftSquad()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, DatabaseMessage> item in mNotificationCenterCache)
		{
			if (messageInfo[item.Value.messageType].type == MessageCenterType.SQUAD && item.Value.canSquadTypeMessageBeRemovedWhenLeftSquad)
			{
				item.Value.Confirm();
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			mNotificationCenterCache.Remove(list[i]);
		}
		list.Clear();
		DisplayMessages();
	}

	private void DisplayMessages(bool buttonClick = false)
	{
		if (!mIsActive)
		{
			return;
		}
		tablePooled.MakeEmpty();
		int num = FilterDataAccordingToFilter();
		scrollPanel.gameObject.SetActive(num != 3);
		assignmentsPart.gameObject.SetActive(num == 3);
		if (num == 3)
		{
			assignmentsPart.InitGUIValues();
			if (buttonClick)
			{
				assignmentsPart.InstaShow();
			}
		}
		else
		{
			tablePooled.Init(mShowingCache.Count, InstantiateMessage, FreeMessage, GetMessageHeight, draggablePanel);
		}
	}

	private int FilterDataAccordingToFilter()
	{
		mShowingCache.Clear();
		int num = filters.FindIndex((MessageCenterFilterButton a) => a == mSelectedFilter);
		if (mNotificationCenterCache == null)
		{
			return num;
		}
		foreach (DatabaseMessage value in mNotificationCenterCache.Values)
		{
			if (num < 1)
			{
				mShowingCache.Add(value);
			}
			else if (num == (int)messageInfo[value.messageType].type)
			{
				mShowingCache.Add(value);
			}
		}
		mShowingCache.Sort((DatabaseMessage m1, DatabaseMessage m2) => m2.messageTime.CompareTo(m1.messageTime));
		return num;
	}

	private void InstantiateNewMessage(DatabaseMessage message)
	{
		int num = filters.FindIndex((MessageCenterFilterButton a) => a == mSelectedFilter);
		if (num < 1 || num == (int)messageInfo[message.messageType].type)
		{
			mShowingCache.Add(message);
			mShowingCache.Sort((DatabaseMessage m1, DatabaseMessage m2) => m2.messageTime.CompareTo(m1.messageTime));
			DisplayMessages();
		}
	}

	private Transform InstantiateMessage(int index)
	{
		if (index >= 0 && index < mShowingCache.Count)
		{
			MessageCenterRecord messageCenterRecord = (MessageCenterRecord)Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(messageRecordPrefab, tablePooled.gameObject, $"Message {index}");
			if (messageCenterRecord != null)
			{
				messageCenterRecord.Initialize(mShowingCache[index]);
				return messageCenterRecord.transform;
			}
		}
		return null;
	}

	private void FreeMessage(Transform obj)
	{
		if (obj != null)
		{
			MessageCenterRecord component = obj.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private float GetMessageHeight(int index, Transform trans)
	{
		if (trans != null)
		{
			MessageCenterRecord component = trans.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				return component.height;
			}
		}
		if (index >= 0 && index < mShowingCache.Count)
		{
			messageCenterRecordForHeight.Initialize(mShowingCache[index], forCountingHeight: true);
			float height = messageCenterRecordForHeight.height;
			messageCenterRecordForHeight.FakeDestroyPooled();
			return height;
		}
		return 0f;
	}

	public void UpdateMessageCenterMessage(string playerId)
	{
		for (int i = 0; i < mShowingCache.Count; i++)
		{
			Transform itemOnIndex = tablePooled.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MessageCenterRecord component = itemOnIndex.GetComponent<MessageCenterRecord>();
				if (component != null)
				{
					component.UpdateAcceptPlayer(playerId);
				}
			}
		}
	}

	public void UpdatePlayerInMessages(DatabasePlayerInfo player)
	{
		foreach (DatabaseMessage value in mNotificationCenterCache.Values)
		{
			if (value.messageType == DatabaseMessage.Type.Challenge || value.messageType == DatabaseMessage.Type.SquadDemotion || value.messageType == DatabaseMessage.Type.SquadInvitation || value.messageType == DatabaseMessage.Type.SquadJoined || value.messageType == DatabaseMessage.Type.SquadJoinRequest || value.messageType == DatabaseMessage.Type.SquadLeft || value.messageType == DatabaseMessage.Type.SquadPromotion)
			{
				value.UpdatePlayer(player);
			}
		}
		foreach (DatabaseMessage item in mShowingCache)
		{
			if (item.messageType == DatabaseMessage.Type.Challenge || item.messageType == DatabaseMessage.Type.SquadDemotion || item.messageType == DatabaseMessage.Type.SquadInvitation || item.messageType == DatabaseMessage.Type.SquadJoined || item.messageType == DatabaseMessage.Type.SquadJoinRequest || item.messageType == DatabaseMessage.Type.SquadLeft || item.messageType == DatabaseMessage.Type.SquadPromotion)
			{
				item.UpdatePlayer(player);
			}
		}
		for (int i = 0; i < mShowingCache.Count; i++)
		{
			Transform itemOnIndex = tablePooled.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MessageCenterRecord component = itemOnIndex.GetComponent<MessageCenterRecord>();
				if (component != null)
				{
					component.Initialize(mShowingCache[i]);
				}
			}
		}
	}

	public void InitGui()
	{
		SetIndex();
		DisplayMessages();
	}

	public void ShowMessageCenter(bool enable)
	{
		if (enable)
		{
			if (!messageContent.gameObject.activeSelf)
			{
				messageContent.gameObject.SetActive(value: true);
				messageContent.isFreezed = false;
				messageContent.alpha1 = 0.005f;
				scrollPanel.isFreezed = false;
				scrollPanel.alpha1 = 0.005f;
				assignmentsPart.AnimatePanels(GuiElementSingle<ChatGuiElement>.instance.duration, 1f);
				TweenAlpha.Begin(scrollPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 1f);
				TweenAlpha.Begin(messageContent.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 1f).onFinished = null;
				mIsActive = true;
			}
			SetCorrectTab();
			DisplayMessages();
		}
		if (enable || !messageContent.gameObject.activeSelf)
		{
			return;
		}
		mIsActive = false;
		assignmentsPart.AnimatePanels(GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
		TweenAlpha.Begin(scrollPanel.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f);
		TweenAlpha.Begin(messageContent.gameObject, GuiElementSingle<ChatGuiElement>.instance.duration, 0f).onFinished = delegate
		{
			if (!mIsActive)
			{
				HideMessageCenter();
			}
		};
	}

	private void SetIndex(int index = 0)
	{
		filters[3].Select(index == 3);
		filters[2].Select(index == 2);
		filters[1].Select(index == 1);
		filters[0].Select(index == 0);
		mSelectedFilter = filters[index];
	}

	private void SetCorrectTab()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool flag = Singleton<NotificationManager>.instance.NotificationStarterAssignments();
		int numberOfAssignmentNotifications = Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		bool flag2 = !isActiveAndNotCompleted && numberOfAssignmentNotifications > 0;
		if (GuiElementSingle<ChatGuiElement>.instance.anyMessageCenterNotifications)
		{
			SetIndex();
		}
		else if (flag || flag2)
		{
			SetIndex(3);
		}
		else if (isActiveAndNotCompleted)
		{
			SetIndex(3);
		}
	}

	private void HideMessageCenter()
	{
		messageContent.gameObject.SetActive(value: false);
		tablePooled.MakeEmpty();
	}
}
