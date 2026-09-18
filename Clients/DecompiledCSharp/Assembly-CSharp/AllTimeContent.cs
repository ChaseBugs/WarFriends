using System;
using System.Collections.Generic;
using UnityEngine;

public class AllTimeContent : Core_BaseScript
{
	private enum PlayerSelect
	{
		YOURPOSITION,
		TOPPLAYERS,
		FRIENDS
	}

	private enum SquadSelect
	{
		YOURSQUAD,
		TOPSQUADS
	}

	[Header("Panel")]
	public UIPanel buttonsPanel;

	[Header("Switch between Player and Squad Buttons")]
	public SelectStatisticsButton FilterChoiceButtons;

	[Header("Player Buttons")]
	public UITable playerButtons;

	public CheckBoxButton yourPosition;

	public CheckBoxButton topPlayers;

	public CheckBoxButton friends;

	[Header("Squad Buttons")]
	public UITable squadButtons;

	public CheckBoxButton topSquads;

	public CheckBoxButton yourSquad;

	[Header("List Header")]
	public UILabel header2;

	public UILabel header3;

	public UILabel header4;

	public UILabel header5;

	[Header("Leaderboard List")]
	public LeaderboardRecord leaderboardRecordPrefab;

	public UIPooledGrid leaderboardsGrid;

	public UIPanel leaderboardsPanel;

	public UIDraggablePanel draggablePanel;

	public BoxCollider leaderboardsCollider;

	public GameObject waitingSprite;

	[Header("Invite Friends")]
	public GameObject inviteFriendsPart;

	public GameObject inviteFriendsButton;

	private bool mInitializationPhase;

	private List<DatabasePlayer> mDatabaseFriends = new List<DatabasePlayer>();

	private List<DatabasePlayerData> mDatabasePlayer;

	private List<DatabasePlayerData> mDatabasePlayerLocal;

	private List<DatabaseSquad> mDatabaseSquad;

	private List<DatabaseSquad> mDatabaseSquadLocal;

	private bool mPlayerLeaderboard = true;

	private bool mGlobalLeaderboard = true;

	private PlayerSelect mPlayerSelected;

	private SquadSelect mSquadSelected;

	private bool mSendDataForFriend;

	private bool mSendDataForPlayer;

	private bool mSendDataForSquad;

	private float mWidth = 1800f;

	private float mHeaderHeight => Mathf.Abs(base.transform.parent.localPosition.y);

	public void SetPlayerLeaderboard()
	{
		mPlayerLeaderboard = true;
	}

	public void SetSquadLeaderboard()
	{
		mPlayerLeaderboard = false;
	}

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(draggablePanel.gameObject, GuiScreenSingle<LeaguesScreen>.instance.dur * 2f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(buttonsPanel.gameObject, GuiScreenSingle<LeaguesScreen>.instance.dur * 2f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(base.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitEvents()
	{
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.AnyPlayerUpdated = (Action)Delegate.Combine(instance.AnyPlayerUpdated, new Action(AnyPlayerUpdated));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(inviteFriendsButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(InviteFriendsClick));
		yourPosition.Initialize(Localization.Localize("ID_BUTTON_YOU"));
		topPlayers.Initialize(Localization.Localize("ID_BUTTON_TOPPLAYERS"));
		friends.Initialize(Localization.Localize("ID_BUTTON_FRIENDS"));
		playerButtons.repositionNow = true;
		UIEventListener uIEventListener2 = UIEventListener.Get(yourPosition.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(YourPositionClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(topPlayers.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(TopPlayersClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(friends.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FriendsClick));
		yourSquad.Initialize(Localization.Localize("ID_BUTTON_YOURSQUAD"));
		topSquads.Initialize(Localization.Localize("ID_BUTTON_TOPSQUADS"));
		squadButtons.repositionNow = true;
		UIEventListener uIEventListener5 = UIEventListener.Get(yourSquad.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(YourSquadClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(topSquads.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(TopSquadsClick));
		FilterChoiceButtons.Initialize();
		UIEventListener uIEventListener7 = UIEventListener.Get(FilterChoiceButtons.boxCollider.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(ChangePlayerSquadClick));
		UIEventListener uIEventListener8 = UIEventListener.Get(FilterChoiceButtons.globalLocalCollider.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(ChangeGlobalLocalClick));
		SetSizes();
	}

	private void AnyPlayerUpdated()
	{
		if (!GuiScreenSingle<LeaguesScreen>.instance.isShowed || !base.gameObject.activeInHierarchy || !mPlayerLeaderboard)
		{
			return;
		}
		for (int i = 0; i < leaderboardsGrid.containItems; i++)
		{
			Transform itemOnIndex = leaderboardsGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				LeaderboardRecord component = itemOnIndex.GetComponent<LeaderboardRecord>();
				if (component != null)
				{
					component.UpdateSquadNameForPlayer();
				}
			}
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (base.gameObject.activeSelf)
		{
			if (action == DatabaseAction.GetSquadsByExperience)
			{
				OnGetSquadsByExperience();
			}
			if (action == DatabaseAction.GetPlayersByExperience)
			{
				OnGetPlayersByExperience();
			}
			if (action == DatabaseAction.GetFriendsInfo)
			{
				OnGetFriendsInfo();
			}
			if (action == DatabaseAction.GetSquadDetails)
			{
				OnGetSquadDetails();
			}
		}
	}

	private void OnGetSquadsByExperience()
	{
		mSendDataForSquad = false;
		mDatabaseSquad = Singleton<ServerResultsCache>.instance.GetGlobalSquadLeaderboard();
		mDatabaseSquadLocal = Singleton<ServerResultsCache>.instance.GetLocalSquadLeaderboard();
		if (mDatabaseSquad == null)
		{
			mDatabaseSquad = new List<DatabaseSquad>();
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName);
			int num = mDatabaseSquad.FindIndex((DatabaseSquad s1) => s1.name == GameLoginManager.currentPlayer.squadName);
			if (squad != null)
			{
				if (num < 0)
				{
					mDatabaseSquad.Add(squad);
				}
				else
				{
					mDatabaseSquad[num] = squad;
				}
			}
			else if (num > -1)
			{
				mDatabaseSquad[num].icon = GameLoginManager.instance.squadIconName;
			}
		}
		for (int num2 = mDatabaseSquad.Count - 1; num2 >= 0; num2--)
		{
			if (string.IsNullOrEmpty(mDatabaseSquad[num2].name))
			{
				mDatabaseSquad.RemoveAt(num2);
			}
		}
		mDatabaseSquad.Sort(SortFunctionSquads);
		if (mDatabaseSquadLocal == null)
		{
			mDatabaseSquadLocal = new List<DatabaseSquad>();
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			DatabaseSquad squad2 = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName);
			int num3 = mDatabaseSquadLocal.FindIndex((DatabaseSquad s1) => s1.name == GameLoginManager.currentPlayer.squadName);
			if (squad2 != null)
			{
				if (num3 < 0)
				{
					mDatabaseSquadLocal.Add(squad2);
				}
				else
				{
					mDatabaseSquadLocal[num3] = squad2;
				}
			}
			else if (num3 > -1)
			{
				mDatabaseSquadLocal[num3].icon = GameLoginManager.instance.squadIconName;
			}
		}
		for (int num4 = mDatabaseSquadLocal.Count - 1; num4 >= 0; num4--)
		{
			if (string.IsNullOrEmpty(mDatabaseSquadLocal[num4].name))
			{
				mDatabaseSquadLocal.RemoveAt(num4);
			}
		}
		mDatabaseSquadLocal.Sort(SortFunctionSquads);
		if (!mPlayerLeaderboard)
		{
			DisplayRecords();
		}
	}

	private void OnGetPlayersByExperience()
	{
		mSendDataForPlayer = false;
		mDatabasePlayer = Singleton<ServerResultsCache>.instance.GetGlobalPlayerLeaderboard();
		mDatabasePlayerLocal = Singleton<ServerResultsCache>.instance.GetLocalPlayerLeaderboard();
		if (mDatabasePlayer == null)
		{
			mDatabasePlayer = new List<DatabasePlayerData>();
		}
		else
		{
			DatabasePlayerData me = DatabasePlayerData.currentPlayer;
			int num = mDatabasePlayer.FindIndex((DatabasePlayerData p1) => p1.id == me.id);
			if (num == -1)
			{
				mDatabasePlayer.Add(me);
			}
			else
			{
				mDatabasePlayer[num] = me;
			}
			for (int num2 = mDatabasePlayer.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(mDatabasePlayer[num2].name))
				{
					mDatabasePlayer.RemoveAt(num2);
				}
			}
			mDatabasePlayer.Sort(SortFunctionPlayersData);
		}
		if (mDatabasePlayerLocal == null)
		{
			mDatabasePlayerLocal = new List<DatabasePlayerData>();
		}
		else
		{
			DatabasePlayerData me2 = DatabasePlayerData.currentPlayer;
			int num3 = mDatabasePlayerLocal.FindIndex((DatabasePlayerData p1) => p1.id == me2.id);
			if (num3 == -1)
			{
				mDatabasePlayerLocal.Add(me2);
			}
			else
			{
				mDatabasePlayerLocal[num3] = me2;
			}
			for (int num4 = mDatabasePlayerLocal.Count - 1; num4 >= 0; num4--)
			{
				if (string.IsNullOrEmpty(mDatabasePlayerLocal[num4].name))
				{
					mDatabasePlayerLocal.RemoveAt(num4);
				}
			}
			mDatabasePlayerLocal.Sort(SortFunctionPlayersData);
		}
		if (mPlayerLeaderboard && mPlayerSelected != PlayerSelect.FRIENDS)
		{
			DisplayRecords();
		}
	}

	private void OnGetFriendsInfo()
	{
		mSendDataForFriend = false;
		mDatabaseFriends = Singleton<ServerResultsCache>.instance.GetFriends();
		if (mDatabaseFriends == null)
		{
			mDatabaseFriends = new List<DatabasePlayer>();
		}
		else
		{
			int num = mDatabaseFriends.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
			if (num == -1)
			{
				mDatabaseFriends.Add(GameLoginManager.generatedCurrentPlayer);
			}
			else
			{
				mDatabaseFriends[num] = GameLoginManager.generatedCurrentPlayer;
			}
			for (int num2 = mDatabaseFriends.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(mDatabaseFriends[num2].name))
				{
					mDatabaseFriends.RemoveAt(num2);
				}
			}
			mDatabaseFriends.Sort(SortFunctionPlayers);
			List<DatabasePlayer> list = new List<DatabasePlayer>();
			int num3 = 0;
			int num4;
			for (num4 = mDatabaseFriends.Count - 1; num3 < num4; num3++)
			{
				if (mDatabaseFriends[num3].id != mDatabaseFriends[num3 + 1].id)
				{
					list.Add(mDatabaseFriends[num3]);
				}
			}
			list.Add(mDatabaseFriends[num4]);
			mDatabaseFriends = list;
		}
		if (mPlayerLeaderboard && mPlayerSelected == PlayerSelect.FRIENDS)
		{
			DisplayRecords();
		}
	}

	private void OnGetSquadDetails()
	{
		if (mDatabaseSquad != null)
		{
			foreach (DatabaseSquad item in mDatabaseSquad)
			{
				if (item.name == GameLoginManager.currentPlayer.squadName)
				{
					item.icon = GameLoginManager.instance.squadIconName;
				}
			}
		}
		if (mDatabaseSquadLocal == null)
		{
			return;
		}
		foreach (DatabaseSquad item2 in mDatabaseSquadLocal)
		{
			if (item2.name == GameLoginManager.currentPlayer.squadName)
			{
				item2.icon = GameLoginManager.instance.squadIconName;
			}
		}
	}

	private int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (a.skill != b.skill)
		{
			return b.skill.CompareTo(a.skill);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private int SortFunctionPlayersData(DatabasePlayerData a, DatabasePlayerData b)
	{
		if (a.skill != b.skill)
		{
			return b.skill.CompareTo(a.skill);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private int SortFunctionSquads(DatabaseSquad a, DatabaseSquad b)
	{
		if (a.skill != b.skill)
		{
			return b.skill.CompareTo(a.skill);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private void InviteFriendsClick(GameObject go)
	{
		GameLoginManager.instance.InviteFacebookFriends();
	}

	private void ChangePlayerSquadClick(GameObject go)
	{
		mPlayerLeaderboard = !mPlayerLeaderboard;
		playerButtons.gameObject.SetActive(mPlayerLeaderboard);
		squadButtons.gameObject.SetActive(!mPlayerLeaderboard);
		FilterChoiceButtons.Select(mPlayerLeaderboard);
		SetTableHeader();
		DisplayRecords();
	}

	private void ChangeGlobalLocalClick(GameObject go)
	{
		mGlobalLeaderboard = !mGlobalLeaderboard;
		FilterChoiceButtons.SelectGlobalLocal(mGlobalLeaderboard);
		DisplayRecords();
	}

	private void YourPositionClick(GameObject go)
	{
		PlayerSelect playerSelect = mPlayerSelected;
		mPlayerSelected = PlayerSelect.YOURPOSITION;
		yourPosition.SetSelected(mPlayerSelected == PlayerSelect.YOURPOSITION);
		topPlayers.SetSelected(mPlayerSelected == PlayerSelect.TOPPLAYERS);
		friends.SetSelected(mPlayerSelected == PlayerSelect.FRIENDS);
		if (playerSelect == PlayerSelect.FRIENDS)
		{
			DisplayRecords();
		}
		else
		{
			draggablePanel.AlignToCenter(leaderboardsGrid.transform.localPosition + leaderboardsGrid.getPositionForIndex(PositionOfMe()), instant: false);
		}
	}

	private void TopPlayersClick(GameObject go)
	{
		PlayerSelect playerSelect = mPlayerSelected;
		mPlayerSelected = PlayerSelect.TOPPLAYERS;
		yourPosition.SetSelected(mPlayerSelected == PlayerSelect.YOURPOSITION);
		topPlayers.SetSelected(mPlayerSelected == PlayerSelect.TOPPLAYERS);
		friends.SetSelected(mPlayerSelected == PlayerSelect.FRIENDS);
		if (playerSelect == PlayerSelect.FRIENDS)
		{
			DisplayRecords();
		}
		else
		{
			draggablePanel.AlignToPos(instant: false);
		}
	}

	private void FriendsClick(GameObject go)
	{
		mPlayerSelected = PlayerSelect.FRIENDS;
		yourPosition.SetSelected(mPlayerSelected == PlayerSelect.YOURPOSITION);
		topPlayers.SetSelected(mPlayerSelected == PlayerSelect.TOPPLAYERS);
		friends.SetSelected(mPlayerSelected == PlayerSelect.FRIENDS);
		DisplayRecords();
	}

	private void YourSquadClick(GameObject go)
	{
		mSquadSelected = SquadSelect.YOURSQUAD;
		yourSquad.SetSelected(mSquadSelected == SquadSelect.YOURSQUAD);
		topSquads.SetSelected(mSquadSelected == SquadSelect.TOPSQUADS);
		draggablePanel.AlignToCenter(leaderboardsGrid.transform.localPosition + leaderboardsGrid.getPositionForIndex(PositionOfMySquad()), instant: false);
	}

	private void TopSquadsClick(GameObject go)
	{
		mSquadSelected = SquadSelect.TOPSQUADS;
		yourSquad.SetSelected(mSquadSelected == SquadSelect.YOURSQUAD);
		topSquads.SetSelected(mSquadSelected == SquadSelect.TOPSQUADS);
		draggablePanel.AlignToPos(instant: false);
	}

	private void SetSizes()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		float num2 = mHeaderHeight + 142f;
		float num3 = activeWidth - 120f;
		float num4 = num - num2;
		mWidth = num3;
		leaderboardsPanel.clipRange = new Vector4(leaderboardsPanel.clipRange.x, (0f - num4) / 2f, leaderboardsPanel.clipRange.z, num4);
		draggablePanel.transform.localPosition = new Vector3(0f, 0f, draggablePanel.transform.localPosition.z);
		leaderboardsCollider.center = new Vector3(leaderboardsCollider.center.x, (0f - num4) / 2f, leaderboardsCollider.center.z);
		leaderboardsCollider.size = new Vector3(activeWidth, num4, leaderboardsCollider.size.z);
	}

	public void InitGUIValues()
	{
		mInitializationPhase = true;
		yourPosition.SetSelected(mPlayerSelected == PlayerSelect.YOURPOSITION);
		topPlayers.SetSelected(mPlayerSelected == PlayerSelect.TOPPLAYERS);
		friends.SetSelected(mPlayerSelected == PlayerSelect.FRIENDS);
		playerButtons.gameObject.SetActive(mPlayerLeaderboard);
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		if (flag)
		{
			mSquadSelected = SquadSelect.TOPSQUADS;
		}
		yourSquad.gameObject.SetActive(!flag);
		squadButtons.repositionNow = true;
		yourSquad.SetSelected(mSquadSelected == SquadSelect.YOURSQUAD);
		topSquads.SetSelected(mSquadSelected == SquadSelect.TOPSQUADS);
		squadButtons.gameObject.SetActive(!mPlayerLeaderboard);
		FilterChoiceButtons.Select(mPlayerLeaderboard);
		FilterChoiceButtons.SelectGlobalLocal(mGlobalLeaderboard);
		SetTableHeader();
		waitingSprite.SetActive(value: true);
		inviteFriendsPart.SetActive(value: false);
		mSendDataForPlayer = true;
		Singleton<BeanstalkServerManager>.instance.GetPlayersByExperience();
		mSendDataForSquad = true;
		Singleton<BeanstalkServerManager>.instance.GetSquadsByExperience();
		mSendDataForFriend = true;
		Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
		mInitializationPhase = false;
	}

	public void DoAfterHide()
	{
		leaderboardsGrid.MakeEmpty();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = draggablePanel.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void SetTableHeader()
	{
		header2.text = Localization.Localize((!mPlayerLeaderboard) ? "ID_TABLE_SQUAD" : "ID_TABLE_PLAYER");
		header3.text = Localization.Localize((!mPlayerLeaderboard) ? "ID_TABLE_SQUADRANK" : "ID_TABLE_AP");
		header4.text = Localization.Localize((!mPlayerLeaderboard) ? "ID_TABLE_MEMBERS" : "ID_TABLE_CURRENTLEAGUE");
		header5.text = Localization.Localize((!mPlayerLeaderboard) ? "ID_SQUADMEDALSSMALL" : "ID_TABLE_MEDALS");
	}

	private void DisplayRecords()
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		inviteFriendsPart.SetActive(value: false);
		leaderboardsGrid.MakeEmpty();
		if (mPlayerLeaderboard)
		{
			if (mPlayerSelected == PlayerSelect.FRIENDS)
			{
				waitingSprite.SetActive(mSendDataForFriend);
				if (mSendDataForFriend)
				{
					return;
				}
			}
			else
			{
				waitingSprite.SetActive(mSendDataForPlayer);
				if (mSendDataForPlayer)
				{
					return;
				}
			}
		}
		else
		{
			waitingSprite.SetActive(mSendDataForSquad);
			if (mSendDataForSquad)
			{
				return;
			}
		}
		DisplayResults();
		AlignTable();
	}

	private void DisplayResults()
	{
		if (mPlayerLeaderboard)
		{
			if (mPlayerSelected == PlayerSelect.FRIENDS)
			{
				if (mDatabaseFriends.Count > 0)
				{
					Debug.Log("LEADERBOARDS - showing " + mDatabaseFriends.Count.ToString() + " friends - global:" + mGlobalLeaderboard);
					leaderboardsGrid.init(mDatabaseFriends.Count, InstantiateFriend, RecordFree, draggablePanel);
				}
				else
				{
					Debug.Log("LEADERBOARDS - no friends, showing invite button (ignoring global / local)");
					inviteFriendsPart.SetActive(value: true);
				}
			}
			else
			{
				Debug.Log("LEADERBOARDS - showing top players - global:" + mGlobalLeaderboard);
				leaderboardsGrid.init((!mGlobalLeaderboard) ? mDatabasePlayerLocal.Count : mDatabasePlayer.Count, InstantiatePlayer, RecordFree, draggablePanel);
			}
		}
		else
		{
			Debug.Log("LEADERBOARDS - showing top squads - global:" + mGlobalLeaderboard);
			leaderboardsGrid.init((!mGlobalLeaderboard) ? mDatabaseSquadLocal.Count : mDatabaseSquad.Count, InstantiateSquad, RecordFree, draggablePanel);
		}
	}

	public void AlignTable()
	{
		if (mPlayerLeaderboard)
		{
			if (mPlayerSelected == PlayerSelect.YOURPOSITION)
			{
				draggablePanel.AlignToCenter(leaderboardsGrid.transform.localPosition + leaderboardsGrid.getPositionForIndex(PositionOfMe()), mInitializationPhase);
				leaderboardsGrid.PositionChanged();
			}
			else
			{
				draggablePanel.AlignToPos(mInitializationPhase);
			}
		}
		else if (mSquadSelected == SquadSelect.YOURSQUAD)
		{
			draggablePanel.AlignToCenter(leaderboardsGrid.transform.localPosition + leaderboardsGrid.getPositionForIndex(PositionOfMySquad()), mInitializationPhase);
			leaderboardsGrid.PositionChanged();
		}
		else
		{
			draggablePanel.AlignToPos(mInitializationPhase);
		}
	}

	private Transform InstantiateFriend(int index)
	{
		if (index >= 0 && index < mDatabaseFriends.Count)
		{
			string text = string.Format("Friend {0} {1}", (10000 - mDatabaseFriends[index].skill).ToString("D5"), mDatabaseFriends[index].name);
			LeaderboardRecord leaderboardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(leaderboardRecordPrefab, leaderboardsGrid.gameObject, text) as LeaderboardRecord;
			if (leaderboardRecord != null)
			{
				leaderboardRecord.InitializePlayer(mDatabaseFriends[index], index + 1, mWidth);
				return leaderboardRecord.transform;
			}
		}
		return null;
	}

	private Transform InstantiatePlayer(int index)
	{
		List<DatabasePlayerData> list = ((!mGlobalLeaderboard) ? mDatabasePlayerLocal : mDatabasePlayer);
		if (index >= 0 && index < list.Count)
		{
			string text = string.Format("Player {0} {1}", (10000 - list[index].skill).ToString("D5"), list[index].name);
			LeaderboardRecord leaderboardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(leaderboardRecordPrefab, leaderboardsGrid.gameObject, text) as LeaderboardRecord;
			if (leaderboardRecord != null)
			{
				leaderboardRecord.InitializePlayer(list[index], index + 1, mWidth);
				return leaderboardRecord.transform;
			}
		}
		return null;
	}

	private Transform InstantiateSquad(int index)
	{
		List<DatabaseSquad> list = ((!mGlobalLeaderboard) ? mDatabaseSquadLocal : mDatabaseSquad);
		if (index >= 0 && index < list.Count)
		{
			string text = string.Format("Squad {0} {1}", (100000 - list[index].skill).ToString("D6"), list[index].name);
			LeaderboardRecord leaderboardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(leaderboardRecordPrefab, leaderboardsGrid.gameObject, text) as LeaderboardRecord;
			if (leaderboardRecord != null)
			{
				leaderboardRecord.InitializeSquad(list[index], index + 1, mWidth);
				return leaderboardRecord.transform;
			}
		}
		return null;
	}

	private void RecordFree(Transform obj)
	{
		if (obj != null)
		{
			LeaderboardRecord component = obj.GetComponent<LeaderboardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private int PositionOfMe()
	{
		List<DatabasePlayerData> list = ((!mGlobalLeaderboard) ? mDatabasePlayerLocal : mDatabasePlayer);
		if (list == null)
		{
			return 0;
		}
		int num = list.FindIndex((DatabasePlayerData p1) => p1.id == GameLoginManager.currentPlayer.id);
		return (num >= 0) ? num : 0;
	}

	private int PositionOfMySquad()
	{
		List<DatabaseSquad> list = ((!mGlobalLeaderboard) ? mDatabaseSquadLocal : mDatabaseSquad);
		if (list == null)
		{
			return 0;
		}
		int num = list.FindIndex((DatabaseSquad s1) => s1.name == GameLoginManager.currentPlayer.squadName);
		return (num >= 0) ? num : 0;
	}
}
