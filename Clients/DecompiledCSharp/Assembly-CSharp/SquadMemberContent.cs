using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMemberContent : Core_BaseScript
{
	public class ManagementRecord
	{
		public int type;

		public DatabasePlayer member;

		public int nextRankSizeIncrease;

		public int currentSquadRank;

		public static ManagementRecord GetRecord(DatabasePlayer player)
		{
			ManagementRecord managementRecord = new ManagementRecord();
			managementRecord.type = 0;
			managementRecord.member = player;
			managementRecord.nextRankSizeIncrease = 0;
			managementRecord.currentSquadRank = 0;
			return managementRecord;
		}

		public static ManagementRecord GetEmpty()
		{
			ManagementRecord managementRecord = new ManagementRecord();
			managementRecord.type = 1;
			managementRecord.member = null;
			managementRecord.nextRankSizeIncrease = 0;
			managementRecord.currentSquadRank = 0;
			return managementRecord;
		}

		public static ManagementRecord GetSummary(int nextRankToOpen, int currentRank)
		{
			ManagementRecord managementRecord = new ManagementRecord();
			managementRecord.type = 2;
			managementRecord.member = null;
			managementRecord.nextRankSizeIncrease = nextRankToOpen;
			managementRecord.currentSquadRank = currentRank;
			return managementRecord;
		}
	}

	public class CacheAction
	{
		public DatabaseAction action;

		public string playerId;

		public CacheAction(DatabaseAction a, string id)
		{
			action = a;
			playerId = id;
		}
	}

	[Header("Members List")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	public GameObject topCenterGO;

	public UIPooledGrid membersGrid;

	public MemberRecord memberRecordPrefab;

	[Header("Waiting for server")]
	public UIPanel waitingPanel;

	public UISprite waitingSprite;

	private bool mIsActive;

	private List<ManagementRecord> mManagementRecords = new List<ManagementRecord>();

	private int mSquadSize;

	private RadicalRoutine mRoutine;

	private bool mSkipUpdate;

	private List<CacheAction> mOngoingActions = new List<CacheAction>();

	private int mNumberOfColeaders;

	public bool canBePromotedToColeader => mNumberOfColeaders < 3;

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.SquadWarProcessingChanged = (Action)Delegate.Combine(instance.SquadWarProcessingChanged, new Action(OnSquadProcessingChanged));
		float activeWidth = UIRoot.list[0].activeWidth;
		int num = UIRoot.list[0].activeHeight - 470;
		topCenterGO.transform.localPosition = new Vector3(activeWidth / 2f - 60f, topCenterGO.transform.localPosition.y, 0f);
		Vector4 clipRange = panel.clipRange;
		clipRange.y = (float)(-num) / 2f;
		clipRange.w = num;
		panel.clipRange = clipRange;
		draggablePanel.transform.localPosition = new Vector3(draggablePanel.transform.localPosition.x, 0f, draggablePanel.transform.localPosition.z);
		membersGrid.cellWidth = activeWidth - 120f;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !mIsActive)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].visualType = generatedCurrentPlayer.visualType;
					list[num].visualTimestamp = generatedCurrentPlayer.visualTimestamp;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				mNumberOfColeaders = 0;
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
					else if (list[num2].squadRank == SquadRank.Coleader)
					{
						mNumberOfColeaders++;
					}
				}
				list.Sort(SortFunctionPlayers);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			DisplaySquadMembers(list);
			SkipListUpdate();
			break;
		}
		case DatabaseAction.GetSquadDetails:
			if (waitingSprite.gameObject.activeSelf)
			{
				InitGUIValues();
			}
			break;
		}
	}

	private void OnSquadProcessingChanged()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && mIsActive)
		{
			UpdateDisplayedRecords();
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

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(waitingPanel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void InitGUIValues()
	{
		Debug.Log("Called InitGuiValues in Member Content.");
		waitingSprite.gameObject.SetActive(value: true);
		membersGrid.MakeEmpty();
		Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
	}

	public void DoAfterHide()
	{
		StopUpdatingList();
		membersGrid.MakeEmpty();
		mManagementRecords.Clear();
		mOngoingActions.Clear();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void DisplaySquadMembers(List<DatabasePlayer> squadMembers)
	{
		if (!waitingSprite.gameObject.activeSelf)
		{
			UpdateSquadMembers(squadMembers);
			return;
		}
		StartUpdatingList();
		membersGrid.MakeEmpty();
		if (squadMembers == null)
		{
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		if (squad == null)
		{
			Debug.LogError("Current squad information are not in server cache");
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
			return;
		}
		mSquadSize = Singleton<GameVariables>.instance.GetSquadRankSize(squad.rank);
		int num = Mathf.Max(0, mSquadSize - squadMembers.Count);
		mManagementRecords.Clear();
		int num2 = 0;
		foreach (DatabasePlayer squadMember in squadMembers)
		{
			mManagementRecords.Add(ManagementRecord.GetRecord(squadMember));
			if (squadMember.GetRealStatus() != PlayerStatus.Offline)
			{
				num2++;
			}
		}
		int num3 = 0;
		List<string> list = new List<string>();
		KeyValuePair<string, AwaitingSquadMembersManager.AwaitingMember> member;
		foreach (KeyValuePair<string, AwaitingSquadMembersManager.AwaitingMember> listOfMember in Singleton<AwaitingSquadMembersManager>.instance.listOfMembers)
		{
			member = listOfMember;
			if (squadMembers.FindIndex((DatabasePlayer m1) => m1.id == member.Key) < 0)
			{
				mManagementRecords.Add(ManagementRecord.GetRecord(member.Value.player));
				num3++;
			}
			else
			{
				list.Add(member.Key);
			}
		}
		for (int num4 = 0; num4 < list.Count; num4++)
		{
			Singleton<AwaitingSquadMembersManager>.instance.RemovePlayer(list[num4]);
		}
		list.Clear();
		int num5 = num - num3;
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (squad.isPublic || !flag)
		{
			for (int num6 = 0; num6 < num5; num6++)
			{
				mManagementRecords.Add(ManagementRecord.GetEmpty());
			}
		}
		mManagementRecords.Add(ManagementRecord.GetSummary(Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(squad.rank), squad.rank));
		GuiScreenSingle<SquadScreen>.instance.SetMembersButton(squad.size, mSquadSize, num2);
		waitingSprite.gameObject.SetActive(value: false);
		membersGrid.init(mManagementRecords.Count, MemberInstantiate, MemberFree, draggablePanel);
		draggablePanel.AlignToPos(instant: false);
	}

	private void UpdateSquadMembers(List<DatabasePlayer> squadMembers)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		if (string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			Debug.Log("No longer in squad quit update the squad members");
			StopUpdatingList();
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(generatedCurrentPlayer.squadName, ommitTime: true);
		if (squad == null)
		{
			Debug.Log("no squad details in cache, skip this update");
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < mManagementRecords.Count; i++)
		{
			if (mManagementRecords[i].type == 0)
			{
				num++;
			}
			if (mManagementRecords[i].type == 1)
			{
				num2++;
			}
		}
		Dictionary<string, AwaitingSquadMembersManager.AwaitingMember> dictionary = new Dictionary<string, AwaitingSquadMembersManager.AwaitingMember>();
		KeyValuePair<string, AwaitingSquadMembersManager.AwaitingMember> member;
		foreach (KeyValuePair<string, AwaitingSquadMembersManager.AwaitingMember> listOfMember in Singleton<AwaitingSquadMembersManager>.instance.listOfMembers)
		{
			member = listOfMember;
			if (squadMembers.FindIndex((DatabasePlayer m1) => m1.id == member.Key) < 0)
			{
				dictionary.Add(member.Key, member.Value);
			}
		}
		int num3 = squadMembers.Count + dictionary.Count;
		mSquadSize = Singleton<GameVariables>.instance.GetSquadRankSize(squad.rank);
		int num4 = mSquadSize - squadMembers.Count;
		int num5 = Mathf.Max(0, num4 - dictionary.Count);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (!squad.isPublic && flag)
		{
			num5 = 0;
		}
		if (num + num2 != num3 + num5)
		{
			membersGrid.MakeEmpty();
			waitingSprite.gameObject.SetActive(value: true);
			DisplaySquadMembers(squadMembers);
			return;
		}
		int num6 = 0;
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		foreach (DatabasePlayer squadMember in squadMembers)
		{
			list.Add(squadMember);
			if (squadMember.GetRealStatus() != PlayerStatus.Offline)
			{
				num6++;
			}
		}
		foreach (KeyValuePair<string, AwaitingSquadMembersManager.AwaitingMember> item in dictionary)
		{
			list.Add(item.Value.player);
		}
		for (int num7 = 0; num7 < num3; num7++)
		{
			mManagementRecords[num7].type = 0;
			mManagementRecords[num7].member = list[num7];
		}
		for (int num8 = num3; num8 < num3 + num5; num8++)
		{
			mManagementRecords[num8].type = 1;
		}
		UpdateDisplayedRecords();
		GuiScreenSingle<SquadScreen>.instance.SetMembersButton(squad.size, mSquadSize, num6);
	}

	private void UpdateDisplayedRecords()
	{
		for (int i = 0; i < membersGrid.containItems; i++)
		{
			Transform itemOnIndex = membersGrid.GetItemOnIndex(i);
			if (!(itemOnIndex != null))
			{
				continue;
			}
			MemberRecord component = itemOnIndex.GetComponent<MemberRecord>();
			if (component != null)
			{
				component.FreeTexture();
				if (mManagementRecords[i].type == 0)
				{
					component.InitMember(mManagementRecords[i].member, i + 1);
				}
				else if (mManagementRecords[i].type == 2)
				{
					component.InitSummary(mManagementRecords[i].currentSquadRank, mManagementRecords[i].nextRankSizeIncrease);
				}
				else
				{
					component.InitEmpty();
				}
			}
		}
	}

	public void UpdateShownRecord(string playerId)
	{
		for (int i = 0; i < membersGrid.containItems; i++)
		{
			Transform itemOnIndex = membersGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MemberRecord component = itemOnIndex.GetComponent<MemberRecord>();
				if (component != null && mManagementRecords[i].type == 0 && mManagementRecords[i].member.id == playerId)
				{
					component.InitMember(mManagementRecords[i].member, i + 1);
				}
			}
		}
	}

	private bool IsCorrectRecord(ManagementRecord record, DatabasePlayer player)
	{
		if (record.type == 0 && record.member.id == player.id)
		{
			return true;
		}
		return false;
	}

	private Transform MemberInstantiate(int index)
	{
		if (index >= 0 && index < mManagementRecords.Count)
		{
			ManagementRecord managementRecord = mManagementRecords[index];
			switch (managementRecord.type)
			{
			case 0:
			{
				MemberRecord memberRecord2 = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberRecordPrefab, membersGrid.gameObject, string.Format("{0} Squad Member {1}", index.ToString("D2"), managementRecord.member.name)) as MemberRecord;
				if (memberRecord2 != null)
				{
					memberRecord2.InitMember(managementRecord.member, index + 1);
					return memberRecord2.transform;
				}
				break;
			}
			case 1:
			{
				MemberRecord memberRecord3 = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberRecordPrefab, membersGrid.gameObject, string.Format("{0} Empty", index.ToString("D2"))) as MemberRecord;
				if (memberRecord3 != null)
				{
					memberRecord3.InitEmpty();
					return memberRecord3.transform;
				}
				break;
			}
			case 2:
			{
				MemberRecord memberRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberRecordPrefab, membersGrid.gameObject, string.Format("{0} Summary", index.ToString("D2"))) as MemberRecord;
				if (memberRecord != null)
				{
					memberRecord.InitSummary(managementRecord.currentSquadRank, managementRecord.nextRankSizeIncrease);
					return memberRecord.transform;
				}
				break;
			}
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			MemberRecord component = obj.GetComponent<MemberRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public void SkipListUpdate()
	{
		mSkipUpdate = true;
	}

	private void StartUpdatingList()
	{
		if (mRoutine == null)
		{
			mRoutine = RadicalRoutine.Create(UpdatePlayerList());
			StartCoroutine(mRoutine.enumerator);
		}
	}

	private void StopUpdatingList()
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
			if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
			{
				break;
			}
			if (mSkipUpdate)
			{
				mSkipUpdate = false;
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
			}
		}
		mRoutine = null;
	}

	public bool IsPlayerWaitingForServerResponse(string id)
	{
		foreach (CacheAction mOngoingAction in mOngoingActions)
		{
			if (mOngoingAction.playerId == id)
			{
				return true;
			}
		}
		return false;
	}

	public void AddAction(DatabaseAction action, string id)
	{
		mOngoingActions.Add(new CacheAction(action, id));
	}

	public void ServerResponseCame(DatabaseAction action, string id)
	{
		if (mOngoingActions == null || mOngoingActions.Count == 0)
		{
			return;
		}
		int index = -1;
		for (int i = 0; i < mOngoingActions.Count; i++)
		{
			CacheAction cacheAction = mOngoingActions[i];
			if (cacheAction.action == action && cacheAction.playerId == id)
			{
				index = i;
				break;
			}
		}
		mOngoingActions.RemoveAt(index);
	}
}
