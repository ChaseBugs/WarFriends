using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionDialog : GuiElementSingle<MissionDialog>, IGuiDialog
{
	public struct MissionEnemiesData
	{
		public enum UnitType
		{
			Bot = 1,
			Card,
			Unit
		}

		public int unitLevel;

		public int unitUnlockedLevel;

		public string iconName;

		public UnitType unitType;

		public string[] botVisuals;

		public int CompareTo(MissionEnemiesData value)
		{
			if (unitType == value.unitType)
			{
				if (unitType == UnitType.Unit)
				{
					if (unitUnlockedLevel > value.unitUnlockedLevel)
					{
						return -1;
					}
					if (unitUnlockedLevel < value.unitUnlockedLevel)
					{
						return 1;
					}
				}
				return 0;
			}
			if (unitType > value.unitType)
			{
				return 1;
			}
			return -1;
		}
	}

	[Header("Header")]
	public UIButton backButton;

	public GameObject headerLeftPart;

	public UILabel missionNumber;

	public UILabel missionType;

	public UILabel missionTask;

	public GameObject headerRightPart;

	public UIButton closeButton;

	public UILabel missionTimeLimit;

	[Header("Mission Rewards")]
	public GameObject missionRewardsPart;

	public GameObject missionRewardsGrid;

	public List<MissionRewardsBox> missionRewards;

	[Header("Mission Enemies")]
	public GameObject missionEnemiesPart;

	public UILabel missionEnemiesLevel;

	public GameObject missionEnemiesCenterPart;

	public MissionEnemyRecord missionEnemiesRecordPrefab;

	public UIDraggablePanel draggableEnemies;

	public UIPooledGrid pooledEnemiesGrid;

	[Header("Recommended AP")]
	public GameObject missionRecommendedPart;

	public UITable missionRecommendedTable;

	public UILabel missionRecommendedPowerLabel;

	[Header("Mission Leaderboards")]
	public GameObject missionLeaderboardsParent;

	public UISprite missionLeaderboardsBorder;

	public UIButton connectToFacebookButton;

	public UIButton inviteFriendsButton;

	public MissionLeaderboardRecord missionLeaderboardRecordPrefab;

	public GameObject missionLeaderboardsScrollviewParent;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid pooledGrid;

	public UIPanel missionLeaderboardsPanel;

	public BoxCollider missionLeaderboardsCollider;

	[Header("Mission Highscore")]
	public GameObject missionHighscoreParent;

	public UISprite progress;

	public List<MissionDialogStar> stars;

	[Header("Bottom Buttons")]
	public GameObject playButton;

	public GameObject playCoop;

	[Header("Heroic Part")]
	public GameObject heroicPart;

	public BoxCollider heroicButtonCollider;

	public UIPanel heroicButtonPanel;

	public UISprite heroicSingle;

	public GameObject heroicCoop;

	public UILabel heroicButtonLabel;

	public UILabel heroicCountdownTitle;

	public WinStreakCounter heroicCountdown;

	public GameObject heroicCompleted;

	public GameObject heroicRewards;

	public UISprite heroicGoldIcon;

	public UISprite heroicWarbucksIcon;

	public UILabel heroicRewardValue;

	private int mMissionIndex;

	private ObjectPool mPool;

	private List<MissionEnemiesData> mMissionEnemies = new List<MissionEnemiesData>();

	private List<MissionLeaderboardData> mLeaderboards = new List<MissionLeaderboardData>();

	private Dictionary<string, DatabasePlayerMissionLeaderboard> mRecords = new Dictionary<string, DatabasePlayerMissionLeaderboard>();

	private Texture2D mBossTexture;

	private float mNotActiveAlpha = 0.12f;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed && action == DatabaseAction.GetMissionLeaderboards)
			{
				ShowMissionLeaderboards(Singleton<ServerResultsCache>.instance.GetMissionLeaderboards());
			}
		};
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(playButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PlayButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(playCoop);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PlayCoopButtonClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(heroicButtonCollider.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PlayHeroicClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(connectToFacebookButton.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ConnectToFacebookButtonClick));
		UIEventListener uIEventListener7 = UIEventListener.Get(inviteFriendsButton.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(InviteFriendsButtonClick));
		mPool = Singleton<GuiManager>.instance.objectPool;
		mBossTexture = new Texture2D(Singleton<ArmyPreviewCamera>.instance.playerTexture.width, Singleton<ArmyPreviewCamera>.instance.playerTexture.height, TextureFormat.ARGB32, mipmap: true);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void PlayButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				HideDialog();
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiScreenSingle<MissionScreen>.instance.SetLastPlayedMission();
				StartMission(null);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, fadeOutTime + 0.1f);
			}
		}
	}

	private void PlayCoopButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				HideDialog();
				GuiScreenSingle<MissionScreen>.instance.SetLastPlayedMission();
				PlayCoopMatchFacebookHandler(result: true);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, fadeOutTime + 0.1f);
			}
		}
	}

	private void PlayHeroicClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
		{
			HideDialog();
			GuiScreenSingle<MissionScreen>.instance.SetLastPlayedMission();
			if (heroicCoop.activeSelf)
			{
				PlayCoopMatchFacebookHandler(result: true, heroicButtonClicked: true);
				return;
			}
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			StartMission(null, isHeroic: true);
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, fadeOutTime + 0.1f);
		}
	}

	public void ConnectToFacebookButtonClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool result)
		{
			if (result)
			{
				HideDialog();
				GameLoginManager.instance.SpecialLoginToFacebookInMissionDialog();
			}
		});
	}

	public void InviteFriendsButtonClick(GameObject go)
	{
		GameLoginManager.instance.InviteFacebookFriends();
	}

	private void PlayCoopMatchFacebookHandler(bool result, bool heroicButtonClicked = false)
	{
		if (result)
		{
			Singleton<GameController>.instance.SwitchToCoop();
			string missionName = MissionsManager.instance.GetMissionName(MissionsManager.instance.indexMissionToStart);
			if (heroicButtonClicked)
			{
				SelectFriendsDialog.ShowCoopDialog(OnDialogFriendInvitedForHeroic, 0.2f, string.Format("{0} {1}{2}[-]", missionName, Colours.stringGoldHeroic, Localization.Localize("ID_HEROICMODEHEADER")));
			}
			else
			{
				SelectFriendsDialog.ShowCoopDialog(OnDialogFriendInvited, 0.2f, missionName);
			}
		}
	}

	private void OnDialogFriendInvited(DatabasePlayer player, bool b)
	{
		if (b)
		{
			HideDialog();
			StartMission(player);
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				Singleton<GameController>.instance.StartMultiplayerGame(player);
			}
		}
	}

	private void OnDialogFriendInvitedForHeroic(DatabasePlayer player, bool b)
	{
		if (b)
		{
			HideDialog();
			StartMission(player, isHeroic: true);
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				Singleton<GameController>.instance.StartMultiplayerGame(player);
			}
		}
	}

	public void StartMission(DatabasePlayer player, bool isHeroic = false)
	{
		if (MissionsManager.instance.currentMission == null)
		{
			Debug.LogError("FATAL ERROR - no mission specified");
		}
		else
		{
			MissionsManager.instance.currentMission.OpenMission(player, isInvite: false, isRematch: false, isHeroic);
		}
	}

	public override void InitGUIValues()
	{
		AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
		Mission currentMission = MissionsManager.instance.currentMission;
		mMissionIndex = currentMission.index;
		missionNumber.text = currentMission.number.ToString();
		missionType.text = Localization.Localize(GameVariables.missionDialogTranslationIds[currentMission.missionType].Value1);
		missionTask.text = Localization.LocalizeFormat(GameVariables.missionDialogTranslationIds[currentMission.missionType].Value2, currentMission.GetMissionObjective());
		MiscTools.SetUILabelRescale(missionTask, 35f, 20f, 510);
		missionTimeLimit.text = ((currentMission.missionType != Mission.MissionType.Survive) ? string.Format("{0} {1}{2}", Localization.Localize("ID_TIMELIMIT"), Colours.stringWhite, MiscTools.PrintableTimeTwoDigits(currentMission.maxTimeForMission)) : string.Empty);
		InitializeRewards(currentMission);
		mMissionEnemies = currentMission.GetEnemiesInMission();
		string text = "Mission enemies debugging levels:\n";
		int num = 0;
		for (int i = 0; i < mMissionEnemies.Count; i++)
		{
			text = ((mMissionEnemies[i].unitType == MissionEnemiesData.UnitType.Unit) ? (text + $"UNIT {mMissionEnemies[i].iconName} {mMissionEnemies[i].unitLevel}\n") : ((mMissionEnemies[i].unitType != MissionEnemiesData.UnitType.Card) ? (text + string.Format("BOSS {0} {1}\n", mMissionEnemies[i].unitLevel, string.Join(" ", mMissionEnemies[i].botVisuals))) : (text + $"CARD {mMissionEnemies[i].iconName} {mMissionEnemies[i].unitLevel}\n")));
			if (mMissionEnemies[i].unitType == MissionEnemiesData.UnitType.Unit && num < mMissionEnemies[i].unitLevel)
			{
				num = mMissionEnemies[i].unitLevel;
			}
		}
		Debug.Log(text + "\nMax level:" + num + "\n");
		missionEnemiesLevel.text = string.Format("{0} {1}", Localization.Localize("ID_ENEMIESLEVEL"), num);
		pooledEnemiesGrid.MakeEmpty();
		pooledEnemiesGrid.init(mMissionEnemies.Count, InstantiateEnemy, EnemyFree, draggableEnemies);
		draggableEnemies.AlignToPos(instant: true);
		missionRecommendedPowerLabel.text = MiscTools.FormatBigNumber(currentMission.recommendedArmyPower);
		missionRecommendedTable.repositionNow = true;
		connectToFacebookButton.gameObject.SetActive(GameLoginManager.currentPlayer.accountType != AccountType.Facebook);
		inviteFriendsButton.gameObject.SetActive(GameLoginManager.currentPlayer.accountType == AccountType.Facebook);
		Singleton<BeanstalkServerManager>.instance.GetMissionLeaderboards();
		progress.fillAmount = currentMission.ProgressMission(0.174f, 0.589f, currentMission.highscore);
		stars[0].Initialize(currentMission.numberOfStars > 0, currentMission.scoreFor1Star);
		stars[1].Initialize(currentMission.numberOfStars > 1, currentMission.scoreFor2Stars);
		stars[2].Initialize(currentMission.numberOfStars > 2, currentMission.scoreFor3Stars);
		bool flag = currentMission.isHeroic && !MissionsManager.instance.isHeroicLocked;
		ShowHeroicPart(flag);
		if (flag)
		{
			FillHeroicInformations(currentMission);
			return;
		}
		heroicCountdown.StopCountingTo();
		WinStreakCounter winStreakCounter = heroicCountdown;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(HeroicDeadlineEnd));
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		bool flag = heroicPart.activeSelf && heroicButtonCollider.enabled;
		TweenAlpha.Begin(heroicButtonPanel.gameObject, fadeInTime, 0f, (!flag) ? mNotActiveAlpha : 1f);
	}

	private void InitializeRewards(Mission mission)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (MissionRewardsBox missionReward in missionRewards)
		{
			if (!flag)
			{
				flag = true;
				if (mission.rewardWB > 0)
				{
					missionReward.InitializeWarbucks(mission.rewardWB);
					continue;
				}
			}
			if (!flag2)
			{
				flag2 = true;
				if (mission.rewardGold > 0)
				{
					missionReward.InitializeGold(mission.rewardGold, mission.completedWithGoldReward);
					continue;
				}
			}
			if (!flag3)
			{
				flag3 = true;
				if (mission.rewardXP > 0)
				{
					missionReward.InitializeXP(mission.rewardXP);
					continue;
				}
			}
			missionReward.Hide();
		}
	}

	private void ShowHeroicPart(bool isHeroicMission)
	{
		heroicPart.SetActive(isHeroicMission);
		bool flag = isHeroicMission && !Singleton<GameVariables>.instance.isiPadResolution;
		headerLeftPart.transform.localPosition = headerLeftPart.transform.localPosition.ReplaceY((!flag) ? (-190f) : (-170f));
		headerRightPart.transform.localPosition = headerRightPart.transform.localPosition.ReplaceY((!flag) ? (-190f) : (-170f));
		missionRewardsPart.transform.localPosition = missionRewardsPart.transform.localPosition.ReplaceY((!flag) ? 270f : 290f);
		missionRewardsGrid.transform.localPosition = missionRewardsGrid.transform.localPosition.ReplaceY((!flag) ? (-123f) : (-113f));
		missionEnemiesPart.transform.localPosition = missionEnemiesPart.transform.localPosition.ReplaceY((!flag) ? 28f : 58f);
		missionEnemiesCenterPart.transform.localPosition = missionEnemiesCenterPart.transform.localPosition.ReplaceY((!flag) ? (-121f) : (-111f));
		missionRecommendedPart.transform.localPosition = missionRecommendedPart.transform.localPosition.ReplaceY((!flag) ? (-276f) : (-236f));
		missionLeaderboardsParent.transform.localPosition = missionLeaderboardsParent.transform.localPosition.ReplaceY((!flag) ? 270f : 290f);
		missionLeaderboardsBorder.transform.localScale = missionLeaderboardsBorder.transform.localScale.ReplaceY((!flag) ? 372f : 332f);
		missionLeaderboardsScrollviewParent.transform.localPosition = missionLeaderboardsScrollviewParent.transform.localPosition.ReplaceY((!flag) ? (-258f) : (-238f));
		missionLeaderboardsPanel.clipRange = missionLeaderboardsPanel.clipRange.ReplaceW((!flag) ? 364f : 324f);
		missionLeaderboardsCollider.size = missionLeaderboardsCollider.size.ReplaceY((!flag) ? 364f : 324f);
		missionHighscoreParent.transform.localPosition = missionHighscoreParent.transform.localPosition.ReplaceY((!flag) ? (-276f) : (-236f));
		playCoop.transform.localPosition = playCoop.transform.localPosition.ReplaceY((!isHeroicMission) ? 148f : 245f);
		playButton.transform.localPosition = playButton.transform.localPosition.ReplaceY((!isHeroicMission) ? 148f : 245f);
	}

	private void FillHeroicInformations(Mission mission)
	{
		bool flag = mission.heroicType == MissionsManager.HeroicType.Coop;
		bool completedInHeroic = mission.completedInHeroic;
		int midnight = Singleton<BeanstalkServerManager>.instance.midnight;
		bool flag2 = midnight < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		heroicCoop.SetActive(flag);
		heroicSingle.gameObject.SetActive(!flag);
		heroicButtonLabel.text = Localization.Localize((!flag) ? "ID_PLAYHEROIC" : "ID_HEROICCOOP");
		MiscTools.SetUILabelRescale(heroicButtonLabel, 69f, 30f, 510);
		heroicButtonCollider.enabled = !completedInHeroic;
		heroicButtonPanel.alpha1 = ((!completedInHeroic) ? 1f : mNotActiveAlpha);
		heroicCompleted.SetActive(completedInHeroic);
		heroicRewards.SetActive(!completedInHeroic);
		heroicCountdownTitle.text = Localization.Localize((!completedInHeroic) ? "ID_DAILYMISSION" : "ID_NEWHEROIC");
		MiscTools.SetUILabelRescale(heroicCountdownTitle, 35f, 20f, 300);
		if (!completedInHeroic)
		{
			bool flag3 = mission.heroicRewardGold > 0;
			int num = mission.heroicRewardWB + mission.heroicRewardGold;
			heroicGoldIcon.gameObject.SetActive(flag3);
			heroicWarbucksIcon.gameObject.SetActive(!flag3);
			heroicRewardValue.text = MiscTools.FormatBigNumber(num);
		}
		if (flag2)
		{
			heroicCountdown.StopCountingTo();
			WinStreakCounter winStreakCounter = heroicCountdown;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(HeroicDeadlineEnd));
			heroicCountdown.counterLabel.text = string.Empty;
		}
		else
		{
			heroicCountdown.StartCountingTo(midnight);
			WinStreakCounter winStreakCounter2 = heroicCountdown;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Remove(winStreakCounter2.winStreakTimer, new Action(HeroicDeadlineEnd));
			WinStreakCounter winStreakCounter3 = heroicCountdown;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Combine(winStreakCounter3.winStreakTimer, new Action(HeroicDeadlineEnd));
		}
	}

	private void HeroicDeadlineEnd()
	{
		InitGUIValues();
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	internal void ShowMissionLeaderboards(IEnumerable<DatabasePlayerMissionLeaderboard> missionLeaderboards)
	{
		pooledGrid.MakeEmpty();
		mLeaderboards.Clear();
		mRecords.Clear();
		if (missionLeaderboards != null)
		{
			foreach (DatabasePlayerMissionLeaderboard missionLeaderboard in missionLeaderboards)
			{
				if (mRecords.ContainsKey(missionLeaderboard.id))
				{
					Debug.LogError("Mission Leaderboard got more records of player " + missionLeaderboard.name);
					continue;
				}
				int missionScore = missionLeaderboard.GetMissionScore(mMissionIndex);
				if (missionScore >= 1)
				{
					mLeaderboards.Add(MissionLeaderboardData.Load(missionLeaderboard, mMissionIndex));
					mRecords.Add(missionLeaderboard.id, missionLeaderboard);
				}
			}
		}
		mRecords.Clear();
		int num = mLeaderboards.FindIndex((MissionLeaderboardData r1) => r1.data.id == GameLoginManager.instance.playerId);
		if (num == -1)
		{
			Debug.Log("Mission Leaderboard - adding myself to leaderboards");
			mLeaderboards.Add(MissionLeaderboardData.Load(new DatabasePlayerMissionLeaderboard
			{
				id = GameLoginManager.instance.playerId,
				name = GameLoginManager.currentPlayer.name,
				fbId = GameLoginManager.currentPlayer.facebookId,
				decalData = CamosManager.instance.data,
				missionData = null
			}, mMissionIndex));
		}
		mLeaderboards.Sort(SortFunctionLeaderboardsPlayers);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			while (mLeaderboards.Count < 3)
			{
				mLeaderboards.Add(MissionLeaderboardData.CreateInvite());
			}
		}
		pooledGrid.init(mLeaderboards.Count, InstantiateLeaderboard, LeaderboardFree, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
	}

	private int SortFunctionLeaderboardsPlayers(MissionLeaderboardData a, MissionLeaderboardData b)
	{
		if (a.score != b.score)
		{
			return b.score.CompareTo(a.score);
		}
		if (a.data == null || string.IsNullOrEmpty(a.data.name))
		{
			return -1;
		}
		if (b.data == null || string.IsNullOrEmpty(b.data.name))
		{
			return 1;
		}
		return a.data.name.CompareTo(b.data.name);
	}

	private void LeaderboardFree(Transform obj)
	{
		if (obj != null)
		{
			MissionLeaderboardRecord component = obj.GetComponent<MissionLeaderboardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private Transform InstantiateLeaderboard(int index)
	{
		if (index >= 0 && index < mLeaderboards.Count)
		{
			MissionLeaderboardRecord missionLeaderboardRecord = mPool.InstantiateAsChild(missionLeaderboardRecordPrefab, pooledGrid.gameObject, index.ToString("D5")) as MissionLeaderboardRecord;
			if (missionLeaderboardRecord != null)
			{
				if (mLeaderboards[index].isInvite)
				{
					missionLeaderboardRecord.InitializeInvite();
				}
				else
				{
					missionLeaderboardRecord.InitializePlayer(mLeaderboards[index].data, mLeaderboards[index].score, index + 1);
				}
				return missionLeaderboardRecord.transform;
			}
		}
		return null;
	}

	private void EnemyFree(Transform obj)
	{
		if (obj != null)
		{
			MissionEnemyRecord component = obj.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private Transform InstantiateEnemy(int index)
	{
		if (index >= 0 && index < mMissionEnemies.Count)
		{
			MissionEnemyRecord missionEnemyRecord = mPool.InstantiateAsChild(missionEnemiesRecordPrefab, pooledEnemiesGrid.gameObject, index.ToString("D2")) as MissionEnemyRecord;
			if (missionEnemyRecord != null)
			{
				missionEnemyRecord.Initialize(mMissionEnemies[index]);
				return missionEnemyRecord.transform;
			}
		}
		return null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(backButton.gameObject);
	}

	public Texture2D GetBossTexture()
	{
		return mBossTexture;
	}
}
