using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadScreen : GuiScreenSingle<SquadScreen>
{
	public enum Tab
	{
		Member,
		Cardpool,
		Event,
		Stats,
		Emblem,
		Info
	}

	[Header("Not In Squad")]
	public GameObject notInSquadContent;

	public UIGrid notInSquadButtonGrid;

	public List<UIButtonSetter> notInSquadButtonSetters;

	[Header("-Join Existing Squad")]
	public GameObject joinSquadButton;

	public BoxCollider joinButtonCollider;

	public GameObject soldierIconPart;

	public GameObject firstRewardPart;

	public UILabel getRewardLabel;

	public UILabel rewardValueLabel;

	public GameObject joinButtonLock;

	public UILabel joinButtonUnlockLabel;

	[Header("-Create New Squad")]
	public GameObject createNewSquadButton;

	public BoxCollider createButtonCollider;

	public GameObject createButtonLock;

	public UILabel createButtonUnlockLabel;

	[Header("-Bottom")]
	public UISprite leftOrnament;

	public UILabel hintLabel;

	public UISprite rightOrnament;

	public GameObject[] hints;

	public UITable hintGetTable;

	public UILabel[] hintLabels;

	[Header("In Squad")]
	public GameObject squadContent;

	public GameObject squadDataLoading;

	[Header("-Header")]
	public UITable nameTable;

	public UITexture squadIcon;

	public UILabel squadName;

	public BoxCollider squadLeaveButtonCollider;

	public UILabel squadLeaveLabel;

	public GameObject inSquadTopRightAnchor;

	public GameObject inviteButton;

	public GameObject squadWarButton;

	public UISprite squadWarIcon;

	[Header("-Squad Buttons")]
	public UITable headerTable;

	public List<SquadButton> headerButtons;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	public SquadButtonCardpool cardpoolButton;

	[Header("Contents")]
	public SquadMemberContent memberContent;

	public SquadCardpoolContent cardpoolContent;

	public SquadEventContent eventContent;

	public SquadStatsContent statsContent;

	public SquadIconContent emblemContent;

	public SquadInformationContent infoContent;

	[Header("Debug")]
	public GameObject debugContent;

	public GameObject addSquadLevel;

	[HideInInspector]
	public float dur = 0.2f;

	private Tab mCurrentTab;

	private bool mFirstInitSquadPart = true;

	private string mSquadIconName;

	private List<Vector3> mLocalPositionHints = new List<Vector3>
	{
		new Vector3(-860f, 0f, 0f),
		new Vector3(40f, 0f, 0f),
		new Vector3(-860f, -68f, 0f),
		new Vector3(40f, -68f, 0f),
		new Vector3(-860f, -136f, 0f),
		new Vector3(40f, -136f, 0f)
	};

	public UIDraggablePanel selectedDragablePanel
	{
		get
		{
			if (mCurrentTab == Tab.Event)
			{
				return eventContent.draggablePanel;
			}
			if (mCurrentTab == Tab.Stats)
			{
				return statsContent.draggablePanel;
			}
			if (mCurrentTab == Tab.Emblem)
			{
				return emblemContent.draggablePanel;
			}
			if (mCurrentTab == Tab.Cardpool)
			{
				return cardpoolContent.draggablePanel;
			}
			return memberContent.draggablePanel;
		}
	}

	public void ShowSquadMembers()
	{
		mCurrentTab = Tab.Member;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowSquadEvent()
	{
		mCurrentTab = Tab.Event;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowSquadStats()
	{
		mCurrentTab = Tab.Stats;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("View_Stats");
	}

	public void ShowSquadEmblem()
	{
		mCurrentTab = Tab.Emblem;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowSquadInfo()
	{
		mCurrentTab = Tab.Info;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowSquadCardpool()
	{
		mCurrentTab = Tab.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.SquadUpdateReceived += OnSquadUpdateReceived;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		GameLoginManager.instance.PlayerJoinedSquad += OnPlayerJoinedSquad;
		GameLoginManager.instance.PlayerLeftSquad += OnPlayerLeftSquad;
		CardManager.instance.WithdrawTimeChanged += CardpoolNotifications;
		Singleton<NotificationManager>.instance.CardpoolNotificationChanged += CardpoolNotifications;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.SquadWarProcessingChanged = (Action)Delegate.Combine(serverResultsCache.SquadWarProcessingChanged, new Action(SetAnimationSquadWar));
	}

	public void OnSquadUpdateReceived(DatabaseSquad squad)
	{
		if (isShowed && squad != null && GameLoginManager.currentPlayer.squadName == squad.name)
		{
			InitSquad(squad);
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!isShowed)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.GetSquadDetails:
		{
			WaitingDialog.Hide();
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer.squadName))
			{
				DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName);
				if (squad == null)
				{
					squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
				}
				if (squad != null)
				{
					InitSquad(squad);
				}
				else
				{
					InitGUIValues();
				}
			}
			else
			{
				InitGUIValues();
			}
			break;
		}
		case DatabaseAction.GetAllSquadMembers:
			ShowHideInviteButton();
			break;
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.GetSquadDetails)
			{
				Debug.LogError("Server Error, no squad details");
				InitGUIValues();
			}
		}
	}

	private void OnPlayerJoinedSquad(string squadName)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OnPlayerLeftSquad()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public void CardpoolNotifications()
	{
		cardpoolButton.SetNotifications(Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications());
	}

	protected override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(joinSquadButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JoinSquadClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(createNewSquadButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CreateNewSquadClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(squadLeaveButtonCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LeaveSquadClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(squadWarButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(SquadWarClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(inviteButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(InviteToSquadClick));
		SetUpButtonsAccordingToWidth();
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		string text = Localization.Localize("ID_MEMBERS") + "22 / 22" + Localization.Localize("ID_CARDPOOL");
		text = text + Localization.Localize("ID_STATS") + Localization.Localize("ID_EMBLEM") + Localization.Localize("ID_INFO");
		float x = headerButtons[0].buttonName.getSizeForString(text).x;
		float activeWidth = UIRoot.list[0].activeWidth;
		int num = 840;
		float num2 = activeWidth - (float)num;
		float num3 = Mathf.Clamp(Mathf.Floor(num2 / x), 25f, 47f);
		for (int i = 0; i < headerButtons.Count; i++)
		{
			headerButtons[i].buttonName.transform.localScale = new Vector3(num3, num3, 1f);
		}
		headerButtons[0].Initialize(Localization.Localize("ID_MEMBERS"), dur);
		headerButtons[1].Initialize(Localization.Localize("ID_CARDPOOL"), dur);
		headerButtons[2].gameObject.SetActive(value: false);
		headerButtons[3].Initialize(Localization.Localize("ID_STATS"), dur);
		headerButtons[4].Initialize(Localization.Localize("ID_EMBLEM"), dur);
		headerButtons[5].Initialize(Localization.Localize("ID_INFO"), dur);
		headerTable.repositionNow = true;
		headerTable.onReposition = delegate
		{
			SetHighlights();
		};
		foreach (SquadButton headerButton in headerButtons)
		{
			UIEventListener uIEventListener6 = UIEventListener.Get(headerButton.gameObject);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		memberContent.InitControls();
		cardpoolContent.InitControls();
		eventContent.InitControls();
		statsContent.InitControls();
		emblemContent.InitControls();
		infoContent.InitControls();
		addSquadLevel.gameObject.SetActive(value: false);
		NotInSquadHintsRescale();
		DebugSettings.instance.Changed += SetDebugButtons;
	}

	private void SetUpButtonsAccordingToWidth()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = activeWidth / 2f - 167f;
		foreach (UIButtonSetter notInSquadButtonSetter in notInSquadButtonSetters)
		{
			notInSquadButtonSetter.SetWidth(num);
		}
		notInSquadButtonGrid.transform.localPosition = notInSquadButtonGrid.transform.localPosition.ReplaceX(0f - (num / 2f + 107f));
		notInSquadButtonGrid.cellWidth = num / 2f + 107f;
		inSquadTopRightAnchor.transform.localPosition = inSquadTopRightAnchor.transform.localPosition.ReplaceX(activeWidth);
	}

	private void JoinSquadClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || !joinButtonLock.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void CreateNewSquadClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || !createButtonLock.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void LeaveSquadClick(GameObject go)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
		if (squad.size == 1)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_DELETESQUAD"), Localization.Localize("ID_CONFIRM_DELETESQUAD_TEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					Singleton<BeanstalkServerManager>.instance.LeaveSquad();
				}
			}, 0f);
			return;
		}
		if (currentPlayer.squadRank == SquadRank.Leader)
		{
			SelectSquadLeaderDialog.ShowSelectNewSquadLeader(delegate(DatabasePlayer player, bool selected)
			{
				if (selected)
				{
					ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", player.name), delegate(ConfirmDialog dialog, bool result)
					{
						if (result)
						{
							Singleton<BeanstalkServerManager>.instance.PromotePlayerToFounder(player);
							Singleton<BeanstalkServerManager>.instance.LeaveSquad();
						}
					}, 0f);
				}
			}, GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel);
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.Localize("ID_CONFIRM_LEAVESQUAD_TEXT"), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				Singleton<BeanstalkServerManager>.instance.LeaveSquad();
			}
		}, 0f);
	}

	private void SquadWarClick(GameObject go)
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowSquadWars();
	}

	public void InviteToSquadClick(GameObject go)
	{
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (!squad.isPublic && flag)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
		}
		else if (squad != null && squad.GetPlacesLeft() <= 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 0f);
		}
		else
		{
			SelectFriendsDialog.ShowSquadInviteDialog(FriendInvited, selectedDragablePanel, 0.2f);
		}
	}

	private void FriendInvited(DatabasePlayer friend, bool b)
	{
		if (friend == null)
		{
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (friend.squadName == currentPlayer.squadName)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", friend.name), 0f);
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
		if (squad != null)
		{
			bool flag = currentPlayer.squadRank == SquadRank.Member;
			if (!squad.isPublic && flag)
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			}
			else if (squad.GetPlacesLeft() <= 0)
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 0f);
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.InvitePlayerToSquad(friend);
			}
		}
	}

	private void HeaderButtonClick(GameObject go)
	{
		SquadButton button = go.GetComponentsInChildren<SquadButton>(includeInactive: true)[0];
		int num = headerButtons.FindIndex((SquadButton a) => a == button);
		if (num >= 0 && !headerButtons[num].pressed)
		{
			SelectTab((Tab)num);
		}
	}

	public override void InitGUIValues()
	{
		SetDebugButtons();
		SetCorrectLook();
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			InitNotInSquad();
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName);
		if (squad == null)
		{
			SetAnimationSquadWar();
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			InitSquad(squad);
		}
	}

	private void SetDebugButtons()
	{
	}

	private void SetCorrectLook()
	{
		bool isPlayerDataLoaded = Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded;
		string value = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(value);
		bool flag2 = flag;
		if (flag2)
		{
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(value);
			if (squad == null)
			{
				squad = Singleton<ServerResultsCache>.instance.GetSquad(value, ommitTime: true);
			}
			flag2 = squad != null;
		}
		bool flag3 = isPlayerDataLoaded && !flag;
		bool flag4 = isPlayerDataLoaded && flag && flag2;
		bool flag5 = !isPlayerDataLoaded || (flag && !flag2);
		if (flag3 != notInSquadContent.activeSelf)
		{
			notInSquadContent.SetActive(flag3);
		}
		if (flag4 != squadContent.activeSelf)
		{
			squadContent.SetActive(flag4);
		}
		if (flag5 != squadDataLoading.activeSelf)
		{
			squadDataLoading.SetActive(flag5);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		memberContent.draggablePanel.onePanelDisabled = false;
		cardpoolContent.draggablePanel.onePanelDisabled = false;
		eventContent.draggablePanel.onePanelDisabled = false;
		statsContent.draggablePanel.onePanelDisabled = false;
		emblemContent.draggablePanel.onePanelDisabled = false;
		mFirstInitSquadPart = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mCurrentTab == Tab.Member)
		{
			memberContent.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.Cardpool)
		{
			cardpoolContent.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.Event)
		{
			eventContent.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.Stats)
		{
			statsContent.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.Emblem)
		{
			emblemContent.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.Info)
		{
			infoContent.Animate(showTab: false, instant: false);
		}
		Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		memberContent.InstantHideTab();
		cardpoolContent.InstantHideTab();
		eventContent.InstantHideTab();
		statsContent.InstantHideTab();
		emblemContent.InstantHideTab();
		infoContent.InstantHideTab();
		CardManager.instance.ResetSquadCards(GuiElementSingle<ChatGuiElement>.instance.messageContent.messageBuddies);
		squadIcon.mainTexture = null;
		mSquadIconName = null;
	}

	private void InitNotInSquad()
	{
		SetCorrectLook();
		NotInSquadButtonsLook();
	}

	private void NotInSquadHintsRescale()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		int width = (int)activeWidth - 220;
		hintLabel.text = Localization.Localize("ID_JOINORCREATESQUADHINT");
		MiscTools.SetUILabelRescale(hintLabel, 47f, 20f, width);
		float num = hintLabel.relativeSize.x * hintLabel.transform.localScale.x;
		float val = Mathf.Max(25f, (activeWidth - (num + 160f)) / 2f);
		float num2 = activeWidth / 2f - 60f;
		leftOrnament.transform.localPosition = leftOrnament.transform.localPosition.ReplaceX(0f - num2);
		rightOrnament.transform.localPosition = rightOrnament.transform.localPosition.ReplaceX(num2);
		leftOrnament.transform.localScale = leftOrnament.transform.localScale.ReplaceX(val);
		rightOrnament.transform.localScale = rightOrnament.transform.localScale.ReplaceX(val);
		hints[0].transform.localPosition = mLocalPositionHints[0];
		hints[1].transform.localPosition = mLocalPositionHints[1];
		hints[2].transform.localPosition = mLocalPositionHints[2];
		hints[3].transform.localPosition = mLocalPositionHints[3];
		hints[4].transform.localPosition = mLocalPositionHints[4];
		hints[5].transform.localPosition = mLocalPositionHints[5];
		float num3 = activeWidth / 2f - 160f;
		hintLabels[0].text = Localization.Localize("ID_GETSP");
		float num4 = 74f + hintLabels[0].relativeSize.x * hintLabels[0].transform.localScale.x;
		hintLabels[1].lineWidth = (int)(num3 - num4);
		hintLabels[2].lineWidth = (int)num3;
		hintLabels[3].lineWidth = (int)num3;
		hintLabels[4].lineWidth = (int)num3;
		hintLabels[5].lineWidth = (int)num3;
		hintLabels[6].lineWidth = (int)num3;
	}

	private void NotInSquadButtonsLook()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		bool flag3 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldRewardFirstTimeSquad);
		soldierIconPart.transform.localPosition = soldierIconPart.transform.localPosition.ReplaceX((!flag3) ? (-100f) : 0f);
		firstRewardPart.SetActive(!flag3);
		if (!flag3)
		{
			getRewardLabel.text = Localization.Localize("ID_SQUADREWARDGET");
			MiscTools.SetUILabelRescale(getRewardLabel, 89f, 30f, 280);
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			rewardValueLabel.text = MiscTools.FormatBigNumber(num);
		}
		bool flag4 = !flag && !isSquadWarsProcessing;
		bool flag5 = !flag2 && !isSquadWarsProcessing;
		joinButtonCollider.enabled = flag4;
		createButtonCollider.enabled = flag5;
		joinButtonUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), joinSquadUnlockLevel);
		createButtonUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		joinButtonLock.SetActive(flag);
		createButtonLock.SetActive(flag2);
		if (hintLabels[0].transform.localScale.x != hintLabels[1].transform.localScale.x)
		{
			hintLabels[0].transform.localScale = hintLabels[1].transform.localScale;
			hintGetTable.repositionNow = true;
		}
	}

	private void SquadProcessingChangedForButtons()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		joinButtonCollider.enabled = !flag && !isSquadWarsProcessing;
		createButtonCollider.enabled = !flag2 && !isSquadWarsProcessing;
		squadLeaveButtonCollider.gameObject.SetActive(!isSquadWarsProcessing);
	}

	private void InitSquad(DatabaseSquad squad)
	{
		if (squad == null)
		{
			InitNotInSquad();
			Debug.LogError("Squad was deleted.");
			return;
		}
		SetCorrectLook();
		SetSquadIcon(squad.icon);
		squadName.text = GameLoginManager.currentPlayer.squadName;
		SetLeaveButton();
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		squadLeaveButtonCollider.gameObject.SetActive(!isSquadWarsProcessing);
		nameTable.repositionNow = true;
		SetAnimationSquadWar();
		SetMembersButton(squad.size, squad.size + squad.GetPlacesLeft(), 0);
		ShowHideInviteButton();
		CardpoolNotifications();
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		cardpoolButton.SetLocked(isWarcardsLocked);
		if (isWarcardsLocked && mCurrentTab == Tab.Cardpool)
		{
			mCurrentTab = Tab.Member;
		}
		if (mFirstInitSquadPart)
		{
			mFirstInitSquadPart = false;
			SelectTab(mCurrentTab, instant: true);
		}
	}

	private void ShowHideInviteButton()
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		bool flag = squad != null && !squad.isPublic;
		bool flag2 = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		inviteButton.gameObject.SetActive(!flag || !flag2);
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
		if (squadMembers == null)
		{
			return;
		}
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		int num = squadMembers.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
		if (num < 0)
		{
			squadMembers.Add(generatedCurrentPlayer);
		}
		for (int num2 = squadMembers.Count - 1; num2 >= 0; num2--)
		{
			if (string.IsNullOrEmpty(squadMembers[num2].name))
			{
				squadMembers.RemoveAt(num2);
			}
		}
		int num3 = 0;
		foreach (DatabasePlayer item in squadMembers)
		{
			if (item.GetRealStatus() != PlayerStatus.Offline)
			{
				num3++;
			}
		}
		SetMembersButton(squad.size, squad.size + squad.GetPlacesLeft(), num3);
	}

	public void SetMembersButton(int membersSize, int squadSize, int onlinePlayers)
	{
		SquadButtonSpecial squadButtonSpecial = headerButtons[0] as SquadButtonSpecial;
		if (squadButtonSpecial != null)
		{
			squadButtonSpecial.InitializeSpecial($"{membersSize} / {squadSize}", mCurrentTab == Tab.Member, mFirstInitSquadPart);
			squadButtonSpecial.SetOnline(onlinePlayers);
			if (onlinePlayers == 0)
			{
				headerTable.repositionNow = true;
			}
		}
	}

	public void SetSquadIcon(string squadIconName)
	{
		if (mSquadIconName != squadIconName)
		{
			Debug.Log($"Setting squad icon: {squadIconName}");
			squadIcon.mainTexture = Resources.Load<Texture>("SquadIcons/" + squadIconName);
			mSquadIconName = squadIconName;
		}
		else
		{
			Debug.Log($"Squad icon: {squadIconName} already displayed");
		}
	}

	private void SetLeaveButton()
	{
		float num = squadLeaveLabel.relativeSize.x * squadLeaveLabel.transform.localScale.x;
		squadLeaveButtonCollider.size = squadLeaveButtonCollider.size.ReplaceX(100f + num);
		squadLeaveButtonCollider.center = squadLeaveButtonCollider.center.ReplaceX((100f + num) / 2f - 30f);
	}

	private void SelectTab(Tab selectedTab, bool instant = false)
	{
		mCurrentTab = selectedTab;
		SetAndAnimateButtons(instant);
		SetAndAnimateHighlights(instant);
		SetAndAnimateContent(instant);
	}

	private void SetAndAnimateButtons(bool instant)
	{
		if (instant)
		{
			for (int i = 0; i < headerButtons.Count; i++)
			{
				headerButtons[i].InstantAnimate(i == (int)mCurrentTab);
			}
			return;
		}
		headerButtons[0].Animate(toHighlight: false);
		headerButtons[1].Animate(toHighlight: false);
		if (headerButtons[2].gameObject.activeSelf)
		{
			headerButtons[2].Animate(toHighlight: false);
		}
		headerButtons[3].Animate(toHighlight: false);
		headerButtons[4].Animate(toHighlight: false);
		headerButtons[5].Animate(toHighlight: false).onFinished = delegate
		{
			headerButtons[(int)mCurrentTab].Animate(toHighlight: true);
		};
	}

	private void SetHighlights()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = headerButtons[(int)mCurrentTab].posX;
		float width = headerButtons[(int)mCurrentTab].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float leftScale = Mathf.Max(28f, 28f + num - 60f);
		float rightScale = Mathf.Max(28f, 28f + (activeWidth - num2) - 60f);
		SetHighlights(leftScale, rightScale);
	}

	private void SetAndAnimateHighlights(bool instant)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = headerButtons[(int)mCurrentTab].posX;
		float width = headerButtons[(int)mCurrentTab].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float leftScale = Mathf.Max(28f, 28f + num - 60f);
		float rightScale = Mathf.Max(28f, 28f + (activeWidth - num2) - 60f);
		bool showLeft = true;
		bool showRight = activeWidth - num2 - 60f > 0f;
		AnimateHighlights(showLeft, leftScale, showRight, rightScale, instant);
	}

	private void SetHighlights(float leftScale, float rightScale)
	{
		leftHighlight.transform.localScale = new Vector3(leftScale, leftHighlight.transform.localScale.y, 0f);
		rightHighlight.transform.localScale = new Vector3(rightScale, rightHighlight.transform.localScale.y, 0f);
	}

	private void AnimateHighlights(bool showLeft, float leftScale, bool showRight, float rightScale, bool instant)
	{
		if (instant)
		{
			SetHighlights(leftScale, rightScale);
			leftHighlight.alpha = ((!showLeft) ? 0f : 1f);
			rightHighlight.alpha = ((!showRight) ? 0f : 1f);
			TweenAlpha component = leftHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			TweenAlpha component2 = rightHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = false;
			}
		}
		else
		{
			TweenAlpha.Begin(leftHighlight.gameObject, dur, 0f);
			TweenAlpha.Begin(rightHighlight.gameObject, dur, 0f).onFinished = delegate
			{
				SetHighlights(leftScale, rightScale);
				TweenAlpha.Begin(leftHighlight.gameObject, dur, (!showLeft) ? 0f : 1f);
				TweenAlpha.Begin(rightHighlight.gameObject, dur, (!showRight) ? 0f : 1f).onFinished = null;
			};
		}
	}

	private void SetAndAnimateContent(bool instant)
	{
		bool flag = mCurrentTab == Tab.Member;
		bool flag2 = mCurrentTab == Tab.Cardpool;
		bool flag3 = mCurrentTab == Tab.Event;
		bool flag4 = mCurrentTab == Tab.Stats;
		bool flag5 = mCurrentTab == Tab.Emblem;
		bool flag6 = mCurrentTab == Tab.Info;
		if (instant)
		{
			memberContent.Animate(flag, instant: true);
			cardpoolContent.Animate(flag2, instant: true);
			eventContent.Animate(flag3, instant: true);
			statsContent.Animate(flag4, instant: true);
			emblemContent.Animate(flag5, instant: true);
			infoContent.Animate(flag6, instant: true);
			return;
		}
		if (memberContent.gameObject.activeSelf && !flag)
		{
			memberContent.Animate(flag, instant: false);
		}
		if (cardpoolContent.gameObject.activeSelf && !flag2)
		{
			cardpoolContent.Animate(flag2, instant: false);
		}
		if (eventContent.gameObject.activeSelf && !flag3)
		{
			eventContent.Animate(flag3, instant: false);
		}
		if (statsContent.gameObject.activeSelf && !flag4)
		{
			statsContent.Animate(flag4, instant: false);
		}
		if (emblemContent.gameObject.activeSelf && !flag5)
		{
			emblemContent.Animate(flag5, instant: false);
		}
		if (infoContent.gameObject.activeSelf && !flag6)
		{
			infoContent.Animate(flag6, instant: false);
		}
		if (!memberContent.gameObject.activeSelf && flag)
		{
			memberContent.Animate(flag, instant: false);
		}
		if (!cardpoolContent.gameObject.activeSelf && flag2)
		{
			cardpoolContent.Animate(flag2, instant: false);
		}
		if (!eventContent.gameObject.activeSelf && flag3)
		{
			eventContent.Animate(flag3, instant: false);
		}
		if (!statsContent.gameObject.activeSelf && flag4)
		{
			statsContent.Animate(flag4, instant: false);
		}
		if (!emblemContent.gameObject.activeSelf && flag5)
		{
			emblemContent.Animate(flag5, instant: false);
		}
		if (!infoContent.gameObject.activeSelf && flag6)
		{
			infoContent.Animate(flag6, instant: false);
		}
		if (memberContent.gameObject.activeSelf && flag)
		{
			memberContent.Animate(flag, instant: false);
		}
		if (cardpoolContent.gameObject.activeSelf && flag2)
		{
			cardpoolContent.Animate(flag2, instant: false);
		}
		if (eventContent.gameObject.activeSelf && flag3)
		{
			eventContent.Animate(flag3, instant: false);
		}
		if (statsContent.gameObject.activeSelf && flag4)
		{
			statsContent.Animate(flag4, instant: false);
		}
		if (emblemContent.gameObject.activeSelf && flag5)
		{
			emblemContent.Animate(flag5, instant: false);
		}
		if (infoContent.gameObject.activeSelf && flag6)
		{
			infoContent.Animate(flag6, instant: false);
		}
	}

	private void SetAnimationSquadWar()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && squadContent.activeSelf)
		{
			if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
			{
				SquadWarIconAnimationEnd();
			}
			else
			{
				SquadWarIconAnimation();
			}
			SquadProcessingChangedForButtons();
		}
	}

	private void SquadWarIconAnimation()
	{
		Vector3 vector = new Vector3(96f, 96f, 1f);
		TweenScale tweenScale = TweenScale.Begin(squadWarIcon.gameObject, 0.4f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private void SquadWarIconAnimationEnd()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(96f, 96f, 1f), go: squadWarIcon.gameObject, duration: 0.2f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}
}
