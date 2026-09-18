using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SelectFriendsDialog : GuiElementSingle<SelectFriendsDialog>, IGuiDialog
{
	public enum Type
	{
		COOP,
		INVITE,
		FIGHT
	}

	private enum Tab
	{
		Facebook,
		Squad,
		Search
	}

	[Header("Close Button")]
	public UIButton closeButton;

	[Header("Header")]
	public UILabel headerDialog;

	public GameObject coopIcon;

	public GameObject inviteIcon;

	public GameObject fightIcon;

	public List<UIButton> headerButtons;

	[Header("List")]
	public FriendGuiRecord friendGuiRecordPrefab;

	public UIDraggablePanel friendsScrollview;

	public BoxCollider friendsCollider;

	public UIPanel friendsPanel;

	public GameObject waitingPart;

	[Header("-Search Input")]
	public UIInputChat searchInput;

	public UIButton searchButton;

	public UILabel errorLabel;

	public UILabel searchInputHint;

	[Header("-Connect To Facebook")]
	public GameObject facebookPart;

	public UIButton facebookLogin;

	public UITable facebookRewardTable;

	public UILabel facebookRewardNumber;

	public UILabel facebookRewardClaimed;

	public UILabel facebookLabel;

	[Header("-Empty Facebook Friends")]
	public GameObject emptyFacebookPart;

	public UIButton emptyFacebookButton;

	public UILabel emptyFacebookLabel;

	[Header("-Join Or Create Squad")]
	public GameObject squadPart;

	public GameObject joinSquadButton;

	public BoxCollider joinSquadCollider;

	public GameObject soldierIconPart;

	public GameObject firstRewardPart;

	public UILabel getRewardLabel;

	public UILabel rewardValueLabel;

	public GameObject joinLockedPart;

	public UILabel joinUnlockLabel;

	public GameObject createNewSquadButton;

	public BoxCollider createNewSquadCollider;

	public GameObject createLockedPart;

	public UILabel createUnlockLabel;

	[Header("-Empty Squad Friends")]
	public GameObject emptySquadPart;

	public UIButton emptySquadButton;

	public UILabel emptySquadLabel;

	[Header("-Facebook And Squad Results")]
	public UIPooledGrid squadOrFbGrid;

	[Header("-Search Results")]
	public UIPooledGrid searchResultGrid;

	public Action<DatabasePlayer, bool> friendSelected;

	private RadicalRoutine mRoutine;

	private List<DatabasePlayer> mSquadMates = new List<DatabasePlayer>();

	private List<Tuple<bool, DatabasePlayer>> mFacebookFriends = new List<Tuple<bool, DatabasePlayer>>();

	private List<DatabasePlayer> mSearchResults = new List<DatabasePlayer>();

	private bool mSearching;

	private bool mWaitingForFbOrSquad;

	private string mSearchingInput;

	private UIDraggablePanel mPanelToDisable;

	private Tab mSelectedTab = Tab.Search;

	private Type mCurrentType = Type.FIGHT;

	public List<string> mInvitedPlayers = new List<string>();

	public Type currentType => mCurrentType;

	public bool isSquadInviteDialog => mCurrentType == Type.INVITE;

	public static void ShowSquadInviteDialog(Action<DatabasePlayer, bool> friendInvited, UIDraggablePanel draggablePanel, float delay)
	{
		SelectFriendsDialog dialog = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			SelectFriendsDialog selectFriendsDialog = dialog;
			selectFriendsDialog.friendSelected = (Action<DatabasePlayer, bool>)Delegate.Combine(selectFriendsDialog.friendSelected, friendInvited);
			dialog.headerDialog.text = Localization.Localize("ID_INVITETOSQUAD");
			MiscTools.SetUILabelRescale(dialog.headerDialog, 87f, 50f);
			dialog.mPanelToDisable = draggablePanel;
			dialog.mCurrentType = Type.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
	}

	public static void ShowCoopDialog(Action<DatabasePlayer, bool> friendInvited, float delay, string missionName)
	{
		SelectFriendsDialog dialog = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			SelectFriendsDialog selectFriendsDialog = dialog;
			selectFriendsDialog.friendSelected = (Action<DatabasePlayer, bool>)Delegate.Combine(selectFriendsDialog.friendSelected, friendInvited);
			dialog.headerDialog.text = Localization.LocalizeFormat("ID_MISSIONCOOPPARTNER", missionName, Colours.stringBlue);
			MiscTools.SetUILabelRescale(dialog.headerDialog, 87f, 50f);
			dialog.mPanelToDisable = null;
			dialog.mCurrentType = Type.COOP;
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
	}

	public static void ShowFightFriendsDialog(Action<DatabasePlayer, bool> friendInvited, float delay)
	{
		SelectFriendsDialog dialog = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			SelectFriendsDialog selectFriendsDialog = dialog;
			selectFriendsDialog.friendSelected = (Action<DatabasePlayer, bool>)Delegate.Combine(selectFriendsDialog.friendSelected, friendInvited);
			dialog.headerDialog.text = Localization.LocalizeFormat("ID_CHALLENGEYOURFRIEND", Colours.stringRedEnemy);
			MiscTools.SetUILabelRescale(dialog.headerDialog, 87f, 50f);
			dialog.mPanelToDisable = null;
			dialog.mCurrentType = Type.FIGHT;
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(searchButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(SearchButtonClick));
		UIInputChat uIInputChat = searchInput;
		uIInputChat.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInputChat.onSubmit, new UIInput.OnSubmit(OnInputSubmit));
		UIEventListener uIEventListener3 = UIEventListener.Get(facebookLogin.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FacebookLoginClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(emptyFacebookButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FacebookInviteClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(emptySquadButton.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(SquadInviteClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(joinSquadButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JoinSquadClick));
		UIEventListener uIEventListener7 = UIEventListener.Get(createNewSquadButton);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(CreateNewSquadClick));
		foreach (UIButton headerButton in headerButtons)
		{
			UIEventListener uIEventListener8 = UIEventListener.Get(headerButton.gameObject);
			uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.SquadWarProcessingChanged = (Action)Delegate.Combine(serverResultsCache.SquadWarProcessingChanged, new Action(SquadProcessingChanged));
	}

	public override void InitControls()
	{
		searchInput.maxChars = DatabasePlayer.maxPlayerName;
		searchInput.defaultText = Localization.Localize("ID_EMPTYSEARCHPLAYER");
		facebookRewardTable.onReposition = delegate
		{
			float val = 0f - facebookRewardTable.padding.x - (facebookRewardNumber.transform.parent.transform.localPosition.x - facebookRewardTable.padding.x) / 2f + 60f;
			facebookRewardTable.transform.localPosition = facebookRewardTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void CloseButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (friendSelected != null)
			{
				friendSelected(null, arg2: false);
				friendSelected = null;
			}
			if (mCurrentType == Type.COOP)
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<MissionDialog>.instance, 0f);
			}
		}
	}

	private void SearchButtonClick(GameObject go)
	{
		OnInputSubmit(searchInput.text);
	}

	private void OnInputSubmit(string inputString)
	{
		if (inputString.Length < 4)
		{
			if (inputString.Length > 0)
			{
				StopUpdatingPlayersInSearch();
				searchInputHint.gameObject.SetActive(value: false);
				ShowError(Localization.Localize("ID_SELECTFRIENDERRORSHORTNAME"));
				friendsScrollview.UpdateScrollbars(recalculateBounds: true);
				friendsScrollview.AlignToPos(instant: true);
			}
		}
		else
		{
			searchInputHint.gameObject.SetActive(value: false);
			mSearchResults.Clear();
			searchResultGrid.MakeEmpty();
			searchResultGrid.SetHelpersToTheSamePosition();
			errorLabel.gameObject.SetActive(value: false);
			mSearching = true;
			waitingPart.SetActive(mSearching);
			mSearchingInput = inputString;
			Singleton<BeanstalkServerManager>.instance.SearchPlayers(inputString);
		}
	}

	private void FacebookLoginClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void FacebookInviteClick(GameObject go)
	{
		GameLoginManager.instance.InviteFacebookFriends();
	}

	private void JoinSquadClick(GameObject go)
	{
		if (base.isFullyShowed && (DebugSettings.debugEnabled || !joinLockedPart.activeSelf))
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void SquadInviteClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		ShowSquadInviteDialog(delegate(DatabasePlayer friend, bool b)
		{
			if (friend != null)
			{
				DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
				if (friend.squadName == currentPlayer.squadName)
				{
					ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", friend.name), 0f);
				}
				else
				{
					DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
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
		}, mPanelToDisable, fadeOutTime + 0.1f);
	}

	private void CreateNewSquadClick(GameObject go)
	{
		if (base.isFullyShowed && (DebugSettings.debugEnabled || !createLockedPart.activeSelf))
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	private void HeaderButtonClick(GameObject go)
	{
		UIButton button = go.GetComponentsInChildren<UIButton>(includeInactive: true)[0];
		int num = headerButtons.FindIndex((UIButton a) => a == button);
		mSelectedTab = (Tab)num;
		for (int num2 = 0; num2 < headerButtons.Count; num2++)
		{
			SelectFriendsButton component = headerButtons[num2].gameObject.GetComponent<SelectFriendsButton>();
			component.SetHighlight(num2 == (int)mSelectedTab);
		}
		DisplayContent();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			switch (action)
			{
			case DatabaseAction.GetFriendsInfo:
				OnFriendsInfo();
				break;
			case DatabaseAction.SearchPlayers:
				OnSearchResult();
				break;
			}
		}
	}

	private void OnFriendsInfo()
	{
		if (mFacebookFriends.Count > 0 && mSelectedTab == Tab.Facebook)
		{
			UpdateFacebookStatuses(Singleton<ServerResultsCache>.instance.GetFacebookFriends());
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
			if (squadMembers != null && mSquadMates.Count > 0 && mSelectedTab == Tab.Squad)
			{
				UpdateSquadStatuses(squadMembers);
				return;
			}
		}
		mWaitingForFbOrSquad = false;
		CreateDialogCacheFacebookFriends();
		CreateDialogCacheSquadMates();
		if (mSelectedTab == Tab.Facebook || mSelectedTab == Tab.Squad)
		{
			DisplayContent();
		}
	}

	private void OnSearchResult()
	{
		if (!mSearching && mSearchResults.Count > 0 && mSelectedTab == Tab.Search)
		{
			UpdatePlayerStatuses(Singleton<ServerResultsCache>.instance.playerSearchResult);
			return;
		}
		mSearching = false;
		mSearchResults.Clear();
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.playerSearchResult;
		if (list == null)
		{
			list = new List<DatabasePlayer>();
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (!(list[i].id == GameLoginManager.currentPlayer.id) && !string.IsNullOrEmpty(list[i].name))
			{
				mSearchResults.Add(list[i]);
			}
		}
		mSearchResults.Sort(SortFunctionPlayersWithStatus);
		if (mSelectedTab == Tab.Search)
		{
			DisplayContent();
		}
	}

	private void CreateDialogCacheFacebookFriends()
	{
		mFacebookFriends.Clear();
		foreach (DatabasePlayer facebookFriend in Singleton<ServerResultsCache>.instance.GetFacebookFriends())
		{
			mFacebookFriends.Add(new Tuple<bool, DatabasePlayer>(val1: false, facebookFriend));
		}
		if (mFacebookFriends.Count > 0 && mFacebookFriends.Count <= GameVariables.lowFacebookFriends)
		{
			mFacebookFriends.Add(new Tuple<bool, DatabasePlayer>(val1: true, null));
		}
		mFacebookFriends.Sort(TuplePlayerSortFunction);
	}

	private void CreateDialogCacheSquadMates()
	{
		mSquadMates.Clear();
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
		if (squadMembers != null)
		{
			foreach (DatabasePlayer item in squadMembers)
			{
				if (!(item.id == GameLoginManager.currentPlayer.id) && !string.IsNullOrEmpty(item.name))
				{
					mSquadMates.Add(item);
				}
			}
		}
		mSquadMates.Sort(SortFunctionPlayersWithStatus);
	}

	public override void InitGUIValues()
	{
		mInvitedPlayers.Clear();
		SetDialogTo(mCurrentType);
		HideAllParts();
		EmptySearch();
		mSquadMates.Clear();
		mFacebookFriends.Clear();
		InitializeSquadButtonsLook();
		bool flag = true;
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			flag = Singleton<ServerResultsCache>.instance.GetFacebookFriends() != null;
		}
		bool flag2 = true;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			flag2 = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName) != null;
		}
		mWaitingForFbOrSquad = !flag || !flag2;
		Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
		HeaderButtonClick(headerButtons[0].gameObject);
	}

	private void InitializeSquadButtonsLook()
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
		joinSquadCollider.enabled = flag4;
		createNewSquadCollider.enabled = flag5;
		joinUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), joinSquadUnlockLevel);
		createUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		joinLockedPart.SetActive(flag);
		createLockedPart.SetActive(flag2);
	}

	private void SquadProcessingChanged()
	{
		if (isShowed)
		{
			int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
			int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
			bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
			bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
			bool flag2 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
			joinSquadCollider.enabled = !flag && !isSquadWarsProcessing;
			createNewSquadCollider.enabled = !flag2 && !isSquadWarsProcessing;
		}
	}

	private void DisplayContent()
	{
		HideAllParts();
		SetScrollviewPosition();
		if (mSelectedTab == Tab.Search)
		{
			searchInput.gameObject.SetActive(value: true);
			if (mSearching)
			{
				waitingPart.SetActive(value: true);
			}
			else if (!string.IsNullOrEmpty(mSearchingInput))
			{
				if (mSearchResults.Count == 0)
				{
					ShowError(string.Format("{0} {1}", Localization.Localize("ID_SELECTFRIENDERRORNORESULT"), mSearchingInput));
				}
				else
				{
					searchResultGrid.init(mSearchResults.Count, SearchInstantiate, SearchresultFree, friendsScrollview);
					StartUpdatingPlayersInSearch();
				}
			}
		}
		else if (mSelectedTab == Tab.Facebook)
		{
			if (!GameLoginManager.currentPlayer.isFacebookConnected)
			{
				facebookPart.SetActive(value: true);
				bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
				facebookRewardTable.gameObject.SetActive(!flag);
				facebookRewardClaimed.gameObject.SetActive(flag);
				if (!flag)
				{
					facebookRewardTable.repositionNow = true;
					int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
					facebookRewardNumber.text = MiscTools.FormatBigNumber(num);
				}
			}
			else if (mWaitingForFbOrSquad)
			{
				waitingPart.SetActive(value: true);
			}
			else if (mFacebookFriends.Count == 0)
			{
				emptyFacebookPart.SetActive(value: true);
			}
			else
			{
				squadOrFbGrid.init(mFacebookFriends.Count, FacebookInstantiate, SearchresultFree, friendsScrollview);
				StartUpdatingPlayersInSearch();
			}
		}
		else if (mSelectedTab == Tab.Squad)
		{
			if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
			{
				squadPart.SetActive(value: true);
			}
			else if (mWaitingForFbOrSquad)
			{
				waitingPart.SetActive(value: true);
			}
			else if (mSquadMates.Count == 0)
			{
				emptySquadPart.SetActive(value: true);
			}
			else
			{
				squadOrFbGrid.init(mSquadMates.Count, SquadInstantiate, SearchresultFree, friendsScrollview);
				StartUpdatingPlayersInSearch();
			}
		}
		friendsScrollview.UpdateScrollbars(recalculateBounds: true);
		friendsScrollview.AlignToPos(instant: true);
	}

	private void SetScrollviewPosition()
	{
		float num = UIRoot.list[0].activeHeight;
		Transform parent = friendsScrollview.transform.parent;
		Transform parent2 = parent.parent;
		num += parent.localPosition.y + parent2.localPosition.y;
		if (mSelectedTab == Tab.Search)
		{
			num -= 174f;
		}
		float num2 = 0f;
		if (mSelectedTab == Tab.Search)
		{
			num2 -= 174f;
		}
		friendsScrollview.transform.localPosition = new Vector3(0f, num2, -2f);
		friendsCollider.size = friendsCollider.size.ReplaceY(num);
		friendsCollider.center = friendsCollider.center.ReplaceY(num / 2f);
		friendsPanel.clipRange = new Vector4(friendsPanel.clipRange.x, 0f - num / 2f, friendsPanel.clipRange.z, num);
	}

	private void HideAllParts()
	{
		searchResultGrid.MakeEmpty();
		searchResultGrid.SetHelpersToTheSamePosition();
		squadOrFbGrid.MakeEmpty();
		squadOrFbGrid.SetHelpersToTheSamePosition();
		waitingPart.SetActive(value: false);
		facebookPart.SetActive(value: false);
		emptyFacebookPart.SetActive(value: false);
		squadPart.SetActive(value: false);
		emptySquadPart.SetActive(value: false);
		searchInput.gameObject.SetActive(value: false);
		HideError();
		StopUpdatingPlayersInSearch();
		if (mSelectedTab != Tab.Search)
		{
			EmptySearch();
		}
	}

	private void EmptySearch()
	{
		mSearchResults.Clear();
		searchInput.text = string.Empty;
		mSearchingInput = string.Empty;
		mSearching = false;
		searchInputHint.gameObject.SetActive(value: true);
	}

	private void HideError()
	{
		errorLabel.gameObject.SetActive(value: false);
	}

	private void ShowError(string errorMessage)
	{
		errorLabel.gameObject.SetActive(value: true);
		errorLabel.text = errorMessage;
	}

	private Transform SearchInstantiate(int index)
	{
		if (index >= 0 && index < mSearchResults.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(friendGuiRecordPrefab, searchResultGrid.gameObject, index.ToString("'search'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				friendGuiRecord.Initialize(mSearchResults[index]);
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	private Transform FacebookInstantiate(int index)
	{
		if (index >= 0 && index < mFacebookFriends.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(friendGuiRecordPrefab, squadOrFbGrid.gameObject, index.ToString("'friend'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				if (mFacebookFriends[index].Value1)
				{
					friendGuiRecord.InitializeInvite();
				}
				else
				{
					friendGuiRecord.Initialize(mFacebookFriends[index].Value2);
				}
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	private Transform SquadInstantiate(int index)
	{
		if (index >= 0 && index < mSquadMates.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(friendGuiRecordPrefab, squadOrFbGrid.gameObject, index.ToString("'friend'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				friendGuiRecord.Initialize(mSquadMates[index]);
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	private void SearchresultFree(Transform obj)
	{
		if (obj != null)
		{
			FriendGuiRecord component = obj.GetComponent<FriendGuiRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private int SortFunctionPlayersWithStatus(DatabasePlayer a, DatabasePlayer b)
	{
		PlayerStatus realStatus = a.GetRealStatus();
		PlayerStatus realStatus2 = b.GetRealStatus();
		if (realStatus == realStatus2)
		{
			if (string.IsNullOrEmpty(a.name))
			{
				return (!string.IsNullOrEmpty(b.name)) ? 1 : 0;
			}
			return a.name.CompareTo(b.name);
		}
		if (realStatus == PlayerStatus.Online)
		{
			return -1;
		}
		if (realStatus2 == PlayerStatus.Online)
		{
			return 1;
		}
		if (realStatus == PlayerStatus.Offline)
		{
			return 1;
		}
		return -1;
	}

	private int TuplePlayerSortFunction(Tuple<bool, DatabasePlayer> tuple1, Tuple<bool, DatabasePlayer> tuple2)
	{
		if (tuple1.Value1)
		{
			return -1;
		}
		if (tuple2.Value1)
		{
			return 1;
		}
		PlayerStatus realStatus = tuple1.Value2.GetRealStatus();
		PlayerStatus realStatus2 = tuple2.Value2.GetRealStatus();
		if (realStatus == realStatus2)
		{
			if (string.IsNullOrEmpty(tuple1.Value2.name))
			{
				return (!string.IsNullOrEmpty(tuple2.Value2.name)) ? 1 : 0;
			}
			return tuple1.Value2.name.CompareTo(tuple2.Value2.name);
		}
		if (realStatus == PlayerStatus.Online)
		{
			return -1;
		}
		if (realStatus2 == PlayerStatus.Online)
		{
			return 1;
		}
		if (realStatus == PlayerStatus.Offline)
		{
			return 1;
		}
		return -1;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		headerDialog.alpha = 0.9f;
		searchResultGrid.gameObject.SetActive(value: true);
		squadOrFbGrid.gameObject.SetActive(value: true);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		friendsScrollview.UpdateScrollbars(recalculateBounds: true);
		friendsScrollview.AlignToPos(instant: true);
		friendsScrollview.forceDrag = true;
		if (mPanelToDisable != null)
		{
			mPanelToDisable.onePanelDisabled = true;
		}
		UIDraggablePanel.panelDisabled = true;
		TweenAlpha.Begin(squadPart, 0.1f, 1f, 1f);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mPanelToDisable != null)
		{
			mPanelToDisable.onePanelDisabled = false;
			mPanelToDisable = null;
		}
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		searchResultGrid.MakeEmpty();
		searchResultGrid.SetHelpersToTheSamePosition();
		squadOrFbGrid.MakeEmpty();
		squadOrFbGrid.SetHelpersToTheSamePosition();
		mSquadMates.Clear();
		mFacebookFriends.Clear();
		mSearchResults.Clear();
		friendSelected = null;
	}

	public void Select(DatabasePlayer player)
	{
		bool flag = mCurrentType == Type.INVITE;
		if (friendSelected != null)
		{
			Debug.Log("Selected " + player.name);
			friendSelected(player, arg2: true);
			SoundsManager.Instance.PlayButtonClickedSound();
			if (!flag)
			{
				friendSelected = null;
			}
		}
		if (flag)
		{
			SetPlayerWasInviteToSquad(player.id);
		}
		else
		{
			HideDialog();
		}
	}

	private void StartUpdatingPlayersInSearch()
	{
		StopUpdatingPlayersInSearch();
		mRoutine = RadicalRoutine.Create(UpdatePlayerList());
		StartCoroutine(mRoutine.enumerator);
	}

	private void StopUpdatingPlayersInSearch()
	{
		if (mRoutine != null)
		{
			mRoutine.Cancel();
			mRoutine = null;
		}
	}

	private IEnumerator UpdatePlayerList()
	{
		while (true)
		{
			yield return new WaitForSeconds(20f);
			if (GameLoginManager.instance.IsLoggedToFacebook)
			{
				GameLoginManager.instance.RefreshFriends();
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
			}
		}
	}

	private void UpdatePlayerStatuses(List<DatabasePlayer> newData)
	{
		DatabasePlayer player;
		foreach (DatabasePlayer newDatum in newData)
		{
			player = newDatum;
			int num = mSearchResults.FindIndex((DatabasePlayer p1) => p1.id == player.id);
			if (num > -1)
			{
				mSearchResults[num] = player;
			}
		}
		mSearchResults.Sort(SortFunctionPlayersWithStatus);
		for (int num2 = 0; num2 < searchResultGrid.containItems; num2++)
		{
			Transform itemOnIndex = searchResultGrid.GetItemOnIndex(num2);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.Initialize(mSearchResults[num2]);
				}
			}
		}
	}

	private void UpdateFacebookStatuses(List<DatabasePlayer> newData)
	{
		int num = mFacebookFriends.Count;
		if (num < 6)
		{
			num--;
		}
		else if (num == 6)
		{
			foreach (Tuple<bool, DatabasePlayer> mFacebookFriend in mFacebookFriends)
			{
				if (mFacebookFriend.Value1)
				{
					num--;
				}
			}
		}
		if (newData.Count != num)
		{
			CreateDialogCacheFacebookFriends();
			DisplayContent();
			return;
		}
		DatabasePlayer player;
		foreach (DatabasePlayer newDatum in newData)
		{
			player = newDatum;
			int num2 = mFacebookFriends.FindIndex((Tuple<bool, DatabasePlayer> p1) => !p1.Value1 && p1.Value2.id == player.id);
			if (num2 > -1)
			{
				mFacebookFriends[num2].Value2 = player;
			}
		}
		mFacebookFriends.Sort(TuplePlayerSortFunction);
		for (int num3 = 0; num3 < squadOrFbGrid.containItems; num3++)
		{
			Transform itemOnIndex = squadOrFbGrid.GetItemOnIndex(num3);
			if (!(itemOnIndex != null))
			{
				continue;
			}
			FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
			if (component != null)
			{
				component.FreeTexture();
				if (mFacebookFriends[num3].Value1)
				{
					component.InitializeInvite();
				}
				else
				{
					component.Initialize(mFacebookFriends[num3].Value2);
				}
			}
		}
	}

	private void UpdateSquadStatuses(List<DatabasePlayer> newData)
	{
		int num = mSquadMates.Count + 1;
		if (newData.Count != num)
		{
			CreateDialogCacheSquadMates();
			DisplayContent();
			return;
		}
		DatabasePlayer player;
		foreach (DatabasePlayer newDatum in newData)
		{
			player = newDatum;
			int num2 = mSquadMates.FindIndex((DatabasePlayer p1) => p1.id == player.id);
			if (num2 > -1)
			{
				mSquadMates[num2] = player;
			}
		}
		mSquadMates.Sort(SortFunctionPlayersWithStatus);
		for (int num3 = 0; num3 < squadOrFbGrid.containItems; num3++)
		{
			Transform itemOnIndex = squadOrFbGrid.GetItemOnIndex(num3);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.Initialize(mSquadMates[num3]);
				}
			}
		}
	}

	private void ChangePrefabsToCurrentType()
	{
		for (int i = 0; i < squadOrFbGrid.containItems; i++)
		{
			Transform itemOnIndex = squadOrFbGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.ChangeLook(mCurrentType);
				}
			}
		}
		for (int j = 0; j < searchResultGrid.containItems; j++)
		{
			Transform itemOnIndex2 = searchResultGrid.GetItemOnIndex(j);
			if (itemOnIndex2 != null)
			{
				FriendGuiRecord component2 = itemOnIndex2.GetComponent<FriendGuiRecord>();
				if (component2 != null)
				{
					component2.ChangeLook(mCurrentType);
				}
			}
		}
	}

	private void SetDialogTo(Type type)
	{
		mCurrentType = type;
		coopIcon.SetActive(type == Type.COOP);
		inviteIcon.SetActive(type == Type.INVITE);
		fightIcon.SetActive(type == Type.FIGHT);
		bool flag = type == Type.INVITE;
		headerButtons[0].GetComponent<SelectFriendsButton>().SetSize(flag);
		headerButtons[1].gameObject.SetActive(!flag);
		headerButtons[1].GetComponent<SelectFriendsButton>().SetInactiveSquad(flag);
		headerButtons[2].GetComponent<SelectFriendsButton>().SetSize(flag);
		switch (type)
		{
		case Type.COOP:
			facebookLabel.text = Localization.Localize("ID_FACEBOOKHINT-COOP");
			emptyFacebookLabel.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-COOP");
			emptySquadLabel.text = Localization.Localize("ID_SQUADEMPTYTEXT-COOP");
			break;
		case Type.FIGHT:
			facebookLabel.text = Localization.Localize("ID_FACEBOOKHINT-FIGHT");
			emptyFacebookLabel.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-FIGHT");
			emptySquadLabel.text = Localization.Localize("ID_SQUADEMPTYTEXT-FIGHT");
			break;
		case Type.INVITE:
			facebookLabel.text = Localization.Localize("ID_FACEBOOKHINT-SQUADINVITE");
			emptyFacebookLabel.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE");
			break;
		}
		ChangePrefabsToCurrentType();
	}

	private void SetPlayerWasInviteToSquad(string playerId)
	{
		if (!string.IsNullOrEmpty(playerId) && !mInvitedPlayers.Contains(playerId))
		{
			mInvitedPlayers.Add(playerId);
		}
	}

	public bool WasPlayerInvited(DatabasePlayer player)
	{
		return player != null && !string.IsNullOrEmpty(player.id) && mInvitedPlayers.Contains(player.id);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseButtonClick(closeButton.gameObject);
	}
}
