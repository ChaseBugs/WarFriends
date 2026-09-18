using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadWarsContent : Core_BaseScript
{
	public class SquadWarsInternal
	{
		public bool isRecord;

		public LeagueType type;

		public int goldReward;

		public int headerAction;

		public int headerDivision;

		public int position;

		public string squadIcon;

		public string squadName;

		public int squadSize;

		public int squadPoints;

		public static SquadWarsInternal LoadSquad(int pos, string icon, string name, int size, int points, LeagueType curType)
		{
			SquadWarsInternal squadWarsInternal = new SquadWarsInternal();
			squadWarsInternal.isRecord = true;
			squadWarsInternal.position = pos;
			squadWarsInternal.squadIcon = icon;
			squadWarsInternal.squadName = name;
			squadWarsInternal.squadSize = size;
			squadWarsInternal.squadPoints = points;
			squadWarsInternal.type = curType;
			return squadWarsInternal;
		}

		public static SquadWarsInternal LoadHeader(int reward, int action, int division, LeagueType curType)
		{
			SquadWarsInternal squadWarsInternal = new SquadWarsInternal();
			squadWarsInternal.isRecord = false;
			squadWarsInternal.goldReward = reward;
			squadWarsInternal.headerAction = action;
			squadWarsInternal.headerDivision = division;
			squadWarsInternal.type = curType;
			return squadWarsInternal;
		}
	}

	public class SquadMemberInternal
	{
		public bool isHeader;

		public int position;

		public DatabasePlayer player;

		public string positionString;

		public int reward;

		public static SquadMemberInternal LoadMember(int pos, DatabasePlayer member)
		{
			SquadMemberInternal squadMemberInternal = new SquadMemberInternal();
			squadMemberInternal.isHeader = false;
			squadMemberInternal.position = pos;
			squadMemberInternal.player = member;
			return squadMemberInternal;
		}

		public static SquadMemberInternal LoadHeader(string posString, int goldReward)
		{
			SquadMemberInternal squadMemberInternal = new SquadMemberInternal();
			squadMemberInternal.isHeader = true;
			squadMemberInternal.positionString = posString;
			squadMemberInternal.reward = goldReward;
			return squadMemberInternal;
		}
	}

	[Header("Not In Squad")]
	public GameObject notInSquadPart;

	[Header("-Join Squad")]
	public UIButton joinSquadButton;

	public BoxCollider joinSquadCollider;

	public GameObject soldierIconPart;

	public GameObject firstRewardPart;

	public UILabel getRewardLabel;

	public UILabel rewardValueLabel;

	public GameObject joinLockedPart;

	public UILabel joinUnlockLabel;

	public UIPanel joinInsidePanel;

	[Header("-Create Squad")]
	public UIButton createNewSquadButton;

	public BoxCollider createNewSquadCollider;

	public GameObject createLockedPart;

	public UILabel createUnlockLabel;

	public UIPanel createInsidePanel;

	[Header("In Squad - Not Enought SP")]
	public GameObject inSquadLowSPPart;

	public UIButton toMultiplayer;

	[Header("In Squad")]
	public GameObject inSquadPart;

	[Header("-Left")]
	public BoxCollider squadWarMembersRewardsHint;

	public UISprite membersBorder;

	public UISprite squadWarMembersRewardsHintBackground;

	public UITable squadWarRewardTable;

	public UILabel squadPointsCurrent;

	public UILabel squadWarMineReward;

	[Header("--Member List")]
	public SquadPlayerRecord squadPlayerRecordPrefab;

	public UIPooledGrid membersGrid;

	public UIPanel membersPanel;

	public UIDraggablePanel draggableMembers;

	public GameObject waitingMembers;

	[Header("--Hint Squad Wars Reward")]
	public UIPanel hintSquadWarsRewardsDialogPanel;

	public UILabel[] hintSquadWarsRewards;

	[Header("-Right")]
	public UIPanel squadsHeaderPanel;

	public UILabel divisionLabel;

	public UISprite[] divisionArrows;

	public UILabel squadWarEndTimerLabel;

	public BoxCollider squadWarDivisionsHint;

	public UISprite squadWarDivisionsHintSprite;

	[Header("--Squads List")]
	public SquadWarsRecord squadWarsRecordPrefab;

	public UIPooledGrid squadsGrid;

	public UIPanel squadsPanel;

	public UIDraggablePanel draggableSquads;

	public GameObject waitingSquads;

	[Header("In Squad - Processing")]
	public GameObject inSquadProcessingPart;

	[Header("Waiting For Server")]
	public GameObject waitingForServerPart;

	[HideInInspector]
	public int indexStays;

	[HideInInspector]
	public int indexDemotes;

	[HideInInspector]
	public bool lowSquads;

	private List<SquadWarsInternal> mSquadWarsData;

	private List<DatabaseSquad> mSquadWarsSquads;

	private List<SquadMemberInternal> mSquadMembersData;

	private List<DatabasePlayer> mSquadMembers;

	private int mSquadPositionInWar = -1;

	private int mSquadsInWar = -1;

	private int mSquadWarDivision = 1;

	private int mMemberPositionInSquad = -1;

	private int mMemberSquadPoints;

	private int mSquadWarEnd;

	private float mTimer;

	private float mWidth = 1104f;

	private bool mWaitingForSquadDetails;

	private float mHeaderHeight => Mathf.Abs(base.transform.parent.localPosition.y);

	public LeagueType TypeAccordingToPositionAndDivision(int position)
	{
		if (lowSquads)
		{
			return LeagueType.Stay;
		}
		int num = position - 1;
		if (mSquadWarDivision == 8)
		{
			return (num >= indexDemotes) ? LeagueType.Demote : LeagueType.Top;
		}
		if (mSquadWarDivision == 1)
		{
			return (num < indexStays) ? LeagueType.Promote : LeagueType.Stay;
		}
		return (num < indexStays) ? LeagueType.Promote : ((num >= indexDemotes) ? LeagueType.Demote : LeagueType.Stay);
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
			TweenAlpha.Begin(draggableSquads.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(draggableMembers.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(joinInsidePanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(createInsidePanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(squadsHeaderPanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
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

	private void SetSquadWarPosition(int position)
	{
		mSquadPositionInWar = position;
		YourRewardCount();
		ShowMembers();
	}

	private void SetSquadWarCountAndDivision(int count, int division)
	{
		mSquadsInWar = count;
		mSquadWarDivision = division;
		YourRewardCount();
		ShowMembers();
	}

	private void SetMemberPositionInSquad(int position, int squadPoints)
	{
		mMemberPositionInSquad = position;
		mMemberSquadPoints = squadPoints;
		squadPointsCurrent.text = MiscTools.FormatBigNumber(mMemberSquadPoints);
		squadWarRewardTable.repositionNow = true;
		YourRewardCount();
	}

	private void YourRewardCount()
	{
		if (mMemberPositionInSquad >= 0 && mSquadPositionInWar >= 0 && mSquadsInWar >= 0)
		{
			int num = 0;
			if (mMemberSquadPoints > 0)
			{
				int tier = MiscTools.SquadWarTier(mSquadPositionInWar, mSquadsInWar);
				num = Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, mMemberPositionInSquad);
			}
			squadWarMineReward.text = MiscTools.FormatBigNumber(num);
			squadWarRewardTable.repositionNow = true;
			InitializeHintRewards();
		}
	}

	private void SetIndexes(bool setDefault = false)
	{
		indexStays = ((!setDefault) ? MiscTools.SquadWarPositionPromote(mSquadsInWar, mSquadWarDivision) : 5);
		indexDemotes = ((!setDefault) ? MiscTools.SquadWarPositionDemote(mSquadsInWar, mSquadWarDivision) : 45);
		if (mSquadWarDivision == 1)
		{
			indexDemotes = 51;
		}
		if (mSquadWarDivision == 8)
		{
			indexStays = -1;
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		SquadWarManager.instance.SquadWarSquadsUpdated += OnSquadsUpdated;
		SquadWarManager.instance.SquadWarMembersUpdated += OnMembersUpdated;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(joinSquadButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JoinSquadClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(createNewSquadButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CreateNewSquadClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(toMultiplayer.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ToBattleClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(hintSquadWarsRewardsDialogPanel.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HintDialogClicked));
		UIEventListener uIEventListener5 = UIEventListener.Get(squadWarMembersRewardsHint.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HintRewardsClicked));
		UIEventListener uIEventListener6 = UIEventListener.Get(squadWarDivisionsHint.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(SquadDivisionsHintClick));
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.SquadWarProcessingChanged = (Action)Delegate.Combine(instance.SquadWarProcessingChanged, new Action(OnSquadWarProcessingChanged));
		squadWarRewardTable.onReposition = delegate
		{
			float val = 0f - squadWarRewardTable.padding.x - (squadWarMineReward.transform.parent.localPosition.x - squadWarRewardTable.padding.x) / 2f;
			squadWarRewardTable.transform.localPosition = squadWarRewardTable.transform.localPosition.ReplaceX(val);
		};
		SetSizes();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<LeaguesScreen>.instance.isShowed || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (action == DatabaseAction.GetSquadDetails)
		{
			mWaitingForSquadDetails = false;
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName);
			if (squad != null)
			{
				ShowSquadDetails(squad);
				SetCorrectLook(squad.isInDivision);
			}
		}
	}

	private void OnSquadsUpdated()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			waitingSquads.SetActive(value: false);
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName))
			{
				mSquadWarsSquads = SquadWarManager.instance.GetSquadWarSquads();
			}
			if (mSquadWarsSquads != null)
			{
				ShowSquads(mSquadWarsSquads);
			}
		}
	}

	private void OnMembersUpdated()
	{
		if (!GuiScreenSingle<LeaguesScreen>.instance.isShowed || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		mSquadMembers = SquadWarManager.instance.GetSquadWarMembers();
		if (mSquadMembers != null && inSquadPart.activeSelf)
		{
			ShowMembers();
			int num = mSquadMembers.FindIndex((DatabasePlayer p) => p.id == GameLoginManager.currentPlayer.id);
			int squadPoints = ((num >= 0) ? mSquadMembers[num].squadPoints : GameLoginManager.currentPlayer.squadPoints);
			SetMemberPositionInSquad(num + 1, squadPoints);
		}
	}

	private void JoinSquadClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || !joinLockedPart.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void CreateNewSquadClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || !createLockedPart.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	private void ToBattleClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void HintDialogClicked(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHintSquadWarsReward();
	}

	private void HintRewardsClicked(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (hintSquadWarsRewardsDialogPanel.gameObject.activeSelf)
		{
			HideHintSquadWarsReward();
		}
		else
		{
			ShowHintSquadWarsReward();
		}
	}

	private void SquadDivisionsHintClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadWarHintDialog>.instance, 0f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(34f, 40f, 1f);
		TweenScale tweenScale = TweenScale.Begin(squadWarDivisionsHintSprite.gameObject, 0.2f, vector, vector.MultiplyXY(1.1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void OnSquadWarProcessingChanged()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			InitGUIValues();
		}
	}

	private void SetSizes()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		float num2 = mHeaderHeight + 62f;
		float num3 = mHeaderHeight;
		float num4 = 696f;
		float num5 = activeWidth - (120f + num4);
		float num6 = num - num2;
		float num7 = num - (num3 + 250f + 4f + 60f);
		mWidth = num5;
		squadsPanel.transform.parent.localPosition = squadsPanel.transform.parent.localPosition.ReplaceX(num4 + num5 / 2f);
		squadsPanel.clipRange = new Vector4(0f, (0f - num6) / 2f, num5 + 30f, num6);
		draggableSquads.transform.localPosition = draggableSquads.transform.localPosition.ReplaceXY(0f, 0f);
		membersBorder.transform.localScale = membersBorder.transform.localScale.ReplaceY(250f + num7 + 4f);
		membersPanel.transform.parent.localPosition = membersPanel.transform.parent.localPosition.ReplaceY(0f - (250f + num7 / 2f));
		membersPanel.clipRange = new Vector4(0f, 0f, 590f, num7);
		draggableMembers.transform.localPosition = draggableMembers.transform.localPosition.ReplaceXY(0f, 0f);
	}

	public void InitGUIValues()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		Debug.LogFormat("Leaderboards - Squad Wars - is in squad:{0},\t\tsquad wars procesing:{1}", flag, isSquadWarsProcessing);
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName);
		mWaitingForSquadDetails = squad == null;
		SetCorrectLook(squad?.isInDivision ?? false);
		if (!flag)
		{
			InitializeNotInSquad();
		}
		else if (!isSquadWarsProcessing)
		{
			mMemberPositionInSquad = -1;
			mMemberSquadPoints = 0;
			mSquadsInWar = -1;
			mSquadPositionInWar = -1;
			SetSquadWarEndTime();
			InstantHideHintSquadWarsReward();
			if (squad != null)
			{
				ShowSquadDetails(squad);
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
			}
		}
	}

	private void Update()
	{
		if (inSquadPart.activeSelf)
		{
			mTimer += Time.deltaTime;
			if (mTimer > 0.333f)
			{
				mTimer -= 0.333f;
				SetSquadWarEndTime();
			}
		}
	}

	public void DoAfterHide()
	{
		squadsGrid.MakeEmpty();
		if (mSquadWarsSquads != null)
		{
			mSquadWarsSquads = null;
		}
		if (mSquadWarsData != null)
		{
			mSquadWarsData.Clear();
		}
		membersGrid.MakeEmpty();
		if (mSquadMembers != null)
		{
			mSquadMembers = null;
		}
		if (mSquadMembersData != null)
		{
			mSquadMembersData = null;
		}
		mSquadPositionInWar = -1;
		mSquadsInWar = -1;
		mMemberPositionInSquad = -1;
		mMemberSquadPoints = 0;
	}

	public void InstantHideTab()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = draggableSquads.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		TweenAlpha component3 = joinInsidePanel.gameObject.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		TweenAlpha component4 = createInsidePanel.gameObject.GetComponent<TweenAlpha>();
		if (component4 != null)
		{
			component4.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void SetCorrectLook(bool isInDivision)
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		inSquadPart.SetActive(flag && !isSquadWarsProcessing && !mWaitingForSquadDetails && isInDivision);
		inSquadLowSPPart.SetActive(flag && !isSquadWarsProcessing && !mWaitingForSquadDetails && !isInDivision);
		inSquadProcessingPart.SetActive(flag && isSquadWarsProcessing);
		waitingForServerPart.SetActive(flag && !isSquadWarsProcessing && mWaitingForSquadDetails);
		notInSquadPart.SetActive(!flag);
	}

	private void InitializeNotInSquad()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool active = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		bool flag2 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldRewardFirstTimeSquad);
		soldierIconPart.transform.localPosition = soldierIconPart.transform.localPosition.ReplaceX((!flag2) ? (-100f) : 0f);
		firstRewardPart.SetActive(!flag2);
		if (!flag2)
		{
			getRewardLabel.text = Localization.Localize("ID_SQUADREWARDGET");
			MiscTools.SetUILabelRescale(getRewardLabel, 89f, 30f, 280);
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			rewardValueLabel.text = MiscTools.FormatBigNumber(num);
		}
		bool flag3 = !flag && !isSquadWarsProcessing;
		bool flag4 = !flag && !isSquadWarsProcessing;
		joinSquadCollider.enabled = flag3;
		createNewSquadCollider.enabled = flag4;
		joinSquadButton.pressed = ((!flag3) ? Color.gray : Color.white);
		joinSquadButton.hover = ((!flag3) ? Color.gray : Color.white);
		createNewSquadButton.pressed = ((!flag4) ? Color.gray : Color.white);
		createNewSquadButton.hover = ((!flag4) ? Color.gray : Color.white);
		joinUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), joinSquadUnlockLevel);
		createUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		joinLockedPart.SetActive(flag);
		createLockedPart.SetActive(active);
	}

	private void ShowSquadDetails(DatabaseSquad squad)
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		SetCorrectLook(squad?.isInDivision ?? false);
		if (squad == null)
		{
			Debug.LogError("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!");
		}
		if (squad.squadWarDivision == 0)
		{
			Debug.LogError("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD WAR!!!!");
		}
		int num = Mathf.Clamp(squad.squadWarDivision, 1, 8);
		int num2 = 9 - num;
		if (squad.isInDivision)
		{
			divisionLabel.text = string.Format("{0} {1}", Localization.Localize("ID_DIVISION"), num2);
			MiscTools.SetUILabelRescale(divisionLabel, 37f, 20f, 210);
			for (int i = 0; i < divisionArrows.Length; i++)
			{
				divisionArrows[i].gameObject.SetActive(i < num);
			}
			squadWarMineReward.text = "-";
			squadWarRewardTable.repositionNow = true;
			waitingMembers.SetActive(value: true);
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
			waitingSquads.SetActive(value: true);
			Singleton<BeanstalkServerManager>.instance.GetSquadsFromRound(squad.roundId);
		}
	}

	private void ShowSquads(List<DatabaseSquad> databaseSquads)
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		waitingSquads.SetActive(value: false);
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		int squadWarDivision = squad.squadWarDivision;
		lowSquads = databaseSquads.Count <= (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE;
		SetSquadWarPosition(databaseSquads.FindIndex((DatabaseSquad s1) => s1.name == GameLoginManager.currentPlayer.squadName) + 1);
		SetSquadWarCountAndDivision(databaseSquads.Count, squad.squadWarDivision);
		SetIndexes(lowSquads);
		if (IsSameNumberOfSquads(databaseSquads.Count))
		{
			if (lowSquads)
			{
				ActualizeSquadsNotEnough(databaseSquads, squadWarDivision);
			}
			else
			{
				ActualizeSquadsEnough(databaseSquads, squadWarDivision);
			}
		}
		else if (lowSquads)
		{
			ShowSquadsNotEnough(databaseSquads, squadWarDivision);
		}
		else
		{
			ShowSquadsEnough(databaseSquads, squadWarDivision);
		}
	}

	private void ShowSquadsEnough(List<DatabaseSquad> databaseSquads, int division)
	{
		if (mSquadWarsData == null)
		{
			mSquadWarsData = new List<SquadWarsInternal>();
		}
		else
		{
			mSquadWarsData.Clear();
		}
		int action = ((division != 8) ? 1 : 0);
		int reward = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
		LeagueType curType = TypeAccordingToPositionAndDivision(1);
		mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward, action, division, curType));
		int num = 1;
		int num2 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier3Percentage).FLOATVALUE);
		int num3 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier4Percentage).FLOATVALUE);
		int num4 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier5Percentage).FLOATVALUE);
		int num5 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsNoRewardPercentage).FLOATVALUE);
		Debug.LogFormat("Leaderboards - Squad Wars:\nTIER 1: 0-1\nTIER 2: 2-{0}\nTIER 3: {1}-{2}\nTIER 4: {3}-{4}\nTIER 5: {5}-{6}\nNO REWARD: {7}-{8}", num2, num2 + 1, num3, num3 + 1, num4, num4 + 1, num5, num5 + 1, databaseSquads.Count);
		for (int i = 0; i < databaseSquads.Count; i++)
		{
			int reward2 = 0;
			int action2 = 0;
			int num6 = i + 1;
			curType = TypeAccordingToPositionAndDivision(num6);
			if (i < num)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
			}
			else if (i >= num && i < num2)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(2, division);
			}
			else if (i >= num2 && i < num3)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(3, division);
			}
			else if (i >= num3 && i < num4)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(4, division);
			}
			else if (i >= num4 && i < num5)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(5, division);
			}
			if (i < indexStays)
			{
				action2 = 1;
			}
			if (i >= indexDemotes)
			{
				action2 = -1;
			}
			if (i == num || i == num2 || i == num3 || i == num4 || i == num5 || i == indexStays || i == indexDemotes)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward2, action2, division, curType));
			}
			mSquadWarsData.Add(SquadWarsInternal.LoadSquad(num6, databaseSquads[i].icon, databaseSquads[i].name, databaseSquads[i].size, databaseSquads[i].squadPoints, curType));
		}
		squadsGrid.MakeEmpty();
		squadsGrid.init(mSquadWarsData.Count, SquadWarInstantiate, RecordFree, draggableSquads);
		AlignTable();
	}

	private void ShowSquadsNotEnough(List<DatabaseSquad> databaseSquads, int division)
	{
		if (mSquadWarsData == null)
		{
			mSquadWarsData = new List<SquadWarsInternal>();
		}
		else
		{
			mSquadWarsData.Clear();
		}
		int reward = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
		mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward, 0, division, LeagueType.Stay));
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier2Reward).FLOATVALUE - 1;
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier3Reward).FLOATVALUE - 1;
		int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier4Reward).FLOATVALUE - 1;
		int num4 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier5Reward).FLOATVALUE - 1;
		int num5 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsNoReward).FLOATVALUE - 1;
		for (int i = 0; i < databaseSquads.Count; i++)
		{
			if (i == num)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(2, division), 0, division, LeagueType.Stay));
			}
			if (i == num2)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(3, division), 0, division, LeagueType.Stay));
			}
			if (i == num3)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(4, division), 0, division, LeagueType.Stay));
			}
			if (i == num4)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(5, division), 0, division, LeagueType.Stay));
			}
			if (i == num5)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(0, 0, division, LeagueType.Stay));
			}
			mSquadWarsData.Add(SquadWarsInternal.LoadSquad(i + 1, databaseSquads[i].icon, databaseSquads[i].name, databaseSquads[i].size, databaseSquads[i].squadPoints, LeagueType.Stay));
		}
		squadsGrid.MakeEmpty();
		squadsGrid.init(mSquadWarsData.Count, SquadWarInstantiate, RecordFree, draggableSquads);
		AlignTable();
	}

	private void ActualizeSquadsEnough(List<DatabaseSquad> databaseSquads, int division)
	{
		mSquadWarsData.Clear();
		int action = ((division != 8) ? 1 : 0);
		int reward = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
		LeagueType curType = TypeAccordingToPositionAndDivision(1);
		mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward, action, division, curType));
		int num = 1;
		int num2 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier3Percentage).FLOATVALUE);
		int num3 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier4Percentage).FLOATVALUE);
		int num4 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier5Percentage).FLOATVALUE);
		int num5 = Mathf.CeilToInt((float)databaseSquads.Count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsNoRewardPercentage).FLOATVALUE);
		for (int i = 0; i < databaseSquads.Count; i++)
		{
			int reward2 = 0;
			int action2 = 0;
			int num6 = i + 1;
			curType = TypeAccordingToPositionAndDivision(num6);
			if (i < num)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
			}
			else if (i >= num && i < num2)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(2, division);
			}
			else if (i >= num2 && i < num3)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(3, division);
			}
			else if (i >= num3 && i < num4)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(4, division);
			}
			else if (i >= num4 && i < num5)
			{
				reward2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(5, division);
			}
			if (i < indexStays)
			{
				action2 = 1;
			}
			if (i >= indexDemotes)
			{
				action2 = -1;
			}
			if (i == num || i == num2 || i == num3 || i == num4 || i == num5 || i == indexStays || i == indexDemotes)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward2, action2, division, curType));
			}
			mSquadWarsData.Add(SquadWarsInternal.LoadSquad(num6, databaseSquads[i].icon, databaseSquads[i].name, databaseSquads[i].size, databaseSquads[i].squadPoints, curType));
		}
		ActualizeShownRecords();
	}

	private void ActualizeSquadsNotEnough(List<DatabaseSquad> databaseSquads, int division)
	{
		mSquadWarsData.Clear();
		int reward = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, division);
		mSquadWarsData.Add(SquadWarsInternal.LoadHeader(reward, 0, division, LeagueType.Stay));
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier2Reward).FLOATVALUE - 1;
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier3Reward).FLOATVALUE - 1;
		int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier4Reward).FLOATVALUE - 1;
		int num4 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier5Reward).FLOATVALUE - 1;
		int num5 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsNoReward).FLOATVALUE - 1;
		for (int i = 0; i < databaseSquads.Count; i++)
		{
			if (i == num)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(2, division), 0, division, LeagueType.Stay));
			}
			if (i == num2)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(3, division), 0, division, LeagueType.Stay));
			}
			if (i == num3)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(4, division), 0, division, LeagueType.Stay));
			}
			if (i == num4)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(5, division), 0, division, LeagueType.Stay));
			}
			if (i == num5)
			{
				mSquadWarsData.Add(SquadWarsInternal.LoadHeader(0, 0, division, LeagueType.Stay));
			}
			mSquadWarsData.Add(SquadWarsInternal.LoadSquad(i + 1, databaseSquads[i].icon, databaseSquads[i].name, databaseSquads[i].size, databaseSquads[i].squadPoints, LeagueType.Stay));
		}
		ActualizeShownRecords();
	}

	private void ActualizeShownRecords()
	{
		for (int i = 0; i < squadsGrid.containItems; i++)
		{
			Transform itemOnIndex = squadsGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				SquadWarsRecord component = itemOnIndex.GetComponent<SquadWarsRecord>();
				if (component != null)
				{
					component.Initialize(mSquadWarsData[i], mWidth);
				}
			}
		}
	}

	private bool IsSameNumberOfSquads(int squadCount)
	{
		return mSquadWarsData != null && HowManyRecordsFor(squadCount) == mSquadWarsData.Count;
	}

	private int HowManyRecordsFor(int squadCount)
	{
		if (squadCount <= 0)
		{
			return 0;
		}
		int num = 1;
		if (squadCount <= (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier2Reward).FLOATVALUE - 1;
			int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier3Reward).FLOATVALUE - 1;
			int num4 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier4Reward).FLOATVALUE - 1;
			int num5 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier5Reward).FLOATVALUE - 1;
			int num6 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsNoReward).FLOATVALUE - 1;
			for (int i = 0; i < squadCount; i++)
			{
				if (i == num2 || i == num3 || i == num4 || i == num5 || i == num6)
				{
					num++;
				}
				num++;
			}
			return num;
		}
		int num7 = 1;
		int num8 = Mathf.CeilToInt((float)squadCount * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier3Percentage).FLOATVALUE);
		int num9 = Mathf.CeilToInt((float)squadCount * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier4Percentage).FLOATVALUE);
		int num10 = Mathf.CeilToInt((float)squadCount * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier5Percentage).FLOATVALUE);
		int num11 = Mathf.CeilToInt((float)squadCount * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsNoRewardPercentage).FLOATVALUE);
		for (int j = 0; j < squadCount; j++)
		{
			if (j == num7 || j == num8 || j == num9 || j == num10 || j == num11 || j == indexStays || j == indexDemotes)
			{
				num++;
			}
			num++;
		}
		return num;
	}

	private void AlignTable()
	{
		int num = mSquadWarsData.FindIndex((SquadWarsInternal s1) => s1.isRecord && s1.squadName == GameLoginManager.currentPlayer.squadName);
		if (num < 0)
		{
			num = 0;
		}
		draggableSquads.AlignToCenter(squadsGrid.transform.localPosition + squadsGrid.getPositionForIndex(num), instant: true);
		squadsGrid.PositionChanged();
	}

	private Transform SquadWarInstantiate(int index)
	{
		if (index >= 0 && index < mSquadWarsData.Count)
		{
			string text = string.Format("Squad Wars Data {0}", index.ToString("D3"));
			SquadWarsRecord squadWarsRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadWarsRecordPrefab, squadsGrid.gameObject, text) as SquadWarsRecord;
			if (squadWarsRecord != null)
			{
				squadWarsRecord.Initialize(mSquadWarsData[index], mWidth);
				return squadWarsRecord.transform;
			}
		}
		return null;
	}

	private void RecordFree(Transform obj)
	{
		if (obj != null)
		{
			SquadWarsRecord component = obj.GetComponent<SquadWarsRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void ShowMembers()
	{
		if (mSquadPositionInWar >= 0 && mSquadsInWar >= 0 && mSquadMembers != null && mSquadMembers.Count != 0)
		{
			waitingMembers.SetActive(value: false);
			mSquadMembersData = CreateSquadMembersList(mSquadMembers, mSquadWarDivision, mSquadsInWar, mSquadPositionInWar);
			membersGrid.MakeEmpty();
			membersGrid.init(mSquadMembersData.Count, MemberInitialize, MemberFree, draggableMembers);
			MembersAlign();
		}
	}

	public List<SquadMemberInternal> CreateSquadMembersList(List<DatabasePlayer> squadMembers, int squadDivision, int squadsInWas, int squadPosition)
	{
		List<SquadMemberInternal> list = new List<SquadMemberInternal>();
		int tier = MiscTools.SquadWarTier(squadPosition, squadsInWas);
		for (int i = 0; i < squadMembers.Count; i++)
		{
			if (i == 0)
			{
				list.Add(SquadMemberInternal.LoadHeader("1", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 1)));
			}
			if (i == 1)
			{
				list.Add(SquadMemberInternal.LoadHeader("2-5", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 2)));
			}
			if (i == 5)
			{
				list.Add(SquadMemberInternal.LoadHeader("6-10", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 6)));
			}
			if (i == 10)
			{
				list.Add(SquadMemberInternal.LoadHeader("11-19", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 11)));
			}
			if (i == 19)
			{
				list.Add(SquadMemberInternal.LoadHeader("20-29", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 20)));
			}
			if (i == 29)
			{
				list.Add(SquadMemberInternal.LoadHeader("30-40", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 30)));
			}
			if (i == 40)
			{
				list.Add(SquadMemberInternal.LoadHeader("40+", Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, squadDivision, 41)));
			}
			list.Add(SquadMemberInternal.LoadMember(i + 1, squadMembers[i]));
		}
		return list;
	}

	private void MembersAlign()
	{
		int num = mSquadMembersData.FindIndex((SquadMemberInternal p1) => !p1.isHeader && p1.player.id == GameLoginManager.currentPlayer.id);
		if (num < 0)
		{
			num = 0;
		}
		draggableMembers.AlignToCenter(membersGrid.transform.localPosition + membersGrid.getPositionForIndex(num), instant: true);
		membersGrid.PositionChanged();
	}

	private Transform MemberInitialize(int index)
	{
		if (index >= 0 && index < mSquadMembersData.Count)
		{
			SquadMemberInternal squadMemberInternal = mSquadMembersData[index];
			string text = ((!squadMemberInternal.isHeader) ? $"{index:D2} Squad Member {squadMemberInternal.position}" : $"{index:D2} Header {squadMemberInternal.positionString}");
			SquadPlayerRecord squadPlayerRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadPlayerRecordPrefab, membersGrid.gameObject, text) as SquadPlayerRecord;
			if (squadPlayerRecord != null)
			{
				squadPlayerRecord.Initialize(squadMemberInternal);
				return squadPlayerRecord.transform;
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			SquadPlayerRecord component = obj.GetComponent<SquadPlayerRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void HideHintSquadWarsReward()
	{
		squadWarMembersRewardsHintBackground.spriteName = MiscTools.infoButtonSprite;
		squadWarMembersRewardsHintBackground.MakePixelPerfect();
		TweenAlpha.Begin(hintSquadWarsRewardsDialogPanel.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintSquadWarsRewardsDialogPanel.gameObject, 0.4f, new Vector3(600f, 24f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideHintSquadWarsReward();
		};
	}

	private void ShowHintSquadWarsReward()
	{
		squadWarMembersRewardsHintBackground.spriteName = MiscTools.closeButtonSprite;
		squadWarMembersRewardsHintBackground.MakePixelPerfect();
		hintSquadWarsRewardsDialogPanel.gameObject.SetActive(value: true);
		hintSquadWarsRewardsDialogPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintSquadWarsRewardsDialogPanel.gameObject, 0.4f, 1f).onFinished = null;
		hintSquadWarsRewardsDialogPanel.transform.localPosition = new Vector3(600f, -26f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintSquadWarsRewardsDialogPanel.gameObject, 0.25f, new Vector3(600f, -26f, -60f), new Vector3(600f, 4f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintSquadWarsRewardsDialogPanel.gameObject, 0.15f, new Vector3(600f, -6f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void InstantHideHintSquadWarsReward()
	{
		hintSquadWarsRewardsDialogPanel.gameObject.SetActive(value: false);
		squadWarMembersRewardsHintBackground.spriteName = MiscTools.infoButtonSprite;
		squadWarMembersRewardsHintBackground.MakePixelPerfect();
	}

	private void InitializeHintRewards()
	{
		int tier = MiscTools.SquadWarTier(mSquadPositionInWar, mSquadsInWar);
		if (hintSquadWarsRewards.Length > 0)
		{
			hintSquadWarsRewards[0].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 1));
		}
		if (hintSquadWarsRewards.Length > 1)
		{
			hintSquadWarsRewards[1].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 2));
		}
		if (hintSquadWarsRewards.Length > 2)
		{
			hintSquadWarsRewards[2].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 6));
		}
		if (hintSquadWarsRewards.Length > 3)
		{
			hintSquadWarsRewards[3].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 11));
		}
		if (hintSquadWarsRewards.Length > 4)
		{
			hintSquadWarsRewards[4].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 20));
		}
		if (hintSquadWarsRewards.Length > 5)
		{
			hintSquadWarsRewards[5].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 30));
		}
		if (hintSquadWarsRewards.Length > 6)
		{
			hintSquadWarsRewards[6].text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.SquadWarsRewardForMember(tier, mSquadWarDivision, 41));
		}
	}

	public void ShowSquadWarEndTime(int warEvaluationTimestamp)
	{
		mSquadWarEnd = ((warEvaluationTimestamp > Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? warEvaluationTimestamp : 0);
	}

	private void SetSquadWarEndTime()
	{
		int num = mSquadWarEnd - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		squadWarEndTimerLabel.text = ((num <= 0) ? Localization.Localize("ID_LOADING") : Localization.LocalizeFormat("ID_ENDSINTIME", Colours.stringWhite, MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty)));
		if (mSquadWarEnd > 0 && num <= 0)
		{
			CountdownEnded();
		}
	}

	private void CountdownEnded()
	{
		bool flag = Singleton<BeanstalkServerManager>.instance.currentTimestamp < mSquadWarEnd + 3600;
		ShowSquadWarEndTime(Singleton<BeanstalkServerManager>.instance.GetNextWarEvaluationTimestamp());
		if (flag)
		{
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
	}
}
